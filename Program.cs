using System.Runtime.Versioning;

class Program
{
    [SupportedOSPlatform("windows")]
    static void Main()
    {
        string appName = "Football Manager 2024";
        string? installPath = Configuration.GetInstallPath(appName);

        if (!string.IsNullOrEmpty(installPath))
        {
            Console.WriteLine($"Install path of {appName}: {installPath}");
        }
        else
        {
            Console.WriteLine($"{appName} is not installed.");
        }
    }
}