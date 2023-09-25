using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class SingleSpine
    {
        private int id;
        private float amount;
        private GradeCategory gradeCategory;
        private EmployeeGrade employeeGrade;
        private Band band;
        private Step step;
        private Level salaryLevel;
        private bool archived;
        private User user;

        public SingleSpine()
        {
            try
            {
                this.id = 0;
                this.amount = 0;
                this.gradeCategory = new GradeCategory();
                this.employeeGrade = new EmployeeGrade();
                this.band = new Band();
                this.step = new Step();
                this.salaryLevel = new Level();
                this.archived = false;
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

        public float BasicSalary
        {
            get { return amount; }
            set { amount = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public EmployeeGrade EmployeeGrade
        {
            get { return employeeGrade; }
            set { employeeGrade = value; }
        }

        public Band Band
        {
            get { return band; }
            set { band = value; }
        }

        public Step Step
        {
            get { return step; }
            set { step = value; }
        }

        public Level SalaryLevel
        {
            get { return salaryLevel; }
            set { salaryLevel = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
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
                SingleSpine singleSpine = (SingleSpine)obj;
                if (this.id == singleSpine.id)
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
