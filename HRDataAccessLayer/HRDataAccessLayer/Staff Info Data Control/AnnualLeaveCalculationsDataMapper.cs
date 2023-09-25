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
    public class AnnualLeaveCalculationsDataMapper
    {
        private DALHelper dal;
        private AnnualLeaveCalculation annualLeaveCalculation;

        public AnnualLeaveCalculationsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.annualLeaveCalculation = new AnnualLeaveCalculation();
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
                AnnualLeaveCalculation annualLeaveCalculation = (AnnualLeaveCalculation)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", annualLeaveCalculation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", annualLeaveCalculation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@IsAll", annualLeaveCalculation.IsAll, DbType.Boolean);
                dal.CreateParameter("@NumberOfDays", annualLeaveCalculation.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Year", annualLeaveCalculation.Year, DbType.Int32);
                dal.CreateParameter("@Type", annualLeaveCalculation.Type, DbType.String);
                dal.CreateParameter("@UserID", annualLeaveCalculation.User.ID, DbType.Int32);
               
                dal.ExecuteNonQuery("Insert Into AnnualLeaveCalculations (StaffID,StaffCode,IsAll,NumberOfDays,Year,Type,UserID) Values(@StaffID,@StaffCode,@IsAll,@NumberOfDays,@Year,@Type,@UserID)");
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
                AnnualLeaveCalculation annualLeaveCalculation = (AnnualLeaveCalculation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", annualLeaveCalculation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", annualLeaveCalculation.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", annualLeaveCalculation.Employee.ID, DbType.Int32);
                dal.CreateParameter("@IsAll", annualLeaveCalculation.IsAll, DbType.Boolean);
                dal.CreateParameter("@NumberOfDays", annualLeaveCalculation.NumberOfDays, DbType.Decimal);
                dal.CreateParameter("@Year", annualLeaveCalculation.Year, DbType.Int32);
                dal.CreateParameter("@Type", annualLeaveCalculation.Type, DbType.String);
                dal.CreateParameter("@UserID", annualLeaveCalculation.User.ID, DbType.Int32);
                dal.CreateParameter("@Archived", annualLeaveCalculation.Archived, DbType.Boolean);

                dal.ExecuteNonQuery("Update AnnualLeaveCalculations Set StaffID=@StaffID,StaffCode=@StaffCode,IsAll=@IsAll,NumberOfDays=@NumberOfDays,Year=@Year,Type=@Type,UserID=@UserID Where ID =@ID and Archived=@Archived");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Get All
        public IList<AnnualLeaveCalculation> GetAll()
        {
            IList<AnnualLeaveCalculation> annualLeaveCalculations = new List<AnnualLeaveCalculation>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", annualLeaveCalculation.Archived, DbType.String);
                string query = "select AnnualLeaveCalculationView.* from AnnualLeaveCalculationView ";
                query += "WHERE AnnualLeaveCalculationView.Archived=@Archived order BY AnnualLeaveCalculationView.DateAndTimeGenerated DESC";
                DataTable table = dal.ExecuteReader(query);
                foreach (AnnualLeaveCalculation annualLeaveCalc in BuildAnnualLeaveCalculationFromData(table))
                {
                    annualLeaveCalculations.Add(annualLeaveCalc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return annualLeaveCalculations;
        }
        #endregion

        #region DELETE

        public void Delete(object item)
        {
            try
            {
                AnnualLeaveCalculation annualLeaveCalculation = (AnnualLeaveCalculation)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", annualLeaveCalculation.ID, DbType.Int32);
                dal.CreateParameter("@Archived", annualLeaveCalculation.Archived, DbType.Boolean);
                dal.ExecuteNonQuery("Update AnnualLeaveCalculations Set Archived=@Archived Where id =@ID");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        #endregion

        #region GetByCriteria
        public IList<AnnualLeaveCalculation> GetByCriteria(Query query1)
        {
            IList<AnnualLeaveCalculation> annualLeaveCalculations = new List<AnnualLeaveCalculation>();
            try
            {
                DataTable table = new DataTable();

                dal.ClearParameters();
                dal.CreateParameter("@Archived", annualLeaveCalculation.Archived, DbType.Boolean);
                string query = "select AnnualLeaveCalculationView.* from AnnualLeaveCalculationView ";
               
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  AnnualLeaveCalculationView.Archived=@Archived order BY AnnualLeaveCalculationView.StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (AnnualLeaveCalculation AnnualLeaveCalc in BuildAnnualLeaveCalculationFromData(table))
                {
                    annualLeaveCalculations.Add(AnnualLeaveCalc);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return annualLeaveCalculations;
        }
        #endregion

        #region BuildAnnualLeaveCalculationFromData
        private IList<AnnualLeaveCalculation> BuildAnnualLeaveCalculationFromData(DataTable table)
        {
            IList<AnnualLeaveCalculation> annualLeaveCalculations = new List<AnnualLeaveCalculation>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    AnnualLeaveCalculation annualLeaveCalculation = new AnnualLeaveCalculation()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = row["StaffCode"] == DBNull.Value ? 0 : int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"] == DBNull.Value ? null : row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? null : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? null : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? null : row["OtherName"].ToString(),
                        },
                        IsAll = bool.Parse(row["IsAll"].ToString()),
                        NumberOfDays = decimal.Parse(row["NumberOfDays"].ToString()),
                        Year = row["Year"] == DBNull.Value ? 0 : int.Parse(row["Year"].ToString()),
                        DateAndTimeGenerated = row["DateAndTimeGenerated"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateAndTimeGenerated"].ToString()),
                        User = new User() { ID = int.Parse(row["UserID"].ToString()), UserName = row["UserName"].ToString() },
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Type = row["IncrementType"] == DBNull.Value ? null : row["IncrementType"].ToString(),
                    };
                    annualLeaveCalculations.Add(annualLeaveCalculation);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return annualLeaveCalculations;
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
