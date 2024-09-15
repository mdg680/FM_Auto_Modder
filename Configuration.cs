using Microsoft.Win32;

class Configuration
{
    public static string GetInstallPath(string appName)
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