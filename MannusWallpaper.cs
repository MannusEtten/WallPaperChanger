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
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem basketBalNieuwsToolStripMenuItem;
        private ToolStripMenuItem afsluitenToolStripMenuItem;
        private WallPaperChanger changer = new WallPaperChanger();
        private string _shortCutFileName;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private TaskBarManager _taskBarManager;

        public Form1()
        {
            InitializeComponent();
            _taskBarManager = new TaskBarManager();
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
            }
            ToolStripMenuItem flickrMenuItem = new ToolStripMenuItem();
            flickrMenuItem.Text = "Flick'r";
            flickrMenuItem.Tag = "flickr";
            flickrMenuItem.Checked = true;
            contextMenuStrip1.Items.Insert(MannusWallPaperConfiguration.GetConfig().WallPapers.Count, flickrMenuItem);
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.basketBalNieuwsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.basketBalNieuwsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem3,
            this.toolStripSeparator2,
            this.afsluitenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 148);
            this.contextMenuStrip1.Text = "Hoofdmenu";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem1.Text = "Flick\'r";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem2.Text = "Esri Nederland";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // basketBalNieuwsToolStripMenuItem
            // 
            this.basketBalNieuwsToolStripMenuItem.Name = "basketBalNieuwsToolStripMenuItem";
            this.basketBalNieuwsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.basketBalNieuwsToolStripMenuItem.Text = "BasketBalNieuws";
            this.basketBalNieuwsToolStripMenuItem.Click += new System.EventHandler(this.basketBalNieuwsToolStripMenuItem_Click);
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(163, 22);
            this.toolStripMenuItem3.Text = "About";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            toolStripMenuItem2.Checked = false;
            basketBalNieuwsToolStripMenuItem.Checked = false;
            _taskBarIsShown = true;
            ToggleTaskBar();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = false;
            basketBalNieuwsToolStripMenuItem.Checked = false;
            _taskBarIsShown = false;
            ToggleTaskBar();
            changer.SetEsriNederland();
        }

        private void basketBalNieuwsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripMenuItem1.Checked = false;
            toolStripMenuItem2.Checked = false;
            basketBalNieuwsToolStripMenuItem.Checked = true;
            changer.SetBasketBalNieuws();
            _taskBarIsShown = true;
            ToggleTaskBar();
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
                _taskBarManager.ShowTaskBar();
                changer.StartFlickrModus();
            }
            else
            {
                _taskBarManager.HideTaskBar();
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
                toolStripMenuItem2.Checked = false;
                basketBalNieuwsToolStripMenuItem.Checked = false;
                toolStripMenuItem1.Checked = true;
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