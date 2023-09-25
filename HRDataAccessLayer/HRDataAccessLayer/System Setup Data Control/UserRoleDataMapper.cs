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
    public class UserRoleDataMapper
    {
        private DALHelper dal;

        public UserRoleDataMapper()
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
            UserRole userRole = (UserRole)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@UserID", userRole.User.ID, DbType.Int32);
                dal.CreateParameter("@UserCategoryAccessLevelsID", userRole.UserCategoryRole.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into UserAccessLevels (UserID,UserCategoryAccessLevelsID) Values(@UserID,@UserCategoryAccessLevelsID)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            UserRole userRole = (UserRole)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", userRole.ID, DbType.Int32);
                dal.CreateParameter("@UserID", userRole.User.ID, DbType.Int32);
                dal.CreateParameter("@UserCategoryAccessLevelsID", userRole.UserCategoryRole.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update UserAccessLevels Set UserID=@UserID,UserCategoryAccessLevelsID=@UserCategoryAccessLevelsID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<UserRole> GetByCriteria(Query query1)
        {
            IList<UserRole> userRoles = new List<UserRole>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserAccessLevelsView.* from UserAccessLevelsView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                table = dal.ExecuteReader(selectStatement);
                foreach (UserRole userRol in BuildUserAccessLevelsFromData(table))
                {
                    userRoles.Add(userRol);
                }
                return userRoles;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userRoles;
        }
        #endregion

        #region GetAll
        public IList<UserRole> GetAll()
        {
            IList<UserRole> userRoles = new List<UserRole>();
            try
            {
                DataTable table = new DataTable();
                table = dal.ExecuteReader("Select UserAccessLevelsView.* from UserAccessLevelsView");
                foreach (UserRole userRol in BuildUserAccessLevelsFromData(table))
                {
                    userRoles.Add(userRol);
                }
                return userRoles;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userRoles;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                UserRole userRole = (UserRole)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", userRole.ID, DbType.Int32);
                dal.ExecuteNonQuery("Delete From UserAccessLevels Where ID = @ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region BuildUserAccessLevelsFromData
        private IList<UserRole> BuildUserAccessLevelsFromData(DataTable table)
        {
            IList<UserRole> userRoles = new List<UserRole>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserRole userRole = new UserRole()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"].ToString()
                        },
                        UserCategoryRole = new UserCategoryRole()
                        {
                            ID = int.Parse(row["UserCategoryID"].ToString()),
                            UserCategory = new UserCategory()
                            {
                                ID = int.Parse(row["UserCategoryID"].ToString()),
                                Description = row["UserCategory"].ToString()
                            },
                            UserAccessLevel1 = new UserAccessLevel1()
                            {
                                ID = int.Parse(row["Level1ID"].ToString()),
                                Description = row["Level1"].ToString()
                            },
                            UserAccessLevel2 = new UserAccessLevel2()
                            {
                                ID = int.Parse(row["Level2ID"].ToString()),
                                Description = row["Level2"].ToString()
                            },
                            UserAccessLevel3 = new UserAccessLevel3()
                            {
                                ID = int.Parse(row["Level3ID"].ToString()),
                                Description = row["Level3"].ToString()
                            },
                            UserAccessLevel4 = new UserAccessLevel4()
                            {
                                ID = int.Parse(row["Level4ID"].ToString()),
                                Description = row["Level4"].ToString()
                            },
                            CanAdd = bool.Parse(row["CanAdd"].ToString()),
                            CanDelete = bool.Parse(row["CanDelete"].ToString()),
                            CanEdit = bool.Parse(row["CanEdit"].ToString()),
                            CanPrint = bool.Parse(row["CanPrint"].ToString()),
                            CanView = bool.Parse(row["CanView"].ToString()),
                        },
                    };
                    userRoles.Add(userRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userRoles;
        }
        #endregion

    }
}
