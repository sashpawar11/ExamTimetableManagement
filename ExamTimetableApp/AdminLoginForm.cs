using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTimetableApp
{
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((username.Text == "dbce" ) &&  (password.Text == "dbcegoa123"))
            {
                
                this.Hide();
                AdminSelector asr = new AdminSelector();
                asr.Closed += (s, args) => this.Close();
                asr.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username & Password. Please Retry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
