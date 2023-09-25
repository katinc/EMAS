using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class PayRoll
    {
        private int id;
        private string month;
        private string year;
        private string status;
        private IList<PayRollItem> paySlips;

        public PayRoll()
        {
            this.id = 0;
            this.year = string.Empty;
            this.month = string.Empty;
            this.status = string.Empty;
            this.paySlips = new List<PayRollItem>();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Year
        {
            get { return year; }
            set { year = value; }
        }

        public string Month
        {
            get { return month; }
            set { month = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public IList<PayRollItem> PaySlips
        {
            get { return paySlips; }
            set { paySlips = value; }
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            PayRoll payRoll = (PayRoll)obj;
            if (payRoll.Month  == this.Month && payRoll.Year == this.Year)
            {
                result = true;
            }
            return result;
        }
    }
}
