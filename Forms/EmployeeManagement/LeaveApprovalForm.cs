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
using HRBussinessLayer.Validation;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using System.Configuration;
using System.Data.SqlClient;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveApprovalForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private Leave leave;
        private IList<Leave> leaves;
        private IList<Leave> foundLeaves;
        private IList<LeaveType> leaveTypes;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private Company company;
        private int ctr;
        private bool approved;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        private DALHelper dalCommand;


        public LeaveApprovalForm()
        {
            InitializeComponent();
            this.leave = new Leave();
            this.leaves = new List<Leave>();
            this.foundLeaves = new List<Leave>();
            this.leaveTypes = new List<LeaveType>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();
            this.employees = new List<Employee>();
            this.employee = new Employee();
            this.dal = new DAL();
            this.ctr = 0;
            this.approved = false;
            this.company = new Company();
            this.found = false;
            this.dal.OpenConnection();
        }

        private void PopulateView(IList<Leave> leaves)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Leave leave in leaves)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = leave.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = leave.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = leave.StaffName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = leave.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = leave.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = leave.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = leave.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridLeaveType"].Value = leave.LeaveType;
                    grid.Rows[ctr].Cells["gridLeaveDate"].Value = leave.LeaveDate.ToString("dd/MM/yyyy"); 
                    grid.Rows[ctr].Cells["gridStartDate"].Value = leave.StartDate.ToString("dd/MM/yyyy"); 
                    grid.Rows[ctr].Cells["gridEndDate"].Value = leave.EndDate.ToString("dd/MM/yyyy"); 
                    grid.Rows[ctr].Cells["gridStatus"].Value = leave.Status;
                    grid.Rows[ctr].Cells["gridNumberOfDays"].Value = leave.NumberOfDays;
                    grid.Rows[ctr].Cells["gridRecommended"].Value = leave.Recommended;
                    grid.Rows[ctr].Cells["gridApproved"].Value = leave.Approved;
                    grid.Rows[ctr].Cells["gridRejected"].Value = leave.Rejected;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = leave.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = leave.ApprovedUserStaffID;

                    if (grid.Rows[ctr].Cells["gridApprovedDate"].Value != null && grid.Rows[ctr].Cells["gridApprovedTime"].Value != null)
                    {
                        grid.Rows[ctr].Cells["gridApprovedDate"].Value = leave.ApprovedDate.Value.ToString("dd/MM/yyyy");
                        grid.Rows[ctr].Cells["gridApprovedTime"].Value = leave.ApprovedTime.Value.ToString("dd/MM/yyyy");
                    }

                    
                    grid.Rows[ctr].Cells["gridReason"].Value = leave.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(grid.Rows[ctr].Cells["gridUserID"].Value.ToString()))
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = true;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = false;
                    }
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
                if (datePickerLeaveDate.Checked == true && datePickerLeaveDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.LeaveDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerLeaveDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerStartDate.Checked == true && datePickerStartDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.StartDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerStartDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerEndDate.Checked == true && datePickerEndDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.EndDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerEndDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerLeaveDate.Checked == true && datePickerLeaveDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.LeaveDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerLeaveDate.Value,
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
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboLeaveType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.LeaveType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboLeaveType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboDepartment.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboUnit.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffLeaveView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLeaveView.Recommended",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLeaveView.Rejected",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLeaveView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });

                leaves = dal.GetByCriteria<Leave>(query);
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
                cboLeaveType.Items.Clear();
                cboLeaveType.Text = string.Empty;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerLeaveDate.ResetText();
                datePickerLeaveDate.Checked = false;
                datePickerStartDate.ResetText();
                datePickerStartDate.Checked = false;
                datePickerEndDate.ResetText();
                datePickerEndDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved_DropDown(this, EventArgs.Empty);
                cboApproved.Text = "No";
                approved = false;
                txtStaffID.Clear();
                txtSurname.Clear();
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
                        foundLeaves.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        leaves = dal.GetByCriteria<Leave>(query);
                        if (leaves.Count > 0)
                        {
                            foreach (Leave leave in leaves)
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

        private void cboApproved_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboApproved.Items.Clear();
                cboApproved.Items.Add("All");
                cboApproved.Items.Add("Yes");
                cboApproved.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApproved_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboApproved.Text.ToLower().Trim() == "yes")
                {
                    approved = true;
                }
                else if (cboApproved.Text.ToLower().Trim() == "no")
                {
                    approved = false;
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

        private bool ValidateFieldsApproval()
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
                if (datePickerLeaveDate.Checked && !Validator.DateRangeValidator(datePickerLeaveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The Leave Date cannot be greater than today");
                    datePickerLeaveDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsApproval())
                {
                    dalCommand=new DALHelper();
                    dalCommand.BeginTransaction();

                    //SqlConnection connect = new SqlConnection(connectionString);
                    //transaction = connect.BeginTransaction();
                   
                    ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && Convert.ToBoolean(grid.Rows[ctr].Cells["gridSelect"].Value))
                        {
                            leave = dal.GetByID<Leave>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (leave.ID != 0 && leave.Rejected == false && leave.Approved == false)
                            {

                                if (grid.Rows[ctr].Cells["gridReasons"].Value == null || grid.Rows[ctr].Cells["gridReasons"].Value.ToString() == string.Empty)
                                {
                                    MessageBox.Show("Please set a Approval Reason for all your selections");
                                    return;
                                }

                                employee.StaffID = grid.Rows[ctr].Cells["gridStaffID"].Value.ToString().Trim();
                                employee = dal.LazyLoadByStaffID<Employee>(employee);
                                var employees = GlobalData._context.StaffPersonalInfos.SingleOrDefault(u => u.StaffID == employee.StaffID);
                                //if (employees.ID != 0)
                                //{
                                //update employee details
                                    if (leave.LeaveType.Trim().ToUpper() == "LEAVE WITHOUT PAY")
                                    {
                                        employees.Payment = false;
                                    }
                                    employees.OnLeave = true;
                                    employees.LeaveStatus = "Approved";
                                    employees.CurrentLeaveDate = datePickerDate.Value.Date;
                                    employees.CurrentLeaveDate = leave.LeaveDate.Date;
                                    employees.CurrentLeaveStartDate = leave.StartDate.Date;
                                    employees.CurrentLeaveEndDate = leave.EndDate.Date;

                                    GlobalData._context.SubmitChanges();
                                    
                                    //Update Leave
                                    leave.Approved = true;
                                    leave.Rejected = false;
                                    leave.Status = "Approved";
                                    leave.ApprovedDate = datePickerDate.Value.Date;
                                    leave.ApprovedTime = datePickerDate.Value;
                                    leave.ApprovedUser = GlobalData.User.Name;
                                    leave.ApprovedUserStaffID = GlobalData.User.StaffID;
                                    leave.ApprovalReason = grid.Rows[ctr].Cells["gridReasons"].Value.ToString();

                                    dalCommand.ClearParameters();
                                    dalCommand.CreateParameter("@Approved", leave.Approved,DbType.Boolean);
                                    dalCommand.CreateParameter("@Rejected", leave.Rejected, DbType.Boolean);
                                    dalCommand.CreateParameter("@Status", leave.Status, DbType.String);
                                    dalCommand.CreateParameter("@ApprovedDate", leave.ApprovedDate, DbType.Date);
                                    dalCommand.CreateParameter("@ApprovedTime", leave.ApprovedTime, DbType.DateTime);
                                    dalCommand.CreateParameter("@ApprovedUser", leave.ApprovedUser, DbType.String);
                                    dalCommand.CreateParameter("@ApprovedUserStaffID", leave.ApprovedUserStaffID, DbType.String);
                                    dalCommand.CreateParameter("@ID", leave.ID, DbType.Int32);
                                    dalCommand.CreateParameter("@ApprovalReason", leave.ApprovalReason, DbType.String);
                                    dalCommand.ExecuteNonQuery("update StaffLeave set Approved=@Approved,Rejected=@Rejected,ApprovedDate=@ApprovedDate,ApprovedTime=@ApprovedTime,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID, ApprovalReason=@ApprovalReason where ID=@ID");

                                  
                                    dal.Update(leave);
                                    
                                //}
                            }
                        }
                        ctr++;
                    }
                    dalCommand.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dalCommand.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }


        private bool ValidateFieldsReject()
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
                if (datePickerLeaveDate.Checked && !Validator.DateRangeValidator(datePickerLeaveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The Leave Date cannot be greater than today");
                    datePickerLeaveDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFieldsReject())
                {
                    dal.BeginTransaction();
                    ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && Convert.ToBoolean( grid.Rows[ctr].Cells["gridSelect"].Value ))
                        {
                            leave = dal.GetByID<Leave>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (leave.ID != 0 && leave.Approved == false && leave.Rejected == false)
                            {

                                if (grid.Rows[ctr].Cells["gridReasons"].Value == null || grid.Rows[ctr].Cells["gridReasons"].Value.ToString() == string.Empty)
                                {
                                    MessageBox.Show("Please set a Rejection Reason for all your selections");
                                    return;
                                }

                                employee.StaffID = grid.Rows[ctr].Cells["gridStaffID"].Value.ToString().Trim();
                                employee = dal.LazyLoadByStaffID<Employee>(employee);
                                if (employee.ID != 0)
                                {
                                    employee.OnLeave = false;
                                    employee.LeaveStatus = "Rejected";
                                    employee.CurrentLeaveDate = null;
                                    //Correcting the Values For Only Update
                                    //employee.LeaveArrears = employee.LeaveArrears + int.Parse(leave.NumberOfDays.ToString());
                                    //employee.LeaveBalance = employee.LeaveBalance + int.Parse(leave.NumberOfDays.ToString());
                                    //employee.LeaveTaken = employee.LeaveTaken - int.Parse(leave.NumberOfDays.ToString());
                                    if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                                    {
                                        employee.CasualLeave = employee.CasualLeave - int.Parse(leave.NumberOfDays.ToString());
                                        employee.CasualLeaveDate = leave.StartDate.Date;
                                    }
                                    //Update Leave Request
                                    leave.Rejected = true;
                                    leave.Approved = false;
                                    leave.Status = "Rejected";
                                    leave.RejectedDate = datePickerDate.Value.Date;
                                    leave.RejectedTime = datePickerDate.Value;
                                    leave.RejectedUser = GlobalData.User.Name;
                                    leave.RejectedUserStaffID = GlobalData.User.StaffID;
                                    leave.ApprovalReason = grid.Rows[ctr].Cells["gridReasons"].Value.ToString();
                                    dal.Update(leave);
                                }
                            }
                        }
                        ctr++;
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
                MessageBox.Show("ERROR:Could Not Save Successfully");
            }
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to delete the Staff " + "?") == DialogResult.Yes)
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                leave.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                leave.Archived = true;
                                dal.Delete(leave);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                leave.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                leave.Archived = true;
                                dal.Delete(leave);
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
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LeaveApprovalForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnApprove.Enabled = getPermissions.CanAdd;
                    btnReject.Enabled = getPermissions.CanAdd;
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
    }
}
