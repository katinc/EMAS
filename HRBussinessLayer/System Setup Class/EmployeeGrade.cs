using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class EmployeeGrade
    {
        private int gid;
        private GradeCategory gradeCategory;
        private string grade;
        private string code;
        private string level;
        private decimal amount;
        private User user;
        private bool active;
        private bool archived;

        public int StartStep { get; set; }
        public int EndStep { get; set; }



        public EmployeeGrade()
        {
            try
            {
                this.gid = 0;
                this.gradeCategory = new GradeCategory();
                this.user = new User();
                this.grade = string.Empty;
                this.code = string.Empty;
                this.level = string.Empty;
                this.amount = 0;
                this.active = true;
                this.archived = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return gid; }
            set { gid = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public string Level
        {
            get { return level; }
            set 
            {
                    level = value;
            }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                EmployeeGrade grade = (EmployeeGrade)obj;
                if (this.ID == grade.ID)
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
                throw ex;
            }
        }
    }
}
