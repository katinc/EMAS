using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using System.Data;
using HRBussinessLayer.Alerts;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace HRDataAccessLayer.Alerts
{
   public class NotificationDataMapper
    {
        private DALHelper dalHelper;
        private List<Notification> notificationList;

        public notifyType notify_type { get; set; }

        public NotificationDataMapper(notifyType notify_type)
        {
            this.notify_type = notify_type;
            notificationList = new List<Notification>();
            getNotification();
        }
       public List<Notification> getNotification()
        {
            try
            {
                dalHelper = new DALHelper();
                string query = string.Empty;

                if (notify_type == notifyType.Leave)
                {

                    query = "select ID,StaffID,'Leave' as EventType,EndDate  as EventDate,Surname + ' ' + OtherName + ' ' +Firstname as StaffName from StaffLeaveView where getdate()>=EndDate and resumed='false'";
                }
                else if (notify_type == notifyType.Pention)
                {

                    query = "select ID,StaffID,ProbationEndDate,'Probation'  as EventType,Surname + ' ' + OtherName + ' ' +Firstname as StaffName from StaffPersonalInfoView  where Confirmed='false' and getdate()>=ProbationEndDate ";
                }
                else if (notify_type == notifyType.Probation)
                    query = "SELECT s.[ID],s.[StaffID],t.TerminationDate,DATEADD(year,60,s.dob) as EventDate,'Pention' as EvenType, s.Surname + ' ' + s.OtherName + ' ' + s.Firstname as StaffName FROM [StaffPersonalInfoView] s left outer join TerminationView t on t.staffid=s.staffid where s.StaffID='AF215001' and s.Terminated='false' and DATEDIFF(Year, s.dob, GETDATE())>=60 ";

                var dtNotification = dalHelper.ExecuteReader(query);
                notificationList.Clear();
                foreach (DataRow dRow in dtNotification.Rows)
                {
                    var notification = new Notification();
                    notification.ID = (dRow["ID"] != null) ? int.Parse(dRow["ID"].ToString()) : 0;
                    notification.caption = (dRow["EventType"].ToString() == "Pention") ? "Pension" : dRow["EventType"].ToString() + " - Alert!";
                    notification.Type = (notifyType)Enum.Parse(typeof(notifyType), dRow["EventType"].ToString());

                    if (notify_type == notifyType.Leave)
                        notification.message = dRow["StaffName"].ToString() + "(" + dRow["StaffID"] + ") " + (DateTime.Parse(dRow["EventDate"].ToString()).Date < DateTime.Now.Date ? "was" : "is") + " supposed to resume on " + DateTime.Parse(dRow["EventDate"].ToString()).ToString("dd/MM/yyyy");
                    else if (notify_type == notifyType.Probation)
                        notification.message = dRow["StaffName"].ToString() + "(" + dRow["StaffID"] + ") " + (DateTime.Parse(dRow["EventDate"].ToString()).Date < DateTime.Now.Date ? "was" : "is") + " supposed to complete probation on " + DateTime.Parse(dRow["EventDate"].ToString()).ToString("dd/MM/yyyy");
                    else if (notify_type == notifyType.Pention)
                        notification.message = dRow["StaffName"].ToString() + "(" + dRow["StaffID"] + ") " + (DateTime.Parse(dRow["EventDate"].ToString()).Date < DateTime.Now.Date ? "was" : "is") + " supposed to retire on " + DateTime.Parse(dRow["EventDate"].ToString()).ToString("dd/MM/yyyy");
                    
                    notificationList.Add(notification);

                }
            }
            catch (Exception ex) { }
           return notificationList;
        }
       public void doSystemTrayNotifications(NotifyIcon notifyIcon){
          
         while(true){
             
            doNotify(notifyIcon);
         }
       }
       public void doNotify(NotifyIcon notifyIcon)
       {
           try
           {

               foreach (var notify in notificationList)
               {
                   //notifyIcon = new NotifyIcon();
                   Thread.Sleep(3600000);
                   notifyIcon.Visible = false;
                   notifyIcon.Text = "EMAS Alert!";
                   notifyIcon.Icon = SystemIcons.Exclamation;
                   notifyIcon.Visible = true; 
                   notifyIcon.ShowBalloonTip(2000, notify.caption, notify.message, ToolTipIcon.Info);

               }
           }
           catch (Exception ex)
           {

              
           }
       }
      
    }
}
