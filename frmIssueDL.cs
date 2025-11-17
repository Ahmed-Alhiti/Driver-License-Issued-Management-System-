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
    public partial class frmIssueDL : Form
    {
        clsLocalDrivingLicense localDrivingLicense;
        clsLicenseClasses licenseClasses;
        clsApplications applications;
        clsPeople people;
        clsLicenses licenses;
        clsDrivers driver;
        clsAppsTypes types = clsAppsTypes.Find_ByID(1);
        int dl_id;
        public frmIssueDL(int id)
        {
            InitializeComponent();
            dl_id = id;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadData()
        {
            localDrivingLicense = clsLocalDrivingLicense.Find_ByID(dl_id);
            applications = clsApplications.FindBaseApplication(localDrivingLicense._ApplicationID);
            licenseClasses = clsLicenseClasses.Find_ByID(localDrivingLicense._LicenseClassID);
            people = clsPeople.Find_ByID(applications._ApplicantPersonID);
            
            dlInfo1.lbDLID.Text = localDrivingLicense._LocalDrivingLicenseApplicationID.ToString();
            dlInfo1.lblClassName.Text = licenseClasses._ClassName;
            dlInfo1.lblPassedTests.Text = clsTests.GetPassedTests(dl_id).ToString("#0/3");
            dlInfo1.lblAppID.Text = applications._ApplicationID.ToString();
            dlInfo1.lblAppDate.Text = applications._ApplicationDate.ToString();
            dlInfo1.lblAppFees.Text = types._ApplicationFees.ToString();
            dlInfo1.lblAppApplicant.Text = people._FirstName + " " + people._SecondName + " " + people._ThirdName + " " + people._LastName;
            dlInfo1.lblAppCreatedBy.Text = clsUsers.Find_ByID(applications._CreatedByUserID)._UserName.ToString();
            dlInfo1.lblAppStatus.Text = applications._StatusText/*(applications._ApplicationStatus == 1) ? "New" : (applications._ApplicationStatus == 2) ? "Cancelled" : "Completed"*/;
            dlInfo1.lblAppStatusDate.Text = applications._LastStatusDate.ToString();
            dlInfo1.lblAppType.Text = types._ApplicationTypeTitle;

           

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            driver = clsDrivers.Find_ByPersonID(people._PersonID);
            if (driver == null)
            {
                driver = new clsDrivers();
                driver._PersonID = people._PersonID;
                //driver._CreatedDate = DateTime.Now;
                driver._CreatedByUserID = clsCurrentUser.id;
                if (!driver.Save())
                {
                    MessageBox.Show("Error");
                    return;
                }
            }

            licenses = new clsLicenses();
            licenses._ApplicationID = applications._ApplicationID;
            licenses._CreatedByUserID = clsCurrentUser.id;
            licenses._DriverID = driver._DriverID;
            licenses._IssueDate = DateTime.Now;
            licenses._ExpirationDate = licenses._IssueDate.AddYears(licenseClasses._DefaultValidityLength);
            licenses._IssueReason = clsLicenses.en_IssueReason.FirstTime;
            licenses._Notes = txtNotes.Text;
            licenses._PaidFees = types._ApplicationFees;
            licenses._LicenseClass = licenseClasses._LicenseClassID;
            if (licenses.Save())
            {
                applications._PaidFees = licenses._PaidFees;
                applications._ApplicationStatus = clsApplications.enApplicationStatus.Completed;

                if (applications.Save())
                {
                    MessageBox.Show("Licences Issued Successfuly with Licence ID " + licenses._LicenseID.ToString() + "", "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
            }
            else
            {
                MessageBox.Show("Cann't Save");
            }

        }

        private void frmIssueDL_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
