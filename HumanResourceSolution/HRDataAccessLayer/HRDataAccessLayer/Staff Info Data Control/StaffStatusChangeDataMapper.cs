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
    public class StaffStatusChangeDataMapper
    {
        private DALHelper dal;

        public StaffStatusChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffStatusChange staffStatusChange = (StaffStatusChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffStatusChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffStatusChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffStatusChange.Date, DbType.DateTime);
                dal.CreateParameter("@StatusToID", staffStatusChange.StaffStatusTo.ID, DbType.Int32);
                dal.CreateParameter("@StatusFromID", staffStatusChange.StaffStatusFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffStatusChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffStatusChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffStatusChange.ApprovedUserStaffID, DbType.String);
                if (staffStatusChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffStatusChange.ApprovedDate, DbType.Date);
                }
                if (staffStatusChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffStatusChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffStatusChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffStatusChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffStatusChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffStatusChange (StaffID,StaffCode,Date,StatusTo,StatusFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@StatusToID,@StatusFromID,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffStatusChange staffStatusChange = (StaffStatusChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffStatusChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffStatusChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffStatusChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffStatusChange.Date, DbType.DateTime);
                dal.CreateParameter("@StatusToID", staffStatusChange.StaffStatusTo.ID, DbType.Int32);
                dal.CreateParameter("@StatusFromID", staffStatusChange.StaffStatusFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffStatusChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffStatusChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffStatusChange.ApprovedUserStaffID, DbType.String);
                if (staffStatusChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffStatusChange.ApprovedDate, DbType.Date);
                }
                if (staffStatusChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffStatusChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffStatusChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffStatusChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffStatusChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffStatusChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,StatusTo=@StatusToID,StatusFrom=@StatusFromID,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffStatusChange> GetAll()
        {
            try
            {
                IList<StaffStatusChange> staffStatusChanges = new List<StaffStatusChange>();
                DataTable table = dal.ExecuteReader("Select StaffStatusChangeView.*,StaffStatusChangeView.FirstName +' '+ StaffStatusChangeView.OtherName +' '+ StaffStatusChangeView.Surname as StaffName from StaffStatusChangeView where StaffStatusChangeView.Archived ='False' ORDER BY StaffStatusChangeView.ServerTime DESC,StaffStatusChangeView.StaffID ASC");
                foreach (StaffStatusChange sta in BuildStaffStatusChangeFromData(table))
                {
                    staffStatusChanges.Add(sta);
                }
                return staffStatusChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffStatusChange> GetByCriteria(Query query1)
        {
            IList<StaffStatusChange> staffStatusChanges = new List<StaffStatusChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffStatusChangeView.*,StaffStatusChangeView.FirstName +' '+ StaffStatusChangeView.OtherName +' '+ StaffStatusChangeView.Surname as StaffName from StaffStatusChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffStatusChangeView.Archived=@Archived  ORDER BY StaffStatusChangeView.ServerTime DESC,StaffStatusChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffStatusChange term in BuildStaffStatusChangeFromData(table))
                {
                    staffStatusChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffStatusChanges;
        }
        #endregion

        #region Get By ID
        public StaffStatusChange GetByID(object key)
        {
            StaffStatusChange staffAppointmentTypeChange = new StaffStatusChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffStatusChangeView.*,StaffStatusChangeView.FirstName +' '+ StaffStatusChangeView.OtherName +' '+ StaffStatusChangeView.Surname as StaffName from StaffStatusChangeView ";
                query += "WHERE StaffStatusChangeView.ID=@ID And StaffStatusChangeView.Archived=@Archived order BY StaffStatusChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffStatusChange staf in BuildStaffStatusChangeFromData(table))
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

        #region BuildStaffStatusChangeFromData
        private IList<StaffStatusChange> BuildStaffStatusChangeFromData(DataTable table)
        {
            IList<StaffStatusChange> staffStatusChanges = new List<StaffStatusChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffStatusChange staffStatusChange = new StaffStatusChange()
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
                            StaffStatus = new StaffStatus()
                            {
                                ID = row["StatusID"] == DBNull.Value ? 0 : int.Parse(row["StatusID"].ToString()),
                                Description = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString()
                            },
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        StaffStatusFrom = new StaffStatus()
                        {
                            ID = row["StatusFromID"] == DBNull.Value ? 0 : int.Parse(row["StatusFromID"].ToString()),
                            Description = row["StatusFrom"] == DBNull.Value ? string.Empty : row["StatusFrom"].ToString(),
                        },
                        StaffStatusTo = new StaffStatus()
                        {
                            ID = row["StatusToID"] == DBNull.Value ? 0 : int.Parse(row["StatusToID"].ToString()),
                            Description = row["StatusTo"] == DBNull.Value ? string.Empty : row["StatusTo"].ToString(),
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
                    staffStatusChanges.Add(staffStatusChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffStatusChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffStatusChange staffStatusChange = (StaffStatusChange)item;
                dal.ExecuteNonQuery("Update StaffStatusChange Set Archived='True' Where ID=" + staffStatusChange.ID);
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
