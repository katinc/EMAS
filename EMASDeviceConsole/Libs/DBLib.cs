using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace EMASDeviceConsole.Libs
{

    public enum AttendanceState
    {
        CHECK_IN = 0,
        CHECK_OUT = 1,
        BREAK_OUT = 2,
        BREAK_IN =3,
        OT_IN =4,
        OT_OUT=5
    }

    public enum AttVerificationMethod
    {
        PASSWORD_VERIFICATION = 0,
        FINGERPRINT_VERIFICATION =1,
        CARD_VERIFICATION =2
    }

    public class FingerprintTemplate
    {
        public long ID { get; set; }
        public string StaffID { get; set; }
        public string Name { get; set; }
        public int FingerType { get; set; }
        public string Template { get; set; }
        public int TempLen { get; set; }
        public int Flag { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UserID { get; set; }
        public string FingertypeText { get; set; }
        public int StaffMainID { get; set; }
        public string UserType { get; set; }
    }


   public class DBLib
    {
       public int StaffMainID { get; set; }
       public string UserType { get; set; }
       public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString);
       
       private KOF_ContextDataContext context = new KOF_ContextDataContext();

       public bool  OpenConnection()
       {
           try
           {
               if( con.State == System.Data.ConnectionState.Closed)
               {
                    con.Open();
               }

               return true;
           }
           catch (Exception ex) { return false; }
          
       }

       public static string getConString
       {
           get 
           {
               return ConfigurationManager.ConnectionStrings["HRConnectionString"].ConnectionString;
           }
       }

       public bool insertSyncData(FingerprintTemplate temp, int DeviceID)
       {
           bool status = false;
           string sql = "INSERT INTO StaffFingerprintTemplatesSync(DeviceID, StaffID, TemplateID, Action, FingerIndex, SyncedDate, UserType, StaffMainID) values";
           sql += " (@DeviceID, @StaffID, @TemplateID, @Action, @FingerIndex, @SyncedDate, @UserType, @StaffMainID)";

           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("@DeviceID", DeviceID);
               command.Parameters.AddWithValue("@StaffID", temp.StaffID);
               command.Parameters.AddWithValue("@TemplateID", temp.ID );
               command.Parameters.AddWithValue("@Action", "Add");
               command.Parameters.AddWithValue("@FingerIndex", temp.FingerType);
               command.Parameters.AddWithValue("@SyncedDate", DateTime.UtcNow);
               command.Parameters.AddWithValue("@UserType", UserType);
               command.Parameters.AddWithValue("@StaffMainID", StaffMainID);
               try
               {
                   connection.Open();
                   Int32 rowsAffected = command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                   {
                       status = true;
                   }
               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }

               }

               return status;
           }

       }

       public bool UpdateSyncData(int DeviceID, long TemplateID)
       {
           bool status = false;
           string sql = "UPDATE StaffFingerprintTemplatesSync SET SyncedDate = @SyncedDate ";
           sql += " WHERE DeviceID =@DeviceID and TemplateID=@TemplateID";

           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("@DeviceID", DeviceID);
               command.Parameters.AddWithValue("@TemplateID", TemplateID);
               command.Parameters.AddWithValue("@SyncedDate", DateTime.UtcNow);

               try
               {
                   connection.Open();
                   Int32 rowsAffected = command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                   {
                       status = true;
                   }
               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }

               }

               return status;
           }

       }

       public DataTable getDeviceSyncToUpdate(int DeviceID)
       {
           string sql = "SELECT s.* FROM StaffFingerprintTemplatesSync s ";
           sql += " WHERE (s.SyncedDate IS NULL) AND (s.DeviceID = " + DeviceID + ")  and (Action='Delete')";
           DataTable dataTable = new DataTable();
           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);

               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   if (reader.HasRows)
                   {
                       dataTable.Load(reader);
                   }
                   reader.Close();
                   reader.Dispose();

               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }
               }

               return dataTable;
           }
       }

       public DataTable getDeviceTempsToSync(int DeviceID)
       {
           string sql = "select t.*,i.Firstname,i.Surname,i.OtherName from StaffFingerprintTemplates t ";
           sql += " inner join StaffPersonalInfo i on i.StaffID = t.StaffID";
           sql+=" where t.ID not in(select s.TemplateID from  StaffFingerprintTemplatesSync s where s.DeviceID = " + DeviceID + ") ";
           DataTable dataTable = new DataTable();
           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);

               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   if (reader.HasRows)
                   {
                       dataTable.Load(reader);
                   }
                   reader.Close();
                   reader.Dispose();

               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }
               }

               return dataTable;
           }
       }

       public bool deleteDeviceSyncs(int DeviceID)
       {
           bool status = false;
           string sql = "DELETE FROM StaffFingerprintTemplatesSync WHERE DeviceID="+ DeviceID;
          
           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);

               try
               {
                   connection.Open();
                   command.ExecuteNonQuery();
                   status = true; 
               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }
               }

               return status;
           }
       }

       public bool AddAttendaanceRecord(string StaffID, int DeviceID, DateTime Clocktime,int VerifyMethod, int AttendanceType,bool insertFlag,string CaptureField, long updateID)
       {
           if (string.IsNullOrEmpty(CaptureField))
           {
               LogManager.Log("Attendance Details could not be saved. Invalid Capture Field ",LogManager.LogType.WARNING,false);
               return false;
           }

           bool status = false;
           string sql = "INSERT INTO StaffAttendanceLog(StaffID, ClockTime, DeviceID, VerifyMethod, AttendanceType) values";
           sql += " (@StaffID, @ClockTime, @DeviceID, @VerifyMethod, @AttendanceType)";


           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("@StaffID", StaffID );
               command.Parameters.AddWithValue("@ClockTime", Clocktime);
               command.Parameters.AddWithValue("@DeviceID", DeviceID);
               command.Parameters.AddWithValue("@VerifyMethod", VerifyMethod);
               command.Parameters.AddWithValue("@AttendanceType", AttendanceType);
               //command.Parameters.AddWithValue("@StaffMainID", context.StaffPersonalInfos.SingleOrDefault(u => u.ID == Convert.ToInt32(StaffID)).StaffID);
               //command.Parameters.AddWithValue("@UserType", context.StaffPersonalInfos.SingleOrDefault(u => u.ID == Convert.ToInt32(StaffID)).UserType);

               try
               {
                   connection.Open();
                   Int32 rowsAffected = command.ExecuteNonQuery();
                   if (rowsAffected > 0)
                   {
                       command.Parameters.Clear();
                       if (insertFlag)
                       {
                           command.CommandText = string.Format("INSERT INTO StaffAttendance( StaffID,{0},StaffMainID,UserType) VALUES(@StaffID,@{1},@StaffMainID,@UserType)", CaptureField, CaptureField);
                       }
                       else
                       {
                           command.CommandText = string.Format("UPDATE StaffAttendance SET {0}=@{1}, StaffMainID =@StaffMainID,UserType = @UserType where StaffID=@StaffID and {0} IS NULL", CaptureField, CaptureField);
                       }

                       command.Parameters.AddWithValue("@StaffID", StaffID);
                       command.Parameters.AddWithValue("@" + CaptureField, Clocktime);
                       command.Parameters.AddWithValue("@StaffMainID", context.StaffPersonalInfos.SingleOrDefault(u => u.ID == Convert.ToInt32(StaffID)).StaffID);
                       command.Parameters.AddWithValue("@UserType", context.StaffPersonalInfos.SingleOrDefault(u => u.ID == Convert.ToInt32(StaffID)).UserType);

                       rowsAffected = command.ExecuteNonQuery();
                       if (rowsAffected > 0)
                       {
                           status = true;
                           LogManager.Log("Attendance Details Captured Sucessfully ");
                       }
                   }
               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }

               }

               return status;
           }

       }

       public DataTable  getNextAttendanceState(string StaffID)
       {
           string sql = "select * from StaffAttendance where StaffID =@StaffID order by ID desc ";
           
           DataTable dataTable = new DataTable();
           using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
           {
               SqlCommand command = new SqlCommand(sql, connection);
               command.Parameters.AddWithValue("@StaffID", StaffID);

               try
               {
                   connection.Open();
                   SqlDataReader reader = command.ExecuteReader();
                   if (reader.HasRows)
                   {
                       dataTable.Load(reader);
                   }
                   reader.Close();
                   reader.Dispose();

               }
               catch (Exception ex)
               {
                   LogManager.Log(ex.Message, LogManager.LogType.ERROR);
                   if (AppSettings.isDebugMode)
                   {
                       LogManager.Log(ex.Source, LogManager.LogType.ERROR);
                       LogManager.Log(ex.StackTrace, LogManager.LogType.ERROR);
                       LogManager.Log(ex.TargetSite.Name, LogManager.LogType.ERROR);
                   }
               }

               return dataTable;
           }
       }

    }
}
