using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;

namespace HRBussinessLayer.System_Setup_Class
{
    public class Company
    {
        private int id;
        private string name;
        private string postalAddress;
        private string emailAddress;
        private string website;
        private string contactNos;
        private string faxNos;
        private Country country;
        private int minimumCharacter;
        private int pinMinimumCharacter;
        private bool isSalaryStructure;
        private string character;
        private Region region;
        private District district;
        private Town town;
        private HealthFacilityType facilityType;
        private HealthFacilityOwnership ownershipType;
        private Nullable<DateTime> dateEstabished;
        private string initials;
        private string motto;
        private int pensionAgeMale;
        private int pensionAgeFemale;
        private string paymentFrequency;
        private Image logo;
        private bool salary;
        private decimal minimumSalary;
        private string salaryPaymentUnit;
        private bool wage;
        private decimal minimumWage;
        private string wagePaymentUnit;
        private decimal minimumOverTime;
        private string ssnitRegistrationNo;
        
        private string overTimeType;
        private decimal overTimeAmount;
        private bool overTime;
        private string calculatedOn;
        private int minimumEmployeeAge;
        private int maximumEmployeeAge;
        private string initialStaffID;
        private bool isFileNumber;
        private int totalShifts;
        private string _payslipFormat;
        private int authenticationType;

        private decimal dutyAllowanceRate;
        private bool automaticPromotionFlag;


        public Company()
        {
            try
            {
                this.id = 0;
                this.name = string.Empty;
                this.postalAddress = string.Empty;
                this.emailAddress = string.Empty;
                this.initialStaffID = string.Empty;
                this.minimumCharacter = 1;
                this.pinMinimumCharacter = 1;
                this.isSalaryStructure = false;
                this.character = string.Empty;
                this.website = string.Empty;
                this.contactNos = string.Empty;
                this.faxNos = string.Empty;
                this.country = new Country();
                this.region = new Region();
                this.district = new District();
                this.town = new Town();
                this.facilityType = new HealthFacilityType();
                this.ownershipType = new HealthFacilityOwnership();
                this.dateEstabished = null;
                this.motto = string.Empty;
                this.pensionAgeMale = 0;
                this.pensionAgeFemale = 0;
                this.minimumEmployeeAge = 0;
                this.maximumEmployeeAge = 0;
                this.salary = false;
                this.minimumSalary = 0;
                this.salaryPaymentUnit = string.Empty;
                this.wage = false;
                this.minimumWage = 0;
                this.wagePaymentUnit = string.Empty;
                this.paymentFrequency = string.Empty;
                this.initials = string.Empty;
                this.logo = null;
                this.minimumOverTime = 0;
                this.overTimeAmount = 0;
                this.overTimeType = string.Empty;
                this.overTime = false;
                this.calculatedOn = string.Empty;
                this.ssnitRegistrationNo = string.Empty;
                this.isFileNumber = false;
                this.totalShifts = 0;
                this._payslipFormat = "Default";
                this.authenticationType = 0;

                this.dutyAllowanceRate = 0;
                this.automaticPromotionFlag = false;

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

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PayslipFormat
        {
            get { return _payslipFormat; }
            set { _payslipFormat = value; }
        }

        public string SSNITRegistrationNo
        {
            get { return ssnitRegistrationNo; }
            set { ssnitRegistrationNo = value; }
        }

        public string PostalAddress
        {
            get { return postalAddress; }
            set { postalAddress = value; }
        }

        public string Character
        {
            get { return character; }
            set { character = value; }
        }

        public string InitialStaffID
        {
            get { return initialStaffID; }
            set { initialStaffID = value; }
        }

        public int MinimumCharacter
        {
            get { return minimumCharacter; }
            set { minimumCharacter = value; }
        }

        public int PINMinimumCharacter
        {
            get { return pinMinimumCharacter; }
            set { pinMinimumCharacter = value; }
        }

        public bool IsSalaryStructure
        {
            get { return isSalaryStructure; }
            set { isSalaryStructure = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public string ContactNos
        {
            get { return contactNos; }
            set { contactNos = value; }
        }

        public string FaxNos
        {
            get { return faxNos; }
            set { faxNos = value; }
        }

        public Country Country
        {
            get { return country; }
            set { country = value; }
        }

        public Region Region
        {
            get { return region; }
            set { region = value; }
        }

        public District District
        {
            get { return district; }
            set { district = value; }
        }

        public Town Town
        {
            get { return town; }
            set { town = value; }
        }

        public HealthFacilityOwnership OwnershipType
        {
            get { return ownershipType; }
            set { ownershipType = value; }
        }

        public HealthFacilityType FacilityType
        {
            get { return facilityType; }
            set { facilityType = value; }
        }

        public Nullable<DateTime> DateEstabished
        {
            get { return dateEstabished; }
            set { dateEstabished = value; }
        }
        public string Motto
        {
            get { return motto; }
            set { motto = value; }
        }

        public int MaximumEmployeeAge
        {
            get { return maximumEmployeeAge; }
            set { maximumEmployeeAge = value; }
        }
        public int PensionAgeMale
        {
            get { return pensionAgeMale; }
            set { pensionAgeMale = value; }
        }

        public int PensionAgeFemale
        {
            get { return pensionAgeFemale; }
            set { pensionAgeFemale = value; }
        }
        public bool Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public bool Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public decimal MinimumSalary
        {
            get { return minimumSalary; }
            set { minimumSalary = value; }
        }

        public string SalaryPaymentUnit
        {
            get { return salaryPaymentUnit; }
            set { salaryPaymentUnit = value; }
        }

        public string PaymentFrequency 
        {
            get { return paymentFrequency; }
            set { paymentFrequency = value; }
        }

        public Image Logo
        {
            get { return logo; }
            set { logo = value; }
        }
        public string Initials
        {
            get { return initials; }
            set { initials = value; }
        }
        public decimal MinimumWage
        {
            get { return minimumWage; }
            set { minimumWage = value; }
        }

        public string WagePaymentUnit
        {
            get { return wagePaymentUnit; }
            set { wagePaymentUnit = value; }
        }

        public decimal MinimumOverTime
        {
            get { return minimumOverTime; }
            set { minimumOverTime = value; }
        }

        public string OverTimeType
        {
            get { return overTimeType; }
            set { overTimeType = value; }
        }

        public decimal OverTimeAmount
        {
            get { return overTimeAmount; }
            set { overTimeAmount = value; }
        }

        public bool OverTime
        {
            get { return overTime; }
            set { overTime = value; }
        }

        public string CalulatedOn
        {
            get { return calculatedOn; }
            set { calculatedOn = value; }
        }

        public int MinimumEmployeeAge
        {
            get { return minimumEmployeeAge; }
            set { minimumEmployeeAge = value; }
        }

        public bool IsFileNumber
        {
            get { return isFileNumber; }
            set { isFileNumber = value; }
        }

        public bool AutomaticPromotionFlag
        {
            get { return automaticPromotionFlag; }
            set { automaticPromotionFlag = value; }
        }

        public int TotalShifts
        {
            get { return totalShifts; }
            set { totalShifts = value; }
        }

        public int AuthenticationType
        {
            get { return authenticationType; }
            set { authenticationType = value; }
        }

        public decimal DutyAllowanceRate
        {
            get { return dutyAllowanceRate; }
            set { dutyAllowanceRate = value; }
        }

    }
}
