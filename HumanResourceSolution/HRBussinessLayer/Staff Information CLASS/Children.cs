using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Child
    {
       
        private string fullName;
        private Nullable<DateTime> dob;
        private GenderGroups gender;
        int id;

        public Child()
        {
            id = 0;
            fullName = string.Empty;
            dob = null;
            gender = GenderGroups.None;
        }

        public Child(int id,string fullName, DateTime dob, GenderGroups sex)
        {
            this.id = id;
            this.fullName = fullName;
            this.dob = dob;
            this.gender = sex;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public Nullable<DateTime> DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public GenderGroups Gender
        {
            get { return gender; }
            set { gender = value; }
        }
    }
}
