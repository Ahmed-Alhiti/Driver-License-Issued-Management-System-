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
    public partial class frmSechduleTest : Form
    {
        public enum enMode{ AddNew = 0, Update = 1 }
        public enMode mode;
        public enum enTestMode { NewTest = 0, RetakeTest = 1 }
        public enTestMode testMode = enTestMode.NewTest;
        public enum enTestType { vision=1,written=2,street=3}
        public enTestType testType = enTestType.vision;
        clsLocalDrivingLicense license;
        clsTestAppointments appointments;
        //clsTests tests;
        clsApplications applications;
        private int test_typeID = 0;

        int dl_id;
        int appoent_id;
        public frmSechduleTest(int Dl_id,int appoentment_id)
        {
            InitializeComponent();
            dl_id = Dl_id;
            appoent_id = appoentment_id;
            
            mode = (appoent_id == -1) ? enMode.AddNew : enMode.Update;
        }

        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ChangeImageandText()
        {
            if (testType == enTestType.vision)
            {
                test_typeID = 1;
                return;
            }
                
            switch(testType)
            {
                case enTestType.written:
                    test_typeID = 2;
                    pictureBox1.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\magazine_50px.png";
                    label1.Text= "Written Test Appointments";
                    return;


                case enTestType.street:
                    test_typeID = 3;
                    pictureBox1.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\streets_50px.png";
                    label1.Text = "Street Test Appointments";
                    return;
            }
        }
        
        private void _LoadData()
        {
            _ChangeImageandText();

            license = clsLocalDrivingLicense.Find_ByID(dl_id);
            lbDLID.Text = license._LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = license._LicenseClassIDInfo._ClassName;
            lblTrial.Text = license.TotalTrialsPerTest(clsTestTypes.enTestType.VisionTest).ToString();
            lblFees.Text = clsTestTypes.Find(clsTestTypes.enTestType.VisionTest)._TestTypeFees.ToString();
            lblRAppFees.Text = "0";
            lblTotalFees.Text = lblFees.Text;

            if (mode == enMode.AddNew)
            {
                appointments = new clsTestAppointments();
                if (testMode == enTestMode.NewTest)
                {
                    appointments._LocalDrivingLicenseApplicationID = dl_id;
                    appointments._CreatedByUserID = clsCurrentUser.id;
                    return;
                }
               
            }
            else
            {
                
                appointments = clsTestAppointments.Find_ByID(appoent_id);
                dtAppoentment.Value = appointments._AppointmentDate;
                if (appointments._IsLocked)
                {
                    btnSave.Enabled = false;
                    dtAppoentment.Enabled = false;
                }
                if(appointments._RetakeTestApplicationID != -1)
                {
                    clsApplications Rapplications = clsApplications.FindBaseApplication(appointments._RetakeTestApplicationID);
                    lblRAppID.Text = Rapplications._ApplicationID.ToString();
                    lblRAppFees.Text = Rapplications._PaidFees.ToString();
                    lblTotalFees.Text = (short.Parse(lblRAppFees.Text) + short.Parse(lblFees.Text)).ToString();
                    return;
                }
            }
            if (testMode == enTestMode.RetakeTest)
            {
                applications = new clsApplications();
                clsAppsTypes types = clsAppsTypes.Find_ByID(7);
                applications._ApplicantPersonID = clsApplications.FindBaseApplication(license._ApplicationID)._ApplicantPersonID;
                applications._ApplicationDate = DateTime.Now;
                applications._ApplicationStatus = clsApplications.enApplicationStatus.New;
                applications._ApplicationTypeID = types._ApplicationTypeID;
                applications._CreatedByUserID = clsCurrentUser.id;
                applications._LastStatusDate = DateTime.Now;
                applications._PaidFees = types._ApplicationFees;

                lblRAppFees.Text = types._ApplicationFees.ToString();
                lblTotalFees.Text = (short.Parse(lblRAppFees.Text) + short.Parse(lblFees.Text)).ToString();

            }
            
        }

        private void frmSechduleTest_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (testMode == enTestMode.RetakeTest)
            {
                if (applications.Save())
                {
                    
                    lblRAppID.Text = applications._ApplicationID.ToString();
                    lblRAppFees.Text = applications._PaidFees.ToString();
                    //lblTotalFees.Text = (short.Parse(lblRAppFees.Text) + short.Parse(lblFees.Text)).ToString();
                    appointments._RetakeTestApplicationID = applications._ApplicationID;
                    appointments._CreatedByUserID = clsCurrentUser.id;
                }
                else
                {
                    MessageBox.Show("Error");
                    return;

                }
            }
            
            
                appointments._AppointmentDate = dtAppoentment.Value;
                appointments._LocalDrivingLicenseApplicationID = int.Parse(lbDLID.Text);
                appointments._PaidFees = float.Parse(lblTotalFees.Text);
                //appointments._TestTypeID = test_typeID;
                MessageBox.Show(((appointments.Save()) ? "Data Saved" : "Error"));
            

        }
    }
}
