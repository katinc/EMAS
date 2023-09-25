using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;


namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class TownsDataMapper
    {

        DALHelper dal;
        private Town town;

        public TownsDataMapper()
        {
            this.dal = new DALHelper();
            this.town = new Town();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Town town = (Town)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", town.Description, DbType.String);
                dal.CreateParameter("@Code", town.Code, DbType.String);
                dal.CreateParameter("@DistrictID", town.District.ID, DbType.Int32);
                dal.CreateParameter("@Active", town.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Towns (Code,Description,DistrictID,Active) Values(@Code,@Description,@DistrictID,@Active)");
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
                Town town = (Town)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", town.ID, DbType.Int32);
                dal.CreateParameter("@Description", town.Description, DbType.String);
                dal.CreateParameter("@Code", town.Code, DbType.String);
                dal.CreateParameter("@DistrictID", town.District.ID, DbType.Int32);
                dal.CreateParameter("@Active", town.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Towns Set Code=@Code,Description=@Description,DistrictID=@District,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<Town> GetAll()
        {
            IList<Town> towns = new List<Town>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select TownView.* from TownView ";
                query += "WHERE TownView.Archived=@Archived";
                query += "  order BY TownView.Description ASC";

                DataTable table = dal.ExecuteReader(query);
                foreach (Town tow in BuildTownFromData(table))
                {
                    towns.Add(tow);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return towns;
        }
        #endregion

        #region GetByCriteria
        public IList<Town> GetByCriteria(Query query1)
        {
            IList<Town> towns = new List<Town>();
            try
            {                
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select TownView.* from TownView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "TownView.Archived=@Archived order BY TownView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Town town in BuildTownFromData(table))
                {
                    towns.Add(town);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return towns;
        }
        #endregion

        #region GetByID
        public Town GetByID(object key)
        {
            Town town = new Town();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString(), DbType.String);

                string query = "Select * from TownView where ID=@ID";
                DataTable table = dal.ExecuteReader(query);

                foreach (Town tn in BuildTownFromData(table))
                {
                    town = tn;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return town;
        }
        #endregion

        #region BuildTownFromData
        private IList<Town> BuildTownFromData(DataTable table)
        {
            IList<Town> towns = new List<Town>();
            foreach (DataRow row in table.Rows)
            {
                Town town = new Town()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    Code = row["Code"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    District = new District() { ID = int.Parse(row["DistrictID"].ToString()), Description = row["District"].ToString() },
                    DateAndTimeGenerated = DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),
                    Active=bool.Parse(row["Active"].ToString()),
                };
                
                towns.Add(town);
            }
            return towns;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                Town town = (Town)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", town.ID, DbType.Int32);
                dal.CreateParameter("@Archived", town.Archived, DbType.String);

                dal.ExecuteNonQuery("Update Towns Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
