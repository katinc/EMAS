using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class TrainingOrganizersDataMapper
    {
       private List<TrainingOrganizer> lstTrainingOrganizers;
      private DALHelper dalHelper;
      public TrainingOrganizersDataMapper()
      {
          this.lstTrainingOrganizers = new List<TrainingOrganizer>();
       dalHelper=new DALHelper();
          
      }
      public List<TrainingOrganizer> getAll(bool Active)
      {
          try
          {
              dalHelper = new DALHelper();
              dalHelper.CreateParameter("@Active", Active, DbType.Boolean);
              DataTable dt = dalHelper.ExecuteReader("Select * from TrainingOrganizers where Archived='false' and Active=@Active");
              DataMapper(dt);
          }
          catch (Exception e1) { }
         
         return lstTrainingOrganizers;
      }
      public TrainingOrganizer getById(int Id)
      {
          try
          {
              dalHelper = new DALHelper();
              dalHelper.ClearParameters();
              dalHelper.CreateParameter("@Id", Id, DbType.Int32);
              DataTable dt = dalHelper.ExecuteReader("Select * from TrainingOrganizers where Archived='false' and id=@Id");
              DataMapper(dt);
          }
          catch (Exception e1) { }

          return lstTrainingOrganizers.FirstOrDefault();
      }
      void DataMapper(DataTable dt)
      {
          lstTrainingOrganizers.Clear();
          foreach (DataRow dRow in dt.Rows)
          {
              TrainingOrganizer sponsor = new TrainingOrganizer();
              sponsor.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : sponsor.Id;
              sponsor.Code = dRow["Code"] != DBNull.Value ? Convert.ToString(dRow["Code"]) : sponsor.Code;
              sponsor.Description = dRow["Description"] != DBNull.Value ? Convert.ToString(dRow["Description"]) : sponsor.Description;
              sponsor.Active = dRow["Active"] != DBNull.Value ? Convert.ToBoolean(dRow["Active"]) : sponsor.Active;
              sponsor.Archived = dRow["Archived"] != DBNull.Value ? Convert.ToBoolean(dRow["Archived"]) : sponsor.Archived;

              lstTrainingOrganizers.Add(sponsor);
          }
      }
    }
}
