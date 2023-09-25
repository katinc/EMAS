using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserCategoryRole
    {
        private int id;
        private UserCategory userCategory;
        private UserAccessLevel1 userAccessLevel1;
        private UserAccessLevel2 userAccessLevel2;
        private UserAccessLevel3 userAccessLevel3;
        private UserAccessLevel4 userAccessLevel4;
        private bool canAdd;
        private bool canView;
        private bool canPrint;
        private bool canDelete;
        private bool canEdit;

        public UserCategoryRole()
        {
            try
            {
                this.id = 0;
                this.userCategory = new UserCategory();
                this.userAccessLevel1 = new UserAccessLevel1();
                this.userAccessLevel2 = new UserAccessLevel2();
                this.userAccessLevel3 = new UserAccessLevel3();
                this.userAccessLevel4 = new UserAccessLevel4();
                this.canAdd = false;
                this.canDelete = false;
                this.canEdit = false;
                this.canPrint = false;
                this.canView = false;
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

        public UserAccessLevel1 UserAccessLevel1
        {
            get { return userAccessLevel1; }
            set { userAccessLevel1 = value; }
        }

        public UserAccessLevel2 UserAccessLevel2
        {
            get { return userAccessLevel2; }
            set { userAccessLevel2 = value; }
        }

        public UserAccessLevel3 UserAccessLevel3
        {
            get { return userAccessLevel3; }
            set { userAccessLevel3 = value; }
        }

        public UserAccessLevel4 UserAccessLevel4
        {
            get { return userAccessLevel4; }
            set { userAccessLevel4 = value; }
        }

        public bool CanAdd
        {
            get { return canAdd; }
            set { canAdd = value; }
        }

        public bool CanDelete
        {
            get { return canDelete; }
            set { canDelete = value; }
        }

        public bool CanView
        {
            get { return canView; }
            set { canView = value; }
        }

        public bool CanEdit
        {
            get { return canEdit; }
            set { canEdit = value; }
        }

        public bool CanPrint
        {
            get { return canPrint; }
            set { canPrint = value; }
        }
    }
}
