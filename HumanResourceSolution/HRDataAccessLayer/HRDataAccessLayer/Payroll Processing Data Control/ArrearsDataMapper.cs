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
using HRBussinessLayer.PayRoll_Processing_CLASS;


namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class ArrearsDataMapper
    {
        private DALHelper dal;
        private Arrears arrear;

        public ArrearsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.arrear = new Arrears();
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
                Arrears arrear = (Arrears)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", arrear.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", arrear.Employee.ID, DbType.Int32);
                dal.CreateParameter("@PreviousSalary", arrear.PreviousSalary, DbType.Decimal);
                dal.CreateParameter("@CurrentSalary", arrear.CurrentSalary, DbType.Decimal);
                dal.CreateParameter("@NumberOfTimes", arrear.NumberOfTimes, DbType.Int32);
                dal.CreateParameter("@Type", arrear.Type, DbType.String);
                dal.CreateParameter("@SSNIT", arrear.SSNIT, DbType.Boolean);
                dal.CreateParameter("@IncomeTax", arrear.IncomeTax, DbType.Boolean);
                if (arrear.EffectiveDate == null)
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", arrear.EffectiveDate, DbType.Date);
                }
                dal.CreateParameter("@In_Use", arrear.In_Use, DbType.Boolean);
                dal.CreateParameter("@Reason", arrear.Reason, DbType.String);
                dal.CreateParameter("@UserID", arrear.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Arrears (StaffID,StaffCode,PreviousSalary,CurrentSalary,NumberOfTimes,Type,SSNIT,IncomeTax,EffectiveDate,In_Use,Reason,UserID) Values(@StaffID,@StaffCode,@PreviousSalary,@CurrentSalary,@NumberOfTimes,@Type,@SSNIT,@IncomeTax,@EffectiveDate,@In_Use,@Reason,@UserID)");
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
                Arrears arrear = (Arrears)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", arrear.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", arrear.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", arrear.Employee.ID, DbType.Int32);
                dal.CreateParameter("@PreviousSalary", arrear.PreviousSalary, DbType.Decimal);
                dal.CreateParameter("@CurrentSalary", arrear.CurrentSalary, DbType.Decimal);
                dal.CreateParameter("@NumberOfTimes", arrear.NumberOfTimes, DbType.Int32);
                dal.CreateParameter("@Type", arrear.Type, DbType.String);
                dal.CreateParameter("@SSNIT", arrear.SSNIT, DbType.Boolean);
                dal.CreateParameter("@IncomeTax", arrear.IncomeTax, DbType.Boolean);
                if (arrear.EffectiveDate == null)
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", arrear.EffectiveDate, DbType.Date);
                }
                dal.CreateParameter("@In_Use", arrear.In_Use, DbType.Boolean);
                dal.CreateParameter("@Reason", arrear.Reason, DbType.String);
                dal.CreateParameter("@UserID", arrear.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", arrear.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Arrears Set StaffID=@StaffID,StaffCode=@StaffCode,PreviousSalary=@PreviousSalary,CurrentSalary=@CurrentSalary,NumberOfTimes=@NumberOfTimes,Type=@Type,SSNIT=@SSNIT,IncomeTax=@IncomeTax,EffectiveDate=@EffectiveDate,In_Use=@In_Use,Reason=@Reason,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Arrears> GetAll()
        {
            IList<Arrears> arrears = new List<Arrears>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", arrear.Archived, DbType.String);
                string query = "select ArrearsView.* from ArrearsView ";
                query += "WHERE ArrearsView.Archived=@Archived order BY ArrearsView.DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Arrears arr in BuildArrearsFromData(table))
                {
                    arrears.Add(arr);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return arrears;
        }
        #endregion

        #region LazyLoadByStaffID
        public Arrears LazyLoadByStaffID(object key)
        {
            Arrears arrear = new Arrears();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString().Trim(), DbType.String);
                string query = "select ArrearsView.* from ArrearsView ";
                query += "WHERE ArrearsView.StaffID=@StaffID And ArrearsView.Archived=@Archived order BY ArrearsView.DateAndTimeGenerated DESC";

                table = dal.ExecuteReader(query);
                foreach (Arrears arr in BuildArrearsFromData(table))
                {
                    arrear = arr;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return arrear;
        }
        #endregion

        #region Get By ID
        public Arrears GetByID(object key)
        {
            Arrears arrear = new Arrears();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select ArrearsView.* from ArrearsView ";
                query += "WHERE ArrearsView.ID=@ID And ArrearsView.Archived=@Archived order BY ArrearsView.DateAndTimeGenerated DESC,ArrearsView.StaffID ASC";

                table = dal.ExecuteReader(query);
                foreach (Arrears arr in BuildArrearsFromData(table))
                {
                    arrear = arr;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return arrear;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Arrears arrear = (Arrears)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", arrear.ID, DbType.Int32);
                dal.CreateParameter("@Archived", arrear.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Arrears Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Arrears> GetByCriteria(Query query1)
        {
            IList<Arrears> arrears = new List<Arrears>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", arrear.Archived, DbType.Boolean);
                string query = "select ArrearsView.* from ArrearsView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  ArrearsView.Archived=@Archived order BY ArrearsView.DateAndTimeGenerated DESC,ArrearsView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Arrears arr in BuildArrearsFromData(table))
                {
                    arrears.Add(arr);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return arrears;
        }
        #endregion

        #region BuildArrearsFromData
        private IList<Arrears> BuildArrearsFromData(DataTable table)
        {
            IList<Arrears> arrears = new List<Arrears>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Arrears arrear = new Arrears()
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
                        CurrentSalary = row["CurrentSalary"] == DBNull.Value ? 0 : decimal.Parse(row["CurrentSalary"].ToString()),
                        PreviousSalary = row["PreviousSalary"] == DBNull.Value ? 0 : decimal.Parse(row["PreviousSalary"].ToString()),
                        NumberOfTimes = int.Parse(row["NumberOfTimes"].ToString()),
                        Type = row["Type"].ToString(),
                        EffectiveDate = row["EffectiveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EffectiveDate"].ToString()),
                        Reason = row["Reason"] is DBNull ? string.Empty : row["Reason"].ToString(),
                        User = new User() { ID = int.Parse(row["UserID"].ToString())},
                        In_Use = bool.Parse(row["In_Use"].ToString()),
                        SSNIT = bool.Parse(row["SSNIT"].ToString()),
                        IncomeTax = bool.Parse(row["IncomeTax"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                    };
                    arrears.Add(arrear);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return arrears;
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
