using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using System.Data;


namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class LoanPaymentDataMapper
    {
        DALHelper dal;

        public LoanPaymentDataMapper()
        {
            dal = new DALHelper();
        }

        #region SAVE
        public void Save(StaffLoanPayment loanPayment)
        {
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@PaymentDate",loanPayment.PaymentDate,DbType.DateTime);
                dal.CreateParameter("@Amount",loanPayment.Amount,DbType.Decimal);
                dal.CreateParameter("@NotAffectSalary",loanPayment.NotAffectSalary,DbType.Boolean);
                dal.ExecuteNonQuery("INSERT INTO StaffLoanPayments(PaymentDate,Amount,NotAffectSalary) Values(@PaymentDate,@Amount,@NotAffectSalary)");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<StaffLoanPayment> GetAll()
        {
            IList<StaffLoanPayment> loans = new List<StaffLoanPayment>();
            try
            {
                DataTable table = dal.ExecuteReader("select ID,PaymentDate,Amount,NotAffectSalary From StaffLoanPayments ");
                foreach (DataRow row in table.Rows)
                {
                    loans.Add(new StaffLoanPayment() { ID = int.Parse(row["ID"].ToString()), PaymentDate = DateTime.Parse(row["PaymentDate"].ToString()), NotAffectSalary = bool.Parse(row["NotAffectSalary"].ToString()), Amount  = decimal.Parse(row["Amount"].ToString())});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return loans;
        }
        #endregion
    }
}
