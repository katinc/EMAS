using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class SanctionType
    {
        private int id;
        private string code;
        private string description;
        private bool active;
        private bool archived;
        private bool payment;
        private bool separated;
        private bool reinstatement;
        private User user;

        public SanctionType()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.code = string.Empty;
                this.active = true;
                this.archived = false;
                this.payment = false;
                this.separated = false;
                this.reinstatement = false;
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

        public bool Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public bool Separated
        {
            get { return separated; }
            set { separated = value; }
        }

        public bool Reinstatement
        {
            get { return reinstatement; }
            set { reinstatement = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

    }
}
