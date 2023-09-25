using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
   public class SponsorshipGuarantersDataMapper
    {
       private List<SponsorshipGuaranter> lstSponsorshipGuaranters;
       private TrainingBond trainingBond;
       private DALHelper dalHelper;

       private StaffIdentificationTypesDataMapper identityDataMapper;

       public SponsorshipGuarantersDataMapper()
       {
           this.lstSponsorshipGuaranters = new List<SponsorshipGuaranter>();
           this.trainingBond = new TrainingBond();
           this.dalHelper = new DALHelper();
           this.identityDataMapper = new StaffIdentificationTypesDataMapper();
       }

       public List<SponsorshipGuaranter> getData()
       {
           try
           {
               dalHelper.ClearParameters();
               DataTable dtGuaranters = dalHelper.ExecuteReader("select * from viewSponsorshipGuaranters order by GuaranterName");
               DataMapper(dtGuaranters);
           }
           catch (Exception e1)
           {
               Logger.LogError(e1);
           }
          
         return lstSponsorshipGuaranters;
       }
       public List<SponsorshipGuaranter> getData(int trainingBondId)
       {
           try{
           dalHelper.ClearParameters();
           dalHelper.CreateParameter("@trainingBondId", trainingBondId, DbType.Int32);
           DataTable dtGuaranters = dalHelper.ExecuteReader("select * from viewSponsorshipGuaranters where trainingBondId=@trainingBondId  order by GuaranterName");
           DataMapper(dtGuaranters);
           }
           catch (Exception e1)
           {
               Logger.LogError(e1);
           }
           return lstSponsorshipGuaranters;
       }
       public SponsorshipGuaranter getById(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);
               DataTable dtGuaranters = dalHelper.ExecuteReader("select * from viewSponsorshipGuaranters where id=@Id  order by GuaranterName");
               DataMapper(dtGuaranters);
           }
           catch (Exception e1)
           {
               Logger.LogError(e1);
           }
           return lstSponsorshipGuaranters.FirstOrDefault();
       }
       private void DataMapper(DataTable dtSponsorshipGuaranters)
       {
           lstSponsorshipGuaranters.Clear();
           try
           {
               int ctr = 0;
               SponsorshipGuaranter sponsorshipGuaranter;
               foreach (DataRow dRow in dtSponsorshipGuaranters.Rows)
               {
                   sponsorshipGuaranter = new SponsorshipGuaranter();
                   sponsorshipGuaranter.TrainingBond = trainingBond;
                   sponsorshipGuaranter.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : sponsorshipGuaranter.Id;
                   sponsorshipGuaranter.GuaranterName = dRow["GuaranterName"] != DBNull.Value ? dRow["GuaranterName"].ToString() : string.Empty;
                   sponsorshipGuaranter.Designation = dRow["Designation"] != DBNull.Value ? dRow["Designation"].ToString() : string.Empty;
                   sponsorshipGuaranter.ListIndex = ++ctr;
                   sponsorshipGuaranter.Email = dRow["Email"] != DBNull.Value ? dRow["Email"].ToString() : sponsorshipGuaranter.Email;
                   sponsorshipGuaranter.EmpNumber = dRow["EmpNumber"] != DBNull.Value ? dRow["EmpNumber"].ToString() : string.Empty;
                   sponsorshipGuaranter.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : false;
                   sponsorshipGuaranter.Address = dRow["Address"] != DBNull.Value ? Convert.ToString(dRow["Address"]) : string.Empty;
                   sponsorshipGuaranter.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : false;
                   sponsorshipGuaranter.MobileNo = dRow["MobileNo"] != DBNull.Value ? Convert.ToString(dRow["MobileNo"]) : string.Empty;
                   sponsorshipGuaranter.Organization = dRow["Organization"] != DBNull.Value ? Convert.ToString(dRow["Organization"]) : string.Empty;
                   sponsorshipGuaranter.PassPortExpiryDate = dRow["PassPortExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dRow["PassPortExpiryDate"]) : sponsorshipGuaranter.PassPortExpiryDate;
                   sponsorshipGuaranter.PassPortIssueDate = dRow["PassPortIssueDate"] != DBNull.Value ? Convert.ToDateTime(dRow["PassPortIssueDate"]) : sponsorshipGuaranter.PassPortIssueDate;
                   sponsorshipGuaranter.PassPortNo = dRow["PassPortNo"] != DBNull.Value ? Convert.ToString(dRow["PassPortNo"]) : string.Empty;
                   sponsorshipGuaranter.Photo = dRow["Photo"] != DBNull.Value ? (byte[])dRow["Photo"] : sponsorshipGuaranter.Photo;
                   sponsorshipGuaranter.Signature = dRow["Signature"] != DBNull.Value ? (byte[])dRow["Signature"] : sponsorshipGuaranter.Signature;


                   sponsorshipGuaranter.IdentificationType = dRow["IdentityTypeId"] != DBNull.Value ? identityDataMapper.getById(Convert.ToInt32(dRow["IdentityTypeId"])) : sponsorshipGuaranter.IdentificationType;

                   lstSponsorshipGuaranters.Add(sponsorshipGuaranter);

               }
           }
           catch (Exception e1) { }
           
       }
    }
}
