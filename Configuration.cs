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

        public bool UseFlickr
        {
            get
            {
                return bool.Parse(ConfigurationManager.AppSettings["useflickrwallpaper"]);
            }
        }

        [ConfigurationProperty("wallpapers")]
        public GenericConfigurationElementCollection<WallPaperElement> WallPapers
        {
            get { return (GenericConfigurationElementCollection<WallPaperElement>)this["wallpapers"]; }
        }

        [ConfigurationProperty("watermarkfilters")]
        public GenericConfigurationElementCollection<WaterMarkFilter> WaterMarkFilters
        {
            get { return (GenericConfigurationElementCollection<WaterMarkFilter>)this["watermarkfilters"]; }
        }
    }

    public sealed class WaterMarkFilter : ConfigurationElementBase
    {
        [ConfigurationProperty("prefix", IsRequired = true)]
        public string Prefix
        {
            get { return this["prefix"] as string; }
        }

        public override string ElementName
        {
            get { return "filter"; }
        }
    }

    public sealed class WallPaperElement : ConfigurationElementBase
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

    public sealed class FlickrConfiguration : ConfigurationSection
    {
        public static FlickrConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("Flickr") as FlickrConfiguration;
        }

        [ConfigurationProperty("flickrsettings")]
        public GenericConfigurationElementCollection<FlickrSettingElement> FlickrSettings
        {
            get { return (GenericConfigurationElementCollection<FlickrSettingElement>)this["flickrsettings"]; }
        }

        public int FlickrChangeTime
        {
            get
            {
                return int.Parse(FlickrSettings["changetimeinminutes"].Value);
            }
        }
    }

    public sealed class FlickrSettingElement : ConfigurationElementBase
    {
        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return this["value"] as string; }
        }

        public override string ElementName
        {
            get { return "flickrsetting"; }
        }
    }
}