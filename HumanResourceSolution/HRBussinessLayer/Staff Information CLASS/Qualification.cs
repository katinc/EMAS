using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Qualification
    {
        private Employee employee;
        private User user;
        private bool archived;
        private string nameOfInstitution;
        private string certificateObtained;
        private string  fromMonth;
        private string toMonth;
        private string toYear;
        private string fromYear;
        private int id;

        public Qualification()
        {
            try
            {
                this.id = 0;
                this.nameOfInstitution = string.Empty;
                this.certificateObtained = string.Empty;
                this.fromYear = string.Empty;
                this.toYear = string.Empty;
                this.fromMonth = string.Empty;
                this.toMonth = string.Empty;
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
        public Qualification(int id,string nameOfInstitution, string certificateObtained,string fromMonth, string fromYear, string toMonth,string toYear)
        {
            try
            {
                this.id = id;
                this.nameOfInstitution = nameOfInstitution;
                this.certificateObtained = certificateObtained;
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

        public string NameOfInstitution
        {
            get { return nameOfInstitution; }
            set { nameOfInstitution = value; }
        }

        public string CertificateObtained
        {
            get { return certificateObtained; }
            set { certificateObtained = value; }
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
