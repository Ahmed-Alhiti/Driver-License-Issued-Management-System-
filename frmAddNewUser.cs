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
    public partial class frmAddNewUser : Form
    {
        //clsPeople people;
        clsUsers users;
        int User_id;
        enum enMode { AddnNew = 0, Update = 1 }
        enMode mode;
        public frmAddNewUser(int id)
        {
            InitializeComponent();
            if (id == -1)
            {
                mode = enMode.AddnNew;
            }
            else
            {
                User_id = id;
                mode = enMode.Update;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void _LoadData()
        {
            if (mode == enMode.AddnNew)
            {
                users = new clsUsers();
                return;
            }

            label1.Text = "Update User";
            filter1.Enabled = false;
            tabControl1.SelectedTab = tabPage2;
            users = clsUsers.Find_ByID(User_id);
            lblID.Text = users._UserID.ToString();
            txtUserName.Text = users._UserName;
            txtPassword.Text = users._Password;
            txtConfirmPassword.Text = users._Password;
            cBisActive.Checked = users._IsActive;

            //people = clsPeople.FindBaseApplication(users._PersonID);
            filter1.personinfo1.lbID.Text = users.PersonInfo._PersonID.ToString();
            filter1.personinfo1.lblAddress.Text = users.PersonInfo._Address;
            filter1.personinfo1.lblCountry.Text = users.PersonInfo.CountryInfo._CountryName;
            filter1.personinfo1.lblDate.Text = users.PersonInfo._DateOfBirth.ToShortDateString();
            filter1.personinfo1.lblEmail.Text = users.PersonInfo._Email;
            if (users.PersonInfo._Gendor == 0)
                filter1.personinfo1.lblGender.Text = "Male";
            else
                filter1.personinfo1.lblGender.Text = "Female";
            filter1.personinfo1.lblName.Text = users.PersonInfo.FullName;
            filter1.personinfo1.lblNationalNo.Text = users.PersonInfo._NationalNo;
            filter1.personinfo1.lblPhone.Text = users.PersonInfo._Phone;
            filter1.personinfo1.picPerson.ImageLocation = users.PersonInfo.ImagePath;

        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(mode== enMode.AddnNew)
            {
                if (clsUsers.isUserExistFor_Person_ID(int.Parse(filter1.personinfo1.lbID.Text)))
                {
                    if (string.IsNullOrEmpty(txtUserName.Text))
                    {
                        if (MessageBox.Show("You must to add user info first") == DialogResult.OK)
                        {
                            tabControl1.SelectedTab = tabPage2;
                            txtUserName.Focus();
                        }

                    }
                    else
                    {
                        if (tabControl1.SelectedTab == tabPage2)
                        {
                            users = new clsUsers();
                            users._Password = txtPassword.Text;
                            users._UserName = txtUserName.Text;
                            users._IsActive = cBisActive.Checked;
                            users._PersonID = (int.Parse(filter1.personinfo1.lbID.Text));
                            if (users.Save())
                            {
                                MessageBox.Show("Data Saved Succesfuly");
                                lblID.Text = users._UserID.ToString();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Cann't save Data");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("There's allready User Acount Linked with this person account", "Warnning", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }
                return;
            }

            users._Password = txtPassword.Text;
            users._UserName = txtUserName.Text;
            users._IsActive = cBisActive.Checked;
            users._PersonID = (int.Parse(filter1.personinfo1.lbID.Text));
            if (users.Save())
            {
                MessageBox.Show("Data updated Succesfuly");
                return;
            }
            else
            {
                MessageBox.Show("Cann't update Data");
            }
            

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "This Filed Recuired");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "This Filed Recuired");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "This Filed Recuired");
                e.Cancel = true;
            }
            if(txtConfirmPassword.Text != txtPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword, "_Password doesn't matched");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

    }
}
