using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class AppraisalGeneralPerformanceRatingDataMapper
    {
        private DALHelper dalHelper;
        private IList<AppraisalGeneralPerformanceRating> lstAppraisalGeneralPerformanceRatings;
        private AppraisalGeneralPerformanceRating appraisalGeneralPerformanceRating;
        private AppraisalPeriodDataMapper appraisalPeriodDataMapper;
        private EmployeeDataMapper staffDataMapper;
        private AppraisalTypesDataMapper appraisalTypesDataMapper;
        private UserInfoDataMapper userInfoDataMapper;
        

        public AppraisalGeneralPerformanceRatingDataMapper()
        {
            dalHelper = new DALHelper();
            lstAppraisalGeneralPerformanceRatings = new List<AppraisalGeneralPerformanceRating>();
            appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
            staffDataMapper = new EmployeeDataMapper();
            appraisalTypesDataMapper = new AppraisalTypesDataMapper();
            userInfoDataMapper = new UserInfoDataMapper();
        }

        public IList<AppraisalGeneralPerformanceRating> getDataBy(int staffId, int periodId)
        {
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@staffId", staffId, DbType.Int32);
            dalHelper.CreateParameter("@periodId", periodId, DbType.Int32);
            DataTable dt = dalHelper.ExecuteReader("select * from ViewAppraisalGeneralPerformanceRatings where (staffId=@staffId or staffId is NULL) and (periodId=@periodId or periodId is NULL)");
            if(dt.Rows.Count==0)
                dt = dalHelper.ExecuteReader("select distinct factorId,Description,null as id,null as periodId,null as RatingId,null as staffId,null as enteredBy,null as entryDate,null as comment from ViewAppraisalGeneralPerformanceRatings");
            MappData(dt);
            return lstAppraisalGeneralPerformanceRatings;
        }
        
        private void MappData(DataTable dt)
        {
            lstAppraisalGeneralPerformanceRatings.Clear();
            foreach (DataRow dRow in dt.Rows)
            {
                appraisalGeneralPerformanceRating = new AppraisalGeneralPerformanceRating();
                appraisalGeneralPerformanceRating.Id = dRow["id"] != DBNull.Value ?  Convert.ToInt32(dRow["id"]) : 0;
                appraisalGeneralPerformanceRating.Period = dRow["periodId"] != DBNull.Value ? appraisalPeriodDataMapper.getDataById(Convert.ToInt32(dRow["periodId"])) : appraisalGeneralPerformanceRating.Period;
                appraisalGeneralPerformanceRating.Rating = dRow["RatingId"] != DBNull.Value ? new AppraisalRating() { Id = Convert.ToInt32(dRow["RatingId"]), Value = Convert.ToDecimal(dRow["value"]), Description = dRow["Description"].ToString(), RateDescription = dRow["Rating"].ToString(), AvgMin = dRow["avgmin"] != DBNull.Value ? Convert.ToDecimal(dRow["avgmin"]) : -1, AvgMax = dRow["avgmin"] != DBNull.Value ? Convert.ToDecimal(dRow["avgmin"]) : -1, OveralMax = dRow["overalmax"] != DBNull.Value ? Convert.ToInt32(dRow["overalmax"]) : -1, OveralMin = dRow["overalmin"] != DBNull.Value ? Convert.ToInt32(dRow["overalmin"]) : -1 } : appraisalGeneralPerformanceRating.Rating;
                appraisalGeneralPerformanceRating.Staff = dRow["staffId"] != DBNull.Value ? staffDataMapper.GetByID(Convert.ToInt32(dRow["staffId"])) : appraisalGeneralPerformanceRating.Staff;
                appraisalGeneralPerformanceRating.Factor = dRow["factorId"] != DBNull.Value ? appraisalTypesDataMapper.getAppraisalTypeById(Convert.ToInt32(dRow["factorId"])) : appraisalGeneralPerformanceRating.Factor;
                appraisalGeneralPerformanceRating.EnteredBy = dRow["enteredBy"] != DBNull.Value ? userInfoDataMapper.GetById(Convert.ToInt32(dRow["enteredBy"])) : appraisalGeneralPerformanceRating.EnteredBy;
                appraisalGeneralPerformanceRating.EntryDate = dRow["entryDate"] != DBNull.Value ? Convert.ToDateTime(dRow["entryDate"]) : appraisalGeneralPerformanceRating.EntryDate;
                appraisalGeneralPerformanceRating.Comment = dRow["comment"] != DBNull.Value ? Convert.ToString(dRow["comment"]) : string.Empty;
                lstAppraisalGeneralPerformanceRatings.Add(appraisalGeneralPerformanceRating);
            }
        }
    }
}
