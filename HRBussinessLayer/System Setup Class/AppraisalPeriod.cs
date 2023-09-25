using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
  public  class AppraisalPeriod
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
    }
}
