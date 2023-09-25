using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class AttendedSchoolDataMapper
    {
        private List<AttendedSchool> lstAttendedSchool;
        private CountryDataMapper countryMapper;

        private DALHelper dalHelper;

        public AttendedSchoolDataMapper()
        {
            lstAttendedSchool = new List<AttendedSchool>();
            dalHelper = new DALHelper();
            countryMapper = new CountryDataMapper();
        }

        public AttendedSchool getById(int Id)
        {
            try{
                dalHelper = new DALHelper();
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@id", Id, DbType.Int32);

            DataTable dtAttendedSchool = dalHelper.ExecuteReader("select * from AttendedSchools where active='true' and id=@id order by description");
            MappData(dtAttendedSchool);
             }
            catch (Exception e1)
            {
                Logger.LogError(e1);
            }
           return lstAttendedSchool.FirstOrDefault();
        }
        public List< AttendedSchool> getByCountryId(int Id)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@countryId", Id, DbType.Int32);

                DataTable dtAttendedSchool = dalHelper.ExecuteReader("select * from AttendedSchools where   countryId=@countryId order by description");
                MappData(dtAttendedSchool);
            }
            catch (Exception e1)
            {
                Logger.LogError(e1);
            }
            return lstAttendedSchool;
        }
        public List<AttendedSchool> getData(bool active,bool archived)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@active", active, DbType.Boolean);
                dalHelper.CreateParameter("@archived", archived, DbType.Boolean);

                DataTable dtAttendedSchool = dalHelper.ExecuteReader("select * from AttendedSchools where active=@active and archived=@archived order by description");
                MappData(dtAttendedSchool);
            }
            catch (Exception e1)
            {
                Logger.LogError(e1);
            }
          
         return lstAttendedSchool;
        }
        public List<AttendedSchool> getData()
        {
            try
            {
                dalHelper.ClearParameters();
              

                DataTable dtAttendedSchool = dalHelper.ExecuteReader("select * from AttendedSchools order by description");
                MappData(dtAttendedSchool);
            }
            catch (Exception e1)
            {
                Logger.LogError(e1);
            }

            return lstAttendedSchool;
        }
        private void MappData(DataTable dtAttendedSchool)
        {
            try
            {
                lstAttendedSchool.Clear();
                AttendedSchool attendedSchool;
                foreach (DataRow dRow in dtAttendedSchool.Rows)
                {
                    attendedSchool = new AttendedSchool();
                    attendedSchool.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                    attendedSchool.Description = dRow["description"] != DBNull.Value ? Convert.ToString(dRow["description"]) : string.Empty;
                    attendedSchool.Location = dRow["location"] != DBNull.Value ? Convert.ToString(dRow["location"]) : string.Empty;
                    attendedSchool.Website = dRow["website"] != DBNull.Value ? Convert.ToString(dRow["website"]) : string.Empty;
                    attendedSchool.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : false;
                    attendedSchool.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : false;
                    attendedSchool.SchoolCountry=countryMapper.GetById(Convert.ToInt32(dRow["countryId"]));
                    lstAttendedSchool.Add(attendedSchool);
                }
            }
            catch (Exception e1)
            {
                Logger.LogError(e1);
            }
            
        }
    }
}
