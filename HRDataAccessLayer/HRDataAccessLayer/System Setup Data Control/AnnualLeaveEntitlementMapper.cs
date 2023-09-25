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
    public class AnnualLeaveEntitlementMapper
    {
        private DALHelper dal;
        private AnnualLeaveEntitlement annualLeaveEntitlement;

        public AnnualLeaveEntitlementMapper()
        {
            this.dal = new DALHelper();
            this.annualLeaveEntitlement = new AnnualLeaveEntitlement();
        }

        #region SAVE
        public void Save(object item)
        {
            try
            {
                AnnualLeaveEntitlement annualLeaveEntitlement = (AnnualLeaveEntitlement)item;
                dal.ClearParameters();
                dal.CreateParameter("@Status", annualLeaveEntitlement.Status, DbType.String);
                dal.CreateParameter("@CategoryOfPost", annualLeaveEntitlement.CategoryOfPost, DbType.String);
                dal.CreateParameter("@TypesOfGrade", annualLeaveEntitlement.TypeOfGrade, DbType.String);
                dal.CreateParameter("@NumberOfDays", annualLeaveEntitlement.NumberOfDays, DbType.Int32);
                dal.CreateParameter("@PromotionYears", annualLeaveEntitlement.PromotionYears, DbType.Int32);
                dal.CreateParameter("@Active", annualLeaveEntitlement.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", annualLeaveEntitlement.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into AnnualLeaveEntitlement (Status,CategoryOfPost,TypesOfGrade,NumberOfDays,PromotionYears,Active,UserID) Values(@Status,@CategoryOfPost,@TypesOfGrade,@NumberOfDays,@PromotionYears,@Active,@UserID)");
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
                AnnualLeaveEntitlement annualLeaveEntitlement = (AnnualLeaveEntitlement)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", annualLeaveEntitlement.ID, DbType.Int32);
                dal.CreateParameter("@Status", annualLeaveEntitlement.Status, DbType.String);
                dal.CreateParameter("@CategoryOfPost", annualLeaveEntitlement.CategoryOfPost, DbType.String);
                dal.CreateParameter("@TypesOfGrade", annualLeaveEntitlement.TypeOfGrade, DbType.String);
                dal.CreateParameter("@NumberOfDays", annualLeaveEntitlement.NumberOfDays, DbType.Int32);
                dal.CreateParameter("@PromotionYears", annualLeaveEntitlement.PromotionYears, DbType.Int32);
                dal.CreateParameter("@Active", annualLeaveEntitlement.Active, DbType.Boolean);
                dal.CreateParameter("@UserID", annualLeaveEntitlement.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update AnnualLeaveEntitlement Set Status=@Status,CategoryOfPost=@CategoryOfPost,TypesOfGrade=@TypesOfGrade,NumberOfDays=@NumberOfDays,PromotionYears=@PromotionYears,Active=@Active,UserID=@UserID Where ID =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<AnnualLeaveEntitlement> GetAll()
        {
            IList<AnnualLeaveEntitlement> annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", annualLeaveEntitlement.Archived, DbType.String);
                string query = "select * from AnnualLeaveEntitlementView ";
                query += "WHERE AnnualLeaveEntitlementView.Archived=@Archived order BY AnnualLeaveEntitlementView.CategoryOfPost ASC";
                DataTable table = dal.ExecuteReader(query);
                foreach (AnnualLeaveEntitlement annualLeaveEntitlemnt in BuildAnnualLeaveEntitlementFromData(table))
                {
                    annualLeaveEntitlements.Add(annualLeaveEntitlemnt);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return annualLeaveEntitlements;
        }
        #endregion

        #region GetByCriteria
        public IList<AnnualLeaveEntitlement> GetByCriteria(Query query1)
        {
            IList<AnnualLeaveEntitlement> annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);

                string query = "select AnnualLeaveEntitlementView.* from AnnualLeaveEntitlementView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  AnnualLeaveEntitlementView.Archived=@Archived order BY AnnualLeaveEntitlementView.CategoryOfPost ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (AnnualLeaveEntitlement annualLeaveEntitlemnt in BuildAnnualLeaveEntitlementFromData(table))
                {
                    annualLeaveEntitlements.Add(annualLeaveEntitlemnt);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return annualLeaveEntitlements;
        }
        #endregion

        #region BuildAnnualLeaveEntitlementFromData
        private IList<AnnualLeaveEntitlement> BuildAnnualLeaveEntitlementFromData(DataTable table)
        {
            IList<AnnualLeaveEntitlement> annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
            foreach (DataRow row in table.Rows)
            {
                AnnualLeaveEntitlement annualLeaveEntitlement = new AnnualLeaveEntitlement()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    Status = row["Status"].ToString(),
                    CategoryOfPost = row["CategoryOfPost"].ToString(),
                    TypeOfGrade = row["TypesOfGrade"].ToString(),
                    NumberOfDays = int.Parse(row["NumberOfDays"].ToString()),
                    PromotionYears = int.Parse(row["PromotionYears"].ToString()),
                    User = new User() { ID = int.Parse(row["UserID"].ToString())},
                    Archived = bool.Parse(row["Archived"].ToString()),
                    Active = bool.Parse(row["Active"].ToString()),
                    IncludeWeekends = (row["IncludeWeekends"] != null) ? bool.Parse(row["IncludeWeekends"].ToString()) : false,
                    IncludeHolidays = (row["IncludeHolidays"] != null) ? bool.Parse(row["IncludeHolidays"].ToString()) : false,
                };
                annualLeaveEntitlements.Add(annualLeaveEntitlement);
            }
            return annualLeaveEntitlements;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                AnnualLeaveEntitlement annualLeaveEntitlement = (AnnualLeaveEntitlement)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", annualLeaveEntitlement.ID, DbType.Int32);
                dal.CreateParameter("@Archived", annualLeaveEntitlement.Archived, DbType.Boolean);
                dal.CreateParameter("@Active", annualLeaveEntitlement.Active, DbType.Boolean);
                dal.ExecuteNonQuery("Update AnnualLeaveEntitlement Set Active=@Active,Archived=@Archived Where id =@ID");
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
