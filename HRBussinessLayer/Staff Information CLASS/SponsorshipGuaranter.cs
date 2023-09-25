using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.System_Setup_Class
{
   public class SponsorshipGuaranter
    {
        public int Id { get; set; }
        public string GuaranterName { get; set; }
        public string  Designation { get; set; }
        public int ListIndex { get; set; }
        public  TrainingBond TrainingBond { get; set; }
        public string EmpNumber { get; set; }

        public StaffIdentificationType IdentificationType { get; set; }
        public string PassPortNo { get; set; }
        public DateTime PassPortIssueDate { get; set; }
        public DateTime  PassPortExpiryDate { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string TelNo { get; set; }
        public string Address { get; set; }
        public string Organization { get; set; }
        public byte[] Photo { get; set; }
        public byte[] Signature { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }

    }
}
