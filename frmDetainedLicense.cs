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
    public partial class frmDetainedLicense : Form
    {
        //clsAppsTypes types = clsAppsTypes.FindBaseApplication(4);
        clsUsers user = clsUsers.Find_ByID(clsCurrentUser.id);
        clsLicenses License;
        public frmDetainedLicense()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text))
                return;

            int dl_id = int.Parse(txtSearchLicenseID.Text);

            License = clsLicenses.Find_ByID(dl_id);
            if (License == null)
            {
                MessageBox.Show("there's no data found", "nothing found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            lblLocalLID.Text = txtSearchLicenseID.Text;
            //clsDetainedLicenses detainedLicenses = clsDetainedLicenses.Find_ByLicenseID(License._LicenseID);
            if (License.DetainedInfo != null && !License.DetainedInfo._IsReleased)
            {
                MessageBox.Show("Selected License is already detained, Choose undetained license", "Detained", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSave.Enabled = false;
                linklblShowLicenceInfo.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                linklblShowLicenceInfo.Enabled = true;
            }
            
            clsApplications application = clsApplications.FindBaseApplication(License._ApplicationID);
            //clsPeople people = clsPeople.FindBaseApplication(application._ApplicantPersonID);
            //clsDrivers driver = clsDrivers.Find_ByPersonID(people._PersonID);

            localLicenseInfo1.lblName.Text = License.DriverInfo.PersonInfo.FullName;
            localLicenseInfo1.lblLicenseID.Text = License._LicenseID.ToString();
            localLicenseInfo1.lblNationalNo.Text = License.DriverInfo.PersonInfo._NationalNo;
            localLicenseInfo1.lblGender.Text = (License.DriverInfo.PersonInfo._Gendor == 1) ? "Male" : "Female";
            localLicenseInfo1.lblEmail.Text = License.DriverInfo.PersonInfo._Email;
            localLicenseInfo1.lblIssueDate.Text = License._IssueDate.ToShortDateString();
            localLicenseInfo1.lblIssueReason.Text = License._IssueReasonText;//(License._IssueReason == 1) ? "First Time" : (License._IssueReason == 2) ? "Renew" : (License._IssueReason == 3) ? "Replacement For Lost License" : "Replacement For Dameged License";
            localLicenseInfo1.lblNotes.Text = License._Notes;
            localLicenseInfo1.lblisactive.Text = (License._IsActive) ? "Yes" : "No";
            localLicenseInfo1.lblDateOfBrith.Text = License.DriverInfo.PersonInfo._DateOfBirth.ToShortDateString();
            localLicenseInfo1.lblDriverID.Text = License._DriverID.ToString();
            localLicenseInfo1.lblExpirationDate.Text = License._ExpirationDate.ToShortDateString();
            //clsDetainedLicenses detainedLicense = clsDetainedLicenses.Find_ByLicenseID(License._LicenseID);
            localLicenseInfo1.lblIsDetained.Text = (License.DetainedInfo._IsReleased) ? "Yes": "No" ;
            localLicenseInfo1.picPerson.ImageLocation = License.DriverInfo.PersonInfo.ImagePath;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDetainedLicenses detainedLicenses = new clsDetainedLicenses();
            detainedLicenses._CreatedByUserID = clsCurrentUser.id;
            detainedLicenses._DetainDate = DateTime.Now;
            detainedLicenses._FineFees = float.Parse(txtFees.Text);
            detainedLicenses._IsReleased = false;
            detainedLicenses._LicenseID = License._LicenseID;
            detainedLicenses._ReleaseApplicationID = -1;
            detainedLicenses._ReleaseDate = DateTime.MinValue;
            detainedLicenses._ReleasedByUserID = -1;
            if (detainedLicenses.Save())
            {
                License._IsActive = false;
                if (License.Save())
                {
                  MessageBox.Show("License Detained Succesfuly", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  lblDetainID.Text = detainedLicenses._DetainID.ToString();
                }

            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void frmDetainedLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            lblCreateby.Text = user._UserName;
        }

        private void linklblShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenceInfo dLInfo = new frmLicenceInfo(int.Parse(txtSearchLicenseID.Text));
            dLInfo.ShowDialog();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(License.DriverInfo._PersonID);
            licenseHis.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
