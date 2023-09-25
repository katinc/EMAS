using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class StatisticsJoinersSelect : Form
    {
        private Form reportForm;
        private IDAL dal;

        public StatisticsJoinersSelect()
        {
            try
            {
                InitializeComponent();
                this.reportForm = new Form();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void StatisticsJoinersSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }
                reportForm = new StatisticsJoinersForm(fromDatePicker.Checked,fromDatePicker.Value,toDatePicker.Checked, toDatePicker.Value);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                fromDatePicker.ResetText();
                toDatePicker.ResetText();
                fromDatePicker.Checked=false;
                toDatePicker.Checked = false;
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
