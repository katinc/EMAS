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
   public class ExternalTrainingDataMapper
    {
       private IList<ExternalTraining> lstEternalTrainings;
       private DALHelper dalHelper;
       private QualificationDataMapper qualificationMapper;
       private TrainingSponsorDataMapper sponsorMapper;
       private TrainingOrganizersDataMapper organizerMapper;
       private CountryDataMapper countryMapper;
       private AttendedSchoolDataMapper schoolMapper;
       private EmployeeDataMapper staffMapper;
       private UserInfoDataMapper userMapper;
       

       public ExternalTrainingDataMapper()
       {
           this.lstEternalTrainings = new List<ExternalTraining>();
           this.dalHelper = new DALHelper();
           this.qualificationMapper = new QualificationDataMapper();
           this.sponsorMapper = new TrainingSponsorDataMapper();
           this.organizerMapper = new TrainingOrganizersDataMapper();
           this.countryMapper = new CountryDataMapper();
           this.schoolMapper = new AttendedSchoolDataMapper();
           this.staffMapper = new EmployeeDataMapper();
           this.userMapper = new UserInfoDataMapper();
       }

       void DataMapper(DataTable dt)
       {
           try
           {
               lstEternalTrainings.Clear();
               ExternalTraining externalTraining;
               foreach (DataRow dRow in dt.Rows)
               {
                   externalTraining = new ExternalTraining();
                   externalTraining.ID = dRow["ID"] != DBNull.Value ? Convert.ToInt32(dRow["ID"]) : 0;
                   externalTraining.Venue = dRow["Venue"] != DBNull.Value ? Convert.ToString(dRow["Venue"]) : string.Empty;
                   externalTraining.TransportationFee = dRow["TransportationFee"] != DBNull.Value ? Convert.ToDecimal(dRow["TransportationFee"]) : externalTraining.TransportationFee;
                   externalTraining.AccomodationFee = dRow["AccomodationFee"] != DBNull.Value ? Convert.ToDecimal(dRow["AccomodationFee"]) : externalTraining.AccomodationFee;
                   externalTraining.TotalCost = dRow["TotalCost"] != DBNull.Value ? Convert.ToDecimal(dRow["TotalCost"]) : externalTraining.TotalCost;
                   externalTraining.StartDate = dRow["StartDate"] != DBNull.Value ? Convert.ToDateTime(dRow["StartDate"]) : externalTraining.StartDate;
                   externalTraining.EndDate = dRow["EndDate"] != DBNull.Value ? Convert.ToDateTime(dRow["EndDate"]) : externalTraining.EndDate;
                   externalTraining.EnteredDate = dRow["DateEntered"] != DBNull.Value ? Convert.ToDateTime(dRow["DateEntered"]) : externalTraining.EnteredDate;
                   externalTraining.Cost = dRow["CostFee"] != DBNull.Value ? Convert.ToDecimal(dRow["CostFee"]) : externalTraining.Cost;

                   externalTraining.Active = dRow["Active"] != DBNull.Value ? Convert.ToBoolean(dRow["Active"]) : externalTraining.Active;
                   externalTraining.Archived = dRow["Archived"] != DBNull.Value ? Convert.ToBoolean(dRow["Archived"]) : externalTraining.Archived;
                   externalTraining.AspiredQualification = dRow["QualificationId"] != DBNull.Value ? qualificationMapper.GetRawQualificationByID(Convert.ToInt32(dRow["QualificationId"])) : externalTraining.AspiredQualification;

                   externalTraining.InCountryTraining = dRow["InCountryTraining"] != DBNull.Value ? Convert.ToBoolean(dRow["InCountryTraining"]) : externalTraining.InCountryTraining;
                   externalTraining.Organizer = dRow["OrganiserId"] != DBNull.Value ? organizerMapper.getById(Convert.ToInt32(dRow["OrganiserId"])) : externalTraining.Organizer;
                   externalTraining.Sponsor = dRow["SponsorID"] != DBNull.Value ? sponsorMapper.getById(Convert.ToInt32(dRow["SponsorID"])) : externalTraining.Sponsor;
                   externalTraining.Staff = dRow["StaffID"] != DBNull.Value ? staffMapper.GetByID(Convert.ToInt32(dRow["StaffID"])) : externalTraining.Staff;
                   externalTraining.School = dRow["SchoolId"] != DBNull.Value ? schoolMapper.getById(Convert.ToInt32(dRow["SchoolId"])) : externalTraining.School;
                   externalTraining.TrainingCoutry = dRow["CountryId"] != DBNull.Value ? countryMapper.GetById(Convert.ToInt32(dRow["CountryId"])) : externalTraining.TrainingCoutry;
                   externalTraining.EntryBy = dRow["UserID"] != DBNull.Value ? userMapper.GetById(Convert.ToInt32(dRow["UserID"])) : externalTraining.EntryBy;

                   externalTraining.HOD = dRow["HODId"] != DBNull.Value ? staffMapper.GetByID(Convert.ToInt32(dRow["HODId"])) : externalTraining.HOD;
                   externalTraining.isJustified = dRow["isJustified"] != DBNull.Value ? Convert.ToBoolean(dRow["isJustified"]) : false;
                   externalTraining.Justification = dRow["Justification"] != DBNull.Value ? Convert.ToString(dRow["Justification"]) : string.Empty;
                   externalTraining.JustificationDate = dRow["JustificationDate"] != DBNull.Value ? Convert.ToDateTime(dRow["JustificationDate"]) : externalTraining.JustificationDate;

                   externalTraining.HR = dRow["HRId"] != DBNull.Value ? staffMapper.GetByID(Convert.ToInt32(dRow["HRId"])) : externalTraining.HR;
                   externalTraining.HRDecision = dRow["HRDecision"] != DBNull.Value ? Convert.ToString(dRow["HRDecision"]) : externalTraining.HRDecision;
                   externalTraining.HRComment = dRow["HRComments"] != DBNull.Value ? Convert.ToString(dRow["HRComments"]) : externalTraining.HRComment;
                   externalTraining.HRAssessmentDate = dRow["HRAssessmentDate"] != DBNull.Value ? Convert.ToDateTime(dRow["HRAssessmentDate"]) : externalTraining.HRAssessmentDate;
                   externalTraining.HRRecommended = dRow["HRRecommended"] != DBNull.Value ? Convert.ToBoolean(dRow["HRRecommended"]) : externalTraining.HRRecommended;


                   externalTraining.CEO = dRow["CEOId"] != DBNull.Value ? staffMapper.GetByID(Convert.ToInt32(dRow["CEOId"])) : externalTraining.CEO;
                   externalTraining.CEOComment = dRow["CEOComment"] != DBNull.Value ? Convert.ToString(dRow["CEOComment"]) : externalTraining.CEOComment;
                   externalTraining.CEOApprovalDate = dRow["CEOApprovalDate"] != DBNull.Value ? Convert.ToDateTime(dRow["CEOApprovalDate"]) : externalTraining.CEOApprovalDate;
                   externalTraining.CEOApproval = dRow["CEOApproval"] != DBNull.Value ? Convert.ToBoolean(dRow["CEOApproval"]) : externalTraining.CEOApproval;


                   lstEternalTrainings.Add(externalTraining);
               }
           }
           catch (Exception e1) { }
           
       }

       public IList<ExternalTraining> getExternalTrainings()
       {
           try
           {
               dalHelper = new DALHelper();
               dalHelper.ClearParameters();
               DataTable dt = dalHelper.ExecuteReader("select * from ViewExternalTrainings where Archived='false'");
               DataMapper(dt);
           }
           catch (Exception e1) { }
        
           
           return lstEternalTrainings;
       }
       public IList<ExternalTraining> getExternalTrainings(DALHelper newDalHelper)
       {
           try
           {
              // this.dalHelper = dalHelper;

               DataTable dt = dalHelper.ExecuteReader(newDalHelper.CurrentCommand.CommandText);
               DataMapper(dt);
           }
           catch (Exception e1) { }


           return lstEternalTrainings;
       }

       public ExternalTraining getById(int Id)
       {
           try
           {
               dalHelper = new DALHelper();
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);
               DataTable dt = dalHelper.ExecuteReader("select * from ViewExternalTrainings where Archived='false' and id=@Id");
               DataMapper(dt);
           }
           catch (Exception e1) { }
          

           return lstEternalTrainings.FirstOrDefault();
       }
    }
}
