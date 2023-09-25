using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class StaffLoanPayment
    {
        private int id;
        private StaffLoan staffLoan;
        private Nullable<DateTime> paymentDate;
        private decimal amount;
        private bool archive;
        private bool notAffectSalary;
        private User user;

        public StaffLoanPayment()
        {
            try
            {
                this.id = 0;
                this.staffLoan = new StaffLoan();
                this.paymentDate = DateTime.Today;
                this.amount = 0;
                this.archive = false;
                this.notAffectSalary = false;
                this.user = new User();
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

        public Nullable<DateTime> PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public StaffLoan StaffLoan
        {
            get { return staffLoan; }
            set { staffLoan = value; }
        }

        public bool Archived
        {
            get { return archive; }
            set { archive = value; }
        }

        public bool NotAffectSalary
        {
            get { return notAffectSalary; }
            set { notAffectSalary = value; }
        }

        public User User
        {
            get { return user; }
            set { user=value; }
        }
    }
}
