using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class TaxableIncomeDataMapper
    {
        DALHelper dal;

        public TaxableIncomeDataMapper()
        {
            dal = new DALHelper();
        }

        #region Save
        public void Save(TaxableIncome taxableIncome)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Year",4,taxableIncome.Year,DbType.Int32);
                dal.CreateParameter("@Description",30,taxableIncome.Description,DbType.String);
                dal.CreateParameter("@AnnualTaxableIncome",10,taxableIncome.AnnualTaxableIncome,DbType.Decimal);
                dal.CreateParameter("@TaxRate", 3, taxableIncome.TaxRate, DbType.Decimal);
                dal.CreateParameter("@Active", 3, taxableIncome.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", 3, taxableIncome.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into TaxableIncome_Setup(Year,Description,AnnualTaxableIncome,TaxRate,Active,UserID) Values(@Year,@Description,@AnnualTaxableIncome,@TaxRate,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
        #endregion

        #region Update
        public void Update(TaxableIncome taxableIncome)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", 5, taxableIncome.ID, DbType.Int32);
                dal.CreateParameter("@Year", 4, taxableIncome.Year, DbType.Int32);
                dal.CreateParameter("@Description", 30, taxableIncome.Description, DbType.String);
                dal.CreateParameter("@AnnualTaxableIncome", 10, taxableIncome.AnnualTaxableIncome, DbType.Decimal);
                dal.CreateParameter("@TaxRate", 3, taxableIncome.TaxRate, DbType.Decimal);
                dal.CreateParameter("@Active", 3, taxableIncome.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", 3, taxableIncome.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update TaxableIncome_Setup Set UserID=@UserID,Year=@Year,Description=@Description,AnnualTaxableIncome=@AnnualTaxableIncome,TaxRate=@TaxRate,Active=@Active Where TIID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<TaxableIncome> GetAll()
        {
            IList<TaxableIncome> taxableIncomes = new List<TaxableIncome>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From TaxableIncome_Setup where Archived='False'");
                foreach (TaxableIncome ta in BuildTaxableIncomeFromData(table))
                {
                    taxableIncomes.Add(ta);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taxableIncomes;
        }
        #endregion

        #region GetByCriteria
        public IList<TaxableIncome> GetByCriteria(Query query1)
        {
            IList<TaxableIncome> taxableIncomes = new List<TaxableIncome>();
            try
            {
                DataTable table = new DataTable();
                string query = "select * from TaxableIncome_Setup ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY Year DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (TaxableIncome ta in BuildTaxableIncomeFromData(table))
                {
                    taxableIncomes.Add(ta);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return taxableIncomes;
        }
        #endregion

        #region Delete 
        public void Delete(object key)
        {
            try
            {
                dal.ExecuteNonQuery("Update TaxableIncome_Setup Set Archived='True'  Where TIID = " + key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        #region BuildTaxableIncomeFromData
        private IList<TaxableIncome> BuildTaxableIncomeFromData(DataTable table)
        {
            IList<TaxableIncome> taxableIncomes = new List<TaxableIncome>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    TaxableIncome taxableIncome = new TaxableIncome()
                    {
                        ID = int.Parse(row["TIID"].ToString()),
                        AnnualTaxableIncome = decimal.Parse(row["AnnualTaxableIncome"].ToString()),
                        Description = row["Description"].ToString(),
                        TaxRate = decimal.Parse(row["TaxRate"].ToString()),
                        Year = int.Parse(row["Year"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()) }
                    };
                    taxableIncomes.Add(taxableIncome);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return taxableIncomes;
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
