namespace DIP
{
    partial class DIPSample
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rGBtoGrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitPlaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.b7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(876, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stStripLabel
            // 
            this.stStripLabel.Name = "stStripLabel";
            this.stStripLabel.Size = new System.Drawing.Size(158, 19);
            this.stStripLabel.Text = "toolStripStatusLabel1";
            this.stStripLabel.Click += new System.EventHandler(this.stStripLabel_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.iPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(130, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // iPToolStripMenuItem
            // 
            this.iPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rGBtoGrayToolStripMenuItem,
            this.bitPlaneToolStripMenuItem,
            this.inverseToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.histogramToolStripMenuItem});
            this.iPToolStripMenuItem.Name = "iPToolStripMenuItem";
            this.iPToolStripMenuItem.Size = new System.Drawing.Size(36, 24);
            this.iPToolStripMenuItem.Text = "&IP";
            // 
            // rGBtoGrayToolStripMenuItem
            // 
            this.rGBtoGrayToolStripMenuItem.Name = "rGBtoGrayToolStripMenuItem";
            this.rGBtoGrayToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.rGBtoGrayToolStripMenuItem.Text = "RGBtoGray";
            this.rGBtoGrayToolStripMenuItem.Click += new System.EventHandler(this.rGBtoGrayToolStripMenuItem_Click);
            // 
            // bitPlaneToolStripMenuItem
            // 
            this.bitPlaneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.b0ToolStripMenuItem,
            this.b1ToolStripMenuItem,
            this.b2ToolStripMenuItem,
            this.b3ToolStripMenuItem,
            this.b4ToolStripMenuItem,
            this.b5ToolStripMenuItem,
            this.b6ToolStripMenuItem,
            this.b7ToolStripMenuItem});
            this.bitPlaneToolStripMenuItem.Name = "bitPlaneToolStripMenuItem";
            this.bitPlaneToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.bitPlaneToolStripMenuItem.Text = "Bit Plane";
            this.bitPlaneToolStripMenuItem.Click += new System.EventHandler(this.bitPlaneToolStripMenuItem_Click);
            // 
            // b0ToolStripMenuItem
            // 
            this.b0ToolStripMenuItem.Name = "b0ToolStripMenuItem";
            this.b0ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b0ToolStripMenuItem.Text = "B0";
            this.b0ToolStripMenuItem.Click += new System.EventHandler(this.b0ToolStripMenuItem_Click);
            // 
            // b1ToolStripMenuItem
            // 
            this.b1ToolStripMenuItem.Name = "b1ToolStripMenuItem";
            this.b1ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b1ToolStripMenuItem.Text = "B1";
            this.b1ToolStripMenuItem.Click += new System.EventHandler(this.b1ToolStripMenuItem_Click);
            // 
            // b2ToolStripMenuItem
            // 
            this.b2ToolStripMenuItem.Name = "b2ToolStripMenuItem";
            this.b2ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b2ToolStripMenuItem.Text = "B2";
            this.b2ToolStripMenuItem.Click += new System.EventHandler(this.b2ToolStripMenuItem_Click);
            // 
            // b3ToolStripMenuItem
            // 
            this.b3ToolStripMenuItem.Name = "b3ToolStripMenuItem";
            this.b3ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b3ToolStripMenuItem.Text = "B3";
            this.b3ToolStripMenuItem.Click += new System.EventHandler(this.b3ToolStripMenuItem_Click);
            // 
            // b4ToolStripMenuItem
            // 
            this.b4ToolStripMenuItem.Name = "b4ToolStripMenuItem";
            this.b4ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b4ToolStripMenuItem.Text = "B4";
            this.b4ToolStripMenuItem.Click += new System.EventHandler(this.b4ToolStripMenuItem_Click);
            // 
            // b5ToolStripMenuItem
            // 
            this.b5ToolStripMenuItem.Name = "b5ToolStripMenuItem";
            this.b5ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b5ToolStripMenuItem.Text = "B5";
            this.b5ToolStripMenuItem.Click += new System.EventHandler(this.b5ToolStripMenuItem_Click);
            // 
            // b6ToolStripMenuItem
            // 
            this.b6ToolStripMenuItem.Name = "b6ToolStripMenuItem";
            this.b6ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b6ToolStripMenuItem.Text = "B6";
            this.b6ToolStripMenuItem.Click += new System.EventHandler(this.b6ToolStripMenuItem_Click);
            // 
            // b7ToolStripMenuItem
            // 
            this.b7ToolStripMenuItem.Name = "b7ToolStripMenuItem";
            this.b7ToolStripMenuItem.Size = new System.Drawing.Size(110, 26);
            this.b7ToolStripMenuItem.Text = "B7";
            this.b7ToolStripMenuItem.Click += new System.EventHandler(this.b7ToolStripMenuItem_Click);
            // 
            // inverseToolStripMenuItem
            // 
            this.inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            this.inverseToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.inverseToolStripMenuItem.Text = "Inverse";
            this.inverseToolStripMenuItem.Click += new System.EventHandler(this.inverseToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.brightnessToolStripMenuItem.Text = "Brightness and Contrast";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.brightnessToolStripMenuItem_Click);
            // 
            // oFileDlg
            // 
            this.oFileDlg.FileName = "openFileDialog1";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(260, 26);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // DIPSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 434);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DIPSample";
            this.Text = "DIPSample";
            this.Load += new System.EventHandler(this.DIPSample_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stStripLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iPToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog oFileDlg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem rGBtoGrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitPlaneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem b7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inverseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
    }
}