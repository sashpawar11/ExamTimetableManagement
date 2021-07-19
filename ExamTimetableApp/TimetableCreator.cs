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
    public partial class TimetableCreator : Form
    {
        public TimetableCreator()
        {
            InitializeComponent();
        }

        private void numSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            string subjects = numSub.Text.ToString();
            switch (subjects)
            {

                case "1":
                    sub1.Show();
                    break;

                case "2":
                    sub1.Show();
                    sub2.Show();
                    break;

                case "3":
                    sub1.Show();
                    sub2.Show();
                    sub3.Show();
                    break;
                case "4":
                    sub1.Show();
                    sub2.Show();
                    sub3.Show();
                    sub4.Show();
                    break;
                case "5":
                    sub1.Show();
                    sub2.Show();
                    sub3.Show();
                    sub4.Show();
                    sub5.Show();
                    break;
                case "6":
                    sub1.Show();
                    sub2.Show();
                    sub3.Show();
                    sub4.Show();
                    sub5.Show();
                    sub6.Show();
                    break;
                default:
                    MessageBox.Show("Please Select Number of Subjects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sub = string.IsNullOrEmpty(numSub.Text.ToString());
            if (sub)
            {
                MessageBox.Show("Please Select Number of Subjects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                TimeTable tm = new TimeTable();
                tm.Closed += (s, args) => this.Close();
                tm.Show();
            }
        }

        private void TimetableCreator_Load(object sender, EventArgs e)
        {
            sub1.Hide();
            sub2.Hide();
            sub3.Hide();
            sub4.Hide();
            sub5.Hide();
            sub6.Hide();

        }
    }
}
