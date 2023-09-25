using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class HealthFacilityType
    {
        private int id;
        private string description;
        private bool active;
        private bool archived;

        public HealthFacilityType()
        {
            this.id = 0;
            this.description = string.Empty;
            this.active = false;
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
                HealthFacilityType healthFacilityType = (HealthFacilityType)obj;
                if (this.id == healthFacilityType.id)
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
