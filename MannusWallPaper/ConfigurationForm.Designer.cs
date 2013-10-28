namespace MannusWallPaper
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxLocationEnableFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridFilters = new System.Windows.Forms.DataGridView();
            this.textBoxFlickrInterval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.useFlickrCheckbox = new System.Windows.Forms.CheckBox();
            this.flickrGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxPageSize = new System.Windows.Forms.TextBox();
            this.textBoxSetUrl = new System.Windows.Forms.TextBox();
            this.textBoxUserId = new System.Windows.Forms.TextBox();
            this.textBoxAPISharedSecret = new System.Windows.Forms.TextBox();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.dataGridWallpapers = new System.Windows.Forms.DataGridView();
            this.dataGridLibraries = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilters)).BeginInit();
            this.flickrGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWallpapers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibraries)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxLocationEnableFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.textBoxFlickrInterval);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.useFlickrCheckbox);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 177);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // textBoxLocationEnableFile
            // 
            this.textBoxLocationEnableFile.Location = new System.Drawing.Point(206, 13);
            this.textBoxLocationEnableFile.Name = "textBoxLocationEnableFile";
            this.textBoxLocationEnableFile.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocationEnableFile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "location of enable file";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridFilters);
            this.groupBox4.Location = new System.Drawing.Point(29, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(482, 87);
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
            this.dataGridFilters.Size = new System.Drawing.Size(476, 68);
            this.dataGridFilters.TabIndex = 0;
            // 
            // textBoxFlickrInterval
            // 
            this.textBoxFlickrInterval.Location = new System.Drawing.Point(298, 34);
            this.textBoxFlickrInterval.Name = "textBoxFlickrInterval";
            this.textBoxFlickrInterval.Size = new System.Drawing.Size(100, 20);
            this.textBoxFlickrInterval.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "interval changing picture";
            // 
            // useFlickrCheckbox
            // 
            this.useFlickrCheckbox.AutoSize = true;
            this.useFlickrCheckbox.Location = new System.Drawing.Point(46, 36);
            this.useFlickrCheckbox.Name = "useFlickrCheckbox";
            this.useFlickrCheckbox.Size = new System.Drawing.Size(73, 17);
            this.useFlickrCheckbox.TabIndex = 0;
            this.useFlickrCheckbox.Text = "use Flick\'r";
            this.useFlickrCheckbox.UseVisualStyleBackColor = true;
            this.useFlickrCheckbox.Click += new System.EventHandler(this.useFlickrCheckbox_Click);
            // 
            // flickrGroupBox
            // 
            this.flickrGroupBox.Controls.Add(this.textBoxPageSize);
            this.flickrGroupBox.Controls.Add(this.textBoxSetUrl);
            this.flickrGroupBox.Controls.Add(this.textBoxUserId);
            this.flickrGroupBox.Controls.Add(this.textBoxAPISharedSecret);
            this.flickrGroupBox.Controls.Add(this.textBoxAPIKey);
            this.flickrGroupBox.Controls.Add(this.label7);
            this.flickrGroupBox.Controls.Add(this.label6);
            this.flickrGroupBox.Controls.Add(this.label5);
            this.flickrGroupBox.Controls.Add(this.label4);
            this.flickrGroupBox.Controls.Add(this.label3);
            this.flickrGroupBox.Enabled = false;
            this.flickrGroupBox.Location = new System.Drawing.Point(12, 298);
            this.flickrGroupBox.Name = "flickrGroupBox";
            this.flickrGroupBox.Size = new System.Drawing.Size(530, 66);
            this.flickrGroupBox.TabIndex = 1;
            this.flickrGroupBox.TabStop = false;
            this.flickrGroupBox.Text = "Flick\'r";
            // 
            // textBoxPageSize
            // 
            this.textBoxPageSize.Location = new System.Drawing.Point(435, 40);
            this.textBoxPageSize.Name = "textBoxPageSize";
            this.textBoxPageSize.Size = new System.Drawing.Size(100, 20);
            this.textBoxPageSize.TabIndex = 9;
            // 
            // textBoxSetUrl
            // 
            this.textBoxSetUrl.Location = new System.Drawing.Point(313, 46);
            this.textBoxSetUrl.Name = "textBoxSetUrl";
            this.textBoxSetUrl.Size = new System.Drawing.Size(100, 20);
            this.textBoxSetUrl.TabIndex = 8;
            // 
            // textBoxUserId
            // 
            this.textBoxUserId.Location = new System.Drawing.Point(313, 20);
            this.textBoxUserId.Name = "textBoxUserId";
            this.textBoxUserId.Size = new System.Drawing.Size(100, 20);
            this.textBoxUserId.TabIndex = 7;
            // 
            // textBoxAPISharedSecret
            // 
            this.textBoxAPISharedSecret.Location = new System.Drawing.Point(134, 46);
            this.textBoxAPISharedSecret.Name = "textBoxAPISharedSecret";
            this.textBoxAPISharedSecret.Size = new System.Drawing.Size(100, 20);
            this.textBoxAPISharedSecret.TabIndex = 6;
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(134, 20);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(100, 20);
            this.textBoxAPIKey.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Pagesize";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Set url";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "User ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "API shared secret";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "API key";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridLibraries);
            this.groupBox3.Location = new System.Drawing.Point(13, 370);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(537, 70);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Libraries";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridWallpapers);
            this.groupBox5.Location = new System.Drawing.Point(13, 174);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(530, 102);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Wallpapers";
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
            // dataGridWallpapers
            // 
            this.dataGridWallpapers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridWallpapers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridWallpapers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridWallpapers.Location = new System.Drawing.Point(3, 16);
            this.dataGridWallpapers.MultiSelect = false;
            this.dataGridWallpapers.Name = "dataGridWallpapers";
            this.dataGridWallpapers.Size = new System.Drawing.Size(524, 83);
            this.dataGridWallpapers.TabIndex = 1;
            // 
            // dataGridLibraries
            // 
            this.dataGridLibraries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridLibraries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLibraries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLibraries.Location = new System.Drawing.Point(3, 16);
            this.dataGridLibraries.MultiSelect = false;
            this.dataGridLibraries.Name = "dataGridLibraries";
            this.dataGridLibraries.Size = new System.Drawing.Size(531, 51);
            this.dataGridLibraries.TabIndex = 2;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 508);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.flickrGroupBox);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilters)).EndInit();
            this.flickrGroupBox.ResumeLayout(false);
            this.flickrGroupBox.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridWallpapers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLibraries)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox flickrGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox useFlickrCheckbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFlickrInterval;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxLocationEnableFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPageSize;
        private System.Windows.Forms.TextBox textBoxSetUrl;
        private System.Windows.Forms.TextBox textBoxUserId;
        private System.Windows.Forms.TextBox textBoxAPISharedSecret;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.DataGridView dataGridFilters;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.DataGridView dataGridWallpapers;
        private System.Windows.Forms.DataGridView dataGridLibraries;
    }
}