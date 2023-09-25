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
    public class ChartOfAccountMapping
    {
        private int id;
        private GradeCategory gradeCategory;
        private string accountCode;
        private string accountDescription;
        private string report;
        private string accountHeader;
        private string query;
        private string type;
        private ChartOfAccountType chartOfAccountType;
        private Nullable<DateTime> date;
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool active;
        private bool archived;

        public ChartOfAccountMapping()
        {
            try
            {
                this.id = 0;
                this.accountCode = string.Empty;
                this.accountDescription = string.Empty;
                this.accountHeader = string.Empty;
                this.report = string.Empty;
                this.query = string.Empty;
                this.type = string.Empty;
                this.gradeCategory = new GradeCategory();
                this.chartOfAccountType = new ChartOfAccountType();
                this.date = null;
                this.dateAndTimeGenerated = DateTime.Now;
                this.user = new User();
                this.active = false;
                this.archived = false;
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

        public string AccountCode
        {
            get { return accountCode; }
            set { accountCode = value; }
        }

        public string AccountDescription
        {
            get { return accountDescription; }
            set { accountDescription = value; }
        }

        public string AccountHeader
        {
            get { return accountHeader; }
            set { accountHeader = value; }
        }

        public string Report
        {
            get { return report; }
            set { report = value; }
        }


        public string Query
        {
            get { return query; }
            set { query = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public ChartOfAccountType ChartOfAccountType
        {
            get { return chartOfAccountType; }
            set { chartOfAccountType = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; }
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

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
