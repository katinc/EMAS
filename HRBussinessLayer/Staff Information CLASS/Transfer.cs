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
    public class Transfer
    {
        private int id;
        private Employee employee;
        private string staffName;
        private Zone zone;
        private Department department;
        private Unit unit;
        private Nullable<DateTime> date;
        private string type;
        private string previousInstitution;
        private string previousStaffID;
        private string reason;
        private Nullable<DateTime> dateAndTimeGenerated;
        private User user;
        private bool archived;
        private bool transferred;


        public Transfer()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.staffName = string.Empty;
                this.zone = new Zone();
                this.department = new Department();
                this.unit = new Unit();
                this.date = DateTime.Today;
                this.type = string.Empty;
                this.previousInstitution = string.Empty;
                this.previousStaffID = string.Empty;
                this.reason = string.Empty;
                this.dateAndTimeGenerated = DateTime.Today;
                this.user = new User();
                this.archived = false;
                this.transferred = false;
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

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public Zone Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string PreviousInstitution
        {
            get { return previousInstitution; }
            set { previousInstitution = value; }
        }

        public string PreviousStaffID
        {
            get { return previousStaffID; }
            set { previousStaffID = value; }
        }

        public Nullable<DateTime> DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
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

        public bool Transferred
        {
            get { return transferred; }
            set { transferred = value; }
        }   
    }
}
