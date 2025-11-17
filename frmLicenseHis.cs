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
    public partial class frmLicenseHis : Form
    {
        //clsPeople people;
        int Person_id;
        clsDrivers drivers;
        public frmLicenseHis(int id)
        {
            InitializeComponent();

            Person_id = id;
        }

        private void GetHistory()
        {
            drivers = clsDrivers.Find_ByPersonID(Person_id);
            dgvLHis.DataSource = clsLicenses.GetAll(drivers._DriverID);
            dgvinterNLhis.DataSource = clsInternationalLicenses.GetAll(drivers._DriverID);
        }
        
        
        private void _LoadPersonData()
        {
            
            
            filter1.txtFilter.Text = drivers._PersonID.ToString();
            filter1.cbFiltter.SelectedIndex = 1;
            filter1.personinfo1.lbID.Text = drivers.PersonInfo._PersonID.ToString();
            filter1.personinfo1.lblAddress.Text = drivers.PersonInfo._Address;
            filter1.personinfo1.lblCountry.Text = drivers.PersonInfo.CountryInfo._CountryName;
            filter1.personinfo1.lblDate.Text = drivers.PersonInfo._DateOfBirth.ToShortDateString();
            filter1.personinfo1.lblEmail.Text = drivers.PersonInfo._Email;
            filter1.personinfo1.lblGender.Text = (drivers.PersonInfo._Gendor == 0) ? "Male" : "Female";
            filter1.personinfo1.lblName.Text = drivers.PersonInfo.FullName;
            filter1.personinfo1.lblNationalNo.Text = drivers.PersonInfo._NationalNo;
            filter1.personinfo1.lblPhone.Text = drivers.PersonInfo._Phone;
            filter1.personinfo1.picPerson.ImageLocation = drivers.PersonInfo.ImagePath;
        }

        private void LoadData()
        {
            GetHistory();
            _LoadPersonData();

        }

        private void frmLicenseHis_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmLicenceInfo licenceInfo = new frmLicenceInfo((int)dgvLHis.CurrentRow.Cells[0].Value);
            licenceInfo.ShowDialog();

        }
    }
}
