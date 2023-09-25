using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRBussinessLayer.System_Setup_Class
{
    public class User
    {
        private int id;
        private string userName;
        private string password;
        private UserCategory userCategory;
        private Image fingerPrint;
        private string securityQuestion;
        private string securityAnswer;
        private string barCode;
        private string email;
        private bool accountBlocked;
        private int empID;
        private string name;
        private string staffID;
        private bool archived;
        private Nullable<DateTime> archivedTime;
        private int archivedUserID;
        private int createUserID;
        private int updateUserID;
        private string userRole;

        public User()
        {
            try
            {
                this.id = 0;
                this.userCategory = new UserCategory() ;
                this.userName = string.Empty;
                this.password = string.Empty;
                this.fingerPrint = null;
                this.securityQuestion = string.Empty;
                this.securityAnswer = string.Empty;
                this.barCode = string.Empty;
                this.email = string.Empty;
                this.accountBlocked = false;
                this.empID = 0;
                this.name = string.Empty;
                this.staffID = string.Empty;
                this.createUserID = 0;
                this.updateUserID = 0;
                this.archived = false;
                this.archivedUserID = 0;
                this.archivedTime = null;
                this.userRole = string.Empty;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public UserCategory UserCategory
        {
            get { return userCategory; }
            set { userCategory = value; }
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public Image FingerPrint
        {
            get { return fingerPrint; }
            set { fingerPrint = value; }
        }

        public string SecurityQuestion
        {
            get { return securityQuestion; }
            set { securityQuestion = value; }
        }

        public string SecurityAnswer
        {
            get { return securityAnswer; }
            set { securityAnswer = value; }
        }

        public string BarCode
        {
            get { return barCode; }
            set { barCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public bool AccountBlocked
        {
            get { return accountBlocked; }
            set { accountBlocked = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int EmpID
        {
            get { return empID; }
            set { empID = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public Nullable<DateTime> ArchivedTime
        {
            get { return archivedTime; }
            set { archivedTime = value; }
        }

        public int ArchivedUserID
        {
            get { return archivedUserID; }
            set { archivedUserID = value; }
        }

        public int CreateUserID
        {
            get { return createUserID; }
            set { createUserID = value; }
        }

        public int UpdateUserID
        {
            get { return updateUserID; }
            set { updateUserID = value; }
        }

        public string UserRole
        {
            get { return userRole; }
            set { userRole = value; }
        }
    }
}
