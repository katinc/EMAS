using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.System_Setup_Class
{
  public  class AppraisalType
    {
        public int ID { get; set; }
        public string  Description { get; set; }
        public UserInfo User { get; set; }
        public DateTime DateModified { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
    }
}
