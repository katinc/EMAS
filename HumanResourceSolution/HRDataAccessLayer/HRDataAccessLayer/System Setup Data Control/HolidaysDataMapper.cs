using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using System.Data;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class HolidaysDataMapper
    {
        DALHelper dal;

        public HolidaysDataMapper()
        {
            dal = new DALHelper();
        }

        public void Save(object item)
        {
            try
            {
                Holiday holiday = (Holiday)item;
                dal.ClearParameters();
                dal.CreateParameter("@Date", holiday.Date, DbType.DateTime);
                dal.CreateParameter("@Description", holiday.Description, DbType.String);
                dal.ExecuteNonQuery("Insert Into Holidays2(Date,Description) Values(@Date,@Description)");
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
                Holiday holiday = (Holiday)item;
                dal.CreateParameter("@ID", holiday.ID, DbType.Int32);
                dal.CreateParameter("@Date", holiday.Date, DbType.DateTime);
                dal.CreateParameter("@Description", holiday.Description, DbType.String);
                dal.ExecuteNonQuery("Update Holidays2 Set Date=@Date,Description=@Description where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IList<Holiday> GetAll()
        {
            IList<Holiday> holidays = new List<Holiday>();
            try
            { 
                DataTable table = dal.ExecuteReader("Select ID,Date,Description From Holidays2");
                foreach (DataRow row in table.Rows)
                {
                    holidays.Add(new Holiday()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Date = DateTime.Parse(row["Date"].ToString()),
                        Description = row["Description"].ToString()
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
                Holiday holiday = (Holiday)item;
                dal.ExecuteNonQuery("Delete From Holidays2 Where ID="+ holiday.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
