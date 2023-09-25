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
    public class PromotionTypeDataMapper
    {
        private DALHelper dal;
        private PromotionType promotionType;

        public PromotionTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.promotionType = new PromotionType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                PromotionType promotionType = (PromotionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", promotionType.Description, DbType.String);
                dal.CreateParameter("@Active", promotionType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into PromotionTypes (Description,Active) Values(@Description,@Active)");
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
                PromotionType promotionType = (PromotionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", promotionType.ID, DbType.Int32);
                dal.CreateParameter("@Description", promotionType.Description, DbType.String);
                dal.CreateParameter("@Active", promotionType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update PromotionTypes Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<PromotionType> GetAll()
        {
            IList<PromotionType> promotionTypes = new List<PromotionType>();
            try
            {
                string query = "Select * from PromotionTypes";
                DataTable table = dal.ExecuteReader(query);
                foreach (PromotionType promoT in BuildPromotionTypeFromData(table))
                {
                    promotionTypes.Add(promoT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return promotionTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                PromotionType promotionType = (PromotionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", promotionType.ID, DbType.Int32);
                dal.CreateParameter("@Active", promotionType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update PromotionTypes Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<PromotionType> GetByCriteria(Query query1)
        {
            IList<PromotionType> promotionTypes = new List<PromotionType>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from PromotionTypes ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (PromotionType dis in BuildPromotionTypeFromData(table))
                {
                    promotionTypes.Add(dis);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotionTypes;
        }
        #endregion

        #region BuildPromotionTypeFromData
        private IList<PromotionType> BuildPromotionTypeFromData(DataTable table)
        {
            IList<PromotionType> promotionTypes = new List<PromotionType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    PromotionType promotionType = new PromotionType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    promotionTypes.Add(promotionType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotionTypes;
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
