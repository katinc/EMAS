using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Holiday
    {
        private int id;
        private string description;
        private DateTime date;

        public Holiday()
        {
            id = 0;
            date = Hospital.CurrentDate;
            description = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

    }
}
