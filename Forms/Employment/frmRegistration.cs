using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.All_UIs.Staff_Information_FORMS
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCameraCapture c = new frmCameraCapture();
            c.ShowDialog(this);
            if (c.ImageToUse != null)
            {
                pictureBox1.Image = c.ImageToUse;
            }
            c.Close();
        }
    }
}
