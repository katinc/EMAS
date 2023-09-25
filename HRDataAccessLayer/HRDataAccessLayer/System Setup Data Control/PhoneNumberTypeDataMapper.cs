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
    public class PhoneNumberTypeDataMapper
    {
        private DALHelper dal;
        private PhoneNumberType phoneNumberType;

        public PhoneNumberTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.phoneNumberType = new PhoneNumberType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                PhoneNumberType phoneNumberType = (PhoneNumberType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", phoneNumberType.Description, DbType.String);
                dal.CreateParameter("@Description", phoneNumberType.Description, DbType.String);
                dal.CreateParameter("@Active", phoneNumberType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into PhoneNumberTypes(Code,Description,Active) Values(@Code,@Description,@Active)");
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
                PhoneNumberType phoneNumberType = (PhoneNumberType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", phoneNumberType.Description, DbType.String);
                dal.CreateParameter("@Description", phoneNumberType.Description, DbType.String);
                dal.CreateParameter("@Active", phoneNumberType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update PhoneNumberTypes Set Code=@Code,Description=@Description,Active=@Active Where Code =@Code");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<PhoneNumberType> GetAll()
        {
            IList<PhoneNumberType> phoneNumberTypes = new List<PhoneNumberType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Active", phoneNumberType.Active, DbType.String);
                string query = "select * from PhoneNumberTypes ";
                query += "WHERE PhoneNumberTypes.Active=@Active order BY PhoneNumberTypes.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (PhoneNumberType phoneNumberT in BuildPhoneNumberTypeFromData(table))
                {
                    phoneNumberTypes.Add(phoneNumberT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return phoneNumberTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                PhoneNumberType phoneNumberType = (PhoneNumberType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", phoneNumberType.Code, DbType.Int32);
                dal.CreateParameter("@Active", phoneNumberType.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update PhoneNumberTypes Set Active=@Active Where Code =@Code");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<PhoneNumberType> GetByCriteria(Query query1)
        {
            IList<PhoneNumberType> phoneNumberTypes = new List<PhoneNumberType>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Active", phoneNumberType.Active, DbType.Boolean);

                string query = "select * from PhoneNumberTypes ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  PhoneNumberTypes.Active=@Active order BY PhoneNumberTypes.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (PhoneNumberType phoneNumberT in BuildPhoneNumberTypeFromData(table))
                {
                    phoneNumberTypes.Add(phoneNumberT);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return phoneNumberTypes;
        }
        #endregion

        #region BuildPhoneNumberTypeFromData
        private IList<PhoneNumberType> BuildPhoneNumberTypeFromData(DataTable table)
        {
            IList<PhoneNumberType> phoneNumberTypes = new List<PhoneNumberType>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    PhoneNumberType phoneNumberType = new PhoneNumberType()
                    {
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    phoneNumberTypes.Add(phoneNumberType);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return phoneNumberTypes;
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
