using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using System.Data;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class PublicHolidaysDataMapper
    {
        DALHelper dal;

        public PublicHolidaysDataMapper()
        {
            dal = new DALHelper();
        }

        public void Save(object item)
        {
            try
            {
                PublicHoliday holiday = (PublicHoliday)item;
                dal.ClearParameters();
                dal.CreateParameter("@holidayName", holiday.HolidayName, DbType.String);
                dal.CreateParameter("@holidayDate", holiday.HolidayDate, DbType.Date);
                //dal.CreateParameter("@active", holiday.Active, DbType.Boolean);
                dal.CreateParameter("@userid", holiday.UserID, DbType.Int32);
                //dal.CreateParameter("@archived", holiday.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Insert Into publicholidays(HolidayName,HolidayDate,UserID) Values(@holidayName,@holidayDate,@userid)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object item)
        {
            try
            {
                PublicHoliday holiday = (PublicHoliday)item;
                dal.ClearParameters();
                dal.CreateParameter("@holidayName", holiday.HolidayName, DbType.String);
                dal.CreateParameter("@holidayDate", holiday.HolidayDate, DbType.Date);
                dal.CreateParameter("@active", holiday.Active, DbType.Boolean);
                dal.CreateParameter("@userid", holiday.UserID, DbType.Int32);
                dal.CreateParameter("@archived", holiday.Archived, DbType.Boolean);
                dal.CreateParameter("@id", holiday.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update publicholidays Set HolidayName=@holidayName,HolidayDate=@holidayDate,Active=@active,Archived=@archived,UserID=@userid where ID=@id");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<PublicHoliday> GetAll()
        {
            IList<PublicHoliday> holidays = new List<PublicHoliday>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From publicholidays where archived='false'");
                foreach (DataRow row in table.Rows)
                {
                    holidays.Add(new PublicHoliday()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        HolidayName = row["HolidayName"].ToString(),
                        HolidayDate = DateTime.Parse(row["HolidayDate"].ToString()).Date,
                        Archived =bool.Parse( row["Archived"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                        UserID = int.Parse(row["UserID"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return holidays;
        }
        public void Delete(object item)
        {
            try
            {
                PublicHoliday holiday = (PublicHoliday)item;
                dal.ExecuteNonQuery("update publicholidays set archived='true',active='false' Where ID=" + holiday.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
