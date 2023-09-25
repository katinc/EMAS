using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class StaffStatus
    {
        private int id;
        private string code;
        private string description;
        private bool active;
        private bool archived;
        private User user;

        public StaffStatus()
        {
            try
            {
                this.id = 0;
                this.code = string.Empty;
                this.description = string.Empty;
                this.active = true;
                this.archived = false;
                this.user = new User();
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

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
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

        public override bool Equals(object obj)
        {
            try
            {
                StaffStatus staffStatus = (StaffStatus)obj;
                if (this.id == staffStatus.id)
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
