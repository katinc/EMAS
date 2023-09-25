using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Passport
    {
        private int id;
        private bool hasPassport;
        private string passportNo;
        private Nullable<DateTime> passportIssueDate;
        private Nullable<DateTime> passportExpiresDate;
        private string notes;

        public Passport()
        {
            this.id = 0;
            this.hasPassport = false;
            this.passportNo = string.Empty;
            this.passportIssueDate = DateTime.Today;
            this.passportExpiresDate = DateTime.Today;
            this.notes = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string PassportNo
        {
            get { return passportNo; }
            set { passportNo = value; }
        }

        public bool HasPassport
        {
            get { return hasPassport; }
            set { hasPassport = value; }
        }

        public Nullable<DateTime> PassportIssueDate
        {
            get { return passportIssueDate; }
            set { passportIssueDate = value; }
        }

        public Nullable<DateTime> PassportExpiresDate
        {
            get { return passportExpiresDate; }
            set { passportExpiresDate = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
