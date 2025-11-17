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
    public partial class frmPersonInfo : Form
    {
        clsPeople people;
        int person_id;
        


        public frmPersonInfo(int id)
        {
            InitializeComponent();
            person_id = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadData()
        {
            people = clsPeople.Find_ByID(person_id);
            personinfo1.lbID.Text = people._PersonID.ToString();
            personinfo1.lblAddress.Text = people._Address;
            personinfo1.lblCountry.Text = people.CountryInfo._CountryName;
            personinfo1.lblDate.Text = people._DateOfBirth.ToShortDateString();
            personinfo1.lblEmail.Text = people._Email;
            if(people._Gendor == 0)
                personinfo1.lblGender.Text = "Male";
            else
                personinfo1.lblGender.Text = "Female";

            personinfo1.lblNationalNo.Text = people._NationalNo;
            personinfo1.lblPhone.Text = people._Phone;
            personinfo1.lblName.Text = people.FullName;
            personinfo1.picPerson.ImageLocation = people.ImagePath;
            
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            _LoadData();

        }
    }
}
