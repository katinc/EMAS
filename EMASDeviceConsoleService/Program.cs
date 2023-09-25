using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace EMASDeviceConsoleService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
       
        static void Main()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // We are running with a debugger attached, so start
                // the service directly.

                EMASDeviceConsole service = new EMASDeviceConsole();
                string[] args = new string[] { "arg1", "arg2" };
                service.StartFromDebugger(args);
             

            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    new EMASDeviceConsole() 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
