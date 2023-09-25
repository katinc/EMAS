using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class TrainingType
    {
        private int id;
        private string description;
        private string active;

        public TrainingType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = string.Empty;
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

        public string Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
