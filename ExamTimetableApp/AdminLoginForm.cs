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

        private void button1_Click_1(object sender, EventArgs e)
        {

            if ((username.Text == "dbce" ) &&  (password.Text == "123"))
            {
                Login.admin = true;
                this.Hide();
                Navigation asr = new Navigation();
                asr.Closed += (s, args) => this.Close();
                asr.Show();
                
            }
            else
            {
                Login.admin = false;
                MessageBox.Show("Invalid Username & Password. Please Retry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
