using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class UserToRoleDataMapper
    {
        private DALHelper dal;

        public UserToRoleDataMapper()
        {
            this.dal = new DALHelper();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                UserToRole userToRole = (UserToRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", userToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@UserID", userToRole.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into UsersToRoles (FKRoleID,FKUserID) Values(@RoleID,@UserID)");
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
                UserToRole userToRole = (UserToRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", userToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@UserID", userToRole.User.ID, DbType.Int32);
                dal.CreateParameter("@RoleName", userToRole.Role.RoleName, DbType.String);
                dal.CreateParameter("@UserName", userToRole.User.UserName, DbType.String);
                dal.CreateParameter("@ActionBy", userToRole.User.Name, DbType.String);
                dal.CreateParameter("@Action", "DELETE", DbType.String);
                dal.ExecuteNonQuery("Insert into UserManageRoles_ChangeLog (UserName,RoleName,Action,ActionBy) values (@UserName,@RoleName,@Action,@ActionBy)");
                dal.ExecuteNonQuery("Update UsersToRoles Set FKRoleID=@RoleID,FKUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<UserToRole> GetAll()
        {
            IList<UserToRole> userToRoles = new List<UserToRole>();
            try
            {
                string query = "select UserToRoleView.* from UserToRoleView where Active='True' and AccountBlocked='False' and Archived='False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (UserToRole userToRole in BuildRoleFromData(table))
                {
                    userToRoles.Add(userToRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return userToRoles;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                UserToRole userToRole=(UserToRole) key;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", userToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@UserID", userToRole.User.ID, DbType.Int32);
                dal.CreateParameter("@RoleName", userToRole.Role.RoleName, DbType.String);
                dal.CreateParameter("@UserName", userToRole.User.UserName, DbType.String);
                dal.CreateParameter("@ActionBy", userToRole.User.Name, DbType.String);
                dal.CreateParameter("@Action", "DELETE", DbType.String);
                dal.ExecuteNonQuery("Insert into UserManageRoles_ChangeLog (UserName,RoleName,Action,ActionBy) values (@UserName,@RoleName,@Action,@ActionBy)");
                dal.ExecuteNonQuery("Delete from UsersToRoles Where FKRoleID =@RoleID and FKUserID=@UserID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<UserToRole> GetByCriteria(Query query1)
        {
            IList<UserToRole> userToRoles = new List<UserToRole>();
            try
            {
                DataTable table = new DataTable();

                string query = "select UserToRoleView.* from UserToRoleView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                //selectStatement += "  UserToRoleView.Active='True'";
                table = dal.ExecuteReader(selectStatement);
                foreach (UserToRole userToRole in BuildRoleFromData(table))
                {
                    userToRoles.Add(userToRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userToRoles;
        }
        #endregion

        #region BuildRoleFromData
        private IList<UserToRole> BuildRoleFromData(DataTable table)
        {
            IList<UserToRole> userToRoles = new List<UserToRole>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    UserToRole userToRole = new UserToRole()
                    {
                        Role = new Role()
                        {
                            RoleID = int.Parse(row["RoleID"].ToString()),
                            RoleName = row["RoleName"].ToString(),
                            Active = bool.Parse(row["Active"].ToString()),
                        },
                        User = new User()
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            Name = row["Name"].ToString(),
                            UserName = row["UserName"].ToString(),
                            AccountBlocked = bool.Parse(row["AccountBlocked"].ToString()),
                        },
                    };
                    userToRoles.Add(userToRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return userToRoles;
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
