using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class UserCategory
    {
        private int userID;
        private int id;
        private string description;

        public UserCategory()
        {
            userID = 0;
            id = 0;
            description = string.Empty;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
