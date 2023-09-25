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
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class BandsDataMapper
    {
        private DALHelper dal;
        private Band band;

        public BandsDataMapper()
        {
            this.dal = new DALHelper();
            this.band = new Band();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Band band = (Band)item;
                dal.ClearParameters();
                dal.CreateParameter("@Description", band.Description, DbType.String);
                dal.CreateParameter("@Active", band.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", band.User.ID.ToString(), DbType.Int32);
                dal.CreateParameter("@Archived", band.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Bands(Description,Active,UserID,Archived) Values(@Description,@Active,@UserID,@Archived)");
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
                Band band = (Band)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", band.ID, DbType.Int32);
                dal.CreateParameter("@Description", band.Description, DbType.String);
                dal.CreateParameter("@Active", band.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", band.User.ID.ToString(), DbType.String);
                dal.CreateParameter("@Archived", band.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Bands Set Description=@Description,Active=@Active,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Band> GetAll()
        {
            IList<Band> bands = new List<Band>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", band.Archived, DbType.String);
                DataTable table = dal.ExecuteReader("select Bands.ID,Bands.Description,Bands.Active,Bands.Archived,Bands.UserID From Bands WHERE Bands.Archived=@Archived order BY Bands.Description ASC");
                foreach (DataRow row in table.Rows)
                {
                    bands.Add(new Band() 
                    { 
                        ID = int.Parse(row["ID"].ToString()), 
                        Description = row["Description"].ToString(), 
                        Active =  bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()), 
                        User = new User() 
                        { 
                            ID = int.Parse(row["UserID"].ToString())
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return bands;
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

                dal.ExecuteNonQuery("Update Bands Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
