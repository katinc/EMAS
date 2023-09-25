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
    public class QualificationDataMapper
    {
        private DALHelper dal;
        private Qualification qualification;

        public QualificationDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.qualification = new Qualification();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<Qualification> GetAll()
        {
            IList<Qualification> qualifications = new List<Qualification>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffEducationHistoryView Where StaffEducationHistoryView.Archived='False'");

                foreach (DataRow row in table.Rows)
                {
                    qualifications.Add(new Qualification() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        NameOfInstitution = row["NameOfInstitution"].ToString(), 
                        CertificateObtained = row["CertificateObtained"].ToString(), 
                        FromMonth = row["StartMonth"].ToString(), 
                        ToMonth = row["EndMonth"].ToString(), 
                        FromYear = row["StartYear"].ToString(), 
                        ToYear = row["EndYear"].ToString() ,
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
                            FileNumber = new FileNumber()
                            {
                                ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()),
                                Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString()
                            },
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
            return qualifications;
        }

        public Qualification GetByID(object key)
        {
            IList<Qualification> qualifications = new List<Qualification>();
            Qualification qualification = new Qualification();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffEducationHistoryView Where StaffEducationHistoryView.StaffID=@StaffID and StaffEducationHistoryView.Archived=@Archived");

                foreach (Qualification wk in BuildQualificationFromData(table))
                {
                    qualification = wk;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return qualification;
        }

        #region GetByCriteria
        public IList<Qualification> GetByCriteria(Query query1)
        {
            IList<Qualification> qualifications = new List<Qualification>();
            Qualification qualification = new Qualification();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", qualification.Archived, DbType.Boolean);
                string query = "select * from StaffEducationHistoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffEducationHistoryView.Archived=@Archived order BY StaffEducationHistoryView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Qualification qua in BuildQualificationFromData(table))
                {
                    qualifications.Add(qua);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return qualifications;
        }
        #endregion

        private IList<Qualification> BuildQualificationFromData(DataTable table)
        {
            IList<Qualification> qualifications = new List<Qualification>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Qualification qualification = new Qualification()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NameOfInstitution = row["NameOfInstitution"].ToString(),
                        CertificateObtained = row["CertificateObtained"].ToString(),
                        FromMonth = row["StartMonth"].ToString(),
                        ToMonth = row["EndMonth"].ToString(),
                        FromYear = row["StartYear"].ToString(),
                        ToYear = row["StartYear"].ToString(),
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
                            FileNumber = new FileNumber()
                            {
                                ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()),
                                Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString()
                            },
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
                    };
                    qualifications.Add(qualification);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return qualifications;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", "True", DbType.String);

                dal.ExecuteNonQuery("Update StaffEducationHistory Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
