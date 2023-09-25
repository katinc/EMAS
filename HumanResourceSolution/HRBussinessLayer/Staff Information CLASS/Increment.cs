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
    public class Increment
    {
        private int id;
        private Nullable<DateTime> incrementDate;
        private Employee employee;
        private GradeCategory gradeCategory;
        private EmployeeGrade grade;
        private bool isPercentage;
        private decimal increase;
        private Nullable<DateTime> dateAndTimeGenerated;
        private string reason;
        private User user;
        private bool archived;
        private string incrementType;

        public Increment()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.incrementDate = null;
                this.gradeCategory = new GradeCategory();
                this.grade = new EmployeeGrade();
                this.isPercentage = false;
                this.increase = 0;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.incrementType = string.Empty;
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

        public Nullable<DateTime> IncrementDate
        {
            get { return incrementDate; }
            set { incrementDate = value; }
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

        public bool IsPercentage
        {
            get { return isPercentage; }
            set { isPercentage = value; }
        }

        public decimal Increase
        {
            get { return increase; }
            set { increase = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public EmployeeGrade Grade
        {
            get { return grade; }
            set { grade = value; }
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

        public string IncrementType
        {
            get { return incrementType; }
            set { incrementType = value; }
        }   
    }
}
