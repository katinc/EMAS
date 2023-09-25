using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Zone
    {
        private int id;
        private string description;
        private bool active;
        private bool archived;

        public Zone()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = true;
            this.archived = false;
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

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                Zone zone = (Zone)obj;
                if (this.id == zone.id)
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
