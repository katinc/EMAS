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
    public class AppointmentTypeDataMapper
    {
        private DALHelper dal;
        private AppointmentType appointmentType;

        public AppointmentTypeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.appointmentType = new AppointmentType();
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
                AppointmentType appointmentType = (AppointmentType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", appointmentType.Description, DbType.String);
                dal.CreateParameter("@Active", appointmentType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", appointmentType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into AppointmentTypes(Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                AppointmentType appointmentType = (AppointmentType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", appointmentType.ID, DbType.Int32);
                dal.CreateParameter("@Description", appointmentType.Description, DbType.String);
                dal.CreateParameter("@Active", appointmentType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", appointmentType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update AppointmentTypes Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<AppointmentType> GetAll()
        {
            IList<AppointmentType> appointmentTypes = new List<AppointmentType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Active", appointmentType.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", appointmentType.Archived, DbType.Boolean);
                string query = "select AppointmentTypes.* from AppointmentTypes ";
                query += "WHERE AppointmentTypes.Active=@Active and AppointmentTypes.Archived=@Archived order BY AppointmentTypes.ID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (AppointmentType appointType in BuildAppointmentTypeFromData(table))
                {
                    appointmentTypes.Add(appointType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return appointmentTypes;
        }
        #endregion


        #region DELETE

        public void Delete(object item)
        {
            try
            {
                AppointmentType appointmentType = (AppointmentType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", appointmentType.ID, DbType.Int32);
                dal.CreateParameter("@Archived", appointmentType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update AppointmentTypes Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<AppointmentType> GetByCriteria(Query query1)
        {
            IList<AppointmentType> appointmentTypes = new List<AppointmentType>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Active", appointmentType.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", appointmentType.Archived, DbType.Boolean);

                string query = "select AppointmentTypes.* from AppointmentTypes ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  AppointmentTypes.Active=@Active and AppointmentTypes.Archived=@Archived order BY AppointmentTypes.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (AppointmentType appointType in BuildAppointmentTypeFromData(table))
                {
                    appointmentTypes.Add(appointType);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return appointmentTypes;
        }
        #endregion

        #region BuildAppointmentTypeFromData
        private IList<AppointmentType> BuildAppointmentTypeFromData(DataTable table)
        {
            IList<AppointmentType> appointmentTypes = new List<AppointmentType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    AppointmentType appointmentType = new AppointmentType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    appointmentTypes.Add(appointmentType);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return appointmentTypes;
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
