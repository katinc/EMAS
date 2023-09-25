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
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class RoleDataMapper
    {
        private DALHelper dal;
        private Role role;

        public RoleDataMapper()
        {
            this.dal = new DALHelper();
            this.role = new Role();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Role role = (Role)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleName", role.RoleName, DbType.String);

                dal.ExecuteNonQuery("Insert Into Roles (RoleName) Values(@RoleName)");
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
                Role role = (Role)item;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", role.RoleID, DbType.String);
                dal.CreateParameter("@RoleName", role.RoleName, DbType.String);
                dal.ExecuteNonQuery("Update Roles Set RoleName=@RoleName Where RoleID =@RoleID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Role> GetAll()
        {
            IList<Role> roles = new List<Role>();
            try
            {
                string query = "select RoleView.* from RoleView where RoleView.Active = 'True'  order by RoleName";
                DataTable table = dal.ExecuteReader(query);
                foreach (Role role in BuildRoleFromData(table))
                {
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return roles;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Role role = (Role)key;
                dal.ClearParameters();
                dal.CreateParameter("@RoleID", role.RoleID, DbType.Int32);
                dal.CreateParameter("@Active", role.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Roles Set Active=@Active Where RoleID =@RoleID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Role> GetByCriteria(Query query1)
        {
            IList<Role> roles = new List<Role>();
            try
            {
                DataTable table = new DataTable();

                string query = "select RoleView.* from RoleView";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  RoleView.Active='True' order by RoleName";
                table = dal.ExecuteReader(selectStatement);
                foreach (Role role in BuildRoleFromData(table))
                {
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return roles;
        }
        #endregion

        #region BuildRoleFromData
        private IList<Role> BuildRoleFromData(DataTable table)
        {
            IList<Role> roles = new List<Role>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Role role = new Role()
                    {
                        RoleID = int.Parse(row["RoleID"].ToString()),
                        RoleName = row["RoleName"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    roles.Add(role);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return roles;
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
