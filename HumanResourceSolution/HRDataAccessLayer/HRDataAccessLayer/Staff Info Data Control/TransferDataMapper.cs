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
    public class TransferDataMapper
    {
        private DALHelper dal;
        private Transfer transfer;

        public TransferDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.transfer = new Transfer();
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
                Transfer transfer = (Transfer)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", transfer.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", transfer.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Date", transfer.Date, DbType.DateTime);
                dal.CreateParameter("@Type", transfer.Type, DbType.String);
                dal.CreateParameter("@Reason", transfer.Reason, DbType.String);
                dal.CreateParameter("@previousInstitution", transfer.PreviousInstitution, DbType.String);
                dal.CreateParameter("@previousStaffID", transfer.PreviousStaffID, DbType.String);
                dal.CreateParameter("@ZoneID", transfer.Zone.ID, DbType.Int32);
                dal.CreateParameter("@DepartmentID", transfer.Department.ID, DbType.Int32);
                dal.CreateParameter("@UnitID", transfer.Unit.ID, DbType.Int32);
                dal.CreateParameter("@Transferred", transfer.Transferred, DbType.Boolean);
                dal.CreateParameter("@UserID", transfer.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Transfers(StaffID,StaffCode,Date,Type,Reason,previousInstitution,previousStaffID,ZoneID,DepartmentID,UnitID,Transferred,UserID) Values(@StaffID,@StaffCode,@Date,@Type,@Reason,@previousInstitution,@PreviousStaffID,@ZoneID,@DepartmentID,@UnitID,@Transferred,@UserID)");
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
                Transfer transfer = (Transfer)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", transfer.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", transfer.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", transfer.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Date", transfer.Date, DbType.DateTime);
                dal.CreateParameter("@Type", transfer.Type, DbType.String);
                dal.CreateParameter("@Reason", transfer.Reason, DbType.String);
                dal.CreateParameter("@previousInstitution", transfer.PreviousInstitution, DbType.String);
                dal.CreateParameter("@previousStaffID", transfer.PreviousStaffID, DbType.String);
                dal.CreateParameter("@ZoneID", transfer.Zone.ID, DbType.Int32);
                dal.CreateParameter("@DepartmentID", transfer.Department.ID, DbType.Int32);
                dal.CreateParameter("@UnitID", transfer.Unit.ID, DbType.String);
                dal.CreateParameter("@Transferred", transfer.Transferred, DbType.Boolean);
                dal.CreateParameter("@UserID", transfer.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", transfer.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Transfers Set StaffID=@StaffID,StaffCode=@StaffCode,Date=@Date,Type=@Type,Reason=@Reason,previousInstitution=@previousInstitution,previousStaffID=@previousStaffID,ZoneID=@ZoneID,DepartmentID=@DepartmentID,UnitID=@UnitID,Transferred=@Transferred,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Transfer> GetAll()
        {
            IList<Transfer> transfers = new List<Transfer>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", transfer.Archived, DbType.String);
                string query = "select TransferView.*,TransferView.Firstname +' '+ TransferView.OtherName +' '+ TransferView.Surname as StaffName from TransferView ";
                query += "WHERE TransferView.Archived=@Archived order BY TransferView.DateAndTimeGenerated DESC,TransferView.StaffID ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Transfer tran in BuildTransferFromData(table))
                {
                    transfers.Add(tran);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return transfers;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Transfer transfer = (Transfer)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", transfer.ID, DbType.Int32);
                dal.CreateParameter("@Archived", transfer.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Transfers Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Transfer> GetByCriteria(Query query1)
        {
            IList<Transfer> transfers = new List<Transfer>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", transfer.Archived, DbType.Boolean);
                string query = "select TransferView.*,TransferView.Firstname +' '+ TransferView.OtherName +' '+ TransferView.Surname as StaffName from TransferView ";

                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  TransferView.Archived=@Archived order BY TransferView.DateAndTimeGenerated DESC,TransferView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Transfer tran in BuildTransferFromData(table))
                {
                    transfers.Add(tran);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return transfers;
        }
        #endregion

        #region BuildTransferFromData
        private IList<Transfer> BuildTransferFromData(DataTable table)
        {
            IList<Transfer> transfers = new List<Transfer>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Transfer transfer = new Transfer()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                            Title = new Titles()
                            {
                                ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()),
                                Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString()
                            },
                            FileNumber = new FileNumber()
                            {
                                ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()),
                                Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString()
                            },
                            GradeCategory = new GradeCategory()
                            {
                                ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()),
                                Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                            },
                            Grade = new EmployeeGrade()
                            {
                                ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                                Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString()
                            },
                            Gender = row["Gender"] == DBNull.Value ? null : row["Gender"].ToString(),
                            Zone = new Zone()
                            {
                                ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                                Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString()
                            },
                            Unit = new Unit() 
                            { 
                                ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), 
                                Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() 
                            },
                            Department = new Department() 
                            { 
                                ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), 
                                Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() 
                            },
                            Specialty = new Specialty() { ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString() },
                            CurrentTransferredDate = row["CurrentTransferredDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentTransferredDate"].ToString()),
                            TransferType = row["TransferType"] == DBNull.Value ? null : row["TransferType"].ToString(),
                        },
                        Zone = new Zone()
                        {
                            ID = row["TransferZoneID"] == DBNull.Value ? 0 : int.Parse(row["TransferZoneID"].ToString()),
                            Description = row["TransferZone"] == DBNull.Value ? string.Empty : row["TransferZone"].ToString()
                        },
                        Department = new Department()
                        {
                            ID = row["TransferDepartmentID"] == DBNull.Value ? 0 : int.Parse(row["TransferDepartmentID"].ToString()),
                            Description = row["TransferDepartment"] == DBNull.Value ? string.Empty : row["TransferDepartment"].ToString()
                        },
                        Unit = new Unit()
                        {
                            ID = row["TransferUnitID"] == DBNull.Value ? 0 : int.Parse(row["TransferUnitID"].ToString()),
                            Description = row["TransferUnit"] == DBNull.Value ? string.Empty : row["TransferUnit"].ToString()
                        },
                        StaffName = row["StaffName"].ToString(),
                        Type = row["Type"] == DBNull.Value ? string.Empty : row["Type"].ToString(),
                        Reason = row["Reason"] == DBNull.Value ? string.Empty : row["Reason"].ToString(),
                        Date = row["Date"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["Date"].ToString()),
                        PreviousInstitution = row["PreviousInstitution"] == DBNull.Value ? string.Empty : row["PreviousInstitution"].ToString(),
                        PreviousStaffID = row["PreviousStaffID"] == DBNull.Value ? string.Empty : row["PreviousStaffID"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Transferred = bool.Parse(row["Transferred"].ToString()),
                    };
                    transfers.Add(transfer);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return transfers;
        }
        #endregion

        #region LazyLoad
        public IList<Transfer> LazyLoad()
        {
            IList<Transfer> transfers = new List<Transfer>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.String);

                string query = "SELECT * From TransferView Where Archived=@Archived";
                DataTable table = dal.ExecuteReader(query);

                foreach (DataRow row in table.Rows)
                {
                    Transfer transfer = new Transfer()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"].ToString(),
                            FirstName = row["FirstName"].ToString(),
                            OtherName = row["OtherName"].ToString(),
                            Title = new Titles()
                            {
                                ID = int.Parse(row["TitleID"].ToString()),
                                Description = row["Title"].ToString()
                            },
                            FileNumber = new FileNumber()
                            {
                                ID = int.Parse(row["FileNumberID"].ToString()),
                                Description = row["FileNumber"].ToString()
                            },
                            GradeCategory = new GradeCategory()
                            {
                                ID = int.Parse(row["GradeCategoryID"].ToString()),
                                Description = row["GradeCategory"].ToString()
                            },
                            Grade = new EmployeeGrade()
                            {
                                ID = int.Parse(row["GradeID"].ToString()),
                                Grade = row["Grade"].ToString()
                            },
                            Gender = row["Gender"].ToString(),
                            MaritalStatus = row["MaritalStatus"].ToString(),
                            Unit = new Unit() { ID = int.Parse(row["UnitID"].ToString()), Description = row["Unit"].ToString() },
                            Department = new Department() { ID = int.Parse(row["DepartmentID"].ToString()), Description = row["Department"].ToString() },
                            Specialty = new Specialty() { ID = int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"].ToString() },
                        },
                        Type = row["Type"].ToString(),
                        Reason = row["Reason"].ToString(),
                        Date = row["Date"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["Date"].ToString()),
                        PreviousInstitution = row["PreviousInstitution"].ToString(),
                        PreviousStaffID = row["PreviousStaffID"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    transfers.Add(transfer);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return transfers;
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
