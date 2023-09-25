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
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class ZoneDataMapper
    {
        private DALHelper dal;
        private Zone zone;

        public ZoneDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.zone = new Zone();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(Zone zone)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", zone.Description, DbType.String);
                dal.CreateParameter("@Active", zone.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Zone(Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(Zone zone)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", zone.Description, DbType.String);
                dal.CreateParameter("@Active", zone.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", zone.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Zone Set Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Zone> GetAll()
        {
            IList<Zone> zones = new List<Zone>();
            try
            {
                string query = "Select * from ZoneView where Archived='False' and Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Zone zo in BuildZoneFromData(table))
                {
                    zones.Add(zo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return zones;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update Zone Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Zone> GetByCriteria(Query query1)
        {
            IList<Zone> zones = new List<Zone>();
            try
            {
                DataTable table = new DataTable();

                string query = "Select * from ZoneView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (Zone zone in BuildZoneFromData(table))
                {
                    zones.Add(zone);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return zones;
        }
        #endregion

        #region BuildZoneFromData
        private IList<Zone> BuildZoneFromData(DataTable table)
        {
            IList<Zone> zones = new List<Zone>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Zone zone = new Zone()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    zones.Add(zone);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return zones;
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
