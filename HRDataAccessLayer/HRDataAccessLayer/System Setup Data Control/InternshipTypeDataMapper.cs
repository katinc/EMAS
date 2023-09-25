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

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class InternshipTypeDataMapper
    {
        private DALHelper dal;
        private InternshipType internshipType;

        public InternshipTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.internshipType = new InternshipType();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                InternshipType internshipType = (InternshipType)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", internshipType.Description, DbType.String);
                dal.CreateParameter("@Active", internshipType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", internshipType.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into InternshipTypes(Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                InternshipType internshipType = (InternshipType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", internshipType.Description, DbType.Int32);
                dal.CreateParameter("@Description", internshipType.Description, DbType.String);
                dal.CreateParameter("@Active", internshipType.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", internshipType.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", internshipType.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update InternshipTypes Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<InternshipType> GetAll()
        {
            IList<InternshipType> internshipTypes = new List<InternshipType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", internshipType.Archived, DbType.String);
                string query = "select * from InternshipTypeView ";
                query += "WHERE InternshipTypeView.Archived=@Archived order BY InternshipTypeView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    internshipTypes.Add(new InternshipType() 
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

            return internshipTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {           
            try
            {
                InternshipType internshipType = (InternshipType)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", internshipType.ID, DbType.Int32);
                dal.CreateParameter("@Archived", internshipType.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", internshipType.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update InternshipTypes Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<InternshipType> GetByCriteria(Query query1)
        {
            IList<InternshipType> internshipTypes = new List<InternshipType>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", false, DbType.Boolean);

            string query = "select * from InternshipTypeView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  InternshipTypeView.Archived=@Archived order BY InternshipTypeView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (InternshipType internshipT in BuildInternshipTypeFromData(table))
            {
                internshipTypes.Add(internshipT);
            }
            return internshipTypes;
        }
        #endregion

        #region BuildInternshipTypeFromData
        private IList<InternshipType> BuildInternshipTypeFromData(DataTable table)
        {
            IList<InternshipType> internshipTypes = new List<InternshipType>();
            foreach (DataRow row in table.Rows)
            {
                InternshipType internshipType = new InternshipType()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()), 
                };
                internshipTypes.Add(internshipType);
            }
            return internshipTypes;
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
