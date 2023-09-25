using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class AppointmentType
    {
        private int id;
        private string description;
        private bool active;
        private User user;
        private bool archived;
        private DateTime archivedTime;
        private int archiverer;

        public AppointmentType()
        {
            try
            {
                this.id = 0;
                this.description = string.Empty;
                this.active = true;
                this.user = new User();
                this.archived = false;
                this.archivedTime = DateTime.Now;
                this.archiverer = 0;
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

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public DateTime ArchivedTime
        {
            get { return archivedTime; }
            set { archivedTime = value; }
        }

        public int Archiverer
        {
            get { return archiverer; }
            set { archiverer = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                AppointmentType appointmentType = (AppointmentType)obj;
                if (this.id == appointmentType.id)
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
