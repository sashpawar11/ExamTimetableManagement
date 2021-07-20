using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamTimetableApp
{
    public partial class AdminSelector : Form
    {
        public AdminSelector()
        {
            InitializeComponent();
        }
        public static string departmentName;
        public static string year;

        private void button1_Click(object sender, EventArgs e)
        {
            departmentName = departmentBox.Text.ToString();
            year = yearBox.Text.ToString();
            this.Hide();
            TimetableCreator tc = new TimetableCreator();
            tc.Closed += (s, args) => this.Close();
            tc.Show();
        

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
