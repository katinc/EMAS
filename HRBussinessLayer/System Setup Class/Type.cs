using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Type
    {
        private int id;
        private string description;
        private int userID;
        private string archived;

        public Type()
        {
            id = 0;
            description = string.Empty;
            archived = string.Empty;
            userID = 0;

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

        public string Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
