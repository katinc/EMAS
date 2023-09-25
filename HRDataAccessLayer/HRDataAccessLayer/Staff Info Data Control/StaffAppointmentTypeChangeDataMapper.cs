using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class StaffAppointmentTypeChangeDataMapper
    {
        private DALHelper dal;

        public StaffAppointmentTypeChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffAppointmentTypeChange staffAppointmentTypeChange = (StaffAppointmentTypeChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffAppointmentTypeChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffAppointmentTypeChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffAppointmentTypeChange.Date, DbType.DateTime);
                dal.CreateParameter("@AppointmentTypeToID", staffAppointmentTypeChange.AppointmentTypeTo.ID, DbType.Int32);
                dal.CreateParameter("@AppointmentTypeFromID", staffAppointmentTypeChange.AppointmentTypeFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffAppointmentTypeChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffAppointmentTypeChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffAppointmentTypeChange.ApprovedUserStaffID, DbType.String);
                if (staffAppointmentTypeChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffAppointmentTypeChange.ApprovedDate, DbType.Date);
                }
                if (staffAppointmentTypeChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffAppointmentTypeChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffAppointmentTypeChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffAppointmentTypeChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffAppointmentTypeChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffAppointmentTypeChange (StaffID,StaffCode,Date,AppointmentTypeTo,AppointmentTypeFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@AppointmentTypeToID,@AppointmentTypeFromID,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
            }
            catch (Exception ex)
            {
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
                StaffAppointmentTypeChange staffAppointmentTypeChange = (StaffAppointmentTypeChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffAppointmentTypeChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffAppointmentTypeChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffAppointmentTypeChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffAppointmentTypeChange.Date, DbType.DateTime);
                dal.CreateParameter("@AppointmentTypeToID", staffAppointmentTypeChange.AppointmentTypeTo.ID, DbType.Int32);
                dal.CreateParameter("@AppointmentTypeFromID", staffAppointmentTypeChange.AppointmentTypeFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffAppointmentTypeChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffAppointmentTypeChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffAppointmentTypeChange.ApprovedUserStaffID, DbType.String);
                if (staffAppointmentTypeChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffAppointmentTypeChange.ApprovedDate, DbType.Date);
                }
                if (staffAppointmentTypeChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffAppointmentTypeChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffAppointmentTypeChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffAppointmentTypeChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffAppointmentTypeChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffAppointmentTypeChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,AppointmentTypeTo=@AppointmentTypeToID,AppointmentTypeFrom=@AppointmentTypeFromID,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffAppointmentTypeChange> GetAll()
        {
            try
            {
                IList<StaffAppointmentTypeChange> staffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
                DataTable table = dal.ExecuteReader("Select StaffAppointmentTypeChangeView.*,StaffJobTitleChange.FirstName +' '+ StaffAppointmentTypeChangeView.OtherName +' '+ StaffAppointmentTypeChangeView.Surname as StaffName from StaffAppointmentTypeChangeView where StaffAppointmentTypeChangeView.Archived ='False' ORDER BY StaffAppointmentTypeChangeView.ServerTime DESC,StaffAppointmentTypeChangeView.StaffID ASC");
                foreach (StaffAppointmentTypeChange sta in BuildStaffAppointmentTypeChangeFromData(table))
                {
                    staffAppointmentTypeChanges.Add(sta);
                }
                return staffAppointmentTypeChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffAppointmentTypeChange> GetByCriteria(Query query1)
        {
            IList<StaffAppointmentTypeChange> staffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffAppointmentTypeChangeView.*,StaffAppointmentTypeChangeView.FirstName +' '+ StaffAppointmentTypeChangeView.OtherName +' '+ StaffAppointmentTypeChangeView.Surname as StaffName from StaffAppointmentTypeChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffAppointmentTypeChangeView.Archived=@Archived  ORDER BY StaffAppointmentTypeChangeView.ServerTime DESC,StaffAppointmentTypeChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffAppointmentTypeChange term in BuildStaffAppointmentTypeChangeFromData(table))
                {
                    staffAppointmentTypeChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffAppointmentTypeChanges;
        }
        #endregion

        #region Get By ID
        public StaffAppointmentTypeChange GetByID(object key)
        {
            StaffAppointmentTypeChange staffAppointmentTypeChange = new StaffAppointmentTypeChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffAppointmentTypeChangeView.*,StaffAppointmentTypeChangeView.FirstName +' '+ StaffAppointmentTypeChangeView.OtherName +' '+ StaffAppointmentTypeChangeView.Surname as StaffName from StaffAppointmentTypeChangeView ";
                query += "WHERE StaffAppointmentTypeChangeView.ID=@ID And StaffAppointmentTypeChangeView.Archived=@Archived order BY StaffAppointmentTypeChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffAppointmentTypeChange staf in BuildStaffAppointmentTypeChangeFromData(table))
                {
                    staffAppointmentTypeChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffAppointmentTypeChange;
        }
        #endregion

        #region BuildStaffAppointmentTypeChangeFromData
        private IList<StaffAppointmentTypeChange> BuildStaffAppointmentTypeChangeFromData(DataTable table)
        {
            IList<StaffAppointmentTypeChange> staffAppointmentTypeChanges = new List<StaffAppointmentTypeChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffAppointmentTypeChange staffAppointmentTypeChange = new StaffAppointmentTypeChange()
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

                            AppointmentType = new AppointmentType()
                            {
                                ID = row["AppointmentTypeID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeID"].ToString()),
                                Description = row["AppointmentType"] == DBNull.Value ? string.Empty : row["AppointmentType"].ToString(),
                            },
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        AppointmentTypeFrom = new AppointmentType()
                        {
                            ID = row["AppointmentTypeFromID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeFromID"].ToString()),
                            Description = row["AppointmentTypeFrom"] == DBNull.Value ? string.Empty : row["AppointmentTypeFrom"].ToString(),
                        },
                        AppointmentTypeTo = new AppointmentType()
                        {
                            ID = row["AppointmentTypeToID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeToID"].ToString()),
                            Description = row["AppointmentTypeTo"] == DBNull.Value ? string.Empty : row["AppointmentTypeTo"].ToString(),
                        },
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    staffAppointmentTypeChanges.Add(staffAppointmentTypeChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffAppointmentTypeChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffAppointmentTypeChange staffAppointmentTypeChange = (StaffAppointmentTypeChange)item;
                dal.ExecuteNonQuery("Update StaffAppointmentTypeChange Set Archived='True' Where ID=" + staffAppointmentTypeChange.ID);
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
