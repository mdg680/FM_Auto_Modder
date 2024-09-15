using System;
using System.Xml.Serialization;
using Microsoft.Win32;
using static Configuration;

class Program
{
    static void Main()
    {
        string appName = "Football Manager 2024";
        string installPath = Configuration.GetInstallPath(appName);

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