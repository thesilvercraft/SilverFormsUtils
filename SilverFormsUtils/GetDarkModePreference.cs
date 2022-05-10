using Microsoft.Win32;

namespace SilverFormsUtils
{
    /// <summary>
    /// thanks to <a href="https://stackoverflow.com/a/62282762" /> and <a href="https://stackoverflow.com/a/72172845" />
    /// </summary>
    public class GetDarkModePreference
    {
        public static bool ShouldIUseDarkMode()
        {
            int? value = (int?)Registry.GetValue(hive + "\\" + keypath, keyname, null);
            return value != null && value.Value == 0;
        }

        private const string hive = "HKEY_CURRENT_USER";
        private const string keypath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Themes\Personalize";
        private const string keyname = "AppsUseLightTheme";
    }
}