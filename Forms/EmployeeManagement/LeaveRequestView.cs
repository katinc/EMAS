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
    public partial class LeaveView : Form
    {
        private IDAL dal;
        private Leave leave;
        private IList<Leave> leaves;
        private IList<Leave> foundLeaves;
        private LeaveRequest leaveNew;
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

        public LeaveView(LeaveRequest leaveNew)
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.leaveNew = leaveNew;
                this.employee = new Employee();
                this.leave = new Leave();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.leaves = new List<Leave>();
                this.foundLeaves= new List<Leave>();
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
                foreach (Leave item in leaves)
                {
                    if (grid.CurrentRow != null && item.ID == int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString()))
                    {
                        if (!leaveNew.permissions.CanEdit)
                        {
                            MessageBox.Show("Sorry you do not have permission to edit this data.");
                            return;
                        }

                        leave = item;
                        leaveNew.EditLeave(leave);
                        leaveNew.Show();
                        leaveNew.BringToFront();
                        this.Close();
                    }
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
                            leave = dal.GetByID<Leave>(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            //string leaveType = grid.CurrentRow.Cells["gridType"].Value.ToString();
                            //employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                            employee = dal.LazyLoadByStaffID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value.ToString());
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {

                                //dal.Delete(leave);
                                GlobalData.ProcessDelete(this.Name, leave.ID);
                                updateEmployeeLeave(employee, leave.NumberOfDays, leave.LeaveType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                //dal.Delete(leave);
                                GlobalData.ProcessDelete("LeaveRequest", leave.ID);
                                updateEmployeeLeave(employee, leave.NumberOfDays, leave.LeaveType);
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

        private void updateEmployeeLeave(Employee employee, decimal NumberOfDays, string leaveType)
        {
            try
            {
                employee.StaffID = employee.StaffID;
                employee = dal.LazyLoadByStaffID<Employee>(employee);
                employee.LeaveStatus = "Not Requested";
                employee.CurrentLeaveDate = null;
                employee.CurrentLeaveStartDate = null;
                employee.CurrentLeaveEndDate = null;
                

                if (leaveType.ToUpper() == "ANNUAL LEAVE")
                {
                    employee.LeaveTaken -= int.Parse(NumberOfDays.ToString());
                    employee.LeaveBalance += int.Parse(NumberOfDays.ToString());
                    // employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());

                }

                if (leaveType.ToUpper() == "CASUAL LEAVE")
                {
                    employee.CasualLeave -= int.Parse(NumberOfDays.ToString());
                    employee.CasualLeaveDate = null;
                }

                dal.Update(employee);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
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

        private void PopulateView(IList<Leave> leaves)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Leave leave in leaves)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = leave.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = leave.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = leave.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = leave.StaffName;
                    grid.Rows[ctr].Cells["gridGender"].Value = leave.Employee.Gender;
                    grid.Rows[ctr].Cells["gridAge"].Value = leave.Employee.Age;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = leave.StaffName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = leave.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = leave.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = leave.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = leave.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridAnnualLeave"].Value = leave.Employee.AnnualLeave;
                    grid.Rows[ctr].Cells["gridAnnualLeaveYear"].Value = leave.Employee.AnnualLeaveYear;
                    grid.Rows[ctr].Cells["gridCurrentLeaveEndDate"].Value = leave.Employee.CurrentLeaveEndDate;
                    grid.Rows[ctr].Cells["gridLeaveArrears"].Value = leave.Employee.LeaveArrears;
                    grid.Rows[ctr].Cells["gridAnnualLeaveProposedStartDate"].Value = leave.Employee.AnnualLeaveProposedStartDate;
                    grid.Rows[ctr].Cells["gridAnnualLeaveProposedEndDate"].Value = leave.Employee.AnnualLeaveProposedEndDate;
                    grid.Rows[ctr].Cells["gridAnnualLeaveProposedDays"].Value = leave.Employee.AnnualLeaveProposedDays;
                    grid.Rows[ctr].Cells["gridLeaveArrears"].Value = leave.Employee.LeaveArrears;
                    grid.Rows[ctr].Cells["gridLeaveBalance"].Value = leave.Employee.LeaveBalance;
                    grid.Rows[ctr].Cells["gridType"].Value = leave.LeaveType;
                    grid.Rows[ctr].Cells["gridStatus"].Value = leave.Status;
                    grid.Rows[ctr].Cells["gridNumberOfDays"].Value = leave.NumberOfDays;
                    grid.Rows[ctr].Cells["gridStartDate"].Value = leave.StartDate;
                    grid.Rows[ctr].Cells["gridEndDate"].Value = leave.EndDate;
                    grid.Rows[ctr].Cells["gridLeaveDate"].Value = leave.LeaveDate;
                    grid.Rows[ctr].Cells["gridReason"].Value = leave.Reason;
                    grid.Rows[ctr].Cells["gridApproved"].Value = leave.Approved;
                    grid.Rows[ctr].Cells["gridRecommended"].Value = leave.Recommended;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    grid.Rows[ctr].Cells["gridLeaveYear"].Value = leave.LeaveYear;
                    grid.Rows[ctr].Cells["gridFunding"].Value = leave.Funding;
                    grid.Rows[ctr].Cells["gridProgramType"].Value = leave.ProgramType;

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
                        Property = "StaffLeaveView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboLeaveType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.LeaveType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = leaveTypes[cboLeaveType.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLeaveView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                if (cmbApproved.Text == "YES" || cmbApproved.Text == "NO")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cmbApproved.Text == "NO" ? false : true,
                        CriteriaOperator = CriteriaOperator.None
                    });
                }
                leaves = dal.GetByCriteria<Leave>(query);
                if (leaves.Count == 0)
                {
                    MessageBox.Show("No pending leave request", "Leave View");
                    return;
                }
                PopulateView(leaves);
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
                leave = new Leave();
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

        private void LeaveView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                cmbApproved_DropDown(sender, e);
                cmbApproved.Text = "NO";
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                        foundLeaves.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.Archived",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        leaves = dal.GetByCriteria<Leave>(query);
                        if (leaves.Count > 0)
                        {
                            foreach (Leave leave in this.leaves)
                            {
                                if (leave.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundLeaves.Add(leave);
                                }
                            }
                            PopulateView(foundLeaves);
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
                grid.Rows.Clear();
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

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboGradeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbApproved_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbApproved.Items.Clear();
                cmbApproved.Items.Add("ALL");
                cmbApproved.Items.Add("NO");
                cmbApproved.Items.Add("YES");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
