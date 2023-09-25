using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class ProfessionDataMapper
    {
        private DALHelper dal;
        private Profession profession;

        public ProfessionDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.profession = new Profession();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<Profession> GetAll()
        {
            IList<Profession> professions = new List<Profession>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffProfessionHistoryView Where StaffProfessionHistoryView.Archived='False'");

                foreach (Profession prof in BuildProfessionFromData(table))
                {
                    professions.Add(prof);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return professions;
        }

        public Profession GetByID(object key)
        {
            IList<Profession> professions = new List<Profession>();
            Profession profession = new Profession();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffProfessionHistoryView Where StaffProfessionHistoryView.StaffID=@StaffID and StaffProfessionHistoryView.Archived=@Archived");
                
                foreach (Profession pf in BuildProfessionFromData(table))
                {
                    profession = pf;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return profession;
        }

        #region GetByCriteria
        public IList<Profession> GetByCriteria(Query query1)
        {
            IList<Profession> professions = new List<Profession>();
            Profession profession = new Profession();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", profession.Archived, DbType.Boolean);
                string query = "select * from StaffProfessionHistoryView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffProfessionHistoryView.Archived=@Archived order BY StaffProfessionHistoryView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Profession prof in BuildProfessionFromData(table))
                {
                    professions.Add(prof);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return professions;
        }
        #endregion

        private IList<Profession> BuildProfessionFromData(DataTable table)
        {
            IList<Profession> professions = new List<Profession>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Profession profession = new Profession()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        NameOfProfession = row["NameOfProfession"].ToString(),
                        FromMonth = row["StartMonth"].ToString(),
                        ToMonth = row["EndMonth"].ToString(),
                        FromYear = row["StartYear"].ToString(),
                        ToYear = row["EndYear"].ToString(),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                        },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    };
                    professions.Add(profession);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return professions;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", "True", DbType.String);

                dal.ExecuteNonQuery("Update StaffProfessionHistory Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
