using Microsoft.Win32;
namespace TanganTask.Config
{
    public static class PasswordRegistry
    {
        public static string GetPassword(string userRoot, string subkey, string keyName)
        {
            return (string)Registry.GetValue(userRoot, subkey, keyName);
        }
    }
}