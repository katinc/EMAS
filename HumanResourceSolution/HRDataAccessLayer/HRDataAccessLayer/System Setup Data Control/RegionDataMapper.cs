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

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class RegionDataMapper
    {
        private DALHelper dal;
        private Region region;

        public RegionDataMapper()
        {
            this.dal = new DALHelper();
            this.region = new Region();
        }

        #region SAVE
        public void Save(Region region)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", region.Description, DbType.String);
                dal.CreateParameter("@Active", region.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Insert Into Regions(Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(Region region)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", region.Description, DbType.String);
                dal.CreateParameter("@Active", region.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Regions Set Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Region> GetAll()
        {
            IList<Region> regions = new List<Region>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", region.Archived, DbType.String);
                string query = "select * from Regions ";
                query += "WHERE Archived=@Archived order BY Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    regions.Add(new Region() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Description = row["Description"].ToString(), 
                        Active = bool.Parse(row["Active"].ToString()) ,
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return regions;
        }
        #endregion

        #region Get By ID
        public Region GetByID(object key)
        {
            Region region = new Region();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.String);
                dal.CreateParameter("@Archived", region.Archived, DbType.String);

                string query = "select * from Regions where ID=@ID and Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);
                foreach (Region reg in BuildRegionFromData(table))
                {
                    region = reg;
                }   
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return region;
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

                dal.ExecuteNonQuery("Update Districts Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region BuildRegionFromData
        private IList<Region> BuildRegionFromData(DataTable table)
        {
            IList<Region> regions = new List<Region>();
            foreach (DataRow row in table.Rows)
            {
                Region region = new Region()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    Active = bool.Parse(row["Active"].ToString()),                  
                };
                regions.Add(region);
            }
            return regions;
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
