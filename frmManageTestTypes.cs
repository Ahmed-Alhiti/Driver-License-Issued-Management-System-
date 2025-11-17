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
using DVLD_Buisness;

namespace DVLManagementSystem
{
    public partial class frmManageTestTypes : Form
    {

        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            dgvTestTypes.DataSource = clsTestTypes.GetAll();
            clsLoginData.RecrdsNum(dgvTestTypes, lblNum);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType updateTestType = new frmUpdateTestType((int)dgvTestTypes.CurrentRow.Cells[0].Value);
            updateTestType.ShowDialog();
            _LoadData();

        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();

        }
    }
}
