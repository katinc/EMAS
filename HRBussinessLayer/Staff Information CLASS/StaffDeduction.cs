using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffDeduction
    {
        private int id;
        private Employee employee;
        private User user;
        private bool inUse;
        private Deduction type;
        private string frequency;
        private decimal amount;
        private Nullable<DateTime> effectiveDate;
        private Nullable<DateTime> endDate;
        private bool isEndDate;
        private bool archived;
        

        public StaffDeduction()
        {
            this.id = 0;
            this.employee = new Employee();
            this.user = new User();
            this.type = new Deduction();
            this.frequency = string.Empty;
            this.amount = 0;
            this.effectiveDate = null;
            this.endDate = null;
            this.isEndDate = false;
            this.archived = false;
            this.inUse = true;
        }

        public StaffDeduction(int id, Employee employee, bool inUse, Deduction type, string frequency, decimal amount, Nullable<DateTime> effectiveDate, Nullable<DateTime> endDate, bool isEndDate)
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
            this.user = new User();
            this.archived = false;
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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public Deduction Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Frequency
        {
            get { return frequency; }
            set { frequency = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set 
            {
                    amount = value;
            }
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
