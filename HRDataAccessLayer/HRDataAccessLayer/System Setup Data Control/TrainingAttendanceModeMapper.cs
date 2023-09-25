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
   public class TrainingAttendanceModeMapper
    {
       private IList<TrainingAttendanceMode> lsttraningAttendanceMode;
       private DALHelper dalHelper;

      

       public TrainingAttendanceModeMapper()
       {
           lsttraningAttendanceMode = new List< TrainingAttendanceMode>();
           dalHelper = new DALHelper();

       }

       public IList<TrainingAttendanceMode> GetData()
       {
           try{
           dalHelper.ClearParameters();
           DataTable dtAttendanceModes=dalHelper.ExecuteReader("select * from TrainingAttendanceModes order by description");

           MappData(dtAttendanceModes);
             }
           catch (Exception ei)
           {
               Logger.LogError(ei);
           }
          

           return lsttraningAttendanceMode;
       }

       public TrainingAttendanceMode getById(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@id", Id, DbType.Int32);
               DataTable dtAttendanceModes = dalHelper.ExecuteReader("select * from TrainingAttendanceModes where id=@id order by description");

               MappData(dtAttendanceModes);
           }
           catch (Exception ei)
           {
               Logger.LogError(ei);
           }
          

           return lsttraningAttendanceMode.FirstOrDefault();
       }

       private void MappData(DataTable dtAttendanceModes)
       {
           try
           {
               lsttraningAttendanceMode.Clear();
               TrainingAttendanceMode trainingAttendanceMode;
               foreach (DataRow dRow in dtAttendanceModes.Rows)
               {
                   trainingAttendanceMode = new TrainingAttendanceMode();
                   trainingAttendanceMode.Id = dRow["id"] != DBNull.Value ? Convert.ToInt32(dRow["id"]) : 0;
                   trainingAttendanceMode.Description = dRow["description"] != DBNull.Value ? dRow["description"].ToString() : string.Empty;
                   trainingAttendanceMode.Active = dRow["active"] != DBNull.Value ? Convert.ToBoolean(dRow["active"]) : false;
                   trainingAttendanceMode.Archived = dRow["archived"] != DBNull.Value ? Convert.ToBoolean(dRow["archived"]) : false;

                   lsttraningAttendanceMode.Add(trainingAttendanceMode);
               }
           }
           catch (Exception ei) { }
           
       }

    }
}
