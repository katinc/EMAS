using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.SystemSetup
{
    public partial class AnnualLeaveEntitlementForm : Form
    {
        private IDAL dal;
        private AnnualLeaveEntitlement annualLeaveEntitlement;
        private LeaveType leaveType;
        private IList<AnnualLeaveEntitlement> annualLeaveEntitlements;
        private IList<AnnualLeaveEntitlement> foundAnnualLeaveEntitlements;
        private int ctr;

        public AnnualLeaveEntitlementForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.annualLeaveEntitlement = new AnnualLeaveEntitlement();
                this.leaveType = new LeaveType();
                this.annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.foundAnnualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.ctr = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetData()
        {
            try
            {
                annualLeaveEntitlements = dal.GetAll<AnnualLeaveEntitlement>();
                ctr = 0;
                grid.Rows.Clear();
                foreach (AnnualLeaveEntitlement annualLeaveEntitlement in annualLeaveEntitlements)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = annualLeaveEntitlement.ID;
                    grid.Rows[ctr].Cells["gridStatus"].Value = annualLeaveEntitlement.Status;
                    grid.Rows[ctr].Cells["gridCategoryOfPost"].Value = annualLeaveEntitlement.CategoryOfPost;
                    grid.Rows[ctr].Cells["gridGradeType"].Value = annualLeaveEntitlement.TypeOfGrade;
                    grid.Rows[ctr].Cells["gridNumberOfDays"].Value = annualLeaveEntitlement.NumberOfDays;
                    grid.Rows[ctr].Cells["gridPromotionYears"].Value = annualLeaveEntitlement.PromotionYears;
                    grid.Rows[ctr].Cells["gridActive"].Value = annualLeaveEntitlement.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = annualLeaveEntitlement.User.ID;
                    ctr++;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                        if (row.Cells["gridStatus"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Status cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridCategoryOfPost"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Category of Post cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridGradeType"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Types of Grade cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridNumberOfDays"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Number of Days cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridNumberOfDays"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Number of Days must be Decimal " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridPromotionYears"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Promotion Years cannot be empty " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DecimalValidator(row.Cells["gridPromotionYears"].Value.ToString().Trim()))
                        {
                            result = false;
                            MessageBox.Show("Promotion Years must be Decimal " + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else 
                        {
                            if (int.Parse(numericNumberofDays.Value.ToString()) > dal.GetByDescription<LeaveType>("Annual Leave".ToLower().Trim()).MaximumEntitlement) 
                            {
                                result = false;
                                MessageBox.Show("Number of Days must be Decimal " + (row.Index + 1));
                                grid.Rows[row.Index + 1].Selected = true;
                            }
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
                            annualLeaveEntitlement.Status = row.Cells["gridStatus"].Value.ToString();
                            annualLeaveEntitlement.CategoryOfPost = row.Cells["gridCategoryOfPost"].Value.ToString();
                            annualLeaveEntitlement.TypeOfGrade = row.Cells["gridGradeType"].Value.ToString();
                            annualLeaveEntitlement.NumberOfDays = int.Parse(row.Cells["gridNumberOfDays"].Value.ToString());
                            annualLeaveEntitlement.PromotionYears = int.Parse(row.Cells["gridPromotionYears"].Value.ToString());
                            annualLeaveEntitlement.Active = bool.Parse(row.Cells["gridActive"].Value.ToString());
                            annualLeaveEntitlement.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(annualLeaveEntitlement);
                            }
                            else
                            {
                                annualLeaveEntitlement.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(annualLeaveEntitlement);
                            }
                        }
                    }
                    
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        private bool ValidateFieldsForAdd()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (txtStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Status cannot be empty");
                    txtStatus.Focus();
                }
                else if (txtCategoryOfPost.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Category of Post cannot be empty");
                    txtCategoryOfPost.Focus();

                }
                else if (txtTypesOfGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Types of Grade cannot be empty");
                    txtTypesOfGrade.Focus();
                }
                else if (numericNumberofDays.Value.ToString().Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Number of Days cannot be empty");
                    txtTypesOfGrade.Focus();
                }
                else if (!Validator.DecimalValidator(numericNumberofDays.Value.ToString()))
                {
                    result = false;
                    MessageBox.Show("Number of Days must be Decimal");
                    numericNumberofDays.Focus();
                }
                else if (int.Parse(numericNumberofDays.Value.ToString()) > dal.GetByDescription<LeaveType>("Annual Leave".Trim()).MaximumEntitlement) 
                {
                    result = false;
                    MessageBox.Show("Number of Days must not be greater than Maximum Days");
                    numericNumberofDays.Focus();
                }
                else if (numericPromotionYears.Value.ToString().Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Promotion Years cannot be empty ");
                    numericPromotionYears.Focus();
                }
                else if (!Validator.DecimalValidator(numericPromotionYears.Value.ToString().Trim()))
                {
                    result = false;
                    MessageBox.Show("Promotion Years must be Decimal ");
                    numericPromotionYears.Focus();
                }
                else
                {
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "AnnualLeaveEntitlementView.CategoryOfPost",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtCategoryOfPost.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "AnnualLeaveEntitlementView.TypesOfGrade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtTypesOfGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "AnnualLeaveEntitlementView.Status",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtStatus.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    int count = 0;
                    count = dal.GetByCriteria<AnnualLeaveEntitlement>(query).Count;
                    if(numericID.Value == 0 && count > 0)
                    {
                        result = false;
                        MessageBox.Show("Duplicate Data, Please modify Data");
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsForAdd())
                {
                    dal.BeginTransaction();
                    annualLeaveEntitlement.ID = (int)numericID.Value;
                    annualLeaveEntitlement.Status = txtStatus.Text.Trim();
                    annualLeaveEntitlement.CategoryOfPost = txtCategoryOfPost.Text.Trim();
                    annualLeaveEntitlement.TypeOfGrade = txtTypesOfGrade.Text.Trim();
                    annualLeaveEntitlement.NumberOfDays = (int)numericNumberofDays.Value;
                    annualLeaveEntitlement.PromotionYears = (int)numericPromotionYears.Value;
                    annualLeaveEntitlement.Active = checkBoxActive.Checked;
                    annualLeaveEntitlement.User.ID = GlobalData.User.ID;

                    if (annualLeaveEntitlement.ID == 0)
                    {
                        dal.Save(annualLeaveEntitlement);
                    }
                    else
                    {
                        dal.Update(annualLeaveEntitlement);
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully,Please See the System Administrator");
            }
        }

        private void Clear()
        {
            try
            {
                if(dal.GetByID<LeaveType>(7).Active == false)
                {
                    groupBox1.Enabled = false;
                    groupBoxSearch.Enabled = false;
                    panel1.Enabled = false;
                    errorProvider.SetError(this, "Please Activate the Annual Leave");
                }
                txtCategoryOfPost.Clear();
                txtStatus.Clear();
                txtTypesOfGrade.Clear();
                checkBoxActive.Checked = false;
                numericNumberofDays.Value = 30;
                numericPromotionYears.Value = 0;
                numericID.Value = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grid.Rows[e.RowIndex];
                    numericID.Value = decimal.Parse(row.Cells["gridID"].Value.ToString());
                    txtCategoryOfPost.Text = row.Cells["gridCategoryOfPost"].Value.ToString();
                    txtStatus.Text = row.Cells["gridStatus"].Value.ToString();
                    txtTypesOfGrade.Text = row.Cells["gridGradeType"].Value.ToString();
                    numericNumberofDays.Value = decimal.Parse(row.Cells["gridNumberOfDays"].Value.ToString());
                    numericPromotionYears.Value = decimal.Parse(row.Cells["gridPromotionYears"].Value.ToString());
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                    {
                        btnSave.Enabled = false;
                        btnAdd.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AnnualLeaveEntitlementForm_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                Close();
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
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                annualLeaveEntitlement.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                annualLeaveEntitlement.Active = false;
                                dal.Delete(annualLeaveEntitlement);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                annualLeaveEntitlement.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                annualLeaveEntitlement.Active = false;
                                dal.Delete(annualLeaveEntitlement);
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
