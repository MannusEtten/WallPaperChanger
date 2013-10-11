using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace MannusWallPaper
{
    internal class DesktopManager
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_SENDCHANGE = 0x01 | 0x02;
        public const int COLOR_DESKTOP = 1;
        private const int WM_COMMAND = 0x111;

        [DllImport("user32.dll", SetLastError = true)] 
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)] 
        private static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);
        
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);


        private Desktop _desktop;

        public DesktopManager()
        {
            _desktop = new Desktop();
        }
        
        public void ShowDesktop()
        {
            _desktop.ShowDesktop(true);
        }
        
        public void HideDesktop()
        {
            _desktop.ShowDesktop(false);
        }
        
        public void SetDesktopImage(string path)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", "0");
            key.SetValue(@"TileWallpaper", "0");
            key.Close();
            int nResult = WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path, SPIF_SENDCHANGE);
        }

        [Obsolete("niet gebruiken want werkt toch niet")]
        public void ToggleDesktopIcons()
        {
            /*
            var toggleDesktopCommand = new IntPtr(0x7402);
            IntPtr hWnd = GetWindow(FindWindow("Progman", "Program Manager"), GetWindow_Cmd.GW_CHILD);
            SendMessage(hWnd, WM_COMMAND, toggleDesktopCommand, IntPtr.Zero);
             */
        }

        internal void SetDesktopColor(Color color)
        {
            int[] elements = { COLOR_DESKTOP };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            bool nResult = WinAPI.SetSysColors(elements.Length, elements, colors);
        }

        enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
    }
}