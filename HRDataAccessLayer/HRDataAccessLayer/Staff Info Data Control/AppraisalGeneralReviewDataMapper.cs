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
    public class AppraisalGeneralReviewDataMapper
    {
        private AppraisalGeneralReview appraisalGeneralReview;
        private IList<AppraisalGeneralReview> lstAppraisalGeneralReviews;

        private DALHelper dalHelper;
        private AppraisalPeriodDataMapper appraisalPeriodDataMapper;
        private EmployeeDataMapper staffDataMapper;
        private UserInfoDataMapper userInfoDataMapper;

        public AppraisalGeneralReviewDataMapper()
        {
           
            lstAppraisalGeneralReviews = new List<AppraisalGeneralReview>();
            appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
            staffDataMapper = new EmployeeDataMapper();
            userInfoDataMapper = new UserInfoDataMapper();
            dalHelper = new DALHelper();
        }
        public AppraisalGeneralReview getDataStaffIdANDPeriodId(int StaffId,int PeriodId)
        {
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@periodId", PeriodId, DbType.Int32);
            dalHelper.CreateParameter("@staffId", StaffId, DbType.Int32);
            var dt=  dalHelper.ExecuteReader("select * from ViewAppraisalGeneralReviews where periodId=@periodId and AppraiseeId=@staffId");
            MappData(dt);
          return lstAppraisalGeneralReviews.FirstOrDefault();
        }
        private void MappData(DataTable dt)
        {
            try
            {
                lstAppraisalGeneralReviews.Clear();
                foreach (DataRow dRow in dt.Rows)
                {
                    appraisalGeneralReview = new AppraisalGeneralReview();
                    appraisalGeneralReview.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                    appraisalGeneralReview.strengths = dRow["strengths"] != DBNull.Value ? Convert.ToString(dRow["strengths"]) : string.Empty;
                    appraisalGeneralReview.weeknesses = dRow["weeknesses"] != DBNull.Value ? Convert.ToString(dRow["weeknesses"]) : string.Empty;
                    appraisalGeneralReview.appraisalPeriod = dRow["periodId"] != DBNull.Value ? appraisalPeriodDataMapper.getDataById(Convert.ToInt32(dRow["periodId"])) : appraisalGeneralReview.appraisalPeriod;
                    appraisalGeneralReview.Appraisee = dRow["AppraiseeId"] != DBNull.Value ? staffDataMapper.GetByID(Convert.ToInt32(dRow["AppraiseeId"])) : appraisalGeneralReview.Appraisee;
                    appraisalGeneralReview.AppraiseeComment = dRow["appraiseeComment"] != DBNull.Value ? Convert.ToString(dRow["appraiseeComment"]) : appraisalGeneralReview.AppraiseeComment;
                    appraisalGeneralReview.AppraiseeDate = dRow["appraiseeDate"] != DBNull.Value ? Convert.ToDateTime(dRow["appraiseeDate"]) : appraisalGeneralReview.AppraiseeDate;
                    appraisalGeneralReview.Appraiser = dRow["AppraiserId"] != DBNull.Value ? staffDataMapper.GetByID(Convert.ToInt32(dRow["AppraiserId"])) : appraisalGeneralReview.Appraiser;
                    appraisalGeneralReview.AppraiserComment = dRow["appraiserComment"] != DBNull.Value ? Convert.ToString(dRow["appraiserComment"]) : appraisalGeneralReview.AppraiserComment;
                    appraisalGeneralReview.AppraiserDate = dRow["appraiserDate"] != DBNull.Value ? Convert.ToDateTime(dRow["appraiserDate"]) : appraisalGeneralReview.AppraiserDate;
                    appraisalGeneralReview.Officer = dRow["officerId"] != DBNull.Value ? staffDataMapper.GetByID(Convert.ToInt32(dRow["officerId"])) : appraisalGeneralReview.Officer;
                    appraisalGeneralReview.OfficerComment = dRow["officerComment"] != DBNull.Value ? Convert.ToString(dRow["officerComment"]) : appraisalGeneralReview.OfficerComment;
                    appraisalGeneralReview.OfficerDate = dRow["officerDate"] != DBNull.Value ? Convert.ToDateTime(dRow["officerDate"]) : appraisalGeneralReview.OfficerDate;
                    appraisalGeneralReview.recommendedTrainings = dRow["recommendedTrainings"] != DBNull.Value ? Convert.ToString(dRow["recommendedTrainings"]) : appraisalGeneralReview.recommendedTrainings;
                    appraisalGeneralReview.EnteredBy = dRow["enteredBy"] != DBNull.Value ? userInfoDataMapper.GetById(Convert.ToInt32(dRow["enteredBy"])) : appraisalGeneralReview.EnteredBy;
                    appraisalGeneralReview.EntryDate = dRow["entryDate"] != DBNull.Value ? Convert.ToDateTime(dRow["entryDate"]) : appraisalGeneralReview.EntryDate;

                    lstAppraisalGeneralReviews.Add(appraisalGeneralReview);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }
    }
}
