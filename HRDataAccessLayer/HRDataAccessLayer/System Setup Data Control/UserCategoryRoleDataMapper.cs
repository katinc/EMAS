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
    public class UserCategoryRoleDataMapper
    {
        private DALHelper dal;

        public UserCategoryRoleDataMapper()
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
                UserCategoryRole userCategoryRole = (UserCategoryRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@UserCategoryID", userCategoryRole.UserCategory.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel1ID", userCategoryRole.UserAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel2ID", userCategoryRole.UserAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel3ID", userCategoryRole.UserAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel4ID", userCategoryRole.UserAccessLevel4.ID, DbType.Int32);
                dal.CreateParameter("@CanView", userCategoryRole.CanView, DbType.Boolean);
                dal.CreateParameter("@CanDelete", userCategoryRole.CanDelete, DbType.Boolean);
                dal.CreateParameter("@CanEdit", userCategoryRole.CanEdit, DbType.Boolean);
                dal.CreateParameter("@CanAdd", userCategoryRole.CanAdd, DbType.Boolean);
                dal.CreateParameter("@CanPrint", userCategoryRole.CanPrint, DbType.Boolean);
                dal.ExecuteNonQuery("Insert Into UserCategoryAccessLevels (UserCategoryID,AccessLevel1ID,AccessLevel2ID,CanView,CanDelete,CanEdit,CanAdd,CanPrint) Values(@UserCategoryID,@AccessLevel1ID,@AccessLevel2ID,@CanView,@CanDelete,@CanEdit,@CanAdd,@CanPrint)");
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
            try
            {
                UserCategoryRole userCategoryRole = (UserCategoryRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", userCategoryRole.ID, DbType.Int32);
                dal.CreateParameter("@UserCategoryID", userCategoryRole.UserCategory.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel1ID", userCategoryRole.UserAccessLevel1.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel2ID", userCategoryRole.UserAccessLevel2.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel3ID", userCategoryRole.UserAccessLevel3.ID, DbType.Int32);
                dal.CreateParameter("@UserAccessLevel4ID", userCategoryRole.UserAccessLevel4.ID, DbType.Int32);
                dal.CreateParameter("@CanView", userCategoryRole.CanView, DbType.Boolean);
                dal.CreateParameter("@CanDelete", userCategoryRole.CanDelete, DbType.Boolean);
                dal.CreateParameter("@CanEdit", userCategoryRole.CanEdit, DbType.Boolean);
                dal.CreateParameter("@CanAdd", userCategoryRole.CanAdd, DbType.Boolean);
                dal.CreateParameter("@CanPrint", userCategoryRole.CanPrint, DbType.Boolean);
                dal.ExecuteNonQuery("Update UserCategoryAccessLevels Set UserCategoryID=@UserCategoryID,UserAccessLevel1ID=@UserAccessLevel1ID,UserAccessLevel2ID=@UserAccessLevel2ID,UserAccessLevel3ID=@UserAccessLevel3ID,UserAccessLevel4ID=@UserAccessLevel4ID,CanView=@CanView,CanDelete=@CanDelete,CanEdit=@CanEdit,CanAdd=@CanAdd,CanPrint=@CanPrint Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<UserCategoryRole> GetByCriteria(Query query1)
        {
            IList<UserCategoryRole> userCategoryRoles = new List<UserCategoryRole>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserCategoryAccessLevelsView.* from UserCategoryAccessLevelsView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                table = dal.ExecuteReader(selectStatement);
                foreach (UserCategoryRole userCategoryRol in BuildUserCategoryAccessLevelsFromData(table))
                {
                    userCategoryRoles.Add(userCategoryRol);
                }
                return userCategoryRoles;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userCategoryRoles;
        }
        #endregion

        #region GetAll
        public IList<UserCategoryRole> GetAll()
        {
            IList<UserCategoryRole> userCategoryRoles = new List<UserCategoryRole>();
            try
            {
                DataTable table = new DataTable();
                table = dal.ExecuteReader("Select UserCategoryAccessLevelsView.* from UserCategoryAccessLevelsView");
                foreach (UserCategoryRole userCategoryRol in BuildUserCategoryAccessLevelsFromData(table))
                {
                    userCategoryRoles.Add(userCategoryRol);
                }
                return userCategoryRoles;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userCategoryRoles;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                UserCategoryRole userCategoryRole = (UserCategoryRole)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", userCategoryRole.ID, DbType.Int32);
                dal.ExecuteNonQuery("Delete From UserCategoryAccessLevels Where ID = @ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region BuildUserCategoryAccessLevelsFromData
        private IList<UserCategoryRole> BuildUserCategoryAccessLevelsFromData(DataTable table)
        {
            IList<UserCategoryRole> userCategoryRoles = new List<UserCategoryRole>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserCategoryRole userRole = new UserCategoryRole()
                    {
                        ID = int.Parse(row["ID"].ToString()),
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
                    };
                    userCategoryRoles.Add(userRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userCategoryRoles;
        }
        #endregion

    }
}
