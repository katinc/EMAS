using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Applicant
    {
        private int id;
        private string surname;
        private string firstName;
        private string middleName;
        private Vacancy vacancy;
        private string contactNo;
        private string emailAddress;
        private Nullable<DateTime> applicationDate;
        private string contactAddress;
        private string status;
        private IList<StaffDocument> documents;
        private User user;

        public Applicant()
        {
            this.id = 0;
            this.surname = string.Empty;
            this.firstName = string.Empty;
            this.middleName = string.Empty;
            this.vacancy = new Vacancy();
            this.emailAddress = string.Empty;
            this.applicationDate = null;
            this.contactAddress = string.Empty;
            this.contactNo = string.Empty;
            this.status = string.Empty;
            this.documents = new List<StaffDocument>();
            this.user = new User();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }
        public Nullable<DateTime> ApplicationDate
        {
            get { return applicationDate; }
            set { applicationDate = value; }
        }

        public Vacancy Vacancy
        {
            get { return vacancy; }
            set { vacancy = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress;}
            set { emailAddress = value;}
        }

        public string ContactAddress
        {
            get { return contactAddress; }
            set { contactAddress = value; }
        }

        public string ContactNo
        {
            get { return contactNo; }
            set { contactNo = value; }
        }

        public IList<StaffDocument> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
    }
}
