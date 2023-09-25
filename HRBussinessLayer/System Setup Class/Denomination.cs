using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Denomination
    {
        private int id;
        private string description;
        private Religion religion;
        private bool active;
        private bool archived;
        private User user;

        public Denomination()
        {
            this.id = 0;
            this.description = string.Empty;
            this.religion = new Religion();
            this.active = true;
            this.archived = false;
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

        public Religion Religion
        {
            get { return religion; }
            set { religion = value; }
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
