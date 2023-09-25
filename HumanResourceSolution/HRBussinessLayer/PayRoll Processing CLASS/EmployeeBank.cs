using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class EmployeeBank
    {
        private int id;
        private string staffID;
        private string bankName;
        private string branch;
        private string accountName;
        private string accountNumber;
        private bool inUse;

        public EmployeeBank()
        {
            id = 0;
            staffID = string.Empty;
            bankName = string.Empty;
            branch = string.Empty;
            accountName = string.Empty;
            accountNumber = string.Empty;
            inUse = false;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        public string BankName
        {
            get { return bankName; }
            set { bankName = value; }
        }

        public string Branch
        {
            get { return branch; }
            set { branch = value; }
        }

        public string AccountName
        {
            get { return accountName; }
            set { accountName = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }
    }
}
