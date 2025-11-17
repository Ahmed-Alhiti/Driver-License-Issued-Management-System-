using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;

namespace DVLManagementSystem
{
    public partial class frmPeopleManagement : Form
    {
        public frmPeopleManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo personInfo = new frmAddEditPersonInfo(-1);
            personInfo.ShowDialog();
            _LoadPeople();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            personInfo.ShowDialog();
            _LoadPeople();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void _LoadPeople()
        {
            dgvPeople.DataSource = clsPeople.GetAll();

        }
        private void frmPeopleManagement_Load(object sender, EventArgs e)
        {
            _LoadPeople();

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo personInfo = new frmAddEditPersonInfo((int)dgvPeople.CurrentRow.Cells[0].Value);
            personInfo.ShowDialog();
            _LoadPeople();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if((MessageBox.Show("do you want to delete this record ?","Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                if (clsPeople.Delete((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfuly");

                }
                else
                {
                    MessageBox.Show("There are Data linked with this record");
                }
            }
            _LoadPeople();
        }
    }
}
