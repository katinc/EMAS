using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class SalaryAdvance : Form
    {
        private Employee employee;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private Company company;
        private IDAL dal;
        private bool editMode;
        private int ctr;
        private int staffCode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;
        private StaffLoan staffLoan;
        private int staffLoanID;
        private IList<StaffLoanPayment> staffLoanPayments;




        public SalaryAdvance()
        {
            InitializeComponent();
            this.company = new Company();
            this.employee = new Employee();
            this.staffLoan = new StaffLoan();
            this.dal = new DAL();
            this.dal.OpenConnection();
            this.editMode = false;
            this.ctr = 0;
            this.staffCode = 0;
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();
            this.company = new Company();
            this.staffLoanID = 0;
            this.staffLoanPayments = new List<StaffLoanPayment>();


        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcIntrestRate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcIntrestRate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void CalcIntrestRate()
        {
            try
            {
                decimal loanAmount = 0;
                decimal spreadOver = 1;
                
                if (Validator.DecimalValidator(numericUpDownAmount.Text))
                {
                    amountErrorProvider.Clear();
                    loanAmount = decimal.Parse(numericUpDownAmount.Text);
                }
                else
                {
                    if (numericUpDownAmount.Text.Trim() != string.Empty)
                    {
                        amountErrorProvider.SetError(numericUpDownAmount, "Please enter a valid amount as the loan amount");
                    }
                }
                if (dateTo.Value.Date >= dateFrom.Value.Date)
                {
                    dateErrorProvider.Clear();
                    decimal result = decimal.Parse((dateTo.Value.Subtract(dateFrom.Value).Days / 30).ToString());
                    if (result > 12)
                    {
                        dateTo.Value = DateTime.Today;
                        dateErrorProvider.SetError(dateTo, "Max number of months for payment is 12");
                    }
                    else
                    {
                        spreadOver = (result == 0) ? 1 : (decimal.Ceiling(result) > 0 ? decimal.Ceiling(result) : -1 * decimal.Ceiling(result));
                    }

                }
                else
                {
                    dateErrorProvider.SetError(dateTo, "The end date must be greater than the start date");
                }
                txtMonths.Text = spreadOver.ToString();
                txtMonthlyDeduction.Text = decimal.Round(((loanAmount) / spreadOver), 2).ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void SalaryAdvance_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                staffIDtxt.Select();
                this.Text = GlobalData.Caption;
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    btnView.Enabled = getPermissions.CanView;
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

        private void Clear()
        {
            try
            {
                ClearStaffInfo();
                searchGrid.Visible = false;
                editMode = false;
                numericUpDownAmount.Value = 0;
                staffErrorProvider.Clear();
                dateFrom.Value = DateTime.Today;
                dateTo.Value = DateTime.Today;
                txtMonthlyDeduction.Clear();
                txtMonths.Clear();
                dateLoanOrAdvance.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaffInfo()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                groupBox1.Enabled = false;
                staffIDtxt.Select();
                txtBasicSalary.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Clear();
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            txtBasicSalary.Text = employee.BasicSalary.ToString();
                            departmentTextBox.Text = employee.Department.Description;
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            
                            btnPreView_Click(sender, e);
                        }
                    }
                }
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

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    ctr = 0;
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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
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

        private void closebtn_Click(object sender, EventArgs e)
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

        private void btnPreView_Click(object sender, EventArgs e)
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

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalcIntrestRate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (nametxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(nametxt, "Please Enter Staff Name");
                    nametxt.Focus();
                }
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter Staff No");
                    staffIDtxt.Focus();
                }
                if (numericUpDownAmount.Value == 0)
                {
                    result = false;
                    amountErrorProvider.SetError(numericUpDownAmount, "Please Enter Amount");
                    numericUpDownAmount.Focus();
                }
                if (dateFrom.Value.ToString() == string.Empty)
                {
                    result = false;
                    dateErrorProvider.SetError(dateFrom, "Select Date From");
                    dateFrom.Focus();
                }
                if (dateTo.Value.ToString() == string.Empty)
                {
                    result = false;
                    dateErrorProvider.SetError(dateTo, "Select Date To");
                    dateTo.Focus();
                }
                if (dateFrom.Value.Date > dateTo.Value.Date)
                {
                    result = false;
                    dateErrorProvider.SetError(dateFrom, "Date From cannot be greater than Date To");
                    dateFrom.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void UpdateStaffLoanEntity(StaffLoan staffLoan)
        {
            try
            {
                staffLoan.Employee.StaffID = staffIDtxt.Text;
                staffLoan.Employee.ID = staffCode;
                staffLoan.StaffName = nametxt.Text;
                staffLoan.LoanAmount = decimal.Parse(numericUpDownAmount.Text);
                staffLoan.InterestRate = 0;
                staffLoan.SpreadOver = int.Parse(txtMonths.Text);
                staffLoan.DateFrom = DateTime.Parse(dateFrom.Value.ToShortDateString());
                staffLoan.DateTo = DateTime.Parse(dateTo.Value.ToShortDateString());
                staffLoan.MonthlyInstallment = decimal.Parse(txtMonthlyDeduction.Text);
                staffLoan.Interest = 0;
                staffLoan.AmountToBePaid = decimal.Parse(numericUpDownAmount.Text);
                staffLoan.DateOfLoan = DateTime.Parse(dateLoanOrAdvance.Value.ToShortDateString());
                staffLoan.LoanDescription = "SALARY ADVANCE";
                staffLoan.Loan.ID = 108;
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
                if (ValidateFields())
                {
                    UpdateStaffLoanEntity(staffLoan);
                    if (editMode)
                    {
                        staffLoan.ID = staffLoanID;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffLoanPaymentView.StaffLoanID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = staffLoan.ID,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffLoanPayments = dal.GetByCriteria<StaffLoanPayment>(query);
                        if (staffLoanPayments.Count <= 0)
                        {
                            staffLoan.User.ID = GlobalData.User.ID;
                            dal.Update(staffLoan);
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("The Staff has already started payments");
                        }
                    }
                    else
                    {
                        staffLoan.User.ID = GlobalData.User.ID;
                        dal.Save(staffLoan);
                        Clear();
                    }
                }
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
                LoansView viewForm = new LoansView(this, "SALARY ADVANCE");
                viewForm.removeButton.Enabled = CanDelete;
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffLoan StaffLoan
        {
            set
            {
                staffLoanID = value.ID;
                staffIDtxt.Text = value.Employee.StaffID;
                staffCode = value.Employee.ID;
                nametxt.Text = value.StaffName;
                departmentTextBox.Text = value.Employee.Department.Description.ToString();
                gendertxt.Text = value.Employee.Gender.ToString();
                txtBasicSalary.Text = value.Employee.BasicSalary.ToString();
                agetxt.Text = value.Employee.Age.ToString();
                numericUpDownAmount.Value = Convert.ToDecimal(value.LoanAmount.ToString());
                txtMonths.Text = value.SpreadOver.ToString();
                dateFrom.Value = value.DateFrom.Value;
                dateTo.Value = value.DateTo.Value;
                txtMonthlyDeduction.Text = value.MonthlyInstallment.ToString();
                dateLoanOrAdvance.Value = value.DateOfLoan.Value;
                searchGrid.Visible = false;
                editMode = true;
                label1.Text = "Edit Salary Advance";
                groupBox1.Enabled = true;
                dateLoanOrAdvance.Enabled = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
        }
    }
}
