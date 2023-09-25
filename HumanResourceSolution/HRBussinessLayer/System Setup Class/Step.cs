using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Step
    {
        private int id;
        private string description;
        private bool archived;
        private bool active;
        private User user;

        public Step()
        {
            this.id = 0;
            this.description = string.Empty;
            this.archived = false;
            this.active = true;
            this.user = new User();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
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
                Step step = (Step)obj;
                if (this.id == step.id)
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
