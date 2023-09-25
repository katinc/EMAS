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
    public class AllowanceDataMapper
    {
        private DALHelper dal;

        public AllowanceDataMapper()
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
                Allowance allowance = (Allowance)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", allowance.Code, DbType.String);
                dal.CreateParameter("@AllowanceType", allowance.AllowanceType.ID, DbType.Int32);
                dal.CreateParameter("@AllowanceCategoryID", allowance.AllowanceSubCategory.ID, DbType.Int32);
                dal.CreateParameter("@Description", allowance.Description, DbType.String);
                dal.CreateParameter("@Amount", allowance.Amount, DbType.Decimal);
                dal.CreateParameter("@InUse", allowance.InUse, DbType.Boolean);
                dal.CreateParameter("@Level", allowance.Level.ID, DbType.Int32);
                dal.CreateParameter("@UserID", allowance.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO Allowance_Setup (Code,Type,CategoryID,Description,Amount,InUse,GradeLevel)VALUES(@Code,@AllowanceType,@AllowanceCategoryID,@Description,@Amount,@InUse,@Level)");
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
                Allowance allowance = (Allowance)item;
                dal.ClearParameters();
                dal.CreateParameter("@AID", allowance.ID, DbType.Int32);
                dal.CreateParameter("@Code", allowance.Code, DbType.String);
                dal.CreateParameter("@AllowanceType", allowance.AllowanceType.ID, DbType.Int32);
                dal.CreateParameter("@AllowanceCategoryID", allowance.AllowanceSubCategory.ID, DbType.Int32);
                dal.CreateParameter("@Description", allowance.Description, DbType.String);
                dal.CreateParameter("@Amount", allowance.Amount, DbType.Decimal);
                dal.CreateParameter("@InUse", allowance.InUse, DbType.Boolean);
                dal.CreateParameter("@Level", allowance.Level.ID, DbType.Int32);
                dal.CreateParameter("@UserID", allowance.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update Allowance_Setup Set Code=@Code,Type =@AllowanceType,CategoryID =@AllowanceCategoryID,Description=@Description,Amount =@Amount,InUse=@InUse,GradeLevel=@Level Where AID =@AID");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region GetAll
        public IList<Allowance> GetAll()
        {
            IList<Allowance> allowances = new List<Allowance>();
            try
            {
                string query = "Select * From Allowance_SetupView Where Allowance_SetupView.Archived ='False' ";
                DataTable table = dal.ExecuteReader(query);

                foreach (Allowance allowa in BuildAllowanceFromData(table))
                {
                    allowances.Add(allowa);
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return allowances;
        }
        #endregion

        #region GetByCriteria
        public IList<Allowance> GetByCriteria(Query query1)
        {
            IList<Allowance> allowances = new List<Allowance>();
            Allowance allowance = new Allowance();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from Allowance_SetupView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Allowance_SetupView.Archived='False' Order By Allowance_SetupView.Description ";
                table = dal.ExecuteReader(selectStatement);
                foreach (Allowance allowa in BuildAllowanceFromData(table))
                {
                    allowances.Add(allowa);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return allowances;
        }
        #endregion

        #region BuildAllowanceFromData
        private IList<Allowance> BuildAllowanceFromData(DataTable table)
        {
            IList<Allowance> allowances = new List<Allowance>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Allowance allowance = new Allowance()
                    {
                        ID = int.Parse(row["AID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Level = new EmployeeGrade()
                        {
                            ID = row["GradeLevelID"] == DBNull.Value ? 0 : int.Parse(row["GradeLevelID"].ToString()),
                            Grade = row["GradeLevel"] == DBNull.Value ? null : row["GradeLevel"].ToString()
                        },

                        AllowanceType = new AllowanceCategory() 
                        {
                            ID = row["AllowanceTypeID"] == DBNull.Value ? 0 : int.Parse(row["AllowanceTypeID"].ToString()),
                            Description = row["AllowanceType"] == DBNull.Value ? null : row["AllowanceType"].ToString()
                        },

                        AllowanceSubCategory = new AllowanceSubCategory()
                        {
                            ID = row["AllowanceCategoryID"] == DBNull.Value ? 0 : int.Parse(row["AllowanceCategoryID"].ToString()),
                            Description = row["AllowanceCategory"] == DBNull.Value ? null : row["AllowanceCategory"].ToString()
                        },

                        Amount = row["Amount"] == DBNull.Value ? 0 : Decimal.Parse(row["Amount"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString()
                        },
                        Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString()),
                        InUse = row["InUse"] == DBNull.Value ? false : bool.Parse(row["InUse"].ToString()),
                    
                    };

                    allowances.Add(allowance);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return allowances;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                Allowance allowance = (Allowance)item;
                dal.ExecuteNonQuery("Update Allowance_Setup Set Archived ='True' Where AID=" + allowance.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Transaction Management
        public void BeginTransaction()
        {
            dal.BeginTransaction();
        }

        public void CommitTransaction()
        {
            dal.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            dal.RollBackTransaction();
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
