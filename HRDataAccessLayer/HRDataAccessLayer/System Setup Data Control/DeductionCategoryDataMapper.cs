using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using System.Data;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class DeductionCategoryDataMapper
    {
        private DALHelper dal;

        public DeductionCategoryDataMapper()
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
                DeductionCategory deductionCategory = (DeductionCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", deductionCategory.Description, DbType.String);
                dal.CreateParameter("@Active", deductionCategory.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", deductionCategory.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO DeductionCategories (Description,Active,UserID)VALUES(@Description,@Active,@UserID)");
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
                DeductionCategory deductionCategory = (DeductionCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", deductionCategory.ID, DbType.Int32);
                dal.CreateParameter("@Description", deductionCategory.Description, DbType.String);
                dal.CreateParameter("@Active", deductionCategory.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", deductionCategory.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update DeductionCategories Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        public IList<DeductionCategory> GetAll()
        {
            IList<DeductionCategory> deductionCategories = new List<DeductionCategory>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From DeductionCategoryView Where Archived='False'");
                foreach (DeductionCategory deductionTy in BuildDeductionCategoryFromData(table))
                {
                    deductionCategories.Add(deductionTy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deductionCategories;
        }

        public IList<DeductionCategory> GetByCriteria(Query query1)
        {
            IList<DeductionCategory> deductionCategories = new List<DeductionCategory>();
            try
            {
                string query = "Select * From DeductionCategoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " DeductionCategoryView.Archived='False' Order By DeductionCategoryView.Description ";
                DataTable table = dal.ExecuteReader(selectStatement);
                foreach (DeductionCategory deductionTy in BuildDeductionCategoryFromData(table))
                {
                    deductionCategories.Add(deductionTy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deductionCategories;
        }

        #region BuildDeductionCategoryFromData
        private IList<DeductionCategory> BuildDeductionCategoryFromData(DataTable table)
        {
            IList<DeductionCategory> deductionCategories = new List<DeductionCategory>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    DeductionCategory deductionCategory = new DeductionCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        User = new User() 
                        { 
                            ID = int.Parse(row["ID"].ToString()),
                            UserName = row["UserName"].ToString(),
                        }
                    };

                    deductionCategories.Add(deductionCategory);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return deductionCategories;
        }
        #endregion


        #region Delete
        public void Delete(object item)
        {
            try
            {
                DeductionCategory deductionCategory = (DeductionCategory)item;
                dal.ExecuteNonQuery("Update DeductionCategories Set Archived ='True' Where ID=" + deductionCategory.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
