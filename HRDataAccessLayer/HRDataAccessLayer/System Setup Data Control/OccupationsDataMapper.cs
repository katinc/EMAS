using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;


namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class OccupationsDataMapper
    {

        private DALHelper dal;
        private Occupation occupation;

        public OccupationsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.occupation = new Occupation();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Occupation occupation = (Occupation)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", occupation.Description, DbType.String);
                dal.CreateParameter("@Active", occupation.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Occupations (Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                Occupation occupation = (Occupation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", occupation.ID, DbType.Int32);
                dal.CreateParameter("@Description", occupation.Description, DbType.String);
                dal.CreateParameter("@Active", occupation.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Update LocationTypes Set Description=@Description,Active=@Active Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        public IList<Occupation> GetAll()
        {
            IList<Occupation> occupations = new List<Occupation>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * from OccupationView Where Archived='False'");
                foreach (Occupation occ in BuildOccupationFromData(table))
                {
                    occupations.Add(occ);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return occupations;
        }

        public Occupation GetByID(object key)
        {
            Occupation occupation = new Occupation();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", key.ToString(), DbType.String);

                string query = "Select * from OccupationView where id=@ID";
                DataTable table = dal.ExecuteReader(query);

                foreach (Occupation emp in BuildOccupationFromData(table))
                {
                    occupation = emp;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return occupation;
        }

        #region GetByCriteria
        public IList<Occupation> GetByCriteria(Query query1)
        {
            IList<Occupation> occupations = new List<Occupation>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from OccupationView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY Description ASC";

                table = dal.ExecuteReader(selectStatement);
                foreach (Occupation occ in BuildOccupationFromData(table))
                {
                    occupations.Add(occ);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return occupations;
        }
        #endregion

        private IList<Occupation> BuildOccupationFromData(DataTable table)
        {
            IList<Occupation> occupations = new List<Occupation>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Occupation occupation = new Occupation()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Active = bool.Parse(row["Active"].ToString()),
                    };

                    occupations.Add(occupation);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return occupations;
        }

        public void Delete(object item)
        {
            try
            {
                Occupation occupation = (Occupation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", occupation.ID, DbType.Int32);
                dal.CreateParameter("@Archived",occupation.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", occupation.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Occupations Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

    }
}
