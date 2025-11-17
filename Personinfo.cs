using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLManagementSystem
{
    public partial class Personinfo : UserControl
    {
        public Personinfo()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPersonInfo personInfo = new frmAddEditPersonInfo(int.Parse(lbID.Text));
            personInfo.ShowDialog();
        }
    }
}
