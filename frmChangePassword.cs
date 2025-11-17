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
    public partial class frmChangePassword : Form
    {
        //clsPeople people;
        clsUsers users;
        int User_id = -1;
        public frmChangePassword(int id)
        {
            InitializeComponent();
            User_id = id;
        }

        private void _LoadData()
        {
            users = clsUsers.Find_ByID(User_id);
            lbID.Text = users._UserID.ToString();
            lblIsActive.Text = users._IsActive.ToString();
            lblUserName.Text = users._UserName;
            
            //people = clsPeople.FindBaseApplication(users._PersonID);
            personinfo1.lbID.Text = users.PersonInfo._PersonID.ToString();
            personinfo1.lblAddress.Text = users.PersonInfo._Address;
            personinfo1.lblCountry.Text = users.PersonInfo.CountryInfo._CountryName;
            personinfo1.lblDate.Text = users.PersonInfo._DateOfBirth.ToShortDateString();
            personinfo1.lblEmail.Text = users.PersonInfo._Email;
            if (users.PersonInfo._Gendor == 0)
                personinfo1.lblGender.Text = "Male";
            else
                personinfo1.lblGender.Text = "Female";
            personinfo1.lblName.Text = users.PersonInfo.FullName;
            personinfo1.lblNationalNo.Text = users.PersonInfo._NationalNo;
            personinfo1.lblPhone.Text = users.PersonInfo._Phone;
            personinfo1.picPerson.ImageLocation = users.PersonInfo.ImagePath;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtCurrentPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPass.Text))
            {
                errorProvider1.SetError(txtCurrentPass, "This Filed Recuired");
                e.Cancel = true;
            }
            else if (txtCurrentPass.Text != users._Password)
            {
                errorProvider1.SetError(txtCurrentPass, "This _Password Doesn't Matched the current _Password");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPass, "");
            }
        }

        private void txtNewPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPass.Text))
            {
                errorProvider1.SetError(txtNewPass, "This Filed Recuired");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNewPass, "");
            }
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                errorProvider1.SetError(txtConfirm, "This Filed Recuired");
                e.Cancel = true;
            }
            else if (txtConfirm.Text != txtNewPass.Text)
            {
                errorProvider1.SetError(txtConfirm, "Doesn't match");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirm, "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            users._Password = txtConfirm.Text;
            if (users.Save())
                MessageBox.Show("saved");
            else
                MessageBox.Show("error");
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _LoadData();

        }
    }
}
