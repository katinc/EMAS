using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
  
    public class StaffDocument
    {
        private int id;
        private Nullable<DateTime> dateCreated;
        private string description;
        private string documentGroup;
        private string documentType;
        private byte[] documentContent;
        private string path;
        private Employee employee;
        private User user;
        private bool archived;

        public StaffDocument()
        {
            try
            {
                this.id = 0;
                this.dateCreated = null;
                this.description = string.Empty;
                this.documentGroup = string.Empty;
                this.documentType = string.Empty;
                this.path = string.Empty;
                this.documentContent = null;
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

        public StaffDocument(DateTime dateCreated, string description, string documentGroup, string documentType,byte[] documentContent)
        {
            try
            {
                this.dateCreated = dateCreated;
                this.description = description;
                this.documentGroup = documentGroup;
                this.documentType = documentType;
                this.documentContent = documentContent;
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

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public Nullable<DateTime> DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string DocumentGroup
        {
            get { return documentGroup; }
            set { documentGroup = value; }
        }

        public string DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        public byte[] DocumentContent
        {
            get { return documentContent; }
            set { documentContent = value; }
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
