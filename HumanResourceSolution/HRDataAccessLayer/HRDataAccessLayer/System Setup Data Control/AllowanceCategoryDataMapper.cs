using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class AllowanceCategoryDataMapper
    {
        private DALHelper dal;

        public AllowanceCategoryDataMapper()
        {
            try
            {
                dal = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region Save

        public void Save(object item)
        {
            try
            {
                AllowanceCategory allowanceType = (AllowanceCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", allowanceType.Description, DbType.String);
                dal.CreateParameter("@Active", allowanceType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("INSERT INTO AllowanceTypes (Description,Active)VALUES(@Description,@Active)");
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
                AllowanceCategory allowanceType = (AllowanceCategory)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", allowanceType.ID, DbType.Int32);
                dal.CreateParameter("@Description", allowanceType.Description, DbType.String);
                dal.CreateParameter("@Active", allowanceType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update AllowanceTypes Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        
        public IList<AllowanceCategory> GetAll()
        {
            IList<AllowanceCategory> allowanceTypes = new List<AllowanceCategory>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From AllowanceTypeView");
                foreach (AllowanceCategory allowaT in BuildAllowanceTypeFromData(table))
                {
                    allowanceTypes.Add(allowaT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return allowanceTypes;
        }

        #region GetByCriteria
        public IList<AllowanceCategory> GetByCriteria(Query query1)
        {
            IList<AllowanceCategory> allowanceTypes = new List<AllowanceCategory>();
            AllowanceCategory allowanceType = new AllowanceCategory();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from AllowanceTypeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " AllowanceTypeView.Archived='False' Order By AllowanceTypeView.Description ";
                table = dal.ExecuteReader(selectStatement);
                foreach (AllowanceCategory allowaT in BuildAllowanceTypeFromData(table))
                {
                    allowanceTypes.Add(allowaT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return allowanceTypes;
        }
        #endregion

        #region BuildAllowanceTypeFromData
        private IList<AllowanceCategory> BuildAllowanceTypeFromData(DataTable table)
        {
            IList<AllowanceCategory> allowanceTypes = new List<AllowanceCategory>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    AllowanceCategory allowanceType = new AllowanceCategory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };

                    allowanceTypes.Add(allowanceType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return allowanceTypes;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                AllowanceCategory allowanceType = (AllowanceCategory)item;
                dal.ExecuteNonQuery("Update AllowanceTypes Set Archived ='True' Where ID=" + allowanceType.ID);
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
