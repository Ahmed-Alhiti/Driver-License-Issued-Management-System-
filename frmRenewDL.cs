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
    public partial class frmRenewDL : Form
    {
        clsAppsTypes types = clsAppsTypes.Find_ByID(2);
        clsLicenses oldLicense;

        public frmRenewDL()
        {
            InitializeComponent();
        }

        private void frmRenewDL_Load(object sender, EventArgs e)
        {
            
        }

        private void filterLicense1_Load(object sender, EventArgs e)
        {
            filterLicense1.lblAppFees.Text = clsAppsTypes.Find_ByID(2)._ApplicationFees.ToString();
            filterLicense1.lblLicenseFees.Text = "20";
            filterLicense1.lblTotalFees.Text = (short.Parse(filterLicense1.lblLicenseFees.Text) + short.Parse(filterLicense1.lblAppFees.Text)).ToString();
            filterLicense1.lblCreateby.Text = clsUsers.Find_ByID(clsCurrentUser.id)._UserName;
            filterLicense1.lblIssueDate.Text = DateTime.Now.ToShortDateString();
            filterLicense1.lblINLissueDate.Text = DateTime.Now.ToShortDateString();
            filterLicense1.lblExDate.Text = DateTime.Now.ToShortDateString();
            filterLicense1.lblappDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsDrivers driver = clsDrivers.Find_ByID(int.Parse(filterLicense1.lblDriverID.Text));

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
                licenses._DriverID = int.Parse(filterLicense1.lblDriverID.Text);
                licenses._IssueDate = DateTime.Now;
                licenses._ExpirationDate = licenses._IssueDate.AddYears(clsLicenseClasses.Find_ByID(3)._DefaultValidityLength);
                licenses._IssueReason = clsLicenses.en_IssueReason.Renew;
                licenses._LicenseClass = 3;
                licenses._Notes = filterLicense1.txtNotes.Text;
                licenses._PaidFees = float.Parse(filterLicense1.lblTotalFees.Text);


                if (licenses.Save())
                {
                    filterLicense1.lblRenewAppID.Text = licenses._ApplicationID.ToString();
                    filterLicense1.lblRenewdLID.Text = licenses._LicenseID.ToString();

                    application._ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                    if (application.Save())
                    {
                        oldLicense._IsActive = false;
                        if (oldLicense.Save())
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
            frmLicenceInfo dLInfo = new frmLicenceInfo(int.Parse(filterLicense1.lblRenewdLID.Text));
            dLInfo.ShowDialog();
        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(oldLicense.DriverInfo._PersonID);
            licenseHis.ShowDialog();
        }


        private void LoadLocalLicenseData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text))
                return;

            oldLicense = clsLicenses.Find_ByID(int.Parse(txtSearchLicenseID.Text));
            if(oldLicense._ExpirationDate > DateTime.Now)
            {

                btnSave.Enabled =  false;
                MessageBox.Show("this license isn't Expierd you cann't renew it", "not expierd yet", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
            if (oldLicense != null)
            {
                filterLicense1.lblLicenseID.Text = oldLicense._LicenseID.ToString();
                filterLicense1.lblLocalLID.Text = filterLicense1.lblLicenseID.Text;
                filterLicense1.lblisactive.Text = (oldLicense._IsActive) ? "Yes" : "No";
                filterLicense1.lblIsDetained.Text = (oldLicense._IsActive) ? "No" : "Yes";
                filterLicense1.lblIssueDate.Text = oldLicense._IssueDate.ToShortDateString();
                filterLicense1.lblIssueReason.Text = oldLicense._IssueReasonText;
                filterLicense1.lblExpirationDate.Text = oldLicense._ExpirationDate.ToShortDateString();
                filterLicense1.lblDriverID.Text = oldLicense._DriverID.ToString();
                filterLicense1.lblNotes.Text = oldLicense._Notes;
            }
            else
            {
                MessageBox.Show("there's no data");
                return;
            }


        }

        private void LoadPersonData()
        {
            if (string.IsNullOrEmpty(txtSearchLicenseID.Text) || oldLicense == null)
                return;
            
            filterLicense1.lblName.Text = oldLicense.DriverInfo.PersonInfo.FullName;
            filterLicense1.lblNationalNo.Text = oldLicense.DriverInfo.PersonInfo._NationalNo;
            filterLicense1.lblEmail.Text = oldLicense.DriverInfo.PersonInfo._Email;
            filterLicense1.lblDateOfBrith.Text = oldLicense.DriverInfo.PersonInfo._DateOfBirth.ToShortDateString();
            filterLicense1.lblGender.Text = (oldLicense.DriverInfo.PersonInfo._Gendor == 1) ? "Male" : "Female";
            filterLicense1.picPerson.ImageLocation = oldLicense.DriverInfo.PersonInfo.ImagePath;
        }

        private void LoadData()
        {
            LoadLocalLicenseData();
            LoadPersonData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
