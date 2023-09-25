using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserAccessLevel4 
    {
        private int id;
        private string description;
        private bool active;
        private UserAccessLevel3 userAccessLevel3;


        public UserAccessLevel4()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = true;
                this.userAccessLevel3 = new UserAccessLevel3();
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

        public UserAccessLevel3 UserAccessLevel3
        {
            get { return userAccessLevel3; }
            set { userAccessLevel3 = value; }
        }

        public override bool Equals(object obj)
        {
            UserAccessLevel4 accessLevel = (UserAccessLevel4)obj;
            if (accessLevel.id == this.id)
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
