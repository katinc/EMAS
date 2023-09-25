using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.EMAIL
{
    public class StaffEmail
    {
        private string staffID;
        private string dob;
        private string email;

        public StaffEmail()
        {
            this.staffID = string.Empty;
            this.dob = string.Empty;
            this.email = string.Empty;
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
