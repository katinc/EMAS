using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class ApplicantsReportFormOptions : Form
    {
        private IDAL dal;
        public ApplicantsReportFormOptions()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void ApplicantsReportFormOptions_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ApplicantsReportForm form = new ApplicantsReportForm(startDatePicker.Text,endDatePicker.Text);
            form.Show();
        }
    }
}
