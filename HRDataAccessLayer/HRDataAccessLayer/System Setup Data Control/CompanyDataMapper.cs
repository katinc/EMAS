using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Data;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
    public class CompanyDataMapper
    {
        private DALHelper dal;

        public CompanyDataMapper()
        {
            this.dal = new DALHelper();
        }

        #region UPDATE
        public void Update(object item)
        {
            try
            {
                Company company = (Company)item;
                dal.ClearParameters();
                dal.CreateParameter("@Name", company.Name, DbType.String);
                dal.CreateParameter("@PostalAddress", company.PostalAddress, DbType.String);
                dal.CreateParameter("@EmailAddress", company.EmailAddress, DbType.String);
                dal.CreateParameter("@Website", company.Website, DbType.String);
                dal.CreateParameter("@ContactNos", company.ContactNos, DbType.String);
                dal.CreateParameter("@FaxNos", company.FaxNos, DbType.String);
                dal.CreateParameter("@CountryID", company.Country.ID, DbType.Int32);
                dal.CreateParameter("@RegionID", company.Region.ID, DbType.Int32);
                dal.CreateParameter("@DistrictID", company.District.ID, DbType.Int32);
                dal.CreateParameter("@TownID", company.Town.ID, DbType.Int32);
                dal.CreateParameter("@FacilityTypeID", company.FacilityType.ID, DbType.Int32);
                dal.CreateParameter("@FacilityOwnershipTypeID", company.OwnershipType.ID, DbType.Int32);
                dal.CreateParameter("@DateEstablished", company.DateEstabished, DbType.DateTime);
                dal.CreateParameter("@Motto", company.Motto, DbType.String);
                dal.CreateParameter("@Initials", company.Initials, DbType.String);
                dal.CreateParameter("@Logo", Global.ImageToArray(company.Logo), DbType.Binary);
                dal.CreateParameter("@PensionAgeMales", company.PensionAgeMale, DbType.String);
                dal.CreateParameter("@PensionAgeFemales", company.PensionAgeFemale, DbType.String);
                dal.CreateParameter("@MinimumEmployeeAge", company.MinimumEmployeeAge, DbType.Int32);
                dal.CreateParameter("@MaximumEmployeeAge", company.MaximumEmployeeAge, DbType.Int32);
                dal.CreateParameter("@Salary", company.Salary, DbType.Boolean);
                dal.CreateParameter("@MinimumSalary", company.MinimumSalary, DbType.Decimal);
                dal.CreateParameter("@SalaryPaymentUnit", company.SalaryPaymentUnit, DbType.String);
                dal.CreateParameter("@MinimumCharacter", company.MinimumCharacter, DbType.Int32);
                dal.CreateParameter("@PINMinimumCharacter", company.PINMinimumCharacter, DbType.Int32);
                dal.CreateParameter("@IsSalaryStructure", company.IsSalaryStructure, DbType.Boolean);
                dal.CreateParameter("@Character", company.Character, DbType.String);
                dal.CreateParameter("@Wage", company.Wage, DbType.Boolean);
                dal.CreateParameter("@MinimumWage", company.MinimumWage, DbType.Decimal);
                dal.CreateParameter("@WagePaymentUnit", company.WagePaymentUnit, DbType.String);

                dal.CreateParameter("@PaymentFrequency", company.PaymentFrequency, DbType.String);

                dal.CreateParameter("@OverTime", company.OverTime, DbType.Boolean);
                dal.CreateParameter("@OverTimeAmount", company.OverTimeAmount, DbType.Decimal);
                dal.CreateParameter("@MinimumOverTime", company.MinimumOverTime, DbType.Decimal);
                dal.CreateParameter("@OverTimeType", company.OverTimeType, DbType.String);
                dal.CreateParameter("@CalculatedOn", company.CalulatedOn, DbType.String);
                dal.CreateParameter("@SSNITRegistrationNo", company.SSNITRegistrationNo, DbType.String);
                dal.CreateParameter("@IsFileNumber", company.IsFileNumber, DbType.Boolean);

                dal.CreateParameter("@PayslipFormat", company.PayslipFormat, DbType.String);
                dal.CreateParameter("@DutyAllowanceRate", company.DutyAllowanceRate, DbType.Decimal);
                dal.CreateParameter("@AuthenticationType", company.AuthenticationType, DbType.Int32);
                //dal.CreateParameter("@AutomaticPromotionFlag", company.AutomaticPromotionFlag, DbType.Boolean);

                //dal.ExecuteNonQuery("Update CompanyInfo Set DutyAllowanceRate=@DutyAllowanceRate,PayslipFormat=@PayslipFormat,Name=@Name,MinimumCharacter=@MinimumCharacter," +
                //    "PINMinimumCharacter=@PINMinimumCharacter,IsSalaryStructure=@IsSalaryStructure,Character=@Character,PostalAddress=@PostalAddress,EmailAddress=@EmailAddress," +
                //    "Website=@Website,ContactNos=@ContactNos,FaxNos=@FaxNos,Country=@CountryID,Region=@RegionID,District=@DistrictID,Town=@TownID,FacilityTypeID=@FacilityTypeID," +
                //    "FacilityOwnershipTypeID=@FacilityOwnershipTypeID,DateEstablished=@DateEstablished,Motto=@Motto,Logo=@Logo,PensionAgeMales=@PensionAgeMales,PensionAgeFemales=@PensionAgeFemales," +
                //    "Salary=@Salary,MinimumSalary=@MinimumSalary,SalaryPaymentUnit=@SalaryPaymentUnit,Wage=@Wage,MinimumWage=@MinimumWage,WagePaymentUnit=@WagePaymentUnit,PaymentFrequency=@PaymentFrequency," +
                //    "OverTime=@OverTime,OverTimeType=@OverTimeType,OverTimeAmount=@OverTimeAmount,MinimumOverTime=@MinimumOverTime,CalculatedOn=@CalculatedOn,MinimumEmployeeAge = @MinimumEmployeeAge," +
                //    "MaximumEmployeeAge = @MaximumEmployeeAge, SSNITRegistrationNo=@SSNITRegistrationNo, IsFileNumber=@IsFileNumber,AuthenticationType =@AuthenticationType , AutomaticPromotionFlag=@AutomaticPromotionFlag");

                dal.ExecuteNonQuery("Update CompanyInfo Set DutyAllowanceRate=@DutyAllowanceRate,PayslipFormat=@PayslipFormat,Name=@Name,MinimumCharacter=@MinimumCharacter," +
                    "PINMinimumCharacter=@PINMinimumCharacter,IsSalaryStructure=@IsSalaryStructure,Character=@Character,PostalAddress=@PostalAddress,EmailAddress=@EmailAddress," +
                    "Website=@Website,ContactNos=@ContactNos,FaxNos=@FaxNos,Country=@CountryID,Region=@RegionID,District=@DistrictID,Town=@TownID,FacilityTypeID=@FacilityTypeID," +
                    "FacilityOwnershipTypeID=@FacilityOwnershipTypeID,DateEstablished=@DateEstablished,Motto=@Motto,Logo=@Logo,PensionAgeMales=@PensionAgeMales,PensionAgeFemales=@PensionAgeFemales," +
                    "Salary=@Salary,MinimumSalary=@MinimumSalary,SalaryPaymentUnit=@SalaryPaymentUnit,Wage=@Wage,MinimumWage=@MinimumWage,WagePaymentUnit=@WagePaymentUnit,PaymentFrequency=@PaymentFrequency," +
                    "OverTime=@OverTime,OverTimeType=@OverTimeType,OverTimeAmount=@OverTimeAmount,MinimumOverTime=@MinimumOverTime,CalculatedOn=@CalculatedOn,MinimumEmployeeAge = @MinimumEmployeeAge," +
                    "MaximumEmployeeAge = @MaximumEmployeeAge, SSNITRegistrationNo=@SSNITRegistrationNo, IsFileNumber=@IsFileNumber,AuthenticationType =@AuthenticationType");

                //dal.ExecuteNonQuery("Update CompanyInfo Set PayslipFormat=@PayslipFormat,Name=@Name,MinimumCharacter=@MinimumCharacter,PINMinimumCharacter=@PINMinimumCharacter,IsSalaryStructure=@IsSalaryStructure,Character=@Character,PostalAddress=@PostalAddress,EmailAddress=@EmailAddress,Website=@Website,ContactNos=@ContactNos,FaxNos=@FaxNos,Country=@CountryID,Region=@RegionID,District=@DistrictID,Town=@TownID,FacilityTypeID=@FacilityTypeID,FacilityOwnershipTypeID=@FacilityOwnershipTypeID,DateEstablished=@DateEstablished,Motto=@Motto,Logo=@Logo,PensionAgeMales=@PensionAgeMales,PensionAgeFemales=@PensionAgeFemales,Salary=@Salary,MinimumSalary=@MinimumSalary,SalaryPaymentUnit=@SalaryPaymentUnit,Wage=@Wage,MinimumWage=@MinimumWage,WagePaymentUnit=@WagePaymentUnit,PaymentFrequency=@PaymentFrequency,OverTime=@OverTime,OverTimeType=@OverTimeType,OverTimeAmount=@OverTimeAmount,MinimumOverTime=@MinimumOverTime,CalculatedOn=@CalculatedOn,MinimumEmployeeAge = @MinimumEmployeeAge,MaximumEmployeeAge = @MaximumEmployeeAge, SSNITRegistrationNo=@SSNITRegistrationNo, IsFileNumber=@IsFileNumber,Initials=@Initials");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region GETALL
        public IList<Company> GetAll()
        {
            IList<Company> companies = new List<Company>();
            try
            {
                string query = "Select CompanyInfoView.* From CompanyInfoView";

                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    companies.Add(new Company() 
                    {
                        ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString()),
                        Name = row["Name"] == DBNull.Value ? string.Empty : row["Name"].ToString(),
                        PostalAddress = row["PostalAddress"] == DBNull.Value ? string.Empty : row["PostalAddress"].ToString(),
                        EmailAddress = row["EmailAddress"] == DBNull.Value ? string.Empty : row["EmailAddress"].ToString(),
                        Website = row["Website"] == DBNull.Value ? string.Empty : row["Website"].ToString(),
                        MinimumCharacter = row["MinimumCharacter"] == DBNull.Value ? 0 : int.Parse(row["MinimumCharacter"].ToString()),
                        PINMinimumCharacter = row["PINMinimumCharacter"] == DBNull.Value ? 0 : int.Parse(row["PINMinimumCharacter"].ToString()),
                        IsSalaryStructure = row["IsSalaryStructure"] == DBNull.Value ? false : bool.Parse(row["IsSalaryStructure"].ToString()),
                        Character = row["Character"] == DBNull.Value ? string.Empty : row["Character"].ToString(),
                        InitialStaffID = row["InitialStaffID"] == DBNull.Value ? string.Empty : row["InitialStaffID"].ToString(),
                        ContactNos = row["ContactNos"] == DBNull.Value ? string.Empty : row["ContactNos"].ToString(),
                        FaxNos = row["FaxNos"] == DBNull.Value ? string.Empty : row["FaxNos"].ToString(),
                        Country = new Country() { ID = row["CountryID"] == DBNull.Value ? 0 : int.Parse(row["CountryID"].ToString()), Description = row["Country"] == DBNull.Value ? null : row["Country"].ToString() },
                        District = new District() { ID = row["DistrictID"] == DBNull.Value ? 0 : int.Parse(row["DistrictID"].ToString()), Description = row["District"] == DBNull.Value ? null : row["District"].ToString() },
                        Region = new Region() { ID = row["RegionID"] == DBNull.Value ? 0 : int.Parse(row["RegionID"].ToString()), Description = row["Region"] == DBNull.Value ? null : row["Region"].ToString() },
                        FacilityType = new HealthFacilityType() { ID = row["FacilityTypeID"] == DBNull.Value ? 0 : int.Parse(row["FacilityTypeID"].ToString()), Description = row["HealthFacilityType"] == DBNull.Value ? null : row["HealthFacilityType"].ToString() },
                        OwnershipType = new HealthFacilityOwnership() { ID = row["FacilityOwnershipTypeID"] == DBNull.Value ? 0 : int.Parse(row["FacilityOwnershipTypeID"].ToString()), Description = row["HealthFacilityOwnership"] == DBNull.Value ? null : row["HealthFacilityOwnership"].ToString() },
                        Town = new Town() { ID = row["TownID"] == DBNull.Value ? 0 : int.Parse(row["TownID"].ToString()), Description = row["Town"] == DBNull.Value ? null : row["Town"].ToString() },
                        Salary = row["Salary"] == DBNull.Value ? false : bool.Parse(row["Salary"].ToString()),
                        SalaryPaymentUnit = row["SalaryPaymentUnit"] == DBNull.Value ? string.Empty : row["SalaryPaymentUnit"].ToString(),
                        MinimumSalary = row["MinimumSalary"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumSalary"].ToString()),
                        Wage = row["Wage"] == DBNull.Value ? false : bool.Parse(row["Wage"].ToString()),
                        WagePaymentUnit = row["WagePaymentUnit"].ToString(),
                        MinimumWage = row["MinimumWage"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumWage"].ToString()),
                        PaymentFrequency = row["PaymentFrequency"] == DBNull.Value ? string.Empty : row["PaymentFrequency"].ToString(),
                        Motto = row["Motto"].ToString(),
                        Initials=row["Initials"]!=DBNull.Value?row["Initials"].ToString():string.Empty,
                        DateEstabished = row["DateEstablished"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateEstablished"].ToString()),
                        PensionAgeFemale = row["PensionAgeFemales"] == DBNull.Value ? 0 : int.Parse(row["PensionAgeFemales"].ToString()),
                        PensionAgeMale = row["PensionAgeMales"] == DBNull.Value ? 0 : int.Parse(row["PensionAgeMales"].ToString()),
                        OverTime = row["Overtime"] == DBNull.Value ? false : bool.Parse(row["OverTime"].ToString()),
                        MinimumOverTime = row["MinimumOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumOverTime"].ToString()),
                        OverTimeType = row["OverTimeType"].ToString(),
                        OverTimeAmount = row["OverTimeAmount"] == DBNull.Value ? 0 : decimal.Parse(row["OverTimeAmount"].ToString()),
                        CalulatedOn = row["CalculatedOn"].ToString(),
                        MinimumEmployeeAge = int.Parse(row["MinimumEmployeeAge"].ToString()),
                        MaximumEmployeeAge = int.Parse(row["MaximumEmployeeAge"].ToString()),
                        SSNITRegistrationNo = row["SSNITRegistrationNo"].ToString() ,
                        IsFileNumber = bool.Parse(row["IsFileNumber"].ToString() ),
                        TotalShifts = row["TotalShifts"] == DBNull.Value ? 0 : int.Parse(row["TotalShifts"].ToString()),
                        PayslipFormat = row["PayslipFormat"].ToString(),
                        DutyAllowanceRate=row["DutyAllowanceRate"]!=DBNull.Value? Convert.ToDecimal(row["DutyAllowanceRate"]):0,
                        AuthenticationType = row["AuthenticationType"] == DBNull.Value ? 0 : int.Parse(row["AuthenticationType"].ToString()),
                        //AutomaticPromotionFlag = row["AutomaticPromotionFlag"] == DBNull.Value ? false : bool.Parse(row["AutomaticPromotionFlag"].ToString()),


                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return companies;
        }
        #endregion

        #region LazyLoad
        public IList<Company> LazyLoad()
        {
            IList<Company> companies = new List<Company>();
            try
            {
                string query = "SELECT CompanyInfoLazyLoadView.* From CompanyInfoLazyLoadView";
                DataTable table = dal.ExecuteReader(query);
                foreach (DataRow row in table.Rows)
                {
                    companies.Add(new Company()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Name = row["Name"] == DBNull.Value ? string.Empty : row["Name"].ToString(),
                        PostalAddress = row["PostalAddress"] == DBNull.Value ? string.Empty : row["PostalAddress"].ToString(),
                        EmailAddress = row["EmailAddress"] == DBNull.Value ? string.Empty : row["EmailAddress"].ToString(),
                        Website = row["Website"] == DBNull.Value ? string.Empty : row["Website"].ToString(),
                        MinimumCharacter = row["MinimumCharacter"] == DBNull.Value ? 0 : int.Parse(row["MinimumCharacter"].ToString()),
                        PINMinimumCharacter = row["PINMinimumCharacter"] == DBNull.Value ? 0 : int.Parse(row["PINMinimumCharacter"].ToString()),
                        IsSalaryStructure = row["IsSalaryStructure"] == DBNull.Value ? false : bool.Parse(row["IsSalaryStructure"].ToString()),
                        Character = row["Character"] == DBNull.Value ? null : row["Character"].ToString(),
                        InitialStaffID = row["InitialStaffID"] == DBNull.Value ? null : row["InitialStaffID"].ToString(),
                        ContactNos = row["ContactNos"].ToString(),
                        FaxNos = row["FaxNos"].ToString(),
                        Salary = row["Salary"] == DBNull.Value ? false : bool.Parse(row["Salary"].ToString()),
                        SalaryPaymentUnit = row["SalaryPaymentUnit"].ToString(),
                        MinimumSalary = row["MinimumSalary"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumSalary"].ToString()),
                        Wage = row["Wage"] == DBNull.Value ? false : bool.Parse(row["Wage"].ToString()),
                        WagePaymentUnit = row["WagePaymentUnit"].ToString(),
                        MinimumWage = row["MinimumWage"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumWage"].ToString()),
                        PaymentFrequency = row["PaymentFrequency"].ToString(),
                        DateEstabished = row["DateEstablished"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DateEstablished"].ToString()),
                        PensionAgeFemale = row["PensionAgeFemales"] == DBNull.Value ? 0 : int.Parse(row["PensionAgeFemales"].ToString()),
                        PensionAgeMale = row["PensionAgeMales"] == DBNull.Value ? 0 : int.Parse(row["PensionAgeMales"].ToString()),
                        OverTime = row["Overtime"] == DBNull.Value ? false : bool.Parse(row["OverTime"].ToString()),
                        MinimumOverTime = row["MinimumOverTime"] == DBNull.Value ? 0 : decimal.Parse(row["MinimumOverTime"].ToString()),
                        OverTimeType = row["OverTimeType"].ToString(),
                        OverTimeAmount = row["OverTimeAmount"] == DBNull.Value ? 0 : decimal.Parse(row["OverTimeAmount"].ToString()),
                        CalulatedOn = row["CalculatedOn"].ToString(),
                        MinimumEmployeeAge = int.Parse(row["MinimumEmployeeAge"].ToString()),
                        MaximumEmployeeAge = int.Parse(row["MaximumEmployeeAge"].ToString()),
                        SSNITRegistrationNo = row["SSNITRegistrationNo"].ToString(),
                        IsFileNumber = bool.Parse(row["IsFileNumber"].ToString()),
                        TotalShifts = row["TotalShifts"] == DBNull.Value ? 0 : int.Parse(row["TotalShifts"].ToString()),
                        PayslipFormat = row["PayslipFormat"].ToString(),
                        Initials = row["Initials"] != DBNull.Value ? row["Initials"].ToString() : string.Empty,

                        DutyAllowanceRate = row["DutyAllowanceRate"] != DBNull.Value ? Convert.ToDecimal(row["DutyAllowanceRate"]) : 0,
                        AuthenticationType = row["AuthenticationType"] != DBNull.Value ? Convert.ToInt32((int)row["AuthenticationType"]) : 0
                    
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return companies;
        }
        #endregion

        #region ShowImage
        public Company ShowImage()
        {
            Company company = new Company();
            try
            {
                string query = "SELECT CompanyInfo.ID,CompanyInfo.Logo From CompanyInfo";
                DataTable table = dal.ExecuteReader(query);
                foreach (Company co in ShowImageData(table))
                {
                    company = co;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return company;
        }
        #endregion

        #region ShowImageData
        private IList<Company> ShowImageData(DataTable table)
        {
            IList<Company> companies = new List<Company>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Company company = new Company()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Logo = row["Logo"] == DBNull.Value ? null : Global.ArrayToImage((byte[])row["Logo"]),
                    };
                    companies.Add(company);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return companies;
        }
        #endregion
    }
}
 