using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Deduction
    {
        private int id;
        private string code;
        private DeductionSubCategory type;
        private decimal rate;
        private string description;
        private SalaryType calculatedOn;
        private bool inActive;
        private decimal amount;
        private bool rateBased;
        private bool reportInclusive;
        private User user;

        public Deduction()
        {
            try
            {
                this.id = 0;
                this.code = string.Empty;
                this.type = new DeductionSubCategory();
                this.rate = 0;
                this.description = string.Empty;
                this.calculatedOn = new SalaryType();
                this.inActive = false;
                this.rateBased = true;
                this.amount = 0;
                this.reportInclusive = false;
                this.user = new User();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public DeductionSubCategory Type
        {
             get { return type; }
            set { type = value; }
        }

        public decimal Rate
        {
            get { return rate; }
            set 
            {
                    rate = value;
            }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public SalaryType CalculatedOn
        {
            get { return calculatedOn; }
            set { calculatedOn = value; }
        }

        public bool Inactive
        {
            get { return inActive; }
            set { inActive = value; }
        }

        public bool RateBased
        {
            get { return rateBased; }
            set { rateBased = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool ReportInclusive
        {
            get { return reportInclusive; }
            set { reportInclusive = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
