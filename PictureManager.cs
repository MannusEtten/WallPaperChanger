using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using Mannus.Library.Logging;

namespace MannusWallPaper
{
    public abstract class PictureManager
    {
        private Timer timer = new Timer();
        private DesktopManager _desktopManager;
        protected ILogger _logger;
        private int _intervalInMinutes;

        public PictureManager(int intervalInMinutes)
        {
            _intervalInMinutes = intervalInMinutes;

            _logger = Logger.GetLogger();
            _desktopManager = new DesktopManager();
        }

        public void Start()
        {
            int seconds = 60;
            int second = 1000;
            timer.Interval = _intervalInMinutes * seconds * second;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            SetRandomWallPaper();
            timer.Enabled = true;
            timer.Start();
        }

        public void Stop()
        {
            timer.Enabled = false;
            timer.Stop();
        }

        protected void SetWallPaper(string fileLocation)
        {
            Color color = Color.FromName("White");
            _desktopManager.SetDesktopColor(color);
            _desktopManager.SetDesktopImage(fileLocation);
        }

        protected abstract void SetRandomWallPaper();

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SetRandomWallPaper();
        }
    }
}