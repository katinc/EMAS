using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveRoasterView : Form
    {
        private IDAL dal;
        private StaffLeaveRoaster staffLeaveRoaster;
        private IList<StaffLeaveRoaster> staffLeaveRoasters;
        private IList<StaffLeaveRoaster> foundStaffLeaveRoasters;
        private LeaveRoasterForm leaveRoasterForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<LeaveType> leaveTypes;
        private Company company;
        private int ctr;
        private bool found;

        public LeaveRoasterView(LeaveRoasterForm leaveRoasterForm)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.leaveRoasterForm = leaveRoasterForm;
                this.employee = new Employee();
                this.staffLeaveRoaster = new StaffLeaveRoaster();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.staffLeaveRoasters = new List<StaffLeaveRoaster>();
                this.foundStaffLeaveRoasters = new List<StaffLeaveRoaster>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.leaveTypes = new List<LeaveType>();
                this.dal = new DAL();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();       
            }
            catch(Exception ex)
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
                    staffLeaveRoaster.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffLeaveRoaster.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffLeaveRoaster.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffLeaveRoaster.Employee.Gender = grid.CurrentRow.Cells["gridGender"].Value.ToString();
                    staffLeaveRoaster.Employee.Age = grid.CurrentRow.Cells["gridAge"].Value.ToString();
                    staffLeaveRoaster.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    staffLeaveRoaster.Employee.LeaveArrears = int.Parse(grid.CurrentRow.Cells["gridLeaveArrears"].Value.ToString());
                    staffLeaveRoaster.Employee.AnnualLeave = int.Parse(grid.CurrentRow.Cells["gridAnnualLeave"].Value.ToString());
                    staffLeaveRoaster.Employee.AnnualLeaveYear = int.Parse(grid.CurrentRow.Cells["gridAnnualLeaveYear"].Value.ToString());

                    staffLeaveRoaster.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    staffLeaveRoaster.LeaveType = grid.CurrentRow.Cells["gridType"].Value.ToString();
                    staffLeaveRoaster.NumberOfDays = int.Parse(grid.CurrentRow.Cells["gridNumberOfDays"].Value.ToString());
                    staffLeaveRoaster.StartDate = DateTime.Parse(grid.CurrentRow.Cells["gridStartDate"].Value.ToString());
                    staffLeaveRoaster.EndDate = DateTime.Parse(grid.CurrentRow.Cells["gridEndDate"].Value.ToString());
                    staffLeaveRoaster.LeaveDate = DateTime.Parse(grid.CurrentRow.Cells["gridLeaveDate"].Value.ToString());
                    leaveRoasterForm.EditLeave(staffLeaveRoaster);
                    leaveRoasterForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error: Please see the system Administrator");
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s leave?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {

                                staffLeaveRoaster.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLeaveRoaster);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffLeaveRoaster.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLeaveRoaster);
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
                            MessageBox.Show("Cannot Remove this record,Please See the System Administrator");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
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

        private void PopulateView(IList<StaffLeaveRoaster> staffLeaveRoasters)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (StaffLeaveRoaster staffLeaveRoaster in staffLeaveRoasters)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffLeaveRoaster.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffLeaveRoaster.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffLeaveRoaster.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffLeaveRoaster.StaffName;
                    grid.Rows[ctr].Cells["gridGender"].Value = staffLeaveRoaster.Employee.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = staffLeaveRoaster.Employee.Age;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffLeaveRoaster.StaffName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffLeaveRoaster.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffLeaveRoaster.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffLeaveRoaster.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffLeaveRoaster.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridAnnualLeave"].Value = staffLeaveRoaster.Employee.AnnualLeave;
                    grid.Rows[ctr].Cells["gridAnnualLeaveYear"].Value = staffLeaveRoaster.Employee.AnnualLeaveYear;
                    grid.Rows[ctr].Cells["gridLeaveArrears"].Value = staffLeaveRoaster.Employee.LeaveArrears;
                    grid.Rows[ctr].Cells["gridType"].Value = staffLeaveRoaster.LeaveType;
                    grid.Rows[ctr].Cells["gridNumberOfDays"].Value = staffLeaveRoaster.NumberOfDays;
                    grid.Rows[ctr].Cells["gridStartDate"].Value = staffLeaveRoaster.StartDate;
                    grid.Rows[ctr].Cells["gridEndDate"].Value = staffLeaveRoaster.EndDate;
                    grid.Rows[ctr].Cells["gridLeaveDate"].Value = staffLeaveRoaster.LeaveDate;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffLeaveRoaster.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
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
                        Property = "StaffLeaveRoasterView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboLeaveType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.LeaveType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = leaveTypes[cboLeaveType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveRoasterView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffLeaveRoasters = dal.GetByCriteria<StaffLeaveRoaster>(query);
                PopulateView(staffLeaveRoasters);
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
                staffLeaveRoaster = new StaffLeaveRoaster();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                cboLeaveType.Items.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void StaffLeaveRoasterView_Load(object sender, EventArgs e)
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
                throw ex;
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundStaffLeaveRoasters.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveRoasterView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffLeaveRoasters = dal.GetByCriteria<StaffLeaveRoaster>(query);
                        if (staffLeaveRoasters.Count > 0)
                        {
                            foreach (StaffLeaveRoaster staffLeaveRoaster in this.staffLeaveRoasters)
                            {
                                if (staffLeaveRoaster.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundStaffLeaveRoasters.Add(staffLeaveRoaster);
                                }
                            }
                            PopulateView(foundStaffLeaveRoasters);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not Found");
                            txtStaffID.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
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

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                departments = dal.GetAll<Department>();
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

        private void cboLeaveType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboLeaveType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "LeaveTypeView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "LeaveTypeView.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = "Annual Leave",
                    CriteriaOperator = CriteriaOperator.None
                });
                leaveTypes = dal.GetByCriteria<LeaveType>(query);
                foreach (LeaveType leaveType in leaveTypes)
                {
                    cboLeaveType.Items.Add(leaveType.Description);
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
