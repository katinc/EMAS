using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class StaffBankDataMapper
    {
        private DALHelper dal;
        private StaffBank staffBank;
        private IList<StaffBank> staffBanks;

        public StaffBankDataMapper()
        {
            this.dal = new DALHelper();
            this.staffBank=new StaffBank();
            this.staffBanks=new List<StaffBank>();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffBank staffBank = (StaffBank)item;
                dal.ClearParameters();
                dal.CreateParameter("@AccountName", staffBank.AccountName, DbType.String);
                dal.CreateParameter("@AccountNumber", staffBank.AccountNumber, DbType.String);
                dal.CreateParameter("@AccountTypeID", staffBank.AccountType.ID, DbType.Int32);
                dal.CreateParameter("@Address", staffBank.Address, DbType.String);
                dal.CreateParameter("@BankID", staffBank.Bank.ID, DbType.Int32);
                dal.CreateParameter("@BankBranchID", staffBank.BankBranch.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffBank.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffBank.Employee.ID, DbType.Int32);
                dal.CreateParameter("@InUse", staffBank.In_Use, DbType.Boolean);
                dal.CreateParameter("@UserID", staffBank.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into StaffBanks(AccountName,AccountNumber,AccountTypeID,Address,BankName,Branch,StaffID,StaffCode,InUse,UserID) Values(@AccountName,@AccountNumber,@AccountTypeID,@Address,@BankID,@BankBranchID,@StaffID,@StaffCode,@InUse,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                StaffBank staffBank = (StaffBank)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffBank.ID, DbType.Int32);
                dal.CreateParameter("@AccountName", staffBank.AccountName, DbType.String);
                dal.CreateParameter("@AccountNumber", staffBank.AccountNumber, DbType.String);
                dal.CreateParameter("@AccountTypeID", staffBank.AccountType.ID, DbType.Int32);
                dal.CreateParameter("@Address", staffBank.Address, DbType.String);
                dal.CreateParameter("@BankID", staffBank.Bank.ID, DbType.Int32);
                dal.CreateParameter("@BankBranchID", staffBank.BankBranch.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffBank.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffBank.Employee.ID, DbType.Int32);
                dal.CreateParameter("@InUse", staffBank.In_Use, DbType.Boolean);
                dal.CreateParameter("@UserID", staffBank.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update StaffBanks Set AccountName=@AccountName,AccountNumber=@AccountNumber,AccountTypeID=@AccountTypeID,Address=@Address,BankName=@BankID,Branch=@BankBranchID,StaffID=@StaffID,StaffCode=@StaffCode,InUse=@InUse,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffBank> GetByCriteria(Query query1)
        {
            IList<StaffBank> staffBanks = new List<StaffBank>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "Select StaffBankView.* FROM StaffBankView";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffBankView.Archived=@Archived order BY StaffBankView.Bank ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffBank staffBa in BuildStaffBankFromData(table))
                {
                    staffBanks.Add(staffBa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffBanks;
        }
        #endregion

        public IList<StaffBank> GetAll()
        {
            IList<StaffBank> staffBanks = new List<StaffBank>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", staffBank.Archived, DbType.String);
                string query = "Select StaffBankView.* FROM StaffBankView ";
                query += "WHERE StaffBankView.Archived=@Archived order BY StaffBankView.Bank ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (StaffBank staffB in BuildStaffBankFromData(table))
                {
                    staffBanks.Add(staffB);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffBanks;
        }

        public StaffBank GetByID(object key)
        {
            StaffBank staffBank = new StaffBank();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                dal.CreateParameter("@InUse", true, DbType.Boolean);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                string query = "Select StaffBankView.* FROM StaffBankView ";
                query += "WHERE StaffID=@StaffID and InUse=@InUse and StaffBankView.Archived=@Archived order BY StaffBankView.Bank ASC";
                DataTable table = dal.ExecuteReader(query);

                foreach (StaffBank sl in BuildStaffBankFromData(table))
                {
                    staffBank = sl;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffBank;
        }

        private IList<StaffBank> BuildStaffBankFromData(DataTable table)
        {
            IList<StaffBank> staffBanks = new List<StaffBank>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffBank staffBank = new StaffBank()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee() { ID = int.Parse(row["ID"].ToString()), StaffID = row["StaffID"].ToString() },
                        Bank = new Bank() { ID = int.Parse(row["BankID"].ToString()), Description = row["Bank"].ToString() },
                        BankBranch = new BankBranch() { ID = int.Parse(row["BankBranchID"].ToString()), Description = row["BankBranch"].ToString() },
                        AccountType = new AccountType() { ID = int.Parse(row["AccountTypeID"].ToString()), Description = row["AccountType"].ToString() },
                        AccountName = row["AccountName"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        Address = row["Address"] == DBNull.Value ? string.Empty : row["Address"].ToString(),
                        In_Use = bool.Parse(row["InUse"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        DateCreated = DateTime.Parse(row["ServerTime"].ToString()),
                        User = new User() 
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? string.Empty : row["UserName"].ToString() 
                        },
                    };
                    staffBanks.Add(staffBank);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffBanks;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                StaffBank staffBank = (StaffBank)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffBank.ID, DbType.Int32);
                dal.CreateParameter("@Archived", staffBank.Archived, DbType.String);

                dal.ExecuteNonQuery("Update StaffBanks Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
