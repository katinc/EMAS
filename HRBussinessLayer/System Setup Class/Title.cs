using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Title
    {
        private int id;
        private string description;
        private GenderGroup gender;
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool archived;
        private bool active;

        public Title()
        {
            this.id = 0;
            this.gender = new GenderGroup();
            this.description = string.Empty;
            this.archived = false;
            this.active = false;
            this.user = new User();
            this.dateAndTimeGenerated = DateTime.Today;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public GenderGroup Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
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

        public override bool Equals(object obj)
        {
            try
            {
                Title title = (Title)obj;
                if (this.id == title.id)
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
