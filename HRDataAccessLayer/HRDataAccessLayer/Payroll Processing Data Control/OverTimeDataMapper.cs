using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Data;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class OverTimeDataMapper
    {
        private DALHelper dal;

        public OverTimeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                OverTime overTime = (OverTime)item;

                dal.ClearParameters();
                dal.CreateParameter("@StaffID", overTime.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", overTime.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", overTime.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", overTime.Grade.ID, DbType.Int32);
                dal.CreateParameter("@HrsWorked", overTime.HrsWorked, DbType.Decimal);
                dal.CreateParameter("@BasicSalary", overTime.BasicSalary, DbType.Decimal);
                dal.CreateParameter("@Amount", overTime.Amount, DbType.Decimal);
                dal.CreateParameter("@OverTimeRate", overTime.OverTimeRate, DbType.Decimal);
                dal.CreateParameter("@TotalShifts", overTime.TotalShifts, DbType.Int32);
                if (overTime.Holiday == null)
                {
                    dal.CreateParameter("@Holiday", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@Holiday", overTime.Holiday, DbType.DateTime);
                }
                dal.CreateParameter("@Date", overTime.Date, DbType.DateTime);
                dal.CreateParameter("@OverTimeTypeID", overTime.OverTimeType.ID, DbType.Int32);
                dal.CreateParameter("@InUse", overTime.In_Use, DbType.Boolean);
                dal.CreateParameter("@IsTaxable", overTime.IsTaxable, DbType.Boolean);
                dal.CreateParameter("@Reason", overTime.Reason, DbType.String);
                dal.CreateParameter("@UserID", overTime.User.ID, DbType.Int32);

                string insertCommand = string.Empty;
                insertCommand = "Insert Into OverTime (StaffID,StaffCode,GradeCategoryID,GradeID,HrsWorked,BasicSalary,Amount,OverTimeRate,TotalShifts,Holiday,Date,OverTimeTypeID,InUse,IsTaxable,Reason,UserID) Values(@StaffID,@StaffCode,@GradeCategoryID,@GradeID,@HrsWorked,@BasicSalary,@Amount,@OverTimeRate,@TotalShifts,@Holiday,@Date,@OverTimeTypeID,@InUse,@IsTaxable,@Reason,@UserID)";
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
                OverTime overTime = (OverTime)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", overTime.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", overTime.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", overTime.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", overTime.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", overTime.Grade.ID, DbType.Int32);
                dal.CreateParameter("@HrsWorked", overTime.HrsWorked, DbType.Decimal);
                dal.CreateParameter("@BasicSalary", overTime.BasicSalary, DbType.Decimal);
                dal.CreateParameter("@Amount", overTime.Amount, DbType.Decimal);
                dal.CreateParameter("@OverTimeRate", overTime.OverTimeRate, DbType.Decimal);
                dal.CreateParameter("@TotalShifts", overTime.TotalShifts, DbType.Int32);
                if (overTime.Holiday == null)
                {
                    dal.CreateParameter("@Holiday", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@Holiday", overTime.Holiday, DbType.DateTime);
                }
                dal.CreateParameter("@Date", overTime.Date, DbType.DateTime);
                dal.CreateParameter("@OverTimeTypeID", overTime.OverTimeType.ID, DbType.Int32);
                dal.CreateParameter("@InUse", overTime.In_Use, DbType.Boolean);
                dal.CreateParameter("@IsTaxable", overTime.IsTaxable, DbType.Boolean);
                dal.CreateParameter("@Reason", overTime.Reason, DbType.String);
                dal.CreateParameter("@UserID", overTime.User.ID, DbType.Int32);

                string updateCommand = string.Empty;
                updateCommand = "Update OverTime Set StaffID=@StaffID,StaffCode=@StaffCode,GradeCategoryID=@GradeCategoryID,GradeID=@GradeID,HrsWorked=@HrsWorked,BasicSalary=@BasicSalary,Amount=@Amount,OverTimeRate=@OverTimeRate,TotalShifts=@TotalShifts,Holiday=@Holiday,Date=@Date,OverTimeTypeID=@OverTimeTypeID,InUse=@InUse,Reason=@Reason,UserID=@UserID,IsTaxable=@IsTaxable  Where ID=@ID";
                dal.ExecuteNonQuery(updateCommand);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<OverTime> GetAll()
        {
            IList<OverTime> overTimes = new List<OverTime>();
            try
            {
                string query = "select OverTimeView.*,OverTimeView.FirstName +' '+ OverTimeView.OtherName +' '+ OverTimeView.Surname as StaffName From OverTimeView Where Archived='False'";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (OverTime overTime in BuildOverTimeFromData(salaryInfoTable))
                {
                    overTimes.Add(overTime);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return overTimes;
        }
        #endregion

        #region GetByCriteria
        public IList<OverTime> GetByCriteria(Query query1)
        {
            IList<OverTime> overTimes = new List<OverTime>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT OverTimeView.*,OverTimeView.FirstName +' '+ OverTimeView.OtherName +' '+ OverTimeView.Surname as StaffName From OverTimeView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                if (selectStatement.Trim().EndsWith("And"))
                {
                    selectStatement = selectStatement.Trim().TrimEnd("And".ToCharArray());
                }
                selectStatement += " Order By Date desc,StaffID asc";
                table = dal.ExecuteReader(selectStatement);
                foreach (OverTime overTime in BuildOverTimeFromData(table))
                {
                    overTimes.Add(overTime);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return overTimes;
        }
        #endregion

        #region Get By ID
        public OverTime GetByID(object key)
        {
            OverTime overTime = new OverTime();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                string query = "select OverTimeView.*,OverTimeView.FirstName +' '+ OverTimeView.OtherName +' '+ OverTimeView.Surname as StaffName From OverTimeView Where StaffID=@StaffID and Archived=@Archived";
                DataTable salaryInfoTable = dal.ExecuteReader(query);
                foreach (OverTime overT in BuildOverTimeFromData(salaryInfoTable))
                {
                    overTime = overT;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return overTime;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                OverTime overTime = (OverTime)item;

                dal.ExecuteNonQuery("Update OverTime Set Archived = 'True', ArchiverID='"+ overTime.ArchiverID +"',ArchivedTime='"+ overTime.ArchivedTime +"'  Where ID ='" + overTime.ID + "'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region BuildOverTimeFromData
        private IList<OverTime> BuildOverTimeFromData(DataTable table)
        {
            IList<OverTime> overTimes = new List<OverTime>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    OverTime overTime = new OverTime();
                    overTime.ID = int.Parse(row["ID"].ToString());
                    overTime.Employee = new Employee()
                    {
                        ID = int.Parse(row["StaffCode"].ToString()),
                        StaffID = row["StaffID"].ToString(),
                        Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                        FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                        OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                        BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString()),
                        Title = new Titles()
                        {
                            ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()),
                            Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString()
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
                        Unit = new Unit()
                        {
                            ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()),
                            Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString()
                        },
                        Department = new Department()
                        {
                            ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()),
                            Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString()
                        },
                        Zone = new Zone()
                        {
                            ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                            Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString()
                        },
                        Specialty = new Specialty()
                        {
                            ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()),
                            Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString()
                        },
                        Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString()),
                        EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        DOB = row["DOB"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                    };
                    overTime.StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString();
                    overTime.IsTaxable = row["IsTaxable"] == DBNull.Value ? false : bool.Parse(row["IsTaxable"].ToString());
                    overTime.GradeCategory = new GradeCategory()
                    {
                        ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                        Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                    };
                    overTime.Grade = new EmployeeGrade()
                    {
                        ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                        Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString()
                    };
                    overTime.In_Use = bool.Parse(row["InUse"].ToString());
                    overTime.IsTaxable = bool.Parse(row["IsTaxable"].ToString());
                    overTime.BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString());
                    overTime.HrsWorked = row["HrsWorked"] == DBNull.Value ? 0 : decimal.Parse(row["HrsWorked"].ToString());
                    overTime.Amount = row["Amount"] == DBNull.Value ? 0 : decimal.Parse(row["Amount"].ToString());
                    overTime.Date = DateTime.Parse(row["Date"].ToString());
                    overTime.Reason = row["Reason"] == DBNull.Value ? string.Empty : row["Reason"].ToString();
                    overTime.OverTimeType = new OverTimeType()
                    {
                        ID = row["OverTimeTypeID"] == DBNull.Value ? 0 : int.Parse(row["OverTimeTypeID"].ToString()),
                        Description = row["OverTimeType"] == DBNull.Value ? string.Empty : row["OverTimeType"].ToString(),
                        Rate = row["OverTimeTypeRate"] == DBNull.Value ? 0 : decimal.Parse(row["OverTimeTypeRate"].ToString())
                    };
                    overTime.Holiday = row["Holiday"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["Holiday"].ToString());
                    overTime.OverTimeRate = row["OverTimeRate"] == DBNull.Value ? 0 : decimal.Parse(row["OverTimeRate"].ToString());
                    overTime.TotalShifts = row["TotalShifts"] == DBNull.Value ? 0 : int.Parse(row["TotalShifts"].ToString());
                    overTime.DateAndTimeGenerated = DateTime.Parse(row["ServerTime"].ToString());
                    overTime.Archived = bool.Parse(row["Archived"].ToString());
                    overTime.ArchivedTime = row["ArchivedTime"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["ArchivedTime"].ToString());
                    overTime.ArchiverID = row["ArchiverID"] == DBNull.Value ? 0: int.Parse(row["ArchiverID"].ToString());
                    overTime.User = new User()
                    {
                        ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                    };
                    //OverTime overTime = new OverTime()
                    //{
                    //    ID = int.Parse(row["ID"].ToString()),
                    //    Employee = new Employee()
                    //    {
                    //        ID = int.Parse(row["StaffCode"].ToString()),
                    //        StaffID = row["StaffID"].ToString(),
                    //        Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                    //        FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                    //        OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                    //        BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString()),
                    //        Title = new Titles()
                    //        {
                    //            ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()),
                    //            Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString()
                    //        },
                    //        GradeCategory = new GradeCategory()
                    //        {
                    //            ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                    //            Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString()
                    //        },
                    //        Grade = new EmployeeGrade()
                    //        {
                    //            ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                    //            Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString()
                    //        },
                    //        Gender = row["Gender"] == DBNull.Value ? null : row["Gender"].ToString(),
                    //        Unit = new Unit()
                    //        {
                    //            ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()),
                    //            Description = row["Unit"] == DBNull.Value ? null : row["Unit"].ToString()
                    //        },
                    //        Department = new Department()
                    //        {
                    //            ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()),
                    //            Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString()
                    //        },
                    //        Zone = new Zone()
                    //        {
                    //            ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                    //            Description = row["Zone"] == DBNull.Value ? null : row["Zone"].ToString()
                    //        },
                    //        Specialty = new Specialty()
                    //        {
                    //            ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()),
                    //            Description = row["Specialty"] == DBNull.Value ? null : row["Specialty"].ToString()
                    //        },
                    //        Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString()),
                    //        EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                    //        DOB = row["DOB"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                    //    },
                    //    StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                    //    IsTaxable = row["IsTaxable"] == DBNull.Value ? false : bool.Parse(row["IsTaxable"].ToString()),
                    //    GradeCategory = new GradeCategory()
                    //    {
                    //        ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                    //        Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString()
                    //    },
                    //    Grade = new EmployeeGrade()
                    //    {
                    //        ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                    //        Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString()
                    //    },
                    //    In_Use = bool.Parse(row["InUse"].ToString()),
                    //    BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString()),
                    //    HrsWorked = row["HrsWorked"] == DBNull.Value ? 0 : decimal.Parse(row["HrsWorked"].ToString()),
                    //    Amount = row["Amount"] == DBNull.Value ? 0 : decimal.Parse(row["Amount"].ToString()),
                    //    Date = DateTime.Parse(row["Date"].ToString()),
                    //    Reason = row["Reason"] == DBNull.Value ? string.Empty : row["Reason"].ToString(),
                    //    Type = row["Type"] == DBNull.Value ? string.Empty : row["Type"].ToString(),
                    //    Holiday = row["Holiday"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["Holiday"].ToString()),
                    //    OverTimeRate = row["OverTimeRate"] == DBNull.Value ? 0 : decimal.Parse(row["OverTimeRate"].ToString()),
                    //    TotalShifts = row["TotalShifts"] == DBNull.Value ? 0 : int.Parse(row["TotalShifts"].ToString()),
                    //    DateAndTimeGenerated = DateTime.Parse(row["ServerTime"].ToString()),
                    //    Archived = bool.Parse(row["Archived"].ToString()),
                    //    ArchivedTime = row["ArchivedTime"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["ArchivedTime"].ToString()),
                    //    ArchiverID = row["ArchiverID"] == DBNull.Value ? 0: int.Parse(row["ArchiverID"].ToString()),
                    //    User = new User()
                    //    {
                    //        ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                    //    },
                        
                    //};



                    overTimes.Add(overTime);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return overTimes;
        }
        #endregion
    }
}
