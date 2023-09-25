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
    public class UnitDataMapper
    {
        private DALHelper dal;
        private Unit unit;

        public UnitDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.unit = new Unit();
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
                Unit unit = (Unit)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", unit.Code, DbType.String);
                dal.CreateParameter("@Description", unit.Description, DbType.String);
                dal.CreateParameter("@DepartmentID", unit.Department.ID, DbType.Int32);
                dal.CreateParameter("@UserID", unit.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", unit.Active, DbType.Boolean);

                dal.ExecuteNonQuery("Insert Into Units (Code,Description,DepartmentID,UserID,Active) Values(@Code,@Description,@DepartmentID,@UserID,@Active)");
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
                Unit unit = (Unit)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", unit.ID, DbType.Int32);
                dal.CreateParameter("@Code", unit.Code, DbType.String);
                dal.CreateParameter("@Description", unit.Description, DbType.String);
                dal.CreateParameter("@DepartmentID", unit.Department.ID, DbType.Int32);
                dal.CreateParameter("@UserID", unit.User.ID, DbType.Int32);
                dal.CreateParameter("@Active", unit.Active, DbType.Boolean);
                dal.CreateParameter("@Archived", unit.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Units Set UserID=@UserID,Code=@Code,Description=@Description,DepartmentID=@DepartmentID,Active=@Active Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Unit> GetAll()
        {
            IList<Unit> units = new List<Unit>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", unit.Archived, DbType.String);
                string query = "select * from UnitView ";
                query += "WHERE UnitView.Archived=@Archived order BY UnitView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Unit uni in BuildUnitFromData(table))
                {
                    units.Add(uni);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return units;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Unit unit = (Unit)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", unit.ID, DbType.Int32);
                dal.CreateParameter("@Archived", unit.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", unit.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update Units Set Active=@Active,Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Unit> GetByCriteria(Query query1)
        {
            IList<Unit> units = new List<Unit>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", unit.Archived, DbType.Boolean);

                string query = "select * from UnitView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  UnitView.Archived=@Archived order BY UnitView.Description ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Unit uni in BuildUnitFromData(table))
                {
                    units.Add(uni);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return units;
        }
        #endregion

        #region BuildUnitFromData
        private IList<Unit> BuildUnitFromData(DataTable table)
        {
            IList<Unit> units = new List<Unit>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Unit unit = new Unit()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"].ToString(),
                        Description = row["Description"].ToString(),
                        Department = new Department() { ID = int.Parse(row["DepartmentID"].ToString()), Code = row["DepartmentCode"].ToString(), Description = row["Department"].ToString() },
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Active = bool.Parse(row["Active"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    units.Add(unit);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return units;
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
