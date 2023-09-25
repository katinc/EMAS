using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using System.ComponentModel;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class OccupationalGroupingDataMapper
    {
        private DALHelper dal;
        private OccupationGroup occupationGroup;

        public OccupationalGroupingDataMapper()
        {
            this.dal = new DALHelper();
            this.occupationGroup = new OccupationGroup();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                OccupationGroup occupationGroup = (OccupationGroup)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", occupationGroup.Description, DbType.String);
                dal.CreateParameter("@Active", occupationGroup.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", occupationGroup.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into OccupationGroups (Description,Active,UserID) Values(@Description,@Active,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                OccupationGroup occupationGroup = (OccupationGroup)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", occupationGroup.ID, DbType.String);
                dal.CreateParameter("@Description", occupationGroup.Description, DbType.String);
                dal.CreateParameter("@Active", occupationGroup.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", occupationGroup.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", occupationGroup.Archived, DbType.String);

                dal.ExecuteNonQuery("Update OccupationGroups Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<OccupationGroup> GetAll()
        {
            IList<OccupationGroup> occupationGroups = new List<OccupationGroup>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", occupationGroup.Archived, DbType.String);
                string query = "select * from OccupationGroupView ";
                query += "WHERE OccupationGroupView.Archived=@Archived order BY OccupationGroupView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (OccupationGroup occ in BuildOccupationGroupFromData(table))
                {
                    occupationGroups.Add(occ);
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                throw ex;
            }

            return occupationGroups;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Relationship relationship = (Relationship)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", relationship.ID, DbType.Int32);
                dal.CreateParameter("@Archived", relationship.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", relationship.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update OccupationGroups Set Active=@Active,Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<OccupationGroup> GetByCriteria(Query query1)
        {
            IList<OccupationGroup> occupationGroups = new List<OccupationGroup>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", occupationGroup.Archived, DbType.Boolean);

                string query = "select * from OccupationGroupView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  OccupationGroupView.Archived=@Archived order BY OccupationGroupView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (OccupationGroup occ in BuildOccupationGroupFromData(table))
                {
                    occupationGroups.Add(occ);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return occupationGroups;
        }
        #endregion

        #region BuildOccupationGroupFromData
        private IList<OccupationGroup> BuildOccupationGroupFromData(DataTable table)
        {
            IList<OccupationGroup> occupationGroups = new List<OccupationGroup>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    OccupationGroup occupationGroup = new OccupationGroup()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    occupationGroups.Add(occupationGroup);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return occupationGroups;
        }
        #endregion


        #region Open Connection
        public void OpenConnection()
        {
            try
            {
                dal.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Close Connection
        public void CloseConnection()
        {
            try
            {
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}