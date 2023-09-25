using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Allowance_Setup : Form
    {
        private EmployeeGrade grade;
        private Allowance allowanceSetup;
        private AllowanceCategory allowanceType;
        private IList<AllowanceCategory> allowanceTypes;
        private AllowanceSubCategory allowanceCategory;
        private IList<AllowanceSubCategory> allowanceCategories;
        private IList<Allowance> allowances;
        private IList<Allowance> foundAllowances;
        private IList<EmployeeGrade> grades;
        private IDAL dal;
        private int allowanceTypeID;
        private int levelID;
        private int ctr;
        private bool editMode;

        
        public Allowance_Setup()
        {
            try
            {
                InitializeComponent();
                this.allowanceTypeID = 0;
                this.ctr = 0;
                this.levelID = 0;
                this.editMode = false;
                this.dal = new DAL();
                this.allowanceSetup = new Allowance();
                this.grade = new EmployeeGrade();
                this.allowanceType = new AllowanceCategory();
                this.allowanceTypes = new List<AllowanceCategory>();
                this.allowanceCategory = new AllowanceSubCategory();
                this.allowanceCategories = new List<AllowanceSubCategory>();
                this.grades = new List<EmployeeGrade>();
                this.allowances = new List<Allowance>();
                this.foundAllowances = new List<Allowance>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    gridAllowanceType.Items.Clear();
                    allowanceTypes = dal.GetAll<AllowanceCategory>();
                    foreach (AllowanceCategory type in allowanceTypes)
                    {
                        gridAllowanceType.Items.Add(type.Description);
                    }

                    gridAllowanceCategory.Items.Clear();
                    allowanceCategories = dal.GetAll<AllowanceSubCategory>();
                    foreach (AllowanceSubCategory type in allowanceCategories)
                    {
                        gridAllowanceCategory.Items.Add(type.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Allowance_Setup_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox1.Enabled = false;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                if (levelsComboBox.Text.Trim() == string.Empty)
                {
                    grade.ID = 0;
                }
                else
                {
                    this.levelsComboBox.DropDown += new EventHandler(levelsComboBox_DropDown);                   
                    grade.ID = grades[levelsComboBox.SelectedIndex].ID;
                }

                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "Allowance_SetupView.GradeLevelID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = levelID.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                allowances = dal.GetByCriteria<Allowance>(query);
                PopulateView(allowances);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        //private void PopulateView(IList<Allowance> allowances)
        //{
        //    try
        //    {
        //        this.ctr = 0;
        //        grid.Rows.Clear();
        //        foreach (Allowance allowance in allowances)
        //        {
        //            grid.Rows.Add(1);
        //            grid.Rows[ctr].Cells["gridID"].Value = allowance.ID;
        //            grid.Rows[ctr].Cells["gridCode"].Value = allowance.Code;
        //            grid.Rows[ctr].Cells["gridAllowanceType"].Value = allowance.AllowanceType.Description;
        //            grid.Rows[ctr].Cells["gridAllowanceCategory"].Value = allowance.AllowanceSubCategory.Description;
        //            grid.Rows[ctr].Cells["gridDescription"].Value = allowance.Description;
        //            grid.Rows[ctr].Cells["gridAmount"].Value = allowance.Amount;
        //            grid.Rows[ctr].Cells["gridInActive"].Value = allowance.InUse;
        //            grid.Rows[ctr].Cells["gridUserID"].Value = allowance.User.ID;
        //            grid.Rows[ctr].Cells["gridGradeLevel"].Value = allowance.Level.Grade;
        //            ctr++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string err = ex.Message;
        //    }
        //}

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    levelID = grades[levelsComboBox.SelectedIndex].ID;
                    allowanceSetup.Level.ID = levelID;
                    ctr = 0;
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridCode"].Value != null)
                            {
                                allowanceSetup.Code = row.Cells["gridCode"].Value.ToString();
                            }
                            else
                            {
                                allowanceSetup.Code = string.Empty; 
                            }
                            
                            allowanceSetup.Description = row.Cells["gridDescription"].Value.ToString();                         
                            allowanceSetup.Amount = decimal.Parse(row.Cells["gridAmount"].Value.ToString());
                            allowanceSetup.Level.ID = grades[levelsComboBox.SelectedIndex].ID;
                            allowanceSetup.InUse = (bool)row.Cells["gridInActive"].FormattedValue;
                            allowanceSetup.User.ID = GlobalData.User.ID;
                            string y=row.Cells["gridAllowanceType"].Value.ToString();
                            allowanceSetup.AllowanceType.Description = row.Cells["gridAllowanceType"].Value.ToString();
                            allowanceSetup.AllowanceSubCategory.Description = row.Cells["gridAllowanceCategory"].Value.ToString();
                            Query allowanceTypeQuery = new Query();
                            allowanceTypeQuery.Criteria.Add(new Criterion()
                            {
                                Property = "AllowanceTypeView.Description",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = allowanceSetup.AllowanceType.Description,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            allowanceTypes = dal.GetByCriteria<AllowanceCategory>(allowanceTypeQuery);
                            foreach (AllowanceCategory allowanceType in allowanceTypes)
                            {
                                allowanceSetup.AllowanceType.ID = allowanceType.ID;
                            }
                            Query allowanceCategoryQuery = new Query();
                            allowanceCategoryQuery.Criteria.Add(new Criterion()
                            {
                                Property = "AllowanceCategoryView.Description",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = allowanceSetup.AllowanceSubCategory.Description,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            allowanceCategories = dal.GetByCriteria<AllowanceSubCategory>(allowanceCategoryQuery);
                            foreach (AllowanceSubCategory allowanceCategory in allowanceCategories)
                            {
                                allowanceSetup.AllowanceSubCategory.ID = allowanceCategory.ID;
                            }
                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(allowanceSetup);
                            }
                            else
                            {
                                allowanceSetup.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(allowanceSetup);
                            }
                        }
                    }
                    
                    dal.CommitTransaction();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Data not saved successfully");
                dal.RollBackTransaction();
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                levelErrorProvider.Clear();
                amountErrorProvider.Clear();
                descriptionErrorProvider.Clear();
                if (!Validator.NullOrEmptyStringValidator(levelsComboBox.Text))
                {
                    result = false;
                    levelErrorProvider.SetError(levelsComboBox, "Please select a valid level");
                    return result;
                }
                try
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                if (grid.RowCount == 1)
                {
                    result = false;
                    descriptionErrorProvider.SetError(groupBox1, "Please enter at least one allowance type");
                    return result;
                }
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value == null || row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            descriptionErrorProvider.SetError(groupBox1, "Please enter a description on row " + row.Index + 1);
                        }
                        if (row.Cells["gridAllowanceCategory"].Value == null || row.Cells["gridAllowanceCategory"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            descriptionErrorProvider.SetError(groupBox1, "Please enter Allowance Category on row " + row.Index + 1);
                        }
                        if (row.Cells["gridAmount"].Value == null || !Validator.DecimalValidator(row.Cells["gridAmount"].Value.ToString()))
                        {
                            result = false;
                            amountErrorProvider.SetError(groupBox1, "Please enter a valid decimal amount on row " + row.Index + 1);
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.dal.CloseConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region CLEAR
        private void Clear()
        {
            try
            {
                levelsComboBox.Items.Clear();
                levelsComboBox.Text = string.Empty;
                groupBox1.Enabled = false;
                grid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void levelTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (levelsComboBox.Text.Trim() != string.Empty)
                {
                    levelErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                this.grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && grid.CurrentCell.Value != null)
                {
                    if (grid.CurrentCell.ColumnIndex == gridDescription.Index)
                    {
                        if (grid.CurrentCell.Value.ToString().Trim() != string.Empty)
                        {
                            descriptionErrorProvider.Clear();
                        }
                    }
                    if (grid.CurrentCell.ColumnIndex == gridAmount.Index)
                    {
                        if (grid.CurrentCell.Value.ToString().Trim() != string.Empty)
                        {
                            amountErrorProvider.Clear();
                        }
                    }
                    if (grid.CurrentCell.ColumnIndex == gridAllowanceType.Index)
                    {
                        allowanceTypeID = allowanceTypes[gridAllowanceType.Items.IndexOf(grid.CurrentCell.EditedFormattedValue.ToString())].ID;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void levelsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                
                levelsComboBox.Items.Clear();
                levelsComboBox.Text = string.Empty;
                grades = dal.GetAll<EmployeeGrade>();
                foreach (EmployeeGrade grade in grades)
                {
                    levelsComboBox.Items.Add(grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Allowance> allowances)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                gridAllowanceType.Items.Clear();
                gridAllowanceCategory.Items.Clear();
                allowanceTypes = dal.GetAll<AllowanceCategory>();
                foreach (AllowanceCategory type in allowanceTypes)
                {
                    gridAllowanceType.Items.Add(type.Description);
                }
                allowanceCategories = dal.GetAll<AllowanceSubCategory>();
                foreach (AllowanceSubCategory type in allowanceCategories)
                {
                    gridAllowanceCategory.Items.Add(type.Description);
                }
                foreach (Allowance allowance in allowances)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = allowance.ID;
                    grid.Rows[ctr].Cells["gridCode"].Value = allowance.Code;
                    grid.Rows[ctr].Cells["gridAllowanceType"].Value = allowance.AllowanceType.Description;
                    grid.Rows[ctr].Cells["gridAllowanceCategory"].Value = allowance.AllowanceSubCategory.Description;
                    grid.Rows[ctr].Cells["gridDescription"].Value = allowance.Description;
                    grid.Rows[ctr].Cells["gridAmount"].Value = allowance.Amount;
                    grid.Rows[ctr].Cells["gridInActive"].Value = allowance.InUse;
                    grid.Rows[ctr].Cells["gridUserID"].Value = allowance.User.ID;
                    grid.Rows[ctr].Cells["gridGradeLevel"].Value = allowance.Level.Grade;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                throw ex;
            }
        }

        private void levelsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundAllowances.Clear();               
                grid.Rows.Clear();
                allowances = dal.GetAll<Allowance>();

                foreach (Allowance allowance in allowances)
                {
                    if (allowance.Level.ID == grades[levelsComboBox.SelectedIndex].ID)
                    {
                        foundAllowances.Add(allowance);
                    }
                }
                PopulateView(foundAllowances);
                groupBox1.Enabled = true;

            }
            catch (Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("Cannot load in grid,Please see the System Administrator");
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Allowance_SetupView allowanceSetupView = new Allowance_SetupView(dal);
                allowanceSetupView.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
