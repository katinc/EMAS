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
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Utils;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveRequest : Form
    {
        private IDAL dal;
        private Leave leave;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<LeaveType> leaveTypes;
        private Employee employee;
        private LeaveDataMapper leavManip;
        private DataTable leaveTypesTable;
        private bool editMode;
        private int leaveID;
        private DALHelper dalHelper;
        private Form reportForm;
        private Company company;
        private int ctr;
        private int staffCode;
        private decimal leaveDays;
        private bool leaveTakenChanged;
        private int oldLeaveDaysTaken;

        private string connectionString;

        private DALHelper dalCommand;

        public LeaveRequest()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.leave = new Leave();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.leaveTypes = new List<LeaveType>();
                this.employee = new Employee();
                this.leavManip = new LeaveDataMapper();
                this.editMode = false;
                this.ctr = 0;
                this.staffCode = 0;
                this.leaveDays = 0;
                this.leaveID = 0;
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.company = new Company();
                this.leaveTypesTable = new DataTable();
                this.dalHelper = new DALHelper();
                startDate.Value = DateTime.Now.Date;

                leaveTakenChanged = false;
                oldLeaveDaysTaken = 0;

                dalCommand = new DALHelper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void leaveTypecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                leaveTypecmb.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "LeaveTypeView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.None
                });
                leaveTypes=dal.GetByCriteria<LeaveType>(query);
                foreach (LeaveType leaveType in leaveTypes)
                {
                    leaveTypecmb.Items.Add(leaveType.Description);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditLeave(Leave leave)
        {
            try
            {
                //var employeeStaff = GlobalData._context.StaffPersonalInfos.First(u => u.StaffID == leave.Employee.StaffID);
                Clear();
                editMode = true;
                leaveID = leave.ID;
                staffIDtxt.Text = leave.Employee.StaffID;
                staffCode = leave.Employee.ID;
                nametxt.Text = leave.StaffName;
                btnPreview.Visible = true;
                btnPreviewLetter.Visible = true;
                gendertxt.Text = leave.Employee.Gender;
                agetxt.Text = leave.Employee.Age;
                departmentTextBox.Text = leave.Employee.Department.Description;
                txtLeaveDue.Text = leave.Employee.AnnualLeave.ToString();
                txtAnnualEndDate.Text = leave.Employee.CurrentLeaveEndDate.ToString();
                txtAnnualLeaveYear.Text = leave.Employee.AnnualLeaveYear.ToString();
                txtLeaveArrears.Text = (leave.Employee.LeaveArrears + leave.NumberOfDays).ToString();
                leaveDays = leave.NumberOfDays;
                txtProposedStartDate.Text = leave.Employee.AnnualLeaveProposedStartDate.ToString();
                txtProposedEndDate.Text = leave.Employee.AnnualLeaveProposedEndDate.ToString();
                txtProposedDays.Text = leave.Employee.AnnualLeaveProposedDays.ToString();
               
                if (leave.Recommended == true && leave.Approved == true)
                {
                    savebtn.Enabled = false;
                }
                numericUpDownNumberOfDays.Value = leave.NumberOfDays;

                //txtDaysTaken.Text = (Convert.ToInt32(employeeStaff.AnnualLeave.ToString()) - Convert.ToInt32(employeeStaff.LeaveArrears.ToString())).ToString();

                leaveTypecmb_DropDown(this,EventArgs.Empty);
                leaveTypecmb.Text = leave.LeaveType;
                statusTextBox.Text = leave.Status;
                startDate.Text = leave.StartDate.ToString();
                endDate.Text = leave.EndDate.ToString();
                leaveDate.Text = leave.LeaveDate.ToString();
                groupBox1.Enabled = true;
                searchGrid.Visible = false;
                label1.Text = "Edit Leave";
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != leave.User.ID)
                {
                    savebtn.Enabled = false;
                }
                statusTextBox.Text = "Requested";
                txtDaysTaken.Text = (leave.Employee.AnnualLeave - (leave.Employee.LeaveArrears + leave.NumberOfDays)).ToString();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }
                if (leaveTypecmb.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please select a leave type");
                }

                /*if (numericUpDownNumberOfDays.Value > dal.GetByDescription<LeaveType>(leaveTypecmb.Text.Trim()).MaximumEntitlement)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Number of Days Cannot be greater than the Maximum Days");
                }*/
                //if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && numericUpDownNumberOfDays.Value > decimal.Parse(txtLeaveArrears.Text.Trim()))
                //{
                //    result = false;
                //    staffErrorProvider.SetError(txtLeaveArrears, "Please The Staff is Left with " + txtLeaveArrears.Text.Trim() + "Days");
                //}
                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && (decimal.Parse(txtLeaveDue.Text.Trim()) <= 0 || int.Parse(txtAnnualLeaveYear.Text.Trim()) != DateTime.Today.Year))
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Calculate the Annual Leave For the Staff For this Year,It is run yearly ");
                }
                if (leaveTypecmb.Text.ToUpper().Trim() == "CASUAL LEAVE" && decimal.Parse(txtLeaveArrears.Text.Trim()) > 0 && DateTime.Parse(txtAnnualEndDate.Text.Trim()) > DateTime.Today.Date)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Casual Leave cannot be Requested until the Annual Leave is Exausted");
                }
                if (startDate.Value.Date > endDate.Value.Date)
                {
                    result = false;
                    staffErrorProvider.SetError(startDate, "The start date of the leave cannot be greater than the end date");
                }
                if (numericUpDownNumberOfDays.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Number Of Days Cannot be Zero");
                }
                if (statusTextBox.Text.ToLower().Trim() == "requesting" && editMode == false && (staffIDtxt.Text != string.Empty && txtAnnualLeaveYear.Text != string.Empty && hasPendingLeaveActive(staffIDtxt.Text, int.Parse(txtAnnualLeaveYear.Text)) != "NOT_AVAILABLE"))
                {
                    result = false;
                    staffErrorProvider.SetError(statusTextBox, "Please Staff has already requested for Leave, Pending Recommendation");
                }
                else if (statusTextBox.Text.ToLower().Trim() == "recommended" && editMode == false)
                {
                    result = false;
                    staffErrorProvider.SetError(statusTextBox, "Please Staff has already requested for Leave and has been recommended, Pending Approval");
                }
                /*else if (leaveTypecmb.Text.Trim().ToUpper() != "CASUAL LEAVE" && hasAnnualLeave())
                {
                    result = false;
                    staffErrorProvider.SetError(statusTextBox, "Please Staff must finish his/her annual leave first");
                }
                else if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE" && txtDaysTaken.Text!=string.Empty && numericUpDownNumberOfDays.Value > (getAccruedAnnualLeaves(null) - int.Parse(txtDaysTaken.Text)))
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Please Staff number of leave days cannot be more than staff's accrued leave balance");
                }*/
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            //numericUpDownNumberOfDays_Leave(sender, e);
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    Assign();
                    if (editMode)
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);

                        employee.LeaveStatus = "Requested";
                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            employee.LeaveTaken = Convert.ToInt32(txtDaysTaken.Text) + int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveBalance = Convert.ToInt32(txtLeaveDue.Text) - Convert.ToInt32(txtDaysTaken.Text) - int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveArrears = Convert.ToInt32(txtLeaveDue.Text) - Convert.ToInt32(txtDaysTaken.Text) - int.Parse(leave.NumberOfDays.ToString());
                        }
                        else if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave - int.Parse(leaveDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }                        

                        var leaves = GlobalData._context.StaffLeaves.SingleOrDefault(u => u.ID == leaveID);
                        leaves.Recommended = false;
                        leaves.RecommendedDate = null;
                        leaves.RecommendedTime = null;
                        leaves.RecommendedUser = string.Empty;
                        leaves.RecommendedUserStaffID = string.Empty;
                        GlobalData._context.SubmitChanges();

                        dal.Update(employee);
                        leave.ID = leaveID;
                        dal.Update(leave);
                        Clear();
                    }
                    else
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        employee.LeaveStatus = "Requested";
                        //employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        //employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        //employee.CurrentLeaveEndDate = leave.EndDate.Date;

                        if (txtDaysTaken.Text == string.Empty)
                        {
                            txtDaysTaken.Text = "0";
                        }

                        if (employee.LeaveTaken != Convert.ToInt32(txtDaysTaken.Text))
                        {
                            leaveTakenChanged = true;
                        }
                       
                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            if (leaveTakenChanged == true)
                            {
                                employee.LeaveTaken = Convert.ToInt32(txtDaysTaken.Text) + int.Parse(leave.NumberOfDays.ToString());
                                employee.LeaveBalance = Convert.ToInt32(txtLeaveDue.Text) - Convert.ToInt32(txtDaysTaken.Text) - int.Parse(leave.NumberOfDays.ToString());
                                employee.LeaveArrears = Convert.ToInt32(txtLeaveDue.Text) - Convert.ToInt32(txtDaysTaken.Text) - int.Parse(leave.NumberOfDays.ToString());
                            }
                            else
                            {
                                employee.LeaveTaken = employee.LeaveTaken + int.Parse(leave.NumberOfDays.ToString());
                                employee.LeaveBalance = employee.LeaveBalance - int.Parse(leave.NumberOfDays.ToString());
                                employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());
                            }
                        }
                        
                        if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave + int.Parse(leave.NumberOfDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }
                        
                        dal.Update(employee);
                        dal.Save(leave);
                        Clear();
                    }
                    dal.CommitTransaction();
                    MessageBox.Show("Leave Requested Successfully");
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not saved successfully,Please See the system Administrator");
            }
        }

        private void cleartxt_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closetxt_Click(object sender, EventArgs e)
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

        #region ASSINGNMENTS
        private void Assign()
        {
            try
            {
                leave.ID = leaveID;
                leave.Employee.StaffID = staffIDtxt.Text.Trim();
                leave.Employee.ID = staffCode;
                leave.StaffName = nametxt.Text.Trim();
                leave.Status = "Requested";
                leave.LeaveType = leaveTypecmb.Text.Trim();
                leave.StartDate = startDate.Value;
                leave.EndDate = endDate.Value;
                leave.LeaveDate = leaveDate.Value;
                leave.NumberOfDays = numericUpDownNumberOfDays.Value;
                leave.User.ID = GlobalData.User.ID;
                leave.Reason = txtReason.Text.Trim();
                leave.Institution = txtInstitution.Text.Trim();
                leave.Programme = txtProgramme.Text.Trim();
                leave.Duration = txtDuration.Text.Trim();
                leave.LeaveYear =(txtAnnualLeaveYear.Text!=string.Empty)?int.Parse( txtAnnualLeaveYear.Text):0;
               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                leaveTypecmb.Text = string.Empty;
                startDate.ResetText();
                startDate.Checked=false;
                endDate.ResetText();
                endDate.Checked=false;
                leaveDate.ResetText();
                leaveDate.Value = DateTime.Today.Date;
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveArrears.Clear();
                txtProposedDays.Clear();
                txtProposedEndDate.Clear();
                txtProposedStartDate.Clear();
                leaveID = 0;
                btnPreview.Visible = false;
                label1.Text = "New Leave";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                statusTextBox.Clear();
                departmentTextBox.Clear();
                staffErrorProvider.Clear();
                leaveTypecmb.Items.Clear();
                leaveTypecmb.Text = string.Empty;
                numericUpDownNumberOfDays.Value = 0;
                txtInstitution.Clear();
                txtProgramme.Clear();
                txtDuration.Clear();
                txtReason.Clear();
                lblInstitution.Visible = false;
                txtInstitution.Visible = false;
                lblProgramme.Visible = false;
                txtProgramme.Visible = false;
                lblDuration.Visible = false;
                txtDuration.Visible = false;
                txtDaysTaken.Visible = false;
                txtAccruedDays.Visible = false;
                lblAccruedDays.Visible = false;
                lblDaysTaken.Visible = false;
                txtDaysTaken.Text = string.Empty;
                txtAccruedDays.Text = string.Empty;
                txtAnnualEndDate.ResetText();
                oldLeaveDaysTaken = 0;

                btnPreviewLetter.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Staff Operations
        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            leaveTypecmb.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            if (employee.LeaveStatus.Trim() != string.Empty && employee.LeaveStatus.ToLower().Trim() != "rejected")
                            {
                              
                                    statusTextBox.Text = employee.LeaveStatus;
                            }
                            else
                            {
                                statusTextBox.Text = "Not Requested";
                            }

                            txtLeaveDue.Text = employee.AnnualLeave.ToString();
                            txtAnnualEndDate.Text = employee.CurrentLeaveEndDate.ToString();
                            txtProposedStartDate.Text = employee.AnnualLeaveProposedStartDate.ToString();
                            txtProposedEndDate.Text = employee.AnnualLeaveProposedEndDate.ToString();
                            txtProposedDays.Text = employee.AnnualLeaveProposedDays.ToString();
                            txtAnnualLeaveYear.Text = employee.AnnualLeaveYear.ToString();

                            txtAccruedLeaveBalance.Text = employee.LeaveBalance.ToString();
                            txtDaysTaken.Text = employee.LeaveTaken.ToString();
                            numericUpDownNumberOfDays.Value = 0;
                            //txtDaysTaken.Text = getAnnualLeavesTaken(employee.StaffID, employee.AnnualLeaveYear).ToString();
                            oldLeaveDaysTaken = Convert.ToInt32(txtDaysTaken.Text);
                            
                            if (editMode == false)
                            {
                                txtLeaveArrears.Text = employee.LeaveArrears.ToString();
                                statusTextBox.Text = "Requesting";
                                
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

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    Clear();
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
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });


                        employees = dal.LazyLoadCriteria<Employee>(query);
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        #endregion

        private void Leave_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox1.Enabled = true;
                staffIDtxt.Select();
                startDate.Checked = true;
                startDate.Value = DateTime.Today.Date;
                endDate.Checked = true;
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()));
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                connectionString = ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;

                lblAccruedDays.Visible = false;
                txtAccruedDays.Visible = false;

                lblDaysTaken.Visible = false;
                txtDaysTaken.Visible = false;

                btnBulkLeave.Visible = true;

            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveView form = new LeaveView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    reportForm = new LeaveRequestApplicationForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm.Show();
                }
                else
                {
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        public void getDays()
        {
            try
            {
                decimal result = decimal.Parse((endDate.Value.Subtract(startDate.Value).Days).ToString());
                numericUpDownNumberOfDays.Value = (result == 0) ? 1 : (decimal.Ceiling(result) > 0 ? decimal.Ceiling(result) : -1 * decimal.Ceiling(result));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        DateTime AddBusinessDays(int noofDays, DateTime dtCurrent)
        {
            DateTime tempdt = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
            try
            {
                var holidays = new List<DateTime>() { new DateTime(2014, 12, 25), new DateTime(2014, 10, 28) };

                // if starting day is non working day adjust to next working day
                tempdt = ExcludeNotWorkingDay(tempdt, holidays);

                // if starting day is non working day adjust to next working day then minus 1 day in noofadding days
                if (tempdt.Date > dtCurrent.Date && !(noofDays == 0))
                    noofDays = noofDays - 1;

                while (noofDays > 0)
                {
                    tempdt = tempdt.AddDays(1);
                    // if day is non working day adjust to next working day
                    tempdt = ExcludeNotWorkingDay(tempdt, holidays);
                    noofDays = noofDays - 1;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return tempdt;
        }

        DateTime ExcludeNotWorkingDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            while (!IsWorkDay(dtCurrent, holidays))
            {
                dtCurrent = dtCurrent.AddDays(1);
            }
            return dtCurrent;
        }

        bool IsWorkDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            if ((dtCurrent.DayOfWeek == DayOfWeek.Saturday || dtCurrent.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(dtCurrent)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void numericUpDownNumberOfDays_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                DateTime[] r = DateUtil.generateWorkingDaysRange(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()));
                endDate.Value = r[r.Length - 1];
               // endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString())-1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
          
                try
                {
                    DateTime[] r = DateUtil.generateWorkingDaysRange(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()));
                    if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                      r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if(r.Count()>0)
                    endDate.Value = r[r.Length - 1];

                    //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }

               if(leaveTypecmb.Text.Trim().ToUpper()=="ANNUAL LEAVE")
                txtAccruedDays.Text = getAccruedAnnualLeaves(null).ToString();
            
          
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    employee.StaffID = staffIDtxt.Text.Trim();
                    employee = dal.ShowImageByStaffID<Employee>(employee);
                    if (employee.ID != 0)
                    {
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Staff");
                        }
                    }
                    else
                    {
                        MessageBox.Show("StaffID Not Found");
                    }

                }
                else
                {
                    MessageBox.Show("StaffID is Empty,Please Enter the StaffID");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveTypecmb_SelectionChangeCommitted(object sender, EventArgs e)
        {
           
        }

        private void btnPreviewLetter_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    //reportForm = new LeaveLetterApplicationForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm = new AGALeaveLetterForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm.Show();
                }
                else
                {
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }

                if (leaveTypecmb.Text.ToUpper().Trim() != "ANNUAL LEAVE" && hasAnnualLeave())
                {
                    MessageBox.Show(this, "Staff Must finish his/her annual leave first ");

                    leaveTypecmb.SelectedIndex = -1;
                }

                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && txtAnnualLeaveYear.Text != string.Empty)
                {

                    txtAccruedDays.Text = getAccruedAnnualLeaves(null).ToString();
                    if (label1.Text == "New Leave")
                    {
                        numericUpDownNumberOfDays.Value = int.Parse(txtAccruedDays.Text);
                        statusTextBox.Text = "Requesting";
                    }
                }

                //string sql = string.Empty;

                //if (leaveTypecmb.Text.ToUpper().Trim() != "ANNUAL LEAVE" && hasAnnualLeave()) {
                //    sql = "Select * from LeaveLetterSignature order by StaffID";
                //}

                //var dataTable = new DataTable("LeaveView");
                //dataTable = dalHelper.ExecuteReader(sql);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        

        private void leaveTypecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (editMode == false || leaveTypecmb.Text.Trim().ToUpper() != "ANNUAL LEAVE")
                //    numericUpDownNumberOfDays.Value = leaveTypes[leaveTypecmb.SelectedIndex].MaximumEntitlement;

                //if (leaveTypecmb.Text.Trim() != string.Empty)
                //{
                    
                //    DateTime[] r = DateUtil.generateWorkingDaysRange(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()));
                //    endDate.Value = r[r.Length - 1];

                //}

                if (leaveTypecmb.Text.ToUpper().Trim() == "STUDY LEAVE")
                {
                    lblInstitution.Visible = true;
                    txtInstitution.Visible = true;
                    lblProgramme.Visible = true;
                    txtProgramme.Visible = true;
                    lblDuration.Visible = true;
                    txtDuration.Visible = true;
                }
                else
                {
                    lblInstitution.Visible = false;
                    txtInstitution.Visible = false;
                    lblProgramme.Visible = false;
                    txtProgramme.Visible = false;
                    lblDuration.Visible = false;
                    txtDuration.Visible = false;
                }


                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    lblAccruedDays.Visible = true;
                    txtAccruedDays.Visible = true;

                    lblDaysTaken.Visible = true;
                    txtDaysTaken.Visible = true;

                    txtDaysTaken.Enabled = true;


                    txtAccruedDays.Text = getAccruedAnnualLeaves(null).ToString();

                    //txtDaysTaken.Text =(txtAnnualLeaveYear.Text!=string.Empty)? getAnnualLeavesTaken(staffIDtxt.Text,int.Parse(txtAnnualLeaveYear.Text)).ToString():"0";
                    //txtDaysTaken.Text = (Convert.ToInt32(txtLeaveDue.Text) - Convert.ToInt32(employee.LeaveArrears.ToString())).ToString();

                    if (txtAccruedDays.Text != string.Empty && txtDaysTaken.Text != string.Empty)
                    {

                        double noOfDays = 0.0;

                        noOfDays = (Convert.ToDouble(txtAccruedDays.Text) + Convert.ToDouble(txtLeaveArrears)) - Convert.ToDouble(txtDaysTaken.Text);
                        numericUpDownNumberOfDays.Value = Math.Floor(Convert.ToDecimal(noOfDays));
                        //statusTextBox.Text = "Requesting";
                    }
                    //else
                       // numericUpDownNumberOfDays.Value = leave.NumberOfDays;


                  
                }
                else
                {
                    txtAccruedDays.Clear();
                    lblAccruedDays.Visible = false;
                    txtAccruedDays.Visible = false;

                    txtDaysTaken.Clear();
                    lblDaysTaken.Visible = false;
                    txtDaysTaken.Visible = false;
                }

                if (leaveTypecmb.Text.Trim().ToUpper() == "MATERNITY LEAVE" && gendertxt.Text.Trim().ToUpper()=="MALE")
                {
                    MessageBox.Show("Please you cannot select Maternity Leave for a male!");
                    leaveTypecmb.SelectedIndex = -1;
                    leaveTypecmb.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        
        decimal getAccruedAnnualLeaves(Nullable<DateTime>  currDate)
        {
            decimal accruedLeaves = 0;
            try
            {
                if (currDate == null)
                   currDate= startDate.Value.Date;
                if (txtAnnualLeaveYear.Text != string.Empty && int.Parse(txtAnnualLeaveYear.Text)==startDate.Value.Year)
                {
                    DateTime startOfYear = new DateTime(int.Parse(txtAnnualLeaveYear.Text), 1, 1);
                    //DateTime currDate = GlobalData.ServerDate.Date;
                    dalHelper=new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("startOfYear", startOfYear.Date,DbType.Date);
                    dalHelper.CreateParameter("currDate", currDate, DbType.Date);

                   var monthDiff = dalHelper.ExecuteScalar("select DATEDIFF(MONTH,@startOfYear,@currDate) as monthDiff");

                 
                    var noMonths = 0;
                    if (monthDiff != null)
                    {
                        noMonths = int.Parse(monthDiff.ToString());
                    }


                    dalHelper.ClearParameters();

                    int totalAnnualLeaves = (txtLeaveDue.Text != string.Empty) ? int.Parse(txtLeaveDue.Text) : 0;
                    int LeaveArrears =txtLeaveArrears.Text!=string.Empty?int.Parse(txtLeaveArrears.Text):0;
                   

                    double leavePoint = (float)totalAnnualLeaves / 12.0;

                   accruedLeaves=decimal.Parse((leavePoint * noMonths).ToString());
                   accruedLeaves =Math.Round( decimal.Parse((accruedLeaves).ToString()),2);
                  
                }
            }
            catch(Exception ex){
                Logger.LogError(ex);
               
            }
            return accruedLeaves;
        }
        bool hasAnnualLeave()
        {
            try
            {
                
                    SqlCommand cmdSelect = new SqlCommand("SELECT count(*) as countTaken FROM StaffLeaveView where Approved='true' or Rejected='false' and LeaveType='Annual Leave' and StaffID=@StaffID and LeaveArrears>0  and AnnualLeaveYear=@AnnualLeaveYear", new SqlConnection(connectionString));
                    cmdSelect.Parameters.AddWithValue("StaffID", staffIDtxt.Text.Trim());
                    cmdSelect.Parameters.AddWithValue("AnnualLeaveYear",txtAnnualLeaveYear.Text!=string.Empty? int.Parse(txtAnnualLeaveYear.Text):-1);

                    if (cmdSelect.Connection.State == ConnectionState.Closed)
                        cmdSelect.Connection.Open();

                    var countAnnualLeaveTaken = cmdSelect.ExecuteScalar();
                    if (countAnnualLeaveTaken != null && int.Parse(countAnnualLeaveTaken.ToString()) > 0)
                        return true;
                    else
                    {
                        cmdSelect = new SqlCommand("select top 1 ac.NumberOfDays from AnnualLeaveCalculationView ac where ac.StaffID=@StaffID and ac.Year=@AnnualLeaveYear order by id", new SqlConnection(connectionString));
                        cmdSelect.Parameters.AddWithValue("StaffID", staffIDtxt.Text.Trim());
                        cmdSelect.Parameters.AddWithValue("AnnualLeaveYear", txtAnnualLeaveYear.Text != string.Empty ? int.Parse(txtAnnualLeaveYear.Text) : -1);
                        if (cmdSelect.Connection.State == ConnectionState.Closed)
                            cmdSelect.Connection.Open();

                         countAnnualLeaveTaken = cmdSelect.ExecuteScalar();
                        if (countAnnualLeaveTaken != null && int.Parse(countAnnualLeaveTaken.ToString()) > 0)
                            return true;
                    }
                
            }
            catch (Exception ex) {
                Logger.LogError(ex);
            }
            return false;
        }
        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    DateTime[] r = DateUtil.getWorkingDaysList(startDate.Value, endDate.Value);
            //    numericUpDownNumberOfDays.Value = r.Length;
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //}
            
        }

        private void numericUpDownNumberOfDays_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    int daysLeft = (int)(Convert.ToDouble(txtAccruedDays.Text) + Convert.ToDouble(txtLeaveArrears.Text) - Convert.ToDouble(txtDaysTaken.Text));
                    if (numericUpDownNumberOfDays.Value > daysLeft )
                    {
                        //numericUpDownNumberOfDays.Value = Convert.ToDecimal(txtLeaveArrears.Text);
                        numericUpDownNumberOfDays.Value = daysLeft;
                        MessageBox.Show("Leave days cannot be more than arrears + accrued days");
                    }
                    else if (daysLeft < 0)
                    {
                        numericUpDownNumberOfDays.Value = 0;
                    }
                    else
                    {
                        DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);
                        endDate.Value = r[r.Length - 1];
                    }
                }
                else if (leaveTypecmb.Text.Trim().ToUpper() == "")
                {
                    
                }else
                {
                    DateTime[] r = DateUtil.generateWorkingDaysRange(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()));
                    endDate.Value = r[r.Length - 1];
                }
                // endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString())-1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveDate_ValueChanged(object sender, EventArgs e)
        {
          txtAccruedDays.Text=  getAccruedAnnualLeaves(null).ToString();
        }

        private void txtAccruedDays_TextChanged(object sender, EventArgs e)
        {
            if (editMode == false && txtAccruedDays.Text!=string.Empty)
            {
                //numericUpDownNumberOfDays.Value = (int)decimal.Parse(txtAccruedDays.Text);
            }
           
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            
        }

        int getAnnualLeavesTaken(string staffID,int Year)
        {
            try
            {
                dalCommand = new DALHelper();

                dalCommand.ClearParameters();
                dalCommand.CreateParameter("@StaffID", staffID, DbType.String);
                dalCommand.CreateParameter("@LeaveYear", Year, DbType.Int32);

                var leaveTaken = dalCommand.ExecuteScalar("select sum(NumberOfDays) as leaveTaken from StaffLeave where staffID=@staffID and leaveYear=@leaveYear");

                if (leaveTaken != null && Information.IsNumeric(leaveTaken))
                    return int.Parse(leaveTaken.ToString());
               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return 0;
        }

        string hasPendingLeaveActive(string staffID, int Year)
        {
            try
            {
                dalCommand = new DALHelper();

                dalCommand.ClearParameters();
                dalCommand.CreateParameter("@StaffID", staffID, DbType.String);
                dalCommand.CreateParameter("@LeaveYear", Year, DbType.Int32);

                var leaveStatus = dalCommand.ExecuteScalar(" select top 1 case when recommended='false' then 'UNRECOMMENDED' when approved='false' then 'UNAPPROVED' else 'NOT_AVAILABLE' end AS LEAVE_ACTION_STATUS  from StaffLeave where staffID=@staffID and leaveYear=@leaveYear and  (Approved='false' or recommended='false') and Archived = 'false' order by LeaveDate desc");

                if (leaveStatus != null)
                    return leaveStatus.ToString();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return "NOT_AVAILABLE";
        }

        private void txtDaysTaken_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (oldLeaveDaysTaken.ToString() != txtDaysTaken.Text)
            //    {
            //        //DialogResult result = MessageBox.Show("Are you sure you want to change the number of leave days already taken?",
            //        //"Change Leave Already Taken", MessageBoxButtons.YesNo);

            //        //if (result == System.Windows.Forms.DialogResult.Yes)
            //        //{
            //            leaveTakenChanged = true;
            //            oldLeaveDaysTaken = Convert.ToInt32(txtDaysTaken.Text);
            //        //}
            //        //else
            //        //{
            //        //    txtDaysTaken.Text = oldLeaveDaysTaken.ToString();
            //        //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //    throw;
            //}
        }

        private void txtDaysTaken_Click(object sender, EventArgs e)
        {
            
        }

        private void txtDaysTaken_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var annualLeave = Convert.ToInt32(txtLeaveDue.Text);
                var daysLeft = annualLeave - Convert.ToInt32(txtDaysTaken.Text);
                

                if (daysLeft < 0)
                {
                    numericUpDownNumberOfDays.Value = 0;
                    staffErrorProvider.SetError(txtDaysTaken, "Days taken cannot be more than annual leave days");
                    txtDaysTaken.Focus();
                    savebtn.Enabled = false;
                    
                }
                else 
                {
                    if (editMode == false)
                    {
                        numericUpDownNumberOfDays.Value = daysLeft;
                    }
                    staffErrorProvider.Clear();
                    savebtn.Enabled = true;
                }


                //if (Convert.ToInt32(txtDaysTaken.Text) > Convert.ToInt32(txtLeaveArrears.Text))
                //{
                //    numericUpDownNumberOfDays.Value = 0;
                //    staffErrorProvider.SetError(txtDaysTaken, "Days taken cannot be more than leave areas");
                //    txtDaysTaken.Focus();
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void numericUpDownNumberOfDays_Leave(object sender, EventArgs e)
        {
            try
            {
                //do not remove this !!! WARNING lol
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    //reportForm = new LeaveLetterApplicationForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm = new AGALeaveLetterForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm.Show();
                }
                else
                {
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }

                if (leaveTypecmb.Text.ToUpper().Trim() != "ANNUAL LEAVE" && hasAnnualLeave())
                {
                    MessageBox.Show(this, "Staff Must finish his/her annual leave first ");

                    leaveTypecmb.SelectedIndex = -1;
                }

                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && txtAnnualLeaveYear.Text != string.Empty)
                {

                    txtAccruedDays.Text = getAccruedAnnualLeaves(null).ToString();
                    if (label1.Text == "New Leave")
                    {
                        numericUpDownNumberOfDays.Value = int.Parse(txtAccruedDays.Text);
                        statusTextBox.Text = "Requesting";
                    }
                }

                //string sql = string.Empty;

                //if (leaveTypecmb.Text.ToUpper().Trim() != "ANNUAL LEAVE" && hasAnnualLeave()) {
                //    sql = "Select * from LeaveLetterSignature order by StaffID";
                //}

                //var dataTable = new DataTable("LeaveView");
                //dataTable = dalHelper.ExecuteReader(sql);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        private void btnBulkLeave_Click(object sender, EventArgs e)
        {
            try
            {
                LeavesBulkEntry form = new LeavesBulkEntry();
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
    }
}
