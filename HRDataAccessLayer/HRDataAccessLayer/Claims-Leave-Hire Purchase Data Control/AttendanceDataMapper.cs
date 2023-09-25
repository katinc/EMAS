using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using System.Data.Common;
using System.Data;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control
{
    public class AttendanceDataMapper
    {
        DALHelper dal;
        private Attendance attendance;

        public AttendanceDataMapper()
        {
            dal = new DALHelper();
            this.attendance = new Attendance();
        }

        #region SAVE
        public void Save(object item)
        {
            Attendance attendance = (Attendance)item;
            dal.ClearParameters();
            dal.CreateParameter("@StaffID", attendance.StaffID, DbType.String);
            dal.CreateParameter("@AttendanceDate", attendance.AttendanceDate, DbType.DateTime);
            dal.CreateParameter("@AttendanceTime", attendance.AttendanceTime, DbType.String);

            try
            {
                dal.ExecuteNonQuery("Insert Into StaffAttendance(StaffID,AttendanceDate,AttendanceTime) Values(@StaffID,@AttendanceDate,@AttendanceTime)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public bool Update(Attendance attendance)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", attendance.ID, DbType.Int32);
                dal.CreateParameter("@CheckOutTime", attendance.CheckoutTime, DbType.DateTime);
                dal.CreateParameter("@CheckOutDeviceID", attendance.CheckoutDeviceID, DbType.String);
                dal.CreateParameter("@CheckOutType", attendance.CheckOutType, DbType.String);

                dal.ExecuteNonQuery("Update StaffAttendance Set CheckOutTime=@CheckOutTime, CheckOutDeviceID=@CheckOutDeviceID, CheckOutType=@CheckOutType, AttendanceTime=@AttendanceTime Where ID=@ID");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            Attendance attendance = (Attendance)item;
            try
            {
                dal.ExecuteNonQuery("Update StaffAttendance Set Archived = 'True' where ID = " + attendance.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Attendance> GetAll()
        {
            IList<Attendance> attendances = new List<Attendance>();
            try
            {
                DataTable table = dal.ExecuteReader("Select StaffAttendance.ID,StaffAttendance.StaffID,StaffPersonalInfo.FirstName +' '+ StaffPersonalInfo.OtherName +' '+ StaffPersonalInfo.Surname as StaffName,StaffAttendance.AttendanceDate,StaffAttendance.AttendanceTime From StaffAttendance Inner Join StaffPersonalInfo on StaffPersonalInfo.StaffID = StaffAttendance.StaffID Where StaffAttendance.Archived ='False'");
                foreach (DataRow row in table.Rows)
                {
                    attendances.Add(new Attendance()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        StaffID = row["StaffID"].ToString(),
                        StaffMainID = row["StaffMainID"].ToString(),
                        StaffName = row["StaffName"].ToString(),
                        //AttendanceDate = DateTime.Parse(row["AttendanceDate"].ToString()),
                        AttendanceTime = row["AttendanceTime"].ToString(),
                        CheckoutTime = row["CheckOutTime"].ToString(),
                        CheckinTime = row["CheckInTime"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        //BreakinTime = DateTime.Parse(row["BreakInTime"].ToString()),
                        //BreakoutTime = DateTime.Parse(row["BreakOutTime"].ToString()),
                        UserType = row["UserType"].ToString(),
                        DeviceID = row["DeviceID"].ToString(),
                        CheckinDeviceID = row["CheckInDeviceID"].ToString(),
                        CheckoutDeviceID = row["CheckOutDeviceID"].ToString()

                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attendances;
        }
        #endregion

        #region GetByCriteria
        public IList<Attendance> GetByCriteria(Query query1)
        {
            IList<Attendance> attendances = new List<Attendance>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", attendance.Archived, DbType.Boolean);
                string query = "SELECT * FROM [dbo].[StaffAttendanceView]";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                //string suffix = "And ";
                //selectStatement += " where CheckOutType  ";
                //if (selectStatement.EndsWith(suffix))
                //{
                //    selectStatement = selectStatement.Substring(0, selectStatement.Length - suffix.Length);
                //}
                selectStatement += " Order by StaffAttendanceView.AttendanceDate DESC";
                dal.ExecuteNonQuery(selectStatement);
                table = dal.ExecuteReader(selectStatement);
                foreach (Attendance attend in BuildAttendanceFromData(table))
                {
                    attendances.Add(attend);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return attendances;
        }

        #endregion

        #region BuildAttendanceFromData
        private IList<Attendance> BuildAttendanceFromData(DataTable table)
        {
            IList<Attendance> attendances = new List<Attendance>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Attendance attendance = new Attendance()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            //ID = int.Parse(row["ID"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                        },
                        AttendanceDate = DateTime.Parse(row["AttendanceDate"].ToString()),
                        AttendanceTime = (row["AttendanceTime"].ToString()),
                        CheckoutTime = (row["CheckOutTime"].ToString()),
                        CheckinTime = (row["CheckInTime"].ToString()),
                        StaffMainID = (row["StaffMainId"].ToString()),
                        DeviceID = (row["DeviceID"].ToString()),
                        CheckinDeviceID = (row["CheckInDeviceID"].ToString()),
                        CheckoutDeviceID = (row["CheckoutDeviceID"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        //UserID = (row["UserID"].ToString()),
                        Department = (row["Department"].ToString()),
                        Unit = (row["Unit"].ToString()),
                        CheckOutType = (row["CheckOutType"].ToString()),


                    };
                    attendances.Add(attendance);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return attendances;
        }


        #endregion
    }
}