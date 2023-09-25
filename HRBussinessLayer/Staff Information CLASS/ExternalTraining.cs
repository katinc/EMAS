using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.System_Setup_Data_Control;


namespace HRBussinessLayer.Staff_Information_CLASS
{
  public  class ExternalTraining
    {
        public int ID { get; set; }
        public AttendedSchool School { get; set; }
        public Employee Staff { get; set; }
        public Country TrainingCoutry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrainingOrganizer Organizer { get; set; }
        public Qualification AspiredQualification { get; set; }
        public TrainingSponsor Sponsor { get; set; }
        public UserInfo EntryBy { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
        public DateTime EnteredDate { get; set; }
        public string Venue { get; set; }
        public decimal Cost { get; set; }
        public decimal AccomodationFee { get; set; }
        public decimal TransportationFee { get; set; }

        public bool isJustified { get; set; }
        public Employee HOD { get; set; }
      
        public DateTime JustificationDate { get; set; }
        public string Justification { get; set; }


        public Employee HR { get; set; }
        public string HRDecision { get; set; }
        public string HRComment { get; set; }
        public DateTime HRAssessmentDate { get; set; }
        public bool HRRecommended { get; set; }

        public Employee CEO { get; set; }
        public bool CEOApproval { get; set; }
        public string CEOComment { get; set; }
        public DateTime CEOApprovalDate { get; set; }
       

        public decimal TotalCost
        {
            get;
            set;

        }
        public bool InCountryTraining { get; set; }
       
    }
}
