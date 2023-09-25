namespace eMAS.All_UIs.Staff_Information_FORMS
{
    partial class EmployeeMaintenance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            dal.CloseConnection();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMaintenance));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.closeButton = new System.Windows.Forms.Button();
            this.btnRemoveEmployee = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.docGroupErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.fingerPrintErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.staffErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.relationsErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label45 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.educationErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.employmentErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.professionErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.refereesErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.personalTabPage = new System.Windows.Forms.TabPage();
            this.tabOtherDetails = new System.Windows.Forms.TabControl();
            this.ContactTabPage = new System.Windows.Forms.TabPage();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.label97 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.txtLicenceNumber = new System.Windows.Forms.TextBox();
            this.cboLicenceType = new System.Windows.Forms.ComboBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.txtContactMobileNumber = new System.Windows.Forms.MaskedTextBox();
            this.txtContactTelephone = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboContactHomeTown = new System.Windows.Forms.ComboBox();
            this.cboContactCountry = new System.Windows.Forms.ComboBox();
            this.cboContactRegion = new System.Windows.Forms.ComboBox();
            this.txtContactPostalAddress = new System.Windows.Forms.TextBox();
            this.txtContactEmailAddress = new System.Windows.Forms.TextBox();
            this.cboContactCity = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.cboResidentialRegion = new System.Windows.Forms.ComboBox();
            this.cboResidentialCountry = new System.Windows.Forms.ComboBox();
            this.cboResidentialCity = new System.Windows.Forms.ComboBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.txtResidentialHouseNumber = new System.Windows.Forms.TextBox();
            this.txtResidentialStreetName = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.JobDetailTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label107 = new System.Windows.Forms.Label();
            this.txtOverseer = new System.Windows.Forms.TextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.staffIDtxt = new System.Windows.Forms.TextBox();
            this.staffNoLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.gridStaffNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.transferredOutRadioButton = new System.Windows.Forms.RadioButton();
            this.transferredInRadioButton = new System.Windows.Forms.RadioButton();
            this.grpEngagementMethod = new System.Windows.Forms.GroupBox();
            this.txtEngagementAnnualSalary = new System.Windows.Forms.TextBox();
            this.label100 = new System.Windows.Forms.Label();
            this.cboEngagementGradeOn = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.label91 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.dateEngagementEndingDate = new System.Windows.Forms.DateTimePicker();
            this.dateEngagementEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.checkedListBoxContract = new System.Windows.Forms.CheckedListBox();
            this.cboEngagementGradeLeaving = new System.Windows.Forms.ComboBox();
            this.label76 = new System.Windows.Forms.Label();
            this.dateEngagementDate = new System.Windows.Forms.DateTimePicker();
            this.label75 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.cboEngagementType = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.lblProbationStatus = new System.Windows.Forms.Label();
            this.cboProbationStatus = new System.Windows.Forms.ComboBox();
            this.label94 = new System.Windows.Forms.Label();
            this.dateEmploymentDate = new System.Windows.Forms.DateTimePicker();
            this.label93 = new System.Windows.Forms.Label();
            this.cboAppointmentType = new System.Windows.Forms.ComboBox();
            this.cboSpecialty = new System.Windows.Forms.ComboBox();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.cboEmploymentStatus = new System.Windows.Forms.ComboBox();
            this.startDateLabel = new System.Windows.Forms.Label();
            this.cboJobTitle = new System.Windows.Forms.ComboBox();
            this.probationCheckBox = new System.Windows.Forms.CheckBox();
            this.cboOccupationGrp = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.assumptionDatePicker = new System.Windows.Forms.DateTimePicker();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.DOFADatePicker = new System.Windows.Forms.DateTimePicker();
            this.DOCADatePicker = new System.Windows.Forms.DateTimePicker();
            this.label55 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.SalaryDetailTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.label95 = new System.Windows.Forms.Label();
            this.txtBankDetailAddress = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.txtBankDetailAccountName = new System.Windows.Forms.TextBox();
            this.cboBankDetailName = new System.Windows.Forms.ComboBox();
            this.txtBankDetailAccountNumber = new System.Windows.Forms.TextBox();
            this.cboBankDetailBranch = new System.Windows.Forms.ComboBox();
            this.cboBankDetailAccountType = new System.Windows.Forms.ComboBox();
            this.label89 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblPF = new System.Windows.Forms.Label();
            this.numericPF = new System.Windows.Forms.NumericUpDown();
            this.checkBoxExemptFromSecondTier = new System.Windows.Forms.CheckBox();
            this.isProvidentFundCheckBox = new System.Windows.Forms.CheckBox();
            this.label102 = new System.Windows.Forms.Label();
            this.cboLeaveEntitlement = new System.Windows.Forms.ComboBox();
            this.label101 = new System.Windows.Forms.Label();
            this.cboGradeOnFirstAppointment = new System.Windows.Forms.ComboBox();
            this.label82 = new System.Windows.Forms.Label();
            this.cboSalaryGrouping = new System.Windows.Forms.ComboBox();
            this.checkBoxMechanised = new System.Windows.Forms.CheckBox();
            this.gradeDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label78 = new System.Windows.Forms.Label();
            this.susuPlusContributionAmountTextBox = new System.Windows.Forms.TextBox();
            this.susuPlusContributionCheckBox = new System.Windows.Forms.CheckBox();
            this.calculatedOnComboBox = new System.Windows.Forms.ComboBox();
            this.labelCalculateOn = new System.Windows.Forms.Label();
            this.withholdingTaxRateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.labelRate = new System.Windows.Forms.Label();
            this.withholdingTaxRateRadioButton = new System.Windows.Forms.RadioButton();
            this.withholdingTaxFixedAmountRadioButton = new System.Windows.Forms.RadioButton();
            this.withholdingTaxFixedAmountTextBox = new System.Windows.Forms.TextBox();
            this.withholdingTaxCheckBox = new System.Windows.Forms.CheckBox();
            this.label96 = new System.Windows.Forms.Label();
            this.cboBand = new System.Windows.Forms.ComboBox();
            this.label72 = new System.Windows.Forms.Label();
            this.incomeCheckBox = new System.Windows.Forms.CheckBox();
            this.gradeCategoryComboBox = new System.Windows.Forms.ComboBox();
            this.txtTIN = new System.Windows.Forms.TextBox();
            this.ssnitNoLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.ssnitNoTextBox = new System.Windows.Forms.TextBox();
            this.paymentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.cboStep = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ssnitCheckBox = new System.Windows.Forms.CheckBox();
            this.UserAccountTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.notVerifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.verifiedPictureBox = new System.Windows.Forms.PictureBox();
            this.fingerPrintPictureBox = new System.Windows.Forms.PictureBox();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.fingerPrintTextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userRoleComboBox = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.confirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.dependentsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnRefreshRelations = new System.Windows.Forms.Button();
            this.btnFamilyDetailsRemove = new System.Windows.Forms.Button();
            this.btnClearFamilyDetails = new System.Windows.Forms.Button();
            this.btnSaveFamilyDetails = new System.Windows.Forms.Button();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.gridRelations = new System.Windows.Forms.DataGridView();
            this.relationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationOccupationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationRelationshipID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationRelationship = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.relationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.relationOccupation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.relationDOB = new CalendarColumn();
            this.relationPOB = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.relationPOBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relationAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button21 = new System.Windows.Forms.Button();
            this.button23 = new System.Windows.Forms.Button();
            this.LanguageTabPage = new System.Windows.Forms.TabPage();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btnRefreshLanguages = new System.Windows.Forms.Button();
            this.btnLanguageRemove = new System.Windows.Forms.Button();
            this.btnClearLanguage = new System.Windows.Forms.Button();
            this.btnSaveLanguage = new System.Windows.Forms.Button();
            this.gridLanguage = new System.Windows.Forms.DataGridView();
            this.gridLanguageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanguage = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLanguageLevel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLanguageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proffessionHistoryTabPage = new System.Windows.Forms.TabPage();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnRefreshProfessionHistory = new System.Windows.Forms.Button();
            this.btnProfessionHistoryRemove = new System.Windows.Forms.Button();
            this.btnClearProfessionHistory = new System.Windows.Forms.Button();
            this.btnSaveProfessionHistory = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.gridProfession = new System.Windows.Forms.DataGridView();
            this.professionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professionNameOfProfession = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.professionFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.professionFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.professionToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.professionToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.employmentTabPage = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRefreshEmploymentHistory = new System.Windows.Forms.Button();
            this.btnEmploymentHistoryRemove = new System.Windows.Forms.Button();
            this.btnSaveEmploymentHistory = new System.Windows.Forms.Button();
            this.btnClearEmploymentHistory = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gridEmploymentHistory = new System.Windows.Forms.DataGridView();
            this.experienceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceNameOfOrganisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceJobTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceAnnualSalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experienceFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.experienceReasonForLeaving = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educationHistoryTabPage = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnRefreshEducationHistory = new System.Windows.Forms.Button();
            this.btnEducationHistoryRemove = new System.Windows.Forms.Button();
            this.btnSaveEducationHistory = new System.Windows.Forms.Button();
            this.btnClearEducationHistory = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridEducationHistory = new System.Windows.Forms.DataGridView();
            this.qualificationsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsNameOfInstitution = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsCertificateObtained = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationsFromMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsFromYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsToMonth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qualificationsToYear = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.documentsTabPage = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnRefreshDocuments = new System.Windows.Forms.Button();
            this.btnDocumentsRemove = new System.Windows.Forms.Button();
            this.btnDocumentsClear = new System.Windows.Forms.Button();
            this.btnDocumentsView = new System.Windows.Forms.Button();
            this.btnDocumentsScan = new System.Windows.Forms.Button();
            this.btnDocumentsSave = new System.Windows.Forms.Button();
            this.btnDocumentsUpload = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.gridDocuments = new System.Windows.Forms.DataGridView();
            this.gridDocumentsID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridDocumentsPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridDocumentsDocumentsContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereeTabPage = new System.Windows.Forms.TabPage();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btnRefreshRefrees = new System.Windows.Forms.Button();
            this.btnRefreeRemove = new System.Windows.Forms.Button();
            this.btnClearRefrees = new System.Windows.Forms.Button();
            this.btnSaveRefrees = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.button11 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gridRefrees = new System.Windows.Forms.DataGridView();
            this.refereesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesOccupation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesTelNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refereesEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workPermitTabPage = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.cmbDisabled = new System.Windows.Forms.ComboBox();
            this.cmbBonded = new System.Windows.Forms.ComboBox();
            this.cmbApplied = new System.Windows.Forms.ComboBox();
            this.cmbConvicted = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClearWorkPermits = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.checkBoxHasPassport = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.dateExpires = new System.Windows.Forms.DateTimePicker();
            this.dateIssued = new System.Windows.Forms.DateTimePicker();
            this.txtPassportNotes = new System.Windows.Forms.TextBox();
            this.txtPassportNo = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.checkBoxHasVisa = new System.Windows.Forms.CheckBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txtVisaNo = new System.Windows.Forms.TextBox();
            this.cmbVisaType = new System.Windows.Forms.ComboBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label44 = new System.Windows.Forms.Label();
            this.txtVisaNotes = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.txtDuration = new System.Windows.Forms.NumericUpDown();
            this.txtWorkPermitID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbWorkPermit = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.dateWorkPermit = new System.Windows.Forms.DateTimePicker();
            this.txtWorkPermitNotes = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label104 = new System.Windows.Forms.Label();
            this.txtTribe = new System.Windows.Forms.TextBox();
            this.label103 = new System.Windows.Forms.Label();
            this.cboRace = new System.Windows.Forms.ComboBox();
            this.checkBoxActive = new System.Windows.Forms.CheckBox();
            this.groupBoxSpecialInformation = new System.Windows.Forms.GroupBox();
            this.btnDisabilityType = new System.Windows.Forms.Button();
            this.label99 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.cboDisabilityType = new System.Windows.Forms.ComboBox();
            this.datePickerDisabilityDate = new System.Windows.Forms.DateTimePicker();
            this.cboBirthRegion = new System.Windows.Forms.ComboBox();
            this.label81 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.cboQualificationType = new System.Windows.Forms.ComboBox();
            this.checkBoxDisability = new System.Windows.Forms.CheckBox();
            this.label79 = new System.Windows.Forms.Label();
            this.zoneDatePicker = new System.Windows.Forms.DateTimePicker();
            this.txtFileNumber = new System.Windows.Forms.ComboBox();
            this.label77 = new System.Windows.Forms.Label();
            this.cboZone = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtNumberOfChildren = new System.Windows.Forms.NumericUpDown();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearPersonalInfo = new System.Windows.Forms.Button();
            this.label85 = new System.Windows.Forms.Label();
            this.lblDOM = new System.Windows.Forms.Label();
            this.dateDOM = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNHISNumber = new System.Windows.Forms.TextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.btnDenomination = new System.Windows.Forms.Button();
            this.cboDenomination = new System.Windows.Forms.ComboBox();
            this.btnReligion = new System.Windows.Forms.Button();
            this.button24 = new System.Windows.Forms.Button();
            this.cboNationality = new System.Windows.Forms.ComboBox();
            this.cboBirthCountry = new System.Windows.Forms.ComboBox();
            this.label70 = new System.Windows.Forms.Label();
            this.cboBirthDistrict = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.browse_imagebtn = new System.Windows.Forms.Button();
            this.txtOtherName = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.txtNationalID = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.txtMaidenName = new System.Windows.Forms.TextBox();
            this.txtPIN = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cmbPOB = new System.Windows.Forms.ComboBox();
            this.btnBirthPlace = new System.Windows.Forms.Button();
            this.cmbHomeTown = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.btnBirthDistrict = new System.Windows.Forms.Button();
            this.cmbSex = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMaritalStatus = new System.Windows.Forms.ComboBox();
            this.dateDOB = new System.Windows.Forms.DateTimePicker();
            this.staffIDTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbReligion = new System.Windows.Forms.ComboBox();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.relationshipsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.humanResourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.humanResourceDataSet = new eMAS.HumanResourceDataSet();
            this.townsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.occupationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staffPersonalInfoTab = new System.Windows.Forms.TabControl();
            this.allowancesAndDeductionsSummaryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.allowancesAndDeductionsSummaryTableAdapter = new eMAS.HumanResourceDataSetTableAdapters.AllowancesAndDeductionsSummaryTableAdapter();
            this.relationshipsTableAdapter = new eMAS.HumanResourceDataSetTableAdapters.RelationshipsTableAdapter();
            this.occupationsTableAdapter = new eMAS.HumanResourceDataSetTableAdapters.OccupationsTableAdapter();
            this.townsTableAdapter = new eMAS.HumanResourceDataSetTableAdapters.TownsTableAdapter();
            this.btnQuickSearch = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn7 = new CalendarColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.occupationGroupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.docGroupErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.educationErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.professionErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereesErrorProvider)).BeginInit();
            this.personalTabPage.SuspendLayout();
            this.tabOtherDetails.SuspendLayout();
            this.ContactTabPage.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.JobDetailTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.groupBox27.SuspendLayout();
            this.grpEngagementMethod.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SalaryDetailTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.withholdingTaxRateNumericUpDown)).BeginInit();
            this.UserAccountTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notVerifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.verifiedPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintPictureBox)).BeginInit();
            this.userGroupBox.SuspendLayout();
            this.dependentsTabPage.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.panel13.SuspendLayout();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRelations)).BeginInit();
            this.panel3.SuspendLayout();
            this.LanguageTabPage.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLanguage)).BeginInit();
            this.proffessionHistoryTabPage.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfession)).BeginInit();
            this.employmentTabPage.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).BeginInit();
            this.educationHistoryTabPage.SuspendLayout();
            this.panel7.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).BeginInit();
            this.documentsTabPage.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).BeginInit();
            this.refereeTabPage.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRefrees)).BeginInit();
            this.workPermitTabPage.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBoxSpecialInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfChildren)).BeginInit();
            this.panel9.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationshipsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanResourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanResourceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.townsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupationsBindingSource)).BeginInit();
            this.staffPersonalInfoTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allowancesAndDeductionsSummaryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupationGroupsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.Black;
            this.closeButton.Location = new System.Drawing.Point(862, 594);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(69, 23);
            this.closeButton.TabIndex = 16;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // btnRemoveEmployee
            // 
            this.btnRemoveEmployee.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveEmployee.ForeColor = System.Drawing.Color.Black;
            this.btnRemoveEmployee.Location = new System.Drawing.Point(789, 594);
            this.btnRemoveEmployee.Name = "btnRemoveEmployee";
            this.btnRemoveEmployee.Size = new System.Drawing.Size(69, 23);
            this.btnRemoveEmployee.TabIndex = 18;
            this.btnRemoveEmployee.Text = "Remove";
            this.btnRemoveEmployee.UseVisualStyleBackColor = true;
            this.btnRemoveEmployee.Click += new System.EventHandler(this.btnRemoveEmployee_Click);
            // 
            // viewButton
            // 
            this.viewButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewButton.ForeColor = System.Drawing.Color.Black;
            this.viewButton.Location = new System.Drawing.Point(4, 594);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(108, 23);
            this.viewButton.TabIndex = 17;
            this.viewButton.Text = "Advance Search";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // docGroupErrorProvider
            // 
            this.docGroupErrorProvider.ContainerControl = this;
            // 
            // fingerPrintErrorProvider
            // 
            this.fingerPrintErrorProvider.ContainerControl = this;
            // 
            // staffErrorProvider
            // 
            this.staffErrorProvider.ContainerControl = this;
            // 
            // relationsErrorProvider
            // 
            this.relationsErrorProvider.ContainerControl = this;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.relationsErrorProvider.SetIconPadding(this.label45, 1);
            this.label45.Location = new System.Drawing.Point(193, 35);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(70, 13);
            this.label45.TabIndex = 0;
            this.label45.Text = "Type of Visa:";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.relationsErrorProvider.SetIconPadding(this.label42, 1);
            this.label42.Location = new System.Drawing.Point(8, 66);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(80, 13);
            this.label42.TabIndex = 0;
            this.label42.Text = "Place Of Issue:";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearAll.ForeColor = System.Drawing.Color.Black;
            this.btnClearAll.Location = new System.Drawing.Point(715, 594);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(69, 23);
            this.btnClearAll.TabIndex = 42;
            this.btnClearAll.Text = "Clear All";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // educationErrorProvider
            // 
            this.educationErrorProvider.ContainerControl = this;
            // 
            // employmentErrorProvider
            // 
            this.employmentErrorProvider.ContainerControl = this;
            // 
            // professionErrorProvider
            // 
            this.professionErrorProvider.ContainerControl = this;
            // 
            // refereesErrorProvider
            // 
            this.refereesErrorProvider.ContainerControl = this;
            // 
            // personalTabPage
            // 
            this.personalTabPage.BackColor = System.Drawing.Color.Lavender;
            this.personalTabPage.Controls.Add(this.tabOtherDetails);
            this.personalTabPage.Controls.Add(this.groupBox9);
            this.personalTabPage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personalTabPage.ForeColor = System.Drawing.Color.Black;
            this.personalTabPage.Location = new System.Drawing.Point(4, 22);
            this.personalTabPage.Name = "personalTabPage";
            this.personalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.personalTabPage.Size = new System.Drawing.Size(1042, 566);
            this.personalTabPage.TabIndex = 0;
            this.personalTabPage.Text = "Personal";
            this.personalTabPage.UseVisualStyleBackColor = true;
            // 
            // tabOtherDetails
            // 
            this.tabOtherDetails.Controls.Add(this.ContactTabPage);
            this.tabOtherDetails.Controls.Add(this.JobDetailTabPage);
            this.tabOtherDetails.Controls.Add(this.SalaryDetailTabPage);
            this.tabOtherDetails.Controls.Add(this.UserAccountTabPage);
            this.tabOtherDetails.Controls.Add(this.dependentsTabPage);
            this.tabOtherDetails.Controls.Add(this.LanguageTabPage);
            this.tabOtherDetails.Controls.Add(this.proffessionHistoryTabPage);
            this.tabOtherDetails.Controls.Add(this.employmentTabPage);
            this.tabOtherDetails.Controls.Add(this.educationHistoryTabPage);
            this.tabOtherDetails.Controls.Add(this.documentsTabPage);
            this.tabOtherDetails.Controls.Add(this.refereeTabPage);
            this.tabOtherDetails.Controls.Add(this.workPermitTabPage);
            this.tabOtherDetails.Location = new System.Drawing.Point(3, 312);
            this.tabOtherDetails.Name = "tabOtherDetails";
            this.tabOtherDetails.SelectedIndex = 0;
            this.tabOtherDetails.Size = new System.Drawing.Size(1034, 248);
            this.tabOtherDetails.TabIndex = 1;
            // 
            // ContactTabPage
            // 
            this.ContactTabPage.Controls.Add(this.groupBox18);
            this.ContactTabPage.Location = new System.Drawing.Point(4, 22);
            this.ContactTabPage.Name = "ContactTabPage";
            this.ContactTabPage.Size = new System.Drawing.Size(1026, 222);
            this.ContactTabPage.TabIndex = 17;
            this.ContactTabPage.Text = "Contact";
            this.ContactTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.BackColor = System.Drawing.Color.Lavender;
            this.groupBox18.Controls.Add(this.groupBox24);
            this.groupBox18.Controls.Add(this.groupBox21);
            this.groupBox18.Controls.Add(this.groupBox20);
            this.groupBox18.Location = new System.Drawing.Point(1, 0);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(1022, 228);
            this.groupBox18.TabIndex = 0;
            this.groupBox18.TabStop = false;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.label97);
            this.groupBox24.Controls.Add(this.label83);
            this.groupBox24.Controls.Add(this.txtLicenceNumber);
            this.groupBox24.Controls.Add(this.cboLicenceType);
            this.groupBox24.Location = new System.Drawing.Point(754, 12);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(262, 72);
            this.groupBox24.TabIndex = 28;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Driving Licence Information";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(5, 42);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(86, 13);
            this.label97.TabIndex = 3;
            this.label97.Text = "Licence Number:";
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(17, 20);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(73, 13);
            this.label83.TabIndex = 2;
            this.label83.Text = "Licence Type:";
            // 
            // txtLicenceNumber
            // 
            this.txtLicenceNumber.Location = new System.Drawing.Point(94, 37);
            this.txtLicenceNumber.Name = "txtLicenceNumber";
            this.txtLicenceNumber.Size = new System.Drawing.Size(162, 21);
            this.txtLicenceNumber.TabIndex = 1;
            // 
            // cboLicenceType
            // 
            this.cboLicenceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLicenceType.FormattingEnabled = true;
            this.cboLicenceType.Location = new System.Drawing.Point(94, 15);
            this.cboLicenceType.Name = "cboLicenceType";
            this.cboLicenceType.Size = new System.Drawing.Size(162, 21);
            this.cboLicenceType.TabIndex = 0;
            this.cboLicenceType.DropDown += new System.EventHandler(this.cboLicenceType_DropDown);
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.txtContactMobileNumber);
            this.groupBox21.Controls.Add(this.txtContactTelephone);
            this.groupBox21.Controls.Add(this.label4);
            this.groupBox21.Controls.Add(this.cboContactHomeTown);
            this.groupBox21.Controls.Add(this.cboContactCountry);
            this.groupBox21.Controls.Add(this.cboContactRegion);
            this.groupBox21.Controls.Add(this.txtContactPostalAddress);
            this.groupBox21.Controls.Add(this.txtContactEmailAddress);
            this.groupBox21.Controls.Add(this.cboContactCity);
            this.groupBox21.Controls.Add(this.label15);
            this.groupBox21.Controls.Add(this.label10);
            this.groupBox21.Controls.Add(this.label33);
            this.groupBox21.Controls.Add(this.label16);
            this.groupBox21.Controls.Add(this.label37);
            this.groupBox21.Controls.Add(this.label60);
            this.groupBox21.Controls.Add(this.label61);
            this.groupBox21.Location = new System.Drawing.Point(46, 9);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(377, 220);
            this.groupBox21.TabIndex = 27;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "Contact";
            // 
            // txtContactMobileNumber
            // 
            this.txtContactMobileNumber.Location = new System.Drawing.Point(164, 169);
            this.txtContactMobileNumber.Mask = "999-000-00-00";
            this.txtContactMobileNumber.Name = "txtContactMobileNumber";
            this.txtContactMobileNumber.Size = new System.Drawing.Size(121, 21);
            this.txtContactMobileNumber.TabIndex = 29;
            // 
            // txtContactTelephone
            // 
            this.txtContactTelephone.Location = new System.Drawing.Point(164, 146);
            this.txtContactTelephone.Mask = "999-000-00-00";
            this.txtContactTelephone.Name = "txtContactTelephone";
            this.txtContactTelephone.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtContactTelephone.Size = new System.Drawing.Size(121, 21);
            this.txtContactTelephone.TabIndex = 28;
            this.txtContactTelephone.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txtContactTelephone_MaskInputRejected);
            this.txtContactTelephone.TypeValidationCompleted += new System.Windows.Forms.TypeValidationEventHandler(this.txtContactTelephone_TypeValidationCompleted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Mobile No. *:";
            // 
            // cboContactHomeTown
            // 
            this.cboContactHomeTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactHomeTown.FormattingEnabled = true;
            this.cboContactHomeTown.Location = new System.Drawing.Point(164, 123);
            this.cboContactHomeTown.Name = "cboContactHomeTown";
            this.cboContactHomeTown.Size = new System.Drawing.Size(121, 21);
            this.cboContactHomeTown.TabIndex = 16;
            this.cboContactHomeTown.Visible = false;
            this.cboContactHomeTown.DropDown += new System.EventHandler(this.cboContactHomeTown_DropDown);
            // 
            // cboContactCountry
            // 
            this.cboContactCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactCountry.FormattingEnabled = true;
            this.cboContactCountry.Location = new System.Drawing.Point(164, 100);
            this.cboContactCountry.Name = "cboContactCountry";
            this.cboContactCountry.Size = new System.Drawing.Size(121, 21);
            this.cboContactCountry.TabIndex = 15;
            this.cboContactCountry.DropDown += new System.EventHandler(this.cboContactCountry_DropDown);
            // 
            // cboContactRegion
            // 
            this.cboContactRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactRegion.FormattingEnabled = true;
            this.cboContactRegion.Location = new System.Drawing.Point(164, 54);
            this.cboContactRegion.Name = "cboContactRegion";
            this.cboContactRegion.Size = new System.Drawing.Size(121, 21);
            this.cboContactRegion.TabIndex = 14;
            this.cboContactRegion.SelectionChangeCommitted += new System.EventHandler(this.cboContactRegion_SelectionChangeCommitted);
            this.cboContactRegion.DropDown += new System.EventHandler(this.cboContactRegion_DropDown);
            // 
            // txtContactPostalAddress
            // 
            this.txtContactPostalAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContactPostalAddress.Location = new System.Drawing.Point(164, 10);
            this.txtContactPostalAddress.Multiline = true;
            this.txtContactPostalAddress.Name = "txtContactPostalAddress";
            this.txtContactPostalAddress.Size = new System.Drawing.Size(208, 42);
            this.txtContactPostalAddress.TabIndex = 0;
            // 
            // txtContactEmailAddress
            // 
            this.txtContactEmailAddress.Location = new System.Drawing.Point(164, 192);
            this.txtContactEmailAddress.Name = "txtContactEmailAddress";
            this.txtContactEmailAddress.Size = new System.Drawing.Size(171, 21);
            this.txtContactEmailAddress.TabIndex = 9;
            // 
            // cboContactCity
            // 
            this.cboContactCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboContactCity.FormattingEnabled = true;
            this.cboContactCity.Location = new System.Drawing.Point(164, 77);
            this.cboContactCity.Name = "cboContactCity";
            this.cboContactCity.Size = new System.Drawing.Size(121, 21);
            this.cboContactCity.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(70, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(91, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Postal Address* :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(92, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "City/Town* :";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(108, 56);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 13);
            this.label33.TabIndex = 10;
            this.label33.Text = "Region* :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(102, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Country* :";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(86, 126);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(76, 13);
            this.label37.TabIndex = 11;
            this.label37.Text = "Home Town* :";
            this.label37.Visible = false;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(56, 149);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(105, 13);
            this.label60.TabIndex = 12;
            this.label60.Text = "Telephone Contact :";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(81, 195);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(80, 13);
            this.label61.TabIndex = 13;
            this.label61.Text = "Email Address :";
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.cboResidentialRegion);
            this.groupBox20.Controls.Add(this.cboResidentialCountry);
            this.groupBox20.Controls.Add(this.cboResidentialCity);
            this.groupBox20.Controls.Add(this.label63);
            this.groupBox20.Controls.Add(this.label64);
            this.groupBox20.Controls.Add(this.label67);
            this.groupBox20.Controls.Add(this.txtResidentialHouseNumber);
            this.groupBox20.Controls.Add(this.txtResidentialStreetName);
            this.groupBox20.Controls.Add(this.label65);
            this.groupBox20.Controls.Add(this.label66);
            this.groupBox20.Location = new System.Drawing.Point(427, 12);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(321, 146);
            this.groupBox20.TabIndex = 26;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "Residential Address";
            // 
            // cboResidentialRegion
            // 
            this.cboResidentialRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResidentialRegion.FormattingEnabled = true;
            this.cboResidentialRegion.Location = new System.Drawing.Point(132, 78);
            this.cboResidentialRegion.Name = "cboResidentialRegion";
            this.cboResidentialRegion.Size = new System.Drawing.Size(121, 21);
            this.cboResidentialRegion.TabIndex = 28;
            this.cboResidentialRegion.SelectionChangeCommitted += new System.EventHandler(this.cboResidentialRegion_SelectionChangeCommitted);
            this.cboResidentialRegion.DropDown += new System.EventHandler(this.cboResidentialRegion_DropDown);
            // 
            // cboResidentialCountry
            // 
            this.cboResidentialCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResidentialCountry.FormattingEnabled = true;
            this.cboResidentialCountry.Location = new System.Drawing.Point(132, 124);
            this.cboResidentialCountry.Name = "cboResidentialCountry";
            this.cboResidentialCountry.Size = new System.Drawing.Size(121, 21);
            this.cboResidentialCountry.TabIndex = 27;
            this.cboResidentialCountry.DropDown += new System.EventHandler(this.cboResidentialCountry_DropDown);
            // 
            // cboResidentialCity
            // 
            this.cboResidentialCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboResidentialCity.FormattingEnabled = true;
            this.cboResidentialCity.Location = new System.Drawing.Point(132, 101);
            this.cboResidentialCity.Name = "cboResidentialCity";
            this.cboResidentialCity.Size = new System.Drawing.Size(121, 21);
            this.cboResidentialCity.TabIndex = 26;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(55, 59);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(74, 13);
            this.label63.TabIndex = 21;
            this.label63.Text = "Street Name :";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(60, 105);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(69, 13);
            this.label64.TabIndex = 22;
            this.label64.Text = "City/Town* :";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(39, 28);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(90, 13);
            this.label67.TabIndex = 25;
            this.label67.Text = "House Number* :";
            // 
            // txtResidentialHouseNumber
            // 
            this.txtResidentialHouseNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResidentialHouseNumber.Location = new System.Drawing.Point(132, 11);
            this.txtResidentialHouseNumber.Multiline = true;
            this.txtResidentialHouseNumber.Name = "txtResidentialHouseNumber";
            this.txtResidentialHouseNumber.Size = new System.Drawing.Size(179, 43);
            this.txtResidentialHouseNumber.TabIndex = 15;
            // 
            // txtResidentialStreetName
            // 
            this.txtResidentialStreetName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtResidentialStreetName.Location = new System.Drawing.Point(132, 55);
            this.txtResidentialStreetName.Name = "txtResidentialStreetName";
            this.txtResidentialStreetName.Size = new System.Drawing.Size(179, 21);
            this.txtResidentialStreetName.TabIndex = 16;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(76, 82);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 13);
            this.label65.TabIndex = 23;
            this.label65.Text = "Region* :";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(70, 128);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(59, 13);
            this.label66.TabIndex = 24;
            this.label66.Text = "Country* :";
            // 
            // JobDetailTabPage
            // 
            this.JobDetailTabPage.Controls.Add(this.groupBox2);
            this.JobDetailTabPage.Location = new System.Drawing.Point(4, 22);
            this.JobDetailTabPage.Name = "JobDetailTabPage";
            this.JobDetailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.JobDetailTabPage.Size = new System.Drawing.Size(1026, 222);
            this.JobDetailTabPage.TabIndex = 0;
            this.JobDetailTabPage.Text = "Job Detail";
            this.JobDetailTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Lavender;
            this.groupBox2.Controls.Add(this.label107);
            this.groupBox2.Controls.Add(this.txtOverseer);
            this.groupBox2.Controls.Add(this.groupBox23);
            this.groupBox2.Controls.Add(this.groupBox27);
            this.groupBox2.Controls.Add(this.grpEngagementMethod);
            this.groupBox2.Controls.Add(this.groupBox10);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 285);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // label107
            // 
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(743, 160);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(56, 13);
            this.label107.TabIndex = 68;
            this.label107.Text = "Overseer:";
            // 
            // txtOverseer
            // 
            this.txtOverseer.Enabled = false;
            this.txtOverseer.Location = new System.Drawing.Point(802, 156);
            this.txtOverseer.Name = "txtOverseer";
            this.txtOverseer.Size = new System.Drawing.Size(99, 21);
            this.txtOverseer.TabIndex = 67;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.staffIDtxt);
            this.groupBox23.Controls.Add(this.staffNoLabel);
            this.groupBox23.Controls.Add(this.nameLabel);
            this.groupBox23.Controls.Add(this.nametxt);
            this.groupBox23.Controls.Add(this.searchGrid);
            this.groupBox23.Location = new System.Drawing.Point(746, 4);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(268, 137);
            this.groupBox23.TabIndex = 66;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Supervisor";
            // 
            // staffIDtxt
            // 
            this.staffIDtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.staffIDtxt.Location = new System.Drawing.Point(53, 17);
            this.staffIDtxt.Name = "staffIDtxt";
            this.staffIDtxt.Size = new System.Drawing.Size(133, 21);
            this.staffIDtxt.TabIndex = 10;
            this.staffIDtxt.TextChanged += new System.EventHandler(this.staffIDtxt_TextChanged);
            // 
            // staffNoLabel
            // 
            this.staffNoLabel.AutoSize = true;
            this.staffNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.staffNoLabel.Location = new System.Drawing.Point(1, 20);
            this.staffNoLabel.Name = "staffNoLabel";
            this.staffNoLabel.Size = new System.Drawing.Size(51, 13);
            this.staffNoLabel.TabIndex = 7;
            this.staffNoLabel.Text = "Staff No:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Location = new System.Drawing.Point(12, 42);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 8;
            this.nameLabel.Text = "Name:";
            // 
            // nametxt
            // 
            this.nametxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nametxt.Location = new System.Drawing.Point(53, 39);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(196, 21);
            this.nametxt.TabIndex = 9;
            this.nametxt.TextChanged += new System.EventHandler(this.nametxt_TextChanged);
            // 
            // searchGrid
            // 
            this.searchGrid.AllowUserToAddRows = false;
            this.searchGrid.AllowUserToDeleteRows = false;
            this.searchGrid.BackgroundColor = System.Drawing.Color.White;
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.ColumnHeadersVisible = false;
            this.searchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridStaffNo,
            this.gridName});
            this.searchGrid.Location = new System.Drawing.Point(53, 25);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.ReadOnly = true;
            this.searchGrid.RowHeadersWidth = 5;
            this.searchGrid.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.searchGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchGrid.Size = new System.Drawing.Size(209, 106);
            this.searchGrid.TabIndex = 11;
            this.searchGrid.Visible = false;
            this.searchGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellClick);
            // 
            // gridStaffNo
            // 
            this.gridStaffNo.DataPropertyName = "StaffsID";
            this.gridStaffNo.HeaderText = "Staff No";
            this.gridStaffNo.Name = "gridStaffNo";
            this.gridStaffNo.ReadOnly = true;
            // 
            // gridName
            // 
            this.gridName.DataPropertyName = "Name";
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.transferredOutRadioButton);
            this.groupBox27.Controls.Add(this.transferredInRadioButton);
            this.groupBox27.Location = new System.Drawing.Point(906, 147);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(106, 70);
            this.groupBox27.TabIndex = 65;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "Transfer Detail ";
            this.groupBox27.Visible = false;
            // 
            // transferredOutRadioButton
            // 
            this.transferredOutRadioButton.AutoSize = true;
            this.transferredOutRadioButton.Location = new System.Drawing.Point(15, 50);
            this.transferredOutRadioButton.Name = "transferredOutRadioButton";
            this.transferredOutRadioButton.Size = new System.Drawing.Size(87, 17);
            this.transferredOutRadioButton.TabIndex = 1;
            this.transferredOutRadioButton.TabStop = true;
            this.transferredOutRadioButton.Text = "Transfer Out";
            this.transferredOutRadioButton.UseVisualStyleBackColor = true;
            // 
            // transferredInRadioButton
            // 
            this.transferredInRadioButton.AutoSize = true;
            this.transferredInRadioButton.Location = new System.Drawing.Point(14, 27);
            this.transferredInRadioButton.Name = "transferredInRadioButton";
            this.transferredInRadioButton.Size = new System.Drawing.Size(79, 17);
            this.transferredInRadioButton.TabIndex = 0;
            this.transferredInRadioButton.TabStop = true;
            this.transferredInRadioButton.Text = "Transfer In";
            this.transferredInRadioButton.UseVisualStyleBackColor = true;
            // 
            // grpEngagementMethod
            // 
            this.grpEngagementMethod.Controls.Add(this.txtEngagementAnnualSalary);
            this.grpEngagementMethod.Controls.Add(this.label100);
            this.grpEngagementMethod.Controls.Add(this.cboEngagementGradeOn);
            this.grpEngagementMethod.Controls.Add(this.label92);
            this.grpEngagementMethod.Controls.Add(this.label91);
            this.grpEngagementMethod.Controls.Add(this.label90);
            this.grpEngagementMethod.Controls.Add(this.dateEngagementEndingDate);
            this.grpEngagementMethod.Controls.Add(this.dateEngagementEffectiveDate);
            this.grpEngagementMethod.Controls.Add(this.checkedListBoxContract);
            this.grpEngagementMethod.Controls.Add(this.cboEngagementGradeLeaving);
            this.grpEngagementMethod.Controls.Add(this.label76);
            this.grpEngagementMethod.Controls.Add(this.dateEngagementDate);
            this.grpEngagementMethod.Controls.Add(this.label75);
            this.grpEngagementMethod.Controls.Add(this.label74);
            this.grpEngagementMethod.Controls.Add(this.cboEngagementType);
            this.grpEngagementMethod.Controls.Add(this.label73);
            this.grpEngagementMethod.Location = new System.Drawing.Point(2, 133);
            this.grpEngagementMethod.Name = "grpEngagementMethod";
            this.grpEngagementMethod.Size = new System.Drawing.Size(736, 86);
            this.grpEngagementMethod.TabIndex = 63;
            this.grpEngagementMethod.TabStop = false;
            this.grpEngagementMethod.Text = "Contract/Limited";
            this.grpEngagementMethod.Visible = false;
            // 
            // txtEngagementAnnualSalary
            // 
            this.txtEngagementAnnualSalary.Location = new System.Drawing.Point(569, 60);
            this.txtEngagementAnnualSalary.Name = "txtEngagementAnnualSalary";
            this.txtEngagementAnnualSalary.Size = new System.Drawing.Size(99, 21);
            this.txtEngagementAnnualSalary.TabIndex = 79;
            this.txtEngagementAnnualSalary.Text = "0";
            // 
            // label100
            // 
            this.label100.AutoSize = true;
            this.label100.Location = new System.Drawing.Point(487, 66);
            this.label100.Name = "label100";
            this.label100.Size = new System.Drawing.Size(77, 13);
            this.label100.TabIndex = 78;
            this.label100.Text = "Annual Salary:";
            // 
            // cboEngagementGradeOn
            // 
            this.cboEngagementGradeOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEngagementGradeOn.FormattingEnabled = true;
            this.cboEngagementGradeOn.Location = new System.Drawing.Point(90, 36);
            this.cboEngagementGradeOn.Name = "cboEngagementGradeOn";
            this.cboEngagementGradeOn.Size = new System.Drawing.Size(135, 21);
            this.cboEngagementGradeOn.TabIndex = 77;
            this.cboEngagementGradeOn.DropDown += new System.EventHandler(this.cboEngagementGradeOn_DropDown);
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(612, 17);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(56, 13);
            this.label92.TabIndex = 76;
            this.label92.Text = "Contract :";
            // 
            // label91
            // 
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(6, 64);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(83, 13);
            this.label91.TabIndex = 75;
            this.label91.Text = "Effective Date :";
            // 
            // label90
            // 
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(252, 66);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(72, 13);
            this.label90.TabIndex = 74;
            this.label90.Text = "Ending Date :";
            // 
            // dateEngagementEndingDate
            // 
            this.dateEngagementEndingDate.CustomFormat = " dd/MM/yyyy";
            this.dateEngagementEndingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEngagementEndingDate.Location = new System.Drawing.Point(326, 62);
            this.dateEngagementEndingDate.Name = "dateEngagementEndingDate";
            this.dateEngagementEndingDate.ShowCheckBox = true;
            this.dateEngagementEndingDate.Size = new System.Drawing.Size(155, 21);
            this.dateEngagementEndingDate.TabIndex = 73;
            this.dateEngagementEndingDate.Value = new System.DateTime(2014, 1, 21, 12, 41, 54, 0);
            // 
            // dateEngagementEffectiveDate
            // 
            this.dateEngagementEffectiveDate.CustomFormat = " dd/MM/yyyy";
            this.dateEngagementEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEngagementEffectiveDate.Location = new System.Drawing.Point(89, 59);
            this.dateEngagementEffectiveDate.Name = "dateEngagementEffectiveDate";
            this.dateEngagementEffectiveDate.ShowCheckBox = true;
            this.dateEngagementEffectiveDate.Size = new System.Drawing.Size(137, 21);
            this.dateEngagementEffectiveDate.TabIndex = 72;
            // 
            // checkedListBoxContract
            // 
            this.checkedListBoxContract.FormattingEnabled = true;
            this.checkedListBoxContract.Items.AddRange(new object[] {
            "1st",
            "2nd",
            "3rd",
            "4th"});
            this.checkedListBoxContract.Location = new System.Drawing.Point(671, 11);
            this.checkedListBoxContract.Name = "checkedListBoxContract";
            this.checkedListBoxContract.Size = new System.Drawing.Size(58, 68);
            this.checkedListBoxContract.TabIndex = 70;
            // 
            // cboEngagementGradeLeaving
            // 
            this.cboEngagementGradeLeaving.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEngagementGradeLeaving.FormattingEnabled = true;
            this.cboEngagementGradeLeaving.Location = new System.Drawing.Point(326, 38);
            this.cboEngagementGradeLeaving.Name = "cboEngagementGradeLeaving";
            this.cboEngagementGradeLeaving.Size = new System.Drawing.Size(156, 21);
            this.cboEngagementGradeLeaving.TabIndex = 69;
            this.cboEngagementGradeLeaving.DropDown += new System.EventHandler(this.cboEngagementGradeLeaving_DropDown);
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(239, 41);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(85, 13);
            this.label76.TabIndex = 67;
            this.label76.Text = "Grade(leaving) :";
            // 
            // dateEngagementDate
            // 
            this.dateEngagementDate.CalendarForeColor = System.Drawing.Color.Yellow;
            this.dateEngagementDate.Checked = false;
            this.dateEngagementDate.CustomFormat = " dd/MM/yyyy";
            this.dateEngagementDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEngagementDate.Location = new System.Drawing.Point(326, 14);
            this.dateEngagementDate.Name = "dateEngagementDate";
            this.dateEngagementDate.ShowCheckBox = true;
            this.dateEngagementDate.Size = new System.Drawing.Size(157, 21);
            this.dateEngagementDate.TabIndex = 64;
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(289, 19);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(34, 13);
            this.label75.TabIndex = 66;
            this.label75.Text = "Date:";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(19, 38);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(68, 13);
            this.label74.TabIndex = 65;
            this.label74.Text = "Grade (On) :";
            // 
            // cboEngagementType
            // 
            this.cboEngagementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEngagementType.FormattingEnabled = true;
            this.cboEngagementType.Location = new System.Drawing.Point(90, 13);
            this.cboEngagementType.Name = "cboEngagementType";
            this.cboEngagementType.Size = new System.Drawing.Size(135, 21);
            this.cboEngagementType.TabIndex = 64;
            this.cboEngagementType.DropDown += new System.EventHandler(this.cboEngagementType_DropDown);
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(39, 15);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(38, 13);
            this.label73.TabIndex = 47;
            this.label73.Text = "Type :";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.lblProbationStatus);
            this.groupBox10.Controls.Add(this.cboProbationStatus);
            this.groupBox10.Controls.Add(this.label94);
            this.groupBox10.Controls.Add(this.dateEmploymentDate);
            this.groupBox10.Controls.Add(this.label93);
            this.groupBox10.Controls.Add(this.cboAppointmentType);
            this.groupBox10.Controls.Add(this.cboSpecialty);
            this.groupBox10.Controls.Add(this.endDatePicker);
            this.groupBox10.Controls.Add(this.endDateLabel);
            this.groupBox10.Controls.Add(this.startDatePicker);
            this.groupBox10.Controls.Add(this.cboEmploymentStatus);
            this.groupBox10.Controls.Add(this.startDateLabel);
            this.groupBox10.Controls.Add(this.cboJobTitle);
            this.groupBox10.Controls.Add(this.probationCheckBox);
            this.groupBox10.Controls.Add(this.cboOccupationGrp);
            this.groupBox10.Controls.Add(this.label38);
            this.groupBox10.Controls.Add(this.label18);
            this.groupBox10.Controls.Add(this.assumptionDatePicker);
            this.groupBox10.Controls.Add(this.departmentComboBox);
            this.groupBox10.Controls.Add(this.label34);
            this.groupBox10.Controls.Add(this.cboUnit);
            this.groupBox10.Controls.Add(this.label35);
            this.groupBox10.Controls.Add(this.label56);
            this.groupBox10.Controls.Add(this.DOFADatePicker);
            this.groupBox10.Controls.Add(this.DOCADatePicker);
            this.groupBox10.Controls.Add(this.label55);
            this.groupBox10.Controls.Add(this.label17);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.label36);
            this.groupBox10.Location = new System.Drawing.Point(2, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(736, 129);
            this.groupBox10.TabIndex = 64;
            this.groupBox10.TabStop = false;
            // 
            // lblProbationStatus
            // 
            this.lblProbationStatus.AutoSize = true;
            this.lblProbationStatus.Location = new System.Drawing.Point(11, 105);
            this.lblProbationStatus.Name = "lblProbationStatus";
            this.lblProbationStatus.Size = new System.Drawing.Size(74, 13);
            this.lblProbationStatus.TabIndex = 67;
            this.lblProbationStatus.Text = "Prob. Status :";
            this.lblProbationStatus.Visible = false;
            // 
            // cboProbationStatus
            // 
            this.cboProbationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProbationStatus.FormattingEnabled = true;
            this.cboProbationStatus.Location = new System.Drawing.Point(89, 101);
            this.cboProbationStatus.Name = "cboProbationStatus";
            this.cboProbationStatus.Size = new System.Drawing.Size(135, 21);
            this.cboProbationStatus.TabIndex = 66;
            this.cboProbationStatus.Visible = false;
            this.cboProbationStatus.DropDown += new System.EventHandler(this.cboProbationStatus_DropDown);
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(492, 109);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(98, 13);
            this.label94.TabIndex = 65;
            this.label94.Text = "Employment Date :";
            // 
            // dateEmploymentDate
            // 
            this.dateEmploymentDate.CustomFormat = " dd/MM/yyyy";
            this.dateEmploymentDate.Enabled = false;
            this.dateEmploymentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEmploymentDate.Location = new System.Drawing.Point(593, 105);
            this.dateEmploymentDate.Name = "dateEmploymentDate";
            this.dateEmploymentDate.ShowCheckBox = true;
            this.dateEmploymentDate.Size = new System.Drawing.Size(138, 21);
            this.dateEmploymentDate.TabIndex = 64;
            this.dateEmploymentDate.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(222, 106);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(105, 13);
            this.label93.TabIndex = 63;
            this.label93.Text = "Appointment Type*:";
            // 
            // cboAppointmentType
            // 
            this.cboAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAppointmentType.FormattingEnabled = true;
            this.cboAppointmentType.Location = new System.Drawing.Point(327, 103);
            this.cboAppointmentType.Name = "cboAppointmentType";
            this.cboAppointmentType.Size = new System.Drawing.Size(162, 21);
            this.cboAppointmentType.TabIndex = 62;
            this.cboAppointmentType.SelectionChangeCommitted += new System.EventHandler(this.cboAppointmentType_SelectionChangeCommitted);
            this.cboAppointmentType.DropDown += new System.EventHandler(this.cboAppointmentType_DropDown);
            // 
            // cboSpecialty
            // 
            this.cboSpecialty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSpecialty.FormattingEnabled = true;
            this.cboSpecialty.Location = new System.Drawing.Point(89, 32);
            this.cboSpecialty.Name = "cboSpecialty";
            this.cboSpecialty.Size = new System.Drawing.Size(135, 21);
            this.cboSpecialty.TabIndex = 60;
            this.cboSpecialty.DropDown += new System.EventHandler(this.cboSpecialty_DropDown);
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = " dd/MM/yyyy";
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDatePicker.Location = new System.Drawing.Point(593, 83);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.ShowCheckBox = true;
            this.endDatePicker.Size = new System.Drawing.Size(139, 21);
            this.endDatePicker.TabIndex = 9;
            this.endDatePicker.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            this.endDatePicker.Visible = false;
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.endDateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.endDateLabel.Location = new System.Drawing.Point(532, 88);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(55, 13);
            this.endDateLabel.TabIndex = 31;
            this.endDateLabel.Text = "End Date:";
            this.endDateLabel.Visible = false;
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = " dd/MM/yyyy";
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDatePicker.Location = new System.Drawing.Point(327, 80);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.ShowCheckBox = true;
            this.startDatePicker.Size = new System.Drawing.Size(162, 21);
            this.startDatePicker.TabIndex = 8;
            this.startDatePicker.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            this.startDatePicker.Visible = false;
            // 
            // cboEmploymentStatus
            // 
            this.cboEmploymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmploymentStatus.FormattingEnabled = true;
            this.cboEmploymentStatus.Location = new System.Drawing.Point(593, 35);
            this.cboEmploymentStatus.Name = "cboEmploymentStatus";
            this.cboEmploymentStatus.Size = new System.Drawing.Size(138, 21);
            this.cboEmploymentStatus.TabIndex = 59;
            this.cboEmploymentStatus.DropDown += new System.EventHandler(this.cboEmploymentStatus_DropDown);
            // 
            // startDateLabel
            // 
            this.startDateLabel.AutoSize = true;
            this.startDateLabel.BackColor = System.Drawing.Color.Transparent;
            this.startDateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startDateLabel.Location = new System.Drawing.Point(263, 84);
            this.startDateLabel.Name = "startDateLabel";
            this.startDateLabel.Size = new System.Drawing.Size(61, 13);
            this.startDateLabel.TabIndex = 29;
            this.startDateLabel.Text = "Start Date:";
            this.startDateLabel.Visible = false;
            // 
            // cboJobTitle
            // 
            this.cboJobTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboJobTitle.FormattingEnabled = true;
            this.cboJobTitle.Location = new System.Drawing.Point(593, 13);
            this.cboJobTitle.Name = "cboJobTitle";
            this.cboJobTitle.Size = new System.Drawing.Size(139, 21);
            this.cboJobTitle.TabIndex = 58;
            this.cboJobTitle.DropDown += new System.EventHandler(this.cboJobTitle_DropDown);
            // 
            // probationCheckBox
            // 
            this.probationCheckBox.AutoSize = true;
            this.probationCheckBox.ForeColor = System.Drawing.Color.Black;
            this.probationCheckBox.Location = new System.Drawing.Point(89, 81);
            this.probationCheckBox.Name = "probationCheckBox";
            this.probationCheckBox.Size = new System.Drawing.Size(72, 17);
            this.probationCheckBox.TabIndex = 6;
            this.probationCheckBox.Text = "Probation";
            this.probationCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.probationCheckBox.UseVisualStyleBackColor = true;
            this.probationCheckBox.CheckedChanged += new System.EventHandler(this.probationCheckBox_CheckedChanged);
            // 
            // cboOccupationGrp
            // 
            this.cboOccupationGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOccupationGrp.FormattingEnabled = true;
            this.cboOccupationGrp.Location = new System.Drawing.Point(328, 33);
            this.cboOccupationGrp.Name = "cboOccupationGrp";
            this.cboOccupationGrp.Size = new System.Drawing.Size(159, 21);
            this.cboOccupationGrp.TabIndex = 61;
            this.cboOccupationGrp.DropDown += new System.EventHandler(this.cboOccupationGrp_DropDown);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(495, 63);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(92, 13);
            this.label38.TabIndex = 51;
            this.label38.Text = "Assumption Date:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(15, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 13);
            this.label18.TabIndex = 17;
            this.label18.Text = "Department*:";
            // 
            // assumptionDatePicker
            // 
            this.assumptionDatePicker.CustomFormat = " dd/MM/yyyy";
            this.assumptionDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.assumptionDatePicker.Location = new System.Drawing.Point(593, 58);
            this.assumptionDatePicker.Name = "assumptionDatePicker";
            this.assumptionDatePicker.ShowCheckBox = true;
            this.assumptionDatePicker.Size = new System.Drawing.Size(139, 21);
            this.assumptionDatePicker.TabIndex = 50;
            this.assumptionDatePicker.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(89, 9);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(135, 21);
            this.departmentComboBox.TabIndex = 3;
            this.departmentComboBox.SelectionChangeCommitted += new System.EventHandler(this.departmentComboBox_SelectionChangeCommitted);
            this.departmentComboBox.DropDown += new System.EventHandler(this.departmentComboBox_DropDown);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(545, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(48, 13);
            this.label34.TabIndex = 45;
            this.label34.Text = "Status*:";
            // 
            // cboUnit
            // 
            this.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(328, 11);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(159, 21);
            this.cboUnit.TabIndex = 57;
            this.cboUnit.SelectedIndexChanged += new System.EventHandler(this.cboUnit_SelectedIndexChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(28, 36);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(60, 13);
            this.label35.TabIndex = 46;
            this.label35.Text = "Specialty*:";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(284, 60);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(40, 13);
            this.label56.TabIndex = 55;
            this.label56.Text = "DOCA:";
            // 
            // DOFADatePicker
            // 
            this.DOFADatePicker.CustomFormat = " dd/MM/yyyy";
            this.DOFADatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DOFADatePicker.Location = new System.Drawing.Point(89, 55);
            this.DOFADatePicker.Name = "DOFADatePicker";
            this.DOFADatePicker.ShowCheckBox = true;
            this.DOFADatePicker.Size = new System.Drawing.Size(135, 21);
            this.DOFADatePicker.TabIndex = 52;
            this.DOFADatePicker.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            // 
            // DOCADatePicker
            // 
            this.DOCADatePicker.CustomFormat = " dd/MM/yyyy";
            this.DOCADatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DOCADatePicker.Location = new System.Drawing.Point(327, 56);
            this.DOCADatePicker.Name = "DOCADatePicker";
            this.DOCADatePicker.ShowCheckBox = true;
            this.DOCADatePicker.Size = new System.Drawing.Size(159, 21);
            this.DOCADatePicker.TabIndex = 53;
            this.DOCADatePicker.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            this.DOCADatePicker.ValueChanged += new System.EventHandler(this.DOCADatePicker_ValueChanged);
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(43, 57);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(45, 13);
            this.label55.TabIndex = 54;
            this.label55.Text = "DOFA*:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(536, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 13);
            this.label17.TabIndex = 16;
            this.label17.Text = "Job Title*:";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(291, 15);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(36, 13);
            this.label28.TabIndex = 38;
            this.label28.Text = "Unit*:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(267, 37);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(58, 13);
            this.label36.TabIndex = 48;
            this.label36.Text = "Occu GRP:";
            // 
            // SalaryDetailTabPage
            // 
            this.SalaryDetailTabPage.Controls.Add(this.groupBox1);
            this.SalaryDetailTabPage.Location = new System.Drawing.Point(4, 22);
            this.SalaryDetailTabPage.Name = "SalaryDetailTabPage";
            this.SalaryDetailTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SalaryDetailTabPage.Size = new System.Drawing.Size(1026, 222);
            this.SalaryDetailTabPage.TabIndex = 2;
            this.SalaryDetailTabPage.Text = "Salary Detail";
            this.SalaryDetailTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.groupBox25);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox25
            // 
            this.groupBox25.Controls.Add(this.label95);
            this.groupBox25.Controls.Add(this.txtBankDetailAddress);
            this.groupBox25.Controls.Add(this.label84);
            this.groupBox25.Controls.Add(this.txtBankDetailAccountName);
            this.groupBox25.Controls.Add(this.cboBankDetailName);
            this.groupBox25.Controls.Add(this.txtBankDetailAccountNumber);
            this.groupBox25.Controls.Add(this.cboBankDetailBranch);
            this.groupBox25.Controls.Add(this.cboBankDetailAccountType);
            this.groupBox25.Controls.Add(this.label89);
            this.groupBox25.Controls.Add(this.label88);
            this.groupBox25.Controls.Add(this.label87);
            this.groupBox25.Controls.Add(this.label86);
            this.groupBox25.Location = new System.Drawing.Point(724, 17);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(287, 194);
            this.groupBox25.TabIndex = 83;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "Bank Details";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(39, 154);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(53, 13);
            this.label95.TabIndex = 12;
            this.label95.Text = "Address :";
            // 
            // txtBankDetailAddress
            // 
            this.txtBankDetailAddress.Location = new System.Drawing.Point(101, 143);
            this.txtBankDetailAddress.Multiline = true;
            this.txtBankDetailAddress.Name = "txtBankDetailAddress";
            this.txtBankDetailAddress.Size = new System.Drawing.Size(179, 34);
            this.txtBankDetailAddress.TabIndex = 11;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(10, 124);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(89, 13);
            this.label84.TabIndex = 10;
            this.label84.Text = "Account Name* :";
            // 
            // txtBankDetailAccountName
            // 
            this.txtBankDetailAccountName.Location = new System.Drawing.Point(101, 119);
            this.txtBankDetailAccountName.Name = "txtBankDetailAccountName";
            this.txtBankDetailAccountName.Size = new System.Drawing.Size(179, 21);
            this.txtBankDetailAccountName.TabIndex = 9;
            // 
            // cboBankDetailName
            // 
            this.cboBankDetailName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankDetailName.FormattingEnabled = true;
            this.cboBankDetailName.Location = new System.Drawing.Point(101, 20);
            this.cboBankDetailName.Name = "cboBankDetailName";
            this.cboBankDetailName.Size = new System.Drawing.Size(141, 21);
            this.cboBankDetailName.TabIndex = 8;
            this.cboBankDetailName.SelectionChangeCommitted += new System.EventHandler(this.cboBankDetailName_SelectionChangeCommitted);
            this.cboBankDetailName.DropDown += new System.EventHandler(this.cboBankDetailName_DropDown);
            // 
            // txtBankDetailAccountNumber
            // 
            this.txtBankDetailAccountNumber.Location = new System.Drawing.Point(101, 95);
            this.txtBankDetailAccountNumber.Name = "txtBankDetailAccountNumber";
            this.txtBankDetailAccountNumber.Size = new System.Drawing.Size(141, 21);
            this.txtBankDetailAccountNumber.TabIndex = 7;
            // 
            // cboBankDetailBranch
            // 
            this.cboBankDetailBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankDetailBranch.FormattingEnabled = true;
            this.cboBankDetailBranch.Location = new System.Drawing.Point(101, 45);
            this.cboBankDetailBranch.Name = "cboBankDetailBranch";
            this.cboBankDetailBranch.Size = new System.Drawing.Size(141, 21);
            this.cboBankDetailBranch.TabIndex = 5;
            this.cboBankDetailBranch.SelectionChangeCommitted += new System.EventHandler(this.cboBankDetailBranch_SelectionChangeCommitted);
            // 
            // cboBankDetailAccountType
            // 
            this.cboBankDetailAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBankDetailAccountType.FormattingEnabled = true;
            this.cboBankDetailAccountType.Location = new System.Drawing.Point(101, 70);
            this.cboBankDetailAccountType.Name = "cboBankDetailAccountType";
            this.cboBankDetailAccountType.Size = new System.Drawing.Size(141, 21);
            this.cboBankDetailAccountType.TabIndex = 4;
            this.cboBankDetailAccountType.DropDown += new System.EventHandler(this.cboBankDetailAccountType_DropDown);
            // 
            // label89
            // 
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(2, 100);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(99, 13);
            this.label89.TabIndex = 3;
            this.label89.Text = "Account Number* :";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(15, 74);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(86, 13);
            this.label88.TabIndex = 2;
            this.label88.Text = "Account Type* :";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(22, 48);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(79, 13);
            this.label87.TabIndex = 1;
            this.label87.Text = "Bank Branch* :";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(28, 25);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(73, 13);
            this.label86.TabIndex = 0;
            this.label86.Text = "Bank Name* :";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblPF);
            this.groupBox8.Controls.Add(this.numericPF);
            this.groupBox8.Controls.Add(this.checkBoxExemptFromSecondTier);
            this.groupBox8.Controls.Add(this.isProvidentFundCheckBox);
            this.groupBox8.Controls.Add(this.label102);
            this.groupBox8.Controls.Add(this.cboLeaveEntitlement);
            this.groupBox8.Controls.Add(this.label101);
            this.groupBox8.Controls.Add(this.cboGradeOnFirstAppointment);
            this.groupBox8.Controls.Add(this.label82);
            this.groupBox8.Controls.Add(this.cboSalaryGrouping);
            this.groupBox8.Controls.Add(this.checkBoxMechanised);
            this.groupBox8.Controls.Add(this.gradeDatePicker);
            this.groupBox8.Controls.Add(this.label78);
            this.groupBox8.Controls.Add(this.susuPlusContributionAmountTextBox);
            this.groupBox8.Controls.Add(this.susuPlusContributionCheckBox);
            this.groupBox8.Controls.Add(this.calculatedOnComboBox);
            this.groupBox8.Controls.Add(this.labelCalculateOn);
            this.groupBox8.Controls.Add(this.withholdingTaxRateNumericUpDown);
            this.groupBox8.Controls.Add(this.labelRate);
            this.groupBox8.Controls.Add(this.withholdingTaxRateRadioButton);
            this.groupBox8.Controls.Add(this.withholdingTaxFixedAmountRadioButton);
            this.groupBox8.Controls.Add(this.withholdingTaxFixedAmountTextBox);
            this.groupBox8.Controls.Add(this.withholdingTaxCheckBox);
            this.groupBox8.Controls.Add(this.label96);
            this.groupBox8.Controls.Add(this.cboBand);
            this.groupBox8.Controls.Add(this.label72);
            this.groupBox8.Controls.Add(this.incomeCheckBox);
            this.groupBox8.Controls.Add(this.gradeCategoryComboBox);
            this.groupBox8.Controls.Add(this.txtTIN);
            this.groupBox8.Controls.Add(this.ssnitNoLabel);
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Controls.Add(this.ssnitNoTextBox);
            this.groupBox8.Controls.Add(this.paymentTypeComboBox);
            this.groupBox8.Controls.Add(this.cboStep);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.txtSalary);
            this.groupBox8.Controls.Add(this.gradeComboBox);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.ssnitCheckBox);
            this.groupBox8.Location = new System.Drawing.Point(6, 11);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(714, 202);
            this.groupBox8.TabIndex = 82;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Salary Detail";
            // 
            // lblPF
            // 
            this.lblPF.AutoSize = true;
            this.lblPF.Location = new System.Drawing.Point(527, 158);
            this.lblPF.Name = "lblPF";
            this.lblPF.Size = new System.Drawing.Size(37, 13);
            this.lblPF.TabIndex = 107;
            this.lblPF.Text = "PF %:";
            // 
            // numericPF
            // 
            this.numericPF.DecimalPlaces = 2;
            this.numericPF.Location = new System.Drawing.Point(568, 154);
            this.numericPF.Name = "numericPF";
            this.numericPF.Size = new System.Drawing.Size(120, 21);
            this.numericPF.TabIndex = 106;
            // 
            // checkBoxExemptFromSecondTier
            // 
            this.checkBoxExemptFromSecondTier.AutoSize = true;
            this.checkBoxExemptFromSecondTier.Location = new System.Drawing.Point(568, 179);
            this.checkBoxExemptFromSecondTier.Name = "checkBoxExemptFromSecondTier";
            this.checkBoxExemptFromSecondTier.Size = new System.Drawing.Size(116, 17);
            this.checkBoxExemptFromSecondTier.TabIndex = 71;
            this.checkBoxExemptFromSecondTier.Text = "Exempt From 2Tier";
            this.checkBoxExemptFromSecondTier.UseVisualStyleBackColor = true;
            // 
            // isProvidentFundCheckBox
            // 
            this.isProvidentFundCheckBox.AutoSize = true;
            this.isProvidentFundCheckBox.Location = new System.Drawing.Point(568, 134);
            this.isProvidentFundCheckBox.Name = "isProvidentFundCheckBox";
            this.isProvidentFundCheckBox.Size = new System.Drawing.Size(99, 17);
            this.isProvidentFundCheckBox.TabIndex = 105;
            this.isProvidentFundCheckBox.Text = "Provident Fund";
            this.isProvidentFundCheckBox.UseVisualStyleBackColor = true;
            this.isProvidentFundCheckBox.CheckedChanged += new System.EventHandler(this.isProvidentFundCheckBox_CheckedChanged);
            // 
            // label102
            // 
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(428, 88);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(136, 13);
            this.label102.TabIndex = 104;
            this.label102.Text = "Annual Leave Entitlement :";
            // 
            // cboLeaveEntitlement
            // 
            this.cboLeaveEntitlement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLeaveEntitlement.FormattingEnabled = true;
            this.cboLeaveEntitlement.Location = new System.Drawing.Point(567, 84);
            this.cboLeaveEntitlement.Name = "cboLeaveEntitlement";
            this.cboLeaveEntitlement.Size = new System.Drawing.Size(142, 21);
            this.cboLeaveEntitlement.TabIndex = 103;
            this.cboLeaveEntitlement.DropDown += new System.EventHandler(this.cboLeaveEntitlement_DropDown);
            // 
            // label101
            // 
            this.label101.AutoSize = true;
            this.label101.Location = new System.Drawing.Point(527, 113);
            this.label101.Name = "label101";
            this.label101.Size = new System.Drawing.Size(39, 13);
            this.label101.TabIndex = 102;
            this.label101.Text = "GOFA:";
            // 
            // cboGradeOnFirstAppointment
            // 
            this.cboGradeOnFirstAppointment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradeOnFirstAppointment.FormattingEnabled = true;
            this.cboGradeOnFirstAppointment.Location = new System.Drawing.Point(567, 109);
            this.cboGradeOnFirstAppointment.Name = "cboGradeOnFirstAppointment";
            this.cboGradeOnFirstAppointment.Size = new System.Drawing.Size(142, 21);
            this.cboGradeOnFirstAppointment.TabIndex = 101;
            this.cboGradeOnFirstAppointment.DropDown += new System.EventHandler(this.cboGradeOnFirstAppointment_DropDown);
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(478, 65);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(87, 13);
            this.label82.TabIndex = 100;
            this.label82.Text = "Salary Grouping:";
            // 
            // cboSalaryGrouping
            // 
            this.cboSalaryGrouping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalaryGrouping.FormattingEnabled = true;
            this.cboSalaryGrouping.Items.AddRange(new object[] {
            "Clinical",
            "Non Clinical"});
            this.cboSalaryGrouping.Location = new System.Drawing.Point(567, 61);
            this.cboSalaryGrouping.Name = "cboSalaryGrouping";
            this.cboSalaryGrouping.Size = new System.Drawing.Size(142, 21);
            this.cboSalaryGrouping.TabIndex = 99;
            this.cboSalaryGrouping.DropDown += new System.EventHandler(this.cboSalaryGrouping_DropDown);
            // 
            // checkBoxMechanised
            // 
            this.checkBoxMechanised.AutoSize = true;
            this.checkBoxMechanised.Location = new System.Drawing.Point(553, 42);
            this.checkBoxMechanised.Name = "checkBoxMechanised";
            this.checkBoxMechanised.Size = new System.Drawing.Size(82, 17);
            this.checkBoxMechanised.TabIndex = 98;
            this.checkBoxMechanised.Text = "Mechanised";
            this.checkBoxMechanised.UseVisualStyleBackColor = true;
            // 
            // gradeDatePicker
            // 
            this.gradeDatePicker.CustomFormat = "dd/MM/yyyy";
            this.gradeDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.gradeDatePicker.Location = new System.Drawing.Point(550, 15);
            this.gradeDatePicker.Name = "gradeDatePicker";
            this.gradeDatePicker.ShowCheckBox = true;
            this.gradeDatePicker.Size = new System.Drawing.Size(134, 21);
            this.gradeDatePicker.TabIndex = 97;
            this.gradeDatePicker.Value = new System.DateTime(2014, 10, 2, 0, 0, 0, 0);
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(485, 18);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(66, 13);
            this.label78.TabIndex = 96;
            this.label78.Text = "Grade Date:";
            // 
            // susuPlusContributionAmountTextBox
            // 
            this.susuPlusContributionAmountTextBox.Location = new System.Drawing.Point(230, 133);
            this.susuPlusContributionAmountTextBox.Name = "susuPlusContributionAmountTextBox";
            this.susuPlusContributionAmountTextBox.Size = new System.Drawing.Size(69, 21);
            this.susuPlusContributionAmountTextBox.TabIndex = 95;
            this.susuPlusContributionAmountTextBox.Visible = false;
            // 
            // susuPlusContributionCheckBox
            // 
            this.susuPlusContributionCheckBox.AutoSize = true;
            this.susuPlusContributionCheckBox.Location = new System.Drawing.Point(95, 136);
            this.susuPlusContributionCheckBox.Name = "susuPlusContributionCheckBox";
            this.susuPlusContributionCheckBox.Size = new System.Drawing.Size(136, 17);
            this.susuPlusContributionCheckBox.TabIndex = 94;
            this.susuPlusContributionCheckBox.Text = "Susu Plus Contribution ";
            this.susuPlusContributionCheckBox.UseVisualStyleBackColor = true;
            this.susuPlusContributionCheckBox.CheckedChanged += new System.EventHandler(this.susuPlusContributionCheckBox_CheckedChanged);
            // 
            // calculatedOnComboBox
            // 
            this.calculatedOnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.calculatedOnComboBox.FormattingEnabled = true;
            this.calculatedOnComboBox.Location = new System.Drawing.Point(407, 175);
            this.calculatedOnComboBox.Name = "calculatedOnComboBox";
            this.calculatedOnComboBox.Size = new System.Drawing.Size(132, 21);
            this.calculatedOnComboBox.TabIndex = 92;
            this.calculatedOnComboBox.Visible = false;
            this.calculatedOnComboBox.DropDown += new System.EventHandler(this.calculatedOnComboBox_DropDown);
            // 
            // labelCalculateOn
            // 
            this.labelCalculateOn.AutoSize = true;
            this.labelCalculateOn.Location = new System.Drawing.Point(321, 179);
            this.labelCalculateOn.Name = "labelCalculateOn";
            this.labelCalculateOn.Size = new System.Drawing.Size(81, 13);
            this.labelCalculateOn.TabIndex = 91;
            this.labelCalculateOn.Text = "Calculated On :";
            this.labelCalculateOn.Visible = false;
            // 
            // withholdingTaxRateNumericUpDown
            // 
            this.withholdingTaxRateNumericUpDown.Location = new System.Drawing.Point(407, 150);
            this.withholdingTaxRateNumericUpDown.Name = "withholdingTaxRateNumericUpDown";
            this.withholdingTaxRateNumericUpDown.Size = new System.Drawing.Size(75, 21);
            this.withholdingTaxRateNumericUpDown.TabIndex = 90;
            this.withholdingTaxRateNumericUpDown.Visible = false;
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Location = new System.Drawing.Point(342, 154);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(59, 13);
            this.labelRate.TabIndex = 89;
            this.labelRate.Text = "Rate (%) :";
            this.labelRate.Visible = false;
            // 
            // withholdingTaxRateRadioButton
            // 
            this.withholdingTaxRateRadioButton.AutoSize = true;
            this.withholdingTaxRateRadioButton.Location = new System.Drawing.Point(307, 134);
            this.withholdingTaxRateRadioButton.Name = "withholdingTaxRateRadioButton";
            this.withholdingTaxRateRadioButton.Size = new System.Drawing.Size(55, 17);
            this.withholdingTaxRateRadioButton.TabIndex = 88;
            this.withholdingTaxRateRadioButton.TabStop = true;
            this.withholdingTaxRateRadioButton.Text = "Rate :";
            this.withholdingTaxRateRadioButton.UseVisualStyleBackColor = true;
            this.withholdingTaxRateRadioButton.Visible = false;
            this.withholdingTaxRateRadioButton.CheckedChanged += new System.EventHandler(this.withholdingTaxRateRadioButton_CheckedChanged);
            // 
            // withholdingTaxFixedAmountRadioButton
            // 
            this.withholdingTaxFixedAmountRadioButton.AutoSize = true;
            this.withholdingTaxFixedAmountRadioButton.Location = new System.Drawing.Point(307, 113);
            this.withholdingTaxFixedAmountRadioButton.Name = "withholdingTaxFixedAmountRadioButton";
            this.withholdingTaxFixedAmountRadioButton.Size = new System.Drawing.Size(91, 17);
            this.withholdingTaxFixedAmountRadioButton.TabIndex = 87;
            this.withholdingTaxFixedAmountRadioButton.TabStop = true;
            this.withholdingTaxFixedAmountRadioButton.Text = "Fixed Amount";
            this.withholdingTaxFixedAmountRadioButton.UseVisualStyleBackColor = true;
            this.withholdingTaxFixedAmountRadioButton.Visible = false;
            this.withholdingTaxFixedAmountRadioButton.CheckedChanged += new System.EventHandler(this.withholdingTaxFixedAmountRadioButton_CheckedChanged);
            // 
            // withholdingTaxFixedAmountTextBox
            // 
            this.withholdingTaxFixedAmountTextBox.Location = new System.Drawing.Point(402, 113);
            this.withholdingTaxFixedAmountTextBox.Name = "withholdingTaxFixedAmountTextBox";
            this.withholdingTaxFixedAmountTextBox.Size = new System.Drawing.Size(75, 21);
            this.withholdingTaxFixedAmountTextBox.TabIndex = 86;
            this.withholdingTaxFixedAmountTextBox.Visible = false;
            // 
            // withholdingTaxCheckBox
            // 
            this.withholdingTaxCheckBox.AutoSize = true;
            this.withholdingTaxCheckBox.Location = new System.Drawing.Point(307, 91);
            this.withholdingTaxCheckBox.Name = "withholdingTaxCheckBox";
            this.withholdingTaxCheckBox.Size = new System.Drawing.Size(103, 17);
            this.withholdingTaxCheckBox.TabIndex = 84;
            this.withholdingTaxCheckBox.Text = "Withholding Tax";
            this.withholdingTaxCheckBox.UseVisualStyleBackColor = true;
            this.withholdingTaxCheckBox.CheckedChanged += new System.EventHandler(this.withholdingTaxCheckBox_CheckedChanged);
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(48, 44);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(45, 13);
            this.label96.TabIndex = 83;
            this.label96.Text = "Level *:";
            // 
            // cboBand
            // 
            this.cboBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBand.FormattingEnabled = true;
            this.cboBand.Location = new System.Drawing.Point(96, 39);
            this.cboBand.Name = "cboBand";
            this.cboBand.Size = new System.Drawing.Size(135, 21);
            this.cboBand.TabIndex = 82;
            this.cboBand.DropDown += new System.EventHandler(this.cboBand_DropDown);
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.Transparent;
            this.label72.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label72.Location = new System.Drawing.Point(276, 68);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(28, 13);
            this.label72.TabIndex = 81;
            this.label72.Text = "TIN:";
            // 
            // incomeCheckBox
            // 
            this.incomeCheckBox.AutoSize = true;
            this.incomeCheckBox.Checked = true;
            this.incomeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.incomeCheckBox.ForeColor = System.Drawing.Color.Black;
            this.incomeCheckBox.Location = new System.Drawing.Point(95, 113);
            this.incomeCheckBox.Name = "incomeCheckBox";
            this.incomeCheckBox.Size = new System.Drawing.Size(82, 17);
            this.incomeCheckBox.TabIndex = 77;
            this.incomeCheckBox.Text = "Income Tax";
            this.incomeCheckBox.UseVisualStyleBackColor = true;
            // 
            // gradeCategoryComboBox
            // 
            this.gradeCategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeCategoryComboBox.FormattingEnabled = true;
            this.gradeCategoryComboBox.Location = new System.Drawing.Point(96, 14);
            this.gradeCategoryComboBox.Name = "gradeCategoryComboBox";
            this.gradeCategoryComboBox.Size = new System.Drawing.Size(136, 21);
            this.gradeCategoryComboBox.TabIndex = 64;
            this.gradeCategoryComboBox.SelectionChangeCommitted += new System.EventHandler(this.gradeCategoryComboBox_SelectionChangeCommitted);
            this.gradeCategoryComboBox.DropDown += new System.EventHandler(this.gradeCategoryComboBox_DropDown);
            // 
            // txtTIN
            // 
            this.txtTIN.BackColor = System.Drawing.Color.White;
            this.txtTIN.Location = new System.Drawing.Point(307, 63);
            this.txtTIN.Name = "txtTIN";
            this.txtTIN.Size = new System.Drawing.Size(136, 21);
            this.txtTIN.TabIndex = 80;
            // 
            // ssnitNoLabel
            // 
            this.ssnitNoLabel.AutoSize = true;
            this.ssnitNoLabel.BackColor = System.Drawing.Color.Transparent;
            this.ssnitNoLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ssnitNoLabel.Location = new System.Drawing.Point(44, 185);
            this.ssnitNoLabel.Name = "ssnitNoLabel";
            this.ssnitNoLabel.Size = new System.Drawing.Size(46, 13);
            this.ssnitNoLabel.TabIndex = 78;
            this.ssnitNoLabel.Text = "SSN No:";
            this.ssnitNoLabel.Visible = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(-1, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 13);
            this.label21.TabIndex = 67;
            this.label21.Text = "Grade Category*:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(230, 44);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(74, 13);
            this.label31.TabIndex = 73;
            this.label31.Text = "Basic Salary*:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(7, 90);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 13);
            this.label27.TabIndex = 79;
            this.label27.Text = "Payment Type*:";
            // 
            // ssnitNoTextBox
            // 
            this.ssnitNoTextBox.BackColor = System.Drawing.Color.White;
            this.ssnitNoTextBox.Location = new System.Drawing.Point(94, 180);
            this.ssnitNoTextBox.Name = "ssnitNoTextBox";
            this.ssnitNoTextBox.Size = new System.Drawing.Size(136, 21);
            this.ssnitNoTextBox.TabIndex = 76;
            this.ssnitNoTextBox.Visible = false;
            // 
            // paymentTypeComboBox
            // 
            this.paymentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.paymentTypeComboBox.FormattingEnabled = true;
            this.paymentTypeComboBox.Location = new System.Drawing.Point(96, 86);
            this.paymentTypeComboBox.Name = "paymentTypeComboBox";
            this.paymentTypeComboBox.Size = new System.Drawing.Size(137, 21);
            this.paymentTypeComboBox.TabIndex = 74;
            this.paymentTypeComboBox.DropDown += new System.EventHandler(this.paymentTypeComboBox_DropDown);
            // 
            // cboStep
            // 
            this.cboStep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStep.FormattingEnabled = true;
            this.cboStep.Location = new System.Drawing.Point(96, 62);
            this.cboStep.Name = "cboStep";
            this.cboStep.Size = new System.Drawing.Size(135, 21);
            this.cboStep.TabIndex = 70;
            this.cboStep.SelectedIndexChanged += new System.EventHandler(this.cboStep_SelectedIndexChanged);
            this.cboStep.DropDown += new System.EventHandler(this.cboStep_DropDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(54, 66);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 72;
            this.label30.Text = "Step*:";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(307, 40);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(103, 21);
            this.txtSalary.TabIndex = 68;
            this.txtSalary.Text = "0";
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(307, 16);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(168, 21);
            this.gradeComboBox.TabIndex = 65;
            this.gradeComboBox.SelectionChangeCommitted += new System.EventHandler(this.gradeComboBox_SelectionChangeCommitted);
            this.gradeComboBox.DropDown += new System.EventHandler(this.gradeComboBox_DropDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(254, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 13);
            this.label20.TabIndex = 66;
            this.label20.Text = "Grade*:";
            // 
            // ssnitCheckBox
            // 
            this.ssnitCheckBox.AutoSize = true;
            this.ssnitCheckBox.Checked = true;
            this.ssnitCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ssnitCheckBox.ForeColor = System.Drawing.Color.Black;
            this.ssnitCheckBox.Location = new System.Drawing.Point(95, 159);
            this.ssnitCheckBox.Name = "ssnitCheckBox";
            this.ssnitCheckBox.Size = new System.Drawing.Size(55, 17);
            this.ssnitCheckBox.TabIndex = 75;
            this.ssnitCheckBox.Text = "SSNIT";
            this.ssnitCheckBox.UseVisualStyleBackColor = true;
            this.ssnitCheckBox.CheckedChanged += new System.EventHandler(this.ssnitCheckBox_CheckedChanged);
            // 
            // UserAccountTabPage
            // 
            this.UserAccountTabPage.BackColor = System.Drawing.Color.Lavender;
            this.UserAccountTabPage.Controls.Add(this.panel1);
            this.UserAccountTabPage.Controls.Add(this.userGroupBox);
            this.UserAccountTabPage.Location = new System.Drawing.Point(4, 22);
            this.UserAccountTabPage.Name = "UserAccountTabPage";
            this.UserAccountTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.UserAccountTabPage.Size = new System.Drawing.Size(1026, 222);
            this.UserAccountTabPage.TabIndex = 1;
            this.UserAccountTabPage.Text = "User Account";
            this.UserAccountTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.groupBox7);
            this.panel1.Location = new System.Drawing.Point(585, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 202);
            this.panel1.TabIndex = 42;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.notVerifiedPictureBox);
            this.groupBox7.Controls.Add(this.verifiedPictureBox);
            this.groupBox7.Controls.Add(this.fingerPrintPictureBox);
            this.groupBox7.Location = new System.Drawing.Point(87, 19);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(178, 177);
            this.groupBox7.TabIndex = 38;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Finger Print";
            this.groupBox7.Visible = false;
            // 
            // notVerifiedPictureBox
            // 
            this.notVerifiedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("notVerifiedPictureBox.Image")));
            this.notVerifiedPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("notVerifiedPictureBox.InitialImage")));
            this.notVerifiedPictureBox.Location = new System.Drawing.Point(138, 116);
            this.notVerifiedPictureBox.Name = "notVerifiedPictureBox";
            this.notVerifiedPictureBox.Size = new System.Drawing.Size(33, 33);
            this.notVerifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.notVerifiedPictureBox.TabIndex = 40;
            this.notVerifiedPictureBox.TabStop = false;
            // 
            // verifiedPictureBox
            // 
            this.verifiedPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("verifiedPictureBox.Image")));
            this.verifiedPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("verifiedPictureBox.InitialImage")));
            this.verifiedPictureBox.Location = new System.Drawing.Point(138, 116);
            this.verifiedPictureBox.Name = "verifiedPictureBox";
            this.verifiedPictureBox.Size = new System.Drawing.Size(33, 32);
            this.verifiedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.verifiedPictureBox.TabIndex = 39;
            this.verifiedPictureBox.TabStop = false;
            this.verifiedPictureBox.Visible = false;
            // 
            // fingerPrintPictureBox
            // 
            this.fingerPrintPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fingerPrintPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("fingerPrintPictureBox.Image")));
            this.fingerPrintPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("fingerPrintPictureBox.InitialImage")));
            this.fingerPrintPictureBox.Location = new System.Drawing.Point(9, 18);
            this.fingerPrintPictureBox.Name = "fingerPrintPictureBox";
            this.fingerPrintPictureBox.Size = new System.Drawing.Size(123, 131);
            this.fingerPrintPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fingerPrintPictureBox.TabIndex = 20;
            this.fingerPrintPictureBox.TabStop = false;
            // 
            // userGroupBox
            // 
            this.userGroupBox.Controls.Add(this.label26);
            this.userGroupBox.Controls.Add(this.fingerPrintTextBox);
            this.userGroupBox.Controls.Add(this.label25);
            this.userGroupBox.Controls.Add(this.passwordTextBox);
            this.userGroupBox.Controls.Add(this.userRoleComboBox);
            this.userGroupBox.Controls.Add(this.label24);
            this.userGroupBox.Controls.Add(this.label23);
            this.userGroupBox.Controls.Add(this.confirmPasswordTextBox);
            this.userGroupBox.Controls.Add(this.label22);
            this.userGroupBox.Controls.Add(this.userNameTextBox);
            this.userGroupBox.Controls.Add(this.button7);
            this.userGroupBox.Location = new System.Drawing.Point(156, 6);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(408, 210);
            this.userGroupBox.TabIndex = 40;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "User Account";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(23, 191);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 13);
            this.label26.TabIndex = 40;
            this.label26.Text = "Finger Print ID:";
            // 
            // fingerPrintTextBox
            // 
            this.fingerPrintTextBox.BackColor = System.Drawing.Color.White;
            this.fingerPrintTextBox.Location = new System.Drawing.Point(109, 183);
            this.fingerPrintTextBox.Name = "fingerPrintTextBox";
            this.fingerPrintTextBox.ReadOnly = true;
            this.fingerPrintTextBox.Size = new System.Drawing.Size(183, 21);
            this.fingerPrintTextBox.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(6, 111);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(97, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "Confirm Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.White;
            this.passwordTextBox.Location = new System.Drawing.Point(109, 67);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(183, 21);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // userRoleComboBox
            // 
            this.userRoleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userRoleComboBox.FormattingEnabled = true;
            this.userRoleComboBox.Location = new System.Drawing.Point(109, 145);
            this.userRoleComboBox.Name = "userRoleComboBox";
            this.userRoleComboBox.Size = new System.Drawing.Size(183, 21);
            this.userRoleComboBox.TabIndex = 3;
            this.userRoleComboBox.DropDown += new System.EventHandler(this.userRoleComboBox_DropDown);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(71, 153);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 13);
            this.label24.TabIndex = 9;
            this.label24.Text = "Role:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(46, 75);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(57, 13);
            this.label23.TabIndex = 8;
            this.label23.Text = "Password:";
            // 
            // confirmPasswordTextBox
            // 
            this.confirmPasswordTextBox.BackColor = System.Drawing.Color.White;
            this.confirmPasswordTextBox.Location = new System.Drawing.Point(109, 103);
            this.confirmPasswordTextBox.Name = "confirmPasswordTextBox";
            this.confirmPasswordTextBox.Size = new System.Drawing.Size(183, 21);
            this.confirmPasswordTextBox.TabIndex = 2;
            this.confirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(40, 30);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(63, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "User Name:";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.BackColor = System.Drawing.Color.White;
            this.userNameTextBox.Location = new System.Drawing.Point(109, 22);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(183, 21);
            this.userNameTextBox.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(298, 143);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(30, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dependentsTabPage
            // 
            this.dependentsTabPage.BackColor = System.Drawing.Color.Lavender;
            this.dependentsTabPage.Controls.Add(this.groupBox22);
            this.dependentsTabPage.Controls.Add(this.panel3);
            this.dependentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.dependentsTabPage.Name = "dependentsTabPage";
            this.dependentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dependentsTabPage.Size = new System.Drawing.Size(1026, 222);
            this.dependentsTabPage.TabIndex = 13;
            this.dependentsTabPage.Text = "Family Details";
            this.dependentsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.panel13);
            this.groupBox22.Controls.Add(this.groupBox17);
            this.groupBox22.Location = new System.Drawing.Point(-11, 0);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(1037, 283);
            this.groupBox22.TabIndex = 44;
            this.groupBox22.TabStop = false;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.SlateGray;
            this.panel13.Controls.Add(this.btnRefreshRelations);
            this.panel13.Controls.Add(this.btnFamilyDetailsRemove);
            this.panel13.Controls.Add(this.btnClearFamilyDetails);
            this.panel13.Controls.Add(this.btnSaveFamilyDetails);
            this.panel13.Location = new System.Drawing.Point(928, 74);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(89, 127);
            this.panel13.TabIndex = 15;
            // 
            // btnRefreshRelations
            // 
            this.btnRefreshRelations.Location = new System.Drawing.Point(8, 100);
            this.btnRefreshRelations.Name = "btnRefreshRelations";
            this.btnRefreshRelations.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshRelations.TabIndex = 3;
            this.btnRefreshRelations.Text = "Refresh";
            this.btnRefreshRelations.UseVisualStyleBackColor = true;
            this.btnRefreshRelations.Click += new System.EventHandler(this.btnRefreshRelations_Click);
            // 
            // btnFamilyDetailsRemove
            // 
            this.btnFamilyDetailsRemove.Location = new System.Drawing.Point(8, 48);
            this.btnFamilyDetailsRemove.Name = "btnFamilyDetailsRemove";
            this.btnFamilyDetailsRemove.Size = new System.Drawing.Size(75, 23);
            this.btnFamilyDetailsRemove.TabIndex = 2;
            this.btnFamilyDetailsRemove.Text = "Remove";
            this.btnFamilyDetailsRemove.UseVisualStyleBackColor = true;
            this.btnFamilyDetailsRemove.Click += new System.EventHandler(this.btnFamilyDetailsRemove_Click);
            // 
            // btnClearFamilyDetails
            // 
            this.btnClearFamilyDetails.Location = new System.Drawing.Point(8, 74);
            this.btnClearFamilyDetails.Name = "btnClearFamilyDetails";
            this.btnClearFamilyDetails.Size = new System.Drawing.Size(75, 23);
            this.btnClearFamilyDetails.TabIndex = 1;
            this.btnClearFamilyDetails.Text = "Clear";
            this.btnClearFamilyDetails.UseVisualStyleBackColor = true;
            this.btnClearFamilyDetails.Click += new System.EventHandler(this.btnClearFamilyDetails_Click);
            // 
            // btnSaveFamilyDetails
            // 
            this.btnSaveFamilyDetails.Location = new System.Drawing.Point(8, 23);
            this.btnSaveFamilyDetails.Name = "btnSaveFamilyDetails";
            this.btnSaveFamilyDetails.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFamilyDetails.TabIndex = 0;
            this.btnSaveFamilyDetails.Text = "Save";
            this.btnSaveFamilyDetails.UseVisualStyleBackColor = true;
            this.btnSaveFamilyDetails.Click += new System.EventHandler(this.btnSaveFamilyDetails_Click);
            // 
            // groupBox17
            // 
            this.groupBox17.BackColor = System.Drawing.Color.Transparent;
            this.groupBox17.Controls.Add(this.gridRelations);
            this.groupBox17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox17.ForeColor = System.Drawing.Color.Black;
            this.groupBox17.Location = new System.Drawing.Point(27, 10);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(895, 206);
            this.groupBox17.TabIndex = 4;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Spouse/Parents/Next of Kin";
            // 
            // gridRelations
            // 
            this.gridRelations.AllowUserToOrderColumns = true;
            this.gridRelations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRelations.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridRelations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relationID,
            this.relationName,
            this.relationOccupationID,
            this.relationRelationshipID,
            this.relationRelationship,
            this.relationType,
            this.relationOccupation,
            this.relationDOB,
            this.relationPOB,
            this.relationPOBID,
            this.relationTelephone,
            this.relationAddress});
            this.gridRelations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRelations.GridColor = System.Drawing.Color.Gainsboro;
            this.gridRelations.Location = new System.Drawing.Point(3, 17);
            this.gridRelations.Name = "gridRelations";
            this.gridRelations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRelations.Size = new System.Drawing.Size(889, 186);
            this.gridRelations.TabIndex = 0;
            this.gridRelations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRelations_CellClick);
            this.gridRelations.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridRelations_EditingControlShowing);
            this.gridRelations.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridRelations_DataError);
            // 
            // relationID
            // 
            this.relationID.HeaderText = "ID";
            this.relationID.Name = "relationID";
            this.relationID.Visible = false;
            // 
            // relationName
            // 
            this.relationName.DataPropertyName = "Name";
            this.relationName.HeaderText = "Name";
            this.relationName.Name = "relationName";
            this.relationName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // relationOccupationID
            // 
            this.relationOccupationID.HeaderText = "OccupationID";
            this.relationOccupationID.Name = "relationOccupationID";
            this.relationOccupationID.ReadOnly = true;
            this.relationOccupationID.Visible = false;
            // 
            // relationRelationshipID
            // 
            this.relationRelationshipID.HeaderText = "RelationshipID";
            this.relationRelationshipID.Name = "relationRelationshipID";
            this.relationRelationshipID.ReadOnly = true;
            this.relationRelationshipID.Visible = false;
            // 
            // relationRelationship
            // 
            this.relationRelationship.HeaderText = "Relationship";
            this.relationRelationship.Name = "relationRelationship";
            // 
            // relationType
            // 
            this.relationType.HeaderText = "Type";
            this.relationType.Items.AddRange(new object[] {
            "NEXT OF KIN",
            "EMERGENCY CONTACT PERSON",
            "OTHERS"});
            this.relationType.Name = "relationType";
            // 
            // relationOccupation
            // 
            this.relationOccupation.HeaderText = "Occupation";
            this.relationOccupation.Name = "relationOccupation";
            this.relationOccupation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.relationOccupation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // relationDOB
            // 
            this.relationDOB.HeaderText = "DOB";
            this.relationDOB.Name = "relationDOB";
            this.relationDOB.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.relationDOB.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // relationPOB
            // 
            this.relationPOB.HeaderText = "Place Of Birth";
            this.relationPOB.Name = "relationPOB";
            // 
            // relationPOBID
            // 
            this.relationPOBID.HeaderText = "POBID";
            this.relationPOBID.Name = "relationPOBID";
            this.relationPOBID.Visible = false;
            // 
            // relationTelephone
            // 
            this.relationTelephone.DataPropertyName = "Telephone";
            this.relationTelephone.HeaderText = "Telephone";
            this.relationTelephone.Name = "relationTelephone";
            // 
            // relationAddress
            // 
            this.relationAddress.DataPropertyName = "Address";
            this.relationAddress.HeaderText = "Address";
            this.relationAddress.Name = "relationAddress";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SlateGray;
            this.panel3.Controls.Add(this.button21);
            this.panel3.Controls.Add(this.button23);
            this.panel3.Location = new System.Drawing.Point(1043, 152);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(97, 95);
            this.panel3.TabIndex = 43;
            // 
            // button21
            // 
            this.button21.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button21.ForeColor = System.Drawing.Color.Black;
            this.button21.Location = new System.Drawing.Point(8, 13);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(69, 23);
            this.button21.TabIndex = 23;
            this.button21.Text = "Save";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button23
            // 
            this.button23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button23.ForeColor = System.Drawing.Color.Black;
            this.button23.Location = new System.Drawing.Point(8, 51);
            this.button23.Name = "button23";
            this.button23.Size = new System.Drawing.Size(69, 23);
            this.button23.TabIndex = 21;
            this.button23.Text = "Clear";
            this.button23.UseVisualStyleBackColor = true;
            // 
            // LanguageTabPage
            // 
            this.LanguageTabPage.BackColor = System.Drawing.Color.Lavender;
            this.LanguageTabPage.Controls.Add(this.groupBox12);
            this.LanguageTabPage.Location = new System.Drawing.Point(4, 22);
            this.LanguageTabPage.Name = "LanguageTabPage";
            this.LanguageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.LanguageTabPage.Size = new System.Drawing.Size(1026, 222);
            this.LanguageTabPage.TabIndex = 3;
            this.LanguageTabPage.Text = "Language";
            this.LanguageTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.panel12);
            this.groupBox12.Controls.Add(this.gridLanguage);
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(1026, 287);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.SlateGray;
            this.panel12.Controls.Add(this.btnRefreshLanguages);
            this.panel12.Controls.Add(this.btnLanguageRemove);
            this.panel12.Controls.Add(this.btnClearLanguage);
            this.panel12.Controls.Add(this.btnSaveLanguage);
            this.panel12.Location = new System.Drawing.Point(748, 35);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(102, 114);
            this.panel12.TabIndex = 1;
            // 
            // btnRefreshLanguages
            // 
            this.btnRefreshLanguages.Location = new System.Drawing.Point(12, 81);
            this.btnRefreshLanguages.Name = "btnRefreshLanguages";
            this.btnRefreshLanguages.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshLanguages.TabIndex = 4;
            this.btnRefreshLanguages.Text = "Refresh";
            this.btnRefreshLanguages.UseVisualStyleBackColor = true;
            this.btnRefreshLanguages.Click += new System.EventHandler(this.btnRefreshLanguages_Click);
            // 
            // btnLanguageRemove
            // 
            this.btnLanguageRemove.Location = new System.Drawing.Point(12, 34);
            this.btnLanguageRemove.Name = "btnLanguageRemove";
            this.btnLanguageRemove.Size = new System.Drawing.Size(75, 23);
            this.btnLanguageRemove.TabIndex = 2;
            this.btnLanguageRemove.Text = "Remove";
            this.btnLanguageRemove.UseVisualStyleBackColor = true;
            this.btnLanguageRemove.Click += new System.EventHandler(this.btnLanguageRemove_Click);
            // 
            // btnClearLanguage
            // 
            this.btnClearLanguage.Location = new System.Drawing.Point(12, 58);
            this.btnClearLanguage.Name = "btnClearLanguage";
            this.btnClearLanguage.Size = new System.Drawing.Size(75, 23);
            this.btnClearLanguage.TabIndex = 1;
            this.btnClearLanguage.Text = "Clear";
            this.btnClearLanguage.UseVisualStyleBackColor = true;
            this.btnClearLanguage.Click += new System.EventHandler(this.btnClearLanguage_Click);
            // 
            // btnSaveLanguage
            // 
            this.btnSaveLanguage.Location = new System.Drawing.Point(12, 11);
            this.btnSaveLanguage.Name = "btnSaveLanguage";
            this.btnSaveLanguage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLanguage.TabIndex = 0;
            this.btnSaveLanguage.Text = "Save";
            this.btnSaveLanguage.UseVisualStyleBackColor = true;
            this.btnSaveLanguage.Click += new System.EventHandler(this.btnSaveLanguage_Click);
            // 
            // gridLanguage
            // 
            this.gridLanguage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLanguage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridLanguageID,
            this.colLanguage,
            this.colLanguageLevel,
            this.colLanguageID});
            this.gridLanguage.Location = new System.Drawing.Point(177, 29);
            this.gridLanguage.Name = "gridLanguage";
            this.gridLanguage.Size = new System.Drawing.Size(541, 141);
            this.gridLanguage.TabIndex = 0;
            this.gridLanguage.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridLanguage_CellClick);
            // 
            // gridLanguageID
            // 
            this.gridLanguageID.HeaderText = "ID";
            this.gridLanguageID.Name = "gridLanguageID";
            this.gridLanguageID.Visible = false;
            // 
            // colLanguage
            // 
            this.colLanguage.HeaderText = "Language";
            this.colLanguage.Name = "colLanguage";
            this.colLanguage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colLanguage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colLanguage.Width = 300;
            // 
            // colLanguageLevel
            // 
            this.colLanguageLevel.HeaderText = "Proficiency Level";
            this.colLanguageLevel.Items.AddRange(new object[] {
            "Beginner",
            "Elementary",
            "Intermediate",
            "Proficient"});
            this.colLanguageLevel.Name = "colLanguageLevel";
            this.colLanguageLevel.Width = 200;
            // 
            // colLanguageID
            // 
            this.colLanguageID.HeaderText = "LanguageID";
            this.colLanguageID.Name = "colLanguageID";
            this.colLanguageID.Visible = false;
            // 
            // proffessionHistoryTabPage
            // 
            this.proffessionHistoryTabPage.BackColor = System.Drawing.Color.Lavender;
            this.proffessionHistoryTabPage.Controls.Add(this.panel11);
            this.proffessionHistoryTabPage.Controls.Add(this.panel8);
            this.proffessionHistoryTabPage.Controls.Add(this.groupBox4);
            this.proffessionHistoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.proffessionHistoryTabPage.Name = "proffessionHistoryTabPage";
            this.proffessionHistoryTabPage.Size = new System.Drawing.Size(1026, 222);
            this.proffessionHistoryTabPage.TabIndex = 15;
            this.proffessionHistoryTabPage.Text = "Profession History";
            this.proffessionHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.SlateGray;
            this.panel11.Controls.Add(this.btnRefreshProfessionHistory);
            this.panel11.Controls.Add(this.btnProfessionHistoryRemove);
            this.panel11.Controls.Add(this.btnClearProfessionHistory);
            this.panel11.Controls.Add(this.btnSaveProfessionHistory);
            this.panel11.Location = new System.Drawing.Point(788, 38);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(100, 121);
            this.panel11.TabIndex = 46;
            // 
            // btnRefreshProfessionHistory
            // 
            this.btnRefreshProfessionHistory.Location = new System.Drawing.Point(12, 88);
            this.btnRefreshProfessionHistory.Name = "btnRefreshProfessionHistory";
            this.btnRefreshProfessionHistory.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshProfessionHistory.TabIndex = 4;
            this.btnRefreshProfessionHistory.Text = "Refresh";
            this.btnRefreshProfessionHistory.UseVisualStyleBackColor = true;
            this.btnRefreshProfessionHistory.Click += new System.EventHandler(this.btnRefreshProfessionHistory_Click);
            // 
            // btnProfessionHistoryRemove
            // 
            this.btnProfessionHistoryRemove.Location = new System.Drawing.Point(12, 41);
            this.btnProfessionHistoryRemove.Name = "btnProfessionHistoryRemove";
            this.btnProfessionHistoryRemove.Size = new System.Drawing.Size(75, 23);
            this.btnProfessionHistoryRemove.TabIndex = 2;
            this.btnProfessionHistoryRemove.Text = "Remove";
            this.btnProfessionHistoryRemove.UseVisualStyleBackColor = true;
            this.btnProfessionHistoryRemove.Click += new System.EventHandler(this.btnProfessionHistoryRemove_Click);
            // 
            // btnClearProfessionHistory
            // 
            this.btnClearProfessionHistory.Location = new System.Drawing.Point(12, 64);
            this.btnClearProfessionHistory.Name = "btnClearProfessionHistory";
            this.btnClearProfessionHistory.Size = new System.Drawing.Size(75, 23);
            this.btnClearProfessionHistory.TabIndex = 1;
            this.btnClearProfessionHistory.Text = "Clear";
            this.btnClearProfessionHistory.UseVisualStyleBackColor = true;
            this.btnClearProfessionHistory.Click += new System.EventHandler(this.btnClearProfessionHistory_Click);
            // 
            // btnSaveProfessionHistory
            // 
            this.btnSaveProfessionHistory.Location = new System.Drawing.Point(12, 18);
            this.btnSaveProfessionHistory.Name = "btnSaveProfessionHistory";
            this.btnSaveProfessionHistory.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProfessionHistory.TabIndex = 0;
            this.btnSaveProfessionHistory.Text = "Save";
            this.btnSaveProfessionHistory.UseVisualStyleBackColor = true;
            this.btnSaveProfessionHistory.Click += new System.EventHandler(this.btnSaveProfessionHistory_Click);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.SlateGray;
            this.panel8.Controls.Add(this.button17);
            this.panel8.Controls.Add(this.button18);
            this.panel8.Location = new System.Drawing.Point(815, 303);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(99, 108);
            this.panel8.TabIndex = 45;
            // 
            // button17
            // 
            this.button17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button17.ForeColor = System.Drawing.Color.Black;
            this.button17.Location = new System.Drawing.Point(15, 28);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(69, 23);
            this.button17.TabIndex = 23;
            this.button17.Text = "Save";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button18.ForeColor = System.Drawing.Color.Black;
            this.button18.Location = new System.Drawing.Point(15, 57);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(69, 23);
            this.button18.TabIndex = 21;
            this.button18.Text = "Clear";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.gridProfession);
            this.groupBox4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(168, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(591, 211);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Profession";
            // 
            // gridProfession
            // 
            this.gridProfession.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridProfession.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProfession.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.professionID,
            this.professionNameOfProfession,
            this.professionFromMonth,
            this.professionFromYear,
            this.professionToMonth,
            this.professionToYear});
            this.gridProfession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProfession.GridColor = System.Drawing.Color.Gainsboro;
            this.gridProfession.Location = new System.Drawing.Point(3, 17);
            this.gridProfession.Name = "gridProfession";
            this.gridProfession.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProfession.Size = new System.Drawing.Size(585, 191);
            this.gridProfession.TabIndex = 0;
            this.gridProfession.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProfession_CellClick);
            // 
            // professionID
            // 
            this.professionID.HeaderText = "ID";
            this.professionID.Name = "professionID";
            this.professionID.Visible = false;
            // 
            // professionNameOfProfession
            // 
            this.professionNameOfProfession.DataPropertyName = "NameOfProfession";
            this.professionNameOfProfession.HeaderText = "Name of Profession";
            this.professionNameOfProfession.Name = "professionNameOfProfession";
            this.professionNameOfProfession.Width = 220;
            // 
            // professionFromMonth
            // 
            this.professionFromMonth.HeaderText = "From (Month)";
            this.professionFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.professionFromMonth.Name = "professionFromMonth";
            this.professionFromMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.professionFromMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.professionFromMonth.Width = 80;
            // 
            // professionFromYear
            // 
            this.professionFromYear.DataPropertyName = "From";
            this.professionFromYear.HeaderText = "From (Year)";
            this.professionFromYear.Name = "professionFromYear";
            this.professionFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.professionFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.professionFromYear.Width = 80;
            // 
            // professionToMonth
            // 
            this.professionToMonth.HeaderText = "To (Month)";
            this.professionToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.professionToMonth.Name = "professionToMonth";
            this.professionToMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.professionToMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.professionToMonth.Width = 80;
            // 
            // professionToYear
            // 
            this.professionToYear.DataPropertyName = "To";
            this.professionToYear.HeaderText = "To (Year)";
            this.professionToYear.Name = "professionToYear";
            this.professionToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.professionToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.professionToYear.Width = 80;
            // 
            // employmentTabPage
            // 
            this.employmentTabPage.Controls.Add(this.panel4);
            this.employmentTabPage.Controls.Add(this.groupBox5);
            this.employmentTabPage.Location = new System.Drawing.Point(4, 22);
            this.employmentTabPage.Name = "employmentTabPage";
            this.employmentTabPage.Size = new System.Drawing.Size(1026, 222);
            this.employmentTabPage.TabIndex = 8;
            this.employmentTabPage.Text = "Employment History";
            this.employmentTabPage.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SlateGray;
            this.panel4.Controls.Add(this.btnRefreshEmploymentHistory);
            this.panel4.Controls.Add(this.btnEmploymentHistoryRemove);
            this.panel4.Controls.Add(this.btnSaveEmploymentHistory);
            this.panel4.Controls.Add(this.btnClearEmploymentHistory);
            this.panel4.Location = new System.Drawing.Point(929, 83);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(95, 114);
            this.panel4.TabIndex = 46;
            // 
            // btnRefreshEmploymentHistory
            // 
            this.btnRefreshEmploymentHistory.Location = new System.Drawing.Point(9, 83);
            this.btnRefreshEmploymentHistory.Name = "btnRefreshEmploymentHistory";
            this.btnRefreshEmploymentHistory.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshEmploymentHistory.TabIndex = 25;
            this.btnRefreshEmploymentHistory.Text = "Refresh";
            this.btnRefreshEmploymentHistory.UseVisualStyleBackColor = true;
            this.btnRefreshEmploymentHistory.Click += new System.EventHandler(this.btnRefreshEmploymentHistory_Click);
            // 
            // btnEmploymentHistoryRemove
            // 
            this.btnEmploymentHistoryRemove.Location = new System.Drawing.Point(9, 35);
            this.btnEmploymentHistoryRemove.Name = "btnEmploymentHistoryRemove";
            this.btnEmploymentHistoryRemove.Size = new System.Drawing.Size(75, 23);
            this.btnEmploymentHistoryRemove.TabIndex = 24;
            this.btnEmploymentHistoryRemove.Text = "Remove";
            this.btnEmploymentHistoryRemove.UseVisualStyleBackColor = true;
            this.btnEmploymentHistoryRemove.Click += new System.EventHandler(this.btnEmploymentHistoryRemove_Click);
            // 
            // btnSaveEmploymentHistory
            // 
            this.btnSaveEmploymentHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEmploymentHistory.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEmploymentHistory.Location = new System.Drawing.Point(9, 12);
            this.btnSaveEmploymentHistory.Name = "btnSaveEmploymentHistory";
            this.btnSaveEmploymentHistory.Size = new System.Drawing.Size(76, 23);
            this.btnSaveEmploymentHistory.TabIndex = 23;
            this.btnSaveEmploymentHistory.Text = "Save";
            this.btnSaveEmploymentHistory.UseVisualStyleBackColor = true;
            this.btnSaveEmploymentHistory.Click += new System.EventHandler(this.btnSaveEmploymentHistory_Click);
            // 
            // btnClearEmploymentHistory
            // 
            this.btnClearEmploymentHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearEmploymentHistory.ForeColor = System.Drawing.Color.Black;
            this.btnClearEmploymentHistory.Location = new System.Drawing.Point(9, 59);
            this.btnClearEmploymentHistory.Name = "btnClearEmploymentHistory";
            this.btnClearEmploymentHistory.Size = new System.Drawing.Size(76, 23);
            this.btnClearEmploymentHistory.TabIndex = 21;
            this.btnClearEmploymentHistory.Text = "Clear";
            this.btnClearEmploymentHistory.UseVisualStyleBackColor = true;
            this.btnClearEmploymentHistory.Click += new System.EventHandler(this.btnClearEmploymentHistory_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.gridEmploymentHistory);
            this.groupBox5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(4, -1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(922, 227);
            this.groupBox5.TabIndex = 45;
            this.groupBox5.TabStop = false;
            // 
            // gridEmploymentHistory
            // 
            this.gridEmploymentHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEmploymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmploymentHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.experienceID,
            this.experienceNameOfOrganisation,
            this.experienceJobTitle,
            this.experienceAnnualSalary,
            this.experienceFromMonth,
            this.experienceFromYear,
            this.experienceToMonth,
            this.experienceToYear,
            this.experienceReasonForLeaving});
            this.gridEmploymentHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmploymentHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEmploymentHistory.Location = new System.Drawing.Point(3, 17);
            this.gridEmploymentHistory.Name = "gridEmploymentHistory";
            this.gridEmploymentHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmploymentHistory.Size = new System.Drawing.Size(916, 207);
            this.gridEmploymentHistory.TabIndex = 0;
            this.gridEmploymentHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridExperience_CellClick);
            // 
            // experienceID
            // 
            this.experienceID.HeaderText = "ID";
            this.experienceID.Name = "experienceID";
            this.experienceID.Visible = false;
            // 
            // experienceNameOfOrganisation
            // 
            this.experienceNameOfOrganisation.DataPropertyName = "NameOfOrganisation";
            this.experienceNameOfOrganisation.HeaderText = "Name of Organisation";
            this.experienceNameOfOrganisation.Name = "experienceNameOfOrganisation";
            this.experienceNameOfOrganisation.Width = 184;
            // 
            // experienceJobTitle
            // 
            this.experienceJobTitle.DataPropertyName = "JobDescription";
            this.experienceJobTitle.HeaderText = "Job Title";
            this.experienceJobTitle.Name = "experienceJobTitle";
            this.experienceJobTitle.Width = 130;
            // 
            // experienceAnnualSalary
            // 
            this.experienceAnnualSalary.HeaderText = "Annual Salary";
            this.experienceAnnualSalary.Name = "experienceAnnualSalary";
            this.experienceAnnualSalary.Width = 50;
            // 
            // experienceFromMonth
            // 
            this.experienceFromMonth.HeaderText = "From (Month)";
            this.experienceFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.experienceFromMonth.Name = "experienceFromMonth";
            // 
            // experienceFromYear
            // 
            this.experienceFromYear.DataPropertyName = "From";
            this.experienceFromYear.HeaderText = "From (Year)";
            this.experienceFromYear.Name = "experienceFromYear";
            this.experienceFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceFromYear.Width = 89;
            // 
            // experienceToMonth
            // 
            this.experienceToMonth.HeaderText = "To (Month)";
            this.experienceToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.experienceToMonth.Name = "experienceToMonth";
            // 
            // experienceToYear
            // 
            this.experienceToYear.DataPropertyName = "To";
            this.experienceToYear.HeaderText = "To (Year)";
            this.experienceToYear.Name = "experienceToYear";
            this.experienceToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.experienceToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.experienceToYear.Width = 88;
            // 
            // experienceReasonForLeaving
            // 
            this.experienceReasonForLeaving.HeaderText = "Reason For Leaving";
            this.experienceReasonForLeaving.Name = "experienceReasonForLeaving";
            this.experienceReasonForLeaving.Width = 170;
            // 
            // educationHistoryTabPage
            // 
            this.educationHistoryTabPage.BackColor = System.Drawing.Color.Lavender;
            this.educationHistoryTabPage.Controls.Add(this.panel7);
            this.educationHistoryTabPage.Controls.Add(this.groupBox3);
            this.educationHistoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.educationHistoryTabPage.Name = "educationHistoryTabPage";
            this.educationHistoryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.educationHistoryTabPage.Size = new System.Drawing.Size(1026, 222);
            this.educationHistoryTabPage.TabIndex = 14;
            this.educationHistoryTabPage.Text = "Education History";
            this.educationHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.SlateGray;
            this.panel7.Controls.Add(this.btnRefreshEducationHistory);
            this.panel7.Controls.Add(this.btnEducationHistoryRemove);
            this.panel7.Controls.Add(this.btnSaveEducationHistory);
            this.panel7.Controls.Add(this.btnClearEducationHistory);
            this.panel7.Location = new System.Drawing.Point(912, 69);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(102, 108);
            this.panel7.TabIndex = 43;
            // 
            // btnRefreshEducationHistory
            // 
            this.btnRefreshEducationHistory.Location = new System.Drawing.Point(15, 80);
            this.btnRefreshEducationHistory.Name = "btnRefreshEducationHistory";
            this.btnRefreshEducationHistory.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshEducationHistory.TabIndex = 43;
            this.btnRefreshEducationHistory.Text = "Refresh";
            this.btnRefreshEducationHistory.UseVisualStyleBackColor = true;
            this.btnRefreshEducationHistory.Click += new System.EventHandler(this.btnRefreshEducationHistory_Click);
            // 
            // btnEducationHistoryRemove
            // 
            this.btnEducationHistoryRemove.Location = new System.Drawing.Point(15, 30);
            this.btnEducationHistoryRemove.Name = "btnEducationHistoryRemove";
            this.btnEducationHistoryRemove.Size = new System.Drawing.Size(75, 23);
            this.btnEducationHistoryRemove.TabIndex = 42;
            this.btnEducationHistoryRemove.Text = "Remove";
            this.btnEducationHistoryRemove.UseVisualStyleBackColor = true;
            this.btnEducationHistoryRemove.Click += new System.EventHandler(this.btnEducationHistoryRemove_Click);
            // 
            // btnSaveEducationHistory
            // 
            this.btnSaveEducationHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEducationHistory.ForeColor = System.Drawing.Color.Black;
            this.btnSaveEducationHistory.Location = new System.Drawing.Point(15, 6);
            this.btnSaveEducationHistory.Name = "btnSaveEducationHistory";
            this.btnSaveEducationHistory.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEducationHistory.TabIndex = 41;
            this.btnSaveEducationHistory.Text = "Save";
            this.btnSaveEducationHistory.UseVisualStyleBackColor = true;
            this.btnSaveEducationHistory.Click += new System.EventHandler(this.btnSaveEducationHistory_Click);
            // 
            // btnClearEducationHistory
            // 
            this.btnClearEducationHistory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearEducationHistory.ForeColor = System.Drawing.Color.Black;
            this.btnClearEducationHistory.Location = new System.Drawing.Point(15, 54);
            this.btnClearEducationHistory.Name = "btnClearEducationHistory";
            this.btnClearEducationHistory.Size = new System.Drawing.Size(75, 23);
            this.btnClearEducationHistory.TabIndex = 18;
            this.btnClearEducationHistory.Text = "Clear";
            this.btnClearEducationHistory.UseVisualStyleBackColor = true;
            this.btnClearEducationHistory.Click += new System.EventHandler(this.btnClearEducationHistory_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridEducationHistory);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(898, 210);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Education";
            // 
            // gridEducationHistory
            // 
            this.gridEducationHistory.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.gridEducationHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEducationHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.qualificationsID,
            this.qualificationsNameOfInstitution,
            this.qualificationsCertificateObtained,
            this.qualificationsFromMonth,
            this.qualificationsFromYear,
            this.qualificationsToMonth,
            this.qualificationsToYear});
            this.gridEducationHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEducationHistory.GridColor = System.Drawing.Color.Gainsboro;
            this.gridEducationHistory.Location = new System.Drawing.Point(3, 17);
            this.gridEducationHistory.Name = "gridEducationHistory";
            this.gridEducationHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEducationHistory.Size = new System.Drawing.Size(892, 190);
            this.gridEducationHistory.TabIndex = 0;
            this.gridEducationHistory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridQualification_CellClick);
            // 
            // qualificationsID
            // 
            this.qualificationsID.HeaderText = "ID";
            this.qualificationsID.Name = "qualificationsID";
            this.qualificationsID.Visible = false;
            // 
            // qualificationsNameOfInstitution
            // 
            this.qualificationsNameOfInstitution.DataPropertyName = "NameOfInstitution";
            this.qualificationsNameOfInstitution.HeaderText = "Name of Institution";
            this.qualificationsNameOfInstitution.Name = "qualificationsNameOfInstitution";
            this.qualificationsNameOfInstitution.Width = 280;
            // 
            // qualificationsCertificateObtained
            // 
            this.qualificationsCertificateObtained.DataPropertyName = "CertificateObtained";
            this.qualificationsCertificateObtained.HeaderText = "Certificate Obtained";
            this.qualificationsCertificateObtained.Name = "qualificationsCertificateObtained";
            this.qualificationsCertificateObtained.Width = 198;
            // 
            // qualificationsFromMonth
            // 
            this.qualificationsFromMonth.HeaderText = "From (Month)";
            this.qualificationsFromMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.qualificationsFromMonth.Name = "qualificationsFromMonth";
            this.qualificationsFromMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsFromMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qualificationsFromYear
            // 
            this.qualificationsFromYear.HeaderText = "From (Year)";
            this.qualificationsFromYear.Name = "qualificationsFromYear";
            this.qualificationsFromYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsFromYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsFromYear.Width = 90;
            // 
            // qualificationsToMonth
            // 
            this.qualificationsToMonth.HeaderText = "To (Month)";
            this.qualificationsToMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.qualificationsToMonth.Name = "qualificationsToMonth";
            this.qualificationsToMonth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsToMonth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qualificationsToYear
            // 
            this.qualificationsToYear.HeaderText = "To (Year)";
            this.qualificationsToYear.Name = "qualificationsToYear";
            this.qualificationsToYear.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.qualificationsToYear.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.qualificationsToYear.Width = 82;
            // 
            // documentsTabPage
            // 
            this.documentsTabPage.BackColor = System.Drawing.Color.Lavender;
            this.documentsTabPage.Controls.Add(this.panel6);
            this.documentsTabPage.Controls.Add(this.groupBox19);
            this.documentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.documentsTabPage.Name = "documentsTabPage";
            this.documentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.documentsTabPage.Size = new System.Drawing.Size(1026, 222);
            this.documentsTabPage.TabIndex = 12;
            this.documentsTabPage.Text = "Documents";
            this.documentsTabPage.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.SlateGray;
            this.panel6.Controls.Add(this.btnRefreshDocuments);
            this.panel6.Controls.Add(this.btnDocumentsRemove);
            this.panel6.Controls.Add(this.btnDocumentsClear);
            this.panel6.Controls.Add(this.btnDocumentsView);
            this.panel6.Controls.Add(this.btnDocumentsScan);
            this.panel6.Controls.Add(this.btnDocumentsSave);
            this.panel6.Controls.Add(this.btnDocumentsUpload);
            this.panel6.Location = new System.Drawing.Point(887, 14);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(102, 193);
            this.panel6.TabIndex = 44;
            // 
            // btnRefreshDocuments
            // 
            this.btnRefreshDocuments.Location = new System.Drawing.Point(16, 151);
            this.btnRefreshDocuments.Name = "btnRefreshDocuments";
            this.btnRefreshDocuments.Size = new System.Drawing.Size(70, 23);
            this.btnRefreshDocuments.TabIndex = 25;
            this.btnRefreshDocuments.Text = "Refresh";
            this.btnRefreshDocuments.UseVisualStyleBackColor = true;
            this.btnRefreshDocuments.Click += new System.EventHandler(this.btnRefreshDocuments_Click);
            // 
            // btnDocumentsRemove
            // 
            this.btnDocumentsRemove.Location = new System.Drawing.Point(16, 103);
            this.btnDocumentsRemove.Name = "btnDocumentsRemove";
            this.btnDocumentsRemove.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsRemove.TabIndex = 24;
            this.btnDocumentsRemove.Text = "Remove";
            this.btnDocumentsRemove.UseVisualStyleBackColor = true;
            this.btnDocumentsRemove.Click += new System.EventHandler(this.btnDocumentsRemove_Click);
            // 
            // btnDocumentsClear
            // 
            this.btnDocumentsClear.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentsClear.ForeColor = System.Drawing.Color.Black;
            this.btnDocumentsClear.Location = new System.Drawing.Point(16, 127);
            this.btnDocumentsClear.Name = "btnDocumentsClear";
            this.btnDocumentsClear.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsClear.TabIndex = 23;
            this.btnDocumentsClear.Text = "Clear";
            this.btnDocumentsClear.UseVisualStyleBackColor = true;
            this.btnDocumentsClear.Click += new System.EventHandler(this.btnDocumentsClear_Click);
            // 
            // btnDocumentsView
            // 
            this.btnDocumentsView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentsView.ForeColor = System.Drawing.Color.Black;
            this.btnDocumentsView.Location = new System.Drawing.Point(16, 53);
            this.btnDocumentsView.Name = "btnDocumentsView";
            this.btnDocumentsView.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsView.TabIndex = 21;
            this.btnDocumentsView.Text = "View";
            this.btnDocumentsView.UseVisualStyleBackColor = true;
            this.btnDocumentsView.Click += new System.EventHandler(this.btnDocumentsView_Click);
            // 
            // btnDocumentsScan
            // 
            this.btnDocumentsScan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentsScan.ForeColor = System.Drawing.Color.Black;
            this.btnDocumentsScan.Location = new System.Drawing.Point(16, 4);
            this.btnDocumentsScan.Name = "btnDocumentsScan";
            this.btnDocumentsScan.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsScan.TabIndex = 22;
            this.btnDocumentsScan.Text = "Scan";
            this.btnDocumentsScan.UseVisualStyleBackColor = true;
            this.btnDocumentsScan.Visible = false;
            this.btnDocumentsScan.Click += new System.EventHandler(this.btnDocumentsScan_Click);
            // 
            // btnDocumentsSave
            // 
            this.btnDocumentsSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentsSave.ForeColor = System.Drawing.Color.Black;
            this.btnDocumentsSave.Location = new System.Drawing.Point(16, 78);
            this.btnDocumentsSave.Name = "btnDocumentsSave";
            this.btnDocumentsSave.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsSave.TabIndex = 14;
            this.btnDocumentsSave.Text = "Save";
            this.btnDocumentsSave.UseVisualStyleBackColor = true;
            this.btnDocumentsSave.Click += new System.EventHandler(this.btnDocumentsSave_Click);
            // 
            // btnDocumentsUpload
            // 
            this.btnDocumentsUpload.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocumentsUpload.ForeColor = System.Drawing.Color.Black;
            this.btnDocumentsUpload.Location = new System.Drawing.Point(16, 28);
            this.btnDocumentsUpload.Name = "btnDocumentsUpload";
            this.btnDocumentsUpload.Size = new System.Drawing.Size(69, 23);
            this.btnDocumentsUpload.TabIndex = 20;
            this.btnDocumentsUpload.Text = "Upload";
            this.btnDocumentsUpload.UseVisualStyleBackColor = true;
            this.btnDocumentsUpload.Click += new System.EventHandler(this.btnDocumentsUpload_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.gridDocuments);
            this.groupBox19.Location = new System.Drawing.Point(77, 6);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(795, 210);
            this.groupBox19.TabIndex = 2;
            this.groupBox19.TabStop = false;
            // 
            // gridDocuments
            // 
            this.gridDocuments.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gridDocuments.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridDocuments.BackgroundColor = System.Drawing.Color.SlateGray;
            this.gridDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDocuments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridDocumentsID,
            this.gridDocumentsDateCreated,
            this.gridDocumentsDescription,
            this.gridDocumentsDocumentType,
            this.gridDocumentsDocumentGroup,
            this.gridDocumentsPath,
            this.gridDocumentsDocumentsContent});
            this.gridDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDocuments.GridColor = System.Drawing.SystemColors.Control;
            this.gridDocuments.Location = new System.Drawing.Point(3, 17);
            this.gridDocuments.Name = "gridDocuments";
            this.gridDocuments.RowHeadersWidth = 23;
            this.gridDocuments.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDocuments.Size = new System.Drawing.Size(789, 190);
            this.gridDocuments.TabIndex = 2;
            this.gridDocuments.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDocuments_CellClick);
            // 
            // gridDocumentsID
            // 
            this.gridDocumentsID.HeaderText = "ID";
            this.gridDocumentsID.Name = "gridDocumentsID";
            this.gridDocumentsID.Visible = false;
            // 
            // gridDocumentsDateCreated
            // 
            this.gridDocumentsDateCreated.DataPropertyName = "DateCreated";
            this.gridDocumentsDateCreated.HeaderText = "Date Created";
            this.gridDocumentsDateCreated.Name = "gridDocumentsDateCreated";
            this.gridDocumentsDateCreated.ReadOnly = true;
            // 
            // gridDocumentsDescription
            // 
            this.gridDocumentsDescription.DataPropertyName = "Description";
            this.gridDocumentsDescription.HeaderText = "Description";
            this.gridDocumentsDescription.Name = "gridDocumentsDescription";
            // 
            // gridDocumentsDocumentType
            // 
            this.gridDocumentsDocumentType.DataPropertyName = "DocumentType";
            this.gridDocumentsDocumentType.HeaderText = "Document Type";
            this.gridDocumentsDocumentType.Name = "gridDocumentsDocumentType";
            this.gridDocumentsDocumentType.ReadOnly = true;
            this.gridDocumentsDocumentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDocumentsDocumentType.Visible = false;
            // 
            // gridDocumentsDocumentGroup
            // 
            this.gridDocumentsDocumentGroup.HeaderText = "Document Group";
            this.gridDocumentsDocumentGroup.Name = "gridDocumentsDocumentGroup";
            this.gridDocumentsDocumentGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // gridDocumentsPath
            // 
            this.gridDocumentsPath.HeaderText = "Path";
            this.gridDocumentsPath.Name = "gridDocumentsPath";
            this.gridDocumentsPath.ReadOnly = true;
            // 
            // gridDocumentsDocumentsContent
            // 
            this.gridDocumentsDocumentsContent.HeaderText = "DocumentsContent";
            this.gridDocumentsDocumentsContent.Name = "gridDocumentsDocumentsContent";
            this.gridDocumentsDocumentsContent.Visible = false;
            // 
            // refereeTabPage
            // 
            this.refereeTabPage.BackColor = System.Drawing.Color.Lavender;
            this.refereeTabPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.refereeTabPage.Controls.Add(this.panel10);
            this.refereeTabPage.Controls.Add(this.panel5);
            this.refereeTabPage.Controls.Add(this.groupBox6);
            this.refereeTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refereeTabPage.Location = new System.Drawing.Point(4, 22);
            this.refereeTabPage.Name = "refereeTabPage";
            this.refereeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.refereeTabPage.Size = new System.Drawing.Size(1026, 222);
            this.refereeTabPage.TabIndex = 16;
            this.refereeTabPage.Text = "Refrees";
            this.refereeTabPage.UseVisualStyleBackColor = true;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.SlateGray;
            this.panel10.Controls.Add(this.btnRefreshRefrees);
            this.panel10.Controls.Add(this.btnRefreeRemove);
            this.panel10.Controls.Add(this.btnClearRefrees);
            this.panel10.Controls.Add(this.btnSaveRefrees);
            this.panel10.Location = new System.Drawing.Point(847, 61);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(89, 110);
            this.panel10.TabIndex = 45;
            // 
            // btnRefreshRefrees
            // 
            this.btnRefreshRefrees.Location = new System.Drawing.Point(6, 80);
            this.btnRefreshRefrees.Name = "btnRefreshRefrees";
            this.btnRefreshRefrees.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshRefrees.TabIndex = 4;
            this.btnRefreshRefrees.Text = "Refresh";
            this.btnRefreshRefrees.UseVisualStyleBackColor = true;
            this.btnRefreshRefrees.Click += new System.EventHandler(this.btnRefreshRefrees_Click);
            // 
            // btnRefreeRemove
            // 
            this.btnRefreeRemove.Location = new System.Drawing.Point(6, 32);
            this.btnRefreeRemove.Name = "btnRefreeRemove";
            this.btnRefreeRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRefreeRemove.TabIndex = 2;
            this.btnRefreeRemove.Text = "Remove";
            this.btnRefreeRemove.UseVisualStyleBackColor = true;
            this.btnRefreeRemove.Click += new System.EventHandler(this.btnRefreeRemove_Click);
            // 
            // btnClearRefrees
            // 
            this.btnClearRefrees.Location = new System.Drawing.Point(6, 56);
            this.btnClearRefrees.Name = "btnClearRefrees";
            this.btnClearRefrees.Size = new System.Drawing.Size(75, 23);
            this.btnClearRefrees.TabIndex = 1;
            this.btnClearRefrees.Text = "Clear";
            this.btnClearRefrees.UseVisualStyleBackColor = true;
            this.btnClearRefrees.Click += new System.EventHandler(this.btnClearRefrees_Click);
            // 
            // btnSaveRefrees
            // 
            this.btnSaveRefrees.Location = new System.Drawing.Point(6, 9);
            this.btnSaveRefrees.Name = "btnSaveRefrees";
            this.btnSaveRefrees.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRefrees.TabIndex = 0;
            this.btnSaveRefrees.Text = "Save";
            this.btnSaveRefrees.UseVisualStyleBackColor = true;
            this.btnSaveRefrees.Click += new System.EventHandler(this.btnSaveRefrees_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SlateGray;
            this.panel5.Controls.Add(this.button11);
            this.panel5.Controls.Add(this.button14);
            this.panel5.Location = new System.Drawing.Point(831, 300);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(94, 108);
            this.panel5.TabIndex = 44;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.Black;
            this.button11.Location = new System.Drawing.Point(13, 28);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(69, 23);
            this.button11.TabIndex = 23;
            this.button11.Text = "Save";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button14.ForeColor = System.Drawing.Color.Black;
            this.button14.Location = new System.Drawing.Point(13, 57);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(69, 23);
            this.button14.TabIndex = 21;
            this.button14.Text = "Clear";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.gridRefrees);
            this.groupBox6.Location = new System.Drawing.Point(27, 17);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(808, 197);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // gridRefrees
            // 
            this.gridRefrees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridRefrees.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRefrees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridRefrees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRefrees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.refereesID,
            this.refereesName,
            this.refereesOccupation,
            this.refereesAddress,
            this.refereesTelNo,
            this.refereesEmail});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRefrees.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridRefrees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRefrees.GridColor = System.Drawing.Color.Gainsboro;
            this.gridRefrees.Location = new System.Drawing.Point(3, 16);
            this.gridRefrees.Name = "gridRefrees";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRefrees.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridRefrees.RowHeadersWidth = 5;
            this.gridRefrees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRefrees.Size = new System.Drawing.Size(802, 178);
            this.gridRefrees.TabIndex = 0;
            // 
            // refereesID
            // 
            this.refereesID.HeaderText = "ID";
            this.refereesID.Name = "refereesID";
            this.refereesID.Visible = false;
            // 
            // refereesName
            // 
            this.refereesName.DataPropertyName = "Name";
            this.refereesName.HeaderText = "Name";
            this.refereesName.Name = "refereesName";
            // 
            // refereesOccupation
            // 
            this.refereesOccupation.DataPropertyName = "Occupation";
            this.refereesOccupation.HeaderText = "Occupation";
            this.refereesOccupation.Name = "refereesOccupation";
            // 
            // refereesAddress
            // 
            this.refereesAddress.DataPropertyName = "Address";
            this.refereesAddress.HeaderText = "Address";
            this.refereesAddress.Name = "refereesAddress";
            // 
            // refereesTelNo
            // 
            this.refereesTelNo.HeaderText = "TelNo";
            this.refereesTelNo.Name = "refereesTelNo";
            // 
            // refereesEmail
            // 
            this.refereesEmail.HeaderText = "Email";
            this.refereesEmail.Name = "refereesEmail";
            // 
            // workPermitTabPage
            // 
            this.workPermitTabPage.Controls.Add(this.groupBox13);
            this.workPermitTabPage.Location = new System.Drawing.Point(4, 22);
            this.workPermitTabPage.Name = "workPermitTabPage";
            this.workPermitTabPage.Size = new System.Drawing.Size(1026, 222);
            this.workPermitTabPage.TabIndex = 10;
            this.workPermitTabPage.Text = "Other Info";
            this.workPermitTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.BackColor = System.Drawing.Color.Lavender;
            this.groupBox13.Controls.Add(this.groupBox16);
            this.groupBox13.Controls.Add(this.panel2);
            this.groupBox13.Controls.Add(this.groupBox15);
            this.groupBox13.Controls.Add(this.groupBox14);
            this.groupBox13.Controls.Add(this.groupBox26);
            this.groupBox13.Location = new System.Drawing.Point(1, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(1022, 223);
            this.groupBox13.TabIndex = 49;
            this.groupBox13.TabStop = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.cmbDisabled);
            this.groupBox16.Controls.Add(this.cmbBonded);
            this.groupBox16.Controls.Add(this.cmbApplied);
            this.groupBox16.Controls.Add(this.cmbConvicted);
            this.groupBox16.Controls.Add(this.label51);
            this.groupBox16.Controls.Add(this.label52);
            this.groupBox16.Controls.Add(this.label53);
            this.groupBox16.Controls.Add(this.label54);
            this.groupBox16.Location = new System.Drawing.Point(405, 6);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(385, 101);
            this.groupBox16.TabIndex = 50;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "Past History";
            // 
            // cmbDisabled
            // 
            this.cmbDisabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDisabled.FormattingEnabled = true;
            this.cmbDisabled.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbDisabled.Location = new System.Drawing.Point(276, 56);
            this.cmbDisabled.Name = "cmbDisabled";
            this.cmbDisabled.Size = new System.Drawing.Size(87, 21);
            this.cmbDisabled.TabIndex = 11;
            // 
            // cmbBonded
            // 
            this.cmbBonded.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBonded.FormattingEnabled = true;
            this.cmbBonded.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbBonded.Location = new System.Drawing.Point(276, 34);
            this.cmbBonded.Name = "cmbBonded";
            this.cmbBonded.Size = new System.Drawing.Size(87, 21);
            this.cmbBonded.TabIndex = 10;
            // 
            // cmbApplied
            // 
            this.cmbApplied.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApplied.FormattingEnabled = true;
            this.cmbApplied.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbApplied.Location = new System.Drawing.Point(276, 79);
            this.cmbApplied.Name = "cmbApplied";
            this.cmbApplied.Size = new System.Drawing.Size(87, 21);
            this.cmbApplied.TabIndex = 12;
            // 
            // cmbConvicted
            // 
            this.cmbConvicted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConvicted.FormattingEnabled = true;
            this.cmbConvicted.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbConvicted.Location = new System.Drawing.Point(276, 12);
            this.cmbConvicted.Name = "cmbConvicted";
            this.cmbConvicted.Size = new System.Drawing.Size(87, 21);
            this.cmbConvicted.TabIndex = 9;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(44, 60);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(233, 13);
            this.label51.TabIndex = 15;
            this.label51.Text = "Have you suffered from any physical disability?";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(148, 83);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(130, 13);
            this.label52.TabIndex = 16;
            this.label52.Text = "Have you applied before?";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(41, 37);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(236, 13);
            this.label53.TabIndex = 13;
            this.label53.Text = "Are you bonded to serve in any other capacity?";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(11, 15);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(266, 13);
            this.label54.TabIndex = 14;
            this.label54.Text = "Have you been Convicted in any civil or military court?";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.btnClearWorkPermits);
            this.panel2.Location = new System.Drawing.Point(889, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(94, 37);
            this.panel2.TabIndex = 48;
            // 
            // btnClearWorkPermits
            // 
            this.btnClearWorkPermits.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearWorkPermits.ForeColor = System.Drawing.Color.Black;
            this.btnClearWorkPermits.Location = new System.Drawing.Point(11, 8);
            this.btnClearWorkPermits.Name = "btnClearWorkPermits";
            this.btnClearWorkPermits.Size = new System.Drawing.Size(75, 23);
            this.btnClearWorkPermits.TabIndex = 18;
            this.btnClearWorkPermits.Text = "Clear";
            this.btnClearWorkPermits.UseVisualStyleBackColor = true;
            this.btnClearWorkPermits.Click += new System.EventHandler(this.btnClearWorkPermits_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.checkBoxHasPassport);
            this.groupBox15.Controls.Add(this.label49);
            this.groupBox15.Controls.Add(this.label48);
            this.groupBox15.Controls.Add(this.dateExpires);
            this.groupBox15.Controls.Add(this.dateIssued);
            this.groupBox15.Controls.Add(this.txtPassportNotes);
            this.groupBox15.Controls.Add(this.txtPassportNo);
            this.groupBox15.Controls.Add(this.label47);
            this.groupBox15.Controls.Add(this.label50);
            this.groupBox15.Location = new System.Drawing.Point(12, 101);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(389, 107);
            this.groupBox15.TabIndex = 51;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Passport Details";
            // 
            // checkBoxHasPassport
            // 
            this.checkBoxHasPassport.AutoSize = true;
            this.checkBoxHasPassport.Location = new System.Drawing.Point(25, 13);
            this.checkBoxHasPassport.Name = "checkBoxHasPassport";
            this.checkBoxHasPassport.Size = new System.Drawing.Size(89, 17);
            this.checkBoxHasPassport.TabIndex = 3;
            this.checkBoxHasPassport.Text = "Has Passport";
            this.checkBoxHasPassport.UseVisualStyleBackColor = true;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(20, 56);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(91, 13);
            this.label49.TabIndex = 0;
            this.label49.Text = "Passport Expires:";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(23, 37);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(88, 13);
            this.label48.TabIndex = 0;
            this.label48.Text = "Passport Issued:";
            // 
            // dateExpires
            // 
            this.dateExpires.CustomFormat = " dd/MM/yyyy";
            this.dateExpires.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateExpires.Location = new System.Drawing.Point(119, 56);
            this.dateExpires.Name = "dateExpires";
            this.dateExpires.Size = new System.Drawing.Size(84, 21);
            this.dateExpires.TabIndex = 2;
            // 
            // dateIssued
            // 
            this.dateIssued.CustomFormat = " dd/MM/yyyy";
            this.dateIssued.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateIssued.Location = new System.Drawing.Point(119, 33);
            this.dateIssued.Name = "dateIssued";
            this.dateIssued.Size = new System.Drawing.Size(85, 21);
            this.dateIssued.TabIndex = 2;
            // 
            // txtPassportNotes
            // 
            this.txtPassportNotes.Location = new System.Drawing.Point(119, 79);
            this.txtPassportNotes.Multiline = true;
            this.txtPassportNotes.Name = "txtPassportNotes";
            this.txtPassportNotes.Size = new System.Drawing.Size(262, 23);
            this.txtPassportNotes.TabIndex = 1;
            // 
            // txtPassportNo
            // 
            this.txtPassportNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPassportNo.Location = new System.Drawing.Point(221, 12);
            this.txtPassportNo.Name = "txtPassportNo";
            this.txtPassportNo.Size = new System.Drawing.Size(160, 21);
            this.txtPassportNo.TabIndex = 1;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(148, 14);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(69, 13);
            this.label47.TabIndex = 0;
            this.label47.Text = "Passport No:";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(36, 84);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(80, 13);
            this.label50.TabIndex = 0;
            this.label50.Text = "Place Of Issue:";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.checkBoxHasVisa);
            this.groupBox14.Controls.Add(this.label62);
            this.groupBox14.Controls.Add(this.txtVisaNo);
            this.groupBox14.Controls.Add(this.cmbVisaType);
            this.groupBox14.Controls.Add(this.label45);
            this.groupBox14.Controls.Add(this.dateFrom);
            this.groupBox14.Controls.Add(this.dateTo);
            this.groupBox14.Controls.Add(this.label44);
            this.groupBox14.Controls.Add(this.txtVisaNotes);
            this.groupBox14.Controls.Add(this.label40);
            this.groupBox14.Controls.Add(this.label46);
            this.groupBox14.Location = new System.Drawing.Point(406, 111);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(385, 104);
            this.groupBox14.TabIndex = 48;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Visa Details";
            // 
            // checkBoxHasVisa
            // 
            this.checkBoxHasVisa.AutoSize = true;
            this.checkBoxHasVisa.Location = new System.Drawing.Point(84, 13);
            this.checkBoxHasVisa.Name = "checkBoxHasVisa";
            this.checkBoxHasVisa.Size = new System.Drawing.Size(66, 17);
            this.checkBoxHasVisa.TabIndex = 6;
            this.checkBoxHasVisa.Text = "Has Visa";
            this.checkBoxHasVisa.UseVisualStyleBackColor = true;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(33, 35);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(49, 13);
            this.label62.TabIndex = 5;
            this.label62.Text = "Visa No :";
            // 
            // txtVisaNo
            // 
            this.txtVisaNo.Location = new System.Drawing.Point(84, 31);
            this.txtVisaNo.Name = "txtVisaNo";
            this.txtVisaNo.Size = new System.Drawing.Size(110, 21);
            this.txtVisaNo.TabIndex = 4;
            // 
            // cmbVisaType
            // 
            this.cmbVisaType.FormattingEnabled = true;
            this.cmbVisaType.Items.AddRange(new object[] {
            "Citizen",
            "Student",
            "Vacation"});
            this.cmbVisaType.Location = new System.Drawing.Point(263, 31);
            this.cmbVisaType.Name = "cmbVisaType";
            this.cmbVisaType.Size = new System.Drawing.Size(100, 21);
            this.cmbVisaType.TabIndex = 3;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = " dd/MM/yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(84, 53);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(110, 21);
            this.dateFrom.TabIndex = 2;
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = " dd/MM/yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(263, 53);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(100, 21);
            this.dateTo.TabIndex = 2;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(196, 58);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(67, 13);
            this.label44.TabIndex = 0;
            this.label44.Text = "Expiry Date:";
            // 
            // txtVisaNotes
            // 
            this.txtVisaNotes.Location = new System.Drawing.Point(84, 76);
            this.txtVisaNotes.Multiline = true;
            this.txtVisaNotes.Name = "txtVisaNotes";
            this.txtVisaNotes.Size = new System.Drawing.Size(280, 24);
            this.txtVisaNotes.TabIndex = 1;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(23, 56);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(60, 13);
            this.label40.TabIndex = 0;
            this.label40.Text = "Valid From:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(1, 81);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(80, 13);
            this.label46.TabIndex = 0;
            this.label46.Text = "Place Of Issue:";
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.txtDuration);
            this.groupBox26.Controls.Add(this.txtWorkPermitID);
            this.groupBox26.Controls.Add(this.label19);
            this.groupBox26.Controls.Add(this.cmbWorkPermit);
            this.groupBox26.Controls.Add(this.label43);
            this.groupBox26.Controls.Add(this.dateWorkPermit);
            this.groupBox26.Controls.Add(this.txtWorkPermitNotes);
            this.groupBox26.Controls.Add(this.label42);
            this.groupBox26.Controls.Add(this.label41);
            this.groupBox26.Controls.Add(this.label39);
            this.groupBox26.Location = new System.Drawing.Point(12, 3);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(389, 96);
            this.groupBox26.TabIndex = 49;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Work Permit Details";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(285, 36);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(52, 21);
            this.txtDuration.TabIndex = 6;
            // 
            // txtWorkPermitID
            // 
            this.txtWorkPermitID.BackColor = System.Drawing.Color.White;
            this.txtWorkPermitID.Location = new System.Drawing.Point(284, 9);
            this.txtWorkPermitID.Name = "txtWorkPermitID";
            this.txtWorkPermitID.Size = new System.Drawing.Size(101, 21);
            this.txtWorkPermitID.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(198, 13);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(83, 13);
            this.label19.TabIndex = 4;
            this.label19.Text = "Work Permit ID:";
            // 
            // cmbWorkPermit
            // 
            this.cmbWorkPermit.FormattingEnabled = true;
            this.cmbWorkPermit.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cmbWorkPermit.Location = new System.Drawing.Point(92, 11);
            this.cmbWorkPermit.Name = "cmbWorkPermit";
            this.cmbWorkPermit.Size = new System.Drawing.Size(58, 21);
            this.cmbWorkPermit.TabIndex = 3;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(18, 39);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(70, 13);
            this.label43.TabIndex = 0;
            this.label43.Text = "Expire Date :";
            // 
            // dateWorkPermit
            // 
            this.dateWorkPermit.CustomFormat = " dd/MM/yyyy";
            this.dateWorkPermit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateWorkPermit.Location = new System.Drawing.Point(91, 35);
            this.dateWorkPermit.Name = "dateWorkPermit";
            this.dateWorkPermit.Size = new System.Drawing.Size(101, 21);
            this.dateWorkPermit.TabIndex = 2;
            this.dateWorkPermit.Value = new System.DateTime(2014, 5, 2, 15, 32, 41, 0);
            // 
            // txtWorkPermitNotes
            // 
            this.txtWorkPermitNotes.Location = new System.Drawing.Point(91, 59);
            this.txtWorkPermitNotes.Multiline = true;
            this.txtWorkPermitNotes.Name = "txtWorkPermitNotes";
            this.txtWorkPermitNotes.Size = new System.Drawing.Size(291, 29);
            this.txtWorkPermitNotes.TabIndex = 1;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(196, 40);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(87, 13);
            this.label41.TabIndex = 0;
            this.label41.Text = "Duration (Days):";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(20, 16);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(69, 13);
            this.label39.TabIndex = 0;
            this.label39.Text = "Work Permit:";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label104);
            this.groupBox9.Controls.Add(this.txtTribe);
            this.groupBox9.Controls.Add(this.label103);
            this.groupBox9.Controls.Add(this.cboRace);
            this.groupBox9.Controls.Add(this.checkBoxActive);
            this.groupBox9.Controls.Add(this.groupBoxSpecialInformation);
            this.groupBox9.Controls.Add(this.cboBirthRegion);
            this.groupBox9.Controls.Add(this.label81);
            this.groupBox9.Controls.Add(this.label80);
            this.groupBox9.Controls.Add(this.cboQualificationType);
            this.groupBox9.Controls.Add(this.checkBoxDisability);
            this.groupBox9.Controls.Add(this.label79);
            this.groupBox9.Controls.Add(this.zoneDatePicker);
            this.groupBox9.Controls.Add(this.txtFileNumber);
            this.groupBox9.Controls.Add(this.label77);
            this.groupBox9.Controls.Add(this.cboZone);
            this.groupBox9.Controls.Add(this.label29);
            this.groupBox9.Controls.Add(this.txtNumberOfChildren);
            this.groupBox9.Controls.Add(this.panel9);
            this.groupBox9.Controls.Add(this.label85);
            this.groupBox9.Controls.Add(this.lblDOM);
            this.groupBox9.Controls.Add(this.dateDOM);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.txtNHISNumber);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Controls.Add(this.btnDenomination);
            this.groupBox9.Controls.Add(this.cboDenomination);
            this.groupBox9.Controls.Add(this.btnReligion);
            this.groupBox9.Controls.Add(this.button24);
            this.groupBox9.Controls.Add(this.cboNationality);
            this.groupBox9.Controls.Add(this.cboBirthCountry);
            this.groupBox9.Controls.Add(this.label70);
            this.groupBox9.Controls.Add(this.cboBirthDistrict);
            this.groupBox9.Controls.Add(this.button5);
            this.groupBox9.Controls.Add(this.txtNickName);
            this.groupBox9.Controls.Add(this.label69);
            this.groupBox9.Controls.Add(this.groupBox11);
            this.groupBox9.Controls.Add(this.txtOtherName);
            this.groupBox9.Controls.Add(this.label68);
            this.groupBox9.Controls.Add(this.label59);
            this.groupBox9.Controls.Add(this.txtNationalID);
            this.groupBox9.Controls.Add(this.label58);
            this.groupBox9.Controls.Add(this.label57);
            this.groupBox9.Controls.Add(this.txtMaidenName);
            this.groupBox9.Controls.Add(this.txtPIN);
            this.groupBox9.Controls.Add(this.label32);
            this.groupBox9.Controls.Add(this.cmbPOB);
            this.groupBox9.Controls.Add(this.btnBirthPlace);
            this.groupBox9.Controls.Add(this.cmbHomeTown);
            this.groupBox9.Controls.Add(this.button9);
            this.groupBox9.Controls.Add(this.btnBirthDistrict);
            this.groupBox9.Controls.Add(this.cmbSex);
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.label5);
            this.groupBox9.Controls.Add(this.surnameTextBox);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.txtFirstName);
            this.groupBox9.Controls.Add(this.label14);
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.cmbMaritalStatus);
            this.groupBox9.Controls.Add(this.dateDOB);
            this.groupBox9.Controls.Add(this.staffIDTextBox);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.cmbReligion);
            this.groupBox9.Controls.Add(this.cmbTitle);
            this.groupBox9.Controls.Add(this.label13);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.label11);
            this.groupBox9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(3, 5);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1034, 300);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Employee Details:";
            // 
            // label104
            // 
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(59, 266);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(35, 13);
            this.label104.TabIndex = 74;
            this.label104.Text = "Tribe:";
            // 
            // txtTribe
            // 
            this.txtTribe.Location = new System.Drawing.Point(97, 262);
            this.txtTribe.Name = "txtTribe";
            this.txtTribe.Size = new System.Drawing.Size(157, 21);
            this.txtTribe.TabIndex = 73;
            // 
            // label103
            // 
            this.label103.AutoSize = true;
            this.label103.Location = new System.Drawing.Point(60, 239);
            this.label103.Name = "label103";
            this.label103.Size = new System.Drawing.Size(35, 13);
            this.label103.TabIndex = 72;
            this.label103.Text = "Race:";
            // 
            // cboRace
            // 
            this.cboRace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRace.FormattingEnabled = true;
            this.cboRace.Location = new System.Drawing.Point(98, 235);
            this.cboRace.Name = "cboRace";
            this.cboRace.Size = new System.Drawing.Size(156, 21);
            this.cboRace.TabIndex = 71;
            this.cboRace.DropDown += new System.EventHandler(this.cboRace_DropDown);
            // 
            // checkBoxActive
            // 
            this.checkBoxActive.AutoSize = true;
            this.checkBoxActive.Checked = true;
            this.checkBoxActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxActive.Location = new System.Drawing.Point(628, 243);
            this.checkBoxActive.Name = "checkBoxActive";
            this.checkBoxActive.Size = new System.Drawing.Size(119, 17);
            this.checkBoxActive.TabIndex = 70;
            this.checkBoxActive.Text = "Payment Activation";
            this.checkBoxActive.UseVisualStyleBackColor = true;
            // 
            // groupBoxSpecialInformation
            // 
            this.groupBoxSpecialInformation.Controls.Add(this.btnDisabilityType);
            this.groupBoxSpecialInformation.Controls.Add(this.label99);
            this.groupBoxSpecialInformation.Controls.Add(this.label98);
            this.groupBoxSpecialInformation.Controls.Add(this.cboDisabilityType);
            this.groupBoxSpecialInformation.Controls.Add(this.datePickerDisabilityDate);
            this.groupBoxSpecialInformation.Location = new System.Drawing.Point(260, 233);
            this.groupBoxSpecialInformation.Name = "groupBoxSpecialInformation";
            this.groupBoxSpecialInformation.Size = new System.Drawing.Size(285, 60);
            this.groupBoxSpecialInformation.TabIndex = 69;
            this.groupBoxSpecialInformation.TabStop = false;
            this.groupBoxSpecialInformation.Text = "Special Information";
            this.groupBoxSpecialInformation.Visible = false;
            // 
            // btnDisabilityType
            // 
            this.btnDisabilityType.Location = new System.Drawing.Point(238, 34);
            this.btnDisabilityType.Name = "btnDisabilityType";
            this.btnDisabilityType.Size = new System.Drawing.Size(27, 23);
            this.btnDisabilityType.TabIndex = 71;
            this.btnDisabilityType.Text = "...";
            this.btnDisabilityType.UseVisualStyleBackColor = true;
            this.btnDisabilityType.Click += new System.EventHandler(this.btnDisabilityType_Click);
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(7, 16);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(80, 13);
            this.label99.TabIndex = 70;
            this.label99.Text = "Effective Date:";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(7, 39);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(80, 13);
            this.label98.TabIndex = 69;
            this.label98.Text = "Disability Type:";
            // 
            // cboDisabilityType
            // 
            this.cboDisabilityType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDisabilityType.FormattingEnabled = true;
            this.cboDisabilityType.Location = new System.Drawing.Point(90, 35);
            this.cboDisabilityType.Name = "cboDisabilityType";
            this.cboDisabilityType.Size = new System.Drawing.Size(146, 21);
            this.cboDisabilityType.TabIndex = 68;
            this.cboDisabilityType.DropDown += new System.EventHandler(this.cboDisabilityType_DropDown);
            // 
            // datePickerDisabilityDate
            // 
            this.datePickerDisabilityDate.Checked = false;
            this.datePickerDisabilityDate.CustomFormat = "dd/MM/yyyy";
            this.datePickerDisabilityDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerDisabilityDate.Location = new System.Drawing.Point(90, 12);
            this.datePickerDisabilityDate.Name = "datePickerDisabilityDate";
            this.datePickerDisabilityDate.ShowCheckBox = true;
            this.datePickerDisabilityDate.Size = new System.Drawing.Size(175, 21);
            this.datePickerDisabilityDate.TabIndex = 67;
            // 
            // cboBirthRegion
            // 
            this.cboBirthRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBirthRegion.FormattingEnabled = true;
            this.cboBirthRegion.Location = new System.Drawing.Point(99, 114);
            this.cboBirthRegion.Name = "cboBirthRegion";
            this.cboBirthRegion.Size = new System.Drawing.Size(153, 21);
            this.cboBirthRegion.TabIndex = 65;
            this.cboBirthRegion.SelectionChangeCommitted += new System.EventHandler(this.cboBirthRegion_SelectionChangeCommitted);
            this.cboBirthRegion.DropDown += new System.EventHandler(this.cboBirthRegion_DropDown);
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(21, 118);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(75, 13);
            this.label81.TabIndex = 64;
            this.label81.Text = "Birth Region*:";
            // 
            // label80
            // 
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(1, 213);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(94, 13);
            this.label80.TabIndex = 63;
            this.label80.Text = "Cur. Qualification:";
            // 
            // cboQualificationType
            // 
            this.cboQualificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQualificationType.FormattingEnabled = true;
            this.cboQualificationType.Location = new System.Drawing.Point(98, 209);
            this.cboQualificationType.Name = "cboQualificationType";
            this.cboQualificationType.Size = new System.Drawing.Size(163, 21);
            this.cboQualificationType.TabIndex = 62;
            this.cboQualificationType.DropDown += new System.EventHandler(this.cboQualificationType_DropDown);
            // 
            // checkBoxDisability
            // 
            this.checkBoxDisability.AutoSize = true;
            this.checkBoxDisability.Location = new System.Drawing.Point(366, 214);
            this.checkBoxDisability.Name = "checkBoxDisability";
            this.checkBoxDisability.Size = new System.Drawing.Size(68, 17);
            this.checkBoxDisability.TabIndex = 66;
            this.checkBoxDisability.Text = "Disability";
            this.checkBoxDisability.UseVisualStyleBackColor = true;
            this.checkBoxDisability.CheckedChanged += new System.EventHandler(this.checkBoxDisability_CheckedChanged);
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(246, 191);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(119, 13);
            this.label79.TabIndex = 61;
            this.label79.Text = "Directorate/Zone Date:";
            // 
            // zoneDatePicker
            // 
            this.zoneDatePicker.Checked = false;
            this.zoneDatePicker.CustomFormat = "dd/MM/yyyy";
            this.zoneDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.zoneDatePicker.Location = new System.Drawing.Point(367, 187);
            this.zoneDatePicker.Name = "zoneDatePicker";
            this.zoneDatePicker.ShowCheckBox = true;
            this.zoneDatePicker.Size = new System.Drawing.Size(146, 21);
            this.zoneDatePicker.TabIndex = 60;
            this.zoneDatePicker.Value = new System.DateTime(2014, 9, 17, 0, 0, 0, 0);
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtFileNumber.FormattingEnabled = true;
            this.txtFileNumber.Location = new System.Drawing.Point(304, 16);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.Size = new System.Drawing.Size(145, 21);
            this.txtFileNumber.Sorted = true;
            this.txtFileNumber.TabIndex = 59;
            this.txtFileNumber.DropDown += new System.EventHandler(this.txtFileNumber_DropDown);
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(-1, 190);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(99, 13);
            this.label77.TabIndex = 58;
            this.label77.Text = "Directorate/Zone*:";
            // 
            // cboZone
            // 
            this.cboZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZone.FormattingEnabled = true;
            this.cboZone.Location = new System.Drawing.Point(98, 186);
            this.cboZone.Name = "cboZone";
            this.cboZone.Size = new System.Drawing.Size(146, 21);
            this.cboZone.TabIndex = 57;
            this.cboZone.DropDown += new System.EventHandler(this.cboZone_DropDown);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(257, 19);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(41, 13);
            this.label29.TabIndex = 55;
            this.label29.Text = "File # :";
            // 
            // txtNumberOfChildren
            // 
            this.txtNumberOfChildren.Location = new System.Drawing.Point(629, 45);
            this.txtNumberOfChildren.Name = "txtNumberOfChildren";
            this.txtNumberOfChildren.Size = new System.Drawing.Size(56, 21);
            this.txtNumberOfChildren.TabIndex = 54;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.SlateGray;
            this.panel9.Controls.Add(this.btnSave);
            this.panel9.Controls.Add(this.btnClearPersonalInfo);
            this.panel9.Location = new System.Drawing.Point(831, 202);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(169, 89);
            this.panel9.TabIndex = 51;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(52, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.toolTip2.SetToolTip(this.btnSave, "toolTip2");
            this.toolTip1.SetToolTip(this.btnSave, "Save Button");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.Enter += new System.EventHandler(this.personalTabPage_Enter);
            // 
            // btnClearPersonalInfo
            // 
            this.btnClearPersonalInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPersonalInfo.ForeColor = System.Drawing.Color.Black;
            this.btnClearPersonalInfo.Location = new System.Drawing.Point(52, 48);
            this.btnClearPersonalInfo.Name = "btnClearPersonalInfo";
            this.btnClearPersonalInfo.Size = new System.Drawing.Size(75, 23);
            this.btnClearPersonalInfo.TabIndex = 1;
            this.btnClearPersonalInfo.Text = "Clear";
            this.btnClearPersonalInfo.UseVisualStyleBackColor = true;
            this.btnClearPersonalInfo.Click += new System.EventHandler(this.clearPersonalInfo_Click);
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(538, 49);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(88, 13);
            this.label85.TabIndex = 50;
            this.label85.Text = "No. Of Children :";
            // 
            // lblDOM
            // 
            this.lblDOM.AutoSize = true;
            this.lblDOM.Location = new System.Drawing.Point(528, 218);
            this.lblDOM.Name = "lblDOM";
            this.lblDOM.Size = new System.Drawing.Size(97, 13);
            this.lblDOM.TabIndex = 48;
            this.lblDOM.Text = "Date Of Marriage :";
            this.lblDOM.Visible = false;
            // 
            // dateDOM
            // 
            this.dateDOM.Checked = false;
            this.dateDOM.CustomFormat = " dd/MM/yyyy";
            this.dateDOM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDOM.Location = new System.Drawing.Point(628, 213);
            this.dateDOM.Name = "dateDOM";
            this.dateDOM.ShowCheckBox = true;
            this.dateDOM.Size = new System.Drawing.Size(155, 21);
            this.dateDOM.TabIndex = 47;
            this.dateDOM.Value = new System.DateTime(2014, 1, 21, 0, 0, 0, 0);
            this.dateDOM.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(551, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "NHIS Number:";
            // 
            // txtNHISNumber
            // 
            this.txtNHISNumber.Location = new System.Drawing.Point(629, 189);
            this.txtNHISNumber.Name = "txtNHISNumber";
            this.txtNHISNumber.Size = new System.Drawing.Size(153, 21);
            this.txtNHISNumber.TabIndex = 45;
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.BackColor = System.Drawing.Color.Transparent;
            this.label71.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label71.Location = new System.Drawing.Point(281, 168);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(82, 13);
            this.label71.TabIndex = 44;
            this.label71.Text = "Denomination*:";
            // 
            // btnDenomination
            // 
            this.btnDenomination.Location = new System.Drawing.Point(492, 163);
            this.btnDenomination.Name = "btnDenomination";
            this.btnDenomination.Size = new System.Drawing.Size(30, 23);
            this.btnDenomination.TabIndex = 43;
            this.btnDenomination.Text = "...";
            this.btnDenomination.UseVisualStyleBackColor = true;
            this.btnDenomination.Click += new System.EventHandler(this.btnDenomination_Click);
            // 
            // cboDenomination
            // 
            this.cboDenomination.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDenomination.FormattingEnabled = true;
            this.cboDenomination.Location = new System.Drawing.Point(366, 164);
            this.cboDenomination.Name = "cboDenomination";
            this.cboDenomination.Size = new System.Drawing.Size(126, 21);
            this.cboDenomination.TabIndex = 42;
            // 
            // btnReligion
            // 
            this.btnReligion.Location = new System.Drawing.Point(222, 160);
            this.btnReligion.Name = "btnReligion";
            this.btnReligion.Size = new System.Drawing.Size(30, 23);
            this.btnReligion.TabIndex = 41;
            this.btnReligion.Text = "...";
            this.btnReligion.UseVisualStyleBackColor = true;
            this.btnReligion.Click += new System.EventHandler(this.btnReligion_Click);
            // 
            // button24
            // 
            this.button24.Location = new System.Drawing.Point(754, 165);
            this.button24.Name = "button24";
            this.button24.Size = new System.Drawing.Size(30, 23);
            this.button24.TabIndex = 40;
            this.button24.Text = "...";
            this.button24.UseVisualStyleBackColor = true;
            this.button24.Click += new System.EventHandler(this.btnNationality_Click);
            // 
            // cboNationality
            // 
            this.cboNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNationality.FormattingEnabled = true;
            this.cboNationality.Location = new System.Drawing.Point(629, 166);
            this.cboNationality.Name = "cboNationality";
            this.cboNationality.Size = new System.Drawing.Size(124, 21);
            this.cboNationality.TabIndex = 39;
            this.cboNationality.DropDown += new System.EventHandler(this.cboNationality_DropDown);
            // 
            // cboBirthCountry
            // 
            this.cboBirthCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBirthCountry.FormattingEnabled = true;
            this.cboBirthCountry.Location = new System.Drawing.Point(366, 140);
            this.cboBirthCountry.Name = "cboBirthCountry";
            this.cboBirthCountry.Size = new System.Drawing.Size(156, 21);
            this.cboBirthCountry.TabIndex = 37;
            this.cboBirthCountry.DropDown += new System.EventHandler(this.cboBirthCountry_DropDown);
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(279, 144);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(84, 13);
            this.label70.TabIndex = 36;
            this.label70.Text = " Birth Country*:";
            // 
            // cboBirthDistrict
            // 
            this.cboBirthDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBirthDistrict.FormattingEnabled = true;
            this.cboBirthDistrict.Location = new System.Drawing.Point(366, 116);
            this.cboBirthDistrict.Name = "cboBirthDistrict";
            this.cboBirthDistrict.Size = new System.Drawing.Size(126, 21);
            this.cboBirthDistrict.TabIndex = 35;
            this.cboBirthDistrict.SelectionChangeCommitted += new System.EventHandler(this.cboBirthDistrict_SelectionChangeCommitted);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(753, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(30, 23);
            this.button5.TabIndex = 33;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnTitle_Click);
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(629, 69);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(154, 21);
            this.txtNickName.TabIndex = 32;
            this.txtNickName.Visible = false;
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.BackColor = System.Drawing.Color.Transparent;
            this.label69.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label69.Location = new System.Drawing.Point(566, 74);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(60, 13);
            this.label69.TabIndex = 31;
            this.label69.Text = "Nick Name:";
            this.label69.Visible = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.btnCapture);
            this.groupBox11.Controls.Add(this.btnView);
            this.groupBox11.Controls.Add(this.pictureBox);
            this.groupBox11.Controls.Add(this.browse_imagebtn);
            this.groupBox11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(791, 13);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(236, 183);
            this.groupBox11.TabIndex = 3;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Picture";
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(163, 155);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(61, 22);
            this.btnCapture.TabIndex = 75;
            this.btnCapture.Text = "Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(107, 153);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(51, 23);
            this.btnView.TabIndex = 8;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Visible = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(39, 16);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(170, 131);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // browse_imagebtn
            // 
            this.browse_imagebtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.browse_imagebtn.Location = new System.Drawing.Point(8, 154);
            this.browse_imagebtn.Name = "browse_imagebtn";
            this.browse_imagebtn.Size = new System.Drawing.Size(94, 23);
            this.browse_imagebtn.TabIndex = 0;
            this.browse_imagebtn.Text = "Upload Picture";
            this.browse_imagebtn.UseVisualStyleBackColor = true;
            this.browse_imagebtn.Click += new System.EventHandler(this.browse_imagebtn_Click);
            // 
            // txtOtherName
            // 
            this.txtOtherName.BackColor = System.Drawing.Color.White;
            this.txtOtherName.Location = new System.Drawing.Point(99, 68);
            this.txtOtherName.Name = "txtOtherName";
            this.txtOtherName.Size = new System.Drawing.Size(153, 21);
            this.txtOtherName.TabIndex = 30;
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(27, 72);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(69, 13);
            this.label68.TabIndex = 29;
            this.label68.Text = "Other Name:";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(605, 19);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(64, 13);
            this.label59.TabIndex = 27;
            this.label59.Text = "National ID:";
            // 
            // txtNationalID
            // 
            this.txtNationalID.Location = new System.Drawing.Point(674, 14);
            this.txtNationalID.Name = "txtNationalID";
            this.txtNationalID.Size = new System.Drawing.Size(119, 21);
            this.txtNationalID.TabIndex = 25;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(285, 120);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(78, 13);
            this.label58.TabIndex = 23;
            this.label58.Text = " Birth District*:";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(287, 73);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(75, 13);
            this.label57.TabIndex = 21;
            this.label57.Text = "Maiden Name:";
            // 
            // txtMaidenName
            // 
            this.txtMaidenName.Location = new System.Drawing.Point(365, 68);
            this.txtMaidenName.Name = "txtMaidenName";
            this.txtMaidenName.Size = new System.Drawing.Size(157, 21);
            this.txtMaidenName.TabIndex = 20;
            // 
            // txtPIN
            // 
            this.txtPIN.AcceptsReturn = true;
            this.txtPIN.Location = new System.Drawing.Point(486, 14);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Size = new System.Drawing.Size(115, 21);
            this.txtPIN.TabIndex = 19;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(453, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(28, 13);
            this.label32.TabIndex = 18;
            this.label32.Text = "PIN:";
            // 
            // cmbPOB
            // 
            this.cmbPOB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPOB.FormattingEnabled = true;
            this.cmbPOB.Location = new System.Drawing.Point(629, 117);
            this.cmbPOB.Name = "cmbPOB";
            this.cmbPOB.Size = new System.Drawing.Size(124, 21);
            this.cmbPOB.TabIndex = 16;
            this.cmbPOB.DropDown += new System.EventHandler(this.cmbPOB_DropDown);
            // 
            // btnBirthPlace
            // 
            this.btnBirthPlace.Location = new System.Drawing.Point(753, 115);
            this.btnBirthPlace.Name = "btnBirthPlace";
            this.btnBirthPlace.Size = new System.Drawing.Size(30, 23);
            this.btnBirthPlace.TabIndex = 17;
            this.btnBirthPlace.Text = "...";
            this.btnBirthPlace.UseVisualStyleBackColor = true;
            this.btnBirthPlace.Click += new System.EventHandler(this.btnBirthPlaceForm_Click);
            // 
            // cmbHomeTown
            // 
            this.cmbHomeTown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHomeTown.FormattingEnabled = true;
            this.cmbHomeTown.Location = new System.Drawing.Point(629, 140);
            this.cmbHomeTown.Name = "cmbHomeTown";
            this.cmbHomeTown.Size = new System.Drawing.Size(124, 21);
            this.cmbHomeTown.TabIndex = 13;
            this.cmbHomeTown.DropDown += new System.EventHandler(this.cmbHomeTown_DropDown);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(753, 138);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 23);
            this.button9.TabIndex = 14;
            this.button9.Text = "...";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.btnHomeTown_Click);
            // 
            // btnBirthDistrict
            // 
            this.btnBirthDistrict.Location = new System.Drawing.Point(492, 115);
            this.btnBirthDistrict.Name = "btnBirthDistrict";
            this.btnBirthDistrict.Size = new System.Drawing.Size(30, 23);
            this.btnBirthDistrict.TabIndex = 12;
            this.btnBirthDistrict.Text = "...";
            this.btnBirthDistrict.UseVisualStyleBackColor = true;
            this.btnBirthDistrict.Click += new System.EventHandler(this.btnBirthDistrictForm_Click);
            // 
            // cmbSex
            // 
            this.cmbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSex.FormattingEnabled = true;
            this.cmbSex.Location = new System.Drawing.Point(99, 91);
            this.cmbSex.Name = "cmbSex";
            this.cmbSex.Size = new System.Drawing.Size(154, 21);
            this.cmbSex.TabIndex = 5;
            this.cmbSex.SelectionChangeCommitted += new System.EventHandler(this.cmbSex_SelectionChangeCommitted);
            this.cmbSex.SelectedIndexChanged += new System.EventHandler(this.cmbSex_SelectedIndexChanged);
            this.cmbSex.DropDown += new System.EventHandler(this.cmbSex_DropDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(44, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Gender*:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(31, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Birth Date*:";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.BackColor = System.Drawing.Color.White;
            this.surnameTextBox.Location = new System.Drawing.Point(100, 45);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(153, 21);
            this.surnameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(39, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Surname*:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AcceptsTab = true;
            this.txtFirstName.BackColor = System.Drawing.Color.White;
            this.txtFirstName.Location = new System.Drawing.Point(365, 43);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(157, 21);
            this.txtFirstName.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(559, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Birth Place*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(297, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "First Name*:";
            // 
            // cmbMaritalStatus
            // 
            this.cmbMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaritalStatus.FormattingEnabled = true;
            this.cmbMaritalStatus.Location = new System.Drawing.Point(366, 92);
            this.cmbMaritalStatus.Name = "cmbMaritalStatus";
            this.cmbMaritalStatus.Size = new System.Drawing.Size(156, 21);
            this.cmbMaritalStatus.TabIndex = 4;
            this.cmbMaritalStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbMaritalStatus_SelectionChangeCommitted);
            this.cmbMaritalStatus.DropDown += new System.EventHandler(this.cmbMaritalStatus_DropDown);
            // 
            // dateDOB
            // 
            this.dateDOB.CalendarForeColor = System.Drawing.Color.Yellow;
            this.dateDOB.Checked = false;
            this.dateDOB.CustomFormat = " dd/MM/yyyy";
            this.dateDOB.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDOB.Location = new System.Drawing.Point(98, 137);
            this.dateDOB.Name = "dateDOB";
            this.dateDOB.ShowCheckBox = true;
            this.dateDOB.Size = new System.Drawing.Size(155, 21);
            this.dateDOB.TabIndex = 8;
            this.dateDOB.Value = new System.DateTime(2014, 4, 10, 0, 0, 0, 0);
            // 
            // staffIDTextBox
            // 
            this.staffIDTextBox.BackColor = System.Drawing.Color.White;
            this.staffIDTextBox.Location = new System.Drawing.Point(100, 18);
            this.staffIDTextBox.Name = "staffIDTextBox";
            this.staffIDTextBox.Size = new System.Drawing.Size(153, 21);
            this.staffIDTextBox.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(44, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Staff ID *:";
            // 
            // cmbReligion
            // 
            this.cmbReligion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReligion.FormattingEnabled = true;
            this.cmbReligion.Location = new System.Drawing.Point(98, 161);
            this.cmbReligion.Name = "cmbReligion";
            this.cmbReligion.Size = new System.Drawing.Size(121, 21);
            this.cmbReligion.TabIndex = 11;
            this.cmbReligion.SelectionChangeCommitted += new System.EventHandler(this.cmbReligion_SelectionChangeCommitted);
            this.cmbReligion.DropDown += new System.EventHandler(this.cmbReligion_DropDown);
            // 
            // cmbTitle
            // 
            this.cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(629, 92);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(124, 21);
            this.cmbTitle.TabIndex = 6;
            this.cmbTitle.DropDown += new System.EventHandler(this.cmbTitle_DropDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(280, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Marital Status*:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(589, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Title*:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(553, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Home Town*:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(558, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Nationality*:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(41, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Religion*:";
            // 
            // relationshipsBindingSource
            // 
            this.relationshipsBindingSource.DataMember = "Relationships";
            this.relationshipsBindingSource.DataSource = this.humanResourceBindingSource;
            // 
            // humanResourceBindingSource
            // 
            this.humanResourceBindingSource.DataSource = this.humanResourceDataSet;
            this.humanResourceBindingSource.Position = 0;
            // 
            // humanResourceDataSet
            // 
            this.humanResourceDataSet.DataSetName = "HumanResourceDataSet";
            this.humanResourceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // townsBindingSource
            // 
            this.townsBindingSource.DataMember = "Towns";
            this.townsBindingSource.DataSource = this.humanResourceBindingSource;
            // 
            // occupationsBindingSource
            // 
            this.occupationsBindingSource.DataMember = "Occupations";
            this.occupationsBindingSource.DataSource = this.humanResourceBindingSource;
            // 
            // staffPersonalInfoTab
            // 
            this.staffPersonalInfoTab.Controls.Add(this.personalTabPage);
            this.staffPersonalInfoTab.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffPersonalInfoTab.Location = new System.Drawing.Point(0, 1);
            this.staffPersonalInfoTab.Multiline = true;
            this.staffPersonalInfoTab.Name = "staffPersonalInfoTab";
            this.staffPersonalInfoTab.SelectedIndex = 0;
            this.staffPersonalInfoTab.Size = new System.Drawing.Size(1050, 592);
            this.staffPersonalInfoTab.TabIndex = 0;
            this.staffPersonalInfoTab.Enter += new System.EventHandler(this.personalTabPage_Enter);
            // 
            // allowancesAndDeductionsSummaryBindingSource
            // 
            this.allowancesAndDeductionsSummaryBindingSource.DataMember = "AllowancesAndDeductionsSummary";
            this.allowancesAndDeductionsSummaryBindingSource.DataSource = this.humanResourceBindingSource;
            // 
            // allowancesAndDeductionsSummaryTableAdapter
            // 
            this.allowancesAndDeductionsSummaryTableAdapter.ClearBeforeFill = true;
            // 
            // relationshipsTableAdapter
            // 
            this.relationshipsTableAdapter.ClearBeforeFill = true;
            // 
            // occupationsTableAdapter
            // 
            this.occupationsTableAdapter.ClearBeforeFill = true;
            // 
            // townsTableAdapter
            // 
            this.townsTableAdapter.ClearBeforeFill = true;
            // 
            // btnQuickSearch
            // 
            this.btnQuickSearch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuickSearch.ForeColor = System.Drawing.Color.Black;
            this.btnQuickSearch.Location = new System.Drawing.Point(116, 594);
            this.btnQuickSearch.Name = "btnQuickSearch";
            this.btnQuickSearch.Size = new System.Drawing.Size(102, 23);
            this.btnQuickSearch.TabIndex = 28;
            this.btnQuickSearch.Text = "Quick Search";
            this.btnQuickSearch.UseVisualStyleBackColor = true;
            this.btnQuickSearch.Click += new System.EventHandler(this.btnQuickSearch_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NameOfProfession";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name of Profession";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 341;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 151;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NameOfInstitution";
            this.dataGridViewTextBoxColumn3.HeaderText = "Name of Institution";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 190;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Occupation";
            this.dataGridViewTextBoxColumn4.HeaderText = "ID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 151;
            // 
            // calendarColumn7
            // 
            this.calendarColumn7.HeaderText = "DOB";
            this.calendarColumn7.Name = "calendarColumn7";
            this.calendarColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn7.Width = 106;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "CertificateObtained";
            this.dataGridViewTextBoxColumn5.HeaderText = "Certificate Obtained";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 190;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 196;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "NameOfInstitution";
            this.dataGridViewTextBoxColumn7.HeaderText = "ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 280;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn8.HeaderText = "Address";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 196;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Occupation";
            this.dataGridViewTextBoxColumn9.HeaderText = "Occupation";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 196;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "FullName";
            this.dataGridViewTextBoxColumn10.HeaderText = "Name";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 184;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "NameOfProfession";
            this.dataGridViewTextBoxColumn11.HeaderText = "ID";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 439;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn12.HeaderText = "Name";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 111;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn13.HeaderText = "Telephone";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Visible = false;
            this.dataGridViewTextBoxColumn13.Width = 110;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Occupation";
            this.dataGridViewTextBoxColumn14.HeaderText = "Occupation";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Visible = false;
            this.dataGridViewTextBoxColumn14.Width = 111;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "NameOfInstitution";
            this.dataGridViewTextBoxColumn15.HeaderText = "ID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            this.dataGridViewTextBoxColumn15.Width = 110;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn16.HeaderText = "Address";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Visible = false;
            this.dataGridViewTextBoxColumn16.Width = 110;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "NameOfOrganisation";
            this.dataGridViewTextBoxColumn17.HeaderText = "Name of Organisation";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn17.Visible = false;
            this.dataGridViewTextBoxColumn17.Width = 184;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn18.HeaderText = "ID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Visible = false;
            this.dataGridViewTextBoxColumn18.Width = 265;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "JobDescription";
            this.dataGridViewTextBoxColumn19.HeaderText = "Job Description";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 180;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn20.HeaderText = "Annual Salary";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 191;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "From";
            this.dataGridViewTextBoxColumn21.HeaderText = "From(Year)";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn21.Visible = false;
            this.dataGridViewTextBoxColumn21.Width = 90;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "To";
            this.dataGridViewTextBoxColumn22.HeaderText = "To(Year)";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn22.Visible = false;
            this.dataGridViewTextBoxColumn22.Width = 90;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn23.HeaderText = "ID";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn23.Visible = false;
            this.dataGridViewTextBoxColumn23.Width = 265;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn24.HeaderText = "Date Created";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Visible = false;
            this.dataGridViewTextBoxColumn24.Width = 439;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn25.HeaderText = "Description";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Visible = false;
            this.dataGridViewTextBoxColumn25.Width = 250;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn26.HeaderText = "Document Type";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn26.Visible = false;
            this.dataGridViewTextBoxColumn26.Width = 150;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "NameOfOrganisation";
            this.dataGridViewTextBoxColumn27.HeaderText = "Document Group";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn27.Width = 184;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Occupation";
            this.dataGridViewTextBoxColumn28.HeaderText = "Path";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Visible = false;
            this.dataGridViewTextBoxColumn28.Width = 114;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "JobDescription";
            this.dataGridViewTextBoxColumn29.HeaderText = "Job Description";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Width = 180;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "Monthly Salary";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Width = 110;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn31.HeaderText = "Name";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Width = 265;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "ID";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn33.HeaderText = "Address";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Width = 265;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "Occupation";
            this.dataGridViewTextBoxColumn34.HeaderText = "Occupation";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.Width = 265;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "ID";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Visible = false;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn36.HeaderText = "Date Created";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 191;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn37.HeaderText = "Description";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Width = 191;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "DocumentType";
            this.dataGridViewTextBoxColumn38.HeaderText = "Document Type";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn38.Visible = false;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "Path";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Width = 191;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "DocumentsContent";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.Visible = false;
            // 
            // EmployeeMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(1060, 620);
            this.Controls.Add(this.btnQuickSearch);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.staffPersonalInfoTab);
            this.Controls.Add(this.btnRemoveEmployee);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.viewButton);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EmployeeMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Registration Form";
            this.toolTip1.SetToolTip(this, "AddEmployee");
            this.toolTip2.SetToolTip(this, "toolTip2");
            this.Load += new System.EventHandler(this.EmployeeMaintenance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.docGroupErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationsErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.educationErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employmentErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.professionErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereesErrorProvider)).EndInit();
            this.personalTabPage.ResumeLayout(false);
            this.tabOtherDetails.ResumeLayout(false);
            this.ContactTabPage.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.JobDetailTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.grpEngagementMethod.ResumeLayout(false);
            this.grpEngagementMethod.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.SalaryDetailTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.withholdingTaxRateNumericUpDown)).EndInit();
            this.UserAccountTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notVerifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.verifiedPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fingerPrintPictureBox)).EndInit();
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            this.dependentsTabPage.ResumeLayout(false);
            this.groupBox22.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.groupBox17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRelations)).EndInit();
            this.panel3.ResumeLayout(false);
            this.LanguageTabPage.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridLanguage)).EndInit();
            this.proffessionHistoryTabPage.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProfession)).EndInit();
            this.employmentTabPage.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmploymentHistory)).EndInit();
            this.educationHistoryTabPage.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEducationHistory)).EndInit();
            this.documentsTabPage.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridDocuments)).EndInit();
            this.refereeTabPage.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRefrees)).EndInit();
            this.workPermitTabPage.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            this.groupBox16.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBoxSpecialInformation.ResumeLayout(false);
            this.groupBoxSpecialInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfChildren)).EndInit();
            this.panel9.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationshipsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanResourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanResourceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.townsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupationsBindingSource)).EndInit();
            this.staffPersonalInfoTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allowancesAndDeductionsSummaryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.occupationGroupsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ErrorProvider docGroupErrorProvider;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CalendarColumn calendarColumn1;
        private CalendarColumn calendarColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private CalendarColumn calendarColumn3;
        private CalendarColumn calendarColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private CalendarColumn calendarColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.ErrorProvider fingerPrintErrorProvider;
        private System.Windows.Forms.ErrorProvider staffErrorProvider;
        private System.Windows.Forms.Button btnRemoveEmployee;
        private System.Windows.Forms.ErrorProvider relationsErrorProvider;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.ErrorProvider educationErrorProvider;
        private System.Windows.Forms.ErrorProvider employmentErrorProvider;
        private System.Windows.Forms.ErrorProvider professionErrorProvider;
        private System.Windows.Forms.ErrorProvider refereesErrorProvider;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.TabControl staffPersonalInfoTab;
        private System.Windows.Forms.TabPage personalTabPage;
        private System.Windows.Forms.Button btnClearPersonalInfo;
        private System.Windows.Forms.TabControl tabOtherDetails;
        private System.Windows.Forms.TabPage JobDetailTabPage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpEngagementMethod;
        private System.Windows.Forms.DateTimePicker dateEngagementDate;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.ComboBox cboEngagementType;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox cboSpecialty;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.ComboBox cboEmploymentStatus;
        private System.Windows.Forms.Label startDateLabel;
        private System.Windows.Forms.ComboBox cboJobTitle;
        private System.Windows.Forms.CheckBox probationCheckBox;
        private System.Windows.Forms.ComboBox cboOccupationGrp;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker assumptionDatePicker;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.DateTimePicker DOFADatePicker;
        private System.Windows.Forms.DateTimePicker DOCADatePicker;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TabPage UserAccountTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox notVerifiedPictureBox;
        private System.Windows.Forms.PictureBox verifiedPictureBox;
        private System.Windows.Forms.PictureBox fingerPrintPictureBox;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox fingerPrintTextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ComboBox userRoleComboBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox confirmPasswordTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TabPage SalaryDetailTabPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.TextBox txtTIN;
        private System.Windows.Forms.ComboBox paymentTypeComboBox;
        private System.Windows.Forms.ComboBox cboStep;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.CheckBox incomeCheckBox;
        private System.Windows.Forms.CheckBox ssnitCheckBox;
        private System.Windows.Forms.TextBox ssnitNoTextBox;
        private System.Windows.Forms.Label ssnitNoLabel;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.ComboBox gradeCategoryComboBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox gradeComboBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TabPage LanguageTabPage;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.DataGridView gridLanguage;
        private System.Windows.Forms.TabPage employmentTabPage;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSaveEmploymentHistory;
        private System.Windows.Forms.Button btnClearEmploymentHistory;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView gridEmploymentHistory;
        private System.Windows.Forms.TabPage workPermitTabPage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearWorkPermits;
        private System.Windows.Forms.TabPage documentsTabPage;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnDocumentsClear;
        private System.Windows.Forms.Button btnDocumentsView;
        private System.Windows.Forms.Button btnDocumentsScan;
        private System.Windows.Forms.Button btnDocumentsSave;
        private System.Windows.Forms.Button btnDocumentsUpload;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.DataGridView gridDocuments;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentType;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridDocumentsDocumentGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDocumentsDocumentsContent;
        private System.Windows.Forms.TabPage dependentsTabPage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button23;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.DataGridView gridRelations;
        private System.Windows.Forms.TabPage educationHistoryTabPage;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnSaveEducationHistory;
        private System.Windows.Forms.Button btnClearEducationHistory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridEducationHistory;
        private System.Windows.Forms.TabPage proffessionHistoryTabPage;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gridProfession;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnDenomination;
        private System.Windows.Forms.ComboBox cboDenomination;
        private System.Windows.Forms.Button btnReligion;
        private System.Windows.Forms.Button button24;
        private System.Windows.Forms.ComboBox cboNationality;
        private System.Windows.Forms.ComboBox cboBirthCountry;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.ComboBox cboBirthDistrict;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button browse_imagebtn;
        private System.Windows.Forms.TextBox txtOtherName;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox txtNationalID;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox txtMaidenName;
        private System.Windows.Forms.TextBox txtPIN;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox cmbPOB;
        private System.Windows.Forms.Button btnBirthPlace;
        private System.Windows.Forms.ComboBox cmbHomeTown;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnBirthDistrict;
        private System.Windows.Forms.ComboBox cmbSex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMaritalStatus;
        private System.Windows.Forms.DateTimePicker dateDOB;
        private System.Windows.Forms.TextBox staffIDTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbReligion;
        private System.Windows.Forms.ComboBox cmbTitle;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNHISNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage ContactTabPage;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.TextBox txtContactEmailAddress;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboContactCity;
        private System.Windows.Forms.TextBox txtContactPostalAddress;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtResidentialHouseNumber;
        private System.Windows.Forms.TextBox txtResidentialStreetName;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.ComboBox cboResidentialCountry;
        private System.Windows.Forms.ComboBox cboResidentialCity;
        private System.Windows.Forms.ComboBox cboResidentialRegion;
        private System.Windows.Forms.ComboBox cboContactHomeTown;
        private System.Windows.Forms.ComboBox cboContactCountry;
        private System.Windows.Forms.ComboBox cboContactRegion;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label lblDOM;
        private System.Windows.Forms.DateTimePicker dateDOM;
        private CalendarColumn DateOfBirth;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.TextBox txtBankDetailAccountNumber;
        private System.Windows.Forms.ComboBox cboBankDetailBranch;
        private System.Windows.Forms.ComboBox cboBankDetailAccountType;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TabPage refereeTabPage;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView gridRefrees;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btnClearRefrees;
        private System.Windows.Forms.Button btnSaveRefrees;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.ComboBox cmbDisabled;
        private System.Windows.Forms.ComboBox cmbBonded;
        private System.Windows.Forms.ComboBox cmbApplied;
        private System.Windows.Forms.ComboBox cmbConvicted;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.DateTimePicker dateExpires;
        private System.Windows.Forms.DateTimePicker dateIssued;
        private System.Windows.Forms.TextBox txtPassportNotes;
        private System.Windows.Forms.TextBox txtPassportNo;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.ComboBox cmbVisaType;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox txtVisaNotes;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.TextBox txtWorkPermitID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbWorkPermit;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.DateTimePicker dateWorkPermit;
        private System.Windows.Forms.TextBox txtWorkPermitNotes;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnClearProfessionHistory;
        private System.Windows.Forms.Button btnSaveProfessionHistory;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btnClearLanguage;
        private System.Windows.Forms.Button btnSaveLanguage;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnSaveFamilyDetails;
        private System.Windows.Forms.Button btnClearFamilyDetails;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.CheckedListBox checkedListBoxContract;
        private System.Windows.Forms.ComboBox cboEngagementGradeLeaving;
        private System.Windows.Forms.DateTimePicker dateEngagementEndingDate;
        private System.Windows.Forms.DateTimePicker dateEngagementEffectiveDate;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.ComboBox cboAppointmentType;
        private System.Windows.Forms.ComboBox cboEngagementGradeOn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateEmploymentDate;
        private System.Windows.Forms.Label label94;
        private CalendarColumn ExpiryDate;
        private System.Windows.Forms.Label lblProbationStatus;
        private System.Windows.Forms.ComboBox cboProbationStatus;
        private CalendarColumn calendarColumn6;
        private System.Windows.Forms.ComboBox cboBankDetailName;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.RadioButton transferredOutRadioButton;
        private System.Windows.Forms.RadioButton transferredInRadioButton;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.ComboBox cboBand;
        private System.Windows.Forms.MaskedTextBox txtContactTelephone;
        private System.Windows.Forms.MaskedTextBox txtContactMobileNumber;
        private System.Windows.Forms.NumericUpDown txtNumberOfChildren;
        private System.Windows.Forms.BindingSource occupationGroupsBindingSource;
        private System.Windows.Forms.BindingSource humanResourceBindingSource;
        private System.Windows.Forms.BindingSource allowancesAndDeductionsSummaryBindingSource;
        private eMAS.HumanResourceDataSetTableAdapters.AllowancesAndDeductionsSummaryTableAdapter allowancesAndDeductionsSummaryTableAdapter;
        private System.Windows.Forms.BindingSource relationshipsBindingSource;
        private eMAS.HumanResourceDataSetTableAdapters.RelationshipsTableAdapter relationshipsTableAdapter;
        private System.Windows.Forms.BindingSource occupationsBindingSource;
        private eMAS.HumanResourceDataSetTableAdapters.OccupationsTableAdapter occupationsTableAdapter;
        private System.Windows.Forms.BindingSource townsBindingSource;
        private eMAS.HumanResourceDataSetTableAdapters.TownsTableAdapter townsTableAdapter;
        private System.Windows.Forms.TextBox txtBankDetailAccountName;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox txtBankDetailAddress;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.NumericUpDown txtDuration;
        private System.Windows.Forms.TextBox txtVisaNo;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Button btnFamilyDetailsRemove;
        private System.Windows.Forms.Button btnLanguageRemove;
        private System.Windows.Forms.Button btnProfessionHistoryRemove;
        private System.Windows.Forms.Button btnEmploymentHistoryRemove;
        private System.Windows.Forms.Button btnEducationHistoryRemove;
        private System.Windows.Forms.CheckBox checkBoxHasPassport;
        private System.Windows.Forms.CheckBox checkBoxHasVisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsID;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsNameOfInstitution;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualificationsCertificateObtained;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn qualificationsToYear;
        private System.Windows.Forms.Button btnDocumentsRemove;
        private System.Windows.Forms.Button btnRefreeRemove;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboZone;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.CheckBox withholdingTaxCheckBox;
        private System.Windows.Forms.Label labelRate;
        private System.Windows.Forms.RadioButton withholdingTaxRateRadioButton;
        private System.Windows.Forms.RadioButton withholdingTaxFixedAmountRadioButton;
        private System.Windows.Forms.TextBox withholdingTaxFixedAmountTextBox;
        private System.Windows.Forms.NumericUpDown withholdingTaxRateNumericUpDown;
        private System.Windows.Forms.ComboBox calculatedOnComboBox;
        private System.Windows.Forms.Label labelCalculateOn;
        private System.Windows.Forms.TextBox susuPlusContributionAmountTextBox;
        private System.Windows.Forms.CheckBox susuPlusContributionCheckBox;
        private eMAS.HumanResourceDataSet humanResourceDataSet;
        private System.Windows.Forms.ComboBox txtFileNumber;
        private System.Windows.Forms.Button btnRefreshRelations;
        private System.Windows.Forms.Button btnRefreshLanguages;
        private System.Windows.Forms.Button btnRefreshProfessionHistory;
        private System.Windows.Forms.Button btnRefreshEmploymentHistory;
        private System.Windows.Forms.Button btnRefreshEducationHistory;
        private System.Windows.Forms.Button btnRefreshDocuments;
        private System.Windows.Forms.Button btnRefreshRefrees;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesName;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesOccupation;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesTelNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereesEmail;
        private System.Windows.Forms.DateTimePicker gradeDatePicker;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.DateTimePicker zoneDatePicker;
        private System.Windows.Forms.ComboBox cboQualificationType;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.ComboBox cboBirthRegion;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.CheckBox checkBoxMechanised;
        private System.Windows.Forms.Button btnQuickSearch;
        private System.Windows.Forms.ComboBox cboSalaryGrouping;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.DataGridViewTextBoxColumn professionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn professionNameOfProfession;
        private System.Windows.Forms.DataGridViewComboBoxColumn professionFromMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn professionFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn professionToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn professionToYear;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ComboBox cboDisabilityType;
        private System.Windows.Forms.DateTimePicker datePickerDisabilityDate;
        private System.Windows.Forms.CheckBox checkBoxDisability;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.ComboBox cboLicenceType;
        private System.Windows.Forms.GroupBox groupBoxSpecialInformation;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.TextBox txtLicenceNumber;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Button btnDisabilityType;
        private System.Windows.Forms.TextBox txtEngagementAnnualSalary;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceNameOfOrganisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceJobTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceAnnualSalary;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceFromYear;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToMonth;
        private System.Windows.Forms.DataGridViewComboBoxColumn experienceToYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn experienceReasonForLeaving;
        private CalendarColumn calendarColumn7;
        private System.Windows.Forms.Label label101;
        private System.Windows.Forms.ComboBox cboGradeOnFirstAppointment;
        private System.Windows.Forms.Label label102;
        private System.Windows.Forms.ComboBox cboLeaveEntitlement;
        private System.Windows.Forms.CheckBox checkBoxActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationOccupationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationRelationshipID;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationRelationship;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationType;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationOccupation;
        private CalendarColumn relationDOB;
        private System.Windows.Forms.DataGridViewComboBoxColumn relationPOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationPOBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn relationAddress;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.CheckBox isProvidentFundCheckBox;
        private System.Windows.Forms.CheckBox checkBoxExemptFromSecondTier;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridLanguageID;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLanguage;
        private System.Windows.Forms.DataGridViewComboBoxColumn colLanguageLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLanguageID;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.Label label103;
        private System.Windows.Forms.ComboBox cboRace;
        private System.Windows.Forms.Label label104;
        private System.Windows.Forms.TextBox txtTribe;
        private System.Windows.Forms.Label label107;
        private System.Windows.Forms.TextBox txtOverseer;
        private System.Windows.Forms.TextBox staffIDtxt;
        private System.Windows.Forms.Label staffNoLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridStaffNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Label lblPF;
        private System.Windows.Forms.NumericUpDown numericPF;
    }
}