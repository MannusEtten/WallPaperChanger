using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MannusWallPaper
{
    internal class IsolatedStorageManager
    {
        private const string OAUTHTOKENFILENAME = "OAuthToken.txt";
        private const string OAUTHTOKENSECRETFILENAME = "OAuthTokenSecret.txt";
        private readonly string _oauthTokenFilePath;
        private readonly string _oauthTokenSecretFilePath;

        public IsolatedStorageManager()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _oauthTokenFilePath = Path.Combine(appDataPath, OAUTHTOKENFILENAME);
            _oauthTokenSecretFilePath = Path.Combine(appDataPath, OAUTHTOKENSECRETFILENAME);
        }

        internal void DeleteIsolatedStorage()
        {
            File.Delete(_oauthTokenFilePath);
            File.Delete(_oauthTokenSecretFilePath);
        }

        internal string OAuthToken
        {
            get
            {
                if(!File.Exists(_oauthTokenFilePath))
                {
                    return null;
                }
                return File.ReadAllText(_oauthTokenFilePath);
            }
            set
            {
                File.WriteAllText(_oauthTokenFilePath, value);
            }
        }

        internal string OAuthTokenSecret
        {
            get
            {
                if (!File.Exists(_oauthTokenSecretFilePath))
                {
                    return null;
                }
                return File.ReadAllText(_oauthTokenSecretFilePath);
            }
            set
            {
                File.WriteAllText(_oauthTokenSecretFilePath, value);
            }
        }
    }
}
