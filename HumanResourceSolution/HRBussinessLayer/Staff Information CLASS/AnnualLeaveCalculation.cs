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
    public class AnnualLeaveCalculation
    {
        private int id;
        private Employee employee;
        private int year;
        private decimal numberOfDays;
        private Nullable<DateTime> dateAndTimeGenerated;
        private User user;
        private bool archived;
        private bool isAll;
        private string type;

        public AnnualLeaveCalculation()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.year = 0 ;
                this.numberOfDays = 0;
                this.dateAndTimeGenerated = DateTime.Today;
                this.user = new User();
                this.archived = false;
                this.isAll = false;
                this.type = string.Empty;
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

        public Nullable<DateTime> DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public decimal NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
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

        public bool IsAll
        {
            get { return isAll; }
            set { isAll = value; }
        }   
    }
}
