using System;
using Microsoft.Win32;

class Program
{
    static void Main()
    {
        string appName = "Football Manager 2024"; // Replace with the actual application name
        string installPath = GetInstallPath(appName);

        if (!string.IsNullOrEmpty(installPath))
        {
            Console.WriteLine($"Install path of {appName}: {installPath}");
        }
        else
        {
            Console.WriteLine($"{appName} is not installed.");
        }
    }

    static string GetInstallPath(string appName)
    {
        string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
        {
            if (key != null)
            {
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                    {
                        if (subkey != null)
                        {
                            string displayName = subkey.GetValue("DisplayName") as string;
                            if (!string.IsNullOrEmpty(displayName) && displayName.Contains(appName))
                            {
                                return subkey.GetValue("InstallLocation") as string;
                            }
                        }
                    }
                }
            }
        }
        return null;
    }
}