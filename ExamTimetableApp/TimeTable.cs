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

        private void button1_Click(object sender, EventArgs e)
        {
            using( var bmp = new Bitmap(timetablepanel.Width, timetablepanel.Height))
            {
                timetablepanel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                bmp.Save(@"savedtimetables/testtimetable.jpg");
            }
            
            
          

            OpenFileDialog dlg = new OpenFileDialog();

            dlg.InitialDirectory = @"savedtimetables";
            dlg.Filter = "JPEG files (*.jpg)|*.jpg|All files (*.*)|*.*";
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Examination Timetable";

                foreach (string fileSpec in dlg.FileNames)
                {
                    PdfPage page = document.AddPage();
                    page.Width = timetablepanel.Width;
                    page.Height = timetablepanel.Height;
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    DrawImage(gfx, fileSpec, 0, 0, (int)page.Width, (int)page.Height); 
                }
                if (document.PageCount > 0) document.Save(@"savedtimetables/testtimetable.pdf");
            }
        }

        void DrawImage(XGraphics gfx, string jpegSamplePath, int x, int y, int width, int height)
        {
            XImage image = XImage.FromFile(jpegSamplePath);
            gfx.DrawImage(image, x, y, width, height);
        }

    }
}
