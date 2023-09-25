using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Alerts
{
   public enum notifyType
    {
        Leave,
        Probation,
        Pention,
        None
    }

  public  class Notification
    {
        public int ID { get; set; }
        public string caption { get; set; }
        public string message { get; set; }
        public notifyType Type { get; set; }

       

        public Notification()
        {
            this.ID = 0;
            this.caption = string.Empty;
            this.message = string.Empty;
            this.Type = notifyType.None;

        }

       
    }

    
}
