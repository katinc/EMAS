using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Template
    {
        private int templateID;
        private UserInfo userInfo;
        private int fingerID;
        private Image template;
        private Image template1;
        private Image template2;
        private Image template3;
        private Image template4;
        private Image bitmapPicture;
        private Image bitmapPicture2;
        private Image bitmapPicture3;
        private Image bitmapPicture4;
        private int userType;
        private string eMachineNum;
        private int flag;
        private int divisionFP;

        public Template()
        {
            try
            {
                this.templateID = 0;
                this.userInfo = new UserInfo();
                this.fingerID = 0;
                this.template = null;
                this.template2 = null;
                this.template3 = null;
                this.bitmapPicture = null;
                this.bitmapPicture2 = null;
                this.bitmapPicture3 = null;
                this.bitmapPicture4 = null;
                this.userType = 0;
                this.eMachineNum = string.Empty;
                this.template1 = null;
                this.flag = 0;
                this.divisionFP = 0;
                this.template4 = null;
                
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int TEMPLATEID
        {
            get { return templateID; }
            set { templateID = value; }
        }

        public UserInfo USERINFO
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        public int FINGERID
        {
            get { return fingerID; }
            set { fingerID = value; }
        }

        public Image TEMPLATE
        {
            get { return template; }
            set { template = value; }
        }

        public Image TEMPLATE1
        {
            get { return template1; }
            set { template1 = value; }
        }

        public Image TEMPLATE2
        {
            get { return template2; }
            set { template2 = value; }
        }

        public Image TEMPLATE3
        {
            get { return template3; }
            set { template3 = value; }
        }

        public Image TEMPLATE4
        {
            get { return template4; }
            set { template4 = value; }
        }

        public Image BITMAPPICTURE
        {
            get { return bitmapPicture; }
            set { bitmapPicture = value; }
        }

        public Image BITMAPPICTURE2
        {
            get { return bitmapPicture2; }
            set { bitmapPicture2 = value; }
        }

        public Image BITMAPPICTURE3
        {
            get { return bitmapPicture3; }
            set { bitmapPicture3 = value; }
        }

        public Image BITMAPPICTURE4
        {
            get { return bitmapPicture4; }
            set { bitmapPicture4 = value; }
        }


        public int USERTYPE
        {
            get { return userType; }
            set { userType = value; }
        }

        public string EMACHINENUM
        {
            get { return eMachineNum; }
            set { eMachineNum = value; }
        }

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public int DivisionFP
        {
            get { return divisionFP; }
            set { divisionFP = value; }
        }
    }
}
