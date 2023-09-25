using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class StaffDocumentsDataMapper
    {
        private DALHelper dal;
        private StaffDocument staffDocument;

        public StaffDocumentsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.staffDocument = new StaffDocument();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<StaffDocument> GetAll()
        {
            IList<StaffDocument> staffDocuments = new List<StaffDocument>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffDocumentView Where StaffDocumentView.Archived='False'");

                foreach (DataRow row in table.Rows)
                {
                    staffDocuments.Add(new StaffDocument() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        DateCreated = DateTime.Parse(row["DateCreated"].ToString()), 
                        Description = row["Description"].ToString(), 
                        DocumentType = row["DocumentType"].ToString(),
                        DocumentContent = row["DocumentContent"] is DBNull ? null : (byte[])row["DocumentContent"],
                        DocumentGroup = row["DocumentGroup"].ToString(), 
                        Path = row["Path"].ToString() ,
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                            Title = new Titles()
                            {
                                ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()),
                                Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString()
                            },
                            //FileNumber = new FileNumber()
                            //{
                            //    ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()),
                            //    Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString()
                            //},
                            GradeCategory = new GradeCategory()
                            {
                                ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                                Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                            },
                            Grade = new EmployeeGrade()
                            {
                                ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                                Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString()
                            },
                            Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString(),
                            MaritalStatus = row["MaritalStatus"] == DBNull.Value ? string.Empty : row["MaritalStatus"].ToString(),
                            Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() },
                            Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() },
                            Specialty = new Specialty() { ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString() },
                        },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDocuments;
        }

        public StaffDocument GetByID(object key)
        {
            IList<StaffDocument> staffDocuments = new List<StaffDocument>();
            StaffDocument staffDocument = new StaffDocument();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffDocumentView Where StaffDocumentView.StaffID=@StaffID and StaffDocumentView.Archived=@Archived");

                foreach (StaffDocument sd in BuildStaffDocumentFromData(table))
                {
                    staffDocument = sd;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDocument;
        }

        #region GetByCriteria
        public IList<StaffDocument> GetByCriteria(Query query1)
        {
            IList<StaffDocument> staffDocuments = new List<StaffDocument>();
            StaffDocument staffDocument = new StaffDocument();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", staffDocument.Archived, DbType.Boolean);
                string query = "select * from StaffDocumentView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffDocumentView.Archived=@Archived order BY StaffDocumentView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffDocument staffd in BuildStaffDocumentFromData(table))
                {
                    staffDocuments.Add(staffd);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDocuments;
        }
        #endregion

        private IList<StaffDocument> BuildStaffDocumentFromData(DataTable table)
        {
            IList<StaffDocument> staffDocuments = new List<StaffDocument>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffDocument staffDocument = new StaffDocument()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        DateCreated = DateTime.Parse(row["DateCreated"].ToString()),
                        Description = row["Description"].ToString(),
                        DocumentGroup = row["DocumentGroup"].ToString(),
                        DocumentContent = row["DocumentContent"] is DBNull ? null : (byte[])row["DocumentContent"],
                        DocumentType = row["DocumentType"].ToString(),
                        Path = row["Path"].ToString(),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                        },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    };
                    staffDocuments.Add(staffDocument);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDocuments;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", "True", DbType.String);

                dal.ExecuteNonQuery("Update StaffDocuments Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
