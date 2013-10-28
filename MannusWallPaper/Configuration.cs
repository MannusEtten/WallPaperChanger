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
    public sealed class FlickrConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("apikey", IsRequired = true)]
        public string ApiKey
        {
            get { return this["apikey"] as string; }
            set { this["apikey"] = value; }
        }

        [ConfigurationProperty("apisharedsecret", IsRequired = true)]
        public string ApiSharedSecret
        {
            get { return this["apisharedsecret"] as string; }
            set { this["apisharedsecret"] = value; }
        }

        [ConfigurationProperty("changetimeinminutes", IsRequired = true)]
        public int FlickrChangeTime
        {
            get { return (int)this["changetimeinminutes"]; }
            set { this["changetimeinminutes"] = value; }
        }

        [ConfigurationProperty("pagesize", IsRequired = true)]
        public int PageSize
        {
            get { return (int)this["pagesize"]; }
            set { this["pagesize"] = value; }
        }

        [ConfigurationProperty("seturl", IsRequired = true)]
        public string SetUrl
        {
            get { return this["seturl"] as string; }
            set { this["seturl"] = value; }
        }

        [ConfigurationProperty("useflickr", IsRequired = true)]
        public bool UseFlickr
        {
            get { return (bool)this["useflickr"]; }
            set { this["useflickr"] = value; }
        }

        [ConfigurationProperty("userid", IsRequired = true)]
        public string UserId
        {
            get { return this["userid"] as string; }
            set { this["userid"] = value; }
        }

        public static FlickrConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("Flickr") as FlickrConfiguration;
        }
    }

    public sealed class ImageLibrary : ConfigurationElementBase
    {
        public override string ElementName
        {
            get { return "library"; }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return this["path"] as string; }
            set { this["path"] = value; }
        }
    }

    public sealed class MannusWallPaperConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("imagelibraries")]
        public GenericConfigurationElementCollection<ImageLibrary> ImageLibraries
        {
            get { return (GenericConfigurationElementCollection<ImageLibrary>)this["imagelibraries"]; }
            set { this["imagelibraries"] = value; }
        }

        [ConfigurationProperty("wallpapers")]
        public GenericConfigurationElementCollection<WallPaperElement> WallPapers
        {
            get { return (GenericConfigurationElementCollection<WallPaperElement>)this["wallpapers"]; }
            set { this["wallpapers"] = value; }
        }

        [ConfigurationProperty("watermarkfilters")]
        public GenericConfigurationElementCollection<WaterMarkFilter> WaterMarkFilters
        {
            get { return (GenericConfigurationElementCollection<WaterMarkFilter>)this["watermarkfilters"]; }
            set { this["watermarkfilters"] = value; }
        }

        public static MannusWallPaperConfiguration GetConfig()
        {
            return ConfigurationManager.GetSection("MannusWallPaper") as MannusWallPaperConfiguration;
        }
    }
    public sealed class WallPaperElement : ConfigurationElementBase
    {
        [ConfigurationProperty("description", IsRequired = true)]
        public string Description
        {
            get { return this["description"] as string; }
            set { this["description"] = value; }
        }

        [ConfigurationProperty("desktopbackcolor", IsRequired = true)]
        public string DesktopBackColor
        {
            get { return this["desktopbackcolor"] as string; }
            set { this["desktopbackcolor"] = value; }
        }

        public override string ElementName
        {
            get { return "wallpaper"; }
        }

        [ConfigurationProperty("emptydesktop", IsRequired = true)]
        public bool EmptyDesktop
        {
            get { return (bool)this["emptydesktop"]; }
            set { this["emptydesktop"] = value; }
        }

        [ConfigurationProperty("hideicons", IsRequired = false)]
        public bool HideIcons
        {
            get { return (bool)this["hideicons"]; }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get { return this["path"] as string; }
            set { this["path"] = value; }
        }
    }

    public sealed class WaterMarkFilter : ConfigurationElementBase
    {
        public override string ElementName
        {
            get { return "filter"; }
        }

        [ConfigurationProperty("prefix", IsRequired = true)]
        public string Prefix
        {
            get { return this["prefix"] as string; }
            set { this["prefix"] = value; }
        }
    }
}