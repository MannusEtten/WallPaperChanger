using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MannusWallPaper;

namespace WallpaperChanger
{
    public class Form1 : System.Windows.Forms.Form
    {
        private bool _taskBarIsShown;
        private IContainer components;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem afsluitenToolStripMenuItem;
        private WallPaperChanger changer = new WallPaperChanger();
        private string _shortCutFileName;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private DesktopManager _desktopManager;

        public Form1()
        {
            InitializeComponent();
            _desktopManager = new DesktopManager();
            _taskBarIsShown = true;
            ToggleTaskBar();
            AddMenuItems();
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            _shortCutFileName = Path.Combine(deskDir, "BasketBalNieuws.url");
        }

        private void AddMenuItems()
        {
            foreach (WallPaperElement item in MannusWallPaperConfiguration.GetConfig().WallPapers)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = item.Description;
                menuItem.Tag = item.Key;
                contextMenuStrip1.Items.Insert(0, menuItem);
                menuItem.Click += menuItem_Click;
            }
            ToolStripMenuItem flickrMenuItem = new ToolStripMenuItem();
            flickrMenuItem.Text = "Flick'r";
            flickrMenuItem.Tag = "flickr";
            flickrMenuItem.Checked = true;
            flickrMenuItem.Click += menuItem_Click;
            contextMenuStrip1.Items.Insert(MannusWallPaperConfiguration.GetConfig().WallPapers.Count, flickrMenuItem);
        }

        void menuItem_Click(object sender, EventArgs e)
        {
            foreach (var menuitem in contextMenuStrip1.Items)
            {
                if(menuitem.GetType() == typeof(ToolStripMenuItem))
                {
                    var item = menuitem as ToolStripMenuItem;
                    item.Checked = false;
                }
            }
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            var key = menuItem.Tag as string;
            var wallPaperConfiguration = MannusWallPaperConfiguration.GetConfig().WallPapers[key];
            if (string.Equals(key, "flickr", StringComparison.InvariantCultureIgnoreCase))
            {
                _desktopManager.ShowDesktop();
                TaskBar.Show();
            }
            else
            {
                _desktopManager.SetDesktopImage(wallPaperConfiguration.Path);
                _desktopManager.SetDesktopColor(wallPaperConfiguration.DesktopBackColor);
                var showDesktop = bool.Parse(wallPaperConfiguration.EmptyDesktop);
                if (showDesktop)
                {
                    TaskBar.Show();
                    _desktopManager.ShowDesktop();
                }
                else
                {
                    TaskBar.Hide();
                    _desktopManager.HideDesktop();
                }
            }
            menuItem.Checked = true;
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripSeparator1,
            this.toolStripMenuItem3,
            this.toolStripSeparator2,
            this.afsluitenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 82);
            this.contextMenuStrip1.Text = "Hoofdmenu";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem3.Text = "About";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
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

        private void button1_Click(object sender, EventArgs e)
        {
            _taskBarIsShown = true;
            ToggleTaskBar();
        }

        private void ToggleTaskBar()
        {
            if (_taskBarIsShown)
            {
                changer.StartFlickrModus();
            }
            else
            {
                AddShortCutToDesktop();
                changer.SetEsriNederland();
                CheckShortCut();
            }
        }

        private void CheckShortCut()
        {
            if (File.Exists(_shortCutFileName))
            {
                Thread.Sleep(5000);
                CheckShortCut();
            }
            else
            {
                _taskBarIsShown = true;
                ToggleTaskBar();
            }
        }

        private void AddShortCutToDesktop()
        {
            using (StreamWriter writer = new StreamWriter(_shortCutFileName))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=www.basketbalnieuws.nl");
                writer.Flush();
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}