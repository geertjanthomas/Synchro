using Newtonsoft.Json;

namespace LocalDeploy.Forms;

public class BaseForm : Form 
{
    protected string LocalOveridesFile = string.Empty;

    protected Dictionary<string, string> ReadLocalOverrides(string filename)
    {
        CheckBaseFile(filename);

        string overridesJson = UnCommentedLines(filename);
        var variables = JsonConvert.DeserializeObject<Dictionary<string, string>>(overridesJson);

        if (variables == null) throw new Exception("Could not deserialize Json dictionary");

        return variables;
    }

    protected void ObjectToJsonFile(object data, string filename)
    {
        var jsonText = JsonConvert.SerializeObject(data, Formatting.Indented);
        File.WriteAllText(filename, jsonText);
    }

    protected void CheckBaseFile(string filename)
    {
        // If we don't have a valid file, copy the base template or base file and use that
        if (!File.Exists(filename))
        {
            string baseFilename = filename.Replace(".json", "_base.json");
            File.Copy(baseFilename, filename);
        }
    }

    private static string UnCommentedLines(string filename)
    {
        return string.Join("\r\n", File.ReadAllLines(filename).Where(line => !line.TrimStart().StartsWith("#")));
    }


}