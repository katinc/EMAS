using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using eMAS.Forms.SystemSetup;


namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class DeductionTypes : Form
    {
        private IDAL dal;
        private DeductionSubCategory deductionType;
        private DeductionCategory deductionCategory;
        private IList<DeductionCategory> deductionCategories;
        private IList<DeductionSubCategory> deductionTypes;
        private IList<DeductionSubCategory> founddeductionTypes;
        private int ctr;
        private bool found;

        public DeductionTypes()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.deductionType = new DeductionSubCategory();
                this.deductionCategory = new DeductionCategory();
                this.deductionCategories = new List<DeductionCategory>();
                this.founddeductionTypes = new List<DeductionSubCategory>();
                this.deductionTypes = new List<DeductionSubCategory>();
                this.ctr = 0;
                this.found = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetData()
        {
            try
            {
                dal.OpenConnection();
                if (cboDeductionCategory.Text.Trim() == string.Empty)
                {
                    deductionCategory.ID = 0;
                }
                else
                {
                    deductionCategory.ID = deductionCategories[cboDeductionCategory.SelectedIndex].ID;
                }
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "DeductionTypeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "DeductionTypeView.DeductionCategoryID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = deductionCategory.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                deductionTypes = dal.GetByCriteria<DeductionSubCategory>(query);
                PopulateView(deductionTypes);
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
                if (cboDeductionCategory.Text.ToString() == null || cboDeductionCategory.Text.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Deduction Category ");
                    cboDeductionCategory.Focus();
                }
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
            }
            return result;
        }

        private void savebtn_Click(object sender, EventArgs e)
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
                            deductionType.Description = row.Cells["gridDescription"].Value.ToString();
                            deductionType.DeductionCategory.ID = deductionCategories[cboDeductionCategory.SelectedIndex].ID;
                            deductionType.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            deductionType.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(deductionType);
                            }
                            else
                            {
                                deductionType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(deductionType);
                            }
                        }
                    }
                    GetData();
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

        private void btnDelete_Click(object sender, EventArgs e)
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
                                deductionType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                deductionType.Active = false;
                                deductionType.Archived = true;
                                dal.Delete(deductionType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                deductionType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                deductionType.Active = false;
                                deductionType.Archived = true;
                                dal.Delete(deductionType);
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

        private void PopulateView(IList<DeductionSubCategory> deductionTypes)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (DeductionSubCategory deductionType in deductionTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = deductionType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = deductionType.Description;
                    grid.Rows[ctr].Cells["gridDeductionCategoryID"].Value = deductionType.DeductionCategory.ID.ToString();
                    grid.Rows[ctr].Cells["gridActive"].Value = deductionType.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = deductionType.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                grid.Rows.Clear();
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

        private void DeductionTypes_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDeductionCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                founddeductionTypes.Clear();
                deductionTypes = dal.GetAll<DeductionSubCategory>();
                grid.Rows.Clear();
                foreach (DeductionSubCategory deductionType in deductionTypes)
                {
                    if (deductionType.DeductionCategory.ID == deductionCategories[cboDeductionCategory.SelectedIndex].ID)
                    {
                        founddeductionTypes.Add(deductionType);
                    }
                }
                PopulateView(founddeductionTypes);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboDeductionCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                deductionCategories = dal.GetAll<DeductionCategory>();
                cboDeductionCategory.Items.Clear();
                cboDeductionCategory.Text = string.Empty;
                foreach (DeductionCategory deductionCategory in deductionCategories)
                {
                    cboDeductionCategory.Items.Add(deductionCategory.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboDeductionCategory_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                founddeductionTypes.Clear();
                deductionTypes = dal.GetAll<DeductionSubCategory>();
                grid.Rows.Clear();
                foreach (DeductionSubCategory deductionType in deductionTypes)
                {
                    if (deductionType.DeductionCategory.ID == deductionCategories[cboDeductionCategory.SelectedIndex].ID)
                    {
                        founddeductionTypes.Add(deductionType);
                    }
                }
                PopulateView(founddeductionTypes);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            try
            {
                DeductionCategoryForm deductionCategoryForm = new DeductionCategoryForm();
                deductionCategoryForm.MdiParent = this.MdiParent;
                deductionCategoryForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


    }
}