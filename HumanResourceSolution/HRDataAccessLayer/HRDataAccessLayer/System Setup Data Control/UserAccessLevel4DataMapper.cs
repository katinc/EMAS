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
    public class UserAccessLevel4DataMapper
    {
        private DALHelper dal;

        public UserAccessLevel4DataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                UserAccessLevel4 userAccessLevel4 = (UserAccessLevel4)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", userAccessLevel4.Description, DbType.String);
                dal.CreateParameter("@Level3ID", userAccessLevel4.UserAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel4.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into UserAccessLevel4 (Description,Level3ID,Active) Values(@Description,@Level3ID,@Active)");
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
                UserAccessLevel4 userAccessLevel4 = (UserAccessLevel4)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel4.ID, DbType.Int32);
                dal.CreateParameter("@Description", userAccessLevel4.Description, DbType.String);
                dal.CreateParameter("@Level3ID", userAccessLevel4.UserAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel4.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update UserAccessLevel4 Set Description=@Description,Level3ID=@Level3ID,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<UserAccessLevel4> GetAll()
        {
            IList<UserAccessLevel4> userAccessLevels4 = new List<UserAccessLevel4>();
            try
            {
                dal.ClearParameters();
                string query = "select UserAccessLevel4View.* from UserAccessLevel4View Where UserAccessLevel4View.Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (UserAccessLevel4 userAccessLe4 in BuildUserAccessLevel4FromData(table))
                {
                    userAccessLevels4.Add(userAccessLe4);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return userAccessLevels4;
        }
        #endregion

        #region GetByCriteria
        public IList<UserAccessLevel4> GetByCriteria(Query query1)
        {
            IList<UserAccessLevel4> userAccessLevels4 = new List<UserAccessLevel4>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserAccessLevel4View.* from UserAccessLevel4View ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  UserAccessLevel4View.Active='True' order BY UserAccessLevel4View.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserAccessLevel4 userAccessLe4 in BuildUserAccessLevel4FromData(table))
                {
                    userAccessLevels4.Add(userAccessLe4);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels4;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                UserAccessLevel4 userAccessLevel4 = (UserAccessLevel4)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel4.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel4.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update UserAccessLevel4 Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region BuildUserAccessLevel4FromData
        private IList<UserAccessLevel4> BuildUserAccessLevel4FromData(DataTable table)
        {
            IList<UserAccessLevel4> userAccessLevels4 = new List<UserAccessLevel4>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserAccessLevel4 userAccessLevel4 = new UserAccessLevel4()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        UserAccessLevel3 = new UserAccessLevel3()
                        {
                            ID = int.Parse(row["Level1ID"].ToString()),
                            Description = row["Level1"].ToString()
                        },
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    userAccessLevels4.Add(userAccessLevel4);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels4;
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
