using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mannus.Library.Utilities;

namespace MannusWallPaper
{
    public class PreferencesManager
    {
        private const string PREFERENCESFILENAME = "MannusWallPaperChangerPreferences.xml";
        
        private string GetFilePath()
        {
            var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData, Environment.SpecialFolderOption.Create);
            var filename = Path.Combine(directory, PREFERENCESFILENAME);
            if (!File.Exists(filename))
            {
                File.Create(filename);
            }
            return filename;
        }

        public void SetWallPaperPreferences(EnumWallPaperMode mode, WallPaperElement wallPaper = null)
        {
            XElement wallPaperDocument = new XElement("MannusWallPaperChanger");
            XElement modeXml = new XElement("wallpapermode", mode.ToString());
            string xmlValue = wallPaper != null ? wallPaper.Key : "null";
            XElement wallPaperXml = new XElement("wallpaper", xmlValue);
            wallPaperDocument.Add(modeXml);
            wallPaperDocument.Add(wallPaperXml);
            wallPaperDocument.Save(GetFilePath());
        }

        public WallPaperPreference GetWallPaperPreferences()
        {
            XElement wallPaperDocument = XElement.Load(GetFilePath());
            var mode = EnumHelper.ParseTextToEnumValue<EnumWallPaperMode>(wallPaperDocument.Element("wallpapermode").Value);
            var wallpaperKey = wallPaperDocument.Element("wallpaper").Value;
            if (!string.Equals(wallpaperKey, "null", StringComparison.InvariantCultureIgnoreCase))
            {
                var wallpaper = MannusWallPaperConfiguration.GetConfig().WallPapers[wallpaperKey];
                return new WallPaperPreference() { WallPaper = wallpaper, WallPaperMode = mode };
            }
            return new WallPaperPreference() { WallPaper = null, WallPaperMode = mode };
        }
    }
}