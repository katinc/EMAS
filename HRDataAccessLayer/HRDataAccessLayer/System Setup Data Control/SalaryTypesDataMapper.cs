using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using System.Data;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class SalaryTypesDataMapper
    {
        private DALHelper dal;

        public SalaryTypesDataMapper()
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
                SalaryType salaryType = (SalaryType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", salaryType.Description, DbType.String);
                dal.CreateParameter("@Active", salaryType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", salaryType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO SalaryTypes (Description,Active,UserID)VALUES(@Description,@Active,@UserID)");
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
                SalaryType salaryType = (SalaryType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", salaryType.ID, DbType.Int32);
                dal.CreateParameter("@Description", salaryType.Description, DbType.String);
                dal.CreateParameter("@Active", salaryType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", salaryType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update SalaryTypes Set Description=@Description,Active=@Active,UserID=@UserID Where AID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region GetAll
        public IList<SalaryType> GetAll()
        {
            IList<SalaryType> salaryTypes = new List<SalaryType>();
            try
            {
                DataTable salaryTable = dal.ExecuteReader("Select * From SalaryTypeView where Archived='False'");
                foreach (SalaryType salaTy in BuildSalaryTypeFromData(salaryTable))
                {
                    salaryTypes.Add(salaTy);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return salaryTypes;
        }
        #endregion

        #region GetByCriteria
        public IList<SalaryType> GetByCriteria(Query query1)
        {
            IList<SalaryType> salaryTypes = new List<SalaryType>();
            SalaryType salaryType = new SalaryType();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from SalaryTypeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' Order By SalaryTypeView.Description ";
                table = dal.ExecuteReader(selectStatement);
                foreach (SalaryType salaryTy in BuildSalaryTypeFromData(table))
                {
                    salaryTypes.Add(salaryTy);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return salaryTypes;
        }
        #endregion

        #region BuildSalaryTypeFromData
        private IList<SalaryType> BuildSalaryTypeFromData(DataTable table)
        {
            IList<SalaryType> salaryTypes = new List<SalaryType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    SalaryType salaryType = new SalaryType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] is DBNull ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString(),
                        },
                    };

                    salaryTypes.Add(salaryType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return salaryTypes;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                SalaryType salaryType = (SalaryType)item;
                dal.ExecuteNonQuery("Update SalaryTypes Set Archived ='True' Where ID=" + salaryType.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
