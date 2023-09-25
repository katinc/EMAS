using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class TaxableIncome
    {
        private int id;
        private int year;
        private string description;
        private decimal annualTaxableIncome;
        private decimal taxRate;
        private bool active;
        private User user;

        public TaxableIncome()
        {
            this.id = 0;
            this.year = 0;
            this.description = string.Empty;
            this.annualTaxableIncome = 0;
            this.taxRate = 0;
            this.active = false;
            this.user = new User();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal AnnualTaxableIncome
        {
            get { return annualTaxableIncome; }
            set { annualTaxableIncome = value; }
        }

        public decimal TaxRate
        {
            get { return taxRate; }
            set { taxRate = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
