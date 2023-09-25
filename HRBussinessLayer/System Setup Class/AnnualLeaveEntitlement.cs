using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class AnnualLeaveEntitlement
    {
        private int id;
        private string categoryOfPost;
        private string typeOfGrade;
        private string status;
        private int numberOfDays;
        private int promotionYears;
        private bool active;
        private bool archived;
        private User user;

        private bool includeHolidays;
        private bool includeWeekends;

        public AnnualLeaveEntitlement()
        {
            try
            {
                this.id = 0;
                this.categoryOfPost = string.Empty;
                this.typeOfGrade = string.Empty;
                this.status = string.Empty;
                this.numberOfDays = 0;
                this.promotionYears = 0;
                this.active = true;
                this.archived = false;
                this.user = new User();
                this.includeHolidays = false;
                this.includeWeekends = false;
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

        public string CategoryOfPost
        {
            get { return categoryOfPost; }
            set { categoryOfPost = value; }
        }

        public string TypeOfGrade
        {
            get { return typeOfGrade; }
            set { typeOfGrade = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public int PromotionYears
        {
            get { return promotionYears; }
            set { promotionYears = value; }
        }

        public int NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool IncludeHolidays
        {
            get { return includeHolidays; }
            set { includeHolidays = value; }
        }

        public bool IncludeWeekends
        {
            get { return includeWeekends; }
            set { includeWeekends = value; }
        }
    }
}
