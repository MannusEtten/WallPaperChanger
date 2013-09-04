using System.Runtime.InteropServices;

namespace MannusWallPaper
{
    internal static class TaskBar
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        internal static int Handle
        {
            get
            {
                return FindWindow("Shell_TrayWnd", "");
            }
        }

        internal static int StartHandle
        {
            get
            {
                return FindWindow("Button", "Start");
            }
        }

        public static void Show()
        {
            ShowWindow(Handle, SW_SHOW);
            ShowWindow(StartHandle, SW_SHOW);
        }

        public static void Hide()
        {
            ShowWindow(Handle, SW_HIDE);
            ShowWindow(StartHandle, SW_HIDE);
        }
    }
}