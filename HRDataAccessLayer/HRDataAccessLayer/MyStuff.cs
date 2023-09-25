using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;
using System.Data;

namespace HRDataAccessLayer
{
    public class FingerprintTemplate
    {
        public long ID { get; set; }
        public int TmpLength { get; set; }
        public int Flag { get; set; }
        public string byTmpData { get; set; }
        public short  FingerType { get; set; }
        public string FingerTypeText { get; set; }
        public int StaffMainID { get; set; }
        public string UserType { get; set; }

        public FingerprintTemplate()
        {
            ID = 0;
            TmpLength = 0;
            Flag = 0;
            byTmpData  = "";
            FingerType = -1;
            StaffMainID = 0;
            UserType = "";
        }
    }
    public class MyStuff
    {
        private DALHelper dal;
        private IDAL idal;
        private List<StaffFingerprintTemplates> stafffingerprints;

        public MyStuff()
        {
            try
            {
                this.dal = new DALHelper();
                this.idal = new DAL();
                this.stafffingerprints = new List<StaffFingerprintTemplates>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        public DataTable getFingerTypes(int ZktecMask)
        {
            string query = "";
            dal.ClearParameters();
            query = "SELECT * from FingerTypes ";

            if (ZktecMask > -1)
            {
                dal.CreateParameter("@ZktecMask", ZktecMask, DbType.Int32);
                query += "WHERE ZktecMask=@ZktecMask ";
            }

            query += " order by ZktecMask asc";

            return dal.ExecuteReader(query);
        }

        public DataTable getConnectedDevices()
        {
            string query = "";
            dal.ClearParameters();
            query = "SELECT * from AttendanceDevices ";
            query += " WHERE CurrentStatus='True' order by ID asc";

            return dal.ExecuteReader(query);
        }

        public bool DeleteFingerPrintTemplate(int ID)
        {
            bool status = false;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", ID, DbType.Int32);
                string query = "DELETE from StaffFingerprintTemplates ";
                query += "WHERE ID=@ID";

                string query2 = "update StaffFingerprintTemplatesSync set Action='Delete', SyncedDate=NULL where TemplateID="+ ID ;

                dal.ExecuteNonQuery(query);
                dal.ExecuteNonQuery(query2);
                status = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

             return status;
        }

        public long  SaveFingerPrintTemplate(StaffFingerprintTemplates template, int DeviceID)
        {
            long ScopeID = 0;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", template.StaffID  , DbType.String);
                dal.CreateParameter("@FingerType", template.FingerType , DbType.Int32);
                dal.CreateParameter("@Template", template.Template, DbType.String);
                dal.CreateParameter("@TempLen", template.TempLen , DbType.Int32);
                dal.CreateParameter("@Flag", template.Flag , DbType.Int32);
                dal.CreateParameter("@CreatedDate", template.CreatedDate , DbType.DateTime);
                dal.CreateParameter("@UserID", template.UserID, DbType.Int32);
                dal.CreateParameter("@StaffMainID", template.StaffMainID, DbType.Int32);
                dal.CreateParameter("@UserType", template.UserType, DbType.String);

                string query = "INSERT INTO StaffFingerprintTemplates(StaffID, FingerType, Template, TempLen, Flag, CreatedDate, UserID, StaffMainID, UserType) ";
                query += " VALUES (@StaffID, @FingerType, @Template, @TempLen, @Flag, @CreatedDate, @UserID, @StaffMainID, @UserType)";
                dal.ExecuteNonQuery(query);

               DataTable tbl =  dal.ExecuteReader(" SELECT SCOPE_IDENTITY()");
             
               if (tbl.Rows.Count > 0 && tbl.Rows[0][0] != DBNull.Value )
               {
                   ScopeID = Convert.ToInt64(tbl.Rows[0][0]);
               }
               if (ScopeID == 0)
               {
                   tbl = dal.ExecuteReader(" SELECT MAX(ID) from StaffFingerprintTemplates");

                   ScopeID = Convert.ToInt64(tbl.Rows[0][0]);
               }

                dal.ClearParameters();
                dal.CreateParameter("@DeviceID", DeviceID , DbType.Int32);
                dal.CreateParameter("@TemplateID", ScopeID, DbType.Int64);
                dal.CreateParameter("@StaffID", template.StaffID, DbType.String);
                dal.CreateParameter("@Action", "Add", DbType.String);
                dal.CreateParameter("@FingerIndex", template.FingerType, DbType.Int32);
                dal.CreateParameter("@SyncedDate", DateTime.UtcNow , DbType.DateTime);
                dal.CreateParameter("@StaffMainID", template.StaffMainID, DbType.Int32);
                dal.CreateParameter("@UserType", template.UserType, DbType.String);

                string query2 = "insert into StaffFingerprintTemplatesSync(DeviceID,TemplateID,StaffID,Action,FingerIndex,SyncedDate,StaffMainID,UserType) Values(@DeviceID,@TemplateID,@StaffID,@Action,@FingerIndex,@SyncedDate,@StaffMainID,@UserType)";
                dal.ExecuteNonQuery(query2);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return ScopeID;

        }

        public List<StaffFingerprintTemplates> getStaffFingerprints(string StaffID)
        {
            List<StaffFingerprintTemplates> fingerprintList = new List<StaffFingerprintTemplates>();
            try
            {
                DataTable table = new DataTable();
                
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", StaffID, DbType.String);
                string query = "SELECT f.*,t.FingerType AS FingertypeText from StaffFingerprintTemplates f,FingerTypes t";
                query += " WHERE f.FingerType=t.ZktecMask AND f.StaffID=@StaffID  order by f.ID asc";

                table = dal.ExecuteReader(query);
                foreach (DataRow r in table.Rows)
                {
                    StaffFingerprintTemplates template = new StaffFingerprintTemplates();
                    template.ID = Convert.ToInt32(r["ID"]);
                    template.StaffID = r["StaffID"].ToString();
                    template.FingerType = Convert.ToInt32(r["FingerType"]);
                    template.Template = r["Template"].ToString();
                    template.TempLen = Convert.ToInt32(r["TempLen"]);
                    template.Flag = Convert.ToInt32(r["Flag"]);
                    template.CreatedDate = Convert.ToDateTime(r["CreatedDate"]);
                    template.UserID = Convert.ToInt32(r["UserID"]);
                    template.FingertypeText = r["FingertypeText"].ToString();

                    fingerprintList.Add(template);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return fingerprintList;
        }
    }
}
