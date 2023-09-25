using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Allowance
    {
        private int id;
        private string code;
        private EmployeeGrade level;
        private AllowanceCategory allowanceType;
        private AllowanceSubCategory allowanceCategory;
        private User user;
        private string description;
        private decimal amount;
        private bool inactive;
        private bool archived;

        public Allowance()
        {
            try
            {
                this.id = 0;
                this.code = string.Empty;
                this.allowanceType = new AllowanceCategory();
                this.allowanceCategory = new AllowanceSubCategory();
                this.level = new EmployeeGrade();
                this.user = new User();
                this.description = string.Empty;
                this.amount = 0;
                this.inactive = true;
                this.archived = false;
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

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public EmployeeGrade Level
        {
            get { return level; }
            set { level = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }

        }

        public AllowanceCategory AllowanceType
        {
            get { return allowanceType; }
            set { allowanceType = value; }
        }

        public AllowanceSubCategory AllowanceSubCategory
        {
            get { return allowanceCategory; }
            set { allowanceCategory = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set
            {
                if (Validator.DecimalValidator(value.ToString()))
                    amount = value;
                else
                    throw new Exception("Amount must be a Number");
            }
        }

        public bool InUse
        {
            get { return inactive; }
            set { inactive = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
