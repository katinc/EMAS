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
    public class StaffStatusDataMapper
    {
        private DALHelper dal;
        private StaffStatus staffStatus;

        public StaffStatusDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.staffStatus = new StaffStatus();
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
                StaffStatus staffStatus = (StaffStatus)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", staffStatus.Description, DbType.String);
                dal.CreateParameter("@Active", staffStatus.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", staffStatus.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into StaffStatus (Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                StaffStatus staffStatus = (StaffStatus)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", staffStatus.Description, DbType.String);
                dal.CreateParameter("@Active", staffStatus.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", staffStatus.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update StaffStatus Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<StaffStatus> GetAll()
        {
            IList<StaffStatus> staffStatuses = new List<StaffStatus>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Active", staffStatus.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", staffStatus.Archived, DbType.Boolean);
                string query = "select StaffStatus.* from StaffStatus ";
                query += "WHERE StaffStatus.Active=@Active and StaffStatus.Archived=@Archived order BY StaffStatus.ID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (StaffStatus staffS in BuildStaffStatusFromData(table))
                {
                    staffStatuses.Add(staffS);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return staffStatuses;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                StaffStatus staffStatus = (StaffStatus)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffStatus.ID, DbType.Int32);
                dal.CreateParameter("@Archived", staffStatus.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update StaffStatus Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<StaffStatus> GetByCriteria(Query query1)
        {
            IList<StaffStatus> staffStatuses = new List<StaffStatus>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Active", staffStatus.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", staffStatus.Archived, DbType.Boolean);

                string query = "select StaffStatus.* from StaffStatus ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffStatus.Active=@Active and StaffStatus.Archived=@Archived order BY StaffStatus.ID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffStatus staffS in BuildStaffStatusFromData(table))
                {
                    staffStatuses.Add(staffS);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffStatuses;
        }
        #endregion

        #region BuildStaffStatusFromData
        private IList<StaffStatus> BuildStaffStatusFromData(DataTable table)
        {
            IList<StaffStatus> staffStatuses = new List<StaffStatus>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffStatus staffStatus = new StaffStatus()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString())},
                    };
                    staffStatuses.Add(staffStatus);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffStatuses;
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
