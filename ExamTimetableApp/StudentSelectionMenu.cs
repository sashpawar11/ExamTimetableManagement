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
    public partial class StudentSelectionMenu : Form
    {
        public StudentSelectionMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTable tm = new TimeTable();
            tm.Closed += (s, args) => this.Close();
            tm.Show();
        }
    }
}
