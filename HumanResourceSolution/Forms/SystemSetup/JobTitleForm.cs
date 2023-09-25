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

namespace eMAS.Forms.SystemSetup
{
    public partial class JobTitleForm : Form
    {
        private IDAL dal;
        private JobTitle jobTitle;
        private IList<JobTitle> jobTitles;
        private IList<JobTitle> foundJobTitles;
        private int ctr;
        private bool found;

        public JobTitleForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.jobTitle = new JobTitle();
                this.jobTitles = new List<JobTitle>();
                this.foundJobTitles = new List<JobTitle>();
                this.ctr = 0;
                this.found = false;
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
                        if (row.Cells["gridCode"].Value == null)
                        {
                            if (GlobalData.QuestionMessage("Code is empty for " + (row.Index + 1) + ".\nWould you like to continue it?") == DialogResult.Yes)
                            {
                                row.Cells["gridCode"].Value = string.Empty;
                            }
                            else
                            {
                                result = false;
                                MessageBox.Show("Code cannot be empty" + (row.Index + 1));
                                grid.Rows[row.Index + 1].Selected = true;
                            }
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
                        Property = "ViewStaffJobTitle.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                jobTitles = dal.GetByCriteria<JobTitle>(query);
                PopulateView(jobTitles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
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
                            jobTitle.Description = row.Cells["gridDescription"].Value.ToString();
                            jobTitle.Code = row.Cells["gridCode"].Value.ToString();
                            jobTitle.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            jobTitle.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(jobTitle);
                            }
                            else
                            {
                                jobTitle.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(jobTitle);
                            }
                        }
                    }
                    GetData();
                    Clear();
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
                                jobTitle.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                jobTitle.Active = false;
                                jobTitle.Archived = true;
                                dal.Delete(jobTitle);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                jobTitle.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                jobTitle.Active = false;
                                jobTitle.Archived = true;
                                dal.Delete(jobTitle);
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

        private void JobTitleForm_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            try
            {
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                throw ex;
            }
        }

        private void PopulateView(IList<JobTitle> jobTitles)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = jobTitle.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = jobTitle.Description;
                    grid.Rows[ctr].Cells["gridCode"].Value = jobTitle.Code;
                    grid.Rows[ctr].Cells["gridActive"].Value = jobTitle.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = jobTitle.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundJobTitles.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                grid.Rows.Clear();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    if ((jobTitle.Code.Trim().ToLower().StartsWith(txtCode.Text.Trim().ToLower())))
                    {
                        foundJobTitles.Add(jobTitle);
                    }
                }
                PopulateView(foundJobTitles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundJobTitles.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                grid.Rows.Clear();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    if ((jobTitle.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundJobTitles.Add(jobTitle);
                    }
                }
                PopulateView(foundJobTitles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                txtCode.Clear();
                txtDescription.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
