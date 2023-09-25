using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;


namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class UserAccessLevel2DataMapper
    {
        private DALHelper dal;

        public UserAccessLevel2DataMapper()
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

        #region SAVE
        public void Save(object item)
        {
            try
            {
                UserAccessLevel2 userAccessLevel2 = (UserAccessLevel2)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", userAccessLevel2.Description, DbType.String);
                dal.CreateParameter("@Level1ID", userAccessLevel2.UserAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel2.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into UserAccessLevel2 (Description,Level1ID,Active) Values(@Description,@Level1ID,@Active)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                UserAccessLevel2 userAccessLevel2 = (UserAccessLevel2)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@Description", userAccessLevel2.Description, DbType.String);
                dal.CreateParameter("@Level1ID", userAccessLevel2.UserAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel2.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update UserAccessLevel2 Set Description=@Description,Level1ID=@Level1ID,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<UserAccessLevel2> GetAll()
        {
            IList<UserAccessLevel2> userAccessLevels1 = new List<UserAccessLevel2>();
            try
            {
                dal.ClearParameters();
                string query = "select UserAccessLevel2View.* from UserAccessLevel2View Where UserAccessLevel2View.Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (UserAccessLevel2 userAccessLe1 in BuildUserAccessLevel2FromData(table))
                {
                    userAccessLevels1.Add(userAccessLe1);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return userAccessLevels1;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                UserAccessLevel2 userAccessLevel2 = (UserAccessLevel2)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel2.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update UserAccessLevel2 Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<UserAccessLevel2> GetByCriteria(Query query1)
        {
            IList<UserAccessLevel2> userAccessLevels2 = new List<UserAccessLevel2>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserAccessLevel2View.* from UserAccessLevel2View ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  UserAccessLevel2View.Active='False' order BY UserAccessLevel2View.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserAccessLevel2 userAccessLe1 in BuildUserAccessLevel2FromData(table))
                {
                    userAccessLevels2.Add(userAccessLe1);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels2;
        }
        #endregion

        #region BuildUserAccessLevel2FromData
        private IList<UserAccessLevel2> BuildUserAccessLevel2FromData(DataTable table)
        {
            IList<UserAccessLevel2> userAccessLevels2 = new List<UserAccessLevel2>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserAccessLevel2 userAccessLevel1 = new UserAccessLevel2()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    userAccessLevels2.Add(userAccessLevel1);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels2;
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
