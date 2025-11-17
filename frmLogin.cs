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
using System.IO;
using Microsoft.Win32;

namespace DVLManagementSystem
{
    public partial class frmLogin : Form
    {
        private string _Path = "users.txt";

        public frmLogin()
        {
            InitializeComponent();
            _LoadUserData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _LoadUserData()
        {
            if (File.Exists(_Path))
            {
                string[] lines = File.ReadAllLines(_Path);
                if(lines.Length >= 2)
                {
                    txtUsername.Text = lines[0];
                    txtPassword.Text = lines[1];
                    chBRemeberMe.Checked = true;
                }
            }
        }

        private void _SaveUserData()
        {
            try
            {
                //string directory = _Path;
                if (!File.Exists(_Path))
                {
                    File.WriteAllText(_Path, $"{txtUsername.Text}{Environment.NewLine}{txtPassword.Text}");
                }
                else
                {
                    File.WriteAllText(_Path, $"{txtUsername.Text}{Environment.NewLine}{txtPassword.Text}");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void _DeleteUserData()
        {
            try
            {
                if (File.Exists(_Path))
                {
                    File.Delete(_Path);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _SavetoRegistry()
        {
            string path = @"HKEY_CURRENT_USER\SOFTWARE\DVLDMSYS";
            
            try
            {
                Registry.SetValue(path,"_UserName", txtUsername.Text, RegistryValueKind.String);
                Registry.SetValue(path,"PassWord", txtPassword.Text, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void _DeleteFromRegistry()
        {
            string path = @"SOFTWARE\DVLDMSYS";

            try
            {
                using(RegistryKey basekey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using(RegistryKey supkey = basekey.OpenSubKey(path, true))
                    {
                        try
                        {
                            if(supkey != null)
                            {
                                supkey.DeleteValue("_UserName");
                                supkey.DeleteValue("PassWord");

                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void _LoadFromRegistry()
        {
            string path = @"HKEY_CURRENT_USER\SOFTWARE\DVLDMSYS";

            try
            {
                txtUsername.Text= Registry.GetValue(path, "_UserName", null) as string;
                txtPassword.Text= Registry.GetValue(path, "PassWord", null) as string;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUsers users = clsUsers.FindByUserNameAndPassword(txtUsername.Text, txtPassword.Text);
            if(users != null)
            {
                if(users._IsActive == false)
                {
                    MessageBox.Show("Your Account Isn't Active");
                    return;
                }
                else
                {
                    MessageBox.Show("Login Successfuly");
                    clsCurrentUser.id = users._UserID;
                    if (chBRemeberMe.Checked)
                    {
                        _SaveUserData();
                        //_SavetoRegistry();
                    }
                    else
                    {
                        _DeleteUserData();
                        //_DeleteFromRegistry();
                    }
                    MainForm main = new MainForm();
                    this.Hide();
                    main.Show();
                }
                return;
            }
            else
            {
                MessageBox.Show("Invaild Username or _Password");
            }

        }




    }
}
