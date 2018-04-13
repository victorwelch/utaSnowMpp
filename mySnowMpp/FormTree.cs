using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mySnowMpp
{
    public partial class FormTree : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        private TreeView myTree;

        public FormTree()
        {
            InitializeComponent();
            //this.StartPosition = FormStartPosition.
        }

        private void FormTree_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
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
            uModule.uUpload(
                uModule.uUrl,
                uModule.uUser,
                uModule.uPassword
            );
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox1.Enabled = false;
            label1.Visible = false;
            timer1.Stop();
            timer1.Enabled = false;
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
            panel2.Visible = true;
            btnContinue.Visible = true;
            myTree = new TreeView();
            myTree.Dock = DockStyle.Fill;
            myTree.Scrollable = true;
            myTree.Visible = true;
            myTree.BeginUpdate();
            myTree.Nodes.Clear();
            uModule.buildTree(myTree.Nodes);
            this.Height = 650;
            panel1.Dock = DockStyle.Fill;
            panel1.Controls.Add(myTree);
            panel1.Visible = true;
            btnLaunch.Visible = true;
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            uModule.uHtmlSelected = htmlSelected._splashHtml;
            FormChrome myForm = new FormChrome();
            myForm.Show();
            this.Hide();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            bool isGood = false;
            try
            {
                uModule.launchSnow();
                isGood = true;
            }
            catch(Exception ex)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormTree_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
