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
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class QuickbookMappingForm : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private ChartOfAccountType chartOfAccountType;
        private ChartOfAccountMapping chartOfAccountMapping;
        private IList<ChartOfAccountType> chartOfAccountTypes;
        private IList<GradeCategory> gradeCategories;
        private IList<ChartOfAccountMapping> chartOfAccountMappings;
        private IList<ChartOfAccountMapping> foundChartOfAccountMappings;
        DataTable payTypeView;
        private int ctr;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public QuickbookMappingForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.dal.OpenConnection();
                this.chartOfAccountType = new ChartOfAccountType();
                this.chartOfAccountTypes = new List<ChartOfAccountType>();
                this.gradeCategories = new List<GradeCategory>();
                this.chartOfAccountMapping = new ChartOfAccountMapping();
                this.chartOfAccountMappings = new List<ChartOfAccountMapping>();
                this.foundChartOfAccountMappings = new List<ChartOfAccountMapping>();
                this.payTypeView = new DataTable();
                this.ctr = 0;
                this.found = false;
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
                                chartOfAccountMapping.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                chartOfAccountMapping.Archived = true;
                                dal.Delete(chartOfAccountMapping);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                chartOfAccountMapping.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                chartOfAccountMapping.Archived = true;
                                dal.Delete(chartOfAccountMapping);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
                RefreshView();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void PopulateView(IList<ChartOfAccountMapping> chartOfAccountMappings)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (ChartOfAccountMapping chartOfAccountMapping in chartOfAccountMappings)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = chartOfAccountMapping.ID;
                    grid.Rows[ctr].Cells["gridAccountCode"].Value = chartOfAccountMapping.AccountCode;
                    grid.Rows[ctr].Cells["gridAccountDescription"].Value = chartOfAccountMapping.AccountDescription;
                    grid.Rows[ctr].Cells["gridAccountHeader"].Value = chartOfAccountMapping.AccountHeader;
                    grid.Rows[ctr].Cells["gridReport"].Value = chartOfAccountMapping.Report;
                    grid.Rows[ctr].Cells["gridQuery"].Value = chartOfAccountMapping.Query;
                    grid.Rows[ctr].Cells["gridAccountType"].Value = chartOfAccountMapping.ChartOfAccountType.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = chartOfAccountMapping.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridDate"].Value = chartOfAccountMapping.Date;
                    grid.Rows[ctr].Cells["gridActive"].Value = chartOfAccountMapping.Active;
                    grid.Rows[ctr].Cells["gridType"].Value = chartOfAccountMapping.Type;
                    grid.Rows[ctr].Cells["gridDate"].Value = chartOfAccountMapping.Date;

                    grid.Rows[ctr].Cells["gridUserID"].Value = chartOfAccountMapping.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                /*if (found == true)
                {*/
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                //}
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboAccountType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.AccountType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = chartOfAccountTypes[cboAccountType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtAccountCode.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.AccountCode",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtAccountCode.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtAccountDescription.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.AccountDescription",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtAccountDescription.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtAccountHeader.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.AccountHeader",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtAccountHeader.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtReport.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.Report",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtReport.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtQuery.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.Query",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtQuery.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.Type",
                        CriterionOperator = CriterionOperator.Like,
                        Value = cboType.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                chartOfAccountMappings = dal.GetByCriteria<ChartOfAccountMapping>(query);
                PopulateView(chartOfAccountMappings);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void Clear()
        {
            try
            {
                txtAccountCode.Clear();
                txtAccountDescription.Clear();
                txtAccountHeader.Clear();
                txtReport.Clear();
                txtQuery.Clear();
                checkBoxActive.Checked = false;
                cboGradeCategory.Items.Clear();
                cboAccountType.Items.Clear();
                cboType.Items.Clear();
                PageControls.Items.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ChartOfAccountMapForm_Load(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
                RefreshView();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Visible = getPermissions.CanAdd;
                    deleteButton.Visible = getPermissions.CanView;
                    btnAdd.Visible = getPermissions.CanAdd;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private bool ValidateFieldsForAdd()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (txtAccountCode.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Account Code cannot be empty");
                    txtAccountCode.Focus();
                }
                else if (txtAccountDescription.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Account Description cannot be empty");
                    txtAccountDescription.Focus();

                }
                else if (txtReport.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Report cannot be empty");
                    txtReport.Focus();

                }
                else if (txtQuery.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Query cannot be empty");
                    txtAccountHeader.Focus();
                }
                else if (cboAccountType.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Account Type cannot be empty");
                    cboAccountType.Focus();
                }
                else if (cboGradeCategory.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Grade Category cannot be empty");
                    cboGradeCategory.Focus();
                }
                else
                {
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ChartOfAccountMappingView.AccountCode",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtAccountCode.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    int count = 0;
                    count = dal.GetByCriteria<ChartOfAccountMapping>(query).Count;
                    if (numericID.Value == 0 && count > 0)
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
                    chartOfAccountMapping.ID = (int)numericID.Value;
                    chartOfAccountMapping.GradeCategory.ID = gradeCategories[cboGradeCategory.SelectedIndex].ID;
                    chartOfAccountMapping.ChartOfAccountType.ID = chartOfAccountTypes[cboAccountType.SelectedIndex].ID;
                    chartOfAccountMapping.AccountCode = txtAccountCode.Text.Trim();
                    chartOfAccountMapping.AccountDescription = txtAccountDescription.Text.Trim();
                    chartOfAccountMapping.AccountHeader = txtAccountHeader.Text.Trim();
                    chartOfAccountMapping.Report = txtReport.Text.Trim();
                    chartOfAccountMapping.Query = txtQuery.Text.Trim();
                    chartOfAccountMapping.Active = checkBoxActive.Checked;
                    chartOfAccountMapping.Type = cboType.Text.Trim();
                    chartOfAccountMapping.User.ID = GlobalData.User.ID;
                    chartOfAccountMapping.Date = DateTime.Now.Date;

                    if (chartOfAccountMapping.ID == 0)
                    {
                        dal.Save(chartOfAccountMapping);
                    }
                    else
                    {
                        dal.Update(chartOfAccountMapping);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboAccountType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAccountType.Items.Clear();
                chartOfAccountTypes=dal.GetAll<ChartOfAccountType>();
                foreach (ChartOfAccountType chartOfAccountType in chartOfAccountTypes)
                {
                    cboAccountType.Items.Add(chartOfAccountType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridActive"].Value = true;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridActive"].Value = false;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory gradeCategory in gradeCategories)
                {
                    cboGradeCategory.Items.Add(gradeCategory.Description);
                }
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
                    txtAccountCode.Text = row.Cells["gridAccountCode"].Value.ToString();
                    txtAccountDescription.Text = row.Cells["gridAccountDescription"].Value.ToString();
                    txtAccountHeader.Text = row.Cells["gridAccountHeader"].Value.ToString();
                    txtReport.Text = row.Cells["gridReport"].Value.ToString();
                    txtQuery.Text = row.Cells["gridQuery"].Value.ToString();
                    checkBoxActive.Checked = bool.Parse(row.Cells["gridActive"].Value.ToString());
                    cboAccountType_DropDown(this,EventArgs.Empty);
                    cboAccountType.Text = row.Cells["gridAccountType"].Value.ToString();
                    cboType_DropDown(this, EventArgs.Empty);
                    cboType.Text = row.Cells["gridType"].Value.ToString();
                    cboGradeCategory_DropDown(this,EventArgs.Empty);
                    cboGradeCategory.Text=row.Cells["gridGradeCategory"].Value.ToString();
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                    {
                        btnAdd.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboType.Items.Clear();
                cboType.Items.Add("Debit");
                cboType.Items.Add("Credit");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dal.BeginTransaction();
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        chartOfAccountMapping.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                        chartOfAccountMapping.AccountCode = row.Cells["gridID"].Value.ToString();
                        chartOfAccountMapping.AccountDescription = row.Cells["gridAccountDescription"].Value.ToString();
                        chartOfAccountMapping.AccountHeader = row.Cells["gridAccountHeader"].Value.ToString();
                        chartOfAccountMapping.ChartOfAccountType.Description = row.Cells["gridAccountType"].Value.ToString();
                        chartOfAccountMapping.Date = DateTime.Parse(row.Cells["gridDate"].Value.ToString());
                        chartOfAccountMapping.GradeCategory.Description = row.Cells["gridGradeCategory"].Value.ToString();
                        chartOfAccountMapping.Query = row.Cells["gridQuery"].Value.ToString();
                        chartOfAccountMapping.Report = row.Cells["gridReport"].Value.ToString();
                        chartOfAccountMapping.Type = row.Cells["gridType"].Value.ToString();

                        
                        chartOfAccountMapping.Active = bool.Parse(row.Cells["gridActive"].Value.ToString());
                        chartOfAccountMapping.User.ID = GlobalData.User.ID;
                        dal.Update(chartOfAccountMapping);
                    }
                }

                dal.CommitTransaction();
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }

        public void RefreshView()
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                payTypeView = dalHelper.ExecuteReader("SELECT * from PayTypeView where Archived=@Archived and Active=@Active order by Description asc");
                PageControls.Items.Clear();
                foreach (DataRow row in payTypeView.Rows)
                {
                    PageControls.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PageControls_SelectedValueChanged(object sender, EventArgs e)
        {
            string clause = string.Empty;
            int c = 0;
            foreach (var rRow in PageControls.SelectedItems)
            {
                try
                {
                    c++;
                    if (c == PageControls.SelectedItems.Count)
                    {
                        clause += "ColumnHeader = '" + rRow.ToString() + "'";
                    }
                    else
                    {
                        clause += " ColumnHeader = '" + rRow.ToString() + "' and ";
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            if(clause != string.Empty)
            {
                txtQuery.Text = "Select SUM(ColumnValue) from PayRollSummaryView Where " + clause;
            }
        }

        private void PageControls_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
