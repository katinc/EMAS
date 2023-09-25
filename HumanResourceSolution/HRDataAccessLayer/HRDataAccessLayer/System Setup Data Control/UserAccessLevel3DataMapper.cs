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
    public class UserAccessLevel3DataMapper
    {
        private DALHelper dal;

        public UserAccessLevel3DataMapper()
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
                UserAccessLevel3 userAccessLevel3 = (UserAccessLevel3)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", userAccessLevel3.Description, DbType.String);
                dal.CreateParameter("@Level2ID", userAccessLevel3.UserAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel3.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into UserAccessLevel3 (Description,Level2ID,Active) Values(@Description,@Level2ID,@Active)");
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
                UserAccessLevel3 userAccessLevel3 = (UserAccessLevel3)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@Description", userAccessLevel3.Description, DbType.String);
                dal.CreateParameter("@Level2ID", userAccessLevel3.UserAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel3.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update UserAccessLevel2 Set Description=@Description,Level2ID=@Level2ID,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<UserAccessLevel3> GetAll()
        {
            IList<UserAccessLevel3> userAccessLevels3 = new List<UserAccessLevel3>();
            try
            {
                dal.ClearParameters();
                string query = "select UserAccessLevel3View.* from UserAccessLevel3View Where UserAccessLevel3View.Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (UserAccessLevel3 userAccessLe3 in BuildUserAccessLevel3FromData(table))
                {
                    userAccessLevels3.Add(userAccessLe3);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return userAccessLevels3;
        }
        #endregion

        #region GetByCriteria
        public IList<UserAccessLevel3> GetByCriteria(Query query1)
        {
            IList<UserAccessLevel3> userAccessLevels3 = new List<UserAccessLevel3>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserAccessLevel3View.* from UserAccessLevel3View ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  UserAccessLevel3View.Active='True' order BY UserAccessLevel3View.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserAccessLevel3 userAccessLe3 in BuildUserAccessLevel3FromData(table))
                {
                    userAccessLevels3.Add(userAccessLe3);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels3;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                UserAccessLevel3 userAccessLevel3 = (UserAccessLevel3)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel3.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update UserAccessLevel3 Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region BuildUserAccessLevel3FromData
        private IList<UserAccessLevel3> BuildUserAccessLevel3FromData(DataTable table)
        {
            IList<UserAccessLevel3> userAccessLevels3 = new List<UserAccessLevel3>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserAccessLevel3 userAccessLevel3 = new UserAccessLevel3()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        UserAccessLevel2 = new UserAccessLevel2() 
                        { 
                            ID = int.Parse(row["Level1ID"].ToString()),
                            Description = row["Level1"].ToString() 
                        },
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    userAccessLevels3.Add(userAccessLevel3);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userAccessLevels3;
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
