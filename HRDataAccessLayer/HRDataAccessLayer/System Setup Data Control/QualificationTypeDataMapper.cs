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
    public class QualificationTypeDataMapper
    {
        private DALHelper dal;
        private QualificationType qualification;

        public QualificationTypeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.qualification = new QualificationType();
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
                QualificationType qualification = (QualificationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", qualification.Description, DbType.String);
                dal.CreateParameter("@Code", qualification.Code, DbType.String);
                dal.CreateParameter("@Active", qualification.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", qualification.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Qualification (Code, Description,Active,UserID) Values(@Code,@Description,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                QualificationType qualification = (QualificationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", qualification.ID, DbType.Int32);            
                dal.CreateParameter("@Description", qualification.Description, DbType.String);
                dal.CreateParameter("@Code", qualification.Code, DbType.String);
                dal.CreateParameter("@Active", qualification.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", qualification.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", qualification.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Qualification Set Code=@Code,Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                QualificationType qualification = (QualificationType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", qualification.ID, DbType.Int32);
                dal.CreateParameter("@Archived", qualification.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", qualification.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Qualification Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<QualificationType> GetAll()
        {
            IList<QualificationType> qualifications = new List<QualificationType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", qualification.Archived, DbType.Boolean);
                string query = "select * from QualificationView ";
                query += "WHERE QualificationView.Archived=@Archived order BY QualificationView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (QualificationType qua in BuildQualificationFromData(table))
                {
                    qualifications.Add(qua);
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return qualifications;
        }
        #endregion

        #region GetByCriteria
        public IList<QualificationType> GetByCriteria(Query query1)
        {
            IList<QualificationType> qualifications = new List<QualificationType>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", qualification.Archived, DbType.Boolean);

            string query = "select * from QualificationView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  QualificationView.Archived=@Archived order BY QualificationView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (QualificationType qua in BuildQualificationFromData(table))
            {
                qualifications.Add(qua);
            }
            return qualifications;
        }
        #endregion

        #region BuildQualificationFromData
        private IList<QualificationType> BuildQualificationFromData(DataTable table)
        {
            IList<QualificationType> qualifications = new List<QualificationType>();
            foreach (DataRow row in table.Rows)
            {
                QualificationType qualification = new QualificationType()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Code = row["Code"].ToString(),
                    Description = row["Description"].ToString(),
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                };
                qualifications.Add(qualification);
            }
            return qualifications;
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
