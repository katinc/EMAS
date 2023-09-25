using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
   public class AttendedSchool
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Country SchoolCountry { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
    }
}
