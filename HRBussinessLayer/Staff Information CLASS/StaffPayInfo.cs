using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffPayInfo
    {
        private string pid;
        private string method;
        private string payFrequency;
        private string gradeCategory;
        private string grade;
        private int level;
        private string monthlyBasicSalary;
        private string paymentMode;
        private string sic;

        public string PID
        {
            get { return pid; }
            set { pid = value; }
        }

        public string Method
        {
            get { return method; }
            set { method = value; }
        }

        public string PayFrequency
        {
            get { return payFrequency; }
            set { payFrequency = value; }
        }

        public string GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }

        public string MonthlyBasicSalary
        {
            get { return monthlyBasicSalary; }
            set { monthlyBasicSalary = value; }
        }

        public string PaymentMode
        {
            get { return paymentMode; }
            set { paymentMode = value; }
        }

        public string SIC
        {
            get { return sic; }
            set { sic = value; }
        }
    }
}
