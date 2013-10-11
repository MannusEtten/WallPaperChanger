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
            set { this["path"] = value; }
        }

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
            set { this["hideicons"] = value; }
        }

        public void SetKey(string key)
        {
            this["key"] = key;
        }

        public override string ElementName
        {
            get { return "wallpaper"; }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            var listOfProperties = this.GetType().GetProperties();
            foreach (var property in listOfProperties)
            {
                var hasConfigurationPropertyAttribute = Attribute.IsDefined(property, typeof(ConfigurationPropertyAttribute));
                if (hasConfigurationPropertyAttribute)
                {
                    var value = property.GetValue(this);
                    stringBuilder.AppendFormat("{0}={1}||", property.Name.ToLowerInvariant(), value);
                }
            }
            return stringBuilder.ToString();
        }

        public static WallPaperElement CreateFromString(string wallpaperConfiguration)
        {
            string[] configurationItems = wallpaperConfiguration.Split("||".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> propertyValues = new Dictionary<string, string>();
            foreach (var configurationItem in configurationItems)
            {
                string[] keyAndValue = configurationItem.Split("=".ToCharArray());
                propertyValues.Add(keyAndValue[0], keyAndValue[1]);
            }
            WallPaperElement wallPaperElement = new WallPaperElement();
            var listOfProperties = wallPaperElement.GetType().GetProperties();
            foreach (var property in listOfProperties)
            {
                var hasConfigurationPropertyAttribute = Attribute.IsDefined(property, typeof(ConfigurationPropertyAttribute));
                if (hasConfigurationPropertyAttribute)
                {
                    Type propertyType = property.PropertyType;
                    var propertyName = property.Name.ToLowerInvariant();
                    var propertyValue = propertyValues[propertyName];
                    if (propertyType == typeof(bool))
                    {
                        var boolean = bool.Parse(propertyValue);
                        property.SetValue(wallPaperElement, boolean);
                    }
                    else
                    {
                        if (propertyName.Equals("key"))
                        {
                            wallPaperElement.SetKey(propertyValue);
                        }
                        else
                        {
                            property.SetValue(wallPaperElement, propertyValue);
                        }
                    }
                }
            }
            return wallPaperElement;
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