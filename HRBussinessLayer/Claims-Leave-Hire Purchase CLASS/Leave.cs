using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class Leave
    {
        private int id;
        private Employee employee;
        private string staffName;
        private string leaveType;
        private string status;
        private DateTime startDate;
        private DateTime endDate;
        private DateTime leaveDate;
        private DateTime dateAndTimeGenerated;
        private string reason;
        private decimal numberOfDays;
        private string institution;
        private string programme;
        private string duration;
        private bool approved;
        private string approvedUser;
        private string approvedUserStaffID;
        private Nullable<DateTime> approvedDate;
        private Nullable<DateTime> approvedTime;
        private bool recommended;
        private string recommendedUser;
        private string recommendedUserStaffID;
        private Nullable<DateTime> recommendedDate;
        private Nullable<DateTime> recommendedTime;
        private bool rejected;
        private string rejectedUser;
        private string rejectedUserStaffID;
        private Nullable<DateTime> rejectedDate;
        private Nullable<DateTime> rejectedTime;
        private bool resumed;
        private string resumedUser;
        private string resumedUserStaffID;
        private Nullable<DateTime> resumedDate;
        private Nullable<DateTime> resumedTime;
        private bool recalled;
        private string recalledUser;
        private string recalledUserStaffID;
        private string recalledReason;
        private Nullable<DateTime> recalledDate;
        private Nullable<DateTime> recalledTime;
        private decimal remainingNumberOfDays;
        private User user;
        private bool archived;

        //Added leaveYear
        private int leaveYear;

        private string approvalReason;
        private string recommendationReason;

        private string funding;
        private string programType;

        public Leave()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.staffName = string.Empty;
                this.leaveType = string.Empty;
                this.status = string.Empty;
                this.startDate = Hospital.CurrentDate;
                this.endDate = Hospital.CurrentDate;
                this.leaveDate = Hospital.CurrentDate;
                this.dateAndTimeGenerated = DateTime.Today;
                this.reason = string.Empty;
                this.numberOfDays = 0;
                this.programme = string.Empty;
                this.institution = string.Empty;
                this.duration = string.Empty;
                this.approved = false;
                this.approvedUser = string.Empty;
                this.approvedUserStaffID = string.Empty;
                this.approvedDate = null;
                this.approvedTime = null;
                this.recommended = false;
                this.recommendedUser = string.Empty;
                this.recommendedUserStaffID = string.Empty;
                this.recommendedDate = null;
                this.recommendedTime = null;
                this.rejected = false;
                this.rejectedUser = string.Empty;
                this.rejectedUserStaffID = string.Empty;
                this.rejectedDate = null;
                this.rejectedTime = null;
                this.resumed = false;
                this.resumedUser = string.Empty;
                this.resumedUserStaffID = string.Empty;
                this.resumedDate = null;
                this.resumedTime = null;
                this.recalled = false;
                this.recalledUser = string.Empty;
                this.recalledUserStaffID = string.Empty;
                this.recalledReason = string.Empty;
                this.recalledDate = null;
                this.recalledTime = null;
                this.remainingNumberOfDays = 0;
                this.user = new User();
                this.archived = false;

                this.approvalReason = string.Empty;
                this.recommendationReason = string.Empty;

                this.funding = string.Empty;
                this.programType = string.Empty;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public string ApprovalReason
        {
            get { return approvalReason; }
            set { approvalReason = value; }
        }

        public string RecommendationReason
        {
            get { return recommendationReason; }
            set { recommendationReason = value; }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public decimal NumberOfDays
        {
            get { return numberOfDays; }
            set { numberOfDays = value; }
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

        public string Funding
        {
            get { return funding; }
            set { funding = value; }
        }

        public string ProgramType
        {
            get { return programType; }
            set { programType = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string LeaveType
        {
            get { return leaveType; }
            set { leaveType = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public DateTime LeaveDate
        {
            get { return leaveDate; }
            set { leaveDate = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
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

        public bool Recommended
        {
            get { return recommended; }
            set { recommended = value; }
        }

        public string RecommendedUser
        {
            get { return recommendedUser; }
            set { recommendedUser = value; }
        }

        public string RecommendedUserStaffID
        {
            get { return recommendedUserStaffID; }
            set { recommendedUserStaffID = value; }
        }

        public Nullable<DateTime> RecommendedDate
        {
            get { return recommendedDate; }
            set { recommendedDate = value; }
        }

        public Nullable<DateTime> RecommendedTime
        {
            get { return recommendedTime; }
            set { recommendedTime = value; }
        }

        public bool Rejected
        {
            get { return rejected; }
            set { rejected = value; }
        }

        public string RejectedUser
        {
            get { return rejectedUser; }
            set { rejectedUser = value; }
        }

        public string RejectedUserStaffID
        {
            get { return rejectedUserStaffID; }
            set { rejectedUserStaffID = value; }
        }

        public Nullable<DateTime> RejectedDate
        {
            get { return rejectedDate; }
            set { rejectedDate = value; }
        }

        public Nullable<DateTime> RejectedTime
        {
            get { return rejectedTime; }
            set { rejectedTime = value; }
        }

        public bool Resumed
        {
            get { return resumed; }
            set { resumed = value; }
        }

        public string ResumedUser
        {
            get { return resumedUser; }
            set { resumedUser = value; }
        }

        public string ResumedUserStaffID
        {
            get { return resumedUserStaffID; }
            set { resumedUserStaffID = value; }
        }

        public Nullable<DateTime> ResumedDate
        {
            get { return resumedDate; }
            set { resumedDate = value; }
        }

        public Nullable<DateTime> ResumedTime
        {
            get { return resumedTime; }
            set { resumedTime = value; }
        }

        public bool Recalled
        {
            get { return recalled; }
            set { recalled = value; }
        }

        public string RecalledUser
        {
            get { return recalledUser; }
            set { recalledUser = value; }
        }

        public string RecalledUserStaffID
        {
            get { return recalledUserStaffID; }
            set { recalledUserStaffID = value; }
        }

        public string RecalledReason
        {
            get { return recalledReason; }
            set { recalledReason = value; }
        }

        public Nullable<DateTime> RecalledDate
        {
            get { return recalledDate; }
            set { recalledDate = value; }
        }

        public Nullable<DateTime> RecalledTime
        {
            get { return recalledTime; }
            set { recalledTime = value; }
        }

        public decimal RemainingNumberOfDays
        {
            get { return remainingNumberOfDays; }
            set { remainingNumberOfDays = value; }
        }

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public string Institution
        {
            get { return institution; }
            set { institution = value; }
        }

        public string Programme
        {
            get { return programme; }
            set { programme = value; }
        }

        public string Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public int LeaveYear
        {
            get { return leaveYear; }
            set { leaveYear = value; }
        }
    }
}
