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
    public class StaffLoanPaymentDataMapper
    {
        private DALHelper dal;

        public StaffLoanPaymentDataMapper()
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
                StaffLoanPayment staffLoanPayment = (StaffLoanPayment)item;
                dal.ClearParameters();
                dal.CreateParameter("@StaffLoanID", staffLoanPayment.StaffLoan.ID, DbType.Int32);
                dal.CreateParameter("@PaymentDate", staffLoanPayment.PaymentDate, DbType.DateTime);
                dal.CreateParameter("@Amount", staffLoanPayment.Amount, DbType.Decimal);
                dal.CreateParameter("@NotAffectSalary", staffLoanPayment.NotAffectSalary, DbType.Boolean);
                dal.CreateParameter("@UserID", staffLoanPayment.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Insert Into StaffLoanPayments(StaffLoanID,PaymentDate,Amount,NotAffectSalary,UserID) Values(@StaffLoanID,@PaymentDate,@Amount,@NotAffectSalary,@UserID)");
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
                StaffLoanPayment staffLoanPayment = (StaffLoanPayment)item;
                dal.ClearParameters();
                dal.CreateParameter("@ID", staffLoanPayment.ID, DbType.Int32);
                dal.CreateParameter("@StaffLoanID", staffLoanPayment.StaffLoan.ID, DbType.Int32);
                dal.CreateParameter("@PaymentDate", staffLoanPayment.PaymentDate, DbType.DateTime);
                dal.CreateParameter("@Amount", staffLoanPayment.Amount, DbType.Decimal);
                dal.CreateParameter("@NotAffectSalary", staffLoanPayment.NotAffectSalary, DbType.Boolean);
                dal.CreateParameter("@UserID", staffLoanPayment.User.ID, DbType.Int32);

                dal.ExecuteNonQuery("Update StaffLoanPayments Set StaffLoanID=@StaffLoanID,PaymentDate=@PaymentDate,Amount=@Amount,NotAffectSalary=@NotAffectSalary,UserID=@UserID Where ID=@ID");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<StaffLoanPayment> GetAll()
        {
            IList<StaffLoanPayment> staffLoanPayments = new List<StaffLoanPayment>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From StaffLoanPaymentView Where Archived ='False' Order by ID DESC");
                foreach (DataRow row in table.Rows)
                {
                    foreach (StaffLoanPayment staffLoanP in BuildStaffLoanPaymentFromData(table))
                    {
                        staffLoanPayments.Add(staffLoanP);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
            return staffLoanPayments;
        }

        public IList<StaffLoanPayment> LazyLoad()
        {
            IList<StaffLoanPayment> staffLoanPayments = new List<StaffLoanPayment>();
            try
            {
                DataTable table = dal.ExecuteReader("Select * From StaffLoanPaymentView Where Archived ='False' Order by ID DESC");

                foreach (StaffLoanPayment staffLoanP in BuildStaffLoanPaymentFromData(table))
                {
                    staffLoanPayments.Add(staffLoanP);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoanPayments;
        }

        #region GetByCriteria
        public IList<StaffLoanPayment> GetByCriteria(Query query1)
        {
            IList<StaffLoanPayment> staffLoanPayments = new List<StaffLoanPayment>();
            try
            {
                DataTable table = new DataTable();
                string query = "select * from StaffLoanPaymentView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += "  Archived='False' order BY ID DESC";
                table = dal.ExecuteReader(selectStatement);
                foreach (StaffLoanPayment staffLoanP in BuildStaffLoanPaymentFromData(table))
                {
                    staffLoanPayments.Add(staffLoanP);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoanPayments;
        }
        #endregion

        private IList<StaffLoanPayment> BuildStaffLoanPaymentFromData(DataTable table)
        {
            IList<StaffLoanPayment> staffLoanPayments = new List<StaffLoanPayment>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    StaffLoanPayment staffLoanPayment = new StaffLoanPayment()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Amount = decimal.Parse(row["Amount"].ToString()),
                        PaymentDate = DateTime.Parse(row["PaymentDate"].ToString()),
                        StaffLoan = new StaffLoan() 
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
                            LoanAmount = decimal.Parse(row["AmountTobePaid"].ToString()),
                            LoanDescription = row["Description"].ToString(),
                            MonthlyInstallment = decimal.Parse(row["MonthlyInstallment"].ToString()),
                            SpreadOver = int.Parse(row["SpreadOver"].ToString()),
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
 
                        },
                        NotAffectSalary = bool.Parse(row["NotAffectSalary"].ToString()),
                        Archived = bool.Parse(row["Archived"].ToString()),
                        User = new User()
                        {
                            ID = int.Parse(row["UserID"].ToString()),
                        },
                        
                    };
                    staffLoanPayments.Add(staffLoanPayment);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffLoanPayments;
        }

        public void Delete(object item)
        {
            try
            {
                StaffLoanPayment staffLoanPayment = (StaffLoanPayment)item;
                dal.ExecuteNonQuery("Update StaffLoanPayments Set Archived = 'True' Where ID = " + staffLoanPayment.ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
