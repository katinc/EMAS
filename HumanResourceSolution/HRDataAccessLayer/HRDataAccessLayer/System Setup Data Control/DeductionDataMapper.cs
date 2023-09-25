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
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class DeductionDataMapper
    {
        private DALHelper dal;

        public DeductionDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                Deduction deduction = (Deduction)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", deduction.Code, DbType.String);
                dal.CreateParameter("@DeductionTypeID", 5, deduction.Type.ID, DbType.Int32);
                dal.CreateParameter("@UserID", 5, deduction.User.ID, DbType.Int32);
                dal.CreateParameter("@Description", 30, deduction.Description, DbType.String);
                dal.CreateParameter("@Active", 5, deduction.Inactive, DbType.Boolean);
                dal.CreateParameter("@RateBased", 5, deduction.RateBased, DbType.Boolean);
                if (deduction.RateBased)
                {
                    dal.CreateParameter("@SalaryTypeID", 5, deduction.CalculatedOn.ID, DbType.Int32);
                    dal.CreateParameter("@Rate", 3, deduction.Rate, DbType.Decimal);
                    dal.ExecuteNonQuery("INSERT INTO Deduction_Setup (Code,DeductionTypeID,Description,Rate,SalaryTypeID,Active,RateBased,UserID) VALUES(@Code,@DeductionTypeID,@Description,@Rate,@SalaryTypeID,@Active,@RateBased,@UserID)");
                }
                else
                {
                    dal.CreateParameter("@Amount", 3, deduction.Amount, DbType.Decimal);
                    dal.ExecuteNonQuery("INSERT INTO Deduction_Setup (Code,DeductionTypeID,Description,Amount,Active,RateBased,UserID) VALUES(@Code,@DeductionTypeID,@Description,@Amount,@Active,@RateBased,@UserID)");
                }
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
                Deduction deduction = (Deduction)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", deduction.ID, DbType.Int32);
                dal.CreateParameter("@Code", deduction.Code, DbType.String);
                dal.CreateParameter("@UserID", deduction.User.ID, DbType.Int32);
                dal.CreateParameter("@DeductionTypeID", deduction.Type.ID, DbType.Int32);
                dal.CreateParameter("@Description", deduction.Description, DbType.String);
                dal.CreateParameter("@Rate", deduction.Rate, DbType.Decimal);
                dal.CreateParameter("@Amount", deduction.Amount, DbType.Decimal);
                dal.CreateParameter("@SalaryTypeID", deduction.CalculatedOn.ID, DbType.Int32);
                dal.CreateParameter("@Active", deduction.Inactive, DbType.Boolean);
                dal.CreateParameter("@RateBased", 5, deduction.RateBased, DbType.Boolean);
                dal.ExecuteNonQuery("Update Deduction_Setup  Set Code=@Code,UserID=@UserID,DeductionTypeID=@DeductionTypeID,Amount=@Amount,Description=@Description,Rate=@Rate,SalaryTypeID=@SalaryTypeID,Active=@Active,RateBased=@RateBased Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<Deduction> GetAll()
        {
            IList<Deduction> deductions = new List<Deduction>();
            try
            {
                string query = "Select * From Deduction_SetupView Where Deduction_SetupView.DeductionArchived ='False' ";
                DataTable table = dal.ExecuteReader(query);
                
                foreach (Deduction deduce in BuildDeductionFromData(table))
                {
                    deductions.Add(deduce);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return deductions;
        }
        #endregion

        #region GetByCriteria
        public IList<Deduction> GetByCriteria(Query query1)
        {
            IList<Deduction> deductions = new List<Deduction>();
            Deduction deduction = new Deduction();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from Deduction_SetupView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " DeductionArchived='False' Order By Deduction_SetupView.Description ";
                table = dal.ExecuteReader(selectStatement);
                foreach (Deduction deduce in BuildDeductionFromData(table))
                {
                    deductions.Add(deduce);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return deductions;
        }
        #endregion

        #region BuildDeductionFromData
        private IList<Deduction> BuildDeductionFromData(DataTable table)
        {
            IList<Deduction> deductions = new List<Deduction>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Deduction deduction = new Deduction()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        CalculatedOn = new SalaryType() { ID = row["SalaryTypeID"] is DBNull ? 0 : int.Parse(row["SalaryTypeID"].ToString()), Description = row["SalaryType"] == DBNull.Value ? null: row["SalaryType"].ToString() },
                        Description = row["Description"].ToString(),
                        Type = new DeductionSubCategory() 
                        { 
                            ID = row["DeductionTypeID"] is DBNull ? 0 : int.Parse(row["DeductionTypeID"].ToString()), 
                            Description = row["DeductionType"] == DBNull.Value ? null : row["DeductionType"].ToString() ,
                            DeductionCategory = new DeductionCategory() { ID = row["DeductionCategoryID"] is DBNull ? 0 : int.Parse(row["DeductionCategoryID"].ToString()), Description = row["DeductionCategory"] == DBNull.Value ? null : row["DeductionCategory"].ToString() },
                        },
                        Rate = row["Rate"] is DBNull ? 0 : decimal.Parse(row["Rate"].ToString()),
                        Inactive = bool.Parse(row["DeductionActive"].ToString()),
                        Amount = row["Amount"] is DBNull ? 0 : decimal.Parse(row["Amount"].ToString()),
                        RateBased = bool.Parse(row["RateBased"].ToString()),
                        ReportInclusive = bool.Parse(row["DeductionArchived"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] is DBNull ? 0 : int.Parse(row["UserID"].ToString()),                       
                        },
                    };

                    deductions.Add(deduction);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return deductions;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                Deduction deduction = (Deduction)item;
                dal.ExecuteNonQuery("Update Deduction_Setup Set Archived ='True' Where ID=" + deduction.ID);
            }
            catch (Exception ex)
            {
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
