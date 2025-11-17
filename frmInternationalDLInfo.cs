using Buisness;
using DVLD_Buisness;
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
    public partial class frmInternationalDLInfo : Form
    {
        clsInternationalLicenses license;
        //clsPeople people;
        int L_id;
        public frmInternationalDLInfo(int id)
        {
            InitializeComponent();
            L_id = id;
        }

        private void LoadLicenseData()
        {

            license = clsInternationalLicenses.Find(L_id);
            inretnationalDLInfo1.lblLicenseID.Text = license._InternationalLicenseID.ToString();
            inretnationalDLInfo1.lblisactive.Text = (license._IsActive) ? "Yes" : "No";
            inretnationalDLInfo1.lblIssueDate.Text = license._IssueDate.ToShortDateString();
            inretnationalDLInfo1.lblExpirationDate.Text = license._ExpirationDate.ToShortDateString();
            inretnationalDLInfo1.lblDriverID.Text = license._DriverID.ToString();

        }
        private void LoadPersonData()
        {

            //people = clsPeople.Find_ByDriverID(license._DriverID);
            inretnationalDLInfo1.lblName.Text = license.ApplicantFullName/*people._FirstName + " " + people._SecondName + " " + people._ThirdName + " " + people._LastName*/;
            inretnationalDLInfo1.lblNationalNo.Text = license.DriverInfo.PersonInfo._NationalNo;
            inretnationalDLInfo1.lblDateOfBrith.Text = license.DriverInfo.PersonInfo._DateOfBirth.ToShortDateString();
            inretnationalDLInfo1.lblGender.Text = (license.DriverInfo.PersonInfo._Gendor == 1) ? "Male" : "Female";
            inretnationalDLInfo1.picPerson.ImageLocation = license.DriverInfo.PersonInfo.ImagePath;
        }

        private void inretnationalDLInfo1_Load(object sender, EventArgs e)
        {
            LoadLicenseData();
            LoadPersonData();
        }
    }
}
