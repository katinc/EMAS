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
    public class StaffDOBChangeDataMapper
    {
        private DALHelper dal;

        public StaffDOBChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffDOBChange staffDOBChange = (StaffDOBChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffDOBChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffDOBChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffDOBChange.Date, DbType.DateTime);
                dal.CreateParameter("@DOBTo", staffDOBChange.DOBTo, DbType.Date);
                dal.CreateParameter("@DOBFrom", staffDOBChange.DOBFrom, DbType.Date);
                dal.CreateParameter("@Approved", staffDOBChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffDOBChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffDOBChange.ApprovedUserStaffID, DbType.String);
                if (staffDOBChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffDOBChange.ApprovedDate, DbType.Date);
                }
                if (staffDOBChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffDOBChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffDOBChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffDOBChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffDOBChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffDOBChange (StaffID,StaffCode,Date,DOBTo,DOBFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@DOBTo,@DOBFrom,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffDOBChange staffDOBChange = (StaffDOBChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffDOBChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffDOBChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffDOBChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffDOBChange.Date, DbType.DateTime);
                dal.CreateParameter("@DOBTo", staffDOBChange.DOBTo, DbType.Date);
                dal.CreateParameter("@DOBFrom", staffDOBChange.DOBFrom, DbType.Date);
                dal.CreateParameter("@Approved", staffDOBChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffDOBChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffDOBChange.ApprovedUserStaffID, DbType.String);
                if (staffDOBChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffDOBChange.ApprovedDate, DbType.Date);
                }
                if (staffDOBChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffDOBChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffDOBChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffDOBChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffDOBChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffDOBChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,DOBTo=@DOBTo,DOBFrom=@DOBFrom,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffDOBChange> GetAll()
        {
            try
            {
                IList<StaffDOBChange> staffDOBChanges = new List<StaffDOBChange>();
                DataTable table = dal.ExecuteReader("Select StaffDOBChangeView.*,StaffDOBChangeView.FirstName +' '+ StaffDOBChangeView.OtherName +' '+ StaffDOBChangeView.Surname as StaffName from StaffDOBChangeView where StaffDOBChangeView.Archived ='False' ORDER BY StaffDOBChangeView.ServerTime DESC,StaffDOBChangeView.StaffID ASC");
                foreach (StaffDOBChange sta in BuildStaffDOBChangeFromData(table))
                {
                    staffDOBChanges.Add(sta);
                }
                return staffDOBChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffDOBChange> GetByCriteria(Query query1)
        {
            IList<StaffDOBChange> staffDOBChanges = new List<StaffDOBChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffDOBChangeView.*,StaffDOBChangeView.FirstName +' '+ StaffDOBChangeView.OtherName +' '+ StaffDOBChangeView.Surname as StaffName from StaffDOBChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffDOBChangeView.Archived=@Archived  ORDER BY StaffDOBChangeView.ServerTime DESC,StaffDOBChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffDOBChange term in BuildStaffDOBChangeFromData(table))
                {
                    staffDOBChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDOBChanges;
        }
        #endregion

        #region Get By ID
        public StaffDOBChange GetByID(object key)
        {
            StaffDOBChange staffDOBChange = new StaffDOBChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffDOBChangeView.*,StaffDOBChangeView.FirstName +' '+ StaffDOBChangeView.OtherName +' '+ StaffDOBChangeView.Surname as StaffName from StaffDOBChangeView ";
                query += "WHERE StaffDOBChangeView.ID=@ID And StaffDOBChangeView.Archived=@Archived order BY StaffDOBChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffDOBChange staf in BuildStaffDOBChangeFromData(table))
                {
                    staffDOBChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDOBChange;
        }
        #endregion

        #region BuildStaffDOBChangeFromData
        private IList<StaffDOBChange> BuildStaffDOBChangeFromData(DataTable table)
        {
            IList<StaffDOBChange> staffDOBChanges = new List<StaffDOBChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffDOBChange staffDOBChange = new StaffDOBChange()
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
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                            DOB = row["DOB"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        DOBFrom = row["DOBFrom"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOBFrom"].ToString()),
                        DOBTo = row["DOBTo"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOBTo"].ToString()),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    staffDOBChanges.Add(staffDOBChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDOBChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffDOBChange staffDOBChange = (StaffDOBChange)item;
                dal.ExecuteNonQuery("Update StaffDOBChange Set Archived='True' Where ID=" + staffDOBChange.ID);
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
