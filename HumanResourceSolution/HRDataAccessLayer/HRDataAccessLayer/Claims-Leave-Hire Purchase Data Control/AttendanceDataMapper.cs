using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using System.Data.Common;
using System.Data;

namespace HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control
{
    public class AttendanceDataMapper
    {
        DALHelper dal;

        public AttendanceDataMapper()
        {
            dal = new DALHelper();
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
        public void Update(object item)
        {
            Attendance attendance = (Attendance)item;
            dal.ClearParameters();
            dal.CreateParameter("@ID", attendance.ID, DbType.Int32);
            dal.CreateParameter("@StaffID", attendance.StaffID, DbType.String);
            dal.CreateParameter("@AttendanceDate", attendance.AttendanceDate, DbType.DateTime);
            dal.CreateParameter("@AttendanceTime", attendance.AttendanceTime, DbType.String);
            try
            {
                dal.ExecuteNonQuery("Update StaffAttendance Set StaffID=@StaffID,AttendanceDate=@AttendanceDate,AttendanceTime=@AttendanceTime Where ID=@ID");
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
                        StaffName = row["StaffName"].ToString(),
                        AttendanceDate = DateTime.Parse(row["AttendanceDate"].ToString()),
                        AttendanceTime = row["AttendanceTime"].ToString()
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

    }
}
