using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.TimeAndAttendance
{
    public class TimeUnit
    {
        private int empID;
        private Nullable<DateTime> checkTime;
        private string checkType;
        private int userID;
        private string reason;

        public TimeUnit()
        {
            empID = 0;
            checkTime = null;
            checkType = string.Empty;
            reason = string.Empty;
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public Nullable<DateTime> CheckTime
        {
            get { return checkTime; }
            set { checkTime = value; }
        }

        public string CheckType
        {
            get { return checkType; }
            set { checkType = value; }
        }
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}
