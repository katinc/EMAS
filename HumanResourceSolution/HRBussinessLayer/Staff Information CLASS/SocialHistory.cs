using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class SocialHistory
    {
        int id;
        private string convicted;
        private string bonded;
        private string physicalDisability;
        private string appliedBefore;

        public SocialHistory()
        {
            id = 0;
            convicted = string.Empty;
            bonded = string.Empty;
            physicalDisability = string.Empty;
            appliedBefore = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Convicted
        {
            get { return convicted; }
            set { convicted = value; }
        }

        public string Bonded
        {
            get { return bonded; }
            set { bonded = value; }
        }

        public string PhysicalDisability
        {
            get { return physicalDisability; }
            set { physicalDisability = value; }
        }

        public string AppliedBefore
        {
            get { return appliedBefore; }
            set { appliedBefore = value; }
        }
    }
}
