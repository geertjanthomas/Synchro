namespace LocalDeploy.Helper;

public class Options
{
    public Dictionary<string, object>? DeploymentOptions { get; set; }
}
public class CrdwOptions : Options
{
    public Dictionary<string, bool> Databases { get; set; } = new();
    public Dictionary<string, bool> Ispacs { get; set; } = new();
}
public class LrdwOptions : CrdwOptions
{
    public Dictionary<string, bool> CrdwDatabases { get; set; } = new();
}