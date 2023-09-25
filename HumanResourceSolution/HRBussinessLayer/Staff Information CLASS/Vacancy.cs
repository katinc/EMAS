using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Vacancy
    {
        private int id;
        private EmployeeGrade grade;
        private AppointmentType appointmentType;
        private Department department;
        private DateTime date;
        private DateTime deadline;
        private IList<string> jobDescription;
        private IList<string> jobRequirements;
        private string email;
        private string postalAddress;
        private string contactNos;
        private string faxNo;
        private string vacancyDueTo;
        private VacancyStatus status;
        private int userID;

        public Vacancy()
        {
            try
            {
                id = 0;
                grade = new EmployeeGrade();
                appointmentType = new AppointmentType();
                department = new Department();
                date = DateTime.Today;
                deadline = DateTime.Today;
                jobDescription = new List<string>();
                jobRequirements = new List<string>();
                email = string.Empty;
                postalAddress = string.Empty;
                contactNos = string.Empty;
                faxNo = string.Empty;
                vacancyDueTo = string.Empty;
                status = VacancyStatus.None;
                userID = 0;
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

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public EmployeeGrade Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        public AppointmentType AppointmentType
        {
            get { return appointmentType; }
            set { appointmentType = value; }
        }
        
        public Department Department
        {
            get { return department; }
            set { department = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public DateTime DeadLine
        {
            get { return deadline; }
            set { deadline = value; }
        }

        public IList<string> JobDescription
        {
            get { return jobDescription; }
            set { jobDescription = value; }
        }

        public IList<string> JobRequirements
        {
            get { return jobRequirements; }
            set { jobRequirements = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string PostalAddress
        {
            get { return postalAddress; }
            set { postalAddress = value; }
        }

        public string ContactNos
        {
            get { return contactNos; }
            set { contactNos = value; }
        }

        public string FaxNo
        {
            get { return faxNo; }
            set { faxNo = value; }
        }

        public string VacancyDueTo
        {
            get { return vacancyDueTo; }
            set { vacancyDueTo = value; }
        }

        public VacancyStatus Status
        {
            get { return status; }
            set { status = value; }
        }

        public override bool Equals(object obj)
        {
            Vacancy vacancy = (Vacancy)obj;
            if (this.id == vacancy.id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
