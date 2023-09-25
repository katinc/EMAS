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
    public class DepartmentsDataMapper
    {
        private DALHelper dal;
        private Department department;

        public DepartmentsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.department = new Department();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                Department department = (Department)item;
                dal.ClearParameters();
                dal.CreateParameter("@Code", department.Code, DbType.String);
                dal.CreateParameter("@Description", department.Description, DbType.String);
                dal.CreateParameter("@Supervisor", department.Supervisor, DbType.String);
                dal.CreateParameter("@SupervisorCode", department.SupervisorCode, DbType.String);
                dal.CreateParameter("@SupervisorID", department.SupervisorID, DbType.Int32);
                dal.CreateParameter("@Active", department.In_Use, DbType.Boolean);
                dal.CreateParameter("@MaxStaff", department.Max_Staff, DbType.Int32);
                dal.CreateParameter("@MinStaff", department.Min_Staff, DbType.Int32);
                dal.CreateParameter("@UserID", department.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into DDepartments(Description,Active,Max_Staff,SupervisorID,SupervisorCode,Supervisor,Min_Staff,UserID) Values(@Description,@Active,@MaxStaff,@SupervisorID,@SupervisorCode,@Supervisor,@MinStaff,@UserID)");     
            }
            catch (Exception ex)
            {
                throw ex;
                Logger.LogError(ex);
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            try
            {
                Department department = (Department)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", department.ID, DbType.Int32);
                dal.CreateParameter("@Code", department.Code, DbType.String);
                dal.CreateParameter("@Description", department.Description, DbType.String);
                dal.CreateParameter("@Active", department.In_Use, DbType.Boolean);
                dal.CreateParameter("@Supervisor", department.Supervisor, DbType.String);
                dal.CreateParameter("@SupervisorCode", department.SupervisorCode, DbType.String);
                dal.CreateParameter("@SupervisorID", department.SupervisorID, DbType.Int32);
                dal.CreateParameter("@MaxStaff", department.Max_Staff, DbType.Int32);
                dal.CreateParameter("@MinStaff", department.Min_Staff, DbType.Int32);
                dal.CreateParameter("@UserID", department.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update DDepartments Set Description=@Description,Active=@Active,Max_Staff=@MaxStaff,Min_Staff=@MinStaff, SupervisorID=@SupervisorID,SupervisorCode=@SupervisorCode,Supervisor=@Supervisor,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Department> GetAll()
        {
            IList<Department> departments = new List<Department>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", department.Archived, DbType.String);
                string query = "Select DepartmentView.*,(COALESCE(DepartmentView.Firstname, '') + '   ' + COALESCE(DepartmentView.Surname,'') + ' ' + COALESCE(DepartmentView.OtherName,'')) as Fullname from DepartmentView ";
                query += "WHERE DepartmentView.Archived=@Archived order BY DepartmentView.Description ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Department dep in BuildDepartmentFromData(table))
                {
                    departments.Add(dep);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return departments;
        }
        #endregion

        #region GetByCriteria
        public IList<Department> GetByCriteria(Query query1)
        {
            IList<Department> departments = new List<Department>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT * From DepartmentView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' Order By Description";
                table = dal.ExecuteReader(selectStatement);
                foreach (Department dep in BuildDepartmentFromData(table))
                {
                    departments.Add(dep);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return departments;
        }
        #endregion

        #region Get By Description
        public Department GetByDescription(object key)
        {
            Department department = new Department();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Description", key.ToString().Trim(), DbType.String);
                string query = "select DISTINCT * from DepartmentView ";
                query += "WHERE DepartmentView.Description=@Description order BY DepartmentView.Description ASC";
                table = dal.ExecuteReader(query);
                foreach (Department dep in BuildDepartmentFromData(table))
                {
                    department = dep;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return department;
        }
        #endregion
        #region Get By Id
        public Department GetById(int Id)
        {
            Department department = new Department();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Id", Id, DbType.Int32);
                string query = "select DISTINCT * from DepartmentView ";
                query += "WHERE DepartmentView.ID=@Id ";
                table = dal.ExecuteReader(query);
                foreach (Department dep in BuildDepartmentFromData(table))
                {
                    department = dep;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return department;
        }
        #endregion

        #region BuildDepartmentFromData
        private IList<Department> BuildDepartmentFromData(DataTable table)
        {
            IList<Department> departments = new List<Department>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Department department = new Department()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Code = row["Code"] == DBNull.Value ? string.Empty : row["Code"].ToString(),
                        Description = row["Description"] == DBNull.Value ? string.Empty : row["Description"].ToString(),
                        SupervisorID = row["SupervisorID"] == DBNull.Value ? 0 : int.Parse(row["SupervisorID"].ToString()),
                        Supervisor = row["Supervisor"] == DBNull.Value ? string.Empty : row["Supervisor"].ToString(),
                        SupervisorCode = row["SupervisorCode"] == DBNull.Value ? string.Empty : row["SupervisorCode"].ToString(),
                        SupervisorFirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                        SupervisorLastName = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                        SupervisorOtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                        SupervisorBand = row["Band"] == DBNull.Value ? string.Empty : row["Band"].ToString(),
                        SupervisorStep = row["Step"] == DBNull.Value ? string.Empty : row["Step"].ToString(),
                        SupervisorGradeCategory = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString(),
                        SupervisorGrade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString(),

                        In_Use = row["Active"] == DBNull.Value ? false : bool.Parse(row["Active"].ToString()),
                        Max_Staff = row["Max_Staff"] == DBNull.Value ? 0 : int.Parse(row["Max_Staff"].ToString()),
                        Min_Staff = row["Min_Staff"] == DBNull.Value ? 0 : int.Parse(row["Min_Staff"].ToString()) ,
                        Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"].ToString(),
                        },
                    };

                    departments.Add(department);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return departments;
        }
        #endregion

        #region DELETE

        public void Delete( object item)
        {
            try
            {
                Department department = (Department)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", department.ID, DbType.Int32);
                dal.CreateParameter("@Archived", department.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update DDepartments Set Archived=@Archived Where ID =@ID");
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
