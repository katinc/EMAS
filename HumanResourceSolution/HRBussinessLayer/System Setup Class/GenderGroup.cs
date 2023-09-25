using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class GenderGroup
    {
        private int id;
        private string description;
       
        public GenderGroup()
        {
            this.id = 0;
            this.description = string.Empty;
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
