using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control
{
    public class LeaveDataMapper
    {
        private DALHelper dal;
        private Leave leave;

        public LeaveDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.leave = new Leave();
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
                Leave leave = (Leave)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode",leave.Employee.ID , DbType.Int32);
                dal.CreateParameter("@StaffID", leave.Employee.StaffID, DbType.String);
                dal.CreateParameter("@LeaveType", leave.LeaveType,DbType.String);
                dal.CreateParameter("@Status", leave.Status, DbType.String);
                if (leave.StartDate == null)
                {
                    dal.CreateParameter("@StartDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@StartDate", leave.StartDate, DbType.Date);
                }
                if (leave.EndDate == null)
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", leave.EndDate, DbType.Date);
                }
                if (leave.LeaveDate == null)
                {
                    dal.CreateParameter("@LeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@LeaveDate", leave.LeaveDate, DbType.Date);
                }
                
                dal.CreateParameter("@NumberOfDays", leave.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Reason", leave.Reason, DbType.String);
                dal.CreateParameter("@UserID", leave.User.ID, DbType.Int32);
                dal.CreateParameter("@Institution", leave.Institution, DbType.String);
                dal.CreateParameter("@Programme", leave.Programme, DbType.String);
                dal.CreateParameter("@Duration", leave.Duration, DbType.String);
                dal.CreateParameter("@LeaveYear", leave.LeaveYear, DbType.Int32);
                dal.CreateParameter("@Funding", leave.Funding, DbType.String);
                dal.CreateParameter("@ProgramType", leave.ProgramType, DbType.String);

                dal.ExecuteNonQuery("INSERT INTO StaffLeave (StaffID,StaffCode,LeaveType,Status,StartDate,EndDate,LeaveDate,NumberOfDays,Reason,UserID,Institution,Programme,Duration,LeaveYear , Funding, ProgramType) VALUES(@StaffID,@StaffCode,@LeaveType,@Status,@StartDate,@EndDate,@LeaveDate,@NumberOfDays,@Reason,@UserID,@Institution,@Programme,@Duration,@LeaveYear, @Funding, @ProgramType)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public int SaveLeave(Leave item)
        {
            try
            {
                Leave leave = item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", leave.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", leave.Employee.StaffID, DbType.String);
                dal.CreateParameter("@LeaveType", leave.LeaveType, DbType.String);
                dal.CreateParameter("@Status", leave.Status, DbType.String);
                if (leave.StartDate == null)
                {
                    dal.CreateParameter("@StartDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@StartDate", leave.StartDate, DbType.Date);
                }
                if (leave.EndDate == null)
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", leave.EndDate, DbType.Date);
                }
                if (leave.LeaveDate == null)
                {
                    dal.CreateParameter("@LeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@LeaveDate", leave.LeaveDate, DbType.Date);
                }

                dal.CreateParameter("@NumberOfDays", leave.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Reason", leave.Reason, DbType.String);
                dal.CreateParameter("@UserID", leave.User.ID, DbType.Int32);
                dal.CreateParameter("@Institution", leave.Institution, DbType.String);
                dal.CreateParameter("@Programme", leave.Programme, DbType.String);
                dal.CreateParameter("@Duration", leave.Duration, DbType.String);
                dal.CreateParameter("@LeaveYear", leave.LeaveYear, DbType.Int32);
                dal.CreateParameter("@Funding", leave.Funding, DbType.String);
                dal.CreateParameter("@ProgramType", leave.ProgramType, DbType.String);


                var ID = dal.ExecuteScalar("INSERT INTO StaffLeave (StaffID,StaffCode,LeaveType,Status,StartDate,EndDate,LeaveDate,NumberOfDays,Reason,UserID,Institution,Programme,Duration,LeaveYear, Funding, ProgramType) " +
                    "VALUES(@StaffID,@StaffCode,@LeaveType,@Status,@StartDate,@EndDate,@LeaveDate,@NumberOfDays,@Reason,@UserID,@Institution,@Programme,@Duration,@LeaveYear, @Funding, @ProgramType);select MAX(ID) from StaffLeave");


                if (ID != null && ID.ToString() != string.Empty)
                {
                    return Convert.ToInt32(ID);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

            }
            return 0;
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Leave leave = (Leave)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", leave.ID, DbType.String);
                dal.CreateParameter("@StaffCode", leave.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", leave.Employee.StaffID, DbType.String);
                dal.CreateParameter("@LeaveType", leave.LeaveType, DbType.String);
                dal.CreateParameter("@Status", leave.Status, DbType.String);
                if (leave.StartDate == null)
                {
                    dal.CreateParameter("@StartDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@StartDate", leave.StartDate, DbType.Date);
                }
                if (leave.EndDate == null)
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", leave.EndDate, DbType.Date);
                }
                if (leave.LeaveDate == null)
                {
                    dal.CreateParameter("@LeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@LeaveDate", leave.LeaveDate, DbType.Date);
                }
                dal.CreateParameter("@NumberOfDays", leave.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Reason", leave.Reason, DbType.String);
                dal.CreateParameter("@Approved", leave.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", leave.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", leave.ApprovedUserStaffID, DbType.String);
                if (leave.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", leave.ApprovedDate, DbType.Date);
                }
                if (leave.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", leave.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Recommended", leave.Recommended, DbType.Boolean);
                dal.CreateParameter("@RecommendedUser", leave.RecommendedUser, DbType.String);
                dal.CreateParameter("@RecommendedUserStaffID", leave.RecommendedUserStaffID, DbType.String);
                if (leave.RecommendedDate == null)
                {
                    dal.CreateParameter("@RecommendedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@RecommendedDate", leave.RecommendedDate, DbType.Date);
                }
                if (leave.RecommendedTime == null)
                {
                    dal.CreateParameter("@RecommendedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@RecommendedTime", leave.RecommendedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Rejected", leave.Rejected, DbType.Boolean);
                dal.CreateParameter("@RejectedUser", leave.RejectedUser, DbType.String);
                dal.CreateParameter("@RejectedUserStaffID", leave.RejectedUserStaffID, DbType.String);
                if (leave.RejectedDate == null)
                {
                    dal.CreateParameter("@RejectedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@RejectedDate", leave.RejectedDate, DbType.Date);
                }
                if (leave.RejectedTime == null)
                {
                    dal.CreateParameter("@RejectedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@RejectedTime", leave.RejectedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Resumed", leave.Resumed, DbType.Boolean);
                dal.CreateParameter("@ResumedUser", leave.ResumedUser, DbType.String);
                dal.CreateParameter("@ResumedUserStaffID", leave.ResumedUserStaffID, DbType.String);
                if (leave.ResumedDate == null)
                {
                    dal.CreateParameter("@ResumedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ResumedDate", leave.ResumedDate, DbType.Date);
                }
                if (leave.ResumedTime == null)
                {
                    dal.CreateParameter("@ResumedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ResumedTime", leave.ResumedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Recalled", leave.Recalled, DbType.Boolean);
                dal.CreateParameter("@RecalledUser", leave.RecalledUser, DbType.String);
                dal.CreateParameter("@RecalledUserStaffID", leave.RecalledUserStaffID, DbType.String);
                dal.CreateParameter("@RecalledReason", leave.RecalledReason, DbType.String);
                dal.CreateParameter("@RemainingNumberOfDays", leave.RemainingNumberOfDays, DbType.Decimal);
                if (leave.RecalledDate == null)
                {
                    dal.CreateParameter("@RecalledDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@RecalledDate", leave.RecalledDate, DbType.Date);
                }
                if (leave.RecalledTime == null)
                {
                    dal.CreateParameter("@RecalledTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@RecalledTime", leave.RecalledTime, DbType.DateTime);
                }

                dal.CreateParameter("@UserID", leave.User.ID, DbType.Int32);
                dal.CreateParameter("@Institution", leave.Institution, DbType.String);
                dal.CreateParameter("@Programme", leave.Programme, DbType.String);
                dal.CreateParameter("@Duration", leave.Duration, DbType.String);

                dal.CreateParameter("@RecommendationReason", leave.RecommendationReason, DbType.String);
                dal.CreateParameter("@ApprovalReason", leave.ApprovalReason, DbType.String);

                dal.CreateParameter("@Funding", leave.Funding, DbType.String);
                dal.CreateParameter("@ProgramType", leave.ProgramType, DbType.String);

                dal.ExecuteNonQuery("Update StaffLeave Set StaffID=@StaffID,StaffCode=@StaffCode,LeaveType=@LeaveType,Status=@Status,StartDate=@StartDate,EndDate=@EndDate,LeaveDate=@LeaveDate,Reason=@Reason,NumberOfDays=@NumberOfDays,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedDate=@ApprovedDate,ApprovedTime=@ApprovedTime,Recommended=@Recommended,RecommendedUser=@RecommendedUser,RecommendedUserStaffID=@RecommendedUserStaffID,RecommendedDate=@RecommendedDate,RecommendedTime=@RecommendedTime,Rejected=@Rejected,RejectedUser=@RejectedUser,RejectedUserStaffID=@RejectedUserStaffID,RejectedDate=@RejectedDate,RejectedTime=@RejectedTime,Resumed=@Resumed,ResumedUser=@ResumedUser,ResumedUserStaffID=@ResumedUserStaffID,ResumedDate=@ResumedDate,ResumedTime=@ResumedTime,Recalled=@Recalled,RecalledUser=@RecalledUser,RecalledUserStaffID=@RecalledUserStaffID,RecalledReason=@RecalledReason,RemainingNumberOfDays=@RemainingNumberOfDays,RecalledDate=@RecalledDate,RecalledTime=@RecalledTime,UserID=@UserID,Institution=@Institution,Programme=@Programme,Duration=@Duration, RecommendationReason=@RecommendationReason, ApprovalReason=@ApprovalReason, Funding = @Funding, ProgramType = @ProgramType Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Leave> GetAll()
        {
            IList<Leave> leaves = new List<Leave>();
            try
            {
                string query = "select StaffLeaveView.*,StaffLeaveView.Firstname +' '+ StaffLeaveView.OtherName +' '+ StaffLeaveView.Surname as StaffName From StaffLeaveView ";
                query += " Where StaffLeaveView.Archived ='False' Order by DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Leave lea in BuildLeaveFromData(table))
                {
                    leaves.Add(lea);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaves;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                Leave leave = (Leave)item;
                dal.ExecuteNonQuery("Update StaffLeave Set Archived ='True' Where ID="+ leave.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<Leave> GetByCriteria(Query query1)
        {
            IList<Leave> leaves = new List<Leave>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                string query = "select StaffLeaveView.*,StaffLeaveView.Firstname +' '+ StaffLeaveView.OtherName +' '+ StaffLeaveView.Surname as StaffName From StaffLeaveView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                string suffix = "And ";
                if (selectStatement.EndsWith(suffix))
                {
                    selectStatement = selectStatement.Substring(0, selectStatement.Length - suffix.Length);
                }
                selectStatement += "  Order by DateAndTimeGenerated DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Leave lea in BuildLeaveFromData(table))
                {
                    leaves.Add(lea);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaves;
        }
        #endregion

        #region Get By ID
        public Leave GetByID(object key)
        {
            Leave leave = new Leave();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString().Trim(), DbType.String);
                string query = "select StaffLeaveView.*,StaffLeaveView.Firstname +' '+ StaffLeaveView.OtherName +' '+ StaffLeaveView.Surname as StaffName From StaffLeaveView ";
                query += "WHERE StaffLeaveView.ID=@ID And StaffLeaveView.Archived=@Archived  ORDER BY DateAndTimeGenerated DESC";

                table = dal.ExecuteReader(query);
                foreach (Leave lea in BuildLeaveFromData(table))
                {
                    leave = lea;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leave;
        }
        #endregion

        #region LazyLoadByStaffID
        public Leave LazyLoadByStaffID(object item)
        {
            Leave leave = new Leave();
            try
            {
                Leave leav = (Leave)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", leav.Archived, DbType.Boolean);
                dal.CreateParameter("@StaffID", leav.Employee.StaffID, DbType.String);
                string query = "select StaffLeaveView.*,StaffLeaveView.Firstname +' '+ StaffLeaveView.OtherName +' '+ StaffLeaveView.Surname as StaffName From StaffLeaveView  Where Archived=@Archived and StaffID=@StaffID ORDER BY DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Leave mc in BuildLeaveFromData(table))
                {
                    leave = mc;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leave;
        }
        #endregion

        #region BuildLeaveFromData
        private IList<Leave> BuildLeaveFromData(DataTable table)
        {
            IList<Leave> leaves = new List<Leave>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    var id = int.Parse(row["ID"].ToString());
                    Leave leave = new Leave()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                            Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString(),
                            Zone = new Zone() { ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()), Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString() },
                            Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() },
                            Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() },
                            GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString() },
                            Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() },
                            OnLeave = row["OnLeave"] == DBNull.Value ? false : bool.Parse(row["OnLeave"].ToString()),
                            OnLeaveWithPay = row["OnLeaveWithPay"] == DBNull.Value ? false : bool.Parse(row["OnLeaveWithPay"].ToString()),
                            CurrentLeaveDate = row["CurrentLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveDate"].ToString()),
                            CurrentLeaveStartDate = row["CurrentLeaveStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveStartDate"].ToString()),
                            CurrentLeaveEndDate = row["CurrentLeaveEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveEndDate"].ToString()),
                            AnnualLeave = row["AnnualLeave"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeave"].ToString()),
                            AnnualLeaveYear = int.Parse(row["AnnualLeaveYear"].ToString()),
                            AnnualLeaveDate = row["AnnualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveDate"].ToString()),
                            AnnualLeaveEntitlement = new AnnualLeaveEntitlement()
                            {
                                ID = row["AnnualLeaveEntitlementID"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveEntitlementID"].ToString()),
                                CategoryOfPost = row["CategoryOfPost"] == DBNull.Value ? string.Empty : row["CategoryOfPost"].ToString(),
                                NumberOfDays = row["CurrentNumberOfDays"] == DBNull.Value ? 0 : int.Parse(row["CurrentNumberOfDays"].ToString()),
                                TypeOfGrade = row["TypesOfGrade"] == DBNull.Value ? string.Empty : row["TypesOfGrade"].ToString(),
                                Status = row["AnnualLeaveStatus"] == DBNull.Value ? string.Empty : row["AnnualLeaveStatus"].ToString(),
                            },
                            CasualLeave = row["CasualLeave"] == DBNull.Value ? 0 : int.Parse(row["CasualLeave"].ToString()),
                            CasualLeaveDate = row["CasualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CasualLeaveDate"].ToString()),
                            LeaveArrears = row["LeaveArrears"] == DBNull.Value ? 0 : int.Parse(row["LeaveArrears"].ToString()),
                            LeaveBalance = row["LeaveBalance"] == DBNull.Value ? 0 : int.Parse(row["LeaveBalance"].ToString()),
                            LeaveTaken = row["LeaveTaken"] == DBNull.Value ? 0 : int.Parse(row["LeaveTaken"].ToString()),
                        },
                        StaffName = row["StaffName"].ToString(),
                        LeaveType = row["LeaveType"].ToString(),
                        Status = row["Status"].ToString(),
                        EndDate = DateTime.Parse(row["EndDate"].ToString()),
                        StartDate = DateTime.Parse(row["StartDate"].ToString()),
                        LeaveDate = DateTime.Parse(row["LeaveDate"].ToString()),
                        Reason = row["Reason"].ToString(),
                        NumberOfDays = decimal.Parse(row["NumberOfDays"].ToString()),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Recommended = bool.Parse(row["Recommended"].ToString()),
                        RecommendedUser = row["RejectedUser"].ToString(),
                        RecommendedUserStaffID = row["RecommendedUserStaffID"].ToString(),
                        RecommendedDate = row["RecommendedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RecommendedDate"].ToString()),
                        RecommendedTime = row["RecommendedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RecommendedTime"].ToString()),
                        Rejected = bool.Parse(row["Rejected"].ToString()),
                        RejectedUser = row["RejectedUser"].ToString(),
                        RejectedUserStaffID = row["RejectedUserStaffID"].ToString(),
                        RejectedDate = row["RejectedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RejectedDate"].ToString()),
                        RejectedTime = row["RejectedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RejectedTime"].ToString()),
                        Resumed = bool.Parse(row["Resumed"].ToString()),
                        ResumedUser = row["ResumedUser"].ToString(),
                        ResumedUserStaffID = row["ResumedUserStaffID"].ToString(),
                        ResumedDate = row["ResumedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ResumedDate"].ToString()),
                        ResumedTime = row["ResumedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ResumedTime"].ToString()),
                        Recalled = bool.Parse(row["Recalled"].ToString()),
                        RecalledUser = row["RecalledUser"].ToString(),
                        RecalledUserStaffID = row["RecalledUserStaffID"].ToString(),
                        RecalledReason = row["RecalledReason"].ToString(),
                        RemainingNumberOfDays = decimal.Parse(row["RemainingNumberOfDays"].ToString()),
                        RecalledDate = row["RecalledDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RecalledDate"].ToString()),
                        RecalledTime = row["RecalledTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["RecalledTime"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                        },
                        Institution = row["Institution"].ToString(),
                        Programme = row["Programme"].ToString(),
                        Duration = row["Duration"].ToString(),
                        DateAndTimeGenerated = DateTime.Parse(row["DateAndTimeGenerated"].ToString()),

                        ApprovalReason = row["ApprovalReason"].ToString(),
                        RecommendationReason = row["RecommendationReason"].ToString(),
                        Funding = row["Funding"].ToString(),
                        ProgramType = row["ProgramType"].ToString(),
                    };
                    leaves.Add(leave);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return leaves;
        }
        #endregion
    }
}
