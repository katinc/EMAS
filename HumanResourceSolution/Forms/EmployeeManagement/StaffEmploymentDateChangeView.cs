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
    public partial class StaffEmploymentDateChangeView : Form
    {
        private IDAL dal;
        private StaffEmploymentDateChangeForm staffEmploymentDateChangeForm;
        private IList<StaffEmploymentDateChange> staffEmploymentDateChanges;
        private IList<StaffEmploymentDateChange> foundStaffEmploymentDateChanges;
        private StaffEmploymentDateChange staffEmploymentDateChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<StaffStatus> statuses;
        private Company company;
        private int ctr;
        private bool found;

        public StaffEmploymentDateChangeView(IDAL dal, StaffEmploymentDateChangeForm staffEmploymentDateChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffEmploymentDateChange = new StaffEmploymentDateChange();
                this.staffEmploymentDateChangeForm = staffEmploymentDateChangeForm;
                this.staffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
                this.foundStaffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
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

        public StaffEmploymentDateChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffEmploymentDateChange = new StaffEmploymentDateChange();
                this.staffEmploymentDateChangeForm = new StaffEmploymentDateChangeForm();
                this.staffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
                this.foundStaffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
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
                        StaffEmploymentDateChange staffEmploymentDateChange = new StaffEmploymentDateChange();
                        staffEmploymentDateChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        staffEmploymentDateChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        staffEmploymentDateChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        staffEmploymentDateChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        staffEmploymentDateChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        staffEmploymentDateChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        staffEmploymentDateChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        staffEmploymentDateChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            staffEmploymentDateChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }

                        staffEmploymentDateChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        staffEmploymentDateChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        staffEmploymentDateChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridDOB"].Value != null)
                        {
                            staffEmploymentDateChange.Employee.DOB = DateTime.Parse(grid.CurrentRow.Cells["gridDOB"].Value.ToString());
                        }
                        if (grid.CurrentRow.Cells["gridEmploymentDateTo"].Value != null)
                        {
                            staffEmploymentDateChange.EmploymentDateTo = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDateTo"].Value.ToString());
                        }

                        staffEmploymentDateChangeForm.EditStaffEmploymentChange(staffEmploymentDateChange);
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
                                staffEmploymentDateChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffEmploymentDateChange.Archived = true;
                                dal.Delete(staffEmploymentDateChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffEmploymentDateChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffEmploymentDateChange.Archived = true;
                                dal.Delete(staffEmploymentDateChange);
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

        private void StaffDOBChangeView_Load(object sender, EventArgs e)
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
                dateEmploymentFrom.Checked = false;
                dateEmploymentTo.Checked = false;
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

        private void PopulateView(IList<StaffEmploymentDateChange> staffEmploymentDateChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffEmploymentDateChange staffEmploymentDateChange in staffEmploymentDateChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffEmploymentDateChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffEmploymentDateChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffEmploymentDateChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffEmploymentDateChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffEmploymentDateChange.Employee.EmploymentDate.Value.Date;
                    grid.Rows[ctr].Cells["gridEmploymentDateTo"].Value = staffEmploymentDateChange.EmploymentDateTo;


                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffEmploymentDateChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffEmploymentDateChange.Date;
                    grid.Rows[ctr].Cells["gridDOB"].Value = staffEmploymentDateChange.Employee.DOB;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffEmploymentDateChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffEmploymentDateChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffEmploymentDateChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffEmploymentDateChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffEmploymentDateChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffEmploymentDateChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffEmploymentDateChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffEmploymentDateChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffEmploymentDateChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffEmploymentDateChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffEmploymentDateChange.User.ID;

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
                        Property = "StaffEmploymentDateChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEmploymentFrom.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEmploymentFrom.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEmploymentTo.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEmploymentTo.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffEmploymentDateChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                staffEmploymentDateChanges = dal.GetByCriteria<StaffEmploymentDateChange>(query);
                PopulateView(staffEmploymentDateChanges);
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
                        foundStaffEmploymentDateChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffEmploymentDateChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffEmploymentDateChanges = dal.GetByCriteria<StaffEmploymentDateChange>(query);
                        if (staffEmploymentDateChanges.Count > 0)
                        {
                            foreach (StaffEmploymentDateChange staffEmploymentDateChange in this.staffEmploymentDateChanges)
                            {
                                if (staffEmploymentDateChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffEmploymentDateChanges.Add(staffEmploymentDateChange);
                                }
                            }
                            PopulateView(foundStaffEmploymentDateChanges);
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

