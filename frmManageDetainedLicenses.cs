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
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            dgvDetainedLicenses.DataSource = clsDetainedLicenses.GetAll();
            clsLoginData.RecrdsNum(dgvDetainedLicenses, lblnum);

        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            frmDetainedLicense detainedLicense = new frmDetainedLicense();
            detainedLicense.ShowDialog();
            LoadData();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frmReleaseDetain = new frmReleaseDetainLicense();
            frmReleaseDetain.ShowDialog();
            LoadData();

        }

        private void releasedDetainedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense frmReleaseDetain = new frmReleaseDetainLicense();
            frmReleaseDetain.txtSearchLicenseID.Text = dgvDetainedLicenses.CurrentRow.Cells[1].Value.ToString();
            //frmReleaseDetain.btnSearch.PerformClick();
            frmReleaseDetain.perform = true;
           // frmReleaseDetain.groupBox2.Enabled = false;
            frmReleaseDetain.ShowDialog();
            
            LoadData();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if((bool)dgvDetainedLicenses.CurrentRow.Cells[3].Value == true)
            {
                contextMenuStrip1.Items[3].Enabled = false;
                return;
            }
            contextMenuStrip1.Items[3].Enabled = true;
        }
    }
}
