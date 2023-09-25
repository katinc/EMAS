using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMASDeviceConsoleService.Libs;
using Microsoft.Win32;
using System.Threading;
using System.Windows.Forms;


namespace EMASDeviceConsoleService.Libs
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
                    return true;
                }
                else
                {
                    _connected  = false;
                    int idwErrorCode = 0;
                    _handler.GetLastError(ref idwErrorCode);
                    _lastErrorMessage = "Unable to connect the device,ErrorCode=" + idwErrorCode.ToString();

                    return false;                       
                }
            }
            else
            {
                return true;
            }
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
               /* while (!Monitor.stopping)
                {
                    Thread.Sleep(2000);
                }

                Disconnect();
                unRegisterEvents();*/

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
                this._handler.OnFinger += new zkemkeeper._IZKEMEvents_OnFingerEventHandler(_handler_OnFinger);
                this._handler.OnVerify += new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(_handler_OnVerify); 
                this._handler.OnAttTransactionEx +=new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(_handler_OnAttTransactionEx);   
                this._handler.OnFingerFeature +=new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(_handler_OnFingerFeature);
                this._handler.OnEnrollFingerEx +=new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(_handler_OnEnrollFingerEx);
                this._handler.OnDeleteTemplate +=new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(_handler_OnDeleteTemplate);
                this._handler.OnNewUser +=new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(_handler_OnNewUser);
                this._handler.OnHIDNum +=new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(_handler_OnHIDNum);
                this._handler.OnAlarm +=new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(_handler_OnAlarm);
                this._handler.OnDoor +=new zkemkeeper._IZKEMEvents_OnDoorEventHandler(_handler_OnDoor);
                this._handler.OnWriteCard +=new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(_handler_OnWriteCard);
                this._handler.OnEmptyCard += new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(_handler_OnEmptyCard);
            }
        }

        private void LogMe(string Data,LogManager.LogType  type,bool sectionBreak)
        {
            LogManager.Log(string.Format("Device Location:{0} IP:{1} {2}", this.Location, this.IPAddress, Data),type,sectionBreak );
        }

        private void LogMe(string Data)
        {

            LogManager.Log(string.Format("Device Location:{0} IP:{1} {2}", this.Location, this.IPAddress, Data));
        }

        void _handler_OnEmptyCard(int ActionResult)
        {
            LogMe("OnEmptyCard");
        }

        void _handler_OnWriteCard(int EnrollNumber, int ActionResult, int Length)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnDoor(int EventType)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnAlarm(int AlarmType, int EnrollNumber, int Verified)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnHIDNum(int CardNumber)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnNewUser(int EnrollNumber)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnDeleteTemplate(int EnrollNumber, int FingerIndex)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        void _handler_OnEnrollFingerEx(string EnrollNumber, int FingerIndex, int ActionResult, int TemplateLength)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        //When you have enrolled your finger,this event will be triggered and return the quality of the fingerprint you have enrolled
        void _handler_OnFingerFeature(int Score)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        //If your fingerprint(or your card) passes the verification,this event will be triggered
        void _handler_OnAttTransactionEx(string EnrollNumber, int IsInValid, int AttState, int VerifyMethod, int Year, int Month, int Day, int Hour, int Minute, int Second, int WorkCode)
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        //After you have placed your finger on the sensor(or swipe your card to the device),this event will be triggered.
        //If you passes the verification,the returned value userid will be the user enrollnumber,or else the value will be -1;
        void _handler_OnVerify(int UserID)
        {
            LogMe("RTEvent OnVerify Has been Triggered,Verifying...");
            if (UserID != -1)
            {
                LogMe("Verified OK,the UserID is " + UserID.ToString());
            }
            else
            {
                 LogMe("Verified Failed... ");
            }
        }

        //When you place your finger on sensor of the device,this event will be triggered
        void _handler_OnFinger()
        {
            LogMe("RTEvent OnFinger Has been Triggered");
        }

        public void unRegisterEvents()
        {
            LogMe("Unregistering Events...");
            this._handler.OnFinger -= new zkemkeeper._IZKEMEvents_OnFingerEventHandler(_handler_OnFinger);
            this._handler.OnVerify -= new zkemkeeper._IZKEMEvents_OnVerifyEventHandler(_handler_OnVerify);
            this._handler.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(_handler_OnAttTransactionEx);
            this._handler.OnFingerFeature -= new zkemkeeper._IZKEMEvents_OnFingerFeatureEventHandler(_handler_OnFingerFeature);
            this._handler.OnEnrollFingerEx -= new zkemkeeper._IZKEMEvents_OnEnrollFingerExEventHandler(_handler_OnEnrollFingerEx);
            this._handler.OnDeleteTemplate -= new zkemkeeper._IZKEMEvents_OnDeleteTemplateEventHandler(_handler_OnDeleteTemplate);
            this._handler.OnNewUser -= new zkemkeeper._IZKEMEvents_OnNewUserEventHandler(_handler_OnNewUser);
            this._handler.OnHIDNum -= new zkemkeeper._IZKEMEvents_OnHIDNumEventHandler(_handler_OnHIDNum);
            this._handler.OnAlarm -= new zkemkeeper._IZKEMEvents_OnAlarmEventHandler(_handler_OnAlarm);
            this._handler.OnDoor -= new zkemkeeper._IZKEMEvents_OnDoorEventHandler(_handler_OnDoor);
            this._handler.OnWriteCard -= new zkemkeeper._IZKEMEvents_OnWriteCardEventHandler(_handler_OnWriteCard);
            this._handler.OnEmptyCard -= new zkemkeeper._IZKEMEvents_OnEmptyCardEventHandler(_handler_OnEmptyCard);

            LogMe("Al events fully unregistered");
        }
         
      
    }
}
