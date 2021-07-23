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

        
        public static int numberofsub;
        public static string departmentnm = Navigation.departmentName;
        public static string year = Navigation.year;
        private void button1_Click(object sender, EventArgs e)
        {
            using( var bmp = new Bitmap(timetablepanel.Width, timetablepanel.Height))
            {
                button1.Hide();
                timetablepanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"D:/savedtimetables/jpg/examtimetable.jpg");
            }




            string source  = @"D:/savedtimetables/jpg/examtimetable.jpg";
            string destination = @"D:/savedtimetables/pdf/examtimetable.pdf";
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
            button1.Show();
            

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
                string connectionString = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\ComputerEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";

                OleDbConnection odb1 = new OleDbConnection(connectionString);
                viewTimetable(odb1);



            }
            if (departmentnm == "Civil Engineering")
            {
                string con2 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\CivilEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb2 = new OleDbConnection(con2);
                viewTimetable(odb2);

            }
            if (departmentnm == "Mechanical Engineering")
            {
                string con3 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\MechanicalEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb3 = new OleDbConnection(con3);
                viewTimetable(odb3);


            }
            if (departmentnm == "Electronics & Telecommunication Engineering")
            {
                string con4 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\Electronics&TelecommunicationEngineering.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb4 = new OleDbConnection(con4);
                viewTimetable(odb4);


            }
            if (departmentnm == "Science & Humanities")
            {
                string con5 = @"provider = Microsoft.ACE.OLEDB.12.0; 
                                Data source = D:\timetabledatabase\Science&Humanities.xlsx; 
                                Extended Properties = 'Excel 8.0'";
                OleDbConnection odb5 = new OleDbConnection(con5);
                viewTimetable(odb5);

            }

            


        }

        private void viewTimetable(OleDbConnection odb)
        {

            
            odb.Open();
            DataTable Timetableheaders = new DataTable();
            DataTable Timetabledata = new DataTable();
            
            OleDbCommand cmd = new OleDbCommand();
            if ((year == "FE"))
            {
                string th = @"SELECT * from [DT$] WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetableheaders);
                string query = @"SELECT * from [FE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "SE"))
            {
                string th = @"SELECT * from [DT$] WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetableheaders);
                string query = @"SELECT * from [SE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "TE"))
            {
                string th = @"SELECT * from [DT$] WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetableheaders);
                string query = @"SELECT * from [TE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            if ((year == "BE"))
            {
                string th = @"SELECT * from [DT$] WHERE [Year] = '" + year + "'";
                cmd.Connection = odb;
                cmd.CommandText = th;
                cmd.ExecuteNonQuery();
                ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetableheaders);
                string query = @"SELECT * from [BE$]";
                cmd.Connection = odb;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            ((OleDbDataAdapter)new OleDbDataAdapter(cmd)).Fill(Timetabledata);        // Filling the DataTable with all entries from Excel File
            odb.Close();
            setHeaderLabels(Timetableheaders);
            getSubjectPanels(Timetableheaders);
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
               
            }

            displayData(Timetabledata);

        }

        private void setHeaderLabels(DataTable x)   
        {
            int i = x.Rows.Count - 1;
            if(x.Rows.Count > 0)
            {
                string yrheader = x.Rows[i][0].ToString();
                string departmentheader = x.Rows[i][1].ToString();
                string examtitleheader = x.Rows[i][2].ToString();
                yrlabel.Text = yrheader;
                deptalbel.Text = departmentheader;
                examtitle.Text = examtitleheader;
            }
            else
            {
                MessageBox.Show("Timetable Not Generated!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
           




        }
        private void getSubjectPanels(DataTable x)
        {
            int i = x.Rows.Count - 1;
            string yrheader = x.Rows[i][0].ToString();
            string departmentheader = x.Rows[i][1].ToString();
            string examtitleheader = x.Rows[i][2].ToString();
            if (x.Rows.ToString() == string.Empty)
            {
                MessageBox.Show("Please Select Number of Subjects!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            if (numberofsub == 1)
            {
                string sub1nm = s.Rows[0][0].ToString();
                string sub1dy = s.Rows[0][1].ToString();
                string sub1st = s.Rows[0][2].ToString();
                string sub1et = s.Rows[0][3].ToString();
                sub1date.Text = sub1dy;
                sub1name.Text = sub1nm;
                sub1start.Text = sub1st;
                sub1end.Text = sub1et;
            }



            for (i = 0; i < numberofsub; i++)
            {
                
              
                if (i == 0)
                {
                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub1date.Text = subdy;
                    sub1name.Text = subnm;
                    sub1start.Text = subst;
                    sub1end.Text = subet;
                }
                if(i == 1)
                {

                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub2date.Text = subdy;
                    sub2name.Text = subnm;
                    sub2start.Text = subst;
                    sub2end.Text = subet;
                }
                if (i == 2)
                {
                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub3date.Text = subdy;
                    sub3name.Text = subnm;
                    sub3start.Text = subst;
                    sub3end.Text = subet;
                }
                if (i == 3)
                {
                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub4date.Text = subdy;
                    sub4name.Text = subnm;
                    sub4start.Text = subst;
                    sub4end.Text = subet;
                }
                if (i == 4)
                {
                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub5date.Text = subdy;
                    sub5name.Text = subnm;
                    sub5start.Text = subst;
                    sub5end.Text = subet;
                }
                if (i == 5)
                {
                    string subdy = s.Rows[i][0].ToString();
                    string subnm = s.Rows[i][1].ToString();
                    string subst = s.Rows[i][2].ToString();
                    string subet = s.Rows[i][3].ToString();
                    sub6date.Text = subdy;
                    sub6name.Text = subnm;
                    sub6start.Text = subst;
                    sub6end.Text = subet;
                }
            }
        }

        private void timetablepanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sub1daypanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void examtitle_Click(object sender, EventArgs e)
        {

        }

        private void deptalbel_Click(object sender, EventArgs e)
        {

        }

        private void sub1daypanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void examtitle_Click_1(object sender, EventArgs e)
        {

        }
    }
}
