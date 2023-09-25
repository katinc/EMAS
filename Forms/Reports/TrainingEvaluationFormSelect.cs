using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.ErrorLogging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Reports
{
    public partial class TrainingEvaluationFormSelect : Form
    {
        private Form reportForm;
        public TrainingEvaluationFormSelect()
        {
            InitializeComponent();
            this.reportForm = new Form();
        }

        private void TrainingEvaluationFormSelect_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTraining.Items.Clear();

                var trainings = GlobalData._context.TrainingSetups.Where(u => u.Active).ToList();

                foreach (var item in trainings)
                {
                    cmbTraining.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }

                reportForm = new TrainingEvaluationReportForm(cmbTraining.Text);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }
    }
}
