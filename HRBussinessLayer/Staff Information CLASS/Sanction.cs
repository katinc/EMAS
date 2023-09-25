using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Sanction
    {
        private int id;
        private Nullable<DateTime> sanctionDate;
        private Employee employee;
        private SanctionType sanctionType;
        private Nullable<DateTime> dateAndTimeGenerated;
        private string reason;
        private User user;
        private bool archived;
        private bool sanctioned;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;

        public Sanction()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.sanctionType = new SanctionType();
                this.sanctionDate = null;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.sanctioned = false;
                this.approved = false;
                this.approvedUser = string.Empty;
                this.approvedUserStaffID = string.Empty;
                this.approvedDate = null;
                this.approvedTime = null;
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

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public SanctionType SanctionType
        {
            get { return sanctionType; }
            set { sanctionType = value; }
        }

        public Nullable<DateTime> SanctionDate
        {
            get { return sanctionDate; }
            set { sanctionDate = value; }
        }

        public Nullable<DateTime> DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public bool Sanctioned
        {
            get { return sanctioned; }
            set { sanctioned = value; }
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
    }
}
