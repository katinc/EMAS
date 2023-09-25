using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class StaffBank
    {
        private int id;
        private Employee employee;
        private Bank bank;
        private BankBranch bankBranch;
        private AccountType accountType;
        private string address;
        private string accountName;
        private string accountNumber;
        private bool in_Use;
        private DateTime dateCreated;
        private bool archived;
        private User user;

        public StaffBank()
        {
            try
            {
                this.id = 0;
                this.employee = new Employee();
                this.bank = new Bank();
                this.bankBranch = new BankBranch();
                this.accountType = new AccountType();
                this.address = string.Empty;
                this.AccountName = string.Empty;
                this.accountNumber = string.Empty;
                this.in_Use = false;
                this.archived = false;
                this.dateCreated = DateTime.Today;
                this.user = new User();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffBank(int id,Employee employee,Bank bank,BankBranch bankBranch,AccountType accountType,string address, string accountName, string accountNumber, bool in_Use,DateTime dateCreated, bool archived, User user)
        {
            try
            {
                this.id = 0;
                this.employee = employee;
                this.bank = bank;
                this.bankBranch = bankBranch;
                this.bankBranch = bankBranch;
                this.accountType = accountType;
                this.accountType = accountType;
                this.address = address;
                this.AccountName = accountName;
                this.accountNumber = accountNumber;
                this.in_Use = in_Use;
                this.dateCreated = dateCreated;
                this.archived = archived;
                this.user = user;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public Bank Bank
        {
            get { return bank; }
            set { bank = value; }
        }

        public BankBranch BankBranch
        {
            get { return bankBranch; }
            set { bankBranch = value; }
        }

        public AccountType AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
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

        public bool In_Use
        {
            get { return in_Use; }
            set { in_Use = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public DateTime DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }
    } 
}
