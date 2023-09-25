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
    public class DenominationDataMapper
    {
        private DALHelper dal;
        private Denomination denomination;

        public DenominationDataMapper()
        {
            this.dal = new DALHelper();
            this.denomination = new Denomination();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Denomination denomination = (Denomination)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", denomination.Description, DbType.String);
                dal.CreateParameter("@ReligionID", denomination.Religion.ID, DbType.String);
                dal.CreateParameter("@Active", denomination.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", denomination.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Denominations (Description,ReligionID,Active,UserID) Values(@Description,@ReligionID,@Active,@UserID)");
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
                Denomination denomination = (Denomination)item;
                dal.ClearParameters();
                dal.ClearParameters();
                dal.CreateParameter("@ID", denomination.ID, DbType.String);
                dal.CreateParameter("@Description", denomination.Description, DbType.String);
                dal.CreateParameter("@ReligionID", denomination.Religion.ID, DbType.String);
                dal.CreateParameter("@Active", denomination.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", denomination.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", denomination.Archived, DbType.String);

                dal.ExecuteNonQuery("Update Denominations Set Description=@Description,ReligionID=@ReligionID,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Denomination> GetAll()
        {
            IList<Denomination> denominations = new List<Denomination>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", denomination.Archived, DbType.String);
                string query = "select * from DenominationView ";
                query += "WHERE DenominationView.Archived=@Archived order BY DenominationView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    denominations.Add(new Denomination() 
                    { 
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Religion = new Religion() { ID = int.Parse(row["ReligionID"].ToString()), Description = row["Religion"].ToString() },
                        User=new User(){ID=int.Parse(row["UserID"].ToString()),UserName=row["UserName"].ToString()},
                        Active = bool.Parse(row["Active"].ToString()) ,
                        Archived = bool.Parse(row["Archived"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return denominations;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Denomination denomination = (Denomination)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", denomination.ID, DbType.Int32);
                dal.CreateParameter("@Archived", denomination.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", denomination.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Denominations Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Denomination> GetByCriteria(Query query1)
        {
            IList<Denomination> denominations = new List<Denomination>();
            DataTable table = new DataTable();

            dal.ClearParameters();
            dal.CreateParameter("@Archived", denomination.Archived, DbType.Boolean);

            string query = "select * from DenominationView ";
            string selectStatement = QueryTranslater.TranslateQuery(query, query1);
            selectStatement += "  DenominationView.Archived=@Archived order BY DenominationView.Description ASC";
            table = dal.ExecuteReader(selectStatement);
            foreach (Denomination den in BuildDenominationFromData(table))
            {
                denominations.Add(den);
            }
            return denominations;
        }
        #endregion

        #region BuildDenominationFromData
        private IList<Denomination> BuildDenominationFromData(DataTable table)
        {
            IList<Denomination> denominations = new List<Denomination>();
            foreach (DataRow row in table.Rows)
            {
                Denomination denomination = new Denomination()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Description = row["Description"].ToString(),
                    Religion = new Religion() { ID = int.Parse(row["ReligionID"].ToString()), Description = row["Religion"].ToString() },
                    User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                    Active = bool.Parse(row["Active"].ToString()),
                    Archived = bool.Parse(row["Archived"].ToString()),   
                };
                denominations.Add(denomination);
            }
            return denominations;
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
