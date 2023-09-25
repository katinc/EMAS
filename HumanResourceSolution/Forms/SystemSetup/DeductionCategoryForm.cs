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

namespace eMAS.Forms.SystemSetup
{
    public partial class DeductionCategoryForm : Form
    {
        private IDAL dal;
        private DeductionCategory deductionCategory;
        private IList<DeductionCategory> deductionCategories;
        private IList<DeductionCategory> foundDeductionCategories;
        private int ctr;
        private bool found;

        public DeductionCategoryForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.deductionCategory = new DeductionCategory();
                this.deductionCategories = new List<DeductionCategory>();
                this.foundDeductionCategories = new List<DeductionCategory>();
                this.ctr = 0;
                this.found = false;
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
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "DeductionCategoryView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                deductionCategories = dal.GetByCriteria<DeductionCategory>(query);
                PopulateView(deductionCategories);
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

        private void PopulateView(IList<DeductionCategory> deductionTypes)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (DeductionCategory deductionType in deductionTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = deductionType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = deductionType.Description;                   
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
                            deductionCategory.Description = row.Cells["gridDescription"].Value.ToString();                        
                            deductionCategory.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            deductionCategory.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(deductionCategory);
                            }
                            else
                            {
                                deductionCategory.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(deductionCategory);
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
                                deductionCategory.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                deductionCategory.Active = false;
                                deductionCategory.Archived = true;
                                dal.Delete(deductionCategory);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                deductionCategory.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                deductionCategory.Active = false;
                                deductionCategory.Archived = true;
                                dal.Delete(deductionCategory);
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

        private void DeductionCategoryForm_Load(object sender, EventArgs e)
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


    }
}
