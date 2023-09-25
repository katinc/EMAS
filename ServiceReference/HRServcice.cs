using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eMAS.DataReference;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.ServiceReference
{
    public class HRServcice
    {
        private hrContextDataContext hrcontext = new hrContextDataContext();

        public int GetWeekEndsInDateRange(DateTime StartDate, DateTime EndDate, string LeaveType)
        {
            var getNumDays = hrcontext.LeaveTypes.SingleOrDefault(u => u.Description == LeaveType);
            int num = 0;
            if(getNumDays != null && getNumDays.CountWeekends == true)
            {
                TimeSpan Difference = EndDate - StartDate;

                int days = Difference.Days;
                for (var i = 0; i <= days; i++)
                {
                    var DateInCheck = StartDate.AddDays(i);
                    if (DateInCheck.DayOfWeek == DayOfWeek.Saturday || DateInCheck.DayOfWeek == DayOfWeek.Sunday)
                    {
                        num++;
                    }
                }
            }
            
            return num;
        }

        /// <summary>
        /// Checks for available holidays within a leave period and returns the number of available holidays
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="NumberOfDays"></param>
        /// <param name="LeaveTypeID"></param>
        /// <returns></returns>
        public int CheckHolidaysAndWeekends(DateTime StartDate, DateTime EndDate, int NumberOfDays, string LeaveType)
        {
            string message = string.Empty;
            int num = 0;
            try
            {
                if(NumberOfDays == 0)
                {
                    var getNumDays = hrcontext.LeaveTypes.SingleOrDefault(u => u.Description == LeaveType);
                    if(getNumDays != null)
                    {
                        NumberOfDays = (int)getNumDays.MaximumEntitlement;
                        EndDate = StartDate.AddDays((double)NumberOfDays);

                        if (getNumDays.CountHolidays == true)
                        {
                            var getHolidays = hrcontext.Holidays2s.ToList();
                            if (getHolidays.Count() > 0)
                            {

                                foreach (var item in getHolidays)
                                {
                                    while (item.Date >= StartDate || item.Date <= EndDate)
                                    {
                                        if (getNumDays.CountWeekends == true)
                                        {
                                            if (item.Date.Value.DayOfWeek == DayOfWeek.Sunday || item.Date.Value.DayOfWeek == DayOfWeek.Saturday)
                                            {
                                                num++;
                                            }
                                        }
                                        else
                                        {
                                            num++;
                                        }
                                    }
                                }
                            }
                        }
                        else if (getNumDays.CountWeekends == true)
                        {
                            TimeSpan Difference = EndDate - StartDate;
                            int days = Difference.Days;
                            for (var i = 0; i <= days; i++)
                            {
                                var DateInCheck = StartDate.AddDays(i);
                                if (DateInCheck.DayOfWeek == DayOfWeek.Saturday || DateInCheck.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    num++;
                                }
                            }
                        }
                    }
                }
                else
                {
                    var getNumDays = hrcontext.LeaveTypes.SingleOrDefault(u => u.Description == LeaveType);
                    if (getNumDays != null)
                    {
                        EndDate = StartDate.AddDays((double)NumberOfDays);

                        if (getNumDays.CountHolidays == true)
                        {
                            var getHolidays = hrcontext.Holidays2s.Where(u => u.Date.Value.Year == DateTime.Now.Year).ToList();
                            if (getHolidays.Count() > 0)
                            {

                                foreach (var item in getHolidays)
                                {
                                    while (item.Date >= StartDate || item.Date <= EndDate)
                                    {
                                        if (getNumDays.CountWeekends == true)
                                        {
                                            if (item.Date.Value.DayOfWeek == DayOfWeek.Sunday || item.Date.Value.DayOfWeek == DayOfWeek.Saturday)
                                            {
                                                num++;
                                            }
                                        }
                                        else
                                        {
                                            num++;
                                        }
                                    }
                                }
                            }
                        }
                        else if (getNumDays.CountWeekends == true)
                        {
                            TimeSpan Difference = EndDate - StartDate;
                            int days = Difference.Days;
                            for (var i = 0; i <= days; i++)
                            {
                                var DateInCheck = StartDate.AddDays(i);
                                if (DateInCheck.DayOfWeek == DayOfWeek.Saturday || DateInCheck.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    num++;
                                }
                            }
                        }
                    }
                    
                   
                    
                    
                }

                return num;
            }
            catch(Exception er)
            {
                Logger.LogError(er);
                return 0;
            }
        }

    }
}
