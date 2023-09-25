using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class PublicHoliday
    {
        private int id;
        private string holidayName;
        private DateTime holidayDate;
        private bool archived;
        private bool active;
        private int userid;

        public PublicHoliday()
        {
            id = 0;
            holidayName = string.Empty;
            holidayDate = Hospital.CurrentDate;
            archived = false;
            active = true;
            userid = 0;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime HolidayDate
        {
            get { return holidayDate; }
            set { holidayDate = value; }
        }

        public string HolidayName
        {
            get { return holidayName; }
            set { holidayName = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public int UserID
        {
            get { return userid; }
            set { userid = value; }
        }
    }
}
