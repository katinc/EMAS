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

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveResumptionForm : Form
    {
        private IDAL dal;
        private Leave leave;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<LeaveType> leaveTypes;
        private Employee employee;
        private IList<Leave> leaves;
        private bool editMode;
        private int leaveID;
        private Form reportForm;
        private Company company;
        private int ctr;
        private int staffCode;
        private decimal leaveDays;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        List<Control> controls;
        List<controlObject> OldValues;

        private DateTime endDate;

        public LeaveResumptionForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.leave = new Leave();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.leaveTypes = new List<LeaveType>();
                this.leaves = new List<Leave>();
                this.employee = new Employee();
                this.editMode = false;
                this.ctr = 0;
                this.staffCode = 0;
                this.leaveDays = 0;
                this.leaveID = 0;
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.company = new Company();
                this.endDate = new DateTime();

                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();

            }
            catch (Exception ex)
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
                gendertxt.Text = leave.Employee.Gender;
                agetxt.Text = leave.Employee.Age;
                departmentTextBox.Text = leave.Employee.Department.Description;

                txtLeaveDue.Text = leave.Employee.AnnualLeave.ToString();
                txtAnnualLeaveYear.Text = leave.Employee.AnnualLeaveYear.ToString();
                txtLeaveArrears.Text = (leave.Employee.LeaveArrears + leave.NumberOfDays).ToString();
                leaveDays = leave.NumberOfDays;
                txtStartDate.Text = leave.StartDate.ToString();
                txtEndDate.Text = leave.EndDate.ToString();
                txtRequestedDays.Text = leave.NumberOfDays.ToString();
                resumptionDate.Text = leave.ResumedDate.Value.Date.ToString();
                txtLeaveType.Text = leave.LeaveType;
                groupBox1.Enabled = true;
                searchGrid.Visible = false;
                label1.Text = "Edit Leave Resumption Form";
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != leave.User.ID)
                {
                    savebtn.Enabled = false;
                }
                endDate = leave.EndDate;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            OldValues = GlobalData.CloneControls(controls, this);

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
                if (txtEndDate.Text!=string.Empty && resumptionDate.Value.Date < endDate.AddDays(1))
                {
                    result = false;
                    staffErrorProvider.SetError(resumptionDate, "The Resumption date should be greater than end date");
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
                    //dalHelper = new DALHelper();
                    dal.BeginTransaction();
                    Assign();
                    if (editMode)
                    {
                        if (!CanEdit)
                        {
                            MessageBox.Show("Sorry you do not have permission to edit this data.");
                            return;
                        }

                        employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                        employee.LeaveStatus = "Resumed";
                        employee.OnLeave = false;
                        dal.Update(employee);
                        //UpdateEmployee(employee);
                        //dal.Update(leave);
                        //UpdateLeave(leave);
                        GlobalData.ProcessEdit(OldValues, controls, this, leaveID, staffIDtxt.Text);
                        Clear();
                    }
                    else
                    {
                        employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                        employee.LeaveStatus = "Resumed";
                        employee.OnLeave = false;
                        dal.Update(employee);
                        dal.Update(leave);
                        //UpdateEmployee(employee);
                        //UpdateLeave(leave);
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

        /*DALHelper dalHelper;
        void UpdateEmployee(Employee emp)
        {
          
            //dalHelper.BeginTransaction();

            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@LeaveStatus", emp.LeaveStatus, DbType.String);
                dalHelper.CreateParameter("@OnLeave", emp.OnLeave, DbType.Boolean);
                dalHelper.CreateParameter("@ID", emp.ID, DbType.Int32);


                dalHelper.ExecuteNonQuery("update StaffPersonalInfo set LeaveStatus=@LeaveStatus,OnLeave=@OnLeave where ID=@ID");
                //dalHelper.CommitTransaction();
            
            }
            catch (Exception ex)
            {
                //dalHelper.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        void UpdateLeave(Leave leave)
        {
          

            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Resumed", leave.Resumed, DbType.Boolean);
                dalHelper.CreateParameter("@ResumedUser", leave.ResumedUser, DbType.String);
                dalHelper.CreateParameter("@ResumedUserStaffID", leave.ResumedUserStaffID, DbType.Int32);
                dalHelper.CreateParameter("@ResumedDate", leave.ResumedDate, DbType.Date);
                dalHelper.CreateParameter("@ResumedTime", leave.ResumedTime, DbType.Time);

                dalHelper.CreateParameter("@ID", leave.ID, DbType.Int32);

                dalHelper.ExecuteNonQuery("update StaffLeave set Resumed=@Resumed,ResumedUser=@ResumedUser,ResumedUserStaffID=@ResumedUserStaffID,ResumedDate=@ResumedDate,ResumedTime=@ResumedTime where ID=@ID");
                //dalHelper.CommitTransaction();
            }
            catch (Exception ex)
            {
                //dalHelper.RollBackTransaction();
                Logger.LogError(ex);
            }
        }*/
        #region ASSINGNMENTS
        private void Assign()
        {
            try
            {
                leave.ID = leaveID;
                leave = dal.GetByID<Leave>(leaveID);
                leave.Employee.StaffID = staffIDtxt.Text.Trim();
                leave.Employee.ID = staffCode;
                leave.StaffName = nametxt.Text.Trim();
                leave.Resumed = true;
                leave.ResumedUser = GlobalData.User.Name;
                leave.ResumedUserStaffID = GlobalData.User.StaffID;
                leave.ResumedDate = resumptionDate.Value.Date;
                leave.ResumedTime = resumptionDate.Value;
                leave.User.ID = GlobalData.User.ID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

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

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                staffIDtxt.Clear();
                nametxt.Clear();
                staffIDtxt.Select();
                gendertxt.Clear();
                agetxt.Clear();
                resumptionDate.ResetText();
                resumptionDate.Checked=false;
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveArrears.Clear();
                txtRequestedDays.Clear();
                txtEndDate.Clear();
                txtStartDate.Clear();
                txtLeaveType.Clear();
                leaveID = 0;
                
                label1.Text = "New Leave Resumption Form";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                departmentTextBox.Clear();
                staffErrorProvider.Clear();
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
                    foreach (Leave leave in leaves)
                    {
                        if (leave.ID.ToString() == searchGrid.CurrentRow.Cells["gridID"].Value.ToString().Trim())
                        {
                            string name = leave.Employee.FirstName + (leave.Employee.OtherName == string.Empty ? string.Empty : " " + leave.Employee.OtherName) + " " + leave.Employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = leave.Employee.StaffID;
                            staffCode = leave.Employee.ID;
                            gendertxt.Text = leave.Employee.Gender;
                            agetxt.Text = leave.Employee.Age;
                            departmentTextBox.Text = leave.Employee.Department.Description;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            leaveID = leave.ID;
                            endDate = leave.EndDate;
                            txtLeaveDue.Text = leave.Employee.AnnualLeave.ToString();
                            txtStartDate.Text = leave.StartDate.Date.ToString("dd/MM/yyyy");
                            txtEndDate.Text = leave.EndDate.Date.ToString("dd/MM/yyyy");
                            txtRequestedDays.Text = leave.NumberOfDays.ToString();
                            txtAnnualLeaveYear.Text = leave.Employee.AnnualLeaveYear.ToString();
                            txtLeaveType.Text = leave.LeaveType;
                            if (editMode == false)
                            {
                                txtLeaveArrears.Text = leave.Employee.LeaveArrears.ToString();
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
                            Property = "StaffLeaveView.StaffID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = staffIDtxt.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.Recommended",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.Approved",
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
                        if(editMode == false)
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffLeaveView.Resumed",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = false,
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLeaveView.Recalled",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        leaves = dal.GetByCriteria<Leave>(query);
                        if (leaves.Count > 0)
                        {
                            foreach (Leave leave in leaves)
                            {
                                string name = leave.Employee.FirstName + (leave.Employee.OtherName == string.Empty ? string.Empty : " " + leave.Employee.OtherName) + " " + leave.Employee.Surname;
                                if (leave.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridID"].Value = leave.ID;
                                    searchGrid.Rows[ctr].Cells["gridLeaveType"].Value = leave.LeaveType;
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = leave.Employee.StaffID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 45;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 44;
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + " Has Already Resumed Leave");
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

        private void LeaveResumptionForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    findbtn.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
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
                LeaveResumptionView form = new LeaveResumptionView(this);
                form.MdiParent = this.MdiParent;
                form.removeButton.Enabled = CanDelete;
                form.Show();
            }
            catch(Exception ex)
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
    }
}

