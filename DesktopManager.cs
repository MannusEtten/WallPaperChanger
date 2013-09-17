using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        internal void SetDesktopColor(Color color)
        {
            int[] elements = { COLOR_DESKTOP };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            bool nResult = WinAPI.SetSysColors(elements.Length, elements, colors);
        }
    }
}