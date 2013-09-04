using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Mannus.Library.Configuration;

namespace MannusWallPaper
{
    public sealed class MannusWallPaperConfiguration : ConfigurationSection
    {
        public static MannusWallPaperConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("MannusWallPaper") as MannusWallPaperConfiguration;
        }

        public int FlickrChangeTime
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["flickrchangetimeinminutes"]);
            }
        }

        [ConfigurationProperty("wallpapers")]
        public GenericConfigurationElementCollection<WallPaperElement> WallPapers
        {
            get { return (GenericConfigurationElementCollection<WallPaperElement>)this["wallpapers"]; }
        }
    }

    public class WallPaperElement : ConfigurationElementBase
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return this["path"] as string; }
        }

        [ConfigurationProperty("description", IsRequired = true)]
        public string Description
        {
            get { return this["description"] as string; }
        }

        [ConfigurationProperty("desktopbackcolor", IsRequired = true)]
        public string DesktopBackColor
        {
            get { return this["desktopbackcolor"] as string; }
        }

        [ConfigurationProperty("emptydesktop", IsRequired = true)]
        public string EmptyDesktop
        {
            get { return this["emptydesktop"] as string; }
        }

        public override string ElementName
        {
            get { return "wallpaper"; }
        }
    }
}