using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using Microsoft.VisualBasic;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
   public  class ExcuseDutyRequestTypeDataMapper
    {
        private DALHelper dal;

        public ExcuseDutyRequestTypeDataMapper()
        {
            this.dal = new DALHelper();
         
        }
        
        public List<ExcuseDutyRequestType> getAll(int userid)
        {
            dal.ClearParameters();
            dal.CreateParameter("@active", true, DbType.Boolean);
            dal.CreateParameter("@archived", false, DbType.Boolean);
            dal.CreateParameter("@userid", userid, DbType.Int32);

            var dtRequestTypes = dal.ExecuteReader("select * from ExcuseDutyRequestTypes where active=@active and archived=@archived");

            List<ExcuseDutyRequestType> lstrequestType = new List<ExcuseDutyRequestType>();
            foreach (DataRow dr in dtRequestTypes.Rows)
            {
                ExcuseDutyRequestType requestType = new ExcuseDutyRequestType();

                requestType.id = Convert.ToInt32(dr["id"]);
                requestType.description = dr["description"].ToString();
                requestType.userid = dr["userid"]!=DBNull.Value? Convert.ToInt32(dr["userid"]):0;
                requestType.archived = Convert.ToBoolean(dr["archived"]);
                requestType.active = Convert.ToBoolean(dr["active"]);

                lstrequestType.Add(requestType);
            }
            return lstrequestType;
        }

        public ExcuseDutyRequestType getById(int id)
        {
            dal.ClearParameters();
            dal.CreateParameter("@active", true, DbType.Boolean);
            dal.CreateParameter("@archived", false, DbType.Boolean);
            dal.CreateParameter("@id", id, DbType.Int32);

            var dtRequestTypes = dal.ExecuteReader("select * from ExcuseDutyRequestTypes where active=@active and archived=@archived and id=@id");

            ExcuseDutyRequestType requestType = new ExcuseDutyRequestType();
            foreach (DataRow dr in dtRequestTypes.Rows)
            {
               
                requestType.id = Convert.ToInt32(dr["id"]);
                requestType.description = dr["description"].ToString();
                requestType.userid = Convert.ToInt32(dr["userid"]);
                requestType.archived = Convert.ToBoolean(dr["archived"]);
                requestType.active = Convert.ToBoolean(dr["active"]);

            }
            return requestType;
        }
      
    }
}
