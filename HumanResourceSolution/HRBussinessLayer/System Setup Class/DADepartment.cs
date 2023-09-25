using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class DADepartment
    {
        private int deptID;
        private Department department;
        private string deptName;
        private int supDeptID;
        private int inheritParentSch;
        private int inheritDeptSch;
        private int inheritDeptSchClass;
        private int autoSchPlan;
        private int inLate;
        private int outEarly;
        private int inheritDeptRule;
        private int minAutoSchInterval;
        private int registerOT;
        private int defaultSchId;
        private int att;
        private int holiday;
        private int overTime;

        public DADepartment()
        {
            try
            {
                this.deptID = 0;
                this.department = new Department();
                this.deptName = string.Empty;
                this.supDeptID = 0;
                this.inheritParentSch = 0;
                this.inheritDeptSch = 0;
                this.inheritDeptSchClass = 0;
                this.autoSchPlan = 0;
                this.inLate = 0;
                this.outEarly = 0;
                this.inheritDeptRule = 0;
                this.minAutoSchInterval = 0;
                this.registerOT = 0;
                this.defaultSchId = 0;
                this.att = 0;
                this.holiday = 0;
                this.overTime = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int DEPTID
        {
            get { return deptID; }
            set { deptID = value; }
        }

        public string DEPTNAME
        {
            get { return deptName; }
            set { deptName = value; }
        }

        public int SUPDEPTID
        {
            get { return supDeptID; }
            set { supDeptID = value; }
        }

        public int InheritParentSch
        {
            get { return inheritParentSch; }
            set { inheritParentSch = value; }
        }

        public int InheritDeptSch
        {
            get { return inheritDeptSch; }
            set { inheritDeptSch = value; }
        }

        public int InheritDeptSchClass
        {
            get { return inheritDeptSchClass; }
            set { inheritDeptSchClass = value; }
        }

        public int AutoSchPlan
        {
            get { return autoSchPlan; }
            set { autoSchPlan = value; }
        }

        public int InLate
        {
            get { return inLate; }
            set { inLate = value; }
        }

        public int OutEarly
        {
            get { return outEarly; }
            set { outEarly = value; }
        }

        public int InheritDeptRule
        {
            get { return inheritDeptRule; }
            set { inheritDeptRule = value; }
        }

        public int MinAutoSchInterval
        {
            get { return minAutoSchInterval; }
            set { minAutoSchInterval = value; }
        }

        public int RegisterOT
        {
            get { return registerOT; }
            set { registerOT = value; }
        }

        public int DefaultSchId
        {
            get { return defaultSchId; }
            set { defaultSchId = value; }
        }

        public int ATT
        {
            get { return att; }
            set { att = value; }
        }

        public int Holiday
        {
            get { return holiday; }
            set { holiday = value; }
        }

        public int OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                DADepartment department = (DADepartment)obj;
                if (this.deptID == department.deptID)
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
