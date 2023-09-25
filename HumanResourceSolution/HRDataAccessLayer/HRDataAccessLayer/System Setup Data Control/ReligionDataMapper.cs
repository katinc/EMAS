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
    public class ReligionDataMapper
    {
        private DALHelper dal;
        private Religion religion;

        public ReligionDataMapper()
        {
            this.dal = new DALHelper();
            this.religion = new Religion();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Religion religion = (Religion)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", religion.Description, DbType.String);
                dal.CreateParameter("@Active", religion.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", religion.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Religions (Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                dal.ClearParameters();
                dal.CreateParameter("@ID", relationship.ID, DbType.String);
                dal.CreateParameter("@Description", relationship.Description, DbType.String);
                dal.CreateParameter("@Active", relationship.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", relationship.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", relationship.Archived, DbType.String);

                dal.ExecuteNonQuery("Update Religions Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Religion> GetAll()
        {
            IList<Religion> religions = new List<Religion>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", religion.Archived, DbType.String);
                string query = "select * from ReligionView ";
                query += "WHERE ReligionView.Archived=@Archived order BY ReligionView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    religions.Add(new Religion() 
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
            }

            return religions;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Religion religion = (Religion)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", religion.ID, DbType.Int32);
                dal.CreateParameter("@Archived", religion.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", religion.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Religions Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Religion> GetByCriteria(Query query1)
        {
            IList<Religion> religions = new List<Religion>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", religion.Archived, DbType.Boolean);

            string query = "select * from ReligionView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  ReligionView.Archived=@Archived order BY ReligionView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (Religion rel in BuildReligionFromData(table))
            {
                religions.Add(rel);
            }
            return religions;
        }
        #endregion

        #region BuildReligionFromData
        private IList<Religion> BuildReligionFromData(DataTable table)
        {
            IList<Religion> religions = new List<Religion>();
            foreach (DataRow row in table.Rows)
            {
                Religion religion = new Religion()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),   
                };
                religions.Add(religion);
            }
            return religions;
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
