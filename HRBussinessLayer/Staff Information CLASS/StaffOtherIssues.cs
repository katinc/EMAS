using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffOtherIssues
    {
        private string convicted;
        private string bonded;
        private string disabled;
        private string applied;

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

        public string Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        public string Applied
        {
            get { return applied; }
            set { applied = value; }
        }
    }
}
