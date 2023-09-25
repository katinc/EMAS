using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceProcess;

namespace EMASDeviceConsole.Libs
{
    public class ServiceMonitor
    {
        ServiceController sc = new ServiceController("EMAS Device Console");

        public ServiceControllerStatus getStatus()
        {
            sc.Refresh();
            return sc.Status;
                    
        }

        public void Start()
        {
            sc.Start();
        }
        public void Stop()
        {
            sc.Stop();
        }

        public void Pause()
        {
            sc.Pause();
        }
        public void Resume()
        {
            sc.Continue();
        }
        public void Restart()
        {
            Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped);
            Start();
        }

    }
}
