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
    public partial class frmAddEditPersonInfo : Form
    {
        clsPeople people;
        int Person_id;
        public enum enMode { Addnew = 0, Update = 1 }
        enMode mode;
        public frmAddEditPersonInfo(int id)
        {
            InitializeComponent();
            Person_id = id;
            if (Person_id == -1)
                mode = enMode.Addnew;
            else
                mode = enMode.Update;
        }

        private void _FillcbCountry()
        {
            cbCountry.DataSource = clsCountry.GetAll();
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedValue = -1;
        }
        private void _LoadData()
        {
            _FillcbCountry();
            dtBrith.MaxDate = GetAllowedDate();
            

            if (mode == enMode.Addnew)
            {
                people = new clsPeople();
                rdbMale.Checked = true;
                return;
            }

            label1.Text = "Update Person";

            people = clsPeople.Find_ByID(Person_id);
            lblID.Text = people._PersonID.ToString();
            txtFirst.Text = people._FirstName;
            txtSecond.Text = people._SecondName;
            txtThird.Text = people._ThirdName;
            txtLast.Text = people._LastName;
            txtNationalNo.Text = people._NationalNo;
            dtBrith.Value = people._DateOfBirth;
            txtEmail.Text = people._Email;
            txtPhone.Text = people._Phone;
            txtAddress.Text = people._Address;
            if (people._Gendor == 0)
                rdbMale.Checked = true;
            else
                rdbFemale.Checked = true;
            cbCountry.SelectedValue = people._NationalityCountryID;
            pBPerson.ImageLocation = people.ImagePath;



        }
        private DateTime GetAllowedDate()
        {
            DateTime CurrentDate = DateTime.Now;

            return CurrentDate.AddYears(-18);
        }
        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            people._FirstName = txtFirst.Text;
            people._SecondName = txtSecond.Text;
            people._ThirdName = txtThird.Text;
            people._LastName = txtLast.Text;
            people._Phone = txtPhone.Text;
            people._NationalNo = txtNationalNo.Text;
            if (rdbFemale.Checked)
                people._Gendor = 1;
            else
                people._Gendor = 0;
            people._DateOfBirth = dtBrith.Value;
            people._Address = txtAddress.Text;
            people._Email = txtEmail.Text;
            people._NationalityCountryID = (int)cbCountry.SelectedValue;
            people.ImagePath = pBPerson.ImageLocation;
            if (people.Save())
            {
                MessageBox.Show("Data Saved");
                if (mode == enMode.Addnew)
                {
                    lblID.Text = people._PersonID.ToString();
                }
            }
            else
                MessageBox.Show("Cann't Save");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            openFileDialog1.Filter = " |*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Choose Image";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string ImagePath = openFileDialog1.FileName;
                pBPerson.ImageLocation = ImagePath;
            }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pBPerson.ImageLocation = null;
            people.ImagePath = pBPerson.ImageLocation;
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(people.ImagePath))
                return;

             if (rdbMale.Checked)
                pBPerson.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\user_male_50px.png";
        }
        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(people.ImagePath))
                return;
            if (rdbFemale.Checked)
                pBPerson.ImageLocation = @"D:\DVLD\DVLManagementSystem\DVLManagementSystem\Resources\female_user_50px.png";
        }
    }
}
