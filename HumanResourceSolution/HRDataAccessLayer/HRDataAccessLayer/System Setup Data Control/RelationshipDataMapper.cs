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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class RelationshipDataMapper
    {
        private DALHelper dal;
        private Relationship relationship;

        public RelationshipDataMapper()
        {
            this.dal = new DALHelper();
            this.relationship = new Relationship();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Relationship relationship = (Relationship)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", relationship.Description, DbType.String);
                dal.CreateParameter("@Active", relationship.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", relationship.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Relationships (Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                Relationship relationship = (Relationship)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", relationship.ID, DbType.String);
                dal.CreateParameter("@Description", relationship.Description, DbType.String);
                dal.CreateParameter("@Active", relationship.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", relationship.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", relationship.Archived, DbType.String);

                dal.ExecuteNonQuery("Update Relationships Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Relationship> GetAll()
        {
            IList<Relationship> relationships = new List<Relationship>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", relationship.Archived, DbType.String);
                string query = "select * from RelationshipView ";
                query += "WHERE RelationshipView.Archived=@Archived order BY RelationshipView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    relationships.Add(new Relationship() 
                    { 
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(), 
                        User=new User(){ID=int.Parse(row["UserID"].ToString()),UserName=row["UserName"].ToString()},
                        Active = bool.Parse(row["Active"].ToString()) ,
                        Archived = bool.Parse(row["Archived"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                throw ex;
            }

            return relationships;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Relationship relationship = (Relationship)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", relationship.ID, DbType.Int32);
                dal.CreateParameter("@Archived", relationship.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", relationship.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Relationships Set Active=@Active,Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Relationship> GetByCriteria(Query query1)
        {
            IList<Relationship> relationships = new List<Relationship>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", relationship.Archived, DbType.Boolean);

                string query = "select * from RelationshipView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  RelationshipView.Archived=@Archived order BY RelationshipView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Relationship rel in BuildRelationshipFromData(table))
                {
                    relationships.Add(rel);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return relationships;
        }
        #endregion

        #region BuildRelationshipFromData
        private IList<Relationship> BuildRelationshipFromData(DataTable table)
        {
            IList<Relationship> relationships = new List<Relationship>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Relationship relationship = new Relationship()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    relationships.Add(relationship);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return relationships;
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
