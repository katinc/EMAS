using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Specialty
    {
        private int id;
        private string description;
        private User user;
        private bool archived;
        private bool active;

        public Specialty()
        {
            this.id = 0;
            this.description = string.Empty;
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
