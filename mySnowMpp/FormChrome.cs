using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cefWin=CefSharp.WinForms;
using cefS = CefSharp;


namespace mySnowMpp
{
    public partial class FormChrome : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        private uChrome myChrome;
        private string myUrl = String.Empty;
        public FormChrome()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            uModule.myAction = this.FormChrome_Form1A_Action;
        }

        private void FormChrome_Load(object sender, EventArgs e)
        {
            myChrome = new uChrome();
            panel1.Controls.Add(myChrome.uBrowser);
            loadUrl();
            this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        private void loadUrl()
        {
            switch (uModule.uHtmlSelected)
            {
                case htmlSelected._splashHtml:
                    toolStripMenuItem2_Upload.Visible = false;
                    toolStripMenuItem2A_Upload.Visible = false;
                    toolStripMenuItem3_OpenFile.Visible = true;
                    toolStripMenuItem3A_OpenProj.Visible = true;
                    mainMenuToolStripMenuItem.Visible = false;
                    myUrl = this.uGlobal.uSplashHtmlUrl;
                    break;
                case htmlSelected._mppHtml:
                    toolStripMenuItem2_Upload.Visible = true;
                    toolStripMenuItem2A_Upload.Visible = false;
                    toolStripMenuItem3_OpenFile.Visible = false;
                    toolStripMenuItem3A_OpenProj.Visible = false;
                    mainMenuToolStripMenuItem.Visible = true;
                    myUrl = this.uGlobal.uMppHtmlUrl;
                    break;
                case htmlSelected._snowHtml:
                    toolStripMenuItem2_Upload.Visible = false;
                    toolStripMenuItem2A_Upload.Visible = true;
                    toolStripMenuItem3_OpenFile.Visible = false;
                    toolStripMenuItem3A_OpenProj.Visible = false;
                    mainMenuToolStripMenuItem.Visible = true;
                    myUrl = this.uGlobal.uSnowHtmlUrl;
                    break;
                case htmlSelected._projHtml:
                    toolStripMenuItem2_Upload.Visible = false;
                    toolStripMenuItem2A_Upload.Visible = false;
                    toolStripMenuItem3_OpenFile.Visible = false;
                    toolStripMenuItem3A_OpenProj.Visible = false;
                    mainMenuToolStripMenuItem.Visible = true;
                    myUrl = this.uGlobal.uProjHtmlUrl;
                    break;
            }
            myChrome.uBrowser.Load(myUrl);
        }

        private void toolStripMenuItem2_Upload_Click(object sender, EventArgs e)
        {
            string myFile = System.IO.Path.GetFileName(uModule.uFileName);
            string myPrompt = String.Format("Ready to load this data into a new SERVICENOW PROJECT? (\"YES\" will create a NEW project!)", myFile);
            if (MessageBox.Show(myPrompt, "my MPP/Service Now",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var myResult = uModule.uJsExec(myChrome, uModule.cDataGatherJs);
                uModule.uStoreResponse(myResult);

                FormTree myForm = new FormTree();
                myForm.Show();
                this.Hide();
            }
        }

        private void toolStripMenuItem3_OpenFile_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;

            this.Hide();
            Form1 myForm = new Form1();
            myForm.Show();
        }

        private void toolStripMenuItem2A_Upload_Click(object sender, EventArgs e)
        {
            var myResult = uModule.uJsExec(myChrome, uModule.cDataGatherJs);
            uModule.uStoreResponse(myResult);

            uModule.uHtmlSelected = htmlSelected._none;

            this.Hide();
            Form1A myForm = new Form1A();
            myForm.Show();
        }

        private void toolStripMenuItem3A_OpenProj_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            uModule.uHtmlSelected = htmlSelected._projHtml;
            this.Hide();
            Form1A myForm = new Form1A();
            myForm.Show();
        }

        private void toolStripMenuItem4_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormChrome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormChrome_Form1A_Action()
        {
            Form1A myForm = new Form1A();
            this.Hide();
            myForm.Show();
        }

        private void mainMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uModule.uHtmlSelected = htmlSelected._splashHtml;
            toolStripMenuItem2_Upload.Visible = false;
            toolStripMenuItem2A_Upload.Visible = false;
            toolStripMenuItem3_OpenFile.Visible = true;
            toolStripMenuItem3A_OpenProj.Visible = true;
            mainMenuToolStripMenuItem.Visible = false;
            myUrl = this.uGlobal.uSplashHtmlUrl;
            myChrome.uBrowser.Load(myUrl);
        }
    }
}
