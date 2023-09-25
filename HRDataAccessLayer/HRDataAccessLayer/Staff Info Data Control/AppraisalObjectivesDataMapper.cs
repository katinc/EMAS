using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class AppraisalObjectivesDataMapper
    {
       private DALHelper dalHelper;
       private IList<AppraisalObjective> lstAppraisalObjectives;
       private AppraisalPeriodDataMapper appraisalPeriodDataMapper;
       private EmployeeDataMapper staffDataMapper;
       private UserInfoDataMapper userInfoDataMapper;
       

       public AppraisalObjectivesDataMapper()
       {
           this.dalHelper = new DALHelper();
           lstAppraisalObjectives = new List<AppraisalObjective>();
           appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
           staffDataMapper = new EmployeeDataMapper();
           userInfoDataMapper = new UserInfoDataMapper();
       }

       public IList<AppraisalObjective> getData()
       {
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
           DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalObjectives where Arvchived=@Archived");
          DataMapper(dt);
          return lstAppraisalObjectives;
       }
       public IList<AppraisalObjective> getByYear(int Year,bool Active)
       {
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
           dalHelper.CreateParameter("@Active", Active, DbType.Boolean);
           dalHelper.CreateParameter("@Year", Year, DbType.Int32);
           DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalObjectives where PeriodCode<>'Annual' and Arvchived=@Archived and PeriodYear=@Year and Active=@Active");
           DataMapper(dt);
           return lstAppraisalObjectives;
       }
       
       public IList<AppraisalObjective> getData(bool Active)
       {
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
           dalHelper.CreateParameter("@Active", Active, DbType.Boolean);
           DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalObjectives where Arvchived=@Archived and Active=@Active");
           DataMapper(dt);
           return lstAppraisalObjectives;
       }
       public AppraisalObjective getDataById(int Id)
       {
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@Id", Id, DbType.Int32);
           DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalObjectives where id=@Id");
           DataMapper(dt);
           return lstAppraisalObjectives.FirstOrDefault();
       }
       public IList<AppraisalObjective> getDataByStaffId(int Id,int PeriodId)
       {
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@staffId", Id, DbType.Int32);
           dalHelper.CreateParameter("@periodId", PeriodId, DbType.Int32);
           DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalObjectives where staffId=@staffId and Archived='false' and periodId=@periodId");
           DataMapper(dt);
           return lstAppraisalObjectives;
       }
       private void DataMapper(DataTable dt)
       {
           try
           {
                lstAppraisalObjectives.Clear();
                   AppraisalObjective appraisalObjective;
                   foreach (DataRow dRow in dt.Rows)
                   {
                       appraisalObjective=new AppraisalObjective();
                      appraisalObjective.Id= dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                      appraisalObjective.Description = dRow["description"] != DBNull.Value ? Convert.ToString(dRow["description"]) : string.Empty;
                      appraisalObjective.Comment = dRow["comment"] != DBNull.Value ? Convert.ToString(dRow["comment"]) : string.Empty;
                      appraisalObjective.Period = dRow["periodId"] != DBNull.Value ? appraisalPeriodDataMapper.getDataById(Convert.ToInt32(dRow["periodId"])) : appraisalObjective.Period;
                      appraisalObjective.Staff = dRow["staffId"] != DBNull.Value ? staffDataMapper.GetByID(Convert.ToInt32(dRow["staffId"])) : appraisalObjective.Staff;
                      appraisalObjective.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : appraisalObjective.Active;
                      appraisalObjective.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : appraisalObjective.Archived;
                      appraisalObjective.EntryDate = dRow["entryDate"] != DBNull.Value ? Convert.ToDateTime(dRow["entryDate"]) : appraisalObjective.EntryDate;
                      appraisalObjective.EnteredBy = dRow["enteredById"] != DBNull.Value ? userInfoDataMapper.GetById(Convert.ToInt32(dRow["enteredById"]) ): appraisalObjective.EnteredBy;
                      appraisalObjective.PeriodRating = dRow["ratingId"] != DBNull.Value ? new AppraisalRating() { Id = Convert.ToInt32(dRow["ratingId"]), Value = dRow["value"] != DBNull.Value ? Convert.ToInt32(dRow["value"]) : -1, Description = Convert.ToString(dRow["Rating"]), RateDescription = dRow["RateDescription"].ToString(), AvgMin = dRow["avgmin"] != DBNull.Value ? Convert.ToDecimal(dRow["avgmin"]) : -1, AvgMax = dRow["avgmax"] != DBNull.Value ? Convert.ToDecimal(dRow["avgmax"]) : -1 } : appraisalObjective.PeriodRating;

                      lstAppraisalObjectives.Add(appraisalObjective);
                   }
           }
           catch (Exception xi) { Logger.LogError(xi); }
           
       }
    }
}
