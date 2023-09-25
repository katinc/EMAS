using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class StaffLoan
    {
        private int id;
        private Employee employee;
        private string loanDescription;
        private Loan loan;
        private decimal loanAmount;
        private decimal interestRate;
        private int spreadOver;
        private Nullable<DateTime> dateFrom;
        private Nullable<DateTime> dateTo;
        private decimal monthlyInstallment;
        private decimal interest;
        private decimal amountToBePaid;
        private Nullable<DateTime> dateOfLoan;
        private string staffName;
        private bool archived;
        private IList<StaffLoanPayment> staffLoanPayments;
        private bool notAffectSalary;
        private User user;
        private int count;

        public StaffLoan()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.loanDescription = string.Empty;
                this.loan = new Loan();
                this.loanAmount = 0;
                this.interestRate = 0;
                this.spreadOver = 0;
                this.dateFrom = DateTime.Today;
                this.dateTo = DateTime.Today;
                this.monthlyInstallment = 0;
                this.interest = 0;
                this.amountToBePaid = 0;
                this.dateOfLoan = DateTime.Today; ;
                this.staffName = string.Empty;
                this.archived = false;
                this.staffLoanPayments = new List<StaffLoanPayment>();
                this.notAffectSalary = false;
                this.user = new User();
                this.count = 1;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public bool NotAffectSalary
        {
            get { return notAffectSalary; }
            set { notAffectSalary = value; }
        }
        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }
        public string LoanDescription
        {
            get { return loanDescription; }
            set { loanDescription = value; }
        }

        public Loan Loan
        {
            get { return loan; }
            set { loan = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public decimal LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value;}
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value;}
        }

        public int SpreadOver
        {
            get { return spreadOver; }
            set { spreadOver = value; }
        }

        public Nullable<DateTime> DateFrom
        {
            get { return dateFrom; }
            set { dateFrom = value; }
        }

        public Nullable<DateTime> DateTo
        {
            get { return dateTo; }
            set { dateTo = value; }
        }

        public decimal MonthlyInstallment
        {
            get { return monthlyInstallment; }
            set { monthlyInstallment = value;}
        }

        public decimal Interest
        {
            get { return interest; }
            set { interest = value;}
        }

        public decimal AmountToBePaid
        {
            get { return amountToBePaid; }
            set { amountToBePaid = value;}
        }

        public Nullable<DateTime> DateOfLoan
        {
            get { return dateOfLoan; }
            set { dateOfLoan = value; }
        }

        public IList<StaffLoanPayment> Payments
        {
            get { return staffLoanPayments; }
            set { staffLoanPayments = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

    }
}
