using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class SalaryGrade
    {
        public SalaryGrade(string grade_Code, string description,string salary,string pay_Period, string effectiveDate, string in_use)
        {
            this.grade_Code = grade_Code;
            this.description = description;
            this.salary = salary;
            this.pay_Period = pay_Period;
            this.effectiveDate = effectiveDate;
            this.in_use = in_use;
        }

        public SalaryGrade(string grade_Code, string description, string effectiveDate, string in_use)
        {
            this.grade_Code = grade_Code;
            this.description = description;
            this.effectiveDate = effectiveDate;
            this.in_use = in_use;
        }

        public SalaryGrade()
        {
        }

        private string grade_Code;
        private string description;
        private string salary;
        private string pay_Period;
        private string effectiveDate;
        private string in_use;

        public string Grade_Code
        {
            get { return grade_Code; }
            set { grade_Code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Salary
        {
            get { return salary; }
            set
            {
                    salary = value;
            }
        }

        public string Pay_Period
        {
            get { return pay_Period; }
            set { pay_Period = value; }
        }

        public string EffectiveDate
        {
            get { return effectiveDate; }
            set { effectiveDate = value; }
        }

        public string In_Use
        {
            get { return in_use; }
            set { in_use = value; }
        }
    }
}
