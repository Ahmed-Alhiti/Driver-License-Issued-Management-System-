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
    public partial class frmManageinterNLApps : Form
    {
        //clsInternationalLicenses internationalLicenses;
        public frmManageinterNLApps()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvInterNDVL.DataSource = clsInternationalLicenses.GetAll();
            clsLoginData.RecrdsNum(dgvInterNDVL, lblnum);

        }
        private void frmManageinterNLApps_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication licenseApplication = new frmInternationalLicenseApplication();
            licenseApplication.ShowDialog();
            LoadData();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo((int)dgvInterNDVL.CurrentRow.Cells[2].Value);
            personInfo.ShowDialog();

        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLicenceInfo licenceInfo = new frmLicenceInfo((int)dgvInterNDVL.CurrentRow.Cells[3].Value);
            licenceInfo.ShowDialog();

        }

        private void showKicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis((int)dgvInterNDVL.CurrentRow.Cells[2].Value);
            licenseHis.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
