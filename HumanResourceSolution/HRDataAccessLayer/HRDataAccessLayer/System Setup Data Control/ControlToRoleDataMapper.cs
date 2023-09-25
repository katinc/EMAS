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
    public class ControlToRoleDataMapper
    {
        private DALHelper dal;

        public ControlToRoleDataMapper()
        {
            this.dal = new DALHelper();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                ControlToRole controlToRole = (ControlToRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", controlToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@PageID", controlToRole.Controls.Page, DbType.String);
                dal.CreateParameter("@ControlID", controlToRole.Controls.ControlID, DbType.String);
                dal.CreateParameter("@Active", controlToRole.Active, DbType.Boolean);
                dal.CreateParameter("@Invisible", controlToRole.Invisible, DbType.Int32);
                dal.CreateParameter("@Disabled", controlToRole.Disabled, DbType.Int32);
                dal.CreateParameter("@UserID", controlToRole.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into ControlsToRoles (FKRole,FKPage,FKControlID,Invisible,Disabled,UserID,Active) Values(@RoleID,@PageID,@ControlID,@Invisible,@Disabled,@UserID,@Active)");
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
                ControlToRole controlToRole = (ControlToRole)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", controlToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@PageID", controlToRole.Controls.Page, DbType.String);
                dal.CreateParameter("@ControlID", controlToRole.Controls .ControlID, DbType.String);
                dal.CreateParameter("@Active", controlToRole.Active, DbType.Boolean);
                dal.CreateParameter("@Invisible", controlToRole.Invisible, DbType.Int32);
                dal.CreateParameter("@Disabled", controlToRole.Disabled, DbType.Int32);
                dal.CreateParameter("@UserID", controlToRole.User.ID, DbType.Int32);
                dal.CreateParameter("@RoleName", controlToRole.Role.RoleName, DbType.String);
                dal.CreateParameter("@ActionBy", controlToRole.User.Name, DbType.String);
                dal.CreateParameter("@Action", "DELETE", DbType.String);
                dal.ExecuteNonQuery("Insert into UserPermissions_ChangeLog (Page,Role,Control,Disabled,Invisible,Active,Action,ActionBy) values (@PageID,@RoleName,@ControlID,@Disabled,@Invisible,@Active,@Action,@ActionBy)");
                dal.ExecuteNonQuery("Update ControlsToRoles Set FKRole=@RoleID,FKPage=@PageID,FKControlID=@ControlID,Invisible=@Invisible,Disabled=@Disabled,UserID=@UserID,Active=@Active Where FKRole=@RoleID and FKPage=@PageID and FKControlID=@ControlID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<ControlToRole> GetAll()
        {
            IList<ControlToRole> controlToRoles = new List<ControlToRole>();
            try
            {
                string query = "select ControlToRoleView.* from ControlToRoleView where Active='True' and RoleActive='True' and ControlActive='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (ControlToRole controlToRole in BuildRoleFromData(table))
                {
                    controlToRoles.Add(controlToRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return controlToRoles;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                ControlToRole controlToRole = (ControlToRole)key;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", controlToRole.Role.RoleID, DbType.Int32);
                dal.CreateParameter("@PageID", controlToRole.Controls.Page, DbType.String);
                dal.CreateParameter("@ControlID", controlToRole.Controls.ControlID, DbType.String);
                dal.CreateParameter("@RoleName", controlToRole.Role.RoleName, DbType.String);
                dal.CreateParameter("@Disabled", controlToRole.Disabled, DbType.Int32);
                dal.CreateParameter("@Invisible", controlToRole.Invisible, DbType.Int32);
                dal.CreateParameter("@Active", controlToRole.Active, DbType.Boolean);
                dal.CreateParameter("@ActionBy", controlToRole.User.Name, DbType.String);
                dal.CreateParameter("@Action", "DELETE", DbType.String);
                dal.ExecuteNonQuery("Insert into UserPermissions_ChangeLog (Page,Role,Control,Disabled,Invisible,Active,Action,ActionBy) values (@PageID,@RoleName,@ControlID,@Disabled,@Invisible,@Active,@Action,@ActionBy)");
                dal.ExecuteNonQuery("Delete from ControlsToRoles Where FKRole=@RoleID and FKPage=@PageID and FKControlID=@ControlID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<ControlToRole> GetByCriteria(Query query1)
        {
            IList<ControlToRole> controlToRoles = new List<ControlToRole>();
            try
            {
                DataTable table = new DataTable();

                string query = "select ControlToRoleView.* from ControlToRoleView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                //selectStatement += "  ControlToRoleView.Active='True'";
                table = dal.ExecuteReader(selectStatement);
                foreach (ControlToRole controlToRole in BuildRoleFromData(table))
                {
                    controlToRoles.Add(controlToRole);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return controlToRoles;
        }
        #endregion

        #region BuildRoleFromData
        private IList<ControlToRole> BuildRoleFromData(DataTable table)
        {
            IList<ControlToRole> controlToRoles = new List<ControlToRole>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    ControlToRole controlToRole = new ControlToRole();
                    controlToRole.Role = new Role()
                    {
                        RoleID = int.Parse(row["RoleID"].ToString()),
                        RoleName = row["RoleName"].ToString(),
                        Active = bool.Parse(row["RoleActive"].ToString()),
                    };
                    controlToRole.Controls = new Controls()
                    {
                        Page = row["Page"].ToString(),
                        ControlID = row["ControlID"].ToString(),
                        Active = bool.Parse(row["ControlActive"].ToString()),
                    };
                    controlToRole.Invisible = int.Parse(row["Invisible"].ToString());
                    controlToRole.Disabled = int.Parse(row["Disabled"].ToString());
                    controlToRole.Active = bool.Parse(row["Active"].ToString());
                    controlToRole.User = new User()
                    {
                        ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString()),
                        Name = row["Name"] == DBNull.Value ? null : row["Name"].ToString(),
                        UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString(),
                    };
                    controlToRoles.Add(controlToRole);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return controlToRoles;
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
