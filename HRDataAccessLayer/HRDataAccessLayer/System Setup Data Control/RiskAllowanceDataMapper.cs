using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class RiskAllowanceDataMapper
    {
        IList<RiskAllowance> lstRiskAllowances;

        public DALHelper dalHelper;
        private CompanyDataMapper companyDataMapper;

        private Company company;
        private string Period;
        private int Year;

        public RiskAllowanceDataMapper()
        {
            lstRiskAllowances = new List<RiskAllowance>();

            dalHelper = new DALHelper();
            companyDataMapper = new CompanyDataMapper();

            company = companyDataMapper.GetAll().FirstOrDefault();
        }

        public RiskAllowanceDataMapper(string Period, int Year)
        {
            this.Period = Period;
            this.Year = Year;
            lstRiskAllowances = new List<RiskAllowance>();

            dalHelper = new DALHelper();
            companyDataMapper = new CompanyDataMapper();

            company = companyDataMapper.GetAll().FirstOrDefault();
        }

        public bool PeriodHasData(string Period, int Year, string Department, decimal rate)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Period", Period, DbType.String);
                dalHelper.CreateParameter("@Year", Year, DbType.Int32);
                dalHelper.CreateParameter("@Rate", rate, DbType.Decimal);

                string count = string.Empty;
                if (!(Department == string.Empty || Department.ToUpper().Trim() == "ALL DEPARTMENTS"))
                {
                    dalHelper.CreateParameter("@Department", Department, DbType.String);
                    count = dalHelper.ExecuteScalar("select count(*) from StaffRiskAllowancesView where [Period]=@Period and [Year]=@Year and [Department]=@Department and Terminated != '1'").ToString();
                }
                else
                {
                    count = dalHelper.ExecuteScalar("select count(*) from StaffRiskAllowancesView where [Period]=@Period and [Year]=@Year and Terminated != '1'").ToString();
                }

                if (count != null)
                    return Convert.ToBoolean(Convert.ToInt32(count));
            }
            catch (Exception xi) { }


            return false;
        }

        public bool PeriodHasData(string Period, int Year, string Department)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Period", Period, DbType.String);
                dalHelper.CreateParameter("@Year", Year, DbType.Int32);

                string count = string.Empty;
                if (!(Department == string.Empty || Department.ToUpper().Trim() == "ALL DEPARTMENTS"))
                {
                    dalHelper.CreateParameter("@Department", Department, DbType.String);
                    count = dalHelper.ExecuteScalar("select count(*) from StaffRiskAllowancesView where [Period]=@Period and [Year]=@Year and [Department]=@Department and Terminated != '1'").ToString();
                }
                else
                {
                    count = dalHelper.ExecuteScalar("select count(*) from StaffRiskAllowancesView where [Period]=@Period and [Year]=@Year and Terminated != '1'").ToString();
                }

                if (count != null)
                    return Convert.ToBoolean(Convert.ToInt32(count));
            }
            catch (Exception xi) { }


            return false;
        }

        public bool Save(RiskAllowance riskAllowance, string Period, int Year, User user)
        {
            try
            {
                string sql = string.Empty;
                //string where = string.Empty;
                dalHelper.ClearParameters();
                if (riskAllowance.ID > 0)
                {
                    dalHelper.CreateParameter("@ID", riskAllowance.ID, DbType.Int32);
                    dalHelper.CreateParameter("@DateModified", DateTime.Now, DbType.DateTime);
                    dalHelper.CreateParameter("@EarnedRiskAllowance", riskAllowance.EarnedRiskAllowance, DbType.Decimal);
                    dalHelper.CreateParameter("@DaysAbsent", riskAllowance.DaysAbsent, DbType.Decimal);
                    dalHelper.CreateParameter("@Department", riskAllowance.Department, DbType.String);
                    sql = "update StaffRiskAllowances set DaysAbsent=@DaysAbsent,EarnedRiskAllowance=@EarnedRiskAllowance,DateModified=@DateModified, Department=@Department where ID=@ID";

                }
                else
                {
                    sql = "insert into StaffRiskAllowance (staffcode,BasicSalary,RiskAllowanceRate,DaysAbsent,EarnedRiskAllowance,Period,Year,PayFrequency,EntryDate, EnteredById, Department)" +
                        "values(@staffcode,@BasicSalary,@RiskAllowanceRate,@DaysAbsent,@EarnedRiskAllowance,@Period,@Year,@PayFrequency,@EntryDate, @EnteredById, @Department)";
                    dalHelper.CreateParameter("@staffCode", riskAllowance.Staff.ID, DbType.Int32);
                    dalHelper.CreateParameter("@BasicSalary", riskAllowance.BasicSalary, DbType.Decimal);
                    dalHelper.CreateParameter("@RiskAllowanceRate", riskAllowance.RiskAllowanceRate, DbType.Decimal);
                    dalHelper.CreateParameter("@DaysAbsent", riskAllowance.DaysAbsent, DbType.Decimal);

                    dalHelper.CreateParameter("@Period", Period, DbType.String);
                    dalHelper.CreateParameter("@Year", Year, DbType.Int32);
                    dalHelper.CreateParameter("@PayFrequency", riskAllowance.PayFrequency, DbType.String);
                    dalHelper.CreateParameter("@EntryDate", DateTime.Now.Date, DbType.DateTime);
                    dalHelper.CreateParameter("@EnteredById", user.ID, DbType.Int32);
                    dalHelper.CreateParameter("@EarnedRiskAllowance", riskAllowance.EarnedRiskAllowance, DbType.Decimal);
                    dalHelper.CreateParameter("Department", riskAllowance.Department, DbType.String);
                }
                dalHelper.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception xi)
            {
                return false;
            }
        }

        public IList<RiskAllowance> getRiskAllowances(string StaffID, string name, string Period, int Year, string Department, string Mechanised, decimal rate)
        {
            try
            {
                dalHelper.ClearParameters();
                var where = string.Empty;
                string sql = string.Empty;
                bool periodHasData = false;

                if (Department == "ALL DEPARTMENTS")
                {
                    Department = string.Empty;
                }

                //if (PeriodHasData(Period, Year, Department, rate))
                //{
                //    dalHelper = new DALHelper();
                //    dalHelper.ClearParameters();
                //    dalHelper.CreateParameter("@Period", Period, DbType.String);
                //    dalHelper.CreateParameter("@Year", Year, DbType.Int32);
                //    where += " Period=@Period and Year=@Year and ";

                //    sql = "select * from StaffRiskAllowancesView ";

                //    periodHasData = true;
                //}
                //else
                //{
                    sql = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView ";
                    periodHasData = false;
                //}

                where += " Confirmed='true' and TransferredOut='false' and Terminated='false' and Payment='true' and ";

                if (!periodHasData)
                {
                    where += " Archived = 'false' and ";
                }

                if (StaffID != string.Empty)
                {
                    where += " StaffID like '" + StaffID.Trim() + "%' and ";
                }
                if (name != string.Empty)
                {
                    where += " surname like '" + name.Trim() + "%' or firstname like '" + name.Trim() + "%' or (othername<>'' and othername like '" + name.Trim() + "%') and ";
                }
                if (Department != string.Empty && Department != "ALL DEPARTMENTS")
                {
                    where += " Department=@Department and ";
                    dalHelper.CreateParameter("@Department", Department, DbType.String);
                }
                if (Mechanised.ToLower() != "all" && Mechanised != string.Empty)
                {
                    where += " Mechanised=@Mechanised and ";
                    dalHelper.CreateParameter("@Mechanised", Mechanised.ToLower() == "yes" ? true : false, DbType.Boolean);
                }
                DataTable dt;

                if (where != string.Empty)
                    where = "where " + where.TrimEnd(" and ".ToCharArray());
                sql = sql + where + " order by staffID asc ";
                dt = dalHelper.ExecuteReader(sql);
                DataMappper(dt, periodHasData, rate);
            }
            catch (Exception xi) { }

            return lstRiskAllowances;
        }

        public int DeleteRiskAllowance(DALHelper newDALHelper, RiskAllowance riskAllowance, int AllowanceTypeId, int month)
        {
            int ctr = 0;
            try
            {
                newDALHelper.ClearParameters();
                newDALHelper.CreateParameter("@Id", riskAllowance.ID, DbType.Int32);

                newDALHelper.ExecuteNonQuery("delete StaffRiskAllowance where id=@Id");

                StaffAllowanceDataMapper staffAllowanceDataMapper = new StaffAllowanceDataMapper();
                staffAllowanceDataMapper.ArchiveCurrent(newDALHelper, riskAllowance.Staff.ID, AllowanceTypeId, month);
                ctr++;
            }
            catch (Exception xi)
            {

                Logger.LogError(xi);

            }
            return ctr;
        }

        public void deleteAllRiskAllowances(DALHelper newDALHelper, int year, int AllowanceTypeId, string month, string department)
        {
            try
            {
                newDALHelper.ClearParameters();
                newDALHelper.CreateParameter("@Month", month, DbType.String);
                newDALHelper.CreateParameter("@Year", year, DbType.Int32);
                newDALHelper.CreateParameter("@Department", department, DbType.String);

                newDALHelper.ExecuteNonQuery("delete from StaffRiskAllowance where Period=@Month and Year=@Year and Department=@Department");

                StaffAllowanceDataMapper staffAllowanceDataMapper = new StaffAllowanceDataMapper();
                //staffAllowanceDataMapper.ArchiveAll(newDALHelper, AllowanceTypeId, year, Global.GetMonth(month));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

        public RiskAllowance getRiskAllowance(int Id)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", Id, DbType.Int32);

                var dt = dalHelper.ExecuteReader("select * from StaffRiskAllowancesView where id=@Id");

                DataMappper(dt, true, 0);
            }
            catch (Exception xi) { }

            return lstRiskAllowances.FirstOrDefault();
        }

        public IList<RiskAllowance> getRetrieveRiskAllowances(DataTable dt)
        {
            DataMappper(dt, true, 0);
            return lstRiskAllowances;
        }

        public void DataMappper(DataTable dt, bool periodHasData, decimal rate)
        {
            try
            {
                lstRiskAllowances.Clear();
                foreach (DataRow dataRow in dt.Rows)
                {
                    RiskAllowance riskAllowance = new RiskAllowance();


                    if (periodHasData == true)
                    {
                        riskAllowance.ID = dataRow["ID"] != DBNull.Value ? Convert.ToInt32(dataRow["ID"]) : 0;
                        riskAllowance.BasicSalary = dataRow["Expr2"] != DBNull.Value ? Convert.ToDecimal(dataRow["Expr2"]) : 0;
                        //riskAllowance.BasicSalary = dataRow["BasicSalary"] != DBNull.Value ? Convert.ToDecimal(dataRow["BasicSalary"]) : 0;

                        riskAllowance.Staff = dataRow["ID"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["ID"]), StaffID = Convert.ToString(dataRow["StaffID"]), FirstName = Convert.ToString(dataRow["Firstname"]), Surname = Convert.ToString(dataRow["Surname"]), OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, PaymentType = Convert.ToString(dataRow["PaymentType"]), Department = new Department() { Description = Convert.ToString(dataRow["Department"]), ID = Convert.ToInt32(dataRow["DepartmentID"]) }, Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), BasicSalary = (periodHasData == true) ? Convert.ToDecimal(dataRow["BasicSalary"]) : Convert.ToDecimal(dataRow["BasicSalary"]) } : riskAllowance.Staff;

                        riskAllowance.Staff = dataRow["staffCode"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["staffCode"]), StaffID = Convert.ToString(dataRow["StaffID"]), FirstName = Convert.ToString(dataRow["Firstname"]), Surname = Convert.ToString(dataRow["Surname"]), OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, PaymentType = Convert.ToString(dataRow["PaymentType"]), Department = new Department() { Description = Convert.ToString(dataRow["Department"]), ID = Convert.ToInt32(dataRow["DepartmentID"]) }, Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), BasicSalary = Convert.ToDecimal(dataRow["BasicSalary"]) } : riskAllowance.Staff;

                        riskAllowance.RiskAllowanceRate = dataRow["RiskAllowanceRate"] != DBNull.Value ? Convert.ToDecimal(dataRow["RiskAllowanceRate"]) : 0;

                        riskAllowance.EarnedRiskAllowance = dataRow["EarnedRiskAllowance"] != DBNull.Value ? Convert.ToDecimal(dataRow["EarnedRiskAllowance"]) : 0;

                        riskAllowance.EntryDate = dataRow["EntryDate"] != DBNull.Value ? Convert.ToDateTime(dataRow["EntryDate"]) : riskAllowance.EntryDate;


                        riskAllowance.PayFrequency = dataRow["PayFrequency"] != DBNull.Value ? Convert.ToString(dataRow["PayFrequency"]) : string.Empty;
                        riskAllowance.Period = dataRow["Period"] != DBNull.Value ? Convert.ToString(dataRow["Period"]) : string.Empty;

                        riskAllowance.Year = dataRow["Year"] != DBNull.Value ? Convert.ToInt32(dataRow["Year"]) : 0;

                        riskAllowance.DateModified = dataRow["DateModified"] != DBNull.Value ? Convert.ToDateTime(dataRow["DateModified"]) : riskAllowance.DateModified;
                        riskAllowance.EnteredBy = dataRow["EnteredById"] != DBNull.Value ? new User() { ID = Convert.ToInt32(dataRow["EnteredById"]), UserName = dataRow["UserName"] != DBNull.Value ? Convert.ToString(dataRow["UserName"]) : string.Empty, Name = dataRow["UserName"] != DBNull.Value ? Convert.ToString(dataRow["UserName"]) : string.Empty } : riskAllowance.EnteredBy;

                        riskAllowance.DaysAbsent = dataRow["DaysAbsent"] != DBNull.Value ? Convert.ToInt32(dataRow["DaysAbsent"]) : 0;

                        riskAllowance.Department = dataRow["Department"] != DBNull.Value ? (dataRow["Department"]).ToString() : string.Empty;
                    }
                    else
                    {
                        riskAllowance.ID = 0;
                        riskAllowance.Staff = dataRow["ID"] != DBNull.Value ? 
                            new Employee() { ID = Convert.ToInt32(dataRow["ID"]), 
                                StaffID = Convert.ToString(dataRow["StaffID"]), 
                                FirstName = Convert.ToString(dataRow["Firstname"]), 
                                Surname = Convert.ToString(dataRow["Surname"]), 
                                OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, 
                                PaymentType = Convert.ToString(dataRow["PaymentType"]), 
                                Department = new Department() { 
                                Description = Convert.ToString(dataRow["Department"]), 
                                ID = Convert.ToInt32(dataRow["DepartmentID"]) }, 
                                Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), 
                                BasicSalary = Convert.ToDecimal(dataRow["BasicSalary"]) } : riskAllowance.Staff;

                    }


                    if (riskAllowance.BasicSalary == 0)
                        riskAllowance.BasicSalary = riskAllowance.Staff.BasicSalary;



                    if (riskAllowance.ID == 0)
                        riskAllowance.RiskAllowanceRate = rate;


                    lstRiskAllowances.Add(riskAllowance);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }
    }
}
