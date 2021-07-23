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
            updatebtn.Hide();
            if(adminaccess)
            {
                createbtn.Show();
                updatebtn.Show();
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

        //Deleting Existing timetable function - currently under dev
        private void updatebtn_Click(object sender, EventArgs e)
        {
            departmentName = departmentBox.SelectedItem.ToString();
            year = yearBox.SelectedItem.ToString();
            if (departmentName == "Computer Engineering")
            {
                string connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\ComputerEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";

                OleDbConnection odb1 = new OleDbConnection(connectionString);
                deleteTimetable(odb1);



            }
            if (departmentName == "Civil Engineering")
            {
                string con2 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\CivilEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb2 = new OleDbConnection(con2);
                deleteTimetable(odb2);

            }
            if (departmentName == "Mechanical Engineering")
            {
                string con3 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\MechanicalEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb3 = new OleDbConnection(con3);
                deleteTimetable(odb3);


            }
            if (departmentName == "Electronics & Telecommunication Engineering")
            {
                string con4 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\Electronics&TelecommunicationEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb4 = new OleDbConnection(con4);
                deleteTimetable(odb4);


            }
            if (departmentName == "Science & Humanities")
            {
                string con5 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\Science&Humanities.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb5 = new OleDbConnection(con5);
                deleteTimetable(odb5);

            }
        }

        private void deleteTimetable(OleDbConnection odb)
        {
            odb.Open();

            OleDbCommand cmd = new OleDbCommand();

            if ((year == "FE"))
            {
                string th = @"UPDATE [DT$] SET [Year] = '" + string.Empty + "', [Department] = '" + string.Empty + "', [ExamTitle] = '" + string.Empty + "', [NumSub] = '" + string.Empty + "' WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                string td = @"UPDATE [FE$] SET [Subject] = '" + string.Empty + "', [Day/Date] = '" + string.Empty + "', [Start-Time] = '" + string.Empty + "', [End-Time] = '" + string.Empty + "'";
                cmd.Connection = odb;
                cmd.CommandText = td;
                cmd.ExecuteNonQuery();
            }
            if ((year == "SE"))
            {
                string th = @"UPDATE [DT$] SET [Year] = '" + null + "', [Department] = '" + null + "', [ExamTitle] = '" + null + "', [NumSub] = '" + null + "' WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                string td = @"UPDATE [SE$] SET [Subject] = '" + null + "', [Day/Date] = '" + null + "', [Start-Time] = '" + null + "', [End-Time] = '" + null + "'";
                cmd.Connection = odb;
                cmd.CommandText = td;
                cmd.ExecuteNonQuery();
            }
            if ((year == "TE"))
            {
                string th = @"UPDATE [DT$] SET [Year] = '" + null + "', [Department] = '" + null + "', [ExamTitle] = '" + null + "', [NumSub] = '" + null + "' WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                string td = @"UPDATE [TE$] SET [Subject] = '" + null + "', [Day/Date] = '" + null + "', [Start-Time] = '" + null + "', [End-Time] = '" + null + "'";
                cmd.Connection = odb;
                cmd.CommandText = td;
                cmd.ExecuteNonQuery();
            }
            if ((year == "BE"))
            {
                string th = @"UPDATE [DT$] SET [Year] = '" + null + "', [Department] = '" + null + "', [ExamTitle] = '" + null + "', [NumSub] = '" + null + "' WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                string td = @"UPDATE [BE$] SET [Subject] = '" + null + "', [Day/Date] = '" + null + "', [Start-Time] = '" + null + "', [End-Time] = '" + null + "'";
                cmd.Connection = odb;
                cmd.CommandText = td;
                cmd.ExecuteNonQuery();
            }

            odb.Close();
            MessageBox.Show("Timetable Successfully Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
