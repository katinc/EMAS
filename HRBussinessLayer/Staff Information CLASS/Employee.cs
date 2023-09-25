using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO ;
using System.Drawing;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace HRBussinessLayer.Staff_Information_CLASS
{
    public class Titles
    {
        private int id;
        private string description;
        private GenderGroups gender;

      

        public Titles()
        {
            id = 0;
            description = string.Empty;
            gender = GenderGroups.None;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Gender
        {
            get { return gender.ToString(); }
            set { gender = (GenderGroups) Enum.Parse(typeof(GenderGroups),value); }
        }
    }

    public enum MaritalStatusGroups
    {
        None,
        Single,
        Married,
        Widow,
        Widower,
        Divorced,
        LegallySeparated
    }

    public enum GenderGroups
    {
        None,
        All,
        Female,
        Male
    }

    public enum PaymentTypes
    {
        None,
        Salary,
        Cash
    }

    public enum ProbationStatuses
    {
        None,
        Confirmed,
        Not_Confirmed 
    }

    public enum EngagementTypes
    {
        None,
        Contract,
        Limited
    }

    public enum ObjectToSave
    {
        None,
        PersonalInfo,
        WorkPermit,
        Documents,
        Referees,
        EmploymentHistory,
        EducationAndProfession,
        RelationsAndChildren
    }

    public class Employee
    {
        private int id;
        private string fingerPrintID;
        private string staffID;
        private string surname;
        private string firstName;
        private string otherName;
        private string nickName;
        private string pin;
        private bool isInSalaryInfo;
        private decimal oldBasicSalary;
        private string nationalID;
        private string maidenName;
        private string age;
        private decimal pfRate;

        private string tribe;
        private string overseer;
        private Race race;
        private int supervisorCode;
        private string supervisorName;
        private string supervisorStaffID;

        private DisabilityType disabilityType;
        private bool isDisable;
        private Nullable<DateTime> disabilityDate;

        private LicenceType licenceType;
        private string licenceNumber;

        private Nullable<DateTime> incrementDate; 
        private bool payment;

        private SeparationType separationType;
        private bool terminated;
        private Nullable<DateTime> terminationDate;
        private Nullable<DateTime> jobTitleDate;

        private string transferType;
        private bool transferredOut;
        private bool transferredIn;
        private bool transferredInternally;
        private Nullable<DateTime> currentTransferredDate;

        private bool confirmed;
        private Nullable<DateTime> currentConfirmationDate;
        private Nullable<DateTime> currentConfirmationTime;
        private string confirmer;

        private PromotionType promotionType;
        private Nullable<DateTime> currentPromotionDate;

        private int leaveArreas;
        private int annualLeave;
        private AnnualLeaveEntitlement annualLeaveEntitlement;
        private Nullable<DateTime> annualLeaveDate;
        private Nullable<DateTime> annualLeaveProposedStartDate;
        private Nullable<DateTime> annualLeaveProposedEndDate;
        private int annualLeaveProposedDays;
        private int annualLeaveYear;
        private int casualLeave;
        private Nullable<DateTime> casualLeaveDate;
        private int leaveTaken;
        private int leaveBalance;
        private bool onLeave;
        private string leaveStatus;
        private bool onLeaveWithPay;
        private Nullable<DateTime> currentLeaveDate;
        private Nullable<DateTime> currentLeaveStartDate;
        private Nullable<DateTime> currentLeaveEndDate;

        private bool sanctioned;
        private SanctionType sanctionType;
        private Nullable<DateTime> currentSanctionDate;

        private QualificationType qualificationType;
        private GradeCategory gradeCategory;
        private EmployeeGrade grade;
        private Nullable<DateTime> gradeDate;
        private EmployeeGrade gradeOnFirstAppointment;

        private string salaryGrouping;
        private Zone zone;
        private Nullable<DateTime> inZoneDate;
        private Step step;
        private Level salaryLevel;
        private Band band;
        private decimal basicSalary;
        private Nullable<DateTime> birthDate;
        private GenderGroups gender;
        private Titles title;
        private Nationality nationality;
        private Town town;
        private Town homeTown;
        private string telNo;
        private string mobileNo;
        private MaritalStatusGroups maritalStatus;
        private Nullable<DateTime> marriageDate;
        private Religion religion;
        private Town placeOfBirth;
        private HRBussinessLayer.System_Setup_Class.Region regionOfBirth;
        private Country countryOfBirth;
        private District districtOfBirth;
        private int noOfChildren;
        private Denomination denomination;
        private string numberNHIS;
        private string houseNumber;
        private string streetName;
        private Town residentialTown;
        private HRBussinessLayer.System_Setup_Class.Region residentialRegion;
        private Country residentialCountry;
        private string postalAddress;
        private string email;
        private HRBussinessLayer.System_Setup_Class.Region region;
        private Country contactCountry;
        private Town contactHomeTown;
        private Image photo;
        private Department department;
        private Nullable<DateTime> employmentDate;

        private string paymentacctype;
        private bool mechanised;
        private bool ssnitContribution;
        private bool isProvidentFund;
        private bool isExemptFromSecondTier;
        private bool incomeTaxContribution;
        private bool isSusuPlusContribution;
        private decimal susuPlusContributionAmount;
        private bool isWithholdingTax;
        private bool isWithholdingTaxFixedAmount;
        private decimal withholdingTaxFixedAmount;
        private bool isWithholdingTaxRate;
        private decimal withholdingTaxRate;
        private SalaryType salaryType;
        
        private bool probation;
        private Nullable<DateTime> probationStartDate;
        private Nullable<DateTime> probationEndDate;
        private ProbationStatuses probationStatus;
        private string probationApprover;
        private Nullable<DateTime> probationApprovedDate;
        private Nullable<DateTime> probationApprovedTime;

        private string ssnitNo;
        private string tin;
        private PaymentTypes paymentType;
        private bool hourly;
        private byte[] fingerPrint;
        
        private DateTime dateAndTimeGenerated;
        private User user;
        private bool archived;
        private EngagementTypes engagementType;
        private EmployeeGrade engagementGradeOn;
        private EmployeeGrade engagementGradeLeave;
        private Nullable<DateTime> engagementDate;
        private Nullable<DateTime> engagementEffectiveDate;
        private Nullable<DateTime> engagementEndingDate;
        private string engagementContractOption;
        private decimal enagagementAnnualSalary;
        private Nullable<DateTime> doFA;
        private Nullable<DateTime> doCA;
        private Nullable<DateTime> assumptionDate;
        private Specialty specialty;
        private Unit unit;
        private JobTitle jobTitle;
        private OccupationGroup occupationGroup;
        private DateTime serverDate;
        private DateTime serverTime;
        private string fileNumber;
        private string fileLocation;

        private string photoPath;
               
        private WorkPermit workPermit;
        private Visa visa;
        private Passport passport;
        private SocialHistory socialHistory;
        private IList<StaffLanguage> staffLanguage;
        private IList<StaffBank> staffBank;
        private IList<StaffDocument> documents;
        private IList<Qualification> qualifications;
        private IList<Profession> professions;
        private IList<Referee> referees;
        private IList<WorkExperience> workExperiences;
        private IList<Child> children;
        private IList<Relation> otherRelatives;

        private StaffStatus staffStatus;
        private AppointmentType appointmentType;

        //Payroll Processing
        private IList<StaffAllowance> staffAllowances;
        private IList<StaffDeduction> staffDeductions;
        private IList<StaffLoan> staffLoans;
        private IList<MedicalClaims> staffMedicalClaims;
        private IList<StaffSalaryHistory> salaryInfo;

        private ObjectToSave objectToSave;

        public StaffFingerprintTemplates FingerPrintTemplates { get; set; }

        public Directorate directorates { get; set; }
        private string GPS;

        private decimal currentTaxRelief;
        private int currentTaxReliefMonth;
        private int currentTaxReliefYear;
        private Nullable<DateTime> conversionDate;
        private Nullable<DateTime> upgradeDate;
        private string vehicleNumber;
        private string vehicleDescription;
        private string vehicleType;
        private string subBMC;

        public Employee()
        {
            try
            {
                this.id = 0;
                this.staffID = string.Empty;
                this.fingerPrintID = string.Empty;
                this.surname = string.Empty;
                this.firstName = string.Empty;
                this.otherName = string.Empty;
                this.nickName = string.Empty;
                //this.fileNumber = new FileNumber();
                this.FileNumber = string.Empty;
                this.fileLocation = string.Empty;
                this.pin = string.Empty;
                this.isInSalaryInfo = false;
                this.oldBasicSalary = 0;
                this.pfRate = 0;

                this.GPS = string.Empty;
                this.currentTaxRelief = 0;
                this.currentTaxReliefMonth = 0;

                this.tribe = string.Empty;
                this.overseer = string.Empty;
                this.race = new Race();
                this.supervisorCode = 0;
                this.supervisorName = string.Empty;
                this.supervisorStaffID = string.Empty;

                this.disabilityType = new DisabilityType();
                this.isDisable = false;
                this.disabilityDate = null;

                this.licenceType = new LicenceType();
                this.licenceNumber = string.Empty;

                this.nationalID = string.Empty;
                this.maidenName = string.Empty;
                this.qualificationType = new QualificationType();
                this.zone = new Zone();

                this.incrementDate = null;
                this.payment = false;

                this.confirmed = false;
                this.confirmer = string.Empty;
                this.currentConfirmationDate = null;
                this.currentConfirmationTime = null;

                this.separationType = new SeparationType();
                this.terminated = false;
                this.terminationDate = null;
                this.jobTitleDate = null;

                this.transferType = string.Empty;
                this.transferredIn = false;
                this.transferredOut = false;
                this.transferredInternally = false;
                this.currentTransferredDate = null;

                this.annualLeaveEntitlement = new AnnualLeaveEntitlement();
                this.leaveArreas = 0;
                this.leaveBalance = 0;
                this.leaveTaken = 0;
                this.currentLeaveDate = null;
                this.casualLeave = 0;
                this.casualLeaveDate = null;
                this.currentLeaveStartDate = null;
                this.currentLeaveEndDate = null;
                this.annualLeave = 0;
                this.annualLeaveDate = null;
                this.annualLeaveProposedStartDate = null;
                this.annualLeaveProposedEndDate = null;
                this.annualLeaveProposedDays = 0;
                this.annualLeaveYear = 0;
                this.leaveStatus = string.Empty;
                this.onLeave = false;
                this.onLeaveWithPay = false;
                this.currentLeaveDate = null;

                this.promotionType = new PromotionType();
                this.currentPromotionDate = null;

                this.sanctioned = false;
                this.sanctionType = new SanctionType();
                this.currentSanctionDate = null;

                this.inZoneDate = null;
                this.gradeCategory = new GradeCategory();
                this.grade = new EmployeeGrade();
                this.gradeDate = null;
                this.gradeOnFirstAppointment = new EmployeeGrade();

                this.salaryGrouping = string.Empty;
                this.step = new Step();
                this.salaryLevel = new Level();
                this.band = new Band();
                this.basicSalary = 0;
                this.birthDate = null;
                this.gender = GenderGroups.All;
                this.title = new Titles();
                this.nationality = new Nationality();
                this.town = new Town();
                this.homeTown = new Town();
                this.telNo = string.Empty;
                this.mobileNo = string.Empty;
                this.maritalStatus = MaritalStatusGroups.None;
                this.marriageDate = null;
                this.religion = new Religion();
                this.placeOfBirth = new Town();
                this.countryOfBirth = new Country();
                this.districtOfBirth = new District();
                this.regionOfBirth = new HRBussinessLayer.System_Setup_Class.Region();
                this.noOfChildren = 0;
                this.denomination = new Denomination();
                this.numberNHIS = string.Empty;
                this.houseNumber = string.Empty;
                this.streetName = string.Empty;
                this.residentialTown = new Town();
                this.residentialRegion = new HRBussinessLayer.System_Setup_Class.Region();
                this.residentialCountry = new Country();
                this.postalAddress = string.Empty;
                this.email = string.Empty;
                this.region = new HRBussinessLayer.System_Setup_Class.Region();
                this.contactCountry = new Country();
                this.contactHomeTown = new Town();
                this.photo = null;
                this.department = new Department();
                this.employmentDate = null;

                this.paymentacctype = string.Empty;
                this.mechanised = false;
                this.ssnitContribution = false;
                this.isProvidentFund = false;
                this.isExemptFromSecondTier = false;
                this.incomeTaxContribution = false;
                this.isSusuPlusContribution = false;
                this.susuPlusContributionAmount = 0;
                this.isWithholdingTax = false;
                this.isWithholdingTaxFixedAmount = false;
                this.withholdingTaxFixedAmount = 0;
                this.isWithholdingTaxRate = false;
                this.withholdingTaxRate = 0;
                this.salaryType = new SalaryType();

                this.probation = false;
                this.probationStartDate = null;
                this.probationEndDate = null;
                this.probationStatus = ProbationStatuses.None;
                this.probationApprover = string.Empty;
                this.probationApprovedTime = null;
                this.probationApprovedDate = null;

                this.ssnitNo = string.Empty;
                this.tin = string.Empty;
                this.paymentType = PaymentTypes.None;
                this.hourly = false;
                this.fingerPrint = null;
                this.dateAndTimeGenerated = DateTime.Today;
                this.user = new User();
                this.archived = false;
                this.engagementType = EngagementTypes.None;
                this.engagementGradeOn = new EmployeeGrade();
                this.engagementGradeLeave = new EmployeeGrade();
                this.engagementDate = null;
                this.engagementEffectiveDate = null;
                this.engagementEndingDate = null;
                this.engagementContractOption = string.Empty;
                this.enagagementAnnualSalary = 0;
                this.doFA = null;
                this.doCA = null;
                this.assumptionDate = null;
                this.specialty = new Specialty();
                this.unit = new Unit();
                this.jobTitle = new JobTitle();
                this.occupationGroup = new OccupationGroup();
                this.serverDate = DateTime.Today;
                this.serverTime = DateTime.Today;
                this.photoPath = string.Empty;
                this.staffBank = new List<StaffBank>();
                this.staffLanguage = new List<StaffLanguage>();
                this.visa = new Visa();
                this.passport = new Passport();
                this.workPermit = new WorkPermit();
                this.socialHistory = new SocialHistory();
                this.documents = new List<StaffDocument>();
                this.qualifications = new List<Qualification>();
                this.professions = new List<Profession>();
                this.referees = new List<Referee>();
                this.workExperiences = new List<WorkExperience>();
                this.children = new List<Child>();
                this.otherRelatives = new List<Relation>();
                this.staffAllowances = new List<StaffAllowance>();
                this.staffDeductions = new List<StaffDeduction>();
                this.staffLoans = new List<StaffLoan>();

                this.staffStatus = new StaffStatus();
                this.appointmentType=new AppointmentType();
                this.staffMedicalClaims = new List<MedicalClaims>();
                this.salaryInfo = new List<StaffSalaryHistory>();
                this.objectToSave = ObjectToSave.None;

                this.directorates = new Directorate();
                this.conversionDate = DateTime.Today;
                this.upgradeDate = DateTime.Today;

                this.vehicleNumber = string.Empty;
                this.vehicleDescription = string.Empty;
                this.vehicleType = string.Empty;
                this.subBMC = string.Empty;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Employee(string surName, string firstName, string staffNo)
        {
            this.surname = surName;
            this.firstName = firstName;
            this.staffID = staffNo;
        }

        public override bool Equals(object obj)
        {
            try
            {
                Employee employee = (Employee)obj;
                if (employee.id == this.id)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid object type. Employee object required" + ex.Message);
            }
        }

        public ObjectToSave ObjectToSave
        {
            get { return objectToSave; }
            set { objectToSave = value; }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }
        
        public string VehicleNumber
        {
            get { return vehicleNumber; }
            set { vehicleNumber = value; }
        }
        
        public string VehicleDescription
        {
            get { return vehicleDescription; }
            set { vehicleDescription = value; }
        }
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public string SubBMC
        {
            get { return subBMC; }
            set { subBMC = value; }
        }

        public string FingerPrintID
        {
            get { return fingerPrintID; }
            set { fingerPrintID = value; }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
            }
        }

        public string OtherName
        {
            get { return otherName; }
            set { otherName = value; }
        }

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public string FileNumber
        {
            get { return fileNumber; }
            set { fileNumber = value; }
        }

        public string FileLocation
        {
            get { return fileLocation; }
            set { fileLocation = value; }
        }

        public string PIN
        {
            get { return pin; }
            set { pin = value; }
        }

        public bool IsInSalaryInfo
        {
            get { return isInSalaryInfo; }
            set { isInSalaryInfo = value; }
        }

        public decimal PFRate
        {
            get { return pfRate; }
            set { pfRate = value; }
        }

        public decimal OldBasicSalary
        {
            get { return oldBasicSalary; }
            set { oldBasicSalary = value; }
        }

        public DisabilityType DisabilityType
        {
            get { return disabilityType; }
            set { disabilityType = value; }
        }

        public bool IsDisable
        {
            get { return isDisable; }
            set { isDisable = value; }
        }

        public Nullable<DateTime> DisabilityDate
        {
            get { return disabilityDate; }
            set { disabilityDate = value; }
        }

        public LicenceType LicenceType
        {
            get { return licenceType; }
            set { licenceType = value; }
        }

        public string LicenceNumber
        {
            get { return licenceNumber; }
            set { licenceNumber = value; }
        }

        public string NationalID
        {
            get { return nationalID; }
            set { nationalID = value; }
        }

        public string MaidenName
        {
            get { return maidenName; }
            set { maidenName = value; }
        }

        public QualificationType QualificationType
        {
            get { return qualificationType; }
            set { qualificationType = value; }
        }

        public Nullable<DateTime> IncrementDate
        {
            get { return incrementDate; }
            set
            {
                incrementDate = value;
            }
        }

        public SeparationType SeparationType
        {
            get { return separationType; }
            set
            {
                separationType = value;
            }
        }

        public Nullable<DateTime> TerminationDate
        {
            get { return terminationDate; }
            set
            {
                terminationDate = value;
            }
        }

        public Nullable<DateTime> ConversionDate
        {
            get { return conversionDate; }
            set
            {
                conversionDate = value;
            }
        }

        public Nullable<DateTime> UpgradeDate
        {
            get { return upgradeDate; }
            set
            {
                upgradeDate = value;
            }
        }

        public Nullable<DateTime> JobTitleDate
        {
            get { return jobTitleDate; }
            set
            {
                jobTitleDate = value;
            }
        }

        public bool Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        public bool Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }

        public Nullable<DateTime> CurrentConfirmationDate
        {
            get { return currentConfirmationDate; }
            set
            {
                currentConfirmationDate = value;
            }
        }

        public string Confirmer
        {
            get { return confirmer; }
            set { confirmer = value; }
        }

        public Nullable<DateTime> CurrentConfirmationTime
        {
            get { return currentConfirmationTime; }
            set { currentConfirmationTime = value; }
        }

        public Nullable<DateTime> CurrentLeaveDate
        {
            get { return currentLeaveDate; }
            set
            {
                currentLeaveDate = value;
            }
        }

        public Nullable<DateTime> CurrentLeaveStartDate
        {
            get { return currentLeaveStartDate; }
            set
            {
                currentLeaveStartDate = value;
            }
        }

        public Nullable<DateTime> CurrentLeaveEndDate
        {
            get { return currentLeaveEndDate; }
            set
            {
                currentLeaveEndDate = value;
            }
        }

        public int LeaveArrears
        {
            get { return leaveArreas; }
            set
            {
                leaveArreas = value;
            }
        }

        public AnnualLeaveEntitlement AnnualLeaveEntitlement
        {
            get { return annualLeaveEntitlement; }
            set
            {
                annualLeaveEntitlement = value;
            }
        }

        public int AnnualLeave
        {
            get { return annualLeave; }
            set
            {
                annualLeave = value;
            }
        }

        public Nullable<DateTime> AnnualLeaveDate
        {
            get { return annualLeaveDate; }
            set
            {
                annualLeaveDate = value;
            }
        }

        public Nullable<DateTime> AnnualLeaveProposedStartDate
        {
            get { return annualLeaveProposedStartDate; }
            set
            {
                annualLeaveProposedStartDate = value;
            }
        }

        public Nullable<DateTime> AnnualLeaveProposedEndDate
        {
            get { return annualLeaveProposedEndDate; }
            set
            {
                annualLeaveProposedEndDate = value;
            }
        }

        public int AnnualLeaveProposedDays
        {
            get { return annualLeaveProposedDays; }
            set
            {
                annualLeaveProposedDays = value;
            }
        }

        public int AnnualLeaveYear
        {
            get { return annualLeaveYear; }
            set
            {
                annualLeaveYear = value;
            }
        }

        public int CasualLeave
        {
            get { return casualLeave; }
            set
            {
                casualLeave = value;
            }
        }

        public Nullable<DateTime> CasualLeaveDate
        {
            get { return casualLeaveDate; }
            set
            {
                casualLeaveDate = value;
            }
        }

        public int LeaveTaken
        {
            get { return leaveTaken; }
            set
            {
                leaveTaken = value;
            }
        }

        public int LeaveBalance
        {
            get { return leaveBalance; }
            set
            {
                leaveBalance = value;
            }
        }

        public bool Sanctioned
        {
            get { return sanctioned; }
            set
            {
                sanctioned = value;
            }
        }

        public SanctionType SanctionType
        {
            get { return sanctionType; }
            set
            {
                sanctionType = value;
            }
        }

        public Nullable<DateTime> CurrentSanctionDate
        {
            get { return currentSanctionDate; }
            set
            {
                currentSanctionDate = value;
            }
        }

        public PromotionType PromotionType
        {
            get { return promotionType; }
            set
            {
                promotionType = value;
            }
        }

        public Nullable<DateTime> CurrentPromotionDate
        {
            get { return currentPromotionDate; }
            set
            {
                currentPromotionDate = value;
            }
        }

        public string TransferType
        {
            get { return transferType; }
            set
            {
                transferType = value;
            }
        }

        public Nullable<DateTime> CurrentTransferredDate
        {
            get { return currentTransferredDate; }
            set
            {
                currentTransferredDate = value;
            }
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

        public EmployeeGrade GradeOnFirstAppointment
        {
            get { return gradeOnFirstAppointment; }
            set { gradeOnFirstAppointment = value; }
        }

        public Nullable<DateTime> GradeDate
        {
            get { return gradeDate; }
            set
            {
                gradeDate = value;
            }
        }

        public Zone Zone
        {
            get { return zone; }
            set { zone = value; }
        }

        public Nullable<DateTime> InZoneDate
        {
            get { return inZoneDate; }
            set
            {
                inZoneDate = value;
            }
        }

        public Step Step
        {
            get { return step; }
            set { step = value; }
        }

        public Level SalaryLevel
        {
            get { return salaryLevel; }
            set { salaryLevel = value; }
        }

        public string SalaryGrouping
        {
            get { return salaryGrouping; }
            set { salaryGrouping = value; }
        }

        public Band Band
        {
            get { return band; }
            set { band = value; }
        }

        public decimal BasicSalary
        {
            get { return basicSalary; }
            set { basicSalary = value; }
        }

        public Nullable<DateTime> DOB
        {
            get { return birthDate; }
            set
            {
                birthDate = value;
            }
        }

        public string Gender
        {
            get { return gender.ToString(); }
            set
            {
                gender = (GenderGroups)Enum.Parse(typeof(GenderGroups), value.ToString());
            }
        }

        public Titles Title
        {
            get { return title; }
            set { title = value; }
        }

        public Nationality Nationality
        {
            get { return nationality; }
            set
            {
                nationality = value;
            }
        }

        public Town Town
        {
            get { return town; }
            set { town = value; }
        }

        public Town HomeTown
        {
            get { return homeTown; }
            set { homeTown = value; }
        }

        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }

        public string MobileNo
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }

        public string Tribe
        {
            get { return tribe; }
            set { tribe = value; }
        }

        public string Overseer
        {
            get { return overseer; }
            set { overseer = value; }
        }

        public Race Race
        {
            get { return race; }
            set { race = value; }
        }

        public int SupervisorCode
        {
            get { return supervisorCode; }
            set { supervisorCode = value; }
        }

        public string SupervisorStaffID
        {
            get { return supervisorStaffID; }
            set { supervisorStaffID = value; }
        }

        public string SupervisorName
        {
            get { return supervisorName; }
            set { supervisorName = value; }
        }

        public string MaritalStatus
        {
            get { return maritalStatus.ToString(); }
            set
            {
                maritalStatus = (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), value.ToString());
            }
        }

        public Nullable<DateTime> DOM
        {
            get { return marriageDate; }
            set { marriageDate = value; }
        }

        public Religion Religion
        {
            get { return religion; }
            set { religion = value; }
        }

        public Town POB
        {
            get { return placeOfBirth; }
            set { placeOfBirth = value; }
        }

        public Country CountryOfBirth
        {
            get { return countryOfBirth; }
            set { countryOfBirth = value; }
        }

        public District DistrictOfBirth
        {
            get { return districtOfBirth; }
            set { districtOfBirth = value; }
        }

        public HRBussinessLayer.System_Setup_Class.Region RegionOfBirth
        {
            get { return regionOfBirth; }
            set { regionOfBirth = value; }
        }

        public int NoOfChildren
        {
            get { return noOfChildren; }
            set
            {
                noOfChildren = value;
            }
        }

        public Denomination Denomination
        {
            get { return denomination; }
            set { denomination = value;}
        }

        public string NHISNumber
        {
            get { return numberNHIS; }
            set { numberNHIS = value; }
        }

        public string GPSAddress
        {
            get { return GPS; }
            set { GPS = value; }
        }

        public decimal CurrentTaxRelief
        {
            get { return currentTaxRelief; }
            set { currentTaxRelief = value; }
        }

        public int CurrentTaxReliefMonth
        {
            get { return currentTaxReliefMonth; }
            set { currentTaxReliefMonth = value; }
        }

        public int CurrentTaxReliefYear
        {
            get { return currentTaxReliefYear; }
            set { currentTaxReliefYear = value; }
        }

        public string HouseNumber
        {
            get { return houseNumber; }
            set { houseNumber = value; }
        }

        public string StreetName
        {
            get { return streetName; }
            set { streetName = value; }
        }

        public Town ResidentialTown
        {
            get { return residentialTown; }
            set { residentialTown = value; }
        }

        public HRBussinessLayer.System_Setup_Class.Region ResidentialRegion
        {
            get { return residentialRegion; }
            set { residentialRegion = value; }
        }

        public Country ResidentialCountry
        {
            get { return residentialCountry; }
            set { residentialCountry = value; }
        }

        public string Address
        {
            get { return postalAddress; }
            set { postalAddress = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value;}
        }

        public HRBussinessLayer.System_Setup_Class.Region Region
        {
            get { return region; }
            set { region = value; }
        }

        public Country ContactCountry
        {
            get { return contactCountry; }
            set { contactCountry = value; }
        }

        public Town ContactHomeTown
        {
            get { return contactHomeTown; }
            set { contactHomeTown = value; }
        }

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public Department Department
        {
            get { return department; }
            set { department = value; }
        }

        public AppointmentType AppointmentType
        {
            get { return appointmentType; }
            set { appointmentType = value;}
        }

        public Nullable<DateTime> EmploymentDate
        {
            get { return employmentDate; }
            set { employmentDate = value; }
        }

        public bool Mechanised
        {
            get { return mechanised; }
            set { mechanised = value; }
        }
        public string PaymentAccType
        {
            get { return paymentacctype; }
            set { paymentacctype = value; }
        }

        public bool SSNITContribution
        {
            get { return ssnitContribution; }
            set { ssnitContribution = value; }
        }

        public bool IsProvidentFund
        {
            get { return isProvidentFund; }
            set { isProvidentFund = value; }
        }

        public bool IsExemptFromSecondTier
        {
            get { return isExemptFromSecondTier; }
            set { isExemptFromSecondTier = value; }
        }

        public bool IncomeTaxContribution
        {
            get { return incomeTaxContribution; }
            set { incomeTaxContribution = value; }
        }

        public bool IsSusuPlusContribution
        {
            get { return isSusuPlusContribution; }
            set { isSusuPlusContribution = value; }
        }

        public decimal SusuPlusContributionAmount
        {
            get { return susuPlusContributionAmount; }
            set { susuPlusContributionAmount = value; }
        }

        public bool IsWithholdingTax
        {
            get { return isWithholdingTax; }
            set { isWithholdingTax = value; }
        }

        public bool IsWithholdingTaxFixedAmount
        {
            get { return isWithholdingTaxFixedAmount; }
            set { isWithholdingTaxFixedAmount = value; }
        }

        public decimal WithholdingTaxFixedAmount
        {
            get { return withholdingTaxFixedAmount; }
            set { withholdingTaxFixedAmount = value; }
        }

        public bool IsWithholdingTaxRate
        {
            get { return isWithholdingTaxRate; }
            set { isWithholdingTaxRate = value; }
        }

        public decimal WithholdingTaxRate
        {
            get { return withholdingTaxRate; }
            set { withholdingTaxRate = value; }
        }

        public SalaryType SalaryType
        {
            get { return salaryType; }
            set { salaryType = value; }
        }

        public bool Probation
        {
            get { return probation; }
            set { probation = value; }
        }

        public Nullable<DateTime> ProbationStartDate
        {
            get { return probationStartDate; }
            set { probationStartDate = value; }
        }

        public Nullable<DateTime> ProbationEndDate
        {
            get { return probationEndDate; }
            set { probationEndDate = value; }
        }

        public string ProbationApprover
        {
            get { return probationApprover; }
            set { probationApprover = value; }
        }

        public Nullable<DateTime> ProbationApprovedDate
        {
            get { return probationApprovedDate; }
            set { probationApprovedDate = value; }
        }

        public Nullable<DateTime> ProbationApprovedTime
        {
            get { return probationApprovedTime; }
            set { probationApprovedTime = value; }
        }

        public string ProbationStatus
        {
            get { return probationStatus.ToString(); }
            set
            {
                probationStatus = (ProbationStatuses)Enum.Parse(typeof(ProbationStatuses), value.ToString());
            }
        }

        public string SSNITNo
        {
            get { return ssnitNo; }
            set { ssnitNo = value; }
        }

        public string TIN
        {
            get { return tin; }
            set { tin = value; }
        }

        public string PaymentType
        {
            get { return paymentType.ToString(); }
            set
            {
                paymentType = (PaymentTypes)Enum.Parse(typeof(PaymentTypes), value.ToString());
            }
        }

        public bool Hourly
        {
            get { return hourly; }
            set { hourly = value; }
        }

        public byte[] FingerPrint
        {
            get { return fingerPrint; }
            set
            {
                if (value != null)
                    fingerPrint = value;
            }
        }

        public bool Terminated
        {
            get { return terminated; }
            set { terminated = value; }
        }

        public string LeaveStatus
        {
            get { return leaveStatus; }
            set { leaveStatus = value; }
        }

        public bool OnLeave
        {
            get { return onLeave; }
            set { onLeave = value; }
        }

        public bool OnLeaveWithPay
        {
            get { return onLeaveWithPay; }
            set { onLeaveWithPay = value; }
        }

        public bool TransferredOut
        {
            get { return transferredOut; }
            set { transferredOut = value; }
        }

        public bool TransferedIn
        {
            get { return transferredIn; }
            set { transferredIn = value; }
        }

        public bool TransferredInternally
        {
            get { return transferredInternally; }
            set { transferredInternally = value; }
        }

        public DateTime DateAndTimeGenerated
        {
            get { return dateAndTimeGenerated; }
            set { dateAndTimeGenerated = value; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public bool Archived
        {
            get { return archived; }
            set { archived = value; }
        }

        public string EngagementType
        {
            get { return engagementType.ToString(); }
            set
            {
                engagementType = (EngagementTypes)Enum.Parse(typeof(EngagementTypes), value.ToString());
            }
        }

        public StaffStatus StaffStatus
        {
            get { return staffStatus; }
            set { staffStatus = value; }
        }

        public EmployeeGrade EngagementGradeOn
        {
            get { return engagementGradeOn; }
            set { engagementGradeOn = value; }
        }

        public EmployeeGrade EngagementGradeLeaving
        {
            get { return engagementGradeLeave; }
            set { engagementGradeLeave = value; }
        }

        public Nullable<DateTime> EngagementDateApplied
        {
            get { return engagementDate; }
            set { engagementDate = value; }
        }

        public Nullable<DateTime> EngagementEffectiveDate
        {
            get { return engagementEffectiveDate; }
            set { engagementEffectiveDate = value; }
        }

        public Nullable<DateTime> EngagementEndingDate
        {
            get { return engagementEndingDate; }
            set { engagementEndingDate = value; }
        }

        public string EngagementContractOption
        {
            get { return engagementContractOption; }
            set { engagementContractOption = value; }
        }

        public decimal EngagementAnnualSalary
        {
            get { return enagagementAnnualSalary; }
            set { enagagementAnnualSalary = value; }
        }


        public Nullable<DateTime> DOFA
        {
            get { return doFA; }
            set { doFA = value; }
        }

        public Nullable<DateTime> DOCA
        {
            get { return doCA; }
            set { doCA = value; }
        }

        public Nullable<DateTime> AssumptionDate
        {
            get { return assumptionDate; }
            set { assumptionDate = value; }
        }

        public Specialty Specialty
        {
            get { return specialty; }
            set { specialty = value; }
        }

        public Unit Unit
        {
            get { return unit; }
            set { unit = value; }
        }

        public JobTitle JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        public OccupationGroup OccupationGroup
        {
            get { return occupationGroup; }
            set { occupationGroup = value; }
        }

        public DateTime ServerDate
        {
            get { return serverDate; }
            set { serverDate = value; }
        }

        public DateTime ServerTime
        {
            get { return serverTime; }
            set { serverTime = value; }
        }

        public string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; }
        }
        
       
        public IList<StaffBank> StaffBank
        {
            get { return staffBank; }
            set { staffBank = value; }
        }

        public IList<StaffLanguage> StaffLanguage
        {
            get { return staffLanguage; }
            set { staffLanguage = value; }
        }

        public IList<Qualification> Qualifications
        {
            get { return qualifications; }
            set { qualifications = value; }
        }

        public IList<Profession> Professions
        {
            get { return professions; }
            set { professions = value; }
        }

        public IList<Referee> Referees
        {
            get { return referees; }
            set { referees = value; }
        }

        public IList<WorkExperience> WorkExperiences
        {
            get { return workExperiences; }
            set { workExperiences = value; }
        }

        public IList<StaffSalaryHistory> SalaryHistories
        {
            get { return salaryInfo; }
            set { salaryInfo = value; }
        }

        public IList<Child> Children
        {
            get { return children; }
            set { children = value; }
        }

        public IList<Relation> OtherRelatives
        {
            get { return otherRelatives; }
            set { otherRelatives = value; }
        }

        public IList<StaffAllowance> Allowances
        {
            get { return staffAllowances; }
            set { staffAllowances = value; }
        }

        public IList<StaffDeduction> Deductions
        {
            get { return staffDeductions; }
            set { staffDeductions = value; }
        }

        public IList<StaffDocument> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        public WorkPermit WorkPermit
        {
            get { return workPermit; }
            set { workPermit = value; }
        }

        public Visa Visa
        {
            get { return visa; }
            set { visa = value; }
        }

        public Passport Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        public SocialHistory SocialHistory
        {
            get { return socialHistory; }
            set { socialHistory = value; }
        }

        public string Age
        {
            get
            {                
                string age = String.Empty;
                try
                {
                    int yrcheck = Hospital.CurrentDate.Year - DateTime.Parse(birthDate.ToString()).Year;
                    int monthcheck = Hospital.CurrentDate.Month - DateTime.Parse(birthDate.ToString()).Month;
                    int daycheck = Hospital.CurrentDate.Day - DateTime.Parse(birthDate.ToString()).Day;
                    if (yrcheck == 0)
                    {
                        if (daycheck == 0 || daycheck > 0)
                            age = monthcheck + " months";
                        else
                            age = monthcheck - 1 + " months";
                    }
                    else if (yrcheck == 1)
                    {
                        if (monthcheck < 0)
                        {
                            if (daycheck > 0 || daycheck == 0)
                                age = monthcheck + 12 + " months";
                            else if (daycheck < 1)
                                age = (monthcheck - 1) + 12 + " months";
                        }
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 || daycheck > 0)
                                age = "1 yr";
                            else if (daycheck < 0)
                                age = "11 months";
                            else if (monthcheck > 0)
                                age = "1 yr";
                        }
                    }
                    else if (yrcheck > 1)
                    {
                        if (monthcheck > 0)
                            age = yrcheck + " yrs";
                        else if (monthcheck < 0)
                            age = yrcheck - 1 + " yrs";
                        else if (monthcheck == 0)
                        {
                            if (daycheck == 0 && daycheck > 0)
                                age = yrcheck + " yrs";
                            else
                                age = yrcheck - 1 + " yrs";
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    age = "N/A";
                }
                return age;
            }
            set { age = this.Age; }
        }        
    }
}
