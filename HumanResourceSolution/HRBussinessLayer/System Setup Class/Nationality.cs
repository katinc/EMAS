using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Nationality
    {
        private int id;
        private string description;
        private string dateAndTimeGenerated;
        private int userID;
        private bool archived;

        public Nationality()
        {
            id = 0;
            description = string.Empty;
            dateAndTimeGenerated = string.Empty;
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

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }
    }
}
