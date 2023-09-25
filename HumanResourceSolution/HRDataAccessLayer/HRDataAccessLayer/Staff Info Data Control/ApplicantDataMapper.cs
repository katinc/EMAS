using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class ApplicantDataMapper
    {
        private DALHelper dal;
        private Applicant applicant;

        public ApplicantDataMapper()
        {
            this.dal = new DALHelper();
            this.applicant = new Applicant();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Applicant applicant = (Applicant)item;
                dal.BeginTransaction();
                dal.ClearParameters();
                dal.CreateParameter("@Surname", applicant.Surname, DbType.String);
                dal.CreateParameter("@MiddleName", applicant.MiddleName, DbType.String);
                dal.CreateParameter("@FirstName", applicant.FirstName, DbType.String);
                dal.CreateParameter("@ContactNo", applicant.ContactNo, DbType.String);
                dal.CreateParameter("@EmailAddress", applicant.EmailAddress, DbType.String);
                dal.CreateParameter("@VacancyID", applicant.Vacancy.ID, DbType.Int32);
                dal.CreateParameter("@ContactAddress", applicant.ContactAddress, DbType.String);
                dal.CreateParameter("@ApplicationDate", applicant.ApplicationDate, DbType.DateTime);
                dal.CreateParameter("@UserID", applicant.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into Applicants(Surname,MiddleName,FirstName,VacancyID,ContactNo,EmailAddress,ContactAddress,ApplicationDate,UserID) Values(@Surname,@MiddleName,@FirstName,@VacancyID,@ContactNo,@EmailAddress,@ContactAddress,@ApplicationDate,@UserID)");

                applicant.ID = int.Parse(dal.ExecuteScalar("Select Max(ID) from Applicants").ToString());
                foreach (StaffDocument document in applicant.Documents)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@ApplicantID", applicant.ID, DbType.Int32);
                    dal.CreateParameter("@DateCreated", document.DateCreated, DbType.DateTime);
                    dal.CreateParameter("@Description", document.Description, DbType.String);
                    dal.CreateParameter("@DocumentGroup", document.DocumentGroup, DbType.String);
                    dal.CreateParameter("@DocumentContent", document.DocumentContent, DbType.Binary);
                    dal.CreateParameter("@Path", document.Path, DbType.String);
                    dal.CreateParameter("@UserID", document.User.ID, DbType.Int32);
                    dal.ExecuteNonQuery("Insert Into ApplicantDocuments(ApplicantID,DateCreated,Description,DocumentGroup,DocumentContent,Path,UserID) Values(@ApplicantID,@DateCreated,@Description,@DocumentGroup,@DocumentContent,@Path,@UserID)");
                }
                dal.CommitTransaction();
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Applicant applicant = (Applicant)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", applicant.ID, DbType.Int32);
                dal.CreateParameter("@Surname", applicant.Surname, DbType.String);
                dal.CreateParameter("@MiddleName", applicant.MiddleName, DbType.String);
                dal.CreateParameter("@FirstName", applicant.FirstName, DbType.String);
                dal.CreateParameter("@ContactNo", applicant.ContactNo, DbType.String);
                dal.CreateParameter("@EmailAddress", applicant.EmailAddress, DbType.String);
                dal.CreateParameter("@VacancyID", applicant.Vacancy.ID, DbType.Int32);
                dal.CreateParameter("@ContactAddress", applicant.ContactAddress, DbType.String);
                dal.CreateParameter("@ApplicationDate", applicant.ApplicationDate, DbType.DateTime);
                dal.CreateParameter("@UserID", applicant.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update Applicants Set Surname=@Surname,MiddleName=@MiddleName,FirstName=@FirstName,ContactNo=@ContactNo,EmailAddress=@EmailAddress,VacancyID=@VacancyID,ContactAddress=@ContactAddress,ApplicationDate=@ApplicationDate,UserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Applicant> GetAll()
        {
            IList<Applicant> applicants = new List<Applicant>();
            try
            {
                string query="Select * from ApplicantView where ApplicantView.Archived ='False' ";
                query += "And ApplicantView.Status ='Received'";
                DataTable table = dal.ExecuteReader(query);
                
                foreach (DataRow row in table.Rows)
                {
                    IList<StaffDocument> documents = new List<StaffDocument>();
                    foreach(DataRow item in dal.ExecuteReader("Select DateCreated,Description,DocumentGroup,DocumentContent,Path From ApplicantDocumentView where ApplicantID="+ row["ID"].ToString()).Rows)
                    {
                        documents.Add(new StaffDocument() 
                        { 
                            DateCreated = DateTime.Parse(item["DateCreated"].ToString()),
                            Description = item["Description"].ToString(),
                            DocumentGroup = item["DocumentGroup"].ToString(),
                            DocumentContent = (byte[])item["DocumentContent"],
                            Path = item["Path"].ToString(),
                            User = new User()
                            {
                                ID = int.Parse(row["UserID"].ToString()),
                            },
                        });
                    }
                    applicants.Add(new Applicant()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        Surname = row["Surname"].ToString(),
                        Vacancy = new Vacancy() 
                        { 
                            ID = int.Parse(row["VacancyID"].ToString()), 
                            Grade = new HRBussinessLayer.System_Setup_Class.EmployeeGrade() { Grade = row["Grade"].ToString() } 
                        },
                        ContactAddress = row["ContactAddress"].ToString(),
                        EmailAddress = row["EmailAddress"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString()),
                        ContactNo = row["ContactNo"].ToString(),
                        Status = row["Status"].ToString(),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                        },
                        Documents = documents
                    });

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return applicants;
        }
        #endregion

        #region GetByCriteria
        public IList<Applicant> GetByCriteria(Query query1)
        {
            IList<Applicant> applicants = new List<Applicant>();
            try
            {
                IList<StaffDocument> documents = new List<StaffDocument>();
                DataTable table = new DataTable();
                string query = "Select * from ApplicantView  ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " ApplicantView.Archived ='False' And ApplicantView.Status ='Received' Order By ApplicantView.ApplicationDate desc,ApplicantView.Surname";
                table = dal.ExecuteReader(selectStatement);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataRow item in dal.ExecuteReader("Select DateCreated,Description,DocumentGroup,DocumentContent,Path From ApplicantDocumentView where ApplicantID=" + row["ID"].ToString()).Rows)
                    {
                        documents.Add(new StaffDocument()
                        {
                            DateCreated = DateTime.Parse(item["DateCreated"].ToString()),
                            Description = item["Description"].ToString(),
                            DocumentGroup = item["DocumentGroup"].ToString(),
                            DocumentContent = (byte[])item["DocumentContent"],
                            Path = item["Path"].ToString(),
                            User = new User()
                            {
                                ID = int.Parse(row["UserID"].ToString()),
                            },
                        });
                    }
                    Applicant applicant = new Applicant()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"] == DBNull.Value ? null : row["MiddleName"].ToString(),
                        Surname = row["Surname"].ToString(),
                        Vacancy = new Vacancy()
                        {
                            ID = int.Parse(row["VacancyID"].ToString()),
                            Grade = new HRBussinessLayer.System_Setup_Class.EmployeeGrade() { Grade = row["Grade"].ToString() }
                        },
                        ContactAddress = row["ContactAddress"] == DBNull.Value ? null : row["ContactAddress"].ToString(),
                        EmailAddress = row["EmailAddress"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString()),
                        ContactNo = row["ContactNo"].ToString(),
                        Status = row["Status"].ToString(),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                        },
                        Documents = documents
                    };
                    applicants.Add(applicant);
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return applicants;
        }
        #endregion

        #region LazyLoad
        public IList<Applicant> LazyLoad()
        {
            IList<Applicant> applicants = new List<Applicant>();
            try
            {
                IList<StaffDocument> documents = new List<StaffDocument>();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);

                string query = "Select * from ApplicantView Where ApplicantView.Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataRow item in dal.ExecuteReader("Select DateCreated,Description,DocumentGroup,DocumentContent,Path From ApplicantDocumentView where ApplicantID=" + row["ID"].ToString()).Rows)
                    {
                        documents.Add(new StaffDocument()
                        {
                            DateCreated = DateTime.Parse(item["DateCreated"].ToString()),
                            Description = item["Description"].ToString(),
                            DocumentGroup = item["DocumentGroup"].ToString(),
                            DocumentContent = (byte[])item["DocumentContent"],
                            Path = item["Path"].ToString(),
                            User = new User()
                            {
                                ID = int.Parse(row["UserID"].ToString()),
                            },
                        });
                    }
                    Applicant applicant = new Applicant()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"] == DBNull.Value ? null : row["MiddleName"].ToString(),
                        Surname = row["Surname"].ToString(),
                        Vacancy = new Vacancy() { ID = int.Parse(row["VacancyID"].ToString()) },
                        ContactAddress = row["ContactAddress"] == DBNull.Value ? null : row["ContactAddress"].ToString(),
                        EmailAddress = row["EmailAddress"].ToString(),
                        ApplicationDate = DateTime.Parse(row["ApplicationDate"].ToString()),
                        ContactNo = row["ContactNo"].ToString(),
                        Status = row["Status"].ToString(),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                        },
                        Documents = documents
                    };
                    applicants.Add(applicant);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return applicants;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                Applicant applicant = (Applicant)item;
                dal.ExecuteNonQuery("Update Applicants Set Archived='True' Where ID ="+ applicant.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region ImageToArray
        private byte[] ImageToArray(Image img)
        {
            byte[] photoArray;
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Png);
            photoArray = ms.ToArray();
            return photoArray;
        }
        #endregion

        #region ArrayToImage
        private Image ArrayToImage(byte[] photoArray)
        {
            MemoryStream ms = new MemoryStream(photoArray);
            Image img = Image.FromStream(ms);
            return img;
        }
        #endregion
    }
}
