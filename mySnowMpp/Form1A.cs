using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using myMpxjLib;

namespace mySnowMpp
{
    public partial class Form1A : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        private string myProjList;
        private string myHtml;
        public Form1A()
        {
            InitializeComponent();
            this.label2.Visible = false;
            this.panel2.Visible = false;
            this.btnLaunch.Visible = false;
            this.btnContinue.Visible = false;
            this.btnExit.Visible = false;
        }

        private void Form1A_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            timer1.Interval = 500;
            timer1.Start();
            timer1.Enabled = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;           
            switch(uModule.uHtmlSelected)
            {
                case htmlSelected._projHtml:
                    myProjList = mpxWrapper.Utility.uGetProjList(
                                        uModule.uUrl,
                                        uModule.uUser,
                                        uModule.uPassword
                                   );
                    this.uGlobal.uCreateProjListFile(myProjList);
                    backgroundWorker1.CancelAsync();
                    break;
                case htmlSelected._snowHtml:
                    myHtml = mpxWrapper.Utility.uGetSnowProj(
                                    uModule.uUrl,
                                    uModule.uUser,
                                    uModule.uPassword,
                                    uModule.projsysid
                             );
                    this.uGlobal.uCreateSnowProjFile(myHtml);
                    break;
                case htmlSelected._none:
                    uModule.uUpdate(
                        uModule.uUrl,
                        uModule.uUser,
                        uModule.uPassword
                    );
                    break;

            }
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor.Current = Cursors.Default;
            if (uModule.uHtmlSelected == htmlSelected._none)
            {
                timer1.Stop();
                timer1.Enabled = false;
                this.label1.Visible = false;
                this.pictureBox1.Visible = false;
                this.label2.Visible = true;
                this.panel2.Visible = true;
                this.btnLaunch.Visible = true;
                this.btnContinue.Visible = true;
                this.btnExit.Visible = true;
            }
            else
            {
                FormChrome myForm = new FormChrome();
                myForm.Show();
                this.Hide();
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            bool isGood = false;
            try
            {
                uModule.launchSnow();
                isGood = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    String.Format("Unable to Launch Web Browser: {0}", ex.Message),
                    "ServiceNow Launch Failed",
                    MessageBoxButtons.OK
                );
                btnLaunch.Visible = false;
            }
            if (isGood)
            {
                //Application.Exit();
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            uModule.uHtmlSelected = htmlSelected._splashHtml;
            FormChrome myForm = new FormChrome();
            myForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1A_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
