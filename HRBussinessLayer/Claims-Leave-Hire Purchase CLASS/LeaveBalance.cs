using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class LeaveBalance
    {
        public int ID { get; set; }
        public Employee employee { get; set; }
        public string leaveType { get; set; }
        public decimal leaveTaken { get; set; }
        public int month { get; set; }
        public int AnnualLeaveYear { get; set; }
        public decimal leaveArrears { get; set; }
        public decimal leaveBalance { get; set; }
        public int AnnualLeave { get; set; }

    }
}
