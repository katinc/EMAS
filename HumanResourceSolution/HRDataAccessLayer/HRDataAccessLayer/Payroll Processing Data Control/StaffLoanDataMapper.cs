using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class StaffLoanDataMapper
    {
        private DALHelper dal;

        public StaffLoanDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void Save(object item)
        {
            try
            {
                StaffLoan staffLoan = (StaffLoan)item;
                dal.ClearParameters();
                dal.CreateParameter("@AmountToBePaid", staffLoan.AmountToBePaid, DbType.Decimal);
                dal.CreateParameter("@DateFrom", staffLoan.DateFrom, DbType.DateTime);
                dal.CreateParameter("@DateOfLoan", staffLoan.DateOfLoan, DbType.DateTime);
                dal.CreateParameter("@DateTo", staffLoan.DateTo, DbType.DateTime);
                dal.CreateParameter("@Interest", staffLoan.Interest, DbType.Decimal);
                dal.CreateParameter("@InterestRate", staffLoan.InterestRate, DbType.Decimal);
                dal.CreateParameter("@Amount", staffLoan.LoanAmount, DbType.Decimal);
                dal.CreateParameter("@Description", staffLoan.LoanDescription, DbType.String);
                dal.CreateParameter("@MonthlyInstallment", staffLoan.MonthlyInstallment, DbType.Decimal);
                dal.CreateParameter("@SpreadOver", staffLoan.SpreadOver, DbType.Int32);
                dal.CreateParameter("@StaffID", staffLoan.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffLoan.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Type", staffLoan.Loan.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffLoan.User.ID, DbType.Int32);
                dal.CreateParameter("@NotAffectSalary", staffLoan.NotAffectSalary, DbType.Boolean);


                dal.ExecuteNonQuery("Insert Into StaffLoans(AmountToBePaid,DateFrom,DateOfLoan,DateTo,Interest,InterestRate,Amount,Description,MonthlyInstallment,SpreadOver,StaffID,StaffCode,Type,NotAffectSalary,UserID) Values(@AmountToBePaid,@DateFrom,@DateOfLoan,@DateTo,@Interest,@InterestRate,@Amount,@Description,@MonthlyInstallment,@SpreadOver,@StaffID,@StaffCode,@Type,@NotAffectSalary,@UserID)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(object item)
        {
            try
            {
                StaffLoan staffLoan = (StaffLoan)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffLoan.ID, DbType.Int32);
                dal.CreateParameter("@AmountToBePaid", staffLoan.AmountToBePaid, DbType.Decimal);
                dal.CreateParameter("@DateFrom", staffLoan.DateFrom, DbType.DateTime);
                dal.CreateParameter("@DateOfLoan", staffLoan.DateOfLoan, DbType.DateTime);
                dal.CreateParameter("@DateTo", staffLoan.DateTo, DbType.DateTime);
                dal.CreateParameter("@Interest", staffLoan.Interest, DbType.Decimal);
                dal.CreateParameter("@InterestRate", staffLoan.InterestRate, DbType.Decimal);
                dal.CreateParameter("@Amount", staffLoan.LoanAmount, DbType.Decimal);
                dal.CreateParameter("@Description", staffLoan.LoanDescription, DbType.String);
                dal.CreateParameter("@MonthlyInstallment", staffLoan.MonthlyInstallment, DbType.Decimal);
                dal.CreateParameter("@SpreadOver", staffLoan.SpreadOver, DbType.Int32);
                dal.CreateParameter("@StaffID", staffLoan.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", staffLoan.Employee.ID, DbType.Int32);
                dal.CreateParameter("@Type", staffLoan.Loan.ID, DbType.Int32);
                dal.CreateParameter("@UserID", staffLoan.User.ID, DbType.Int32);
                dal.CreateParameter("@NotAffectSalary", staffLoan.NotAffectSalary, DbType.Boolean);

                dal.ExecuteNonQuery("Update StaffLoans Set AmountToBePaid=@AmountToBePaid,DateFrom=@DateFrom,DateOfLoan=@DateOfLoan,DateTo=@DateTo,Interest=@Interest,InterestRate=@InterestRate,Amount=@Amount,Description=@Description,MonthlyInstallment=@MonthlyInstallment,SpreadOver=@SpreadOver,StaffID=@StaffID,StaffCode=@StaffCode,Type=@Type,NotAffectSalary=@NotAffectSalary,UserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<StaffLoan> GetAll()
        {
            IList<StaffLoan> staffLoans = new List<StaffLoan>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From StaffLoanView Where Archived ='False'");
                foreach (StaffLoan staffL in BuildStaffLoanFromData(table))
                {
                    staffLoans.Add(staffL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return staffLoans;
        }

        public IList<StaffLoan> LazyLoad()
        {
            IList<StaffLoan> staffLoans = new List<StaffLoan>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From StaffLoanView Where Archived ='False'");
                foreach (StaffLoan staffL in BuildStaffLoanFromData(table))
                {
                    staffLoans.Add(staffL);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoans;
        }

        #region GetByCriteria
        public IList<StaffLoan> GetByCriteria(Query query1)
        {
            IList<StaffLoan> staffLoans = new List<StaffLoan>();
            try
            {
                DataTable table = new DataTable();
                string query = "select * from StaffLoanView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY StaffID ASC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffLoan staffL in BuildStaffLoanFromData(table))
                {
                    staffLoans.Add(staffL);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoans;
        }
        #endregion

        private IList<StaffLoan> BuildStaffLoanFromData(DataTable table)
        {
            IList<StaffLoan> staffLoans = new List<StaffLoan>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffLoan staffLoan = new StaffLoan()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"].ToString(),
                            Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString(),
                            FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString(),
                            OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString(),
                        },
                        StaffName = row["Firstname"].ToString() + " " + row["Surname"].ToString() + " " + row["OtherName"].ToString(),
                        AmountToBePaid = decimal.Parse(row["AmountToBePaid"].ToString()),
                        DateFrom = DateTime.Parse(row["DateFrom"].ToString()),
                        DateTo = DateTime.Parse(row["DateTo"].ToString()),
                        DateOfLoan = DateTime.Parse(row["DateOfLoan"].ToString()),
                        Interest = decimal.Parse(row["Interest"].ToString()),
                        InterestRate = decimal.Parse(row["InterestRate"].ToString()),
                        LoanAmount = decimal.Parse(row["Amount"].ToString()),
                        LoanDescription = row["Description"].ToString(),
                        MonthlyInstallment = decimal.Parse(row["MonthlyInstallment"].ToString()),
                        SpreadOver = int.Parse(row["SpreadOver"].ToString()),
                        NotAffectSalary = bool.Parse(row["NotAffectSalary"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        Count=1,
                        Loan = new Loan()
                        {
                            ID = int.Parse(row["LID"].ToString()),
                            Description = row["Loan"].ToString(),
                            Type = new LoanType()
                            {
                                ID = int.Parse(row["LoanTypeID"].ToString()),
                                Description = row["LoanType"].ToString(),
                            },
                        },
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                        },
                        
                    };
                    staffLoans.Add(staffLoan);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoans;
        }

        public void Delete(object item)
        {
            try
            {
                StaffLoan staffLoan = (StaffLoan)item;
                dal.ExecuteNonQuery("Update StaffLoans Set Archived = 'True' Where ID = " + staffLoan.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
