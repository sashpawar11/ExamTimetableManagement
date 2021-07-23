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
using System.Data.OleDb;

namespace ExamTimetableApp
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }
        public static string departmentName;
        public static string year;

        private void button1_Click(object sender, EventArgs e)
        {
            departmentName = departmentBox.SelectedItem.ToString();
            year = yearBox.SelectedItem.ToString();
            
            this.Hide();
            TimetableCreator tc = new TimetableCreator();
            tc.Closed += (s, args) => this.Close();
            tc.Show();
        

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Navigation_Load(object sender, EventArgs e)
        {
            bool adminaccess = Login.admin;
            opentable.Show();
            createbtn.Hide();
            
            if(adminaccess)
            {
                createbtn.Show();
                
            }
          
        }

        private void opentable_Click(object sender, EventArgs e)
        {
            departmentName = departmentBox.SelectedItem.ToString();
            year = yearBox.SelectedItem.ToString();

            this.Hide();
            TimeTable tb = new TimeTable();
            if(tb == null)
            {
                    MessageBox.Show("Please Select Number of Subjects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tb.Closed += (s, args) => this.Close();
                tb.Show();
            }
            tb.Closed += (s, args) => this.Close();
            tb.Show();
        }

       
    }
}
