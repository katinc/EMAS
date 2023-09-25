using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    //DeductionTypes in a Table
    public class DeductionSubCategory
    {
        private int id;
        private string description;
        private DeductionCategory deductionCategory;
        private bool archived;
        private bool active;
        private User user;

        public DeductionSubCategory()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.deductionCategory = new DeductionCategory();
                this.archived = false;
                this.active = true;
                this.User = new User();
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

        public DeductionCategory DeductionCategory
        {
            get { return deductionCategory; }
            set { deductionCategory = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
