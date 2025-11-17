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
    public partial class frmDrivers : Form
    {
        public frmDrivers()
        {
            InitializeComponent();
        }

        private void LoadDrivers()
        {
            dgvDrivers.DataSource = clsDrivers.GetAll();

        }

        private void frmDrivers_Load(object sender, EventArgs e)
        {
            LoadDrivers();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
