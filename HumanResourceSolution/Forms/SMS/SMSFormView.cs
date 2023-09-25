using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using eMAS.Forms.SMS;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using HRBussinessLayer;

namespace eMAS.Forms.SMS
{
    public partial class SMSFormView : Form
    {
        private Form reportForm;
        private IDAL dal;

        public SMSFormView()
        {
            InitializeComponent();
            this.reportForm = new Form();
            this.dal = new DAL();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }
                reportForm = new SMSReportForm(datePickerFromDate.Checked, datePickerFromDate.Value, datePickerToDate.Checked, datePickerToDate.Value, cboType.Text.Trim());
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        private void cboType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboType.Items.Clear();
                cboType.Items.Add("Scheduled");
                cboType.Items.Add("Send");
                cboType.Items.Add("Sent");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                MessageBox.Show("Error:Options could not be loaded");
            }
        }

        private void Clear()
        {
            try
            {
                datePickerFromDate.Value=DateTime.Today;
                datePickerToDate.Value=DateTime.Today;
                cboType.Items.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SMSFormView_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }


    }
}
