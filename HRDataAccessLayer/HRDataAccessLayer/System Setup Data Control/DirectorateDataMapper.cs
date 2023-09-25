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
   public class DirectorateDataMapper
    {
        private DALHelper dal;
        private Directorate  directorate;

        public DirectorateDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.directorate = new Directorate ();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(Directorate d)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", d.Description, DbType.String);
                dal.CreateParameter("@Active", d.IsActive, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Directorates (Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(Directorate d)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", d.Description, DbType.String);
                dal.CreateParameter("@Active", d.IsActive, DbType.Boolean);


                dal.ExecuteNonQuery("Update Directorates Set Description=@Description,Active=@Active Where ID =@ID ");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Directorate> GetAll()
        {
            IList<Directorate> dirlist = new List<Directorate>();
            try
            {
                string query = "Select * from Directorates where Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Directorate  d in BuildDIrectorateFromData(table))
                {
                    dirlist.Add(d);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return dirlist;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32); 

                dal.ExecuteNonQuery("delete from Directorates Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Directorate> GetByCriteria(Query query1)
        {
            IList<Directorate> dirlist = new List<Directorate>();
            try
            {
                DataTable table = new DataTable();

                string query = "Select * from Directorates ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  order BY Directorate ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (Directorate d in BuildDIrectorateFromData(table))
                {
                    dirlist.Add(d);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return dirlist;
        }

        #endregion

        #region BuildDIrectorateFromData
        private IList<Directorate> BuildDIrectorateFromData(DataTable table)
        {
            IList<Directorate> d = new List<Directorate>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Directorate dir = new Directorate()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        IsActive = bool.Parse(row["Active"].ToString()),
                    };
                    d.Add(dir );
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return d;
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
