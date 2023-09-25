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
    public partial class StaffAttendanceSelect : Form
    {
        private IDAL dal;

        public StaffAttendanceSelect()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            endDatePicker.ResetText();
            startDatePicker.ResetText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StaffAttendanceReportForm report = new StaffAttendanceReportForm(startDatePicker.Text,endDatePicker.Text);
            report.Show();
        }

        private void StaffAttendanceSelect_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
