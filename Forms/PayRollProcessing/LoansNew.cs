using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class Loans : Form
    {
        private IDAL dal;
        private Loan loan;
        private IList<Loan> loans;
        private IList<Employee> employees;
        private StaffLoan staffLoan;
        private IList<StaffLoan> staffLoans;
        private IList<StaffLoanPayment> staffLoanPayments;
        private Company company;
        private int ctr;
        private int staffCode;
        private int staffLoanID;
        private bool editMode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public Loans()
        {
            try
            {
                InitializeComponent();
                this.loan = new Loan();
                this.company = new Company();
                this.staffLoan = new StaffLoan();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.loans=new List<Loan>();
                this.staffLoanPayments=new List<StaffLoanPayment>();
                this.employees=new List<Employee>();
                this.staffLoans = new List<StaffLoan>();
                this.staffCode=0;
                this.staffLoanID = 0;
                this.editMode = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffLoan StaffLoan
        {
            set
            {
                staffLoanID = value.ID;
                txtStaffNo.Text = value.Employee.StaffID;
                staffCode = value.Employee.ID;
                txtStaffName.Text = value.StaffName;
                txtLoanDescription.Text = value.LoanDescription;
                txtLoanOrAdvanceAmount.Text = value.LoanAmount.ToString();
                txtInterestRate.Text = value.InterestRate.ToString();
                txtSpreadOver.Text = value.SpreadOver.ToString();
                dateFrom.Value = value.DateFrom.Value;
                dateTo.Value = value.DateTo.Value;
                txtLoanType_DropDown(this, EventArgs.Empty);
                txtLoanType.Text = value.Loan.Description;
                txtMonthlyInstallment.Text = value.MonthlyInstallment.ToString();
                txtInterest.Text = value.Interest.ToString();
                txtAmountToBePaid.Text = value.AmountToBePaid.ToString();
                dateLoanOrAdvance.Value = value.DateOfLoan.Value;
                grid.Visible = false;
                editMode = true;
                label3.Text = "Edit Staff Loans";
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                {
                    btnSave.Enabled = false;
                }
            }
        }

        void txtLoanType_DropDown(object sender, EventArgs e)
        {
            try
            {
                txtLoanType.DataSource = null;
                loans = dal.GetAll<Loan>();

                txtLoanType.DataSource = loans;
                txtLoanType.DisplayMember = "Description";
                txtLoanType.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridStaffSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    txtStaffNo.Text = grid.SelectedCells[1].Value.ToString();
                    txtStaffName.Text = grid.SelectedCells[0].Value.ToString();
                    staffCode = int.Parse(grid.SelectedCells[2].Value.ToString());
                    grid.Hide();
                    DisableBoxes(false);
                    txtLoanDescription.Select();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Loans_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                DisableBoxes(true);
                txtStaffNo.Select();
                this.Text = GlobalData.Caption;
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
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

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (txtStaffName.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtStaffName, "Please Enter Staff Name");
                    txtStaffName.Focus();
                }
                if (txtStaffNo.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtStaffNo, "Please Enter Staff No");
                    txtStaffNo.Focus();
                }
                if (txtLoanDescription.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtLoanDescription, "Please Enter Loan Description");
                    txtLoanDescription.Focus();
                }
                if (txtLoanType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtLoanType, "Please Select Loan Type");
                    txtLoanType.Focus();
                }
                if (txtLoanOrAdvanceAmount.Text.Trim() == string.Empty)
                {
                    result = false;
                    amountErrorProvider.SetError(txtLoanOrAdvanceAmount, "Please Enter Amount");
                    txtLoanOrAdvanceAmount.Focus();
                }
                if (!Validator.DecimalValidator(txtLoanOrAdvanceAmount.Text))
                {
                    result = false;
                    amountErrorProvider.SetError(txtLoanOrAdvanceAmount, "Please Enter a valid decimal as the amount");
                    txtLoanOrAdvanceAmount.Focus();
                }
                if (txtInterestRate.Text.Trim() == string.Empty)
                {
                    result = false;
                    amountErrorProvider.SetError(txtInterestRate, "Please Enter Interest Rate");
                    txtInterestRate.Focus();
                }
                if (!Validator.DecimalValidator(txtInterestRate.Text))
                {
                    result = false;
                    amountErrorProvider.SetError(txtInterestRate, "Enter a valid decimal as the Interest Rate");
                    txtInterestRate.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
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

        private void UpdateStaffLoanEntity(StaffLoan staffLoan)
        {
            try
            {
                staffLoan.Employee.StaffID = txtStaffNo.Text;
                staffLoan.Employee.ID = staffCode;
                staffLoan.StaffName = txtStaffName.Text; 
                staffLoan.LoanAmount = decimal.Parse(txtLoanOrAdvanceAmount.Text);
                staffLoan.InterestRate = decimal.Parse(txtInterestRate.Text);
                staffLoan.SpreadOver = int.Parse(txtSpreadOver.Text);
                staffLoan.DateFrom = DateTime.Parse(dateFrom.Value.ToShortDateString());
                staffLoan.DateTo = DateTime.Parse(dateTo.Value.ToShortDateString());
                staffLoan.MonthlyInstallment = decimal.Parse(txtMonthlyInstallment.Text);
                staffLoan.Interest = decimal.Parse(txtInterest.Text);
                staffLoan.AmountToBePaid = decimal.Parse(txtAmountToBePaid.Text);
                staffLoan.DateOfLoan = DateTime.Parse(dateLoanOrAdvance.Value.ToShortDateString());
                staffLoan.LoanDescription = txtLoanDescription.Text;
                staffLoan.Loan.ID = loans[txtLoanType.SelectedIndex].ID;
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
                staffErrorProvider.Clear();
                dateErrorProvider.Clear();
                amountErrorProvider.Clear();
                txtStaffNo.Clear();
                staffCode = 0;
                txtStaffName.Clear();
                txtLoanDescription.Clear();
                txtLoanType.Items.Clear();
                txtLoanType.Text = string.Empty;
                txtLoanOrAdvanceAmount.Clear();
                txtInterestRate.Clear();
                dateTo.ResetText();
                dateFrom.ResetText();
                txtMonthlyInstallment.Clear();
                txtInterest.Clear();
                txtAmountToBePaid.Clear();
                dateLoanOrAdvance.ResetText();
                DisableBoxes(true);
                txtSpreadOver.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                dal.CloseConnection();
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

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffNo.Text.Trim() != string.Empty)
                {
                    company = dal.LazyLoad<Company>()[0];
                    if (txtStaffNo.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        grid.Rows.Clear();
                        grid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffNo.Text.Trim() + '%',
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
                                if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    grid.Rows.Add(1);
                                    grid.Rows[ctr].Cells["gridName"].Value = name;
                                    grid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    grid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (grid.RowCount == 2)
                                {
                                    grid.Height = grid.RowCount * 24;
                                }
                                else
                                {
                                    grid.Height = grid.RowCount * 23;
                                }
                                grid.Location = new Point(txtStaffNo.Location.X, txtStaffNo.Location.Y + 21);
                                grid.BringToFront();
                                grid.Visible = true;
                            }
                            else
                            {
                                grid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffNo.Text + " is not Found");
                            txtStaffNo.Text = string.Empty;
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

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    grid.Rows.Clear();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();  
                    foreach (Employee employee in this.employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
                        {
                            found = true;
                            grid.Rows.Add(1);
                            grid.Rows[ctr].Cells["gridName"].Value = name;
                            grid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            grid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (grid.RowCount == 2)
                        {
                            grid.Height = grid.RowCount * 24;
                        }
                        else
                        {
                            grid.Height = grid.RowCount * 23;
                        }
                        grid.Location = new Point(108, 72);
                        grid.BringToFront();
                        grid.Visible = true;
                    }

                }
                else
                {
                    Clear();
                    grid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtLoanOrAdvanceAmount_TextChanged(object sender, EventArgs e)
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
                decimal interestRate = 0;
                decimal loanAmount = 0;
                decimal spreadOver = 1;
                if (Validator.DecimalValidator(txtInterestRate.Text))
                {
                    interestErrorProvider.Clear();
                    interestRate = decimal.Parse(txtInterestRate.Text);
                }
                else
                {
                    if (txtInterestRate.Text.Trim() != string.Empty)
                    {
                        interestErrorProvider.SetError(txtInterestRate, "Please enter a valid decimal as the interest rate");
                    }
                }
                if (Validator.DecimalValidator(txtLoanOrAdvanceAmount.Text))
                {
                    amountErrorProvider.Clear();
                    loanAmount = decimal.Parse(txtLoanOrAdvanceAmount.Text);
                }
                else
                {
                    if (txtLoanOrAdvanceAmount.Text.Trim() != string.Empty)
                    {
                        amountErrorProvider.SetError(txtLoanOrAdvanceAmount, "Please enter a valid amount as the loan amount");
                    }
                }
                if (dateTo.Value.Date >= dateFrom.Value.Date)
                {
                    dateErrorProvider.Clear();
                    decimal result = decimal.Parse((dateTo.Value.Subtract(dateFrom.Value).Days / 30).ToString());
                    spreadOver = (result == 0) ? 1 : (decimal.Ceiling(result) > 0 ? decimal.Ceiling(result) : -1 * decimal.Ceiling(result));
                }
                else
                {
                    dateErrorProvider.SetError(dateTo, "The end date must be greater than the start date");
                }

                decimal interest = (interestRate / 100) * loanAmount;
                txtSpreadOver.Text = spreadOver.ToString();
                txtAmountToBePaid.Text = decimal.Round((interest + loanAmount), 2).ToString();
                txtInterest.Text = decimal.Round(interest, 2).ToString();
                txtMonthlyInstallment.Text = decimal.Round(((interest + loanAmount) / spreadOver), 2).ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtInterestRate_TextChanged(object sender, EventArgs e)
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

        private void DisableBoxes(bool state)
        {
            try
            {
                //txtLoanDescription.ReadOnly = state;
                //txtLoanType.Enabled = !state;
                //txtLoanOrAdvanceAmount.ReadOnly = state;
                //txtInterestRate.ReadOnly = state;
                ////txtSpreadOver.ReadOnly = state;
                //dateTo.Enabled = !state;
                //dateFrom.Enabled = !state;
                //dateLoanOrAdvance.Enabled = !state;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
            try
            {
                LoansView viewForm = new LoansView(this);
                viewForm.removeButton.Enabled = CanDelete;
                viewForm.ShowDialog();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
