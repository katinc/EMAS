using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;


namespace EMASDeviceConsole.Libs
{
    public class Device 
    {
        public  int DeviceID {get; set;}
        public string Location { get; set; }
        public string SerialNo { get; set; }
        public string IPAddress { get; set; }
        public int Port { get; set; }
        public bool IsActive { get; set; }
        public bool? Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public DateTime? LastSynced { get; set; }
      

        private bool _connected;
        private zkemkeeper.CZKEMClass _handler = new zkemkeeper.CZKEMClass();
        private DeviceManager manager = new DeviceManager();
        private string _lastErrorMessage;
        private DBLib lib = new DBLib();
        public bool Connected 
        { 
            get { return _connected; } 
        }

        public bool ConnectDevice()
        {
            if (!Connected)
            {
                if (manager.ConnectToDevice(ref _handler, IPAddress))
                {                    
                    _connected = true;
                    updateStatus();
                    return true;
                }
                else
                {
                    _connected  = false;
                    int idwErrorCode = 0;
                    _handler.GetLastError(ref idwErrorCode);
                    _lastErrorMessage = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();
                    updateStatus();
                    return false;                       
                }
            }
            else
            {
                return true;
            }
        }


        public bool SyncMe()
        {
            int idwErrorCode = 0;
            bool status = false;
            LogMe("Deleting Old sync data");
            if (lib.deleteDeviceSyncs(this.DeviceID))
            {
                LogMe("Done");
            }
           
            return status;
        }

        public bool ImportMe()
        {
            int idwErrorCode = 0;
            bool status = false;
            string sdwEnrollNumber = "";         
            int idwVerifyMode = 0;
            int idwInOutMode = 0;
            int idwYear = 0;
            int idwMonth = 0;
            int idwDay = 0;
            int idwHour = 0;
            int idwMinute = 0;
            int idwSecond = 0;
            int idwWorkcode = 0;
           
            if (!Connected)
            {
                startActivity();
            }

            if (Connected)
            {
                _handler.EnableDevice(1, false);
                if (_handler.ReadGeneralLogData(1))//read all the attendance records to the memory
                {
                    LogMe("Data Found. Initiating Saving Process");
                    while (_handler.SSR_GetGeneralLogData(1, out sdwEnrollNumber, out idwVerifyMode,
                               out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond, ref idwWorkcode))//get records from the memory
                    {
                     
                        _handler_OnAttTransactionEx(sdwEnrollNumber, 0, idwInOutMode, idwVerifyMode, idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond, idwWorkcode);
                    }

                    status = true;
                    _handler.EnableDevice(1, true);
                }
                else
                {
                    _handler.EnableDevice(1, true);
                    _handler.GetLastError(ref idwErrorCode);

                    if (idwErrorCode != 0)
                    {
                        LogMe("Reading data from terminal failed,ErrorCode: " + idwErrorCode.ToString());
                    }
                    else
                    {
                        LogMe("No data from terminal returns!");
                    }
                }
            }

            return status;
        }
        
        public bool setLocalTime()
        {
            int idwErrorCode = 0;
            bool status = false;
            if (!Connected)
            {
                startActivity();
            }

            if (Connected)
            {
                _handler.CancelOperation();
                if (_handler.SetDeviceTime(1))
                {
                    status = true;
                }
                else
                {
                    _handler.GetLastError(ref idwErrorCode);
                    LogMe("User Information could not be set on the device,ErrorCode=" + idwErrorCode.ToString());
                }
            }

            return status;
        }

        public bool ClearLog()
        {
            int idwErrorCode = 0;
            bool status = false;
            if (!Connected)
            {
                startActivity();
            }

            if (Connected)
            {
                _handler.EnableDevice(1, false);
                if (_handler.ClearGLog(1))
                {
                    _handler.RefreshData(1);                    
                    _handler.EnableDevice(1, true);
                    LogMe("All attendance Logs have been cleared from teiminal!");
                    status = true;
                }
                else
                {
                    _handler.EnableDevice(1, true);
                    _handler.GetLastError(ref idwErrorCode);
                    LogMe("Could not clear attendance log from device,ErrorCode=" + idwErrorCode.ToString(),LogManager.LogType.WARNING,false);
                }
            }

            return status;
        }
        public void startActivity()
        {
            LogMe("Attempting to connect to Device");
            ConnectDevice();
            if (Connected)
            {
                _handler.EnableDevice(1, true);
                LogMe ("Connected Successfuly");
                LogMe("Registering Events");
                RegisterEvents();
                LogMe ("Events Registered");

                LogMe("Now Monitoring events");
              

            }
            else
            {
                LogMe(string.Format("Failed to conenct to device: {0}", LastErrorMessage), LogManager.LogType.ERROR,false);
            }
        }

        public void Disconnect()
        {
            if (Connected)
            {
                LogMe("Disconnected");
                manager.DisconnectDevice(ref _handler);
                _connected = false;
                updateStatus();
            }
        }

        public string LastErrorMessage
        {
            get
            {               
                return _lastErrorMessage;
            }
        }

        public void RegisterEvents()
        {
            if (_handler.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
            {
                this._handler.OnConnected += new zkemkeeper._IZKEMEvents_OnConnectedEventHandler(_handler_OnConnected);
                this._handler.OnDisConnected += new zkemkeeper._IZKEMEvents_OnDisConnectedEventHandler(_handler_OnDisConnected);
                this._handler.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(_handler_OnFinger);
                this._handler.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(_handler_OnVerify);
                this._handler.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(_handler_OnAttTransactionEx);
                
            }
        }

        void _handler_OnAttTransactionEx(string EnrollNumber,int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            try
            {
                DateTime attTime = new DateTime(Year, Month, Day, Hour, Minute, Second);
                DataTable tbl = lib.getNextAttendanceState(EnrollNumber);
                AttendanceState attType = (AttendanceState)AttState;
                string activityLabel = getAttendanceTypeField(AttState);
                if (tbl.Rows.Count > 0)
                {
                    DataRow row = tbl.Rows[0];
                    AttendanceState nextType = getNextActivity(row);

                    if (attType == AttendanceState.CHECK_IN)
                    {
                        DateTime checkInTime = Convert.ToDateTime(row["CheckInTime"]);
                        TimeSpan t = DateTime.Now.Subtract(checkInTime);

                        if (nextType == AttendanceState.CHECK_IN)
                        {
                            lib.AddAttendaanceRecord(EnrollNumber,this.DeviceID, attTime, VerifyMethod, AttState, true, activityLabel, 0);
                        }
                        else if (nextType == AttendanceState.CHECK_OUT)
                        {
                            if (t.Hours >= 24)
                            {
                                lib.AddAttendaanceRecord(EnrollNumber, this.DeviceID, attTime, VerifyMethod, AttState, true, activityLabel, 0);
                            }
                            else
                            {
                                LogMe("Invalid Function Selected: " + activityLabel + ", Required is Check-Out", LogManager.LogType.WARNING, false);
                                LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                            }
                            //AttState = (int)nextType;
                            //lib.AddAttendaanceRecord(EnrollNumber, this.DeviceID, attTime, VerifyMethod, AttState, true, activityLabel, 0);

                        }
                        else if (nextType == AttendanceState.BREAK_IN)
                        {
                            if (t.Hours >= 24)
                            {
                                lib.AddAttendaanceRecord(EnrollNumber,this.DeviceID, attTime, VerifyMethod, AttState, true, activityLabel, 0);
                            }
                            else
                            {
                                LogMe("Invalid Function Selected: " + activityLabel + ", Required is Break-In", LogManager.LogType.WARNING, false);
                                LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                            }
                        }
                        else
                        {
                            LogMe("Invalid Function Selected: " + activityLabel, LogManager.LogType.WARNING, false);
                            LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                        }
                    }
                    else if (attType == AttendanceState.CHECK_OUT)
                    {                      
                        if (nextType == AttendanceState.CHECK_OUT)
                        {
                            lib.AddAttendaanceRecord(EnrollNumber, this.DeviceID, attTime, VerifyMethod, AttState, false, activityLabel, Convert.ToInt64(row["ID"]));
                        }
                        else 
                        {
                            LogMe("Invalid Function Selected: " + activityLabel + ", Required is Check-In", LogManager.LogType.WARNING, false);
                            LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                        }                        
                    }
                    else if (attType == AttendanceState.BREAK_OUT)
                    {
                         DateTime checkInTime = Convert.ToDateTime(row["CheckInTime"]);
                         TimeSpan t = DateTime.Now.Subtract(checkInTime);
                         if (t.Hours > 1)
                         {
                             if (DBNull.Value == row["CheckOutTime"])
                             {
                                 lib.AddAttendaanceRecord(EnrollNumber,this.DeviceID, attTime, VerifyMethod, AttState, false, activityLabel, Convert.ToInt64(row["ID"]));
                             }
                             else
                             {
                                 LogMe("Invalid Function Selected: " + activityLabel + ". You have already checked out", LogManager.LogType.WARNING, false);
                                 LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                             }
                         }
                         else
                         {
                             LogMe("Invalid Function Selected: " + activityLabel, LogManager.LogType.WARNING, false);
                             LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                         }

                    }
                    else if (attType == AttendanceState.BREAK_IN)
                    {      
                        if (nextType == AttendanceState.BREAK_IN)
                        {
                            lib.AddAttendaanceRecord(EnrollNumber,this.DeviceID, attTime, VerifyMethod, AttState, false, activityLabel, Convert.ToInt64(row["ID"]));
                        }
                        else
                        {
                            LogMe("Invalid Function Selected: " + activityLabel, LogManager.LogType.WARNING, false);
                            LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                        }

                    }
                    else
                    {
                        LogMe("Invalid Function Selected: " + activityLabel, LogManager.LogType.WARNING, false);
                        LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
                    }

                }
                else
                {
                    if (attType == AttendanceState.CHECK_IN)
                    {
                        lib.AddAttendaanceRecord(EnrollNumber,this.DeviceID, attTime, VerifyMethod, AttState, true, activityLabel, 0);
                    }
                    else
                    {
                        LogMe("Invalid Function Selected: " + activityLabel,LogManager.LogType.WARNING,false);
                        LogMe("Clock Ignored: " + activityLabel, LogManager.LogType.WARNING, false);
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

        }

        private AttendanceState getNextActivity(DataRow row)
        {
            AttendanceState state = AttendanceState.CHECK_IN;

            if (row["CheckInTime"] == DBNull.Value || string.IsNullOrEmpty(row["CheckInTime"].ToString()))
            {
                state = AttendanceState.CHECK_IN;
            }
            else if (row["CheckOutTime"] == DBNull.Value || string.IsNullOrEmpty(row["CheckOutTime"].ToString()))
            {
                state = AttendanceState.CHECK_OUT;
            }

            if (row["BreakOutTime"] != DBNull.Value)
            {
                state = AttendanceState.BREAK_IN;
            }
            else if (row["BreakInTime"] != DBNull.Value)
            {
                state = AttendanceState.CHECK_OUT;
            }

            return state;
        }

        private string getAttendanceTypeField(int atttype)
        {
            string type = "";
            switch (atttype)
            {
                case 0:
                    type ="CheckInTime";
                    break;
                case 1:
                    type = "CheckOutTime";
                    break;
                case 2:
                    type = "BreakOutTime";
                    break;
                case 4:
                    type = "BreakInTime";
                    break;               
            }

            return type;
        }

        void _handler_OnDisConnected()
        {
            LogMe("Now Disconnected",LogManager.LogType.WARNING,false );
            _connected = false;
        }

        void _handler_OnConnected()
        {
            LogMe("Now connected");
            _connected = true;
        }


        private void LogMe(string Data,LogManager.LogType  type,bool sectionBreak)
        {
            LogManager.Log(string.Format("Device Location:{0} IP:{1} {2}", this.Location, this.IPAddress, Data),type,sectionBreak );
        }

        private void LogMe(string Data)
        {

            LogManager.Log(string.Format("Device Location:{0} IP:{1} {2}", this.Location, this.IPAddress, Data));
        }

        
        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        void _handler_OnVerify(int UserID)
        {
            LogMe("OnVerify Event Has been triggered");
            if (UserID != -1)
            {
                LogMe("User Verified Successfully,the User Sequence on Device is: " + UserID.ToString());
            }
            else
            {
                 LogMe("User Verification Failed ");
            }
        }

        //When you place your finger on sensor of the device,this event will be triggered
        void _handler_OnFinger()
        {
            LogMe("OnFinger Has been Triggered");
           // _handler.EnableCustomizeVoice(
        }

        public void unRegisterEvents()
        {
            LogMe("Unregistering Events...");
            this._handler.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(_handler_OnFinger);
            this._handler.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(_handler_OnVerify);
            this._handler.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(_handler_OnAttTransactionEx);
            
            LogMe("Events fully unregistered");
        }


        private void updateStatus()
        {
            string sql = "UPDATE  AttendanceDevices SET CurrentStatus=@CurrentStatus,StatusDate=@StatusDate where ID=" + DeviceID;


            using (SqlConnection connection = new SqlConnection(Libs.DBLib.getConString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@CurrentStatus", _connected);
                command.Parameters.AddWithValue("@StatusDate", DateTime.UtcNow);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    LogMe(ex.Message);
                }
            }
        }


        public bool DeleteTemplate(string StaffID, int fingerIndex)
        {
            int idwErrorCode = 0;            
            bool status = false;
            if (!Connected)
            {
                startActivity();
            }

            if (Connected)
            {
                _handler.CancelOperation();
                if (_handler.SSR_DelUserTmpExt(1, StaffID, fingerIndex))
                {                   
                    status = true;
                }
                else
                {
                    _handler.GetLastError(ref idwErrorCode);
                    LogMe("User Template could not be deleted on the device,ErrorCode=" + idwErrorCode.ToString());
                }
            }

            return status;
        }

        public bool UploadTemplate(FingerprintTemplate temp)
        {
            int idwErrorCode=0;
           // byte[] byTmpData = temp.Template;
          //  string byTempData = temp.Template;
            bool status = false;
            if (!Connected)
            {
                startActivity();
            }

            if (Connected)
            {
                //_handler.CancelOperation();
                //if (_handler.SSR_SetUserInfo(1, temp.StaffID, temp.Name, null, 0, true))
                //{
                //    if (_handler.SetUserTmpExStr(1,temp.StaffID, temp.FingerType, temp.Flag,temp.Template))
                //    {
                //        status = true;
                //    }
                //    else
                //    {
                //        _handler.GetLastError(ref idwErrorCode);
                //        LogMe("User Fingerprint Template could not be set on the device,ErrorCode=" + idwErrorCode.ToString());
                //    }
                //}
                //else
                //{
                //    _handler.GetLastError(ref idwErrorCode);
                //    LogMe("User Information could not be set on the device,ErrorCode=" + idwErrorCode.ToString());
                //}
                _handler.CancelOperation();
                if (_handler.SSR_SetUserInfo(1, temp.StaffMainID.ToString(), temp.Name, null, 0, true))
                {
                    if (_handler.SetUserTmpExStr(1, temp.StaffMainID.ToString(), temp.FingerType, temp.Flag, temp.Template))
                    {
                        status = true;
                    }
                    else
                    {
                        _handler.GetLastError(ref idwErrorCode);
                        LogMe("User Fingerprint Template could not be set on the device,ErrorCode=" + idwErrorCode.ToString());
                    }
                }
                else
                {
                    _handler.GetLastError(ref idwErrorCode);
                    LogMe("User Information could not be set on the device,ErrorCode=" + idwErrorCode.ToString());
                }
            }

            return status;
        }
      
    }

}
