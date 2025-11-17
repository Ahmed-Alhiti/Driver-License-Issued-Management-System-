using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Buisness;

namespace DVLManagementSystem
{
    public partial class DLInfo : UserControl
    {
        public DLInfo()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //clsLocalDrivingLicense localDrivingLicense = clsLocalDrivingLicense.FindBaseApplication(int.Parse(lbDLID.Text));
            //frmLicenceInfo licenceInfo = new frmLicenceInfo(localDrivingLicense._LocalDrivingLicenseApplicationID);
            //licenceInfo.Show();

        }

        private void PersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsApplications applications = clsApplications.FindBaseApplication(int.Parse(lblAppID.Text));

            clsPeople people = clsPeople.Find_ByID(applications._ApplicantPersonID);
            frmPersonInfo personInfo = new frmPersonInfo(people._PersonID);
            personInfo.ShowDialog();

        }
    }
}
