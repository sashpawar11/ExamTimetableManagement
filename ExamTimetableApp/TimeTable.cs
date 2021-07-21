using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
    public partial class TimeTable : Form
    {
        public TimeTable()
        {
            InitializeComponent();
        }

        public static string connectionString = "";
        public static int numberofsub;
        public static string departmentnm = Navigation.departmentName;
        public static string year = Navigation.year;
        private void button1_Click(object sender, EventArgs e)
        {
            using( var bmp = new Bitmap(timetablepanel.Width, timetablepanel.Height))
            {
                timetablepanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"savedtimetables/jpg/examtimetable.jpg");
            }



            string source  = @"savedtimetables/jpg/examtimetable.jpg";
            string destination = @"savedtimetables/pdf/examtimetable.pdf";
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.AddPage();
            page.Width = timetablepanel.Width;
            page.Height = timetablepanel.Height;
            XGraphics xgr = XGraphics.FromPdfPage(page);
            XImage img = XImage.FromFile(source);
            xgr.DrawImage(img, 0, 0, (int)page.Width, (int)page.Height);
            doc.Save(destination);
            doc.Close();
            MessageBox.Show("Timetable Successfully Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
      
           
        }
    

        void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }

        private void TimeTable_Load(object sender, EventArgs e)
        {
            sub1panel.Hide();
            sub2panel.Hide();
            sub3panel.Hide();
            sub4panel.Hide();
            sub5panel.Hide();
            sub6panel.Hide();


            if (departmentnm == "Computer Engineering")
            {
                connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\ComputerEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                OleDbConnection odb = new OleDbConnection(connectionString);
                viewTimetable(odb);


            }
            if (departmentnm == "Civil Engineering")
            {
                connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\CivilEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                OleDbConnection odb = new OleDbConnection(connectionString);
                viewTimetable(odb);


            }
            if (departmentnm == "Mechanical Engineering")
            {
                connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\MechanicalEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                OleDbConnection odb = new OleDbConnection(connectionString);
                viewTimetable(odb);

            }
            if (departmentnm == "Electronics & Telecommunication Engineering")
            {
                connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\Electronics&TelecommunicationEngineering.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                OleDbConnection odb = new OleDbConnection(connectionString);
                viewTimetable(odb);

            }
            if (departmentnm == "Science & Humanities")
            {
                connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                            Data source = D:\timetabledatabase\Science&Humanities.xlsx; 
                            Extended Properties = 'Excel 8.0'";
                OleDbConnection odb = new OleDbConnection(connectionString);
                viewTimetable(odb);


            }
            


        }

        private void viewTimetable(OleDbConnection odb)
        {


            //string connection = string.Format(@"{0}", getConsstring());
            DataTable Timetableheaders = new DataTable();
            DataTable Timetabledata = new DataTable();
            odb.Open();
            OleDbCommand cmd = new OleDbCommand();

            //importing timetable headers 
            string th = @"SELECT * from [DT$]";
            cmd.Connection = odb;
            cmd.CommandText = th;
            cmd.ExecuteNonQuery();
            ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetableheaders);
            //Checks for empty rows in datatable and deletes them
          
            try
            {
                Timetableheaders = Timetableheaders.Rows
                   .Cast<DataRow>()
                   .Where(row => !row.ItemArray.All(field => field is DBNull ||
                                                    string.IsNullOrWhiteSpace(field as string)))
                   .CopyToDataTable();
            }
            catch (Exception)
            {
                MessageBox.Show("Failure in reading database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            setHeaderLabels(Timetableheaders);
            getSubjectPanels(Timetableheaders);
            if ((year == "FE"))
            {
                string query = @"SELECT * from [FE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "SE"))
            {
                string query = @"SELECT * from [SE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "TE"))
            {
                string query = @"SELECT * from [TE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "BE"))
            {
                string query = @"SELECT * from [BE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetabledata);        // Filling the DataTable with all entries from Excel File (Oxygen Suppliers)
            odb.Close();
            try
            {
                Timetabledata = Timetabledata.Rows
                   .Cast<DataRow>()
                   .Where(row => !row.ItemArray.All(field => field is DBNull ||
                                                    string.IsNullOrWhiteSpace(field as string)))
                   .CopyToDataTable();
            }
            catch (Exception)
            {
                MessageBox.Show("Failure in reading database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            displayData(Timetabledata);

        }

        private void setHeaderLabels(DataTable x)
        {
         
         

            int i = (x.Rows.Count - 1);
            string yrheader = x.Rows[i][0].ToString();
            string departmentheader = x.Rows[i][1].ToString();
            string examtitleheader = x.Rows[i][2].ToString();

            yrlabel.Text = yrheader;
            deptalbel.Text = departmentheader;
            examtitle.Text = examtitleheader;

         

        }
        private void getSubjectPanels(DataTable x)
        {
            int i = x.Rows.Count - 1;
            string yrheader = x.Rows[i][0].ToString();
            string departmentheader = x.Rows[i][1].ToString();
            string examtitleheader = x.Rows[i][2].ToString();

            numberofsub = int.Parse(x.Rows[i][3].ToString());  
            
            switch (numberofsub.ToString())
            {

                case "1":
                    sub1panel.Show();
                    break;

                case "2":
                    sub1panel.Show();
                    sub2panel.Show();
                    break;

                case "3":
                    sub1panel.Show();
                    sub2panel.Show();
                    sub3panel.Show();
                    break;
                case "4":
                    sub1panel.Show();
                    sub2panel.Show();
                    sub3panel.Show();
                    sub4panel.Show();
                    break;
                case "5":
                    sub1panel.Show();
                    sub2panel.Show();
                    sub3panel.Show();
                    sub4panel.Show();
                    sub5panel.Show();
                    break;
                case "6":
                    sub1panel.Show();
                    sub2panel.Show();
                    sub3panel.Show();
                    sub4panel.Show();
                    sub5panel.Show();
                    sub6panel.Show();
                    break;
                default:
                    MessageBox.Show("Something went wrong! Retry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void displayData(DataTable s)
        {
            int i;
            for (i = 0; i < numberofsub; i++)
            {
                string subname = s.Rows[i][0].ToString();
                string daydate = s.Rows[i][1].ToString();
                string starttime = s.Rows[i][2].ToString();
                string endtime = s.Rows[i][3].ToString();

               if(i == 0)
                {
                    sub1date.Text = daydate;
                    sub1name.Text = subname;
                    sub1start.Text = starttime;
                    sub1end.Text = endtime;
                }
            }
        }

        private void timetablepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        //private string getConsstring()
        //{

        //    if (departmentnm == "Computer Engineering")
        //    {
        //        string conn = @"provider = Microsoft.ACE.OLEDB.12.0; 
        //                    Data source = D:\timetabledatabase\ComputerEngineering.xlsx; 
        //                    Extended Properties = 'Excel 8.0'";
        //        return conn;

        //    }
        //    if (departmentnm == "Civil Engineering")
        //    {
        //        string conn = @"provider = Microsoft.ACE.OLEDB.12.0; 
        //                    Data source = D:\timetabledatabase\CivilEngineering.xlsx; 
        //                    Extended Properties = 'Excel 8.0'";
        //        return conn;

        //    }
        //    if (departmentnm == "Mechanical Engineering")
        //    {
        //        string conn = @"provider = Microsoft.ACE.OLEDB.12.0; 
        //                    Data source = D:\timetabledatabase\MechanicalEngineering.xlsx; 
        //                    Extended Properties = 'Excel 8.0'";

                
        //        return conn;

        //    }
        //    if (departmentnm == "Electronics & Telecommunication Engineering")
        //    {
        //        string conn = @"provider = Microsoft.ACE.OLEDB.12.0; 
        //                    Data source = D:\timetabledatabase\Electronics&TelecommunicationEngineering.xlsx; 
        //                    Extended Properties = 'Excel 8.0'";
        //        return conn;

        //    }
        //    if (departmentnm == "Science & Humanities")
        //    {
        //        string conn = @"provider = Microsoft.ACE.OLEDB.12.0; 
        //                    Data source = D:\timetabledatabase\Science&Humanities.xlsx; 
        //                    Extended Properties = 'Excel 8.0'";
        //        return conn;

        //    }
        //    else
        //    {
        //        return "Error!";
        //    }
        //}
    }
}
