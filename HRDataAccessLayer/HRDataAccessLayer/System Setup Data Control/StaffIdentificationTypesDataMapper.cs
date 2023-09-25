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
    
   public class StaffIdentificationTypesDataMapper
   {
       private DALHelper dalHelper;
       private IList<StaffIdentificationType> staffIdentificationTypes;

       public StaffIdentificationTypesDataMapper(){
           this.dalHelper = new DALHelper();
           this.staffIdentificationTypes = new List<StaffIdentificationType>();
       }
       public IList<StaffIdentificationType> getData()
       {
           try
           {
               dalHelper.ClearParameters();
               var dt = dalHelper.ExecuteReader("select * from StaffIdentificationTypes where archived='false'");
               MappData(dt);
           }
           catch (Exception xi)
           {
               Logger.LogError(xi);
           }
          return staffIdentificationTypes;
       }
       public StaffIdentificationType getById(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@ID", Id, DbType.Int32);
               var dt = dalHelper.ExecuteReader("select * from StaffIdentificationTypes where ID=@ID");
               MappData(dt);
           }
           catch (Exception xi)
           {
               Logger.LogError(xi);
           }
           return staffIdentificationTypes.FirstOrDefault();
       }
       public bool Delete(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@ID", Id, DbType.Int32);
               dalHelper.ExecuteNonQuery("delete StaffIdentificationTypes where ID=@ID");

               return true;
           }
           catch (Exception xi)
           {
               Logger.LogError(xi);
               return false;
           }
         
       }
       public bool Save(StaffIdentificationType identity)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@CardName", identity.CardName, DbType.String);
               dalHelper.CreateParameter("@Active", identity.Active, DbType.Boolean);
               dalHelper.CreateParameter("@Archived", identity.Archived, DbType.Boolean);

               if (identity.ID > 0)
               {
                   dalHelper.CreateParameter("@ID", identity.ID, DbType.Int32);

                   dalHelper.ExecuteNonQuery("update StaffIdentificationTypes set CardName=@CardName,Active=@Active,Archived=@Archived where ID=@ID");

               }
               else
                   dalHelper.ExecuteNonQuery("insert into StaffIdentificationTypes(CardName,Active,Archived)values(@CardName,@Active,@Archived)");

               return true;
           }
           catch (Exception xi)
           {
               Logger.LogError(xi);
               return false;
           }         
       }
       private void MappData(DataTable dt)
       {
           try
           {
           staffIdentificationTypes.Clear();
           foreach (DataRow dataRow in dt.Rows)
           {
               var identity = new StaffIdentificationType();
               identity.ID = Convert.ToInt32(dataRow["ID"] ?? 0);
               identity.CardName = Convert.ToString(dataRow["CardName"] ?? string.Empty);
               identity.Active = Convert.ToBoolean(dataRow["Active"] ?? false);
               identity.Archived = Convert.ToBoolean(dataRow["Archived"] ?? false);

               staffIdentificationTypes.Add(identity);
           }
          }
          catch (Exception xi)
          {
               Logger.LogError(xi);
          }
       }
   }
}
