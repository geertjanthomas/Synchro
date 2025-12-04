using System.Globalization;

namespace LocalDeploy.Helper;

public static class ObjectExtensions
{
    public static string SafeSql(this object o)
    {
        switch (o)
        {
            case null:
                return "NULL";
            case DBNull:
                return "NULL";
            case bool b:
                // bool => bit
                return b ? "1" : "0";
            case DateTime d:
                // Proper DATETIME format
                return $"'{d:yyyy-MM-dd HH:mm:ss}'";
            case string s:
                // Escape single quote character
                return $"'{s.Replace("'", "''")}'";
            case Guid g:
                return $"'{g}'";
            case decimal dc:
                // Enforce . decimal character
                return dc.ToString(new NumberFormatInfo { NumberDecimalSeparator = "." });
            default:
                return o.ToString() ?? string.Empty;
        }
    }
}