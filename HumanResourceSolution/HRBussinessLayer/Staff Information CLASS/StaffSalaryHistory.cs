using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffSalaryHistory
    {
        private int id;
        private Employee employee;
        private string startTime;
        private string endTime;
        private DateTime startDate;
        private Nullable<DateTime> endDate;
        private EmployeeGrade  grade;
        private string  supervisor;
        private decimal monthlyBasicSalary;
        private decimal salaryEarned;
        private string paymentMode;
        private string paymentFrequency;
        private string paymentType;
        private bool inUse;
        private decimal hoursWorked;
        private Department  department;
        private Band band;
        private Step step;
        private int userID;
        private bool archived;

        public StaffSalaryHistory()
        {
            this.employee = new Employee();
            this.userID = 0;
            this.id = 0;
            this.startTime = string.Empty;
            this.endTime = string.Empty;
            this.startDate = Hospital.CurrentDate;
            this.endDate = null;
            this.grade = new EmployeeGrade() ;
            this.supervisor = string.Empty;
            this.monthlyBasicSalary = 0;
            this.salaryEarned = 0;
            this.paymentMode = string.Empty;
            this.inUse = false;
            this.hoursWorked = 0;
            this.department = new Department();
            this.paymentFrequency = string.Empty;
            this.paymentType = string.Empty;
            this.band = new Band();
            this.step = new Step();
            this.archived = false;
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

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public EmployeeGrade  Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string  Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        public decimal MonthlyBasicSalary
        {
            get { return monthlyBasicSalary; }
            set { monthlyBasicSalary = value; }
        }

        public decimal SalaryEarned
        {
            get { return salaryEarned; }
            set { salaryEarned = value; }
        }

        public string PaymentMode
        {
            get { return paymentMode; }
            set { paymentMode = value; }
        }

        public bool In_Use
        {
            get { return inUse; }
            set { inUse = value; }
        }

        public decimal HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public Department  Department
        {
            get { return department; }
            set { department = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public Nullable<DateTime> EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string PaymentFrequency
        {
            get { return paymentFrequency; }
            set { paymentFrequency = value; }
        }

        public string PaymentType
        {
            get { return paymentType; }
            set { paymentType = value; }
        }

        public Step Step
        {
            get { return step; }
            set { step = value; }
        }

        public Band Band
        {
            get { return band; }
            set { band = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
