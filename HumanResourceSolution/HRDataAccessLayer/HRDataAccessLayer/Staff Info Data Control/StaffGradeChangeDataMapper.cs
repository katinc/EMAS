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
    public class StaffGradeChangeDataMapper
    {
        private DALHelper dal;

        public StaffGradeChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffGradeChange staffGradeChange = (StaffGradeChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffGradeChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffGradeChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffGradeChange.Date, DbType.DateTime);
                dal.CreateParameter("@GradeCategoryToID", staffGradeChange.GradeCategoryTo.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryFromID", staffGradeChange.GradeCategoryFrom.ID, DbType.Int32);
                dal.CreateParameter("@GradeToID", staffGradeChange.GradeTo.ID, DbType.Int32);
                dal.CreateParameter("@GradeFromID", staffGradeChange.GradeFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffGradeChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffGradeChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffGradeChange.ApprovedUserStaffID, DbType.String);
                if (staffGradeChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffGradeChange.ApprovedDate, DbType.Date);
                }
                if (staffGradeChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffGradeChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffGradeChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffGradeChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffGradeChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffGradeChange (StaffID,StaffCode,Date,GradeCategoryFrom,GradeCategoryTo,GradeFrom,GradeTo,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@GradeCategoryFromID,@GradeCategoryToID,@GradeFromID,@GradeToID,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffGradeChange staffGradeChange = (StaffGradeChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffGradeChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffGradeChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffGradeChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffGradeChange.Date, DbType.DateTime);
                dal.CreateParameter("@GradeCategoryToID", staffGradeChange.GradeCategoryTo.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryFromID", staffGradeChange.GradeCategoryFrom.ID, DbType.Int32);
                dal.CreateParameter("@GradeToID", staffGradeChange.GradeTo.ID, DbType.Int32);
                dal.CreateParameter("@GradeFromID", staffGradeChange.GradeFrom.ID, DbType.Int32);
                dal.CreateParameter("@Approved", staffGradeChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffGradeChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffGradeChange.ApprovedUserStaffID, DbType.String);
                if (staffGradeChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffGradeChange.ApprovedDate, DbType.Date);
                }
                if (staffGradeChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffGradeChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffGradeChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffGradeChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffGradeChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffGradeChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,GradeCategoryFrom=@GradeCategoryFromID,GradeCategoryTo=@GradeCategoryToID,GradeFrom=@GradeFrom,GradeTo=@GradeTo,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffGradeChange> GetAll()
        {
            try
            {
                IList<StaffGradeChange> staffGradeChanges = new List<StaffGradeChange>();
                DataTable table = dal.ExecuteReader("Select StaffGradeChangeView.*,StaffGradeChangeView.FirstName +' '+ StaffGradeChangeView.OtherName +' '+ StaffGradeChangeView.Surname as StaffName from StaffGradeChangeView where StaffGradeChangeView.Archived ='False' ORDER BY StaffGradeChangeView.ServerTime DESC,StaffGradeChangeView.StaffID ASC");
                foreach (StaffGradeChange sta in BuildStaffGradeChangeFromData(table))
                {
                    staffGradeChanges.Add(sta);
                }
                return staffGradeChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffGradeChange> GetByCriteria(Query query1)
        {
            IList<StaffGradeChange> staffGradeChanges = new List<StaffGradeChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffGradeChangeView.*,StaffGradeChangeView.FirstName +' '+ StaffGradeChangeView.OtherName +' '+ StaffGradeChangeView.Surname as StaffName from StaffGradeChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffGradeChangeView.Archived=@Archived  ORDER BY StaffGradeChangeView.ServerTime DESC,StaffGradeChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffGradeChange term in BuildStaffGradeChangeFromData(table))
                {
                    staffGradeChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffGradeChanges;
        }
        #endregion

        #region Get By ID
        public StaffGradeChange GetByID(object key)
        {
            StaffGradeChange staffGradeChange = new StaffGradeChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffGradeChangeView.*,StaffGradeChangeView.FirstName +' '+ StaffGradeChangeView.OtherName +' '+ StaffGradeChangeView.Surname as StaffName from StaffGradeChangeView ";
                query += "WHERE StaffGradeChangeView.ID=@ID And StaffGradeChangeView.Archived=@Archived order BY StaffGradeChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffGradeChange staf in BuildStaffGradeChangeFromData(table))
                {
                    staffGradeChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffGradeChange;
        }
        #endregion

        #region BuildStaffGradeChangeFromData
        private IList<StaffGradeChange> BuildStaffGradeChangeFromData(DataTable table)
        {
            IList<StaffGradeChange> staffGradeChanges = new List<StaffGradeChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffGradeChange staffGradeChange = new StaffGradeChange()
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
                            GradeDate = row["GradeDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["GradeDate"].ToString()),
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
                        GradeCategoryFrom = new GradeCategory()
                        {
                            ID = row["GradeCategoryFromID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryFromID"].ToString()),
                            Description = row["GradeCategoryFrom"] == DBNull.Value ? string.Empty : row["GradeCategoryFrom"].ToString(),
                        },
                        GradeCategoryTo = new GradeCategory()
                        {
                            ID = row["GradeCategoryToID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryToID"].ToString()),
                            Description = row["GradeCategoryTo"] == DBNull.Value ? string.Empty : row["GradeCategoryTo"].ToString(),
                        },
                        GradeFrom = new EmployeeGrade()
                        {
                            ID = row["GradeFromID"] == DBNull.Value ? 0 : int.Parse(row["GradeFromID"].ToString()),
                            Grade = row["GradeFrom"] == DBNull.Value ? string.Empty : row["GradeFrom"].ToString(),
                        },
                        GradeTo = new EmployeeGrade()
                        {
                            ID = row["GradeToID"] == DBNull.Value ? 0 : int.Parse(row["GradeToID"].ToString()),
                            Grade = row["GradeTo"] == DBNull.Value ? string.Empty : row["GradeTo"].ToString(),
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
                    staffGradeChanges.Add(staffGradeChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffGradeChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffGradeChange staffGradeChange = (StaffGradeChange)item;
                dal.ExecuteNonQuery("Update StaffGradeChange Set Archived='True' Where ID=" + staffGradeChange.ID);
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
