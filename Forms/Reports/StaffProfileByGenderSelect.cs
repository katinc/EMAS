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
    public partial class StaffProfileByGenderSelect : Form
    {
        private IDAL dal;
        private Form reportForm;

        public StaffProfileByGenderSelect()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.reportForm = new Form();
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
                reportForm = new StaffProfileByGenderForm(asAtDatePicker.Checked, asAtDatePicker.Value,cboGender.Text);
                reportForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboGender_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGender.Items.Clear();
                cboGender.Items.Add("All");
                foreach (GenderGroups item in Enum.GetValues(typeof(GenderGroups)))
                {
                    if (item != GenderGroups.All && item != GenderGroups.None)
                    {
                        cboGender.Items.Add(item);
                    }
                }
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
                cboGender.Items.Clear();
                cboGender.Text = string.Empty;

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

        private void StaffProfileByGenderSelect_Load(object sender, EventArgs e)
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
