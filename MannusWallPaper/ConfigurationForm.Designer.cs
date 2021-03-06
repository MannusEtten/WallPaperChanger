﻿namespace MannusWallPaper
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.textBoxLocationEnableFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridFilters = new System.Windows.Forms.DataGridView();
            this.textBoxFlickrInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridLibraries = new System.Windows.Forms.DataGridView();
            this.dataGridWallpapers = new System.Windows.Forms.DataGridView();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.useFlickrCheckbox = new System.Windows.Forms.CheckBox();
            this.flickrSettingsGroupbox = new System.Windows.Forms.GroupBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.textBoxSetUrl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.flickrAuthenticationGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVerifierCode = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibraries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWallpapers)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.flickrSettingsGroupbox.SuspendLayout();
            this.flickrAuthenticationGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLocationEnableFile
            // 
            this.textBoxLocationEnableFile.Location = new System.Drawing.Point(142, 6);
            this.textBoxLocationEnableFile.Name = "textBoxLocationEnableFile";
            this.textBoxLocationEnableFile.Size = new System.Drawing.Size(388, 20);
            this.textBoxLocationEnableFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "location of enable file";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridFilters);
            this.groupBox4.Location = new System.Drawing.Point(14, 62);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(516, 359);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Name filters";
            // 
            // dataGridFilters
            // 
            this.dataGridFilters.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridFilters.Location = new System.Drawing.Point(3, 16);
            this.dataGridFilters.MultiSelect = false;
            this.dataGridFilters.Name = "dataGridFilters";
            this.dataGridFilters.Size = new System.Drawing.Size(510, 340);
            this.dataGridFilters.TabIndex = 0;
            // 
            // textBoxFlickrInterval
            // 
            this.textBoxFlickrInterval.Location = new System.Drawing.Point(142, 36);
            this.textBoxFlickrInterval.Name = "textBoxFlickrInterval";
            this.textBoxFlickrInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxFlickrInterval.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "interval changing picture";
            // 
            // dataGridLibraries
            // 
            this.dataGridLibraries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridLibraries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLibraries.Location = new System.Drawing.Point(3, 12);
            this.dataGridLibraries.MultiSelect = false;
            this.dataGridLibraries.Name = "dataGridLibraries";
            this.dataGridLibraries.Size = new System.Drawing.Size(544, 414);
            this.dataGridLibraries.TabIndex = 2;
            // 
            // dataGridWallpapers
            // 
            this.dataGridWallpapers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridWallpapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWallpapers.Location = new System.Drawing.Point(6, 6);
            this.dataGridWallpapers.MultiSelect = false;
            this.dataGridWallpapers.Name = "dataGridWallpapers";
            this.dataGridWallpapers.Size = new System.Drawing.Size(538, 417);
            this.dataGridWallpapers.TabIndex = 1;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(335, 473);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(418, 473);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 455);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBoxLocationEnableFile);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.textBoxFlickrInterval);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(550, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.dataGridWallpapers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(550, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wallpapers";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.dataGridLibraries);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(550, 429);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Libraries";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.useFlickrCheckbox);
            this.tabPage4.Controls.Add(this.flickrSettingsGroupbox);
            this.tabPage4.Controls.Add(this.flickrAuthenticationGroupBox);
            this.tabPage4.ForeColor = System.Drawing.Color.Black;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(550, 429);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Flick\'r";
            // 
            // useFlickrCheckbox
            // 
            this.useFlickrCheckbox.AutoSize = true;
            this.useFlickrCheckbox.Location = new System.Drawing.Point(25, 12);
            this.useFlickrCheckbox.Name = "useFlickrCheckbox";
            this.useFlickrCheckbox.Size = new System.Drawing.Size(73, 17);
            this.useFlickrCheckbox.TabIndex = 16;
            this.useFlickrCheckbox.Text = "use Flick\'r";
            this.useFlickrCheckbox.UseVisualStyleBackColor = true;
            this.useFlickrCheckbox.CheckedChanged += new System.EventHandler(this.useFlickrCheckbox_CheckedChanged);
            // 
            // flickrSettingsGroupbox
            // 
            this.flickrSettingsGroupbox.Controls.Add(this.textBoxUserId);
            this.flickrSettingsGroupbox.Controls.Add(this.label5);
            this.flickrSettingsGroupbox.Controls.Add(this.label6);
            this.flickrSettingsGroupbox.Controls.Add(this.textBoxPageSize);
            this.flickrSettingsGroupbox.Controls.Add(this.textBoxSetUrl);
            this.flickrSettingsGroupbox.Controls.Add(this.label7);
            this.flickrSettingsGroupbox.Enabled = false;
            this.flickrSettingsGroupbox.Location = new System.Drawing.Point(25, 147);
            this.flickrSettingsGroupbox.Name = "flickrSettingsGroupbox";
            this.flickrSettingsGroupbox.Size = new System.Drawing.Size(497, 256);
            this.flickrSettingsGroupbox.TabIndex = 15;
            this.flickrSettingsGroupbox.TabStop = false;
            this.flickrSettingsGroupbox.Text = "Flick\'r settings";
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(114, 58);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(348, 20);
            this.textBoxUserId.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "User ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Set url";
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(114, 132);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(348, 20);
            this.textBoxPageSize.TabIndex = 9;
            // 
            // textBoxSetUrl
            // 
            this.textBoxSetUrl.Location = new System.Drawing.Point(114, 95);
            this.textBoxSetUrl.Name = "textBoxSetUrl";
            this.textBoxSetUrl.Size = new System.Drawing.Size(348, 20);
            this.textBoxSetUrl.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pagesize";
            // 
            // flickrAuthenticationGroupBox
            // 
            this.flickrAuthenticationGroupBox.Controls.Add(this.label3);
            this.flickrAuthenticationGroupBox.Controls.Add(this.txtVerifierCode);
            this.flickrAuthenticationGroupBox.Controls.Add(this.button2);
            this.flickrAuthenticationGroupBox.Controls.Add(this.button1);
            this.flickrAuthenticationGroupBox.Enabled = false;
            this.flickrAuthenticationGroupBox.Location = new System.Drawing.Point(25, 35);
            this.flickrAuthenticationGroupBox.Name = "flickrAuthenticationGroupBox";
            this.flickrAuthenticationGroupBox.Size = new System.Drawing.Size(497, 109);
            this.flickrAuthenticationGroupBox.TabIndex = 14;
            this.flickrAuthenticationGroupBox.TabStop = false;
            this.flickrAuthenticationGroupBox.Text = "Flick\'r authentication";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "fill in verifier code";
            // 
            // txtVerifierCode
            // 
            this.txtVerifierCode.Location = new System.Drawing.Point(147, 50);
            this.txtVerifierCode.Name = "txtVerifierCode";
            this.txtVerifierCode.Size = new System.Drawing.Size(281, 20);
            this.txtVerifierCode.TabIndex = 12;
            this.txtVerifierCode.TextChanged += new System.EventHandler(this.txtVerifierCode_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "authentication step 2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "authentication step 1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 508);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibraries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWallpapers)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.flickrSettingsGroupbox.ResumeLayout(false);
            this.flickrSettingsGroupbox.PerformLayout();
            this.flickrAuthenticationGroupBox.ResumeLayout(false);
            this.flickrAuthenticationGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFlickrInterval;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxLocationEnableFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridFilters;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView dataGridWallpapers;
        private System.Windows.Forms.DataGridView dataGridLibraries;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSetUrl;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox flickrSettingsGroupbox;
        private System.Windows.Forms.GroupBox flickrAuthenticationGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVerifierCode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox useFlickrCheckbox;
    }
}