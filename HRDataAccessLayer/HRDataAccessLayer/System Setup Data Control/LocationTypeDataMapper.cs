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
    public class LocationTypeDataMapper
    {
        private DALHelper dal;
        private LocationType locationType;

        public LocationTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.locationType = new LocationType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                LocationType locationType=(LocationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", locationType.Description, DbType.String);
                dal.CreateParameter("@Active", locationType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into LocationTypes(Description,Active) Values(@Description,@Active)");
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
                LocationType locationType = (LocationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", locationType.ID, DbType.Int32);
                dal.CreateParameter("@Description", locationType.Description, DbType.String);
                dal.CreateParameter("@Active", locationType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update LocationTypes Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<LocationType> GetAll()
        {
            IList<LocationType> locationTypes = new List<LocationType>();
            try
            {
                dal.ClearParameters();
                //dal.CreateParameter("@Archived", locationType.Archived, DbType.String);
                DataTable table = dal.ExecuteReader("select * from LocationTypes order BY Description ASC");
                foreach (DataRow row in table.Rows)
                {
                    locationTypes.Add(new LocationType() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Description = row["Description"].ToString(), 
                        Active = bool.Parse(row["Active"].ToString()),
                        //Archived = bool.Parse(row["Archived"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return locationTypes;
        }
        #endregion

        #region GetByCriteria
        public IList<LocationType> GetByCriteria(Query query1)
        {
            IList<LocationType> locationTypes = new List<LocationType>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from LocationTypes ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (LocationType loc in BuildLocationTypeFromData(table))
                {
                    locationTypes.Add(loc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return locationTypes;
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

                dal.ExecuteNonQuery("Update LocationTypes Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private IList<LocationType> BuildLocationTypeFromData(DataTable table)
        {
            IList<LocationType> locationTypes = new List<LocationType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    LocationType locationType = new LocationType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                    };

                    locationTypes.Add(locationType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return locationTypes;
        }

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
