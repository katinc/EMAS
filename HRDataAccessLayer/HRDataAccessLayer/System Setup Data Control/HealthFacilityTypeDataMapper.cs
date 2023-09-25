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
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class HealthFacilityTypeDataMapper
    {
        private DALHelper dal;
        private HealthFacilityType healthFacilityType;

        public HealthFacilityTypeDataMapper()
        {
            this.dal = new DALHelper();
            this.healthFacilityType = new HealthFacilityType();
        }

        #region SAVE
        public void Save(HealthFacilityType healthFacilityType)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", healthFacilityType.Description, DbType.String);
                dal.CreateParameter("@Active", healthFacilityType.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Insert Into HealthFacilityType(Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(HealthFacilityType healthFacilityType)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", healthFacilityType.ID, DbType.Int32);
                dal.CreateParameter("@Description", healthFacilityType.Description, DbType.String);
                dal.CreateParameter("@Active", healthFacilityType.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update HealthFacilityType Set Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<HealthFacilityType> GetAll()
        {
            IList<HealthFacilityType> healthFacilityTypes = new List<HealthFacilityType>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", healthFacilityType.Archived, DbType.String);
                DataTable table = dal.ExecuteReader("select * from HealthFacilityType WHERE Archived=@Archived order BY Description ASC");
                foreach (DataRow row in table.Rows)
                {
                    healthFacilityTypes.Add(new HealthFacilityType() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString(), Active = bool.Parse(row["Active"].ToString())});
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return healthFacilityTypes;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", key.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", true, DbType.Boolean);
                dal.CreateParameter("@Active", false, DbType.Boolean);

                dal.ExecuteNonQuery("Update HealthFacilityType Set Active=@Active, Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
