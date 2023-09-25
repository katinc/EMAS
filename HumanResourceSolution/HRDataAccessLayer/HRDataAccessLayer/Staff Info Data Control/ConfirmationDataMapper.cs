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


namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class ConfirmationDataMapper
    {
        private DALHelper dal;
        private Confirmation confirmation;

        public ConfirmationDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.confirmation = new Confirmation();
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
                Confirmation confirmation = (Confirmation)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", confirmation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", confirmation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Confirmed", confirmation.Confirmed, DbType.Boolean);
                if (confirmation.ConfirmationDate == null)
                {
                    dal.CreateParameter("@ConfirmationDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ConfirmationDate", confirmation.ConfirmationDate, DbType.Date);
                }
                
                dal.CreateParameter("@Reason", confirmation.Reason, DbType.String);
                dal.CreateParameter("@UserID", confirmation.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Confirmations(StaffID,StaffCode,ConfirmationDate,Confirmed,Reason,UserID) Values(@StaffID,@StaffCode,@ConfirmationDate,@Confirmed,@Reason,@UserID)");
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
                Confirmation confirmation = (Confirmation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", confirmation.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", confirmation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", confirmation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Confirmed", confirmation.Confirmed, DbType.Boolean);
                if (confirmation.ConfirmationDate == null)
                {
                    dal.CreateParameter("@ConfirmationDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ConfirmationDate", confirmation.ConfirmationDate, DbType.Date);
                }
                dal.CreateParameter("@Reason", confirmation.Reason, DbType.String);
                dal.CreateParameter("@UserID", confirmation.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", confirmation.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Confirmations Set StaffID=@StaffID,StaffCode=@StaffCode,ConfirmationDate=@ConfirmationDate,Confirmed=@Confirmed,Reason=@Reason,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Confirmation> GetAll()
        {
            IList<Confirmation> confirmations = new List<Confirmation>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", confirmation.Archived, DbType.String);
                string query = "select ConfirmationView.* from ConfirmationView ";
                query += "WHERE ConfirmationView.Archived=@Archived order BY ConfirmationView.StaffID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Confirmation confir in BuildConfirmationFromData(table))
                {
                    confirmations.Add(confir);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return confirmations;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Confirmation confirmation = (Confirmation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", confirmation.ID, DbType.Int32);
                dal.CreateParameter("@Archived", confirmation.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Confirmations Set Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Confirmation> GetByCriteria(Query query1)
        {
            IList<Confirmation> confirmations = new List<Confirmation>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", confirmation.Archived, DbType.Boolean);
                string query = "select ConfirmationView.* from ConfirmationView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  ConfirmationView.Archived=@Archived order BY ConfirmationView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Confirmation confir in BuildConfirmationFromData(table))
                {
                    confirmations.Add(confir);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return confirmations;
        }
        #endregion

        #region LazyLoadByStaffID
        public Confirmation LazyLoadByStaffID(object item)
        {
            Confirmation confirmation = new Confirmation();
            try
            {
                Confirmation conf = (Confirmation)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", confirmation.Archived, DbType.String);
                string query = "select ConfirmationView.* from ConfirmationView ";
                query += "WHERE ConfirmationView.Archived=@Archived and ConfirmationView.StaffID=@StaffID order BY ConfirmationView.StaffID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Confirmation con in BuildConfirmationFromData(table))
                {
                    confirmation = con;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return confirmation;
        }
        #endregion

        #region BuildConfirmationFromData
        private IList<Confirmation> BuildConfirmationFromData(DataTable table)
        {
            IList<Confirmation> confirmations = new List<Confirmation>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Confirmation confirmation = new Confirmation()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? null : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? null : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? null : row["OtherName"].ToString(),
                            GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString() },
                            Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() },
                            Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() },
                            Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() },
                        },
                        ConfirmationDate = row["ConfirmationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ConfirmationDate"].ToString()),
                        Reason = row["Reason"] is DBNull ? string.Empty : row["Reason"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Confirmed = bool.Parse(row["Confirmed"].ToString()),
                    };
                    confirmations.Add(confirmation);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return confirmations;
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
