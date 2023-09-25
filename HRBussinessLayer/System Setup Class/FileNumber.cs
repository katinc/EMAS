using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class FileNumber
    {
        private int id;
        private string description;
        private User user;
        private bool inUse;
        private bool archived;
        private string fileLocation;

        public FileNumber()
        {
            this.id = 0;
            this.description = string.Empty;
            this.user = new User();
            this.inUse = true;
            this.archived = false;
            this.fileLocation = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                FileNumber fileNumber = (FileNumber)obj;
                if (this.id == fileNumber.id)
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
