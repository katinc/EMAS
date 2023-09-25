using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.Configuration;
using HRBussinessLayer.EMAIL;
using HRDataAccessLayer.EMAILS;
using HRDataAccessLayerBase;
using HRDataAccessLayer;

namespace AutomatedEmailService
{
    partial class BirthdayEmailService : ServiceBase
    {
        private Timer scheduleTimer = null;
        private DateTime lastRun;
        private bool flag;
        private IDAL dal;
        private IList<StaffEmail> staffEmails;

        public BirthdayEmailService()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.staffEmails=new List<StaffEmail>();

            if (!System.Diagnostics.EventLog.SourceExists("EmailSource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("EmailSource", "EmailLog");
            }
            eventLogEmail.Source = "EmailSource";
            eventLogEmail.Log = "EmailLog";

            scheduleTimer = new Timer();
            scheduleTimer.Interval = 1 * 1 * 60 * 1000;
            scheduleTimer.Elapsed += new ElapsedEventHandler(scheduleTimer_Elapsed);

        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            flag = true;
            lastRun = DateTime.Now;
            scheduleTimer.Start();
            eventLogEmail.WriteEntry("Started");
        }

        protected void scheduleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (flag == true)
            {
                ServiceEmailMethod();
                lastRun = DateTime.Now;
                flag = false;
            }
            else if (flag == false)
            {
                if (lastRun.Date < DateTime.Now.Date)
                {
                    ServiceEmailMethod();
                }
            }
        }

        private void ServiceEmailMethod()
        {
            eventLogEmail.WriteEntry("In Sending Email Method");
            staffEmails=dal.GetAll<StaffEmail>();
            //EmailComponent.GetEmailIdsFromDB getEmails = new EmailComponent.GetEmailIdsFromDB();
            //getEmails.connectionString = ConfigurationManager.ConnectionStrings["CustomerDBConnectionString"].ConnectionString;
            //getEmails.storedProcName = "GetBirthdayBuddiesEmails";
            //System.Data.DataSet ds = getEmails.GetMailIds();

            Email email = new Email();
            email.fromEmail = "faisallarai@gmail.com";
            email.fromName = "NCHS";
            email.subject = "Birthday Wishes";
            email.smtpServer = "smtp.gmail.com";
            email.smtpCredentials = new System.Net.NetworkCredential("faisallarai@gmail.com", "Fbi0244656852#");

            foreach (StaffEmail staffEmail in staffEmails)
            {
                email.messageBody = "<h4>Hello " + staffEmail.StaffID + "</h4><br/><h3>We Wish you a very Happy" +
                                    "Birthday  to You!!! Have a bash...</h3><br/><h4>Thank you.</h4>";

                bool result = email.SendEmailAsync(staffEmail.Email, staffEmail.StaffID, null, null, string.Empty);

                if (result == true)
                {
                    eventLogEmail.WriteEntry("Message Sent SUCCESS to - " + staffEmail.Email +
                                             " - " + staffEmail.StaffID);
                }
                else
                {
                    eventLogEmail.WriteEntry("Message Sent FAILED to - " + staffEmail.Email +
                                             " - " + staffEmail.StaffID);
                }

            }
        }

        protected override void OnStop()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("Stopped");
        }
        protected override void OnPause()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("Paused");
        }
        protected override void OnContinue()
        {
            scheduleTimer.Start(); ;
            eventLogEmail.WriteEntry("Continuing");
        }
        protected override void OnShutdown()
        {
            scheduleTimer.Stop();
            eventLogEmail.WriteEntry("ShutDowned");
        }
    }
}