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
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class SanctionTypeDataMapper
    {
        private DALHelper dal;
        private SanctionType sanctionType;

        public SanctionTypeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.sanctionType = new SanctionType();
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
                SanctionType sanctionType = (SanctionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", sanctionType.Description, DbType.String);
                dal.CreateParameter("@Code", sanctionType.Code, DbType.String);
                dal.CreateParameter("@Active", sanctionType.Active, DbType.Boolean);
                dal.CreateParameter("@Payment", sanctionType.Payment, DbType.Boolean);
                dal.CreateParameter("@Separated", sanctionType.Separated, DbType.Boolean);
                dal.CreateParameter("@Reinstatement", sanctionType.Reinstatement, DbType.Boolean);
                dal.CreateParameter("@UserID", sanctionType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into SanctionType (Code, Description,Active,Payment,Separated,Reinstatement,UserID) Values(@Code,@Description,@Active,@Payment,@Separated,@Reinstatement,@UserID)");
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
                SanctionType sanctionType = (SanctionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", sanctionType.ID, DbType.Int32);
                dal.CreateParameter("@Description", sanctionType.Description, DbType.String);
                dal.CreateParameter("@Code", sanctionType.Code, DbType.String);
                dal.CreateParameter("@Active", sanctionType.Active, DbType.Boolean);
                dal.CreateParameter("@Payment", sanctionType.Payment, DbType.Boolean);
                dal.CreateParameter("@Separated", sanctionType.Separated, DbType.Boolean);
                dal.CreateParameter("@Reinstatement", sanctionType.Reinstatement, DbType.Boolean);
                dal.CreateParameter("@UserID", sanctionType.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", sanctionType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update SanctionType Set Code=@Code,Description=@Description,Active=@Active,Payment=@Payment,Separated=@Separated,Reinstatement=@Reinstatement,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                SanctionType sanctionType = (SanctionType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", item.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", sanctionType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update SanctionType Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<SanctionType> GetAll()
        {
            IList<SanctionType> sanctionTypes = new List<SanctionType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", sanctionType.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", true, DbType.Boolean);
                string query = "select * from SanctionTypeView ";
                query += "WHERE SanctionTypeView.Archived=@Archived AND SanctionTypeView.Active=@Active order BY SanctionTypeView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (SanctionType san in BuildSanctionTypeFromData(table))
                {
                    sanctionTypes.Add(san);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return sanctionTypes;
        }
        #endregion

        #region GetByCriteria
        public IList<SanctionType> GetByCriteria(Query query1)
        {
            IList<SanctionType> sanctionTypes = new List<SanctionType>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", sanctionType.Archived, DbType.Boolean);
                //dal.CreateParameter("@Active", true, DbType.Boolean);
                string query = "select * from SanctionTypeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  SanctionTypeView.Archived=@Archived order BY SanctionTypeView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (SanctionType san in BuildSanctionTypeFromData(table))
                {
                    sanctionTypes.Add(san);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return sanctionTypes;
        }
        #endregion

        #region BuildSanctionTypeFromData
        private IList<SanctionType> BuildSanctionTypeFromData(DataTable table)
        {
            IList<SanctionType> sanctionTypes = new List<SanctionType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    SanctionType sanctionType = new SanctionType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Payment = bool.Parse(row["Payment"].ToString()),
                        Separated = bool.Parse(row["Separated"].ToString()),
                        Reinstatement = bool.Parse(row["Reinstatement"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    sanctionTypes.Add(sanctionType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return sanctionTypes;
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
