using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserAccessLevel3  
    {
        private int id;
        private string description;
        private bool active;
        private UserAccessLevel2 userAccessLevel2;

        public UserAccessLevel3()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active=true;
                this.userAccessLevel2 = new UserAccessLevel2();
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

        public UserAccessLevel2 UserAccessLevel2
        {
            get { return userAccessLevel2; }
            set { userAccessLevel2 = value; }
        }

        public override bool Equals(object obj)
        {
            UserAccessLevel3 accessLevel = (UserAccessLevel3)obj;
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
