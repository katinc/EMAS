using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace eMAS.All_UIs.Staff_Information_FORMS
{
    public partial class frmCameraCapture : Form
    {
        private Capture cam;
        private IntPtr m_ip = IntPtr.Zero;
        private int Z_index;

        const int VIDEODEVICE = 0; // zero based index of video capture device to use
        const int VIDEOWIDTH = 640; // Depends on video device caps
        const int VIDEOHEIGHT = 480; // Depends on video device caps
        const int VIDEOBITSPERPIXEL = 24; // BitsPerPixel values determined by device
          

        Rectangle mRect; //will be used for my cropping..

        public Bitmap ImageToUse = null; 
        public frmCameraCapture()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            cam = new Capture(VIDEODEVICE, VIDEOWIDTH, VIDEOHEIGHT, VIDEOBITSPERPIXEL, picDisplay);


        }

        private void frmCameraCapture_Load(object sender, EventArgs e)
        {

        }

        private void frmCameraCapture_FormClosed(object sender, FormClosedEventArgs e)
        {
            cam.Dispose();

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);

            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            // Release any previous buffer
            if (m_ip != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(m_ip);
                m_ip = IntPtr.Zero;
            }

            // capture image
            m_ip = cam.Click();
           Bitmap b = new Bitmap(cam.Width, cam.Height, cam.Stride, PixelFormat.Format24bppRgb, m_ip);
           
             Bitmap new_image = new Bitmap(picCapture.Width , picCapture.Height);
             Graphics g = Graphics.FromImage((Image)new_image );

           g.CompositingQuality = CompositingQuality.HighQuality;
           g.SmoothingMode = SmoothingMode.HighQuality;         

           g.DrawImage(b, 0, 0, picCapture.Width , picCapture.Height);
           

           // If the image is upsidedown. I don't know why but it comes as upside down
           new_image.RotateFlip(RotateFlipType.RotateNoneFlipY);
           picCapture.Image = new_image;

            Cursor.Current = Cursors.Default;
        }
               
       
        private void picCapture_MouseDown(object sender, MouseEventArgs e)
        {           
            mRect = new Rectangle(e.X, e.Y, 0, 0);
            picCapture.Invalidate();           
           
        }
         
        private void picCapture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mRect = new Rectangle(mRect.Left, mRect.Top, e.X - mRect.Left, e.Y - mRect.Top);
                picCapture.Invalidate();               
            }
          
        }

        private void picCapture_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (mRect.Width > 0)
                {
                    Bitmap captured = new Bitmap(picCapture.Image);
                    Bitmap cropped = (Bitmap)captured.Clone((RectangleF)mRect, captured.PixelFormat);
                    picCropped.Image = cropped;

                }
            }
            catch { }
        }
      
       private void picCapture_Paint(object sender, PaintEventArgs e)
       {
           using (Pen p = new Pen(Color.FromArgb(42, 112, 181), 2))
           {
               e.Graphics.DrawRectangle(p, mRect);
           }
       }

       private void btnSave_Click(object sender, EventArgs e)
       {
           if (picCropped.Image != null)
           {
               saveFileDialog1.AddExtension = true;
               saveFileDialog1.ShowDialog();              
           }
       }

       private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
       {
           try
           {
               if (picCropped.Image != null)
               {                    
                   if (!string.IsNullOrEmpty(saveFileDialog1.FileName))
                   {
                       picCropped.Image.Save(saveFileDialog1.FileName);
                       MessageBox.Show("Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   }
               }
           }
           catch (Exception ex) { MessageBox.Show(string.Format("Sorry Could not save! {0}{1}", Environment.NewLine,ex.Message ), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
       }

       private void btnUseImage_Click(object sender, EventArgs e)
       {
           // This is where we make avialble the image object to be used in the calling form
           if (picCropped.Image != null)
           {
               ImageToUse = new Bitmap(picCropped.Image);
               this.Close();
           }
       }

    }
}
