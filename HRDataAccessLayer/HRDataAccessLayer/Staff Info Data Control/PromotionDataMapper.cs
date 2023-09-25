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
    public class PromotionDataMapper
    {
        private DALHelper dal;
        private Promotion promotion;

        public PromotionDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.promotion = new Promotion();
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
                Promotion promotion = (Promotion)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", promotion.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", promotion.Employee.ID, DbType.Int32);
                dal.CreateParameter("@PromotionTypeID", promotion.PromotionType.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", promotion.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", promotion.Grade.ID, DbType.Int32);
                dal.CreateParameter("@StepID", promotion.Step.ID, DbType.Int32);
                dal.CreateParameter("@BandID", promotion.Band.ID, DbType.Int32);
                dal.CreateParameter("@NewSalary", promotion.NewSalary, DbType.Decimal);
                if (promotion.PromotionDate == null)
                {
                    dal.CreateParameter("@PromotionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@PromotionDate", promotion.PromotionDate, DbType.Date);
                }
                if (promotion.NotionalDate == null)
                {
                    dal.CreateParameter("@NotionalDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@NotionalDate", promotion.NotionalDate, DbType.Date);
                }
                if (promotion.SubstantiveDate == null)
                {
                    dal.CreateParameter("@SubstantiveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@SubstantiveDate", promotion.SubstantiveDate, DbType.Date);
                }
                dal.CreateParameter("@Approved", promotion.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", promotion.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", promotion.ApprovedUserStaffID, DbType.String);
                if (promotion.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", promotion.ApprovedDate, DbType.Date);
                }
                if (promotion.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", promotion.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", promotion.Reason, DbType.String);
                dal.CreateParameter("@UserID", promotion.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into Promotions(StaffID,StaffCode,PromotionDate,NotionalDate,SubstantiveDate,PromotionTypeID,GradeCategoryID,GradeID,StepID,BandID,NewSalary,Reason,Approved,ApprovedUser,ApprovedUserStaffID,ApprovedDate,ApprovedTime,UserID) Values(@StaffID,@StaffCode,@PromotionDate,@NotionalDate,@SubstantiveDate,@PromotionTypeID,@GradeCategoryID,@GradeID,@StepID,@BandID,@NewSalary,@Reason,@Approved,@ApprovedUser,@ApprovedUserStaffID,@ApprovedDate,@ApprovedTime,@UserID)");
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
                Promotion promotion = (Promotion)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", promotion.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", promotion.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", promotion.Employee.ID, DbType.Int32);
                dal.CreateParameter("@PromotionTypeID", promotion.PromotionType.ID, DbType.Int32);
                dal.CreateParameter("@GradeCategoryID", promotion.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", promotion.Grade.ID, DbType.Int32);
                dal.CreateParameter("@StepID", promotion.Step.ID, DbType.Int32);
                dal.CreateParameter("@BandID", promotion.Band.ID, DbType.Int32);
                dal.CreateParameter("@NewSalary", promotion.NewSalary, DbType.Decimal);
                if (promotion.PromotionDate == null)
                {
                    dal.CreateParameter("@PromotionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@PromotionDate", promotion.PromotionDate, DbType.Date);
                }
                if (promotion.NotionalDate == null)
                {
                    dal.CreateParameter("@NotionalDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@NotionalDate", promotion.NotionalDate, DbType.Date);
                }
                if (promotion.SubstantiveDate == null)
                {
                    dal.CreateParameter("@SubstantiveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@SubstantiveDate", promotion.SubstantiveDate, DbType.Date);
                }
                dal.CreateParameter("@Approved", promotion.Approved, DbType.Boolean);
                dal.CreateParameter("@ApprovedUser", promotion.ApprovedUser, DbType.String);
                dal.CreateParameter("@ApprovedUserStaffID", promotion.ApprovedUserStaffID, DbType.String);
                if (promotion.ApprovedDate == null)
                {
                    dal.CreateParameter("@ApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ApprovedDate", promotion.ApprovedDate, DbType.Date);
                }
                if (promotion.ApprovedTime == null)
                {
                    dal.CreateParameter("@ApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ApprovedTime", promotion.ApprovedTime, DbType.DateTime);
                }
                dal.CreateParameter("@Reason", promotion.Reason, DbType.String);
                dal.CreateParameter("@UserID", promotion.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", promotion.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update Promotions Set StaffID=@StaffID,StaffCode=@StaffCode,PromotionDate=@PromotionDate,NotionalDate=@NotionalDate,SubstantiveDate=@SubstantiveDate,PromotionTypeID=@PromotionTypeID,GradeCategoryID=@GradeCategoryID,GradeID=@GradeID,StepID=@StepID,BandID=@BandID,NewSalary=@NewSalary,Reason=@Reason,UserID=@UserID,Approved=@Approved,ApprovedUser=@ApprovedUser,ApprovedUserStaffID=@ApprovedUserStaffID,ApprovedTime=@ApprovedTime,ApprovedDate=@ApprovedDate Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<Promotion> GetAll()
        {
            IList<Promotion> promotions = new List<Promotion>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", promotion.Archived, DbType.String);
                string query = "select PromotionView.* from PromotionView ";
                query += "WHERE PromotionView.Archived=@Archived order BY PromotionView.DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (Promotion promo in BuildPromotionFromData(table))
                {
                    promotions.Add(promo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return promotions;
        }
        #endregion

        #region LazyLoadByStaffID
        public Promotion LazyLoadByStaffID(object key)
        {
            Promotion promotion = new Promotion();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString().Trim(), DbType.String);
                string query = "select PromotionView.* from PromotionView ";
                query += "WHERE PromotionView.StaffID=@StaffID And PromotionView.Archived=@Archived order BY PromotionView.DateAndTimeGenerated DESC";

                table = dal.ExecuteReader(query);
                foreach (Promotion promo in BuildPromotionFromData(table))
                {
                    promotion = promo;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotion;
        }
        #endregion

        #region Get By ID
        public Promotion GetByID(object key)
        {
            Promotion promotion = new Promotion();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@ID", int.Parse(key.ToString()), DbType.Int32);
                string query = "select PromotionView.* from PromotionView ";
                query += "WHERE PromotionView.ID=@ID And PromotionView.Archived=@Archived order BY PromotionView.DateAndTimeGenerated DESC,PromotionView.StaffID ASC";

                table = dal.ExecuteReader(query);
                foreach (Promotion promo in BuildPromotionFromData(table))
                {
                    promotion = promo;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotion;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                Promotion promotion = (Promotion)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", promotion.ID, DbType.Int32);
                dal.CreateParameter("@Archived", promotion.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update Promotions Set Archived=@Archived Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<Promotion> GetByCriteria(Query query1)
        {
            IList<Promotion> promotions = new List<Promotion>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                string query = "select * from PromotionView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " order BY PromotionView.DateAndTimeGenerated DESC,PromotionView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (Promotion promo in BuildPromotionFromData(table))
                {
                    promotions.Add(promo);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotions;
        }
        #endregion

        #region BuildPromotionFromData
        private IList<Promotion> BuildPromotionFromData(DataTable table)
        {
            IList<Promotion> promotions = new List<Promotion>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Promotion promotion = new Promotion()
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
                            //FileNumber = new FileNumber()
                            //{
                            //    ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()),
                            //    Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString()
                            //},
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
                        PromotionDate = row["PromotionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["PromotionDate"].ToString()),
                        NotionalDate = row["NotionalDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["NotionalDate"].ToString()),
                        SubstantiveDate = row["SubstantiveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["SubstantiveDate"].ToString()),
                        GradeCategory = new GradeCategory()
                        {
                            ID = row["NewGradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["NewGradeCategoryID"].ToString()),
                            Description = row["NewGradeCategory"] == DBNull.Value ? string.Empty : row["NewGradeCategory"].ToString()
                        },
                        Grade = new EmployeeGrade()
                        {
                            ID = row["NewGradeID"] == DBNull.Value ? 0 : int.Parse(row["NewGradeID"].ToString()),
                            Grade = row["NewGrade"] == DBNull.Value ? string.Empty : row["NewGrade"].ToString()
                        },
                        PromotionType = new PromotionType()
                        {
                            ID = row["PromotionTypeID"] == DBNull.Value ? 0 : int.Parse(row["PromotionTypeID"].ToString()),
                            Description = row["PromotionType"] == DBNull.Value ? string.Empty : row["PromotionType"].ToString()
                        },
                        Step = new Step()
                        {
                            ID = row["StepID"] == DBNull.Value ? 0 : int.Parse(row["StepID"].ToString()),
                            Description = row["Step"] == DBNull.Value ? string.Empty : row["Step"].ToString()
                        },
                        Band = new Band()
                        {
                            ID = row["BandID"] == DBNull.Value ? 0 : int.Parse(row["BandID"].ToString()),
                            Description = row["Band"] == DBNull.Value ? null : row["Band"].ToString()
                        },
                        NewStepId = row["NewStepId"] == DBNull.Value ? 0 : int.Parse(row["NewStepId"].ToString()),
                        NewSalary = row["NewSalary"] == DBNull.Value ? 0 : decimal.Parse(row["NewSalary"].ToString()),
                        Reason = row["Reason"] is DBNull ? string.Empty : row["Reason"].ToString(),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString())},
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Approved = bool.Parse(row["Approved"].ToString()),
                        ApprovedUser = row["ApprovedUser"] == DBNull.Value ? string.Empty : row["ApprovedUser"].ToString(),
                        ApprovedUserStaffID = row["ApprovedUserStaffID"] == DBNull.Value ? string.Empty : row["ApprovedUserStaffID"].ToString(),
                        ApprovedDate = row["ApprovedDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedDate"].ToString()),
                        ApprovedTime = row["ApprovedTime"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ApprovedTime"].ToString()),
                    };
                    promotions.Add(promotion);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return promotions;
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
