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
    public class SpecialtyDataMapper
    {
        private DALHelper dal;
        private Specialty specialty;

        public SpecialtyDataMapper()
        {
            this.dal = new DALHelper();
            this.specialty = new Specialty();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Specialty specialty = (Specialty)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", specialty.Description, DbType.String);
                dal.CreateParameter("@Active", specialty.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", specialty.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Specialties (Description,Active,UserID) Values(@Description,@Active,@UserID)");
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
                Specialty specialty = (Specialty)item;
                dal.ClearParameters();
                dal.ClearParameters();
                dal.CreateParameter("@ID", specialty.ID, DbType.String);
                dal.CreateParameter("@Description", specialty.Description, DbType.String);
                dal.CreateParameter("@Active", specialty.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", specialty.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", specialty.Archived, DbType.String);

                dal.ExecuteNonQuery("Update Specialties Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Specialty> GetAll()
        {
            IList<Specialty> specialties = new List<Specialty>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", specialty.Archived, DbType.String);
                string query = "select * from SpecialtyView ";
                query += "WHERE SpecialtyView.Archived=@Archived order BY SpecialtyView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    specialties.Add(new Specialty() 
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

            return specialties;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Specialty specialty = (Specialty)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", specialty.ID, DbType.Int32);
                dal.CreateParameter("@Archived", specialty.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", specialty.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Specialties Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Specialty> GetByCriteria(Query query1)
        {
            IList<Specialty> specialties = new List<Specialty>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", specialty.Archived, DbType.Boolean);

            string query = "select * from SpecialtyView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += " where SpecialtyView.Archived= 'False' order BY SpecialtyView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (Specialty spe in BuildSpecialtyFromData(table))
            {
                specialties.Add(spe);
            }
            return specialties;
        }
        #endregion

        #region BuildSpecialtyFromData
        private IList<Specialty> BuildSpecialtyFromData(DataTable table)
        {
            IList<Specialty> specialties = new List<Specialty>();
            foreach (DataRow row in table.Rows)
            {
                Specialty specialty = new Specialty()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),   
                };
                specialties.Add(specialty);
            }
            return specialties;
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
