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
    public partial class frmManageLocalDVL : Form
    {
        
        public frmManageLocalDVL()
        {
            InitializeComponent();
        }

        private void _LoadData()
        {
            dgvLocalDVL.DataSource = clsLocalDrivingLicense.GetAll();
            clsLoginData.RecrdsNum(dgvLocalDVL, lblnum);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense license = new frmNewLocalDrivingLicense(-1);
            license.ShowDialog();
            _LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense license = new frmNewLocalDrivingLicense((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            license.ShowDialog();
            _LoadData();

        }

        private void frmManageLocalDVL_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsApplications applications = clsApplications.FindBaseApplication((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            applications._ApplicationStatus = clsApplications.enApplicationStatus.Cancelled;
            if (applications.Save())
            {
                MessageBox.Show("Application Cancelled");
                _LoadData();

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("do you want to delete this record ?", "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK))
            {
                clsLocalDrivingLicense localDrivingLicense = clsLocalDrivingLicense.Find_ByID((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
                if (localDrivingLicense != null && localDrivingLicense.Delete())
                {
                    MessageBox.Show("Deleted Successfuly");

                }
                else
                {
                    MessageBox.Show("There are Data linked with this record");
                    return;
                }
            }
            _LoadData();
        }

        private void sechduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisionTestAppointments VisionTest = new frmVisionTestAppointments((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            VisionTest.ShowDialog();
            _LoadData();

        }

        private void sToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {

            bool vision = (clsTests.CheckTestResult(1, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;
            bool written = (clsTests.CheckTestResult(2, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;
            bool street = (clsTests.CheckTestResult(3, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;


            if (!vision)
            {
                sToolStripMenuItem.DropDownItems[0].Enabled = true;
                sToolStripMenuItem.DropDownItems[1].Enabled = false;
                sToolStripMenuItem.DropDownItems[2].Enabled = false;
                return;
            }
            else
            {
                sToolStripMenuItem.DropDownItems[0].Enabled = false;

                if (!written)
                {
                    sToolStripMenuItem.DropDownItems[1].Enabled = true;
                    sToolStripMenuItem.DropDownItems[2].Enabled = false;
                    return;
                }
                else
                {
                    sToolStripMenuItem.DropDownItems[1].Enabled = false;

                    if (!street)
                    {
                        sToolStripMenuItem.DropDownItems[2].Enabled = true;
                        return;
                    }
                    else
                    {
                        sToolStripMenuItem.DropDownItems[2].Enabled = false;


                    }
                }
            }


        }

        private void sechduleWTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWritten_Testappoentment frmWritten = new frmWritten_Testappoentment((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            frmWritten.ShowDialog();
            _LoadData();
        }

        private void sechdulePracticalStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStreetTestappointments frmStreet = new frmStreetTestappointments((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            frmStreet.ShowDialog();
            _LoadData();
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            


            bool vision = (clsTests.CheckTestResult(1, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;
            bool written = (clsTests.CheckTestResult(2, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;
            bool street = (clsTests.CheckTestResult(3, (int)dgvLocalDVL.CurrentRow.Cells[0].Value)) ? true : false;
            contextMenuStrip1.Items[4].Enabled = (vision && written && street) ? false : true;

            clsLocalDrivingLicense drivingLicense = clsLocalDrivingLicense.Find_ByID((int)dgvLocalDVL.CurrentRow.Cells[0].Value);

            clsLicenses licenses = clsLicenses.Find_ByAppID(drivingLicense._ApplicationID);
            if(licenses != null)
            {
                contextMenuStrip1.Items[1].Enabled = false;
                contextMenuStrip1.Items[2].Enabled = false;
                contextMenuStrip1.Items[3].Enabled = false;
                //contextMenuStrip1.Items[4].Enabled = false;
                contextMenuStrip1.Items[5].Enabled = false;
                contextMenuStrip1.Items[6].Enabled = true;
                return;
            }
            contextMenuStrip1.Items[1].Enabled = true;
            contextMenuStrip1.Items[2].Enabled = true;
            contextMenuStrip1.Items[3].Enabled = true;
            //contextMenuStrip1.Items[4].Enabled = true;
            contextMenuStrip1.Items[5].Enabled = true;
            contextMenuStrip1.Items[6].Enabled = false;

        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueDL issueDL = new frmIssueDL((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            issueDL.ShowDialog();

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenceInfo licenceInfo = new frmLicenceInfo((int)dgvLocalDVL.CurrentRow.Cells[0].Value);
            licenceInfo.ShowDialog();

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(clsApplications.FindBaseApplication(clsLocalDrivingLicense.Find_ByID((int)dgvLocalDVL.CurrentRow.Cells[0].Value)._ApplicationID)._ApplicantPersonID);
            licenseHis.ShowDialog();

        }
    }
}
