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
   public class TrainingBondDataMapper
    {
       private List<TrainingBond> lstTrainingBonds;
       private QualificationDataMapper qualificationDataMapper;
       private TrainingAttendanceModeMapper attendanceModeMapper;
       private AttendedSchoolDataMapper schoolDataMapper;
       private SponsoredCertProgrammeDataMapper sponsoredProgrammeDataMapper;
       private SponsorshipGuarantersDataMapper guarantersDataMapper;
       private EmployeeDataMapper StaffDataMapper;

       private UserInfoDataMapper userInfoMapper;
       private DALHelper dalHelper;

       public TrainingBondDataMapper()
       {
           this.lstTrainingBonds=new List<TrainingBond>();
           qualificationDataMapper = new QualificationDataMapper();
           attendanceModeMapper = new TrainingAttendanceModeMapper();
           schoolDataMapper = new AttendedSchoolDataMapper();
           sponsoredProgrammeDataMapper = new SponsoredCertProgrammeDataMapper();
           guarantersDataMapper = new SponsorshipGuarantersDataMapper();
           StaffDataMapper = new EmployeeDataMapper();
           this.dalHelper = new DALHelper();

           this.userInfoMapper = new UserInfoDataMapper();
       }
       public List<TrainingBond> getData()
       {
           try
           {
               dalHelper.ClearParameters();
               DataTable dtTrainingBonds = dalHelper.ExecuteReader("select * from ViewTrainingBond where archived='false' order by entrydate desc, Qualification asc");
               MappData(dtTrainingBonds);
           }
           catch (Exception e1) { Logger.LogError(e1); }
          
           return lstTrainingBonds;
       }

       public List<TrainingBond> getData(DALHelper newDalHelper)
       {
           try
           {
              // dalHelper.ClearParameters();
               this.dalHelper = newDalHelper;
               
               DataTable dtTrainingBonds = this.dalHelper.ExecuteReader(this.dalHelper.CurrentCommand.CommandText);
               MappData(dtTrainingBonds);
           }
           catch (Exception e1) { Logger.LogError(e1); }

           return lstTrainingBonds;
       }
      
       public TrainingBond getById(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);
               DataTable dtTrainingBonds = dalHelper.ExecuteReader("select * from ViewTrainingBond where archived='false' and id=@Id order by entrydate desc, Qualification asc");
               MappData(dtTrainingBonds);
           }
           catch (Exception e1) { Logger.LogError(e1); }

           return lstTrainingBonds.FirstOrDefault();
       }
       private void MappData(DataTable dtTrainingBonds)
       {
           try
           {
               lstTrainingBonds.Clear();
               TrainingBond trainingBond;
               foreach (DataRow dRow in dtTrainingBonds.Rows)
               {
                   trainingBond = new TrainingBond();
                   trainingBond.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                   trainingBond.AspiredQualification = dRow["qualificationId"] != DBNull.Value ? qualificationDataMapper.GetRawQualificationByID(Convert.ToInt32(dRow["qualificationId"])) : trainingBond.AspiredQualification;
                   trainingBond.CourseAttendanceMode = dRow["AttendanceModeId"] != DBNull.Value ? attendanceModeMapper.getById(Convert.ToInt32(dRow["AttendanceModeId"])) : trainingBond.CourseAttendanceMode;
                   trainingBond.CourseStartDate = dRow["courseStartDate"] != DBNull.Value ? Convert.ToDateTime(dRow["courseStartDate"]) : trainingBond.CourseStartDate;
                   trainingBond.CourseEndDate = dRow["courseEndDate"] != DBNull.Value ? Convert.ToDateTime(dRow["courseEndDate"]) : trainingBond.CourseEndDate;
                   trainingBond.DeclarationDate = dRow["declarationDate"] != DBNull.Value ? Convert.ToDateTime(dRow["declarationDate"]) : trainingBond.DeclarationDate;
                   trainingBond.EntryDate = dRow["entrydate"] != DBNull.Value ? Convert.ToDateTime(dRow["entrydate"]) : trainingBond.EntryDate;
                   trainingBond.School = dRow["schoolId"] != DBNull.Value ? schoolDataMapper.getById(Convert.ToInt32(dRow["schoolId"])) : trainingBond.School;
                   trainingBond.SponsoredProgrammeCategory = dRow["sponsoredProgrammeGroupId"] != DBNull.Value ? sponsoredProgrammeDataMapper.getById(Convert.ToInt32(dRow["sponsoredProgrammeGroupId"])) : trainingBond.SponsoredProgrammeCategory;
                   trainingBond.SponsorshipGuaranters = guarantersDataMapper.getData(trainingBond.Id);
                   trainingBond.Staff = dRow["staffId"] != DBNull.Value ? StaffDataMapper.GetByID(Convert.ToInt32(dRow["staffId"])) : trainingBond.Staff;
                   trainingBond.WitnessDate = dRow["witnessDate"] != DBNull.Value ? Convert.ToDateTime(dRow["witnessDate"]) : trainingBond.WitnessDate;
                   trainingBond.WitnessedBy = dRow["witnessByName"] != DBNull.Value ? Convert.ToString(dRow["witnessByName"]) : trainingBond.WitnessedBy;
                   trainingBond.WitnessStamp = dRow["witnessStamp"] != DBNull.Value ? (byte[])dRow["witnessStamp"] : trainingBond.WitnessStamp;
                   trainingBond.EntryBy = dRow["entryById"] != DBNull.Value ? userInfoMapper.GetById(Convert.ToInt32(dRow["entryById"])) : trainingBond.EntryBy;
                   trainingBond.Status = dRow["status"] != DBNull.Value ? Convert.ToString(dRow["status"]) : string.Empty;
                   trainingBond.ForAdditionalQualification = dRow["forAdditionalQualification"] != DBNull.Value ? Convert.ToBoolean(dRow["forAdditionalQualification"]) : true;
                   trainingBond.letterName = dRow["letterName"] != DBNull.Value ? Convert.ToString(dRow["letterName"]) : string.Empty;

                   lstTrainingBonds.Add(trainingBond);
               }
           }
           catch (Exception e1) { }
           
       }
    }
}
