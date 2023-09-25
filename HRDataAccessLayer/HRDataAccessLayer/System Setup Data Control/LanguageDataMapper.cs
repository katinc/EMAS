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
    public class LanguageDataMapper
    {
        private DALHelper dal;
        private Language language;

        public LanguageDataMapper()
        {
            this.dal = new DALHelper();
            this.language = new Language();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Language language = (Language)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", language.Description, DbType.String);
                dal.CreateParameter("@Active", language.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Languages (Description,Active) Values(@Description,@Active)");
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
                Language language = (Language)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", language.ID, DbType.Int32);
                dal.CreateParameter("@Description", language.Description, DbType.String);
                dal.CreateParameter("@Active", language.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Languages Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Language> GetAll()
        {
            IList<Language> languages = new List<Language>();
            try
            {
                string query = "Select * from Languages  where Active='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Language lan in BuildLanguageFromData(table))
                {
                    languages.Add(lan);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return languages;
        }
        #endregion

        #region GetByCriteria
        public IList<Language> GetByCriteria(Query query1)
        {
            IList<Language> languages = new List<Language>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from Languages ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "   Active='True' order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (Language lan in BuildLanguageFromData(table))
                {
                    languages.Add(lan);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return languages;
        }
        #endregion

        #region BuildLanguageFromData
        private IList<Language> BuildLanguageFromData(DataTable table)
        {
            IList<Language> languages = new List<Language>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Language language = new Language()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    languages.Add(language);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return languages;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Language language = (Language)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", language.ID, DbType.Int32);
                dal.CreateParameter("@Active", language.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Languages Set Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
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
