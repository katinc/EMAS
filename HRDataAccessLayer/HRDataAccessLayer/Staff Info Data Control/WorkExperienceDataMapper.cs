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
    public class WorkExperienceDataMapper
    {
        private DALHelper dal;
        private WorkExperience experience;

        public WorkExperienceDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.experience = new WorkExperience();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #region GetAll
        public IList<WorkExperience> GetAll()
        {
            IList<WorkExperience> workExperiences = new List<WorkExperience>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffEmploymentHistoryView Where Archived='False'");
                foreach (WorkExperience wk in BuildStaffEmploymentHistoryFromData(table))
                {
                    workExperiences.Add(wk);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return workExperiences;
        }
        #endregion

        #region GetByID
        public WorkExperience GetByID(object key)
        {
            IList<WorkExperience> workExperiences = new List<WorkExperience>();
            WorkExperience workExperience = new WorkExperience();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffEmploymentHistoryView Where StaffEmploymentHistoryView.StaffID=@StaffID and Archived=@Archived");

                foreach (WorkExperience wk in BuildStaffEmploymentHistoryFromData(table))
                {
                    workExperience = wk;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return workExperience;
        }

        #region GetByCriteria
        public IList<WorkExperience> GetByCriteria(Query query1)
        {
            IList<WorkExperience> workExperiences = new List<WorkExperience>();
            WorkExperience workExperience = new WorkExperience();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", workExperience.Archived, DbType.Boolean);
                string query = "select * from StaffEmploymentHistoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffEmploymentHistoryView.Archived=@Archived order BY StaffEmploymentHistoryView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (WorkExperience wk in BuildStaffEmploymentHistoryFromData(table))
                {
                    workExperiences.Add(wk);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return workExperiences;
        }
        #endregion

        private IList<WorkExperience> BuildStaffEmploymentHistoryFromData(DataTable table)
        {
            IList<WorkExperience> workExperiences = new List<WorkExperience>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    WorkExperience workExperience = new WorkExperience()
                    {
                        ID = int.Parse(row["ID"].ToString()),
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
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        NameOfOrganisation = row["NameOfOrganisation"].ToString(),
                        JobTitle = row["JobDescription"].ToString(),
                        FromMonth = row["StartMonth"].ToString(),
                        ToMonth = row["EndMonth"].ToString(),
                        FromYear = row["StartYear"].ToString(),
                        ToYear = row["StartYear"].ToString(),
                        AnnualSalary = decimal.Parse(row["AnnualSalary"].ToString()),
                        DateAndTimeGenerated = DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        ReasonForLeaving = row["ReasonForLeaving"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    workExperiences.Add(workExperience);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return workExperiences;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", "True", DbType.String);

                dal.ExecuteNonQuery("Update StaffEmploymentHistory Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
