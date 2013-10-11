using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Net;
using System.Reflection;
using System.Timers;
using FlickrNet;
using Mannus.Library.Logging;
using Mannus.Library.Utilities;

namespace MannusWallPaper
{
    public class FlickrManager : PictureManager
    {
        private const string UNAVAILABLEPHOTONAME = "photo_unavailable.gif";

        public FlickrManager() : base(FlickrConfiguration.GetConfig().FlickrChangeTime) {}

        protected override void SetRandomWallPaper()
        {
            var photo = GetRandomPhoto();
            if (photo != null)
            {
                _logger.LogDebug(photo.LargeUrl);
                string fileLocation = DownloadFile(photo.LargeUrl);
                if (!string.IsNullOrEmpty(fileLocation))
                {
                    WaterMarker waterMarker = new WaterMarker();
                    waterMarker.AddWaterMark(fileLocation, photo.Title);
                    SetWallPaper(fileLocation);
                }
            }
        }

        private string DownloadFile(string photoUrl)
        {
            string uriString = Assembly.GetExecutingAssembly().CodeBase;
            Uri uri = new Uri(uriString);
            string directory = Path.GetDirectoryName(uri.LocalPath);
            MannusWebClient client = new MannusWebClient();
            string newFileName = Path.Combine(directory, "flickr.jpg");
            client.DownloadFile(photoUrl, newFileName);
            var responseUri = client.ResponseUri;
            var path = responseUri.AbsolutePath.ToLowerInvariant();
            if (path.Contains(UNAVAILABLEPHOTONAME))
            {
                _logger.LogInfo("no new wallpaper. Photo is unavailable /r/n {0}", photoUrl);
                return null;
            }
            return newFileName;
        }

        private Photo GetRandomPhoto()
        {
            List<Photoset> set = new FlickrGalleries.Sets().GetPhotoSets();
            Random random = new Random();
            if (set != null)
            {
                // nummer set
                int r1 = random.Next(0, set.Count - 1);
                var setphotos = new FlickrGalleries.Photos().GetPhotosBySet(set[r1].PhotosetId, string.Empty);
                // nummer foto
                int r2 = random.Next(0, setphotos.Count - 1);
                return setphotos[r2];
            }
            return null;
        }
    }
}