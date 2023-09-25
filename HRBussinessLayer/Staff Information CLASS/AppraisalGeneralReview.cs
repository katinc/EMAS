using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class AppraisalGeneralReview
    {
        public int Id { get; set; }
        public AppraisalPeriod appraisalPeriod { get; set; }
        public string strengths { get; set; }
        public string weeknesses { get; set; }
        public string recommendedTrainings { get; set; }
        public Employee Appraiser { get; set; }
        public string AppraiserComment { get; set; }
        public DateTime AppraiserDate { get; set; }
        public Employee Appraisee { get; set; }
        public string AppraiseeComment { get; set; }
        public DateTime AppraiseeDate { get; set; }
        public Employee Officer { get; set; }
        public string OfficerComment { get; set; }
        public DateTime OfficerDate { get; set; }
        public DateTime  EntryDate { get; set; }
        public UserInfo EnteredBy { get; set; }
        
    }
}
