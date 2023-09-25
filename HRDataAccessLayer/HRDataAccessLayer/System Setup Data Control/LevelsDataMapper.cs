using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class LevelsDataMapper
    {
        private DALHelper dal;

        public LevelsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region OpenConnection
        private void OpenConnection()
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

        #region CloseConnection
        private void CloseConnection()
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

        #region GetAll
        public IList<Level> GetAll()
        {
            IList<Level> levels = new List<Level>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from SalaryLevelView where Archived='False' and Active='True'");
                foreach (Level lev in BuildLevelFromData(table))
                {
                    levels.Add(lev);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return levels;
        }
        #endregion

        #region GetByCriteria
        public IList<Level> GetByCriteria(Query query1)
        {
            IList<Level> levels = new List<Level>();
            Level level = new Level();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from SalaryLevelView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' and Active='True' Order By Description";
                table = dal.ExecuteReader(selectStatement);
                foreach (Level lev in BuildLevelFromData(table))
                {
                    levels.Add(lev);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return levels;
        }
        #endregion

        #region BuildLevelFromData
        private IList<Level> BuildLevelFromData(DataTable table)
        {
            IList<Level> levels = new List<Level>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Level level = new Level()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString()
                        },
                    };

                    levels.Add(level);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return levels;
        }
        #endregion
    }
}
