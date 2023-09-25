using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Validation;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Drawing;

namespace HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS
{
    public class MedicalClaimsItems
    {
        private int id;
        private MedicalClaims medicalClaim;
        private string description;
        private string type;
        private int quantity;
        private decimal amount;
        private bool sign;
        private bool archived;
        private int archivedUserID;
        private Nullable<DateTime> archivedTime;
        private User user;

        public MedicalClaimsItems()
        {
            try
            {
                this.id = 0;
                this.medicalClaim = new MedicalClaims();
                this.description = string.Empty;
                this.type = string.Empty;
                this.quantity = 0;
                this.amount = 0;
                this.sign = false;
                this.archived = false;
                this.archivedUserID = 0;
                this.archivedTime = null;
                this.user = new User();
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

        public MedicalClaims MedicalClaim
        {
            get { return medicalClaim; }
            set { medicalClaim = value; }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
            }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public bool Sign
        {
            get { return sign; }
            set { sign = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public int ArchivedUserID
        {
            get { return archivedUserID; }
            set { archivedUserID = value; }
        }


        public Nullable<DateTime> ArchivedTime
        {
            get { return archivedTime; }
            set { archivedTime = value; }
        }
    }
}
