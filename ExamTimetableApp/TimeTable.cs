using PdfSharp.Drawing;
using PdfSharp.Pdf;
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
    public partial class TimeTable : Form
    {
        public TimeTable()
        {
            InitializeComponent();
        }
        public static string departmentName = AdminSelector.departmentName;
        public static string year = AdminSelector.year;

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

        }
    }
}
