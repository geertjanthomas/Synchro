using System.Data;
using System.Reflection;
using System.Text;

namespace LocalDeploy.Helper;

public class LocalSddLoader
{
    private readonly Action<string, bool> _callback;
    private readonly string _devServer;
    private readonly string _sddServer;
    private Thread? _workerThread;
    private Exception? _threadException;
    private SqlRunner? _metaCrdwRunner;
    private SqlRunner? _metaLrdwRunner;
    private SqlRunner? _sddRunner;
    private SqlRunner? _rdwRunner;

    public LocalSddLoader(string sqlServer = @".\VM_DEV_01", Action<string, bool>? callback = null)
    {
        _callback = callback ?? ((_, _) => { });
        _devServer = sqlServer;
        _sddServer = sqlServer;
    }

    public void LoadRdwConfiguration()
    {
        StartWorkerThread(StartRdwConfigurationWork);
    }

    public void LoadRdwStaticData()
    {
        StartWorkerThread(StartRdwStaticDataWork);
    }

    public void LoadLrdwReferenceData()
    {
        StartWorkerThread(StartLrdwReferenceDataWork);
    }

    private void Callback(string message) => _callback(message, false);
    private void CallbackEnd(string message) => _callback(message, true);

    private void StartWorkerThread(Action action)
    {
        _workerThread = new Thread(_ => action())
        {
            IsBackground = true
        };
        _workerThread.Start();
    }

    private void StartLrdwReferenceDataWork()
    {
        try
        {
            CheckDatabaseConnections();
            if (_rdwRunner == null) return;

            var assembly = Assembly.GetExecutingAssembly();
            var names = assembly.GetManifestResourceNames();
            var resourceName = $"{assembly.GetName().Name}.LoadLrdwReferenceData.sql";
            using var stream = assembly.GetManifestResourceStream(resourceName)!;
            using var streamReader = new StreamReader(stream, Encoding.UTF8);

            var sqlText = streamReader.ReadToEnd();
            var recordCounts = _rdwRunner.ExecuteTable(sqlText);

            recordCounts?.Rows.Cast<DataRow>().ToList().ForEach(row =>
            {
                Callback($"{row["TableName"]} - {row["RecordCount"]} records");
            });


            CallbackEnd("Done loading LRDW Static Data");
        }
        catch (Exception e)
        {
            CallbackEnd($"ERROR: {e}");
            _threadException = e;
        }
    }

    private void StartRdwStaticDataWork()
    {
        try
        {
            CheckDatabaseConnections();
            if (_rdwRunner == null) return;
            if (_metaCrdwRunner == null) return;
            if (_sddRunner == null) return;

            var lineageId = (long)(_rdwRunner.ExecuteScalar("SELECT NEXT VALUE FOR [Audit].[LineageID_Seq]") ?? 0);

            var metaData = _metaCrdwRunner.ExecuteTable("EXEC MetaData.GetReferenceStagingSourceQueries");
            if (metaData != null)
            {
                foreach (DataRow row in metaData.Rows)
                {
                    var sourceQuery = row["SourceQuery"].ToString();
                    var targetSchemaName = row["SourceSchemaName"].ToString();
                    var targetTableName = row["SourceTableName"].ToString();
                    if (sourceQuery == null) throw new Exception($"No source query found in MetaData.ADFSimpleCopy for table {targetSchemaName}.{targetTableName}");

                    _rdwRunner.ExecuteSql($"TRUNCATE TABLE [{targetSchemaName}].[{targetTableName}]");

                    var sddData = _sddRunner.ExecuteTable(sourceQuery);
                    if (sddData != null)
                    {
                        Callback($"Loading [{targetSchemaName}].[{targetTableName}] ({sddData.Rows.Count} records)");

                        var columnTemplate = string.Join(", ",
                            sddData.Columns.Cast<DataColumn>().Select(c => $"[{c.ColumnName}]"));
                        var valuesTemplate = string.Join(", ",
                            sddData.Columns.Cast<DataColumn>()
                                .Select((_, i) => $"{{{i}}}"));

                        columnTemplate = $"{columnTemplate}, LineageID, LoadDate";
                        valuesTemplate = $"({valuesTemplate}, {lineageId}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";

                        var template =
                            $"INSERT INTO [{targetSchemaName}].[{targetTableName}] ({columnTemplate}) VALUES ";

                        var batchSize = 1000;
                        var batch = new List<string>();
                        foreach (DataRow sddRow in sddData.Rows)
                        {
                            var values = string.Format(valuesTemplate,
                                sddRow.ItemArray.Select(o => o?.SafeSql()).Cast<object>().ToArray());
                            batch.Add(values);
                            if (batch.Count == batchSize)
                            {
                                var sqlBatch = template + string.Join(", ", batch);
                                _rdwRunner.ExecuteSql(sqlBatch);
                                Callback($"{batch.Count} inserted");
                                batch = new List<string>();
                            }
                        }

                        if (batch.Any())
                        {
                            var sql = template + string.Join(", ", batch);
                            _rdwRunner.ExecuteSql(sql);
                            Callback($"{batch.Count} inserted");
                        }
                    }
                }
            }
            Callback("Set status for SddCrdwStaticData to 'SDDStaging READY'");
            Callback("Please wait for package 'ReferenceDataVaultLoadMaster.dtsx' to finish.");
            _rdwRunner.ExecuteSql("EXEC WorkFlow.SetCurrentStatus 'SddCrdwStaticData', NULL, 'READY', 'SDDStaging READY', 'Dashboard load', @id", [new() { ParameterName = "@id", Value = lineageId }]);
            CallbackEnd("Done loading CRDW Static Data");
        }
        catch (Exception e)
        {
            CallbackEnd($"ERROR: {e}");
            _threadException = e;
        }
    }

    private void StartRdwConfigurationWork()
    {
        try
        {
            CheckDatabaseConnections();
            if (_rdwRunner == null) return;
            if (_metaCrdwRunner == null) return;
            if (_sddRunner == null) return;

            var lineageId = (long)(_rdwRunner.ExecuteScalar("SELECT NEXT VALUE FOR [Audit].[LineageID_Seq]") ?? 0);

            var metaData = _metaCrdwRunner.ExecuteTable("SELECT * FROM MetaData.ADFSimpleCopy");
            if (metaData != null)
            {
                foreach (DataRow row in metaData.Rows)
                {
                    var sourceQuery = row["SourceQuery"].ToString();
                    var targetSchemaName = row["TargetSchemaName"].ToString();
                    var targetTableName = row["TargetTableName"].ToString();
                    if (sourceQuery == null) throw new Exception($"No source query found in MetaData.ADFSimpleCopy for table {targetSchemaName}.{targetTableName}");

                    _rdwRunner.ExecuteSql($"TRUNCATE TABLE [{targetSchemaName}].[{targetTableName}]");

                    var sddData = _sddRunner.ExecuteTable(sourceQuery);
                    if (sddData != null)
                    {
                        Callback(
                            $"Loading [{targetSchemaName}].[{targetTableName}] ({sddData.Rows.Count} records)");

                        var columnTemplate = string.Join(", ",
                            sddData.Columns.Cast<DataColumn>().Select(c => $"[{c.ColumnName}]"));
                        var valuesTemplate = string.Join(", ",
                            sddData.Columns.Cast<DataColumn>()
                                .Select((_, i) => $"{{{i}}}"));

                        columnTemplate = $"{columnTemplate}, LineageID, LoadDate";
                        valuesTemplate = $"({valuesTemplate}, {lineageId}, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}')";

                        var template =
                            $"INSERT INTO [{targetSchemaName}].[{targetTableName}] ({columnTemplate}) VALUES ";

                        var batchSize = 1000;
                        var batch = new List<string>();
                        foreach (DataRow sddRow in sddData.Rows)
                        {
                            var values = string.Format(valuesTemplate,
                                sddRow.ItemArray.Select(o => o?.SafeSql()).Cast<object>().ToArray());
                            batch.Add(values);
                            if (batch.Count == batchSize)
                            {
                                var sqlBatch = template + string.Join(", ", batch);
                                _rdwRunner.ExecuteSql(sqlBatch);
                                Callback($"{batch.Count} inserted");
                                batch = new List<string>();
                            }
                        }

                        if (batch.Any())
                        {
                            var sql = template + string.Join(", ", batch);
                            _rdwRunner.ExecuteSql(sql);
                            Callback($"{batch.Count} inserted");
                        }
                    }
                }

                Callback("Running WorkFlow.StatusHouseKeeping");
                _rdwRunner.ExecuteProcedure("WorkFlow.StatusHouseKeeping", new Dictionary<string, object>());
            }

            CallbackEnd("Done loading model RDW_Configuration");
        }
        catch (Exception e)
        {
            CallbackEnd($"ERROR: {e}");
            _threadException = e;
        }
    }

    public void WaitToFinish()
    {
        _workerThread?.Join(TimeSpan.FromMinutes(10));
        if (_threadException != null) throw _threadException;
    }

    private void CheckDatabaseConnections()
    {
        Callback("Checking database connections");

        _metaCrdwRunner = new SqlRunner(_devServer, "CRDW_MetaData");
        _metaLrdwRunner = new SqlRunner(_devServer, "LRDW_MetaData");
        _rdwRunner = new SqlRunner(_devServer, "LRDW_DataVault");
        _sddRunner = new SqlRunner(_sddServer, "StaticDataDepot");

        var metaCrdwOk = CheckConnection(_metaCrdwRunner);
        if (!metaCrdwOk.ok)
        {
            _metaCrdwRunner = null;
            throw new Exception($"Bad MetaData connection: {metaCrdwOk.message}");
        }
        var metaLrdwOk = CheckConnection(_metaLrdwRunner);
        if (!metaLrdwOk.ok)
        {
            _metaLrdwRunner = null;
            throw new Exception($"Bad MetaData connection: {metaLrdwOk.message}");
        }
        var sddOk = CheckConnection(_sddRunner);
        if (!sddOk.ok)
        {
            _sddRunner = null;
            throw new Exception($"Bad SDD connection: {sddOk.message}");
        }
        var rdwOk = CheckConnection(_rdwRunner);
        if (!rdwOk.ok)
        {
            _rdwRunner = null;
            throw new Exception($"Bad RDW connection: {metaCrdwOk.message}");
        }
    }

    private static (bool ok, string message) CheckConnection(SqlRunner sqlRunner)
    {
        try
        {
            sqlRunner.ExecuteScalar("SELECT 1 as One");
            return (true, string.Empty);
        }
        catch (Exception e)
        {
            return (false, e.Message);
        }
    }
}