using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class LeaveType
    {
        private int id;
        private string description;
        private int maximumEntitlement;
        private DateTime dateModified;
        private User user;
        private bool active;

        public LeaveType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.maximumEntitlement = 0;
            this.dateModified = DateTime.Now;
            this.user = new User();
            this.active = true;
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

        public int MaximumEntitlement
        {
            get { return maximumEntitlement; }
            set { maximumEntitlement = value; }
        }

        public DateTime DateModified
        {
            get { return dateModified; }
            set { dateModified = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
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
                LeaveType leaveType = (LeaveType)obj;
                if (this.id == leaveType.id)
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
