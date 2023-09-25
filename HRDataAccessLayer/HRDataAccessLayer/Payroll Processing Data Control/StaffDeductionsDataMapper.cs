using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class StaffDeductionsDataMapper
    {
        private DALHelper dal;
        private StaffDeduction staffDeduction;

        public StaffDeductionsDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.staffDeduction = new StaffDeduction();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                StaffDeduction staffDeduction = (StaffDeduction)item;

                dal.ClearParameters();
                dal.CreateParameter("@StaffID", staffDeduction.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffDeduction.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Amount", staffDeduction.Amount, DbType.Decimal);
                if (staffDeduction.EffectiveDate != null)
                {
                    dal.CreateParameter("@EffectiveDate", staffDeduction.EffectiveDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@IsEndDate", staffDeduction.IsEndDate, DbType.Boolean);
                if (staffDeduction.IsEndDate == true && staffDeduction.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", staffDeduction.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@Frequency", staffDeduction.Frequency, DbType.String);
                dal.CreateParameter("@InUse", staffDeduction.InUse, DbType.Boolean);
                dal.CreateParameter("@AllowanceID", staffDeduction.Type.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffDeduction.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into StaffDeductions (StaffID,StaffCode,Amount,EffectiveDate,IsEndDate,EndDate,Frequency,InUse,TypeID,UserID) Values(@StaffID,@StaffCode,@Amount,@EffectiveDate,@IsEndDate,@EndDate,@Frequency,@InUse,@AllowanceID,@UserID)");
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
                StaffDeduction staffDeduction = (StaffDeduction)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", staffDeduction.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffDeduction.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffDeduction.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Amount", staffDeduction.Amount, DbType.Decimal);
                if (staffDeduction.EffectiveDate != null)
                {
                    dal.CreateParameter("@EffectiveDate", staffDeduction.EffectiveDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@IsEndDate", staffDeduction.IsEndDate, DbType.Boolean);
                if (staffDeduction.IsEndDate == true && staffDeduction.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", staffDeduction.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@Frequency", staffDeduction.Frequency, DbType.String);
                dal.CreateParameter("@InUse", staffDeduction.InUse, DbType.Boolean);
                dal.CreateParameter("@AllowanceID", staffDeduction.Type.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffDeduction.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Update StaffDeductions Set UserID=@UserID,StaffID=@StaffID,StaffCode=@StaffCode,Amount=@Amount,EffectiveDate=@EffectiveDate,IsEndDate=@IsEndDate,EndDate=@EndDate,Frequency=@Frequency,InUse=@InUse,TypeID=@AllowanceID Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<StaffDeduction> GetAll()
        {
            IList<StaffDeduction> staffDeductions = new List<StaffDeduction>();
            try
            {
                string query = "Select * From StaffDeductionView Where StaffDeductionView.Archived ='False' ";
                query += "and StaffDeductionView.DeductionArchived = 'False' and StaffDeductionView.DeductionActive = 'True' ";

                DataTable table = dal.ExecuteReader(query);
                foreach (StaffDeduction staffded in BuildStaffDeductionFromData(table))
                {
                    staffDeductions.Add(staffded);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffDeductions;
        }
        #endregion

        #region GetByCriteria
        public IList<StaffDeduction> GetByCriteria(Query query1)
        {
            IList<StaffDeduction> staffDeductions = new List<StaffDeduction>();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from StaffDeductionView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' Order By StaffDeductionView.StaffID ";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffDeduction staffDedu in BuildStaffDeductionFromData(table))
                {
                    staffDeductions.Add(staffDedu);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDeductions;
        }
        #endregion

        #region BuildStaffDeductionFromData
        private IList<StaffDeduction> BuildStaffDeductionFromData(DataTable table)
        {
            IList<StaffDeduction> staffDeductions = new List<StaffDeduction>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffDeduction staffDeduction = new StaffDeduction()
                    {
                        //Personal Info
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = row["StaffCode"] == DBNull.Value ? 0 : int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"] == DBNull.Value ? null : row["StaffID"].ToString()
                        },
                        InUse = row["InUse"] == DBNull.Value ? true : bool.Parse(row["InUse"].ToString()),
                        Type = new Deduction()
                        {
                            ID = row["DeductionID"] == DBNull.Value ? 0 : int.Parse(row["DeductionID"].ToString()),
                            Description = row["Deduction"] == DBNull.Value ? null : row["Deduction"].ToString()
                        },
                        Amount = row["Amount"] == DBNull.Value ? 0 : Decimal.Parse(row["Amount"].ToString()),
                        EffectiveDate = row["EffectiveDate"] is DBNull ? DateTime.Today : (Nullable<DateTime>)DateTime.Parse(row["EffectiveDate"].ToString()),
                        EndDate = row["EndDate"] is DBNull ? DateTime.Today : (Nullable<DateTime>)DateTime.Parse(row["EndDate"].ToString()),
                        IsEndDate = bool.Parse(row["IsEndDate"].ToString()),
                        Frequency = row["Frequency"] == DBNull.Value ? null : row["Frequency"].ToString(),
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? null : row["UserName"].ToString()
                        },
                        Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString()),
                    };

                    staffDeductions.Add(staffDeduction);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffDeductions;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                StaffDeduction staffDeduction = (StaffDeduction)item;
                dal.ExecuteNonQuery("Update StaffDeductions Set Archived ='True' Where ID=" + staffDeduction.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
