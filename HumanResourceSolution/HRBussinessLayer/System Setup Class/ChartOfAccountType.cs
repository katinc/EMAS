using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class ChartOfAccountType
    {
        private int id;
        private string code;
        private string description;
        private User user;
        private bool active;

        public ChartOfAccountType()
        {
            try
            {
                this.id = 0;
                this.code = string.Empty;
                this.description = string.Empty;
                this.user = new User();
                this.active = true;
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

        public override bool Equals(object obj)
        {
            try
            {
                ChartOfAccountType chartOfAccountType = (ChartOfAccountType)obj;
                if (this.id == chartOfAccountType.id)
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
