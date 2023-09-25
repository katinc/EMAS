using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.TimeAndAttendance
{
    public class TimeCard
    {

        private int empID;
        private Nullable<DateTime> checkIn;
        private Nullable<DateTime> checkOut;
        private string checkInType;
        private string checkOutType;
        private string checkInReason;
        private string checkOutReason;
        private decimal workHours;
        private decimal overTimeHours;
        private decimal duration;
        private int userID;

        public TimeCard()
        {
            empID = 0;
            checkIn = null;
            checkOut = null;
            workHours = 0;
            overTimeHours = 0;
            checkInType = string.Empty;
            checkOutType = string.Empty;
            userID = 0;
            checkInReason = string.Empty;
            checkOutReason = string.Empty;
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string CheckInReason
        {
            get { return checkInReason; }
            set { checkInReason = value; }
        }

        public string CheckOutReason
        {
            get { return checkOutReason; }
            set { checkOutReason = value; }
        }

        public Nullable<DateTime> CheckIn
        {
            get { return checkIn; }
            set { checkIn = value; }
        }

        public Nullable<DateTime> CheckOut
        {
            get { return checkOut; }
            set { checkOut = value; }
        }

        public string CheckInType
        {
            get
            {
                if (checkInType == "I")
                    return "From Device";
                else
                    return "From HRIS";
            }
            set
            {
                if (value == "From Device" || value =="I")
                    checkInType = "I";
                else
                    checkInType = "E";
            }
        }

        public string CheckOutType
        {
            get
            {
                if (checkOutType == "I")
                    return "From Device";
                else
                    return "From HRIS";
            }
            set
            {
                if (value == "From Device" || value == "I")
                    checkOutType = "I";
                else
                    checkOutType = "E";
            }
        }


        public decimal  Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public decimal OverTimeHours
        {
            get { return overTimeHours;}
            set { overTimeHours = value; }
        }

        public decimal WorkHours
        {
            get { return workHours; }
            set { workHours = value; }
        }

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }
    }
}
