using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class GradeCategory
    {
        private int id;
        private string description;
        private string code;
        private bool active;
        private bool archived;
        private User user;

        private string leaveEncashmentRate;
        private string overtimeRate;

        public GradeCategory()
        {
            this.id = 0;
            this.description = string.Empty;
            this.code = string.Empty;
            this.active = false;
            this.archived = false;
            this.user = new User();

            this.leaveEncashmentRate = string.Empty;
            this.overtimeRate = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string LeaveEncashmentRate
        {
            get { return leaveEncashmentRate; }
            set { leaveEncashmentRate = value; }
        }

        public string OverTimeRate
        {
            get { return overtimeRate; }
            set { overtimeRate = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
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
