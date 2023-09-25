using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class DisabilityType
    {
        private int id;
        private string description;
        private bool active;
        private User user;

        public DisabilityType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = true;
            this.user = new User();
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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                DisabilityType disabilityType = (DisabilityType)obj;
                if (this.id == disabilityType.id)
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
