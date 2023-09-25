using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffFingerprintTemplates
    {
        public long ID { get; set; }
        public string StaffID { get; set; }
        public int FingerType { get; set; }
        public string Template { get; set; }
        public int TempLen { get; set; }
        public int Flag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UserID { get; set; }
        public string FingertypeText { get; set; }
        public int StaffMainID { get; set; }
        public string UserType { get; set; }
    }
}
