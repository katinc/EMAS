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
using HRBussinessLayer.ErrorLogging;


namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class IncrementDataMapper
    {
        private DALHelper dal;
        private Increment increment;

        public IncrementDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.increment = new Increment();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Increment increment = (Increment)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", increment.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", increment.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", increment.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", increment.Grade.ID, DbType.Int32);
                dal.CreateParameter("@IsPercentage", increment.IsPercentage, DbType.Boolean);
                dal.CreateParameter("@Increase", increment.Increase, DbType.Decimal);
                dal.CreateParameter("@IncrementType", increment.IncrementType, DbType.String);
                if (increment.IncrementDate == null)
                {
                    dal.CreateParameter("@IncrementDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@IncrementDate", increment.IncrementDate, DbType.Date);
                }

                dal.CreateParameter("@Reason", increment.Reason, DbType.String);
                dal.CreateParameter("@UserID", increment.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Increments(StaffID,StaffCode,IncrementDate,IncrementType,GradeCategoryID,GradeID,IsPercentage,Increase,Reason,UserID) Values(@StaffID,@StaffCode,@IncrementDate,@IncrementType,@GradeCategoryID,@GradeID,@IsPercentage,@Increase,@Reason,@UserID)");
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
                Increment increment = (Increment)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", increment.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", increment.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", increment.Employee.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", increment.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", increment.Grade.ID, DbType.Int32);
                dal.CreateParameter("@IsPercentage", increment.IsPercentage, DbType.Boolean);
                dal.CreateParameter("@Increase", increment.Increase, DbType.Decimal);
                dal.CreateParameter("@IncrementType", increment.IncrementType, DbType.String);
                if (increment.IncrementDate == null)
                {
                    dal.CreateParameter("@IncrementDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@IncrementDate", increment.IncrementDate, DbType.Date);
                }

                dal.CreateParameter("@Reason", increment.Reason, DbType.String);
                dal.CreateParameter("@UserID", increment.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", increment.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Increments Set StaffID=@StaffID,StaffCode=@StaffCode,IncrementDate=@IncrementDate,IncrementType=@IncrementType,GradeCategoryID=@GradeCategoryID,GradeID=@GradeID,IsPercentage=@IsPercentage,Increase=@Increase,Reason=@Reason,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Increment> GetAll()
        {
            IList<Increment> increments = new List<Increment>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", increment.Archived, DbType.String);
                string query = "select IncrementView.* from IncrementView ";
                query += "WHERE IncrementView.Archived=@Archived order BY IncrementView.StaffID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Increment incre in BuildIncrementFromData(table))
                {
                    increments.Add(incre);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return increments;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Increment Increment = (Increment)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", Increment.ID, DbType.Int32);
                dal.CreateParameter("@Archived", Increment.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Increments Set Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Increment> GetByCriteria(Query query1)
        {
            IList<Increment> increments = new List<Increment>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", increment.Archived, DbType.Boolean);
                string query = "select IncrementView.* from IncrementView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  IncrementView.Archived=@Archived order BY IncrementView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Increment incre in BuildIncrementFromData(table))
                {
                    increments.Add(incre);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return increments;
        }
        #endregion

        #region BuildIncrementFromData
        private IList<Increment> BuildIncrementFromData(DataTable table)
        {
            IList<Increment> increments = new List<Increment>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Increment increment = new Increment()
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
                            Unit = new Unit()
                            {
                                ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()),
                                Description = row["Unit"] == DBNull.Value ? null : row["Unit"].ToString()
                            },
                            Department = new Department()
                            {
                                ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()),
                                Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString()
                            },
                            Zone = new Zone()
                            {
                                ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                                Description = row["Zone"] == DBNull.Value ? null : row["Zone"].ToString()
                            },
                            Specialty = new Specialty()
                            {
                                ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()),
                                Description = row["Specialty"] == DBNull.Value ? null : row["Specialty"].ToString()
                            },
                        },
                        IncrementDate = row["IncrementDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["IncrementDate"].ToString()),
                        GradeCategory = new GradeCategory()
                        {
                            ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                            Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString()
                        },
                        Grade = new EmployeeGrade()
                        {
                            ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                            Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString()
                        },
                        IsPercentage = bool.Parse(row["IsPercentage"].ToString()),
                        Increase = decimal.Parse(row["Increase"].ToString()),
                        Reason = row["Reason"] is DBNull ? null : row["Reason"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() 
                        { 
                            ID = int.Parse(row["UserID"].ToString()) 
                        },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        IncrementType = row["IncrementType"] == DBNull.Value ? null : row["IncrementType"].ToString(),
                    };
                    increments.Add(increment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return increments;
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
