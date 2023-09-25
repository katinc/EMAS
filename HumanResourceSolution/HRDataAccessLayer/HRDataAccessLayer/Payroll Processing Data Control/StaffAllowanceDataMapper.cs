using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Data;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class StaffAllowanceDataMapper
    {
        private DALHelper dal;

        public StaffAllowanceDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Save
        public void Save(object item)
        {
            try
            {
                StaffAllowance staffAllowance = (StaffAllowance)item;

                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", staffAllowance.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffAllowance.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Amount", staffAllowance.Amount, DbType.Decimal);
                if (staffAllowance.EffectiveDate != null)
                {
                    dal.CreateParameter("@EffectiveDate", staffAllowance.EffectiveDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@IsEndDate", staffAllowance.IsEndDate, DbType.Boolean);
                if (staffAllowance.IsEndDate == true && staffAllowance.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", staffAllowance.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                
                dal.CreateParameter("@Frequency", staffAllowance.Frequency, DbType.String);
                dal.CreateParameter("@InUse", staffAllowance.InUse, DbType.Boolean);
                dal.CreateParameter("@AllowanceID", staffAllowance.Type.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffAllowance.User.ID, DbType.Int32);
                dal.ExecuteNonQuery("Insert Into StaffAllowances (StaffID,StaffCode,Amount,EffectiveDate,IsEndDate,EndDate,Frequency,InUse,TypeID) Values(@StaffID,@StaffCode,@Amount,@EffectiveDate,@IsEndDate,@EndDate,@Frequency,@InUse,@AllowanceID)");
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
                StaffAllowance staffAllowance = (StaffAllowance)item;

                dal.ClearParameters();
                dal.CreateParameter("@ID", staffAllowance.ID, DbType.Int32);
                dal.CreateParameter("@StaffCode", staffAllowance.Employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", staffAllowance.Employee.StaffID, DbType.String);
                dal.CreateParameter("@Amount", staffAllowance.Amount, DbType.Decimal);
                if (staffAllowance.EffectiveDate != null)
                {
                    dal.CreateParameter("@EffectiveDate", staffAllowance.EffectiveDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EffectiveDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@IsEndDate", staffAllowance.IsEndDate, DbType.Boolean);
                if (staffAllowance.IsEndDate == true && staffAllowance.EndDate != null)
                {
                    dal.CreateParameter("@EndDate", staffAllowance.EndDate, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                }
                dal.CreateParameter("@Frequency", staffAllowance.Frequency, DbType.String);
                dal.CreateParameter("@InUse", staffAllowance.InUse, DbType.Boolean);
                dal.CreateParameter("@AllowanceID", staffAllowance.Type.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffAllowance.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update StaffAllowances Set StaffID=@StaffID,StaffCode=@StaffCode,Amount=@Amount,EffectiveDate=@EffectiveDate,IsEndDate=@IsEndDate,EndDate=@EndDate,Frequency=@Frequency,InUse=@InUse,TypeID=@AllowanceID Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<StaffAllowance> GetAll()
        {
            IList<StaffAllowance> staffAllowances = new List<StaffAllowance>();
            try
            {
                string query = "Select * From StaffAllowanceView Where StaffAllowanceView.Archived ='False' and StaffAllowanceView.AllowanceArchived='False' and StaffAllowanceView.AllowanceInUse='True'";
                DataTable table = dal.ExecuteReader(query);
                foreach (StaffAllowance staffallow in BuildStaffAllowanceFromData(table))
                {
                    staffAllowances.Add(staffallow);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffAllowances;
        }
        #endregion

        #region GetByCriteria
        public IList<StaffAllowance> GetByCriteria(Query query1)
        {
            IList<StaffAllowance> staffAllowances = new List<StaffAllowance>();
            StaffAllowance staffAllowance = new StaffAllowance();
            try
            {
                DataTable table = new DataTable();
                string query = "Select * from StaffAllowanceView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Archived='False' Order By StaffAllowanceView.StaffID ";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffAllowance staffallowa in BuildStaffAllowanceFromData(table))
                {
                    staffAllowances.Add(staffallowa);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffAllowances;
        }
        #endregion

        #region BuildStaffAllowanceFromData
        private IList<StaffAllowance> BuildStaffAllowanceFromData(DataTable table)
        {
            IList<StaffAllowance> staffAllowances = new List<StaffAllowance>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffAllowance staffAllowance = new StaffAllowance()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = row["StaffCode"] == DBNull.Value ? 0 : int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"] == DBNull.Value ? string.Empty : row["StaffID"].ToString()
                        },
                        InUse = row["InUse"] == DBNull.Value ? true : bool.Parse(row["InUse"].ToString()),
                        Amount = row["Amount"] == DBNull.Value ? 0 : decimal.Parse(row["Amount"].ToString()),
                        EffectiveDate = row["EffectiveDate"] is DBNull ? DateTime.Today : (Nullable<DateTime>)DateTime.Parse(row["EffectiveDate"].ToString()),
                        EndDate = row["EndDate"] is DBNull ? DateTime.Today : (Nullable<DateTime>)DateTime.Parse(row["EndDate"].ToString()),
                        IsEndDate = bool.Parse(row["IsEndDate"].ToString()),
                        Frequency = row["Frequency"] == DBNull.Value ? string.Empty : row["Frequency"].ToString(),
                        Type = new Allowance()
                        {
                            ID = row["AllowanceID"] == DBNull.Value ? 0 : int.Parse(row["AllowanceID"].ToString()),
                            Description = row["Allowance"] == DBNull.Value ? string.Empty : row["Allowance"].ToString()
                        },
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? string.Empty : row["UserName"].ToString()
                        },
                        Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString()),
                    };

                    staffAllowances.Add(staffAllowance);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffAllowances;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            try
            {
                StaffAllowance staffAllowance = (StaffAllowance)item;
                dal.ExecuteNonQuery("Update StaffAllowances Set Archived ='True' Where ID=" + staffAllowance.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
