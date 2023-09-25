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
    public class ChartOfAccountGenerationDataMapper
    {
        private DALHelper dal;

        public ChartOfAccountGenerationDataMapper()
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
                ChartOfAccountGeneration chartOfAccountGeneration = (ChartOfAccountGeneration)item;
               
                dal.ClearParameters();
                dal.CreateParameter("@AccountCode", chartOfAccountGeneration.AccountCode, DbType.String);
                dal.CreateParameter("@AccountDescription", chartOfAccountGeneration.AccountDescription, DbType.String);
                dal.CreateParameter("@AccountHeader", chartOfAccountGeneration.AccountHeader, DbType.String);
                dal.CreateParameter("@Report", chartOfAccountGeneration.Report, DbType.String);
                dal.CreateParameter("@QuickbookOverseer", chartOfAccountGeneration.QuickbookOverseer, DbType.String);
                dal.CreateParameter("@Amount", chartOfAccountGeneration.Amount, DbType.Decimal);
                dal.CreateParameter("@GradeCategory", chartOfAccountGeneration.GradeCategory.Description, DbType.String);
                dal.CreateParameter("@Department", chartOfAccountGeneration.Department.Description, DbType.String);
                dal.CreateParameter("@DepartmentCode", chartOfAccountGeneration.Department.Code, DbType.String);
                dal.CreateParameter("@Unit", chartOfAccountGeneration.Unit.Description, DbType.String);
                dal.CreateParameter("@UnitCode", chartOfAccountGeneration.Unit.Code, DbType.String);
                dal.CreateParameter("@AccountType", chartOfAccountGeneration.ChartOfAccountType.Description, DbType.String);
                dal.CreateParameter("@Active", chartOfAccountGeneration.Active, DbType.Boolean);
                dal.CreateParameter("@Posted", chartOfAccountGeneration.Posted, DbType.Boolean);
                dal.CreateParameter("@UserName", chartOfAccountGeneration.User.UserName, DbType.String);
                dal.CreateParameter("@Name", chartOfAccountGeneration.User.Name, DbType.String);
                dal.CreateParameter("@Status", chartOfAccountGeneration.Status, DbType.String);
                dal.CreateParameter("@Month", chartOfAccountGeneration.Month, DbType.String);
                dal.CreateParameter("@Year", chartOfAccountGeneration.Year, DbType.String);
                dal.CreateParameter("@Type", chartOfAccountGeneration.Type, DbType.String);
                dal.CreateParameter("@TransactionID", chartOfAccountGeneration.TransactionID, DbType.String);

                if (chartOfAccountGeneration.Date == null)
                {
                    dal.CreateParameter("@Date", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@Date", chartOfAccountGeneration.Date, DbType.Date);
                }

                string insertCommand = string.Empty;
                insertCommand = "Insert Into ChartOfAccountGeneration (AccountCode,AccountDescription,AccountHeader,Report,QuickbookOverseer,Amount,GradeCategory,Department,DepartmentCode,Unit,UnitCode,AccountType,Active,UserName,Name,Status,Month,Year,Type,Date,Posted,TransactionID) Values(@AccountCode,@AccountDescription,@AccountHeader,@Report,@QuickbookOverseer,@Amount,@GradeCategory,@Department,@DepartmentCode,@Unit,@UnitCode,@AccountType,@Active,@UserName,@Name,@Status,@Month,@Year,@Type,@Date,@Posted,@TransactionID)";
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
                ChartOfAccountGeneration chartOfAccountGeneration = (ChartOfAccountGeneration)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", chartOfAccountGeneration.ID, DbType.Int32);
                dal.CreateParameter("@AccountCode", chartOfAccountGeneration.AccountCode, DbType.String);
                dal.CreateParameter("@AccountDescription", chartOfAccountGeneration.AccountDescription, DbType.String);
                dal.CreateParameter("@AccountHeader", chartOfAccountGeneration.AccountHeader, DbType.String);
                dal.CreateParameter("@Report", chartOfAccountGeneration.Report, DbType.String);
                dal.CreateParameter("@QuickbookOverseer", chartOfAccountGeneration.QuickbookOverseer, DbType.String);
                dal.CreateParameter("@Amount", chartOfAccountGeneration.Amount, DbType.String);
                dal.CreateParameter("@GradeCategory", chartOfAccountGeneration.GradeCategory.Description, DbType.String);
                dal.CreateParameter("@Department", chartOfAccountGeneration.Department.Description, DbType.String);
                dal.CreateParameter("@DepartmentCode", chartOfAccountGeneration.Department.Code, DbType.String);
                dal.CreateParameter("@Unit", chartOfAccountGeneration.Unit.Description, DbType.String);
                dal.CreateParameter("@UnitCode", chartOfAccountGeneration.Unit.Code, DbType.String);
                dal.CreateParameter("@AccountType", chartOfAccountGeneration.ChartOfAccountType.Description, DbType.String);
                dal.CreateParameter("@Active", chartOfAccountGeneration.Active, DbType.Boolean);
                dal.CreateParameter("@Posted", chartOfAccountGeneration.Posted, DbType.Boolean);
                dal.CreateParameter("@UserName", chartOfAccountGeneration.User.UserName, DbType.String);
                dal.CreateParameter("@Name", chartOfAccountGeneration.User.Name, DbType.String);
                dal.CreateParameter("@Status", chartOfAccountGeneration.Status, DbType.String);
                dal.CreateParameter("@Month", chartOfAccountGeneration.Month, DbType.String);
                dal.CreateParameter("@Year", chartOfAccountGeneration.Year, DbType.String);
                dal.CreateParameter("@Type", chartOfAccountGeneration.Type, DbType.String);
                dal.CreateParameter("@TransactionID", chartOfAccountGeneration.TransactionID, DbType.String);

                if (chartOfAccountGeneration.Date == null)
                {
                    dal.CreateParameter("@Date", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@Date", chartOfAccountGeneration.Date, DbType.Date);
                }

                string updateCommand = string.Empty;
                updateCommand = "Update ChartOfAccountGeneration Set AccountCode=@AccountCode,AccountDescription=@AccountDescription,AccountHeader=@AccountHeader,Report=@Report,QuickbookOverseer=@QuickbookOverseer,GradeCategory=@GradeCategory,Department=@Department,DepartmentCode=@DepartmentCode,Unit=@Unit,UnitCode=@UnitCode,AccountType=@AccountType,Active=@Active,UserName=@UserName,Name=@Name,Status=@Status,Month=@Month,Year=@Year,Type=@Type,Date=@Date,Posted=@Posted,TransactionID=@TransactionID  Where ID=@ID";
                dal.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<ChartOfAccountGeneration> GetAll()
        {
            IList<ChartOfAccountGeneration> chartOfAccountGenerations = new List<ChartOfAccountGeneration>();
            try
            {
                string query = "select ChartOfAccountGenerationView.* From ChartOfAccountGenerationView ";
                DataTable table = dal.ExecuteReader(query);
                foreach (ChartOfAccountGeneration chartOfAccountGeneration in BuildChartOfAccountGenerationFromData(table))
                {
                    chartOfAccountGenerations.Add(chartOfAccountGeneration);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return chartOfAccountGenerations;
        }
        #endregion

        #region GetByCriteria
        public IList<ChartOfAccountGeneration> GetByCriteria(Query query1)
        {
            IList<ChartOfAccountGeneration> chartOfAccountGenerations = new List<ChartOfAccountGeneration>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT ChartOfAccountGenerationView.* From ChartOfAccountGenerationView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                table = dal.ExecuteReader(selectStatement);
                foreach (ChartOfAccountGeneration chartOfAccountGeneration in BuildChartOfAccountGenerationFromData(table))
                {
                    chartOfAccountGenerations.Add(chartOfAccountGeneration);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountGenerations;
        }
        #endregion

        #region Get By ID
        public ChartOfAccountGeneration GetByID(object key)
        {
            ChartOfAccountGeneration chartOfAccountGeneration = new ChartOfAccountGeneration();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@AccountCode", key.ToString(), DbType.String);
                string query = "select ChartOfAccountGenerationView.* From ChartOfAccountGenerationView Where AccountCode=@AccountCode";
                DataTable table = dal.ExecuteReader(query);
                foreach (ChartOfAccountGeneration chartOfAccountGen in BuildChartOfAccountGenerationFromData(table))
                {
                    chartOfAccountGeneration = chartOfAccountGen;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountGeneration;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                ChartOfAccountGeneration chartOfAccountGeneration = (ChartOfAccountGeneration)item;

                dal.ExecuteNonQuery("delete from ChartOfAccountGeneration Where ID ='" + chartOfAccountGeneration.ID + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildChartOfAccountGenerationFromData
        private IList<ChartOfAccountGeneration> BuildChartOfAccountGenerationFromData(DataTable table)
        {
            IList<ChartOfAccountGeneration> chartOfAccountGenerations = new List<ChartOfAccountGeneration>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ChartOfAccountGeneration chartOfAccountGeneration = new ChartOfAccountGeneration();
                    chartOfAccountGeneration.ID = int.Parse(row["ID"].ToString());
                    chartOfAccountGeneration.Amount = decimal.Parse(row["Amount"].ToString());
                    chartOfAccountGeneration.AccountCode = row["AccountCode"] == DBNull.Value ? string.Empty : row["AccountCode"].ToString();
                    chartOfAccountGeneration.AccountDescription = row["AccountDescription"] == DBNull.Value ? string.Empty : row["AccountDescription"].ToString();
                    chartOfAccountGeneration.AccountHeader = row["AccountHeader"] == DBNull.Value ? string.Empty : row["AccountHeader"].ToString();
                    chartOfAccountGeneration.Report = row["Report"] == DBNull.Value ? string.Empty : row["Report"].ToString();
                    chartOfAccountGeneration.QuickbookOverseer = row["QuickbookOverseer"] == DBNull.Value ? string.Empty : row["QuickbookOverseer"].ToString();
                    chartOfAccountGeneration.Active = row["Active"] == DBNull.Value ? false : bool.Parse(row["Active"].ToString());
                    chartOfAccountGeneration.Posted = row["Posted"] == DBNull.Value ? false : bool.Parse(row["Posted"].ToString());
                    chartOfAccountGeneration.Status = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString();
                    chartOfAccountGeneration.Month = row["Month"] == DBNull.Value ? string.Empty : row["Month"].ToString();
                    chartOfAccountGeneration.Year = row["Year"] == DBNull.Value ? string.Empty : row["Year"].ToString();
                    chartOfAccountGeneration.Type = row["Type"] == DBNull.Value ? string.Empty : row["Type"].ToString();
                    chartOfAccountGeneration.TransactionID = row["TransactionID"] == DBNull.Value ? string.Empty : row["TransactionID"].ToString();

                    chartOfAccountGeneration.GradeCategory = new GradeCategory()
                    {
                        Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                    };
                    chartOfAccountGeneration.Department = new Department()
                    {
                        Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString(),
                        Code = row["DepartmentCode"] == DBNull.Value ? string.Empty : row["DepartmentCode"].ToString(),
                    };
                    chartOfAccountGeneration.Unit = new Unit()
                    {
                        Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString(),
                        Code = row["UnitCode"] == DBNull.Value ? string.Empty : row["UnitCode"].ToString(),
                    };
                    chartOfAccountGeneration.ChartOfAccountType = new ChartOfAccountType()
                    {
                        Description = row["AccountType"] == DBNull.Value ? string.Empty : row["AccountType"].ToString()
                    };
                    chartOfAccountGeneration.DateAndTimeGenerated = DateTime.Parse(row["ServerTime"].ToString());
                    chartOfAccountGeneration.User = new User()
                    {
                        UserName = row["UserName"] == DBNull.Value ? string.Empty : row["UserName"].ToString(),
                        Name = row["Name"] == DBNull.Value ? string.Empty : row["Name"].ToString(),
                    };
                    chartOfAccountGeneration.Date = row["Date"] is DBNull ? DateTime.Now.Date : DateTime.Parse(row["Date"].ToString());
                    chartOfAccountGenerations.Add(chartOfAccountGeneration);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return chartOfAccountGenerations;
        }
        #endregion
    }
}
