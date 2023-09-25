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
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Windows.Forms;
using EMASDeviceConsole.Libs;


namespace EMASDeviceConsole
{
    class Monitor
    {     
        public static bool stopping;
        public static List<Device> Devices;


        public void AttemptConnection(Device  Dev)
        {
            bool status = false;
            int dIndex = Devices.FindIndex(d => d.IPAddress == Dev.IPAddress );
            if (dIndex > -1)
            {
                Devices[dIndex].startActivity();
            }
            else
            {
                Dev.startActivity();
                Devices.Add(Dev);
            }           
        }

        public void AttemptDisConnection(Device Dev)
        {
            bool status = false;
            int dIndex = Devices.FindIndex(d => d.IPAddress == Dev.IPAddress);
            if (dIndex > -1)
            {
                Devices[dIndex].Disconnect();
                Devices[dIndex].unRegisterEvents();
            }           
        }

        public bool SetDeviceTime(Device Dev)
        {
            bool status = false;
            int dIndex = Devices.FindIndex(d => d.IPAddress == Dev.IPAddress);
            if (dIndex > -1)
            {
                if (Devices[dIndex].Connected)
                {
                    status = Devices[dIndex].setLocalTime();                    
                }                
            }

            return status;
        }

        public bool SyncDevice(Device Dev)
        {
            bool status = false;
            int dIndex = Devices.FindIndex(d => d.IPAddress == Dev.IPAddress);
            if (dIndex > -1)
            {
                if (Devices[dIndex].Connected)
                {
                    status = Devices[dIndex].SyncMe();
                }
            }

            return status;
        }

        public bool ImportLog(Device Dev)
        {
            bool status = false;
            int dIndex = Devices.FindIndex(d => d.IPAddress == Dev.IPAddress);
            if (dIndex > -1)
            {
                if (Devices[dIndex].Connected)
                {
                    status = Devices[dIndex].ImportMe();
                }
            }

            return status;
        }

        public  void work()
        {
            try
            {
                Devices = getActiveDevices();
                LogManager.Log(string.Format("{0} Devices Found", Devices.Count),LogManager.LogType.INFORMATION,true);

                for (int i = 0; i < Devices.Count;i++ )
                {
                   // new Thread(Devices[i].startActivity).Start();
                  //  ThreadPool.QueueUserWorkItem(Devices[i].startActivity);                    

                    Devices[i].startActivity();
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
                        d = new Libs.Device();
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
           // EMASDeviceConsoleService.EMASDeviceConsole.eventLog1.WriteEntry(data);
        }
    }

}
