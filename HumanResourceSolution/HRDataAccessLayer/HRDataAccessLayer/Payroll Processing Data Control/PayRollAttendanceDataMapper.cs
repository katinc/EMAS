using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.ComponentModel;
using System.Data;
using HRDataAccessLayerBase;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class PayRollAttendanceDataMapper
    {
        private DALHelper dal;

        public PayRollAttendanceDataMapper()
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
        

        #region SAVE
        public void Save(object item)
        {
            try
            {
                PayRollAttendance attendance = (PayRollAttendance)item;
                dal.ClearParameters();
                dal.CreateParameter("@Title", attendance.Employee.Title.Description, DbType.String);
                dal.CreateParameter("@Name", attendance.Name, DbType.String);
                dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                dal.CreateParameter("@DaysOfAttendance", attendance.Attendance, DbType.String);
                dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                dal.CreateParameter("@BasicSalary", attendance.BasicSalary, DbType.Decimal);
                dal.CreateParameter("@ActualBasicSalary", attendance.ActualBasicSalary, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployee", attendance.SSNITEmployee, DbType.Decimal);
                dal.CreateParameter("@SSNITFirstTier", attendance.SSNITFirstTier, DbType.Decimal);
                dal.CreateParameter("@SecondTier", attendance.SecondTier, DbType.Decimal);
                dal.CreateParameter("@IncomeTax", attendance.IncomeTax, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployer", attendance.SSNITEmployer, DbType.Decimal);
                dal.CreateParameter("@PaymentMode", attendance.PaymentMode, DbType.String);
                dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                dal.CreateParameter("@GradeLevel", attendance.Band.Description, DbType.String);
                dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                dal.CreateParameter("@SSNIT", attendance.SSNIT, DbType.Boolean);
                dal.CreateParameter("@SSNITNo", attendance.SsnitNo, DbType.String);
                dal.CreateParameter("@NetAfterTax", attendance.NetAfterTax, DbType.Decimal);
                dal.CreateParameter("@MedicalClaims", attendance.MedicalClaims, DbType.Decimal);
                dal.CreateParameter("@Arrears", attendance.Arrears, DbType.Decimal);
                dal.CreateParameter("@UserID", attendance.User.ID, DbType.Int32);
                dal.CreateParameter("@UserName", attendance.User.Name, DbType.String);
                dal.CreateParameter("@NetSalary", attendance.NetSalary, DbType.Decimal);
                dal.CreateParameter("@TakeHome", attendance.TakeHome, DbType.Decimal);
                dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                dal.CreateParameter("@Status", attendance.Status, DbType.Int32);
                dal.CreateParameter("@TotalAllowance", attendance.TotalAllowance, DbType.Decimal);
                dal.CreateParameter("@TotalDeduction", attendance.TotalDeductions, DbType.Decimal);
                dal.CreateParameter("@GrandTotalAllowance", attendance.GrandTotalAllowance, DbType.Decimal);
                dal.CreateParameter("@GrandTotalDeduction", attendance.GrandTotalDeductions, DbType.Decimal);
                dal.CreateParameter("@InitialLoan", attendance.InitialLoan, DbType.Decimal);
                dal.CreateParameter("@Loan", attendance.TotalLoans, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployeeRate", attendance.SsnitEmployeeRate, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployerRate", attendance.SsnitEmployerRate, DbType.Decimal);
                dal.CreateParameter("@SSNITFirstTierRate", attendance.SSNITFirstTierRate, DbType.Decimal);
                dal.CreateParameter("@SecondTierRate", attendance.SecondTierRate, DbType.Decimal);
                dal.CreateParameter("@GrossSalary", attendance.GrossSalary, DbType.Decimal);
                dal.CreateParameter("@TaxableIncome", attendance.TaxableIncome, DbType.Decimal);

                dal.CreateParameter("@IsExemptFromSecondTier", attendance.Employee.IsExemptFromSecondTier, DbType.Boolean);
                dal.CreateParameter("@IsSusuPlusContribution", attendance.Employee.IsSusuPlusContribution, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTax", attendance.Employee.IsWithholdingTax, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTaxFixedAmount", attendance.Employee.IsWithholdingTaxFixedAmount, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTaxRate", attendance.Employee.IsWithholdingTaxRate, DbType.Boolean);

                dal.CreateParameter("@SusuPlusContribution", attendance.SusuPlusContributionAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingAmount", attendance.WithholdingAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingFixedTaxAmount", attendance.WithholdingTaxFixedAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingTaxCalculateOn", attendance.SalaryType.Description, DbType.String);//SalaryType
                dal.CreateParameter("@WithholdingTaxRate", attendance.WithholdingTaxRate, DbType.Decimal);

                dal.CreateParameter("@Bank", attendance.StaffBank.Bank.Description, DbType.String);
                dal.CreateParameter("@BankBranch", attendance.StaffBank.BankBranch.Description, DbType.String);
                dal.CreateParameter("@BankAddress", attendance.StaffBank.Address, DbType.String);
                dal.CreateParameter("@AccountNumber", attendance.StaffBank.AccountNumber, DbType.String);
                dal.CreateParameter("@AccountType", attendance.StaffBank.AccountType.Description, DbType.String);
                dal.CreateParameter("@AccountName", attendance.StaffBank.AccountName, DbType.String);

                dal.CreateParameter("@Email", attendance.Employee.Email, DbType.String);
                dal.CreateParameter("@MobileNumber", attendance.Employee.MobileNo, DbType.String);
                dal.CreateParameter("@IsProvidentFund", attendance.IsProvidentFund, DbType.Boolean);
                dal.CreateParameter("@IsExemptAllowance", attendance.IsExemptAllowance, DbType.Boolean);
                dal.CreateParameter("@IsExemptDeduction", attendance.IsExemptDeduction, DbType.Boolean);
                dal.CreateParameter("@ProvidentFundEmployee", attendance.ProvidentFundEmployee, DbType.Decimal);
                dal.CreateParameter("@ProvidentFundEmployer", attendance.ProvidentFundEmployer, DbType.Decimal);
                dal.CreateParameter("@ProvidentFundEmployeeRate", attendance.ProvidentFundEmployeeRate, DbType.Decimal);
                dal.CreateParameter("@ProvidentFundEmployerRate", attendance.ProvidentFundEmployerRate, DbType.Decimal);

                dal.CreateParameter("@TotalOverTime", attendance.TotalOverTime, DbType.Decimal);
                dal.CreateParameter("@TotalOverTimeHours", attendance.TotalOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@PublicHolidayOverTime", attendance.PublicHolidayOverTime, DbType.Decimal);
                dal.CreateParameter("@PublicHolidayOverTimeHours", attendance.PublicHolidayOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@DailyOverTime", attendance.DailyOverTime, DbType.Decimal);
                dal.CreateParameter("@DailyOverTimeHours", attendance.DailyOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@HoursWorked", attendance.HoursWorked, DbType.Decimal);


                dal.CreateParameter("@WeekendOverTime", attendance.WeekendOverTime, DbType.Decimal);
                dal.CreateParameter("@WeekendOverTimeHours", attendance.WeekendOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@SaturdayOverTime", attendance.SaturdayOverTime, DbType.Decimal);
                dal.CreateParameter("@SaturdayOverTimeHours", attendance.SaturdayOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@SundayOverTime", attendance.SundayOverTime, DbType.Decimal);
                dal.CreateParameter("@SundayOverTimeHours", attendance.SundayOverTimeHours, DbType.Decimal);

                dal.CreateParameter("@NightOverTime", attendance.NightOverTime, DbType.Decimal);
                dal.CreateParameter("@NightOverTimeHours", attendance.NightOverTimeHours, DbType.Decimal);
                dal.CreateParameter("@AnnualLeaveBalance", attendance.AnnualLeaveBalance, DbType.Decimal);
                dal.CreateParameter("@AnnualLeaveBalanceMonthly", attendance.AnnualLeaveBalanceMonthly, DbType.Decimal);
                dal.CreateParameter("@AnnualLeave", attendance.AnnualLeave, DbType.Decimal);
                dal.CreateParameter("@AnnualLeaveMonthly", attendance.AnnualLeaveMonthly, DbType.Decimal);
                dal.CreateParameter("@TotalOverTimeTax", attendance.TotalOverTimeTax, DbType.Decimal);

                dal.CreateParameter("@TotalBonus", attendance.TotalBonus, DbType.Decimal);
                dal.CreateParameter("@TotalBonusTax", attendance.TotalBonusTax, DbType.Decimal);
                dal.CreateParameter("@SalaryAdvance", attendance.SalaryAdvance, DbType.Decimal);
                dal.CreateParameter("@WageAdvance", attendance.WageAdvance, DbType.Decimal);
                dal.CreateParameter("@TotalTax", attendance.TotalTax, DbType.Decimal);
                dal.CreateParameter("@Step", attendance.Step, DbType.String);
                dal.CreateParameter("@NonAllowanceTax", attendance.NonAllowanceTax, DbType.Decimal);

                dal.CreateParameter("@AllowanceTax", attendance.AllowanceTax, DbType.Decimal);
                dal.CreateParameter("@Overseer", attendance.Overseer, DbType.String);
                dal.CreateParameter("@UpfrontRelief", attendance.UpfrontRelief, DbType.Decimal);
                dal.CreateParameter("@ExemptFirstTierRate", attendance.ExemptFirstTierRate, DbType.Decimal);
                dal.CreateParameter("@TotalCost", attendance.TotalCost, DbType.Decimal);
                dal.CreateParameter("@TotalPayable", attendance.TotalPayable, DbType.Decimal);

                dal.ExecuteNonQuery("INSERT INTO StaffSalaryPayments(PaymentID,Title,Name,StaffID,StaffCode,DaysOfAttendance,Month,Year,BasicSalary,ActualBasicSalary,SSNITEmployee,SSNITEmployer,ProvidentFundEmployee,ProvidentFundEmployer,SSNITFirstTier,SecondTier,IncomeTax,NetAfterTax,NetSalary,MedicalClaims,Arrears,TakeHome,Loan,InitialLoan,TotalAllowance,TotalDeduction,TotalOverTime,PaymentMode,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Status,GradeLevel,Mechanised, IsProvidentFund, SSNIT,SSNITNo,UserID,UserName,SSNITEmployeeRate,SSNITEmployerRate,SSNITFirstTierRate,SecondTierRate,ProvidentFundEmployeeRate,ProvidentFundEmployerRate,GrossSalary,TaxableIncome,IsExemptFromSecondTier,IsSusuPlusContribution,IsWithholdingTax,IsWithholdingTaxFixedAmount,IsWithholdingTaxRate,SusuPlusContribution,WithholdingAmount,WithholdingFixedTaxAmount,WithholdingTaxCalculateOn,WithholdingTaxRate,Bank,BankBranch,BankAddress,AccountNumber,AccountType,AccountName,GrandTotalAllowance,GrandTotalDeduction,Email,MobileNumber,IsExemptAllowance,IsExemptDeduction,TotalOverTimeHours,PublicHolidayOverTime,PublicHolidayOverTimeHours,DailyOverTime,DailyOverTimeHours,HoursWorked,WeekendOverTime,WeekendOverTimeHours,SaturdayOverTime,SaturdayOverTimeHours,SundayOverTime,SundayOverTimeHours,NightOverTime,NightOverTimeHours,AnnualLeaveBalance,AnnualLeave,TotalOverTimeTax,TotalBonus,TotalBonusTax,SalaryAdvance,WageAdvance,TotalTax,Step,NonAllowanceTax,AllowanceTax,Overseer,UpfrontRelief,AnnualLeaveMonthly,AnnualLeaveBalanceMonthly,ExemptFirstTierRate,TotalCost,TotalPayable) VALUES(@PaymentID,@Title,@Name,@StaffID,@StaffCode,@DaysOfAttendance,@Month,@Year,@BasicSalary,@ActualBasicSalary,@SSNITEmployee,@SSNITEmployer,@ProvidentFundEmployee,@ProvidentFundEmployer,@SSNITFirstTier,@SecondTier,@IncomeTax,@NetAfterTax,@NetSalary,@MedicalClaims,@Arrears,@TakeHome,@Loan,@InitialLoan,@TotalAllowance,@TotalDeduction,@TotalOverTime,@PaymentMode,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Status,@GradeLevel,@Mechanised,@IsProvidentFund,@SSNIT,@SSNITNo,@UserID,@UserName,@SSNITEmployeeRate,@SSNITEmployerRate,@SSNITFirstTierRate,@SecondTierRate,@ProvidentFundEmployeeRate,@ProvidentFundEmployerRate,@GrossSalary,@TaxableIncome,@IsExemptFromSecondTier,@IsSusuPlusContribution,@IsWithholdingTax,@IsWithholdingTaxFixedAmount,@IsWithholdingTaxRate,@SusuPlusContribution,@WithholdingAmount,@WithholdingFixedTaxAmount,@WithholdingTaxCalculateOn,@WithholdingTaxRate,@Bank,@BankBranch,@BankAddress,@AccountNumber,@AccountType,@AccountName,@GrandTotalAllowance,@GrandTotalDeduction,@Email,@MobileNumber,@IsExemptAllowance,@IsExemptDeduction,@TotalOverTimeHours,@PublicHolidayOverTime,@PublicHolidayOverTimeHours,@DailyOverTime,@DailyOverTimeHours,@HoursWorked,@WeekendOverTime,@WeekendOverTimeHours,@SaturdayOverTime,@SaturdayOverTimeHours,@SundayOverTime,@SundayOverTimeHours,@NightOverTime,@NightOverTimeHours,@AnnualLeaveBalance,@AnnualLeave,@TotalOverTimeTax,@TotalBonus,@TotalBonusTax,@SalaryAdvance,@WageAdvance,@TotalTax,@Step,@NonAllowanceTax,@AllowanceTax,@Overseer,@UpfrontRelief,@AnnualLeaveMonthly,@AnnualLeaveBalanceMonthly,@ExemptFirstTierRate,@TotalCost,@TotalPayable)");

                if (attendance.IsExemptAllowance == false)
                {
                    foreach (HRBussinessLayer.Staff_Information_CLASS.StaffAllowance allowance in attendance.Allowances)
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                        dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                        dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                        dal.CreateParameter("@Name", attendance.Name, DbType.String);
                        dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                        dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                        dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                        dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                        dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                        dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                        dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                        dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                        dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                        dal.CreateParameter("@Description", allowance.Type.Description, DbType.String);
                        dal.CreateParameter("@Type", allowance.Type.AllowanceSubCategory.Description, DbType.String);
                        dal.CreateParameter("@Frequency", allowance.Frequency, DbType.String);
                        dal.CreateParameter("@EffectiveDate", allowance.EffectiveDate, DbType.DateTime);
                        dal.CreateParameter("@IsEndDate", allowance.IsEndDate, DbType.Boolean);
                        if(allowance.IsEndDate == true && allowance.EndDate != null)
                        {
                            dal.CreateParameter("@EndDate", allowance.EndDate, DbType.Date);
                        }
                        else
                        {
                            dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                        }
                        
                        dal.CreateParameter("@Amount", allowance.Amount, DbType.Decimal);

                        dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsAllowancesAndDeductions(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,Description,Type,Frequency,EffectiveDate,IsEndDate,EndDate,Amount) VALUES(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@Description,@Type,@Frequency,@EffectiveDate,@IsEndDate,@EndDate,@Amount)");
                    }
                }

                foreach (HRBussinessLayer.PayRoll_Processing_CLASS.OverTime overTime in attendance.OverTimes)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Name", attendance.Name, DbType.String);
                    dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                    dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                    dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                    dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                    dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                    dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                    dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                    dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                    dal.CreateParameter("@Description", overTime.OverTimeType.Description, DbType.String);
                    dal.CreateParameter("@Type", "OverTime", DbType.String);
                    dal.CreateParameter("@OverTimeHours", overTime.HrsWorked, DbType.Decimal);
                    dal.CreateParameter("@OverTimeRate", overTime.OverTimeRate, DbType.Decimal);
                    dal.CreateParameter("@TotalShifts", overTime.TotalShifts, DbType.Int32);
                    if (overTime.Holiday != null)
                    {
                        dal.CreateParameter("@Holiday", overTime.Holiday.Value.Date, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@Holiday", DBNull.Value, DbType.Date);
                    }
                    
                    dal.CreateParameter("@EffectiveDate", overTime.Date, DbType.DateTime);
                    dal.CreateParameter("@Amount", overTime.Amount, DbType.Decimal);

                    dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsAllowancesAndDeductions(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,Description,Type,Holiday,EffectiveDate,Amount,OverTimeHours,OverTimeRate,TotalShifts) VALUES(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@Description,@Type,@Holiday,@EffectiveDate,@Amount,@OverTimeHours,@OverTimeRate,@TotalShifts)");
                }

                if (attendance.IsExemptDeduction == false)
                {
                    foreach (HRBussinessLayer.Staff_Information_CLASS.StaffDeduction deduction in attendance.Deductions)
                    {
                        dal.ClearParameters();
                        dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                        dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                        dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                        dal.CreateParameter("@Name", attendance.Name, DbType.String);
                        dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                        dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                        dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                        dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                        dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                        dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                        dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                        dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                        dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                        dal.CreateParameter("@Description", deduction.Type.Description, DbType.String);
                        dal.CreateParameter("@Type", "Deduction", DbType.String);
                        dal.CreateParameter("@Frequency", deduction.Frequency, DbType.String);
                        dal.CreateParameter("@EffectiveDate", deduction.EffectiveDate, DbType.DateTime);
                        dal.CreateParameter("@IsEndDate", deduction.IsEndDate, DbType.Boolean);
                        if (deduction.IsEndDate == true && deduction.EndDate != null)
                        {
                            dal.CreateParameter("@EndDate", deduction.EndDate, DbType.Date);
                        }
                        else
                        {
                            dal.CreateParameter("@EndDate", DBNull.Value, DbType.Date);
                        }
                        dal.CreateParameter("@Amount", deduction.Amount, DbType.Decimal);

                        dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsAllowancesAndDeductions(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,Description,Type,Frequency,EffectiveDate,IsEndDate,EndDate,Amount) VALUES(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@Description,@Type,@Frequency,@EffectiveDate,@IsEndDate,@EndDate,@Amount)");
                    }
                }

                foreach (StaffLoan loan in attendance.Loans)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Name", attendance.Name, DbType.String);
                    dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                    dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                    dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                    dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                    dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                    dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                    dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                    dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                    dal.CreateParameter("@LoanID", loan.ID, DbType.Int32);
                    dal.CreateParameter("@Description", loan.LoanDescription, DbType.String);
                    dal.CreateParameter("@LoanType", loan.Loan.Description, DbType.String);
                    dal.CreateParameter("@Amount", loan.LoanAmount, DbType.Decimal);
                    dal.CreateParameter("@AmountToBePaid", loan.AmountToBePaid, DbType.Decimal);
                    dal.CreateParameter("@MonthlyInstallment", loan.MonthlyInstallment, DbType.Decimal);
                    dal.CreateParameter("@InterestRate", loan.InterestRate, DbType.Decimal);
                    dal.CreateParameter("@Interest", loan.Interest, DbType.Decimal);
                    if (loan.DateFrom == null)
                    {
                        dal.CreateParameter("@DateFrom", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateFrom", loan.DateFrom, DbType.Date);
                    }
                    if (loan.DateTo == null)
                    {
                        dal.CreateParameter("@DateTo", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateTo", loan.DateTo, DbType.Date);
                    }
                    if (loan.DateOfLoan == null)
                    {
                        dal.CreateParameter("@DateOfLoan", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateOfLoan", loan.DateOfLoan, DbType.Date);
                    }
                    
                    dal.CreateParameter("@SpreadOver", loan.SpreadOver, DbType.Int32);
                    dal.CreateParameter("@Count", loan.Count, DbType.Int32);

                    dal.ExecuteNonQuery("Insert Into StaffSalaryPaymentsLoans(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,LoanID,Description,LoanType,Amount,AmountToBePaid,MonthlyInstallment,InterestRate,Interest,DateFrom,DateTo,DateOfLoan,SpreadOver,Count) Values(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@LoanID,@Description,@LoanType,@Amount,@AmountToBePaid,@MonthlyInstallment,@InterestRate,@Interest,@DateFrom,@DateTo,@DateOfLoan,@SpreadOver,@Count)");               
                }
            } 
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                PayRollAttendance attendance = (PayRollAttendance)item;
                dal.ClearParameters();
                dal.CreateParameter("@Title", attendance.Employee.Title.Description, DbType.String);
                dal.CreateParameter("@Name", attendance.Name, DbType.String);
                dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                dal.CreateParameter("@DaysOfAttendance", attendance.Attendance, DbType.String);
                dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                dal.CreateParameter("@BasicSalary", attendance.BasicSalary, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployee", attendance.SSNITEmployee, DbType.Decimal);
                dal.CreateParameter("@SSNITFirstTier", attendance.SSNITFirstTier, DbType.Decimal);
                dal.CreateParameter("@SecondTier", attendance.SecondTier, DbType.Decimal);
                dal.CreateParameter("@IncomeTax", attendance.IncomeTax, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployer", attendance.SSNITEmployer, DbType.Decimal);
                dal.CreateParameter("@PaymentMode", attendance.PaymentMode, DbType.String);
                dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                dal.CreateParameter("@GradeLevel", attendance.Band.Description, DbType.String);
                dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                dal.CreateParameter("@SSNIT", attendance.SSNIT, DbType.Boolean);
                dal.CreateParameter("@SSNITNo", attendance.SsnitNo, DbType.String);
                dal.CreateParameter("@NetAfterTax", attendance.NetAfterTax, DbType.Decimal);
                dal.CreateParameter("@MedicalClaims", attendance.MedicalClaims, DbType.Decimal);
                dal.CreateParameter("@Arrears", attendance.Arrears, DbType.Decimal);
                dal.CreateParameter("@UserID", attendance.User.ID, DbType.Int32);
                dal.CreateParameter("@UserName", attendance.User.Name, DbType.String);
                dal.CreateParameter("@NetSalary", attendance.NetSalary, DbType.Decimal);
                dal.CreateParameter("@TakeHome", attendance.TakeHome, DbType.Decimal);
                dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                dal.CreateParameter("@Status", attendance.Status, DbType.Int32);
                dal.CreateParameter("@TotalAllowance", attendance.TotalAllowance, DbType.Decimal);
                dal.CreateParameter("@TotalDeduction", attendance.TotalDeductions, DbType.Decimal);
                dal.CreateParameter("@GrandTotalAllowance", attendance.GrandTotalAllowance, DbType.Decimal);
                dal.CreateParameter("@GrandTotalDeduction", attendance.GrandTotalDeductions, DbType.Decimal);
                dal.CreateParameter("@InitialLoan", attendance.InitialLoan, DbType.Decimal);
                dal.CreateParameter("@Loan", attendance.TotalLoans, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployeeRate", attendance.SsnitEmployeeRate, DbType.Decimal);
                dal.CreateParameter("@SSNITEmployerRate", attendance.SsnitEmployerRate, DbType.Decimal);
                dal.CreateParameter("@SSNITFirstTierRate", attendance.SSNITFirstTierRate, DbType.Decimal);
                dal.CreateParameter("@SecondTierRate", attendance.SecondTierRate, DbType.Decimal);
                dal.CreateParameter("@GrossSalary", attendance.GrossSalary, DbType.Decimal);
                dal.CreateParameter("@TaxableIncome", attendance.TaxableIncome, DbType.Decimal);

                dal.CreateParameter("@IsSusuPlusContribution", attendance.Employee.IsSusuPlusContribution, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTax", attendance.Employee.IsWithholdingTax, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTaxFixedAmount", attendance.Employee.IsWithholdingTaxFixedAmount, DbType.Boolean);
                dal.CreateParameter("@IsWithholdingTaxRate", attendance.Employee.IsWithholdingTaxRate, DbType.Boolean);

                dal.CreateParameter("@SusuPlusContribution", attendance.SusuPlusContributionAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingAmount", attendance.WithholdingAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingFixedTaxAmount", attendance.WithholdingTaxFixedAmount, DbType.Decimal);
                dal.CreateParameter("@WithholdingTaxCalculateOn", attendance.SalaryType.Description, DbType.String);//SalaryType
                dal.CreateParameter("@WithholdingTaxRate", attendance.WithholdingTaxRate, DbType.Decimal);

                dal.CreateParameter("@Bank", attendance.StaffBank.Bank.Description, DbType.String);
                dal.CreateParameter("@BankBranch", attendance.StaffBank.BankBranch.Description, DbType.String);
                dal.CreateParameter("@BankAddress", attendance.StaffBank.Address, DbType.String);
                dal.CreateParameter("@AccountNumber", attendance.StaffBank.AccountNumber, DbType.String);
                dal.CreateParameter("@AccountType", attendance.StaffBank.AccountType.Description, DbType.String);
                dal.CreateParameter("@AccountName", attendance.StaffBank.AccountName, DbType.String);

                dal.CreateParameter("@Email", attendance.Employee.Email, DbType.String);
                dal.CreateParameter("@MobileNumber", attendance.Employee.MobileNo, DbType.String);

                dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsHistory(PaymentID,Title,Name,StaffID,StaffCode,DaysOfAttendance,Month,Year,BasicSalary,SSNITEmployee,SSNITEmployer,SSNITFirstTier,SecondTier,IncomeTax,NetAfterTax,NetSalary,MedicalClaims,Arrears,TakeHome,Loan,InitialLoan,TotalAllowance,TotalDeduction,PaymentMode,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Status,GradeLevel,Mechanised,SSNIT,SSNITNo,UserID,UserName,SSNITEmployeeRate,SSNITEmployerRate,SSNITFirstTierRate,SecondTierRate,GrossSalary,TaxableIncome,IsSusuPlusContribution,IsWithholdingTax,IsWithholdingTaxFixedAmount,IsWithholdingTaxRate,SusuPlusContribution,WithholdingAmount,WithholdingFixedTaxAmount,WithholdingTaxCalculateOn,WithholdingTaxRate,Bank,BankBranch,BankAddress,AccountNumber,AccountType,AccountName,GrandTotalAllowance,GrandTotalDeduction,Email,MobileNumber) VALUES(@PaymentID,@Title,@Name,@StaffID,@StaffCode,@DaysOfAttendance,@Month,@Year,@BasicSalary,@SSNITEmployee,@SSNITEmployer,@SSNITFirstTier,@SecondTier,@IncomeTax,@NetAfterTax,@NetSalary,@MedicalClaims,@Arrears,@TakeHome,@Loan,@InitialLoan,@TotalAllowance,@TotalDeduction,@PaymentMode,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Status,@GradeLevel,@Mechanised,@SSNIT,@SSNITNo,@UserID,@UserName,@SSNITEmployeeRate,@SSNITEmployerRate,@SSNITFirstTierRate,@SecondTierRate,@GrossSalary,@TaxableIncome,@IsSusuPlusContribution,@IsWithholdingTax,@IsWithholdingTaxFixedAmount,@IsWithholdingTaxRate,@SusuPlusContribution,@WithholdingAmount,@WithholdingFixedTaxAmount,@WithholdingTaxCalculateOn,@WithholdingTaxRate,@Bank,@BankBranch,@BankAddress,@AccountNumber,@AccountType,@AccountName,@GrandTotalAllowance,@GrandTotalDeduction,@Email,@MobileNumber)");

                foreach (HRBussinessLayer.Staff_Information_CLASS.StaffAllowance allowance in attendance.Allowances)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Name", attendance.Name, DbType.String);
                    dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                    dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                    dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                    dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                    dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                    dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                    dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                    dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                    dal.CreateParameter("@Description", allowance.Type.Description, DbType.String);
                    dal.CreateParameter("@Type", "Allowance", DbType.String);
                    dal.CreateParameter("@Frequency", allowance.Frequency, DbType.String);
                    dal.CreateParameter("@EffectiveDate", allowance.EffectiveDate, DbType.DateTime);
                    dal.CreateParameter("@Amount", allowance.Amount, DbType.Decimal);

                    dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsAllowancesAndDeductionsHistory(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,Description,Type,Frequency,EffectiveDate,Amount) VALUES(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@Description,@Type,@Frequency,@EffectiveDate,@Amount)");
                }

                foreach (HRBussinessLayer.Staff_Information_CLASS.StaffDeduction deduction in attendance.Deductions)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Name", attendance.Name, DbType.String);
                    dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                    dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                    dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                    dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                    dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                    dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                    dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                    dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                    dal.CreateParameter("@Description", deduction.Type.Description, DbType.String);
                    dal.CreateParameter("@Type", "Deduction", DbType.String);
                    dal.CreateParameter("@Frequency", deduction.Frequency, DbType.String);
                    dal.CreateParameter("@EffectiveDate", deduction.EffectiveDate, DbType.DateTime);
                    dal.CreateParameter("@Amount", deduction.Amount, DbType.Decimal);

                    dal.ExecuteNonQuery("INSERT INTO StaffSalaryPaymentsAllowancesAndDeductionsHistory(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,Description,Type,Frequency,EffectiveDate,Amount) VALUES(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@Description,@Type,@Frequency,@EffectiveDate,@Amount)");
                }

                foreach (StaffLoan loan in attendance.Loans)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@PaymentID", attendance.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", attendance.Employee.StaffID, DbType.String);
                    dal.CreateParameter("@StaffCode", attendance.Employee.ID, DbType.Int32);
                    dal.CreateParameter("@Name", attendance.Name, DbType.String);
                    dal.CreateParameter("@Department", attendance.Department.Description, DbType.String);
                    dal.CreateParameter("@Unit", attendance.Unit.Description, DbType.String);
                    dal.CreateParameter("@JobTitle", attendance.JobTitle.Description, DbType.String);
                    dal.CreateParameter("@Zone", attendance.Zone.Description, DbType.String);
                    dal.CreateParameter("@GradeCategory", attendance.GradeCategory.Description, DbType.String);
                    dal.CreateParameter("@Grade", attendance.Grade.Grade, DbType.String);
                    dal.CreateParameter("@Mechanised", attendance.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@Month", attendance.Month, DbType.Int32);
                    dal.CreateParameter("@Year", attendance.Year, DbType.Int32);
                    dal.CreateParameter("@LoanID", loan.ID, DbType.Int32);
                    dal.CreateParameter("@Description", loan.LoanDescription, DbType.String);
                    dal.CreateParameter("@LoanType", loan.Loan.Description, DbType.String);
                    dal.CreateParameter("@Amount", loan.LoanAmount, DbType.Decimal);
                    dal.CreateParameter("@AmountToBePaid", loan.AmountToBePaid, DbType.Decimal);
                    dal.CreateParameter("@MonthlyInstallment", loan.MonthlyInstallment, DbType.Decimal);
                    dal.CreateParameter("@InterestRate", loan.InterestRate, DbType.Decimal);
                    dal.CreateParameter("@Interest", loan.Interest, DbType.Decimal);
                    if (loan.DateFrom == null)
                    {
                        dal.CreateParameter("@DateFrom", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateFrom", loan.DateFrom, DbType.Date);
                    }
                    if (loan.DateTo == null)
                    {
                        dal.CreateParameter("@DateTo", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateTo", loan.DateTo, DbType.Date);
                    }
                    if (loan.DateOfLoan == null)
                    {
                        dal.CreateParameter("@DateOfLoan", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dal.CreateParameter("@DateOfLoan", loan.DateOfLoan, DbType.Date);
                    }

                    dal.CreateParameter("@SpreadOver", loan.SpreadOver, DbType.Int32);
                    dal.CreateParameter("@Count", loan.Count, DbType.Int32);

                    dal.ExecuteNonQuery("Insert Into StaffSalaryPaymentsLoansHistory(PaymentID,StaffID,StaffCode,Name,Department,Unit,Zone,JobTitle,GradeCategory,Grade,Mechanised,Month,Year,LoanID,Description,LoanType,Amount,AmountToBePaid,MonthlyInstallment,InterestRate,Interest,DateFrom,DateTo,DateOfLoan,SpreadOver,Count) Values(@PaymentID,@StaffID,@StaffCode,@Name,@Department,@Unit,@Zone,@JobTitle,@GradeCategory,@Grade,@Mechanised,@Month,@Year,@LoanID,@Description,@LoanType,@Amount,@AmountToBePaid,@MonthlyInstallment,@InterestRate,@Interest,@DateFrom,@DateTo,@DateOfLoan,@SpreadOver,@Count)");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GetAll
        public IList<PayRollAttendance> GetAll()
        {
            IList<PayRollAttendance> attendances = new List<PayRollAttendance>();
            try
            {
                string query = "Select StaffSalaryPaymentView.* from StaffSalaryPaymentView ";
                DataTable table = dal.ExecuteReader(query);
                foreach (PayRollAttendance pa in BuildPayRollAttendanceFromData(table))
                {
                    attendances.Add(pa);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attendances;
        }
        #endregion

        #region GetByCriteria
        public IList<PayRollAttendance> GetByCriteria(Query query1)
        {
            IList<PayRollAttendance> attendances = new List<PayRollAttendance>();           
            try
            {
                string query = "Select StaffSalaryPaymentView.* from StaffSalaryPaymentView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " Order By StaffSalaryPaymentView.StaffID,StaffSalaryPaymentView.Name";
                DataTable table = dal.ExecuteReader(selectStatement);
                foreach (PayRollAttendance pa in BuildPayRollAttendanceFromData(table))
                {
                    attendances.Add(pa);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return attendances;
        }
        #endregion

        #region BuildPayRollAttendanceFromData
        private IList<PayRollAttendance> BuildPayRollAttendanceFromData(DataTable table)
        {
            IList<PayRollAttendance> attendances = new List<PayRollAttendance>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    PayRollAttendance attendance = new PayRollAttendance()
                    {
                        Employee = new Employee()
                        {
                            ID = int.Parse(row["StaffCode"].ToString()),
                            StaffID = row["StaffID"] == DBNull.Value ? string.Empty : row["StaffID"].ToString(),
                            Title = new Titles() 
                            { 
                                Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString() 
                            },

                            IsSusuPlusContribution = row["IsSusuPlusContribution"] == DBNull.Value ? false : bool.Parse(row["IsSusuPlusContribution"].ToString()),
                            IsWithholdingTax = row["IsWithholdingTax"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTax"].ToString()),
                            IsWithholdingTaxFixedAmount = row["IsWithholdingTaxFixedAmount"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxFixedAmount"].ToString()),
                            IsWithholdingTaxRate = row["IsWithholdingTaxRate"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxRate"].ToString()),
                            IsExemptFromSecondTier = row["IsExemptFromSecondTier"] == DBNull.Value ? false : bool.Parse(row["IsExemptFromSecondTier"].ToString()),
                            Email = row["Email"] == DBNull.Value ? string.Empty : row["Email"].ToString(),
                            MobileNo = row["MobileNumber"] == DBNull.Value ? string.Empty : row["MobileNumber"].ToString(),

                        },
                        PaymentID = row["PaymentID"] == DBNull.Value ? 0 : int.Parse(row["PaymentID"].ToString()),
                        ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString()),
                        Name = row["Name"] == DBNull.Value ? string.Empty : row["Name"].ToString(),

                        Attendance = row["DaysOfAttendance"] == DBNull.Value ? string.Empty : row["DaysOfAttendance"].ToString(),
                        Department = new Department() 
                        { 
                            Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() 
                        },
                        Unit = new Unit() 
                        { 
                            Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() 
                        },
                        Zone = new Zone()
                        {
                            Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString()
                        },
                        JobTitle = new JobTitle()
                        {
                            Description = row["JobTitle"] == DBNull.Value ? string.Empty : row["JobTitle"].ToString()
                        },
                        GradeCategory = new GradeCategory()
                        {
                            Description = row["GradeCategory"] == DBNull.Value ? string.Empty : row["GradeCategory"].ToString()
                        },
                        Grade = new EmployeeGrade() 
                        { 
                            Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() 
                        },
                        Band = new Band() 
                        {
                            Description = row["GradeLevel"] == DBNull.Value ? string.Empty : row["GradeLevel"].ToString() 
                        },
                        Mechanised = row["Mechanised"] == DBNull.Value ? false : bool.Parse(row["Mechanised"].ToString()),
                        
                        GrossSalary = row["GrossSalary"] == DBNull.Value ? 0 : decimal.Parse(row["GrossSalary"].ToString()),
                        TaxableIncome = row["TaxableIncome"] == DBNull.Value ? 0 : decimal.Parse(row["TaxableIncome"].ToString()),
                        TakeHome = row["TakeHome"] == DBNull.Value ? 0 : decimal.Parse(row["TakeHome"].ToString()),
                        GrandTotalDeductions = row["GrandTotalDeduction"] == DBNull.Value ? 0 : decimal.Parse(row["GrandTotalDeduction"].ToString()),
                        GrandTotalAllowance = row["GrandTotalAllowance"] == DBNull.Value ? 0 : decimal.Parse(row["GrandTotalAllowance"].ToString()),
                        TotalAllowance = row["TotalAllowance"] == DBNull.Value ? 0 : decimal.Parse(row["TotalAllowance"].ToString()),
                        TotalOverTime = row["TotalOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["TotalOverTime"].ToString()),
                        TotalDeductions = row["TotalDeduction"] == DBNull.Value ? 0 : decimal.Parse(row["TotalDeduction"].ToString()),
                        TotalLoans = row["Loan"] == DBNull.Value ? 0 : decimal.Parse(row["Loan"].ToString()),
                        InitialLoan = row["InitialLoan"] == DBNull.Value ? 0 : decimal.Parse(row["InitialLoan"].ToString()),
                        BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString()),
                        ActualBasicSalary = row["ActualBasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["ActualBasicSalary"].ToString()),

                        PublicHolidayOverTime = row["PublicHolidayOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["PublicHolidayOverTime"].ToString()),
                        PublicHolidayOverTimeHours = row["PublicHolidayOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["PublicHolidayOverTimeHours"].ToString()),
                        DailyOverTime = row["DailyOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["DailyOverTime"].ToString()),
                        DailyOverTimeHours = row["DailyOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["DailyOverTimeHours"].ToString()),

                        SaturdayOverTime = row["SaturdayOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["SaturdayOverTime"].ToString()),
                        SaturdayOverTimeHours = row["SaturdayOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["SaturdayOverTimeHours"].ToString()),
                        SundayOverTime = row["SundayOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["SundayOverTime"].ToString()),
                        SundayOverTimeHours = row["SundayOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["SundayOverTimeHours"].ToString()),


                        TotalBonus = row["TotalBonus"] == DBNull.Value ? 0 : decimal.Parse(row["TotalBonus"].ToString()),
                        TotalBonusTax = row["TotalBonusTax"] == DBNull.Value ? 0 : decimal.Parse(row["TotalBonusTax"].ToString()),
                        TotalOverTimeHours = row["TotalOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["TotalOverTimeHours"].ToString()),
                        TotalOverTimeTax = row["TotalOverTimeTax"] == DBNull.Value ? 0 : decimal.Parse(row["TotalOverTimeTax"].ToString()),
                        TotalTax = row["TotalTax"] == DBNull.Value ? 0 : decimal.Parse(row["TotalTax"].ToString()),

                        AllowanceTax = row["AllowanceTax"] == DBNull.Value ? 0 : decimal.Parse(row["AllowanceTax"].ToString()),
                        AnnualLeave = row["AnnualLeave"] == DBNull.Value ? 0 : decimal.Parse(row["AnnualLeave"].ToString()),
                        AnnualLeaveBalance = row["AnnualLeaveBalance"] == DBNull.Value ? 0 : decimal.Parse(row["AnnualLeaveBalance"].ToString()),

                        Overseer = row["Overseer"] == DBNull.Value ? string.Empty : row["Overseer"].ToString(),
                        NightOverTime = row["NightOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["NightOverTime"].ToString()),
                        NightOverTimeHours = row["NightOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["NightOverTimeHours"].ToString()),
                        NonAllowanceTax = row["NonAllowanceTax"] == DBNull.Value ? 0 : decimal.Parse(row["NonAllowanceTax"].ToString()),

                        SalaryAdvance = row["SalaryAdvance"] == DBNull.Value ? 0 : decimal.Parse(row["SalaryAdvance"].ToString()),
                        Step = row["Step"] == DBNull.Value ? string.Empty : row["Step"].ToString(),

                        HoursWorked = row["HoursWorked"] == DBNull.Value ? 0 : decimal.Parse(row["HoursWorked"].ToString()),
                        UpfrontRelief = row["UpfrontRelief"] == DBNull.Value ? 0 : decimal.Parse(row["UpfrontRelief"].ToString()),

                        WageAdvance = row["WageAdvance"] == DBNull.Value ? 0 : decimal.Parse(row["WageAdvance"].ToString()),
                        WeekendOverTime = row["WeekendOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["WeekendOverTime"].ToString()),
                        WeekendOverTimeHours = row["WeekendOverTimeHours"] == DBNull.Value ? 0 : decimal.Parse(row["WeekendOverTimeHours"].ToString()),

                        TotalCost = row["TotalCost"] == DBNull.Value ? 0 : decimal.Parse(row["TotalCost"].ToString()),
                        TotalPayable = row["TotalPayable"] == DBNull.Value ? 0 : decimal.Parse(row["TotalPayable"].ToString()),
                        ExemptFirstTierRate = row["ExemptFirstTierRate"] == DBNull.Value ? 0 : decimal.Parse(row["ExemptFirstTierRate"].ToString()),
                        AnnualLeaveBalanceMonthly = row["AnnualLeaveBalanceMonthly"] == DBNull.Value ? 0 : decimal.Parse(row["AnnualLeaveBalanceMonthly"].ToString()),
                        AnnualLeaveMonthly = row["AnnualLeaveMonthly"] == DBNull.Value ? 0 : decimal.Parse(row["AnnualLeaveMonthly"].ToString()),
                       
                        IncomeTax = row["IncomeTax"] == DBNull.Value ? 0 : decimal.Parse(row["IncomeTax"].ToString()),
                        NetAfterTax = row["NetAfterTax"] == DBNull.Value ? 0 : decimal.Parse(row["NetAfterTax"].ToString()),
                        NetSalary = row["NetSalary"] == DBNull.Value ? 0 : decimal.Parse(row["NetSalary"].ToString()),
                        WithholdingTaxRate = row["WithholdingTaxRate"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingTaxRate"].ToString()),
                        WithholdingAmount = row["WithholdingAmount"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingAmount"].ToString()),
                        WithholdingTaxFixedAmount = row["WithholdingFixedTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingFixedTaxAmount"].ToString()),
                        SSNITEmployee = row["SSNITEmployee"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITEmployee"].ToString()),
                        SSNITFirstTier = row["SSNITFirstTier"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITFirstTier"].ToString()),
                        SecondTier = row["SecondTier"] == DBNull.Value ? 0 : decimal.Parse(row["SecondTier"].ToString()),
                        SsnitEmployeeRate = row["SSNITEmployeeRate"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITEmployeeRate"].ToString()),
                        SSNITEmployer = row["SSNITEmployer"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITEmployer"].ToString()),
                        SsnitEmployerRate = row["SSNITEmployerRate"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITEmployerRate"].ToString()),
                        SSNITFirstTierRate = row["SSNITFirstTierRate"] == DBNull.Value ? 0 : decimal.Parse(row["SSNITFirstTierRate"].ToString()),
                        SecondTierRate = row["SecondTierRate"] == DBNull.Value ? 0 : decimal.Parse(row["SecondTierRate"].ToString()),
                        ProvidentFundEmployee = row["ProvidentFundEmployee"] == DBNull.Value ? 0 : decimal.Parse(row["ProvidentFundEmployee"].ToString()),
                        ProvidentFundEmployer = row["ProvidentFundEmployer"] == DBNull.Value ? 0 : decimal.Parse(row["ProvidentFundEmployer"].ToString()),
                        ProvidentFundEmployeeRate = row["ProvidentFundEmployeeRate"] == DBNull.Value ? 0 : decimal.Parse(row["ProvidentFundEmployeeRate"].ToString()),
                        ProvidentFundEmployerRate = row["ProvidentFundEmployerRate"] == DBNull.Value ? 0 : decimal.Parse(row["ProvidentFundEmployerRate"].ToString()),
                        MedicalClaims = row["MedicalClaims"] == DBNull.Value ? 0 : decimal.Parse(row["MedicalClaims"].ToString()),
                        Arrears = row["Arrears"] == DBNull.Value ? 0 : decimal.Parse(row["Arrears"].ToString()),
                        IsProvidentFund = row["IsProvidentFund"] == DBNull.Value ? false : bool.Parse(row["IsProvidentFund"].ToString()),
                        IsExemptAllowance = row["IsExemptAllowance"] == DBNull.Value ? false : bool.Parse(row["IsExemptAllowance"].ToString()),
                        IsExemptDeduction = row["IsExemptDeduction"] == DBNull.Value ? false : bool.Parse(row["IsExemptDeduction"].ToString()),
                        SSNIT = row["SSNIT"] == DBNull.Value ? false : bool.Parse(row["SSNIT"].ToString()),
                        SsnitNo = row["SSNITNo"] == DBNull.Value ? string.Empty : row["SSNITNo"].ToString(),
                        SusuPlusContributionAmount = row["SusuPlusContribution"] == DBNull.Value ? 0 : decimal.Parse(row["SusuPlusContribution"].ToString()),
                        StaffBank = new StaffBank()
                        {
                            AccountName = row["AccountName"] == DBNull.Value ? string.Empty : row["AccountName"].ToString(),
                            AccountNumber = row["AccountNumber"] == DBNull.Value ? string.Empty : row["AccountNumber"].ToString(),
                            Address = row["BankAddress"] == DBNull.Value ? string.Empty : row["BankAddress"].ToString(),
                            AccountType = new AccountType()
                            {
                                Description = row["AccountType"] == DBNull.Value ? string.Empty : row["AccountType"].ToString()
                            },
                            Bank = new Bank()
                            {
                                Description = row["Bank"] == DBNull.Value ? string.Empty : row["Bank"].ToString()
                            },
                            BankBranch = new BankBranch()
                            {
                                Description = row["BankBranch"] == DBNull.Value ? string.Empty : row["BankBranch"].ToString()
                            }
                        },
                        SalaryType = new SalaryType()
                        {
                            Description = row["WithholdingTaxCalculateOn"] == DBNull.Value ? string.Empty : row["WithholdingTaxCalculateOn"].ToString()
                        },
                        User = new User()
                        {
                            ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                            UserName = row["UserName"] == DBNull.Value ? string.Empty : row["UserName"].ToString()
                        },
                        Status = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString(),
                        Month = row["Month"] == DBNull.Value ? 0 : int.Parse(row["Month"].ToString()),
                        PaymentMode = row["PaymentMode"] == DBNull.Value ? string.Empty : row["PaymentMode"].ToString(),
                        Year = row["Year"] == DBNull.Value ? 0 : int.Parse(row["Year"].ToString())
                    };
                    attendances.Add(attendance);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return attendances;
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            PayRollAttendance payRollAttendance = (PayRollAttendance)item;
            try
            {
                dal.BeginTransaction();
                dal.ClearParameters();

                //Get paymentID for specified period
                object obj = dal.ExecuteScalar("Select Max(PaymentID) from StaffSalaryPayments Where Month='"+ payRollAttendance.Month + "' And Year='"+ payRollAttendance.Year +"' And Status <> 2");
                if (obj != null && obj.ToString() != string.Empty)
                {
                    payRollAttendance.ID = int.Parse(obj.ToString());

                    //Remove information about allowances and deductions
                    dal.ExecuteNonQuery("Delete From StaffSalaryPaymentsAllowancesAndDeductions Where PaymentID=" + payRollAttendance.ID);

                    //Remove information about loanpayments
                    dal.ExecuteNonQuery("Delete From StaffSalaryPaymentsLoans Where PaymentID=" + payRollAttendance.ID);

                    //Finally Delete Salary information
                    dal.ExecuteNonQuery("Delete From StaffSalaryPayments Where PaymentID = " + payRollAttendance.ID);
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                throw ex;
            }

        }
        #endregion
    }
}
