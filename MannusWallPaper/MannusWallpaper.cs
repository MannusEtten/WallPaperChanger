using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Mannus.Library.Utilities;
using MannusWallPaper;
using Mannus.Library.Extensions;
namespace WallpaperChanger
{
    public class Form1 : System.Windows.Forms.Form
    {
        private IContainer components;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem afsluitenToolStripMenuItem;
        private FlickrManager _flickrManager = new FlickrManager();
        private LibraryManager _libraryManager = new LibraryManager();
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator1;
        private DesktopManager _desktopManager;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripComboBox wallPaperModesComboBox;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox toolStripTextBox2;
        private ToolStripComboBox fixedWallPapersComboBox;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem configureMenuItem;
        private DesktopHidingChecker _desktopHidingChecker;

        public Form1()
        {
            InitializeComponent();
            _desktopManager = new DesktopManager();
            _desktopHidingChecker = new DesktopHidingChecker();
            SetWallPaperModes();
            SetFixedWallPapers();
            EnableComboBox();
            SetDesktop();
        }

        private void SetFixedWallPapers()
        {
            foreach (WallPaperElement wallpaper in MannusWallPaperConfiguration.GetConfig().WallPapers)
            {
                fixedWallPapersComboBox.Items.Add(wallpaper.Description);
            }
        }

        private void SetWallPaperModes()
        {
            List<EnumWallPaperMode> modes = new List<EnumWallPaperMode>();
            var useFlickr = false;
            var useLibraries = false;
            if (FlickrConfiguration.GetConfig().UseFlickr)
            {
                modes.Insert(0,EnumWallPaperMode.Flickr);
                useFlickr = true; 
            }
            if (MannusWallPaperConfiguration.GetConfig().ImageLibraries.Count > 0)
            {
                modes.Add(EnumWallPaperMode.Libraries);
            }
            if (MannusWallPaperConfiguration.GetConfig().WallPapers.Count > 0)
            {
                modes.Add(EnumWallPaperMode.FixedWallPaper);
                useLibraries = true;
            }
            if (useFlickr && useLibraries)
            {
                modes.Insert(0, EnumWallPaperMode.FlickrAndLibraries);
            }
            modes.ForEach(m => wallPaperModesComboBox.Items.Add(m));
            if (modes.Count > 0)
            {
                wallPaperModesComboBox.SelectedIndex = 0;
            }
        }

        private void SetDesktop()
        {
            var mode = GetSelectedWallPaperMode();
            switch(mode)
            {
                case EnumWallPaperMode.FixedWallPaper:
                    _flickrManager.Stop();
                    // libraries.stop
                    SetDesktopWithFixedWallPaper();
                    break;
                case EnumWallPaperMode.Flickr:
                    _desktopManager.ShowDesktop();
                    TaskBar.Show();
                    _flickrManager.Start();
                    _libraryManager.Stop();
                    break;
                case EnumWallPaperMode.FlickrAndLibraries:
                    _desktopManager.ShowDesktop();
                    TaskBar.Show();
                    var currentWallPaperMode = GetRandomWallPaperMode();
                    if (currentWallPaperMode == EnumWallPaperMode.Libraries)
                    {
                        _flickrManager.Stop();
                        _libraryManager.Start();
                    }
                    else
                    {
                        _flickrManager.Start();
                        _libraryManager.Stop();
                    }
                    break;
                case EnumWallPaperMode.Libraries:
                    _desktopManager.ShowDesktop();
                    TaskBar.Show();
                    _flickrManager.Stop();
                    _libraryManager.Start();
                    break;
            }

        }

        private EnumWallPaperMode GetRandomWallPaperMode()
        {
            Random random = new Random();
            bool randomNumber = random.Next(0,1) == 1;
            return randomNumber ? EnumWallPaperMode.Flickr : EnumWallPaperMode.Libraries;
        }

        private void SetDesktopWithFixedWallPaper()
        {
            var fixedWallPaperKey = fixedWallPapersComboBox.Text;
            if (string.IsNullOrEmpty(fixedWallPaperKey))
            {
                return;
            }
            WallPaperElement configuration = null;
            foreach (WallPaperElement element in MannusWallPaperConfiguration.GetConfig().WallPapers)
            {
                if (element.Description.Equals(fixedWallPaperKey))
                {
                    configuration = element;
                }
            }
            _desktopManager.SetDesktopImage(configuration.Path);
            Color color = (Color)TypeDescriptor.GetConverter(typeof(Color)).ConvertFromString(configuration.DesktopBackColor);
            _desktopManager.SetDesktopColor(color);
            var showDesktop = configuration.EmptyDesktop;
            var hideIcons = configuration.HideIcons;
                if (!showDesktop)
                {
                    TaskBar.Show();
                    _desktopManager.ShowDesktop();
                    if (hideIcons)
                    {
                        _desktopManager.ToggleDesktopIcons();
                    }
                }
                else
                {
                    TaskBar.Hide();
                    _desktopManager.HideDesktop();
                    _desktopHidingChecker.CreateCheckFile();
                    _desktopHidingChecker.CheckIfDesktopMustBeShownAgain();
                    if (hideIcons)
                    {
                        _desktopManager.ToggleDesktopIcons();
                    }
                }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.wallPaperModesComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.fixedWallPapersComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "Mannus Wallpaper";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Mannus Wallpaper";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.wallPaperModesComboBox,
            this.toolStripTextBox2,
            this.fixedWallPapersComboBox,
            this.toolStripSeparator2,
            this.configureMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem3,
            this.toolStripSeparator3,
            this.afsluitenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 200);
            this.contextMenuStrip1.Text = "Hoofdmenu";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(140, 16);
            this.toolStripTextBox1.Text = "Wallpaper Change Mode";
            // 
            // wallPaperModesComboBox
            // 
            this.wallPaperModesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wallPaperModesComboBox.Name = "wallPaperModesComboBox";
            this.wallPaperModesComboBox.Size = new System.Drawing.Size(140, 23);
            this.wallPaperModesComboBox.SelectedIndexChanged += new System.EventHandler(this.wallPaperModesComboBox_SelectedIndexChanged);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BackColor = System.Drawing.Color.White;
            this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox2.Enabled = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 16);
            this.toolStripTextBox2.Text = "Fixed Wallpaper";
            // 
            // fixedWallPapersComboBox
            // 
            this.fixedWallPapersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fixedWallPapersComboBox.Enabled = false;
            this.fixedWallPapersComboBox.Name = "fixedWallPapersComboBox";
            this.fixedWallPapersComboBox.Size = new System.Drawing.Size(121, 23);
            this.fixedWallPapersComboBox.SelectedIndexChanged += new System.EventHandler(this.fixedWallPapersComboBox_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem3.Text = "About";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.afsluitenToolStripMenuItem.Text = "Exit";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // configureMenuItem
            // 
            this.configureMenuItem.Name = "configureMenuItem";
            this.configureMenuItem.Size = new System.Drawing.Size(200, 22);
            this.configureMenuItem.Text = "Configure";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(225, 34);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WallPaperChanger";
            this.TopMost = true;
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        [STAThread]
        private static void Main()
        {
            Application.Run(new Form1());
        }

        private void afsluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private EnumWallPaperMode GetSelectedWallPaperMode()
        {
            var text = wallPaperModesComboBox.Text;
            var enumValue = EnumHelper.ParseTextToEnumValue<EnumWallPaperMode>(text);
            return enumValue;
        }

        private void EnableComboBox()
        {
            var mode = GetSelectedWallPaperMode();
            fixedWallPapersComboBox.Enabled = mode == EnumWallPaperMode.FixedWallPaper;
            if (mode == EnumWallPaperMode.FixedWallPaper)
            {
                fixedWallPapersComboBox.BackColor = Color.LightGreen;
                SetDesktop();
            }
            else
            {
                fixedWallPapersComboBox.BackColor = Color.White;
            }
        }

        private void wallPaperModesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableComboBox();
            SetDesktop();
        }

        private void fixedWallPapersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDesktop();
        }
    }
}