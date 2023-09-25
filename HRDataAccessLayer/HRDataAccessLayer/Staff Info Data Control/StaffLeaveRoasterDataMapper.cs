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

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class StaffLeaveRoasterDataMapper
    {
        private DALHelper dal;
        private StaffLeaveRoaster staffLeaveRoaster;

        public StaffLeaveRoasterDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.staffLeaveRoaster = new StaffLeaveRoaster();
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
                StaffLeaveRoaster staffLeaveRoaster = (StaffLeaveRoaster)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffLeaveRoaster.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffLeaveRoaster.Employee.StaffID, DbType.String);
                dal.CreateParameter("@LeaveType", staffLeaveRoaster.LeaveType, DbType.String);
                dal.CreateParameter("@StartDate", staffLeaveRoaster.StartDate, DbType.Date);
                dal.CreateParameter("@EndDate", staffLeaveRoaster.EndDate, DbType.Date);
                dal.CreateParameter("@LeaveDate", staffLeaveRoaster.LeaveDate, DbType.Date);
                dal.CreateParameter("@NumberOfDays", staffLeaveRoaster.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Reason", staffLeaveRoaster.Reason, DbType.String);
                dal.CreateParameter("@UserID", staffLeaveRoaster.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("INSERT INTO StaffLeaveRoaster (StaffID,StaffCode,LeaveType,StartDate,EndDate,LeaveDate,NumberOfDays,Reason,UserID) VALUES(@StaffID,@StaffCode,@LeaveType,@StartDate,@EndDate,@LeaveDate,@NumberOfDays,@Reason,@UserID)");
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
                StaffLeaveRoaster staffLeaveRoaster = (StaffLeaveRoaster)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffLeaveRoaster.ID, DbType.String);
                dal.CreateParameter("@StaffCode", staffLeaveRoaster.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffLeaveRoaster.Employee.StaffID, DbType.String);
                dal.CreateParameter("@LeaveType", staffLeaveRoaster.LeaveType, DbType.String);
                dal.CreateParameter("@StartDate", staffLeaveRoaster.StartDate, DbType.Date);
                dal.CreateParameter("@EndDate", staffLeaveRoaster.EndDate, DbType.Date);
                dal.CreateParameter("@LeaveDate", staffLeaveRoaster.LeaveDate, DbType.Date);
                dal.CreateParameter("@NumberOfDays", staffLeaveRoaster.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Reason", staffLeaveRoaster.Reason, DbType.String);
                dal.CreateParameter("@UserID", staffLeaveRoaster.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update StaffLeaveRoaster Set StaffID=@StaffID,StaffCode=@StaffCode,LeaveType=@LeaveType,StartDate=@StartDate,EndDate=@EndDate,LeaveDate=@LeaveDate,Reason=@Reason,NumberOfDays=@NumberOfDays,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<StaffLeaveRoaster> GetAll()
        {
            IList<StaffLeaveRoaster> staffLeaveRoasters = new List<StaffLeaveRoaster>();
            try
            {
                string query = "select StaffLeaveRoasterView.*,StaffLeaveRoasterView.Firstname +' '+ StaffLeaveRoasterView.OtherName +' '+ StaffLeaveRoasterView.Surname as StaffName From StaffLeaveRoasterView ";
                query += " Where StaffLeaveRoasterView.Archived ='False' Order by DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (StaffLeaveRoaster staffLeaveR in BuildLeaveFromData(table))
                {
                    staffLeaveRoasters.Add(staffLeaveR);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLeaveRoasters;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                StaffLeaveRoaster staffLeaveRoaster = (StaffLeaveRoaster)item;
                dal.ExecuteNonQuery("Update StaffLeaveRoaster Set Archived ='True' Where ID=" + staffLeaveRoaster.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<StaffLeaveRoaster> GetByCriteria(Query query1)
        {
            IList<StaffLeaveRoaster> staffLeaveRoasters = new List<StaffLeaveRoaster>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", staffLeaveRoaster.Archived, DbType.Boolean);
                string query = "select StaffLeaveRoasterView.*,StaffLeaveRoasterView.Firstname +' '+ StaffLeaveRoasterView.OtherName +' '+ StaffLeaveRoasterView.Surname as StaffName From StaffLeaveRoasterView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                if (selectStatement.Contains("Where"))
                {
                    selectStatement += " and ";
                }
                else
                {
                    selectStatement += " where";
                }
                selectStatement += "  StaffLeaveRoasterView.Archived ='False' Order by DateAndTimeGenerated DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffLeaveRoaster staffLeaveR in BuildLeaveFromData(table))
                {
                    staffLeaveRoasters.Add(staffLeaveR);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLeaveRoasters;
        }
        #endregion

        #region BuildLeaveFromData
        private IList<StaffLeaveRoaster> BuildLeaveFromData(DataTable table)
        {
            IList<StaffLeaveRoaster> staffLeaveRoasters = new List<StaffLeaveRoaster>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffLeaveRoaster staffLeaveRoaster = new StaffLeaveRoaster()
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
                            AnnualLeave = row["AnnualLeave"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeave"].ToString()),
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
                        EndDate = DateTime.Parse(row["EndDate"].ToString()),
                        StartDate = DateTime.Parse(row["StartDate"].ToString()),
                        LeaveDate = DateTime.Parse(row["LeaveDate"].ToString()),
                        Reason = row["Reason"].ToString(),
                        NumberOfDays = decimal.Parse(row["NumberOfDays"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                        },
                    };
                    staffLeaveRoasters.Add(staffLeaveRoaster);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLeaveRoasters;
        }
        #endregion
    }
}
