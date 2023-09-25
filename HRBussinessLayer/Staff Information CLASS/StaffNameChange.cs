using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffNameChange
    {
        private int id;
        private Employee employee;
        private string staffName;
        private Nullable<DateTime> date;
        private string firstNameFrom;
        private string surnameFrom;
        private string otherNameFrom;
        private string firstNameTo;
        private string surnameTo;
        private string otherNameTo;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;
        private DateTime dateAndTimeGenerated;
        private string reason;
        private string description;
        private bool archived;
        private User user;

        public StaffNameChange()
        {
            this.id = 0;
            this.employee = new Employee();
            this.staffName = string.Empty;
            this.date = null;
            this.description = string.Empty;
            this.reason = string.Empty;
            this.approved = false;
            this.approvedUser = string.Empty;
            this.approvedUserStaffID = string.Empty;
            this.approvedDate = null;
            this.approvedTime = null;
            this.dateAndTimeGenerated = DateTime.Now;
            this.archived = false;
            this.firstNameFrom = string.Empty;
            this.surnameFrom = string.Empty;
            this.otherNameFrom = string.Empty;
            this.firstNameTo = string.Empty;
            this.surnameTo = string.Empty;
            this.otherNameTo = string.Empty;
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

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; }
        }

        public string FirstNameFrom
        {
            get { return firstNameFrom; }
            set { firstNameFrom = value;}
        }

        public string SurnameFrom
        {
            get { return surnameFrom; }
            set { surnameFrom = value; }
        }

        public string OtherNameFrom
        {
            get { return otherNameFrom; }
            set { otherNameFrom = value; }
        }

        public string FirstNameTo
        {
            get { return firstNameTo; }
            set { firstNameTo = value; }
        }

        public string SurnameTo
        {
            get { return surnameTo; }
            set { surnameTo = value; }
        }

        public string OtherNameTo
        {
            get { return otherNameTo; }
            set { otherNameTo = value; }
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

        public string Description
        {
            get { return description; }
            set { description = value; }
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

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
