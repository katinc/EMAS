using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class TemplateDataMapper
    {
        private DALHelper dal;
        private Template template;

        public TemplateDataMapper()
        {
            this.dal = new DALHelper();
            this.template = new Template();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Template template = (Template)item;
                dal.ClearParameters();
                dal.CreateParameter("@USERID", template.USERINFO.USERID, DbType.Int32);
                dal.CreateParameter("@FINGERID", template.FINGERID, DbType.Int32);
                dal.CreateParameter("@TEMPLATE", template.TEMPLATE, DbType.Binary);
                dal.CreateParameter("@TEMPLATE2", template.TEMPLATE2, DbType.Binary);
                dal.CreateParameter("@TEMPLATE3", template.TEMPLATE3, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE", template.BITMAPPICTURE, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE2", template.BITMAPPICTURE2, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE3", template.BITMAPPICTURE3, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE4", template.BITMAPPICTURE4, DbType.Binary);
                dal.CreateParameter("@USETYPE", template.USERTYPE, DbType.Int32);
                dal.CreateParameter("@EMACHINENUM", template.EMACHINENUM, DbType.Int32);
                dal.CreateParameter("@TEMPLATE1", template.TEMPLATE1, DbType.Binary);
                dal.CreateParameter("@Flag", template.Flag, DbType.Int32);
                dal.CreateParameter("@DivisionFP", template.DivisionFP, DbType.Int32);
                dal.CreateParameter("@TEMPLATE4", template.TEMPLATE4, DbType.Binary);
                dal.ExecuteNonQuery("Insert Into TEMPLATE(USERID,FINGERID,TEMPLATE,TEMPLATE2,TEMPLATE3,BITMAPPICTURE,BITMAPPICTURE2,BITMAPPICTURE3,BITMAPPICTURE4,USETYPE,EMACHINENUM,TEMPLATE1,Flag,DivisionFP,TEMPLATE4) Values(@USERID,@FINGERID,@TEMPLATE,@TEMPLATE2,@TEMPLATE3,@BITMAPPICTURE,@BITMAPPICTURE2,@BITMAPPICTURE3,@BITMAPPICTURE4,@USETYPE,@EMACHINENUM,@TEMPLATE1,@Flag,@DivisionFP,@TEMPLATE4)");                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Template template = (Template)item;
                dal.ClearParameters();
                dal.CreateParameter("@TEMPLATEID", template.TEMPLATEID, DbType.Int32);
                dal.CreateParameter("@USERID", template.USERINFO.USERID, DbType.Int32);
                dal.CreateParameter("@FINGERID", template.FINGERID, DbType.Int32);
                dal.CreateParameter("@TEMPLATE", template.TEMPLATE, DbType.Binary);
                dal.CreateParameter("@TEMPLATE2", template.TEMPLATE2, DbType.Binary);
                dal.CreateParameter("@TEMPLATE3", template.TEMPLATE3, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE", template.BITMAPPICTURE, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE2", template.BITMAPPICTURE2, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE3", template.BITMAPPICTURE3, DbType.Binary);
                dal.CreateParameter("@BITMAPPICTURE4", template.BITMAPPICTURE4, DbType.Binary);
                dal.CreateParameter("@USETYPE", template.USERTYPE, DbType.Int32);
                dal.CreateParameter("@EMACHINENUM", template.EMACHINENUM, DbType.Int32);
                dal.CreateParameter("@TEMPLATE1", template.TEMPLATE1, DbType.Binary);
                dal.CreateParameter("@Flag", template.Flag, DbType.Int32);
                dal.CreateParameter("@DivisionFP", template.DivisionFP, DbType.Int32);
                dal.CreateParameter("@TEMPLATE4", template.TEMPLATE4, DbType.Binary);
                dal.ExecuteNonQuery("Update TEMPLATE Set USERID=@USERID,FINGERID=@FINGERID,TEMPLATE=@TEMPLATE,TEMPLATE2=@TEMPLATE2,TEMPLATE3=@TEMPLATE3,BITMAPPICTURE=@BITMAPPICTURE,BITMAPPICTURE2=@BITMAPPICTURE2,BITMAPPICTURE3=@BITMAPPICTURE3,BITMAPPICTURE4=@BITMAPPICTURE4,USETYPE=@USETYPE,EMACHINENUM=@EMACHINENUM,TEMPLATE1=@TEMPLATE1,Flag=@Flag,DivisionFP=@DivisionFP,TEMPLATE4=@TEMPLATE4 Where TEMPLATEID=@TEMPLATEID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<Template> GetAll()
        {
            IList<Template> templates = new List<Template>();
            string query = "Select * from TEMPLATEView ";
            DataTable table = dal.ExecuteReader(query);

            foreach (Template temp in BuildTemplateFromData(table))
            {
                templates.Add(temp);
            }
            return templates;
        }
        #endregion

        #region GetByCriteria
        public IList<Template> GetByCriteria(Query query1)
        {
            IList<Template> templates = new List<Template>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from TEMPLATEView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Order By TEMPLATEView.USERID ";
                table = dal.ExecuteReader(selectStatement);
                foreach (Template temp in BuildTemplateFromData(table))
                {
                    templates.Add(temp);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return templates;
        }
        #endregion

        #region BuildTemplateFromData
        private IList<Template> BuildTemplateFromData(DataTable table)
        {
            IList<Template> templates = new List<Template>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Template template = new Template()
                    {
                        //Personal Info
                        TEMPLATEID = int.Parse(row["TEMPLATEID"].ToString()),
                        USERINFO = new UserInfo()
                        {
                            BADGENUMBER = row["BADGENUMBER"] == DBNull.Value ? null : row["BADGENUMBER"].ToString(),
                            SSN = row["SSN"] == DBNull.Value ? null : row["SSN"].ToString(),
                            NAME = row["NAME"] == DBNull.Value ? null : row["NAME"].ToString(),
                            GENDER = (GenderGroups)Enum.Parse(typeof(GenderGroups), row["GENDER"].ToString()),
                            Title = new Title() { Description = row["TITLE"] == DBNull.Value ? null : row["TITLE"].ToString() },
                            PAGER = row["PAGER"] == DBNull.Value ? null : row["PAGER"].ToString(),
                            BIRTHDATE = row["BIRTHDATE"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["BIRTHDATE"].ToString()),
                            HIREDDAY = row["HIREDDAY"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["HIREDDAY"].ToString()),
                            STREET = row["STREET"] == DBNull.Value ? null : row["STREET"].ToString(),
                            CITY = row["CITY"] == DBNull.Value ? null : row["CITY"].ToString(),
                            STATE = row["STATE"] == DBNull.Value ? null : row["STATE"].ToString(),

                            ZIP = row["ZIP"] == DBNull.Value ? null : row["ZIP"].ToString(),
                            OPHONE = row["OPHONE"] == DBNull.Value ? null : row["OPHONE"].ToString(),
                            FPHONE = row["FPHONE"] == DBNull.Value ? null : row["FPHONE"].ToString(),

                            VERIFICATIONMETHOD = row["VERIFICATIONMETHOD"] == DBNull.Value ? 0 : int.Parse(row["VERIFICATIONMETHOD"].ToString()),
                            Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString() },
                            SECURITYFLAGS = row["SECURITYFLAGS"] == DBNull.Value ? 0 : int.Parse(row["SECURITYFLAGS"].ToString()),
                            ATT = row["ATT"] == DBNull.Value ? 0 : int.Parse(row["ATT"].ToString()),
                            INLATE = row["INLATE"] == DBNull.Value ? 0 : int.Parse(row["INLATE"].ToString()),
                            OUTEARLY = row["OUTEARLY"] == DBNull.Value ? 0 : int.Parse(row["OUTEARLY"].ToString()),
                            OVERTIME = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                            SEP = row["SEP"] == DBNull.Value ? 0 : int.Parse(row["SEP"].ToString()),
                            HOLIDAY = row["HOLIDAY"] == DBNull.Value ? 0 : int.Parse(row["HOLIDAY"].ToString()),
                            MINZU = row["MINZU"] == DBNull.Value ? null : row["MINZU"].ToString(),
                            PASSWORD = row["PASSWORD"] == DBNull.Value ? null : row["PASSWORD"].ToString(),
                            LUNCHDURATION = row["LUNCHDURATION"] == DBNull.Value ? 0 : int.Parse(row["LUNCHDURATION"].ToString()),
                            MVerifyPass = row["MVerifyPass"] == DBNull.Value ? null : row["MVerifyPass"].ToString(),
                            PHOTO = row["PHOTO"] is DBNull ? null : Global.ArrayToImage((byte[])row["PHOTO"]),
                            Notes = row["Notes"] is DBNull ? null : Global.ArrayToImage((byte[])row["Notes"]),
                            Privilege = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                            InheritDeptSch = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                            InheritDeptSchClass = row["OVERTIME"] == DBNull.Value ? 0 : int.Parse(row["OVERTIME"].ToString()),
                            AutoSchPlan = row["AutoSchPlan"] == DBNull.Value ? 0 : int.Parse(row["AutoSchPlan"].ToString()),
                            MinAutoSchInterval = row["MinAutoSchInterval"] == DBNull.Value ? 0 : int.Parse(row["MinAutoSchInterval"].ToString()),
                            RegisterOT = row["RegisterOT"] == DBNull.Value ? 0 : int.Parse(row["RegisterOT"].ToString()),
                            InheritDeptRule = row["InheritDeptRule"] == DBNull.Value ? 0 : int.Parse(row["InheritDeptRule"].ToString()),
                            EMPRIVILEGE = row["EMPRIVILEGE"] == DBNull.Value ? 0 : int.Parse(row["EMPRIVILEGE"].ToString()),
                            CardNo = row["CardNo"] == DBNull.Value ? null : row["CardNo"].ToString(),
                        },
                        FINGERID = row["FINGERID"] == DBNull.Value ? 0 : int.Parse(row["FINGERID"].ToString()),
                        TEMPLATE = row["TEMPLATE"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["TEMPLATE"]),
                        TEMPLATE1 = row["TEMPLATE1"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["TEMPLATE1"]),
                        TEMPLATE2 = row["TEMPLATE2"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["TEMPLATE2"]),
                        TEMPLATE3 = row["TEMPLATE3"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["TEMPLATE3"]),
                        TEMPLATE4 = row["TEMPLATE4"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["TEMPLATE4"]),
                        BITMAPPICTURE = row["BITMAPPICTURE"] is DBNull ? null : Global.ArrayToImage((byte[])row["BITMAPPICTURE"]),
                        BITMAPPICTURE2 = row["BITMAPPICTURE2"] is DBNull ? null : Global.ArrayToImage((byte[])row["BITMAPPICTURE2"]),
                        BITMAPPICTURE3 = row["BITMAPPICTURE3"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["BITMAPPICTURE3"]),
                        BITMAPPICTURE4 = row["BITMAPPICTURE4"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["BITMAPPICTURE4"]),
                        USERTYPE = row["USERTYPE"] == DBNull.Value ? 0 : int.Parse(row["USERTYPE"].ToString()),

                        EMACHINENUM = row["EMACHINENUM"] == DBNull.Value ? null : row["EMACHINENUM"].ToString(),
                        Flag = row["Flag"] == DBNull.Value ? 0 : int.Parse(row["Flag"].ToString()),
                        DivisionFP = row["DivisionFP"] == DBNull.Value ? 0 : int.Parse(row["DivisionFP"].ToString()),
                    };

                    templates.Add(template);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return templates;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                Applicant applicant = (Applicant)item;
                dal.ExecuteNonQuery("Update TEMPLATE Set Archived='True' Where ID ="+ applicant.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
