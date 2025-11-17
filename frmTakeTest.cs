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
    public partial class frmTakeTest : Form
    {
        clsLocalDrivingLicense localDrivingLicense;
        int ld_id;
        int appoentment_id;
        clsTestAppointments appointment;
        public enum enTestType { vision = 1, written = 2, street = 3 }
        public enTestType testType = enTestType.vision;
        
        public frmTakeTest(int id , int appoent_id)
        {
            InitializeComponent();

            ld_id = id;
            appoentment_id = appoent_id;
        }

        private void _ChangeImageandText()
        {
            if (testType == enTestType.vision)
                return;
            switch (testType)
            {
                case enTestType.written:
                    pictureBox1.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\magazine_50px.png";
                    label1.Text = "Written Test";
                    return;


                case enTestType.street:
                    pictureBox1.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\streets_50px.png";
                    label1.Text = "Street Test";
                    return;
            }
        }
        private void LoadData()
        {
            
            _ChangeImageandText();
            appointment = clsTestAppointments.Find_ByID(appoentment_id);
            localDrivingLicense = clsLocalDrivingLicense.Find_ByID(appointment._LocalDrivingLicenseApplicationID);

            clsPeople people = clsPeople.Find_ByID(clsApplications.FindBaseApplication(localDrivingLicense._ApplicationID)._ApplicantPersonID);
            localDrivingLicense = clsLocalDrivingLicense.Find_ByID(ld_id);
            lbDLID.Text = localDrivingLicense._LocalDrivingLicenseApplicationID.ToString();
            lblClassName.Text = clsLicenseClasses.Find_ByID(localDrivingLicense._LicenseClassID)._ClassName;
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblFees.Text = clsTestTypes.Find(clsTestTypes.enTestType.VisionTest)._TestTypeFees.ToString();
            lblName.Text = people._FirstName + " " + people._SecondName + " " + people._ThirdName + " " + people._LastName;
            lblTrial.Text = clsTestAppointments.GetTrail(appointment._TestTypeID, ld_id).ToString();

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsTests tests = new clsTests();
            tests._CreatedByUserID = clsCurrentUser.id;
            tests._Notes = txtNotes.Text;
            tests._TestAppointmentID = appoentment_id;
            tests._TestResult = (rdbPass.Checked) ? true : false;

            if (tests.Save())
            {
                lblTestD.Text = tests._TestID.ToString();
                appointment._IsLocked = true;
                if (appointment.Save())
                {
                    if(testType == enTestType.street && tests._TestResult == true)
                    {
                        clsApplications applications = clsApplications.FindBaseApplication(localDrivingLicense._ApplicationID);
                        applications._ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                        if (applications.Save())
                        {
                            MessageBox.Show("Saved");
                            return;
                        }
                    }

                    MessageBox.Show("Saved");
                    return;
                }
               
            }

            MessageBox.Show("Not Saved");
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            LoadData();

        }
    }
}
