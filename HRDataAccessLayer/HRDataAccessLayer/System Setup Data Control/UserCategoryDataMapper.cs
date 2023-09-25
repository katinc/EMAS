using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class UserCategoryDataMapper
    {
        DALHelper dal;

        public UserCategoryDataMapper()
        {
            dal = new DALHelper();
        }

        #region GetAll
        public IList<UserCategory> GetAll()
        {
            IList<UserCategory> salaryTypes = new List<UserCategory>();
            try
            {
                DataTable salaryTable = dal.ExecuteReader("Select * From UserCategories Where Archived ='False' order by Description");
                foreach (DataRow row in salaryTable.Rows)
                {
                    salaryTypes.Add(new UserCategory() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString() });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salaryTypes;
        }
        #endregion

        #region Save
        public void Save(object item)
        {
            UserCategory userCategory = (UserCategory)item;

            dal.ClearParameters();
            dal.CreateParameter("@Description", userCategory.Description, DbType.String);
            dal.CreateParameter("@UserID", userCategory.UserID, DbType.Int32);

            try
            {
                dal.ExecuteNonQuery("Insert Into UserCategories(Description,UserID) Values(@Description,@UserID)");
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
            UserCategory userCategory = (UserCategory)item;

            dal.ClearParameters();
            dal.CreateParameter("@Description", userCategory.Description, DbType.String);
            dal.CreateParameter("@ID", userCategory.ID, DbType.Int32);
            dal.CreateParameter("@UserID", userCategory.UserID, DbType.Int32);

            try
            {
                dal.ExecuteNonQuery("Update UserCategories Set Description = @Description,UserID = @UserID Where ID = @ID");
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
            UserCategory userCategory = (UserCategory)item;

            dal.ClearParameters();
            dal.CreateParameter("@ID", userCategory.ID, DbType.Int32);

            try
            {
                dal.ExecuteNonQuery("Delete From UserCategories Where ID = @ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
