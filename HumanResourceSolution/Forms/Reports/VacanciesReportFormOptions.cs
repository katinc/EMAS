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
    public partial class VacanciesReportFormOptions : Form
    {
        private IDAL dal;

        public VacanciesReportFormOptions()
        {
            InitializeComponent();
            this.dal = new DAL();
        }

        private void VacanciesReportFormOptions_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VacanciesReportForm form = new VacanciesReportForm(startDatePicker.Text,endDatePicker.Text);
            form.Show();
        }
    }
}
