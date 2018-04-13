using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myMpxjLib;

namespace mySnowMpp
{
    public partial class Form0 : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        public Form0()
        {
            InitializeComponent();
        }

        private void Form0_KeyDown(object sender, KeyEventArgs e)
        {
            Form2 myForm = new Form2();
            myForm.Show();
        }

        private void Form0_Activated(object sender, EventArgs e)
        {
            cmbxSelectInstance.DataSource = this.uGlobal.uDgvList;
            cmbxSelectInstance.DisplayMember = "Name";
            cmbxSelectInstance.ValueMember = "Url";
            cmbxSelectInstance.SelectedIndex = -1;
            this.uGlobal.isBindingListUpdate = false;
        }

        private void Form0_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            bool isSelectInstanceValid = (cmbxSelectInstance.SelectedIndex != -1);
            bool isUserValid = (txbUser.Text.Length > 0);
            bool isPasswordValid = (txbPassword.Text.Length > 0);
            bool isCredentialsValid = false;
            string isUser;

            if (!isSelectInstanceValid)
                MessageBox.Show("You forgot to select a Service-Now instance to connect to!","Input Error!");
            else
            {
                if (isUserValid && isPasswordValid)
                {
                    uModule.uUrl = cmbxSelectInstance.SelectedValue.ToString();
                    uModule.uUser = txbUser.Text.Trim();
                    uModule.uPassword = txbPassword.Text;
                    isCredentialsValid = mpxWrapper.Utility.uValidateUser(
                                            uModule.uUrl,
                                            uModule.uUser,
                                            uModule.uPassword
                                         );
                    
                    isUser = mpxWrapper.Utility.uUserId;
                    if (!isCredentialsValid || (isUser != uModule.uUser))
                    {
                        MessageBox.Show("The User/Password credentials you entered for the selected instance are invalid!");
                    } 
                }
                else
                {
                    MessageBox.Show("You forgot to enter User/Password credentials!");
                }
            }

            if (!(isSelectInstanceValid && isUserValid && isPasswordValid && isCredentialsValid)) return;

            this.Height += 37;
            groupBox1.Height += 37;
            pictureBox1.Visible = true;
            pictureBox1.Enabled = true;
            btnConnect.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.uGlobal.uJsonCommon = mpxWrapper.Utility.uGetLuLists(
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
            this.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;

            this.Hide();
            uModule.uHtmlSelected = htmlSelected._splashHtml;
            FormChrome myForm = new FormChrome();
            myForm.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form0_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
