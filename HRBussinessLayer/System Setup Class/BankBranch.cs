using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class BankBranch
    {
        private int id;
        private string code;
        private string description;
        private string sortcode;
        private Bank bank;
        private User user;
        private bool active;
        private bool archived;

        public BankBranch()
        {
            this.id = 0;
            this.code = string.Empty;
            this.description = string.Empty;
            this.sortcode = string.Empty;
            this.bank = new Bank();
            this.user = new User();
            this.active = true;
            this.archived = false;
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
        public string SortCode
        {
            get { return sortcode; }
            set { sortcode = value; }
        }
        public Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
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

        public override bool Equals(object obj)
        {
            try
            {
                BankBranch bankBranch = (BankBranch)obj;
                if (this.id == bankBranch.id)
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
