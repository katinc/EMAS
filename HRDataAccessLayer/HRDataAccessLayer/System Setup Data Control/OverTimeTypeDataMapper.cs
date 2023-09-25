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
    public class OverTimeTypeDataMapper
    {
        private DALHelper dal;
        private OverTimeType overTimeType;

        public OverTimeTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.overTimeType = new OverTimeType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                OverTimeType overTimeType = (OverTimeType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", overTimeType.Description, DbType.String);
                dal.CreateParameter("@Rate", overTimeType.Rate, DbType.Decimal);
                dal.CreateParameter("@Active", overTimeType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into OverTimeTypes (Description,Rate,Active) Values(@Description,@Rate,@Active)");
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
                OverTimeType overTimeType = (OverTimeType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", overTimeType.ID, DbType.Int32);
                dal.CreateParameter("@Description", overTimeType.Description, DbType.String);
                dal.CreateParameter("@Rate", overTimeType.Rate, DbType.Decimal);
                dal.CreateParameter("@Active", overTimeType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update OverTimeTypes Set Description=@Description,Rate=@Rate,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<OverTimeType> GetAll()
        {
            IList<OverTimeType> overTimeTypes = new List<OverTimeType>();
            try
            {
                string query = "select OverTimeTypeView.* from OverTimeTypeView ";
                query += "WHERE OverTimeTypeView.Active='True' order BY OverTimeTypeView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (OverTimeType overTimeTy in BuildOverTimeTypeFromData(table))
                {
                    overTimeTypes.Add(overTimeTy);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return overTimeTypes;
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

                dal.ExecuteNonQuery("Update OverTimeTypes Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<OverTimeType> GetByCriteria(Query query1)
        {
            IList<OverTimeType> overTimeTypes = new List<OverTimeType>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                string query = "select OverTimeTypeView.* from OverTimeTypeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  OverTimeTypeView.Active='True' order BY OverTimeTypeView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (OverTimeType overTimeTy in BuildOverTimeTypeFromData(table))
                {
                    overTimeTypes.Add(overTimeTy);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return overTimeTypes;
        }
        #endregion

        #region BuildOverTimeTypeFromData
        private IList<OverTimeType> BuildOverTimeTypeFromData(DataTable table)
        {
            IList<OverTimeType> overTimeTypes = new List<OverTimeType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    OverTimeType overTimeType = new OverTimeType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Rate = decimal.Parse(row["Rate"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    overTimeTypes.Add(overTimeType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return overTimeTypes;
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
