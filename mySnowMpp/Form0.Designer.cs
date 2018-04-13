namespace mySnowMpp
{
    partial class Form0
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form0));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbxSelectInstance = new System.Windows.Forms.ComboBox();
            this.lblSelectInstance = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txbPassword);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.txbUser);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.cmbxSelectInstance);
            this.groupBox1.Controls.Add(this.lblSelectInstance);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 199);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect To ServiceNow";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(334, 148);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 36);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(155, 148);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            this.pictureBox1.Visible = false;
            this.pictureBox1.WaitOnLoad = true;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(253, 148);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 36);
            this.btnConnect.TabIndex = 14;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(139, 107);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(270, 22);
            this.txbPassword.TabIndex = 13;
            this.txbPassword.UseSystemPasswordChar = true;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 110);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(73, 17);
            this.lblPassword.TabIndex = 12;
            this.lblPassword.Text = "Password:";
            // 
            // txbUser
            // 
            this.txbUser.Location = new System.Drawing.Point(139, 74);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(270, 22);
            this.txbUser.TabIndex = 11;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(81, 77);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 17);
            this.lblUser.TabIndex = 10;
            this.lblUser.Text = "User:";
            // 
            // cmbxSelectInstance
            // 
            this.cmbxSelectInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSelectInstance.FormattingEnabled = true;
            this.cmbxSelectInstance.Location = new System.Drawing.Point(139, 38);
            this.cmbxSelectInstance.Name = "cmbxSelectInstance";
            this.cmbxSelectInstance.Size = new System.Drawing.Size(270, 24);
            this.cmbxSelectInstance.TabIndex = 9;
            // 
            // lblSelectInstance
            // 
            this.lblSelectInstance.AutoSize = true;
            this.lblSelectInstance.Location = new System.Drawing.Point(15, 41);
            this.lblSelectInstance.Name = "lblSelectInstance";
            this.lblSelectInstance.Size = new System.Drawing.Size(108, 17);
            this.lblSelectInstance.TabIndex = 8;
            this.lblSelectInstance.Text = "Select Instance:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 219);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form0";
            this.Text = "my Mpp/ServiceNow";
            this.Activated += new System.EventHandler(this.Form0_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form0_FormClosed);
            this.Load += new System.EventHandler(this.Form0_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form0_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbxSelectInstance;
        private System.Windows.Forms.Label lblSelectInstance;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}