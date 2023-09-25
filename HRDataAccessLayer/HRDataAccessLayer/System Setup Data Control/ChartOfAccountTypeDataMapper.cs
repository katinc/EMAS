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
    public class ChartOfAccountTypeDataMapper
    {
        private DALHelper dal;
        private ChartOfAccountType chartOfAccountType;

        public ChartOfAccountTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.chartOfAccountType = new ChartOfAccountType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                ChartOfAccountType chartOfAccountType = (ChartOfAccountType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", chartOfAccountType.Code, DbType.String);
                dal.CreateParameter("@Description", chartOfAccountType.Description, DbType.String);
                dal.CreateParameter("@UserID", chartOfAccountType.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", chartOfAccountType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into ChartOfAccountType (Code,Description,User,Active) Values(@Code,@Description,@UserID,@Active)");
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
                AccountType chartOfAccountType = (AccountType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", chartOfAccountType.ID, DbType.Int32);
                dal.CreateParameter("@Code", chartOfAccountType.Code, DbType.String);
                dal.CreateParameter("@Description", chartOfAccountType.Description, DbType.String);
                dal.CreateParameter("@UserID", chartOfAccountType.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", chartOfAccountType.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", chartOfAccountType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update ChartOfAccountType Set Code=@Code,UserID=@UserID,Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<ChartOfAccountType> GetAll()
        {
            IList<ChartOfAccountType> chartOfAccountTypes = new List<ChartOfAccountType>();
            try
            {
                string query = "select ChartOfAccountTypeView.* from ChartOfAccountTypeView ";
                DataTable table = dal.ExecuteReader(query);
                foreach (ChartOfAccountType accountT in BuildChartOfAccountTypeFromData(table))
                {
                    chartOfAccountTypes.Add(accountT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return chartOfAccountTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                ChartOfAccountType chartOfAccountType = (ChartOfAccountType)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", chartOfAccountType.ID, DbType.Int32);

                dal.ExecuteNonQuery("Delete from ChartOfAccountType Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<ChartOfAccountType> GetByCriteria(Query query1)
        {
            IList<ChartOfAccountType> chartOfAccountTypes = new List<ChartOfAccountType>();
            try
            {
                DataTable table = new DataTable();

                string query = "select ChartOfAccountTypeView.* from ChartOfAccountTypeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                table = dal.ExecuteReader(selectStatement);
                foreach (ChartOfAccountType accountType in BuildChartOfAccountTypeFromData(table))
                {
                    chartOfAccountTypes.Add(accountType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return chartOfAccountTypes;
        }
        #endregion

        #region BuildChartOfAccountTypeFromData
        private IList<ChartOfAccountType> BuildChartOfAccountTypeFromData(DataTable table)
        {
            IList<ChartOfAccountType> chartOfAccountTypes = new List<ChartOfAccountType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ChartOfAccountType chartOfAccountType = new ChartOfAccountType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()) },
                        Active = bool.Parse(row["Active"].ToString())
                    };
                    chartOfAccountTypes.Add(chartOfAccountType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountTypes;
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
