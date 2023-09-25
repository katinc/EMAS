﻿using System;
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
using eMAS.ServiceReference;
using eMAS;
using System.Collections;
using Newtonsoft.Json;

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


        private DALHelper dalCommand;

        private HRServcice _hrservice = new HRServcice();
        private DataReference.hrContextDataContext hrcontext = new DataReference.hrContextDataContext();

        List<Control> controls;
        List<controlObject> OldValues;

        public Permissions permissions;

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
                //startDate.Value = DateTime.Now.Date;

                dalCommand = new DALHelper();
                leaveBalanceMapper = new LeaveBalanceDataMapper();

                controls = new List<Control>();
                OldValues = new List<controlObject>();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void leaveTypecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                leaveTypecmb.DataSource = null;
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "LeaveTypeView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.None
                });
                leaveTypes = dal.GetByCriteria<LeaveType>(query);

                leaveTypecmb.DataSource = leaveTypes;
                leaveTypecmb.DisplayMember = "Description";
                leaveTypecmb.ValueMember = "ID";

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        Leave LeaveEditing;
        public void EditLeave(Leave leave)
        {
            LeaveEditing = leave;
            try
            {
                Clear();
                staffIDtxt.ReadOnly = true;
                nametxt.ReadOnly = true;
                employee = dal.GetByID<Employee>(leave.Employee.StaffID);
                editMode = true;
                leaveID = leave.ID;
                staffIDtxt.Text = leave.Employee.StaffID;
                staffCode = leave.Employee.ID;
                nametxt.Text = leave.StaffName;
                btnPreview.Visible = false;
                btnPreviewLetter.Visible = true;
                gendertxt.Text = leave.Employee.Gender;
                agetxt.Text = leave.Employee.Age;
                departmentTextBox.Text = leave.Employee.Department.Description;
                txtLeaveDue.Text = leave.Employee.AnnualLeave.ToString();
                txtAnnualEndDate.Text = leave.Employee.CurrentLeaveEndDate.ToString();
                txtAnnualLeaveYear.Text = leave.Employee.AnnualLeaveYear.ToString();
                txtLeaveBalance.Text = leave.Employee.LeaveBalance.ToString();
                txtPrevLeaveArrears.Text = leave.Employee.LeaveArrears.ToString();
                leaveDays = leave.NumberOfDays;
                txtProposedStartDate.Text = leave.Employee.AnnualLeaveProposedStartDate.ToString();
                txtProposedEndDate.Text = leave.Employee.AnnualLeaveProposedEndDate.ToString();
                txtProposedDays.Text = leave.Employee.AnnualLeaveProposedDays.ToString();

                txtReason.Text = leave.Reason.Trim();

                if (leave.Recommended == true && leave.Approved == true)
                {
                    savebtn.Enabled = false;
                }

                leaveTypecmb_DropDown(this, EventArgs.Empty);
                leaveTypecmb.Text = leave.LeaveType;

                leaveTypecmb_SelectedIndexChanged(this, EventArgs.Empty);
                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    lblAccruedDays.Visible = true;
                    txtAccruedDays.Visible = true;

                    lblDaysTaken.Visible = true;
                    txtDaysTaken.Visible = true;
                    txtDaysTaken.Text = ((int)leaveBalanceMapper.getLeaveTaken(leave.LeaveYear, DateTime.Now.Month, leave.Employee.ID)).ToString();
                }
                else
                {
                    lblAccruedDays.Visible = false;
                    txtAccruedDays.Visible = false;

                    lblDaysTaken.Visible = false;
                    txtDaysTaken.Visible = false;
                }

                numericUpDownNumberOfDays.Value = leave.NumberOfDays;
                statusTextBox.Text = leave.Status;
                startDate.Text = leave.StartDate.ToString();
                endDate.Text = leave.EndDate.ToString();
                leaveDate.Text = leave.LeaveDate.ToString();
                groupBox1.Enabled = true;
                searchGrid.Visible = false;
                label1.Text = "Edit Leave";

                txtInstitution.Text = leave.Institution;
                txtProgramme.Text = leave.Programme;
                txtDuration.Text = leave.Duration;
                cboPayment.Text = leave.Funding;
                cboStudyLeaveType.Text = leave.ProgramType;

                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != leave.User.ID)
                {
                    savebtn.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            //GlobalData.FillControls(controls, this);
            OldValues = GlobalData.CloneControls(controls, this);
        }


        void loadPaymentItems()
        {
            try
            {
                cboPayment.Items.Clear();
                cboPayment.Items.Add("Full Payment");
                cboPayment.Items.Add("Part Payment");
                cboPayment.Items.Add("No Funding");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
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

                /* if (numericUpDownNumberOfDays.Value > dal.GetByDescription<LeaveType>(leaveTypecmb.Text.Trim()).MaximumEntitlement)
                 {
                     result = false;
                     staffErrorProvider.SetError(leaveTypecmb, "Please Number of Days Cannot be greater than the Maximum Days");
                 }*/
                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && editMode == false && numericUpDownNumberOfDays.Value > decimal.Parse(txtLeaveBalance.Text.Trim()))
                {
                    result = false;
                    staffErrorProvider.SetError(txtLeaveBalance, "Please The Staff is Left with " + txtLeaveBalance.Text.Trim() + "Days");
                }
                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && (decimal.Parse(txtLeaveDue.Text.Trim()) <= 0 || int.Parse(txtAnnualLeaveYear.Text.Trim()) != DateTime.Today.Year))
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Calculate the Annual Leave For the Staff For this Year,It is run yearly ");
                }
                /*if (leaveTypecmb.Text.ToUpper().Trim() == "CASUAL LEAVE" && decimal.Parse(txtLeaveBalance.Text.Trim()) > 0 && DateTime.Parse(txtAnnualEndDate.Text.Trim()) > DateTime.Today.Date)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Casual Leave cannot be Requested until the Annual Leave is Exausted");
                }*/
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
                }*/
                else if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE" && txtDaysTaken.Text != string.Empty && numericUpDownNumberOfDays.Value > Convert.ToInt32(txtLeaveBalance.Text))
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Please Staff number of leave days cannot be more than staff's accrued leave balance");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        LeaveBalanceDataMapper leaveBalanceMapper;
        private Employee selectedEmployee;
        private void savebtn_Click(object sender, EventArgs e)
        {
             LeaveBalance leaveBalance = new LeaveBalance();
            try
            {
                if (company.Initials != "HTH" ? ValidateFields() : true)
                {
                    dal.BeginTransaction();
                    Assign();
                    if (editMode)
                    {
                        if (!permissions.CanEdit)
                        {
                            MessageBox.Show("Sorry you do not have permission to edit this data.");
                        }

                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);

                        employee.LeaveStatus = "Requested";
                        employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        employee.CurrentLeaveEndDate = leave.EndDate.Date;

                        if (leave.LeaveType.Trim().ToUpper() == "ANNUAL LEAVE")
                        {
                            employee.LeaveTaken = (int)leaveBalanceMapper.getLeaveTaken(txtAnnualLeaveYear.Text != "0" ? Convert.ToInt32(txtAnnualLeaveYear.Text) : employee.AnnualLeaveYear, DateTime.Now.Month, employee.ID) + int.Parse(leave.NumberOfDays.ToString());
                            employee.LeaveBalance = (int)(leaveBalanceMapper.getYearAnnualLeave(Convert.ToInt32(txtAnnualLeaveYear.Text), employee.ID) + leaveBalanceMapper.getMyLeaveArrears(Convert.ToInt32(txtAnnualLeaveYear.Text), leave.StartDate.Year, employee.ID) - leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), leave.StartDate.Month, employee.ID)) - int.Parse(leave.NumberOfDays.ToString());
                            //employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());
                            //employee.AccruedLeaveBalance=txtAccruedDays.Text!=string.Empty? -Convert.ToInt32(txtAccruedDays.Text):

                        }
                        else if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave + int.Parse(leave.NumberOfDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }

                        dal.Update(employee);
                        leave.ID = leaveID;
                        //dal.Update(leave);
                        //Clear();

                        var result = GlobalData.ProcessEdit(OldValues, controls, this, leaveID, staffIDtxt.Text);
                        if (!result)
                        {
                            return;
                        }
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
                            // employee.LeaveArrears = employee.LeaveArrears - int.Parse(leave.NumberOfDays.ToString());
                        }

                        if (leave.LeaveType.Trim().ToUpper() == "CASUAL LEAVE")
                        {
                            employee.CasualLeave = employee.CasualLeave + int.Parse(leave.NumberOfDays.ToString());
                            employee.CasualLeaveDate = leave.LeaveDate.Date;
                        }

                        //if (leave.LeaveType.Trim().ToUpper() == "LEAVE WITHOUT PAY")
                        //{
                        //    employee.Payment = false;
                        //}

                        dal.Update(employee);
                        dal.Save(leave);
                        
                    }
                    dal.CommitTransaction();
                    Clear();
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
            catch (Exception ex)
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
                leave.LeaveYear = (txtAnnualLeaveYear.Text != string.Empty) ? int.Parse(txtAnnualLeaveYear.Text) : 0;
                leave.Funding = cboPayment.Text;
                leave.ProgramType = cboStudyLeaveType.Text;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void clearPersonalInfo()
        {
            try
            {
                editMode = false;
                staffIDtxt.Text = string.Empty;
                nametxt.Text = string.Empty;
                gendertxt.Text = string.Empty;
                agetxt.Text = string.Empty;
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Text = string.Empty;
                txtLeaveBalance.Text = string.Empty;
                txtProposedDays.Text = string.Empty;
                txtProposedEndDate.Text = string.Empty;
                txtProposedStartDate.Text = string.Empty;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                clearPersonalInfo();
                staffIDtxt.ReadOnly = false;
                nametxt.ReadOnly = false;
                startDate.ResetText();
                startDate.Checked = false;
                endDate.ResetText();
                endDate.Checked = false;
                //leaveDate.ResetText();
                leaveDate.Value = DateTime.Today.Date;
                leaveID = 0;
                btnPreview.Visible = false;
                label1.Text = "New Leave";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                statusTextBox.Clear();
                departmentTextBox.Clear();
                staffErrorProvider.Clear();
                leaveTypecmb.DataSource = null;
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
                txtAnnualEndDate.Clear();
                txtPrevLeaveArrears.Clear();
                txtAccruedDays.Text = "0";
                txtYTDAccruedLeave.Text = "0";
                txtDaysTaken.Text = "0";
                this.employee = null;

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
                    clearPersonalInfo();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            this.employee = employee;
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


                            //txtLeaveDue.Text = ((int)leaveBalanceMapper.getYearAnnualLeave(employee.AnnualLeaveYear, employee.ID)).ToString();
                            txtLeaveDue.Text = GlobalData._context.StaffPersonalInfos.FirstOrDefault(u => u.StaffID == staffIDtxt.Text).AnnualLeave.ToString();
                            txtAnnualEndDate.Text = employee.CurrentLeaveEndDate.ToString();
                            txtProposedStartDate.Text = employee.AnnualLeaveProposedStartDate.ToString();
                            txtProposedEndDate.Text = employee.AnnualLeaveProposedEndDate.ToString();
                            txtProposedDays.Text = employee.AnnualLeaveProposedDays.ToString();
                            txtAnnualLeaveYear.Text = employee.AnnualLeaveYear.ToString();

                            //txtLeaveBalance.Text = employee.LeaveBalance.ToString();
                            //lblLeaveBalance.Text = "Leave Balance (" + employee.AnnualLeaveYear + ")";
                            txtDaysTaken.Text = ((int)leaveBalanceMapper.getLeaveTaken(employee.AnnualLeaveYear, DateTime.Now.Month, employee.ID)).ToString();
                            txtPrevLeaveArrears.Text = ((int)leaveBalanceMapper.getMyLeaveArrears(employee.AnnualLeaveYear, DateTime.Now.Month, employee.ID)).ToString();

                            selectedEmployee = employee;

                            if (editMode == false)
                            {
                                txtLeaveBalance.Text = ((int)(leaveBalanceMapper.getYearAnnualLeave(employee.AnnualLeaveYear, employee.ID) + leaveBalanceMapper.getMyLeaveArrears(employee.AnnualLeaveYear, 12, employee.ID) - leaveBalanceMapper.getLeaveTaken(employee.AnnualLeaveYear, DateTime.Now.Month, employee.ID))).ToString();

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
                    clearPersonalInfo();
                    //Clear();

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
            //leaveBalanceMapper = new LeaveBalanceDataMapper();
            try
            {
                startDate.Value = DateTime.Today;
                endDate.Value = DateTime.Today;
                leaveDate.Value = DateTime.Today;

                this.Text = GlobalData.Caption;
                groupBox1.Enabled = false;
                groupleaveCashment.Visible = false;
                staffIDtxt.Select();

                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                lblAccruedDays.Visible = false;
                txtAccruedDays.Visible = false;

                lblDaysTaken.Visible = false;
                txtDaysTaken.Visible = false;

                lblFunding.Visible = false;
                lblProgramType.Visible = false;
                cboStudyLeaveType.Visible = false;
                cboPayment.Visible = false;

                var studyLeaveTypes = GlobalData._context.StudyLeaveTypes.Where(u => u.Archived == false).ToList();

                cboStudyLeaveType.Items.Clear();

                cboStudyLeaveType.DataSource = studyLeaveTypes;
                cboStudyLeaveType.DisplayMember = "Description";
                cboStudyLeaveType.ValueMember = "ID";

                loadPaymentItems();

                permissions = GlobalData.CheckPermissions(3);
                if (permissions != null)
                {
                    savebtn.Enabled = permissions.CanAdd;
                    btnView.Enabled = permissions.CanEdit;
                    btnPreviewLetter.Enabled = permissions.CanPrint;
                }
            }
            catch (Exception ex)
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
                form.removeButton.Enabled = permissions.CanDelete;
                form.Show();
            }
            catch (Exception ex)
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
            catch (Exception ex)
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

                //if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                //{
                //DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);
                //endDate.Value = r[r.Length - 1];
                //}
                //else
                //{
                //DateTime[] r = DateUtil.generateWorkingDaysRange(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()));
                //endDate.Value = r[r.Length - 1];
                //}
                // endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString())-1);

                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if (r.Count() > 0)
                    {
                        endDate.Value = r[r.Length - 1];
                    }
                    txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();
                    if (txtPrevLeaveArrears.Text != string.Empty)
                    {
                        txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();
                    }
                }
                else
                {
                    if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE")
                    {
                        DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);
                        endDate.Value = r[r.Length - 1];
                    }
                    else
                    {
                        DateTime newDate;
                        if (leaveTypecmb.Text.Trim().ToUpper() == "MATERNITY LEAVE")
                        {
                            if (gendertxt.Text.ToUpper() == "MALE")
                            {
                                MessageBox.Show("Males can't apply for maternity leave", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        var daysToAdd = _hrservice.CheckHolidaysAndWeekends(startDate.Value, endDate.Value, (int)numericUpDownNumberOfDays.Value, leaveTypecmb.Text);
                        newDate = startDate.Value.AddDays((int)numericUpDownNumberOfDays.Value);
                        endDate.Value = startDate.Value.AddDays((int)numericUpDownNumberOfDays.Value + daysToAdd);
                        var num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                        //for (int i = 1; i <= num; i++ )
                        //{
                        //    newDate = endDate.Value;
                        //    endDate.Value = endDate.Value.AddDays(i);
                        //    num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value);
                        //}
                        while (num > 0)
                        {
                            //MessageBox.Show(num.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            newDate = endDate.Value;
                            endDate.Value = endDate.Value.AddDays(num);
                            if (newDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                newDate = newDate.AddDays(1);
                            }
                            if (newDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                newDate = newDate.AddDays(1);
                            }
                            num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                        }

                    }
                }

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
                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if (r.Count() > 0)
                    {
                        endDate.Value = r[r.Length - 1];
                    }

                    txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();
                    if (txtPrevLeaveArrears.Text != string.Empty)
                    {
                        txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();
                    }
                }
                else if (leaveTypecmb.Text.Trim().ToUpper() == "CASUAL LEAVE")
                {
                    DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if (r.Count() > 0)
                    {
                        endDate.Value = r[r.Length - 1];
                    }
                }
                else
                {
                    DateTime newDate;
                    var daysToAdd = _hrservice.CheckHolidaysAndWeekends(startDate.Value, endDate.Value, (int)numericUpDownNumberOfDays.Value, leaveTypecmb.Text);
                    newDate = startDate.Value.AddDays((int)numericUpDownNumberOfDays.Value);
                    endDate.Value = startDate.Value.AddDays((int)(numericUpDownNumberOfDays.Value - 1) + daysToAdd);
                    var num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                    //for (int i = 1; i <= num; i++ )
                    //{
                    //    newDate = endDate.Value;
                    //    endDate.Value = endDate.Value.AddDays(i);
                    //    num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value);
                    //}
                    while (num > 0)
                    {
                        //MessageBox.Show(num.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        newDate = endDate.Value;
                        endDate.Value = endDate.Value.AddDays(num);
                        if (newDate.DayOfWeek == DayOfWeek.Saturday)
                        {
                            newDate = newDate.AddDays(1);
                        }
                        if (newDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            newDate = newDate.AddDays(1);
                        }
                        num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                    }

                }


                //endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
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
                btnBulkEntry.Visible = false;
                groupleaveCashment.Visible = false;
                if (editMode == false || leaveTypecmb.Text.Trim().ToUpper() != "ANNUAL LEAVE")
                {
                    btnBulkEntry.Visible = true;
                    try
                    {
                        if (numericUpDownNumberOfDays.Value == 0)
                        {
                            numericUpDownNumberOfDays.Value = leaveTypes[leaveTypecmb.SelectedIndex].MaximumEntitlement;
                        }

                        if (txtAccruedDays.Text != string.Empty && txtDaysTaken.Text != string.Empty)
                        {
                            var requestingLeave = (int)decimal.Parse(txtAccruedDays.Text) - (txtDaysTaken.Text != string.Empty ? Convert.ToInt32(txtDaysTaken.Text) : 0);
                            numericUpDownNumberOfDays.Value = requestingLeave;
                        }
                    }
                    catch (Exception xi)
                    {

                    }

                }

                if (leaveTypecmb.Text.Trim() != string.Empty)
                {

                    try
                    {
                        if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" || leaveTypecmb.Text.ToUpper().Trim() == "CASUAL LEAVE")
                        {
                            groupleaveCashment.Visible = false;
                            DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);
                            endDate.Value = r[r.Length - 1];
                        }
                        else
                        {
                            DateTime newDate;
                            //if (leaveTypecmb.Text.Trim().ToUpper() == "MATERNITY LEAVE")
                            //{
                            //    if (gendertxt.Text.ToUpper() == "MALE")
                            //    {
                            //        MessageBox.Show("Males can't apply for maternity leave", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //        return;
                            //    }
                            //}
                            var daysToAdd = _hrservice.CheckHolidaysAndWeekends(startDate.Value, endDate.Value, (int)numericUpDownNumberOfDays.Value, leaveTypecmb.Text);
                            newDate = startDate.Value.AddDays((int)numericUpDownNumberOfDays.Value);
                            endDate.Value = startDate.Value.AddDays((int)(numericUpDownNumberOfDays.Value - 1) + daysToAdd);
                            var num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                            //for (int i = 1; i <= num; i++ )
                            //{
                            //    newDate = endDate.Value;
                            //    endDate.Value = endDate.Value.AddDays(i);
                            //    num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value);
                            //}
                            while (num > 0)
                            {
                                //MessageBox.Show(num.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                newDate = endDate.Value;
                                endDate.Value = endDate.Value.AddDays(num);
                                if (newDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    newDate.AddDays(1);
                                }
                                if (newDate.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    newDate.AddDays(1);
                                }
                                num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                            }

                        }

                    }
                    catch (Exception xi) { }


                }

                if (leaveTypecmb.Text.ToUpper().Trim() == "STUDY LEAVE")
                {
                    lblInstitution.Visible = true;
                    txtInstitution.Visible = true;
                    lblProgramme.Visible = true;
                    txtProgramme.Visible = true;
                    lblDuration.Visible = true;
                    txtDuration.Visible = true;
                    lblFunding.Visible = true;
                    lblProgramType.Visible = true;
                    cboStudyLeaveType.Visible = true;
                    cboPayment.Visible = true;
                }
                else
                {
                    lblInstitution.Visible = false;
                    txtInstitution.Visible = false;
                    lblProgramme.Visible = false;
                    txtProgramme.Visible = false;
                    lblDuration.Visible = false;
                    txtDuration.Visible = false;
                    lblFunding.Visible = false;
                    lblProgramType.Visible = false;
                    cboStudyLeaveType.Visible = false;
                    cboPayment.Visible = false;
                }

                


                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    numericUpDownNumberOfDays.Value = 0;

                    lblAccruedDays.Visible = true;
                    txtAccruedDays.Visible = true;

                    lblDaysTaken.Visible = true;
                    txtDaysTaken.Visible = true;

                    lblYTDAccruedLeave.Visible = true;
                    txtYTDAccruedLeave.Visible = true;


                    txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();
                    if (txtPrevLeaveArrears.Text != string.Empty)
                    {
                        txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();
                    }

                    txtDaysTaken.Text = ((int)leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), DateTime.Now.Month, selectedEmployee.ID)).ToString();
                    try
                    {
                        if (editMode == false && txtAccruedDays.Text != string.Empty && txtDaysTaken.Text != string.Empty)
                        {
                            numericUpDownNumberOfDays.Value = (int)(decimal.Parse(txtAccruedDays.Text) - int.Parse(txtDaysTaken.Text));
                            statusTextBox.Text = "Requesting";
                        }
                    }
                    catch (Exception xi) { }

                    //else
                    // numericUpDownNumberOfDays.Value = leave.NumberOfDays;



                }
                else
                {
                    txtAccruedDays.Text = "";
                    lblAccruedDays.Visible = false;
                    txtAccruedDays.Visible = false;

                    txtDaysTaken.Text = "";
                    lblDaysTaken.Visible = false;
                    txtDaysTaken.Visible = false;

                    lblYTDAccruedLeave.Visible = false;
                    txtYTDAccruedLeave.Visible = false;
                    txtYTDAccruedLeave.Text = "";

                    numericUpDownNumberOfDays.Value = leaveTypes[leaveTypecmb.SelectedIndex].MaximumEntitlement;
                }

                //if (leaveTypecmb.Text.Trim().ToUpper() == "MATERNITY LEAVE" && gendertxt.Text.Trim().ToUpper()=="MALE")
                //{
                //    MessageBox.Show("Please you cannot select Maternity Leave for a male!");

                //}
                if (leaveTypecmb.Text.Trim().ToUpper() == "MATERNITY LEAVE")
                {
                    if (gendertxt.Text.ToUpper() == "MALE")
                    {
                        MessageBox.Show("Males can't apply for maternity leave", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        leaveTypecmb.SelectedIndex = -1;
                        leaveTypecmb.Text = string.Empty;
                        return;
                    }
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
                string leaveType = string.Empty;

                if (leaveTypecmb.Text.ToLower().Trim() == "annual leave")
                {
                    leaveType = "LEAVE";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "maternity leave")
                {
                    leaveType = "MATLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "study leave")
                {
                    leaveType = "STUDLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "sick leave")
                {
                    leaveType = "SICKLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "casual leave")
                {
                    leaveType = "CASLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "general leave")
                {
                    leaveType = "GENLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "examination leave")
                {
                    leaveType = "EXAMLEV";
                }
                else if (leaveTypecmb.Text.ToLower().Trim() == "bereavement leave")
                {
                    leaveType = "BERLEV";
                }

                DateTime todays = DateTime.Now;

                string refNo = "HR/LET/JA/" + leaveType + "/" + staffIDtxt.Text + "/" + todays.ToString("MMM").ToUpper() + "/" + todays.ToString("yy");
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    reportForm = new AGALeaveLetterForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value, refNo);
                    reportForm.Show();
                }
                else
                {
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }

                if (leaveTypecmb.Text.ToUpper().Trim() != "ANNUAL LEAVE" && leaveTypecmb.Text.ToUpper().Trim() == "CASUAL LEAVE" && Information.IsNumeric(txtLeaveBalance.Text) && Convert.ToInt32(txtLeaveBalance.Text) > 0)
                {
                    MessageBox.Show(this, "Staff Must finish his/her annual leave first ");

                    leaveTypecmb.SelectedIndex = -1;
                }

                if (leaveTypecmb.Text.ToUpper().Trim() == "ANNUAL LEAVE" && txtAnnualLeaveYear.Text != string.Empty)
                {

                    txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();

                    if (txtPrevLeaveArrears.Text != string.Empty)
                        txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();

                    if (label1.Text == "New Leave")
                    {
                        numericUpDownNumberOfDays.Value = int.Parse(txtAccruedDays.Text) - int.Parse(txtDaysTaken.Text);
                        statusTextBox.Text = "Requesting";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        private void leaveTypecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        decimal getAccruedAnnualLeaves(Nullable<DateTime> currDate)
        {
            decimal accruedLeaves = 0;
            try
            {
                if (currDate == null)
                    currDate = startDate.Value.Date;
                if (txtAnnualLeaveYear.Text != string.Empty && int.Parse(txtAnnualLeaveYear.Text) == startDate.Value.Year)
                {
                    DateTime startOfYear = new DateTime();
                    if (employee.EmploymentDate.Value.Year == DateTime.Now.Year)
                    {
                        startOfYear = new DateTime(int.Parse(employee.EmploymentDate.Value.Year.ToString()), employee.EmploymentDate.Value.Month, 1);
                    }
                    else
                    {
                        startOfYear = new DateTime(int.Parse(txtAnnualLeaveYear.Text), 1, 1);
                    }
                    //DateTime currDate = GlobalData.ServerDate.Date;
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("startOfYear", startOfYear.Date, DbType.Date);
                    dalHelper.CreateParameter("currDate", currDate, DbType.Date);

                    var monthDiff = dalHelper.ExecuteScalar("select DATEDIFF(MONTH,@startOfYear,@currDate) as monthDiff");
                    var noMonths = 0;
                    if (monthDiff != null)
                    {
                        noMonths = int.Parse(monthDiff.ToString());
                    }


                    dalHelper.ClearParameters();

                    int totalLeaves = (txtLeaveDue.Text != string.Empty) ? int.Parse(txtLeaveDue.Text) : 0;
                    // int LeaveBalance =txtLeaveBalance.Text!=string.Empty?int.Parse(txtLeaveBalance.Text):0;

                    double leavePoint = (float)totalLeaves / 12.0;

                    accruedLeaves = decimal.Parse((leavePoint * noMonths).ToString());

                    accruedLeaves = Math.Round(decimal.Parse((accruedLeaves).ToString()), 2);

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

            }
            return accruedLeaves;
        }
        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            //DateTime[] r = DateUtil.getWorkingDaysList(startDate.Value, endDate.Value);
            //numericUpDownNumberOfDays.Value = r.Length;

        }

        private void numericUpDownNumberOfDays_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (leaveTypecmb.Text.Trim().ToUpper() == "ANNUAL LEAVE")
                {
                    DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if (r.Count() > 0)
                    {
                        endDate.Value = r[r.Length - 1];
                    }
                    txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();
                    if (txtPrevLeaveArrears.Text != string.Empty)
                    {
                        txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();
                    }
                }
                else if (leaveTypecmb.Text.Trim().ToUpper() == "CASUAL LEAVE")
                {
                    DateTime[] r = AppUtils.getNonePublicHolidaysOWeekends(startDate.Value, int.Parse(numericUpDownNumberOfDays.Value.ToString()), employee.AnnualLeaveEntitlement.IncludeHolidays, employee.AnnualLeaveEntitlement.IncludeWeekends);

                    if (r.Count() > 0)
                    {
                        endDate.Value = r[r.Length - 1];
                    }
                }
                else
                {
                    
                        DateTime newDate;

                        var daysToAdd = _hrservice.CheckHolidaysAndWeekends(startDate.Value, endDate.Value, (int)numericUpDownNumberOfDays.Value, leaveTypecmb.Text);
                        newDate = startDate.Value.AddDays((int)numericUpDownNumberOfDays.Value);
                        endDate.Value = startDate.Value.AddDays((int)(numericUpDownNumberOfDays.Value - 1) + daysToAdd);
                        var num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                        //for (int i = 1; i <= num; i++ )
                        //{
                        //    newDate = endDate.Value;
                        //    endDate.Value = endDate.Value.AddDays(i);
                        //    num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value);
                        //}
                        while (num > 0)
                        {
                            //MessageBox.Show(num.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            newDate = endDate.Value;
                            endDate.Value = endDate.Value.AddDays(num);
                            if (newDate.DayOfWeek == DayOfWeek.Saturday)
                            {
                                newDate = newDate.AddDays(1);
                            }
                            if (newDate.DayOfWeek == DayOfWeek.Sunday)
                            {
                                newDate = newDate.AddDays(1);
                            }
                            num = _hrservice.GetWeekEndsInDateRange(newDate, endDate.Value, leaveTypecmb.Text);
                        }

                    }
                

            }
            catch (Exception ex)
            {

                Logger.LogError(ex);
            }
        }

        /// <summary>
        /// Check for weekends and holidays for all leave days except for annual days 
        /// </summary>
        private void CheckLeave()
        {
            DateTime newDate;
            try
            {
                if (leaveTypecmb.SelectedIndex == 0 || leaveTypecmb.Text == " " || string.IsNullOrEmpty(leaveTypecmb.Text))
                {
                    //MessageBox.Show("Please select leave type", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (leaveTypecmb.Text.Trim().ToUpper() != "ANNUAL LEAVE")
                    {

                    }
                    else
                    {

                    }
                }
            }
            catch (Exception er)
            {
                Logger.LogError(er);
            }
        }

        private void leaveDate_ValueChanged(object sender, EventArgs e)
        {
            txtYTDAccruedLeave.Text = getAccruedAnnualLeaves(null).ToString();

            if (txtPrevLeaveArrears.Text != string.Empty)
            {
                txtAccruedDays.Text = (Convert.ToDecimal(txtYTDAccruedLeave.Text) + Convert.ToInt32(txtPrevLeaveArrears.Text)).ToString();
            }
        }

        private void txtAccruedDays_TextChanged(object sender, EventArgs e)
        {
            if (editMode == false && txtAccruedDays.Text != string.Empty)
            {
                var requestingLeave = (int)decimal.Parse(txtAccruedDays.Text) - (txtDaysTaken.Text != string.Empty ? Convert.ToInt32(txtDaysTaken.Text) : 0);

                numericUpDownNumberOfDays.Value = requestingLeave;
            }

        }

        private void label1_TextChanged(object sender, EventArgs e)
        {

        }

        int getAnnualLeavesTaken(string staffID, int Year)
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

                var leaveStatus = dalCommand.ExecuteScalar(" select top 1 case when recommended='false' then 'UNRECOMMENDED' when approved='false' then 'UNAPPROVED' else 'NOT_AVAILABLE' end AS LEAVE_ACTION_STATUS  from StaffLeave where staffID=@staffID and leaveYear=@leaveYear and Archived = 'false' and  (Approved='false' or recommended='false') order by LeaveDate desc");

                if (leaveStatus != null)
                    return leaveStatus.ToString();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return "NOT_AVAILABLE";
        }



        private void lblAccruedDays_Click(object sender, EventArgs e)
        {

        }

        private void leaveTypecmb_TextUpdate(object sender, EventArgs e)
        {

        }

        private void leaveTypecmb_TextChanged(object sender, EventArgs e)
        {
            leaveTypecmb_SelectionChangeCommitted(sender, e);
        }

        private void numericUpDownNumberOfDays_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDownNumberOfDays_Click(object sender, EventArgs e)
        {
            //if (editMode == true)
            //    txtDaysTaken.Text = ((int)(leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), LeaveEditing.Employee.ID) + numericUpDownNumberOfDays.Value)).ToString();

            //else
            //    txtDaysTaken.Text = ((int)(leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), selectedEmployee.ID) + numericUpDownNumberOfDays.Value)).ToString();
        }

        private void txtAnnualLeaveYear_TextChanged(object sender, EventArgs e)
        {
            //if (startDate.Value.Year != employee.AnnualLeaveYear)
            //{
            //    txtAnnualLeaveYear.Text = startDate.Value.Year.ToString();
            //    try
            //    {
            //        txtLeaveDue.Text = ((int)leaveBalanceMapper.getYearAnnualLeave(Convert.ToInt32(txtAnnualLeaveYear.Text), employee.ID)).ToString();
            //        txtDaysTaken.Text = ((int)leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), DateTime.Now.Month, employee.ID)).ToString();
            //        txtPrevLeaveArrears.Text = ((int)leaveBalanceMapper.getMyLeaveArrears(Convert.ToInt32(txtAnnualLeaveYear.Text), DateTime.Now.Month, employee.ID)).ToString();

            //        selectedEmployee = employee;

            //        if (editMode == false)
            //        {
            //            txtLeaveBalance.Text = ((int)(leaveBalanceMapper.getYearAnnualLeave(Convert.ToInt32(txtAnnualLeaveYear.Text), employee.ID) + leaveBalanceMapper.getMyLeaveArrears(Convert.ToInt32(txtAnnualLeaveYear.Text), 12, employee.ID) - leaveBalanceMapper.getLeaveTaken(Convert.ToInt32(txtAnnualLeaveYear.Text), DateTime.Now.Month, employee.ID))).ToString();

            //            statusTextBox.Text = "Requesting";

            //        }
            //    }
            //    catch (Exception xi) { }
            //}

        }

        private void btnBulkEntry_Click(object sender, EventArgs e)
        {
            LeavesBulkEntry form = new LeavesBulkEntry();
            form.MdiParent = this.MdiParent;
            form.Show();
        }

        private void btnLeaveEncashment_Click(object sender, EventArgs e)
        {

        }

    }
}
