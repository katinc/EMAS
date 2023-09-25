using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.ServiceModel;
using System.Text;
using System.Threading;
using EMASDeviceConsoleService.Libs;
using System.Windows.Forms;


namespace EMASDeviceConsoleService
{
    [ServiceContract(Namespace = "http://EMASDeviceConsoleService")]
    public partial class EMASDeviceConsole : ServiceBase
    {
        public ServiceHost serviceHost = null;
        private bool stopping = false;
        private ManualResetEvent stoppedEvent;
        private Monitor m;
         
        public EMASDeviceConsole()
        {
            InitializeComponent();

            m = new Monitor();
            stopping = false;
            stoppedEvent = new ManualResetEvent(false); 

            if (!System.Diagnostics.EventLog.SourceExists("EMAS Device Console"))
                System.Diagnostics.EventLog.CreateEventSource("EMAS Device Console", "Application");

            eventLog1.Source = "EMAS Device Console";
            eventLog1.Log = "Application";
            eventLog1.EnableRaisingEvents = true;
            
        }

        protected override void OnStart(string[] args)
        {
           
            eventLog1.WriteEntry("EMAS Device Console Starting..."); 

            if (serviceHost != null)
            {
                serviceHost.Close();
            }

             //Create a ServiceHost for the CalculatorService type and 
             //provide the base address.
            serviceHost = new ServiceHost(typeof(EMASDeviceConsole));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
            m.Start();
                       
        }
       

        public void StartFromDebugger(string[] args)
        {
           OnStart(args);            
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("EMAS Device Console Stopping");
            Monitor.stopping = true;

            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }

            this.stopping = true;
            this.stoppedEvent.WaitOne();

        }

        [OperationContract]
        public bool Ping(string Host)
        {
            return new DeviceManager().PingDevice(Host);
        }

        [OperationContract]
        public bool GetDeviceStatus(string Host)
        {
            return new DeviceManager().PingDevice(Host);
        }

      
    }
}
