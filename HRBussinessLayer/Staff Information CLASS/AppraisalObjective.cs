using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class AppraisalObjective
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public AppraisalPeriod Period { get; set; }
        public Employee Staff { get; set; }
        public AppraisalRating PeriodRating{ get; set; }
        public string  Comment { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
        
        public UserInfo EnteredBy { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
