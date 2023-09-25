using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Visa
    {
        private int id;
        private string visaNo;
        private bool hasVisa;
        private Nullable<DateTime> validFrom;
        private Nullable<DateTime> expiresDate;
        private string visaType;
        private string notes;

        public Visa()
        {
            this.id = 0;
            this.visaNo = string.Empty;
            this.hasVisa = false;
            this.validFrom = DateTime.Today;
            this.expiresDate = DateTime.Today;
            this.visaType = string.Empty;
            this.notes = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string VisaNo
        {
            get { return visaNo; }
            set { visaNo = value; }
        }

        public bool HasVisa
        {
            get { return hasVisa; }
            set { hasVisa = value; }
        }

        public Nullable<DateTime> ValidFrom
        {
            get { return validFrom; }
            set { validFrom = value; }
        }

        public Nullable<DateTime> ExpiresDate
        {
            get { return expiresDate; }
            set { expiresDate = value; }
        }

        public string VisaType
        {
            get { return visaType; }
            set { visaType = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}
