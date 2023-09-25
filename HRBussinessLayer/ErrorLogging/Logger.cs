using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace HRBussinessLayer.ErrorLogging
{
    public class Logger
    {
        public static void LogError(Exception ex)
        {
            WriteToLogFile(ex.Message);
        }

        public static void WriteToLogFile(string content)
        {
            try
            {
                //if the directory does not exist create the directory
                if (!(Directory.Exists(ConfigurationManager.AppSettings["LogFilePath"].ToString())))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                }

                //get the path for the log file
                StringBuilder strLogFilePath = new StringBuilder();
                strLogFilePath.Append(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                strLogFilePath.Append(@"\LogFile_" + DateTime.Today.ToString("dd-MM-yyyy") + ".txt");

                //if the file doesnot exist create the file
                if (!File.Exists(strLogFilePath.ToString()))
                {
                    FileStream fsErrorLog = new FileStream(strLogFilePath.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsErrorLog.Close();
                }

                //write to the log file
                StreamWriter writer = new StreamWriter(strLogFilePath.ToString(), true);
                writer.WriteLine("********************************************************************");
                writer.WriteLine("Date " + DateTime.Now);
                writer.WriteLine("Content: " + content);
                writer.WriteLine("********************************************************************");
                writer.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
