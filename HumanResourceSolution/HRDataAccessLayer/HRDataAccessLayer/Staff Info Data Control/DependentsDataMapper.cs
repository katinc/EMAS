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
    public class DependentsDataMapper
    {
        private DALHelper dal;
        private Relation relation;

        public DependentsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.relation = new Relation();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public IList<Relation> GetAll()
        {
            IList<Relation> relations = new List<Relation>();
            try
            {
                string query = "select * from StaffOtherRelativeView Where StaffOtherRelativeView.Archived='False'";
                DataTable table = dal.ExecuteReader(query);
                
                foreach (Relation rel in BuildDependentsFromData(table))
                {
                    relation = rel;
                }              
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return relations;
        }

        public Relation GetByID(object key)
        {
            IList<Relation> relations = new List<Relation>();
            Relation relation = new Relation();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                string query = "Select * from StaffOtherRelativeView Where StaffOtherRelativeView.StaffID=@StaffID and StaffOtherRelativeView.Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);

                foreach (Relation rel in BuildDependentsFromData(table))
                {
                    relation = rel;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return relation;
        }

        public Relation GetByOtherID(object key,object key2)
        {
            IList<Relation> relations = new List<Relation>();
            Relation relation = new Relation();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString(), DbType.String);
                dal.CreateParameter("@ID", key2.ToString(), DbType.String);
                DataTable table = dal.ExecuteReader("Select * from StaffOtherRelativeView Where StaffOtherRelativeView.StaffID=@StaffID and StaffOtherRelativeView.ID=@ID and StaffOtherRelativeView.Archived=@Archived");

                foreach (Relation rel in BuildDependentsFromData(table))
                {
                    relation = rel;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return relation;
        }

        #region GetByCriteria
        public IList<Relation> GetByCriteria(Query query1)
        {
            IList<Relation> relations = new List<Relation>();
            Relation relation = new Relation();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", relation.Archived, DbType.Boolean);
                string query = "select * from StaffOtherRelativeView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  StaffOtherRelativeView.Archived=@Archived order BY StaffOtherRelativeView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Relation rela in BuildDependentsFromData(table))
                {
                    relations.Add(rela);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return relations;
        }
        #endregion

        private IList<Relation> BuildDependentsFromData(DataTable table)
        {
            IList<Relation> relations = new List<Relation>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Relation relation = new Relation()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Occupation = new Occupation() { ID = int.Parse(row["OccupationID"].ToString()), Description = row["Occupation"].ToString() },
                        Relationship = new Relationship() { ID = int.Parse(row["RelationshipID"].ToString()), Description = row["Relationship"].ToString() },
                        Address = row["Address"].ToString(),
                        Name = row["Name"].ToString(),
                        POB = new Town() { ID = int.Parse(row["POBID"].ToString()), Description = row["POB"].ToString() },
                        DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString()),
                        Telephone = row["Telephone"].ToString(),
                        Type = row["Type"] == DBNull.Value ? string.Empty : row["Type"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    };
                    relations.Add(relation);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return relations;
        }

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Relation relation = (Relation)key;
                dal.ClearParameters();
                dal.CreateParameter("@ID", relation.ID, DbType.Int32);
                dal.CreateParameter("@Archived", relation.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update StaffOtherRelatives Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion
    }
}
