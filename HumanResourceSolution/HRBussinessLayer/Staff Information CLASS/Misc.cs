using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Misc
    {
        private string mid;
        private string department;
        private DateTime dfa;
        private DateTime dpa;
        private string incomeTaxContribution; //CL
        private string staffCategory;
        private string ssnitNo;
        private string ssnitContribution;
        private string convicted;
        private string bonded;
        private string disable;
        private string appliedBefore;

        public string MID
        {
            get { return mid; }
            set { mid = value; }
        }

        public string Department
        { 
            get { return department; }
            set { department = value; }
        }

        public DateTime DFA
        {
            get { return dfa; }
            set { dfa = value; }
        }

        public DateTime DPA
        {
            get { return dpa; }
            set { dpa = value; }
        }

        public string IncomeTaxContribution
        {
            get { return incomeTaxContribution; }
            set { incomeTaxContribution = value; }
        }

        public string StaffCategory
        {
            get { return staffCategory; }
            set { staffCategory = value; }
        }

        public string SSNITNo
        {
            get { return ssnitNo; }
            set { ssnitNo = value; }
        }

        public string SSNITContribution
        {
            get { return ssnitContribution; }
            set { ssnitContribution = value; }
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

        public string Disable
        {
            get { return disable; }
            set { disable = value; }
        }

        public string AppliedBefore
        {
            get { return appliedBefore; }
            set { appliedBefore = value; }
        }

    }
}
