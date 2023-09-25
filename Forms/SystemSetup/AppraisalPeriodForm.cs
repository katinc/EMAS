using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalPeriodForm : Form
    {
        public AppraisalPeriod appraisalPeriod;
        private DALHelper dalHelper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public AppraisalPeriodForm()
        {
            InitializeComponent();
            //appraisalPeriod = new AppraisalPeriod();
            dalHelper = new DALHelper();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string error = string.Empty;
                if (dtpStartDate.Value >= dtpEndDate.Value)
                {
                    error = "Start Date Cannot Be Greater Than End Date";
                    errorProvider1.SetError(dtpStartDate, error);
                }
                else if (txtDescription.Text == string.Empty)
                {
                    error = "Description Cannot Be Empty";
                    errorProvider1.SetError(txtDescription, error);
                }
                else if(cmbType.SelectedItem==null)
                {
                    error = "Appraisal Type Cannot Be Empty";
                    errorProvider1.SetError(cmbType, error);
                }
               
                else
                {
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@description", txtDescription.Text, DbType.String);
                    dalHelper.CreateParameter("@code", cmbType.SelectedItem.ToString(), DbType.String);
                    dalHelper.CreateParameter("@startDate", dtpStartDate.Value.Date, DbType.Date);
                    dalHelper.CreateParameter("@endDate", dtpEndDate.Value.Date, DbType.Date);
                    dalHelper.CreateParameter("@active", chkActive.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@year",nudYear.Value, DbType.Int32);
                    if (appraisalPeriod != null && appraisalPeriod.Id > 0)
                    {
                        dalHelper.CreateParameter("@Id", appraisalPeriod.Id, DbType.Int32);
                        dalHelper.ExecuteNonQuery("update AppraisalPeriods set description=@description,startDate=@startDate,endDate=@endDate,active=@active, code=@code where id=@Id");
                    }
                    else
                    {
                        dalHelper.CreateParameter("@archived", false, DbType.Boolean);
                        dalHelper.ExecuteNonQuery("insert into AppraisalPeriods (description,startDate,endDate,active,archived,year,code) values (@description,@startDate,@endDate,@active,@archived,@year,@code)");
                        btnClear_Click(sender, e);
                    }
                }
                if (error != string.Empty)
                    MessageBox.Show("Sorry:" + error);
                else
                    MessageBox.Show("Record Is Saved Successfully!");
            }
            catch (Exception xi)
            {
                //Logger.LogError(xi);
                if(xi.Message.ToLower().Contains("duplicate"))
                    MessageBox.Show("Sorry Period Already Exist\n" + xi.Message);
                else
                MessageBox.Show("Unable To Save Record\n" + xi.Message);
            }
            
        }

        private void AppraisalPeriodForm_Load(object sender, EventArgs e)
        {
            appraisalPeriod = new AppraisalPeriod();
            nudYear.Maximum = DateTime.Now.Year + 10;
            nudYear.Minimum = DateTime.Now.Year - 10;
            nudYear.Value = DateTime.Now.Year;

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                btnView.Enabled = getPermissions.CanView;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            AppraisalPeriodView appraisalView = new AppraisalPeriodView(this);
            appraisalView.btnDelete.Visible = CanDelete;
            appraisalView.ShowDialog(this);
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            nudYear.Maximum = dtpEndDate.Value.Year;
            nudYear.Minimum = dtpStartDate.Value.Year;
            nudYear.Value = dtpStartDate.Value.Year;
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            nudYear.Maximum = dtpEndDate.Value.Year;
            nudYear.Minimum = dtpStartDate.Value.Year;
            nudYear.Value = dtpStartDate.Value.Year;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dtpEndDate.ResetText();
            dtpStartDate.ResetText();
            txtDescription.Clear();
            chkActive.Checked = true;
            cmbType.SelectedIndex = -1;
            dtpEndDate_ValueChanged(sender, e);
            appraisalPeriod = new AppraisalPeriod();
        }
    }
}
