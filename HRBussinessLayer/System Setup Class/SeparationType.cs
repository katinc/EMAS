using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class SeparationType
    {
        private int id;
        private string description;
        private bool active;
        private bool reinstatement;

        public SeparationType()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = false;
                this.reinstatement = false;
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

        public bool Reinstatement
        {
            get { return reinstatement; }
            set { reinstatement = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
