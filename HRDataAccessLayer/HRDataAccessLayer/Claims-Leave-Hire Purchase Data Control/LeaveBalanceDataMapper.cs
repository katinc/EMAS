using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;


namespace HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control
{
    public class LeaveBalanceDataMapper
    {
        List<LeaveBalance> leaveBalances;
        //EmployeeDataMapper employeeDataMapper;
        DALHelper dalHelper;
        // private int userId;

        public LeaveBalanceDataMapper()
        {
            leaveBalancesEmp = new List<Employee>();
        }

        public LeaveBalance GetData(int staffId, int month, int annualLeaveYear)
        {
            try
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@staffId", staffId, DbType.Int32);
                dalHelper.CreateParameter("@Month", month, DbType.Int32);
                dalHelper.CreateParameter("@AnnualLeaveYear", annualLeaveYear, DbType.Int32);

                var dt = dalHelper.ExecuteReader("select * from StaffLeaveBalancesView where Month=@Month and AnnualLeaveYear=@AnnualLeaveYear and staffId=@staffId");

                DataMapper(dt);

                return leaveBalances.FirstOrDefault();
            }
            catch (Exception xi)
            {
                return new LeaveBalance();
            }
        }
        private List<Employee> leaveBalancesEmp;

        public bool ComputeLeaveBalances(Employee employee, int Month, int Year, int monthEnd)
        {
            //employeeDataMapper = new EmployeeDataMapper();
            bool ctr = false;
            try
            {
                if (!leaveBalancesEmp.Contains(employee))
                {
                    leaveBalancesEmp.Add(employee);

                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@StaffId", employee.ID, DbType.Int32);
                    dalHelper.CreateParameter("@Month", Month, DbType.Int32);
                    dalHelper.CreateParameter("@Year", Year, DbType.Int32);

                    dalHelper.ExecuteNonQuery("delete StaffLeaveBalances where StaffId=@StaffId and Month=@Month and AnnualLeaveYear=@Year");

                    //var leaveBalance = GetData(employee.ID, Month, Year);
                    //if (leaveBalance == null)
                    LeaveBalance leaveBalance = new LeaveBalance();

                    leaveBalance.leaveType = "Annual Leave";
                    leaveBalance.leaveTaken = getLeaveTaken(Year, Month, employee.ID);
                    leaveBalance.leaveArrears = getMyLeaveArrears(Year, Month, employee.ID);
                    leaveBalance.AnnualLeave = (int)getYearAnnualLeave(Year, employee.ID);
                    leaveBalance.leaveBalance = (leaveBalance.AnnualLeave + leaveBalance.leaveArrears) - leaveBalance.leaveTaken;
                    // leaveBalance.leaveArrears = employee.LeaveArrears;
                    leaveBalance.employee = employee;
                    leaveBalance.AnnualLeaveYear = Year;
                    leaveBalance.month = Month;
                    monthEnd = employee.EmploymentDate.Value.Month;

                    ctr = AddOrUpdate(leaveBalance, monthEnd);
                    //employee.LeaveArrears = (int)leaveBalance.leaveArrears;
                    //employeeDataMapper.Save(employee);
                }

            }
            catch (Exception xi) { }
            return ctr;
        }


        public bool AddOrUpdate(LeaveBalance leaveBalance, int monthEnd)
        {
            try
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@leaveType", leaveBalance.leaveType, DbType.String);
                dalHelper.CreateParameter("@leaveTaken", leaveBalance.leaveTaken, DbType.Decimal);
                dalHelper.CreateParameter("@leaveArrears", leaveBalance.leaveArrears, DbType.Decimal);
                dalHelper.CreateParameter("@leaveBalance", leaveBalance.leaveBalance, DbType.Decimal);
                dalHelper.CreateParameter("@AnnualLeave", leaveBalance.AnnualLeave, DbType.Int32);
                dalHelper.CreateParameter("@EngagementMonth", monthEnd, DbType.Int16);


                if (leaveBalance.ID > 0)
                {
                    dalHelper.CreateParameter("@ID", leaveBalance.ID, DbType.Int32);
                    dalHelper.ExecuteNonQuery("update staffLeaveBalances set leaveType=@leaveType,leaveTaken=@leaveTaken,leaveArrears=@leaveArrears,leaveBalance=@leaveBalance,AnnualLeave=@AnnualLeave, EngagementMonth=@MonthEndwhere ID=@ID");
                }
                else
                {
                    dalHelper.CreateParameter("@month", leaveBalance.month, DbType.Int32);
                    dalHelper.CreateParameter("@AnnualLeaveYear", leaveBalance.AnnualLeaveYear, DbType.Int32);
                    dalHelper.CreateParameter("@staffId", leaveBalance.employee.ID, DbType.Int32);

                    dalHelper.ExecuteNonQuery("insert into staffLeaveBalances (leaveType,leaveTaken,leaveArrears,leaveBalance,month,AnnualLeaveYear,staffId,AnnualLeave, EngagementMonth) values(@leaveType,@leaveTaken,@leaveArrears,@leaveBalance,@month,@AnnualLeaveYear,@staffId,@AnnualLeave,@EngagementMonth)");
                }
                return true;
            }
            catch (Exception xi)
            {
                return false;
            }
        }

        public bool Add(LeaveBalance newLeaveBalance)
        {
            var leaveBalance = newLeaveBalance;
            try
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@leaveType", leaveBalance.leaveType, DbType.String);
                dalHelper.CreateParameter("@leaveTaken", leaveBalance.leaveTaken, DbType.Decimal);
                dalHelper.CreateParameter("@leaveArrears", leaveBalance.leaveArrears, DbType.Decimal);
                dalHelper.CreateParameter("@leaveBalance", leaveBalance.leaveBalance, DbType.Decimal);


                dalHelper.CreateParameter("@month", leaveBalance.month, DbType.Int32);
                dalHelper.CreateParameter("@AnnualLeaveYear", leaveBalance.AnnualLeaveYear, DbType.Int32);
                dalHelper.CreateParameter("@staffId", leaveBalance.employee.ID, DbType.Int32);

                dalHelper.ExecuteNonQuery("insert into staffLeaveBalances (leaveType,leaveTaken,leaveArrears,leaveBalance,month,AnnualLeaveYear,staffId) values(@leaveType,@leaveTaken,@leaveArrears,@leaveBalance,@month,@AnnualLeaveYear,@staffId)");

                return true;
            }
            catch (Exception xi)
            {
                return false;
            }
        }
        public decimal getYearAnnualLeave(int year, int StaffCode)
        {
            try
            {
                DALHelper dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
                dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);
                //dalHelper.CreateParameter("@UserID", this.userId, DbType.Int32);

                var annualLeave = dalHelper.ExecuteScalar("select NumberOfDays from AnnualLeaveCalculationsClearedDups  where StaffCode=@StaffCode and Year=@AnnualLeaveYear and Archived='false'");

                if (annualLeave != null && annualLeave.ToString() != string.Empty)
                    return Convert.ToDecimal(annualLeave);
            }
            catch (Exception xi) { }
            return 0;
        }
        public decimal getBeginToDateAnnualLeave(int year, int StaffCode)
        {
            try
            {
                DALHelper dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
                dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);
                //dalHelper.CreateParameter("@UserID", this.userId, DbType.Int32);

                var annualLeave = dalHelper.ExecuteScalar("select sum(NumberOfDays) from AnnualLeaveCalculationsClearedDups  where StaffCode=@StaffCode and Year<=@AnnualLeaveYear and Archived='false'  ");

                if (annualLeave != null)
                    return Convert.ToDecimal(annualLeave);
            }
            catch (Exception xi) { }
            return 0;
        }
        public decimal getLeaveTaken(int year, int month, int StaffCode)
        {
            try
            {
                DALHelper dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
                dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);
                dalHelper.CreateParameter("@Month", month, DbType.Int32);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);

                var taken = dalHelper.ExecuteScalar("select sum(NumberOfDays) from StaffLeaveView  where LeaveType='Annual Leave' and Rejected='false' and Archived='false' and LeaveYear=@AnnualLeaveYear and month(StartDate)<=@Month and Archived = @Archived and StaffCode=@StaffCode ");

                if (taken != null)
                    return Convert.ToDecimal(taken);
            }
            catch (Exception xi) { }
            return 0;
        }

        public decimal getBeginToDateLeaveTaken(int year, int month, int StaffCode)
        {
            try
            {
                DALHelper dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
                dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);
                //dalHelper.CreateParameter("@Month", month, DbType.Int32);
                ///dalHelper.CreateParameter("@UserID", this.userId, DbType.Int32);

                var taken = dalHelper.ExecuteScalar("select sum(NumberOfDays) from StaffLeaveView  where LeaveType='Annual Leave' and Rejected='false' and Archived='false' and LeaveYear<=@AnnualLeaveYear and StaffCode=@StaffCode ");

                if (taken != null)
                    return Convert.ToDecimal(taken);
            }
            catch (Exception xi) { }
            return 0;
        }

        //public decimal getYTDLeaveTaken(int year, int StaffCode)
        //{
        //    try
        //    {
        //        DALHelper dalHelper = new DALHelper();
        //        dalHelper.ClearParameters();

        //        dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
        //        dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);

        //        var taken = dalHelper.ExecuteScalar("select sum(NumberOfDays) from StaffLeaveView  where LeaveType='Annual Leave' and Rejected='false' and LeaveYear=@AnnualLeaveYear and StaffCode=@StaffCode");

        //        if (taken != null)
        //            return Convert.ToDecimal(taken);
        //    }
        //    catch (Exception xi) { }
        //    return 0;
        //}
        //public decimal getLeaveTaken(int maxyear,int minyear, int StaffCode)
        //{
        //    try
        //    {
        //        DALHelper dalHelper = new DALHelper();
        //        dalHelper.ClearParameters();

        //        dalHelper.CreateParameter("@AnnualLeaveYear", year, DbType.Int32);
        //        dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);

        //        var taken = dalHelper.ExecuteScalar("select sum(NumberOfDays) from StaffLeaveView  where LeaveType='Annual Leave' and Rejected='false' and LeaveYear=@AnnualLeaveYear and StaffCode=@StaffCode");

        //        if (taken != null)
        //            return Convert.ToDecimal(taken);
        //    }
        //    catch (Exception xi) { }
        //    return 0;
        //}
        public decimal getMyLeaveArrears(int Year, int Month, int staffCode)
        {
            try
            {
                decimal PrevYearAnnualLeave = getBeginToDateAnnualLeave(Year - 1, staffCode);
                decimal PrevYearLeaveTaken = getBeginToDateLeaveTaken(Year - 1, Month, staffCode);

                decimal leaveArrears = PrevYearAnnualLeave - PrevYearLeaveTaken;

                return leaveArrears;
            }
            catch (Exception xi)
            {
                return 0;
            }

        }
        //public  decimal getleaveArrears(int year, int StaffCode)
        //{

        //    try
        //    {
        //        DALHelper dalHelper = new DALHelper();
        //        dalHelper.ClearParameters();

        //        dalHelper.CreateParameter("@AnnualLeaveYear", year - 1, DbType.Int32);
        //        dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);

        //        var balance = dalHelper.ExecuteScalar("select leaveBalance from StaffLeaveView where LeaveType='Annual Leave' and Rejected='false' and id=(select max(id) from StaffLeaveView where LeaveYear=@AnnualLeaveYear and StaffCode=@StaffCode)");

        //        if (balance != null)
        //            return Convert.ToDecimal(balance);
        //        else
        //        {
        //            dalHelper.ClearParameters();
        //            dalHelper.CreateParameter("@Year", year - 1, DbType.Int32);
        //            dalHelper.CreateParameter("@StaffCode", StaffCode, DbType.Int32);

        //            balance = dalHelper.ExecuteScalar("select NumberOfDays from AnnualLeaveCalculations where ID=(select max(ID) from AnnualLeaveCalculations where Year=@Year and StaffCode=@StaffCode and Archived='false')");

        //            if (balance != null)
        //                return Convert.ToDecimal(balance);
        //        }
        //    }
        //    catch (Exception xi) { }
        //    return 0;
        //}
        void DataMapper(DataTable dt)
        {
            leaveBalances = new List<LeaveBalance>();
            //employeeDataMapper = new EmployeeDataMapper();
            foreach (DataRow dataRow in dt.Rows)
            {
                var leaveBalance = new LeaveBalance();
                leaveBalance.AnnualLeaveYear = dataRow["AnnualLeaveYear"] != DBNull.Value ? Convert.ToInt32(dataRow["AnnualLeaveYear"]) : 0;
                leaveBalance.ID = dataRow["ID"] != DBNull.Value ? Convert.ToInt32(dataRow["ID"]) : 0;
                leaveBalance.leaveTaken = dataRow["leaveTaken"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveTaken"]) : 0;
                leaveBalance.leaveType = dataRow["leaveType"] != DBNull.Value ? Convert.ToString(dataRow["leaveTaken"]) : string.Empty;
                leaveBalance.employee = dataRow["StaffId"] != DBNull.Value ? new Employee() { ID = Convert.ToInt32(dataRow["StaffId"]), StaffID = dataRow["empID"] != DBNull.Value ? dataRow["empID"].ToString() : string.Empty, AnnualLeave = dataRow["AnnualLeave"] != DBNull.Value ? Convert.ToInt32(dataRow["AnnualLeave"]) : 0, CasualLeave = dataRow["CasualLeave"] != DBNull.Value ? Convert.ToInt32(dataRow["CasualLeave"]) : 0, LeaveBalance = dataRow["leaveBalance"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveBalance"]) : 0, LeaveArrears = dataRow["leaveArrears"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveArrears"]) : 0, LeaveTaken = dataRow["leaveTaken"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveTaken"]) : 0, AnnualLeaveYear = dataRow["AnnualLeaveYear"] != DBNull.Value ? Convert.ToInt32(dataRow["AnnualLeaveYear"]) : 0 } : leaveBalance.employee;
                leaveBalance.leaveBalance = dataRow["leaveBalance"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveBalance"]) : 0;
                leaveBalance.leaveArrears = dataRow["leaveArrears"] != DBNull.Value ? Convert.ToInt32(dataRow["leaveArrears"]) : 0;
                leaveBalance.month = dataRow["Month"] != DBNull.Value ? Convert.ToInt32(dataRow["Month"]) : 0;
                leaveBalance.AnnualLeave = dataRow["AnnualLeave"] != DBNull.Value ? Convert.ToInt32(dataRow["AnnualLeave"]) : 0;

                leaveBalances.Add(leaveBalance);
            }
        }
    }
}
