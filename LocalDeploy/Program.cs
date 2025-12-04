using LocalDeploy.Forms;
using Microsoft.Extensions.Configuration;

// Comment for sync test

namespace LocalDeploy;

internal static class Program
{
#pragma warning disable CS8618
    public static IConfiguration Configuration;
#pragma warning restore CS8618

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        try
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new Start());
    }
}