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
    public partial class frmUpdateTestType : Form
    {
        clsTestTypes type;
        int Type_id = -1;
        public frmUpdateTestType(int id)
        {
            InitializeComponent();
            Type_id = id;
        }

        private void _LoadData()
        {
            clsTestTypes.enTestType testType = (Type_id == 1) ? clsTestTypes.enTestType.VisionTest : (Type_id == 2) ? clsTestTypes.enTestType.WrittenTest : clsTestTypes.enTestType.StreetTest;


            type = clsTestTypes.Find(testType);
            lblID.Text = type._TestTypeID.ToString();
            txtDescription.Text = type._TestTypeDescription;
            txtFees.Text = type._TestTypeFees.ToString();
            txtTitle.Text = type._TestTypeTitle;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            type._TestTypeTitle = txtTitle.Text;
            type._TestTypeFees = Convert.ToSingle(txtFees.Text);
            type._TestTypeDescription = txtDescription.Text;
            if (type.Save())
            {
                MessageBox.Show("Updated succesfuly");
                
            }
            else
                MessageBox.Show("error");

        }
    }
}
