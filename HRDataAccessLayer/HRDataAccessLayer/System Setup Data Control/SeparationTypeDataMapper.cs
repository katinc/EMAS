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
    public class SeparationTypeDataMapper
    {
        private DALHelper dal;
        private SeparationType separationType;

        public SeparationTypeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.separationType = new SeparationType();
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
                SeparationType separationType = (SeparationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", separationType.Description, DbType.String);
                dal.CreateParameter("@Reinstatement", separationType.Reinstatement, DbType.Boolean);
                dal.CreateParameter("@Active", separationType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into SeparationTypes (Description,Reinstatement,Active) Values(@Description,@Reinstatement,@Active)");
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
                SeparationType separationType = (SeparationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", separationType.ID, DbType.Int32);
                dal.CreateParameter("@Description", separationType.Description, DbType.String);
                dal.CreateParameter("@Reinstatement", separationType.Reinstatement, DbType.Boolean);
                dal.CreateParameter("@Active", separationType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update SeparationTypes Set Description=@Description,Reinstatement=@Reinstatement,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<SeparationType> GetAll()
        {
            IList<SeparationType> separationTypes = new List<SeparationType>();
            try
            {
                string query = "Select * from SeparationTypesView where Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (SeparationType sep in BuildSeparationTypeFromData(table))
                {
                    separationTypes.Add(sep);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return separationTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                SeparationType separationType = (SeparationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", separationType.ID, DbType.Int32);
                dal.CreateParameter("@Active", separationType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update SeparationTypes Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<SeparationType> GetByCriteria(Query query1)
        {
            IList<SeparationType> separationTypes = new List<SeparationType>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from SeparationTypesView  ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Active='True' order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (SeparationType sep in BuildSeparationTypeFromData(table))
                {
                    separationTypes.Add(sep);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return separationTypes;
        }
        #endregion

        #region BuildSeparationTypeFromData
        private IList<SeparationType> BuildSeparationTypeFromData(DataTable table)
        {
            IList<SeparationType> separationTypes = new List<SeparationType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    SeparationType separationType = new SeparationType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Reinstatement = bool.Parse(row["Reinstatement"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    separationTypes.Add(separationType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return separationTypes;
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
