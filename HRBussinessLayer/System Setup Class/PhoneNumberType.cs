using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class PhoneNumberType
    {
        private string code;
        private string description;
        private bool active;

        public PhoneNumberType()
        {
            this.code = string.Empty;
            this.description = string.Empty;
            this.active = true;
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
