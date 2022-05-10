using System.Runtime.InteropServices;

namespace SilverFormsUtils
{
    /// <summary>
    /// <a href="https://stackoverflow.com/a/9753302"/> but better (modified)
    /// </summary>
    public static class ProgressBarExtensions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        public static void SetState(this ProgressBar pBar, ProgressBarState state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }

        public enum ProgressBarState : int
        {
            Normal = 1, Green = 1,
            Error = 2, Red = 2,
            Warning = 3, Yellow = 3
        }
    }
}