using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.SMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.SMS
{
    public class ScheduleMessageDataMapper
    {
        private DALHelper dal;
        private ScheduleMessage scheduleMessage;

        public ScheduleMessageDataMapper()
        {
            try
            {
                dal = new DALHelper();
                scheduleMessage = new ScheduleMessage();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                ScheduleMessage scheduleMessage = (ScheduleMessage)item;
                dal.ClearParameters();
                dal.CreateParameter("@From", scheduleMessage.From, DbType.String);
                dal.CreateParameter("@To", scheduleMessage.To, DbType.String);
                dal.CreateParameter("@Message", scheduleMessage.Message, DbType.String);
                dal.CreateParameter("@Schedule_time", scheduleMessage.Schedule_time, DbType.DateTime);
                dal.CreateParameter("@Status", scheduleMessage.Status, DbType.String);

                dal.ExecuteNonQuery("Insert Into schedule_messges ([from],[to],message,schedule_time,status) Values(@From,@To,@Message,@Schedule_time,@Status)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                ScheduleMessage scheduleMessage = (ScheduleMessage)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", scheduleMessage.ID, DbType.Int32);
                dal.CreateParameter("@From", scheduleMessage.From, DbType.String);
                dal.CreateParameter("@To", scheduleMessage.To, DbType.String);
                dal.CreateParameter("@Message", scheduleMessage.Message, DbType.String);
                dal.CreateParameter("@Schedule_time", scheduleMessage.Schedule_time, DbType.DateTime);
                dal.CreateParameter("@Status", scheduleMessage.Status, DbType.String);

                dal.ExecuteNonQuery("Update schedule_messges  Set [from]=@From, [to]=@To, message=@Message, schedule_time=@Schedule_time, status=@Status Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<ScheduleMessage> GetAll()
        {
            IList<ScheduleMessage> scheduleMessages = new List<ScheduleMessage>();
            try
            {
                DataTable table = dal.ExecuteReader("select * From schedule_messges Where Archived='False' order BY schedule_messges.schedule_time DESC");
                foreach (DataRow row in table.Rows)
                {
                    scheduleMessages.Add(new ScheduleMessage() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        From = row["from"].ToString(), 
                        To = row["to"].ToString(),
                        Message = row["message"].ToString(),
                        Schedule_time = DateTime.Parse(row["schedule_time"].ToString()),
                        Status = row["status"].ToString(), 
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return scheduleMessages;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.ExecuteNonQuery("Update schedule_messges Set Archived='True' Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Open Connection
        public void OpenConnection()
        {
            try
            {
                dal.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Close Connection
        public void CloseConnection()
        {
            try
            {
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
