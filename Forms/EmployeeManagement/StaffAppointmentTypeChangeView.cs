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
    public partial class StaffAppointmentTypeChangeView : Form
    {
        private IDAL dal;
        private StaffAppointmentTypeChangeForm staffAppointmentTypeChangeForm;
        private IList<StaffAppointmentTypeChange> staffAppointmentTypeChanges;
        private IList<StaffAppointmentTypeChange> foundStaffAppointmentTypeChanges;
        private StaffAppointmentTypeChange staffAppointmentTypeChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<AppointmentType> appointmentTypes;
        private Company company;
        private int ctr;
        private bool found;

        public StaffAppointmentTypeChangeView(IDAL dal, StaffAppointmentTypeChangeForm staffAppointmentTypeChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffAppointmentTypeChange = new StaffAppointmentTypeChange();
                this.staffAppointmentTypeChangeForm = staffAppointmentTypeChangeForm;
                this.staffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
                this.foundStaffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.appointmentTypes = new List<AppointmentType>();
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

        public StaffAppointmentTypeChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffAppointmentTypeChange = new StaffAppointmentTypeChange();
                this.staffAppointmentTypeChangeForm = new StaffAppointmentTypeChangeForm();
                this.staffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
                this.foundStaffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.appointmentTypes = new List<AppointmentType>();
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
                    StaffAppointmentTypeChange staffAppointmentTypeChange = new StaffAppointmentTypeChange();
                    staffAppointmentTypeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffAppointmentTypeChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffAppointmentTypeChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffAppointmentTypeChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    staffAppointmentTypeChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                    staffAppointmentTypeChange.Employee.AppointmentType.Description = grid.CurrentRow.Cells["gridAppointmentTypeFrom"].Value.ToString();
                    staffAppointmentTypeChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                    staffAppointmentTypeChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                    staffAppointmentTypeChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                    if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                    {
                        staffAppointmentTypeChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                    }

                    staffAppointmentTypeChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    staffAppointmentTypeChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                    staffAppointmentTypeChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                    staffAppointmentTypeChange.AppointmentTypeTo.Description = grid.CurrentRow.Cells["gridAppointmentTypeTo"].Value.ToString();
                    staffAppointmentTypeChangeForm.EditStaffAppointmentTypeChange(staffAppointmentTypeChange);
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
                                staffAppointmentTypeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffAppointmentTypeChange.Archived = true;
                                dal.Delete(staffAppointmentTypeChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffAppointmentTypeChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffAppointmentTypeChange.Archived = true;
                                dal.Delete(staffAppointmentTypeChange);
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

        private void StaffAppointmentTypeChangeView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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

        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                cboAppointmentTypeTo.Items.Clear();
                cboAppointmentTypeTo.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                dateEntry.Value = DateTime.Today.Date;
                dateEntry.Checked = false;
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

        private void PopulateView(IList<StaffAppointmentTypeChange> staffAppointmentTypeChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffAppointmentTypeChange staffAppointmentTypeChange in staffAppointmentTypeChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffAppointmentTypeChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffAppointmentTypeChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffAppointmentTypeChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffAppointmentTypeChange.StaffName;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffAppointmentTypeChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffAppointmentTypeChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffAppointmentTypeChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffAppointmentTypeChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffAppointmentTypeChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffAppointmentTypeChange.Employee.EmploymentDate;
                    grid.Rows[ctr].Cells["gridAppointmentTypeFrom"].Value = staffAppointmentTypeChange.AppointmentTypeFrom.Description;
                    grid.Rows[ctr].Cells["gridAppointmentTypeTo"].Value = staffAppointmentTypeChange.AppointmentTypeTo.Description;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffAppointmentTypeChange.Date;

                    grid.Rows[ctr].Cells["gridApproved"].Value = staffAppointmentTypeChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffAppointmentTypeChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffAppointmentTypeChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffAppointmentTypeChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffAppointmentTypeChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffAppointmentTypeChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffAppointmentTypeChange.User.ID;

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
                        Property = "StaffAppointmentTypeChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboAppointmentType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.AppointmentTypeFrom",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = appointmentTypes[cboAppointmentType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboAppointmentTypeTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.AppointmentTypeTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = appointmentTypes[cboAppointmentTypeTo.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAppointmentTypeChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffAppointmentTypeChanges = dal.GetByCriteria<StaffAppointmentTypeChange>(query);
                PopulateView(staffAppointmentTypeChanges);
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
                        foundStaffAppointmentTypeChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffAppointmentTypeChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffAppointmentTypeChanges = dal.GetByCriteria<StaffAppointmentTypeChange>(query);
                        if (staffAppointmentTypeChanges.Count > 0)
                        {
                            foreach (StaffAppointmentTypeChange staffAppointmentTypeChange in this.staffAppointmentTypeChanges)
                            {
                                if (staffAppointmentTypeChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffAppointmentTypeChanges.Add(staffAppointmentTypeChange);
                                }
                            }
                            PopulateView(foundStaffAppointmentTypeChanges);
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

        private void cboAppointmentTypeTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppointmentTypeTo.Items.Clear();
                if (appointmentTypes.Count <= 0)
                {
                    appointmentTypes = dal.GetAll<AppointmentType>();
                }

                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    cboAppointmentTypeTo.Items.Add(appointmentType.Description);
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

        private void cboAppointmentType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppointmentTypeTo.Items.Clear();
                if (appointmentTypes.Count <= 0)
                {
                    appointmentTypes = dal.GetAll<AppointmentType>();
                }

                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    cboAppointmentTypeTo.Items.Add(appointmentType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
