using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

        public static string dept = Navigation.departmentName;
        public static string yr = Navigation.year;
        public static int numberofSubjects;
        public static string connectionString= @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Extended Properties = 'Excel 8.0'";



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
                if (dept == "Computer Engineering")
                {
                    connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\ComputerEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                    OleDbConnection odb= new OleDbConnection(connectionString);
                    


                }
                if (dept == "Civil Engineering")
                {
                    connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\CivilEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                    OleDbConnection odb = new OleDbConnection(connectionString);
                    generateTimetable(odb);

                }
                if (dept == "Mechanical Engineering")
                {
                    connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\MechanicalEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                    OleDbConnection odb = new OleDbConnection(connectionString);
                    generateTimetable(odb);


                }
                if (dept == "Electronics & Telecommunication Engineering")
                {
                    connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\Electronics&TelecommunicationEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                    OleDbConnection odb = new OleDbConnection(connectionString);
                    generateTimetable(odb);


                }
                if (dept == "Science & Humanities")
                {
                    connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\Science&Humanities.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                    OleDbConnection odb = new OleDbConnection(connectionString);
                    generateTimetable(odb);

                }
                
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

        private void generateTimetable(OleDbConnection odb)
        {
            numberofSubjects = int.Parse(numSub.Text);
            
            odb.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = odb;
            string headers = "INSERT INTO [DT$] ([Year], [Department], [ExamTitle], [NumSub]) VALUES('" + yr + "','" + dept + "','" + examtitle.Text + "','" + numberofSubjects + "')";
            cmd.CommandText = headers;
            cmd.ExecuteNonQuery();

            if (yr == "FE")
            {
                for (int i = 1; i <= numberofSubjects; i++)
                {
                    if (i == 1)
                    {
                        string query = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 2)
                    {
                        string query1 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 3)
                    {
                        string query1 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 4)
                    {
                        string query1 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 5)
                    {
                        string query1 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 6)
                    {
                        string query1 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        string query6 = "INSERT INTO [FE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub6name.Text + "','" + sub6date.Text + "','" + sub6start.Text + "','" + sub6end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.CommandText = query6;
                        cmd.ExecuteNonQuery();

                    }
                }
            }

            if (yr == "SE")
            {
                for (int i = 1; i <= numberofSubjects; i++)
                {
                    if (i == 1)
                    {
                        string query = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 2)
                    {
                        string query1 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 3)
                    {
                        string query1 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 4)
                    {
                        string query1 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 5)
                    {
                        string query1 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 6)
                    {
                        string query1 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        string query6 = "INSERT INTO [SE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub6name.Text + "','" + sub6date.Text + "','" + sub6start.Text + "','" + sub6end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.CommandText = query6;
                        cmd.ExecuteNonQuery();

                    }

                }
            }
            if (yr == "TE")
            {
                for (int i = 1; i <= numberofSubjects; i++)
                {
                    if (i == 1)
                    {
                        string query = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 2)
                    {
                        string query1 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 3)
                    {
                        string query1 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 4)
                    {
                        string query1 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 5)
                    {
                        string query1 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 6)
                    {
                        string query1 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        string query6 = "INSERT INTO [TE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub6name.Text + "','" + sub6date.Text + "','" + sub6start.Text + "','" + sub6end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.CommandText = query6;
                        cmd.ExecuteNonQuery();

                    }
                }

            }
            if (yr == "BE")
            {
                for (int i = 1; i <= numberofSubjects; i++)
                {
                    if (i == 1)
                    {
                        string query = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 2)
                    {
                        string query1 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 3)
                    {
                        string query1 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 4)
                    {
                        string query1 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 5)
                    {
                        string query1 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.ExecuteNonQuery();

                    }
                    if (i == 6)
                    {
                        string query1 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub1name.Text + "','" + sub1date.Text + "','" + sub1start.Text + "','" + sub1end.Text + "')";
                        string query2 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub2name.Text + "','" + sub2date.Text + "','" + sub2start.Text + "','" + sub2end.Text + "')";
                        string query3 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub3name.Text + "','" + sub3date.Text + "','" + sub3start.Text + "','" + sub3end.Text + "')";
                        string query4 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub4name.Text + "','" + sub4date.Text + "','" + sub4start.Text + "','" + sub4end.Text + "')";
                        string query5 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub5name.Text + "','" + sub5date.Text + "','" + sub5start.Text + "','" + sub5end.Text + "')";
                        string query6 = "INSERT INTO [BE$] ([Subject], [Day/Date], [Start-Time], [End-Time]) VALUES('" + sub6name.Text + "','" + sub6date.Text + "','" + sub6start.Text + "','" + sub6end.Text + "')";
                        cmd.CommandText = query1;
                        cmd.CommandText = query2;
                        cmd.CommandText = query3;
                        cmd.CommandText = query4;
                        cmd.CommandText = query5;
                        cmd.CommandText = query6;
                        cmd.ExecuteNonQuery();

                    }
                }
            }

            odb.Close();




        }
    }
}


                                    

        
                          
                       
        
    

