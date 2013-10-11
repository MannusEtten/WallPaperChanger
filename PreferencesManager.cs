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
            XElement wallPaperXml = new XElement("wallpaper");
            string xmlValue = wallPaper != null ? wallPaper.ToString() : "null";
            wallPaperXml.Value = xmlValue;
            wallPaperDocument.Add(modeXml);
            wallPaperDocument.Add(wallPaperXml);
            wallPaperDocument.Save(GetFilePath());
        }

        public WallPaperPreference GetWallPaperPreferences()
        {
            XElement wallPaperDocument = XElement.Load(GetFilePath());
            var mode = EnumHelper.ParseTextToEnumValue<EnumWallPaperMode>(wallPaperDocument.Element("wallpapermode").Value);
            var wallpaper = wallPaperDocument.Element("wallpaper").Value;
            var wallpaperConfiguration = WallPaperElement.CreateFromString(wallpaper);
            return new WallPaperPreference() { WallPaper = wallpaperConfiguration, WallPaperMode = mode };
        }
    }
}