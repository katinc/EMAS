using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Profession
    {
        private Employee employee;
        private User user;
        private bool archived;
        private string nameOfProfession;
        private string fromYear;
        private string fromMonth;
        private string toYear;
        private string toMonth;
        private int id;

        public Profession()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.user = new User();
                this.archived = false;
                this.fromYear = string.Empty;
                this.toYear = string.Empty;
                this.nameOfProfession = string.Empty;
                this.fromMonth = string.Empty;
                this.toMonth = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            
        }

        public Profession(int id, string nameOfProfession, string fromMonth, string toMonth, string fromYear, string toYear)
        {
            try
            {
                this.id = id;
                this.nameOfProfession = nameOfProfession;
                this.fromYear = fromYear;
                this.toYear = toYear;
                this.fromMonth = fromMonth;
                this.toMonth = toMonth;
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

        public string NameOfProfession
        {
            get { return nameOfProfession; }
            set { nameOfProfession = value; }
        }

        public string FromMonth
        {
            get { return fromMonth; }
            set { fromMonth = value; }
        }

        public string FromYear
        {
            get { return fromYear; }
            set { fromYear = value; }
        }

        public string ToMonth
        {
            get { return toMonth; }
            set { toMonth = value; }
        }

        public string ToYear
        {
            get { return toYear; }
            set { toYear = value; }
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

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }
    }
}
