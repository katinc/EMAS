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
    public class ChartOfAccountGeneration
    {
        private int id;
        private GradeCategory gradeCategory;
        private Department department;
        private Unit unit;
        private string accountCode;
        private string accountDescription;
        private string report;
        private string accountHeader;
        private string quickbookOverseer;
        private decimal amount;
        private ChartOfAccountType chartOfAccountType;
        private DateTime date;
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool active;
        private string status;
        private string month;
        private string year;
        private string type;
        private bool posted;
        private string transactionID;

        public ChartOfAccountGeneration()
        {
            try
            {
                this.id = 0;
                this.accountCode = string.Empty;
                this.accountDescription = string.Empty;
                this.accountHeader = string.Empty;
                this.report = string.Empty;
                this.amount = 0;
                this.quickbookOverseer = string.Empty;
                this.gradeCategory = new GradeCategory();
                this.department = new Department();
                this.unit = new Unit();
                this.chartOfAccountType = new ChartOfAccountType();
                this.date = DateTime.Now.Date;
                this.dateAndTimeGenerated = DateTime.Now;
                this.user = new User();
                this.active = false;
                this.status = string.Empty;
                this.month = string.Empty;
                this.year = string.Empty;
                this.type = string.Empty;
                this.posted = false;
                this.transactionID = string.Empty;
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


        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public string QuickbookOverseer
        {
            get { return quickbookOverseer; }
            set { quickbookOverseer = value; }
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

        public DateTime Date
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

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Posted
        {
            get { return posted; }
            set { posted = value; }
        }

        public string TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }
    }
}
