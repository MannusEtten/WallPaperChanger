using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Timers;
using FlickrNet;

namespace MannusWallPaper
{
    public class WallPaperChanger
    {
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_SENDCHANGE = 0x01 | 0x02;
        private Timer timer = new Timer();

        private void SetWallPaper(String fileName)
        {
            int nResult = WinAPI.SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, fileName, SPIF_SENDCHANGE);
        }

        internal void SetEsriNederland()
        {
            timer.Enabled = false;
            timer.Stop();
            string picturename = ConfigurationManager.AppSettings["esrinlwallpaper"];
            string picturePath = Assembly.GetExecutingAssembly().FindFileNextToAssembly(picturename);
            SetWallPaper(picturePath);
        }

        internal void StartFlickrModus()
        {
            int minutes = MannusWallPaperConfiguration.GetConfig().FlickrChangeTime;
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
                SetWallPaper(fileLocation);
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

        public string GetRandomPhoto()
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

        internal void SetBasketBalNieuws()
        {
            timer.Enabled = false;
            timer.Stop();
            string picturename = ConfigurationManager.AppSettings["basketbalnieuwswallpaper"];
            string picturePath = Assembly.GetExecutingAssembly().FindFileNextToAssembly(picturename);
            SetWallPaper(picturePath);
        }
    }
}