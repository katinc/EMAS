using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserRole
    {
        private int id;
        private User user;
        private UserCategoryRole userCategoryRole;

        public UserRole()
        {
            try
            {
                this.id = 0;
                this.user = new User();
                this.userCategoryRole = new UserCategoryRole();
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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public UserCategoryRole UserCategoryRole
        {
            get { return userCategoryRole; }
            set { userCategoryRole = value; }
        }
    }
}
