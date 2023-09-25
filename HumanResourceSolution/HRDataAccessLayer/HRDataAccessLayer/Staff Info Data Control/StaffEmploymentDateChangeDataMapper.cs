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
    public class StaffEmploymentDateChangeDataMapper
    {
        private DALHelper dal;

        public StaffEmploymentDateChangeDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                StaffEmploymentDateChange staffEmploymentDateChange = (StaffEmploymentDateChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffEmploymentDateChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffEmploymentDateChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffEmploymentDateChange.Date, DbType.DateTime);

                if (staffEmploymentDateChange.EmploymentDateTo == null)
                {
                    dal.CreateParameter("@EmploymentDateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EmploymentDateTo", staffEmploymentDateChange.EmploymentDateTo, DbType.Date);
                }
                if (staffEmploymentDateChange.EmploymentDateFrom == null)
                {
                    dal.CreateParameter("@EmploymentDateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EmploymentDateFrom", staffEmploymentDateChange.EmploymentDateFrom, DbType.Date);
                }

                if (staffEmploymentDateChange.AssumptionDateFrom == null)
                {
                    dal.CreateParameter("@AssumptionDateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AssumptionDateFrom", staffEmploymentDateChange.AssumptionDateFrom, DbType.Date);
                }
                if (staffEmploymentDateChange.AssumptionDateTo == null)
                {
                    dal.CreateParameter("@AssumptionDateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AssumptionDateTo", staffEmploymentDateChange.AssumptionDateTo, DbType.Date);
                }

                if (staffEmploymentDateChange.DOFADateFrom == null)
                {
                    dal.CreateParameter("@DOFADateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOFADateFrom", staffEmploymentDateChange.DOFADateFrom, DbType.Date);
                }
                if (staffEmploymentDateChange.DOFADateTo == null)
                {
                    dal.CreateParameter("@DOFADateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOFADateTo", staffEmploymentDateChange.DOFADateTo, DbType.Date);
                }

                dal.CreateParameter("@Approved", staffEmploymentDateChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffEmploymentDateChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffEmploymentDateChange.ApprovedUserStaffID, DbType.String);
                if (staffEmploymentDateChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffEmploymentDateChange.ApprovedDate, DbType.Date);
                }
                if (staffEmploymentDateChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffEmploymentDateChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffEmploymentDateChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffEmploymentDateChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffEmploymentDateChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO StaffEmploymentDateChange (StaffID,StaffCode,Date,EmploymentDateTo,EmploymentDateFrom,AssumptionDateTo,AssumptionDateFrom,DOFADateTo,DOFADateFrom,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Description,Reason,CreateUserID) VALUES(@StaffID,@StaffCode,@Date,@EmploymentDateTo,@EmploymentDateFrom,@AssumptionDateTo,@AssumptionDateFrom,@DOFADateTo,@DOFADateFrom,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Description,@Reason,@UserID)");
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
                StaffEmploymentDateChange staffEmploymentDateChange = (StaffEmploymentDateChange)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffEmploymentDateChange.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffEmploymentDateChange.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffEmploymentDateChange.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Date", staffEmploymentDateChange.Date, DbType.DateTime);
                if (staffEmploymentDateChange.EmploymentDateTo == null)
                {
                    dal.CreateParameter("@EmploymentDateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EmploymentDateTo", staffEmploymentDateChange.EmploymentDateTo, DbType.Date);
                }
                if (staffEmploymentDateChange.EmploymentDateFrom == null)
                {
                    dal.CreateParameter("@EmploymentDateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EmploymentDateFrom", staffEmploymentDateChange.EmploymentDateFrom, DbType.Date);
                }

                if (staffEmploymentDateChange.AssumptionDateFrom == null)
                {
                    dal.CreateParameter("@AssumptionDateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AssumptionDateFrom", staffEmploymentDateChange.AssumptionDateFrom, DbType.Date);
                }
                if (staffEmploymentDateChange.AssumptionDateTo == null)
                {
                    dal.CreateParameter("@AssumptionDateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AssumptionDateTo", staffEmploymentDateChange.AssumptionDateTo, DbType.Date);
                }

                if (staffEmploymentDateChange.DOFADateFrom == null)
                {
                    dal.CreateParameter("@DOFADateFrom", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOFADateFrom", staffEmploymentDateChange.DOFADateFrom, DbType.Date);
                }
                if (staffEmploymentDateChange.DOFADateTo == null)
                {
                    dal.CreateParameter("@DOFADateTo", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOFADateTo", staffEmploymentDateChange.DOFADateTo, DbType.Date);
                }
                dal.CreateParameter("@Approved", staffEmploymentDateChange.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", staffEmploymentDateChange.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", staffEmploymentDateChange.ApprovedUserStaffID, DbType.String);
                if (staffEmploymentDateChange.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", staffEmploymentDateChange.ApprovedDate, DbType.Date);
                }
                if (staffEmploymentDateChange.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", staffEmploymentDateChange.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", staffEmploymentDateChange.Reason, DbType.String);
                dal.CreateParameter("@Description", staffEmploymentDateChange.Description, DbType.String);
                dal.CreateParameter("@UserID", staffEmploymentDateChange.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE StaffEmploymentDateChange Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,EmploymentDateTo=@EmploymentDateTo,AssumptionDateTo=@AssumptionDateTo,DOFADateTo=@DOFADateTo,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Description=@Description,Reason=@Reason,CreateUserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffEmploymentDateChange> GetAll()
        {
            try
            {
                IList<StaffEmploymentDateChange> staffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
                DataTable table = dal.ExecuteReader("Select StaffEmploymentDateChangeView.*,StaffEmploymentDateChangeView.FirstName +' '+ StaffEmploymentDateChangeView.OtherName +' '+ StaffEmploymentDateChangeView.Surname as StaffName from StaffEmploymentDateChangeView where StaffEmploymentDateChangeView.Archived ='False' ORDER BY StaffEmploymentDateChangeView.ServerTime DESC,StaffEmploymentDateChangeView.StaffID ASC");
                foreach (StaffEmploymentDateChange sta in BuildStaffEmploymentDateChangeFromData(table))
                {
                    staffEmploymentDateChanges.Add(sta);
                }
                return staffEmploymentDateChanges;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffEmploymentDateChange> GetByCriteria(Query query1)
        {
            IList<StaffEmploymentDateChange> staffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select StaffEmploymentDateChangeView.*,StaffEmploymentDateChangeView.FirstName +' '+ StaffEmploymentDateChangeView.OtherName +' '+ StaffEmploymentDateChangeView.Surname as StaffName from StaffEmploymentDateChangeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffEmploymentDateChangeView.Archived=@Archived  ORDER BY StaffEmploymentDateChangeView.ServerTime DESC,StaffEmploymentDateChangeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffEmploymentDateChange term in BuildStaffEmploymentDateChangeFromData(table))
                {
                    staffEmploymentDateChanges.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffEmploymentDateChanges;
        }
        #endregion

        #region Get By ID
        public StaffEmploymentDateChange GetByID(object key)
        {
            StaffEmploymentDateChange staffEmploymentDateChange = new StaffEmploymentDateChange();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select StaffEmploymentDateChangeView.*,StaffEmploymentDateChangeView.FirstName +' '+ StaffEmploymentDateChangeView.OtherName +' '+ StaffEmploymentDateChangeView.Surname as StaffName from StaffEmploymentDateChangeView ";
                query += "WHERE StaffEmploymentDateChangeView.ID=@ID And StaffEmploymentDateChangeView.Archived=@Archived order BY StaffEmploymentDateChangeView.ServerTime DESC";

                table = dal.ExecuteReader(query);
                foreach (StaffEmploymentDateChange staf in BuildStaffEmploymentDateChangeFromData(table))
                {
                    staffEmploymentDateChange = staf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffEmploymentDateChange;
        }
        #endregion

        #region BuildStaffEmploymentDateChangeFromData
        private IList<StaffEmploymentDateChange> BuildStaffEmploymentDateChangeFromData(DataTable table)
        {
            IList<StaffEmploymentDateChange> staffEmploymentDateChanges = new List<StaffEmploymentDateChange>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffEmploymentDateChange staffEmploymentDateChange = new StaffEmploymentDateChange()
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
                            DOB = row["DOB"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        User = new User()
                        {
                            ID = row["CreateUserID"] == DBNull.Value ? 0 : int.Parse(row["CreateUserID"].ToString()),
                        },
                        EmploymentDateFrom = row["EmploymentDateFrom"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDateFrom"].ToString()),
                        EmploymentDateTo = row["EmploymentDateTo"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDateTo"].ToString()),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                        Description = row["Description"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    staffEmploymentDateChanges.Add(staffEmploymentDateChange);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffEmploymentDateChanges;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                StaffEmploymentDateChange staffEmploymentDateChange = (StaffEmploymentDateChange)item;
                dal.ExecuteNonQuery("Update StaffEmploymentDateChange Set Archived='True' Where ID=" + staffEmploymentDateChange.ID);
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
