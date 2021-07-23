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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public static bool admin = false;
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginForm al = new AdminLoginForm();
            al.Closed += (s, args) =>this.Close();
            al.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            admin = false;
            this.Hide();
            Navigation sm= new Navigation();
            sm.Closed += (s, args) => this.Close();
            sm.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minbtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
