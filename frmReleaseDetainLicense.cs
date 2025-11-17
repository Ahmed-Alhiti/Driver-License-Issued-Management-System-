using Buisness;
using System;
using System.Windows.Forms;

namespace DVLManagementSystem
{
    public partial class frmReleaseDetainLicense : Form
    {
        clsAppsTypes types = clsAppsTypes.Find_ByID(5);
        clsUsers user = clsUsers.Find_ByID(clsCurrentUser.id);
        clsLicenses oldlicenses;
        public bool perform = false;
        public frmReleaseDetainLicense()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text))
                return;

            int dl_id = int.Parse(txtSearchLicenseID.Text);

            oldlicenses = clsLicenses.Find_ByID(dl_id);
            if (oldlicenses == null)
            {
                MessageBox.Show("there's no data found", "nothing found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            clsDetainedLicenses detainedLicense = clsDetainedLicenses.Find_ByLicenseID(oldlicenses._LicenseID);
            lblLocalLID.Text = txtSearchLicenseID.Text;

            if (detainedLicense != null && detainedLicense._IsReleased)
            {
                MessageBox.Show("Selected License isn't Detained , Choose Detained license", "not activated", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSave.Enabled = false;
                linklblShowLicenceInfo.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                linklblShowLicenceInfo.Enabled = true;
            }

            clsApplications application = clsApplications.FindBaseApplication(oldlicenses._ApplicationID);
            clsPeople people = clsPeople.Find_ByID(application._ApplicantPersonID);
            clsDrivers driver = clsDrivers.Find_ByPersonID(people._PersonID);

            localLicenseInfo1.lblName.Text = people._FirstName + " " + people._SecondName + " " + people._ThirdName + " " + people._LastName;
            localLicenseInfo1.lblLicenseID.Text = oldlicenses._LicenseID.ToString();
            localLicenseInfo1.lblNationalNo.Text = people._NationalNo;
            localLicenseInfo1.lblGender.Text = (people._Gendor == 1) ? "Male" : "Female";
            localLicenseInfo1.lblEmail.Text = people._Email;
            localLicenseInfo1.lblIssueDate.Text = oldlicenses._IssueDate.ToShortDateString();
            localLicenseInfo1.lblIssueReason.Text = oldlicenses._IssueReasonText;
            localLicenseInfo1.lblNotes.Text = oldlicenses._Notes;
            localLicenseInfo1.lblisactive.Text = (oldlicenses._IsActive) ? "Yes" : "No";
            localLicenseInfo1.lblDateOfBrith.Text = people._DateOfBirth.ToShortDateString();
            localLicenseInfo1.lblDriverID.Text = driver._DriverID.ToString();
            localLicenseInfo1.lblExpirationDate.Text = oldlicenses._ExpirationDate.ToShortDateString();
            localLicenseInfo1.lblIsDetained.Text = (detainedLicense != null && !detainedLicense._IsReleased) ? "Yes" : "No";
            localLicenseInfo1.picPerson.ImageLocation = people.ImagePath;
            if (detainedLicense != null)
            {
                lblDetainID.Text = detainedLicense._DetainID.ToString();
                lblFineFees.Text = detainedLicense._FineFees.ToString();
                lbltotalfees.Text = (types._ApplicationFees + detainedLicense._FineFees).ToString();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmReleaseDetainLicense_Load(object sender, EventArgs e)
        {
            lblAppFees.Text = types._ApplicationFees.ToString();
            lblappDate.Text = DateTime.Now.ToShortDateString();
            lblCreateby.Text = user._UserName;
            lbltotalfees.Text = lblAppFees.Text;
            if (perform)
            {
                btnSearch.PerformClick();
                groupBox2.Enabled = false;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsApplications application = new clsApplications();
            application._ApplicantPersonID = application._ApplicantPersonID;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = clsApplications.enApplicationStatus.New;
            application._ApplicationTypeID = types._ApplicationTypeID;
            application._CreatedByUserID = clsCurrentUser.id;
            application._PaidFees = float.Parse(lbltotalfees.Text);
            if (application.Save())
            {
                clsDetainedLicenses detainedLicense = clsDetainedLicenses.Find_ByLicenseID(oldlicenses._LicenseID);
                detainedLicense._ReleaseApplicationID = application._ApplicationID;
                detainedLicense._ReleaseDate = DateTime.Now;
                detainedLicense._ReleasedByUserID = user._UserID;
                detainedLicense._IsReleased = true;
                if (detainedLicense.Save())
                {
                    oldlicenses._IsActive = true;
                    if (oldlicenses.Save())
                    {
                        application._ApplicationStatus = clsApplications.enApplicationStatus.Completed;

                        if (application.Save())
                        {
                            MessageBox.Show("License Released Succesfuly", "Released", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lblReleaseappID.Text = application._ApplicationID.ToString();

                            return;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void linklblShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenceInfo dLInfo = new frmLicenceInfo(oldlicenses._LicenseID);
            dLInfo.ShowDialog();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(oldlicenses.DriverInfo._PersonID);
            licenseHis.ShowDialog();
        }
    }
}
