using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.TimeAndAttendance
{
    public class AttendanceParameters
    {
        private int ID;

        private Nullable<DateTime> checkInStartTime;
        private Nullable<DateTime> checkInTime;
        private Nullable<DateTime> checkInEndTime;

        private Nullable<DateTime> checkOutStartTime;
        private Nullable<DateTime> checkOutTime;
        private Nullable<DateTime> checkOutEndTime;

        private Nullable<DateTime> breakStartTime;
        private Nullable<DateTime> breakTime;
        private Nullable<DateTime> breakEndTime;

        public AttendanceParameters()
        {
            checkInStartTime = null;
            checkInTime = null;
            checkInEndTime = null;
            checkOutStartTime = null;
            checkOutTime = null;
            checkOutEndTime = null;
            breakEndTime = null;
            breakStartTime = null;
            breakTime = null;
        }

        public Nullable<DateTime> CheckInStartTime
        {
            get { return checkInStartTime; }
            set { checkInStartTime = value; }
        }
        public Nullable<DateTime> CheckInTime
        {
            get { return checkInTime; }
            set { checkInTime = value; }
        }
        public Nullable<DateTime> CheckInEndTime
        {
            get { return checkInEndTime; }
            set { checkInEndTime = value; }
        }

        public Nullable<DateTime> CheckOutStartTime
        {
            get { return checkOutStartTime; }
            set { checkOutStartTime = value; }
        }

        public Nullable<DateTime> CheckOutTime
        {
            get { return checkOutTime; }
            set { checkOutTime = value; }
        }

        public Nullable<DateTime> CheckOutEndTime
        {
            get { return checkOutTime; }
            set { checkOutTime = value; }
        }

        public Nullable<DateTime> BreakStartTime
        {
            get { return breakStartTime; }
            set { breakStartTime = value; }
        }

        public Nullable<DateTime> BreakTime
        {
            get { return breakTime; }
            set { breakTime = value; }
        }
        public Nullable<DateTime> BreakEndTime
        {
            get { return breakEndTime; }
            set { breakEndTime = value; }
        }
    }
}
