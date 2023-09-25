using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HRBussinessLayer
{
   public static class Hospital
    {
       private static DateTime currentDate = DateTime.Today;
       private static string currentTime = DateTime.Today.TimeOfDay.ToString();

       public static DateTime CurrentDate
       {
           get { return currentDate; }
           set { currentDate = value; }
       }

       public static string CurrentTime
       {
           get { return currentTime; }
           set { currentTime = value; }
       }

    }
}
