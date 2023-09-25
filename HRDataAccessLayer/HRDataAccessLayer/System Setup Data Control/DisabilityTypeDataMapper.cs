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
    public class DisabilityTypeDataMapper
    {
        private DALHelper dal;
        private DisabilityType disabilityType;

        public DisabilityTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.disabilityType = new DisabilityType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                DisabilityType disabilityType = (DisabilityType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", disabilityType.Description, DbType.String);
                dal.CreateParameter("@Active", disabilityType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", disabilityType.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into DisabilityTypes (Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                DisabilityType disabilityType = (DisabilityType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", disabilityType.ID, DbType.Int32);
                dal.CreateParameter("@Description", disabilityType.Description, DbType.String);
                dal.CreateParameter("@Active", disabilityType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", disabilityType.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update DisabilityTypes Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<DisabilityType> GetAll()
        {
            IList<DisabilityType> disabilityTypes = new List<DisabilityType>();
            try
            {
                string query = "Select * from DisabilityTypes";
                DataTable table = dal.ExecuteReader(query);
                foreach (DisabilityType dis in BuildDisabilityTypeFromData(table))
                {
                    disabilityTypes.Add(dis);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return disabilityTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                DisabilityType disabilityType = (DisabilityType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", disabilityType.ID, DbType.Int32);
                dal.CreateParameter("@Active", disabilityType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update DisabilityTypes Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<DisabilityType> GetByCriteria(Query query1)
        {
            IList<DisabilityType> disabilityTypes = new List<DisabilityType>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from DisabilityTypes ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (DisabilityType dis in BuildDisabilityTypeFromData(table))
                {
                    disabilityTypes.Add(dis);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return disabilityTypes;
        }
        #endregion

        #region BuildDisabilityTypeFromData
        private IList<DisabilityType> BuildDisabilityTypeFromData(DataTable table)
        {
            IList<DisabilityType> disabilityTypes = new List<DisabilityType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    DisabilityType disabilityType = new DisabilityType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] is DBNull ? 0 : int.Parse(row["UserID"].ToString()),
                        },
                    };
                    disabilityTypes.Add(disabilityType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return disabilityTypes;
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
