using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
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

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class OrganizersDataMapper
    {
        private DALHelper dal;
        private TrainingType trainingType;

        public OrganizersDataMapper()
        {
            this.dal = new DALHelper();
            this.trainingType = new TrainingType();
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                Organizers organizers = (Organizers)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", organizers.Description, DbType.String);
                dal.CreateParameter("@Active", organizers.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert into Organizers(Description,Active) values (@Description,@Active)");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Get All
        public IList<Organizers> GetAll()
        {

            IList<Organizers> organizers = new List<Organizers>();

            try
            {
                dal.ClearParameters();
                string query = "Select * from Organizers";
                query += " Order by Organizers.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    organizers.Add(new Organizers()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {

                string er = ex.Message;
            }
            return organizers;

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
