﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Country
    {
        private int id;
        private string description;
        private bool active;
        private bool archived;

        public Country()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = false;
                this.archived = false;
            }
            catch(Exception ex)
            {
                string str = ex.Message;
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
    }
}
