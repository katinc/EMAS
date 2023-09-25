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
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.Employment;

namespace eMAS.Forms.SystemSetup
{
    public partial class SingleSpineForm : Form
    {
        private SingleSpine singleSpine;
        private IList<SingleSpine> singleSpines;
        private IList<SingleSpine> singleSpineList;
        private IList<SingleSpine> foundSingleSpines;
        private IList<EmployeeGrade> grades;
        private IList<GradeCategory> gradeCategories;
        private IList<Level> levels;
        private IList<Step> steps;
        private IList<Band> bands;
        private IDAL dal;
        private int ctr;
        private bool found;

        public SingleSpineForm()
        {
            try
            {
                InitializeComponent();
                this.singleSpine = new SingleSpine();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.ctr = 0;
                this.singleSpines = new List<SingleSpine>();
                this.singleSpineList = new List<SingleSpine>();
                this.foundSingleSpines = new List<SingleSpine>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.bands = new List<Band>();
                this.levels = new List<Level>();
                this.steps = new List<Step>();
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in grades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
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
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                if (gradeCategories.Count <= 0)
                {
                    gradeCategories = dal.GetAll<GradeCategory>();
                }

                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboStep_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboStep.Items.Clear();
                if (steps.Count <= 0)
                {
                    steps = dal.GetAll<Step>();
                }

                foreach (Step step in steps)
                {
                    cboStep.Items.Add(step.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLevel_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboLevel.Items.Clear();
                if (bands.Count <= 0)
                {
                    bands = dal.GetAll<Band>();
                }

                foreach (Band band in bands)
                {
                    cboLevel.Items.Add(band.Description);
                }
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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<SingleSpine> singleSpines)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (SingleSpine singleSpine in singleSpines)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = singleSpine.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = singleSpine.EmployeeGrade.Grade;
                    grid.Rows[ctr].Cells["gridStep"].Value = singleSpine.Step.Description;
                    grid.Rows[ctr].Cells["gridLevel"].Value = singleSpine.SalaryLevel;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = singleSpine.BasicSalary;
                    grid.Rows[ctr].Cells["gridUserID"].Value = singleSpine.User.ID;
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
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SingleSpineSalaryView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SingleSpineSalaryView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SingleSpineSalaryView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = grades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboStep.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SingleSpineSalaryView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = steps[cboStep.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboLevel.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SingleSpineSalaryView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = bands[cboLevel.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                singleSpines = dal.GetByCriteria<SingleSpine>(query);
                PopulateView(singleSpines);
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
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboStep.Items.Clear();
                cboStep.Text = string.Empty;
                cboLevel.Items.Clear();
                cboLevel.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool resultGrid = false;
            bool result = false;
            try
            {
                errorProvider.Clear();
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (grid.Rows[ctr].Cells["gridSelect"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    }
                    if (bool.Parse(grid.Rows[ctr].Cells["gridSelect"].Value.ToString()) == true)
                    {
                        resultGrid = true;
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if (resultGrid == false)
                {
                    MessageBox.Show("Select at least one row");
                    resultGrid = false;
                    result = false;
                }
                if (cboGradeCategory.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Grade Category Cannot be Empty");
                    cboGradeCategory.Focus();
                }
                if (cboGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Grade Cannot be Empty");
                    cboGradeCategory.Focus();
                }
                if (cboStep.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Grade Cannot be Empty");
                    cboGradeCategory.Focus();
                }
                if (cboGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Grade Cannot be Empty");
                    cboGradeCategory.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = true;
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
                    grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    ctr++;
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
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SingleSpineForm_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                                singleSpine.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                singleSpine.Archived = true;
                                dal.Delete(singleSpine);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                singleSpine.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                singleSpine.Archived = true;
                                dal.Delete(singleSpine);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                            GetData();
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
