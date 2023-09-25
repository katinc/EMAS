using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
  public  class StaffIdentificationType
  {
      public StaffIdentificationType()
      {
          this.Active = true;
          this.Archived=false;
      }
      public int ID { get; set; }
      public string CardName { get; set; }
      public bool Active { get; set; }
      public bool Archived { get; set; }
  }
}
