using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Controls
    {
        private string page;
        private string controlID;
        private bool active;

        public Controls()
        {
            try
            {
                this.page = string.Empty;
                this.controlID = string.Empty;
                this.active = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public string Page
        {
            get { return page; }
            set { page = value; }
        }

        public string ControlID
        {
            get { return controlID; }
            set { controlID = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
    }
}
