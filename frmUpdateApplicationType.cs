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
    public partial class frmUpdateApplicationType : Form
    {
        int app_id = -1;
        clsAppsTypes type;
        public frmUpdateApplicationType(int id)
        {
            InitializeComponent();
            app_id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void _LoadData()
        {
            type = clsAppsTypes.Find_ByID(app_id);
            txtTitle.Text = type._ApplicationTypeTitle;
            txtFees.Text = type._ApplicationFees.ToString();
            lblID.Text = type._ApplicationTypeID.ToString();
        }

        private void frmUpdateApplicationType_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            type._ApplicationFees = short.Parse(txtFees.Text);
            type._ApplicationTypeTitle = txtTitle.Text;
            if (type.Save())
            {
                MessageBox.Show("Updated succesfuly");
            }
            else
                MessageBox.Show("Error");

        }
    }
}
