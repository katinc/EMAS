using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class Arrears
    {
        private int id;
        private Employee employee;
        private decimal previousSalary;
        private decimal currentSalary;
        private int numberOfTimes;
        private string type;
        private bool ssnit;
        private bool incomeTax;
        private Nullable<DateTime> effectiveDate;
        private DateTime dateAndTimeGenerated;
        private string reason;
        private User user;
        private bool archived;
        private bool in_Use;

        public Arrears()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.previousSalary = 0;
                this.currentSalary = 0;
                this.numberOfTimes = 0;
                this.type = string.Empty;
                this.ssnit = false;
                this.incomeTax = false;
                this.effectiveDate = null;
                this.dateAndTimeGenerated = DateTime.Now;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.in_Use = false;
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

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public decimal PreviousSalary
        {
            get { return previousSalary; }
            set { previousSalary = value; }
        }

        public decimal CurrentSalary
        {
            get { return currentSalary; }
            set { currentSalary = value; }
        }

        public int NumberOfTimes
        {
            get { return numberOfTimes; }
            set { numberOfTimes = value; }
        }

        public string Type
        {
            get { return type ; }
            set { type  = value; }
        }

        public bool SSNIT
        {
            get { return ssnit; }
            set { ssnit = value; }
        }

        public bool IncomeTax
        {
            get { return incomeTax; }
            set { incomeTax = value; }
        }

        public Nullable<DateTime> EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public bool In_Use
        {
            get { return in_Use; }
            set { in_Use = value; }
        }
    }
}
