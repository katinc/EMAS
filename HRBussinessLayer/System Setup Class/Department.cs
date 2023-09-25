using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Department
    {
        private int id;
        private string supervisor;
        private int supervisorID;
        private string supervisorCode;
        private string supervisorFirstName;
        private string supervisorLastName;
        private string supervisorOtherName;
        private string supervisorGradeCategory;
        private string supervisorGrade;
        private string supervisorBand;
        private string supervisorStep;

        private string code;
        private string description;
        private bool archived;
        private bool active;
        private int maxStaff;
        private int minStaff;
        private User user;

        public Department()
        {
            try
            {
                this.id = 0;
                this.supervisor = string.Empty;
                this.supervisorCode = string.Empty;
                this.supervisorID = 0;
                this.supervisorFirstName = string.Empty;
                this.supervisorLastName = string.Empty;
                this.supervisorOtherName = string.Empty;
                this.supervisorGradeCategory = string.Empty;
                this.supervisorGrade = string.Empty;
                this.supervisorBand = string.Empty;
                this.supervisorStep = string.Empty;

                this.code = string.Empty;
                this.description = string.Empty;
                this.archived = false;
                this.active = true;
                this.maxStaff = 0;
                this.minStaff = 0;
                this.user = new User();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public string Supervisor
        {
            get { return supervisor; }
            set { supervisor = supervisorLastName + " " + supervisorFirstName + " " + supervisorOtherName; }
        }

        public string SupervisorCode
        {
            get { return supervisorCode; }
            set { supervisorCode = value; }
        }

        public int SupervisorID
        {
            get { return supervisorID; }
            set { supervisorID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool In_Use
        {
            get { return active; }
            set { active = value; }
        }

        public int Max_Staff
        {
            get { return maxStaff; }
            set { maxStaff = value;}
        }

        public int Min_Staff
        {
            get { return minStaff; }
            set { minStaff = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string SupervisorFirstName
        {
            get { return supervisorFirstName; }
            set { supervisorFirstName = value; }
        }

        public string SupervisorLastName
        {
            get { return supervisorLastName; }
            set { supervisorLastName = value; }
        }

        public string SupervisorOtherName
        {
            get { return supervisorOtherName; }
            set { supervisorOtherName = value; }
        }

        public string SupervisorGradeCategory
        {
            get { return supervisorGradeCategory; }
            set { supervisorGradeCategory = value; }
        }

        public string SupervisorGrade
        {
            get { return supervisorGrade; }
            set { supervisorGrade = value; }
        }

        public string SupervisorBand
        {
            get { return supervisorBand; }
            set { supervisorBand = value; }
        }

        public string SupervisorStep
        {
            get { return supervisorStep; }
            set { supervisorStep = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                Department department = (Department)obj;
                if (this.id == department.id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            return false;
        }
    }
}
