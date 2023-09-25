using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class LicenceType
    {
        private int id;
        private string description;
        private bool active;

        public LicenceType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = true;
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

        public override bool Equals(object obj)
        {
            try
            {
                LicenceType licenceType = (LicenceType)obj;
                if (this.id == licenceType.id)
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
