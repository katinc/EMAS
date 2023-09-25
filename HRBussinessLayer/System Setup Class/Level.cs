using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Level
    {
        private int id;
        private string description;
        private bool active;
        private bool archived;
        private User user;

        public Level()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = true;
                this.archived = false;
                this.user = new User();
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

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
