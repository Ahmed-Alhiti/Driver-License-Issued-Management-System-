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
    public partial class frmLicenceInfo : Form
    {
        clsLocalDrivingLicense drivingLicense;
        clsApplications application;
        clsDrivers driver;
        clsPeople people;
        clsLicenses licenses;
        int dl_id;
        public frmLicenceInfo(int id)
        {
            InitializeComponent();
            dl_id = id;
        }
        private void LoadData()
        {
           
            licenses = clsLicenses.Find_ByID(dl_id);
            application = clsApplications.FindBaseApplication(licenses._ApplicationID);
            //licenses = clsLicenses.Find_ByAppID(application._ApplicationID);
            people = clsPeople.Find_ByID(application._ApplicantPersonID);
            driver = clsDrivers.Find_ByPersonID(people._PersonID);

            lblName.Text = people._FirstName + " " + people._SecondName + " " + people._ThirdName + " " + people._LastName;
            lblLicenseID.Text = licenses._LicenseID.ToString();
            lblNationalNo.Text = people._NationalNo;
            lblGender.Text = (people._Gendor == 1) ? "Male" : "Female";
            lblEmail.Text = people._Email;
            lblIssueDate.Text = licenses._IssueDate.ToShortDateString();
            lblIssueReason.Text = licenses._IssueReasonText/*(licenses._IssueReason == 1) ? "First Time" : (licenses._IssueReason == 2) ? "Renew" : (licenses._IssueReason == 3) ? "Replacement For Lost License" : "Replacement For Dameged License"*/;
            lblNotes.Text = licenses._Notes;
            lblisactive.Text = (licenses._IsActive) ? "Yes" : "No";
            lblDateOfBrith.Text = people._DateOfBirth.ToShortDateString();
            lblDriverID.Text = driver._DriverID.ToString();
            lblExpirationDate.Text = licenses._ExpirationDate.ToShortDateString();
            clsDetainedLicenses detainedLicense = clsDetainedLicenses.Find_ByLicenseID(licenses._LicenseID);
            lblIsDetained.Text = (detainedLicense != null && !detainedLicense._IsReleased) ? "Yes" : "No";
            picPerson.ImageLocation = people.ImagePath;

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmLicenceInfo_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
