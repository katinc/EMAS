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
    public class SanctionDataMapper
    {
        private DALHelper dal;
        private Sanction sanction;

        public SanctionDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.sanction = new Sanction();
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
                Sanction sanction = (Sanction)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", sanction.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", sanction.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Sanctioned", sanction.Sanctioned, DbType.Boolean);
                dal.CreateParameter("@SanctionTypeID", sanction.SanctionType.ID, DbType.Int32);
                if (sanction.SanctionDate == null)
                {
                    dal.CreateParameter("@SanctionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@SanctionDate", sanction.SanctionDate, DbType.Date);
                }
                dal.CreateParameter("@Approved", sanction.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", sanction.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", sanction.ApprovedUserStaffID, DbType.String);
                if (sanction.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", sanction.ApprovedDate, DbType.Date);
                }
                if (sanction.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", sanction.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", sanction.Reason, DbType.String);
                dal.CreateParameter("@UserID", sanction.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Sanctions(StaffID,StaffCode,SanctionDate,SanctionTypeID,Sanctioned,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Reason,UserID) Values(@StaffID,@StaffCode,@SanctionDate,@SanctionTypeID,@Sanctioned,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Reason,@UserID)");
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
                Sanction sanction = (Sanction)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", sanction.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", sanction.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", sanction.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Sanctioned", sanction.Sanctioned, DbType.Boolean);
                dal.CreateParameter("@SanctionTypeID", sanction.SanctionType.ID, DbType.Int32);
                if (sanction.SanctionDate == null)
                {
                    dal.CreateParameter("@SanctionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@SanctionDate", sanction.SanctionDate, DbType.Date);
                }
                dal.CreateParameter("@Approved", sanction.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", sanction.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", sanction.ApprovedUserStaffID, DbType.String);
                if (sanction.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", sanction.ApprovedDate, DbType.Date);
                }
                if (sanction.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", sanction.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", sanction.Reason, DbType.String);
                dal.CreateParameter("@UserID", sanction.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", sanction.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Sanctions Set StaffID=@StaffID,StaffCode=@StaffCode,SanctionDate=@SanctionDate,SanctionTypeID=@SanctionTypeID,Sanctioned=@Sanctioned,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Reason=@Reason,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Sanction> GetAll()
        {
            IList<Sanction> sanctions = new List<Sanction>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", sanction.Archived, DbType.String);
                string query = "select SanctionView.* from SanctionView ";
                query += "WHERE SanctionView.Archived=@Archived order BY SanctionView.DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Sanction sanc in BuildSanctionsFromData(table))
                {
                    sanctions.Add(sanc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return sanctions;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Sanction sanction = (Sanction)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", sanction.ID, DbType.Int32);
                dal.CreateParameter("@Archived", sanction.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Sanctions Set Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region Get By ID
        public Sanction GetByID(object key)
        {
            Sanction sanction = new Sanction();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select SanctionView.* from SanctionView ";
                query += "WHERE SanctionView.ID=@ID And SanctionView.Archived=@Archived order BY SanctionView.DateAndTimeGenerated DESC";

                table = dal.ExecuteReader(query);
                foreach (Sanction san in BuildSanctionsFromData(table))
                {
                    sanction = san;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return sanction;
        }
        #endregion

        #region GetByCriteria
        public IList<Sanction> GetByCriteria(Query query1)
        {
            IList<Sanction> sanctions = new List<Sanction>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", sanction.Archived, DbType.Boolean);
                string query = "select SanctionView.* from SanctionView ";
                
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  SanctionView.Archived=@Archived order BY SanctionView.DateAndTimeGenerated DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Sanction sanc in BuildSanctionsFromData(table))
                {
                    sanctions.Add(sanc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return sanctions;
        }
        #endregion

        #region BuildSanctionsFromData
        private IList<Sanction> BuildSanctionsFromData(DataTable table)
        {
            IList<Sanction> sanctions = new List<Sanction>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Sanction sanction = new Sanction()
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
                            Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString(),
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
                            Zone = new Zone()
                            {
                                ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                                Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString()
                            },
                            Specialty = new Specialty()
                            {
                                ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()),
                                Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString()
                            },
                        },
                        SanctionDate = row["SanctionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["SanctionDate"].ToString()),
                        Reason = row["Reason"] is DBNull ? string.Empty : row["Reason"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()) },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Sanctioned = bool.Parse(row["Sanctioned"].ToString()),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        SanctionType = new SanctionType()
                        {
                            ID = row["SanctionTypeID"] == DBNull.Value ? 0 : int.Parse(row["SanctionTypeID"].ToString()),
                            Description = row["SanctionType"] == DBNull.Value ? string.Empty : row["SanctionType"].ToString(),
                            Separated = bool.Parse(row["Separated"].ToString()),
                            Payment = bool.Parse(row["Payment"].ToString()),
                            Reinstatement = bool.Parse(row["Reinstatement"].ToString()),
                            Active = bool.Parse(row["Active"].ToString()),
                        },

                    };
                    sanctions.Add(sanction);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return sanctions;
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
