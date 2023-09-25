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
    public class StaffNameChangeDataMapper
    {
        private DALHelper dal;

        public StaffNameChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffNameChange staffNameChange = (StaffNameChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffNameChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffNameChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffNameChange.Date, DbType.DateTime);
                dal.CreateParameter("@FirstNameFrom", staffNameChange.FirstNameFrom, DbType.String);
                dal.CreateParameter("@SurnameFrom", staffNameChange.SurnameFrom, DbType.String);
                dal.CreateParameter("@OtherNameFrom", staffNameChange.OtherNameFrom, DbType.String);
                dal.CreateParameter("@FirstNameTo", staffNameChange.FirstNameTo, DbType.String);
                dal.CreateParameter("@SurnameTo", staffNameChange.SurnameTo, DbType.String);
                dal.CreateParameter("@OtherNameTo", staffNameChange.OtherNameTo, DbType.String);
                dal.CreateParameter("@Approved", staffNameChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffNameChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffNameChange.ApprovedUserStaffID, DbType.String);
                if (staffNameChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffNameChange.ApprovedDate, DbType.Date);
                }
                if (staffNameChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffNameChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffNameChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffNameChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffNameChange.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO StaffNameChange (StaffID,StaffCode,Date,FirstNameTo,SurnameTo,OtherNameTo,FirstNameFrom,SurnameFrom,OtherNameFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@FirstNameTo,@SurnameTo,@OtherNameTo,@FirstNameFrom,@SurnameFrom,@OtherNameFrom,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffNameChange staffNameChange = (StaffNameChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffNameChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffNameChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffNameChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffNameChange.Date, DbType.DateTime);
                dal.CreateParameter("@FirstNameFrom", staffNameChange.FirstNameFrom, DbType.String);
                dal.CreateParameter("@SurnameFrom", staffNameChange.SurnameFrom, DbType.String);
                dal.CreateParameter("@OtherNameFrom", staffNameChange.OtherNameFrom, DbType.String);
                dal.CreateParameter("@FirstNameTo", staffNameChange.FirstNameTo, DbType.String);
                dal.CreateParameter("@SurnameTo", staffNameChange.SurnameTo, DbType.String);
                dal.CreateParameter("@OtherNameTo", staffNameChange.OtherNameTo, DbType.String);
                dal.CreateParameter("@Approved", staffNameChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffNameChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffNameChange.ApprovedUserStaffID, DbType.String);
                if (staffNameChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffNameChange.ApprovedDate, DbType.Date);
                }
                if (staffNameChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffNameChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffNameChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffNameChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffNameChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffNameChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,FirstNameTo=@FirstNameTo,SurnameTo=@SurnameTo,OtherNameTo=@OtherNameTo,FirstNameFrom=@FirstNameFrom,SurnameFrom=@SurnameFrom,OtherNameFrom=@OtherNameFrom,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffNameChange> GetAll()
        {
            try
            {
                IList<StaffNameChange> staffNameChanges = new List<StaffNameChange>();
                DataTable table = dal.ExecuteReader("Select StaffNameChangeView.*,StaffNameChangeView.FirstName +' '+ StaffNameChangeView.OtherName +' '+ StaffNameChangeView.Surname as StaffName from StaffNameChangeView where StaffNameChangeView.Archived ='False' ORDER BY StaffNameChangeView.ServerTime DESC,StaffNameChangeView.StaffID ASC");
                foreach (StaffNameChange sta in BuildStaffNameChangeFromData(table))
                {
                    staffNameChanges.Add(sta);
                }
                return staffNameChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffNameChange> GetByCriteria(Query query1)
        {
            IList<StaffNameChange> staffNameChanges = new List<StaffNameChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffNameChangeView.*,StaffNameChangeView.FirstName +' '+ StaffNameChangeView.OtherName +' '+ StaffNameChangeView.Surname as StaffName from StaffNameChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffNameChangeView.Archived=@Archived  ORDER BY StaffNameChangeView.ServerTime DESC,StaffNameChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffNameChange term in BuildStaffNameChangeFromData(table))
                {
                    staffNameChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffNameChanges;
        }
        #endregion

        #region Get By ID
        public StaffNameChange GetByID(object key)
        {
            StaffNameChange staffNameChange = new StaffNameChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffNameChangeView.*,StaffNameChangeView.FirstName +' '+ StaffNameChangeView.OtherName +' '+ StaffNameChangeView.Surname as StaffName from StaffNameChangeView ";
                query += "WHERE StaffNameChangeView.ID=@ID And StaffNameChangeView.Archived=@Archived order BY StaffNameChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffNameChange staf in BuildStaffNameChangeFromData(table))
                {
                    staffNameChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffNameChange;
        }
        #endregion

        #region BuildStaffNameChangeFromData
        private IList<StaffNameChange> BuildStaffNameChangeFromData(DataTable table)
        {
            IList<StaffNameChange> staffNameChanges = new List<StaffNameChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffNameChange staffNameChange = new StaffNameChange()
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
                            StaffStatus = new StaffStatus()
                            {
                                ID = row["StatusID"] == DBNull.Value ? 0 : int.Parse(row["StatusID"].ToString()),
                                Description = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString()
                            },
                            Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString()),
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        FirstNameFrom = row["FirstNameFrom"] == DBNull.Value ? string.Empty : row["FirstNameFrom"].ToString(),
                        SurnameFrom = row["SurnameFrom"] == DBNull.Value ? string.Empty : row["SurnameFrom"].ToString(),
                        OtherNameFrom = row["OtherNameFrom"] == DBNull.Value ? string.Empty : row["OtherNameFrom"].ToString(),
                        FirstNameTo = row["FirstNameTo"] == DBNull.Value ? string.Empty : row["FirstNameTo"].ToString(),
                        SurnameTo = row["SurnameTo"] == DBNull.Value ? string.Empty : row["SurnameTo"].ToString(),
                        OtherNameTo = row["OtherNameTo"] == DBNull.Value ? string.Empty : row["OtherNameTo"].ToString(),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    staffNameChanges.Add(staffNameChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffNameChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffNameChange staffNameChange = (StaffNameChange)item;
                dal.ExecuteNonQuery("Update StaffNameChange Set Archived='True' Where ID=" + staffNameChange.ID);
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
