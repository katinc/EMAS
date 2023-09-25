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
    public class DistrictDataMapper
    {
        private DALHelper dal;
        private District district;

        public DistrictDataMapper()
        {
            this.dal = new DALHelper();
            this.district = new District();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                District district=(District)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", district.Code, DbType.String);
                dal.CreateParameter("@Description", district.Description, DbType.String);
                dal.CreateParameter("@RegionID", district.Region.ID, DbType.Int32);
                dal.CreateParameter("@Active", district.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Insert Into Districts(Code,Description,RegionID,Active) Values(@Code,@Description,@RegionID,@Active)");
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
                District district = (District)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", district.Code, DbType.String);
                dal.CreateParameter("@Description", district.Description, DbType.String);
                dal.CreateParameter("@RegionID", district.Region.ID, DbType.Int32);
                dal.CreateParameter("@Active", district.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", district.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Districts Set Code=@Code,RegionID=@RegionID,Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<District> GetAll()
        {
            IList<District> districts = new List<District>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", district.Archived, DbType.String);
                string query = "select Regions.ID as RegionID,Regions.Description as Region,Districts.* from Districts ";
                query += "inner join Regions on Regions.ID=Districts.RegionID ";
                query += "WHERE Districts.Archived=@Archived order BY Districts.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    districts.Add(new District() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Code=row["Code"].ToString(),
                        Description = row["Description"].ToString(), 
                        Region=new Region(){ID=int.Parse(row["RegionID"].ToString()),Description=row["Region"].ToString()},
                        Active = bool.Parse(row["Active"].ToString()) ,
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return districts;
        }
        #endregion

        #region Get By Region
        public IList<District> GetByRegion(object key)
        {
            IList<District> districts = new List<District>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", district.Archived, DbType.String);
                dal.CreateParameter("@Region", key.ToString(), DbType.Int32);

                string query = "select Regions.ID as RegionID,Regions.Description as Region,Districts.* from Districts ";
                query += "inner join Regions on Regions.ID=Districts.RegionID ";
                query += "WHERE Districts.Archived=@Archived and Regions.Description=@Region order BY Districts.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    districts.Add(new District()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Region = new Region() { ID = int.Parse(row["RegionID"].ToString()), Description = row["Region"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return districts;
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
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<District> GetByCriteria(Query query1)
        {
            IList<District> districts = new List<District>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select Regions.ID as RegionID,Regions.Description as Region,Districts.* from Districts ";
                query += "inner join Regions on Regions.ID=Districts.RegionID ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Districts.Archived=@Archived order BY Districts.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (District district in BuildDistrictFromData(table))
                {
                    districts.Add(district);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return districts;
        }
        #endregion

        #region GetByRegion
        public IList<District> GetByRegion(string key)
        {
            IList<District> districts = new List<District>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                dal.CreateParameter("@Region", key.ToString(), DbType.String);

                string query = "select Regions.ID as RegionID,Regions.Description as Region,Districts.* from Districts ";
                query += "inner join Regions on Regions.ID=Districts.RegionID ";
                query += "WHERE Districts.Archived=@Archived and Regions.Description=@Region  order BY Districts.Description ASC";

                table = dal.ExecuteReader(query);
                foreach (District district in BuildDistrictFromData(table))
                {
                    districts.Add(district);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return districts;
        }
        #endregion

        #region BuildDistrictFromData
        private IList<District> BuildDistrictFromData(DataTable table)
        {
            IList<District> districts = new List<District>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    District district = new District()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Region = new Region() { ID = int.Parse(row["RegionID"].ToString()), Description = row["Region"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    districts.Add(district);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return districts;
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
