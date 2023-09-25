using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class ControlToRole
    {
        private Role role;
        private Controls control;
        private User user;
        private int invisible;
        private int disabled;
        private bool active;

        public ControlToRole()
        {
            try
            {
                this.role = new Role();
                this.control = new Controls();
                this.user=new User();
                this.invisible = 0;
                this.disabled = 0;
                this.active = false;
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

        public Controls Controls
        {
            get { return control; }
            set { control = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public int Invisible
        {
            get { return invisible; }
            set { invisible = value; }
        }

        public int Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
