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
    public class LicenceTypeDataMapper
    {
        private DALHelper dal;
        private LicenceType licenceType;

        public LicenceTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.licenceType = new LicenceType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                LicenceType licenceType = (LicenceType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", licenceType.Description, DbType.String);
                dal.CreateParameter("@Active", licenceType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into LicenceTypes (Description,Active) Values(@Description,@Active)");
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
                LicenceType licenceType = (LicenceType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", licenceType.ID, DbType.Int32);
                dal.CreateParameter("@Description", licenceType.Description, DbType.String);
                dal.CreateParameter("@Active", licenceType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update LicenceTypes Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<LicenceType> GetAll()
        {
            IList<LicenceType> licenceTypes = new List<LicenceType>();
            try
            {
                string query = "Select * from LicenceTypes";
                DataTable table = dal.ExecuteReader(query);
                foreach (LicenceType lic in BuildLicenceTypeFromData(table))
                {
                    licenceTypes.Add(lic);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return licenceTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                LicenceType licenceType = (LicenceType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", licenceType.ID, DbType.Int32);
                dal.CreateParameter("@Active", licenceType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update LicenceTypes Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<LicenceType> GetByCriteria(Query query1)
        {
            IList<LicenceType> licenceTypes = new List<LicenceType>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from LicenceTypes ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (LicenceType lic in BuildLicenceTypeFromData(table))
                {
                    licenceTypes.Add(lic);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return licenceTypes;
        }
        #endregion

        #region BuildLicenceTypeFromData
        private IList<LicenceType> BuildLicenceTypeFromData(DataTable table)
        {
            IList<LicenceType> licenceTypes = new List<LicenceType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    LicenceType licenceType = new LicenceType()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    licenceTypes.Add(licenceType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return licenceTypes;
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
