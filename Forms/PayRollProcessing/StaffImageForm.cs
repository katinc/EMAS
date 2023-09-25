using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class StaffImageForm : Form
    {
        private Image img;
        public StaffImageForm()
        {
            InitializeComponent();
            //this.img = img;
            //pictureBox.Image = img;

        }
        public StaffImageForm(Image img)
        {
            InitializeComponent();
            this.img = img;
            pictureBox.Image = img;
           
        }
        public void SetImage(Image img){
            this.img = img;
            pictureBox.Image = img;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StaffImageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
