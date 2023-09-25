using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using eMAS.Forms.StaffInformation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;
using eMAS.Forms.SystemSetup;
using eMAS.Forms.Employment;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;

namespace eMAS.All_UIs.Staff_Information_FORMS
{

    delegate void Function();	// a simple delegate for marshalling calls from event handlers to the GUI thread

    public partial class EmployeeMaintenance : Form
    {
        //Variable Declaration
        IDAL dal;
        Employee employee;
        UserInfo userInfo;
        FileNumber fileNumber;
        SingleSpine singleSpine;
        Relation relation;
        StaffLanguage staffLanguage;
        Profession staffProfessionHistory;
        WorkExperience staffEmploymentHistory;
        Qualification staffEducationHistory;
        StaffDocument staffDocument;
        Referee referee;
        SingleSpineDataMapper singleSpineMapper;
        EmployeeDataMapper employees;
        DependentsDataMapper dependentsMapper;
        QualificationDataMapper qualificationsMapper;
        StaffLanguagesDataMapper languagesMapper;
        ProfessionDataMapper professionsMapper;
        RefereesDataMapper refreesMapper;
        StaffDocumentsDataMapper documentsMapper;
        WorkExperienceDataMapper experiencesMapper;
        SalaryTypesDataMapper salaryTypesDal;
        IList<SalaryType> salaryTypes;
        DALHelper dalHelper;
        private PDFReader reader;
        private DocBrowser reader1;

        string workPermitID;
        string passportID;
        string socialHistoryID;
        string visaID;

        bool saveAll;
        bool allowedToSaveAll;
        bool editMode;
        int staffCode;

        //modelling tables in the database
        //Personal Detail
        IList<Zone> zones;
        IList<FileNumber> fileNumbers;
        DataTable documentGroupsTable;
        DataTable nationalitiesTable;
        DataTable religionsTable;
        DataTable townsTable;
        DataTable denominationsTable;
        DataTable titlesTable;        
        DataTable birthCountriesTable;
        DataTable birthPlacesTable;
        DataTable birthDistrictsTable;
        DataTable birthRegionsTable;
        DataTable racesTable;
        
        //Contacts
        DataTable contactTownsTable;
        DataTable contactRegionsTable;
        DataTable contactCountriesTable;
        DataTable contactHomeTownsTable;

        //Residential
        DataTable residentialTownsTable;
        DataTable residentialRegionsTable;
        DataTable residentialCountriesTable;

        //Job Detail        
        DataTable unitsTable;
        DataTable jobTitlesTable;
        DataTable specialtiesTable;
        DataTable occupationGrpsTable;
        DataTable employmentStatusesTable;
        DataTable appointmentTypesTable;

        //Job Detail, Engagement

        DataTable engagementTypesTable;
        DataTable engagementGradesOnTable;
        DataTable engagementGradesLeavingTable;

        //Salary Detail
        DataTable gradesTable;
        DataTable gradesOnFirstTable;
        DataTable stepsTable;
        DataTable levelsTable;
        DataTable bandsTable;
        DataTable bankDetailBranchesTable;
        DataTable bankDetailsTable;
        DataTable bankDetailAccountTypesTable;
        DataTable probationStatusesTable;
        private IList<Employee> employeeList;
        private IList<Qualification> qualifications;
        private IList<QualificationType> qualificationTypes;
        private IList<StaffDocument> documents;
        private IList<WorkExperience> experiences;
        private IList<Referee> referees;
        private IList<Profession> professions;
        private IList<StaffLanguage> staffLanguages;
        private IList<Language> languages;
        private IList<StaffStatus> staffStatuses;
        private IList<AppointmentType> appointmentTypes;

        private IList<Department> departments;
        private StaffBank staffBank;
        private IList<StaffBank> staffBanks;
        private IList<AccountType> accountTypes;
        private IList<Bank> banks;
        private IList<BankBranch> bankBranches;
        private IList<Title> titlesList;
        private IList<Relationship> relationships;
        private IList<Relation> dependents;
        private IList<Occupation> occupations;
        private IList<EmployeeGrade> grades;
        private IList<GradeCategory> gradeCategories;
        private IList<UserCategory> userCategories;
        private IList<Town> towns;
        private IList<Religion> religions;
        private IList<HRBussinessLayer.System_Setup_Class.Region> regions;
        private IList<Nationality> nationalities;
        private IList<Country> countries;
        private IList<DisabilityType> disabilityTypes;
        private IList<LicenceType> licenceTypes;
        private IList<PhoneNumberType> phoneNumberTypeList;
        private Forms.SystemSetup.Titles titlesForm;
        private Nationalities nationalitiesForm;
        private Religions religionsForm;
        private Towns townsForm;
        private Districts districtsForm;
        private DenominationForm denominationsForm;
        private DisabilityTypeForm disabilityTypeForm;
        private IList<AnnualLeaveEntitlement> annualLeaveEntitlements;

        private Company company;
        private string empID;
        private int ctr;


        public EmployeeMaintenance()
        {
            try
            {
                InitializeComponent();
                this.empID = string.Empty;
                this.userInfo = new UserInfo();
                this.reader = new PDFReader();
                this.company = new Company();
                this.fileNumber = new FileNumber();
                this.phoneNumberTypeList = new List<PhoneNumberType>();  
                this.fileNumbers=new List<FileNumber>();               
                this.titlesList = new List<Title>();
                this.staffBanks = new List<StaffBank>();
                this.staffBank = new StaffBank();
                this.departments = new List<Department>();
                this.languages = new List<Language>();
                this.salaryTypesDal = new SalaryTypesDataMapper();
                this.salaryTypes = new List<SalaryType>();
                this.zones = new List<Zone>();
                this.towns = new List<Town>();
                this.staffLanguages = new List<StaffLanguage>();
                this.regions = new List<HRBussinessLayer.System_Setup_Class.Region>();
                this.countries = new List<Country>();
                this.nationalities = new List<Nationality>();
                this.disabilityTypes = new List<DisabilityType>();
                this.annualLeaveEntitlements = new List<AnnualLeaveEntitlement>();
                this.licenceTypes = new List<LicenceType>();
                this.relationships = new List<Relationship>();
                this.qualificationTypes = new List<QualificationType>();
                this.occupations = new List<Occupation>();
                this.grades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.userCategories = new List<UserCategory>();
                this.staffStatuses = new List<StaffStatus>();
                this.appointmentTypes=new List<AppointmentType>();
                this.employeeList = new List<Employee>();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.editMode = false;
                this.employee = new Employee();
                this.singleSpine = new SingleSpine();
                this.relation = new Relation();
                this.staffLanguage = new StaffLanguage();
                this.staffProfessionHistory = new Profession();
                this.staffEmploymentHistory = new WorkExperience();
                this.staffDocument = new StaffDocument();
                this.staffEducationHistory = new Qualification();
                this.referee = new Referee();
                this.singleSpineMapper = new SingleSpineDataMapper();
                this.employees = new EmployeeDataMapper();
                this.dependentsMapper = new DependentsDataMapper();
                this.dependents=new List<Relation>();
                this.languagesMapper = new StaffLanguagesDataMapper();
                this.qualificationsMapper = new QualificationDataMapper();
                this.refreesMapper = new RefereesDataMapper();
                this.professionsMapper = new ProfessionDataMapper();
                this.documentsMapper = new StaffDocumentsDataMapper();
                this.experiencesMapper = new WorkExperienceDataMapper();
                this.workPermitID = string.Empty;
                this.passportID = string.Empty;
                this.socialHistoryID = string.Empty;
                this.visaID = string.Empty;
                this.saveAll = false;
                this.staffCode = 0;
                //personalTabPage.Enter += new EventHandler(personalTabPage_Enter);
                //dependentsTabPage.Enter += new EventHandler(dependentsTabPage_Enter);
                //educationHistoryTabPage.Enter += new EventHandler(careerDetailsTabPage_Enter);
                //employmentTabPage.Enter += new EventHandler(employmentTabPage_Enter);
                //refereeTabPage.Enter += new EventHandler(refereeTabPage_Enter);
                //documentsTabPage.Enter += new EventHandler(documentsTabPage_Enter);
                //workPermitTabPage.Enter += new EventHandler(workPermiTabPage_Enter);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void paymentTypeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                paymentTypeComboBox.Items.Clear();
                IList<Company> companyInfo = dal.GetAll<Company>();
                foreach (Company company in companyInfo)
                {
                    if (company.Salary)
                    {
                        paymentTypeComboBox.Items.Add("Salary");
                    }
                    if (company.Wage)
                    {
                        paymentTypeComboBox.Items.Add("Wage");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridRelations_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //gridRelations.CurrentCellDirtyStateChanged += new EventHandler(gridRelations_CurrentCellDirtyStateChanged);
        }

        void gridRelations_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridRelations.CurrentRow != null && gridRelations.CurrentRow.Cells["relationRelationship"].Value != null)
                {
                    foreach (Relationship relation in relationships)
                    {
                        if (relation.Description == gridRelations.CurrentRow.Cells["relationRelationship"].Value.ToString())
                        {
                            gridRelations.CurrentRow.Cells["relationID"].Value = relation.ID;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditEmployee(DataGridViewRow row)
        {

        }

        void cmbPOB_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cboBirthDistrict.Text.Trim() == string.Empty)
                {
                    staffErrorProvider.SetError(cboBirthDistrict, "Please select Birth District first");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboBirthDistrict_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                birthDistrictsTable = dalHelper.ExecuteReader("Select * from DistrictView Where DistrictView.Archived = @Archived order by DistrictView.Description asc");
                cboBirthDistrict.Items.Clear();
                foreach (DataRow row in birthDistrictsTable.Rows)
                {
                    cboBirthDistrict.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cmbSex_DropDown(object sender, EventArgs e)
        {
            try
            {
                //if (!editMode)
                //{
                //    fingerPrintTextBox.Text = GenerateFingerPrintID();
                //    staffIDTextBox.Text = GenerateStaffID();
                //}
                cmbSex.Items.Clear();
                foreach (GenderGroups item in Enum.GetValues(typeof(GenderGroups)))
                {
                    if (item != GenderGroups.All && item != GenderGroups.None)
                    {
                        cmbSex.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cmbHomeTown_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                townsTable = dalHelper.ExecuteReader("Select * from TownView Where TownView.Archived = @Archived order by TownView.Description asc");
                cmbHomeTown.Items.Clear();
                foreach (DataRow row in townsTable.Rows)
                {
                    cmbHomeTown.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
       
        void cboResidentialCountry_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                residentialCountriesTable = dalHelper.ExecuteReader("Select * from CountryView Where CountryView.Archived = @Archived order by CountryView.Description asc");
                cboResidentialCountry.Items.Clear();
                foreach (DataRow row in residentialCountriesTable.Rows)
                {
                    cboResidentialCountry.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboContactCountry_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                contactCountriesTable = dalHelper.ExecuteReader("Select * from CountryView Where CountryView.Archived = @Archived order by CountryView.Description asc");
                cboContactCountry.Items.Clear();
                foreach (DataRow row in contactCountriesTable.Rows)
                {
                    cboContactCountry.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridDocuments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridDocuments.CurrentRow != null && !gridDocuments.CurrentRow.IsNewRow)
                {
                    if (gridDocuments.CurrentCell.ColumnIndex == 4)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@Archived", "False", DbType.String);
                        documentGroupsTable = dalHelper.ExecuteReader("Select * from DocumentGroupView Where DocumentGroupView.Archived = @Archived order by DocumentGroupView.Description asc");
                        gridDocumentsDocumentGroup.Items.Clear();
                        foreach (DataRow row in documentGroupsTable.Rows)
                        {
                            gridDocumentsDocumentGroup.Items.Add(row["Description"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cmbReligion_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                religionsTable = dalHelper.ExecuteReader("Select * from ReligionView Where ReligionView.Archived = @Archived and ReligionView.Active = @Active order by ReligionView.Description asc");
                cmbReligion.Items.Clear();
                foreach (DataRow row in religionsTable.Rows)
                {
                    cmbReligion.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboNationality_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                nationalitiesTable = dalHelper.ExecuteReader("Select * from NationalityView Where NationalityView.Archived = @Archived order by NationalityView.Description asc");
                cboNationality.Items.Clear();
                foreach (DataRow row in nationalitiesTable.Rows)
                {
                    cboNationality.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void userRoleComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                userCategories = dal.GetAll<UserCategory>();
                userRoleComboBox.Items.Clear();
                foreach (UserCategory category in userCategories)
                {
                    if (category.Description.ToLower().Trim() != "system administrator")
                    {
                        userRoleComboBox.Items.Add(category.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gradeCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                gradeCategories = dal.GetAll<GradeCategory>();
                gradeCategoryComboBox.Items.Clear();
                foreach (GradeCategory category in gradeCategories)
                {
                    gradeCategoryComboBox.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gradeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (gradeCategoryComboBox.Text.Trim() == string.Empty)
                {
                    staffErrorProvider.SetError(gradeCategoryComboBox, "Please select grade category first");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridExperience_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmploymentHistory.CurrentCell.ColumnIndex == 5)
                {
                    experienceFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceFromYear.Items.Add(year);
                    }

                }

                if (gridEmploymentHistory.CurrentCell.ColumnIndex == 6)
                {
                    experienceToMonth.Items.Clear();
                    foreach (string year in GlobalData.GetMonths())
                    {
                        experienceToMonth.Items.Add(year);
                    }
                    experienceToMonth.Items.Add("To Date");
                }

                if (gridEmploymentHistory.CurrentCell.ColumnIndex == 7)
                {
                    experienceToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceToYear.Items.Add(year);
                    }
                    experienceToYear.Items.Add("To Date");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridProfession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridProfession.CurrentCell.ColumnIndex == 3)
                {
                    professionFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionFromYear.Items.Add(year);
                    }

                }
                if (gridProfession.CurrentCell.ColumnIndex == 4)
                {
                    professionToMonth.Items.Clear();
                    foreach (string year in GlobalData.GetMonths())
                    {
                        professionToMonth.Items.Add(year);
                    }
                    professionToMonth.Items.Add("To Date");
                }
                if (gridProfession.CurrentCell.ColumnIndex == 5)
                {
                    professionToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionToYear.Items.Add(year);
                    }
                    professionToYear.Items.Add("To Date");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridQualification_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEducationHistory.CurrentCell.ColumnIndex == 4)
                {
                    qualificationsFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsFromYear.Items.Add(year);
                    }

                }

                if (gridEducationHistory.CurrentCell.ColumnIndex == 5)
                {
                    qualificationsToMonth.Items.Clear();
                    foreach (string year in GlobalData.GetMonths())
                    {
                        qualificationsToMonth.Items.Add(year);
                    }
                    qualificationsToMonth.Items.Add("To Date");
                }

                if (gridEducationHistory.CurrentCell.ColumnIndex == 6)
                {
                    qualificationsToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsToYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Add("To Date");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gridLanguage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridLanguage.CurrentCell.ColumnIndex == 1)
                {
                    GetLanguages();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetLanguages()
        {
            try
            {
                languages = dal.GetAll<Language>();
                colLanguage.Items.Clear();
                foreach (Language language in languages)
                {
                    colLanguage.Items.Add(language.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void gridRelations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridRelations.CurrentCell.ColumnIndex == 4)
                {
                    GetRelationships();
                }
                if (gridRelations.CurrentCell.ColumnIndex == 6)
                {
                    GetOccupations();
                }
                if (gridRelations.CurrentCell.ColumnIndex == 8)
                {
                    GetTowns();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetRelationships()
        {
            try
            {
                relationships = dal.GetAll<Relationship>();
                relationRelationship.Items.Clear();
                foreach (Relationship relationship in relationships)
                {
                    relationRelationship.Items.Add(relationship.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetOccupations()
        {
            try
            {
                occupations = dal.GetAll<Occupation>();
                relationOccupation.Items.Clear();
                foreach (Occupation occupation in occupations)
                {
                    relationOccupation.Items.Add(occupation.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        private void GetTowns()
        {
            try
            {
                towns = dal.GetAll<Town>();
                relationPOB.Items.Clear();
                foreach (Town town in towns)
                {
                    relationPOB.Items.Add(town.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        void cmbMaritalStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbMaritalStatus.Items.Clear();
                foreach (MaritalStatusGroups group in Enum.GetValues(typeof(MaritalStatusGroups)))
                {
                    if (group != MaritalStatusGroups.None)
                    {
                        cmbMaritalStatus.Items.Add(group.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cmbTitle_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (cmbSex.Text.Trim() == string.Empty)
                {
                    staffErrorProvider.SetError(cmbSex, "Please select a title first");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void departmentComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {               
                departments = dal.GetAll<Department>();
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                foreach (Department department in departments)
                {
                    departmentComboBox.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        void workPermiTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.WorkPermit;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void documentsTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.Documents;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void refereeTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.Referees;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void employmentTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.EmploymentHistory;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void careerDetailsTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.EducationAndProfession;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void dependentsTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.RelationsAndChildren;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void personalTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                employee.ObjectToSave = ObjectToSave.PersonalInfo;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public bool Verified
        {
            set
            {
                if (value)
                {
                    verifiedPictureBox.Visible = true;
                    notVerifiedPictureBox.Visible = false;
                }
                else
                {
                    verifiedPictureBox.Visible = false;
                    notVerifiedPictureBox.Visible = true;
                }
            }
        }

        public Image FingerPrint
        {
            set { fingerPrintPictureBox.Image = value; }
        }

        public Employee Employee
        {
            get { return employee; }
        }

        void personalTabPage_GotFocus(object sender, EventArgs e)
        {
            personalTabPage.Tag = "True";
        }

        #region Staff Personal Info
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearStaffPersonalInfo();
        }

        private void UpdateEmployeeEntity(Employee employee)
        {
            Validator.Errors.Clear();
            employee.StaffID = staffIDTextBox.Text;
            employee.Surname = surnameTextBox.Text;
            employee.FirstName = txtFirstName.Text;
            employee.OtherName = txtOtherName.Text;

            if (cmbTitle.SelectedIndex >= 0)
                employee.Title.ID = cmbTitle.SelectedIndex;

            employee.DOB = dateDOB.Value;
            employee.Gender = cmbSex.Text;
            employee.Nationality = nationalities[cboNationality.SelectedIndex];
            employee.Religion = religions[cboNationality.SelectedIndex];
            employee.POB = towns[cmbPOB.SelectedIndex];
            employee.NoOfChildren = int.Parse(txtNumberOfChildren.Text);
            employee.MaritalStatus = cmbMaritalStatus.Text;
            employee.EngagementType = cboEngagementType.Text;
            employee.StaffStatus.Description = cboEmploymentStatus.Text;
            employee.HomeTown = towns[departmentComboBox.SelectedIndex];
            employee.Town = towns[departmentComboBox.SelectedIndex];

            if (departmentComboBox.SelectedIndex >= 0)
                employee.Department = departments[departmentComboBox.SelectedIndex];
            else
                employee.Department = new Department();

            employee.EmploymentDate = DateTime.Parse(dateEmploymentDate.Text);

            if (departmentComboBox.SelectedIndex >= 0)
                employee.Department = departments[departmentComboBox.SelectedIndex];
            else
                employee.Department = new Department();

            if (gradeCategoryComboBox.SelectedIndex >= 0)
                employee.Grade = grades[gradeComboBox.SelectedIndex];
            else
                employee.Grade = new EmployeeGrade();

            employee.SSNITContribution = ssnitCheckBox.Checked;
            employee.SSNITNo = ssnitNoTextBox.Text;
            employee.IncomeTaxContribution = incomeCheckBox.Checked;
            employee.Probation = probationCheckBox.Checked;

            //if (Template != null)
            //    employee.FingerPrint = Template.Bytes;
            //else
            //    employee.FingerPrint = null;

            employee.Address = txtContactPostalAddress.Text;
            employee.TelNo = txtContactTelephone.Text;
            employee.MobileNo = txtContactMobileNumber.Text;
            employee.Email = txtContactEmailAddress.Text;
            employee.Photo = pictureBox.Image;
            employee.User.UserName = userNameTextBox.Text;
            employee.User.Password = passwordTextBox.Text;
            if (userRoleComboBox.SelectedIndex > 0)
            {
                employee.User.UserCategory.ID = userCategories[userRoleComboBox.SelectedIndex].ID;
                employee.User.UserCategory.Description = userRoleComboBox.Text;
            }

            employee.Documents.Clear();
            foreach (DataGridViewRow row in gridDocuments.Rows)
            {
                StaffDocument document = new StaffDocument();
                document.DateCreated = DateTime.Parse(row.Cells["gridDocumentsDateCreated"].Value.ToString());
                document.Description = row.Cells["gridDocumentsDescription"].Value.ToString();
                document.DocumentGroup = row.Cells["gridDocumentsDocumentGroup"].Value.ToString();
                document.DocumentType = row.Cells["gridDocumentsDocumentType"].Value.ToString();
                document.Path = row.Cells["gridDocumentsPath"].Value.ToString();
                document.DocumentContent = (byte[])row.Cells["gridDocumentsDocumentsContent"].Value;
                employee.Documents.Add(document);
            }

            //Work Permit
            employee.WorkPermit.ID = txtWorkPermitID.Text.Trim();
            employee.WorkPermit.Duration = txtDuration.Value;
            employee.WorkPermit.HasPermit = cmbWorkPermit.Text.Trim();
            employee.WorkPermit.Notes = txtWorkPermitNotes.Text.Trim();
            employee.WorkPermit.PermitExpires = dateWorkPermit.Value;


            //Visa
            employee.Visa.ExpiresDate = dateTo.Value;
            employee.Visa.ValidFrom = dateFrom.Value;
            employee.Visa.Notes = txtVisaNotes.Text.Trim();
            employee.Visa.VisaType = cmbVisaType.Text.Trim();

            //Passport
            employee.Passport.Notes = txtPassportNotes.Text.Trim();
            employee.Passport.PassportExpiresDate = dateExpires.Value;
            employee.Passport.PassportIssueDate = dateIssued.Value;
            employee.Passport.PassportNo = txtPassportNo.Text.Trim();

            //Social History
            employee.SocialHistory.AppliedBefore = cmbApplied.Text.Trim();
            employee.SocialHistory.Bonded = cmbBonded.Text.Trim();
            employee.SocialHistory.Convicted = cmbConvicted.Text.Trim();
            employee.SocialHistory.PhysicalDisability = cmbDisabled.Text.Trim();

            employee.Qualifications.Clear();
            foreach (DataGridViewRow row in gridEducationHistory.Rows)
            {
                if (!row.IsNewRow)
                {
                    Qualification qualification = new Qualification();
                    if (row.Cells["qualificationsID"].Value != null)
                        qualification.ID = int.Parse(row.Cells["qualificationsID"].Value.ToString());
                    qualification.CertificateObtained = row.Cells["qualificationsCertificateObtained"].Value.ToString();
                    qualification.FromMonth = row.Cells["qualificationsGridFromMonth"].Value.ToString();
                    qualification.FromYear = row.Cells["qualificationsFromYear"].Value.ToString();
                    qualification.NameOfInstitution = row.Cells["qualificationsNameOfInstitution"].Value.ToString();
                    qualification.ToYear = row.Cells["qualificationsToYear"].Value.ToString();
                    qualification.ToMonth = row.Cells["qualificationsGridToMonth"].Value.ToString();
                    employee.Qualifications.Add(qualification);
                }
            }

            employee.Professions.Clear();
            foreach (DataGridViewRow row in gridProfession.Rows)
            {
                if (!row.IsNewRow)
                {
                    Profession profession = new Profession();
                    if (row.Cells["professionID"].Value != null)
                        profession.ID = int.Parse(row.Cells["professionID"].Value.ToString());
                    profession.FromYear = row.Cells["ProfessionGridFromMonth"].Value.ToString();
                    profession.FromYear = row.Cells["ProfessionFromYear"].Value.ToString();
                    profession.NameOfProfession = row.Cells["professionNameOfProfession"].Value.ToString();
                    profession.ToYear = row.Cells["professionToYear"].Value.ToString();
                    profession.ToMonth = row.Cells["professionGridToMonth"].Value.ToString();
                    employee.Professions.Add(profession);
                }
            }

            employee.Referees.Clear();
            foreach (DataGridViewRow row in gridRefrees.Rows)
            {
                if (!row.IsNewRow)
                {
                    Referee referee = new Referee();
                    if (row.Cells["refereesID"].Value != null)
                        referee.ID = int.Parse(row.Cells["refereesID"].Value.ToString());
                    referee.Address = row.Cells["refereesAddress"].Value.ToString();
                    referee.Name = row.Cells["refereesName"].Value.ToString();
                    referee.Occupation = row.Cells["refereesOccupation"].Value.ToString();
                    referee.TelNo=gridRefrees.Rows[ctr].Cells["refereesTelNo"].Value.ToString();
                    referee.Email=gridRefrees.Rows[ctr].Cells["refereesEmail"].Value.ToString() ;
                    employee.Referees.Add(referee);
                }
            }

            employee.WorkExperiences.Clear();
            foreach (DataGridViewRow row in gridEmploymentHistory.Rows)
            {
                if (!row.IsNewRow)
                {
                    WorkExperience experience = new WorkExperience();
                    if (row.Cells["experienceID"].Value != null)
                        experience.ID = int.Parse(row.Cells["experienceID"].Value.ToString());
                    experience.FromYear = row.Cells["experienceFromYear"].Value.ToString();
                    experience.FromMonth = row.Cells["experienceFromMonth"].Value.ToString();
                    experience.JobTitle = row.Cells["experienceJobTitle"].Value.ToString();
                    experience.AnnualSalary = decimal.Parse(row.Cells["experienceAnnualSalary"].Value.ToString());
                    experience.NameOfOrganisation = row.Cells["experienceNameOfOrganisation"].Value.ToString();
                    experience.ToYear = row.Cells["experienceToYear"].Value.ToString();
                    experience.ToMonth = row.Cells["experienceToMonth"].Value.ToString();
                    experience.ReasonForLeaving = row.Cells["ReasonForLeaving"].Value.ToString();
                    employee.WorkExperiences.Add(experience);
                }
            }

            employee.OtherRelatives.Clear();
            foreach (DataGridViewRow row in gridRelations.Rows)
            {
                if (!row.IsNewRow)
                {
                    Relation otherRelatives = new Relation();
                    if (row.Cells["relationID"].Value != null)
                        otherRelatives.ID = int.Parse(row.Cells["relationID"].Value.ToString());
                    otherRelatives.Address = row.Cells["relationAddress"].Value.ToString();
                    otherRelatives.Name = row.Cells["relationName"].Value.ToString();
                    otherRelatives.Occupation.Description = row.Cells["relationOccupation"].Value.ToString();
                    otherRelatives.Relationship.Description = row.Cells["relationRelationship"].Value.ToString();
                    otherRelatives.Type = row.Cells["relationType"].Value.ToString();
                    otherRelatives.Occupation.ID = int.Parse(row.Cells["relationOccupationID"].Value.ToString());
                    otherRelatives.Relationship.ID = int.Parse(row.Cells["relationRelationshipID"].Value.ToString());
                    otherRelatives.Telephone = row.Cells["relationTelephone"].Value.ToString();
                    employee.OtherRelatives.Add(otherRelatives);
                }
            }
        }

        public void QuickSearchView(string search)
        {
            try
            {
                ClearAll();
                employee = dal.GetByID<Employee>(search);
                if (employee.StaffID == null || employee.StaffID == string.Empty)
                {
                    search = String.Format("{0:###-###-##-##}", search);
                    employee = dal.GetByPhoneNumber<Employee>(search.Trim());
                }
                if (employee.StaffID != null && employee.StaffID != string.Empty)
                {
                    disableControls(employee,false);
                    btnView.Visible = true;
                    editMode = true;
                    //Personal Info
                    staffIDTextBox.Text = employee.StaffID;
                    txtPIN.Text = employee.PIN;
                    txtNationalID.Text = employee.NationalID;
                    checkBoxActive.Checked = employee.Payment;
                    //Images
                    if (employee.Photo != null)
                        pictureBox.Image = employee.Photo;
                    else
                        pictureBox.Image = pictureBox.InitialImage;

                    surnameTextBox.Text = employee.Surname;
                    txtFirstName.Text = employee.FirstName;
                    txtNumberOfChildren.Text = employee.NoOfChildren.ToString();
                    txtOtherName.Text = employee.OtherName;
                    txtMaidenName.Text = employee.MaidenName;
                    txtNickName.Text = employee.NickName;
                    txtFileNumber_DropDown(this, EventArgs.Empty);
                    txtFileNumber.Text = employee.FileNumber.Description;

                    txtTribe.Text = employee.Tribe;
                    txtOverseer.Text = employee.Overseer;
                    staffIDtxt_TextChanged(this, EventArgs.Empty);
                    staffIDtxt.Text = employee.SupervisorStaffID;
                    nametxt.Text = employee.SupervisorName;
                    searchGrid.CellClick += new DataGridViewCellEventHandler(searchGrid_CellClick);

                    cboRace_DropDown(this, EventArgs.Empty);
                    cboRace.Text = employee.Race.Description;

                    cboDisabilityType_DropDown(this, EventArgs.Empty);
                    cboDisabilityType.Text = employee.DisabilityType.Description;
                    checkBoxDisability.Checked = employee.IsDisable;
                    if (employee.DisabilityDate == null)
                    {
                        datePickerDisabilityDate.Checked = false;
                    }
                    else
                    {
                        datePickerDisabilityDate.Value = DateTime.Parse(employee.DisabilityDate.ToString()).Date;
                        datePickerDisabilityDate.Checked = true;
                    }

                    cboLicenceType_DropDown(this, EventArgs.Empty);
                    cboLicenceType.Text = employee.LicenceType.Description;
                    txtLicenceNumber.Text = employee.LicenceNumber;

                    cmbSex_DropDown(this, EventArgs.Empty);
                    cmbSex.Text = employee.Gender;
                    cmbMaritalStatus_DropDown(this, EventArgs.Empty);
                    cmbMaritalStatus.Text = employee.MaritalStatus;
                    cmbSex_SelectionChangeCommitted(this, EventArgs.Empty);
                    cmbTitle.Text = employee.Title.Description;
                    if (employee.DOB == null)
                    {
                        dateDOB.Checked = false;
                    }
                    else
                    {
                        dateDOB.Value = DateTime.Parse(employee.DOB.ToString()).Date;
                        dateDOB.Checked = true;
                    }
                    cboBirthDistrict_DropDown(this, EventArgs.Empty);
                    cboBirthDistrict.Text = employee.DistrictOfBirth.Description;
                    cboBirthDistrict_SelectionChangeCommitted(this, EventArgs.Empty);

                    cboBirthRegion_DropDown(this, EventArgs.Empty);
                    cboBirthRegion.Text = employee.RegionOfBirth.Description;
                    cboBirthDistrict_SelectionChangeCommitted(this, EventArgs.Empty);

                    cmbPOB.Text = employee.POB.Description;
                    cmbHomeTown_DropDown(this, EventArgs.Empty);
                    cmbHomeTown.Text = employee.HomeTown.Description;
                    cboQualificationType_DropDown(this, EventArgs.Empty);
                    cboQualificationType.Text = employee.QualificationType.Description;
                    cboBirthCountry_DropDown(this, EventArgs.Empty);
                    cboBirthCountry.Text = employee.CountryOfBirth.Description;
                    cboNationality_DropDown(this, EventArgs.Empty);
                    cboNationality.Text = employee.Nationality.Description;
                    cmbReligion_DropDown(this, EventArgs.Empty);
                    cmbReligion.Text = employee.Religion.Description;
                    cmbReligion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboDenomination.Text = employee.Denomination.Description;
                    txtNHISNumber.Text = employee.NHISNumber;
                    cmbMaritalStatus_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboZone_DropDown(this, EventArgs.Empty);
                    cboZone.Text = employee.Zone.Description;
                    if (employee.InZoneDate == null)
                    {
                        zoneDatePicker.Checked = false;
                    }
                    else
                    {
                        zoneDatePicker.Value = DateTime.Parse(employee.InZoneDate.ToString()).Date;
                        zoneDatePicker.Checked = true;
                    }
                    if (employee.DOM == null)
                    {
                        dateDOM.Checked = false;
                    }
                    else
                    {
                        dateDOM.Value = DateTime.Parse(employee.DOM.ToString()).Date;
                        dateDOM.Checked = true;
                    }

                    //Contact Address
                    txtContactPostalAddress.Text = employee.Address;
                    cboContactRegion_DropDown(this, EventArgs.Empty);
                    cboContactRegion.Text = employee.Region.Description;
                    cboContactRegion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboContactCity.Text = employee.Town.Description;
                    cboContactCountry_DropDown(this, EventArgs.Empty);
                    cboContactCountry.Text = employee.ContactCountry.Description;
                    cboContactHomeTown_DropDown(this, EventArgs.Empty);
                    cboContactHomeTown.Text = employee.ContactHomeTown.Description;
                    txtContactTelephone.Text = employee.TelNo;
                    txtContactMobileNumber.Text = employee.MobileNo;
                    txtContactEmailAddress.Text = employee.Email;

                    //Residential
                    txtResidentialHouseNumber.Text = employee.HouseNumber;
                    txtResidentialStreetName.Text = employee.StreetName;
                    cboResidentialRegion_DropDown(this, EventArgs.Empty);
                    cboResidentialRegion.Text = employee.ResidentialRegion.Description;
                    cboResidentialRegion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboResidentialCity.Text = employee.ResidentialTown.Description;
                    cboResidentialCountry_DropDown(this, EventArgs.Empty);
                    cboResidentialCountry.Text = employee.ResidentialCountry.Description;

                    //Job Detail
                    departmentComboBox_DropDown(this, EventArgs.Empty);
                    departmentComboBox.Text = employee.Department.Description;
                    departmentComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboUnit.Text = employee.Unit.Description;
                    cboJobTitle_DropDown(this, EventArgs.Empty);
                    cboJobTitle.Text = employee.JobTitle.Description;
                    cboSpecialty_DropDown(this, EventArgs.Empty);
                    cboSpecialty.Text = employee.Specialty.Description;
                    cboOccupationGrp_DropDown(this, EventArgs.Empty);
                    cboOccupationGrp.Text = employee.OccupationGroup.Description;
                    cboEmploymentStatus_DropDown(this, EventArgs.Empty);
                    cboEmploymentStatus.Text = employee.StaffStatus.Description;

                    if (employee.DOFA == null)
                    {
                        DOFADatePicker.Checked = false;
                    }
                    else
                    {
                        DOFADatePicker.Value = DateTime.Parse(employee.DOFA.ToString()).Date;
                        DOFADatePicker.Checked = true;
                    }
                    if (employee.DOCA == null)
                    {
                        DOCADatePicker.Checked = false;
                    }
                    else
                    {
                        DOCADatePicker.Value = DateTime.Parse(employee.DOCA.ToString()).Date;
                        DOCADatePicker.Checked = true;
                    }
                    if (employee.AssumptionDate == null)
                    {
                        assumptionDatePicker.Checked = false;
                    }
                    else
                    {
                        assumptionDatePicker.Value = DateTime.Parse(employee.AssumptionDate.ToString()).Date;
                        assumptionDatePicker.Checked = true;
                    }

                    probationCheckBox.Checked = employee.Probation;
                    probationCheckBox_CheckedChanged(this, EventArgs.Empty);
                    if (employee.ProbationStartDate == null)
                    {
                        startDatePicker.Checked = false;
                    }
                    else
                    {
                        startDatePicker.Value = DateTime.Parse(employee.ProbationStartDate.ToString()).Date;
                        startDatePicker.Checked = true;
                    }
                    if (employee.ProbationEndDate == null)
                    {
                        endDatePicker.Checked = false;
                    }
                    else
                    {
                        endDatePicker.Value = DateTime.Parse(employee.ProbationEndDate.ToString()).Date;
                        endDatePicker.Checked = true;
                    }
                    cboProbationStatus_DropDown(this, EventArgs.Empty);
                    cboProbationStatus.Text = employee.ProbationStatus.ToString();
                    cboAppointmentType_DropDown(this, EventArgs.Empty);
                    cboAppointmentType.Text = employee.AppointmentType.Description;

                    if (employee.EmploymentDate == null)
                    {
                        dateEmploymentDate.Checked = false;
                    }
                    else
                    {
                        dateEmploymentDate.Value = DateTime.Parse(employee.EmploymentDate.ToString()).Date;
                        dateEmploymentDate.Checked = true;
                    }


                    //probationCheckBox.Checked = employee.Probation;
                    //if (probationCheckBox.Checked)
                    //{
                    //    startDateLabel.Visible = true;
                    //    startDatePicker.Text = employee.ProbationStartDate.ToString();
                    //    endDateLabel.Visible = true;
                    //    endDatePicker.Visible = true;
                    //    startDatePicker.Text = employee.ProbationStartDate.ToString();
                    //    endDatePicker.Text = employee.ProbationEndDate.ToString();
                    //}
                    //else
                    //{
                    //    startDateLabel.Visible = false;
                    //    startDatePicker.Visible = false;
                    //    endDateLabel.Visible = false;
                    //    endDatePicker.Visible = false;
                    //    startDatePicker.ResetText();
                    //    endDatePicker.ResetText();
                    //}

                    //Transfer Details
                    transferredInRadioButton.Checked = employee.TransferedIn;
                    transferredOutRadioButton.Checked = employee.TransferredOut;

                    //Engagement Methods
                    cboEngagementType_DropDown(this, EventArgs.Empty);
                    cboEngagementType.Text = employee.EngagementType.ToString();
                    if (employee.EngagementDateApplied == null)
                    {
                        dateEngagementDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementDate.Value = DateTime.Parse(employee.EngagementDateApplied.ToString()).Date;
                        dateEngagementDate.Checked = true;
                    }

                    if (employee.EngagementContractOption != null && employee.EngagementContractOption != "0" && employee.EngagementContractOption.Trim() != string.Empty)
                    {
                        string contractOption = employee.EngagementContractOption;
                        if (contractOption != "0" && contractOption.Trim() != string.Empty)
                        {
                            string[] split = contractOption.Split(',');

                            foreach (string item in split)
                            {
                                if (item.ToString() != string.Empty)
                                {
                                    int y = checkedListBoxContract.Items.IndexOf(item);
                                    checkedListBoxContract.SetItemCheckState(y, CheckState.Checked);
                                }
                            }
                        }
                    }
                    cboEngagementGradeOn_DropDown(this, EventArgs.Empty);
                    cboEngagementGradeOn.Text = employee.EngagementGradeOn.Grade;
                    cboEngagementGradeLeaving_DropDown(this, EventArgs.Empty);
                    cboEngagementGradeLeaving.Text = employee.EngagementGradeLeaving.Grade;
                    if (employee.EngagementEffectiveDate == null)
                    {
                        dateEngagementEffectiveDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementEffectiveDate.Value = DateTime.Parse(employee.EngagementEffectiveDate.ToString()).Date;
                        dateEngagementEffectiveDate.Checked = true;
                    }
                    if (employee.EngagementEndingDate == null)
                    {
                        dateEngagementEndingDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementEndingDate.Value = DateTime.Parse(employee.EngagementEndingDate.ToString()).Date;
                        dateEngagementEndingDate.Checked = true;
                    }
                    txtEngagementAnnualSalary.Text = employee.EngagementAnnualSalary.ToString();
                    //Salary Details
                    gradeCategoryComboBox_DropDown(this, EventArgs.Empty);
                    gradeCategoryComboBox.Text = employee.GradeCategory.Description;
                    gradeCategoryComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                    gradeComboBox.Text = employee.Grade.Grade;
                    cboGradeOnFirstAppointment_DropDown(this, EventArgs.Empty);
                    cboGradeOnFirstAppointment.Text = employee.Grade.Grade;
                    if (employee.GradeDate == null)
                    {
                        gradeDatePicker.Checked = false;
                    }
                    else
                    {
                        gradeDatePicker.Value = DateTime.Parse(employee.GradeDate.ToString()).Date;
                        gradeDatePicker.Checked = true;
                    }
                    cboStep_DropDown(this, EventArgs.Empty);
                    cboStep.Text = employee.Step.Description;
                    txtSalary.Text = employee.BasicSalary.ToString();
                    cboSalaryGrouping_DropDown(this, EventArgs.Empty);
                    cboSalaryGrouping.Text = employee.SalaryGrouping;
                    cboLeaveEntitlement_DropDown(this, EventArgs.Empty);
                    cboLeaveEntitlement.Text = employee.AnnualLeaveEntitlement.CategoryOfPost + " " + employee.AnnualLeaveEntitlement.Status + " (" + employee.AnnualLeaveEntitlement.NumberOfDays + ")";
                    cboBand_DropDown(this, EventArgs.Empty);
                    cboBand.Text = employee.Band.Description;
                    paymentTypeComboBox_DropDown(this, EventArgs.Empty);
                    paymentTypeComboBox.Text = employee.PaymentType;
                    txtTIN.Text = employee.TIN;
                    checkBoxMechanised.Checked = employee.Mechanised;
                    ssnitCheckBox_CheckedChanged(this, EventArgs.Empty);
                    ssnitCheckBox.Checked = employee.SSNITContribution;
                    ssnitNoTextBox.Text = employee.SSNITNo;
                    incomeCheckBox.Checked = employee.IncomeTaxContribution;
                    isProvidentFundCheckBox_CheckedChanged(this, EventArgs.Empty);
                    isProvidentFundCheckBox.Checked = employee.IsProvidentFund;
                    numericPF.Value = employee.PFRate;
                    checkBoxExemptFromSecondTier.Checked = employee.IsExemptFromSecondTier;
                    susuPlusContributionCheckBox_CheckedChanged(this, EventArgs.Empty);
                    susuPlusContributionCheckBox.Checked = employee.IsSusuPlusContribution;
                    susuPlusContributionAmountTextBox.Text = employee.SusuPlusContributionAmount.ToString();

                    withholdingTaxCheckBox_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxCheckBox.Checked = employee.IsWithholdingTax;
                    withholdingTaxFixedAmountRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxFixedAmountRadioButton.Checked = employee.IsWithholdingTax;
                    withholdingTaxFixedAmountRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxFixedAmountRadioButton.Checked = employee.IsWithholdingTaxFixedAmount;
                    withholdingTaxFixedAmountTextBox.Text = employee.WithholdingTaxFixedAmount.ToString();
                    withholdingTaxRateRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxRateRadioButton.Checked = employee.IsWithholdingTaxRate;
                    withholdingTaxRateNumericUpDown.Value = decimal.Parse(employee.WithholdingTaxRate.ToString());
                    calculatedOnComboBox_DropDown(this, EventArgs.Empty);
                    calculatedOnComboBox.Text = employee.SalaryType.Description;

                    //if (ssnitCheckBox.Checked)
                    //{
                    //    ssnitNoLabel.Visible = true;
                    //    ssnitNoTextBox.Visible = true;
                    //    ssnitNoTextBox.Text = employee.SSNITNo;
                    //}
                    //else
                    //{
                    //    ssnitNoLabel.Visible = false;
                    //    ssnitNoTextBox.Visible = false;
                    //    ssnitNoTextBox.Clear();
                    //}

                    //Salary Details/Bank Details         
                    foreach (StaffBank staffBank in employee.StaffBank)
                    {
                        cboBankDetailName_DropDown(this, EventArgs.Empty);
                        cboBankDetailName.Text = staffBank.Bank.Description;
                        cboBankDetailName_SelectionChangeCommitted(this, EventArgs.Empty);
                        cboBankDetailBranch.Text = staffBank.BankBranch.Description;
                        cboBankDetailAccountType_DropDown(this, EventArgs.Empty);
                        cboBankDetailAccountType.Text = staffBank.AccountType.Description;
                        txtBankDetailAccountNumber.Text = staffBank.AccountNumber;
                        txtBankDetailAccountName.Text = staffBank.AccountName;
                        txtBankDetailAddress.Text = staffBank.Address;
                    }

                    //Finger Print Details
                    fingerPrintTextBox.Text = employee.FingerPrintID;
                    if (employee.FingerPrint != null)
                        fingerPrintPictureBox.Image = GlobalData.ArrayToImage(employee.FingerPrint);
                    else
                        fingerPrintPictureBox.Image = fingerPrintPictureBox.InitialImage;

                    //Clear User Info
                    userNameTextBox.Clear();
                    passwordTextBox.Clear();
                    confirmPasswordTextBox.Clear();
                    userRoleComboBox.Items.Clear();
                    userRoleComboBox.Text = string.Empty;
                    userGroupBox.Enabled = false;

                    //Work Permit
                    workPermitID = employee.WorkPermit.ID.ToString();
                    cmbWorkPermit.Text = employee.WorkPermit.HasPermit;
                    txtWorkPermitID.Text = employee.WorkPermit.WorkPermitID;
                    dateWorkPermit.Text = employee.WorkPermit.PermitExpires.ToString();
                    txtDuration.Value = employee.WorkPermit.Duration;
                    txtWorkPermitNotes.Text = employee.WorkPermit.Notes;

                    //Visa
                    visaID = employee.Visa.ID.ToString();
                    checkBoxHasVisa.Checked = employee.Visa.HasVisa;
                    txtVisaNo.Text = employee.Visa.VisaNo;
                    cmbVisaType.Text = employee.Visa.VisaType;
                    dateFrom.Text = employee.Visa.ValidFrom.ToString();
                    dateTo.Text = employee.Visa.ExpiresDate.ToString();
                    txtVisaNotes.Text = employee.Visa.Notes;

                    //Passport
                    passportID = employee.Passport.ID.ToString();
                    checkBoxHasPassport.Checked = employee.Passport.HasPassport;
                    txtPassportNo.Text = employee.Passport.PassportNo;
                    dateIssued.Text = employee.Passport.PassportIssueDate.ToString();
                    dateExpires.Text = employee.Passport.PassportExpiresDate.ToString();
                    txtPassportNotes.Text = employee.Passport.Notes;

                    //Social History
                    socialHistoryID = employee.SocialHistory.ID.ToString();
                    cmbConvicted.Text = employee.SocialHistory.Convicted;
                    cmbDisabled.Text = employee.SocialHistory.PhysicalDisability;
                    cmbBonded.Text = employee.SocialHistory.Bonded;
                    cmbApplied.Text = employee.SocialHistory.AppliedBefore;

                    int ctr = 0;
                    gridDocuments.Rows.Clear();

                    documentGroupsTable = dalHelper.ExecuteReader("Select * from DocumentGroupView Where DocumentGroupView.Archived = 'false' order by DocumentGroupView.description asc");
                    gridDocumentsDocumentGroup.Items.Clear();
                    foreach (DataRow row1 in documentGroupsTable.Rows)
                    {
                        gridDocumentsDocumentGroup.Items.Add(row1["Description"].ToString());
                    }

                    foreach (StaffDocument document in employee.Documents)
                    {
                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[ctr].Cells["gridDocumentsID"].Value = document.ID;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDateCreated"].Value = document.DateCreated;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDescription"].Value = document.Description;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentGroup"].Value = document.DocumentGroup;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentType"].Value = document.DocumentType;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentsContent"].Value = document.DocumentContent;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsPath"].Value = document.Path;
                        ctr++;
                    }

                    ctr = 0;
                    gridEducationHistory.Rows.Clear();

                    qualificationsFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        qualificationsFromMonth.Items.Add(month);
                    }

                    qualificationsToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        qualificationsToMonth.Items.Add(month);
                    }
                    qualificationsToMonth.Items.Add("To Date");

                    qualificationsFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsFromYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsToYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Add("To Date");

                    foreach (Qualification qualification in employee.Qualifications)
                    {
                        gridEducationHistory.Rows.Add(1);
                        gridEducationHistory.Rows[ctr].Cells["qualificationsID"].Value = qualification.ID;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsCertificateObtained"].Value = qualification.CertificateObtained;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsNameOfInstitution"].Value = qualification.NameOfInstitution;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromMonth"].Value = qualification.FromMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToMonth"].Value = qualification.ToMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromYear"].Value = qualification.FromYear;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToYear"].Value = qualification.ToYear;
                        ctr++;
                    }
                    ctr = 0;
                    gridProfession.Rows.Clear();

                    professionFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        professionFromMonth.Items.Add(month);
                    }

                    professionToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        professionToMonth.Items.Add(month);
                    }
                    professionToMonth.Items.Add("To Date");

                    professionFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionFromYear.Items.Add(year);
                    }
                    professionToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionToYear.Items.Add(year);
                    }
                    professionToYear.Items.Add("To Date");

                    foreach (Profession profession in employee.Professions)
                    {
                        gridProfession.Rows.Add(1);
                        gridProfession.Rows[ctr].Cells["professionID"].Value = profession.ID;
                        gridProfession.Rows[ctr].Cells["professionNameOfProfession"].Value = profession.NameOfProfession;
                        gridProfession.Rows[ctr].Cells["professionFromYear"].Value = profession.FromYear;
                        gridProfession.Rows[ctr].Cells["professionFromMonth"].Value = profession.FromMonth;
                        gridProfession.Rows[ctr].Cells["professionToMonth"].Value = profession.ToMonth;
                        gridProfession.Rows[ctr].Cells["professionToYear"].Value = profession.ToYear;
                        ctr++;
                    }
                    ctr = 0;
                    gridRefrees.Rows.Clear();
                    foreach (Referee referee in employee.Referees)
                    {
                        gridRefrees.Rows.Add(1);
                        gridRefrees.Rows[ctr].Cells["refereesID"].Value = referee.ID;
                        gridRefrees.Rows[ctr].Cells["refereesName"].Value = referee.Name;
                        gridRefrees.Rows[ctr].Cells["refereesAddress"].Value = referee.Address;
                        gridRefrees.Rows[ctr].Cells["refereesOccupation"].Value = referee.Occupation;
                        gridRefrees.Rows[ctr].Cells["refereesTelNo"].Value = referee.TelNo;
                        gridRefrees.Rows[ctr].Cells["refereesEmail"].Value = referee.Email;
                        ctr++;
                    }
                    ctr = 0;
                    gridEmploymentHistory.Rows.Clear();

                    experienceFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        experienceFromMonth.Items.Add(month);
                    }

                    experienceToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        experienceToMonth.Items.Add(month);
                    }
                    experienceToMonth.Items.Add("To Date");

                    experienceFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceFromYear.Items.Add(year);
                    }
                    experienceToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceToYear.Items.Add(year);
                    }
                    experienceToYear.Items.Add("To Date");

                    foreach (WorkExperience experience in employee.WorkExperiences)
                    {
                        gridEmploymentHistory.Rows.Add(1);
                        gridEmploymentHistory.Rows[ctr].Cells["experienceID"].Value = experience.ID;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromMonth"].Value = experience.FromMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToMonth"].Value = experience.ToMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromYear"].Value = experience.FromYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToYear"].Value = experience.ToYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceAnnualSalary"].Value = experience.AnnualSalary;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceNameOfOrganisation"].Value = experience.NameOfOrganisation;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceJobTitle"].Value = experience.JobTitle;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceReasonForLeaving"].Value = experience.ReasonForLeaving;
                        ctr++;
                    }

                    //Family Details/Spouse/Parents/Next of kin
                    ctr = 0;
                    gridRelations.Rows.Clear();
                    relationOccupation.Items.Clear();
                    occupations = dal.GetAll<Occupation>();
                    foreach (Occupation occupation in occupations)
                    {
                        relationOccupation.Items.Add(occupation.Description);
                    }
                    relationRelationship.Items.Clear();
                    relationships = dal.GetAll<Relationship>();
                    foreach (Relationship relationship in relationships)
                    {
                        relationRelationship.Items.Add(relationship.Description);
                    }
                    relationPOB.Items.Clear();
                    towns = dal.GetAll<Town>();
                    foreach (Town town in towns)
                    {
                        relationPOB.Items.Add(town.Description);
                    }
                    foreach (Relation relation in employee.OtherRelatives)
                    {
                        gridRelations.Rows.Add(1);
                        gridRelations.Rows[ctr].Cells["relationName"].Value = relation.Name;
                        gridRelations.Rows[ctr].Cells["relationID"].Value = relation.ID;
                        gridRelations.Rows[ctr].Cells["relationOccupation"].Value = relation.Occupation.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationOccupationID"].Value = relation.Occupation.ID;
                        gridRelations.Rows[ctr].Cells["relationRelationship"].Value = relation.Relationship.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationType"].Value = relation.Type.ToString();
                        gridRelations.Rows[ctr].Cells["relationRelationshipID"].Value = relation.Relationship.ID;
                        gridRelations.Rows[ctr].Cells["relationPOB"].Value = relation.POB.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationPOBID"].Value = relation.POB.ID;
                        gridRelations.Rows[ctr].Cells["relationDOB"].Value = relation.DOB;
                        gridRelations.Rows[ctr].Cells["relationTelephone"].Value = relation.Telephone;
                        gridRelations.Rows[ctr].Cells["relationAddress"].Value = relation.Address;

                        ctr++;
                    }
                    //foreach (Relation relation in employee.OtherRelatives)
                    //{
                    //    gridRelations.Rows.Add(1);
                    //    gridRelations.Rows[ctr].Cells["relationName"].Value = relation.Name;
                    //    gridRelations.Rows[ctr].Cells["relationID"].Value = relation.ID;
                    //    relationOccupation.DataSource = occupationsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationOccupation"].Value = relation.Occupation.Description.ToString();
                    //    gridRelations.DataError += new DataGridViewDataErrorEventHandler(gridRelations_DataError);
                    //    gridRelations.Rows[ctr].Cells["relationOccupationID"].Value = relation.Occupation.ID;
                    //    relationRelationship.DataSource = relationshipsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationRelationship"].Value = relation.Relationship.Description.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationType"].Value = relation.Type.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationRelationshipID"].Value = relation.Relationship.ID;
                    //    relationPOB.DataSource = townsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationPOB"].Value = relation.POB.Description.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationPOBID"].Value = relation.POB.ID;
                    //    gridRelations.Rows[ctr].Cells["relationDOB"].Value = relation.DOB;
                    //    gridRelations.Rows[ctr].Cells["relationTelephone"].Value = relation.Telephone;
                    //    gridRelations.Rows[ctr].Cells["relationAddress"].Value = relation.Address;

                    //    ctr++;
                    //}

                    //Language Details
                    ctr = 0;
                    gridLanguage.Rows.Clear();
                    colLanguage.Items.Clear();
                    languages = dal.GetAll<Language>();
                    foreach (Language language in languages)
                    {
                        colLanguage.Items.Add(language.Description);
                    }
                    foreach (StaffLanguage staffLanguage in employee.StaffLanguage)
                    {
                        gridLanguage.Rows.Add(1);
                        gridLanguage.Rows[ctr].Cells["gridLanguageID"].Value = staffLanguage.ID;
                        gridLanguage.Rows[ctr].Cells["colLanguage"].Value = staffLanguage.Language.Description;
                        gridLanguage.Rows[ctr].Cells["colLanguageLevel"].Value = staffLanguage.LanguageLevel;
                        ctr++;
                    }

                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != employee.User.ID)
                    {
                        btnSave.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Employee Could Not be found,Please Check the Number entered");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        public void PopulateView(DataGridViewRow row)
        {
            try
            {
                ClearAll();
                employee = dal.GetByID<Employee>(row.Cells["gridStaffNo"].Value.ToString());
                if (employee.StaffID != null && employee.StaffID != string.Empty)
                {
                    disableControls(employee,false);
                    btnView.Visible = true;
                    editMode = true;
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != employee.User.ID)
                    {
                        btnSave.Enabled = false;
                    }
                    //Personal Info
                    staffIDTextBox.Text = employee.StaffID;
                    txtPIN.Text = employee.PIN;
                    txtNationalID.Text = employee.NationalID;
                    checkBoxActive.Checked = employee.Payment;

                    //Images
                    if (employee.Photo != null)
                        pictureBox.Image = employee.Photo;
                    else
                        pictureBox.Image = pictureBox.InitialImage;

                    
                    surnameTextBox.Text = employee.Surname;
                    txtFirstName.Text = employee.FirstName;
                    txtNumberOfChildren.Text = employee.NoOfChildren.ToString();
                    txtOtherName.Text = employee.OtherName;
                    txtMaidenName.Text = employee.MaidenName;
                    txtNickName.Text = employee.NickName;
                    txtFileNumber_DropDown(this, EventArgs.Empty);
                    txtFileNumber.Text = employee.FileNumber.Description;

                    cboDisabilityType_DropDown(this, EventArgs.Empty);
                    cboDisabilityType.Text = employee.DisabilityType.Description;
                    checkBoxDisability.Checked = employee.IsDisable;
                    if (employee.DisabilityDate == null)
                    {
                        datePickerDisabilityDate.Checked = false;
                    }
                    else
                    {
                        datePickerDisabilityDate.Value = DateTime.Parse(employee.DisabilityDate.ToString()).Date;
                        datePickerDisabilityDate.Checked = true;
                    }

                    txtTribe.Text = employee.Tribe;
                    txtOverseer.Text = employee.Overseer;
                    staffIDtxt_TextChanged(this,EventArgs.Empty);
                    searchGrid.CellClick += new DataGridViewCellEventHandler(searchGrid_CellClick);
                    staffIDtxt.Text = employee.SupervisorStaffID;
                    nametxt.Text = employee.SupervisorName;
                    cboRace_DropDown(this, EventArgs.Empty);
                    cboRace.Text = employee.Race.Description;
                    

                    cboLicenceType_DropDown(this, EventArgs.Empty);
                    cboLicenceType.Text = employee.LicenceType.Description;
                    txtLicenceNumber.Text = employee.LicenceNumber;

                    cmbSex_DropDown(this, EventArgs.Empty);
                    cmbSex.Text = employee.Gender;
                    cmbMaritalStatus_DropDown(this, EventArgs.Empty);
                    cmbMaritalStatus.Text = employee.MaritalStatus;
                    cmbSex_SelectionChangeCommitted(this, EventArgs.Empty);
                    cmbTitle.Text = employee.Title.Description;
                    if (employee.DOB == null)
                    {
                        dateDOB.Checked = false;
                    }
                    else
                    {
                        dateDOB.Value = DateTime.Parse(employee.DOB.ToString()).Date;
                        dateDOB.Checked = true;
                    }
                    cboBirthDistrict_DropDown(this, EventArgs.Empty);
                    cboBirthDistrict.Text = employee.DistrictOfBirth.Description;
                    cboBirthDistrict_SelectionChangeCommitted(this, EventArgs.Empty);

                    cboBirthRegion_DropDown(this, EventArgs.Empty);
                    cboBirthRegion.Text = employee.RegionOfBirth.Description;
                    cboBirthDistrict_SelectionChangeCommitted(this, EventArgs.Empty);

                    cmbPOB.Text = employee.POB.Description;
                    cmbHomeTown_DropDown(this, EventArgs.Empty);
                    cmbHomeTown.Text = employee.HomeTown.Description;
                    cboQualificationType_DropDown(this, EventArgs.Empty);
                    cboQualificationType.Text = employee.QualificationType.Description;
                    cboBirthCountry_DropDown(this, EventArgs.Empty);
                    cboBirthCountry.Text = employee.CountryOfBirth.Description;
                    cboNationality_DropDown(this, EventArgs.Empty);
                    cboNationality.Text = employee.Nationality.Description;
                    cmbReligion_DropDown(this, EventArgs.Empty);
                    cmbReligion.Text = employee.Religion.Description;
                    cmbReligion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboDenomination.Text = employee.Denomination.Description;
                    txtNHISNumber.Text = employee.NHISNumber;
                    cmbMaritalStatus_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboZone_DropDown(this, EventArgs.Empty);
                    cboZone.Text = employee.Zone.Description;
                    if (employee.InZoneDate == null)
                    {
                        zoneDatePicker.Checked = false;
                    }
                    else
                    {
                        zoneDatePicker.Value = DateTime.Parse(employee.InZoneDate.ToString()).Date;
                        zoneDatePicker.Checked = true;
                    }
                    if (employee.DOM == null)
                    {
                        dateDOM.Checked = false;
                    }
                    else
                    {
                        dateDOM.Value = DateTime.Parse(employee.DOM.ToString()).Date;
                        dateDOM.Checked = true;
                    }

                    //Contact Address
                    txtContactPostalAddress.Text = employee.Address;
                    cboContactRegion_DropDown(this, EventArgs.Empty);
                    cboContactRegion.Text = employee.Region.Description;
                    cboContactRegion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboContactCity.Text = employee.Town.Description;
                    cboContactCountry_DropDown(this, EventArgs.Empty);
                    cboContactCountry.Text = employee.ContactCountry.Description;
                    cboContactHomeTown_DropDown(this, EventArgs.Empty);
                    cboContactHomeTown.Text = employee.ContactHomeTown.Description;
                    txtContactTelephone.Text = employee.TelNo;
                    txtContactMobileNumber.Text = employee.MobileNo;
                    txtContactEmailAddress.Text = employee.Email;

                    //Residential
                    txtResidentialHouseNumber.Text = employee.HouseNumber;
                    txtResidentialStreetName.Text = employee.StreetName;
                    cboResidentialRegion_DropDown(this, EventArgs.Empty);
                    cboResidentialRegion.Text = employee.ResidentialRegion.Description;
                    cboResidentialRegion_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboResidentialCity.Text = employee.ResidentialTown.Description;
                    cboResidentialCountry_DropDown(this, EventArgs.Empty);
                    cboResidentialCountry.Text = employee.ResidentialCountry.Description;

                    //Job Detail
                    departmentComboBox_DropDown(this, EventArgs.Empty);
                    departmentComboBox.Text = employee.Department.Description;
                    departmentComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                    cboUnit.Text = employee.Unit.Description;
                    cboJobTitle_DropDown(this, EventArgs.Empty);
                    cboJobTitle.Text = employee.JobTitle.Description;
                    cboSpecialty_DropDown(this, EventArgs.Empty);
                    cboSpecialty.Text = employee.Specialty.Description;
                    cboOccupationGrp_DropDown(this, EventArgs.Empty);
                    cboOccupationGrp.Text = employee.OccupationGroup.Description;
                    cboEmploymentStatus_DropDown(this, EventArgs.Empty);
                    cboEmploymentStatus.Text = employee.StaffStatus.Description;

                    if (employee.DOFA == null)
                    {
                        DOFADatePicker.Checked = false;
                    }
                    else
                    {
                        DOFADatePicker.Value = DateTime.Parse(employee.DOFA.ToString()).Date;
                        DOFADatePicker.Checked = true;
                    }
                    if (employee.DOCA == null)
                    {
                        DOCADatePicker.Checked = false;
                    }
                    else
                    {
                        DOCADatePicker.Value = DateTime.Parse(employee.DOCA.ToString()).Date;
                        DOCADatePicker.Checked = true;
                    }
                    if (employee.AssumptionDate == null)
                    {
                        assumptionDatePicker.Checked = false;
                    }
                    else
                    {
                        assumptionDatePicker.Value = DateTime.Parse(employee.AssumptionDate.ToString()).Date;
                        assumptionDatePicker.Checked = true;
                    }

                    probationCheckBox.Checked = employee.Probation;
                    probationCheckBox_CheckedChanged(this, EventArgs.Empty);
                    if (employee.ProbationStartDate == null)
                    {
                        startDatePicker.Checked = false;
                    }
                    else
                    {
                        startDatePicker.Value = DateTime.Parse(employee.ProbationStartDate.ToString()).Date;
                        startDatePicker.Checked = true;
                    }
                    if (employee.ProbationEndDate == null)
                    {
                        endDatePicker.Checked = false;
                    }
                    else
                    {
                        endDatePicker.Value = DateTime.Parse(employee.ProbationEndDate.ToString()).Date;
                        endDatePicker.Checked = true;
                    }
                    cboProbationStatus_DropDown(this, EventArgs.Empty);
                    cboProbationStatus.Text = employee.ProbationStatus.ToString();
                    cboAppointmentType_DropDown(this, EventArgs.Empty);
                    cboAppointmentType.Text = employee.AppointmentType.Description;

                    if (employee.EmploymentDate == null)
                    {
                        dateEmploymentDate.Checked = false;
                    }
                    else
                    {
                        dateEmploymentDate.Value = DateTime.Parse(employee.EmploymentDate.ToString()).Date;
                        dateEmploymentDate.Checked = true;
                    }


                    //probationCheckBox.Checked = employee.Probation;
                    //if (probationCheckBox.Checked)
                    //{
                    //    startDateLabel.Visible = true;
                    //    startDatePicker.Text = employee.ProbationStartDate.ToString();
                    //    endDateLabel.Visible = true;
                    //    endDatePicker.Visible = true;
                    //    startDatePicker.Text = employee.ProbationStartDate.ToString();
                    //    endDatePicker.Text = employee.ProbationEndDate.ToString();
                    //}
                    //else
                    //{
                    //    startDateLabel.Visible = false;
                    //    startDatePicker.Visible = false;
                    //    endDateLabel.Visible = false;
                    //    endDatePicker.Visible = false;
                    //    startDatePicker.ResetText();
                    //    endDatePicker.ResetText();
                    //}

                    //Transfer Details
                    transferredInRadioButton.Checked = employee.TransferedIn;
                    transferredOutRadioButton.Checked = employee.TransferredOut;

                    //Engagement Methods
                    cboEngagementType_DropDown(this, EventArgs.Empty);
                    cboEngagementType.Text = employee.EngagementType.ToString();
                    if (employee.EngagementDateApplied == null)
                    {
                        dateEngagementDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementDate.Value = DateTime.Parse(employee.EngagementDateApplied.ToString()).Date;
                        dateEngagementDate.Checked = true;
                    }

                    if (employee.EngagementContractOption != null && employee.EngagementContractOption != "0" && employee.EngagementContractOption.Trim() != string.Empty)
                    {
                        string contractOption = employee.EngagementContractOption;
                        if (contractOption != "0" && contractOption.Trim() != string.Empty)
                        {
                            string[] split = contractOption.Split(',');

                            foreach (string item in split)
                            {
                                if (item.ToString() != string.Empty)
                                {
                                    int y = checkedListBoxContract.Items.IndexOf(item);
                                    checkedListBoxContract.SetItemCheckState(y, CheckState.Checked);
                                }
                            }
                        }
                    }
                    cboEngagementGradeOn_DropDown(this, EventArgs.Empty);
                    cboEngagementGradeOn.Text = employee.EngagementGradeOn.Grade;
                    cboEngagementGradeLeaving_DropDown(this, EventArgs.Empty);
                    cboEngagementGradeLeaving.Text = employee.EngagementGradeLeaving.Grade;
                    if (employee.EngagementEffectiveDate == null)
                    {
                        dateEngagementEffectiveDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementEffectiveDate.Value = DateTime.Parse(employee.EngagementEffectiveDate.ToString()).Date;
                        dateEngagementEffectiveDate.Checked = true;
                    }
                    if (employee.EngagementEndingDate == null)
                    {
                        dateEngagementEndingDate.Checked = false;
                    }
                    else
                    {
                        dateEngagementEndingDate.Value = DateTime.Parse(employee.EngagementEndingDate.ToString()).Date;
                        dateEngagementEndingDate.Checked = true;
                    }
                    txtEngagementAnnualSalary.Text = employee.EngagementAnnualSalary.ToString();
                    //Salary Details
                    gradeCategoryComboBox_DropDown(this, EventArgs.Empty);
                    gradeCategoryComboBox.Text = employee.GradeCategory.Description;
                    gradeCategoryComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                    gradeComboBox.Text = employee.Grade.Grade;
                    cboGradeOnFirstAppointment_DropDown(this, EventArgs.Empty);
                    cboGradeOnFirstAppointment.Text = employee.GradeOnFirstAppointment.Grade;
                    if (employee.GradeDate == null)
                    {
                        gradeDatePicker.Checked = false;
                    }
                    else
                    {
                        gradeDatePicker.Value = DateTime.Parse(employee.GradeDate.ToString()).Date;
                        gradeDatePicker.Checked = true;
                    }
                    cboStep_DropDown(this, EventArgs.Empty);
                    cboStep.Text = employee.Step.Description;
                    txtSalary.Text = employee.BasicSalary.ToString();
                    cboBand_DropDown(this, EventArgs.Empty);
                    cboBand.Text = employee.Band.Description;
                    cboSalaryGrouping_DropDown(this, EventArgs.Empty);
                    cboSalaryGrouping.Text = employee.SalaryGrouping;
                    cboLeaveEntitlement_DropDown(this, EventArgs.Empty);
                    cboLeaveEntitlement.Text = employee.AnnualLeaveEntitlement.CategoryOfPost + " " + employee.AnnualLeaveEntitlement.Status + " (" + employee.AnnualLeaveEntitlement.NumberOfDays + ")";
                    paymentTypeComboBox_DropDown(this, EventArgs.Empty);
                    paymentTypeComboBox.Text = employee.PaymentType;
                    txtTIN.Text = employee.TIN;
                    checkBoxMechanised.Checked = employee.Mechanised;
                    ssnitCheckBox_CheckedChanged(this, EventArgs.Empty);
                    ssnitCheckBox.Checked = employee.SSNITContribution;
                    ssnitNoTextBox.Text = employee.SSNITNo;
                    incomeCheckBox.Checked = employee.IncomeTaxContribution;
                    isProvidentFundCheckBox_CheckedChanged(this, EventArgs.Empty);
                    isProvidentFundCheckBox.Checked = employee.IsProvidentFund;
                    numericPF.Value = employee.PFRate;
                    checkBoxExemptFromSecondTier.Checked = employee.IsExemptFromSecondTier;

                    susuPlusContributionCheckBox_CheckedChanged(this, EventArgs.Empty);
                    susuPlusContributionCheckBox.Checked = employee.IsSusuPlusContribution;
                    susuPlusContributionAmountTextBox.Text = employee.SusuPlusContributionAmount.ToString();

                    withholdingTaxCheckBox_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxCheckBox.Checked = employee.IsWithholdingTax;
                    withholdingTaxFixedAmountRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxFixedAmountRadioButton.Checked = employee.IsWithholdingTax;
                    withholdingTaxFixedAmountRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxFixedAmountRadioButton.Checked = employee.IsWithholdingTaxFixedAmount;
                    withholdingTaxFixedAmountTextBox.Text = employee.WithholdingTaxFixedAmount.ToString();
                    withholdingTaxRateRadioButton_CheckedChanged(this, EventArgs.Empty);
                    withholdingTaxRateRadioButton.Checked = employee.IsWithholdingTaxRate;
                    withholdingTaxRateNumericUpDown.Value = decimal.Parse(employee.WithholdingTaxRate.ToString());
                    calculatedOnComboBox_DropDown(this, EventArgs.Empty);
                    calculatedOnComboBox.Text = employee.SalaryType.Description;

                    //if (ssnitCheckBox.Checked)
                    //{
                    //    ssnitNoLabel.Visible = true;
                    //    ssnitNoTextBox.Visible = true;
                    //    ssnitNoTextBox.Text = employee.SSNITNo;
                    //}
                    //else
                    //{
                    //    ssnitNoLabel.Visible = false;
                    //    ssnitNoTextBox.Visible = false;
                    //    ssnitNoTextBox.Clear();
                    //}

                    //Salary Details/Bank Details         
                    foreach (StaffBank staffBank in employee.StaffBank)
                    {
                        cboBankDetailName_DropDown(this, EventArgs.Empty);
                        cboBankDetailName.Text = staffBank.Bank.Description;
                        cboBankDetailName_SelectionChangeCommitted(this, EventArgs.Empty);
                        cboBankDetailBranch.Text = staffBank.BankBranch.Description;
                        cboBankDetailAccountType_DropDown(this, EventArgs.Empty);
                        cboBankDetailAccountType.Text = staffBank.AccountType.Description;
                        txtBankDetailAccountNumber.Text = staffBank.AccountNumber;
                        txtBankDetailAccountName.Text = staffBank.AccountName;
                        txtBankDetailAddress.Text = staffBank.Address;
                    }

                    //Finger Print Details
                    fingerPrintTextBox.Text = employee.FingerPrintID;
                    if (employee.FingerPrint != null)
                        fingerPrintPictureBox.Image = GlobalData.ArrayToImage(employee.FingerPrint);
                    else
                        fingerPrintPictureBox.Image = fingerPrintPictureBox.InitialImage;

                    //Clear User Info
                    userNameTextBox.Clear();
                    passwordTextBox.Clear();
                    confirmPasswordTextBox.Clear();
                    userRoleComboBox.Items.Clear();
                    userRoleComboBox.Text = string.Empty;
                    userGroupBox.Enabled = false;

                    //Work Permit
                    workPermitID = employee.WorkPermit.ID.ToString();
                    cmbWorkPermit.Text = employee.WorkPermit.HasPermit;
                    txtWorkPermitID.Text = employee.WorkPermit.WorkPermitID;
                    dateWorkPermit.Text = employee.WorkPermit.PermitExpires.ToString();
                    txtDuration.Value = employee.WorkPermit.Duration;
                    txtWorkPermitNotes.Text = employee.WorkPermit.Notes;

                    //Visa
                    visaID = employee.Visa.ID.ToString();
                    checkBoxHasVisa.Checked = employee.Visa.HasVisa;
                    txtVisaNo.Text = employee.Visa.VisaNo;
                    cmbVisaType.Text = employee.Visa.VisaType;
                    dateFrom.Text = employee.Visa.ValidFrom.ToString();
                    dateTo.Text = employee.Visa.ExpiresDate.ToString();
                    txtVisaNotes.Text = employee.Visa.Notes;

                    //Passport
                    passportID = employee.Passport.ID.ToString();
                    checkBoxHasPassport.Checked = employee.Passport.HasPassport;
                    txtPassportNo.Text = employee.Passport.PassportNo;
                    dateIssued.Text = employee.Passport.PassportIssueDate.ToString();
                    dateExpires.Text = employee.Passport.PassportExpiresDate.ToString();
                    txtPassportNotes.Text = employee.Passport.Notes;

                    //Social History
                    socialHistoryID = employee.SocialHistory.ID.ToString();
                    cmbConvicted.Text = employee.SocialHistory.Convicted;
                    cmbDisabled.Text = employee.SocialHistory.PhysicalDisability;
                    cmbBonded.Text = employee.SocialHistory.Bonded;
                    cmbApplied.Text = employee.SocialHistory.AppliedBefore;

                    int ctr = 0;
                    gridDocuments.Rows.Clear();

                    documentGroupsTable = dalHelper.ExecuteReader("Select * from DocumentGroupView Where DocumentGroupView.Archived = 'false' order by DocumentGroupView.description asc");
                    gridDocumentsDocumentGroup.Items.Clear();
                    foreach (DataRow row1 in documentGroupsTable.Rows)
                    {
                        gridDocumentsDocumentGroup.Items.Add(row1["Description"].ToString());
                    }

                    foreach (StaffDocument document in employee.Documents)
                    {
                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[ctr].Cells["gridDocumentsID"].Value = document.ID;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDateCreated"].Value = document.DateCreated;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDescription"].Value = document.Description;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentGroup"].Value = document.DocumentGroup;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentType"].Value = document.DocumentType;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentsContent"].Value = document.DocumentContent;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsPath"].Value = document.Path;
                        ctr++;
                    }

                    ctr = 0;
                    gridEducationHistory.Rows.Clear();

                    qualificationsFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        qualificationsFromMonth.Items.Add(month);
                    }

                    qualificationsToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        qualificationsToMonth.Items.Add(month);
                    }
                    qualificationsToMonth.Items.Add("To Date");

                    qualificationsFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsFromYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        qualificationsToYear.Items.Add(year);
                    }
                    qualificationsToYear.Items.Add("To Date");

                    foreach (Qualification qualification in employee.Qualifications)
                    {
                        gridEducationHistory.Rows.Add(1);
                        gridEducationHistory.Rows[ctr].Cells["qualificationsID"].Value = qualification.ID;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsCertificateObtained"].Value = qualification.CertificateObtained;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsNameOfInstitution"].Value = qualification.NameOfInstitution;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromMonth"].Value = qualification.FromMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToMonth"].Value = qualification.ToMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromYear"].Value = qualification.FromYear;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToYear"].Value = qualification.ToYear;
                        ctr++;
                    }
                    ctr = 0;
                    gridProfession.Rows.Clear();

                    professionFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        professionFromMonth.Items.Add(month);
                    }

                    professionToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        professionToMonth.Items.Add(month);
                    }
                    professionToMonth.Items.Add("To Date");

                    professionFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionFromYear.Items.Add(year);
                    }
                    professionToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        professionToYear.Items.Add(year);
                    }
                    professionToYear.Items.Add("To Date");

                    foreach (Profession profession in employee.Professions)
                    {
                        gridProfession.Rows.Add(1);
                        gridProfession.Rows[ctr].Cells["professionID"].Value = profession.ID;
                        gridProfession.Rows[ctr].Cells["professionNameOfProfession"].Value = profession.NameOfProfession;
                        gridProfession.Rows[ctr].Cells["professionFromYear"].Value = profession.FromYear;
                        gridProfession.Rows[ctr].Cells["professionFromMonth"].Value = profession.FromMonth;
                        gridProfession.Rows[ctr].Cells["professionToMonth"].Value = profession.ToMonth;
                        gridProfession.Rows[ctr].Cells["professionToYear"].Value = profession.ToYear;
                        ctr++;
                    }
                    ctr = 0;
                    gridRefrees.Rows.Clear();
                    foreach (Referee referee in employee.Referees)
                    {
                        gridRefrees.Rows.Add(1);
                        gridRefrees.Rows[ctr].Cells["refereesID"].Value = referee.ID;
                        gridRefrees.Rows[ctr].Cells["refereesName"].Value = referee.Name;
                        gridRefrees.Rows[ctr].Cells["refereesAddress"].Value = referee.Address;
                        gridRefrees.Rows[ctr].Cells["refereesOccupation"].Value = referee.Occupation;
                        gridRefrees.Rows[ctr].Cells["refereesTelNo"].Value = referee.TelNo;
                        gridRefrees.Rows[ctr].Cells["refereesEmail"].Value = referee.Email;
                        ctr++;
                    }
                    ctr = 0;
                    gridEmploymentHistory.Rows.Clear();

                    experienceFromMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        experienceFromMonth.Items.Add(month);
                    }

                    experienceToMonth.Items.Clear();
                    foreach (string month in GlobalData.GetMonths())
                    {
                        experienceToMonth.Items.Add(month);
                    }
                    experienceToMonth.Items.Add("To Date");

                    experienceFromYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceFromYear.Items.Add(year);
                    }
                    experienceToYear.Items.Clear();
                    foreach (string year in GlobalData.GetYears())
                    {
                        experienceToYear.Items.Add(year);
                    }
                    experienceToYear.Items.Add("To Date");

                    foreach (WorkExperience experience in employee.WorkExperiences)
                    {
                        gridEmploymentHistory.Rows.Add(1);
                        gridEmploymentHistory.Rows[ctr].Cells["experienceID"].Value = experience.ID;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromMonth"].Value = experience.FromMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToMonth"].Value = experience.ToMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromYear"].Value = experience.FromYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToYear"].Value = experience.ToYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceAnnualSalary"].Value = experience.AnnualSalary;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceNameOfOrganisation"].Value = experience.NameOfOrganisation;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceJobTitle"].Value = experience.JobTitle;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceReasonForLeaving"].Value = experience.ReasonForLeaving;
                        ctr++;
                    }

                    //Family Details/Spouse/Parents/Next of kin
                    ctr = 0;
                    gridRelations.Rows.Clear();
                    relationOccupation.Items.Clear();
                    occupations=dal.GetAll<Occupation>();
                    foreach (Occupation occupation in occupations)
                    {
                        relationOccupation.Items.Add(occupation.Description);
                    }
                    relationRelationship.Items.Clear();
                    relationships = dal.GetAll<Relationship>();
                    foreach (Relationship relationship in relationships)
                    {
                        relationRelationship.Items.Add(relationship.Description);
                    }
                    relationPOB.Items.Clear();
                    towns = dal.GetAll<Town>();
                    foreach (Town town in towns)
                    {
                        relationPOB.Items.Add(town.Description);
                    }
                    foreach (Relation relation in employee.OtherRelatives)
                    {
                        gridRelations.Rows.Add(1);
                        gridRelations.Rows[ctr].Cells["relationName"].Value = relation.Name;
                        gridRelations.Rows[ctr].Cells["relationID"].Value = relation.ID;
                        gridRelations.Rows[ctr].Cells["relationOccupation"].Value = relation.Occupation.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationOccupationID"].Value = relation.Occupation.ID;
                        gridRelations.Rows[ctr].Cells["relationRelationship"].Value = relation.Relationship.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationType"].Value = relation.Type.ToString();
                        gridRelations.Rows[ctr].Cells["relationRelationshipID"].Value = relation.Relationship.ID;
                        gridRelations.Rows[ctr].Cells["relationPOB"].Value = relation.POB.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationPOBID"].Value = relation.POB.ID;
                        gridRelations.Rows[ctr].Cells["relationDOB"].Value = relation.DOB;
                        gridRelations.Rows[ctr].Cells["relationTelephone"].Value = relation.Telephone;
                        gridRelations.Rows[ctr].Cells["relationAddress"].Value = relation.Address;

                        ctr++;
                    }
                    //foreach (Relation relation in employee.OtherRelatives)
                    //{
                    //    gridRelations.Rows.Add(1);
                    //    gridRelations.Rows[ctr].Cells["relationName"].Value = relation.Name;
                    //    gridRelations.Rows[ctr].Cells["relationID"].Value = relation.ID;
                    //    relationOccupation.DataSource = occupationsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationOccupation"].Value = relation.Occupation.Description.ToString();
                    //    gridRelations.DataError += new DataGridViewDataErrorEventHandler(gridRelations_DataError);
                    //    gridRelations.Rows[ctr].Cells["relationOccupationID"].Value = relation.Occupation.ID;
                    //    relationRelationship.DataSource = relationshipsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationRelationship"].Value = relation.Relationship.Description.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationType"].Value = relation.Type.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationRelationshipID"].Value = relation.Relationship.ID;
                    //    relationPOB.DataSource = townsBindingSource;
                    //    gridRelations.Rows[ctr].Cells["relationPOB"].Value = relation.POB.Description.ToString();
                    //    gridRelations.Rows[ctr].Cells["relationPOBID"].Value = relation.POB.ID;
                    //    gridRelations.Rows[ctr].Cells["relationDOB"].Value = relation.DOB;
                    //    gridRelations.Rows[ctr].Cells["relationTelephone"].Value = relation.Telephone;
                    //    gridRelations.Rows[ctr].Cells["relationAddress"].Value = relation.Address;

                    //    ctr++;
                    //}

                    //Language Details
                    ctr = 0;
                    gridLanguage.Rows.Clear();
                    colLanguage.Items.Clear();
                    languages=dal.GetAll<Language>();
                    foreach (Language language in languages)
                    {
                        colLanguage.Items.Add(language.Description);
                    }
                    foreach (StaffLanguage staffLanguage in employee.StaffLanguage)
                    {
                        gridLanguage.Rows.Add(1);
                        gridLanguage.Rows[ctr].Cells["gridLanguageID"].Value = staffLanguage.ID;
                        gridLanguage.Rows[ctr].Cells["colLanguage"].Value = staffLanguage.Language.Description;
                        gridLanguage.Rows[ctr].Cells["colLanguageLevel"].Value = staffLanguage.LanguageLevel;
                        ctr++;
                    }
                }
                else
                {
                    MessageBox.Show("Employee cannot be found");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }       
        }

        private void ClearStaffPersonalInfo()
        {
            try
            {
                docGroupErrorProvider.Clear();
                fingerPrintErrorProvider.Clear();
                staffIDTextBox.Clear();
                surnameTextBox.Clear();
                txtFirstName.Clear();
                txtOtherName.Clear();
                cmbTitle.Items.Clear();
                cmbTitle.Text = string.Empty;
                dateDOB.ResetText();
                cmbSex.Items.Clear();
                cmbSex.Text = string.Empty;
                cboNationality.Items.Clear();
                cboNationality.Text = string.Empty;
                cmbReligion.Items.Clear();
                cmbReligion.Text = string.Empty;
                cmbHomeTown.Items.Clear();
                cmbHomeTown.Text = string.Empty;
                cmbMaritalStatus.Items.Clear();
                cmbMaritalStatus.Text = string.Empty;

                //Disability
                cboDisabilityType.Items.Clear();
                cboDisabilityType.Text = string.Empty;
                datePickerDisabilityDate.ResetText();
                checkBoxDisability.Checked = false;
                //Licence
                cboLicenceType.Items.Clear();
                txtLicenceNumber.Text = string.Empty;

                txtNumberOfChildren.Value = 0;
                txtContactPostalAddress.Clear();
                txtResidentialHouseNumber.Clear();
                txtContactTelephone.Clear();
                txtContactMobileNumber.Clear();
                txtContactEmailAddress.Clear();
                cmbPOB.Items.Clear();
                cmbPOB.Text = string.Empty;
                pictureBox.Image = pictureBox.InitialImage;
                fingerPrintPictureBox.Image = fingerPrintPictureBox.InitialImage;
                verifiedPictureBox.Visible = false;
                notVerifiedPictureBox.Visible = true;

                //User Acount
                userRoleComboBox.Items.Clear();
                userRoleComboBox.Text = string.Empty;
                userNameTextBox.Clear();
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();

                //Job Details
                dateEmploymentDate.ResetText();
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                cboQualificationType.Items.Clear();
                cboQualificationType.Text = string.Empty;

                ssnitCheckBox.Checked = false;
                incomeCheckBox.Checked = false;
                probationCheckBox.Checked = false;

                gridEducationHistory.Rows.Clear();
                gridProfession.Rows.Clear();
                gridRefrees.Rows.Clear();
                gridRelations.Rows.Clear();
                gridDocuments.Rows.Clear();
                gridEmploymentHistory.Rows.Clear();

                cmbWorkPermit.ResetText();
                dateWorkPermit.ResetText();
                txtDuration.Value = 0;
                txtWorkPermitNotes.Clear();
                txtPassportNo.Clear();
                dateExpires.ResetText();
                dateIssued.ResetText();
                txtPassportNotes.Clear();
                dateFrom.ResetText();
                dateTo.ResetText();
                cmbVisaType.ResetText();
                txtVisaNotes.Clear();
                cmbConvicted.Text = "No";
                cmbBonded.Text = "No";
                cmbDisabled.Text = "No";
                cmbApplied.Text = "No";
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        private void browse_imagebtn_Click(object sender, EventArgs e)
        {
            try
            {
                ShowPictureDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            try
            {
                //Get the image current width
                int sourceWidth = imgToResize.Width;
                //Get the image current height
                int sourceHeight = imgToResize.Height;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;
                //Calulate  width with new desired size
                nPercentW = ((float)size.Width / (float)sourceWidth);
                //Calculate height with new desired size
                nPercentH = ((float)size.Height / (float)sourceHeight);

                if (nPercentH < nPercentW)
                    nPercent = nPercentH;
                else
                    nPercent = nPercentW;
                //New Width
                int destWidth = (int)(sourceWidth * nPercent);
                //New Height
                int destHeight = (int)(sourceHeight * nPercent);
                Bitmap b = new Bitmap(destWidth, destHeight);
                try
                {
                    Graphics g = Graphics.FromImage((System.Drawing.Image)b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    // Draw image with new width and height
                    g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    throw ex;
                }
                return (System.Drawing.Image)b;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ShowPictureDialog()
        {
            try
            {
                OpenFileDialog pictureDialog = new OpenFileDialog();
                pictureDialog.Multiselect = false;
                pictureDialog.RestoreDirectory = true;
                pictureDialog.Title = "Select A Picture";
                pictureDialog.AutoUpgradeEnabled = true;
                pictureDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                pictureDialog.Filter = "Image Files(*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG)|*.JPE;*.JPEG;*.JFIF;*.JPG;*.EXIF;*.TIFF;*.TIF;*.PAW;*.PNG;*.GIF;*.BMP;*.PPM;*.PGM;*.PBM;*.PNM;*.CGM;*.SVG|All Files(*.*)|*.*";
                pictureDialog.CheckFileExists = true;
                if (pictureDialog.ShowDialog(this) == DialogResult.OK)
                {
                    pictureBox.Image = Image.FromFile(pictureDialog.FileName);
                    pictureBox.Image = resizeImage(pictureBox.Image, new Size(150, 150));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();
                if (Validator.Errors.Count > 0)
                {
                    foreach (KeyValuePair<string, string> error in Validator.Errors)
                    {
                        if (error.Key == "StaffID")
                        {
                            result = false;
                            staffErrorProvider.SetError(staffIDTextBox, error.Value);
                        }
                        if (error.Key == "Surname")
                        {
                            result = false;
                            staffErrorProvider.SetError(surnameTextBox, error.Value);
                        }
                        if (error.Key == "OtherName")
                        {
                            result = false;
                            staffErrorProvider.SetError(txtOtherName, error.Value);
                        }
                        if (error.Key == "FirstName")
                        {
                            result = false;
                            staffErrorProvider.SetError(txtFirstName, error.Value);
                        }
                        if (error.Key == "Title")
                        {
                            result = false;
                            staffErrorProvider.SetError(cmbTitle, error.Value);
                        }
                        if (error.Key == "DateOfBirth")
                        {
                            result = false;
                            staffErrorProvider.SetError(dateDOB, error.Value);
                        }
                        if (error.Key == "Gender")
                        {
                            result = false;
                            staffErrorProvider.SetError(cmbSex, error.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        #endregion


        private void Save()
        {
            UpdateEmployeeEntity(employee);
            if (ValidateFields())
            {
                try
                {
                    dal.OpenConnection();
                    dal.BeginTransaction();
                    if (editMode)
                    {
                        dal.Update(employee);
                        employee = dal.GetByID<Employee>(employee.StaffID);
                        //PopulateView(employee);
                    }
                    else
                    {
                        dal.Save(employee);
                        ClearStaffPersonalInfo();
                    }
                    dal.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dal.RollBackTransaction();
                    Logger.LogError(ex);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.gridRelations.DataSource = null;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the ff employee:\nFull Name: " + employee.FirstName + " " + employee.OtherName + " " + employee.Surname, GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                try
                {
                    dal.Delete(employee);
                    this.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void dateWorkPermit_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dateWorkPermit.Text != string.Empty)
                {
                    if (DateTime.Parse(dateWorkPermit.Text) > Hospital.CurrentDate)
                    {
                        txtDuration.Text = DateTime.Parse(dateWorkPermit.Text).Subtract(Hospital.CurrentDate).Days.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDeleteDocuments_Click(object sender, EventArgs e)
        {
            if (gridDocuments.CurrentRow != null)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffDocuments where ID =" + gridDocuments.CurrentRow.Cells["gridDocumentsID"].Value.ToString());
                    gridDocuments.Rows.RemoveAt(gridDocuments.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnDeleteEmploymentHistory_Click(object sender, EventArgs e)
        {
            if (gridEmploymentHistory.CurrentRow != null && !gridEmploymentHistory.CurrentRow.IsNewRow)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffExperience where ID =" + gridEmploymentHistory.CurrentRow.Cells["experienceID"].Value.ToString());
                    gridEmploymentHistory.Rows.RemoveAt(gridEmploymentHistory.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnDeleteFamilyDetails_Click(object sender, EventArgs e)
        {

            if (gridRelations.CurrentRow != null && !gridRelations.CurrentRow.IsNewRow)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffOtherRelatives where ID =" + gridRelations.CurrentRow.Cells["relationID"].Value.ToString());
                    gridRelations.Rows.RemoveAt(gridRelations.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnDeleteRefrees_Click(object sender, EventArgs e)
        {
            if (gridRefrees.CurrentRow != null && !gridRefrees.CurrentRow.IsNewRow)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffReferees where ID =" + gridRefrees.CurrentRow.Cells["refereesID"].Value.ToString());
                    gridRefrees.Rows.RemoveAt(gridRefrees.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnDeleteEducationHistory_Click(object sender, EventArgs e)
        {
            if (gridEducationHistory.CurrentRow != null && !gridEducationHistory.CurrentRow.IsNewRow)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffQualifications where ID =" + gridEducationHistory.CurrentRow.Cells["qualificationsID"].Value.ToString());
                    gridEducationHistory.Rows.RemoveAt(gridEducationHistory.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnDeleteProfessionHistory_Click(object sender, EventArgs e)
        {
            if (gridProfession.CurrentRow != null && !gridProfession.CurrentRow.IsNewRow)
            {
                try
                {
                    dalHelper.ExecuteNonQuery("Delete From StaffProfession where ID =" + gridProfession.CurrentRow.Cells["professionID"].Value.ToString());
                    gridProfession.Rows.RemoveAt(gridProfession.CurrentRow.Index);
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            try
            {
                Employee_Search searchForm = new Employee_Search(dal, this);
                searchForm.MdiParent = this.MdiParent;
                searchForm.Show();
                searchForm.Focus();
                searchForm.BringToFront();
                this.WindowState = FormWindowState.Normal;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void browse_imagebtn_Click_1(object sender, EventArgs e)
        {
            ShowPictureDialog();
        }

        private void clearButton_Click_1(object sender, EventArgs e)
        {
            ClearStaffPersonalInfo();
        }

        private void ssnitCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ssnitCheckBox.Checked)
            {
                ssnitNoLabel.Visible = true;
                ssnitNoTextBox.Visible = true;
            }
            else
            {
                ssnitNoLabel.Visible = false;
                ssnitNoTextBox.Visible = false;
            }
        }

        //private void btnEmployeeBanks_Click(object sender, EventArgs e)
        //{
        //    EnrollmentForm Enroller = new EnrollmentForm(this);
        //    Enroller.OnTemplate += this.OnTemplate;
        //    Enroller.ShowDialog();
        //}



        //private void OnTemplate(DPFP.Template template)
        //{
        //    this.Invoke(new Function(delegate()
        //    {
        //        Template = template;
        //        if (Template != null)
        //            MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment");
        //        else
        //            MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment");
        //    }));
        //}
        //public DPFP.Template Template;

        private void EmployeeMaintenance_Load(object sender, EventArgs e)
        {         
            try
            {
                //// TODO: This line of code loads data into the 'humanResourceDataSet.Towns' table. You can move, or remove it, as needed.
                //this.townsTableAdapter.Fill(this.humanResourceDataSet.Towns);
                //// TODO: This line of code loads data into the 'humanResourceDataSet.Occupations' table. You can move, or remove it, as needed.
                //this.occupationsTableAdapter.Fill(this.humanResourceDataSet.Occupations);
                //// TODO: This line of code loads data into the 'humanResourceDataSet.Relationships' table. You can move, or remove it, as needed.
                //this.relationshipsTableAdapter.Fill(this.humanResourceDataSet.Relationships);
                ////// TODO: This line of code loads data into the 'humanResourceDataSet.AllowancesAndDeductionsSummary' table. You can move, or remove it, as needed.
                //this.allowancesAndDeductionsSummaryTableAdapter.Fill(this.humanResourceDataSet.AllowancesAndDeductionsSummary);
                ssnitCheckBox_CheckedChanged(this,EventArgs.Empty);
                ssnitCheckBox.Checked = true;
                saveAll = false;
                allowedToSaveAll = false;
                editMode = false;
                if (!editMode)
                {
                    fingerPrintTextBox.Text = GenerateFingerPrintID();
                    staffIDTextBox.Text = GenerateStaffID();
                }

                GlobalData.SetFormPermissions(this,dal,GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private string GenerateFingerPrintID()
        {
            
            //Finger Print ID
            int fingerPrintID = 0;
            try
            {
                object result = null;
                string tempFingerPrint = string.Empty;
                dalHelper.ClearParameters();
                result = dalHelper.ExecuteScalar("Select MAX(FingerPrintID) from StaffPersonalInfo Where Archived='False' ");
                if (result == null || result.ToString().Trim() == string.Empty)
                {
                    fingerPrintID = 10000;
                }
                else
                {
                    fingerPrintID = int.Parse(result.ToString());
                    fingerPrintID++;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return fingerPrintID.ToString();
        }

        //private string GenerateStaffID()
        //{
        //    string staffID = string.Empty;
        //    try
        //    {
        //        this.company = dal.GetAll<Company>()[0];
        //        object result = null;
        //        dalHelper.ClearParameters();
        //        string query = "SELECT MAX(CAST(StaffID AS Int)) FROM StaffPersonalInfo ";
        //        query += "WHERE ISNUMERIC(StaffID)=1 ";
        //        query += "AND StaffID NOT LIKE '%[a-z]%' ";
        //        query += "AND StaffID NOT LIKE '%.%' ";
        //        query += "AND Archived='False'";
        //        result = dalHelper.ExecuteScalar(query);
        //        if (result == null || result.ToString().Trim() == string.Empty)
        //        {
        //            staffID = this.company.Character + this.company.InitialStaffID;
        //        }
        //        else
        //        {
        //            string numberPart = result.ToString().Substring(0, result.ToString().Length);
        //            int temp = int.Parse(numberPart);
        //            temp++;
        //            staffID = temp.ToString();

        //            //switch (temp.ToString().Length)
        //            //{
        //            //    case 1:
        //            //        staffID = this.company.Character + "00" + temp.ToString();
        //            //        break;
        //            //    case 2:
        //            //        staffID = this.company.Character + "0" + temp.ToString();
        //            //        break;
        //            //    case 3:
        //            //        staffID = this.company.Character + temp.ToString();
        //            //        break;
        //            //    default:
        //            //        throw new Exception("Invalid argument provided");
        //            //}
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Logger.LogError(ex);
        //        throw ex;
        //    }
        //    return staffID;
        //}


        private string GenerateStaffID()
        {
            string staffID = string.Empty;
            try
            {
                this.company = dal.GetAll<Company>()[0];
                object result = null;
                result = dalHelper.ExecuteScalar("Select Max(StaffID) From StaffPersonalInfo Where Archived='False' ");
                if (result == null || result.ToString().Trim() == string.Empty)
                {
                    staffID = this.company.Character + this.company.InitialStaffID;
                }
                else
                {
                    try
                    {
                        string numberPart = result.ToString().Substring(company.Character.Length, result.ToString().Length - company.Character.Length);
                        int temp = int.Parse(numberPart);
                        temp++;
                        staffID = this.company.Character + temp.ToString();
                    }
                    catch (Exception ex)
                    {
                        staffID = this.company.Character + this.company.InitialStaffID;
                        string message=ex.Message;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return staffID;
        }

        
        private void probationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                startDateLabel.Visible = probationCheckBox.Checked;
                startDatePicker.Visible = probationCheckBox.Checked;
                endDateLabel.Visible = probationCheckBox.Checked;
                endDatePicker.Visible = probationCheckBox.Checked;
                lblProbationStatus.Visible = probationCheckBox.Checked;
                cboProbationStatus.Visible = probationCheckBox.Checked;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateDocuments()
        {
            bool result = true;
            try
            {              
                docGroupErrorProvider.Clear();
                foreach (DataGridViewRow row in gridDocuments.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDocumentsDocumentGroup"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select a document group on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = documentsTabPage;
                            gridDocuments.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridDocumentsDocumentGroup"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select a document group on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = documentsTabPage;
                            gridDocuments.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["gridDocumentsDescription"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select a document group on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = documentsTabPage;
                            gridDocuments.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridDocumentsDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the description of the document on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = documentsTabPage;
                            gridDocuments.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
                allowedToSaveAll = result;
                
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
            return result;
        }

        private void btnDocumentsSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if (ValidateDocuments())
                    {
                        try
                        {
                            SaveDocuments();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Not save successfully,Please See the System Administrator");
                        }
                        GetDocuments();
                    }
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could not refresh the grid");
            }
        }

        private void SaveDocuments()
        {
            try
            {
                if (gridDocuments.Rows.Count > 0)
                {
                    if (ValidateDocuments())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridDocuments.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            foreach (DataGridViewRow row in gridDocuments.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    staffDocument = dal.GetByID<StaffDocument>(employee.StaffID);
                                    if (row.Cells["gridDocumentsID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                                        if (row.Cells["gridDocumentsDateCreated"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@DateCreated", GlobalData.ServerDate, DbType.DateTime);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@DateCreated", row.Cells["gridDocumentsDateCreated"].Value, DbType.DateTime);
                                        }
                                        dalHelper.CreateParameter("@Description", row.Cells["gridDocumentsDescription"].Value, DbType.String);
                                        dalHelper.CreateParameter("@DocumentContent", row.Cells["gridDocumentsDocumentsContent"].Value, DbType.Binary);
                                        dalHelper.CreateParameter("@DocumentGroup", row.Cells["gridDocumentsDocumentGroup"].Value, DbType.String);
                                        dalHelper.CreateParameter("@DocumentType", row.Cells["gridDocumentsDocumentType"].Value, DbType.String);
                                        dalHelper.CreateParameter("@Path", row.Cells["gridDocumentsPath"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffDocuments(StaffID,StaffCode,DateCreated,Description,DocumentContent,DocumentGroup,DocumentType,Path,UserID) Values(@StaffID,@StaffCode,@DateCreated,@Description,@DocumentContent,@DocumentGroup,@DocumentType,@Path,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                                        if (row.Cells["gridDocumentsDateCreated"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@DateCreated", GlobalData.ServerDate, DbType.DateTime);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@DateCreated", row.Cells["gridDocumentsDateCreated"].Value, DbType.DateTime);
                                        }
                                        dalHelper.CreateParameter("@Description", row.Cells["gridDocumentsDescription"].Value, DbType.String);
                                        dalHelper.CreateParameter("@DocumentContent", row.Cells["gridDocumentsDocumentsContent"].Value, DbType.Binary);
                                        dalHelper.CreateParameter("@DocumentGroup", row.Cells["gridDocumentsDocumentGroup"].Value, DbType.String);
                                        dalHelper.CreateParameter("@DocumentType", row.Cells["gridDocumentsDocumentType"].Value, DbType.String);
                                        dalHelper.CreateParameter("@Path", row.Cells["gridDocumentsPath"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@ID", row.Cells["gridDocumentsID"].Value, DbType.String);

                                        dalHelper.ExecuteNonQuery("Update StaffDocuments set StaffID=@StaffID,StaffCode=@StaffCode,DateCreated=@DateCreated,Description=@Description,DocumentContent=@DocumentContent,DocumentGroup=@DocumentGroup,DocumentType=@DocumentType,Path=@Path,UserID=@UserID where StaffID=@StaffID and ID=@ID");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnDocumentsUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ////Browse pdf and get their paths
                //docGroupErrorProvider.Clear();
                //OpenFileDialog documentDialog = new OpenFileDialog();
                //documentDialog.Multiselect = false;
                //documentDialog.RestoreDirectory = true;
                //documentDialog.Title = "Select CV";
                //documentDialog.AutoUpgradeEnabled = true;
                //documentDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                //documentDialog.Filter = "PDF Document (*.PDF)|*.PDF|Word 2007 Document (*.DOCX)|*.DOCX|Word 2003 Document (*.DOC)|*.DOC|Excel 2007 Document (*.XLSX)|*.XLSX|Excel 2003 Document (*.XLS)|*.XLS|All Files(*.*)|*.*";
                //documentDialog.CheckFileExists = true;
                //if (documentDialog.ShowDialog(this) == DialogResult.OK)
                //{
                //    int fileExtensionLength = documentDialog.FileName.Length - (documentDialog.FileName.IndexOf(".") + 1);
                //    string fileExtension = documentDialog.FileName.Substring(documentDialog.FileName.IndexOf(".") + 1, fileExtensionLength);
                //    string fileName = documentDialog.SafeFileName.Substring(0, documentDialog.SafeFileName.Length - (fileExtensionLength + 1));

                //    byte[] buff;
                //    using (FileStream fs = new FileStream(documentDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read)) 
                //    {
                //        BinaryReader br = new BinaryReader(fs);
                //        int numBytes = (int)new FileInfo(documentDialog.FileName).Length;
                //        buff = br.ReadBytes(numBytes);
                //        fs.Flush();
                //        fs.Dispose();
                //        fs.Close(); 
                //    }

                //    ////Force clean up
                //    GC.Collect();

                //    //// Copy file 
                //    //File.Copy(sourceFileName, destinationFilename, true); 

                //    //FileStream fs = new FileStream(documentDialog.FileName, FileMode.Open, FileAccess.Read);
                //    //BinaryReader br = new BinaryReader(fs);
                //    //int numBytes = (int)new FileInfo(documentDialog.FileName).Length;
                //    //byte[] buff = br.ReadBytes(numBytes);
                //    //cryRpt.Load(@Application.StartupPath + @"\PaySlipReport.rpt");
                //    string installedPath = @Application.StartupPath + @"EMAS-DOC";
                //    //Check whether folder path is exist
                //    if (!System.IO.Directory.Exists(installedPath))
                //    {
                //        // If not create new folder
                //        System.IO.Directory.CreateDirectory(installedPath);
                //    }
                //    //Save pdf files in installedPath
                //    string sourceFileName = documentDialog.FileName;
                //    string destinationFileName = System.IO.Path.Combine(installedPath, System.IO.Path.GetFileName(sourceFileName));
                //    if (File.Exists(destinationFileName) == true)
                //    {
                //        if (GlobalData.QuestionMessage("Are sure you want to replace this file") == DialogResult.Yes)
                //        {
                //            File.Delete(destinationFileName);
                //            //File.Replace(sourceFileName, destinationFileName, destinationFileName,false);
                //            System.IO.File.Copy(sourceFileName, destinationFileName);

                //            MessageBox.Show("Data REPLACED");
                //        }
                //    }
                //    else
                //    {
                //        System.IO.File.Copy(sourceFileName, destinationFileName);
                //        gridDocuments.Rows.Add(1);
                //        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDateCreated"].Value = GlobalData.ServerDate.Day + "/" + GlobalData.ServerDate.Month + "/" + GlobalData.ServerDate.Year;
                //        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDescription"].Value = fileName;
                //        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDocumentType"].Value = fileExtension;
                //        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsPath"].Value = sourceFileName;
                //        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDocumentsContent"].Value = buff;         
                //    }
            //}
                    OpenFileDialog documentDialog = new OpenFileDialog();
                    documentDialog.Multiselect = false;
                    documentDialog.RestoreDirectory = true;
                    documentDialog.Title = "Select Document";
                    documentDialog.AutoUpgradeEnabled = true;
                    documentDialog.Filter = "PDF Document (*.PDF)|*.PDF|Word 2007 Document (*.DOCX)|*.DOCX|Word 2003 Document (*.DOC)|*.DOC|Excel 2007 Document (*.XLSX)|*.XLSX|Excel 2003 Document (*.XLS)|*.XLS|All Files(*.*)|*.*";
                    documentDialog.CheckFileExists = true;
                    

                    if (documentDialog.ShowDialog(this) == DialogResult.OK)
                    {
                        FileStream fs = new FileStream(documentDialog.FileName, FileMode.Open, FileAccess.Read);
                        BinaryReader br = new BinaryReader(fs);
                        int numBytes = (int)new FileInfo(documentDialog.FileName).Length;
                        byte[] buff = br.ReadBytes(numBytes);
                        int fileExtensionLength = documentDialog.FileName.Length - (documentDialog.FileName.IndexOf(".") + 1);
                        string fileExtension = documentDialog.FileName.Substring(documentDialog.FileName.IndexOf(".") + 1, fileExtensionLength);
                        string fileName = documentDialog.SafeFileName.Substring(0, documentDialog.SafeFileName.Length - (fileExtensionLength + 1));

                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDateCreated"].Value = GlobalData.ServerDate;
                        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDescription"].Value = documentDialog.FileName;
                        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDocumentType"].Value = fileExtension;
                        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsPath"].Value = documentDialog.FileName;
                        gridDocuments.Rows[gridDocuments.RowCount - 1].Cells["gridDocumentsDocumentsContent"].Value = buff;   
                    }
                   
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                MessageBox.Show("Cannot upload, See the system administrator tt" + ex.Message + ex.Source);
            }
        }


        private void btnTitle_Click(object sender, EventArgs e)
        {
            try
            {
                if (titlesForm != null && titlesForm.IsDisposed == false)
                {
                    titlesForm.Close();
                    titlesForm = null;
                }
                titlesForm = new eMAS.Forms.SystemSetup.Titles();
                titlesForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnNationality_Click(object sender, EventArgs e)
        {
            try
            {
                if (nationalitiesForm != null && nationalitiesForm.IsDisposed == false)
                {
                    nationalitiesForm.Close();
                    nationalitiesForm = null;
                }
                nationalitiesForm = new Nationalities();
                nationalitiesForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnReligion_Click(object sender, EventArgs e)
        {
            try
            {
                if (religionsForm != null && religionsForm.IsDisposed == false)
                {
                    religionsForm.Close();
                    religionsForm = null;
                }
                religionsForm = new Religions();
                religionsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnHomeTown_Click(object sender, EventArgs e)
        {
            try
            {
                if (townsForm != null && townsForm.IsDisposed == false)
                {
                    townsForm.Close();
                    townsForm = null;
                }
                townsForm = new Towns();
                townsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnTown_Click(object sender, EventArgs e)
        {
            try
            {
                btnHomeTown_Click(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSaveFamilyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if(ValidateRelations())
                    {
                        try
                        {
                            SaveDependants();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Could Not Save Successfully,Please See the System Administrator");
                        }
                        GetDependents();
                    }                    
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Load The Data,Please See the System Administrator");
            }
        }

        private void btnSaveLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if(ValidateLanguages())
                    {
                        try
                        {
                            SaveLanguages();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Could Not save successfully,Please See the System Administrator");
                        }
                        GetStaffLanguages();
                    }
                }
                else
                {
                    MessageBox.Show("Please Save Employee's Personal Info First", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Load The Data,Please See the System Administrator");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {             
            try
            {
                if (ValidatePersonalInfo() && ValidateRelations() && ValidateLanguages() && ValidateProffessionHistory() && ValidateEmploymentHistory() && ValidateEducationHistory() && ValidateDocuments() && ValidateReferees() && ValidateWorkPermit() && ValidatePassport() && ValidateVisa())
                {
                    string prompt = string.Empty;
                    dalHelper.BeginTransaction();
                    dalHelper.ClearParameters();

                    //Person
                    dalHelper.CreateParameter("@StaffID", staffIDTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@Surname", surnameTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@Firstname", txtFirstName.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@OtherName", txtOtherName.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@NickName", txtNickName.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@PIN", txtPIN.Text, DbType.String);
                    dalHelper.CreateParameter("@NationalID", txtNationalID.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@MaidenName", txtMaidenName.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@Payment", checkBoxActive.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@Overseer", txtOverseer.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@Tribe", txtTribe.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@SupervisorCode", staffCode, DbType.Int32);
                    dalHelper.CreateParameter("@IsExemptFromSecondTier", checkBoxExemptFromSecondTier.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@PFRate", numericPF.Value, DbType.Decimal);


                    if (cboRace.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@RaceID", racesTable.Rows[cboRace.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@RaceID", 0, DbType.Int32);
                    }

                    if (cboLeaveEntitlement.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@AnnualLeaveEntitlementID", annualLeaveEntitlements[cboLeaveEntitlement.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@AnnualLeaveEntitlementID", 0, DbType.Int32);
                    }
                    
                    
                    if (cmbSex.Text.Trim() == string.Empty)
                    {
                        dalHelper.CreateParameter("@GenderGroupID", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@GenderGroupID", (GenderGroups)Enum.Parse(typeof(GenderGroups), cmbSex.Text), DbType.Int32);
                    }

                    if (cboLicenceType.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@LicenceTypeID", licenceTypes[cboLicenceType.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@LicenceTypeID", 0, DbType.Int32);
                    }
                    dalHelper.CreateParameter("@LicenceNumber", txtLicenceNumber.Text, DbType.String);
                    if (cboDisabilityType.Text.Trim() == string.Empty || checkBoxDisability.Checked == false)
                    {
                        dalHelper.CreateParameter("@DisabilityTypeID", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DisabilityTypeID", disabilityTypes[cboDisabilityType.SelectedIndex].ID, DbType.Int32);
                        
                    }
                    if (datePickerDisabilityDate.Value == null || datePickerDisabilityDate.Checked == false || checkBoxDisability.Checked == false)
                    {
                        dalHelper.CreateParameter("@DisabilityDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DisabilityDate", datePickerDisabilityDate.Value, DbType.Date);
                    }
                    dalHelper.CreateParameter("@IsDisable", checkBoxDisability.Checked, DbType.Boolean);

                    if (dateDOB.Value == null || dateDOB.Checked == false)
                    {
                        dalHelper.CreateParameter("@DOB", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DOB", dateDOB.Value, DbType.Date);
                    }

                    if (cboBirthDistrict.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@BirthDistrict", birthDistrictsTable.Rows[cboBirthDistrict.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@BirthDistrict", 0, DbType.Int32);
                    }
                    if (cmbReligion.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ReligionID", religionsTable.Rows[cmbReligion.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ReligionID", 0, DbType.Int32);
                    }
                    
                    if (cmbMaritalStatus.Text.Trim() == string.Empty)
                    {
                        dalHelper.CreateParameter("@MaritalStatusID", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@MaritalStatusID", (MaritalStatusGroups)Enum.Parse(typeof(MaritalStatusGroups), cmbMaritalStatus.Text), DbType.Int32);
                    }
                    if (cmbPOB.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@POB", birthPlacesTable.Rows[cmbPOB.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@POB", 0, DbType.Int32);
                    }
                    if (cboBirthCountry.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@CountryOfBirth", birthCountriesTable.Rows[cboBirthCountry.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@CountryOfBirth", 0, DbType.Int32);
                    }
                    if (cboBirthDistrict.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@DistrictOfBirth", birthDistrictsTable.Rows[cboBirthDistrict.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DistrictOfBirth", 0, DbType.Int32);
                    }
                    if (cboBirthRegion.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@RegionOfBirth", birthRegionsTable.Rows[cboBirthRegion.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@RegionOfBirth", 0, DbType.Int32);
                    }
                    if (cboDenomination.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@Denomination", denominationsTable.Rows[cboDenomination.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@Denomination", 0, DbType.Int32);
                    }

                    dalHelper.CreateParameter("@NoOfChildren", txtNumberOfChildren.Text, DbType.String);                   
                    if (cmbTitle.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@TitleID", titlesTable.Rows[cmbTitle.SelectedIndex]["ID"], DbType.Int32); 
                    }
                    else
                    {
                        dalHelper.CreateParameter("@TitleID", 0, DbType.Int32);
                    }
                    if (cmbHomeTown.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@HomeTown", townsTable.Rows[cmbHomeTown.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@HomeTown", 0, DbType.Int32);
                    }
                    if (cboNationality.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@NationalityID", nationalitiesTable.Rows[cboNationality.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@NationalityID", 0, DbType.Int32);
                    }
                    dalHelper.CreateParameter("@NHISNumber", txtNHISNumber.Text.Trim(), DbType.String);
                    if (cboZone.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ZoneID", zones[cboZone.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ZoneID", 0, DbType.Int32);
                    }

                    if (dateDOM.Value == null || dateDOM.Checked == false || cmbMaritalStatus.Text.ToLower().Trim() != "married")
                    {
                        dalHelper.CreateParameter("@DOM", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DOM", dateDOM.Value, DbType.Date);
                    }
                    //Contact                     
                    dalHelper.CreateParameter("@ContactPostalAddress", txtContactPostalAddress.Text.Trim(), DbType.String);
                    if (cboContactCity.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ContactTownID", contactTownsTable.Rows[cboContactCity.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ContactTownID", 0, DbType.Int32);
                    }
                    if (cboContactRegion.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ContactRegionID", contactRegionsTable.Rows[cboContactRegion.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ContactRegionID", 0, DbType.Int32);
                    }
                    if (cboContactCountry.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ContactCountryID", contactCountriesTable.Rows[cboContactCountry.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ContactCountryID", 0, DbType.Int32);
                    }
                    if (cboContactHomeTown.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ContactHomeTownID", contactHomeTownsTable.Rows[cboContactHomeTown.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ContactHomeTownID", 0, DbType.Int32);
                    }

                    dalHelper.CreateParameter("@ContactTelephone", txtContactTelephone.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@ContactMobileNumber", txtContactMobileNumber.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@ContactEmailAddress", txtContactEmailAddress.Text.Trim(), DbType.String);
                    
                    //Residential
                    dalHelper.CreateParameter("@ResidentialHouseNumber", txtResidentialHouseNumber.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@ResidentialStreetName", txtResidentialStreetName.Text.Trim(), DbType.String);
                    if (cboResidentialCity.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ResidentialTownID", residentialTownsTable.Rows[cboResidentialCity.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ResidentialTownID", 0, DbType.Int32);
                    }
                    if (cboResidentialRegion.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ResidentialRegionID", residentialRegionsTable.Rows[cboResidentialRegion.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ResidentialRegionID", 0, DbType.Int32);
                    }
                    if (cboResidentialCountry.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ResidentialCountryID", residentialCountriesTable.Rows[cboResidentialCountry.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ResidentialCountryID", 0, DbType.Int32);
                    }  
                                   
                    
                    //Job Detail
                    if (departmentComboBox.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@DepartmentID", departments[departmentComboBox.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DepartmentID", 0, DbType.Int32);
                    }
                    if (cboSpecialty.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@SpecialtyID", specialtiesTable.Rows[cboSpecialty.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@SpecialtyID", 0, DbType.Int32);
                    }

                    if (DOFADatePicker.Value == null || DOFADatePicker.Checked == false)
                    {
                        dalHelper.CreateParameter("@DOFA", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DOFA", DOFADatePicker.Value, DbType.Date);
                    }

                    if (cboUnit.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@UnitID", unitsTable.Rows[cboUnit.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@UnitID", 0, DbType.Int32);
                    }

                    if (cboOccupationGrp.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@OccuGRP", occupationGrpsTable.Rows[cboOccupationGrp.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@OccuGRP", 0, DbType.Int32);
                    }
                    if (cboEmploymentStatus.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@StatusID", staffStatuses[cboEmploymentStatus.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@StatusID", 0, DbType.Int32);
                    }

                    if (DOCADatePicker.Value == null || DOCADatePicker.Checked == false)
                    {
                        dalHelper.CreateParameter("@DOCA", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@DOCA", DOCADatePicker.Value, DbType.Date);
                    }
                    dalHelper.CreateParameter("@Probation", probationCheckBox.Checked, DbType.Int32);
                    if (probationCheckBox.Checked && cboProbationStatus.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@ProbationStatusID", probationStatusesTable.Rows[cboProbationStatus.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ProbationStatusID", 0, DbType.Int32);
                    }
                    if (probationCheckBox.Checked && startDatePicker.Value != null && startDatePicker.Checked)
                    {
                        dalHelper.CreateParameter("@ProbationStartDate", startDatePicker.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ProbationStartDate", DBNull.Value, DbType.Date);
                    }

                    if (probationCheckBox.Checked && endDatePicker.Value != null && endDatePicker.Checked)
                    {
                        dalHelper.CreateParameter("@ProbationEndDate", endDatePicker.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ProbationEndDate", DBNull.Value, DbType.Date);
                    }     
                    
                    if (cboAppointmentType.Text.Trim() == string.Empty)
                    {
                        dalHelper.CreateParameter("@AppointmentTypeID", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@AppointmentTypeID", appointmentTypes[cboAppointmentType.SelectedIndex].ID, DbType.Int32);
                    }

                    if (dateEmploymentDate.Value == null || dateEmploymentDate.Checked == false)
                    {
                        dalHelper.CreateParameter("@EmploymentDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EmploymentDate", dateEmploymentDate.Value, DbType.Date);
                    }     
                    
                    if (cboJobTitle.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@JobTitleID", jobTitlesTable.Rows[cboJobTitle.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@JobTitleID", 0, DbType.Int32);
                    }
                    //if (cboEmploymentStatus.Text.Trim() == string.Empty)
                    //{
                    //    dalHelper.CreateParameter("@EmploymentStatusID", 0, DbType.Int32);
                    //}
                    //else
                    //{
                    //    dalHelper.CreateParameter("@EmploymentStatusID", employmentStatusesTable.Rows[cboEmploymentStatus.SelectedIndex]["ID"], DbType.Int32);
                    //    //dalHelper.CreateParameter("@EmploymentStatusID", (HRBussinessLayer.Staff_Information_CLASS.EmploymentStatuses)Enum.Parse(typeof(HRBussinessLayer.Staff_Information_CLASS.EmploymentStatuses), cboEmploymentStatus.Text), DbType.Int32);
                    //}

                    if (assumptionDatePicker.Value == null || assumptionDatePicker.Checked == false)
                    {
                        dalHelper.CreateParameter("@AssumptionDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@AssumptionDate", assumptionDatePicker.Value, DbType.Date);
                    }     
                    //Transfer Details
                    dalHelper.CreateParameter("@TransferredIn", transferredInRadioButton.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@TransferredOut", transferredOutRadioButton.Checked, DbType.Boolean);

                    ////Engagement
                    if (cboEngagementType.Text.Trim() == string.Empty || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementTypeID", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementTypeID", engagementTypesTable.Rows[cboEngagementType.SelectedIndex]["ID"], DbType.Int32);
                    }

                    if (cboEngagementGradeOn.Text.Trim() == string.Empty || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementGradeIDOn", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementGradeIDOn", engagementGradesOnTable.Rows[cboEngagementGradeOn.SelectedIndex]["ID"], DbType.Int32);
                    }

                    if (dateEngagementEffectiveDate.Value == null || dateEngagementEffectiveDate.Checked == false  || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementEffectiveDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementEffectiveDate", dateEngagementEffectiveDate.Value, DbType.Date);
                    }      
                    
                    if (dateEngagementDate.Value == null || dateEngagementDate.Checked == false  || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementDate", dateEngagementDate.Value, DbType.Date);
                    }

                    if (cboEngagementGradeLeaving.Text.Trim() == string.Empty || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementGradeIDLeaving", 0, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementGradeIDLeaving", engagementGradesLeavingTable.Rows[cboEngagementGradeLeaving.SelectedIndex]["ID"], DbType.Int32);
                    }

                    if (dateEngagementEndingDate.Value == null || dateEngagementEndingDate.Checked == false  || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementEndingDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementEndingDate", dateEngagementEndingDate.Value, DbType.Date);
                    }

                    if (checkedListBoxContract.CheckedItems.Count <= 0 || cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementContractOption", 0, DbType.Int32);
                    }
                    else
                    {
                        StringBuilder sb = new StringBuilder();
                        foreach (object itemChecked in checkedListBoxContract.CheckedItems)
                        {
                            sb.Append(itemChecked.ToString() + ",");
                        }
                        dalHelper.CreateParameter("@EngagementContractOption", sb.ToString(), DbType.String);
                        
                    }
                    if (cboAppointmentType.Text.ToLower().Trim() != "contract")
                    {
                        dalHelper.CreateParameter("@EngagementAnnualSalary", 0, DbType.Decimal);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@EngagementAnnualSalary", decimal.Parse(txtEngagementAnnualSalary.Text), DbType.Decimal);
                    }
                    
                    //Salary Detail
                    if (gradeCategoryComboBox.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@GradeCategoryID", gradeCategories[gradeCategoryComboBox.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@GradeCategoryID", 0, DbType.Int32);
                    }
                    if (cboStep.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@StepID", stepsTable.Rows[cboStep.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@StepID", 0, DbType.Int32);
                    }

                    if (cboBand.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@BandID", bandsTable.Rows[cboBand.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@BandID", 0, DbType.Int32);
                    }

                    if (paymentTypeComboBox.Text.Trim() == string.Empty)
                    {
                        dalHelper.CreateParameter("@PaymentType", DBNull.Value, DbType.String);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@PaymentType", (HRBussinessLayer.Staff_Information_CLASS.PaymentTypes)Enum.Parse(typeof(HRBussinessLayer.Staff_Information_CLASS.PaymentTypes), paymentTypeComboBox.Text), DbType.String);
                    }

                    dalHelper.CreateParameter("@Mechanised", checkBoxMechanised.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@SSNIT", ssnitCheckBox.Checked, DbType.Boolean);                   
                    dalHelper.CreateParameter("@IncomeTax", incomeCheckBox.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@IsSusuPlusContribution", susuPlusContributionCheckBox.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@SusuPlusContributionAmount", susuPlusContributionAmountTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@IsProvidentFund", isProvidentFundCheckBox.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@IsWithholdingTax", withholdingTaxCheckBox.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@IsWithholdingTaxFixedAmount", withholdingTaxFixedAmountRadioButton.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@WithholdingTaxFixedAmount", withholdingTaxFixedAmountTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@IsWithholdingTaxRate", withholdingTaxRateRadioButton.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@WithholdingTaxRate", withholdingTaxRateNumericUpDown.Value, DbType.Decimal);
                    if (calculatedOnComboBox.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@CalculateOn", salaryTypes[calculatedOnComboBox.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@CalculateOn", 0, DbType.Int32);
                    }

                    if (gradeComboBox.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@GradeID", gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@GradeID", 0, DbType.Int32);
                    }
                    if (cboGradeOnFirstAppointment.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@GradeOnFirstAppointmentID", gradesOnFirstTable.Rows[cboGradeOnFirstAppointment.SelectedIndex]["ID"], DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@GradeOnFirstAppointmentID", 0, DbType.Int32);
                    }
                    if (cboQualificationType.Text.Trim() != string.Empty)
                    {
                        dalHelper.CreateParameter("@QualificationID", qualificationTypes[cboQualificationType.SelectedIndex].ID, DbType.Int32);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@QualificationID", 0, DbType.Int32);
                    }
                    if (gradeDatePicker.Value == null || gradeDatePicker.Checked == false)
                    {
                        dalHelper.CreateParameter("@GradeDate", DateTime.Now.Date, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@GradeDate", gradeDatePicker.Value, DbType.Date);
                    }
                    if (zoneDatePicker.Value == null || zoneDatePicker.Checked == false)
                    {
                        dalHelper.CreateParameter("@InZoneDate", DBNull.Value, DbType.Date);
                    }
                    else
                    {
                        dalHelper.CreateParameter("@InZoneDate", zoneDatePicker.Value, DbType.Date);
                    }
                    
                    this.company = dal.GetAll<Company>()[0];
                    if (company.IsSalaryStructure == true)
                    {
                        singleSpine = dal.GetSalaryAmount<SingleSpine>(gradeCategories[gradeCategoryComboBox.SelectedIndex].ID.ToString(), gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"].ToString(), stepsTable.Rows[cboStep.SelectedIndex]["ID"].ToString());
                        txtSalary.Text = singleSpine.BasicSalary.ToString();
                    }

                    dalHelper.CreateParameter("@Salary", decimal.Parse(txtSalary.Text.Trim()), DbType.Decimal);
                    dalHelper.CreateParameter("@SalaryGrouping", cboSalaryGrouping.Text.Trim(), DbType.String);

                    dalHelper.CreateParameter("@SSNITNo", ssnitNoTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@TIN", txtTIN.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@FingerPrintID", fingerPrintTextBox.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                    //txtFileNumber is a combobox it shall be a TextField in the future after the automatically generates the File Number
                    if (txtFileNumber.Text.Trim() == string.Empty)
                    {
                        dalHelper.CreateParameter("@FileNumberID", 0, DbType.Int32);
                        dalHelper.CreateParameter("@FileNumber", string.Empty, DbType.String);
                    }
                    else
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "FileNumberView.Description",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = txtFileNumber.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        fileNumbers = dal.GetByCriteria<FileNumber>(query);
                        foreach (FileNumber fileNo in fileNumbers)
                        {
                            employee.FileNumber.Description = fileNo.Description;
                            employee.FileNumber.ID = fileNo.ID;
                            dalHelper.CreateParameter("@FileNumberID", fileNo.ID, DbType.Int32);
                            dalHelper.CreateParameter("@FileNumber", fileNo.Description, DbType.String);
                        }                       
                    }
                    
                    //if is in the edit mode
                    if (editMode)
                    {
                        dalHelper.CreateParameter("@ID", employee.ID, DbType.Int32);
                        string query = "Update StaffPersonalInfo Set StaffID=@StaffID,FingerPrintID=@FingerPrintID,Surname=@Surname,Firstname=@Firstname,OtherName=@OtherName,NickName=@NickName,FileNumber=@FileNumber,FileNumberID=@FileNumberID,PIN=@PIN,NationalID=@NationalID,MaidenName=@MaidenName,";
                        query += "SalaryGrouping=@SalaryGrouping,GradeCategoryID=@GradeCategoryID,GradeID=@GradeID,GradeOnFirstAppointmentID=@GradeOnFirstAppointmentID,GradeDate=@GradeDate,StepID=@StepID,BandID=@BandID,BasicSalary=@Salary,DOB=@DOB,GenderGroupID=@GenderGroupID,TitleID=@TitleID,NationalityID=@NationalityID,TownID=@ContactTownID,Hometown=@HomeTown,ContactHomeTownID=@ContactHomeTownID,Telno=@ContactTelephone,MobileNo=@ContactMobileNumber,MaritalStatusID=@MaritalStatusID,DOM=@DOM,ReligionID=@ReligionID,";
                        query += "Placeofbirth=@POB,CountryOfBirth=@CountryOfBirth,DistrictOfBirth=@DistrictOfBirth,RegionOfBirth=@RegionOfBirth,NoOfChildren=@NoOfChildren,Denomination=@Denomination,NHISNumber=@NHISNumber,HouseNumber=@ResidentialHouseNumber,StreetName=@ResidentialStreetName,ResidentialTownID=@ResidentialTownID,";
                        query += "ResidentialRegionID=@ResidentialRegionID,ResidentialCountryID=@ResidentialCountryID,Address=@ContactPostalAddress,Email=@ContactEmailAddress,RegionID=@ContactRegionID,ContactCountryID=@ContactCountryID,DepartmentID=@DepartmentID,AppointmentTypeID=@AppointmentTypeID,EmploymentDate=@EmploymentDate,Mechanised=@Mechanised,SSNIT=@SSNIT,";
                        query += "IncomeTax=@IncomeTax,Probation=@Probation,ProbationStartDate=@ProbationStartDate,ProbationEndDate=@ProbationEndDate,ProbationStatusID=@ProbationStatusID,SSNITNo=@SSNITNo,TIN=@TIN,";
                        query += "IsDisable=@IsDisable,DisabilityTypeID=@DisabilityTypeID,DisabilityDate=@DisabilityDate,LicenceTypeID=@LicenceTypeID,LicenceNumber=@LicenceNumber,";
                        query += "Payment=@Payment,AnnualLeaveEntitlementID=@AnnualLeaveEntitlementID,PaymentType=@PaymentType,UserID=@UserID,EngagementTypeID=@EngagementTypeID,EngagementGradeIDOn=@EngagementGradeIDOn,EngagementGradeIDLeaving=@EngagementGradeIDLeaving,EngagementDateApplied=@EngagementDate,";
                        query += "EngagementEffectiveDate=@EngagementEffectiveDate,EngagementEndingDate=@EngagementEndingDate,EngagementContractOption=@EngagementContractOption,EngagementAnnualSalary=@EngagementAnnualSalary,";
                        query += "CurrentPromotionDate=@DOFA,DOFA=@DOFA,DOCA=@DOCA,AssumptionDate=@AssumptionDate,SpecialtyID=@SpecialtyID,UnitID=@UnitID,JobTitleID=@JobTitleID,OccuGRP=@OccuGRP,RaceID=@RaceID,Tribe=@Tribe,Overseer=@Overseer,SupervisorCode=@SupervisorCode,StatusID=@StatusID,ZoneID=@ZoneID,InZoneDate=@InZoneDate,";
                        query += "PFRate=@PFRate,IsExemptFromSecondTier=@IsExemptFromSecondTier,IsSusuPlusContribution=@IsSusuPlusContribution,SusuPlusContributionAmount=@SusuPlusContributionAmount,IsWithholdingTax=@IsWithholdingTax,IsWithholdingTaxFixedAmount=@IsWithholdingTaxFixedAmount,WithholdingTaxFixedAmount=@WithholdingTaxFixedAmount,IsWithholdingTaxRate=@IsWithholdingTaxRate,WithholdingTaxRate=@WithholdingTaxRate,CalculateOn=@CalculateOn,";
                        query += "TransferredOut=@TransferredOut,IsProvidentFund=@IsProvidentFund,QualificationID=@QualificationID,TransferredIn=@TransferredIn Where ID = @ID";
                        dalHelper.ExecuteNonQuery(query);
                        prompt = "Edited Successfully";
                    }
                    else
                    {
                        string query = "Insert Into StaffPersonalInfo(StaffID,FingerPrintID,Surname,Firstname,OtherName,NickName,FileNumber,FileNumberID,PIN,NationalID,MaidenName,";
                        query += "SalaryGrouping,GradeCategoryID,GradeID,GradeOnFirstAppointmentID,GradeDate,StepID,BandID,BasicSalary,DOB,GenderGroupID,TitleID,NationalityID,TownID,Hometown,Telno,MobileNo,MaritalStatusID,DOM,ReligionID,";
                        query += "Placeofbirth,CountryOfBirth,DistrictOfBirth,RegionOfBirth,NoOfChildren,Denomination,NHISNumber,HouseNumber,StreetName,ResidentialTownID,";
                        query += "ResidentialRegionID,ResidentialCountryID,Address,Email,RegionID,ContactCountryID,ContactHomeTownID,DepartmentID,AppointmentTypeID,EmploymentDate,Mechanised,SSNIT,";
                        query += "IncomeTax,Probation,ProbationStartDate,ProbationEndDate,ProbationStatusID,SSNITNo,TIN,Payment,AnnualLeaveEntitlementID,PaymentType,UserID,EngagementTypeID,EngagementGradeIDOn,";
                        query += "EngagementGradeIDLeaving,EngagementDateApplied,EngagementEffectiveDate,EngagementEndingDate,EngagementContractOption,";
                        query += "CurrentPromotionDate,DOFA,DOCA,AssumptionDate,SpecialtyID,UnitID,JobTitleID,OccuGRP,";
                        query += "IsDisable,DisabilityTypeID,DisabilityDate,LicenceTypeID,LicenceNumber,EngagementAnnualSalary,";
                        query += "PFRate,IsExemptFromSecondTier,IsSusuPlusContribution,SusuPlusContributionAmount,IsWithholdingTax,IsWithholdingTaxFixedAmount,WithholdingTaxFixedAmount,IsWithholdingTaxRate,WithholdingTaxRate,CalculateOn,";
                        query += "RaceID,Tribe,Overseer,SupervisorCode,StatusID,ZoneID,InZoneDate,TransferredOut,IsProvidentFund,QualificationID,TransferredIn)";
                        query += "Values(@StaffID,@FingerPrintID,@Surname,@Firstname,@OtherName,@NickName,@FileNumber,@FileNumberID,@PIN,@NationalID,@MaidenName,@SalaryGrouping,@GradeCategoryID,@GradeID,@GradeOnFirstAppointmentID,@GradeDate,@StepID,@BandID,@Salary,@DOB,@GenderGroupID,";
                        query += "@TitleID,@NationalityID,@ContactTownID,@HomeTown,@ContactTelephone,@ContactMobileNumber,@MaritalStatusID,@DOM,@ReligionID,";
                        query += "@POB,@CountryOfBirth,@DistrictOfBirth,@RegionOfBirth,@NoOfChildren,@Denomination,@NHISNumber,@ResidentialHouseNumber,@ResidentialStreetName,@ResidentialTownID,";
                        query += "@ResidentialRegionID,@ResidentialCountryID,@ContactPostalAddress,@ContactEmailAddress,@ContactRegionID,@ContactCountryID,@ContactHomeTownID,@DepartmentID,@AppointmentTypeID,";
                        query += "@EmploymentDate,@Mechanised,@SSNIT,@IncomeTax,@Probation,@ProbationStartDate,@ProbationEndDate,@ProbationStatusID,@SSNITNo,@TIN,@Payment,@AnnualLeaveEntitlementID,@PaymentType,@UserID,";
                        query += "@EngagementTypeID,@EngagementGradeIDOn,@EngagementGradeIDLeaving,@EngagementDate,@EngagementEffectiveDate,";
                        query += "@EngagementEndingDate,@EngagementContractOption,@DOFA,@DOFA,@DOCA,@AssumptionDate,@SpecialtyID,@UnitID,@JobTitleID,@OccuGRP,";
                        query += "@IsDisable,@DisabilityTypeID,@DisabilityDate,@LicenceTypeID,@LicenceNumber,@EngagementAnnualSalary,";
                        query += "@PFRate,@IsExemptFromSecondTier,@IsSusuPlusContribution,@SusuPlusContributionAmount,@IsWithholdingTax,@IsWithholdingTaxFixedAmount,@WithholdingTaxFixedAmount,@IsWithholdingTaxRate,@WithholdingTaxRate,@CalculateOn,";
                        query += "@RaceID,@Tribe,@Overseer,@SupervisorCode,@StatusID,@ZoneID,@InZoneDate,@TransferredOut,@IsProvidentFund,@QualificationID,@TransferredIn)";
                        dalHelper.ExecuteNonQuery(query);
                        employee.ID = int.Parse(dalHelper.ExecuteScalar("Select Max(ID) from StaffPersonalInfo").ToString());

                        if (userNameTextBox.Text.Trim() != string.Empty)
                        {
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@UserName", userNameTextBox.Text, DbType.String);
                            dalHelper.CreateParameter("@Password", passwordTextBox.Text, DbType.String);
                            dalHelper.CreateParameter("@UserCategoryID", userCategories[userRoleComboBox.SelectedIndex].ID, DbType.Int32);
                            dalHelper.CreateParameter("@EmpID", employee.ID, DbType.Int32);

                            dalHelper.ExecuteNonQuery("Insert Into Users(UserName,Password,UserCategoryID,EmpID) Values(@UserName,@Password,@UserCategoryID,@EmpID)");
                        }
                        prompt = "Saved Successfully";
                    }

                    if (pictureBox.Image != null && pictureBox.InitialImage != pictureBox.Image)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@ID", employee.ID, DbType.Int32);
                        dalHelper.CreateParameter("@Image", GlobalData.ImageToArray(pictureBox.Image), DbType.Binary);
                        dalHelper.ExecuteNonQuery("Update StaffPersonalInfo Set Image =@Image Where ID=@ID");
                    }

                    if (fingerPrintPictureBox.Image != null && fingerPrintPictureBox.InitialImage != fingerPrintPictureBox.Image)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@ID", employee.ID, DbType.Int32);
                        dalHelper.CreateParameter("@FingerPrint", GlobalData.ImageToArray(fingerPrintPictureBox.Image), DbType.Binary);
                        dalHelper.ExecuteNonQuery("Update StaffPersonalInfo Set FingerPrint=@FingerPrint Where ID=@ID");
                    }

                    if (probationCheckBox.Checked)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@ID", employee.ID, DbType.Int32);
                        dalHelper.CreateParameter("@ProbationStartDate", DateTime.Parse(startDatePicker.Value.ToString()), DbType.DateTime);
                        dalHelper.CreateParameter("@ProbationEndDate", DateTime.Parse(endDatePicker.Value.ToString()), DbType.DateTime);
                        dalHelper.ExecuteNonQuery("Update StaffPersonalInfo Set ProbationStartDate=@ProbationStartDate,ProbationEndDate=@ProbationEndDate Where ID=@ID");
                    }

                    //It has passed all validations
                    if (allowedToSaveAll)
                    {
                        //Linking attendance sofwtare USERINFO
                        //SaveUserInfo();
                        SaveFileNumber();
                        SaveDependants();
                        SaveLanguages();
                        SaveProfessionHistory();
                        SaveEmploymentHistory();
                        SaveEducationHistory();
                        SaveDocuments();
                        SaveReferee();
                        SaveStaffBanks();
                        SaveOthers();                      
                        userGroupBox.Enabled = false;
                        dalHelper.CommitTransaction();
                        GlobalData.ShowMessage(prompt);
                        saveAll = true;
                    }
                    //After saving successfully
                    editMode = false;
                    btnView.Visible = false;
                    saveAll = false;
                    ClearAll();
                }
            }
            catch (Exception ex)
            {
                dalHelper.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Save Successfully,Please See the System Administrator");
            }
        }

        private void SaveFileNumber()
        {
            try
            {
                if (txtFileNumber.Text != string.Empty)
                {
                    fileNumber.InUse = true;                   
                    fileNumber.User.ID = GlobalData.User.ID;
                    fileNumber.Archived = false;
                    fileNumber.Description = employee.FileNumber.Description;
                    fileNumber.ID = employee.FileNumber.ID;
                    dal.Update(fileNumber);
                }               
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void SaveDependants()
        {
            try
            {
                if (gridRelations.Rows.Count > 1)
                {
                    if (ValidateRelations())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridRelations.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            int relationshipID = 0;
                            int occupationID = 0;
                            int townID = 0;
                            foreach (DataGridViewRow row in gridRelations.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["relationID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        Query relationshipQuery = new Query();
                                        relationshipQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "RelationshipView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationRelationship"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        relationships = dal.GetByCriteria<Relationship>(relationshipQuery);
                                        foreach (Relationship relationship in relationships)
                                        {
                                            if (relationship.Description.Trim() == row.Cells["relationRelationship"].Value.ToString().Trim())
                                            {
                                                relationshipID = relationship.ID;
                                                break;
                                            }
                                            else if (relationship.ID.ToString().Trim() == row.Cells["relationRelationship"].Value.ToString().Trim())
                                            {
                                                relationshipID = relationship.ID;
                                                break;
                                            }
                                        }
                                        Query occupationQuery = new Query();
                                        occupationQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "OccupationView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationOccupation"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        occupations = dal.GetByCriteria<Occupation>(occupationQuery);
                                        foreach (Occupation occupation in occupations)
                                        {
                                            if (occupation.Description.Trim() == row.Cells["relationOccupation"].Value.ToString().Trim())
                                            {
                                                occupationID = occupation.ID;
                                                break;
                                            }
                                            else if (occupation.ID.ToString().Trim() == row.Cells["relationOccupation"].Value.ToString().Trim())
                                            {
                                                occupationID = occupation.ID;
                                                break;
                                            }
                                        }
                                        Query townQuery = new Query();
                                        townQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "TownView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationPOB"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        towns = dal.GetByCriteria<Town>(townQuery);
                                        foreach (Town town in towns)
                                        {
                                            if (town.Description.Trim() == row.Cells["relationPOB"].Value.ToString().Trim())
                                            {
                                                townID = town.ID;
                                                break;
                                            }
                                            else if (town.ID.ToString().Trim() == row.Cells["relationPOB"].Value.ToString().Trim())
                                            {
                                                townID = town.ID;
                                                break;
                                            }
                                        }

                                        dalHelper.CreateParameter("@RelationshipID", relationshipID, DbType.Int32);
                                        dalHelper.CreateParameter("@OccupationID", occupationID, DbType.Int32);
                                        dalHelper.CreateParameter("@POB", townID, DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@DOB", row.Cells["relationDOB"].Value.ToString(), DbType.Date);
                                        dalHelper.CreateParameter("@Type", row.Cells["relationType"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Name", row.Cells["relationName"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Telephone", row.Cells["relationTelephone"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Address", row.Cells["relationAddress"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffOtherRelatives(StaffID,StaffCode,RelationshipID,Type,Name,Telephone,OccupationID,Address,POB,DOB,UserID) Values(@StaffID,@StaffCode,@RelationshipID,@Type,@Name,@Telephone,@OccupationID,@Address,@POB,@DOB,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        Query relationshipQuery = new Query();
                                        relationshipQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "RelationshipView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationRelationship"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        relationships = dal.GetByCriteria<Relationship>(relationshipQuery);
                                        foreach (Relationship relationship in relationships)
                                        {
                                            if (relationship.Description == row.Cells["relationRelationship"].Value.ToString())
                                            {
                                                relationshipID = relationship.ID;
                                                break;
                                            }
                                            else if (relationship.ID.ToString() == row.Cells["relationRelationship"].Value.ToString())
                                            {
                                                relationshipID = relationship.ID;
                                                break;
                                            }
                                        }
                                        Query occupationQuery = new Query();
                                        occupationQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "OccupationView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationOccupation"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        occupations = dal.GetByCriteria<Occupation>(occupationQuery);
                                        foreach (Occupation occupation in occupations)
                                        {
                                            if (occupation.Description == row.Cells["relationOccupation"].Value.ToString())
                                            {
                                                occupationID = occupation.ID;
                                                break;
                                            }
                                            else if (occupation.ID.ToString() == row.Cells["relationOccupation"].Value.ToString())
                                            {
                                                occupationID = occupation.ID;
                                                break;
                                            }
                                        }
                                        Query townQuery = new Query();
                                        townQuery.Criteria.Add(new Criterion()
                                        {
                                            Property = "TownView.Description",
                                            CriterionOperator = CriterionOperator.EqualTo,
                                            Value = row.Cells["relationPOB"].Value.ToString().Trim(),
                                            CriteriaOperator = CriteriaOperator.And
                                        });
                                        towns = dal.GetByCriteria<Town>(townQuery);
                                        foreach (Town town in towns)
                                        {
                                            if (town.Description.Trim() == row.Cells["relationPOB"].Value.ToString().Trim())
                                            {
                                                townID = town.ID;
                                                break;
                                            }
                                            else if (town.ID.ToString().Trim() == row.Cells["relationPOB"].Value.ToString().Trim())
                                            {
                                                townID = town.ID;
                                                break;
                                            }
                                        }
                                        dalHelper.CreateParameter("@RelationshipID", relationshipID, DbType.Int32);
                                        dalHelper.CreateParameter("@OccupationID", occupationID, DbType.Int32);
                                        dalHelper.CreateParameter("@POB", townID, DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@DOB", row.Cells["relationDOB"].Value.ToString(), DbType.Date);
                                        dalHelper.CreateParameter("@Type", row.Cells["relationType"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Name", row.Cells["relationName"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Telephone", row.Cells["relationTelephone"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Address", row.Cells["relationAddress"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@ID", row.Cells["relationID"].Value.ToString(), DbType.String);
                                        dalHelper.ExecuteNonQuery("Update StaffOtherRelatives set StaffID=@StaffID,StaffCode=@StaffCode,RelationshipID=@RelationshipID,Type=@Type,Name=@Name,Telephone=@Telephone,OccupationID=@OccupationID,Address=@Address,POB=@POB,DOB=@DOB,UserID=@UserID where StaffID=@StaffID and ID=@ID and Archived='False'");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void SaveUserInfo()
        {
            try
            {
                //edit this code to 
                employee.StaffID = staffIDTextBox.Text.Trim();
                employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                userInfo.Employee.StaffID = employee.StaffID;
                userInfo.Employee.ID = employee.ID;
                staffBank.Bank.ID = banks[cboBankDetailName.SelectedIndex].ID;
                staffBank.AccountName = txtBankDetailAccountName.Text;
                staffBank.AccountNumber = txtBankDetailAccountNumber.Text;
                staffBank.AccountType.ID = accountTypes[cboBankDetailAccountType.SelectedIndex].ID;
                staffBank.BankBranch.ID = bankBranches[cboBankDetailBranch.SelectedIndex].ID;
                staffBank.In_Use = true;
                staffBank.Address = txtBankDetailAddress.Text;
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffBankView.AccountNumber",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffBank.AccountNumber,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffBanks.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffBank.Employee.StaffID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffBanks = dal.GetByCriteria<StaffBank>(query);
                if (staffBanks.Count <= 0)
                {
                    Query query1 = new Query();
                    query1.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBanks.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffBank.Employee.StaffID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query1.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBanks.InUse",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffBank.In_Use,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    staffBanks = dal.GetByCriteria<StaffBank>(query1);
                    foreach (StaffBank staffA in staffBanks)
                    {
                        staffA.In_Use = false;
                        dal.Update(staffA);
                    }
                    dal.Save(staffBank);
                }
                else
                {
                    foreach (StaffBank staffB in staffBanks)
                    {
                        staffB.Employee.StaffID = staffBank.Employee.StaffID;
                        staffB.Employee.ID = staffBank.Employee.ID;
                        staffB.Bank.ID = staffBank.Bank.ID;
                        staffB.AccountName = staffBank.AccountName;
                        staffB.AccountNumber = staffBank.AccountNumber;
                        staffB.AccountType.ID = staffBank.AccountType.ID;
                        staffB.BankBranch.ID = staffBank.BankBranch.ID;
                        staffB.In_Use = staffBank.In_Use;
                        staffB.Address = staffBank.Address;
                        dal.Update(staffB);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void SaveStaffBanks()
        {
            try
            {

                employee.StaffID = staffIDTextBox.Text.Trim();
                employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                staffBank.Employee.StaffID = employee.StaffID;
                staffBank.Employee.ID = employee.ID;
                staffBank.Bank.ID = banks[cboBankDetailName.SelectedIndex].ID;
                staffBank.AccountName = txtBankDetailAccountName.Text;
                staffBank.AccountNumber = txtBankDetailAccountNumber.Text;
                staffBank.AccountType.ID = accountTypes[cboBankDetailAccountType.SelectedIndex].ID;
                staffBank.BankBranch.ID = bankBranches[cboBankDetailBranch.SelectedIndex].ID;
                staffBank.In_Use = true;
                staffBank.Address = txtBankDetailAddress.Text.Trim();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffBankView.AccountNumber",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffBank.AccountNumber,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffBankView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffBank.Employee.StaffID,
                    CriteriaOperator = CriteriaOperator.And
                });
                staffBanks = dal.GetByCriteria<StaffBank>(query);
                if (staffBanks.Count <= 0)
                {
                    Query query1 = new Query();                  
                    query1.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBankView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffBank.Employee.StaffID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query1.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBankView.InUse",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffBank.In_Use,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    staffBanks = dal.GetByCriteria<StaffBank>(query1);
                    foreach (StaffBank staffA in staffBanks)
                    {
                        staffA.In_Use = false;  
                        dal.Update(staffA);
                    }
                    dal.Save(staffBank);
                }
                else
                {
                    foreach (StaffBank staffB in staffBanks)
                    {
                        staffB.Employee.StaffID = staffBank.Employee.StaffID;
                        staffB.Employee.ID=staffBank.Employee.ID;
                        staffB.Bank.ID=staffBank.Bank.ID;
                        staffB.AccountName=staffBank.AccountName;
                        staffB.AccountNumber=staffBank.AccountNumber;
                        staffB.AccountType.ID=staffBank.AccountType.ID;
                        staffB.BankBranch.ID=staffBank.BankBranch.ID;
                        staffB.In_Use=staffBank.In_Use;
                        staffB .Address= staffBank.Address;
                        dal.Update(staffB);
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }           
        }

        private void SaveLanguages()
        {
            try
            {
                if (gridLanguage.Rows.Count > 1)
                {
                    if (ValidateLanguages())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridLanguage.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            string languageID = string.Empty;
                            foreach (DataGridViewRow row in gridLanguage.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["gridLanguageID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        languages = dal.GetAll<Language>();
                                        foreach (Language language in languages)
                                        {
                                            if (language.Description.Trim() == row.Cells["colLanguage"].Value.ToString().Trim())
                                            {
                                                languageID = language.ID.ToString();
                                                break;
                                            }
                                            else if (language.ID.ToString().Trim() == row.Cells["colLanguage"].Value.ToString().Trim())
                                            {
                                                languageID = language.ID.ToString();
                                                break;
                                            }
                                        }
                                        dalHelper.CreateParameter("@StaffID", staffIDTextBox.Text.Trim(), DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@LanguageID", languageID, DbType.Int32);
                                        dalHelper.CreateParameter("@LanguageLevel", row.Cells["colLanguageLevel"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffLanguages(StaffID,StaffCode,LanguageID,LanguageLevel,UserID) Values(@StaffID,@StaffCode,@LanguageID,@LanguageLevel,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        languages = dal.GetAll<Language>();
                                        foreach (Language language in languages)
                                        {
                                            if (language.Description.Trim() == row.Cells["colLanguage"].Value.ToString().Trim())
                                            {
                                                languageID = language.ID.ToString();
                                                break;
                                            }
                                            else if (language.ID.ToString().Trim() == row.Cells["colLanguage"].Value.ToString().Trim())
                                            {
                                                languageID = language.ID.ToString();
                                                break;
                                            }
                                        }
                                        dalHelper.CreateParameter("@ID", row.Cells["gridLanguageID"].Value, DbType.String);
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@LanguageID", languageID, DbType.String);
                                        dalHelper.CreateParameter("@LanguageLevel", row.Cells["colLanguageLevel"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Update StaffLanguages set StaffID=@StaffID,StaffCode=@StaffCode,LanguageID=@LanguageID,LanguageLevel=@LanguageLevel,UserID=@UserID where StaffID=@StaffID and ID=@ID");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void SaveEducationHistory()
        {
            try
            {
                if (gridEducationHistory.Rows.Count > 1)
                {
                    if (ValidateEducationHistory())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridEducationHistory.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            foreach (DataGridViewRow row in gridEducationHistory.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["qualificationsID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@CertificateObtained", row.Cells["qualificationsCertificateObtained"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@NameOfInstitution", row.Cells["qualificationsNameOfInstitution"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["qualificationsFromMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["qualificationsFromYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["qualificationsToMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["qualificationsToYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffEducationHistory(StaffID,StaffCode,CertificateObtained,NameOfInstitution,StartMonth,StartYear,EndMonth,EndYear,UserID) Values (@StaffID,@StaffCode,@CertificateObtained,@NameOfInstitution,@StartMonth,@StartYear,@EndMonth,@EndYear,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@CertificateObtained", row.Cells["qualificationsCertificateObtained"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@NameOfInstitution", row.Cells["qualificationsNameOfInstitution"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["qualificationsFromMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["qualificationsFromYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["qualificationsToMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["qualificationsToYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@ID", row.Cells["qualificationsID"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Archived", false, DbType.Boolean);

                                        dalHelper.ExecuteNonQuery("Update StaffEducationHistory set StaffID=@StaffID,StaffCode=@StaffCode,CertificateObtained=@CertificateObtained,NameOfInstitution=@NameOfInstitution,StartMonth=@StartMonth,StartYear=@StartYear,EndMonth=@EndMonth,EndYear=@EndYear,UserID=@UserID where StaffID=@StaffID and ID=@ID and Archived=@Archived");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private string getPhoneFormat(string PhoneNo)
        {
            string CorrectPhoneNumber = string.Empty;
            try
            {
                if (PhoneNo.Trim() != string.Empty && PhoneNo.Length == 13 && PhoneNo != null)
                {
                    string[] PhoneParts = PhoneNo.Split('-');
                    string FirstPart = PhoneParts[0].ToString().Trim();

                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PhoneNumberTypes.Code".Trim(),
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = FirstPart,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    phoneNumberTypeList = dal.GetByCriteria<PhoneNumberType>(query);
                    if (phoneNumberTypeList.Count > 0)
                    {
                        CorrectPhoneNumber = "Yes";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return CorrectPhoneNumber;
        }

        private bool ValidatePersonalInfo()
        {
            bool result = true;
            try
            {
                int MaxAge = 0;
                int MinAge = 0;
                string OwnershipType = string.Empty;
                bool isFileNumber = false;
                staffErrorProvider.Clear();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@StaffID", staffIDTextBox.Text.Trim(), DbType.String);
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@ID", employee.ID, DbType.Int32);

                company = dal.LazyLoad<Company>()[0];
                MaxAge = company.MaximumEmployeeAge;
                MinAge = company.MinimumEmployeeAge;
                isFileNumber = company.IsFileNumber;

                //Personal Details
                if (employee.ID == 0)
                {

                    if (dalHelper.ExecuteReader("Select StaffID from StaffPersonalInfo Where StaffID =@StaffID And Archived =@Archived").Rows.Count > 0)
                    {
                        result = false;
                        staffErrorProvider.SetError(staffIDTextBox, "The staff ID you have entered already exists please change it");
                        staffIDTextBox.Focus();
                    }
                }
                else
                {
                    if (dalHelper.ExecuteReader("Select StaffID from StaffPersonalInfo Where StaffID =@StaffID And ID <>@ID And Archived =@Archived").Rows.Count > 0)
                    {
                        result = false;
                        staffErrorProvider.SetError(staffIDTextBox, "The staff ID you have entered already exists please change it");
                        staffIDTextBox.Focus();
                    }
                    if (staffCode == employee.ID)
                    {
                        result = false;
                        MessageBox.Show("Please Supervisor Cannot be the same person (Job Detail)");
                        tabOtherDetails.SelectedTab = JobDetailTabPage;
                        staffIDtxt.Focus();
                    }
                }

                if (staffIDTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDTextBox, "Please generate or enter a staffID");
                    staffIDTextBox.Focus();
                }
                else if (isFileNumber == true && txtFileNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtFileNumber, "Please Select the File Number");
                    txtFileNumber.Focus();
                }
                else if (surnameTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(surnameTextBox, "Please enter the employee's surname");
                    surnameTextBox.Focus();
                }
                else if (txtFirstName.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtFirstName, "Please enter the employee's first name");
                    txtFirstName.Focus();
                }
                else if (cmbSex.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbSex, "Please select the employee's gender");
                    cmbSex.Focus();
                }
                else if (cmbMaritalStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbMaritalStatus, "Please select the employee's marital status");
                    cmbMaritalStatus.Focus();
                }
                else if (cmbMaritalStatus.SelectedItem.ToString() == "Married" && dateDOM.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOM, "Please select the employee's date of marriage");
                    dateDOM.Focus();
                }
                else if (cmbTitle.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbTitle, "Please select the employee's title");
                    cmbTitle.Focus();
                }
                else if (dateDOB.Checked && !Validator.DateRangeValidator(dateDOB.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "The employee's date of birth cannot be greater than today");
                    dateDOB.Focus();
                }
                else if (dateDOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please select the employee's date of birth");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) > MaxAge)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please the age cannot be greater than the max age");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) < MinAge)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please the age cannot be less than the min age");
                    dateDOB.Focus();
                }
                else if (cmbPOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbPOB, "Please select a place of birth");
                    cmbPOB.Focus();
                }
                else if (cmbHomeTown.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbHomeTown, "Please select a home town");
                    cmbHomeTown.Focus();
                }
                else if (cboBirthDistrict.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboBirthDistrict, "Please select the employee's Birth District");
                    cboBirthDistrict.Focus();
                }
                else if (cboBirthCountry.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboBirthCountry, "Please select the employee's Birth Country");
                    cboBirthCountry.Focus();
                }
                else if (cboNationality.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboNationality, "Please select the employee's nationality");
                    cboNationality.Focus();
                }
                else if (cmbReligion.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cmbReligion, "Please select the employee's Religion");
                    cmbReligion.Focus();
                }
                else if (cmbReligion.Text.Trim() != string.Empty && cboDenomination.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboDenomination, "Please select the employee's Denomination");
                    cboDenomination.Focus();
                }
                else if (cboZone.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboZone, "Please select the employee's Zone");
                    cboZone.Focus();
                }
                //Contact Detail
                else if (txtContactPostalAddress.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Postal Address (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtContactPostalAddress.Focus();
                }
                else if (cboContactRegion.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Region (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboContactRegion.Focus();
                }
                else if (cboContactRegion.Text.Trim() != string.Empty && cboContactCity.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's City (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboContactCity.Focus();
                }
                else if (cboContactCountry.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Country (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboContactCountry.Focus();
                }
                //else if (cboContactHomeTown.Text.Trim() == string.Empty)
                //{
                //    result = false;
                //    MessageBox.Show("Please Select Employee's HomeTown (Contact)");
                //    tabOtherDetails.SelectedTab = ContactTabPage;
                //    cboContactHomeTown.Focus();
                //}
                else if (txtContactTelephone.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Telephone (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtContactTelephone.Focus();
                }
                else if (getPhoneFormat(txtContactMobileNumber.Text.Trim()) == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Correct Format For the Mobile Number (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtContactMobileNumber.Focus();
                }
                else if (txtContactMobileNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Mobile Number (Contact)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtContactMobileNumber.Focus();
                }
                //else if (txtContactEmailAddress.Text.Trim() == string.Empty)
                //{
                //    result = false;
                //    MessageBox.Show("Email Address cannot be empty");
                //    tabOtherDetails.SelectedTab = ContactTabPage;
                //    txtContactEmailAddress.Focus();
                //}
                else if (txtContactEmailAddress.Text.Trim() != string.Empty && !Validator.EmailValidator(txtContactEmailAddress.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Email address is invalid");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtContactEmailAddress.Focus();
                }
                //Contact/Residential
                else if (txtResidentialHouseNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's House Number (Contact/Residential)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    txtResidentialHouseNumber.Focus();
                }
                else if (cboResidentialRegion.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Region (Contact/Residential)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboResidentialRegion.Focus();
                }
                else if (cboResidentialRegion.Text.Trim() != string.Empty && cboResidentialCity.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's City (Contact/Residential)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboResidentialCity.Focus();
                }
                else if (cboResidentialCountry.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Country (Contact/Residential)");
                    tabOtherDetails.SelectedTab = ContactTabPage;
                    cboResidentialCountry.Focus();
                }
                //Job Detail
                else if (departmentComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Department (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    departmentComboBox.Focus();
                }
                else if (departmentComboBox.Text.Trim() != string.Empty && cboUnit.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Unit (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboUnit.Focus();
                }
                else if (cboJobTitle.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Job Title (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboJobTitle.Focus();
                }
                else if (cboSpecialty.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Specialty (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboSpecialty.Focus();
                }
                else if (cboOccupationGrp.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Occupation Group (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboOccupationGrp.Focus();
                }
                else if (cboEmploymentStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Status (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboEmploymentStatus.Focus();
                }
                else if (DOFADatePicker.Checked && !Validator.DateRangeValidator(DOFADatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's DOFA cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    DOFADatePicker.Focus();
                }
                else if (DOFADatePicker.Checked == false  || DOFADatePicker.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's DOFA (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    DOFADatePicker.Focus();
                }
                else if (DOCADatePicker.Checked && !Validator.DateRangeValidator(DOCADatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's DOCA cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    DOCADatePicker.Focus();
                }
                else if (DOCADatePicker.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's DOCA (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    DOCADatePicker.Focus();
                }
                else if (assumptionDatePicker.Checked && !Validator.DateRangeValidator(assumptionDatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's date of assumption cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    assumptionDatePicker.Focus();
                }
                else if (assumptionDatePicker.Checked == false || assumptionDatePicker.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's date of assumption (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    assumptionDatePicker.Focus();
                }
                else if (probationCheckBox.Checked && startDatePicker.Checked && !Validator.DateRangeValidator(startDatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's start date cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    startDatePicker.Focus();
                }
                else if (probationCheckBox.Checked && startDatePicker.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's start date (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    assumptionDatePicker.Focus();
                }
                else if (probationCheckBox.Checked && startDatePicker.Value > endDatePicker.Value)
                {
                    result = false;
                    MessageBox.Show("Please Employee's start date cannot be greater than the End Date(Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    assumptionDatePicker.Focus();
                }
                else if (probationCheckBox.Checked && endDatePicker.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's end date (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    endDatePicker.Focus();
                }
                else if (probationCheckBox.Checked && cboProbationStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Probation Status (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboProbationStatus.Focus();
                }
                else if (cboAppointmentType.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Appointment Type (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    cboAppointmentType.Focus();
                }
                else if (dateEmploymentDate.Checked && !Validator.DateRangeValidator(dateEmploymentDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's date of employment cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEmploymentDate.Focus();
                }
                else if (dateEmploymentDate.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's date of employment (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEmploymentDate.Focus();
                }
                else if (dateEngagementDate.Checked && !Validator.DateRangeValidator(dateEngagementDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's Engagement Date cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementDate.Focus();
                }
                else if (dateEngagementDate.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Engagement Date (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementDate.Focus();
                }
                else if (dateEngagementEffectiveDate.Checked && !Validator.DateRangeValidator(dateEngagementEffectiveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's Engagement Effective Date cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementEffectiveDate.Focus();
                }
                else if (dateEngagementEffectiveDate.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Engagement Effective Date (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementEffectiveDate.Focus();
                }
                else if (dateEngagementEndingDate.Checked && !Validator.DateRangeValidator(dateEngagementEffectiveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The employee's Engagement Ending Date cannot be greater than today (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementEndingDate.Focus();
                }
                else if (dateEngagementEndingDate.Value.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Engagement Ending Date (Job Detail)");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    dateEngagementEndingDate.Focus();
                }
                else if (cboAppointmentType.Text.ToLower().Trim() == "contract" && !Validator.DecimalValidator(txtEngagementAnnualSalary.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Please Enter a Decimal in the Annual Salary ");
                    tabOtherDetails.SelectedTab = JobDetailTabPage;
                    txtEngagementAnnualSalary.Focus();
                }
                //Salary Detail
                else if (gradeCategoryComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Grade Category (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    gradeCategoryComboBox.Focus();
                }
                else if (gradeCategoryComboBox.Text.Trim() != string.Empty && gradeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Grade (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    gradeComboBox.Focus();
                }
                else if (company.IsSalaryStructure==true && cboStep.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Step (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    cboStep.Focus();
                }
                else if (txtSalary.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Basic Salary");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    txtSalary.Focus();
                }
                else if (!Validator.DecimalValidator(txtSalary.Text.Trim()))
                {
                    result = false;
                    MessageBox.Show("Please Enter a Decimal in the Basic Salary ");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    txtSalary.Focus();
                }
                else if (company.IsSalaryStructure == true && cboBand.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Level (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    cboBand.Focus();
                }

                else if (ssnitCheckBox.Checked && ssnitNoTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's SSNIT Number (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    ssnitNoTextBox.Focus();
                }
                else if (paymentTypeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Payment Type (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    paymentTypeComboBox.Focus();
                }
                //else if (cboLeaveEntitlement.Text.Trim() == string.Empty)
                //{
                //    result = false;
                //    MessageBox.Show("Please Select Employee's Leave Entitlement (Salary Detail)");
                //    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                //    cboLeaveEntitlement.Focus();
                //}

                //Salary Details /Bank Details
                else if (cboBankDetailName.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Bank (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    cboBankDetailName.Focus();
                }
                else if (cboBankDetailName.Text.Trim() != string.Empty && cboBankDetailBranch.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Bank Branch (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    cboBankDetailBranch.Focus();
                }
                else if (cboBankDetailName.Text.Trim() != string.Empty && cboBankDetailAccountType.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Employee's Account Type (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    cboBankDetailAccountType.Focus();
                }
                else if (cboBankDetailName.Text.Trim() != string.Empty && txtBankDetailAccountNumber.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Account Number (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    txtBankDetailAccountNumber.Focus();
                }
                else if (cboBankDetailName.Text.Trim() != string.Empty && txtBankDetailAccountName.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Enter Employee's Account Name (Salary Detail)");
                    tabOtherDetails.SelectedTab = SalaryDetailTabPage;
                    txtBankDetailAccountName.Focus();
                }
                //If is in the insert mode
                else if (!editMode)
                {
                    if (userNameTextBox.Text.Trim() != string.Empty)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@UserName", userNameTextBox.Text.Trim().ToLower(), DbType.String);
                        if (dalHelper.ExecuteReader("select * from users where Lower(UserName)=@UserName").Rows.Count > 0)
                        {
                            result = false;
                            MessageBox.Show("The user name you have entered already exists. Please change it");
                            tabOtherDetails.SelectedTab = UserAccountTabPage;
                            userNameTextBox.Focus();
                        }
                        if (userNameTextBox.Text.Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter employee's user name");
                            tabOtherDetails.SelectedTab = UserAccountTabPage;
                            userNameTextBox.Focus();
                        }
                        if (passwordTextBox.Text.Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please employee's enter Password");
                            tabOtherDetails.SelectedTab = UserAccountTabPage;
                            passwordTextBox.Focus();
                        }
                        else
                        {
                            if (passwordTextBox.Text.Trim() != confirmPasswordTextBox.Text.Trim())
                            {
                                result = false;
                                MessageBox.Show("Please confirm your password");
                                tabOtherDetails.SelectedTab = UserAccountTabPage;
                                confirmPasswordTextBox.Focus();
                            }
                        }
                        if (userRoleComboBox.Text.Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the employee's Role");
                            tabOtherDetails.SelectedTab = UserAccountTabPage;
                            userRoleComboBox.Focus();
                        }
                    }
                }
                allowedToSaveAll = result;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                result = false;
                throw ex;
            }
            return result;
        }

        private bool ValidateWorkPermit()
        {
            bool result = true;
            try
            {
                //Work Permit Details
                if (cmbWorkPermit.Text.Trim() == "Yes")
                {
                    if (txtWorkPermitID.Text.Trim() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter Work Permit ID");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        txtWorkPermitID.Focus();
                    }
                    else if (cmbWorkPermit.Text.Trim() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Select Work Permit");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        cmbWorkPermit.Focus();
                    }
                    else if (dateWorkPermit.Value.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Work Permit Expiry Date ");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateWorkPermit.Focus();
                    }
                    else if (txtDuration.Text.Trim() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Work Permit Duration (Days)");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        txtDuration.Focus();
                    }
                }
                
            }
            catch(Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return result;
        }

        private bool ValidatePassport()
        {
            bool result = true;
            try
            {
                //Passport Details
                if (checkBoxHasPassport.Checked == true)
                {
                    if (txtPassportNo.Text.Trim() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Passport Number");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        txtPassportNo.Focus();
                    }
                    else if (dateIssued.Value.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Passport Issued Date");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateIssued.Focus();
                    }
                    else if (!Validator.DateRangeValidator(dateIssued.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                    {
                        result = false;
                        MessageBox.Show("The Passport Issued date cannot be greater than today");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateIssued.Focus();
                    }
                    else if (dateIssued.Value > dateExpires.Value)
                    {
                        result = false;
                        MessageBox.Show("The Passport Issued date cannot be greater than Expiry date");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateIssued.Focus();
                    }
                    else if (dateExpires.Value.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Passport Expiry Date");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateExpires.Focus();
                    }
                }
            }
            catch(Exception ex)
            {
                string str=ex.Message;
                throw ex;
            }
            return result;
        }

        private bool ValidateVisa()
        {
            bool result = true;
            try
            {
                //Visa Details
                if(checkBoxHasVisa.Checked==true)
                {
                    if (txtVisaNo.Text.Trim() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Visa Number");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        txtVisaNo.Focus();
                    }
                    else if (dateFrom.Value.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Start Date of the Visa");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateFrom.Focus();
                    }
                    else if (dateTo.Value.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Expiry Date of the Visa");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateTo.Focus();
                    }
                    else if (!Validator.DateRangeValidator(dateFrom.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                    {
                        result = false;
                        MessageBox.Show("The Visa date(From) cannot be greater than today");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateFrom.Focus();
                    }
                    else if (dateFrom.Value > dateTo.Value)
                    {
                        result = false;
                        MessageBox.Show("The Visa date(From) cannot be greater than Expired date");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        dateFrom.Focus();
                    }
                    else if (cmbVisaType.Text.ToString() == string.Empty)
                    {
                        result = false;
                        MessageBox.Show("Please Enter The Visa Type");
                        tabOtherDetails.SelectedTab = workPermitTabPage;
                        cmbVisaType.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                throw ex;
            }
            return result;
        }

        private bool ValidateRelations()
        {
            bool result = true;
            try
            {
                relationsErrorProvider.Clear();
                gridRelations.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in gridRelations.Rows)
                {
                    //If data is entered
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["relationName"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter a name on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationName"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter a name on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["relationRelationship"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select a relation on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationRelationship"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select a relation on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationType"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the Type on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationType"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the Type on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationOccupation"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the Occupation on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationOccupation"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the Occupation on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationDOB"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter DOB on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationDOB"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter DOB on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (!Validator.DateRangeValidator(DateTime.Parse(row.Cells["relationDOB"].Value.ToString()), GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                        {
                            result = false;
                            MessageBox.Show("Please DOB cannot be  grater than Today on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationPOB"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the Place of birth on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["relationPOB"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the Place of birth on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = dependentsTabPage;
                            gridRelations.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["relationTelephone"].Value == null)
                        {
                            row.Cells["relationTelephone"].Value = string.Empty;
                        }
                        if (row.Cells["relationOccupation"].Value == null)
                        {
                            row.Cells["relationOccupation"].Value = string.Empty;
                        }
                        if (row.Cells["relationAddress"].Value == null)
                        {
                            row.Cells["relationAddress"].Value = string.Empty;
                        }
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private bool ValidateLanguages()
        {
            bool result = true;
            try
            {
                gridLanguage.CommitEdit(DataGridViewDataErrorContexts.Commit);
                foreach (DataGridViewRow row in gridLanguage.Rows)
                {
                    //If data is entered
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["colLanguage"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select a Language on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = LanguageTabPage;
                            gridLanguage.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["colLanguage"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select a Language on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = LanguageTabPage;
                            gridLanguage.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["colLanguageLevel"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select a Level on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = LanguageTabPage;
                            gridLanguage.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["colLanguageLevel"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select a Level on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = LanguageTabPage;
                            gridLanguage.Rows[row.Index + 1].Selected = true;
                        }                     
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void ClearProfessionHistory()
        {
            try
            {
                gridProfession.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearPersonalInfo()
        {
            try
            {
                //Peronal Info
                fingerPrintTextBox.Text = GenerateFingerPrintID();
                staffIDTextBox.Text = GenerateStaffID();
                dalHelper.CloseConnection();
                dal.CloseConnection();

                enableControls(true);

                cboRace.Items.Clear();
                cboRace.Text = string.Empty;
                txtOverseer.Clear();
                txtTribe.Clear();
                staffIDtxt.Clear();
                nametxt.Clear();
                checkBoxExemptFromSecondTier.Checked = false;

                txtPIN.Clear();
                txtNationalID.Clear();
                surnameTextBox.Clear();
                txtFirstName.Clear();
                txtNumberOfChildren.Text = "0";
                txtOtherName.Clear();
                txtMaidenName.Clear();
                txtFileNumber.Items.Clear();
                txtFileNumber.Text = string.Empty;
                txtNickName.Clear();
                cmbSex.Items.Clear();
                cmbSex.Text = string.Empty;
                cmbMaritalStatus.Items.Clear();
                cmbMaritalStatus.Text = string.Empty;
                cmbTitle.Items.Clear();
                cmbTitle.Text = string.Empty;
                dateDOB.ResetText();
                dateDOB.Checked = false;
                cmbPOB.Items.Clear();
                cmbPOB.Text = string.Empty;
                cmbHomeTown.Items.Clear();
                cmbHomeTown.Text = string.Empty;
                cboBirthRegion.Items.Clear();
                cboBirthRegion.Text = string.Empty;
                cboBirthDistrict.Items.Clear();
                cboBirthDistrict.Text = string.Empty;
                cboBirthCountry.Items.Clear();
                cboBirthCountry.Text = string.Empty;
                cboNationality.Items.Clear();
                cboNationality.Text = string.Empty;
                cmbReligion.Items.Clear();
                cmbReligion.Text = string.Empty;
                cboDenomination.Items.Clear();
                cboDenomination.Text = string.Empty;
                txtNHISNumber.Clear();
                dateDOM.ResetText();
                pictureBox.Image = pictureBox.InitialImage;
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboQualificationType.Items.Clear();
                cboQualificationType.Text = string.Empty;
                checkBoxActive.Checked = false;

                checkBoxDisability.Checked = false;
                cboDisabilityType.Items.Clear();
                cboDisabilityType.Text = string.Empty;
                datePickerDisabilityDate.Checked = false;

                cboLicenceType.Items.Clear();
                cboLicenceType.Text = string.Empty;
                txtLicenceNumber.Text = string.Empty;


                //Contact 
                txtContactPostalAddress.Clear();
                cboContactRegion.Items.Clear();
                cboContactRegion.Text = string.Empty;
                cboContactCity.Items.Clear();
                cboContactCity.Text = string.Empty;
                cboContactCountry.Items.Clear();
                cboContactCountry.Text = string.Empty;
                cboContactHomeTown.Items.Clear();
                cboContactHomeTown.Text = string.Empty;
                txtContactTelephone.Clear();
                txtContactMobileNumber.Clear();
                txtContactEmailAddress.Clear();

                //Residential
                txtResidentialHouseNumber.Clear();
                txtResidentialStreetName.Clear();
                cboResidentialRegion.Items.Clear();
                cboResidentialRegion.Text = string.Empty;
                cboResidentialCity.Items.Clear();
                cboResidentialCity.Text = string.Empty;
                cboResidentialCountry.Items.Clear();
                cboResidentialCountry.Text = string.Empty;


                //Job Detail
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboJobTitle.Items.Clear();
                cboJobTitle.Text = string.Empty;
                cboSpecialty.Items.Clear();
                cboSpecialty.Text = string.Empty;
                cboOccupationGrp.Items.Clear();
                cboOccupationGrp.Text = string.Empty;
                cboEmploymentStatus.Items.Clear();
                cboEmploymentStatus.Text = string.Empty;
                DOFADatePicker.ResetText();
                DOCADatePicker.ResetText();
                assumptionDatePicker.ResetText();
                probationCheckBox.Checked=false;
                startDatePicker.Checked = false;
                startDatePicker.ResetText();
                endDatePicker.ResetText();
                endDatePicker.Checked = false;
                cboProbationStatus.Items.Clear();
                cboProbationStatus.Text = string.Empty;
                cboAppointmentType.Items.Clear();
                cboAppointmentType.Text = string.Empty;
                dateEmploymentDate.ResetText();
                cboEngagementType.Items.Clear();
                cboEngagementType.Text = string.Empty;
                dateEngagementDate.ResetText();
                dateEngagementDate.Checked = false;
                cboEngagementGradeOn.Items.Clear();
                cboEngagementGradeOn.Text = string.Empty;
                cboEngagementGradeLeaving.Items.Clear();
                cboEngagementGradeLeaving.Text = string.Empty;
                dateEngagementEffectiveDate.ResetText();
                dateEngagementEndingDate.ResetText();
                dateEngagementEffectiveDate.Checked = false;
                dateEngagementEndingDate.Checked = false;
                foreach (int i in checkedListBoxContract.CheckedIndices)
                {
                    checkedListBoxContract.SetItemCheckState(i, CheckState.Unchecked);
                }
                txtEngagementAnnualSalary.ResetText();
                //Job Detail Transfer Details
                transferredInRadioButton.Checked=false;
                transferredOutRadioButton.Checked=false;

                //Salary Detail
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                gradeDatePicker.Checked = false;

                cboGradeOnFirstAppointment.Items.Clear();
                cboGradeOnFirstAppointment.Text=string.Empty;
                cboStep.Items.Clear();
                cboStep.Text = string.Empty;
                txtSalary.Text = "0";
                cboBand.Items.Clear();
                cboBand.Text = string.Empty;
                cboSalaryGrouping.Items.Clear();
                cboSalaryGrouping.Text = string.Empty;
                cboLeaveEntitlement.Items.Clear();
                cboLeaveEntitlement.Text = string.Empty;
                ssnitNoTextBox.Clear();
                numericPF.Value = 0;
                paymentTypeComboBox.Items.Clear();
                paymentTypeComboBox.Text = string.Empty;
                txtTIN.Clear();
                checkBoxMechanised.Checked = false;
                ssnitCheckBox.Checked = false;
                incomeCheckBox.Checked = false;
                isProvidentFundCheckBox.Checked = false;
                susuPlusContributionCheckBox.Checked = false;
                susuPlusContributionAmountTextBox.Text = string.Empty;
                withholdingTaxCheckBox.Checked = false;
                withholdingTaxFixedAmountRadioButton.Checked = false;
                withholdingTaxFixedAmountTextBox.Text = string.Empty;
                withholdingTaxRateRadioButton.Checked = false;
                withholdingTaxRateNumericUpDown.Value = 0;
                calculatedOnComboBox.Items.Clear();
                calculatedOnComboBox.Text = string.Empty;


                //Bank Details
                cboBankDetailName.Items.Clear();
                cboBankDetailName.Text = string.Empty;
                cboBankDetailBranch.Items.Clear();
                cboBankDetailBranch.Text = string.Empty;
                cboBankDetailAccountType.Items.Clear();
                cboBankDetailAccountType.Text = string.Empty;
                txtBankDetailAccountNumber.Clear();
                txtBankDetailAccountName.Clear();
                txtBankDetailAddress.Clear();

                //User Account
                userNameTextBox.Clear();
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                userRoleComboBox.Items.Clear();
                userRoleComboBox.Text = string.Empty;
                fingerPrintTextBox.Clear();
                fingerPrintPictureBox.Image = fingerPrintPictureBox.InitialImage;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnDocumentsView_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDocuments.CurrentRow != null && gridDocuments.CurrentRow.Cells["gridDocumentsPath"].Value != null)
                {
                    //if (reader != null && !reader.IsDisposed)
                    //{
                    //    reader.Close();
                    //    reader = null;
                    //}

                    //reader1 = new DocBrowser();
                    //reader1.LoadDocument("C:/Users/User/Downloads/sample.docx");

                    reader = new PDFReader(gridDocuments.CurrentRow.Cells["gridDocumentsPath"].Value.ToString());
                    reader.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void SetTransferInOut(bool transferIn, bool transferOut)
        {
            try
            {
                transferredInRadioButton.Checked = transferIn;
                transferredOutRadioButton.Checked = transferOut;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearFamilyDetails_Click(object sender, EventArgs e)
        {
            try
            {
                gridRelations.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearEducationHistory_Click(object sender, EventArgs e)
        {
            try
            {
                gridEducationHistory.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearEmploymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                gridEmploymentHistory.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                gridLanguage.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearRefrees_Click(object sender, EventArgs e)
        {
            try
            {
                gridRefrees.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ClearOthers()
        {
            try
            {
               
                dalHelper.CloseConnection();
                dal.CloseConnection();
                //Work Permit Details
                cmbWorkPermit.ResetText();
                cmbWorkPermit.Text = string.Empty;
                txtWorkPermitID.Clear();
                dateWorkPermit.ResetText();
                txtDuration.Value = 0;
                txtWorkPermitNotes.Clear();

                //Passport Details
                checkBoxHasPassport.Checked = false;
                txtPassportNo.ResetText();
                dateIssued.ResetText();
                dateExpires.ResetText();
                txtPassportNotes.Clear();

                //Social History Details
                cmbDisabled.Text = string.Empty;
                cmbApplied.Text = string.Empty;
                cmbBonded.Text = string.Empty;
                cmbConvicted.Text = string.Empty;

                //Visa Details
                checkBoxHasVisa.Checked = false;
                txtVisaNo.Clear();
                cmbVisaType.ResetText();
                dateFrom.ResetText();
                dateTo.ResetText();
                txtVisaNotes.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClearWorkPermits_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOthers();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private bool ValidateEducationHistory()
        {
            bool result = true;
            try
            {
                educationErrorProvider.Clear();
                foreach (DataGridViewRow row in gridEducationHistory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["qualificationsNameOfInstitution"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the institution attended on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsNameOfInstitution"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the institution attended on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsCertificateObtained"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the certificate obtained on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsCertificateObtained"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the certificate obtained on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsFromMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsFromMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsFromYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsFromYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsToMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsToMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsToYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the end year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["qualificationsToYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = educationHistoryTabPage;
                            gridEducationHistory.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }


        private void btnSaveEducationHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if (ValidateEducationHistory())
                    {
                        try
                        {
                            SaveEducationHistory();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Not save successfully");
                        }
                        GetEducationHistory();
                    }
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could not refresh the grid");
            }
        }

        private bool ValidateEmploymentHistory()
        {
            bool result = true;
            try
            {
                educationErrorProvider.Clear();
                foreach (DataGridViewRow row in gridEmploymentHistory.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["experienceNameOfOrganisation"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the organization on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceNameOfOrganisation"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the organization on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceJobTitle"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the job description on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceJobTitle"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the job description on row  " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceAnnualSalary"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the Annual Salary on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceAnnualSalary"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the Annual Salary on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceFromMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceFromMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceFromYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceFromYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceToMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceToMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceToYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["experienceToYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = employmentTabPage;
                            gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                        }
                        else
                        {
                            try
                            {
                                decimal test = decimal.Parse(row.Cells["experienceAnnualSalary"].Value.ToString().Trim());
                            }
                            catch (Exception ex)
                            {
                                string err = ex.Message;
                                result = false;
                                MessageBox.Show("Please enter a valid decimal as monthly salary on row " + (row.Index + 1));
                                tabOtherDetails.SelectedTab = employmentTabPage;
                                gridEmploymentHistory.Rows[row.Index + 1].Selected = true;
                            }
                        }
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSaveEmploymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if(ValidateEmploymentHistory())
                    {
                        try
                        {
                            SaveEmploymentHistory();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Could Not Save Successfully, Please See the System Administrator");
                        }
                        GetEmploymentHistory();
                    }                                     
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could not refresh the grid");
            }
        }

        public void SaveEmploymentHistory()
        {
            try
            {
                if (gridEmploymentHistory.Rows.Count > 1)
                {
                    if (ValidateEmploymentHistory())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridEmploymentHistory.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            foreach (DataGridViewRow row in gridEmploymentHistory.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["experienceID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@AnnualSalary", row.Cells["experienceAnnualSalary"].Value, DbType.Decimal);
                                        dalHelper.CreateParameter("@JobTitle", row.Cells["experienceJobTitle"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@NameOfOrganisation", row.Cells["experienceNameOfOrganisation"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["experienceFromMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["experienceFromYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["experienceToMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["experienceToYear"].Value.ToString(), DbType.String);
                                        if (row.Cells["experienceReasonForLeaving"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@ReasonForLeaving", string.Empty, DbType.String);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@ReasonForLeaving", row.Cells["experienceReasonForLeaving"].Value, DbType.String);
                                        }
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffEmploymentHistory(StaffID,StaffCode,AnnualSalary,JobTitle,NameOfOrganisation,StartMonth,StartYear,EndMonth,EndYear,ReasonForLeaving,UserID) Values (@StaffID,@StaffCode,@AnnualSalary,@JobTitle,@NameOfOrganisation,@StartMonth,@StartYear,@EndMonth,@EndYear,@ReasonForLeaving,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@ID", row.Cells["experienceID"].Value, DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@AnnualSalary", row.Cells["experienceAnnualSalary"].Value, DbType.Decimal);
                                        dalHelper.CreateParameter("@JobTitle", row.Cells["experienceJobTitle"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@NameOfOrganisation", row.Cells["experienceNameOfOrganisation"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["experienceFromMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["experienceFromYear"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["experienceToMonth"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["experienceToYear"].Value.ToString(), DbType.String);
                                        if (row.Cells["experienceReasonForLeaving"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@ReasonForLeaving", string.Empty, DbType.String);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@ReasonForLeaving", row.Cells["experienceReasonForLeaving"].Value, DbType.String);
                                        }
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Update StaffEmploymentHistory set StaffID=@StaffID,StaffCode=@StaffCode,AnnualSalary=@AnnualSalary,JobTitle=@JobTitle,NameOfOrganisation=@NameOfOrganisation,StartMonth=@StartMonth,StartYear=@StartYear,EndMonth=@EndMonth,EndYear=@EndYear,ReasonForLeaving=@ReasonForLeaving,UserID=@UserID where StaffID=@StaffID and ID=@ID");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
     
        private bool ValidateProffessionHistory()
        {
            bool result = true;
            try
            {
                professionErrorProvider.Clear();
                foreach (DataGridViewRow row in gridProfession.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["professionNameOfProfession"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the profession on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionNameOfProfession"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the name of the profession on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionFromMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionFromMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionFromYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionFromYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the start year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionToMonth"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionToMonth"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end month on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionToYear"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please select the end year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["professionToYear"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please select the end year on row " + (row.Index + 1));
                            tabOtherDetails.SelectedTab = proffessionHistoryTabPage;
                            gridProfession.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSaveProfessionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if(ValidateProffessionHistory())
                    {
                        try
                        {
                            SaveProfessionHistory();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Not save successfully");
                        }
                        GetProfessionHistory();
                    }                 
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could not refresh the grid");
            }
        }

        private void SaveProfessionHistory()
        {
            try
            {
                if (gridProfession.Rows.Count > 1)
                {
                    if (ValidateProffessionHistory())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridProfession.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            foreach (DataGridViewRow row in gridProfession.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["professionID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", staffIDTextBox.Text.Trim(), DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@NameOfProfession", row.Cells["professionNameOfProfession"].Value, DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["professionFromMonth"].Value, DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["professionFromYear"].Value, DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["professionToMonth"].Value, DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["professionToYear"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.ExecuteNonQuery("Insert Into StaffProfessionHistory(StaffID,StaffCode,NameOfProfession,StartMonth,StartYear,EndMonth,EndYear,UserID) Values (@StaffID,@StaffCode,@NameOfProfession,@StartMonth,@StartYear,@EndMonth,@EndYear,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@ID", row.Cells["professionID"].Value, DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", staffIDTextBox.Text.Trim(), DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@NameOfProfession", row.Cells["professionNameOfProfession"].Value, DbType.String);
                                        dalHelper.CreateParameter("@StartMonth", row.Cells["professionFromMonth"].Value, DbType.String);
                                        dalHelper.CreateParameter("@StartYear", row.Cells["professionFromYear"].Value, DbType.String);
                                        dalHelper.CreateParameter("@EndMonth", row.Cells["professionToMonth"].Value, DbType.String);
                                        dalHelper.CreateParameter("@EndYear", row.Cells["professionToYear"].Value, DbType.String);
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@Archived", "False", DbType.String);
                                        dalHelper.ExecuteNonQuery("Update StaffProfessionHistory set StaffID=@StaffID,StaffCode=@StaffCode,NameOfProfession=@NameOfProfession,StartMonth=@StartMonth,StartYear=@StartYear,EndMonth=@EndMonth,EndYear=@EndYear,UserID=@UserID where StaffID=@StaffID and ID=@ID and Archived=@Archived");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateReferees()
        {
            bool result = true;
            try
            {
                refereesErrorProvider.Clear();
                foreach (DataGridViewRow row in gridRefrees.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["refereesName"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's name" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["refereesName"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's name" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["refereesAddress"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's address" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["refereesAddress"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's address" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["refereesOccupation"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's occupation" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["refereesOccupation"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's occupation" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        if (row.Cells["refereesTelNo"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's TelNo" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["refereesTelNo"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Please enter the referee's TelNo" + (row.Index + 1));
                            tabOtherDetails.SelectedTab = refereeTabPage;
                            gridRefrees.Rows[row.Index + 1].Selected = true;
                        }
                        //else if (row.Cells["refereesTelNo"].Value.ToString().Trim() != string.Empty && !Validator.DecimalValidator(row.Cells["refereesTelNo"].Value.ToString().Trim()))
                        //{
                        //    result = false;
                        //    MessageBox.Show("TelNo is should be integer" + (row.Index + 1));
                        //    tabOtherDetails.SelectedTab = refereeTabPage;
                        //    gridRefrees.Rows[row.Index + 1].Selected = true;
                        //}
                        if (row.Cells["refereesEmail"].Value != null)
                        {
                            if (row.Cells["refereesEmail"].Value.ToString().Trim() != string.Empty && !Validator.EmailValidator(row.Cells["refereesEmail"].Value.ToString().Trim()))
                            {
                                result = false;
                                MessageBox.Show("Email address is invalid" + (row.Index + 1));
                                tabOtherDetails.SelectedTab = refereeTabPage;
                                gridRefrees.Rows[row.Index + 1].Selected = true;
                            }
                        }
                        
                    }
                }
                allowedToSaveAll = result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSaveRefrees_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if (ValidateReferees())
                    {
                        try
                        {
                            SaveReferee();
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            MessageBox.Show("ERROR:Not save successfully,Please See The System Administrator");
                        }
                        GetRefrees();
                    }
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could not refresh the grid");
            }
        }

        private void SaveReferee()
        {
            try
            {
                if (gridRefrees.Rows.Count > 1)
                {
                    if (ValidateReferees())
                    {
                        employee.StaffID = staffIDTextBox.Text.Trim();
                        employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            gridRefrees.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            foreach (DataGridViewRow row in gridRefrees.Rows)
                            {
                                //If data is entered in the grid
                                if (!row.IsNewRow)
                                {
                                    if (row.Cells["refereesID"].Value == null)
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@Name", row.Cells["refereesName"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Address", row.Cells["refereesAddress"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Occupation", row.Cells["refereesOccupation"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@TelNo", row.Cells["refereesTelNo"].Value.ToString(), DbType.String);
                                        if (row.Cells["refereesEmail"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@Email", string.Empty, DbType.String);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@Email", row.Cells["refereesEmail"].Value.ToString(), DbType.String);
                                        }

                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                                        dalHelper.ExecuteNonQuery("Insert Into StaffReferees(StaffID,StaffCode,Name,Address,TelNo,Email,Occupation,UserID) Values (@StaffID,@StaffCode,@Name,@Address,@TelNo,@Email,@Occupation,@UserID)");
                                    }
                                    else
                                    {
                                        dalHelper.ClearParameters();
                                        dalHelper.CreateParameter("@ID", row.Cells["refereesID"].Value, DbType.Int32);
                                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                                        dalHelper.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@Name", row.Cells["refereesName"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Address", row.Cells["refereesAddress"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@Occupation", row.Cells["refereesOccupation"].Value.ToString(), DbType.String);
                                        dalHelper.CreateParameter("@TelNo", row.Cells["refereesTelNo"].Value.ToString(), DbType.String);
                                        if (row.Cells["refereesEmail"].Value == null)
                                        {
                                            dalHelper.CreateParameter("@Email", string.Empty, DbType.String);
                                        }
                                        else
                                        {
                                            dalHelper.CreateParameter("@Email", row.Cells["refereesEmail"].Value.ToString(), DbType.String);
                                        }
                                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                                        dalHelper.CreateParameter("@Archived", false, DbType.Boolean);

                                        dalHelper.ExecuteNonQuery("Update StaffReferees set StaffID=@StaffID,StaffCode=@StaffCode,Name=@Name,Address=@Address,TelNo=@TelNo,Email=@Email,Occupation=@Occupation,UserID=@UserID where StaffID=@StaffID and ID=@ID and Archived=@Archived");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnDocumentsClear_Click(object sender, EventArgs e)
        {
            try
            {
                gridDocuments.Rows.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void btnSaveWorkPermits_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    SaveOthers();
                }
                else
                {
                    MessageBox.Show("Please save employee's personal info first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SaveOthers()
        {
            try
            {
                if (ValidateWorkPermit() && ValidateVisa() && ValidatePassport())
                {
                    employee.StaffID = staffIDTextBox.Text.Trim();
                    employee = dal.LazyLoadUnconfirmedByStaffID<Employee>(employee);
                    dalHelper.ClearParameters();

                    //Work Permit    
                    if (cmbWorkPermit.Text.Trim() == "Yes")
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                        dalHelper.CreateParameter("@Duration", txtDuration.Text, DbType.String);
                        dalHelper.CreateParameter("@Notes", txtWorkPermitNotes.Text, DbType.String);
                        if (dateWorkPermit.Value != null)
                        {
                            dalHelper.CreateParameter("@ExpiryDate", dateWorkPermit.Value, DbType.DateTime);
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ExpiryDate", DBNull.Value, DbType.DateTime);
                        }
                        dalHelper.CreateParameter("@HasPermit", cmbWorkPermit.Text, DbType.String);
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dalHelper.CreateParameter("@WorkPermitID", txtWorkPermitID.Text, DbType.String);
                        if (int.Parse(dalHelper.ExecuteScalar("Select Count(ID) From StaffWorkPermit Where StaffID=@StaffID").ToString()) == 0)
                        {
                            dalHelper.ExecuteNonQuery("Insert Into StaffWorkPermit(StaffID,StaffCode,WorkPermitID,Duration,Notes,ExpiryDate,HasPermit,UserID) Values(@StaffID,@StaffCode,@WorkPermitID,@Duration,@Notes,@ExpiryDate,@HasPermit,@UserID)");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ID", workPermitID, DbType.Int32);
                            dalHelper.ExecuteNonQuery("Update StaffWorkPermit Set StaffID=@StaffID,StaffCode=@StaffCode,WorkPermitID=@WorkPermitID,Duration=@Duration,Notes=@Notes,ExpiryDate=@ExpiryDate,HasPermit=@HasPermit,UserID=@UserID Where ID =@ID");
                        }
                    }

                    //Visa
                    if (checkBoxHasVisa.Checked == true)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                        dalHelper.CreateParameter("@VisaNo", txtVisaNo.Text, DbType.String);
                        if (dateWorkPermit.Value != null)
                        {
                            dalHelper.CreateParameter("@ExpiryDate", dateTo.Value, DbType.DateTime);
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ExpiryDate", DBNull.Value, DbType.DateTime);
                        }
                        
                        dalHelper.CreateParameter("@Notes", txtVisaNotes.Text, DbType.String);
                        dalHelper.CreateParameter("@ValidFrom", dateFrom.Value, DbType.DateTime);
                        dalHelper.CreateParameter("@VisaType", cmbVisaType.Text, DbType.String);
                        dalHelper.CreateParameter("@HasVisa", checkBoxHasVisa.Checked, DbType.Boolean);
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                        if (int.Parse(dalHelper.ExecuteScalar("Select Count(ID) From StaffVisa Where StaffID=@StaffID").ToString()) == 0)
                        {
                            dalHelper.ExecuteNonQuery("Insert Into StaffVisa(StaffID,StaffCode,VisaNo,ExpiryDate,Notes,ValidFrom,VisaType,HasVisa,UserID) Values(@StaffID,@StaffCode,@VisaNo,@ExpiryDate,@Notes,@ValidFrom,@VisaType,@HasVisa,@UserID)");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ID", employee.Visa.ID, DbType.Int32);
                            dalHelper.ExecuteNonQuery("Update StaffVisa Set StaffID=@StaffID,StaffCode=@StaffCode,VisaNo=@VisaNo,ExpiryDate=@ExpiryDate,Notes=@Notes,ValidFrom=@ValidFrom,VisaType=@VisaType,HasVisa=@HasVisa,UserID=@UserID Where ID=@ID");
                        }
                    }

                    //Passport
                    if (checkBoxHasPassport.Checked == true)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                        dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                        dalHelper.CreateParameter("@HasPassport", checkBoxHasPassport.Checked, DbType.Boolean);
                        dalHelper.CreateParameter("@Notes", txtPassportNotes.Text, DbType.String);
                        if (dateWorkPermit.Value != null)
                        {
                            dalHelper.CreateParameter("@ExpiryDate", dateExpires.Value, DbType.DateTime);
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ExpiryDate", DBNull.Value, DbType.DateTime);
                        }
                        
                        dalHelper.CreateParameter("@IssueDate", dateIssued.Value, DbType.DateTime);
                        dalHelper.CreateParameter("@PassportNo", txtPassportNo.Text, DbType.String);
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                        if (int.Parse(dalHelper.ExecuteScalar("Select Count(ID) From StaffPassport Where StaffID=@StaffID").ToString()) == 0)
                        {
                            dalHelper.ExecuteNonQuery("Insert Into StaffPassport(StaffID,StaffCode,Notes,ExpiryDate,HasPassport,IssueDate,PassportNo,UserID) Values(@StaffID,@StaffCode,@Notes,@ExpiryDate,@HasPassport,@IssueDate,@PassportNo,@UserID)");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ID", employee.Passport.ID, DbType.Int32);
                            dalHelper.ExecuteNonQuery("Update StaffPassport Set StaffID=@StaffID,StaffCode=@StaffCode,Notes=@Notes,HasPassport=@HasPassport,ExpiryDate=@ExpiryDate,IssueDate=@IssueDate,PassportNo=@PassportNo,UserID=@UserID where ID=@ID");
                        }
                    }

                    //Social History
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dalHelper.CreateParameter("@StaffCode", employee.ID.ToString(), DbType.String);
                    dalHelper.CreateParameter("@PhysicalDisability", cmbDisabled.Text, DbType.String);
                    dalHelper.CreateParameter("@AppliedBefore", cmbApplied.Text, DbType.String);
                    dalHelper.CreateParameter("@Bonded", cmbBonded.Text, DbType.String);
                    dalHelper.CreateParameter("@Convicted", cmbConvicted.Text, DbType.String);
                    dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                    if (int.Parse(dalHelper.ExecuteScalar("Select Count(ID) From StaffSocialHistory Where StaffID=@StaffID").ToString()) == 0)
                    {
                        dalHelper.ExecuteNonQuery("Insert Into StaffSocialHistory(StaffID,StaffCode,PhysicalDisability,AppliedBefore,Bonded,Convicted,UserID) Values(@StaffID,@StaffCode,@PhysicalDisability,@AppliedBefore,@Bonded,@Convicted,@UserID)");
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ID", employee.SocialHistory.ID, DbType.Int32);
                        dalHelper.ExecuteNonQuery("Update StaffSocialHistory Set StaffID=@StaffID,StaffCode=@StaffCode,PhysicalDisability=@PhysicalDisability,AppliedBefore=@AppliedBefore,Bonded=@Bonded,Convicted=@Convicted,UserID=@UserID Where ID=@ID");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnDocumentsScan_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Please connect a scanner first", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ClearAll()
        {
            try
            {
                ClearPersonalInfo();
                //Details

                gridRelations.Rows.Clear();
                gridLanguage.Rows.Clear();
                gridProfession.Rows.Clear();
                gridEmploymentHistory.Rows.Clear();
                gridEducationHistory.Rows.Clear();
                gridDocuments.Rows.Clear();
                gridRefrees.Rows.Clear();

                employee.ID = 0;
                empID = string.Empty;

                ClearOthers();
                docGroupErrorProvider.Clear();
                staffErrorProvider.Clear();
                fingerPrintErrorProvider.Clear();
                relationsErrorProvider.Clear();
                employmentErrorProvider.Clear();
                professionErrorProvider.Clear();
                educationErrorProvider.Clear();
                refereesErrorProvider.Clear();
                userGroupBox.Enabled = true;
                editMode = false;
                surnameTextBox.Select();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (employee.ID != 0)
                {
                    if (GlobalData.QuestionMessage("Are you sure you want to remove the " + txtFirstName.Text + " " + surnameTextBox.Text + "'s Information from the system?") == DialogResult.Yes)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.BeginTransaction();                       
                        dalHelper.CreateParameter("@Archived", "True", DbType.String);
                        dalHelper.CreateParameter("@AccountBlocked", "True", DbType.String);
                        dalHelper.ExecuteNonQuery("Update StaffPersonalInfo Set Archived = @Archived Where ID =" + employee.ID);
                        dalHelper.ExecuteNonQuery("Update Users Set AccountBlocked = @AccountBlocked Where EmpID = " + employee.ID);
                        dalHelper.CommitTransaction();
                        ClearAll();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dalHelper.RollBackTransaction();
            }
        }

        private void clearPersonalInfo_Click(object sender, EventArgs e)
        {
            try
            {
                ClearPersonalInfo();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearProfessionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                ClearProfessionHistory();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboEmploymentStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                staffStatuses = dal.GetAll<StaffStatus>();
                cboEmploymentStatus.Items.Clear();
                cboEmploymentStatus.Text = string.Empty;
                foreach (StaffStatus staffStatus in staffStatuses)
                {
                    cboEmploymentStatus.Items.Add(staffStatus.Description);
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbSex_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();                
                dalHelper.CreateParameter("@Description", cmbSex.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                dalHelper.CreateParameter("@All", "All", DbType.StringFixedLength);
                titlesTable = dalHelper.ExecuteReader("Select Titles.ID as ID,Titles.Description as Description from Titles Inner Join GenderGroups On GenderGroups.ID = Titles.GenderGroupID Where Titles.Archived = @Archived and Titles.Active = @Active and GenderGroups.Description=@Description or GenderGroups.Description=@All Order by Titles.Description asc");
                cmbTitle.Items.Clear();
                foreach (DataRow row in titlesTable.Rows)
                {
                    cmbTitle.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                cboStep.Items.Clear();
                gradeComboBox.Items.Clear();
                dalHelper.CreateParameter("@GradeCategory", gradeCategoryComboBox.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                gradesTable = dalHelper.ExecuteReader("select * from EmployeeGradeView where EmployeeGradeView.GradeCategory=@GradeCategory and EmployeeGradeView.Archived=@Archived and EmployeeGradeView.Active=@Active Order By EmployeeGradeView.Description ASC");
                
                foreach (DataRow row in gradesTable.Rows)
                {
                    gradeComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboContactHomeTown_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                contactHomeTownsTable = dalHelper.ExecuteReader("select Towns.ID as ID,Towns.Description as Description From Towns WHERE Towns.Archived=@Archived and Towns.Active=@Active ORDER BY Towns.Description ASC");
                cboContactHomeTown.Items.Clear();
                foreach (DataRow row in contactHomeTownsTable.Rows)
                {
                    cboContactHomeTown.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBirthCountry_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();               
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                birthCountriesTable = dalHelper.ExecuteReader("SELECT Countries.ID as ID,Countries.Description as Description from Countries where Countries.Archived=@Archived and Countries.Active=@Active order by Countries.Description asc");
                cboBirthCountry.Items.Clear();
                foreach (DataRow row in birthCountriesTable.Rows)
                {
                    cboBirthCountry.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBirthDistrict_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();                
                dalHelper.CreateParameter("@Description", cboBirthDistrict.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                birthPlacesTable = dalHelper.ExecuteReader("select TownView.ID as ID,TownView.Description as Description From TownView WHERE TownView.Archived=@Archived and TownView.Active=@Active and TownView.District=@Description order BY TownView.Description ASC");
                cmbPOB.Items.Clear();
                foreach (DataRow row in birthPlacesTable.Rows)
                {
                    cmbPOB.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboContactRegion_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();               
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                contactRegionsTable = dalHelper.ExecuteReader("select RegionView.ID,RegionView.Description from RegionView where RegionView.Archived=@Archived and RegionView.Active=@Active order BY RegionView.Description ASC");
                cboContactRegion.Items.Clear();
                foreach (DataRow row in contactRegionsTable.Rows)
                {
                    cboContactRegion.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboResidentialRegion_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                residentialRegionsTable = dalHelper.ExecuteReader("select RegionView.ID,RegionView.Description from RegionView where RegionView.Archived=@Archived and RegionView.Active=@Active order BY RegionView.Description ASC");
                cboResidentialRegion.Items.Clear();
                foreach (DataRow row in residentialRegionsTable.Rows)
                {
                    cboResidentialRegion.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboContactRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Description", cboContactRegion.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                contactTownsTable = dalHelper.ExecuteReader("select TownView.ID as ID,TownView.Description as Description From TownView where TownView.Archived=@Archived and TownView.Active=@Active and TownView.Region=@Description order BY TownView.Description ASC");
                cboContactCity.Items.Clear();
                foreach (DataRow row in contactTownsTable.Rows)
                {
                    cboContactCity.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboResidentialRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();               
                dalHelper.CreateParameter("@Description", cboResidentialRegion.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                residentialTownsTable = dalHelper.ExecuteReader("select TownView.ID as ID,TownView.Description as Description From TownView where TownView.Archived=@Archived and TownView.Active=@Active and TownView.Region=@Description order BY TownView.Description ASC");
                cboResidentialCity.Items.Clear();
                foreach (DataRow row in residentialTownsTable.Rows)
                {
                    cboResidentialCity.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboStep_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                stepsTable = dalHelper.ExecuteReader("Select * from StepView Where Archived = @Archived and Active=@Active order by ID asc");
                cboStep.Items.Clear();
                foreach (DataRow row in stepsTable.Rows)
                {
                    cboStep.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboProbationStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                probationStatusesTable = dalHelper.ExecuteReader("Select * from ProbationStatus Where Archived = @Archived and Active=@Active order by Description asc");
                cboProbationStatus.Items.Clear();
                foreach (DataRow row in probationStatusesTable.Rows)
                {
                    cboProbationStatus.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBankDetailAccountType_DropDown(object sender, EventArgs e)
        {
            try
            {
                accountTypes = dal.GetAll<AccountType>();
                cboBankDetailAccountType.Items.Clear();
                cboBankDetailAccountType.Text = string.Empty;
                foreach (AccountType accountType in accountTypes)
                {
                    cboBankDetailAccountType.Items.Add(accountType.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboBankDetailName_DropDown(object sender, EventArgs e)
        {
            try
            {
                banks = dal.GetAll<Bank>();
                cboBankDetailName.Items.Clear();
                cboBankDetailName.Text = string.Empty;
                foreach (Bank bank in banks)
                {
                    cboBankDetailName.Items.Add(bank.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboBankDetailName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "BankView.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboBankDetailName.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                bankBranches = dal.GetByCriteria<BankBranch>(query);
                cboBankDetailBranch.Items.Clear();
                cboBankDetailBranch.Text = string.Empty;
                foreach (BankBranch bankBranch in bankBranches)
                {
                    cboBankDetailBranch.Items.Add(bankBranch.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboEngagementGradeOn_DropDown(object sender, EventArgs e)
        {
            try
            {
                dal.OpenConnection();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                engagementGradesOnTable = dalHelper.ExecuteReader("Select * from EmployeeGrades_Setup Where Archived = @Archived and Active=@Active order by Description asc");
                cboEngagementGradeOn.Items.Clear();
                foreach (DataRow row in engagementGradesOnTable.Rows)
                {
                    cboEngagementGradeOn.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboEngagementGradeLeaving_DropDown(object sender, EventArgs e)
        {
            try
            {
                dal.OpenConnection();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                engagementGradesLeavingTable = dalHelper.ExecuteReader("Select * from EmployeeGrades_Setup Where Archived = @Archived and Active=@Active order by Description asc");
                cboEngagementGradeLeaving.Items.Clear();
                foreach (DataRow row in engagementGradesLeavingTable.Rows)
                {
                    cboEngagementGradeLeaving.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboEngagementType_DropDown(object sender, EventArgs e)
        {
            try
            {
                dal.OpenConnection();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                engagementTypesTable = dalHelper.ExecuteReader("Select * from EngagementTypes Where Archived = @Archived and Active=@Active order by Description asc");
                cboEngagementType.Items.Clear();
                foreach (DataRow row in engagementTypesTable.Rows)
                {
                    cboEngagementType.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboAppointmentType_DropDown(object sender, EventArgs e)
        {
            try
            {
                appointmentTypes = dal.GetAll<AppointmentType>();
                cboAppointmentType.Items.Clear();
                cboAppointmentType.Text = string.Empty;
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    cboAppointmentType.Items.Add(appointmentType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboJobTitle_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                jobTitlesTable = dalHelper.ExecuteReader("Select * from StaffJobTitle Where Archived = @Archived and Active=@Active order by Description asc");
                cboJobTitle.Items.Clear();
                foreach (DataRow row in jobTitlesTable.Rows)
                {
                    cboJobTitle.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void departmentComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();                
                dalHelper.CreateParameter("@Description", departmentComboBox.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                unitsTable = dalHelper.ExecuteReader("select * from UnitView where UnitView.Archived=@Archived and UnitView.Active=@Active and UnitView.Department=@Description order BY UnitView.Description ASC");
                cboUnit.Items.Clear();
                foreach (DataRow row in unitsTable.Rows)
                {
                    cboUnit.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboSpecialty_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                specialtiesTable = dalHelper.ExecuteReader("Select * from SpecialtyView Where SpecialtyView.Archived = @Archived and SpecialtyView.Active=@Active order by SpecialtyView.Description asc");
                cboSpecialty.Items.Clear();
                foreach (DataRow row in specialtiesTable.Rows)
                {
                    cboSpecialty.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboOccupationGrp_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                occupationGrpsTable = dalHelper.ExecuteReader("Select * from OccupationGroupView Where OccupationGroupView.Archived = @Archived and OccupationGroupView.Active=@Active order by OccupationGroupView.Description asc");
                cboOccupationGrp.Items.Clear();
                foreach (DataRow row in occupationGrpsTable.Rows)
                {
                    cboOccupationGrp.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBand_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                bandsTable = dalHelper.ExecuteReader("Select * from BandView Where BandView.Archived = @Archived and BandView.Active=@Active order by BandView.Description asc");
                cboBand.Items.Clear();
                foreach (DataRow row in bandsTable.Rows)
                {
                    cboBand.Items.Add(row["Description"].ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbReligion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                
                dalHelper.CreateParameter("@Description", cmbReligion.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                denominationsTable = dalHelper.ExecuteReader("select * From DenominationView where DenominationView.Archived=@Archived and DenominationView.Active=@Active and DenominationView.Religion=@Description order BY DenominationView.Description ASC");
                cboDenomination.Items.Clear();
                foreach (DataRow row in denominationsTable.Rows)
                {
                    cboDenomination.Items.Add(row["Description"].ToString());
                }               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbMaritalStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbMaritalStatus.Text.ToString() == "Married")
                {
                    lblDOM.Visible = true;
                    dateDOM.Visible = true;
                }
                else
                {
                    lblDOM.Visible = false;
                    dateDOM.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtContactTelephone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            try
            {
                if (txtContactTelephone.Text.Trim().Replace("-", "").Trim() != string.Empty)
                {
                    MessageBox.Show("Error: The Telephone Number is truncated because is greater than 10");
                    txtContactTelephone.ResetText();
                    txtContactTelephone.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtContactTelephone_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {
            try
            {
                if (txtContactTelephone.Text.Trim().Replace("-", "").Trim() != string.Empty)
                {
                    MessageBox.Show("Validated: " + e.ReturnValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            try
            {
                age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return age;
        }

        private void gridRelations_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnFamilyDetailsRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridRelations.CurrentRow != null && !gridRelations.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Family Details:\n" , GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        relation.ID = int.Parse(gridRelations.CurrentRow.Cells["relationID"].Value.ToString());
                        relation.Archived = true;
                        dependentsMapper.Delete(relation);
                        gridRelations.Rows.RemoveAt(gridRelations.Rows.IndexOf(gridRelations.CurrentRow));
                        gridRelations.Refresh();
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnLanguageRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridLanguage.CurrentRow != null && !gridLanguage.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Languages:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        staffLanguage.ID = int.Parse(gridLanguage.CurrentRow.Cells["gridLanguageID"].Value.ToString());
                        staffLanguage.Archived = true;
                        languagesMapper.Delete(staffLanguage);
                        gridLanguage.Rows.RemoveAt(gridLanguage.Rows.IndexOf(gridLanguage.CurrentRow));
                        gridLanguage.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnProfessionHistoryRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridProfession.CurrentRow != null && !gridProfession.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Profession Details:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        professionsMapper.Delete(gridProfession.CurrentRow.Cells["professionID"].Value.ToString());
                        gridProfession.Rows.RemoveAt(gridProfession.Rows.IndexOf(gridProfession.CurrentRow));
                        gridProfession.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnEmploymentHistoryRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridEmploymentHistory.CurrentRow != null && !gridEmploymentHistory.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Work experiences:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        experiencesMapper.Delete(gridEmploymentHistory.CurrentRow.Cells["experienceID"].Value.ToString());
                        gridEmploymentHistory.Rows.RemoveAt(gridEmploymentHistory.Rows.IndexOf(gridEmploymentHistory.CurrentRow));
                        gridEmploymentHistory.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnEducationHistoryRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridEducationHistory.CurrentRow != null && !gridEducationHistory.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Education History:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        qualificationsMapper.Delete(gridEducationHistory.CurrentRow.Cells["qualificationsID"].Value.ToString());
                        gridEducationHistory.Rows.RemoveAt(gridEducationHistory.Rows.IndexOf(gridEducationHistory.CurrentRow));
                        gridEducationHistory.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnDocumentsRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridDocuments.CurrentRow != null && !gridDocuments.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Documents:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        documentsMapper.Delete(gridDocuments.CurrentRow.Cells["gridDocumentsID"].Value.ToString());
                        gridDocuments.Rows.RemoveAt(gridDocuments.Rows.IndexOf(gridDocuments.CurrentRow));
                        gridDocuments.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void btnRefreeRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridRefrees.CurrentRow != null && !gridRefrees.CurrentRow.IsNewRow)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. Referees:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        referee.ID = int.Parse(gridRefrees.CurrentRow.Cells["refereesID"].Value.ToString());
                        referee.Archived = true;
                        refreesMapper.Delete(referee);
                        gridRefrees.Rows.RemoveAt(gridRefrees.Rows.IndexOf(gridRefrees.CurrentRow));
                        gridRefrees.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Remove The Record,Please See the System Administrator");
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                zones = dal.GetAll<Zone>();
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void calculatedOnComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                calculatedOnComboBox.Items.Clear();
                try
                {
                    salaryTypes = salaryTypesDal.GetAll();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
                foreach (SalaryType salary in salaryTypes)
                {
                    calculatedOnComboBox.Items.Add(salary.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void susuPlusContributionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (susuPlusContributionCheckBox.Checked)
                {
                    susuPlusContributionAmountTextBox.Visible = true;
                }
                else
                {
                    susuPlusContributionAmountTextBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void withholdingTaxCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (withholdingTaxCheckBox.Checked)
                {
                    withholdingTaxFixedAmountRadioButton.Visible = true;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = true;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
                else
                {
                    withholdingTaxFixedAmountRadioButton.Visible = false;
                    withholdingTaxFixedAmountRadioButton.Checked = false;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = false;
                    withholdingTaxRateRadioButton.Checked = false;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void withholdingTaxFixedAmountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (withholdingTaxCheckBox.Checked && withholdingTaxFixedAmountRadioButton.Checked)
                {
                    withholdingTaxFixedAmountTextBox.Visible = true;
                    withholdingTaxRateRadioButton.Visible = true;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
                else if (withholdingTaxCheckBox.Checked && withholdingTaxFixedAmountRadioButton.Checked == false)
                {
                    withholdingTaxFixedAmountRadioButton.Visible = true;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = true;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
                else
                {
                    withholdingTaxFixedAmountRadioButton.Visible = false;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = false;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void withholdingTaxRateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (withholdingTaxCheckBox.Checked && withholdingTaxRateRadioButton.Checked)
                {
                    withholdingTaxFixedAmountRadioButton.Visible = true;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = true;
                    labelRate.Visible = true;
                    withholdingTaxRateNumericUpDown.Visible = true;
                    labelCalculateOn.Visible = true;
                    calculatedOnComboBox.Visible = true;
                }
                else if (withholdingTaxCheckBox.Checked && withholdingTaxRateRadioButton.Checked == false)
                {
                    withholdingTaxFixedAmountRadioButton.Visible = true;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = true;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
                else
                {
                    withholdingTaxFixedAmountRadioButton.Visible = false;
                    withholdingTaxFixedAmountTextBox.Visible = false;
                    withholdingTaxRateRadioButton.Visible = false;
                    labelRate.Visible = false;
                    withholdingTaxRateNumericUpDown.Visible = false;
                    labelCalculateOn.Visible = false;
                    calculatedOnComboBox.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.company = dal.GetAll<Company>()[0];
                if (company.OwnershipType.ID == 2)
                {
                    if (gradeCategoryComboBox.Text.Trim() != string.Empty)
                    {
                        employee.GradeCategory.ID= gradeCategories[gradeCategoryComboBox.SelectedIndex].ID;
                    }
                    else
                    {
                        employee.GradeCategory.ID = 0;
                    }
                    if (cboStep.Text.Trim() != string.Empty)
                    {
                        employee.Step.ID = int.Parse(stepsTable.Rows[cboStep.SelectedIndex]["ID"].ToString());
                    }
                    else
                    {
                        employee.Step.ID=0;
                    }
                    if (gradeComboBox.Text.Trim() != string.Empty)
                    {
                        employee.Grade.ID = int.Parse(gradesTable.Rows[gradeComboBox.SelectedIndex]["ID"].ToString());
                    }
                    else
                    {
                        employee.Grade.ID = 0;
                    }
                    singleSpine = dal.GetSalaryAmount<SingleSpine>(employee.GradeCategory.ID, employee.Grade.ID, employee.Step.ID);
                    txtSalary.Text = singleSpine.BasicSalary.ToString();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cboStep.Items.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtFileNumber_DropDown(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "FileNumberView.InUse",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                fileNumbers = dal.GetByCriteria<FileNumber>(query);
                txtFileNumber.Items.Clear();
                txtFileNumber.Text = string.Empty;
                if (employee.FileNumber.Description != null && employee.FileNumber.Description != string.Empty)
                {
                    txtFileNumber.Items.Add(employee.FileNumber.Description);                 
                }
                foreach (FileNumber fileNo in fileNumbers)
                {
                    txtFileNumber.Items.Add(fileNo.Description);
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetDependents()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridRelations.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffOtherRelativeView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                dependents = dal.GetByCriteria<Relation>(query);
                if (dependents.Count > 0)
                {
                    relationOccupation.Items.Clear();
                    occupations = dal.GetAll<Occupation>();
                    foreach (Occupation occupation in occupations)
                    {
                        relationOccupation.Items.Add(occupation.Description);
                    }
                    relationRelationship.Items.Clear();
                    relationships = dal.GetAll<Relationship>();
                    foreach (Relationship relationship in relationships)
                    {
                        relationRelationship.Items.Add(relationship.Description);
                    }
                    relationPOB.Items.Clear();
                    towns = dal.GetAll<Town>();
                    foreach (Town town in towns)
                    {
                        relationPOB.Items.Add(town.Description);
                    }
                    foreach (Relation relation in dependents)
                    {
                        gridRelations.Rows.Add(1);
                        gridRelations.Rows[ctr].Cells["relationName"].Value = relation.Name;
                        gridRelations.Rows[ctr].Cells["relationID"].Value = relation.ID;
                        gridRelations.Rows[ctr].Cells["relationOccupation"].Value = relation.Occupation.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationOccupationID"].Value = relation.Occupation.ID;
                        gridRelations.Rows[ctr].Cells["relationRelationship"].Value = relation.Relationship.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationType"].Value = relation.Type.ToString();
                        gridRelations.Rows[ctr].Cells["relationRelationshipID"].Value = relation.Relationship.ID;
                        gridRelations.Rows[ctr].Cells["relationPOB"].Value = relation.POB.Description.ToString();
                        gridRelations.Rows[ctr].Cells["relationPOBID"].Value = relation.POB.ID;
                        gridRelations.Rows[ctr].Cells["relationDOB"].Value = relation.DOB.ToString();
                        gridRelations.Rows[ctr].Cells["relationTelephone"].Value = relation.Telephone;
                        gridRelations.Rows[ctr].Cells["relationAddress"].Value = relation.Address;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshRelations_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetDependents();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetStaffLanguages()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridLanguage.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffLanguageView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                staffLanguages = dal.GetByCriteria<StaffLanguage>(query);
                if (staffLanguages.Count > 0)
                {
                    colLanguage.Items.Clear();
                    languages = dal.GetAll<Language>();
                    foreach (Language language in languages)
                    {
                        colLanguage.Items.Add(language.Description);
                    }
                    foreach (StaffLanguage staffLanguage in staffLanguages)
                    {
                        gridLanguage.Rows.Add(1);
                        gridLanguage.Rows[ctr].Cells["gridLanguageID"].Value = staffLanguage.ID;
                        gridLanguage.Rows[ctr].Cells["colLanguage"].Value = staffLanguage.Language.Description;
                        gridLanguage.Rows[ctr].Cells["colLanguageLevel"].Value = staffLanguage.LanguageLevel;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshLanguages_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetStaffLanguages();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void GetProfessionHistory()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridProfession.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffProfessionHistoryView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                professions = dal.GetByCriteria<Profession>(query);
                if (professions.Count > 0)
                {
                    foreach (Profession profession in professions)
                    {
                        gridProfession.Rows.Add(1);
                        gridProfession.Rows[ctr].Cells["professionID"].Value = profession.ID;
                        gridProfession.Rows[ctr].Cells["professionNameOfProfession"].Value = profession.NameOfProfession;
                        gridProfession.Rows[ctr].Cells["professionFromYear"].Value = profession.FromYear;
                        gridProfession.Rows[ctr].Cells["professionFromMonth"].Value = profession.FromMonth;
                        gridProfession.Rows[ctr].Cells["professionToMonth"].Value = profession.ToMonth;
                        gridProfession.Rows[ctr].Cells["professionToYear"].Value = profession.ToYear;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshProfessionHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetProfessionHistory();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetEmploymentHistory()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridEmploymentHistory.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffEmploymentHistoryView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                experiences = dal.GetByCriteria<WorkExperience>(query);
                if (experiences.Count > 0)
                {
                    foreach (WorkExperience experience in experiences)
                    {
                        gridEmploymentHistory.Rows.Add(1);
                        gridEmploymentHistory.Rows[ctr].Cells["experienceID"].Value = experience.ID;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromMonth"].Value = experience.FromMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToMonth"].Value = experience.ToMonth;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceFromYear"].Value = experience.FromYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceToYear"].Value = experience.ToYear;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceAnnualSalary"].Value = experience.AnnualSalary;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceReasonForLeaving"].Value = experience.ReasonForLeaving;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceNameOfOrganisation"].Value = experience.NameOfOrganisation;
                        gridEmploymentHistory.Rows[ctr].Cells["experienceJobTitle"].Value = experience.JobTitle;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private void btnRefreshEmploymentHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetEmploymentHistory();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetEducationHistory()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridEducationHistory.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffEducationHistoryView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                qualifications = dal.GetByCriteria<Qualification>(query);
                if (qualifications.Count > 0)
                {
                    foreach (Qualification qualification in qualifications)
                    {
                        gridEducationHistory.Rows.Add(1);
                        gridEducationHistory.Rows[ctr].Cells["qualificationsID"].Value = qualification.ID;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsCertificateObtained"].Value = qualification.CertificateObtained;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsNameOfInstitution"].Value = qualification.NameOfInstitution;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromMonth"].Value = qualification.FromMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToMonth"].Value = qualification.ToMonth;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsFromYear"].Value = qualification.FromYear;
                        gridEducationHistory.Rows[ctr].Cells["qualificationsToYear"].Value = qualification.ToYear;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshEducationHistory_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetEducationHistory();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetDocuments()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridDocuments.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffDocumentView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                documents = dal.GetByCriteria<StaffDocument>(query);
                if (documents.Count > 0)
                {
                    foreach (StaffDocument document in documents)
                    {
                        gridDocuments.Rows.Add(1);
                        gridDocuments.Rows[ctr].Cells["gridDocumentsID"].Value = document.ID;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDateCreated"].Value = document.DateCreated;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDescription"].Value = document.Description;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentGroup"].Value = document.DocumentGroup;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentType"].Value = document.DocumentType;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsDocumentsContent"].Value = document.DocumentContent;
                        gridDocuments.Rows[ctr].Cells["gridDocumentsPath"].Value = document.Path;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetDocuments();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetRefrees()
        {
            try
            {
                Query query = new Query();
                ctr = 0;
                gridRefrees.Rows.Clear();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffRefereeView.StaffID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = staffIDTextBox.Text.Trim(),
                    CriteriaOperator = CriteriaOperator.And
                });
                referees = dal.GetByCriteria<Referee>(query);
                if (referees.Count > 0)
                {
                    foreach (Referee referee in referees)
                    {
                        gridRefrees.Rows.Add(1);
                        gridRefrees.Rows[ctr].Cells["refereesID"].Value = referee.ID;
                        gridRefrees.Rows[ctr].Cells["refereesName"].Value = referee.Name;
                        gridRefrees.Rows[ctr].Cells["refereesAddress"].Value = referee.Address;
                        gridRefrees.Rows[ctr].Cells["refereesOccupation"].Value = referee.Occupation;
                        gridRefrees.Rows[ctr].Cells["refereesTelNo"].Value = referee.TelNo;
                        gridRefrees.Rows[ctr].Cells["refereesEmail"].Value = referee.Email;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnRefreshRefrees_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    GetRefrees();
                }
                else
                {
                    MessageBox.Show("ERROR:The Staff ID cannot be blank");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboQualificationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                qualificationTypes = dal.GetAll<QualificationType>();
                cboQualificationType.Items.Clear();
                cboQualificationType.Text = string.Empty;
                foreach (QualificationType qualificationType in qualificationTypes)
                {
                    cboQualificationType.Items.Add(qualificationType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnBirthPlaceForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (townsForm != null && townsForm.IsDisposed == false)
                {
                    townsForm.Close();
                    townsForm = null;
                }
                townsForm = new Towns();
                townsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnBirthDistrictForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (districtsForm != null && districtsForm.IsDisposed == false)
                {
                    districtsForm.Close();
                    districtsForm = null;
                }
                districtsForm = new Districts();
                districtsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDenomination_Click(object sender, EventArgs e)
        {
            try
            {
                if (denominationsForm != null && denominationsForm.IsDisposed == false)
                {
                    denominationsForm.Close();
                    denominationsForm = null;
                }
                denominationsForm = new DenominationForm();
                denominationsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBirthRegion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Description", cboBirthRegion.SelectedItem, DbType.String);
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                birthDistrictsTable = dalHelper.ExecuteReader("select DistrictView.ID as ID,DistrictView.Description as Description From DistrictView where DistrictView.Archived=@Archived and DistrictView.Active=@Active and DistrictView.Region=@Description order BY DistrictView.Description ASC");
                cboBirthDistrict.Items.Clear();
                foreach (DataRow row in birthDistrictsTable.Rows)
                {
                    cboBirthDistrict.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBirthRegion_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", "False", DbType.String);
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                birthRegionsTable = dalHelper.ExecuteReader("select RegionView.ID,RegionView.Description from RegionView where RegionView.Archived=@Archived and RegionView.Active=@Active order BY RegionView.Description ASC");
                cboBirthRegion.Items.Clear();
                foreach (DataRow row in birthRegionsTable.Rows)
                {
                    cboBirthRegion.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnQuickSearch_Click(object sender, EventArgs e)
        {
            try
            {
                QuickEmployeeSearchForm quickEmployeeSearchForm = new QuickEmployeeSearchForm(dal, this);
                quickEmployeeSearchForm.MdiParent = this.MdiParent;
                quickEmployeeSearchForm.Show();
                quickEmployeeSearchForm.BringToFront();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBankDetailBranch_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string name = txtFirstName.Text.Trim() + (txtOtherName.Text.Trim() == string.Empty ? string.Empty : " " + txtOtherName.Text.Trim()) + " " + surnameTextBox.Text.Trim();
                txtBankDetailAccountName.Text = name;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    employee.StaffID = staffIDTextBox.Text.Trim();
                    employee = dal.ShowImageByStaffID<Employee>(employee);
                    if (employee.ID != 0)
                    {
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Staff");
                        }
                    }
                    else
                    {
                        MessageBox.Show("StaffID Not Found");
                    }
                }
                else
                {
                    MessageBox.Show("StaffID is Empty,Please Enter the StaffID");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxDisability_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxDisability.Checked == true)
                {
                    groupBoxSpecialInformation.Visible = true;
                }
                else
                {
                    groupBoxSpecialInformation.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDisabilityType_DropDown(object sender, EventArgs e)
        {
            try
            {
                disabilityTypes = dal.GetAll<DisabilityType>();
                cboDisabilityType.Items.Clear();
                cboDisabilityType.Text = string.Empty;
                foreach (DisabilityType disabilityType in disabilityTypes)
                {
                    cboDisabilityType.Items.Add(disabilityType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboAppointmentType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboAppointmentType.Text.ToLower().Trim() == "contract" || cboAppointmentType.Text.ToLower().Trim() == "part time")
                {
                    grpEngagementMethod.Visible = true;
                }
                else
                {
                    grpEngagementMethod.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLicenceType_DropDown(object sender, EventArgs e)
        {
            try
            {
                licenceTypes = dal.GetAll<LicenceType>();
                cboLicenceType.Items.Clear();
                cboLicenceType.Text = string.Empty;
                foreach (LicenceType licenceType in licenceTypes)
                {
                    cboLicenceType.Items.Add(licenceType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDisabilityType_Click(object sender, EventArgs e)
        {
            try
            {
                if (disabilityTypeForm != null && disabilityTypeForm.IsDisposed == false)
                {
                    disabilityTypeForm.Close();
                    disabilityTypeForm = null;
                }
                disabilityTypeForm = new DisabilityTypeForm();
                disabilityTypeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeOnFirstAppointment_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                gradesOnFirstTable = dalHelper.ExecuteReader("select * from EmployeeGradeView where EmployeeGradeView.Archived=@Archived and EmployeeGradeView.Active=@Active Order By EmployeeGradeView.Description ASC");
                cboGradeOnFirstAppointment.Items.Clear();
                foreach (DataRow row in gradesOnFirstTable.Rows)
                {
                    cboGradeOnFirstAppointment.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboAnnualLeaveCalculator_DropDown(object sender, EventArgs e)
        {
            try
            {
                licenceTypes = dal.GetAll<LicenceType>();
                cboLicenceType.Items.Clear();
                cboLicenceType.Text = string.Empty;
                foreach (LicenceType licenceType in licenceTypes)
                {
                    cboLicenceType.Items.Add(licenceType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboSalaryGrouping_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSalaryGrouping.Items.Clear();
                cboSalaryGrouping.Items.Add("Clinical");
                cboSalaryGrouping.Items.Add("Non-Clinical");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboLeaveEntitlement_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboLeaveEntitlement.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "AnnualLeaveEntitlementView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                annualLeaveEntitlements = dal.GetByCriteria<AnnualLeaveEntitlement>(query);
                foreach (AnnualLeaveEntitlement annualLeaveEntitlement in annualLeaveEntitlements)
                {
                    cboLeaveEntitlement.Items.Add(annualLeaveEntitlement.CategoryOfPost + " " + annualLeaveEntitlement.Status + " (" + annualLeaveEntitlement.NumberOfDays + ")");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void cboRace_DropDown(object sender, EventArgs e)
        {
            try
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Active", "True", DbType.String);
                racesTable = dalHelper.ExecuteReader("select RaceView.ID,RaceView.Description from RaceView where RaceView.Active=@Active order BY RaceView.Description ASC");
                cboRace.Items.Clear();
                foreach (DataRow row in racesTable.Rows)
                {
                    cboRace.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (nametxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        int ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employeeList = dal.LazyLoadCriteria<Employee>(query);
                        foreach (Employee employee in employeeList)
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                            {
                                found = true;
                                searchGrid.Rows.Add(1);
                                searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                staffCode = employee.ID;
                                ctr++;
                            }
                        }
                        if (found)
                        {
                            if (searchGrid.RowCount == 2)
                            {
                                searchGrid.Height = searchGrid.RowCount * 24;
                            }
                            else
                            {
                                searchGrid.Height = searchGrid.RowCount * 23;
                            }
                            searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                            searchGrid.BringToFront();
                            searchGrid.Visible = true;
                        }
                        else
                        {
                            searchGrid.Visible = false;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employeeList = dal.LazyLoadCriteria<Employee>(query);
                        if (employeeList.Count > 0)
                        {
                            foreach (Employee employee in employeeList)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    staffCode = employee.ID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }


        private void ClearStaff()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                staffIDtxt.Select();
                searchGrid.Visible = false;
                staffCode = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void DOCADatePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dateEmploymentDate.Value = DOCADatePicker.Value;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void disableControls(object item,bool enable)
        {
            try
            {
                Employee employee = (Employee)item;
                enable = false;
                if (employee.Surname.Trim() != string.Empty && employee.Surname.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    surnameTextBox.Enabled = enable;
                }
                if (employee.FirstName.Trim() != string.Empty && employee.FirstName.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    txtFirstName.Enabled = enable;
                }
                if (employee.OtherName.Trim() != string.Empty && employee.OtherName.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    txtOtherName.Enabled = enable;
                }
                if (employee.GradeCategory.Description == null && employee.GradeCategory.Description != string.Empty && employee.GradeCategory.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    gradeCategoryComboBox.Enabled = enable;
                }
                if (employee.Grade.Grade.Trim() != string.Empty && employee.Grade.Grade.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    gradeComboBox.Enabled = enable;
                }
                if (employee.Department.Description.Trim() != string.Empty && employee.Department.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    departmentComboBox.Enabled = enable;
                }
                if (employee.Unit.Description.Trim() != string.Empty && employee.Unit.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    cboUnit.Enabled = enable;
                }
                if (employee.JobTitle.Description.Trim() != string.Empty && employee.JobTitle.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    cboJobTitle.Enabled = enable;
                }
                if (employee.AppointmentType.Description.Trim() != string.Empty && employee.AppointmentType.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    cboAppointmentType.Enabled = enable;
                }
                if (employee.StaffStatus.Description.Trim() != string.Empty && employee.StaffStatus.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                {
                    cboEmploymentStatus.Enabled = enable;
                }
                if (employee.DOB != null && employee.Confirmed == true)
                {
                    dateDOB.Enabled = enable;
                }
                if (employee.DOFA != null && employee.Confirmed == true)
                {
                    DOFADatePicker.Enabled = enable;
                }
                if (employee.DOCA != null && employee.Confirmed == true)
                {
                    DOCADatePicker.Enabled = enable;
                }
                if (employee.AssumptionDate != null && employee.Confirmed == true)
                {
                    assumptionDatePicker.Enabled = enable;
                }

                //Salary Details/Bank Details   
                if (employee.BasicSalary > 0 && employee.Confirmed == true)
                {
                    txtSalary.Enabled = enable;
                }

                foreach (StaffBank staffBank in employee.StaffBank)
                {
                    if (staffBank.Bank.Description.Trim() != string.Empty && staffBank.Bank.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                    {
                        cboBankDetailName.Enabled = enable;
                    }
                    if (staffBank.BankBranch.Description.Trim() != string.Empty && staffBank.BankBranch.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                    {
                        cboBankDetailBranch.Enabled = enable;
                    }
                    if (staffBank.AccountType.Description.Trim() != string.Empty && staffBank.AccountType.Description.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                    {
                        cboBankDetailAccountType.Enabled = enable;
                    }
                    if (staffBank.AccountNumber.Trim() != string.Empty && staffBank.AccountNumber.ToLower().Trim() != "not applicable" && employee.Confirmed == true)
                    {
                        txtBankDetailAccountNumber.Enabled = enable;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void enableControls(bool enable)
        {
            try
            {
                enable = true;
                surnameTextBox.Enabled = enable;
                txtFirstName.Enabled = enable;
                txtOtherName.Enabled = enable;
                gradeCategoryComboBox.Enabled = enable;
                gradeComboBox.Enabled = enable;
                departmentComboBox.Enabled = enable;
                cboUnit.Enabled = enable;
                cboJobTitle.Enabled = enable;
                cboAppointmentType.Enabled = enable;
                cboEmploymentStatus.Enabled = enable;
                dateDOB.Enabled = enable;
                DOFADatePicker.Enabled = enable;
                DOCADatePicker.Enabled = enable;
                assumptionDatePicker.Enabled = enable;
                txtSalary.Enabled = enable;
                cboBankDetailName.Enabled = enable;
                cboBankDetailBranch.Enabled = enable;
                cboBankDetailAccountType.Enabled = enable;
                txtBankDetailAccountNumber.Enabled = enable;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtOverseer.Text = unitsTable.Rows[cboUnit.SelectedIndex]["Code"].ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            frmCameraCapture c = new frmCameraCapture();
            c.ShowDialog(this);
            if (c.ImageToUse != null)
            {
                pictureBox.Image = c.ImageToUse;
            }
            c.Close();
        }

        private void isProvidentFundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isProvidentFundCheckBox.Checked)
            {
                lblPF.Visible = true;
                numericPF.Visible = true;
            }
            else
            {
                lblPF.Visible = false;
                numericPF.Visible = false;
                numericPF.Value = 0;
            }
        }
    }
}
