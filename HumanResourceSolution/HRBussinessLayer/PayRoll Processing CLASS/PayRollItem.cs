using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class PayRollItem
    {
        private int id;
        private string staffID;
        private string name;
        private string firstName;
        private string lastName;
        private string otherName;
        private string columnHeader;
        private decimal columnValue;
        private string department;
        private string type;
        private bool mechanised;
        private string gradeCategory;
        private string grade;
        private string unit;
        private string overseer;
        private string status;
        private string zone;
        private int columnPosition;
        private string jobTitle;
        private string sSNITNumber;
        private string bank;
        private string accountNumber;

        public PayRollItem()
        {
            this.id = 0;
            this.staffID = string.Empty;
            this.name = string.Empty;
            this.firstName = string.Empty;
            this.lastName = string.Empty;
            this.otherName = string.Empty;
            this.columnHeader = string.Empty;
            this.columnValue = 0;
            this.department = string.Empty;
            this.type = string.Empty;
            this.mechanised = false;
            this.gradeCategory = string.Empty;
            this.grade = string.Empty;
            this.unit = string.Empty;
            this.overseer = string.Empty;
            this.status = string.Empty;
            this.zone = string.Empty;
            this.columnPosition = 0;
            this.jobTitle = string.Empty;
            this.sSNITNumber = string.Empty;
            this.bank = string.Empty;
            this.accountNumber = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string OtherName
        {
            get { return otherName; }
            set { otherName = value; }
        }

        public string ColumnHeader
        {
            get { return columnHeader; }
            set { columnHeader = value; }
        }

        public decimal ColumnValue
        {
            get { return columnValue; }
            set { columnValue = value; }
        }

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public bool Mechanised
        {
            get { return mechanised; }
            set { mechanised = value; }
        }

        public string GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public string Overseer
        {
            get { return overseer; }
            set { overseer = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public int ColumnPosition
        {
            get { return columnPosition; }
            set { columnPosition = value; }
        }

        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public string SSNITNumber
        {
            get { return sSNITNumber; }
            set { sSNITNumber = value; }
        }

        public string Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
    }
}
