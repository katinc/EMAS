using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
   public class GradeSalaries
    {
        public int CategoryID { get; set; }
        public int GradeID { get; set; }
        public int Step { get; set; }
        public double BasicSalary { get; set; }
        public double HourlyRate { get; set; }
        public int UserID { get; set; }
    }
}
