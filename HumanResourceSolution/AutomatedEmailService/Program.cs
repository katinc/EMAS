using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AutomatedEmailService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
#if DEBUG

            BirthdayEmailService birthdayEmailService = new BirthdayEmailService();
            birthdayEmailService.onDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new BirthdayEmailService() 
			};
            ServiceBase.Run(ServicesToRun);
#endif
 
        }
    }
}
