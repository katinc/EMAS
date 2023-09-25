using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Role
    {
        private int id;
        private string name;
        private bool active;

        public Role()
        {
            try
            {
                this.id = 0;
                this.name = string.Empty;
                this.active = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int RoleID
        {
            get { return id; }
            set { id = value; }
        }

        public string RoleName
        {
            get { return name; }
            set { name = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                Role role = (Role)obj;
                if (this.id == role.id)
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
