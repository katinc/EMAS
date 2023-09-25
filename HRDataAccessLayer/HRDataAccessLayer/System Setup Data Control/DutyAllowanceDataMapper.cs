using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;

namespace HRDataAccessLayer.System_Setup_Data_Control
{
   public class DutyAllowanceDataMapper
    {
       IList<DutyAllowance> lstDutyAllowances;
      
       public DALHelper dalHelper;
       private CompanyDataMapper companyDataMapper;

       private Company company;
       private string Period;
       private int Year;

       public DutyAllowanceDataMapper()
       {
           lstDutyAllowances = new List<DutyAllowance>();
         
           dalHelper = new DALHelper();
           companyDataMapper = new CompanyDataMapper();

           company = companyDataMapper.GetAll().FirstOrDefault();
       }

       public DutyAllowanceDataMapper( string Period, int Year)
       {
           this.Period = Period;
           this.Year = Year;
           lstDutyAllowances = new List<DutyAllowance>();
         
           dalHelper = new DALHelper();
           companyDataMapper = new CompanyDataMapper();

           company = companyDataMapper.GetAll().FirstOrDefault();
       }
       public bool PeriodHasData(string Period, int Year)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Period", Period, DbType.String);
               dalHelper.CreateParameter("@Year", Year, DbType.Int32);

                var count = dalHelper.ExecuteScalar("select count(*) from StaffDutyAllowancesView where [Period]=@Period and [Year]=@Year and Terminated != '1'");

          if (count != null)
              return Convert.ToBoolean(count);
           }
           catch (Exception xi) { }
           
          
              return false;
       }
       public bool Save(DutyAllowance dutyAllowance,string Period,int Year,User user)
       {
           try
           {
               string sql = string.Empty;
               //string where = string.Empty;
               dalHelper.ClearParameters();
               if (dutyAllowance.ID > 0)
               {
                   dalHelper.CreateParameter("@ID", dutyAllowance.ID, DbType.Int32);
                   dalHelper.CreateParameter("@DateModified", DateTime.Now, DbType.DateTime);
                   dalHelper.CreateParameter("@EarnedDutyAllowance", dutyAllowance.EarnedDutyAllowance, DbType.Decimal);
                   dalHelper.CreateParameter("@DaysAbsent", dutyAllowance.DaysAbsent, DbType.Decimal);
                   sql = "update StaffDutyAllowances set DaysAbsent=@DaysAbsent,EarnedDutyAllowance=@EarnedDutyAllowance,DateModified=@DateModified where ID=@ID";
               }
               else
               {
                  

                   sql = "insert into StaffDutyAllowances (staffcode,BasicSalary,DutyAllowanceRate,DaysAbsent,EarnedDutyAllowance,Period,Year,PayFrequency,EntryDate)values(@staffcode,@BasicSalary,@DutyAllowanceRate,@DaysAbsent,@EarnedDutyAllowance,@Period,@Year,@PayFrequency,@EntryDate)";
                   dalHelper.CreateParameter("@staffCode", dutyAllowance.Staff.ID, DbType.Int32);
                   dalHelper.CreateParameter("@BasicSalary", dutyAllowance.BasicSalary, DbType.Decimal);
                   dalHelper.CreateParameter("@DutyAllowanceRate", dutyAllowance.DutyAllowanceRate, DbType.Decimal);
                   dalHelper.CreateParameter("@DaysAbsent", dutyAllowance.DaysAbsent, DbType.Decimal);

                   dalHelper.CreateParameter("@Period", Period, DbType.String);
                   dalHelper.CreateParameter("@Year", Year, DbType.Int32);
                   dalHelper.CreateParameter("@PayFrequency", dutyAllowance.PayFrequency, DbType.String);
                   dalHelper.CreateParameter("@EntryDate", DateTime.Now.Date, DbType.DateTime);
                   dalHelper.CreateParameter("@EnteredById", user.ID, DbType.Int32);
                   dalHelper.CreateParameter("@EarnedDutyAllowance", dutyAllowance.EarnedDutyAllowance, DbType.Decimal);
               }

              

               dalHelper.ExecuteNonQuery(sql);
               return true;
           }
           catch (Exception xi)
           {
               return false;
           }
       }
       //public IList<DutyAllowance> getDutyAllowances(string Period,int Year)
       //{
       //    try
       //    {
       //        dalHelper.ClearParameters();
       //        dalHelper.CreateParameter("@Period", Period, DbType.String);
       //        dalHelper.CreateParameter("@Year", Year, DbType.Int32);

       //        DataTable dt;
       //        if (PeriodHasData(Period, Year))
       //        {
       //            dt= dalHelper.ExecuteReader("select * from StaffDutyAllowancesView where Period=@Period and Year=@Year order by  staffID desc");
       //        }
       //        else
       //            dt = dalHelper.ExecuteReader("select * from StaffDutyAllowancesView  order by  staffID desc");

       //        DataMappper(dt);
       //    }
       //    catch (Exception xi) { }
         
       //   return lstDutyAllowances;
       //}
       public IList<DutyAllowance> getDutyAllowances(string StaffID,string name,string Period, int Year,string Department,string Mechanised)
       {
           try
           {
               dalHelper.ClearParameters();
               var where = string.Empty;
               string sql = string.Empty;
               bool periodHasData = false;

               if (PeriodHasData(Period, Year))
               {
                   dalHelper = new DALHelper();
                   dalHelper.ClearParameters();
                   dalHelper.CreateParameter("@Period", Period, DbType.String);
                   dalHelper.CreateParameter("@Year", Year, DbType.Int32);
                   where += " Period=@Period and Year=@Year and ";

                   sql = "select * from StaffDutyAllowancesView ";

                   periodHasData = true;
               }
               else
               {
                   sql = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView ";
                   periodHasData = false;
               }

               where += " Confirmed='true' and TransferredOut='false' and Terminated='false' and Payment='true' and ";

                if (!periodHasData)
                {
                    where += " Archived = 'false' and ";
                }

                if (StaffID != string.Empty)
               {
                   where += " StaffID like '"+StaffID.Trim()+"%' and ";
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
               if (Mechanised.ToLower() != "all" && Mechanised!=string.Empty)
               {
                   where += " Mechanised=@Mechanised and ";
                   dalHelper.CreateParameter("@Mechanised", Mechanised.ToLower()=="yes"?true:false, DbType.Boolean);
               }
               DataTable dt;

               if (where != string.Empty)
                   where = "where " + where.TrimEnd(" and ".ToCharArray());
               sql = sql + where+" order by staffID ";
               dt=dalHelper.ExecuteReader(sql);
               DataMappper(dt,periodHasData);
           }
           catch (Exception xi) { }

           return lstDutyAllowances;
       }
       public int DeleteDutyAllowance(DALHelper newDALHelper,DutyAllowance dutyAllowance,int AllowanceTypeId,int month)
       {
           int ctr = 0;
           try
           {
               newDALHelper.ClearParameters();
               newDALHelper.CreateParameter("@Id", dutyAllowance.ID, DbType.Int32);

               newDALHelper.ExecuteNonQuery("delete StaffDutyAllowances where id=@Id");
               
               StaffAllowanceDataMapper staffAllowanceDataMapper = new StaffAllowanceDataMapper();
               staffAllowanceDataMapper.ArchiveCurrent(newDALHelper, dutyAllowance.Staff.ID, AllowanceTypeId, month);
               ctr++;
           }
           catch (Exception xi)
           {
               
               Logger.LogError(xi);
               
           }
           return ctr;
       }
       public DutyAllowance getDutyAllowance(int Id)
       {
           try
           {
               dalHelper.ClearParameters();
               dalHelper.CreateParameter("@Id", Id, DbType.Int32);

               var dt = dalHelper.ExecuteReader("select * from StaffDutyAllowancesView where id=@Id");

               DataMappper(dt,true);
           }
           catch (Exception xi){}

           return lstDutyAllowances.FirstOrDefault();
       }
       public IList<DutyAllowance> getRetrieveDutyAllowances(DataTable dt)
       {
           DataMappper(dt,true);
           return lstDutyAllowances;
       }
       public void DataMappper(DataTable dt,bool periodHasData)
       {
           try
           {
               lstDutyAllowances.Clear();
               foreach (DataRow dataRow in dt.Rows)
               {
                   DutyAllowance dutyAllowance = new DutyAllowance();
                  

                   if (periodHasData == true)
                   {
                       dutyAllowance.ID = dataRow["ID"] != DBNull.Value ? Convert.ToInt32(dataRow["ID"]) : 0;
                       dutyAllowance.BasicSalary = dataRow["currentBasicSalary"] != DBNull.Value ? Convert.ToDecimal(dataRow["currentBasicSalary"]) : 0;
                       //dutyAllowance.BasicSalary =  dataRow["BasicSalary"] != DBNull.Value ? Convert.ToDecimal(dataRow["BasicSalary"]) : 0;

                       dutyAllowance.Staff = dataRow["ID"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["ID"]), StaffID = Convert.ToString(dataRow["StaffID"]), FirstName = Convert.ToString(dataRow["Firstname"]), Surname = Convert.ToString(dataRow["Surname"]), OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, PaymentType = Convert.ToString(dataRow["PaymentType"]), Department = new Department() { Description = Convert.ToString(dataRow["Department"]), ID = Convert.ToInt32(dataRow["DepartmentID"]) }, Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), BasicSalary = (periodHasData == true) ? Convert.ToDecimal(dataRow["currentBasicSalary"]) : Convert.ToDecimal(dataRow["BasicSalary"]) } : dutyAllowance.Staff;

                       dutyAllowance.Staff = dataRow["staffCode"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["staffCode"]), StaffID = Convert.ToString(dataRow["StaffID"]), FirstName = Convert.ToString(dataRow["Firstname"]), Surname = Convert.ToString(dataRow["Surname"]), OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, PaymentType = Convert.ToString(dataRow["PaymentType"]), Department = new Department() { Description = Convert.ToString(dataRow["Department"]), ID = Convert.ToInt32(dataRow["DepartmentID"]) }, Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), BasicSalary = Convert.ToDecimal(dataRow["currentBasicSalary"]) } : dutyAllowance.Staff;

                       dutyAllowance.DutyAllowanceRate = dataRow["DutyAllowanceRate"] != DBNull.Value ? Convert.ToDecimal(dataRow["DutyAllowanceRate"]) : 0;

                       dutyAllowance.EarnedDutyAllowance = dataRow["EarnedDutyAllowance"] != DBNull.Value ? Convert.ToDecimal(dataRow["EarnedDutyAllowance"]) : 0;

                       dutyAllowance.EntryDate = dataRow["EntryDate"] != DBNull.Value ? Convert.ToDateTime(dataRow["EntryDate"]) : dutyAllowance.EntryDate;


                       dutyAllowance.PayFrequency = dataRow["PayFrequency"] != DBNull.Value ? Convert.ToString(dataRow["PayFrequency"]) : string.Empty;
                       dutyAllowance.Period = dataRow["Period"] != DBNull.Value ? Convert.ToString(dataRow["Period"]) : string.Empty;

                       dutyAllowance.Year = dataRow["Year"] != DBNull.Value ? Convert.ToInt32(dataRow["Year"]) : 0;

                       dutyAllowance.DateModified = dataRow["DateModified"] != DBNull.Value ? Convert.ToDateTime(dataRow["DateModified"]) : dutyAllowance.DateModified;
                       dutyAllowance.EnteredBy = dataRow["EnteredById"] != DBNull.Value ? new User() { ID = Convert.ToInt32(dataRow["EnteredById"]), UserName = dataRow["UserName"] != DBNull.Value ? Convert.ToString(dataRow["UserName"]) : string.Empty, Name = dataRow["UserFullName"] != DBNull.Value ? Convert.ToString(dataRow["UserFullName"]) : string.Empty } : dutyAllowance.EnteredBy;

                       dutyAllowance.DaysAbsent = dataRow["DaysAbsent"] != DBNull.Value ? Convert.ToInt32(dataRow["DaysAbsent"]) : 0;

                   
                   }
                   else
                   {
                       dutyAllowance.ID = 0;
                       dutyAllowance.Staff = dataRow["ID"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["ID"]), StaffID = Convert.ToString(dataRow["StaffID"]), FirstName = Convert.ToString(dataRow["Firstname"]), Surname = Convert.ToString(dataRow["Surname"]), OtherName = dataRow["OtherName"] != DBNull.Value ? Convert.ToString(dataRow["OtherName"]) : string.Empty, PaymentType = Convert.ToString(dataRow["PaymentType"]), Department = new Department() { Description = Convert.ToString(dataRow["Department"]), ID = Convert.ToInt32(dataRow["DepartmentID"]) }, Mechanised = Convert.ToBoolean(dataRow["Mechanised"]), BasicSalary = Convert.ToDecimal(dataRow["BasicSalary"]) } : dutyAllowance.Staff;

                   }
                  
                   
                   if (dutyAllowance.BasicSalary == 0)
                       dutyAllowance.BasicSalary = dutyAllowance.Staff.BasicSalary;

                   

                   if (dutyAllowance.ID == 0)
                       dutyAllowance.DutyAllowanceRate = company.DutyAllowanceRate;
               

                   lstDutyAllowances.Add(dutyAllowance);
               }
           }
           catch (Exception xi)
           {
               Logger.LogError(xi);
           }
          
       }
    }
}
