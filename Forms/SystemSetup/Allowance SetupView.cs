using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayerBase;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Allowance_SetupView : Form, IRefreshView 
    {

        private IDAL dal;
        private IList<Allowance> allowances;
        private Allowance allowance;
        private bool CanEdit;

        public Allowance_SetupView(IDAL dal)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.allowance = new Allowance();
                this.allowances = new List<Allowance>();
                this.RefreshView();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Allowance_SetupView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.allowance = new Allowance();
                this.allowances = new List<Allowance>();
                this.RefreshView();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && CanEdit)
                {
                    Allowance allowance = new Allowance();
                    allowance.Code = grid.CurrentRow.Cells["gridCode"].Value.ToString();
                    allowance.Amount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    allowance.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                    allowance.ID = int.Parse(grid.CurrentRow.Cells["gridAID"].Value.ToString());
                    allowance.InUse = bool.Parse(grid.CurrentRow.Cells["gridInActive"].Value.ToString());
                    allowance.Level.Grade = grid.CurrentRow.Cells["gridLevel"].Value.ToString();
                    allowance.Level.ID = int.Parse(grid.CurrentRow.Cells["gridLevelID"].Value.ToString());
                    allowance.AllowanceType.Description = grid.CurrentRow.Cells["gridAllowanceType"].Value.ToString();
                    allowance.AllowanceType.ID = int.Parse(grid.CurrentRow.Cells["gridTypeID"].Value.ToString());
                    allowance.AllowanceSubCategory.Description = grid.CurrentRow.Cells["gridAllowanceCategory"].Value.ToString();
                    allowance.AllowanceSubCategory.ID = int.Parse(grid.CurrentRow.Cells["gridCategoryID"].Value.ToString());
                    allowance.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    Allowance_SetupEdit allowanceEdit = new Allowance_SetupEdit(allowance, dal, this);
                    allowanceEdit.Show();
                }
                else if (!CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Allowance_SetupView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                this.RefreshView();
                // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == "Allowance_Setup" && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    CanEdit = getPermissions.CanEdit;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RefreshView()
        {
            try
            {
                allowances = dal.GetAll<Allowance>();
                int ctr = 0;
                grid.Rows.Clear();
                foreach (Allowance allowance in allowances)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridAID"].Value = allowance.ID;
                    grid.Rows[ctr].Cells["gridCode"].Value = allowance.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = allowance.Description;
                    grid.Rows[ctr].Cells["gridAllowanceType"].Value = allowance.AllowanceType.Description;
                    grid.Rows[ctr].Cells["gridTypeID"].Value = allowance.AllowanceType.ID;
                    grid.Rows[ctr].Cells["gridAllowanceCategory"].Value = allowance.AllowanceSubCategory.Description;
                    grid.Rows[ctr].Cells["gridCategoryID"].Value = allowance.AllowanceSubCategory.ID;
                    grid.Rows[ctr].Cells["gridAmount"].Value = allowance.Amount;
                    grid.Rows[ctr].Cells["gridInActive"].Value = allowance.InUse;
                    grid.Rows[ctr].Cells["gridLevel"].Value = allowance.Level.Grade;
                    grid.Rows[ctr].Cells["gridLevelID"].Value = allowance.Level.ID;
                    grid.Rows[ctr].Cells["gridUserID"].Value = allowance.User.ID;
                    ctr++;
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
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridAID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {                         
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                allowance.ID = int.Parse(grid.CurrentRow.Cells["gridAID"].Value.ToString());
                                allowance.InUse = false;
                                allowance.Archived = true;
                                dal.Delete(allowance);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                allowance.ID = int.Parse(grid.CurrentRow.Cells["gridAID"].Value.ToString());
                                allowance.InUse = false;
                                allowance.Archived = true;
                                dal.Delete(allowance);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
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
