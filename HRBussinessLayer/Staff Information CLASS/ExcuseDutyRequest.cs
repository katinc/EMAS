using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class ExcuseDutyRequest
    {

       private Employee employee;

       public ExcuseDutyRequest(){
           this.employee = new Employee();
       }
       

        public int id { get; set; }
        public string StaffID { get; set; }
        public string LeaveStatus { get; set; }
        public int LeaveYear { get; set; }
        public byte[] ExcuseDutySheet { get; set; }
        public string ExcuseDutyFileName { get; set; }
        public string SpecifyOther { get; set; }
        public DateTime StartDate { get; set; }
        public int NumOfDays { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Recommended { get; set; }
        public string AdditionalComment { get; set; }

        public int SupervisorId { get; set; }
        public string SupervisorName { get; set; }
        public string SupervisorEmpCode { get; set; }
        public bool SupervisorTerminated { get; set; }

        public Nullable<DateTime> RecommendationDate { get; set; }
        public int RecommendedById { get; set; }
        public string RecommendedByName { get; set; }

        public int HRRecommendedById { get; set; }
        public bool HREligibility { get; set; }
        public bool HRRecommended { get; set; }
        public string HRAdditionalComment { get; set; }
        public Nullable<DateTime> HRAssessmentDate { get; set; }

        public int ApprovedById { get; set; }
        public string ApprovedByName { get; set; }
        public string ApprovalComment { get; set; }

        public bool Approved { get; set; }
        public Nullable<DateTime> ApprovedDate { get; set; }
        public ExcuseDutyRequestType requestType { get; set; }
        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public bool Returned { get; set; }
        public Nullable<DateTime> ResumptionDate { get; set; }
        public string ResumptionReason { get; set; }

          
    }


}
