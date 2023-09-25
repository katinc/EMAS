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
    public class RaceDataMapper
    {
        private DALHelper dal;
        private Race race;

        public RaceDataMapper()
        {
            this.dal = new DALHelper();
            this.race = new Race();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Race race = (Race)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", race.Description, DbType.String);
                dal.CreateParameter("@Active", race.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Race (Description,Active) Values(@Description,@Active)");
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
                Race race = (Race)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", race.ID, DbType.Int32);
                dal.CreateParameter("@Description", race.Description, DbType.String);
                dal.CreateParameter("@Active", race.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Race Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Race> GetAll()
        {
            IList<Race> races = new List<Race>();
            try
            {
                string query = "select RaceView.* from RaceView ";
                query += "WHERE RaceView.Active='True' order BY RaceView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Race race in BuildRaceFromData(table))
                {
                    races.Add(race);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return races;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Race race = (Race)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", race.ID, DbType.Int32);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update Race Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Race> GetByCriteria(Query query1)
        {
            IList<Race> races = new List<Race>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                string query = "select RaceView.* from RaceView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  RaceView.Active='True' order BY RaceView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Race race in BuildRaceFromData(table))
                {
                    races.Add(race);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return races;
        }
        #endregion

        #region BuildRaceFromData
        private IList<Race> BuildRaceFromData(DataTable table)
        {
            IList<Race> races = new List<Race>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Race race = new Race()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    races.Add(race);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return races;
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
