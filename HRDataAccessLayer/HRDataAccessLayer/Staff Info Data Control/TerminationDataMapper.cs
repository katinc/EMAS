using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;

using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class TerminationDataMapper
    {
        private DALHelper dal;

        public TerminationDataMapper()
        {
            this.dal = new DALHelper(); 
        }
        
        #region SAVE
        public void Save(object item)
        {
            try
            {
                Termination termination = (Termination)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", termination.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", termination.Employee.StaffID,DbType.String);
                dal.CreateParameter("@TerminationDate",termination.TerminationDate,DbType.DateTime);
                dal.CreateParameter("@EmployeeNotified", termination.EmployeeNoticed, DbType.Boolean);
                dal.CreateParameter("@EmployerNotified", termination.EmployerNoticed, DbType.Boolean);
                dal.CreateParameter("@Type", termination.Type, DbType.String);
                dal.CreateParameter("@SeparationTypeID", termination.SeparationType.ID, DbType.Int32);
                dal.CreateParameter("@Approved", termination.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", termination.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", termination.ApprovedUserStaffID, DbType.String);
                if (termination.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", termination.ApprovedDate, DbType.Date);
                }
                if (termination.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", termination.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", termination.Reason, DbType.String);
                dal.CreateParameter("@UserID", termination.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("INSERT INTO Termination (StaffID,StaffCode,TerminationDate,EmployeeNotified,EmployerNotified,Type,SeparationTypeID,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,Reason,UserID) VALUES(@StaffID,@StaffCode,@TerminationDate,@EmployeeNotified,@EmployerNotified,@Type,@SeparationTypeID,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@Reason,@UserID)");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Termination termination = (Termination)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", termination.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", termination.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", termination.Employee.StaffID, DbType.String);
                dal.CreateParameter("@TerminationDate", termination.TerminationDate, DbType.DateTime);
                dal.CreateParameter("@EmployeeNotified", termination.EmployeeNoticed, DbType.Boolean);
                dal.CreateParameter("@EmployerNotified", termination.EmployerNoticed, DbType.Boolean);
                dal.CreateParameter("@SeparationTypeID", termination.SeparationType.ID, DbType.Int32);
                dal.CreateParameter("@Type", termination.Type, DbType.String);
                dal.CreateParameter("@Approved", termination.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", termination.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", termination.ApprovedUserStaffID, DbType.String);
                if (termination.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", termination.ApprovedDate, DbType.Date);
                }
                if (termination.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", termination.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", termination.Reason, DbType.String);
                dal.CreateParameter("@UserID", termination.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("UPDATE Termination Set StaffID=@StaffID,StaffCode=@StaffCode,TerminationDate=@TerminationDate,EmployeeNotified=@EmployeeNotified,EmployerNotified=@EmployerNotified,Type=@Type,SeparationTypeID=@SeparationTypeID,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate,Reason=@Reason,UserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Termination> GetAll()
        {
            try
            {
                IList<Termination> terminations = new List<Termination>();
                DataTable table = dal.ExecuteReader("Select TerminationView.*,TerminationView.FirstName +' '+ TerminationView.OtherName +' '+ TerminationView.Surname as StaffName from TerminationView where TerminationView.Archived ='False' ORDER BY TerminationView.DateAndTimeGenerated DESC,TerminationView.StaffID ASC");
                foreach (Termination ter in BuildTerminationFromData(table))
                {
                    terminations.Add(ter);
                }
                return terminations;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetByCriteria
        public IList<Termination> GetByCriteria(Query query1)
        {
            IList<Termination> terminations = new List<Termination>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                //dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "select TerminationView.*,TerminationView.FirstName +' '+ TerminationView.OtherName +' '+ TerminationView.Surname as StaffName from TerminationView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                string suffix = "And ";
                if (selectStatement.EndsWith(suffix))
                {
                    selectStatement = selectStatement.Substring(0, selectStatement.Length - suffix.Length);
                }
                selectStatement += "   ORDER BY TerminationView.DateAndTimeGenerated DESC,TerminationView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Termination term in BuildTerminationFromData(table))
                {
                    terminations.Add(term);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return terminations;
        }
        #endregion

        #region Get By ID
        public Termination GetByID(object key)
        {
            Termination termination = new Termination();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select TerminationView.*,TerminationView.FirstName +' '+ TerminationView.OtherName +' '+ TerminationView.Surname as StaffName from TerminationView ";
                query += "WHERE TerminationView.ID=@ID And TerminationView.Archived=@Archived order BY TerminationView.DateAndTimeGenerated DESC";

                table = dal.ExecuteReader(query);
                foreach (Termination ter in BuildTerminationFromData(table))
                {
                    termination = ter;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return termination;
        }
        #endregion

        #region BuildTerminationFromData
        private IList<Termination> BuildTerminationFromData(DataTable table)
        {
            IList<Termination> terminations = new List<Termination>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Termination termination = new Termination()
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
                                Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString()
                            },
                            Grade = new EmployeeGrade()
                            {
                                ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()),
                                Grade = row["Grade"] == DBNull.Value ? null : row["Grade"].ToString()
                            },
                            Gender = row["Gender"] == DBNull.Value ? null : row["Gender"].ToString(),
                            Unit = new Unit()
                            {
                                ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()),
                                Description = row["Unit"] == DBNull.Value ? null : row["Unit"].ToString()
                            },
                            Department = new Department()
                            {
                                ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()),
                                Description = row["Department"] == DBNull.Value ? null : row["Department"].ToString()
                            },
                            Zone = new Zone()
                            {
                                ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()),
                                Description = row["Zone"] == DBNull.Value ? null : row["Zone"].ToString()
                            },
                            Specialty = new Specialty()
                            {
                                ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()),
                                Description = row["Specialty"] == DBNull.Value ? null : row["Specialty"].ToString()
                            },
                            Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString()),
                            TerminationDate = row["CurrentSeparationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentSeparationDate"].ToString()),
                            SeparationType = new SeparationType()
                            {
                                ID = row["CurrentSeparationTypeID"] == DBNull.Value ? 0 : int.Parse(row["CurrentSeparationTypeID"].ToString()),
                                Description = row["CurrentSeparationType"] == DBNull.Value ? string.Empty : row["CurrentSeparationType"].ToString(),
                            },
                            EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString()),
                        },
                        StaffName = row["StaffName"] == DBNull.Value ? string.Empty : row["StaffName"].ToString(),
                        TerminationDate = DateTime.Parse(row["TerminationDate"].ToString()),
                        EmployeeNoticed = bool.Parse(row["EmployeeNotified"].ToString()),
                        EmployerNoticed = bool.Parse(row["EmployerNotified"].ToString()),
                        Type = row["Type"].ToString(),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                        },
                        SeparationType = new SeparationType()
                        {
                            ID = row["SeparationTypeID"] == DBNull.Value ? 0 : int.Parse(row["SeparationTypeID"].ToString()),
                            Description = row["SeparationType"] == DBNull.Value ? string.Empty : row["SeparationType"].ToString(),
                            Reinstatement = bool.Parse(row["Reinstatement"].ToString()),
                            Active = bool.Parse(row["Active"].ToString()),
                        },
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                        Reason = row["Reason"].ToString(),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    terminations.Add(termination);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return terminations;
        }
        #endregion

        #region DELETE
        public void Delete(object item)
        {
            try
            {
                Termination termination = (Termination)item;
                dal.ExecuteNonQuery("Update Termination Set Archived='True' Where ID="+ termination.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
