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
    public class StaffJobTitleChangeDataMapper
    {
        private DALHelper dal;

        public StaffJobTitleChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffJobTitleChange staffJobTitleChange = (StaffJobTitleChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffJobTitleChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffJobTitleChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffJobTitleChange.Date, DbType.DateTime);
                dal.CreateParameter("@JobTitleToID", staffJobTitleChange.JobTitleTo.ID, DbType.Int32);
                dal.CreateParameter("@JobTitleFromID", staffJobTitleChange.JobTitleFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffJobTitleChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffJobTitleChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffJobTitleChange.ApprovedUserStaffID, DbType.String);
                if (staffJobTitleChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffJobTitleChange.ApprovedDate, DbType.Date);
                }
                if (staffJobTitleChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffJobTitleChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffJobTitleChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffJobTitleChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffJobTitleChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffJobTitleChange (StaffID,StaffCode,Date,StaffJobTitleTo,StaffJobTitleFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@JobTitleToID,@JobTitleFromID,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffJobTitleChange staffJobTitleChange = (StaffJobTitleChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffJobTitleChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffJobTitleChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffJobTitleChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffJobTitleChange.Date, DbType.DateTime);
                dal.CreateParameter("@JobTitleToID", staffJobTitleChange.JobTitleTo.ID, DbType.Int32);
                dal.CreateParameter("@JobTitleFromID", staffJobTitleChange.JobTitleFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffJobTitleChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffJobTitleChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffJobTitleChange.ApprovedUserStaffID, DbType.String);
                if (staffJobTitleChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffJobTitleChange.ApprovedDate, DbType.Date);
                }
                if (staffJobTitleChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffJobTitleChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffJobTitleChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffJobTitleChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffJobTitleChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffJobTitleChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,StaffJobTitleTo=@JobTitleToID,StaffJobTitleFrom=@JobTitleFromID,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffJobTitleChange> GetAll()
        {
            try
            {
                IList<StaffJobTitleChange> staffJobTitleChanges = new List<StaffJobTitleChange>();
                DataTable table = dal.ExecuteReader("Select StaffJobTitleChangeView.*,StaffJobTitleChangeView.FirstName +' '+ StaffJobTitleChangeView.OtherName +' '+ StaffJobTitleChangeView.Surname as StaffName from StaffJobTitleChangeView where StaffJobTitleChangeView.Archived ='False' ORDER BY StaffJobTitleChangeView.ServerTime DESC,StaffJobTitleChangeView.StaffID ASC");
                foreach (StaffJobTitleChange sta in BuildStaffJobTitleChangeFromData(table))
                {
                    staffJobTitleChanges.Add(sta);
                }
                return staffJobTitleChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffJobTitleChange> GetByCriteria(Query query1)
        {
            IList<StaffJobTitleChange> staffJobTitleChanges = new List<StaffJobTitleChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffJobTitleChangeView.*,StaffJobTitleChangeView.FirstName +' '+ StaffJobTitleChangeView.OtherName +' '+ StaffJobTitleChangeView.Surname as StaffName from StaffJobTitleChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffJobTitleChangeView.Archived=@Archived  ORDER BY StaffJobTitleChangeView.ServerTime DESC,StaffJobTitleChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffJobTitleChange term in BuildStaffJobTitleChangeFromData(table))
                {
                    staffJobTitleChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffJobTitleChanges;
        }
        #endregion

        #region Get By ID
        public StaffJobTitleChange GetByID(object key)
        {
            StaffJobTitleChange staffJobTitleChange = new StaffJobTitleChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffJobTitleChangeView.*,StaffJobTitleChangeView.FirstName +' '+ StaffJobTitleChangeView.OtherName +' '+ StaffJobTitleChangeView.Surname as StaffName from StaffJobTitleChangeView ";
                query += "WHERE StaffJobTitleChangeView.ID=@ID And StaffJobTitleChangeView.Archived=@Archived order BY StaffJobTitleChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffJobTitleChange staf in BuildStaffJobTitleChangeFromData(table))
                {
                    staffJobTitleChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffJobTitleChange;
        }
        #endregion

        #region BuildStaffJobTitleChangeFromData
        private IList<StaffJobTitleChange> BuildStaffJobTitleChangeFromData(DataTable table)
        {
            IList<StaffJobTitleChange> staffJobTitleChanges = new List<StaffJobTitleChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffJobTitleChange staffJobTitleChange = new StaffJobTitleChange()
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
                            JobTitleDate = row["JobTitleDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["JobTitleDate"].ToString()),
                            JobTitle = new JobTitle()
                            {
                                ID = row["JobTitleID"] == DBNull.Value ? 0 : int.Parse(row["JobTitleID"].ToString()),
                                Description = row["JobTitle"] == DBNull.Value ? string.Empty : row["JobTitle"].ToString(),
                            },
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        JobTitleFrom = new JobTitle()
                        {
                            ID = row["StaffJobTitleFromID"] == DBNull.Value ? 0 : int.Parse(row["StaffJobTitleFromID"].ToString()),
                            Description = row["StaffJobTitleFrom"] == DBNull.Value ? string.Empty : row["StaffJobTitleFrom"].ToString(),
                        },
                        JobTitleTo = new JobTitle()
                        {
                            ID = row["StaffJobTitleToID"] == DBNull.Value ? 0 : int.Parse(row["StaffJobTitleToID"].ToString()),
                            Description = row["StaffJobTitleTo"] == DBNull.Value ? string.Empty : row["StaffJobTitleTo"].ToString(),
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
                    staffJobTitleChanges.Add(staffJobTitleChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffJobTitleChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffJobTitleChange staffJobTitleChange = (StaffJobTitleChange)item;
                dal.ExecuteNonQuery("Update StaffJobTitleChange Set Archived='True' Where ID=" + staffJobTitleChange.ID);
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
