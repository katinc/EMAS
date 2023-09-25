using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class TrainingBond
    {
        public int Id { get; set; }
        public Employee Staff { get; set; }
        public Qualification AspiredQualification { get; set; }
        public AttendedSchool School { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public TrainingAttendanceMode CourseAttendanceMode { get; set; }
        public SponsoredCertProgramme SponsoredProgrammeCategory { get; set; }
        public DateTime DeclarationDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string WitnessedBy { get; set; }
        public byte[] WitnessStamp { get; set; }
        public DateTime WitnessDate { get; set; }
        public List<SponsorshipGuaranter> SponsorshipGuaranters { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
        public UserInfo EntryBy { get; set; }
        public bool ForAdditionalQualification { get; set; }
        public string letterName { get; set; }
    }
}
