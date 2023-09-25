using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Loan
    {
        private int id;
        private string description;
        private LoanType type;
        private bool inactive;
        private User user;
        private bool archived;

        public Loan()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.type = new LoanType();
                this.user = new User();
                this.inactive = false;
                this.archived = false;
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

        public LoanType Type
        {
            get { return type; }
            set { type = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Inactive
        {
            get { return inactive; }
            set { inactive = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }
    }
}
