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
    public partial class AdminSelector : Form
    {
        public AdminSelector()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimetableCreator tc = new TimetableCreator();
            tc.Closed += (s, args) => this.Close();
            tc.Show();
        }
    }
}
