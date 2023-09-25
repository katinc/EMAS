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
    public class CountryDataMapper
    {
        private DALHelper dal;
        private Country country;

        public CountryDataMapper()
        {
            this.dal = new DALHelper();
            this.country = new Country();
        }

        #region SAVE
        public void Save(Country country)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", country.Description, DbType.String);
                dal.CreateParameter("@Active", country.Active, DbType.Boolean);
                
                dal.ExecuteNonQuery("Insert Into Countries(Description,Active) Values(@Description,@Active)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Update
        public void Update(Country country)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@ID", country.ID, DbType.Int32);
                dal.CreateParameter("@Description", country.Description, DbType.String);
                dal.CreateParameter("@Active", country.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Countries Set Description=@Description,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Country> GetAll()
        {
            IList<Country> countries = new List<Country>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", country.Archived, DbType.String);
                DataTable table = dal.ExecuteReader("select * from Countries WHERE Archived=@Archived order BY Description ASC");
                foreach (DataRow row in table.Rows)
                {
                    countries.Add(new Country() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString(), Active = bool.Parse(row["Active"].ToString()) });
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return countries;
        }
        #endregion

        #region Get By Id
        public Country GetById(int Id)
        {
            Country country = new Country();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@id",Id, DbType.Int32);
                DataTable table = dal.ExecuteReader("select * from Countries WHERE id=@id order BY Description ASC");
                if (table.Rows.Count > 0)
                {
                  DataRow row = table.Rows[0];
                  country=  new Country() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString(), Active = bool.Parse(row["Active"].ToString()) };
                }
             
            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return country;
        }
        #endregion

        #region Get By Name
        public Country GetByName(string Name)
        {
            Country country = new Country();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Description", Name.Trim(), DbType.String);
                DataTable table = dal.ExecuteReader("select * from Countries WHERE Description=@Description");
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    country = new Country() { ID = int.Parse(row["ID"].ToString()), Description = row["Description"].ToString(), Active = bool.Parse(row["Active"].ToString()) };
                }

            }
            catch (Exception ex)
            {
                string er = ex.Message;
            }

            return country;
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

                dal.ExecuteNonQuery("Update Countries Set Active=@Active, Archived=@Archived Where ID =@ID");
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
