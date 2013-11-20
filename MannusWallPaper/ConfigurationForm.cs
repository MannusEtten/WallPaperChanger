using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Mannus.Library.Configuration;
using Mannus.Library.Utilities;
using FlickrNet;
using System.Diagnostics;
namespace MannusWallPaper
{
    public partial class ConfigurationForm : Form
    {
        private FlickrManager _flickrManager;
        private Flickr _flickr;
        private IsolatedStorageManager _storageManager;
        private OAuthRequestToken _token;
        public ConfigurationForm()
        {
            InitializeComponent();
            _flickrManager = new FlickrManager();
            _flickr = new Flickr("04b183e090d0f3eaaf84240f18a7dc2a", "5a1315102ff1e88f");
            _storageManager = new IsolatedStorageManager();
            _token = null;
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
            textBoxFlickrInterval.Text = ConfigurationManager.AppSettings["changetimeinminutes"];
            textBoxSetUrl.Text = FlickrConfiguration.GetConfig().SetUrl;
            textBoxUserId.Text = FlickrConfiguration.GetConfig().UserId;
            textBoxPageSize.Text = FlickrConfiguration.GetConfig().PageSize.ToString();
            SetStateOfFlickrTextBoxes();
        }

        private void LoadLibraries()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("path");
            var list = MannusWallPaperConfiguration.GetConfig().ImageLibraries.Items.ToList();
            list.ToList().ForEach(x => dt.Rows.Add(x.Path));
            dataGridLibraries.DataSource = dt;
            dataGridLibraries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            dataGridWallpapers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridWallpapers.Columns[0].Width = 100;
            dataGridWallpapers.Columns[1].Width = 160;
            dataGridWallpapers.Columns[2].Width = 160;
            dataGridWallpapers.Columns[3].Width = 75;
        }

        private void LoadNameFilters()
        {
            DataTable dt = new DataTable();
            DataColumn column = new DataColumn("prefix");
            column.AllowDBNull = false;
            column.DataType = typeof(string);
            column.Unique = true;
            dt.Columns.Add(column);
            var list = MannusWallPaperConfiguration.GetConfig().WaterMarkFilters.Items.Select(x => x.Prefix);
            list.ToList().ForEach(x => dt.Rows.Add(new object[] { x }));
            dataGridFilters.DataSource = dt;
            dataGridFilters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            config.AppSettings.Settings["changetimeinminutes"].Value = textBoxFlickrInterval.Text;
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

        private void SetStateOfFlickrTextBoxes()
        {
            textBoxPageSize.Enabled = useFlickrCheckbox.Checked;
            textBoxSetUrl.Enabled = useFlickrCheckbox.Checked;
            textBoxUserId.Enabled = useFlickrCheckbox.Checked;
            var isolatedStorageManager = new IsolatedStorageManager();
            var flickrIsAuthenticated = _flickrManager.LoginToFlickr();
            flickrAuthenticationGroupBox.Enabled = useFlickrCheckbox.Checked && !flickrIsAuthenticated;
            flickrSettingsGroupbox.Enabled = useFlickrCheckbox.Checked && flickrIsAuthenticated;
            button2.Enabled = txtVerifierCode.Text.Length > 10;
        }

        private void useFlickrCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            SetStateOfFlickrTextBoxes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AuthenticationStepOne();
        }

        private void AuthenticationStepOne()
        {
            OAuthRequestToken requestToken = _flickr.OAuthGetRequestToken("oob");
            string url = _flickr.OAuthCalculateAuthorizationUrl(requestToken.Token, AuthLevel.Write);
            _token = requestToken;
            Process.Start(url);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AuthenticationStepTwo();
        }

        private void AuthenticationStepTwo()
        {
                var token = _storageManager.OAuthToken;
                var accessToken = _flickr.OAuthGetAccessToken(_token, txtVerifierCode.Text);
                _storageManager.OAuthToken = accessToken.Token;
                _storageManager.OAuthTokenSecret = accessToken.TokenSecret;
                _flickr.OAuthAccessToken = accessToken.Token;
                _flickr.OAuthAccessTokenSecret = accessToken.TokenSecret;
                flickrAuthenticationGroupBox.Enabled = false;
                flickrSettingsGroupbox.Enabled = true;
        }

        private void txtVerifierCode_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = txtVerifierCode.Text.Length > 10;
        }
    }
}