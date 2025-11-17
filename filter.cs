using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DVLD_Buisness;
using Buisness;

namespace DVLManagementSystem
{
    public partial class filter : UserControl
    {
        public filter()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo personInfo = new frmAddEditPersonInfo(-1);
            personInfo.ShowDialog();
        }
        clsPeople people;
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(cbFiltter.Text == "NationalNo")
            {
                people = clsPeople.Find(txtFilter.Text);
                
                if(people == null)
                {
                    MessageBox.Show("there's no infomation");
                    return;
                }

                personinfo1.lbID.Text = people._PersonID.ToString();
                personinfo1.lblAddress.Text = people._Address;
                personinfo1.lblCountry.Text = people.CountryInfo._CountryName;
                personinfo1.lblDate.Text = people._DateOfBirth.ToShortDateString();
                personinfo1.lblEmail.Text = people._Email;
                personinfo1.lblName.Text = people._FirstName +" "+people._SecondName+" "+people._ThirdName+" "+people._LastName;
                personinfo1.lblNationalNo.Text = people._NationalNo;
                personinfo1.lblPhone.Text = people._Phone;
                if(people._Gendor == 0)
                    personinfo1.lblGender.Text = "Male";
                else
                    personinfo1.lblGender.Text = "Female";

                personinfo1.picPerson.ImageLocation = people.ImagePath;
            }
        }

        private void filter_Load(object sender, EventArgs e)
        {
            cbFiltter.SelectedIndex = 0;
        }
    }
}
