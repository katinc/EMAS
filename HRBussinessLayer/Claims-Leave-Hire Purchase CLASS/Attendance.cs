using HRBussinessLayer.Staff_Information_CLASS;
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
        private string checkoutTime;
        private string checkinTime;
        private bool archived;
        private string breakoutTime;
        private string breakinTime;
        private string shiftType;
        private string userType;
        private string staffMainID;
        private string inType;
        private string outType;
        private string deviceID;
        private string userID;
        private string checkoutDeviceID;
        private string checkinDeviceID;
        private DateTime date;
        private Employee employee;
        private string department;
        private string unit;
        private string checkOutType;

        public Attendance()
        {
            this.id = 0;
            this.staffID = string.Empty;
            this.staffName = string.Empty;
            this.attendanceDate = Hospital.CurrentDate;
            this.attendanceTime = string.Empty;
            this.checkoutTime = string.Empty;
            this.checkinTime = string.Empty;
            this.archived = false;
            this.breakoutTime = string.Empty;
            this.breakinTime = string.Empty;
            this.shiftType = string.Empty;
            this.userType = string.Empty;
            this.staffMainID = string.Empty;
            this.inType = string.Empty;
            this.outType = string.Empty;
            this.deviceID = string.Empty;
            this.userID = string.Empty;
            this.date = DateTime.Today;
            this.checkinDeviceID = string.Empty;
            this.checkoutDeviceID = string.Empty;
            this.employee = new Employee();
            this.department = string.Empty;
            this.unit = string.Empty;
            this.checkOutType = string.Empty;
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

        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public string CheckOutType
        {
            get { return checkOutType; }
            set { checkOutType = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
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

        public string CheckoutTime
        {
            get { return checkoutTime; }
            set { checkoutTime = value; }
        }

        public string CheckinTime
        {
            get { return checkinTime; }
            set { checkinTime = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public string BreakoutTime
        {
            get { return breakoutTime; }
            set { breakoutTime = value; }
        }

        public string BreakinTime
        {
            get { return breakinTime; }
            set { breakinTime = value; }
        }

        public string ShiftType
        {
            get { return shiftType; }
            set { shiftType = value; }
        }

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public string StaffMainID
        {
            get { return staffMainID; }
            set { staffMainID = value; }
        }

        public string InType
        {
            get { return inType; }
            set { inType = value; }
        }

        public string OutType
        {
            get { return outType; }
            set { outType = value; }
        }

        public string DeviceID
        {
            get { return deviceID; }
            set { deviceID = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public string CheckinDeviceID
        {
            get { return checkinDeviceID; }
            set { checkinDeviceID = value; }
        }

        public string CheckoutDeviceID
        {
            get { return checkoutDeviceID; }
            set { checkoutDeviceID = value; }
        }
    }
}
