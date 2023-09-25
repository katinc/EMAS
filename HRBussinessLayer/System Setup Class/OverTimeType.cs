using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class OverTimeType
    {
        private int id;
        private string description;
        private decimal rate;
        private bool active;

        public OverTimeType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.rate = 0;
            this.active = false;
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

        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
