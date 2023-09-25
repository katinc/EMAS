using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class Attendance
    {
        private int id;
        private string staffID;
        private string staffName;
        private DateTime attendanceDate;
        private string attendanceTime;

        public Attendance()
        {
            id = 0;
            staffID = string.Empty;
            staffName = string.Empty;
            attendanceDate = Hospital.CurrentDate;
            attendanceTime = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public string StaffName
        {
            get { return staffName; }
            set { staffName = value; }
        }

        public DateTime AttendanceDate
        {
            get { return attendanceDate; }
            set { attendanceDate = value; }
        }

        public string AttendanceTime
        {
            get { return attendanceTime; }
            set { attendanceTime = value; }
        }
    }
}
