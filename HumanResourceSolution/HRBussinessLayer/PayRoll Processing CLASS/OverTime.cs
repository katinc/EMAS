using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class OverTime
    {
        private int id;
        private Employee employee;
        private string staffName;
        private GradeCategory gradeCategory;
        private EmployeeGrade grade;
        private decimal basicSalary;
        private decimal hrsWorked;
        private decimal amount;
        private decimal overTimeRate;
        private int totalShifts;
        private OverTimeType overTimeType;
        private Nullable<DateTime> holiday;
        private Nullable<DateTime> date;
        private DateTime dateAndTimeGenerated;
        private string reason;
        private User user;
        private bool archived;
        private int archiverID;
        private Nullable<DateTime> archivedTime;
        private bool in_Use;
        private bool isTaxable;
        
        public OverTime()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.staffName = string.Empty;
                this.gradeCategory = new GradeCategory();
                this.grade = new EmployeeGrade();
                this.hrsWorked = 0;
                this.basicSalary = 0;
                this.amount = 0;
                this.overTimeRate = 0;
                this.totalShifts = 0;
                this.overTimeType = new OverTimeType();
                this.date = null;
                this.holiday = null;
                this.dateAndTimeGenerated = DateTime.Now;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.in_Use = false;
                this.isTaxable = false;
                this.archivedTime = null;
                this.archiverID = 0;
            }
            catch (Exception ex)
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

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public decimal HrsWorked
        {
            get { return hrsWorked; }
            set { hrsWorked = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public decimal OverTimeRate
        {
            get { return overTimeRate; }
            set { overTimeRate = value; }
        }

        public int TotalShifts
        {
            get { return totalShifts; }
            set { totalShifts = value; }
        }

        public OverTimeType OverTimeType
        {
            get { return overTimeType; }
            set { overTimeType = value; }
        }

        public Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; }
        }

        public Nullable<DateTime> Holiday
        {
            get { return holiday; }
            set { holiday = value; }
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

        public Nullable<DateTime> ArchivedTime
        {
            get { return archivedTime; }
            set { archivedTime = value; }
        }

        public int ArchiverID
        {
            get { return archiverID; }
            set { archiverID = value; }
        }

        public bool In_Use
        {
            get { return in_Use; }
            set { in_Use = value; }
        }

        public bool IsTaxable
        {
            get { return isTaxable; }
            set { isTaxable = value; }
        }
    }
}
