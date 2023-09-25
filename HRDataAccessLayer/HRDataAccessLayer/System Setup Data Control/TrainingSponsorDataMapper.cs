using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
  public  class TrainingSponsorDataMapper
    {
      private List<TrainingSponsor> lstTrainingSponsors;
      private DALHelper dalHelper;
      private CompanyDataMapper companyMapper;
      private IList< Company> lstcurrentCompany;
      public TrainingSponsorDataMapper()
      {
          this.lstTrainingSponsors = new List<TrainingSponsor>();
       dalHelper=new DALHelper();
       companyMapper = new CompanyDataMapper();
       lstcurrentCompany = new List<Company>();
      }
      public void AddCurrentCompany()
      {
          try
          {
              lstcurrentCompany = companyMapper.GetAll();
              int ctr = 0;
              foreach (var company in lstcurrentCompany)
              {
                  dalHelper.ClearParameters();
                  dalHelper.CreateParameter("@Description", company.Name.Trim(), DbType.String);
                  var ExistiningEntry = dalHelper.ExecuteReader("select * from TrainingSponsors where Description=@Description");
                  if (company.Name != string.Empty && ExistiningEntry == null)
                  {
                      dalHelper = new DALHelper();
                      dalHelper.ClearParameters();
                      // dalHelper.CreateParameter("@id", company.ID, DbType.Int32);
                      dalHelper.CreateParameter("@code", "INT-" + (++ctr), DbType.String);
                      dalHelper.CreateParameter("@Description", company.Name.Trim(), DbType.String);
                      dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                      dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                      dalHelper.ExecuteNonQuery("insert into TrainingSponsors (code,Description,Active) values (@code,@Description,@Active)");
                  }


              }
             
          }
          catch (Exception e1) { }
      }
      public List<TrainingSponsor> getAll(bool Active)
      {
          try
          {
              dalHelper = new DALHelper();
              dalHelper.CreateParameter("@Active", Active, DbType.Boolean);
              DataTable dt = dalHelper.ExecuteReader("Select * from TrainingSponsors where Archived='false' and Active=@Active");
             
              
              DataMapper(dt);
              
          }
          catch (Exception e1) { }
         
         return lstTrainingSponsors;
      }
      public TrainingSponsor getById(int Id)
      {
          try
          {
              dalHelper = new DALHelper();
              dalHelper.ClearParameters();
              dalHelper.CreateParameter("@Id", Id, DbType.Int32);
              DataTable dt = dalHelper.ExecuteReader("Select * from TrainingSponsors where Archived='false' and id=@Id");
              DataMapper(dt);
          }
          catch (Exception e1) { }

          return lstTrainingSponsors.FirstOrDefault();
      }
      void DataMapper(DataTable dt)
      {
          lstTrainingSponsors.Clear();
          foreach (DataRow dRow in dt.Rows)
          {
              TrainingSponsor sponsor = new TrainingSponsor();
              sponsor.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : sponsor.Id;
              sponsor.Description = dRow["Description"] != DBNull.Value ? Convert.ToString(dRow["Description"]) : sponsor.Description;
              sponsor.Code = dRow["Code"] != DBNull.Value ? Convert.ToString(dRow["Code"]) : sponsor.Code;
              sponsor.Active = dRow["Active"] != DBNull.Value ? Convert.ToBoolean(dRow["Active"]) : sponsor.Active;
              sponsor.Archived = dRow["Archived"] != DBNull.Value ? Convert.ToBoolean(dRow["Archived"]) : sponsor.Archived;

              lstTrainingSponsors.Add(sponsor);
          }
      }
    }
}
