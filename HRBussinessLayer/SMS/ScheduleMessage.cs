using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.SMS
{
    public class ScheduleMessage
    {
        private int id;
        private string from;
        private string to;
        private string message;
        private DateTime schedule_time;
        private string status;

        public ScheduleMessage()
        {
            this.id = 0;
            this.from = string.Empty;
            this.to = string.Empty;
            this.message = string.Empty;
            this.schedule_time = DateTime.Today;
            this.status = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string From
        {
            get { return from; }
            set { from = value; }
        }

        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public DateTime Schedule_time
        {
            get { return schedule_time; }
            set { schedule_time = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public override bool Equals(object obj)
        {
            try
            {
                ScheduleMessage scheduleMessage = (ScheduleMessage)obj;
                if (this.id == scheduleMessage.id)
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
