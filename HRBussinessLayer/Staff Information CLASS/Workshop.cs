using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class Workshop
    {
        public int Id { get; set; }
        public Employee Staff { get; set; }
        public Qualification Course { get; set; }
        public AttendedSchool School { get; set; }
        public Country Country { get; set; }
        public string Venue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime EntryDate { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
    }
}
