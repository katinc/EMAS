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
    public class UserAccessLevel1DataMapper
    {
        private DALHelper dal;

        public UserAccessLevel1DataMapper()
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
                UserAccessLevel1 userAccessLevel1 = (UserAccessLevel1)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", userAccessLevel1.Description, DbType.String);
                dal.CreateParameter("@Active", userAccessLevel1.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into UserAccessLevel1 (Description,Active) Values(@Description,@Active)");
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
                UserAccessLevel1 userAccessLevel1 = (UserAccessLevel1)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@Description", userAccessLevel1.Description, DbType.String);
                dal.CreateParameter("@Active", userAccessLevel1.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update UserAccessLevel1 Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<UserAccessLevel1> GetAll()
        {
            IList<UserAccessLevel1> userAccessLevels1 = new List<UserAccessLevel1>();
            try
            {
                string query = "select UserAccessLevel1View.* from UserAccessLevel1View Where UserAccessLevel1View.Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (UserAccessLevel1 userAccessLe1 in BuildUserAccessLevel1FromData(table))
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
                UserAccessLevel1 userAccessLevel1 = (UserAccessLevel1)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@Active", userAccessLevel1.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update UserAccessLevel1 Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<UserAccessLevel1> GetByCriteria(Query query1)
        {
            IList<UserAccessLevel1> userAccessLevels1 = new List<UserAccessLevel1>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserAccessLevel1View.* from UserAccessLevel1View ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  UserAccessLevel1View.Active='True' order BY UserAccessLevel1View.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserAccessLevel1 userAccessLe1 in BuildUserAccessLevel1FromData(table))
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

        #region BuildUserAccessLevel1FromData
        private IList<UserAccessLevel1> BuildUserAccessLevel1FromData(DataTable table)
        {
            IList<UserAccessLevel1> userAccessLevels1 = new List<UserAccessLevel1>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserAccessLevel1 userAccessLevel1 = new UserAccessLevel1()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    userAccessLevels1.Add(userAccessLevel1);
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
