using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class AllowanceAndDeductionSummaryDataMapper
    {
        private DALHelper dal;

        public AllowanceAndDeductionSummaryDataMapper()
        {
            dal = new DALHelper();
        }

        public void Delete(object item)
        {
            AllowanceAndDeductionSummary allDedSum = (AllowanceAndDeductionSummary)item;
            dal.ExecuteNonQuery("Delete From AllowancesAndDeductionsSummary Where StartDate='" + allDedSum.StartDate + "' And EndDate='" + allDedSum.EndDate + "'");
        }

        public void Save(object item)
        {
            try
            {
                AllowanceAndDeductionSummary pAAD = (AllowanceAndDeductionSummary)item;
                foreach (StaffAllowance allowance in pAAD.Allowances)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@StaffID", allowance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", allowance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Description", allowance.Type.Description, DbType.String);
                    dal.CreateParameter("@Type", "Allowance", DbType.String);
                    dal.CreateParameter("@Frequency", allowance.Frequency, DbType.String);
                    dal.CreateParameter("@EffectiveDate", allowance.EffectiveDate, DbType.DateTime);
                    dal.CreateParameter("@Amount", allowance.Amount, DbType.Decimal);
                    dal.CreateParameter("@StartDate", pAAD.StartDate, DbType.DateTime);
                    dal.CreateParameter("@EndDate", pAAD.EndDate, DbType.DateTime);
                    dal.ExecuteNonQuery("Insert Into AllowancesAndDeductionsSummary(StaffID,StaffCode,Description,Type,Frequency,EffectiveDate,Amount,StartDate,EndDate) Values(@StaffID,@StaffCode,@Description,@Type,@Frequency,@EffectiveDate,@Amount,@StartDate,@EndDate)");
                }
                foreach (StaffDeduction deduction in pAAD.Deductions)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@StaffID", deduction.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", deduction.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Description", deduction.Type.Description, DbType.String);
                    dal.CreateParameter("@Type", "Deduction", DbType.String);
                    dal.CreateParameter("@Frequency", deduction.Frequency, DbType.String);
                    dal.CreateParameter("@EffectiveDate", deduction.EffectiveDate, DbType.DateTime);
                    dal.CreateParameter("@Amount", deduction.Amount, DbType.Decimal);
                    dal.CreateParameter("@StartDate", pAAD.StartDate, DbType.DateTime);
                    dal.CreateParameter("@EndDate", pAAD.EndDate, DbType.DateTime);
                    dal.ExecuteNonQuery("Insert Into AllowancesAndDeductionsSummary(StaffID,StaffCode,Description,Type,Frequency,EffectiveDate,Amount,StartDate,EndDate) Values(@StaffID,@StaffCode,@Description,@Type,@Frequency,@EffectiveDate,@Amount,@StartDate,@EndDate)");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
