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
    public class Internship
    {
        private int id;
        private Image photo;
        private string idNumber;
        private string staffID;
        private string surname;
        private string otherName;
        private string institution;
        private Nullable<DateTime> birthDate;
        private string age;
        private string areaOfStudy;
        private string mobileNo;
        private string address;
        private string overseer;
        private string supervisorStaffID;
        private string supervisorName;
        private int supervisorCode;
        private decimal yearStudied;
        private GenderGroups gender;
        private MaritalStatusGroups maritalStatus;
        private Department department;
        private Unit unit;
        private Zone zone;
        private InternshipType internshipType;
        private Nullable<DateTime> startDate;
        private Nullable<DateTime> endDate;
        private Nullable<DateTime> reportingDate;
        private User user;
        private bool archived;


        public Internship()
        {
            try
            {
                this.id = 0;
                this.photo = null;
                this.idNumber = string.Empty;
                this.staffID = string.Empty;
                this.surname = string.Empty;
                this.otherName = string.Empty;
                this.institution = string.Empty;
                this.birthDate = DateTime.Today;
                this.age = string.Empty;
                this.areaOfStudy = string.Empty;
                this.mobileNo = string.Empty;
                this.address = string.Empty;
                this.overseer = string.Empty;
                this.supervisorName = string.Empty;
                this.supervisorStaffID = string.Empty;
                this.supervisorCode = 0;
                this.yearStudied = 0;
                this.gender = GenderGroups.None;
                this.maritalStatus = MaritalStatusGroups.None;
                this.department = new Department();
                this.unit = new Unit();
                this.zone = new Zone();
                this.internshipType = new InternshipType();
                this.startDate = DateTime.Today;
                this.endDate = DateTime.Today;
                this.reportingDate = DateTime.Today;
                this.user = new User();
                this.archived = false;
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

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string IDNumber
        {
            get { return idNumber; }
            set { idNumber = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public string AreaOfStudy
        {
            get { return areaOfStudy; }
            set { areaOfStudy = value; }
        }

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string SupervisorName
        {
            get { return supervisorName; }
            set { supervisorName = value; }
        }

        public string SupervisorStaffID
        {
            get { return supervisorStaffID; }
            set { supervisorStaffID = value; }
        }

        public int SupervisorCode
        {
            get { return supervisorCode; }
            set { supervisorCode = value; }
        }

        public string Overseer
        {
            get { return overseer; }
            set { overseer = value; }
        }

        public decimal YearStudied
        {
            get { return yearStudied; }
            set { yearStudied = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string OtherName
        {
            get { return otherName; }
            set { otherName = value; }
        }

        public string Institution
        {
            get { return institution; }
            set { institution = value; }
        }

        public Nullable<DateTime> DOB
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public MaritalStatusGroups MaritalStatus
        {
            get { return maritalStatus; }
            set { maritalStatus = value; }
        }

        public GenderGroups Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public InternshipType InternshipType
        {
            get { return internshipType; }
            set { internshipType = value; }
        }

        public Zone Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Nullable<DateTime> StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public Nullable<DateTime> EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public Nullable<DateTime> ReportingDate
        {
            get { return reportingDate; }
            set { reportingDate = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public string Age
        {
            get
            {
                string age = String.Empty;
                try
                {
                    int yrcheck = Hospital.CurrentDate.Year - DateTime.Parse(birthDate.ToString()).Year;
                    int monthcheck = Hospital.CurrentDate.Month - DateTime.Parse(birthDate.ToString()).Month;
                    int daycheck = Hospital.CurrentDate.Day - DateTime.Parse(birthDate.ToString()).Day;
                    if (yrcheck == 0)
                    {
                        if (daycheck == 0 || daycheck > 0)
                            age = monthcheck + " months";
                        else
                            age = monthcheck - 1 + " months";
                    }
                    else if (yrcheck == 1)
                    {
                        if (monthcheck < 0)
                        {
                            if (daycheck > 0 || daycheck == 0)
                                age = monthcheck + 12 + " months";
                            else if (daycheck < 1)
                                age = (monthcheck - 1) + 12 + " months";
                        }
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 || daycheck > 0)
                                age = "1 yr";
                            else if (daycheck < 0)
                                age = "11 months";
                            else if (monthcheck > 0)
                                age = "1 yr";
                        }
                    }
                    else if (yrcheck > 1)
                    {
                        if (monthcheck > 0)
                            age = yrcheck + " yrs";
                        else if (monthcheck < 0)
                            age = yrcheck - 1 + " yrs";
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 && daycheck > 0)
                                age = yrcheck + " yrs";
                            else
                                age = yrcheck - 1 + " yrs";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    age = "N/A";
                }
                return age;
            }
            set { age = this.Age; }
        } 
    }
}
