using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void peopleManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleManagement management = new frmPeopleManagement();
            management.MdiParent = this;
            management.Show();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersManagement usersManagement = new frmUsersManagement();
            usersManagement.MdiParent = this;
            usersManagement.Show();

        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo userInfo = new frmUserInfo(clsCurrentUser.id);
            userInfo.MdiParent = this;
            userInfo.Show();

        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword changePassword = new frmChangePassword(clsCurrentUser.id);
            changePassword.MdiParent = this;
            changePassword.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes applicationTypes = new frmManageApplicationTypes();
            applicationTypes.MdiParent = this;
            applicationTypes.Show();


        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes manageTestTypes = new frmManageTestTypes();
            manageTestTypes.MdiParent = this;
            manageTestTypes.Show();

        }

        private void localLicenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicense drivingLicense = new frmNewLocalDrivingLicense(-1);
            drivingLicense.MdiParent = this;
            drivingLicense.Show();

        }

        private void localDrivingLicenesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalDVL localDVL = new frmManageLocalDVL();
            localDVL.MdiParent = this;
            localDVL.Show();

        }

        private void siToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin login = new frmLogin();
            login.ShowDialog();


        }

        private void internationalDrivingLicenesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageinterNLApps manageinterNLApps = new frmManageinterNLApps();
            manageinterNLApps.MdiParent = this;
            manageinterNLApps.Show();


        }

        private void internationalLicenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseApplication licenseApplication = new frmInternationalLicenseApplication();
            licenseApplication.MdiParent = this;
            licenseApplication.Show();
        }

        private void renewDrivingLicenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewDL renewDL = new frmRenewDL();
            renewDL.MdiParent = this;
            renewDL.Show();

        }

        private void replacementForLostOrDamagedLicenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementforDamegedLicense damegedLicense = new frmReplacementforDamegedLicense();
            damegedLicense.MdiParent = this;
            damegedLicense.Show();
        }

        private void detainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainedLicense detainedLicense = new frmDetainedLicense();
            detainedLicense.MdiParent = this;
            detainedLicense.Show();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense();
            releaseDetainLicense.MdiParent = this;
            releaseDetainLicense.Show();
        }

        private void relToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainLicense releaseDetainLicense = new frmReleaseDetainLicense();
            releaseDetainLicense.MdiParent = this;
            releaseDetainLicense.Show();
        }

        private void manageDtainedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageDetainedLicenses manageDetainedLicenses = new frmManageDetainedLicenses();
            manageDetainedLicenses.MdiParent = this;
            manageDetainedLicenses.Show();
        }
    }
}
