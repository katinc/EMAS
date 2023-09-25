using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Shift
    {
        int id;
        string description;
        Employee supervisor;
        string startTime;
        string endTime;
        Department department;
        DateTime fromDate;
        DateTime toDate;

        public Shift()
        {
            id = 0;
            description = string.Empty;
            supervisor = new Employee();
            startTime = string.Empty;
            endTime = string.Empty;
            department = new Department();
            fromDate = Hospital.CurrentDate;
            toDate = Hospital.CurrentDate;
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

        public Employee Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

    }
}
