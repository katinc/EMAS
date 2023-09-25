using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Termination
    {
        private int id;
        private Employee employee;
        private string staffName;
        private Nullable<DateTime> terminationDate;
        private bool employeeNotified;
        private bool employerNotified;
        private string type;
        private SeparationType separationType;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;
        private string reason;
        private bool archived;
        private User user;

        public Termination()
        {
            this.id = 0;
            this.employee = new Employee();
            this.staffName = string.Empty;
            this.terminationDate = null;
            this.employerNotified = false;
            this.employeeNotified = false;
            this.type = string.Empty;
            this.reason = string.Empty;
            this.approved = false;
            this.approvedUser = string.Empty;
            this.approvedUserStaffID = string.Empty;
            this.approvedDate = null;
            this.approvedTime = null;
            this.archived = false;
            this.separationType = new SeparationType();
            this.user = new User();
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

        public Nullable<DateTime> TerminationDate
        {
            get { return terminationDate; }
            set { terminationDate = value; }
        }

        public bool EmployeeNoticed
        {
            get { return employeeNotified; }
            set 
            {
                employeeNotified = value;
            }
        }

        public bool EmployerNoticed
        {
            get { return employerNotified; }
            set 
            {
                    employerNotified = value;
            }
        }

        public string Type
        {
            get { return type; }
            set { type = value;}
        }

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public SeparationType SeparationType
        {
            get { return separationType; }
            set { separationType = value;}
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        public string ApprovedUser
        {
            get { return approvedUser; }
            set { approvedUser = value; }
        }

        public string ApprovedUserStaffID
        {
            get { return approvedUserStaffID; }
            set { approvedUserStaffID = value; }
        }

        public Nullable<DateTime> ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        public Nullable<DateTime> ApprovedTime
        {
            get { return approvedTime; }
            set { approvedTime = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
