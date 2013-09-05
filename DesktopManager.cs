using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannusWallPaper
{
    internal class DesktopManager
    {
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
        }

        internal void SetDesktopColor(string color)
        {   
        }
    }
}