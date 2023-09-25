using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Data;
using System.Configuration;
using EMASDeviceConsoleService.Libs;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Diagnostics;


namespace EMASDeviceConsoleService
{
    class Monitor
    {
        private Thread t;
        public static bool stopping;
        public static List<Device> Devices;


        public void Start()
        {
            LogManager.Log("Starting Service...", "Information", true);

            stopping = false;
            t = new Thread(new ThreadStart(work));
            t.Start();
           LogManager.Log("Service started", "Information", true);
        }

        public void Stop()
        {

            if (t != null)
            {
                if (t.ThreadState == System.Threading.ThreadState.Suspended)
                    Resume();

                t.Abort();
                t.Join();
                LogManager.Log("EMAS Device Console Stopped");
            }
        }

        public void Pause()
        {
            try
            {
                if (t != null)
                {
                    t.Suspend();

                }

                LogManager.Log("Service Paused");
            }
            catch (ThreadAbortException ex) { }
        }
        public void Resume()
        {
            try
            {
                if (t != null)
                {
                    t.Resume();

                }

                LogManager.Log("Service Resumed");
            }
            catch (ThreadAbortException ex)
            {

            }
        }

        private void work()
        {
            int mins = 10;
            try
            {
               // Devices = getActiveDevices();
               // LogManager.Log(string.Format("{0} Devices Found", Devices.Count),LogManager.LogType.INFORMATION,true);

               /* for (int i = 0; i < Devices.Count;i++ )
                {
                   // new Thread(Devices[i].startActivity).Start();
                  //  ThreadPool.QueueUserWorkItem(Devices[i].startActivity);                    
 

                }*/

                while (true)
                {
                    if (stopping)
                    {
                        break;
                    }

                    try
                    {
                        Process[] pname = System.Diagnostics.Process.GetProcessesByName("EMASDeviceConsole.exe");
                        if (pname.Length == 0)
                        {
                            string path = System.Reflection.Assembly.GetEntryAssembly().Location;
                            string ProgramName = GetDirectoryName(path) + @"\EMASDeviceConsole.exe";
                            System.Diagnostics.Process.Start(ProgramName);
                        }     
                                      
                        System.Threading.Thread.Sleep(1000 * 60 * mins );
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
                    }
                }

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
            }
        }

        static string GetDirectoryName(string f)
        {
            try
            {
                return f.Substring(0, f.LastIndexOf('\\'));
            }
            catch
            {
                return string.Empty;
            }
        }

        public List<Device> getActiveDevices()
        {
            string sql = "SELECT * FROM AttendanceDevices  where IsActive='True'";

            List<Device> deviceLst = new List<Device>();
            Device d = null;
            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader rs = command.ExecuteReader();

                    while (rs.Read())
                    {
                        d = new EMASDeviceConsoleService.Libs.Device();
                        d.DeviceID = Convert.ToInt32(rs["ID"]);
                        d.IPAddress = rs["IPAddress"].ToString();
                        d.Port = Convert.ToInt32( rs["Port"].ToString());
                        d.Location  = rs["Location"].ToString();
                        d.SerialNo  = rs["SerialNo"].ToString();
                        d.IsActive = Convert.ToBoolean(rs["IsActive"].ToString());  
                               
                        if(DBNull.Value != rs["LastSynced"])
                        {
                            d.LastSynced = Convert.ToDateTime(rs["LastSynced"]);
                        }

                        if (DBNull.Value != rs["CurrentStatus"])
                        {
                            d.Status = Convert.ToBoolean(rs["CurrentStatus"].ToString());
                        }

                        if (DBNull.Value != rs["StatusDate"])
                        {
                            d.StatusDate = Convert.ToDateTime(rs["StatusDate"].ToString());
                        }                        
                        deviceLst.Add(d);
                    }
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
                }
            }

            return deviceLst;

        }

        public static void WriteEventLog(string data)
        {
            EMASDeviceConsoleService.EMASDeviceConsole.eventLog1.WriteEntry(data);
        }
    }

}
