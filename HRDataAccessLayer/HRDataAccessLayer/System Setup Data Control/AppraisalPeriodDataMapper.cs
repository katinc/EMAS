using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class AppraisalPeriodDataMapper
    {
       private DALHelper dalHelper;
       private IList<AppraisalPeriod> lstAppraisalPeriods; 

       public AppraisalPeriodDataMapper()
       {
           dalHelper = new DALHelper();
           lstAppraisalPeriods = new List<AppraisalPeriod>();
       }
       public IList<AppraisalPeriod> getData(bool Active,bool Archived)
       {
           dalHelper = new DALHelper();

           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Active", Active, DbType.Boolean);
           dalHelper.CreateParameter("@Archived", Archived, DbType.Boolean);

           DataTable dt = dalHelper.ExecuteReader("select * from AppraisalPeriods where Active=@Active and Archived=@Archived order by description");
           DataMapper(dt);
           return lstAppraisalPeriods;
       }
       public IList<AppraisalPeriod> getData()
       {
           dalHelper = new DALHelper();

           dalHelper.ClearParameters();
        

           DataTable dt = dalHelper.ExecuteReader("select * from AppraisalPeriods order by description");
           DataMapper(dt);
           return lstAppraisalPeriods;
       }
       public AppraisalPeriod getDataById(int Id)
       {
           dalHelper = new DALHelper();

           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Id", Id, DbType.Int32);

           DataTable dt = dalHelper.ExecuteReader("select * from AppraisalPeriods where id=@Id");
           DataMapper(dt);
           return lstAppraisalPeriods.FirstOrDefault();
       }
       public void DataMapper(DataTable dt)
       {
           lstAppraisalPeriods.Clear();
           AppraisalPeriod period;
           foreach (DataRow dRow in dt.Rows)
           {
                period = new AppraisalPeriod();
                period.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                period.Description = dRow["description"] != DBNull.Value ? Convert.ToString(dRow["description"]) : string.Empty;
                period.Year = dRow["year"] != DBNull.Value ? Convert.ToInt32(dRow["year"]) : 0;
               period.StartDate = dRow["startDate"] != DBNull.Value ? Convert.ToDateTime(dRow["startDate"]) : period.StartDate;
                period.EndDate = dRow["endDate"] != DBNull.Value ? Convert.ToDateTime(dRow["endDate"]) : period.EndDate;
                period.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : period.Active;
                period.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : period.Archived;
                period.Code = dRow["code"] != DBNull.Value ? Convert.ToString(dRow["code"]) : string.Empty;
               
               lstAppraisalPeriods.Add(period);
           }
       }
    }
}
