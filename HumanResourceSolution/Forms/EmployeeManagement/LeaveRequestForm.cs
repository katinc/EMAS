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

                leaveTypecmb_DropDown(this,EventArgs.Empty);
                leaveTypecmb.Text = leave.LeaveType;
                numericUpDownNumberOfDays.Value = leave.NumberOfDays;
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

                if (numericUpDownNumberOfDays.Value > dal.GetByDescription<LeaveType>(leaveTypecmb.Text.Trim()).MaximumEntitlement)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Number of Days Cannot be greater than the Maximum Days");
                }
                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && numericUpDownNumberOfDays.Value > decimal.Parse(txtLeaveArrears.Text.Trim()))
                {
                    result = false;
                    staffErrorProvider.SetError(txtLeaveArrears, "Please The Staff is Left with " + txtLeaveArrears.Text.Trim() + "Days");
                }
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
                if (statusTextBox.Text.ToLower().Trim() == "requested" && editMode == false)
                {
                    result = false;
                    staffErrorProvider.SetError(statusTextBox, "Please Staff has already requested for Leave, Pending Recommendation");
                }
                else if (statusTextBox.Text.ToLower().Trim() == "recommended" && editMode == false)
                {
                    result = false;
                    staffErrorProvider.SetError(statusTextBox, "Please Staff has already requested for Leave and has been recommended, Pending Approval");
                }
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
                        employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        employee.CurrentLeaveEndDate = leave.EndDate.Date;
                        //Correcting the Values For Only Update
                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            employee.LeaveArrears = employee.LeaveArrears + int.Parse(leaveDays.ToString());
                            employee.LeaveBalance = employee.LeaveBalance + int.Parse(leaveDays.ToString());
                            employee.LeaveTaken = employee.LeaveTaken - int.Parse(leaveDays.ToString());
                        }
                        else if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave - int.Parse(leaveDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }

                        //Saving the Current Entry
                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            employee.LeaveTaken = employee.LeaveTaken + int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveBalance = employee.LeaveBalance - int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());
                        }
                        else if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave + int.Parse(leave.NumberOfDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }
                        
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
                        employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        employee.CurrentLeaveEndDate = leave.EndDate.Date;
                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            employee.LeaveTaken = employee.LeaveTaken + int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveBalance = employee.LeaveBalance - int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());
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
                            if (editMode == false)
                            {
                                txtLeaveArrears.Text = employee.LeaveArrears.ToString();
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
                groupBox1.Enabled = false;
                staffIDtxt.Select();
                startDate.Checked = true;
                startDate.Value = DateTime.Today.Date;
                endDate.Checked = true;
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()));
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

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
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString())-1);
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
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
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
            try
            {
                if(leaveTypecmb.Text.Trim() != string.Empty)
                {
                    numericUpDownNumberOfDays.Value=leaveTypes[leaveTypecmb.SelectedIndex].MaximumEntitlement;
                }

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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
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
                    reportForm = new LeaveLetterApplicationForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm.Show();
                }
                else
                {
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }
    }
}
