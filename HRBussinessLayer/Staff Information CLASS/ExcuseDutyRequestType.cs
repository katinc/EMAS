using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.Staff_Information_CLASS
{
   public class ExcuseDutyRequestType
    {
        public int id { get; set; }
        public string description { get; set; }
        public int userid { get; set; }
        public bool active { get; set; }
        public bool archived { get; set; }

        public ExcuseDutyRequestType()
        {
            this.id = 0;
            this.description = null;
            this.userid = 0;
            this.active = false;
            this.archived = false;
        }
        public int getRequestId(List<ExcuseDutyRequestType> lstExcuseDutyRequestType,string requestText)
        {
            foreach (var ls in lstExcuseDutyRequestType)
            {
                if (ls.description == requestText.Trim())
                  return ls.id;
            }
            return 0;
        }
    }
}
