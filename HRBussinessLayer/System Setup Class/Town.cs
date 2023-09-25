using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Town
    {
        private int id;
        private string description;
        private string code;
        private District district;
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool archived;
        private bool active;

        public Town()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.code = string.Empty;
                this.District = new District();
                this.user = new User();
                this.DateAndTimeGenerated = DateTime.Today;
                this.user = new User();
            }
            catch(Exception ex)
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

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public District District
        {
            get { return district; }
            set { district = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
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
