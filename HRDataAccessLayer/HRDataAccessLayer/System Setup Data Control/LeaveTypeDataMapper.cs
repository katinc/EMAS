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
    public class LeaveTypeDataMapper
    {
        private DALHelper dal;
        private LeaveType leaveType;

        public LeaveTypeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.leaveType = new LeaveType();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                LeaveType leaveType = (LeaveType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", leaveType.Description, DbType.String);
                dal.CreateParameter("@MaximumEntitlement", leaveType.MaximumEntitlement, DbType.String);
                dal.CreateParameter("@Active", leaveType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", leaveType.User.ID, DbType.Int32);
                dal.CreateParameter("@CountHolidays", leaveType.CountHolidays, DbType.Boolean);
                dal.CreateParameter("@CountWeekends", leaveType.CountWeekends, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into LeaveTypes (Description,MaximumEntitlement,Active,UserID,CountHolidays,CountWeekends) " +
                                                    "Values(@Description,@MaximumEntitlement,@Active,@UserID,@CountHolidays,@CountWeekends)");
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
                LeaveType leaveType = (LeaveType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", leaveType.ID, DbType.Int32);
                dal.CreateParameter("@Description", leaveType.Description, DbType.String);
                dal.CreateParameter("@MaximumEntitlement", leaveType.MaximumEntitlement, DbType.String);
                dal.CreateParameter("@Active", leaveType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", leaveType.User.ID, DbType.Int32);
                dal.CreateParameter("@CountHolidays", leaveType.CountHolidays, DbType.Boolean);
                dal.CreateParameter("@CountWeekends", leaveType.CountWeekends, DbType.Boolean);

                dal.ExecuteNonQuery("Update LeaveTypes Set Description=@Description,MaximumEntitlement=@MaximumEntitlement,Active=@Active,UserID=@UserID,CountHolidays = @CountHolidays, CountWeekends=@CountWeekends  Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<LeaveType> GetAll()
        {
            IList<LeaveType> leaveTypes = new List<LeaveType>();
            try
            {
                string query = "select * from LeaveTypeView ";
                query += " Where Archived='False' order BY LeaveTypeView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (LeaveType leaveTyp in BuildLeaveTypeFromData(table))
                {
                    leaveTypes.Add(leaveTyp);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return leaveTypes;
        }
        #endregion

        #region Get By ID
        public LeaveType GetByID(object key)
        {
            LeaveType leaveType = new LeaveType();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString().Trim(), DbType.String);
                string query = "select * from LeaveTypeView ";
                query += "WHERE LeaveTypeView.ID=@ID order BY LeaveTypeView.Description ASC";
                table = dal.ExecuteReader(query);
                foreach (LeaveType leaveTy in BuildLeaveTypeFromData(table))
                {
                    leaveType = leaveTy;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaveType;
        }
        #endregion

        #region Get By Description
        public LeaveType GetByDescription(object key)
        {
            LeaveType leaveType = new LeaveType();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Description", key.ToString().Trim(), DbType.String);
                string query = "select DISTINCT * from LeaveTypeView ";
                query += "WHERE LeaveTypeView.Description=@Description order BY LeaveTypeView.Description ASC";
                table = dal.ExecuteReader(query);
                foreach (LeaveType leaveTy in BuildLeaveTypeFromData(table))
                {
                    leaveType = leaveTy;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaveType;
        }
        #endregion

        #region GetByCriteria
        public IList<LeaveType> GetByCriteria(Query query1)
        {
            IList<LeaveType> leaveTypes = new List<LeaveType>();
            try
            {
                DataTable table = new DataTable();

                string query = "select * from LeaveTypeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " order BY LeaveTypeView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (LeaveType leaveTyp in BuildLeaveTypeFromData(table))
                {
                    leaveTypes.Add(leaveTyp);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaveTypes;
        }
        #endregion

        #region BuildLeaveTypeFromData
        private IList<LeaveType> BuildLeaveTypeFromData(DataTable table)
        {
            IList<LeaveType> leaveTypes = new List<LeaveType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    LeaveType leaveType = new LeaveType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        MaximumEntitlement = int.Parse(row["MaximumEntitlement"].ToString()),
                        DateModified = DateTime.Parse(row["DateModified"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        CountHolidays = bool.Parse(row["CountHolidays"].ToString()),
                        CountWeekends = bool.Parse(row["CountWeekends"].ToString()),
                    };
                    leaveTypes.Add(leaveType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaveTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                LeaveType leaveType = (LeaveType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", leaveType.ID, DbType.Int32);
                dal.CreateParameter("@Active", leaveType.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update LeaveTypes Set Active=@Active Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
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
