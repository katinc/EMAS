using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.SystemSetup
{
    public partial class Leave_Types : Form
    {
        private LeaveType leaveType;
        private IList<LeaveType> leaveTypes;
        private IDAL dal;
        private bool found;

        public Leave_Types()
        {
            try
            {
                InitializeComponent();
                this.leaveType = new LeaveType();
                this.leaveTypes = new List<LeaveType>();
                this.dal = new DAL();
                this.leaveType = new LeaveType();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Leave_Types_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetLeaves();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetLeaves()
        {
            try
            {
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "LeaveTypeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                leaveTypes=dal.GetByCriteria<LeaveType>(query);
                PopulateView(leaveTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<LeaveType> leaveTypes)
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (LeaveType leaveType in leaveTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = leaveType.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = leaveType.Description;
                    grid.Rows[ctr].Cells["gridMaximumEntitlement"].Value = leaveType.MaximumEntitlement;
                    grid.Rows[ctr].Cells["gridActive"].Value = leaveType.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = leaveType.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    try
                    {
                        if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s leave?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {                          
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                leaveType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(leaveType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                leaveType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(leaveType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            leaveType.MaximumEntitlement = int.Parse(row.Cells["gridMaximumEntitlement"].Value.ToString());
                            leaveType.Description = row.Cells["gridDescription"].Value.ToString();
                            leaveType.Active = bool.Parse(row.Cells["gridActive"].Value.ToString());
                            leaveType.User.ID = GlobalData.User.ID;
                            

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(leaveType);
                            }
                            else
                            {
                                leaveType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(leaveType);
                            }
                        }
                    }
                    GetLeaves();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }
    }
}
