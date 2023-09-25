using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class AllowanceAndDeductionSummary
    {
        private DateTime startDate;
        private DateTime endDate;
        private IList<StaffAllowance> allowances;
        private IList<StaffDeduction> deductions;
        
        public AllowanceAndDeductionSummary()
        {
            allowances = new List<StaffAllowance>();
            deductions = new List<StaffDeduction>();
        }
        public AllowanceAndDeductionSummary(IList<StaffAllowance> allowances, IList<StaffDeduction> deductions,DateTime startDate, DateTime endDate)
        {
            this.allowances = allowances;
            this.deductions = deductions;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        public IList<StaffAllowance> Allowances
        {
            get { return allowances; }
            set { allowances = value; }
        }
        public IList<StaffDeduction> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
    }
}
