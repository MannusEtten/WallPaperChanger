using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Timers;
using FlickrNet;

namespace MannusWallPaper
{
    public class FlickrManager
    {
        private Timer timer = new Timer();
        private DesktopManager _desktopManager;

        public FlickrManager()
        {
            _desktopManager = new DesktopManager();
        }
        internal void StopFlickrModus()
        {
            timer.Enabled = false;
            timer.Stop();
        }

        internal void StartFlickrModus()
        {
            int minutes = FlickrConfiguration.GetConfig().FlickrChangeTime;
            int seconds = 60;
            int second = 1000;
            timer.Interval = minutes * seconds * second;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            SetRandomWallPaper();
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SetRandomWallPaper();
        }

        private void SetRandomWallPaper()
        {
            string fileName = GetRandomPhoto();
            if (!string.IsNullOrEmpty(fileName))
            {
                string fileLocation = DownloadFile(fileName);
                // TODO naar MannusLibrary verplaatsen
                Color color = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString("White");
                _desktopManager.SetDesktopColor(color);
                _desktopManager.SetDesktopImage(fileLocation);
            }
        }

        private string DownloadFile(string fileName)
        {
            string uriString = Assembly.GetExecutingAssembly().CodeBase;
            Uri uri = new Uri(uriString);
            string directory = Path.GetDirectoryName(uri.LocalPath);
            WebClient client = new WebClient();
            string newFileName = Path.Combine(directory, "flickr.jpg");
            client.DownloadFile(fileName, newFileName);
            return newFileName;
        }

        private string GetRandomPhoto()
        {
            List<Photoset> set = new FlickrGalleries.Sets().GetPhotoSets();
            List<Photo> setphotos = new List<Photo>();
            List<PhotoInfo> photos = new List<PhotoInfo>();
            Random random = new Random();
            if (set != null)
            {
                // nummer set
                int r1 = random.Next(0, set.Count - 1);
                setphotos = new FlickrGalleries.Photos().GetPhotosBySet(set[r1].PhotosetId, string.Empty);
                // nummer foto
                int r2 = random.Next(0, setphotos.Count - 1);
                return setphotos[r2].LargeUrl;
            }
            return null;
        }
    }
}