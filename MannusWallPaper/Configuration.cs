using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using Mannus.Library.Configuration;
using Mannus.Library.Utilities;

namespace MannusWallPaper
{
    public sealed class MannusWallPaperConfiguration : ConfigurationSection
    {
        public static MannusWallPaperConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("MannusWallPaper") as MannusWallPaperConfiguration;
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

        [ConfigurationProperty("imagelibraries")]
        public GenericConfigurationElementCollection<ImageLibrary> ImageLibraries
        {
            get { return (GenericConfigurationElementCollection<ImageLibrary>)this["imagelibraries"]; }
        }
    }

    public sealed class ImageLibrary : ConfigurationElementBase
    {
        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return this["path"] as string; }
        }

        public override string ElementName
        {
            get { return "library"; }
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
        public bool EmptyDesktop
        {
            get { return (bool)this["emptydesktop"]; }
        }

        [ConfigurationProperty("hideicons", IsRequired = false)]
        public bool HideIcons
        {
            get { return (bool)this["hideicons"]; }
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

        [ConfigurationProperty("changetimeinminutes", IsRequired = true)]
        public int FlickrChangeTime
        {
            get { return (int)this["changetimeinminutes"]; }
        }

        [ConfigurationProperty("useflickr", IsRequired = true)]
        public bool UseFlickr
        {
            get { return (bool)this["useflickr"]; }
        }
    }
}