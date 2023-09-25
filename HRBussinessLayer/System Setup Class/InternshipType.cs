using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class InternshipType
    {
        private int id;
        private string description;
        private User user;
        private bool active;
        private bool archived;
        private DateTime serverTime;
        private DateTime serverDate;

        public InternshipType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = false;
            this.archived = false;
            this.user = new User();
            this.serverDate = DateTime.Today;
            this.serverTime = DateTime.Today;
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

        public DateTime ServerDate
        {
            get { return serverDate; }
            set { serverDate = value; }
        }

        public DateTime ServerTime
        {
            get { return serverTime; }
            set { serverTime = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
