using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class UserInfo
    {
        //From USERINFO 
        private int userID;
        private Employee employee;
        private string badgeNumber;
        private string ssn;
        private string name;
        private GenderGroups gender;
        private Title title;
        private string pager;
        private Nullable<DateTime> birthDate;

        private Nullable<DateTime> hiredDay;
        private string street;
        private string city;
        private string state;
        private string zip;
        private string oPhone;
        private string fPhone;
        private int verificationMethod;
        private Department department;
        private int securityFlags;

        private int att;
        private int inLate;
        private int outEarly;
        private int overTime;
        private int sep;
        private int holiday;
        private string minzu;
        private string password;
        private int lunchDuration;
        private string mVerifyPass;
        private Image photo;
        private Image notes;
        private int privilege;

        private int inheritDeptSch;
        private int inheritDeptSchClass;
        private int autoSchPlan;
        private int minAutoSchInterval;
        private int registerOT;
        private int inheritDeptRule;
        private int empPrivilege;
        private string cardNo;
        private bool archived;


        public UserInfo()
        {
            try
            {
                this.userID = 0;
                this.employee = new Employee();
                this.badgeNumber = string.Empty;
                this.ssn = string.Empty;
                this.name = string.Empty;
                this.gender = GenderGroups.None;
                this.title = new Title();
                this.pager = string.Empty;
                this.birthDate = DateTime.Today;
                this.hiredDay = DateTime.Today;
                this.street = string.Empty;
                this.city = string.Empty;
                this.state = string.Empty;
                this.zip = string.Empty;
                this.oPhone = string.Empty;
                this.fPhone = string.Empty;
                this.verificationMethod =0;
                this.department = new Department();
                this.securityFlags = 0;

                this.att = 0;
                this.inLate = 0;
                this.outEarly = 0;
                this.overTime = 0;
                this.sep = 0;
                this.holiday = 0;
                this.minzu = string.Empty;
                this.password = string.Empty;
                this.lunchDuration = 0;
                this.mVerifyPass = string.Empty;
                this.photo = null;
                this.notes = null;
                this.privilege = 0;
                this.inheritDeptSch = 0;
                this.inheritDeptSchClass = 0;
                this.autoSchPlan = 0;
                this.minAutoSchInterval = 0;
                this.registerOT = 0;
                this.inheritDeptRule = 0;
                this.empPrivilege = 0;
                this.cardNo = string.Empty;
                this.archived = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int USERID
        {
            get { return userID; }
            set { userID = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public string BADGENUMBER
        {
            get { return badgeNumber; }
            set { badgeNumber = value; }
        }

        public string SSN
        {
            get { return ssn; }
            set { ssn = value; }
        }

        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        public GenderGroups GENDER
        {
            get { return gender; }
            set { gender = value; }
        }

        public Title Title
        {
            get { return title; }
            set { title = value; }
        }

        public string PAGER
        {
            get { return pager; }
            set { pager = value; }
        }

        public Nullable<DateTime> BIRTHDATE
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public Nullable<DateTime> HIREDDAY
        {
            get { return hiredDay; }
            set { hiredDay = value; }
        }

        public string STREET
        {
            get { return street; }
            set { street = value; }
        }

        public string CITY
        {
            get { return city; }
            set { city = value; }
        }

        public string STATE
        {
            get { return state; }
            set { state = value; }
        }

        public string ZIP
        {
            get { return zip; }
            set { zip = value; }
        }

        public string OPHONE
        {
            get { return oPhone; }
            set { oPhone = value; }
        }

        public string FPHONE
        {
            get { return fPhone; }
            set { fPhone = value; }
        }

        public int VERIFICATIONMETHOD
        {
            get { return verificationMethod; }
            set { verificationMethod = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }



        public int SECURITYFLAGS
        {
            get { return securityFlags; }
            set { securityFlags = value; }
        }

        public int ATT
        {
            get { return att; }
            set { att = value; }
        }

        public int INLATE
        {
            get { return inLate; }
            set { inLate = value; }
        }

        public int OUTEARLY
        {
            get { return outEarly; }
            set { outEarly = value; }
        }

        public int OVERTIME
        {
            get { return overTime; }
            set { overTime = value; }
        }

        public int SEP
        {
            get { return sep; }
            set { sep = value; }
        }

        public int HOLIDAY
        {
            get { return holiday; }
            set { holiday = value; }
        }

        public string MINZU
        {
            get { return minzu; }
            set { minzu = value; }
        }

        public string PASSWORD
        {
            get { return password; }
            set { password = value; }
        }

        public int LUNCHDURATION
        {
            get { return lunchDuration; }
            set { lunchDuration = value; }
        }

        public string MVerifyPass
        {
            get { return mVerifyPass; }
            set { mVerifyPass = value; }
        }

        public Image PHOTO
        {
            get { return photo; }
            set { photo = value; }
        }

        public Image Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public int Privilege
        {
            get { return privilege; }
            set { privilege = value; }
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

        public int InheritDeptRule
        {
            get { return inheritDeptRule; }
            set { inheritDeptRule = value; }
        }

        public int EMPRIVILEGE
        {
            get { return empPrivilege; }
            set { empPrivilege = value; }
        }

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
