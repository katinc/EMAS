using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
   public class SponsoredCertProgramme
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Comparator { get; set; }
        public int ProgrammeDuration { get; set; }
        public int BondedDuration { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }

       
    }
}
