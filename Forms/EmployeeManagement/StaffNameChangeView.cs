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
    public partial class StaffNameChangeView : Form
    {
        private IDAL dal;
        private StaffNameChangeForm staffNameChangeForm;
        private IList<StaffNameChange> staffNameChanges;
        private IList<StaffNameChange> foundStaffNameChanges;
        private StaffNameChange staffNameChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<StaffStatus> statuses;
        private Company company;
        private int ctr;
        private bool found;

        public StaffNameChangeView(IDAL dal, StaffNameChangeForm staffNameChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffNameChange = new StaffNameChange();
                this.staffNameChangeForm = staffNameChangeForm;
                this.staffNameChanges = new List<StaffNameChange>();
                this.foundStaffNameChanges = new List<StaffNameChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.statuses = new List<StaffStatus>();
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

        public StaffNameChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffNameChange = new StaffNameChange();
                this.staffNameChangeForm = new StaffNameChangeForm();
                this.staffNameChanges = new List<StaffNameChange>();
                this.foundStaffNameChanges = new List<StaffNameChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.statuses = new List<StaffStatus>();
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
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == true)
                    {
                        StaffNameChange staffNameChange = new StaffNameChange();
                        staffNameChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        staffNameChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        staffNameChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        staffNameChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        staffNameChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        staffNameChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        staffNameChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        staffNameChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        staffNameChange.Employee.StaffStatus.Description = grid.CurrentRow.Cells["gridStatus"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            staffNameChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }

                        staffNameChange.Employee.StaffStatus.Description = grid.CurrentRow.Cells["gridStatus"].Value.ToString();
                        staffNameChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        staffNameChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        staffNameChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        staffNameChange.SurnameTo = grid.CurrentRow.Cells["gridSurnameTo"].Value.ToString();
                        staffNameChange.FirstNameTo = grid.CurrentRow.Cells["gridFirstNameTo"].Value.ToString();
                        staffNameChange.OtherNameTo = grid.CurrentRow.Cells["gridOtherNameTo"].Value.ToString();

                        staffNameChangeForm.EditStaffNameChange(staffNameChange);
                        Close();
                    }               
                }
            }
            catch(Exception ex)
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
                                staffNameChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffNameChange.Archived = true;
                                dal.Delete(staffNameChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffNameChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffNameChange.Archived = true;
                                dal.Delete(staffNameChange);
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void StaffNameChangeView_Load(object sender, EventArgs e)
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
                txtFirstNameTo.Clear();
                txtSurnameTo.Clear();
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<StaffNameChange> staffNameChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffNameChange staffNameChange in staffNameChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffNameChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffNameChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffNameChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffNameChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridStatus"].Value = staffNameChange.Employee.StaffStatus.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffNameChange.Employee.EmploymentDate;

                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffNameChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffNameChange.Date;
                    grid.Rows[ctr].Cells["gridFirstNameTo"].Value = staffNameChange.FirstNameTo;
                    grid.Rows[ctr].Cells["gridSurnameTo"].Value = staffNameChange.SurnameTo;
                    grid.Rows[ctr].Cells["gridOtherNameTo"].Value = staffNameChange.OtherNameTo;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffNameChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffNameChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffNameChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffNameChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffNameChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffNameChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffNameChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffNameChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffNameChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffNameChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffNameChange.User.ID;

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
                        Property = "StaffNameChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurnameTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.SurnameTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtSurnameTo.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstNameTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.FirstNameTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtFirstNameTo.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffNameChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffNameChanges = dal.GetByCriteria<StaffNameChange>(query);
                PopulateView(staffNameChanges);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                        foundStaffNameChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffNameChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffNameChanges = dal.GetByCriteria<StaffNameChange>(query);
                        if (staffNameChanges.Count > 0)
                        {
                            foreach (StaffNameChange staffNameChange in this.staffNameChanges)
                            {
                                if (staffNameChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffNameChanges.Add(staffNameChange);
                                }
                            }
                            PopulateView(foundStaffNameChanges);
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
    }
}
