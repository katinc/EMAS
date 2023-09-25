using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffLeaveRoaster
    {
        private int id;
        private Employee employee;
        private string staffName;
        private string leaveType;
        private string status;
        private DateTime startDate;
        private DateTime endDate;
        private DateTime leaveDate;
        private DateTime dateAndTimeGenerated;
        private string reason;
        private decimal numberOfDays;
        private User user;
        private bool archived;


        public StaffLeaveRoaster()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.staffName = string.Empty;
                this.leaveType = string.Empty;
                this.status = string.Empty;
                this.startDate = Hospital.CurrentDate;
                this.endDate = Hospital.CurrentDate;
                this.leaveDate = Hospital.CurrentDate;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.numberOfDays = 0;
                this.user = new User();
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

        public decimal NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
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

        public DateTime LeaveDate
        {
            get { return leaveDate; }
            set { leaveDate = value; }
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

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
