using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class JobTitle
    {
        private int id;
        private string code;
        private string description;
        private User user;
        private bool active;
        private bool archived;

        public JobTitle()
        {
            this.id = 0;
            this.code = string.Empty;
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

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
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
    }
}
