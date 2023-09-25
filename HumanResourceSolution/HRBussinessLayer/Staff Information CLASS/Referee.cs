using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Referee
    {
        private int id;
        private Employee employee;
        private string name;
        private string address;
        private string occupation;
        private string telNo;
        private string email;
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool archived;
        
        public Referee()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.name = string.Empty;
                this.address = string.Empty;
                this.occupation = string.Empty;
                this.telNo = string.Empty;
                this.email = string.Empty;
                this.dateAndTimeGenerated = DateTime.Today;
                this.user = new User();
                this.archived = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public Referee(int id,string name, string address, string occupation, string telNo,string email)
        {
            try
            {
                this.id = id;
                this.name = name;
                this.address = address;
                this.occupation = occupation;
                this.telNo = telNo;
                this.email = email;
                this.dateAndTimeGenerated = DateTime.Today;
                this.employee = new Employee();
                this.user = new User();
                this.archived = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Occupation
        {
            get { return occupation; }
            set { occupation = value; }
        }

        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
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
    }
}
