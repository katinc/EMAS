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
using eMAS;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveEncashment : Form
    {
        private IDAL dal;
        private Leave leave;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<LeaveType> leaveTypes;
        private Employee employee;
        private LeaveDataMapper leavManip;
        private DataTable leaveTypesTable;
        private DALHelper dalHelper;
        private Form reportForm;
        private Company company;
        private int ctr;
        private int staffCode;

        private DataReference.LeaveEncashmentView encashment;
        private bool editMode;
        private int encashmentID;

        private IList<GradeCategory> gradeCategories;

        private DALHelper dalCommand;

        private DataReference.hrContextDataContext hrcontext= new DataReference.hrContextDataContext();
        List<Control> controls;
        List<controlObject> OldValues;

        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public LeaveEncashment()
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
                this.ctr = 0;
                this.staffCode = 0;
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.leaveTypesTable = new DataTable();
                this.dalHelper = new DALHelper();
                this.company = new Company();

                this.encashment = new DataReference.LeaveEncashmentView();
                this.editMode = false;
                this.encashmentID = 0;


                this.gradeCategories = new List<GradeCategory>();

                dalCommand = new DALHelper();
                this.controls = new List<Control>();
                this.OldValues = new List<controlObject>();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LeaveEncashment_Load(object sender, EventArgs e)
        {
            try
            {
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    Viewbtn.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }

                //txtEncashmentRate.Enabled = false;
                txtBasicSalary.Enabled = false;
                //txtEncashmentDays.Enabled = false;
                leaveDate.Enabled = false;
                txtAmount.Enabled = false;
                //txtEncashmentDays.Value = 1;
                editMode = false;

                GlobalData.FillControls(controls, this);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void EditEncashment(string Id)
        {
            try
            {
                encashment = GlobalData._context.LeaveEncashmentViews.SingleOrDefault(u => u.ID == Convert.ToDecimal(Id));
                editMode = true;

                //leave details
                encashmentID = Convert.ToInt32(encashment.ID);
                staffIDtxt.Text = encashment.StaffID.ToString();
                nametxt.Text = encashment.Firstname + " " + encashment.OtherName + " " + encashment.Surname;
                gendertxt.Text = encashment.Gender;
                agetxt.Text = encashment.Age.ToString();
                departmentTextBox.Text = encashment.Department;
                txtLeaveDue.Text = encashment.CurrentAnnualLeave.ToString();
                txtAnnualLeaveYear.Text = encashment.LeaveYear.ToString();
                txtPrevLeaveArrears.Text = encashment.LeaveArreas.ToString();
                txtLeaveBalance.Text = encashment.LeaveBalance.ToString();
                searchGrid.Visible = false;
                label1.Text = "Edit Encashment";

                //encashment details
                txtEncashmentRate.ReadOnly = true;
                txtEncashmentRate.Enabled = true;
                txtEncashmentDays.Value = encashment.NumberOfDays;
                txtEncashmentRate.Text = encashment.EncashmentRate.ToString();
                leaveDate.Value = encashment.EntryDate;
                txtAmount.Text = encashment.Amount.ToString();
                cmbJobCategory_DropDown(this, EventArgs.Empty);
                txtBasicSalary.Text = encashment.BasicSalary.ToString();

                //cmbJobCategory.Enabled = false;
                //txtEncashmentRate.ReadOnly = true;
                //txtAmount.ReadOnly = true;
                txtEncashmentDays.Visible = true;
                txtEncashmentDays.ReadOnly = false;
                txtEncashmentDays.Enabled = true;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            OldValues = GlobalData.CloneControls(controls, this);

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

        private Employee selectedEmployee;
        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
                    foreach (Employee employ in employees)
                    {
                        if (employ.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            employee = employ;

                            string name = employ.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employ.OtherName) + " " + employ.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employ.StaffID;
                            staffCode = employ.ID;
                            gendertxt.Text = employ.Gender;
                            pictureBox.Image = employ.Photo;
                            agetxt.Text = employ.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            departmentTextBox.Text = employ.Department.Description;

                            //txtLeaveDue.Text = ((int)leaveBalanceMapper.getYearAnnualLeave(employee.AnnualLeaveYear, employee.ID)).ToString();
                            txtAnnualEndDate.Text = employ.CurrentLeaveEndDate.ToString();
                            txtLeaveDue.Text = employ.AnnualLeave.ToString();
                            txtBasicSalary.Text = employ.BasicSalary.ToString();

                            txtAnnualLeaveYear.Text = employ.AnnualLeaveYear.ToString();

                            txtLeaveBalance.Text = employ.LeaveBalance.ToString();
                            txtPrevLeaveArrears.Text = employ.LeaveArrears.ToString();
                            //lblLeaveBalance.Text = "Leave Balance (" + employee.AnnualLeaveYear + ")";

                            selectedEmployee = employ;

                            cmbJobCategory_DropDown(this, EventArgs.Empty);
                            //cmbJobCategory.Text = employ.GradeCategory.Description;
                            cmbJobCategory_SelectionChangeCommitted(this, EventArgs.Empty);
                            //cmbJobCategory.Enabled = false;

                            CalculateEncashmentAmount(employ);


                            
                        }
                    }
                }
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
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                leaveDate.ResetText();
                leaveDate.Value = DateTime.Today.Date;
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveBalance.Clear();
                label1.Text = "New Leave Encashment";
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                departmentTextBox.Clear();
                txtAnnualEndDate.Clear();
                txtPrevLeaveArrears.Clear();
                txtBasicSalary.Clear();

                txtAmount.Clear();
                txtEncashmentRate.Text = string.Empty;
                //txtEncashmentDays.ResetText();
                txtEncashmentDays.Value = 1;

                //cmbJobCategory.DataSource = null;
                //cmbJobCategory.Text = string.Empty;
                //RestoreDefaults();
                editMode = false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void RestoreDefaults()
        {
            try
            {
                txtEncashmentRate.Text = string.Empty;
                txtEncashmentDays.Value = 1;
                txtAmount.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool checkEncashmentDays()
        {
            try
            {

                if (staffIDtxt.Text == string.Empty || staffIDtxt.Text == null)
                {
                    return false;
                }

                //if ((txtEncashmentRate.Text == null || txtEncashmentRate.Text == string.Empty) && (staffIDtxt.Text != string.Empty || staffIDtxt.Text != null))
                //{
                //    MessageBox.Show("Kindly set encashment rate for selected category");
                //    RestoreDefaults();
                //    return false;
                //}
                //else 
                if (txtLeaveBalance.Text == null || txtLeaveBalance.Text == string.Empty && txtEncashmentRate.Enabled != false && editMode == false)
                {
                    MessageBox.Show("Cannot encash leave for null Staff with empty leave balance");
                    RestoreDefaults();
                    return false;
                }

                int encashmentDays = Convert.ToInt32(txtEncashmentDays.Value);
                int leaveBalance = Convert.ToInt32(txtLeaveBalance.Text);


                if (encashmentDays > leaveBalance || leaveBalance <= 0)
                {
                    txtEncashmentDays.Value = leaveBalance;
                    MessageBox.Show("Encashment days cannot be more than Leave balance or less than or equal to 0");
                    return true;
                }

                CalculateEncashmentAmount(employee);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return false;
        }

        private void CalculateEncashmentAmount(Employee employee)
        {
            try
            {
                decimal encashmentRate = 0;
                if (editMode == false)
                {
                    encashmentRate = Math.Round(employee.BasicSalary / 27, 2);
                    txtEncashmentRate.Text = encashmentRate.ToString();
                }
                else
                {
                    encashmentRate = encashment.EncashmentRate;
                    txtEncashmentRate.Text = encashmentRate.ToString();
                }
                

                if (txtEncashmentDays.Value <= 0)
                {
                    txtEncashmentDays.Value = 1;
                }

                decimal amount = Convert.ToDecimal(txtEncashmentRate.Text) * Convert.ToDecimal(txtEncashmentDays.Value);

                txtAmount.Text = amount.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void txtEncashment_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                checkEncashmentDays();   
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void editModeOn()
        {
            try
            {
                editMode = true;
                label1.Text = "Edit Encashment";

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkEncashmentDays())
                {
                    var employeeLeave = GlobalData._context.StaffPersonalInfoViews.SingleOrDefault(u => u.StaffID == staffIDtxt.Text);

                    if (employeeLeave == null)
                    {
                        return;
                    }

                    DateTime date = Convert.ToDateTime(leaveDate.Value);
                    DateTime effectiveDate = new DateTime(date.Year, date.Month, 1);
                    DateTime endDate = effectiveDate.AddMonths(1).AddDays(-1);

                    //check if the same start and end dates exists already
                    //var alreadyExists = GlobalData._context.LeaveEncashments.SingleOrDefault(u => u.EffectiveDate == effectiveDate && u.StaffID == staffIDtxt.Text );

                    if (editMode)
                    {
                        var encashment = GlobalData._context.LeaveEncashments.SingleOrDefault(u => u.ID == encashmentID);
                        var staffAllowance = GlobalData._context.StaffAllowances.SingleOrDefault(u => u.StaffID == employeeLeave.StaffID && u.EffectiveDate == effectiveDate && u.EndDate == endDate && u.TypeID == 113);

                        if (encashment != null && staffAllowance != null)
                        {
                            encashment.ID = encashmentID;
                            encashment.NumberOfDays = txtEncashmentDays.Value;
                            encashment.Amount = Convert.ToDecimal(txtAmount.Text);

                            staffAllowance.Amount = Convert.ToDecimal(txtAmount.Text);
                            staffAllowance.EffectiveDate = effectiveDate;
                            staffAllowance.EndDate = endDate;

                            //GlobalData._context.SubmitChanges();
                            GlobalData.ProcessEdit(OldValues, controls, this, encashmentID, staffIDtxt.Text);
                            MessageBox.Show("Leave Encashment updated successfully");
                            editMode = false;
                        }
                        else
                        {
                            MessageBox.Show("Leave encashment was not updated. Contact your Administrator");
                        }

                        
                    }
                    else
                    {
                        //save encashment
                        var leaveEncashment = new DataReference.LeaveEncashment
                        {
                            StaffID = staffIDtxt.Text,
                            EncashmentRate = Convert.ToDecimal(txtEncashmentRate.Text),
                            NumberOfDays = txtEncashmentDays.Value,
                            Amount = Convert.ToDecimal(txtAmount.Text),
                            DateTimeGenerated = DateTime.Now,
                            EntryDate = effectiveDate,
                            //GradeCategoryID = gradeCategories[cmbJobCategory.SelectedIndex].ID.ToString(),
                            BasicSalary = Convert.ToDecimal(txtBasicSalary.Text),
                            CurrentAnnualLeave = Convert.ToDecimal(txtLeaveDue.Text),
                            LeaveYear = Convert.ToDecimal(txtAnnualLeaveYear.Text),
                            LeaveBalance = Convert.ToDecimal(txtLeaveBalance.Text),
                            LeaveArreas = Convert.ToDecimal(txtPrevLeaveArrears.Text),

                        };
                        GlobalData._context.LeaveEncashments.InsertOnSubmit(leaveEncashment);
                        GlobalData._context.SubmitChanges();

                        //check if save was successful
                        var newEncashment = GlobalData._context.LeaveEncashments.SingleOrDefault(u => u.StaffID == leaveEncashment.StaffID && u.DateTimeGenerated == leaveEncashment.DateTimeGenerated);

                        DataReference.StaffAllowance staffAllowance = new DataReference.StaffAllowance();

                        //if it was save allowance as well
                        if (newEncashment != null)
                        {
                            //save allowance for payroll calculation
                            
                                staffAllowance.Amount = Convert.ToDecimal(txtAmount.Text);
                                staffAllowance.Archived = false;
                                staffAllowance.EffectiveDate = effectiveDate; //first day of the entry date month 
                                staffAllowance.EndDate = endDate; //last day of the entry date month
                                staffAllowance.Frequency = company.PaymentFrequency;
                                staffAllowance.InUse = true;
                                staffAllowance.IsEndDate = true;
                                staffAllowance.TypeID = 113; //ID for leave encashed days
                                staffAllowance.StaffID = employee.StaffID;
                                staffAllowance.UserID = GlobalData.User.ID;
                                staffAllowance.StaffCode = employee.ID;
                            
                            GlobalData._context.StaffAllowances.InsertOnSubmit(staffAllowance);
                            GlobalData._context.SubmitChanges();
                        }

                        //check if allowance save was successful
                        var newAllowance = GlobalData._context.StaffAllowances.SingleOrDefault(u => u == staffAllowance);

                        if (newAllowance == null) //allowance was not saved, so delete the encashment and throw error
                        {
                            GlobalData._context.LeaveEncashments.DeleteOnSubmit(leaveEncashment);
                            MessageBox.Show("There was an error saving allowance. Contact your Administrator");
                            return;
                        }
                        else
                        {
                            //everything saved correctly
                            employeeLeave.LeaveTaken += Convert.ToInt32(txtEncashmentDays.Value);
                            employeeLeave.LeaveBalance -= Convert.ToInt32(txtEncashmentDays.Value);
                            employeeLeave.LeaveArrears -= Convert.ToInt32(txtEncashmentDays.Value);

                            GlobalData._context.SubmitChanges();
                            MessageBox.Show("Leave Encashment saved successfully");
                        }

                        
                    }
                    Clear();
                }

            }
            catch (Exception ex)
            {
                checkEncashmentDays();   
                //throw ex;
            }
        }

        private void salaryPaymentUnitComboBox_DropDown(object sender, EventArgs e)
        {

        }

        private void cmbJobCategory_DropDown(object sender, EventArgs e)
        {
            //try
            //{
            //    gradeCategories = dal.GetAll<GradeCategory>();

            //    cmbJobCategory.Items.Clear();
            //    foreach (GradeCategory category in gradeCategories)
            //    {
            //        cmbJobCategory.Items.Add(category.Description);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //    throw ex;
            //}
        }

        private void cmbJobCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                //txtEncashmentRate.Text = string.Empty;

                //txtEncashmentRate.Text = gradeCategories[cmbJobCategory.SelectedIndex].LeaveEncashmentRate.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtLeaveBalance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtLeaveBalance.Text != string.Empty || txtLeaveBalance.Text != null)
                {
                    txtEncashmentRate.Enabled = true;
                    //cmbJobCategory.Enabled = true;
                    txtEncashmentDays.Enabled = true;
                    leaveDate.Enabled = true;
                    txtAmount.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveEncashmentView viewDialog = new LeaveEncashmentView(this);
                viewDialog.MdiParent = this.MdiParent;
                viewDialog.btnDelete.Enabled = CanDelete;
                viewDialog.Show();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
