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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginForm al = new AdminLoginForm();
            al.Closed += (s, args) =>this.Close();
            al.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            StudentSelectionMenu sm= new StudentSelectionMenu();
            sm.Closed += (s, args) => this.Close();
            sm.Show();
        }
    }
}
