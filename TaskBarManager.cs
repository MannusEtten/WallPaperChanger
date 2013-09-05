using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannusWallPaper
{
    internal class TaskBarManager
    {
        private Desktop _desktop;

        public TaskBarManager()
        {
            _desktop = new Desktop();
        }

        public void ShowTaskBar()
        {
            TaskBar.Show();
            _desktop.ShowDesktop(true);
        }

        public void HideTaskBar()
        {
            TaskBar.Hide();
            _desktop.ShowDesktop(false);
        }
    }
}