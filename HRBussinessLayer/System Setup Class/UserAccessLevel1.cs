using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserAccessLevel1
    {
        private int id;
        private string description;
        private bool active;

        public UserAccessLevel1()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = true;
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

        public override bool Equals(object obj)
        {
            UserAccessLevel1 accessLevel = (UserAccessLevel1)obj;
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
