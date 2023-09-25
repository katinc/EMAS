using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.All_UIs.Staff_Information_FORMS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.Employment;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Threading;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class AnnualCalculateLeaveForm : Form
    {
        private IList<Employee> employees;
        private Employee employee;
        private AnnualLeaveCalculation annualLeaveCalculation;
        private IList<AnnualLeaveEntitlement> annualLeaveEntitlements;
        private DAL dal;
        private Company company;
        private int annualLeaveCalculationsID;
        private int staffCode;
        private int ctr;
        private bool editMode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public AnnualCalculateLeaveForm()
        {
            try
            {
                InitializeComponent();
                this.annualLeaveCalculation = new AnnualLeaveCalculation();
                this.annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.dal = new DAL();
                this.company = new Company();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.annualLeaveCalculationsID = 0;
                this.staffCode = 0;
                this.ctr = 0;
                this.editMode = false;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
                yearComboBox.Items.Add(DateTime.Now.Year);
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

        private void btnClear_Click(object sender, EventArgs e)
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

        private void Clear()
        {
            try
            {
                annualLeaveCalculationsID = 0;
                staffErrorProvider.Clear();
                yearComboBox.Items.Clear();
                yearComboBox.Text = string.Empty;
                yearComboBox_DropDown(this,EventArgs.Empty);
                yearComboBox.Text = DateTime.Today.Year.ToString();
                cboLeaveEntitlement.Items.Clear();
                cboLeaveEntitlement.Text = string.Empty;
                radioButtonAll.Checked = true;
                numericUpDownNumberOfDays.Value = 0;
                searchGrid.Visible = false;
                editMode = false;
                ClearStaff();
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaff()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                staffIDtxt.Focus();
                txtLeaveEntitlement.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    ClearStaff();
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
                            txtLeaveEntitlement.Text = employee.AnnualLeaveEntitlement.CategoryOfPost + " " + employee.AnnualLeaveEntitlement.Status + " (" + employee.AnnualLeaveEntitlement.NumberOfDays + ")";
                            numericUpDownNumberOfDays.Value = employee.AnnualLeaveEntitlement.NumberOfDays;
                            numericUpDownNumberOfDays.Enabled = false;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            checkBoxIsNewEngagement.Visible = true;
                            break;
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
                        string lastName = employee.Surname;
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()) || lastName.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
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
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private LeaveBalanceDataMapper leaveBalanceMapper;
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            LeaveBalance leaveBalance = new LeaveBalance();
            leaveBalanceMapper = new LeaveBalanceDataMapper();
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    if (radioButtonAll.Checked == true)
                    {
                        employees = dal.GetAll<Employee>();
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                UpdateAnnualLeaveCalculationsEntity();
                                employee.AnnualLeave = employee.AnnualLeaveEntitlement.NumberOfDays;
                                employee.LeaveArrears = (int)leaveBalanceMapper.getMyLeaveArrears(annualLeaveCalculation.Year, 12, employee.ID);

                                employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                                employee.AnnualLeaveYear = annualLeaveCalculation.Year;
                                employee.AnnualLeaveProposedStartDate = null;
                                employee.AnnualLeaveProposedEndDate = null;


                                employee.LeaveTaken = (int)leaveBalanceMapper.getLeaveTaken(annualLeaveCalculation.Year, DateTime.Now.Month, employee.ID);
                                employee.LeaveBalance = (employee.AnnualLeave + employee.LeaveArrears) - employee.LeaveTaken;


                                leaveBalance.leaveArrears = employee.LeaveArrears;
                                leaveBalance.leaveBalance = employee.LeaveBalance;
                                leaveBalance.AnnualLeaveYear = employee.AnnualLeaveYear;
                                leaveBalance.leaveTaken = employee.LeaveTaken;
                                leaveBalance.month = (DateTime.Now.Year == Convert.ToInt32(yearComboBox.Text)) ? DateTime.Now.Month : 1;
                                leaveBalance.employee = employee;
                                leaveBalance.leaveType = "Annual Leave";

                                dal.Update(employee);
                                annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                                annualLeaveCalculation.Employee.ID = employee.ID;

                                annualLeaveCalculation.NumberOfDays = employee.AnnualLeaveEntitlement.NumberOfDays;
                                dal.Save(annualLeaveCalculation);
                                annualLeaveCalculation = new AnnualLeaveCalculation();

                                leaveBalanceMapper.Add(leaveBalance);
                            }
                            Clear();
                        }
                    }
                    else if (radioButtonBy.Checked == true)
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.AnnualLeaveEntitlementID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].ID,
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
                                UpdateAnnualLeaveCalculationsEntity();
                                employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
                                employee.LeaveArrears = (int)leaveBalanceMapper.getMyLeaveArrears(annualLeaveCalculation.Year, 12, employee.ID);

                                employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                                employee.AnnualLeaveYear = annualLeaveCalculation.Year;


                                employee.LeaveTaken = (int)leaveBalanceMapper.getLeaveTaken(annualLeaveCalculation.Year, DateTime.Now.Month, employee.ID);

                                employee.LeaveBalance = (employee.AnnualLeave + employee.LeaveArrears) - employee.LeaveTaken;

                                employee.AnnualLeaveProposedStartDate = null;
                                employee.AnnualLeaveProposedEndDate = null;
                                dal.Update(employee);


                                leaveBalance.leaveArrears = employee.LeaveArrears;
                                leaveBalance.leaveBalance = employee.LeaveBalance;
                                leaveBalance.AnnualLeaveYear = employee.AnnualLeaveYear;
                                leaveBalance.leaveTaken = employee.LeaveTaken;
                                leaveBalance.month = (DateTime.Now.Year == Convert.ToInt32(yearComboBox.Text)) ? DateTime.Now.Month : 1;
                                leaveBalance.employee = employee;
                                leaveBalance.leaveType = "Annual Leave";


                                annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                                annualLeaveCalculation.Employee.ID = employee.ID;
                                dal.Save(annualLeaveCalculation);
                                annualLeaveCalculation = new AnnualLeaveCalculation();

                                leaveBalanceMapper.Add(leaveBalance);
                            }
                            Clear();
                        }
                    }
                    else
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);

                        DALHelper dalHelper = new DALHelper();
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                        dalHelper.CreateParameter("@Year", int.Parse(yearComboBox.Text), DbType.Int32);
                        var dtEmpLeaveCalc = dalHelper.ExecuteReader("select * from AnnualLeaveCalculations where Year=@Year and StaffID=@StaffID");

                        if (employee.ID != 0)
                        {
                            UpdateAnnualLeaveCalculationsEntity();
                            employee.AnnualLeave = employee.AnnualLeaveEntitlement.NumberOfDays;
                            employee.LeaveArrears = (int)leaveBalanceMapper.getMyLeaveArrears(annualLeaveCalculation.Year, 12, employee.ID);

                            employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
                            employee.AnnualLeaveYear = annualLeaveCalculation.Year;
                            employee.AnnualLeaveProposedStartDate = null;
                            employee.AnnualLeaveProposedEndDate = null;

                            employee.LeaveTaken = (int)leaveBalanceMapper.getLeaveTaken(annualLeaveCalculation.Year, DateTime.Now.Month, employee.ID);
                            employee.LeaveBalance = (employee.AnnualLeave + employee.LeaveArrears) - employee.LeaveTaken;


                            dal.Update(employee);

                            leaveBalance.leaveArrears = employee.LeaveArrears;
                            leaveBalance.leaveBalance = employee.LeaveBalance;
                            leaveBalance.AnnualLeaveYear = employee.AnnualLeaveYear;
                            leaveBalance.leaveTaken = employee.LeaveTaken;
                            leaveBalance.month = (DateTime.Now.Year == Convert.ToInt32(yearComboBox.Text)) ? DateTime.Now.Month : 1;
                            leaveBalance.employee = employee;
                            leaveBalance.leaveType = "Annual Leave";

                            annualLeaveCalculation.Employee.StaffID = employee.StaffID;
                            annualLeaveCalculation.Employee.ID = employee.ID;
                            if (dtEmpLeaveCalc.Rows.Count == 0)
                            {
                                dal.Save(annualLeaveCalculation);
                                leaveBalanceMapper.Add(leaveBalance);
                            }

                            else
                            {
                                dalHelper.ClearParameters();
                                dalHelper.CreateParameter("@NumberOfDays", annualLeaveCalculation.NumberOfDays, DbType.Int32);

                                dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                dalHelper.CreateParameter("@Year", int.Parse(yearComboBox.Text), DbType.Int32);
                                dalHelper.ExecuteNonQuery("update AnnualLeaveCalculations set NumberOfDays=@NumberOfDays , isAll='false' where Year=@Year and StaffID=@StaffID");
                            }
                            Clear();
                        }
                    }
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not Saved Successfully,Please See the system Administrator");
            }
        }

        //private void btnCalculate_Click(object sender, EventArgs e)
        //{
        //    try
        //        {
        //        if (ValidateFields())
        //        {
        //            dal.BeginTransaction();
        //            if (radioButtonAll.Checked == true)
        //            {
        //                employees = dal.GetAll<Employee>();
        //                if (employees.Count > 0)
        //                {
        //                    foreach (Employee employee in employees)
        //                    {
        //                        var annualLeaveAlreadyCalculated = GlobalData._context.AnnualLeaveCalculations.FirstOrDefault(u => u.Year.ToString() == yearComboBox.Text && u.StaffID == employee.StaffID && u.Type.ToLower() == "increase");
        //                        if (annualLeaveAlreadyCalculated == null)
        //                        {
        //                            UpdateAnnualLeaveCalculationsEntity();
        //                            employee.AnnualLeave = employee.AnnualLeaveEntitlement.NumberOfDays;
        //                            if (checkBoxIsNewEngagement.Checked == true)
        //                            {
        //                                employee.LeaveArrears = 0;
        //                                employee.LeaveBalance = int.Parse(numericUpDownNumberOfDays.Value.ToString());
        //                            }
        //                            else
        //                            {
        //                                employee.LeaveArrears += employee.AnnualLeaveEntitlement.NumberOfDays - employee.LeaveTaken;
        //                                employee.LeaveBalance = employee.LeaveArrears;
        //                            }
        //                            employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
        //                            employee.AnnualLeaveYear = annualLeaveCalculation.Year;
        //                            employee.AnnualLeaveProposedStartDate = null;
        //                            employee.AnnualLeaveProposedEndDate = null;


        //                            dal.Update(employee);
        //                            annualLeaveCalculation.Employee.StaffID = employee.StaffID;
        //                            annualLeaveCalculation.Employee.ID = employee.ID;

        //                            annualLeaveCalculation.NumberOfDays = employee.AnnualLeaveEntitlement.NumberOfDays;
        //                            dal.Save(annualLeaveCalculation);
        //                            annualLeaveCalculation = new AnnualLeaveCalculation();
        //                        }
        //                    }
        //                    Clear();
        //                }
        //            }
        //            else if (radioButtonBy.Checked == true)
        //            {
        //                Query query = new Query();
        //                query.Criteria.Add(new Criterion()
        //                {
        //                    Property = "StaffPersonalInfoLazyLoadView.AnnualLeaveEntitlementID",
        //                    CriterionOperator = CriterionOperator.EqualTo,
        //                    Value = annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].ID,
        //                    CriteriaOperator = CriteriaOperator.And
        //                });
        //                query.Criteria.Add(new Criterion()
        //                {
        //                    Property = "StaffPersonalInfoLazyLoadView.Terminated",
        //                    CriterionOperator = CriterionOperator.EqualTo,
        //                    Value = false,
        //                    CriteriaOperator = CriteriaOperator.And
        //                });
        //                query.Criteria.Add(new Criterion()
        //                {
        //                    Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
        //                    CriterionOperator = CriterionOperator.EqualTo,
        //                    Value = false,
        //                    CriteriaOperator = CriteriaOperator.And
        //                });
        //                query.Criteria.Add(new Criterion()
        //                {
        //                    Property = "StaffPersonalInfoLazyLoadView.Confirmed",
        //                    CriterionOperator = CriterionOperator.EqualTo,
        //                    Value = true,
        //                    CriteriaOperator = CriteriaOperator.And
        //                });
        //                employees = dal.LazyLoadCriteria<Employee>(query);
        //                if (employees.Count > 0)
        //                {
        //                    foreach (Employee employee in employees)
        //                    {
        //                        var annualLeaveAlreadyCalculated = GlobalData._context.AnnualLeaveCalculations.FirstOrDefault(u => u.Year.ToString() == yearComboBox.Text && u.StaffID == employee.StaffID && u.Type.ToLower() == "increase");
        //                        if (annualLeaveAlreadyCalculated == null)
        //                        {
        //                            UpdateAnnualLeaveCalculationsEntity();
        //                            employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
        //                            employee.LeaveArrears = employee.AnnualLeaveEntitlement.NumberOfDays;
        //                            employee.LeaveBalance = employee.AnnualLeaveEntitlement.NumberOfDays;
        //                            employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
        //                            employee.AnnualLeaveYear = annualLeaveCalculation.Year;

        //                            employee.AnnualLeaveProposedStartDate = null;
        //                            employee.AnnualLeaveProposedEndDate = null;
        //                            dal.Update(employee);

        //                            annualLeaveCalculation.Employee.StaffID = employee.StaffID;
        //                            annualLeaveCalculation.Employee.ID = employee.ID;
        //                            dal.Save(annualLeaveCalculation);
        //                            annualLeaveCalculation = new AnnualLeaveCalculation();
        //                        }
        //                    }
        //                    Clear();
        //                }
        //            }
        //            else
        //            {
        //                employee.StaffID = staffIDtxt.Text.Trim();
        //                employee = dal.LazyLoadByStaffID<Employee>(employee);

        //                DALHelper dalHelper = new DALHelper();
        //                dalHelper.ClearParameters();
        //                dalHelper.CreateParameter("@StaffID",employee.StaffID,DbType.String);
        //                dalHelper.CreateParameter("@Year",int.Parse(yearComboBox.Text),DbType.Int32);
        //                var dtEmpLeaveCalc=dalHelper.ExecuteReader("select * from AnnualLeaveCalculations where Year=@Year and StaffID=@StaffID");

        //                if (employee.ID != 0)
        //                {
        //                    var annualLeaveAlreadyCalculated = GlobalData._context.AnnualLeaveCalculations.FirstOrDefault(u => u.Year.ToString() == yearComboBox.Text && u.StaffID == employee.StaffID && u.Type.ToLower() == "increase");
        //                    if (annualLeaveAlreadyCalculated == null)
        //                    {
        //                        UpdateAnnualLeaveCalculationsEntity();
        //                        if (checkBoxIsNewEngagement.Checked)
        //                        {
        //                            employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
        //                            employee.LeaveArrears = 0;
        //                            employee.LeaveBalance = 0;
        //                            employee.LeaveTaken = 0;
        //                            employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
        //                            employee.AnnualLeaveYear = annualLeaveCalculation.Year;
        //                            employee.AnnualLeaveProposedStartDate = null;
        //                            employee.AnnualLeaveProposedEndDate = null;
        //                            dal.Update(employee);

        //                            annualLeaveCalculation.Employee.StaffID = employee.StaffID;
        //                            annualLeaveCalculation.Employee.ID = employee.ID;
        //                            if (dtEmpLeaveCalc.Rows.Count == 0)
        //                                dal.Save(annualLeaveCalculation);
        //                            else
        //                            {
        //                                dalHelper.ClearParameters();
        //                                dalHelper.CreateParameter("@NumberOfDays", annualLeaveCalculation.NumberOfDays, DbType.Int32);

        //                                dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
        //                                dalHelper.CreateParameter("@Year", int.Parse(yearComboBox.Text), DbType.Int32);
        //                                dalHelper.ExecuteNonQuery("update AnnualLeaveCalculations set NumberOfDays=@NumberOfDays , isAll='false' where Year=@Year and StaffID=@StaffID");
        //                            }
        //                        }
        //                        else
        //                        {
        //                            employee.LeaveArrears += employee.AnnualLeave - employee.LeaveTaken;
        //                            employee.LeaveTaken = 0;
        //                            employee.LeaveBalance = employee.LeaveArrears;// this is accrued leave balance
        //                            employee.AnnualLeaveDate = annualLeaveCalculation.DateAndTimeGenerated.Value.Date;
        //                            employee.AnnualLeave = int.Parse(annualLeaveCalculation.NumberOfDays.ToString());
        //                            employee.AnnualLeaveYear = annualLeaveCalculation.Year;
        //                            employee.AnnualLeaveProposedStartDate = null;
        //                            employee.AnnualLeaveProposedEndDate = null;

        //                            dal.Update(employee);
        //                            annualLeaveCalculation.Employee.StaffID = employee.StaffID;
        //                            annualLeaveCalculation.Employee.ID = employee.ID;
        //                            if (dtEmpLeaveCalc.Rows.Count == 0)
        //                                dal.Save(annualLeaveCalculation);
        //                            else
        //                            {
        //                                dalHelper.ClearParameters();
        //                                dalHelper.CreateParameter("@NumberOfDays", annualLeaveCalculation.NumberOfDays, DbType.Int32);

        //                                dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
        //                                dalHelper.CreateParameter("@Year", int.Parse(yearComboBox.Text), DbType.Int32);
        //                                dalHelper.ExecuteNonQuery("update AnnualLeaveCalculations set NumberOfDays=@NumberOfDays , isAll='false' where Year=@Year and StaffID=@StaffID and Type='Increase'");
        //                            }
        //                        }

        //                    }




        //                    Clear();
        //                }
        //            }
        //            dal.CommitTransaction();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dal.RollBackTransaction();
        //        Logger.LogError(ex);
        //        MessageBox.Show("Error:Not Saved Successfully,Please See the system Administrator");
        //    }
        //}

        private void UpdateAnnualLeaveCalculationsEntity()
        {
            try
            {
                annualLeaveCalculation.ID = annualLeaveCalculationsID;
                annualLeaveCalculation.IsAll = radioButtonAll.Checked;
                annualLeaveCalculation.User.ID = GlobalData.User.ID;
                annualLeaveCalculation.NumberOfDays = numericUpDownNumberOfDays.Value;
                annualLeaveCalculation.Year = int.Parse(yearComboBox.Text.Trim());
                annualLeaveCalculation.Type = "Increase";

            }
            catch (Exception ex)
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
                if (yearComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(yearComboBox, "Please select the Year");
                    yearComboBox.Focus();
                }
                if (radioButtonIndividual.Checked == true && staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter StaffID");
                    staffIDtxt.Focus();
                }
                if (radioButtonBy.Checked == true && cboLeaveEntitlement.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboLeaveEntitlement, "Please Select Leave Entitlement");
                    cboLeaveEntitlement.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void AnnualCalculateLeaveForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnCalculate.Enabled = getPermissions.CanAdd;
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

        private void radioButtonIndividual_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonIndividual.Checked == true)
                {
                    groupBoxStaff.Visible = true;
                    cboLeaveEntitlement.Visible = false;
                    numericUpDownNumberOfDays.Visible = true;
                    lblDays.Visible = true;
                }
                else
                    checkBoxIsNewEngagement.Visible = true;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonAll.Checked == true)
                {
                    groupBoxStaff.Visible = false;
                    cboLeaveEntitlement.Visible = false;
                    numericUpDownNumberOfDays.Visible = false;
                    lblDays.Visible = false;
                    checkBoxIsNewEngagement.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLeaveEntitlement_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboLeaveEntitlement.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "AnnualLeaveEntitlementView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                annualLeaveEntitlements = dal.GetByCriteria<AnnualLeaveEntitlement>(query);
                foreach (AnnualLeaveEntitlement annualLeaveEntitlement in annualLeaveEntitlements)
                {
                    cboLeaveEntitlement.Items.Add(annualLeaveEntitlement.CategoryOfPost + " " +annualLeaveEntitlement.Status + " ("+annualLeaveEntitlement.NumberOfDays+")");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void radioButtonBy_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonBy.Checked == true)
                {
                    groupBoxStaff.Visible = false;
                    cboLeaveEntitlement.Visible = true;
                    numericUpDownNumberOfDays.Visible = true;
                    lblDays.Visible = true;
                    checkBoxIsNewEngagement.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLeaveEntitlement_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                numericUpDownNumberOfDays.Value = annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].NumberOfDays;
                numericUpDownNumberOfDays.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxIsNewEngagement_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsNewEngagement.Visible == true && staffIDtxt.Text != string.Empty)
            {
                if (checkBoxIsNewEngagement.Checked)
                {
                    numericUpDownNumberOfDays.Enabled = true;
                    int employmentDate = employee.EmploymentDate == null ? DateTime.Now.Month : employee.EmploymentDate.Value.Month;

                    if (employmentDate != 12)
                    {
                        decimal annualLeaveEntitlement = Convert.ToDecimal((13 - employmentDate) * (1.833333333333));
                        numericUpDownNumberOfDays.Value = Convert.ToInt32(annualLeaveEntitlement);
                    }
                }
                else
                    numericUpDownNumberOfDays.Enabled = false;
            }
        }
    }
}
