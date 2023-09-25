using HRBussinessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace HRDataAccessLayer
{
    public class ComboDataMapper
    {
        private DALHelper dal;

        public ComboDataMapper()
        {
            this.dal = new DALHelper();
        }

        public List<ComboElement> GetElements(string tableName)
        {
            List<ComboElement> elements = new List<ComboElement>();

            try
            {
                string query = "Select * from " + tableName;
                query += " Order by " + tableName + ".Description ASC";
                DataTable table = dal.ExecuteReader(query);

                foreach (DataRow row in table.Rows)
                {
                    elements.Add(new ComboElement()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Description = row["Description"].ToString(),
                        Active = bool.Parse(row["Active"].ToString()),
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            return elements;
        }

        public object GetCurrentValue(string tableName, string columnName, string staffId)
        {
            try
            {
                
                string query = "Select " + columnName + " from " + tableName + " where staffId = '" + staffId + "'";
                DataTable table = dal.ExecuteReader(query);

                foreach (DataRow row in table.Rows)
                {
                    return row[columnName];
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                return null;
            }
        }

        public void UpdateImage(string columnName, string staffID, object newValue)
        {
            try
            {

                string result = string.Empty;
                dal.CreateParameter("@NewImage", newValue, DbType.Binary);
                string query = "Update StaffPersonalInfo set " + columnName + " = @NewImage where StaffID = '" + staffID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void UpdateComboText(string columnName, string tableName, string staffID, string newValue)
        {
            try
            {
                string result = string.Empty;
                string query = "Update StaffPersonalInfo set " + columnName + " = '" + newValue + "' where StaffID = '" + staffID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void UpdateText(string columnName, string tableName, string staffID, string newValue)
        {
            try
            {
                string result = string.Empty;
                string query = "Update " + tableName + " set " + columnName + " = '" + newValue + "' where staffID = '" + staffID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void UpdateText(string columnName, string tableName, decimal ChangeID, string newValue)
        {
            try
            {
                dal.ClearParameters();
                string query = "Update " + tableName + " set " + columnName + " = '" + newValue + "' where ID = '" + ChangeID + "'";
                //string query = "Update @TableName set @ColumnName = @NewValue where ID = @ChangeID";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void UpdateDate(string columnName, string tableName, string staffID, DateTime newValue)
        {
            try
            {
                string result = string.Empty;
                string query = "Update  " + tableName + "  set " + columnName + " = '" + newValue + "' where StaffId = '" + staffID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void UpdateDateTrans(string columnName, string tableName, decimal ChangeID, DateTime newValue)
        {
            try
            {
                string result = string.Empty;
                string query = "Update  " + tableName + "  set " + columnName + " = '" + newValue + "' where ID = '" + ChangeID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void Archive(string tableName, int ChangeID )
        {
            try
            {
                string query = "Update " + tableName + " set Archived = 'True' where ID = '" + ChangeID + "'";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
