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
        }

        private void LoadNameFilters()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("My first column Name");
            dt.Rows.Add(new object[] { "Item 1" });
            dt.Rows.Add(new object[] { "Item number 2" });
            dt.Rows.Add(new object[] { "Item number three" });

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
            throw new NotImplementedException();
        }
    }
}