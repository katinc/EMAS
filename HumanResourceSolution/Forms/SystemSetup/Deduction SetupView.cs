using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using HRDataAccessLayer; 

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class DeductionSetupView : Form, IRefreshView 
    {
        private Deduction_Setup deductionSetup;
        private Deduction deduction;
        private IList<Deduction> deductions; 
        private IDAL dal;

        public DeductionSetupView(IDAL dal, Deduction_Setup deductionSetup)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.deduction = new Deduction();
                this.deductions = new List<Deduction>();
                this.deductionSetup = deductionSetup;
                this.dal.OpenConnection();
                this.RefreshView();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public DeductionSetupView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.deduction = new Deduction();
                this.deductions = new List<Deduction>();
                this.deductionSetup = new Deduction_Setup();
                this.dal.OpenConnection();
                this.RefreshView();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void DeductionSetupView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region IREFRESHVIEW MEMBERS
        public void RefreshView()
        {
            try
            {               
                grid.Rows.Clear();
                int ctr = 0;
                deductions = dal.GetAll<Deduction>();
                foreach (Deduction deduction in deductions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = deduction.ID;
                    grid.Rows[ctr].Cells["gridCode"].Value = deduction.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = deduction.Description;
                    grid.Rows[ctr].Cells["gridSalaryType"].Value = deduction.CalculatedOn.Description;
                    grid.Rows[ctr].Cells["gridSalaryTypeID"].Value = deduction.CalculatedOn.ID;
                    grid.Rows[ctr].Cells["gridDeductionType"].Value = deduction.Type.Description;
                    grid.Rows[ctr].Cells["gridDeductionTypeID"].Value = deduction.Type.ID;
                    grid.Rows[ctr].Cells["gridDeductionType"].Value = deduction.Type.Description;
                    grid.Rows[ctr].Cells["gridDeductionCategoryID"].Value = deduction.Type.DeductionCategory.ID;
                    grid.Rows[ctr].Cells["gridDeductionCategory"].Value = deduction.Type.DeductionCategory.Description;
                    grid.Rows[ctr].Cells["gridRate"].Value = deduction.Rate;
                    grid.Rows[ctr].Cells["gridInActive"].Value = deduction.Inactive;
                    grid.Rows[ctr].Cells["gridAmount"].Value = deduction.Amount;
                    grid.Rows[ctr].Cells["gridRateBased"].Value = deduction.RateBased;
                    grid.Rows[ctr].Cells["gridUserID"].Value = deduction.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void grid_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    deduction.RateBased = bool.Parse(grid.CurrentRow.Cells["gridRateBased"].Value.ToString());
                    if (deduction.RateBased == true)
                    {
                        deduction.CalculatedOn.ID = int.Parse(grid.CurrentRow.Cells["gridSalaryTypeID"].Value.ToString());
                        deduction.CalculatedOn.Description = grid.CurrentRow.Cells["gridSalaryType"].Value.ToString();
                        deduction.Rate = decimal.Parse(grid.CurrentRow.Cells["gridRate"].Value.ToString());
                    }
                    else
                    {
                        deduction.Amount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    }
                    if (grid.CurrentRow.Cells["gridDeductionCategory"].Value != null)
                    {
                        deduction.Type.DeductionCategory.ID = int.Parse(grid.CurrentRow.Cells["gridDeductionCategoryID"].Value.ToString());
                        deduction.Type.DeductionCategory.Description = grid.CurrentRow.Cells["gridDeductionCategory"].Value.ToString();
                    }
                    deduction.Code = grid.CurrentRow.Cells["gridCode"].Value.ToString();
                    deduction.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                    deduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    deduction.Inactive = bool.Parse(grid.CurrentRow.Cells["gridInActive"].Value.ToString());                   
                    deduction.Type.ID = int.Parse(grid.CurrentRow.Cells["gridDeductionTypeID"].Value.ToString());
                    deduction.Type.Description = grid.CurrentRow.Cells["gridDeductionType"].Value.ToString();
                    deduction.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    Deduction_SetupEdit deductionEdit = new Deduction_SetupEdit(deduction, this);
                    deductionEdit.MdiParent = this.MdiParent;
                    deductionEdit.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the ff. deduction: \n" + grid.CurrentRow.Cells["gridDescription"].Value.ToString(), GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            deduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            deduction.Inactive = false;
                            deduction.ReportInclusive = true;
                            dal.Delete(deduction);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            deduction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            deduction.Inactive = false;
                            deduction.ReportInclusive = true;
                            dal.Delete(deduction);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
