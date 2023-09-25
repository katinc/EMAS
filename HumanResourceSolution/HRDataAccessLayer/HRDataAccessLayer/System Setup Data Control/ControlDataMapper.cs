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
    public class ControlDataMapper
    {
        private DALHelper dal;
        private Controls control;

        public ControlDataMapper()
        {
            this.dal = new DALHelper();
            this.control = new Controls();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Controls control = (Controls)item;
                dal.ClearParameters();
                dal.CreateParameter("@Page", control.Page, DbType.String);
                dal.CreateParameter("@ControlID", control.ControlID, DbType.String);
                dal.CreateParameter("@Active", control.Active, DbType.Boolean);


                dal.ExecuteNonQuery("Insert Into Controls (Page,ControlID,Active) Values(@Page,@ControlID,@Active)");
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
                Controls control = (Controls)item;
                dal.ClearParameters();
                dal.CreateParameter("@Page", control.Page, DbType.String);
                dal.CreateParameter("@ControlID", control.ControlID, DbType.String);
                dal.CreateParameter("@Active", control.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Controls Set Page=@Page,ControlID=@ControlID,Active=@Active Where Page=@Page and ControlID=@ControlID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Controls> GetAll()
        {
            IList<Controls> controls = new List<Controls>();
            try
            {
                string query = "select ControlView.* from ControlView where Active = 'True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Controls control in BuildControlFromData(table))
                {
                    controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return controls;
        }
        #endregion

        #region DELETE

        public void Delete(object key)
        {
            try
            {
                Controls control = (Controls)key;
                dal.ClearParameters();
                dal.CreateParameter("@Page", control.Page, DbType.String);
                dal.CreateParameter("@ControlID", control.ControlID, DbType.String);
                dal.CreateParameter("@Active", control.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Update Controls Set Active=@Active Where Page=@Page and ControlID=@ControlID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Controls> GetByCriteria(Query query1)
        {
            IList<Controls> controls = new List<Controls>();
            try
            {
                DataTable table = new DataTable();

                string query = "select ControlView.* from ControlView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  ControlView.Active='True'";
                table = dal.ExecuteReader(selectStatement);
                foreach (Controls control in BuildControlFromData(table))
                {
                    controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return controls;
        }
        #endregion

        #region BuildControlFromData
        private IList<Controls> BuildControlFromData(DataTable table)
        {
            IList<Controls> controls = new List<Controls>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Controls control = new Controls()
                    {
                        Page = row["Page"].ToString(),
                        ControlID = row["ControlID"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    };
                    controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return controls;
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
