using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
   public class WorkshopDataMapper
    {
       private DALHelper dalHelper;
       private IList<Workshop> lstWorkshops;
       private EmployeeDataMapper employeeDataMapper;
       private AttendedSchoolDataMapper schoolDataMapper;
       private QualificationDataMapper courseDataMapper;
       private CountryDataMapper countryDataMapper;

       public WorkshopDataMapper()
       {
           dalHelper = new DALHelper();
           lstWorkshops = new List<Workshop>();
           employeeDataMapper = new EmployeeDataMapper();
           schoolDataMapper = new AttendedSchoolDataMapper();
           courseDataMapper = new QualificationDataMapper();
           countryDataMapper = new CountryDataMapper();
       }

       public IList<Workshop> getData()
       {
           try
           {
            dalHelper = new DALHelper();
            var dt = dalHelper.ExecuteReader("select * from ViewWorkshops where archived='false' order by id desc");
            DataMapper(dt);
           }
           catch (Exception xi) { }
         
          return lstWorkshops;
       }
       public IList<Workshop> getDataStaffId(int Id)
       {
           try
           {
               dalHelper = new DALHelper();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);
               var dt = dalHelper.ExecuteReader("select * from ViewWorkshops where archived='false' and staffId=@Id order by id desc");
               DataMapper(dt);
           }
           catch (Exception xi) { }

           return lstWorkshops;
       }
       public Workshop getById(int Id)
       {
           try
           {
               dalHelper = new DALHelper();
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);
               var dt = dalHelper.ExecuteReader("select * from ViewWorkshops where archived='false' and id=@Id");
               DataMapper(dt);
           }
           catch (Exception xi) { }

           return lstWorkshops.FirstOrDefault();
       }
       private void DataMapper(DataTable dt)
       {
           try
           {

           Workshop workshop;
           foreach(DataRow dRow in dt.Rows){
               workshop = new Workshop();
               workshop.Id=  dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
               workshop.Staff = dRow["staffId"] != DBNull.Value ? employeeDataMapper.GetByID(Convert.ToInt32(dRow["staffId"])) : workshop.Staff;
               workshop.School=dRow["schoolId"]!=DBNull.Value ? schoolDataMapper.getById(Convert.ToInt32(dRow["schoolId"])) : workshop.School;
               workshop.StartDate = dRow["startDate"] != DBNull.Value ? Convert.ToDateTime(dRow["startDate"]) : workshop.StartDate;
               workshop.EndDate = dRow["endDate"] != DBNull.Value ? Convert.ToDateTime(dRow["endDate"]) : workshop.EndDate;
               workshop.EntryDate=dRow["entryDate"] !=DBNull.Value ? Convert.ToDateTime(dRow["entryDate"]) : workshop.EntryDate;
               workshop.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : workshop.Active;
               workshop.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : workshop.Archived;
               workshop.Course = dRow["courseId"] != DBNull.Value ? courseDataMapper.GetRawQualificationByID( Convert.ToInt32(dRow["courseId"]) ): workshop.Course;
               workshop.Country = dRow["countryId"] != DBNull.Value ? countryDataMapper.GetById(Convert.ToInt32(dRow["countryId"])) : workshop.Country;
               workshop.Venue = dRow["venue"] != DBNull.Value ? Convert.ToString(dRow["venue"]) : workshop.Venue;
               lstWorkshops.Add(workshop);
           }
           }
           catch (Exception xi) { Logger.LogError(xi); }
       }
    }
}
