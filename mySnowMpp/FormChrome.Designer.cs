namespace mySnowMpp
{
    partial class FormChrome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChrome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2_Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2A_Upload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3A_OpenProj = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1261, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Upload";
            // 
            // toolStripMenuItem1_File
            // 
            this.toolStripMenuItem1_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2_Upload,
            this.toolStripMenuItem3_OpenFile,
            this.toolStripMenuItem2A_Upload,
            this.toolStripMenuItem3A_OpenProj,
            this.mainMenuToolStripMenuItem,
            this.toolStripMenuItem4_Exit});
            this.toolStripMenuItem1_File.Name = "toolStripMenuItem1_File";
            this.toolStripMenuItem1_File.Size = new System.Drawing.Size(44, 24);
            this.toolStripMenuItem1_File.Text = "File";
            // 
            // toolStripMenuItem2_Upload
            // 
            this.toolStripMenuItem2_Upload.Name = "toolStripMenuItem2_Upload";
            this.toolStripMenuItem2_Upload.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem2_Upload.Text = "Upload Current MPP Project";
            this.toolStripMenuItem2_Upload.Visible = false;
            this.toolStripMenuItem2_Upload.Click += new System.EventHandler(this.toolStripMenuItem2_Upload_Click);
            // 
            // toolStripMenuItem3_OpenFile
            // 
            this.toolStripMenuItem3_OpenFile.Name = "toolStripMenuItem3_OpenFile";
            this.toolStripMenuItem3_OpenFile.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem3_OpenFile.Text = "Open MPP Project File";
            this.toolStripMenuItem3_OpenFile.Click += new System.EventHandler(this.toolStripMenuItem3_OpenFile_Click);
            // 
            // toolStripMenuItem2A_Upload
            // 
            this.toolStripMenuItem2A_Upload.Name = "toolStripMenuItem2A_Upload";
            this.toolStripMenuItem2A_Upload.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem2A_Upload.Text = "Upload Current Service Now Project";
            this.toolStripMenuItem2A_Upload.Visible = false;
            this.toolStripMenuItem2A_Upload.Click += new System.EventHandler(this.toolStripMenuItem2A_Upload_Click);
            // 
            // toolStripMenuItem3A_OpenProj
            // 
            this.toolStripMenuItem3A_OpenProj.Name = "toolStripMenuItem3A_OpenProj";
            this.toolStripMenuItem3A_OpenProj.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem3A_OpenProj.Text = "Open Service Now Project";
            this.toolStripMenuItem3A_OpenProj.Click += new System.EventHandler(this.toolStripMenuItem3A_OpenProj_Click);
            // 
            // mainMenuToolStripMenuItem
            // 
            this.mainMenuToolStripMenuItem.Name = "mainMenuToolStripMenuItem";
            this.mainMenuToolStripMenuItem.Size = new System.Drawing.Size(321, 26);
            this.mainMenuToolStripMenuItem.Text = "Main Menu";
            this.mainMenuToolStripMenuItem.Click += new System.EventHandler(this.mainMenuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4_Exit
            // 
            this.toolStripMenuItem4_Exit.Name = "toolStripMenuItem4_Exit";
            this.toolStripMenuItem4_Exit.Size = new System.Drawing.Size(321, 26);
            this.toolStripMenuItem4_Exit.Text = "Exit";
            this.toolStripMenuItem4_Exit.Click += new System.EventHandler(this.toolStripMenuItem4_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1261, 1247);
            this.panel1.TabIndex = 1;
            // 
            // FormChrome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1261, 1275);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormChrome";
            this.Text = "my Mpp/ServiceNow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormChrome_FormClosed);
            this.Load += new System.EventHandler(this.FormChrome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2_Upload;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3_OpenFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4_Exit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2A_Upload;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3A_OpenProj;
        private System.Windows.Forms.ToolStripMenuItem mainMenuToolStripMenuItem;
    }
}