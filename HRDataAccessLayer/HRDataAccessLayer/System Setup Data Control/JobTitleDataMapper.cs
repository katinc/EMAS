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
    public class JobTitleDataMapper
    {
        private DALHelper dal;
        private JobTitle jobTitle;

        public JobTitleDataMapper()
        {
            this.dal = new DALHelper();
            this.jobTitle = new JobTitle();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                JobTitle jobTitle = (JobTitle)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", jobTitle.Description, DbType.String);
                dal.CreateParameter("@Code", jobTitle.Code, DbType.String);
                dal.CreateParameter("@Active", jobTitle.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", jobTitle.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into StaffJobTitle (Description,Code,Active,UserID) Values(@Description,@Code,@Active,@UserID)");
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
                JobTitle jobTitle = (JobTitle)item;
                dal.ClearParameters();
                dal.ClearParameters();
                dal.CreateParameter("@ID", jobTitle.ID, DbType.String);
                dal.CreateParameter("@Code", jobTitle.Code, DbType.String);
                dal.CreateParameter("@Description", jobTitle.Description, DbType.String);
                dal.CreateParameter("@Active", jobTitle.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", jobTitle.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", jobTitle.Archived, DbType.String);

                dal.ExecuteNonQuery("Update StaffJobTitle Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<JobTitle> GetAll()
        {
            IList<JobTitle> jobTitles = new List<JobTitle>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", jobTitle.Archived, DbType.String);
                string query = "select * from ViewStaffJobTitle ";
                query += "WHERE ViewStaffJobTitle.Archived=@Archived order BY ViewStaffJobTitle.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    jobTitles.Add(new JobTitle() 
                    { 
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(), 
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

            return jobTitles;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                JobTitle jobTitle = (JobTitle)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", jobTitle.ID, DbType.Int32);
                dal.CreateParameter("@Archived", jobTitle.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", jobTitle.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update StaffJobTitle Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<JobTitle> GetByCriteria(Query query1)
        {
            IList<JobTitle> jobTitles = new List<JobTitle>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", jobTitle.Archived, DbType.Boolean);

            string query = "select * from ViewStaffJobTitle ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  ViewStaffJobTitle.Archived=@Archived order BY ViewStaffJobTitle.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (JobTitle jobT in BuildJobTitleFromData(table))
            {
                jobTitles.Add(jobT);
            }
            return jobTitles;
        }
        #endregion

        #region BuildJobTitleFromData
        private IList<JobTitle> BuildJobTitleFromData(DataTable table)
        {
            IList<JobTitle> jobTitles = new List<JobTitle>();
            foreach (DataRow row in table.Rows)
            {
                JobTitle jobTitle = new JobTitle()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Code = row["Code"].ToString(),
                    Description = row["Description"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),   
                };
                jobTitles.Add(jobTitle);
            }
            return jobTitles;
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
