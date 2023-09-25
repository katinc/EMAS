using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class WorkExperience
    {
        private int id;
        private Employee employee;
        private DateTime dateAndTimeGenerated;
        private User user;
        private string nameOfOrganisation;
        private string jobTitle;
        private decimal annualSalary;
        private string fromYear;
        private string fromMonth;
        private string toYear;
        private string toMonth;
        private string reasonForLeaving;
        private bool archived;

        public WorkExperience()
        {
            try
            {
                this.id = 0;
                this.annualSalary = 0;
                this.nameOfOrganisation = string.Empty;
                this.jobTitle = string.Empty;
                this.annualSalary = 0;
                this.fromYear = string.Empty;
                this.toYear = string.Empty;
                this.fromMonth = string.Empty;
                this.toMonth = string.Empty;
                this.user = new User();
                this.employee = new Employee();
                this.archived = false;
                this.reasonForLeaving = string.Empty;
                this.dateAndTimeGenerated = DateTime.Now;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public WorkExperience(int id, string nameOfOrganisation, string jobTitle,decimal annualSalary, string fromMonth, string fromYear, string toYear, string toMonth, string reasonForLeaving, DateTime dateAndTimeGenerated, bool archived)
        {
            try
            {
                this.id = id;
                this.nameOfOrganisation = nameOfOrganisation;
                this.jobTitle = jobTitle;
                this.annualSalary = annualSalary;
                this.fromYear = fromYear;
                this.fromMonth = fromMonth;
                this.toYear = toYear;
                this.toMonth = toMonth;
                this.dateAndTimeGenerated = dateAndTimeGenerated;
                this.archived = archived;
                this.reasonForLeaving = reasonForLeaving;
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

        public string NameOfOrganisation
        {
            get { return nameOfOrganisation; }
            set { nameOfOrganisation = value; }
        }

        public decimal AnnualSalary
        {
            get { return annualSalary; }
            set { annualSalary = value; }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public string FromYear
        {
            get { return fromYear; }
            set { fromYear = value; }
        }

        public string ToYear
        {
            get { return toYear; }
            set { toYear = value; }
        }

        public string FromMonth
        {
            get { return fromMonth; }
            set { fromMonth = value; }
        }

        public string ToMonth
        {
            get { return toMonth; }
            set { toMonth = value; }
        }

        public string ReasonForLeaving
        {
            get { return reasonForLeaving; }
            set { reasonForLeaving = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
