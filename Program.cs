using System.Diagnostics;
using System.Runtime.Versioning;

class Program
{
    [SupportedOSPlatform("windows")]
    static void Main()
    {
        string appName = "Football Manager 2024";
        string? installPath = InstallUtils.GetInstallPath(appName);
        if (installPath == null)
        {
            Console.WriteLine($"{appName} is not installed.");
            return;
        }
        string[] files = InstallUtils.GetFilesFromRegex(installPath, "*.lnc");

        if (!string.IsNullOrEmpty(installPath))
        {
            // Debug output
            Console.WriteLine($"Install path of {appName}: {installPath}");
            foreach (string file in files)
            {
                Console.WriteLine($"Found file: {file}");
            }
        }
        else
        {
            Console.WriteLine($"{appName} is not installed.");
        }
    }
}