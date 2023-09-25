using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace EMASDeviceConsole.Libs
{
    public class AppSettings
    {

        public static string Read(string key)
        {
            try
            {
                return ConfigurationSettings.AppSettings[key];
            }
            catch (Exception ex)
            {
                LogManager.Writelog("Error", ex.Message, false);
                if (AppSettings.isDebugMode)
                {
                    LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                    LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                    LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                }
                return null;
            }
        }

        public static bool isDebugMode
        {
            get
            {
                if (ConfigurationSettings.AppSettings["logMode"].Equals("debug", StringComparison.CurrentCultureIgnoreCase))
                    return true;
                else
                    return false;

            }
        }
      

    }
}
