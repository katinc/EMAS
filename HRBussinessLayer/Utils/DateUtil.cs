using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensions;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;

namespace HRBussinessLayer.Utils
{
    public class DateUtil
    {
      

        public static int getWorkingDays(DateTime dateFrom, DateTime dateTo)
        {
                       
            int numofdays = (DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month) - dateFrom.Day) + dateTo.Day;
            int numworkingdays = 0;
            for (int i = 1; i <= numofdays; i++)
            {
                DateTime currDate=dateFrom.AddDays(i);
              
                  if (currDate.IsWorkingDay())
                    numworkingdays++;
              
            
            }

            return numworkingdays;

        }

        public static DateTime[]  getWorkingDaysList(DateTime dateFrom, DateTime dateTo)
        {

            int numofdays = (DateTime.DaysInMonth(dateFrom.Year, dateFrom.Month) - dateFrom.Day) + dateTo.Day;
            List<DateTime> datelist = new List<DateTime>();
            for (int i = 1; i <= numofdays; i++)
            {
                DateTime d = dateFrom.AddDays(i);

                    if (d.IsWorkingDay())
                        datelist.Add(d);
            }

            return datelist.ToArray();

        }

        public static DateTime[] getWorkingDaysList(DateTime dateFrom, int days)
        {

            int numofdays = days;
            List<DateTime> datelist = new List<DateTime>();
            for (int i = 1; i <= numofdays; i++)
            {
                DateTime d = dateFrom.AddDays(i);

                    if (d.IsWorkingDay())
                        datelist.Add(d);
             
            }

            return datelist.ToArray();

        }

        public static  DateTime[] generateWorkingDaysRange(DateTime dateFrom, int days)
        {
                       
            List<DateTime> datelist = new List<DateTime>();
            int i = 0;
            while (datelist.Count < days)
            {
                DateTime d = dateFrom.AddDays(i++);

                    if (d.IsWorkingDay())
                        datelist.Add(d);
              

            }

            return datelist.ToArray();

        }
       
        
    }
}
