using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class LoanType
    {
        private int id;
        private string description;

        public LoanType()
        {
            id = 0;
            description = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
