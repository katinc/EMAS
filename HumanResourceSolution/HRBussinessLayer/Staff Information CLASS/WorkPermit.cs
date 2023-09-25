using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class WorkPermit
    {
        private string id;
        private string hasPermit;
        private Nullable<DateTime> permitExpires;
        private decimal duration;
        private string notes;
        private string workPermitID;
       

        public WorkPermit()
        {
            id = string.Empty;
            hasPermit = string.Empty;
            permitExpires = null;
            duration = 0;
            notes = string.Empty;
            workPermitID = string.Empty;
        }

        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string HasPermit
        {
            get { return hasPermit; }
            set { hasPermit = value; }
        }

        public Nullable<DateTime> PermitExpires
        {
            get { return permitExpires; }
            set { permitExpires = value; }
        }

        public decimal Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public string WorkPermitID
        {
            get { return workPermitID; }
            set { workPermitID = value; }
        }
    }
}
