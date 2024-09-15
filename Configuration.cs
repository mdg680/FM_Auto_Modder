using System.Runtime.Versioning;
using Microsoft.Win32;
class Configuration
{
    /* Get the install path of the specified application.
     * 
     * appName: The name of the application.
     * 
     * Returns: The install path of the application if found; otherwise, null.
     */
    [SupportedOSPlatform("windows")]
    public static string? GetInstallPath(string appName) {
        string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
        RegistryKey? key = Registry.LocalMachine.OpenSubKey(registryKey);
        
        if (key != null) {
            foreach (string subkeyName in key.GetSubKeyNames()) {
                RegistryKey? subkey = key.OpenSubKey(subkeyName);
                
                if (subkey != null) {
                    string? displayName = subkey.GetValue("DisplayName") as string;
                    if (!string.IsNullOrEmpty(displayName) && displayName.Contains(appName)) {
                        return subkey.GetValue("InstallLocation") as string;
                    }
                }
            }
        }
        return string.Empty;
    }
}