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
    public partial class StaffListByQualificationTypeSelect : Form
    {
        private Form reportForm;
        private IDAL dal;
        private IList<QualificationType> qualificationTypes;

        public StaffListByQualificationTypeSelect()
        {
            try
            {
                InitializeComponent();
                this.reportForm = new Form();
                this.dal = new DAL();
                this.qualificationTypes=new List<QualificationType>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboQualificationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboQualificationType.Items.Clear();
                qualificationTypes = dal.GetAll<QualificationType>();
                cboQualificationType.Items.Add("All");
                foreach (QualificationType qualification in qualificationTypes)
                {
                    cboQualificationType.Items.Add(qualification.Description);
                }
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
                reportForm = new StaffListByQualificationForm(cboQualificationType.Text);
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
                cboQualificationType.Items.Clear();
                cboQualificationType.Text = string.Empty;
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

        private void StaffListByQualificationTypeSelect_Load(object sender, EventArgs e)
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
    }
}
