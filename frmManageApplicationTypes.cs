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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationType frmUpdate = new frmUpdateApplicationType((int)dgvAppTypes.CurrentRow.Cells[0].Value);
            frmUpdate.ShowDialog();
            _LoadData();

        }

        private void _LoadData()
        {
            dgvAppTypes.DataSource = clsAppsTypes.GetAll();
            clsLoginData.RecrdsNum(dgvAppTypes, lblnum);
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();

        }
    }
}
