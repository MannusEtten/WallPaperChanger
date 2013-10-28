using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Configuration;
using Mannus.Library.Configuration;
using Mannus.Library.Utilities;
namespace MannusWallPaper
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            LoadNameFilters();
            LoadWallPapers();
            LoadLibraries();
            LoadGeneralSettings();
        }

        private void LoadGeneralSettings()
        {
            textBoxLocationEnableFile.Text = ConfigurationManager.AppSettings["locationofenablefile"];
            useFlickrCheckbox.Checked = FlickrConfiguration.GetConfig().UseFlickr;
            textBoxFlickrInterval.Text = FlickrConfiguration.GetConfig().FlickrChangeTime.ToString();
            textBoxAPIKey.Text = FlickrConfiguration.GetConfig().ApiKey;
            textBoxAPISharedSecret.Text = FlickrConfiguration.GetConfig().ApiSharedSecret;
            textBoxSetUrl.Text = FlickrConfiguration.GetConfig().SetUrl;
            textBoxUserId.Text = FlickrConfiguration.GetConfig().UserId;
            textBoxPageSize.Text = FlickrConfiguration.GetConfig().PageSize.ToString();
            flickrGroupBox.Enabled = useFlickrCheckbox.Checked;
        }

        private void LoadLibraries()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("path");
            var list = MannusWallPaperConfiguration.GetConfig().ImageLibraries.Items.ToList();
            list.ToList().ForEach(x => dt.Rows.Add(x.Path));
            dataGridLibraries.DataSource = dt;
        }

        private void LoadWallPapers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("path");
            dt.Columns.Add("description");
            dt.Columns.Add("emptydesktop");
            var list = MannusWallPaperConfiguration.GetConfig().WallPapers.Items.ToList();
            list.ToList().ForEach(x => dt.Rows.Add(x.Key, x.Path, x.Description, x.EmptyDesktop));
            dataGridWallpapers.DataSource = dt;
        }

        private void LoadNameFilters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("prefix");
            var list = MannusWallPaperConfiguration.GetConfig().WaterMarkFilters.Items.Select(x => x.Prefix);
            list.ToList().ForEach(x => dt.Rows.Add(new object[] { x }));
            dataGridFilters.DataSource = dt;
        }

        private void useFlickrCheckbox_Click(object sender, EventArgs e)
        {
            flickrGroupBox.Enabled = useFlickrCheckbox.Checked;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            SaveData();
            this.Close();
        }

        private void SaveData()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["locationofenablefile"].Value = textBoxLocationEnableFile.Text;
            var flickrSection = (FlickrConfiguration)config.GetSection("Flickr");
            flickrSection.UseFlickr = useFlickrCheckbox.Checked;
            flickrSection.FlickrChangeTime = int.Parse(textBoxFlickrInterval.Text);
            flickrSection.ApiKey = textBoxAPIKey.Text;
            flickrSection.ApiSharedSecret = textBoxAPISharedSecret.Text;
            flickrSection.SetUrl = textBoxSetUrl.Text;
            flickrSection.UserId = textBoxUserId.Text;
            flickrSection.PageSize = int.Parse(textBoxPageSize.Text);
            var wallpaperSection = (MannusWallPaperConfiguration)config.GetSection("MannusWallPaper");
            SaveFilters(wallpaperSection);
            SaveLibraries(wallpaperSection);
            SaveWallPapers(wallpaperSection);
             config.Save(ConfigurationSaveMode.Modified);
              ConfigurationManager.RefreshSection("Flickr");
              ConfigurationManager.RefreshSection("appSettings");
        }

        private void SaveFilters(MannusWallPaperConfiguration wallpaperSection)
        {
            DataTable filters = dataGridFilters.DataSource as DataTable;
            var list = new GenericConfigurationElementCollection<WaterMarkFilter>();
            list.Clear();
            foreach (DataRow datarow in filters.Rows)
            {
                var item = new WaterMarkFilter();
                item.Key = Randomizer.RandomString(10);
                item.Prefix = datarow.ItemArray[0].ToString();
                list.Add(item);
            }
            wallpaperSection.WaterMarkFilters = list;
        }

        private void SaveLibraries(MannusWallPaperConfiguration wallpaperSection)
        {
            DataTable libraries = dataGridLibraries.DataSource as DataTable;
            var list = new GenericConfigurationElementCollection<ImageLibrary>();
            list.Clear();
            foreach (DataRow datarow in libraries.Rows)
            {
                var item = new ImageLibrary();
                item.Key = Randomizer.RandomString(10);
                item.Path = datarow.ItemArray[0].ToString();
                list.Add(item);
            }
            wallpaperSection.ImageLibraries = list;
        }

        private void SaveWallPapers(MannusWallPaperConfiguration wallpaperSection)
        {
            DataTable wallpapers = dataGridWallpapers.DataSource as DataTable;
            var list = new GenericConfigurationElementCollection<WallPaperElement>();
            list.Clear();
            foreach (DataRow datarow in wallpapers.Rows)
            {
                var item = new WallPaperElement();
                item.Key = datarow.ItemArray[0].ToString();
                item.Path = datarow.ItemArray[1].ToString();
                item.Description = datarow.ItemArray[2].ToString();
                item.EmptyDesktop = bool.Parse(datarow.ItemArray[3].ToString());
                item.DesktopBackColor = "White";
                list.Add(item);
            }
            wallpaperSection.WallPapers = list;
        }
    }
}