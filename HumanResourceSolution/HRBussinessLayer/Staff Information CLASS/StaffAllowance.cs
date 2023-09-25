using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffAllowance
    {
        private Employee employee;
        private bool inUse;
        private Allowance type;
        private User user;
        private string frequency;
        private Nullable<DateTime> effectiveDate;
        private Nullable<DateTime> endDate;
        private bool isEndDate;
        private decimal amount;
        private int id;
        private bool archived;

        public StaffAllowance()
        {
            try
            {
                this.employee = new Employee();
                this.id = 0;
                this.inUse = false;
                this.type = new Allowance();
                this.frequency = string.Empty;
                this.effectiveDate = null;
                this.endDate = null;
                this.isEndDate = false;
                this.amount = 0;
                this.archived = false;
                this.user = new User();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffAllowance(int id, Employee employee, bool inUse, Allowance type, string frequency, decimal amount, Nullable<DateTime> effectiveDate, Nullable<DateTime> endDate, bool isEndDate)
        {
            try
            {
                this.employee = employee;
                this.id = id;
                this.inUse = inUse;
                this.type = type;
                this.frequency = frequency;
                this.amount = amount;
                this.effectiveDate = effectiveDate;
                this.endDate = endDate;
                this.isEndDate = isEndDate;
                this.archived = false;
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

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public Allowance Type
        {
            get { return type; }
            set { type = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public Nullable<DateTime> EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public Nullable<DateTime> EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool IsEndDate
        {
            get { return isEndDate; }
            set { isEndDate = value; }
        }

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
