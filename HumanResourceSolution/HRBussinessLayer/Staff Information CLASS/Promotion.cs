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
    public class Promotion
    {
        private int id;
        private Nullable<DateTime> promotionDate;
        private Nullable<DateTime> notionalDate;
        private Nullable<DateTime> substantiveDate;
        private Employee employee;
        private GradeCategory newGradeCategory;
        private EmployeeGrade newGrade;
        private Step step;
        private Band band;
        private decimal newSalary;
        private Nullable<DateTime> dateAndTimeGenerated;
        private string reason;
        private User user;
        private PromotionType promotionType;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;
        private bool archived;

        public Promotion()
        {
            try
            {
                this.id = 0;
                this.employee =new Employee();
                this.promotionDate = null;
                this.notionalDate = null;
                this.substantiveDate = null;
                this.newGradeCategory = new GradeCategory();
                this.newGrade = new EmployeeGrade();
                this.step = new Step();
                this.band = new Band();
                this.newSalary = 0;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.user = new User();
                this.archived = false;
                this.approved = false;
                this.approvedUser = string.Empty;
                this.approvedUserStaffID = string.Empty;
                this.approvedDate = null;
                this.approvedTime = null;
                this.promotionType = new PromotionType();
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

        public Nullable<DateTime> PromotionDate
        {
            get { return promotionDate; }
            set { promotionDate = value; }
        }

        public Nullable<DateTime> NotionalDate
        {
            get { return notionalDate; }
            set { notionalDate = value; }
        }

        public Nullable<DateTime> SubstantiveDate
        {
            get { return substantiveDate; }
            set { substantiveDate = value; }
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

        public decimal NewSalary
        {
            get { return newSalary; }
            set { newSalary = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return newGradeCategory; }
            set { newGradeCategory = value; }
        }

        public EmployeeGrade Grade
        {
            get { return newGrade; }
            set { newGrade = value; }
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

        public bool Approved
        {
            get { return approved; }
            set { approved = value; }
        }

        public string ApprovedUser
        {
            get { return approvedUser; }
            set { approvedUser = value; }
        }

        public string ApprovedUserStaffID
        {
            get { return approvedUserStaffID; }
            set { approvedUserStaffID = value; }
        }

        public Nullable<DateTime> ApprovedDate
        {
            get { return approvedDate; }
            set { approvedDate = value; }
        }

        public Nullable<DateTime> ApprovedTime
        {
            get { return approvedTime; }
            set { approvedTime = value; }
        }

        public PromotionType PromotionType
        {
            get { return promotionType; }
            set { promotionType = value; }
        }   
    }
}
