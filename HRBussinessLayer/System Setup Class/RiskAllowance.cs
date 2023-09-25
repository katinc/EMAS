using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.System_Setup_Class
{
    public class RiskAllowance
    {
        public int ID { get; set; }
        public Employee Staff { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal RiskAllowanceRate { get; set; }
        public int DaysAbsent { get; set; }
        public decimal EarnedRiskAllowance { get; set; }
        public string Period { get; set; }
        public int Year { get; set; }
        public string PayFrequency { get; set; }

        public DateTime EntryDate { get; set; }
        public DateTime DateModified { get; set; }
        public User EnteredBy { get; set; }
        public string Department { get; set; }
    }
}
