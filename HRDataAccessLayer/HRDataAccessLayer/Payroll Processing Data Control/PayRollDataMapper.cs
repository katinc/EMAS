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
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using System.Configuration;
using HRBussinessLayer.ErrorLogging;

namespace HRDataAccessLayer.Payroll_Processing_Data_Control
{
    public class PayRollDataMapper
    {
        DALHelper dal;

        public PayRollDataMapper()
        {
            dal = new DALHelper();
        }

        #region Save
        public void Save(object item)
        {
            PayRoll payRoll = (PayRoll)item;
            try
            {
                dal.ExecuteNonQuery("delete from PayRollSummary where Month='"+ payRoll.Month +"' and Year='"+ payRoll.Year +"'");
                //foreach (PayRollItem paySlip in payRoll.PaySlips)
                //{
                //    dal.ClearParameters();
                //    dal.CreateParameter("@Month", payRoll.Month, DbType.String);
                //    dal.CreateParameter("@Year", payRoll.Year, DbType.String);
                //    dal.CreateParameter("@ColumnHeader", paySlip.ColumnHeader , DbType.String);
                //    dal.CreateParameter("@StaffID", paySlip.StaffID , DbType.String);
                //    dal.CreateParameter("@Name", paySlip.Name , DbType.String);
                //    dal.CreateParameter("@ColumnValue", paySlip.ColumnValue , DbType.Decimal);
                //    dal.CreateParameter("@Department", paySlip.Department , DbType.String);
                //    dal.CreateParameter("@Type", paySlip.Type, DbType.String);
                //    dal.CreateParameter("@Mechanised", paySlip.Mechanised, DbType.Boolean);
                //    dal.CreateParameter("@ColumnPosition", paySlip.ColumnPosition, DbType.Int32);
                //    dal.CreateParameter("@GradeCategory", paySlip.GradeCategory, DbType.String);
                //    dal.CreateParameter("@Grade", paySlip.Grade, DbType.String);
                //    dal.CreateParameter("@Unit", paySlip.Unit, DbType.String);
                //    dal.CreateParameter("@Overseer", paySlip.Overseer, DbType.String);
                //    dal.CreateParameter("@Status", payRoll.Status, DbType.String);
                //    dal.ExecuteNonQuery("Insert Into PayRollSummary(ColumnHeader,StaffID,Name,ColumnValue,Department,Type,Month,Year,ColumnPosition,Mechanised,GradeCategory,Grade,Unit,Overseer,Status) Values(@ColumnHeader,@StaffID,@Name,@ColumnValue,@Department,@Type,@Month,@Year,@ColumnPosition,@Mechanised,@GradeCategory,@Grade,@Unit,@Overseer,@Status)");
                //}

                DataTable dt = FillDatatoGrid(payRoll);
                //String password;
                //password = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings["dbPassword"]));
                using (SqlConnection cn = new SqlConnection(dal.ConnectionString()))
                {
                    cn.Open();
                    using (SqlBulkCopy copy = new SqlBulkCopy(cn))
                    {
                        copy.ColumnMappings.Add("ID", "ID");
                        copy.ColumnMappings.Add("Month", "Month");
                        copy.ColumnMappings.Add("Year", "Year");
                        copy.ColumnMappings.Add("ColumnHeader", "ColumnHeader");
                        copy.ColumnMappings.Add("StaffID", "StaffID");
                        copy.ColumnMappings.Add("Name", "Name");
                        copy.ColumnMappings.Add("ColumnValue", "ColumnValue");
                        copy.ColumnMappings.Add("Department", "Department");
                        copy.ColumnMappings.Add("Type", "Type");
                        copy.ColumnMappings.Add("Mechanised", "Mechanised");
                        copy.ColumnMappings.Add("ColumnPosition", "ColumnPosition");

                        copy.ColumnMappings.Add("GradeCategory", "GradeCategory");
                        copy.ColumnMappings.Add("Grade", "Grade");
                        copy.ColumnMappings.Add("Unit", "Unit");
                        copy.ColumnMappings.Add("Overseer", "Overseer");
                        copy.ColumnMappings.Add("Status", "Status");
                        copy.ColumnMappings.Add("Zone", "Zone");
                        copy.ColumnMappings.Add("JobTitle", "JobTitle");
                        copy.ColumnMappings.Add("SSNITNumber", "SSNITNumber");
                        copy.ColumnMappings.Add("Bank", "Bank");
                        copy.ColumnMappings.Add("AccountNumber", "AccountNumber");
                        copy.ColumnMappings.Add("HoursWorked", "HoursWorked");
                        copy.ColumnMappings.Add("AccountType", "AccountType");

                        copy.DestinationTableName = "PayRollSummary";
                        copy.WriteToServer(dt);
                    }
                }

                
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
            PayRoll payRoll = (PayRoll)item;
            try
            {
                dal.ExecuteNonQuery("delete from PayRollSummary where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "'");
                foreach (PayRollItem paySlip in payRoll.PaySlips)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@Month", payRoll.Month, DbType.String);
                    dal.CreateParameter("@Year", payRoll.Year, DbType.String);
                    dal.CreateParameter("@ColumnHeader", paySlip.ColumnHeader, DbType.String);
                    dal.CreateParameter("@StaffID", paySlip.StaffID, DbType.String);
                    dal.CreateParameter("@Name", paySlip.Name, DbType.String);
                    dal.CreateParameter("@ColumnValue", paySlip.ColumnValue, DbType.Decimal);
                    dal.CreateParameter("@Department", paySlip.Department, DbType.String);
                    dal.CreateParameter("@Type", paySlip.Type, DbType.String);
                    dal.CreateParameter("@Mechanised", paySlip.Mechanised, DbType.Boolean);
                    dal.CreateParameter("@ColumnPosition", paySlip.ColumnPosition, DbType.Int32);
                    dal.CreateParameter("@GradeCategory", paySlip.GradeCategory, DbType.String);
                    dal.CreateParameter("@Grade", paySlip.Grade, DbType.String);
                    dal.CreateParameter("@Unit", paySlip.Unit, DbType.String);
                    dal.CreateParameter("@Overseer", paySlip.Overseer, DbType.String);
                    dal.CreateParameter("@Status", payRoll.Status, DbType.String);
                    dal.ExecuteNonQuery("Update PayRollSummary set ColumnHeader=@ColumnHeader,StaffID=@StaffID,Name=@Name,ColumnValue=@ColumnValue,Department=@Department,Type=@Type,Month=@Month,Year=@Year,ColumnPosition=@ColumnPosition,Mechanised=@Mechanised,GradeCategory=@GradeCategory,Grade=@Grade,Unit=@Unit,Overseer=@Overseer,Status=@Status");
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetByID
        public PayRoll GetByID(object key)
        {
            PayRoll payRoll = (PayRoll)key;
            try
            {
                DataTable table = dal.ExecuteReader("Select * from StaffSalaryPaymentView Where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "'");

                foreach (DataRow row in table.Rows)
                {
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Basic Salary",
                        ColumnValue = decimal.Parse(row["BasicSalary"].ToString()),
                        Type = "Basic Salary",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = 1
                    });

                    //Add Allowances
                    int ctr = 2;
                    foreach (DataRow allowance in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='Allowance' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        payRoll.PaySlips.Add(new PayRollItem()
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            ColumnHeader = allowance["Description"].ToString(),
                            ColumnValue = decimal.Parse(allowance["Amount"].ToString()),
                            Type = "Allowance",
                            Department = row["Department"].ToString(),
                            Name = row["Name"].ToString(),
                            StaffID = row["StaffID"].ToString(),
                            Mechanised = bool.Parse(row["Mechanised"].ToString()),
                            GradeCategory = row["GradeCategory"].ToString(),
                            Grade = row["Grade"].ToString(),
                            Unit = row["Unit"].ToString(),
                            Overseer = row["Overseer"].ToString(),
                            Status = row["Status"].ToString(),
                            Zone = row["Zone"].ToString(),
                            JobTitle = row["JobTitle"].ToString(),
                            SSNITNumber = row["SSNITNumber"].ToString(),
                            Bank = row["Bank"].ToString(),
                            AccountNumber = row["AccountNumber"].ToString(),
                            ColumnPosition = ctr
                        });
                        ctr++;
                    }
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Medical Claims",
                        ColumnValue = decimal.Parse(row["MedicalClaims"].ToString()),
                        Type = "Allowance",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Total Other Allowances",
                        ColumnValue = decimal.Parse(row["TotalAllowance"].ToString()),
                        Type = "Total Other Allowances",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Total Allowance",
                        ColumnValue = decimal.Parse(row["GrandTotalAllowance"].ToString()),
                        Type = "Total Allowance",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Gross Income",
                        ColumnValue = decimal.Parse(row["GrossSalary"].ToString()),
                        Type = "Gross Income",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "SSF EE",
                        ColumnValue = decimal.Parse(row["SSNITEmployee"].ToString()),
                        Type = "SSNIT",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;

                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Taxable Income",
                        ColumnValue = decimal.Parse(row["TaxableIncome"].ToString()),
                        Type = "Tax",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Income Tax",
                        ColumnValue = decimal.Parse(row["IncomeTax"].ToString()),
                        Type = "Tax",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "NAT",
                        ColumnValue = decimal.Parse(row["NetAfterTax"].ToString()),
                        Type = "NAT",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    //Add Deductions
                    foreach (DataRow deduction in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='Deduction' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        payRoll.PaySlips.Add(new PayRollItem()
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            ColumnHeader = deduction["Description"].ToString(),
                            ColumnValue = decimal.Parse(deduction["Amount"].ToString()),
                            Type = "Deduction",
                            Department = row["Department"].ToString(),
                            Name = row["Name"].ToString(),
                            StaffID = row["StaffID"].ToString(),
                            Mechanised = bool.Parse(row["Mechanised"].ToString()),
                            GradeCategory = row["GradeCategory"].ToString(),
                            Grade = row["Grade"].ToString(),
                            Unit = row["Unit"].ToString(),
                            Overseer = row["Overseer"].ToString(),
                            Status = row["Status"].ToString(),
                            Zone = row["Zone"].ToString(),
                            JobTitle = row["JobTitle"].ToString(),
                            SSNITNumber = row["SSNITNumber"].ToString(),
                            Bank = row["Bank"].ToString(),
                            AccountNumber = row["AccountNumber"].ToString(),
                            ColumnPosition = ctr
                        });
                        ctr++;
                    }
                    //Add OverTime
                    foreach (DataRow OverTime in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='OverTime' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        payRoll.PaySlips.Add(new PayRollItem()
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            ColumnHeader = OverTime["Description"].ToString(),
                            ColumnValue = decimal.Parse(OverTime["Amount"].ToString()),
                            Type = "OverTime",
                            Department = row["Department"].ToString(),
                            Name = row["Name"].ToString(),
                            StaffID = row["StaffID"].ToString(),
                            Mechanised = bool.Parse(row["Mechanised"].ToString()),
                            GradeCategory = row["GradeCategory"].ToString(),
                            Grade = row["Grade"].ToString(),
                            Unit = row["Unit"].ToString(),
                            Overseer = row["Overseer"].ToString(),
                            Status = row["Status"].ToString(),
                            Zone = row["Zone"].ToString(),
                            JobTitle = row["JobTitle"].ToString(),
                            SSNITNumber = row["SSNITNumber"].ToString(),
                            Bank = row["Bank"].ToString(),
                            AccountNumber = row["AccountNumber"].ToString(),
                            ColumnPosition = ctr
                        });
                        ctr++;
                    }

                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Withholding Tax",
                        ColumnValue = decimal.Parse(row["WithholdingAmount"].ToString()),
                        Type = "Deduction",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Susu Plus",
                        ColumnValue = decimal.Parse(row["SusuPlusContribution"].ToString()),
                        Type = "Deduction",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    //Add Loans
                    foreach (DataRow loan in dal.ExecuteReader("Select LoanType,Description,Amount,MonthlyInstallment From StaffSalaryPaymentsLoanView Where PaymentID=" + payRoll.ID + " and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        payRoll.PaySlips.Add(new PayRollItem()
                        {
                            ID = int.Parse(row["ID"].ToString()),
                            ColumnHeader = loan["LoanType"].ToString(),
                            ColumnValue = decimal.Parse(loan["MonthlyInstallment"].ToString()),
                            Type = "Deduction",
                            Department = row["Department"].ToString(),
                            Name = row["Name"].ToString(),
                            StaffID = row["StaffID"].ToString(),
                            Mechanised = bool.Parse(row["Mechanised"].ToString()),
                            GradeCategory = row["GradeCategory"].ToString(),
                            Grade = row["Grade"].ToString(),
                            Unit = row["Unit"].ToString(),
                            Overseer = row["Overseer"].ToString(),
                            Status = row["Status"].ToString(),
                            Zone = row["Zone"].ToString(),
                            JobTitle = row["JobTitle"].ToString(),
                            SSNITNumber = row["SSNITNumber"].ToString(),
                            Bank = row["Bank"].ToString(),
                            AccountNumber = row["AccountNumber"].ToString(),
                            ColumnPosition = ctr
                        });
                        ctr++;
                    }
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Loans",
                        ColumnValue = decimal.Parse(row["Loan"].ToString()),
                        Type = "Total Loans",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Total Other Deductions",
                        ColumnValue = decimal.Parse(row["TotalDeduction"].ToString()),
                        Type = "Total Other Deductions",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Total Deduction",
                        ColumnValue = decimal.Parse(row["GrandTotalDeduction"].ToString()),
                        Type = "Total Deduction",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "Net Salary",
                        ColumnValue = decimal.Parse(row["TakeHome"].ToString()),
                        Type = "Net Salary",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = "SSF ER",
                        ColumnValue = decimal.Parse(row["SSNITEmployer"].ToString()),
                        Type = "SSNIT",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return payRoll;
        }
        #endregion

        #region GetByCriteria
        public IList<PayRoll> GetByCriteria(Query query)
        {
            IList<PayRoll> payRolls = new List<PayRoll>();
            try
            {
                DataTable table = new DataTable();
                string queryString = "Select * from StaffSalaryPaymentView ";
                string selectStatement = QueryTranslater.TranslateQuery(queryString, query);
                table = dal.ExecuteReader(selectStatement);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return payRolls;
        }
        #endregion

        //#region GetByID
        //public PayRoll GetByID(object key)
        //{
        //    PayRoll payRoll = (PayRoll)key;
        //    try
        //    {
        //        DataTable table = new DataTable();
        //        string queryString = "Select * from StaffSalaryPaymentView Where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "' ";
        //        table = dal.ExecuteReader(queryString);
        //        foreach (PayRoll pa in BuildPayRollFromData(table))
        //        {
        //            payRoll=pa;
        //        } 
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return payRoll;
        //}
        //#endregion


        private DataTable FillDatatoGrid(object item)
        {
            PayRoll payRoll = (PayRoll)item;
            DataTable dt = new DataTable("PayRollSummary");
            try
            {
                //Adding columns to table Emp
                DataColumn ID = new DataColumn("ID", typeof(System.Int32));
                DataColumn Month = new DataColumn("Month", typeof(System.Int32));
                DataColumn Year = new DataColumn("Year", typeof(System.String));
                DataColumn ColumnHeader = new DataColumn("ColumnHeader", typeof(System.String));
                DataColumn ColumnValue = new DataColumn("ColumnValue", typeof(System.Decimal));
                DataColumn Type = new DataColumn("Type", typeof(System.String));
                DataColumn Department = new DataColumn("Department", typeof(System.String));
                DataColumn Name = new DataColumn("Name", typeof(System.String));
                DataColumn StaffID = new DataColumn("StaffID", typeof(System.String));

                DataColumn Mechanised = new DataColumn("Mechanised", typeof(System.Boolean));
                DataColumn GradeCategory = new DataColumn("GradeCategory", typeof(System.String));
                DataColumn Grade = new DataColumn("Grade", typeof(System.String));
                DataColumn Unit = new DataColumn("Unit", typeof(System.String));
                DataColumn Overseer = new DataColumn("Overseer", typeof(System.String));
                DataColumn Status = new DataColumn("Status", typeof(System.String));
                DataColumn ColumnPosition = new DataColumn("ColumnPosition", typeof(System.String));
                DataColumn Zone = new DataColumn("Zone", typeof(System.String));
                DataColumn JobTitle = new DataColumn("JobTitle", typeof(System.String));
                DataColumn SSNITNumber = new DataColumn("SSNITNumber", typeof(System.String));
                DataColumn Bank = new DataColumn("Bank", typeof(System.String));
                DataColumn AccountNumber = new DataColumn("AccountNumber", typeof(System.String));
                DataColumn HoursWorked = new DataColumn("HoursWorked", typeof(System.String));
                DataColumn AccountType = new DataColumn("AccountType", typeof(System.String));

                //Adding columns to datatable
                dt.Columns.AddRange(new DataColumn[] { ID, Month, Year, ColumnHeader, ColumnValue, Type, Department, Name, StaffID, Mechanised, GradeCategory, Grade, Unit, Overseer, Status, Zone, JobTitle, SSNITNumber, Bank, AccountNumber, HoursWorked, AccountType, ColumnPosition });

                DataTable table = dal.ExecuteReader("Select * from StaffSalaryPaymentView Where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "'");

                foreach (DataRow row in table.Rows)
                {

                    //Adding data
                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Basic Salary", decimal.Parse(row["BasicSalary"].ToString()), "Basic Salary", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", 1);

                    //Add Allowances
                    int ctr = 2;
                    foreach (DataRow allowance in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where Type='Other Allowance' or Type='Allowance' and staffID ='" + row["StaffID"].ToString() + "' and Month ='" + row["Month"].ToString() + "' and Year ='" + row["Year"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), allowance["Description"].ToString(), decimal.Parse(allowance["Amount"].ToString()), "Allowance", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                        ctr++;
                    }

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Taxable Allowance", decimal.Parse(row["AllowanceTax"].ToString()), "Total Taxable Allowance", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Non Taxable Allowance", decimal.Parse(row["NonAllowanceTax"].ToString()), "Total Non Taxable Allowance", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Other Earnings", decimal.Parse(row["TotalAllowance"].ToString()), "Total Other Allowances", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Allowance", decimal.Parse(row["GrandTotalAllowance"].ToString()), "Total Allowance", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Medical Claims", decimal.Parse(row["MedicalClaims"].ToString()), "Allowance", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                    ctr++;

                    //Add OverTime
                    foreach (DataRow overtime in dal.ExecuteReader("Select Description,Amount,OverTimeHours,OverTimeRate,TotalShifts,Holiday From StaffSalaryPaymentsAllowancesAndDeductionsView Where Type='OverTime' and staffID ='" + row["StaffID"].ToString() + "' and Month ='" + row["Month"].ToString() + "' and Year ='" + row["Year"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), overtime["Description"].ToString(), decimal.Parse(overtime["Amount"].ToString()), "OverTime", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                        ctr++;

                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), overtime["Description"].ToString() + " Hrs", decimal.Parse(overtime["OverTimeHours"].ToString()), "OverTimeHours", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                        ctr++;
                    }

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Gross Income", decimal.Parse(row["GrossSalary"].ToString()), "Gross Income", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "SSF ER", decimal.Parse(row["SSNITEmployer"].ToString()), "SSNIT", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Provident Fund Employer", decimal.Parse(row["ProvidentFundEmployer"].ToString()), "PF", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                    ctr++;

                    //Add TotalCost
                    foreach (DataRow totalcost in dal.ExecuteReader("Select SUM(TotalCost) as TotalCost from StaffSalaryPaymentView Where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "' and StaffID='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Cost", decimal.Parse(totalcost["TotalCost"].ToString()), "TotalCost", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Debit", ctr);
                        ctr++;
                    }

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "SSF EE", decimal.Parse(row["SSNITEmployee"].ToString()), "SSNIT", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Provident Fund Employee", decimal.Parse(row["ProvidentFundEmployee"].ToString()), "PF", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "NAT", decimal.Parse(row["NetAfterTax"].ToString()), "NAT", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    //Add Deductions
                    foreach (DataRow deduction in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where Type='Deduction' and staffID ='" + row["StaffID"].ToString() + "' and Month ='" + row["Month"].ToString() + "' and Year ='" + row["Year"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), deduction["Description"].ToString(), decimal.Parse(deduction["Amount"].ToString()), "Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                        ctr++;
                    }

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Other Deductions", decimal.Parse(row["TotalDeduction"].ToString()), "Total Other Deductions", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Deduction", decimal.Parse(row["GrandTotalDeduction"].ToString()), "Total Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Withholding Tax", decimal.Parse(row["WithholdingAmount"].ToString()), "Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Susu Plus", decimal.Parse(row["SusuPlusContribution"].ToString()), "Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Income Tax", decimal.Parse(row["IncomeTax"].ToString()), "Tax", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Overtime Tax", decimal.Parse(row["TotalOverTimeTax"].ToString()), "Tax", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Bonus Tax", decimal.Parse(row["TotalBonusTax"].ToString()), "Tax", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Upfront Relief", decimal.Parse(row["UpfrontRelief"].ToString()), "Tax Relief", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Taxable Income", decimal.Parse(row["TaxableIncome"].ToString()), "Taxable Income", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Tax", decimal.Parse(row["TotalTax"].ToString()), "Total Tax", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    //Add Loans
                    foreach (DataRow loan in dal.ExecuteReader("Select LoanType,Description,Amount,MonthlyInstallment From StaffSalaryPaymentsLoanView Where PaymentID=" + payRoll.ID + " and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), loan["LoanType"].ToString(), decimal.Parse(loan["MonthlyInstallment"].ToString()), "Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                        ctr++;
                    }

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Loans", decimal.Parse(row["Loan"].ToString()), "Deduction", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "", ctr);
                    ctr++;

                    dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Net Salary", decimal.Parse(row["TakeHome"].ToString()), "Net Salary", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);
                    ctr++;

                    //Add TotalPayables
                    foreach (DataRow totalpayable in dal.ExecuteReader("Select SUM(TotalPayable) as TotalPayable from StaffSalaryPaymentView Where Month='" + payRoll.Month + "' and Year='" + payRoll.Year + "' and StaffID='" + row["StaffID"].ToString() + "'").Rows)
                    {
                        dt.Rows.Add(int.Parse(row["ID"].ToString()), int.Parse(row["Month"].ToString()), row["Year"].ToString(), "Total Payables", decimal.Parse(totalpayable["TotalPayable"].ToString()), "TotalPayables", row["Department"].ToString(), row["Name"].ToString(), row["StaffID"].ToString(), bool.Parse(row["Mechanised"].ToString()), row["GradeCategory"].ToString(), row["Grade"].ToString(), row["Unit"].ToString(), row["Overseer"].ToString(), row["Status"].ToString(), row["Zone"].ToString(), row["JobTitle"].ToString(), row["SSNITNo"].ToString(), row["Bank"].ToString(), row["AccountNumber"].ToString(), row["HoursWorked"].ToString(), "Credit", ctr);

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
            

            return dt;
        }

        #region BuildPayRollFromData
        private PayRoll BuildPayRollFromData(DataTable table)
        {
            PayRoll payRoll = new PayRoll();
            DataTable dt = new DataTable();
            foreach (DataRow row in table.Rows)
            {
                payRoll.Month = row["Month"].ToString();
                payRoll.Year = row["Year"].ToString();

                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Basic Salary",
                    ColumnValue = decimal.Parse(row["BasicSalary"].ToString()),
                    Type = "Basic Salary",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = 1
                });

                //Add Allowances
                int ctr = 2;
                foreach (DataRow allowance in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='Allowance' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                {
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = allowance["Description"].ToString(),
                        ColumnValue = decimal.Parse(allowance["Amount"].ToString()),
                        Type = "Allowance",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                }
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Medical Claims",
                    ColumnValue = decimal.Parse(row["MedicalClaims"].ToString()),
                    Type = "Allowance",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Total Other Allowances",
                    ColumnValue = decimal.Parse(row["TotalAllowance"].ToString()),
                    Type = "Total Other Allowances",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Total Allowance",
                    ColumnValue = decimal.Parse(row["GrandTotalAllowance"].ToString()),
                    Type = "Total Allowance",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Gross Income",
                    ColumnValue = decimal.Parse(row["GrossSalary"].ToString()),
                    Type = "Gross Income",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "SSF EE",
                    ColumnValue = decimal.Parse(row["SSNITEmployee"].ToString()),
                    Type = "SSNIT",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;

                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Taxable Income",
                    ColumnValue = decimal.Parse(row["TaxableIncome"].ToString()),
                    Type = "Taxable Income",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Income Tax",
                    ColumnValue = decimal.Parse(row["IncomeTax"].ToString()),
                    Type = "Tax",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "NAT",
                    ColumnValue = decimal.Parse(row["NetAfterTax"].ToString()),
                    Type = "NAT",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                //Add Deductions
                foreach (DataRow deduction in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='Deduction' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                {
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = deduction["Description"].ToString(),
                        ColumnValue = decimal.Parse(deduction["Amount"].ToString()),
                        Type = "Deduction",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                }
                //Add OverTime
                foreach (DataRow OverTime in dal.ExecuteReader("Select Description,Amount From StaffSalaryPaymentsAllowancesAndDeductionsView Where PaymentID=" + payRoll.ID + " and Type='OverTime' and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                {
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = OverTime["Description"].ToString(),
                        ColumnValue = decimal.Parse(OverTime["Amount"].ToString()),
                        Type = "OverTime",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                }

                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Withholding Tax",
                    ColumnValue = decimal.Parse(row["WithholdingAmount"].ToString()),
                    Type = "Deduction",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Susu Plus",
                    ColumnValue = decimal.Parse(row["SusuPlusContribution"].ToString()),
                    Type = "Deduction",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                //Add Loans
                foreach (DataRow loan in dal.ExecuteReader("Select LoanType,Description,Amount,MonthlyInstallment From StaffSalaryPaymentsLoanView Where PaymentID=" + payRoll.ID + " and staffID ='" + row["StaffID"].ToString() + "'").Rows)
                {
                    payRoll.PaySlips.Add(new PayRollItem()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        ColumnHeader = loan["LoanType"].ToString(),
                        ColumnValue = decimal.Parse(loan["MonthlyInstallment"].ToString()),
                        Type = "Deduction",
                        Department = row["Department"].ToString(),
                        Name = row["Name"].ToString(),
                        StaffID = row["StaffID"].ToString(),
                        Mechanised = bool.Parse(row["Mechanised"].ToString()),
                        GradeCategory = row["GradeCategory"].ToString(),
                        Grade = row["Grade"].ToString(),
                        Unit = row["Unit"].ToString(),
                        Overseer = row["Overseer"].ToString(),
                        Status = row["Status"].ToString(),
                        Zone = row["Zone"].ToString(),
                        JobTitle = row["JobTitle"].ToString(),
                        SSNITNumber = row["SSNITNumber"].ToString(),
                        Bank = row["Bank"].ToString(),
                        AccountNumber = row["AccountNumber"].ToString(),
                        ColumnPosition = ctr
                    });
                    ctr++;
                }
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Loans",
                    ColumnValue = decimal.Parse(row["Loan"].ToString()),
                    Type = "Total Loans",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Total Other Deductions",
                    ColumnValue = decimal.Parse(row["TotalDeduction"].ToString()),
                    Type = "Total Other Deductions",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Total Deduction",
                    ColumnValue = decimal.Parse(row["GrandTotalDeduction"].ToString()),
                    Type = "Total Deduction",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Net Salary",
                    ColumnValue = decimal.Parse(row["TakeHome"].ToString()),
                    Type = "Net Salary",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Provident Fund Employee",
                    ColumnValue = decimal.Parse(row["ProvidentFundEmployee"].ToString()),
                    Type = "PF",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "Provident Fund Employer",
                    ColumnValue = decimal.Parse(row["ProvidentFundEmployer"].ToString()),
                    Type = "PF",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
                ctr++;
                payRoll.PaySlips.Add(new PayRollItem()
                {
                    ID = int.Parse(row["ID"].ToString()),
                    ColumnHeader = "SSF ER",
                    ColumnValue = decimal.Parse(row["SSNITEmployer"].ToString()),
                    Type = "SSNIT",
                    Department = row["Department"].ToString(),
                    Name = row["Name"].ToString(),
                    StaffID = row["StaffID"].ToString(),
                    Mechanised = bool.Parse(row["Mechanised"].ToString()),
                    GradeCategory = row["GradeCategory"].ToString(),
                    Grade = row["Grade"].ToString(),
                    Unit = row["Unit"].ToString(),
                    Overseer = row["Overseer"].ToString(),
                    Status = row["Status"].ToString(),
                    Zone = row["Zone"].ToString(),
                    JobTitle = row["JobTitle"].ToString(),
                    SSNITNumber = row["SSNITNumber"].ToString(),
                    Bank = row["Bank"].ToString(),
                    AccountNumber = row["AccountNumber"].ToString(),
                    ColumnPosition = ctr
                });
            }
            return payRoll;
        }
        #endregion
    }
}
