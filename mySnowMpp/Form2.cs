using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace mySnowMpp
{
    public partial class Form2 : Form
    {
        private uModule uGlobal = uModule.uModuleInstanceHandler;
        private bool isDataChanged = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            dataGridView1.DataSource = this.uGlobal.uDgvList;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].FillWeight = 100;
            dataGridView1.Columns[1].FillWeight = 300;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.AutoResizeColumns();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isDataChanged = true;
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (isDataChanged)
            {
                this.uGlobal.uDgvUpdate(dataGridView1);
            }
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
