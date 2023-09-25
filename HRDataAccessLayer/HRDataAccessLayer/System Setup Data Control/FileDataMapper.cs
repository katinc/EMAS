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
    public class FileDataMapper
    {
        private DALHelper dal;
        private FileNumber file;

        public FileDataMapper()
        {
            this.dal = new DALHelper();
            this.file = new FileNumber();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                FileNumber file = (FileNumber)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", file.Description, DbType.String);
                dal.CreateParameter("@FileLocation", file.FileLocation, DbType.String);
                dal.CreateParameter("@InUse", file.InUse, DbType.Boolean);
                dal.CreateParameter("@UserID", file.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into FileNumber (Description,FileLocation,InUse,UserID) Values(@Description,@FileLocation,@InUse,@UserID)");
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
                FileNumber file = (FileNumber)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", file.ID, DbType.String);
                dal.CreateParameter("@Description", file.Description, DbType.String);
                dal.CreateParameter("@InUse", file.InUse, DbType.Boolean);
                dal.CreateParameter("@UserID", file.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", file.Archived, DbType.String);

                dal.ExecuteNonQuery("Update FileNumber Set Description=@Description,InUse=@InUse,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<FileNumber> GetAll()
        {
            IList<FileNumber> files = new List<FileNumber>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", file.Archived, DbType.String);
                string query = "select * from FileNumberView ";
                query += "WHERE FileNumberView.Archived=@Archived order BY FileNumberView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    files.Add(new FileNumber() 
                    { 
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(), 
                        User=new User(){ID=int.Parse(row["UserID"].ToString()),UserName=row["UserName"].ToString()},
                        InUse = bool.Parse(row["InUse"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return files;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                FileNumber file = (FileNumber)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", file.ID, DbType.Int32);
                dal.CreateParameter("@Archived", file.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", file.InUse, DbType.Boolean);
                dal.ExecuteNonQuery("Update FileNumber Set Active=@Active,Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<FileNumber> GetByCriteria(Query query1)
        {
            IList<FileNumber> files = new List<FileNumber>();
            DataTable table = new DataTable();

            //dal.ClearParameters();
            dal.CreateParameter("@Archive", file.Archived, DbType.Boolean);

            string query = "select * from FileNumberView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "where FileNumberView.Archived=@Archive order BY FileNumberView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (FileNumber fil in BuildFileFromData(table))
            {
                files.Add(fil);
            }
            return files;
        }
        #endregion

        #region BuildFileFromData
        private IList<FileNumber> BuildFileFromData(DataTable table)
        {
            IList<FileNumber> files = new List<FileNumber>();
            foreach (DataRow row in table.Rows)
            {
                FileNumber file = new FileNumber()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    FileLocation = row["FileLocation"].ToString(),
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    InUse = bool.Parse(row["InUse"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),   
                };
                files.Add(file);
            }
            return files;
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
