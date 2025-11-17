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
    public partial class frmReplacementforDamegedLicense : Form
    {
        clsAppsTypes types = clsAppsTypes.Find_ByID(4);
        clsUsers user = clsUsers.Find_ByID(clsCurrentUser.id);
        clsLicenses oldlicenses;
        public frmReplacementforDamegedLicense()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void LoadData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text))
                return;
                
            int dl_id = int.Parse(txtSearchLicenseID.Text);

             oldlicenses = clsLicenses.Find_ByID(dl_id);
            if(oldlicenses == null)
            {
                MessageBox.Show("there's no data found", "nothing found", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            lblLocalLID.Text = txtSearchLicenseID.Text;

            if (!oldlicenses._IsActive)
            {
                MessageBox.Show("Selected License isn't active, Choose an active license", "not activated", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnSave.Enabled = false;
                linklblShowLicenceInfo.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
                linklblShowLicenceInfo.Enabled = true;
            }

            //clsApplications application = clsApplications.FindBaseApplication(oldlicenses._ApplicationID);
            //clsPeople people = clsPeople.Find_ByID(application._ApplicantPersonID);
            //clsDrivers driver = clsDrivers.Find_ByPersonID(people._PersonID);

            localLicenseInfo1.lblName.Text = oldlicenses.DriverInfo.PersonInfo.FullName;
            localLicenseInfo1.lblLicenseID.Text = oldlicenses._LicenseID.ToString();
            localLicenseInfo1.lblNationalNo.Text = oldlicenses.DriverInfo.PersonInfo._NationalNo;
            localLicenseInfo1.lblGender.Text = (oldlicenses.DriverInfo.PersonInfo._Gendor == 1) ? "Male" : "Female";
            localLicenseInfo1.lblEmail.Text = oldlicenses.DriverInfo.PersonInfo._Email;
            localLicenseInfo1.lblIssueDate.Text = oldlicenses._IssueDate.ToShortDateString();
            localLicenseInfo1.lblIssueReason.Text = oldlicenses._IssueReasonText;
            localLicenseInfo1.lblNotes.Text = oldlicenses._Notes;
            localLicenseInfo1.lblisactive.Text = (oldlicenses._IsActive) ? "Yes" : "No";
            localLicenseInfo1.lblDateOfBrith.Text = oldlicenses.DriverInfo.PersonInfo._DateOfBirth.ToShortDateString();
            localLicenseInfo1.lblDriverID.Text = oldlicenses.DriverInfo._DriverID.ToString();
            localLicenseInfo1.lblExpirationDate.Text = oldlicenses._ExpirationDate.ToShortDateString();
            clsDetainedLicenses detainedLicense = clsDetainedLicenses.Find_ByLicenseID(oldlicenses._LicenseID);
            localLicenseInfo1.lblIsDetained.Text = (detainedLicense != null && !detainedLicense._IsReleased) ? "Yes" : "No";
            localLicenseInfo1.picPerson.ImageLocation = oldlicenses.DriverInfo.PersonInfo.ImagePath;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmReplacementforDamegedLicense_Load(object sender, EventArgs e)
        {

            lblAppFees.Text = types._ApplicationFees.ToString();
            lblCreateby.Text = user._UserName;
            lblappDate.Text = DateTime.Now.ToShortDateString();

        }

        private void rdDamaged_CheckedChanged(object sender, EventArgs e)
        {
            types = clsAppsTypes.Find_ByID(3);
            lblAppFees.Text = types._ApplicationFees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            clsDrivers driver = clsDrivers.Find_ByID(int.Parse(localLicenseInfo1.lblDriverID.Text));
            //int person_id = clsPeople.Find_ByDriverID(driver_id)._PersonID;

            clsApplications application = new clsApplications();
            application._ApplicantPersonID = driver._PersonID;
            application._ApplicationDate = DateTime.Now;
            application._ApplicationStatus = clsApplications.enApplicationStatus.New;
            application._ApplicationTypeID = types._ApplicationTypeID;
            application._CreatedByUserID = clsCurrentUser.id;
            application._LastStatusDate = DateTime.Now;
            application._PaidFees = types._ApplicationFees;

            if (application.Save())
            {
                clsLicenses licenses = new clsLicenses();
                licenses._ApplicationID = application._ApplicationID;
                licenses._CreatedByUserID = clsCurrentUser.id;
                licenses._DriverID = driver._DriverID;
                licenses._IssueDate = DateTime.Now;
                licenses._ExpirationDate = licenses._IssueDate.AddYears(clsLicenseClasses.Find_ByID(3)._DefaultValidityLength);
                licenses._IssueReason = (rdDamaged.Checked) ? clsLicenses.en_IssueReason.LostReplacement : clsLicenses.en_IssueReason.DamagedReplacement;
                licenses._LicenseClass = oldlicenses._LicenseClass;
                licenses._Notes = (rdDamaged.Checked)? "Replcement for damaged license": "Replcement for lost license";
                licenses._PaidFees = float.Parse(lblAppFees.Text);


                if (licenses.Save())
                {
                    lblReplaceAppID.Text = licenses._ApplicationID.ToString();
                    lblReplacedDLID.Text = licenses._LicenseID.ToString();

                    application._ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                    if (application.Save())
                    {
                        oldlicenses._IsActive = false;
                        if (oldlicenses.Save())
                        {
                            MessageBox.Show("Data Saved ! Your License ID = " + licenses._LicenseID.ToString() + "", "Saved Succefuly", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            linklblShowLicenceInfo.Enabled = true;
                            return;
                        }

                    }

                    else
                    {
                        MessageBox.Show("Error");
                        return;
                    }

                }
            }

        }

        private void linklblShowLicenceInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenceInfo dLInfo = new frmLicenceInfo(int.Parse(lblReplacedDLID.Text));
            dLInfo.ShowDialog();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(oldlicenses.DriverInfo._PersonID);
            licenseHis.ShowDialog();
        }
    }
}
