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
    public class StaffLanguagesDataMapper
    {
        private DALHelper dal;
        private StaffLanguage staffLanguage;

        public StaffLanguagesDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.staffLanguage = new StaffLanguage();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<StaffLanguage> GetAll()
        {
            IList<StaffLanguage> staffLanguages = new List<StaffLanguage>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffLanguageView Where StaffLanguageView.Archived='False'");

                foreach (StaffLanguage sl in BuildStaffLanguagesFromData(table))
                {
                    staffLanguage = sl;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLanguages;
        }

        public StaffLanguage GetByID(object key)
        {
            IList<StaffLanguage> staffLanguages = new List<StaffLanguage>();
            StaffLanguage staffLanguage = new StaffLanguage();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffLanguageView Where StaffLanguageView.StaffID=@StaffID and StaffLanguageView.Archived=@Archived");

                foreach (StaffLanguage sl in BuildStaffLanguagesFromData(table))
                {
                    staffLanguage = sl;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLanguage;
        }

        #region GetByCriteria
        public IList<StaffLanguage> GetByCriteria(Query query1)
        {
            IList<StaffLanguage> staffLanguages = new List<StaffLanguage>();
            StaffLanguage staffLanguage = new StaffLanguage();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", staffLanguage.Archived, DbType.Boolean);
                string query = "select * from StaffLanguageView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffLanguageView.Archived=@Archived order BY StaffLanguageView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffLanguage staffl in BuildStaffLanguagesFromData(table))
                {
                    staffLanguages.Add(staffl);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLanguages;
        }
        #endregion

        private IList<StaffLanguage> BuildStaffLanguagesFromData(DataTable table)
        {
            IList<StaffLanguage> staffLanguages = new List<StaffLanguage>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffLanguage staffLanguage = new StaffLanguage()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Language = new Language()
                        {
                            ID = row["LanguageID"] == DBNull.Value ? 0 : int.Parse(row["LanguageID"].ToString()),
                            Description = row["Language"] == DBNull.Value ? string.Empty : row["Language"].ToString()
                        },
                        LanguageLevel = row["LanguageLevel"].ToString(),
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
                        Active = bool.Parse(row["Active"].ToString()),
                        DateCreated = DateTime.Parse(row["DateCreated"].ToString()),
                    };
                    staffLanguages.Add(staffLanguage);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLanguages;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                StaffLanguage staffLanguage = (StaffLanguage)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffLanguage.ID, DbType.Int32);
                dal.CreateParameter("@Archived", staffLanguage.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update StaffLanguages Set Archived=@Archived Where ID =@ID");
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
