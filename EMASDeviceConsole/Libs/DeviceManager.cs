using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace EMASDeviceConsole.Libs
{
    public class DeviceManager
    {
       
        public bool PingDevice(string IPAddress)
        {
            bool status = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(IPAddress);
                status = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return status;

        }

        public bool ConnectToDevice(ref zkemkeeper.CZKEMClass deviceHandle, string IPAddress)
        {
            return ConnectToDevice(ref deviceHandle, IPAddress, 4370);

        }
        public bool ConnectToDevice(ref zkemkeeper.CZKEMClass deviceHandle,string IPAddress, int Port)
        {
            bool status = false;

            try
            {
                status = deviceHandle.Connect_Net(IPAddress, Port);
            }
            catch (Exception ex) { }

            return status;
        }

        public void DisconnectDevice(ref zkemkeeper.CZKEMClass deviceHandle)
        {
            deviceHandle.Disconnect();            
        }
    }
}
