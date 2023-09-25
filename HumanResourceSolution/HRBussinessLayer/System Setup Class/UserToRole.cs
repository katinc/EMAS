using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserToRole
    {
        private User user;
        private Role role;

        public UserToRole()
        {
            try
            {
                this.user = new User();
                this.role = new Role();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Role Role
        {
            get { return role; }
            set { role = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
