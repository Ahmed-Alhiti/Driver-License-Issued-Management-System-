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
using DVLD_Buisness;

namespace DVLManagementSystem
{
    public partial class frmInternationalLicenseApplication : Form
    {
        clsAppsTypes types = clsAppsTypes.Find_ByID(6);

        public frmInternationalLicenseApplication()
        {
            InitializeComponent();
        }

        private void internationalLicensesApp1_Load(object sender, EventArgs e)
        {
            internationalLicensesApp1.lblFees.Text = types._ApplicationFees.ToString();
            internationalLicensesApp1.lblCreateby.Text = clsUsers.Find_ByID(clsCurrentUser.id)._UserName;
            internationalLicensesApp1.lblIssueDate.Text = DateTime.Now.ToShortDateString();
            internationalLicensesApp1.lblINLissueDate.Text = DateTime.Now.ToShortDateString();
            internationalLicensesApp1.lblExDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            internationalLicensesApp1.lblappDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        clsDrivers driver;
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int driver_id = int.Parse(internationalLicensesApp1.lblDriverID.Text);
            if (clsInternationalLicenses.IsTherePreviousLicense(driver_id))
            {
                MessageBox.Show("this Driver already has international License");
                return;
            }
            driver = clsDrivers.Find_ByID(driver_id);

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
                clsInternationalLicenses internationalLicense = new clsInternationalLicenses();
                internationalLicense._ApplicationID = application._ApplicationID;
                internationalLicense._CreatedByUserID = clsCurrentUser.id;
                internationalLicense._DriverID = driver_id;
                internationalLicense._ExpirationDate = DateTime.Parse(internationalLicensesApp1.lblExDate.Text);
                internationalLicense._IsActive = true;
                internationalLicense._IssueDate = DateTime.Parse(internationalLicensesApp1.lblINLissueDate.Text);
                internationalLicense.IssuedUsingLocalLicenseID = int.Parse(internationalLicensesApp1.lblLocalLID.Text);
                if (internationalLicense.Save())
                {
                    internationalLicensesApp1.lblinterNLAppID.Text = internationalLicense._ApplicationID.ToString();
                    internationalLicensesApp1.lblinterNLID.Text = internationalLicense._InternationalLicenseID.ToString();

                    application._ApplicationStatus = clsApplications.enApplicationStatus.Completed;
                    if (application.Save())
                    {
                        MessageBox.Show("Data Saved ! Your InterLicense ID = " + internationalLicense._InternationalLicenseID.ToString() + "", "Saved Succefuly", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        linklblShowLicenceInfo.Enabled = true;
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
            frmInternationalDLInfo dLInfo = new frmInternationalDLInfo(int.Parse(internationalLicensesApp1.lblinterNLID.Text));
            dLInfo.ShowDialog();

        }

        private void linkShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicenseHis licenseHis = new frmLicenseHis(driver._PersonID);
            licenseHis.ShowDialog();

        }
    }
}
