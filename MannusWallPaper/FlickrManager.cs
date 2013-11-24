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
using System.Diagnostics;
using System.IO.IsolatedStorage;

namespace MannusWallPaper
{
    public class FlickrManager : PictureManager
    {
        // TODO watermarkfilters ook gebruiken voor library
        private const string UNAVAILABLEPHOTONAME = "photo_unavailable.gif";
        private readonly Flickr _flickr;
        private readonly IsolatedStorageManager _isolatedStorage;

        public FlickrManager()
        {
            _flickr = new Flickr("04b183e090d0f3eaaf84240f18a7dc2a", "5a1315102ff1e88f");
            _isolatedStorage = new IsolatedStorageManager();
        }
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
            var userId = FlickrConfiguration.GetConfig().UserId;
            var sets = _flickr.PhotosetsGetList(userId);
            Random random = new Random();
            if (sets.Count > 0)
            {
                // nummer set
                int r1 = random.Next(0, sets.Count - 1);
                var setphotos  = sets[r1];
                // nummer foto
                int r2 = random.Next(0, setphotos.NumberOfPhotos - 1);
                var photos = _flickr.PhotosetsGetPhotos(setphotos.PhotosetId);
                return photos[r2];
            }
            return null;
        }

        public bool LoginToFlickr()
        {
            var token = _isolatedStorage.OAuthToken;
            var secret = _isolatedStorage.OAuthTokenSecret;
            if(token == null && secret == null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(secret))
            {
                _flickr.OAuthAccessToken = token;
                _flickr.OAuthAccessTokenSecret = secret;
                var result = _flickr.AuthOAuthCheckToken();
                var loginSuccessFull = result.Token.Equals(_flickr.OAuthAccessToken);
                if (!loginSuccessFull)
                {
                    _isolatedStorage.DeleteIsolatedStorage();
                    return false;
                }
            }
            return true;
        }
    }
}