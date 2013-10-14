using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MannusWallPaper
{
   internal class DesktopHidingChecker
    {
       private Timer _timer;
       private string _filename;

       public DesktopHidingChecker()
       {
           _timer = new Timer(5000);
           _timer.AutoReset = true;
           _timer.Enabled = true;
           _timer.Elapsed += _timer_Elapsed;
           _filename = ConfigurationManager.AppSettings["locationofenablefile"];
       }

       void _timer_Elapsed(object sender, ElapsedEventArgs e)
       {
            if (!File.Exists(_filename))
            {
               _timer.Stop();
               TaskBar.Show();
               var desktopManager = new DesktopManager();
               desktopManager.ShowDesktop();
            }
       }

        internal void CreateCheckFile()
        {
            if(File.Exists(_filename))
            {
                File.Delete(_filename);
            }
            File.WriteAllText(_filename,"MannusWallPaper");
        }

        public void CheckIfDesktopMustBeShownAgain()
        {
            _timer.Start();
        }
    }
}