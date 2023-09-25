using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class StaffGradeChangeView : Form
    {
        private IDAL dal;
        private StaffGradeChangeForm staffGradeChangeForm;
        private IList<StaffGradeChange> staffGradeChanges;
        private IList<StaffGradeChange> foundStaffGradeChanges;
        private StaffGradeChange staffGradeChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private Company company;
        private int ctr;
        private bool found;

        public StaffGradeChangeView(IDAL dal, StaffGradeChangeForm staffGradeChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffGradeChange = new StaffGradeChange();
                this.staffGradeChangeForm = staffGradeChangeForm;
                this.staffGradeChanges = new List<StaffGradeChange>();
                this.foundStaffGradeChanges = new List<StaffGradeChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dateEntry.Value = DateTime.Today.Date;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffGradeChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffGradeChange = new StaffGradeChange();
                this.staffGradeChangeForm = new StaffGradeChangeForm();
                this.staffGradeChanges = new List<StaffGradeChange>();
                this.foundStaffGradeChanges = new List<StaffGradeChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dateEntry.Value = DateTime.Today.Date;
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
                if (grid.CurrentRow != null)
                {
                    StaffGradeChange staffGradeChange = new StaffGradeChange();
                    staffGradeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffGradeChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffGradeChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffGradeChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    staffGradeChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                    staffGradeChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategoryFrom"].Value.ToString();
                    staffGradeChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGradeFrom"].Value.ToString();
                    staffGradeChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                    if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                    {
                        staffGradeChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                    }
                    if (grid.CurrentRow.Cells["gridGradeDate"].Value != null)
                    {
                        staffGradeChange.Employee.GradeDate = DateTime.Parse(grid.CurrentRow.Cells["gridGradeDate"].Value.ToString());
                    }

                    staffGradeChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    staffGradeChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                    staffGradeChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                    staffGradeChange.GradeCategoryTo.Description = grid.CurrentRow.Cells["gridGradeCategoryTo"].Value.ToString();
                    staffGradeChange.GradeTo.Grade = grid.CurrentRow.Cells["gridGradeTo"].Value.ToString();
                    staffGradeChangeForm.EditStaffGradeChange(staffGradeChange);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s termination?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                staffGradeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffGradeChange.Archived = true;
                                dal.Delete(staffGradeChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffGradeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffGradeChange.Archived = true;
                                dal.Delete(staffGradeChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
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

        private void StaffGradeChangeView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch(Exception ex)
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

        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                cboGradeTo.Items.Clear();
                cboGradeTo.Text = string.Empty;
                cboGradeCategoryTo.Items.Clear();
                cboGradeCategoryTo.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                dateEntry.Value = DateTime.Today.Date;
                staffIDtxt.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<StaffGradeChange> staffGradeChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffGradeChange staffGradeChange in staffGradeChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffGradeChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffGradeChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffGradeChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffGradeChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffGradeChange.Employee.EmploymentDate;
                    grid.Rows[ctr].Cells["gridGradeCategoryFrom"].Value = staffGradeChange.GradeCategoryFrom.Description;
                    grid.Rows[ctr].Cells["gridGradeFrom"].Value = staffGradeChange.GradeFrom.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategoryTo"].Value = staffGradeChange.GradeCategoryTo.Description;
                    grid.Rows[ctr].Cells["gridGradeTo"].Value = staffGradeChange.GradeTo.Grade;
                    grid.Rows[ctr].Cells["gridGradeDate"].Value = staffGradeChange.Employee.GradeDate;

                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffGradeChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffGradeChange.Date;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffGradeChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffGradeChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffGradeChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffGradeChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffGradeChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffGradeChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffGradeChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffGradeChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffGradeChange.User.ID;

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
                        Property = "StaffGradeChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.GradeCategoryFrom",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.GradeFrom",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategoryTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.GradeCategoryTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategoryTo.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.GradeTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGradeTo.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffGradeChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffGradeChanges = dal.GetByCriteria<StaffGradeChange>(query);
                PopulateView(staffGradeChanges);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        foundStaffGradeChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffGradeChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffGradeChanges = dal.GetByCriteria<StaffGradeChange>(query);
                        if (staffGradeChanges.Count > 0)
                        {
                            foreach (StaffGradeChange staffGradeChange in this.staffGradeChanges)
                            {
                                if (staffGradeChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffGradeChanges.Add(staffGradeChange);
                                }
                            }
                            PopulateView(foundStaffGradeChanges);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }

                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
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
                    Value = cboDepartment.SelectedItem,
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

        private void cboGradeCategoryTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGradeTo.Items.Clear();
                cboGradeTo.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategoryTo.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGradeTo.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategoryTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategoryTo.Items.Clear();
                if (gradeCategories.Count <= 0)
                {
                    gradeCategories = dal.GetAll<GradeCategory>();
                }

                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategoryTo.Items.Add(category.Description);
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
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
