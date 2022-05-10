using System.Runtime.InteropServices;

namespace SilverFormsUtils
{
    /// <summary>
    /// <a href="https://github.com/MicrosoftDocs/windows-uwp/blob/docs/hub/apps/desktop/modernize/apply-rounded-corners.md"/>
    /// </summary>
    public static class RoundTheWindow
    {
        public enum DWMWINDOWATTRIBUTE
        {
            DWMWA_WINDOW_CORNER_PREFERENCE = 33
        }

        public enum RoundPreference
        {
            Default = 0,
            DoNotRound = 1,
            Round = 2,
            RoundSmall = 3
        }

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern long DwmSetWindowAttribute(IntPtr hwnd,
                                                         DWMWINDOWATTRIBUTE attribute,
                                                         ref RoundPreference pvAttribute,
                                                         uint cbAttribute);

        public static long RoundWindow(IntPtr Pointer, RoundPreference preference)
        {
            return DwmSetWindowAttribute(Pointer, DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE, ref preference, sizeof(uint));
        }
    }
}