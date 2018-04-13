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
    public partial class Form1 : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        private bool myIsCanceled = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.Control && e.KeyCode == Keys.Z)
            {
                Form2 myForm = new Form2();
                myForm.Show();
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txbFileName.Text = openFileDialog1.FileName;
                btnOpenFile.Visible = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            myIsCanceled = true;
            backgroundWorker1.CancelAsync();
            Cursor.Current = Cursors.Default;
            uModule.uHtmlSelected = htmlSelected._splashHtml;
            FormChrome myForm = new FormChrome();
            myForm.Show();
            this.Hide();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            this.Height = this.Height + 40;
            btnOpenFile.Visible = false;
            pictureBox1.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            uModule.uFileName = txbFileName.Text;
            this.uGlobal.uCreateWebFiles(uModule.uFileName);
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!myIsCanceled)
            {
                Cursor.Current = Cursors.Default;
                uModule.uHtmlSelected = htmlSelected._mppHtml;
                FormChrome myForm = new FormChrome();
                myForm.Show();
                this.Hide();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
