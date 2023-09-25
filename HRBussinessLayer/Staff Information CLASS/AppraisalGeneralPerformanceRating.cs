using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
  public  class AppraisalGeneralPerformanceRating
    {
        public int Id { get; set; }
        public Employee Staff { get; set; }
        public AppraisalType Factor { get; set; }
        public AppraisalPeriod Period { get; set; }
        public AppraisalRating Rating { get; set; }
        public string Comment { get; set; }
        public DateTime EntryDate { get; set; }
        public UserInfo EnteredBy { get; set; }


    }

    public class AppraisalRating{
        public int Id { get; set; }
        public string Description { get; set; }
        public string  RateDescription { get; set; }
        public decimal Value { get; set; }
        public decimal AvgMin { get; set; }
        public decimal AvgMax { get; set; }

        public decimal OveralMin { get; set; }
        public decimal OveralMax { get; set; }
    }
}
