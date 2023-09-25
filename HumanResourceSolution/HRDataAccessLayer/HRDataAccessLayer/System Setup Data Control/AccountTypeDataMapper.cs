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
    public class AccountTypeDataMapper
    {
        private DALHelper dal;
        private AccountType accountType;

        public AccountTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.accountType = new AccountType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                AccountType accountType = (AccountType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", accountType.Code, DbType.String);
                dal.CreateParameter("@Description", accountType.Description, DbType.String);
                dal.CreateParameter("@UserID", accountType.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", accountType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into AccountTypes (Code,Description,User,Active) Values(@Code,@Description,@UserID,@Active)");
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
                AccountType accountType = (AccountType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", accountType.Code, DbType.String);
                dal.CreateParameter("@Description", accountType.Description, DbType.String);
                dal.CreateParameter("@UserID", accountType.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", accountType.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", accountType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update AccountTypes Set Code=@Code,UserID=@UserID,Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<AccountType> GetAll()
        {
            IList<AccountType> accountTypes = new List<AccountType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", accountType.Archived, DbType.String);
                string query = "select AccountTypeView.* from AccountTypeView ";
                query += "WHERE AccountTypeView.Archived=@Archived order BY AccountTypeView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (AccountType accountT in BuildAccountTypeFromData(table))
                {
                    accountTypes.Add(accountT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return accountTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                AccountType accountType = (AccountType)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", accountType.ID, DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update AccountTypes Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<AccountType> GetByCriteria(Query query1)
        {
            IList<AccountType> accountTypes = new List<AccountType>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select AccountTypeView.* from AccountTypeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  AccountTypeView.Archived=@Archived order BY AccountTypeView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (AccountType accountType in BuildAccountTypeFromData(table))
                {
                    accountTypes.Add(accountType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return accountTypes;
        }
        #endregion

        #region BuildAccountTypeFromData
        private IList<AccountType> BuildAccountTypeFromData(DataTable table)
        {
            IList<AccountType> accountTypes = new List<AccountType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    AccountType accountType = new AccountType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()) },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    accountTypes.Add(accountType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return accountTypes;
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
