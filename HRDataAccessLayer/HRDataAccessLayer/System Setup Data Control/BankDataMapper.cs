using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class BankDataMapper
    {
        private DALHelper dal;
        private Bank bank;

        public BankDataMapper()
        {
            this.dal = new DALHelper();
            this.bank = new Bank();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Bank bank = (Bank)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", bank.Code, DbType.String);
                dal.CreateParameter("@Description", bank.Description, DbType.String);
                dal.CreateParameter("@SortCode", bank.Sortcode, DbType.String);
                dal.CreateParameter("@Active", bank.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", bank.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Banks(Code,Description,SortCode,Active,UserID) Values(@Code,@Description,@SortCode,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                Bank bank = (Bank)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", bank.ID, DbType.Int32);
                dal.CreateParameter("@Code", bank.Code, DbType.String);
                dal.CreateParameter("@Description", bank.Description, DbType.String);
                dal.CreateParameter("@SortCode", bank.Sortcode, DbType.String);
                dal.CreateParameter("@Active", bank.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", bank.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", bank.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Banks Set Code=@Code,Description=@Description,SortCode=@SortCode,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Bank> GetAll()
        {
            IList<Bank> banks = new List<Bank>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", bank.Archived, DbType.String);
                string query = "select * from BankView ";
                query += "WHERE BankView.Archived=@Archived order BY BankView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Bank ban in BuildBankFromData(table))
                {
                    banks.Add(ban);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return banks;
        }
        #endregion

        #region GetByCriteria
        public IList<Bank> GetByCriteria(Query query1)
        {
            IList<Bank> banks = new List<Bank>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select * from BankView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  BankView.Archived=@Archived order BY BankView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Bank bank in BuildBankFromData(table))
                {
                    banks.Add(bank);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return banks;
        }
        #endregion

        #region BuildBankFromData
        private IList<Bank> BuildBankFromData(DataTable table)
        {
            IList<Bank> banks = new List<Bank>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Bank bank = new Bank()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Sortcode=row["SortCode"]!=DBNull.Value ? row["SortCode"].ToString():string.Empty,
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    banks.Add(bank);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return banks;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Bank bank = (Bank)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", bank.ID, DbType.Int32);
                dal.CreateParameter("@Archived", bank.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", bank.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Banks Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region Open Connection
        public void OpenConnection()
        {
            try
            {
                dal.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Close Connection
        public void CloseConnection()
        {
            try
            {
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
