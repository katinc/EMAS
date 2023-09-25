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
    public class EmployeeGradeCategoryDataMapper
    {
        private DALHelper dal;

        public EmployeeGradeCategoryDataMapper()
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

        #region SAVE
        public void Save(object item)
        {
            try
            {
                GradeCategory gradeCategory = (GradeCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description",gradeCategory.Description, DbType.String);
                dal.CreateParameter("@Code",gradeCategory.Code, DbType.String);
                dal.CreateParameter("@Active", gradeCategory.Active, DbType.Boolean);
                dal.CreateParameter("@UserID",gradeCategory.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO GradeCategory_Setup (Code,Description,Active,UserID)VALUES(@Code,@Description,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                GradeCategory gradeCategory = (GradeCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", gradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@Description", gradeCategory.Description, DbType.String);
                dal.CreateParameter("@Code", gradeCategory.Code, DbType.String);
                dal.CreateParameter("@Active", gradeCategory.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", gradeCategory.User.ID, DbType.String);
                dal.ExecuteNonQuery("Update GradeCategory_Setup Set Description =@Description,Code = @Code, Active=@Active, UserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                GradeCategory gradeCategory = (GradeCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", gradeCategory.ID, DbType.String);
                dal.ExecuteNonQuery("Update GradeCategory_Setup Set Archived='True' Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll()
        public IList<GradeCategory> GetAll()
        {
            IList<GradeCategory> gradeCategories = new List<GradeCategory>();
            try
            {
                string query = "Select * from GradeCategoryView  Where Archived='False' order by Description";
                DataTable table = dal.ExecuteReader(query);
                foreach (GradeCategory gradeCat in BuildGradeCategoryFromData(table))
                {
                    gradeCategories.Add(gradeCat);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return gradeCategories;
        }
        #endregion

        #region GetByKey
        public GradeCategory GetByKey(string categoryID)
        {
            GradeCategory gradeCategory = new GradeCategory();
            try
            {
                string query = "Select * from GradeCategoryView  Where ID =" + categoryID + " And GradeCategoryView.Archived='False' order by GradeCategoryView.Description";
                DataTable gradeTable = dal.ExecuteReader(query);
                foreach (DataRow row in gradeTable.Rows)
                {
                    gradeCategory = new GradeCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"] == DBNull.Value ? null : row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return gradeCategory;
        }
        #endregion

        #region GetByCriteria
        public IList<GradeCategory> GetByCriteria(Query query1)
        {
            IList<GradeCategory> gradeCategories = new List<GradeCategory>();
            try
            {
                DataTable table = new DataTable();

                string query = "select * from GradeCategoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  GradeCategoryView.Archived='False' order BY GradeCategoryView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (GradeCategory gradeCat in BuildGradeCategoryFromData(table))
                {
                    gradeCategories.Add(gradeCat);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return gradeCategories;
        }
        #endregion

        #region BuildGradeCategoryFromData
        private IList<GradeCategory> BuildGradeCategoryFromData(DataTable table)
        {
            IList<GradeCategory> gradeCategories = new List<GradeCategory>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    GradeCategory gradeCategory = new GradeCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"] == DBNull.Value ? string.Empty : row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                    };
                    gradeCategories.Add(gradeCategory);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return gradeCategories;
        }
        #endregion
    }
}
