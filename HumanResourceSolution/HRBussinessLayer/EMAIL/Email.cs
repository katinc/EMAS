using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Runtime.Remoting.Messaging;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace HRBussinessLayer.EMAIL
{
        public class Email
        {
            public string subject { get; set; }
            public string fromEmail { get; set; }
            public string fromName { get; set; }
            public string messageBody { get; set; }
            public string smtpServer { get; set; }
            public NetworkCredential smtpCredentials { get; set; }

            public bool SendEmail(string toEmail,string toName,ReportDocument rpt, ExportFormatType fileType, string fileName)
            {
                try
                {
                    MailMessage Message = new MailMessage();
                    Message.IsBodyHtml = true;
                    Message.To.Add(new MailAddress(toEmail, toName));
                    Message.From = (new MailAddress(this.fromEmail, this.fromName));
                    Message.Subject = this.subject;
                    Message.Body = this.messageBody;
                    Message.Attachments.Add(new Attachment(rpt.ExportToStream(fileType), fileName));
                    SmtpClient sc = new SmtpClient();
                    sc.Host = this.smtpServer;
                    sc.Credentials = smtpCredentials;
                    sc.EnableSsl = true;

                    sc.Send(Message);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }

            public delegate bool SendEmailDelegate(string toEmail, string toName, ReportDocument rpt, ExportFormatType fileType, string fileName);

            public void GetResultsOnCallback(IAsyncResult ar)
            {
                SendEmailDelegate del = (SendEmailDelegate)((AsyncResult)ar).AsyncDelegate;
                try
                {
                    bool result = del.EndInvoke(ar);
                }
                catch (Exception ex)
                {
                    bool result = false;
                }
            }

            public bool SendEmailAsync(string toEmail, string toName, ReportDocument rpt, ExportFormatType fileType, string fileName)
            {
                try
                {
                    SendEmailDelegate dc = new SendEmailDelegate(this.SendEmail);
                    AsyncCallback cb = new AsyncCallback(this.GetResultsOnCallback);
                    IAsyncResult ar = dc.BeginInvoke(toEmail, toName, rpt, fileType, fileName,cb, null);
                }
                catch (Exception ex)
                {
                    return false;
                }
                return true;
            }
    }

}