using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class EmployeeGradeDataMapper
    {
        private DALHelper dal;
        private EmployeeGrade employeeGrade;

        public EmployeeGradeDataMapper()
        {
            this.dal = new DALHelper();
            this.employeeGrade = new EmployeeGrade();
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                EmployeeGrade employeeGrade = (EmployeeGrade)item;
                dal.ClearParameters();
                dal.CreateParameter("@CategoryID",employeeGrade.GradeCategory.ID,DbType.Int32);
                dal.CreateParameter("@Code",employeeGrade.Code,DbType.String);
                dal.CreateParameter("@Grade",employeeGrade.Grade,DbType.String);
                dal.CreateParameter("@GradeLevel",employeeGrade.Level,DbType.String);
                dal.CreateParameter("@BasicSalary", employeeGrade.Amount, DbType.Decimal);
                dal.CreateParameter("@Active", employeeGrade.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", employeeGrade.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO EmployeeGrades_Setup (CategoryID,Code,Description,GradeLevel,BasicSalary,Active,UserID)VALUES(@CategoryID,@Code,@Grade,@GradeLevel,@BasicSalary,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                EmployeeGrade employeeGrade = (EmployeeGrade)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID",employeeGrade.ID, DbType.Int32);
                dal.CreateParameter("@CategoryID",employeeGrade.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@Code",employeeGrade.Code, DbType.String);
                dal.CreateParameter("@Grade", employeeGrade.Grade, DbType.String);
                dal.CreateParameter("@GradeLevel",employeeGrade.Level, DbType.String);
                dal.CreateParameter("@BasicSalary", employeeGrade.Amount, DbType.Decimal);
                dal.CreateParameter("@UserID", employeeGrade.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", employeeGrade.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update EmployeeGrades_Setup Set Code =@Code, Description=@Grade, GradeLevel=@GradeLevel, CategoryID=@CategoryID,BasicSalary =@BasicSalary, Active=@Active, UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                EmployeeGrade employeeGrade = (EmployeeGrade)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", employeeGrade.ID, DbType.String);
                dal.ExecuteNonQuery("Update EmployeeGrades_Setup Set Archived='True' Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<EmployeeGrade> GetAll()
        {
            IList<EmployeeGrade> employeeGrades = new List<EmployeeGrade>();
            try
            {
                string query = "Select * from EmployeeGradeView where EmployeeGradeView.Archived='False' Order By EmployeeGradeView.Description,EmployeeGradeView.GradeCategory ASC";
                DataTable gradesTable = dal.ExecuteReader(query);
                foreach (EmployeeGrade employeeGr in BuildEmployeeGradeFromData(gradesTable))
                {
                    employeeGrades.Add(employeeGr);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employeeGrades;
        }
        #endregion endregion

        #region GetByKey
        public EmployeeGrade GetByKey(string categoryCode)
        {
            EmployeeGrade empGrade = new EmployeeGrade();
            try
            {
                string query = "Select * from EmployeeGradeView where EmployeeGradeView.ID =" + categoryCode + " And EmployeeGradeView.Archived='False'";
                DataTable gradeTable = dal.ExecuteReader(query);
                foreach (DataRow row in gradeTable.Rows)
                {
                    empGrade = new EmployeeGrade()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"] == DBNull.Value ? null : row["Code"].ToString(),
                        Grade = row["Description"].ToString(),
                        GradeCategory = new GradeCategory() { ID = int.Parse(row["GradeCategoryID"].ToString()), Code = row["GradeCategoryCode"] == DBNull.Value ? null : row["GradeCategoryCode"].ToString(), Description = row["GradeCategory"].ToString(), },
                        Level = row["GradeLevel"] == DBNull.Value ? null : row["GradeLevel"].ToString(),
                        Amount = decimal.Parse(row["BasicSalary"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                    };
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return empGrade;
        }
        #endregion

        #region GetByCriteria
        public IList<EmployeeGrade> GetByCriteria(Query query1)
        {
            IList<EmployeeGrade> employeeGrades = new List<EmployeeGrade>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", employeeGrade.Archived, DbType.Boolean);

                string query = "select * from EmployeeGradeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  EmployeeGradeView.Archived=@Archived order BY EmployeeGradeView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (EmployeeGrade empGrade in BuildEmployeeGradeFromData(table))
                {
                    employeeGrades.Add(empGrade);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employeeGrades;
        }
        #endregion

        #region BuildEmployeeGradeFromData
        private IList<EmployeeGrade> BuildEmployeeGradeFromData(DataTable table)
        {
            IList<EmployeeGrade> employeeGrades = new List<EmployeeGrade>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    EmployeeGrade employeeGrade = new EmployeeGrade()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"] == DBNull.Value ? string.Empty : row["Code"].ToString(),
                        Grade = row["Description"].ToString(),
                        GradeCategory = new GradeCategory() { ID = int.Parse(row["GradeCategoryID"].ToString()), Code = row["GradeCategoryCode"] == DBNull.Value ? string.Empty : row["GradeCategoryCode"].ToString(), Description = row["GradeCategory"].ToString(), },
                        Level = row["GradeLevel"] == DBNull.Value ? string.Empty : row["GradeLevel"].ToString(),
                        Amount = decimal.Parse(row["BasicSalary"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() }
                    };
                    employeeGrades.Add(employeeGrade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employeeGrades;
        }
        #endregion

        #region OpenConnection
        public void OpenConnection()
        {
            dal.OpenConnection();
        }
        #endregion

        #region OpenConnection
        public void CloseConnection()
        {
            dal.CloseConnection();
        }
        #endregion
    }
}
