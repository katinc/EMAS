using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffLanguage
    {
        private int id;
        private Employee employee;
        private Language language;
        private string languageLevel;
        private bool active;
        private DateTime dateCreated;
        private bool archived;
        private User user;

        public StaffLanguage()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.language = new Language();
                this.languageLevel = string.Empty;
                this.active = false;
                this.dateCreated = DateTime.Today;
                this.archived = false;
                this.user = new User();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public StaffLanguage(int id, string staffID, int staffCode, int languageID, string language, string languageLevel, bool active, DateTime dateCreated)
        {
            try
            {
                this.id = id;
                this.employee = new Employee();
                this.language = new Language();
                this.employee.ID = staffCode;
                this.employee.StaffID = staffID;
                this.language.Description = language;
                this.language.ID = languageID;
                this.languageLevel = languageLevel;
                this.active = active;
                this.dateCreated = dateCreated;
                this.archived = false;
                this.user = new User();
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

        public Language Language
        {
            get { return language; }
            set { language = value; }
        }

        public string LanguageLevel
        {
            get { return languageLevel; }
            set { languageLevel = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
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
