using Microsoft.Data.SqlClient;
using System.Data;

namespace LocalDeploy.Helper;

public class SqlRunner
{
    private readonly string? _databaseName;
    private readonly string? _serverInstance;
    private SqlConnection? _transactionConnection;
    private string? _transactionName;
    private string? _connectionStringOverrride;

    public SqlRunner()
    {

    }

    public SqlRunner(string databaseName)
    {
        _databaseName = databaseName;
    }

    public SqlRunner(string serverInstance, string databaseName)
    {
        _databaseName = databaseName;
        _serverInstance = serverInstance;
    }

    public enum ResultType
    {
        None,
        Value,
        Set
    }

    public void OverrideConnectionString(string connectionString)
    {
        _connectionStringOverrride = connectionString;
    }

    protected string GetConnectionString()
    {
        if (!string.IsNullOrEmpty(_connectionStringOverrride))
        {
            return _connectionStringOverrride;
        }

        var connectionstring = @"Data Source=server\instance;Initial Catalog=database;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True;";

        var dict = connectionstring
            .Split([';'], StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Split('='))
            .ToDictionary(a => a[0].ToUpper(), a => a[1]);

        if (_databaseName != null)
        {
            dict["INITIAL CATALOG"] = _databaseName;
        }
        if (_serverInstance != null)
        {
            dict["DATA SOURCE"] = _serverInstance;
        }

        connectionstring = string.Join(";", dict.Select(kvp => $"{kvp.Key}={kvp.Value}"));

        return connectionstring;
    }

    public object? ExecuteSql(string sql, SqlParameter[]? parameters = null, bool keepOpen = false)
    {
        return ExecuteSql(GetConnectionString(), ResultType.None, sql, parameters, keepOpen);
    }

    public DataTable? ExecuteTable(string sql, SqlParameter[]? parameters = null)
    {
        return ExecuteSql(GetConnectionString(), ResultType.Set, sql, parameters) as DataTable;
    }

    public object? ExecuteScalar(string sql, SqlParameter[]? parameters = null)
    {
        return ExecuteSql(GetConnectionString(), ResultType.Value, sql, parameters);
    }

    public object? ExecuteSql(string connectionString, ResultType resultType, string sql, SqlParameter[]? parameters = null, bool keepOpen = false)
    {
        SqlConnection connection;
        if (keepOpen)
        {
            _transactionConnection ??= new SqlConnection(connectionString.ToLower().Replace("multipleactiveresultsets=true", ""));
            connection = _transactionConnection;
        }
        else
        {
            connection = _transactionConnection ?? new SqlConnection(connectionString);
        }


        try
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            var cmd = new SqlCommand(sql, connection)
            {
                CommandTimeout = 1000
            };
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            switch (resultType)
            {
                case ResultType.None:
                    return cmd.ExecuteNonQuery();
                case ResultType.Value:
                    return cmd.ExecuteScalar();
                case ResultType.Set:
                    var dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
            }

            return null;
        }
        catch (SqlException sqlException)
        {
            throw new Exception($"ERROR - message: {sqlException.Message} - connection: {connectionString} - SQL: {sql}", sqlException);
        }
        finally
        {
            if (!keepOpen) connection.Close();
        }
    }

    public void ExecuteProcedure(string procedureName, Dictionary<string, object> parameters)
    {
        ExecuteProcedure(GetConnectionString(), procedureName, parameters);
    }

    public void ExecuteProcedure(string connectionString, string procedureName, Dictionary<string, object> parameters)
    {
        try
        {
            using var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand
            {
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 3600,
                Connection = connection
            };

            foreach (var p in parameters)
            {
                cmd.Parameters.Add(new SqlParameter(p.Key, p.Value));
            }

            connection.Open();

            cmd.ExecuteNonQuery();
        }
        catch (SqlException sqlException)
        {
            throw new Exception($"ERROR - connection: {connectionString} - procedure: {procedureName}", sqlException);
        }
    }

    public void BeginTransaction(string transactionName = "CRDW")
    {
        _transactionName = transactionName;
        ExecuteSql("BEGIN TRANSACTION @name", [new SqlParameter { ParameterName = "@name", Value = transactionName }], true);
    }

    public void CommitTransaction()
    {
        if (string.IsNullOrEmpty(_transactionName)) throw new Exception("Cannot commit a transaction that was not started.");

        ExecuteSql($"COMMIT TRANSACTION {_transactionName}");
        _transactionConnection?.Close();
        _transactionConnection = null;
        _transactionName = null;
    }

    public void RollbackTransaction()
    {
        if (string.IsNullOrEmpty(_transactionName)) throw new Exception("Cannot rollback a transaction that was not started.");

        ExecuteSql($"ROLLBACK TRANSACTION {_transactionName}");
        _transactionConnection?.Close();
        _transactionConnection = null;
        _transactionName = null;
    }
}