using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannusWallPaper
{
    public class IsolatedStorageManager
    {
        private const string OAUTHTOKENFILENAME = "OAuthToken.txt";
        private const string OAUTHTOKENSECRETFILENAME = "OAuthTokenSecret.txt";
        private const string FLICKRISAUTHENTICATED = "Flickr.txt";
        private readonly string _oauthTokenFilePath;
        private readonly string _oauthTokenSecretFilePath;
        private readonly string _flickrFilePath;

        public IsolatedStorageManager()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _oauthTokenFilePath = Path.Combine(appDataPath, OAUTHTOKENFILENAME);
            _oauthTokenSecretFilePath = Path.Combine(appDataPath, OAUTHTOKENSECRETFILENAME);
            _flickrFilePath = Path.Combine(appDataPath, FLICKRISAUTHENTICATED);
        }

        public void DeleteIsolatedStorage()
        {
            File.Delete(_oauthTokenFilePath);
            File.Delete(_oauthTokenSecretFilePath);
            File.Delete(_flickrFilePath);
        }

        internal string OAuthToken
        {
            get
            {
                return ReadFromTextFile(_oauthTokenFilePath);
            }
            set
            {
                WriteToTextFile(_oauthTokenFilePath, value);
            }
        }

        internal string OAuthTokenSecret
        {
            get
            {
                return ReadFromTextFile(_oauthTokenSecretFilePath);
            }
            set
            {
                WriteToTextFile(_oauthTokenSecretFilePath, value);
            }
        }
        private string ReadFromTextFile(string file)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            return File.ReadAllText(file);
        }

        private void WriteToTextFile(string file, string content)
        {
            File.WriteAllText(file, content);
        }
    }
}
