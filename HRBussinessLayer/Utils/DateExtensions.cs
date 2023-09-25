using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Extensions
{
    public static class DateExtensions
    {
       
        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                && date.DayOfWeek != DayOfWeek.Sunday;
        }
        
       
    }

}