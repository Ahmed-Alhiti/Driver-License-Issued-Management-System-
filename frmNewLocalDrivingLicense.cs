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
    public partial class frmNewLocalDrivingLicense : Form
    {
        clsAppsTypes type = clsAppsTypes.Find_ByID(1);
        clsApplications application;
        clsLocalDrivingLicense license;
        
        int License_id;
        public enum enStatus { New = 1, Cancelled = 2, Completed = 3 }
        enum enMode { AddNew = 0, Update = 1 }
        enMode mode;
        public static enStatus status = enStatus.New;
        public string s = ((short)status).ToString();
        public frmNewLocalDrivingLicense(int id)
        {
            InitializeComponent();
            License_id = id;
            mode = (License_id == -1) ? enMode.AddNew : enMode.Update;
        }

        bool three = false;
        private void _FillcbClass()
        {
            cbClass.DataSource = clsLicenseClasses.GetAll();
            cbClass.DisplayMember = "ClassName";
            cbClass.ValueMember = "LicenseClassID";
            cbClass.SelectedValue = -1;
            three = true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void _FillAppDate()
        {
            string time = DateTime.Now.ToShortDateString();
            lblAppDate.Text = time;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void _LoadData()
        {
            _FillcbClass();
            _FillAppDate();
            lblID.Text = type._ApplicationTypeID.ToString();
            lblCreatedBy.Text = clsUsers.Find_ByID(clsCurrentUser.id)._UserName;
            lblAppFees.Text = type._ApplicationFees.ToString();
           
            if (mode == enMode.AddNew)
            {
                application = new clsApplications();
                license = new clsLocalDrivingLicense();
                
                label1.Text = "New Local DrivingLicense";
                return;
            }
            license = clsLocalDrivingLicense.Find_ByID(License_id);
            application = clsApplications.FindBaseApplication(license._ApplicationID);
            
            //filter1.Enabled = false;
            _LoadPersonData();
            lblID.Text = application._ApplicationID.ToString();
            lblCreatedBy.Text = clsUsers.Find_ByID(application._CreatedByUserID)._UserName;
            lblAppFees.Text = type._ApplicationFees.ToString();
            lblAppDate.Text = application._ApplicationDate.ToShortDateString();
            cbClass.SelectedValue = license._LicenseClassID;   
        }
        private void _LoadPersonData()
        {
            clsPeople people = clsPeople.Find_ByID(application._ApplicantPersonID);
            filter1.personinfo1.lbID.Text = people._PersonID.ToString();
            filter1.personinfo1.lblAddress.Text = people._Address;
            filter1.personinfo1.lblCountry.Text = people.CountryInfo._CountryName /*clsCountry.Find_ByID(people._NationalityCountryID)._Name*/;
            filter1.personinfo1.lblDate.Text = people._DateOfBirth.ToShortDateString();
            filter1.personinfo1.lblEmail.Text = people._Email;
            filter1.personinfo1.lblGender.Text = (people._Gendor == 0) ? "Male" : "Female";
            filter1.personinfo1.lblName.Text =people.FullName;
            filter1.personinfo1.lblNationalNo.Text = people._NationalNo;
            filter1.personinfo1.lblPhone.Text = people._Phone;
        }
        private void frmNewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(clsLocalDrivingLicense.Check(int.Parse(filter1.personinfo1.lbID.Text), (int)cbClass.SelectedValue))
            {
                MessageBox.Show("You Cann't Order towice on " + cbClass.Text + " ","Exception",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
            application._ApplicantPersonID = int.Parse(filter1.personinfo1.lbID.Text); 
            application._ApplicationDate = Convert.ToDateTime(lblAppDate.Text);
            application._ApplicationStatus = clsApplications.enApplicationStatus.New;
            application._ApplicationTypeID = type._ApplicationTypeID;
            application._CreatedByUserID = clsCurrentUser.id;
            application._LastStatusDate = DateTime.Now;
            application._PaidFees = 0;

            if (application.Save())
            {
                
                license._ApplicationID = application._ApplicationID;
                license._LicenseClassID = (int)cbClass.SelectedValue;
                if (license.Save())
                {
                    MessageBox.Show("Data Saved");
                }

            }
            else
            {
                MessageBox.Show("Cann't Save Data");
            }
            

        }
    }
}
