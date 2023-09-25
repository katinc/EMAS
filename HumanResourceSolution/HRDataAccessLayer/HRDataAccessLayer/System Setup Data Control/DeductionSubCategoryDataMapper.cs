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
    public class DeductionSubCategoryDataMapper
    {
        private DALHelper dal;

        public DeductionSubCategoryDataMapper()
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
                DeductionSubCategory deductionType = (DeductionSubCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", deductionType.Description, DbType.String);
                dal.CreateParameter("@CategoryID", deductionType.DeductionCategory.ID, DbType.Int32);
                dal.CreateParameter("@Active", deductionType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", deductionType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO DeductionTypes (Description,CategoryID,Active,UserID)VALUES(@Description,@CategoryID,@Active,@UserID)");
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
                DeductionSubCategory deductionType = (DeductionSubCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", deductionType.ID, DbType.Int32);
                dal.CreateParameter("@Description", deductionType.Description, DbType.String);
                dal.CreateParameter("@CategoryID", deductionType.DeductionCategory.ID, DbType.Int32);
                dal.CreateParameter("@Active", deductionType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", deductionType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update DeductionTypes Set Description=@Description,CategoryID=@CategoryID,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        public IList<DeductionSubCategory> GetAll()
        {
            IList<DeductionSubCategory> deductionTypes = new List<DeductionSubCategory>();
            try
            {
                string query = "Select * From DeductionTypeView Where Archived ='False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (DeductionSubCategory deductionTy in BuildDeductionTypeFromData(table))
                {
                    deductionTypes.Add(deductionTy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deductionTypes;
        }

        public IList<DeductionSubCategory> GetByCriteria(Query query1)
        {
            IList<DeductionSubCategory> deductionTypes = new List<DeductionSubCategory>();           
            try
            {
                string query="Select * From DeductionTypeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " DeductionTypeView.Archived='False' and DeductionTypeView.Active='True' Order By DeductionTypeView.Description ";
                DataTable table = dal.ExecuteReader(selectStatement);
                foreach (DeductionSubCategory deductionTy in BuildDeductionTypeFromData(table))
                {
                    deductionTypes.Add(deductionTy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return deductionTypes;
        }

        #region BuildDeductionTypeFromData
        private IList<DeductionSubCategory> BuildDeductionTypeFromData(DataTable table)
        {
            IList<DeductionSubCategory> deductionTypes = new List<DeductionSubCategory>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    DeductionSubCategory deductionType = new DeductionSubCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()), 
                        Description = row["Description"].ToString() ,
                        DeductionCategory = new DeductionCategory() 
                        { 
                            ID = row["DeductionCategoryID"] is DBNull ? 0 : int.Parse(row["DeductionCategoryID"].ToString()), 
                            Description = row["DeductionCategory"] == DBNull.Value ? null : row["DeductionCategory"].ToString() 
                        },

                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()), 
                    };
                    deductionTypes.Add(deductionType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return deductionTypes;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                DeductionSubCategory deductionType = (DeductionSubCategory)item;
                dal.ExecuteNonQuery("Update DeductionTypes Set Archived ='True' Where ID=" + deductionType.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
