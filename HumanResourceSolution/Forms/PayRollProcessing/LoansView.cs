using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class LoansView : Form
    {
        private IDAL dal;
        private Loans newForm;
        private StaffLoan loan;
        private StaffLoanPayment loanPayment;
        private IList<StaffLoan> loans;
        private IList<StaffLoanPayment> loanPayments;

        public LoansView()
        {
            try
            {
                InitializeComponent();
                this.newForm = new Loans();
                this.dal = new DAL();
                this.loan = new StaffLoan();
                this.loanPayment = new StaffLoanPayment();
                this.loans = new List<StaffLoan>();
                this.loanPayments = new List<StaffLoanPayment>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public LoansView(Loans newForm)
        {
            try
            {
                InitializeComponent();
                this.newForm = newForm;               
                this.dal = new DAL();
                this.loan = new StaffLoan();
                this.loanPayment = new StaffLoanPayment();
                this.loans=new List<StaffLoan>();
                this.loanPayments=new List<StaffLoanPayment>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    loan.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    loan.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    loan.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    loan.LoanDescription = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                    loan.Loan.ID = int.Parse(grid.CurrentRow.Cells["gridLoanID"].Value.ToString());
                    loan.Loan.Description = grid.CurrentRow.Cells["gridLoan"].Value.ToString();
                    loan.LoanAmount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    loan.AmountToBePaid = decimal.Parse(grid.CurrentRow.Cells["gridAmountToBePaid"].Value.ToString());
                    loan.InterestRate = decimal.Parse(grid.CurrentRow.Cells["gridInterestRate"].Value.ToString());
                    loan.SpreadOver = int.Parse(grid.CurrentRow.Cells["gridSpreadOver"].Value.ToString());
                    loan.Interest = decimal.Parse(grid.CurrentRow.Cells["gridInterest"].Value.ToString());
                    loan.MonthlyInstallment = decimal.Parse(grid.CurrentRow.Cells["gridMonthlyInstallment"].Value.ToString());
                    loan.DateFrom = DateTime.Parse(grid.CurrentRow.Cells["gridDateFrom"].Value.ToString());
                    loan.DateTo = DateTime.Parse(grid.CurrentRow.Cells["gridDateTo"].Value.ToString());
                    loan.DateOfLoan = DateTime.Parse(grid.CurrentRow.Cells["gridDateOfLoan"].Value.ToString());
                    loan.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    newForm.StaffLoan = loan;
                    newForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void UpdateGrid()
        {
            try
            {
                grid.Rows.Clear();
                int ctr = 0;
                foreach (StaffLoan loan in loans)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = loan.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = loan.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = loan.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = loan.StaffName;
                    grid.Rows[ctr].Cells["gridDescription"].Value = loan.LoanDescription;
                    grid.Rows[ctr].Cells["gridLoanID"].Value = loan.Loan.ID;
                    grid.Rows[ctr].Cells["gridLoan"].Value = loan.Loan.Description;
                    grid.Rows[ctr].Cells["gridAmount"].Value = loan.LoanAmount;
                    grid.Rows[ctr].Cells["gridInterestRate"].Value = loan.InterestRate;
                    grid.Rows[ctr].Cells["gridSpreadOver"].Value = loan.SpreadOver;
                    grid.Rows[ctr].Cells["gridDateFrom"].Value = loan.DateFrom;
                    grid.Rows[ctr].Cells["gridDateTo"].Value = loan.DateTo;
                    grid.Rows[ctr].Cells["gridMonthlyInstallment"].Value = loan.MonthlyInstallment;
                    grid.Rows[ctr].Cells["gridInterest"].Value = loan.Interest;
                    grid.Rows[ctr].Cells["gridAmountToBePaid"].Value = loan.AmountToBePaid;
                    grid.Rows[ctr].Cells["gridDateOfLoan"].Value = loan.DateOfLoan;
                    grid.Rows[ctr].Cells["gridUserID"].Value = loan.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void LoansView_Load(object sender, EventArgs e)
        {
            try
            {
                loans = dal.GetAll<StaffLoan>();
                UpdateGrid();
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s selected loan information?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(loan);
                                loanPayment.StaffLoan.ID = loan.ID;
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffLoanPaymentView.StaffLoanID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = loan.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                loanPayments = dal.GetByCriteria<StaffLoanPayment>(query);
                                foreach (StaffLoanPayment loanPay in loanPayments)
                                {
                                    dal.Delete(loanPay);
                                }
                                dal.CommitTransaction();
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                loan.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(loan);
                                loanPayment.StaffLoan.ID = loan.ID;
                                Query query = new Query();
                                query.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffLoanPaymentView.StaffLoanID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = loan.ID,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                loanPayments = dal.GetByCriteria<StaffLoanPayment>(query);
                                foreach (StaffLoanPayment loanPay in loanPayments)
                                {
                                    dal.Delete(loanPay);
                                }
                                dal.CommitTransaction();
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
            }
        }
    }
}
