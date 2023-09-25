using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class District
    {
        private int id;
        private string code;
        private string description;
        private Region region;
        private bool active;
        private bool archived;
        private DateTime dateAndTimeGenerated;
        private User user;

        public District()
        {
            try
            {
                this.id = 0;
                this.code = string.Empty;
                this.description = string.Empty;
                this.active = false;
                this.archived = false;
                this.region = new Region();
                this.dateAndTimeGenerated = DateTime.Today;
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

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public Region Region
        {
            get { return region; }
            set { region = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                District district = (District)obj;
                if (this.id == district.id)
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
