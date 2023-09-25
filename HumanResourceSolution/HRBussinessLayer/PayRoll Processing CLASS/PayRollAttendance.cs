using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.PayRoll_Processing_CLASS
{
    public class PayRollAttendance
    {
        private int id;
        private int paymentID;
        private string name;
        private string firstName;
        private string lastName;
        private string otherName;
        private Employee employee;
        private string attendance;
        private int month;
        private int year;
        private decimal basicSalary;
        private decimal ssnitEmployee;
        private decimal ssnitEmployer;
        private decimal ssnitFirstTier;
        private decimal secondTier;
        private decimal providentFundEmployee;
        private decimal providentFundEmployer;
        private decimal taxableIncome;
        private decimal incomeTax;
        private decimal netAfterTax;
        private decimal medicalClaims;
        private decimal arrears;
        private string paymentMode;
        private Department department;
        private Unit unit;
        private Zone zone;
        private bool ssnit;
        private bool isProvidentFund;
        private bool isExemptAllowance;
        private bool isExemptDeduction;
        private string ssnitNo;
        private GradeCategory gradeCategory;
        private EmployeeGrade grade;
        private JobTitle jobTitle;
        private Band band;
        private bool mechanised;
        private decimal netSalary;
        private decimal grossSalary;
        private decimal takeHome;
        private string status;
        private StaffBank staffBank;
        private IList<StaffDeduction> deductions;
        private IList<StaffAllowance> allowances;
        private IList<StaffLoan> loans;
        private IList<OverTime> overTimes;
        private decimal grandTotalAllowance;
        private decimal grandTotalDeductions;
        private decimal totalAllowance;
        private decimal totalDeductions;
        private decimal initialLoan;
        private decimal totalLoans;
        private decimal ssnitEmployerRate;
        private decimal ssnitEmployeeRate;
        private decimal ssnitFirstTierRate;
        private decimal secondTierRate;
        private decimal providentFundEmployeeRate;
        private decimal providentFundEmployerRate;
        private User user;
        private decimal susuPlusContributionAmount;
        private decimal withholdingTaxFixedAmount;
        private decimal withholdingTaxRate;
        private decimal withholdingAmount;
        private SalaryType salaryType;
        private decimal totalOverTime;
        private decimal totalOverTimeHours;
        private decimal publicHolidayOverTime;
        private decimal publicHolidayOverTimeHours;
        private decimal dailyOverTime;
        private decimal dailyOverTimeHours;
        private decimal hoursWorked;
        private decimal actualBasicSalary;

        private decimal weekendOverTime;
        private decimal weekendOverTimeHours;
        private decimal sundayOverTime;
        private decimal sundayOverTimeHours;
        private decimal saturdayOverTime;
        private decimal saturdayOverTimeHours;

        private decimal nightOverTime;
        private decimal nightOverTimeHours;
        private decimal annualLeaveBalance;
        private decimal annualLeaveBalanceMonthly;
        private decimal annualLeave;
        private decimal annualLeaveMonthly;
        private decimal totalOverTimeTax;
        private decimal totalBonus;
        private decimal totalBonusTax;
        private decimal salaryAdvance;
        private decimal wageAdvance;
        private decimal totalTax;
        private string step;
        private decimal nonAllowanceTax;
        private decimal allowanceTax;
        private string overseer;
        private decimal upfrontRelief;
        private decimal exemptFirstTierRate;
        private decimal totalCost;
        private decimal totalPayable;


        public PayRollAttendance()
        {
            try
            {
                this.id = 0;
                this.paymentID = 0;
                this.name = string.Empty;
                this.firstName = string.Empty;
                this.lastName = string.Empty;
                this.otherName = string.Empty;
                this.employee = new Employee();
                this.ssnit = false;
                this.isProvidentFund = false;
                this.isExemptAllowance = false;
                this.isExemptDeduction = false;
                this.ssnitNo = string.Empty;
                this.attendance = "N/A";
                this.month = 0;
                this.year = 0;
                this.basicSalary = 0;
                this.withholdingAmount = 0;
                this.ssnitEmployee = 0;
                this.ssnitEmployer = 0;
                this.ssnitFirstTier = 0;
                this.secondTier = 0;
                this.providentFundEmployee = 0;
                this.providentFundEmployer = 0;
                this.incomeTax = 0;
                this.netAfterTax = 0;
                this.staffBank = new StaffBank();
                this.user = new User();
                this.medicalClaims = 0;
                this.arrears = 0;
                this.grossSalary = 0;
                this.taxableIncome = 0;
                this.netSalary = 0;
                this.takeHome = 0;
                this.paymentMode = string.Empty;
                this.department = new Department();
                this.unit = new Unit();
                this.zone = new Zone();
                this.jobTitle = new JobTitle();
                this.gradeCategory = new GradeCategory();
                this.grade = new EmployeeGrade();
                this.band = new Band();
                this.mechanised = false;
                this.status = string.Empty;
                this.deductions = new List<StaffDeduction>();
                this.allowances = new List<StaffAllowance>();
                this.loans = new List<StaffLoan>();
                this.overTimes = new List<OverTime>();
                this.grandTotalAllowance = 0;
                this.grandTotalDeductions = 0;
                this.totalAllowance = 0;
                this.totalDeductions = 0;
                this.totalLoans = 0;
                this.initialLoan = 0;
                this.ssnitEmployerRate = 0;
                this.ssnitEmployeeRate = 0;
                this.ssnitFirstTierRate = 0;
                this.secondTierRate = 0;
                this.providentFundEmployeeRate = 0;
                this.providentFundEmployerRate = 0;
                this.susuPlusContributionAmount = 0;
                this.withholdingTaxFixedAmount = 0;
                this.withholdingTaxRate = 0;
                this.salaryType = new SalaryType();
                this.totalOverTime = 0;
                this.totalOverTimeHours = 0;
                this.publicHolidayOverTime = 0;
                this.publicHolidayOverTimeHours = 0;
                this.dailyOverTime = 0;
                this.dailyOverTimeHours = 0;
                this.hoursWorked = 0;
                this.actualBasicSalary = 0;

                this.weekendOverTime=0;
                this.weekendOverTimeHours=0;
                this.saturdayOverTime = 0;
                this.saturdayOverTimeHours = 0;
                this.sundayOverTime = 0;
                this.sundayOverTimeHours = 0;

                this.nightOverTime=0;
                this.nightOverTimeHours=0;
                this.annualLeaveBalance=0;
                this.annualLeaveBalanceMonthly = 0;
                this.annualLeave = 0;
                this.annualLeaveMonthly = 0;
                this.totalOverTimeTax = 0;
                this.totalBonus = 0;
                this.totalBonusTax = 0;
                this.salaryAdvance = 0;
                this.wageAdvance = 0;
                this.totalTax = 0;
                this.step = string.Empty;
                this.nonAllowanceTax = 0;
                this.allowanceTax = 0;
                this.overseer = string.Empty;
                this.upfrontRelief = 0;
                this.exemptFirstTierRate = 0;
                this.totalCost = 0;
                this.totalPayable = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string OtherName
        {
            get { return otherName; }
            set { otherName = value; }
        }

        public Employee Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        public bool SSNIT
        {
            get { return ssnit; }
            set { ssnit = value; }
        }

        public bool IsProvidentFund
        {
            get { return isProvidentFund; }
            set { isProvidentFund = value; }
        }

        public bool IsExemptAllowance
        {
            get { return isExemptAllowance; }
            set { isExemptAllowance = value; }
        }

        public bool IsExemptDeduction
        {
            get { return isExemptDeduction; }
            set { isExemptDeduction = value; }
        }

        public string SsnitNo
        {
            get { return ssnitNo ; }
            set { ssnitNo = value; }
        }

        public string Attendance
        {
            get { return attendance; }
            set { attendance = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public StaffBank StaffBank
        {
            get { return staffBank; }
            set { staffBank = value; }
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public decimal ActualBasicSalary
        {
            get { return actualBasicSalary; }
            set { actualBasicSalary = value; }
        }

        public decimal GrossSalary
        {
            get { return grossSalary; }
            set { grossSalary = value; }
        }

        public decimal GrandTotalDeductions
        {
            get { return grandTotalDeductions; }
            set { grandTotalDeductions = value; }
        }

        public decimal GrandTotalAllowance
        {
            get { return grandTotalAllowance; }
            set { grandTotalAllowance = value; }
        }

        public decimal TaxableIncome
        {
            get { return taxableIncome; }
            set { taxableIncome = value; }
        }

        public decimal SSNITEmployer
        {
            get { return ssnitEmployer; }
            set { ssnitEmployer = value; }
        }

        public decimal SSNITEmployee
        {
            get { return ssnitEmployee; }
            set { ssnitEmployee = value; }
        }

        public decimal SSNITFirstTier
        {
            get { return ssnitFirstTier; }
            set { ssnitFirstTier = value; }
        }

        public decimal SecondTier
        {
            get { return secondTier; }
            set { secondTier = value; }
        }

        public decimal ProvidentFundEmployee
        {
            get { return providentFundEmployee; }
            set { providentFundEmployee = value; }
        }

        public decimal ProvidentFundEmployer
        {
            get { return providentFundEmployer; }
            set { providentFundEmployer = value; }
        }

        public decimal IncomeTax
        {
            get { return incomeTax; }
            set { incomeTax = value; }
        }

        public decimal NetAfterTax
        {
            get { return netAfterTax; }
            set { netAfterTax = value; }
        }

        public IList<StaffDeduction> Deductions
        {
            get { return deductions; }
            set { deductions = value; }
        }

        public IList<StaffAllowance> Allowances
        {
            get { return allowances; }
            set { allowances = value; }
        }

        public decimal MedicalClaims
        {
            get { return medicalClaims; }
            set { medicalClaims = value; }
        }

        public decimal Arrears
        {
            get { return arrears; }
            set { arrears = value; }
        }

        public string PaymentMode
        {
            get { return paymentMode; }
            set { paymentMode = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public Zone Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public JobTitle JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public GradeCategory GradeCategory
        {
            get { return gradeCategory; }
            set { gradeCategory = value; }
        }

        public EmployeeGrade Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Band Band
        {
            get { return band; }
            set { band = value; }
        }

        public bool Mechanised
        {
            get { return mechanised; }
            set { mechanised = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public decimal NetSalary
        {
            get { return netSalary; }
            set { netSalary = value; }
        }

        public IList<StaffLoan> Loans
        {
            get { return loans; }
            set { loans = value; }
        }

        public IList<OverTime> OverTimes
        {
            get { return overTimes; }
            set { overTimes = value; }
        }

        public decimal TakeHome
        {
            get { return takeHome; }
            set { takeHome = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public decimal TotalAllowance
        {
            get { return totalAllowance; }
            set { totalAllowance = value; }
        }

        public decimal TotalDeductions
        {
            get { return totalDeductions; }
            set { totalDeductions = value; }
        }

        public decimal InitialLoan
        {
            get { return initialLoan; }
            set { initialLoan = value; }
        }

        public decimal TotalLoans
        {
            get { return totalLoans; }
            set { totalLoans = value; }
        }

        public decimal SsnitEmployerRate
        {
            get { return ssnitEmployerRate; }
            set { ssnitEmployerRate = value; }
        }

        public decimal SsnitEmployeeRate
        {
            get { return ssnitEmployeeRate; }
            set { ssnitEmployeeRate = value; }
        }

        public decimal SSNITFirstTierRate
        {
            get { return ssnitFirstTierRate; }
            set { ssnitFirstTierRate = value; }
        }

        public decimal SecondTierRate
        {
            get { return secondTierRate; }
            set { secondTierRate = value; }
        }

        public decimal ProvidentFundEmployeeRate
        {
            get { return providentFundEmployeeRate; }
            set { providentFundEmployeeRate = value; }
        }

        public decimal ProvidentFundEmployerRate
        {
            get { return providentFundEmployerRate; }
            set { providentFundEmployerRate = value; }
        }

        public decimal SusuPlusContributionAmount
        {
            get { return susuPlusContributionAmount; }
            set { susuPlusContributionAmount = value; }
        }


        public decimal WithholdingTaxFixedAmount
        {
            get { return withholdingTaxFixedAmount; }
            set { withholdingTaxFixedAmount = value; }
        }

        public decimal WithholdingTaxRate
        {
            get { return withholdingTaxRate; }
            set { withholdingTaxRate = value; }
        }

        public decimal WithholdingAmount
        {
            get { return withholdingAmount; }
            set { withholdingAmount = value; }
        }

        public SalaryType SalaryType
        {
            get { return salaryType; }
            set { salaryType = value; }
        }

        public decimal TotalOverTime
        {
            get { return totalOverTime; }
            set { totalOverTime = value; }
        }

        public decimal TotalOverTimeHours
        {
            get { return totalOverTimeHours; }
            set { totalOverTimeHours = value; }
        }

        public decimal PublicHolidayOverTime
        {
            get { return publicHolidayOverTime; }
            set { publicHolidayOverTime = value; }
        }

        public decimal PublicHolidayOverTimeHours
        {
            get { return publicHolidayOverTimeHours; }
            set { publicHolidayOverTimeHours = value; }
        }


        public decimal DailyOverTime
        {
            get { return dailyOverTime; }
            set { dailyOverTime = value; }
        }

        public decimal DailyOverTimeHours
        {
            get { return dailyOverTimeHours; }
            set { dailyOverTimeHours = value; }
        }

        public decimal HoursWorked
        {
            get { return hoursWorked; }
            set { hoursWorked = value; }
        }


        public decimal WeekendOverTime
        {
            get { return weekendOverTime; }
            set { weekendOverTime = value; }
        }

        public decimal WeekendOverTimeHours
        {
            get { return weekendOverTimeHours; }
            set { weekendOverTimeHours = value; }
        }

        public decimal SaturdayOverTime
        {
            get { return saturdayOverTime; }
            set { saturdayOverTime = value; }
        }

        public decimal SaturdayOverTimeHours
        {
            get { return saturdayOverTimeHours; }
            set { saturdayOverTimeHours = value; }
        }

        public decimal SundayOverTime
        {
            get { return sundayOverTime; }
            set { sundayOverTime = value; }
        }

        public decimal SundayOverTimeHours
        {
            get { return sundayOverTimeHours; }
            set { sundayOverTimeHours = value; }
        }

        public decimal NightOverTime
        {
            get { return nightOverTime; }
            set { nightOverTime = value; }
        }

        public decimal NightOverTimeHours
        {
            get { return nightOverTimeHours; }
            set { nightOverTimeHours = value; }
        }

        public decimal AnnualLeaveBalance
        {
            get { return annualLeaveBalance; }
            set { annualLeaveBalance = value; }
        }

        public decimal AnnualLeaveBalanceMonthly
        {
            get { return annualLeaveBalanceMonthly; }
            set { annualLeaveBalanceMonthly = value; }
        }


        public decimal AnnualLeave
        {
            get { return annualLeave; }
            set { annualLeave = value; }
        }

        public decimal AnnualLeaveMonthly
        {
            get { return annualLeaveMonthly; }
            set { annualLeaveMonthly = value; }
        }

        public decimal TotalOverTimeTax
        {
            get { return totalOverTimeTax; }
            set { totalOverTimeTax = value; }
        }

        public decimal TotalBonus
        {
            get { return totalBonus; }
            set { totalBonus = value; }
        }

        public decimal TotalBonusTax
        {
            get { return totalBonusTax; }
            set { totalBonusTax = value; }
        }


        public decimal SalaryAdvance
        {
            get { return salaryAdvance; }
            set { salaryAdvance = value; }
        }

        public decimal WageAdvance
        {
            get { return wageAdvance; }
            set { wageAdvance = value; }
        }

        public decimal TotalTax
        {
            get { return totalTax; }
            set { totalTax = value; }
        }

        public string Step
        {
            get { return step; }
            set { step = value; }
        }

        public decimal NonAllowanceTax
        {
            get { return nonAllowanceTax; }
            set { nonAllowanceTax = value; }
        }

        public decimal AllowanceTax
        {
            get { return allowanceTax; }
            set { allowanceTax = value; }
        }

        public string Overseer
        {
            get { return overseer; }
            set { overseer = value; }
        }

        public decimal UpfrontRelief
        {
            get { return upfrontRelief; }
            set { upfrontRelief = value; }
        }

        public decimal ExemptFirstTierRate
        {
            get { return exemptFirstTierRate; }
            set { exemptFirstTierRate = value; }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public decimal TotalPayable
        {
            get { return totalPayable; }
            set { totalPayable = value; }
        }

    }
}
