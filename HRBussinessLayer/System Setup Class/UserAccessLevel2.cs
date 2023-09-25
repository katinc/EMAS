using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserAccessLevel2  
    {
        
        private int id;
        private string description;
        private bool active;
        private UserAccessLevel1 userAccessLevel1;

        public UserAccessLevel2()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = true;
                this.userAccessLevel1 = new UserAccessLevel1();
            }
            catch (Exception ex)
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

        public UserAccessLevel1 UserAccessLevel1
        {
            get { return userAccessLevel1; }
            set { userAccessLevel1 = value; }
        }

        public override bool Equals(object obj)
        {
            UserAccessLevel2 accessLevel = (UserAccessLevel2)obj;
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
