using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Data;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class StaffSalaryHistoryDataMapper
    {
        private DALHelper dal;

        public StaffSalaryHistoryDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                StaffSalaryHistory salaryInformation = (StaffSalaryHistory)item;

                dal.ClearParameters();
                dal.CreateParameter("@StaffID", salaryInformation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", salaryInformation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", salaryInformation.Grade.ID.ToString(), DbType.String);
                dal.CreateParameter("@DepartmentID", salaryInformation.Department.ID, DbType.String);
                dal.CreateParameter("@SupervisorID", salaryInformation.Supervisor, DbType.String);
                dal.CreateParameter("@MonthlyBasicSalary", salaryInformation.MonthlyBasicSalary, DbType.Decimal);
                dal.CreateParameter("@SalaryEarned", salaryInformation.SalaryEarned, DbType.Decimal);
                if(salaryInformation.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", salaryInformation.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@HoursWorked", salaryInformation.HoursWorked, DbType.Decimal);
                dal.CreateParameter("@PaymentMode", salaryInformation.PaymentMode, DbType.String);
                dal.CreateParameter("@Active", salaryInformation.In_Use, DbType.Boolean);
                dal.CreateParameter("@StartDate", salaryInformation.StartDate, DbType.DateTime);
                dal.CreateParameter("@PaymentFrequency", salaryInformation.PaymentFrequency, DbType.String);
                dal.CreateParameter("@PaymentType", salaryInformation.PaymentType, DbType.String);
                dal.CreateParameter("@UserID", salaryInformation.UserID, DbType.Int32);
                dal.CreateParameter("@StepID", salaryInformation.Step.ID, DbType.Int32);
                dal.CreateParameter("@BandID", salaryInformation.Band.ID, DbType.Int32);

                string insertCommand = string.Empty;
                insertCommand = "Insert Into StaffSalaryHistory (StaffID,StaffCode,GradeID,Department,Supervisor,MonthlyBasicSalary,SalaryEarned,HoursWorked,PaymentMode,InUse,StartDate,PaymentFrequency,PaymentType,StepID,BandID,EndDate,UserID) Values(@StaffID,@StaffCode,@GradeID,@DepartmentID,@SupervisorID,@MonthlyBasicSalary,@SalaryEarned,@HoursWorked,@PaymentMode,@Active,@StartDate,@PaymentFrequency,@PaymentType,@StepID,@BandID,@EndDate,@UserID)";
                dal.ExecuteNonQuery(insertCommand);
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
                StaffSalaryHistory salaryInformation = (StaffSalaryHistory)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", salaryInformation.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", salaryInformation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", salaryInformation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", salaryInformation.Grade.ID, DbType.String);
                dal.CreateParameter("@DepartmentID", salaryInformation.Department.ID, DbType.String);
                dal.CreateParameter("@SupervisorID", salaryInformation.Supervisor, DbType.String);
                dal.CreateParameter("@MonthlyBasicSalary", salaryInformation.MonthlyBasicSalary, DbType.Decimal);
                dal.CreateParameter("@SalaryEarned", salaryInformation.SalaryEarned, DbType.Decimal);
                if (salaryInformation.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", salaryInformation.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@HoursWorked", salaryInformation.HoursWorked, DbType.Decimal);
                dal.CreateParameter("@PaymentMode", salaryInformation.PaymentMode, DbType.String);
                dal.CreateParameter("@InUse", salaryInformation.In_Use, DbType.Boolean);
                dal.CreateParameter("@StartDate", salaryInformation.StartDate, DbType.DateTime);
                dal.CreateParameter("@PaymentFrequency", salaryInformation.PaymentFrequency, DbType.String);
                dal.CreateParameter("@PaymentType", salaryInformation.PaymentType, DbType.String);
                dal.CreateParameter("@UserID", salaryInformation.UserID, DbType.String);
                dal.CreateParameter("@StepID", salaryInformation.Step.ID.ToString(), DbType.String);
                dal.CreateParameter("@BandID", salaryInformation.Band.ID.ToString(), DbType.String);

                string updateCommand = string.Empty;
                updateCommand = "Update StaffSalaryHistory Set StaffID=@StaffID,GradeID=@GradeID,Department=@DepartmentID,Supervisor=@SupervisorID,MonthlyBasicSalary=@MonthlyBasicSalary,SalaryEarned=@SalaryEarned,HoursWorked=@HoursWorked,PaymentMode=@PaymentMode,InUse=@InUse,StartDate=@StartDate,PaymentFrequency=@PaymentFrequency,PaymentType=@PaymentType,UserID=@UserID,BandID=@BandID,StepID=@StepID,EndDate=@EndDate  Where ID=@ID";
                dal.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<StaffSalaryHistory> GetAll()
        {
            IList<StaffSalaryHistory> salaryInfos = new List<StaffSalaryHistory>();
            try
            {
                string query = "select * From StaffSalaryHistoryView Where Archived='False'";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (StaffSalaryHistory salaryIn in BuildStaffSalaryHistoryFromData(salaryInfoTable))
                {
                    salaryInfos.Add(salaryIn);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return salaryInfos;
        }
        #endregion

        #region GetByCriteria
        public IList<StaffSalaryHistory> GetByCriteria(Query query1)
        {
            IList<StaffSalaryHistory> salaryInfos = new List<StaffSalaryHistory>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT * From StaffSalaryHistoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' Order By StaffID";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffSalaryHistory salaryIn in BuildStaffSalaryHistoryFromData(table))
                {
                    salaryInfos.Add(salaryIn);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return salaryInfos;
        }
        #endregion

        #region Get By ID
        public StaffSalaryHistory GetByID(object key)
        {
            StaffSalaryHistory salaryInfo = new StaffSalaryHistory();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                string query = "select * From StaffSalaryHistoryView Where StaffID=@StaffID and Archived=@Archived";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (StaffSalaryHistory salaryIn in BuildStaffSalaryHistoryFromData(salaryInfoTable))
                {
                    salaryInfo = salaryIn;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return salaryInfo;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                StaffSalaryHistory salaryInfo = (StaffSalaryHistory)item;
                dal.ExecuteNonQuery("Update StaffSalaryHistory Set Archived = 'True' Where StaffID ='" + salaryInfo.Employee.StaffID + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildStaffSalaryHistoryFromData
        private IList<StaffSalaryHistory> BuildStaffSalaryHistoryFromData(DataTable table)
        {
            IList<StaffSalaryHistory> salaryInfos = new List<StaffSalaryHistory>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffSalaryHistory salaryInfo = new StaffSalaryHistory()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Department = new Department()
                        {
                            ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()),
                            Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString()
                        },
                        Grade = new EmployeeGrade()
                        {
                            ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                            Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString(),
                            GradeCategory = new GradeCategory()
                            {
                                ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                                Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString(),
                            },
                        },
                        In_Use = bool.Parse(row["InUse"].ToString()),
                        MonthlyBasicSalary = decimal.Parse(row["MonthlyBasicSalary"].ToString()),
                        SalaryEarned = decimal.Parse(row["SalaryEarned"].ToString()),
                        HoursWorked = decimal.Parse(row["HoursWorked"].ToString()),
                        PaymentMode = row["PaymentMode"].ToString(),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString()
                        },
                        StartDate = DateTime.Parse(row["StartDate"].ToString()),
                        PaymentFrequency = row["PaymentFrequency"].ToString(),
                        PaymentType = row["PaymentType"].ToString(),
                        Band = new Band()
                        {
                            ID = row["BandID"] == DBNull.Value ? 0 : int.Parse(row["BandID"].ToString()),
                            Description = row["Band"] == DBNull.Value ? null : row["Band"].ToString()
                        },
                        Step = new Step()
                        {
                            ID = row["StepID"] == DBNull.Value ? 0 : int.Parse(row["StepID"].ToString()),
                            Description = row["Step"] == DBNull.Value ? null : row["Step"].ToString()
                        },
                        EndDate = row["EndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EndDate"].ToString())
                    };

                    salaryInfos.Add(salaryInfo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return salaryInfos;
        }
        #endregion
    }
}
