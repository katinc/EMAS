using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Data;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class ChartOfAccountMappingDataMapper
    {
        private DALHelper dal;

        public ChartOfAccountMappingDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                ChartOfAccountMapping chartOfAccountMapping = (ChartOfAccountMapping)item;

                dal.ClearParameters();
                dal.CreateParameter("@AccountCode", chartOfAccountMapping.AccountCode, DbType.String);
                dal.CreateParameter("@AccountDescription", chartOfAccountMapping.AccountDescription, DbType.String);
                dal.CreateParameter("@AccountHeader", chartOfAccountMapping.AccountHeader, DbType.String);
                dal.CreateParameter("@Report", chartOfAccountMapping.Report, DbType.String);
                dal.CreateParameter("@Query", chartOfAccountMapping.Query, DbType.String);
                dal.CreateParameter("@Type", chartOfAccountMapping.Type, DbType.String);
                dal.CreateParameter("@GradeCategoryID", chartOfAccountMapping.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@AccountTypeID", chartOfAccountMapping.ChartOfAccountType.ID, DbType.Int32);
                dal.CreateParameter("@Active", chartOfAccountMapping.Active, DbType.Boolean);
                dal.CreateParameter("@Date", chartOfAccountMapping.Date, DbType.Date);
                dal.CreateParameter("@UserID", chartOfAccountMapping.User.ID, DbType.Int32);

                string insertCommand = string.Empty;
                insertCommand = "Insert Into ChartOfAccountMapping (AccountCode,AccountDescription,AccountHeader,Report,Query,Type,GradeCategoryID,AccountTypeID,Active,Date,UserID) Values(@AccountCode,@AccountDescription,@AccountHeader,@Report,@Query,@Type,@GradeCategoryID,@AccountTypeID,@Active,@Date,@UserID)";
                dal.ExecuteNonQuery(insertCommand);
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
                ChartOfAccountMapping chartOfAccountMapping = (ChartOfAccountMapping)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", chartOfAccountMapping.ID, DbType.Int32);
                dal.CreateParameter("@AccountCode", chartOfAccountMapping.AccountCode, DbType.String);
                dal.CreateParameter("@AccountDescription", chartOfAccountMapping.AccountDescription, DbType.String);
                dal.CreateParameter("@AccountHeader", chartOfAccountMapping.AccountHeader, DbType.String);
                dal.CreateParameter("@Report", chartOfAccountMapping.Report, DbType.String);
                dal.CreateParameter("@Query", chartOfAccountMapping.Query, DbType.String);
                dal.CreateParameter("@Type", chartOfAccountMapping.Type, DbType.String);
                dal.CreateParameter("@GradeCategoryID", chartOfAccountMapping.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@AccountTypeID", chartOfAccountMapping.ChartOfAccountType.ID, DbType.Int32);
                dal.CreateParameter("@Active", chartOfAccountMapping.Active, DbType.Boolean);
                dal.CreateParameter("@Date", chartOfAccountMapping.Date, DbType.Date);
                dal.CreateParameter("@UserID", chartOfAccountMapping.User.ID, DbType.Int32);

                string updateCommand = string.Empty;
                updateCommand = "Update ChartOfAccountMapping Set AccountCode=@AccountCode,AccountDescription=@AccountDescription,AccountHeader=@AccountHeader,Report=@Report,Query=@Query,Type=@Type,GradeCategoryID=@GradeCategoryID,AccountTypeID=@AccountTypeID,Active=@Active,Date=@Date,UserID=@UserID  Where ID=@ID";
                dal.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<ChartOfAccountMapping> GetAll()
        {
            IList<ChartOfAccountMapping> chartOfAccountMappings = new List<ChartOfAccountMapping>();
            try
            {
                string query = "select ChartOfAccountMappingView.* From ChartOfAccountMappingView Where Archived = 'False'";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (ChartOfAccountMapping chartOfAccountMapping in BuildChartOfAccountMappingFromData(salaryInfoTable))
                {
                    chartOfAccountMappings.Add(chartOfAccountMapping);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return chartOfAccountMappings;
        }
        #endregion

        #region GetByCriteria
        public IList<ChartOfAccountMapping> GetByCriteria(Query query1)
        {
            IList<ChartOfAccountMapping> chartOfAccountMappings = new List<ChartOfAccountMapping>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT ChartOfAccountMappingView.* From ChartOfAccountMappingView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "Archived = 'False'";
                table = dal.ExecuteReader(selectStatement);
                foreach (ChartOfAccountMapping chartOfAccountMapping in BuildChartOfAccountMappingFromData(table))
                {
                    chartOfAccountMappings.Add(chartOfAccountMapping);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountMappings;
        }
        #endregion

        #region Get By ID
        public ChartOfAccountMapping GetByID(object key)
        {
            ChartOfAccountMapping chartOfAccountMapping = new ChartOfAccountMapping();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@AccountCode", key.ToString(), DbType.String);
                string query = "select ChartOfAccountMappingView.* From ChartOfAccountMappingView Where AccountCode=@AccountCode and Archived = 'False'";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (ChartOfAccountMapping chartOfAccountMapp in BuildChartOfAccountMappingFromData(salaryInfoTable))
                {
                    chartOfAccountMapping = chartOfAccountMapp;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountMapping;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                ChartOfAccountMapping chartOfAccountMapping = (ChartOfAccountMapping)item;

                dal.ExecuteNonQuery("update ChartOfAccountMapping SET Archived = '" + chartOfAccountMapping.Archived +"' Where ID ='" + chartOfAccountMapping.ID + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildChartOfAccountMappingFromData
        private IList<ChartOfAccountMapping> BuildChartOfAccountMappingFromData(DataTable table)
        {
            IList<ChartOfAccountMapping> chartOfAccountMappings = new List<ChartOfAccountMapping>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ChartOfAccountMapping chartOfAccountMapping = new ChartOfAccountMapping();
                    chartOfAccountMapping.ID = int.Parse(row["ID"].ToString());
                    chartOfAccountMapping.AccountCode = row["AccountCode"] == DBNull.Value ? string.Empty : row["AccountCode"].ToString();
                    chartOfAccountMapping.AccountDescription = row["AccountDescription"] == DBNull.Value ? string.Empty : row["AccountDescription"].ToString();
                    chartOfAccountMapping.AccountHeader = row["AccountHeader"] == DBNull.Value ? string.Empty : row["AccountHeader"].ToString();
                    chartOfAccountMapping.Report = row["Report"] == DBNull.Value ? string.Empty : row["Report"].ToString();
                    chartOfAccountMapping.Query = row["Query"] == DBNull.Value ? string.Empty : row["Query"].ToString();
                    chartOfAccountMapping.Type = row["Type"] == DBNull.Value ? string.Empty : row["Type"].ToString();
                    chartOfAccountMapping.Active = row["Active"] == DBNull.Value ? false : bool.Parse(row["Active"].ToString());
                    chartOfAccountMapping.Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString());
                    chartOfAccountMapping.GradeCategory = new GradeCategory()
                    {
                        ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                        Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                    };
                    chartOfAccountMapping.ChartOfAccountType = new ChartOfAccountType()
                    {
                        ID = row["ChartOfAccountTypeID"] == DBNull.Value ? 0 : int.Parse(row["ChartOfAccountTypeID"].ToString()),
                        Description = row["ChartOfAccountType"] == DBNull.Value ? string.Empty : row["ChartOfAccountType"].ToString()
                    };
                    chartOfAccountMapping.DateAndTimeGenerated = DateTime.Parse(row["ServerTime"].ToString());
                    chartOfAccountMapping.Date = DateTime.Parse(row["Date"].ToString());
                    chartOfAccountMapping.User = new User()
                    {
                        ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                    };

                    chartOfAccountMappings.Add(chartOfAccountMapping);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountMappings;
        }
        #endregion
    }
}
