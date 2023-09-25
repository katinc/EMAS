using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;


namespace eMAS.Forms.Employment
{
    public partial class ApplicantCV : Form
    {
        public ApplicantCV()
        {
            InitializeComponent();
        }

        private void ApplicantCV_Load(object sender, EventArgs e)
        {

        }

        private void gridEducationHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEducationHistory.CurrentCell.ColumnIndex == 4)
                {
                    qualificationsFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsFromYear.Items.Add(year);
                    }

                }

                if (gridEducationHistory.CurrentCell.ColumnIndex == 5)
                {
                    qualificationsToMonth.Items.Clear();
                    foreach (string year in GlobalData.GetMonths())
                    {
                        qualificationsToMonth.Items.Add(year);
                    }
                    qualificationsToMonth.Items.Add("To Date");
                }

                if (gridEducationHistory.CurrentCell.ColumnIndex == 6)
                {
                    qualificationsToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsToYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Add("To Date");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
