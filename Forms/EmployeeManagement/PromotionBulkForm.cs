using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class PromotionBulkForm : Form
    {
        private IDAL dal;
        private IList<Unit> units;
        private DALHelper dalHelper;
        private IList<GradeCategory> gradeCategory;
        private DataReference.EmployeeGradeView grades;


        public PromotionBulkForm()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.dal.OpenConnection();
            this.units = new List<Unit>();
            this.gradeCategory = new List<GradeCategory>();
            this.grades = new DataReference.EmployeeGradeView();
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            
        }

        private void LoadGradeCategory(ComboBox gradeCategory)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                var gradeCategories = dal.GetAll<GradeCategory>();
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

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadGrade(cboGradeCategory, cboGrade);
        }

        private void LoadGrade(ComboBox gradeCategory, ComboBox grade)
        {
            try
            {
                Query query = new Query();
                grade.Items.Clear();
                grade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                var employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    grade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.Items.Clear();
                var departments = dal.GetAll<Department>();
                foreach (var department in departments)
                {
                    cmbDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
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

        private void GetData()
        {
            dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            try
            {
                grid.Rows.Clear();

                var promotions = GlobalData._context.PromotionViews.Where(u =>
                    (u.Department.Contains(cmbDepartment.Text) || u.Department == string.Empty || u.Department == null) &&
                    (u.Unit.Contains(cboUnit.Text) || u.Unit == string.Empty || u.Unit == null) &&
                    (u.GradeCategory.Contains(cboGradeCategory.Text) || u.GradeCategory == string.Empty || u.GradeCategory == null) &&
                    (u.Grade.Contains(cboGrade.Text) || u.Grade == string.Empty || u.Grade == null)
                    && (u.Archived == false)).ToList();

                grid.Rows.Clear();
                PopulateGrid(promotions);
                grid.ClearSelection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                // throw ex;
            }
        }

        private void PopulateGrid(IList<DataReference.PromotionView> promotions)
        {
            try
            {
                int ctr = 0;

                foreach (var item in promotions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = item.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = item.StaffID;
                    grid.Rows[ctr].Cells["gridName"].Value = String.Concat(item.Firstname + " " + item.OtherName).Trim() + " " + item.Surname;

                    grid.Rows[ctr].Cells["gridDepartment"].Value = item.Department;
                    grid.Rows[ctr].Cells["gridUnit"].Value = item.Unit;

                    grid.Rows[ctr].Cells["gridOldGradeCategory"].Value = item.GradeCategory;
                    grid.Rows[ctr].Cells["gridOldGrade"].Value = item.Grade;
                    grid.Rows[ctr].Cells["gridOldStep"].Value = item.Step;
                    grid.Rows[ctr].Cells["gridOldBasicSalary"].Value = item.BasicSalary;
                    //grid.Rows[ctr].Cells[""].Value = item.;
                    
                    ctr++;
                }
            }
            catch (Exception exii)
            {
                Logger.LogError(exii);
            }
        }

        private void LoadPromotionTypes()
        {
            try
            {
                gridPromotionType.Items.Clear();
                var promotionTypes = dal.GetAll<PromotionType>();
                foreach (PromotionType promotionType in promotionTypes)
                {
                    if (promotionType.Description != "DEMOTION")
                    {
                        gridPromotionType.Items.Add(promotionType.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        

        private void PromotionBulkForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.LoadGradeCategory(cboGradeCategory);
                this.LoadGradeCategory(gridNewGradeCategory);
                cboUnit.Items.Clear();
                LoadPromotionTypes();
            }
            catch (Exception es)
            {
                Logger.LogError(es);
            }
        }

        private void LoadGradeCategory(DataGridViewComboBoxColumn gridNewGradeCategory)
        {
            try
            {
                gridNewGradeCategory.Items.Clear();
                gradeCategory = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategory)
                {
                    gridNewGradeCategory.Items.Add(category.Description);
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
                if (grid.CurrentCell != null)
                {
                    if (grid.CurrentCell.ColumnIndex == 9)
                    {
                        if (grid.CurrentRow != null && grid.CurrentRow.Cells["gridNewGradeCategory"].Value != null)
                        {
                            foreach (var gradeCategory in gradeCategory)
                            {
                                if (gradeCategory.Description.Trim() == grid.CurrentRow.Cells["gridNewGradeCategory"].Value.ToString().Trim())
                                {
                                    GetGrades(gradeCategory.Description);
 
                                }
                            }

                        }
                    }
                    else if (grid.CurrentCell.ColumnIndex == 10 && grid.CurrentRow.Cells["gridNewGrade"].Value != null)
                    {
                        foreach (var gradeCategory in gradeCategory)
                        {
                            if (gradeCategory.Description.Trim() == grid.CurrentRow.Cells["gridNewGradeCategory"].Value.ToString().Trim())
                            {
                                GetSteps();
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

        private void GetGrades(string gradeCategory)
        {
            try
            {
                var grades = GlobalData._context.EmployeeGradeViews.Where(u=>u.GradeCategory == gradeCategory);
                gridNewGrade.Items.Clear();

                foreach (var item in grades)
                {
                    gridNewGrade.Items.Add(item.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void GetSteps()
        {
            try
            {
                gridNewStep.Items.Clear();
                string SelectedGrade = grid.CurrentRow.Cells["gridNewGrade"].Value.ToString();
                var grades = GlobalData._context.EmployeeGradeViews.FirstOrDefault(u => u.Description == SelectedGrade);
                var steps = GlobalData._context.Steps.ToList();

                for (int i = grades.StartStep.Value - 1; i <= grades.EndStep.Value + 1; i++)
                {
                    if (steps[i].id >= i && steps[i].id <= grades.EndStep.Value + 1) 
                    {
                        gridNewStep.Items.Add(steps[i].Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }
    }
}
