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
    public class Confirmation
    {
        private int id;
        private Nullable<DateTime> confirmationDate;
        private Employee employee;
        private Nullable<DateTime> dateAndTimeGenerated;
        private string reason;
        private User user;
        private bool archived;
        private bool confirmed;

        public Confirmation()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.confirmationDate = null;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.confirmed = false;
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

        public Nullable<DateTime> ConfirmationDate
        {
            get { return confirmationDate; }
            set { confirmationDate = value; }
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

        public bool Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }   
    }
}
