namespace eMAS
{
    using System.Windows.Forms; 

    partial class MainMDI
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
            if (MessageBox.Show("Are you sure you want to exit the Application?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.recruitmentManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internshipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollProcessingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryInfoFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkSalaryInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDutyAllowancesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.riskAllowancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxReliefToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalClaimsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalClaimsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveMedicalCliamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansSalaryAdvanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryAdvanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrearsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrearsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allowanceArrearsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeBanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuickbookMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuickbookDataGenerationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeeManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveRoasterFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateAnnualLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annualLeavecCalculateFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annualLeaveReverseFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveRequestFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveRecommendationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveApprovalFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveRecallFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveResumptionFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveEncashmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studyLeaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excuseDutytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excuseDutyRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excuseDutyRecommendationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exuseDutyHRRecommendationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excuseDutyApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excuseDutyResumptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinstatingSeparatedStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfStaffDueForSeparationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinstatingTransferedStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performalAppraisalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnustaffsObjectives = new System.Windows.Forms.ToolStripMenuItem();
            this.mnustaffAppraisal = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnutrainingBondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuexternalTrainingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExternalTrainingJustification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExternalTrainingHRRecommendation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExternalTrainingCEOApproval = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingEvaluationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promotionAndDemotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.demotionFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correctDemotionDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDemotionApprovalFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.correctPromotionDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffPromotionApprovalFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfPromotedStaffsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfStaffDueForPromotionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDueForPromotionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.healthAndSafetyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disciplinaryRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanctionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffUnderInvestigationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinstatingSanctionedStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanctionsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accomodationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.houseOfficersRotationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.confirmationsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkConfirmationsFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incrementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalIncrementFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseGeneralIncrementFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectiveIncrementFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseSelectiveIncrementFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfJobTitleFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfGradeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfNameFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfEmploymentDateFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfDOBFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfStatusFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfAppointmentTypeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfMaritalStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOfQualificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeofDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.approveChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.organizationalReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listUnitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowanceSetupReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductionSetupReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listGradeCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listJobTitlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBankReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBankBranchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payRollManagementReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryOfLoansToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryLoansPaymentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSNITReturnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSNITContributionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondTierPensionPaymentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firstTierPensionPaymentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incomeTaxReturnsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payRollAndPaySlipReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalClaimsMonthlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherDeductionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryDeductionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailDeductionsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.susuMonthlyContributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withholdingMonthlyContrbutionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankAdviceSlipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherAllowanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryAllowanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailAllowanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taxReliefToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.staffManagementReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailedProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pensioneersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcuseDutyReport = new System.Windows.Forms.ToolStripMenuItem();
            this.lengthOfServiceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffSummaryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByAppointmentReportToolStrilMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByAgeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByGenderReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListRetiringReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByBankReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByJobReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByZoneReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByGradeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDurationOnGradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDurationOnGradeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDueForPromotionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDurationInBranchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDueForTransferReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffDurationAtAZoneReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffListByQualificationTypeReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinersReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birthdayReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birthdayLettersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sickLeaveListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalBillsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hospitalAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spectaclesIssuedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lensIssuedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listStaffDueForSpectaclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listStaffDueForLensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dependentsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleReportMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionalReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attendanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutyRoasterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveRoasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffLeaveBalancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveResumptionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reprintOfLeaveLetterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveEncashmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studyLeaveReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcuseDutyRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcuseDutyReportForm = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseAttendanceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExternalTrainingReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrainingBondsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingEvaluationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.establishmentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.establishmentListSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.establishmentListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lengthOfServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ageDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionByAgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionByCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionByGradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genderDistributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionByZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.distributionByToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinersStatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wastageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wastageReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeJobTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffChangesReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separationReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicalClaimsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internshipReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promotionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicantReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanctionReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppraisalReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppraisalListReport = new System.Windows.Forms.ToolStripMenuItem();
            this.locumReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recruitmentReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicantListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vacancyListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interviewListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listInternsNotOnPayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferListReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAndAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dutyRoasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAttendanceLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enrollUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCheckOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeCardManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companySystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyBasicInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employmentSystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nationalitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIdentificationTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.townsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titlesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.religionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainingtypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denominationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relationshipsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bankBranchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialtyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualificationTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSponsoredProgrammesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraingAttendanceModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAttendedSchoolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrainingSponsors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTrainingOrganizers = new System.Windows.Forms.ToolStripMenuItem();
            this.occupationalGroupingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promotionTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payrollManagementSystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allowanceTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deductioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incomeTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sSNITContributionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanSetupFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherDeductionsSetupFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.payGradesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeCategoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradeSetupFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradesalaries = new System.Windows.Forms.ToolStripMenuItem();
            this.salaryStruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalaryPaymentAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.timeAndAttendanceSystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roasterGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shiftsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.holidaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffManagementSystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveTypeFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.annualLeaveEntitlementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sanctionTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppraisalFactors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppraisalRatings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAppraisalPeriods = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveLetterSignatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userAccountSystemSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managePermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recruitmentManagementToolStripMenuItem,
            this.payrollProcessingToolStripMenuItem,
            this.employeeManagementToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.timeAndAttendanceToolStripMenuItem,
            this.systemSetupToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // recruitmentManagementToolStripMenuItem
            // 
            this.recruitmentManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vacancyToolStripMenuItem,
            this.applicantToolStripMenuItem,
            this.interviewToolStripMenuItem,
            this.employeeToolStripMenuItem,
            this.internshipToolStripMenuItem,
            this.sMSToolStripMenuItem,
            this.notificationsToolStripMenuItem});
            this.recruitmentManagementToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recruitmentManagementToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.recruitmentManagementToolStripMenuItem.Name = "recruitmentManagementToolStripMenuItem";
            this.recruitmentManagementToolStripMenuItem.Size = new System.Drawing.Size(161, 20);
            this.recruitmentManagementToolStripMenuItem.Text = "Recruitment Management";
            // 
            // vacancyToolStripMenuItem
            // 
            this.vacancyToolStripMenuItem.Name = "vacancyToolStripMenuItem";
            this.vacancyToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.vacancyToolStripMenuItem.Text = "Vacancy";
            this.vacancyToolStripMenuItem.Click += new System.EventHandler(this.vacancyToolStripMenuItem_Click);
            // 
            // applicantToolStripMenuItem
            // 
            this.applicantToolStripMenuItem.Name = "applicantToolStripMenuItem";
            this.applicantToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.applicantToolStripMenuItem.Text = "Applicant";
            this.applicantToolStripMenuItem.Click += new System.EventHandler(this.applicantToolStripMenuItem_Click);
            // 
            // interviewToolStripMenuItem
            // 
            this.interviewToolStripMenuItem.Name = "interviewToolStripMenuItem";
            this.interviewToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.interviewToolStripMenuItem.Text = "Interviews";
            this.interviewToolStripMenuItem.Click += new System.EventHandler(this.interviewToolStripMenuItem_Click);
            // 
            // employeeToolStripMenuItem
            // 
            this.employeeToolStripMenuItem.Name = "employeeToolStripMenuItem";
            this.employeeToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.employeeToolStripMenuItem.Text = "Employee";
            this.employeeToolStripMenuItem.Click += new System.EventHandler(this.employeeToolStripMenuItem_Click);
            // 
            // internshipToolStripMenuItem
            // 
            this.internshipToolStripMenuItem.Name = "internshipToolStripMenuItem";
            this.internshipToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.internshipToolStripMenuItem.Text = "Internship";
            this.internshipToolStripMenuItem.Click += new System.EventHandler(this.internshipToolStripMenuItem_Click);
            // 
            // sMSToolStripMenuItem
            // 
            this.sMSToolStripMenuItem.Name = "sMSToolStripMenuItem";
            this.sMSToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.sMSToolStripMenuItem.Text = "SMS";
            this.sMSToolStripMenuItem.Visible = false;
            this.sMSToolStripMenuItem.Click += new System.EventHandler(this.sMSToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            this.notificationsToolStripMenuItem.Click += new System.EventHandler(this.notificationsToolStripMenuItem_Click);
            // 
            // payrollProcessingToolStripMenuItem
            // 
            this.payrollProcessingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salaryInfoToolStripMenuItem,
            this.allowancesToolStripMenuItem,
            this.deductionsToolStripMenuItem,
            this.mnuDutyAllowancesMenuItem,
            this.riskAllowancesToolStripMenuItem,
            this.taxReliefToolStripMenuItem,
            this.medicalClaimsToolStripMenuItem,
            this.loansSalaryAdvanceToolStripMenuItem,
            this.overTimeToolStripMenuItem,
            this.arrearsToolStripMenuItem,
            this.employeeBanksToolStripMenuItem,
            this.payrollGenerationToolStripMenuItem,
            this.QuickbookMappingToolStripMenuItem,
            this.QuickbookDataGenerationToolStripMenuItem});
            this.payrollProcessingToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payrollProcessingToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.payrollProcessingToolStripMenuItem.Name = "payrollProcessingToolStripMenuItem";
            this.payrollProcessingToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.payrollProcessingToolStripMenuItem.Text = "Payroll Management";
            // 
            // salaryInfoToolStripMenuItem
            // 
            this.salaryInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salaryInfoFormToolStripMenuItem,
            this.bulkSalaryInfoToolStripMenuItem});
            this.salaryInfoToolStripMenuItem.Name = "salaryInfoToolStripMenuItem";
            this.salaryInfoToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.salaryInfoToolStripMenuItem.Text = "Salary Info";
            // 
            // salaryInfoFormToolStripMenuItem
            // 
            this.salaryInfoFormToolStripMenuItem.Name = "salaryInfoFormToolStripMenuItem";
            this.salaryInfoFormToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.salaryInfoFormToolStripMenuItem.Text = "Salary Info";
            this.salaryInfoFormToolStripMenuItem.Click += new System.EventHandler(this.salaryInfoToolStripMenuItem_Click);
            // 
            // bulkSalaryInfoToolStripMenuItem
            // 
            this.bulkSalaryInfoToolStripMenuItem.Name = "bulkSalaryInfoToolStripMenuItem";
            this.bulkSalaryInfoToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.bulkSalaryInfoToolStripMenuItem.Text = "Bulk Salary Info";
            this.bulkSalaryInfoToolStripMenuItem.Click += new System.EventHandler(this.bulkSalaryInfoToolStripMenuItem_Click);
            // 
            // allowancesToolStripMenuItem
            // 
            this.allowancesToolStripMenuItem.Name = "allowancesToolStripMenuItem";
            this.allowancesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.allowancesToolStripMenuItem.Text = "Allowances";
            this.allowancesToolStripMenuItem.Click += new System.EventHandler(this.allowancesToolStripMenuItem_Click);
            // 
            // deductionsToolStripMenuItem
            // 
            this.deductionsToolStripMenuItem.Name = "deductionsToolStripMenuItem";
            this.deductionsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.deductionsToolStripMenuItem.Text = "Deductions";
            this.deductionsToolStripMenuItem.Click += new System.EventHandler(this.deductionsToolStripMenuItem_Click);
            // 
            // mnuDutyAllowancesMenuItem
            // 
            this.mnuDutyAllowancesMenuItem.Name = "mnuDutyAllowancesMenuItem";
            this.mnuDutyAllowancesMenuItem.Size = new System.Drawing.Size(215, 22);
            this.mnuDutyAllowancesMenuItem.Text = "Duty Allowances";
            this.mnuDutyAllowancesMenuItem.Click += new System.EventHandler(this.mnuDutyAllowancesMenuItem_Click);
            // 
            // riskAllowancesToolStripMenuItem
            // 
            this.riskAllowancesToolStripMenuItem.Name = "riskAllowancesToolStripMenuItem";
            this.riskAllowancesToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.riskAllowancesToolStripMenuItem.Text = "Risk Allowances";
            this.riskAllowancesToolStripMenuItem.Click += new System.EventHandler(this.riskAllowancesToolStripMenuItem_Click);
            // 
            // taxReliefToolStripMenuItem
            // 
            this.taxReliefToolStripMenuItem.Name = "taxReliefToolStripMenuItem";
            this.taxReliefToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.taxReliefToolStripMenuItem.Text = "Tax Relief";
            this.taxReliefToolStripMenuItem.Click += new System.EventHandler(this.taxReliefToolStripMenuItem_Click);
            // 
            // medicalClaimsToolStripMenuItem
            // 
            this.medicalClaimsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.medicalClaimsFormToolStripMenuItem,
            this.approveMedicalCliamsToolStripMenuItem});
            this.medicalClaimsToolStripMenuItem.Name = "medicalClaimsToolStripMenuItem";
            this.medicalClaimsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.medicalClaimsToolStripMenuItem.Text = "Medical Claims";
            // 
            // medicalClaimsFormToolStripMenuItem
            // 
            this.medicalClaimsFormToolStripMenuItem.Name = "medicalClaimsFormToolStripMenuItem";
            this.medicalClaimsFormToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.medicalClaimsFormToolStripMenuItem.Text = "Medical Claims";
            this.medicalClaimsFormToolStripMenuItem.Click += new System.EventHandler(this.medicalClaimsToolStripMenuItem_Click);
            // 
            // approveMedicalCliamsToolStripMenuItem
            // 
            this.approveMedicalCliamsToolStripMenuItem.Name = "approveMedicalCliamsToolStripMenuItem";
            this.approveMedicalCliamsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.approveMedicalCliamsToolStripMenuItem.Text = "Approve Medical Claims";
            this.approveMedicalCliamsToolStripMenuItem.Click += new System.EventHandler(this.approveMedicalCliamsToolStripMenuItem_Click);
            // 
            // loansSalaryAdvanceToolStripMenuItem
            // 
            this.loansSalaryAdvanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanToolStripMenuItem,
            this.loanPaymentsToolStripMenuItem,
            this.salaryAdvanceToolStripMenuItem});
            this.loansSalaryAdvanceToolStripMenuItem.Name = "loansSalaryAdvanceToolStripMenuItem";
            this.loansSalaryAdvanceToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.loansSalaryAdvanceToolStripMenuItem.Text = "Loans";
            // 
            // loanToolStripMenuItem
            // 
            this.loanToolStripMenuItem.Name = "loanToolStripMenuItem";
            this.loanToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loanToolStripMenuItem.Text = "Loan";
            this.loanToolStripMenuItem.Click += new System.EventHandler(this.loanToolStripMenuItem_Click);
            // 
            // loanPaymentsToolStripMenuItem
            // 
            this.loanPaymentsToolStripMenuItem.Name = "loanPaymentsToolStripMenuItem";
            this.loanPaymentsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.loanPaymentsToolStripMenuItem.Text = "Loan Payments";
            this.loanPaymentsToolStripMenuItem.Visible = false;
            this.loanPaymentsToolStripMenuItem.Click += new System.EventHandler(this.loanPaymentsToolStripMenuItem_Click);
            // 
            // salaryAdvanceToolStripMenuItem
            // 
            this.salaryAdvanceToolStripMenuItem.Name = "salaryAdvanceToolStripMenuItem";
            this.salaryAdvanceToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.salaryAdvanceToolStripMenuItem.Text = "Salary Advance";
            this.salaryAdvanceToolStripMenuItem.Click += new System.EventHandler(this.salaryAdvanceToolStripMenuItem_Click);
            // 
            // overTimeToolStripMenuItem
            // 
            this.overTimeToolStripMenuItem.Name = "overTimeToolStripMenuItem";
            this.overTimeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.overTimeToolStripMenuItem.Text = "OverTime";
            this.overTimeToolStripMenuItem.Click += new System.EventHandler(this.overTimeToolStripMenuItem_Click);
            // 
            // arrearsToolStripMenuItem
            // 
            this.arrearsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrearsToolStripMenuItem1,
            this.allowanceArrearsToolStripMenuItem});
            this.arrearsToolStripMenuItem.Name = "arrearsToolStripMenuItem";
            this.arrearsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.arrearsToolStripMenuItem.Text = "Arrears";
            this.arrearsToolStripMenuItem.Click += new System.EventHandler(this.arrearsToolStripMenuItem_Click);
            // 
            // arrearsToolStripMenuItem1
            // 
            this.arrearsToolStripMenuItem1.Name = "arrearsToolStripMenuItem1";
            this.arrearsToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.arrearsToolStripMenuItem1.Text = "Arrears";
            this.arrearsToolStripMenuItem1.Click += new System.EventHandler(this.arrearsToolStripMenuItem1_Click);
            // 
            // allowanceArrearsToolStripMenuItem
            // 
            this.allowanceArrearsToolStripMenuItem.Name = "allowanceArrearsToolStripMenuItem";
            this.allowanceArrearsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.allowanceArrearsToolStripMenuItem.Text = "Allowance Arrears";
            this.allowanceArrearsToolStripMenuItem.Click += new System.EventHandler(this.allowanceArrearsToolStripMenuItem_Click);
            // 
            // employeeBanksToolStripMenuItem
            // 
            this.employeeBanksToolStripMenuItem.Name = "employeeBanksToolStripMenuItem";
            this.employeeBanksToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.employeeBanksToolStripMenuItem.Text = "Employee Banks";
            this.employeeBanksToolStripMenuItem.Click += new System.EventHandler(this.employeeBanksToolStripMenuItem_Click);
            // 
            // payrollGenerationToolStripMenuItem
            // 
            this.payrollGenerationToolStripMenuItem.Name = "payrollGenerationToolStripMenuItem";
            this.payrollGenerationToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.payrollGenerationToolStripMenuItem.Text = "Pay Roll Generation";
            this.payrollGenerationToolStripMenuItem.Click += new System.EventHandler(this.payrollGenerationToolStripMenuItem_Click);
            // 
            // QuickbookMappingToolStripMenuItem
            // 
            this.QuickbookMappingToolStripMenuItem.Name = "QuickbookMappingToolStripMenuItem";
            this.QuickbookMappingToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.QuickbookMappingToolStripMenuItem.Text = "Map Quickbook Accounts";
            this.QuickbookMappingToolStripMenuItem.Click += new System.EventHandler(this.QuickbookMappingToolStripMenuItem_Click);
            // 
            // QuickbookDataGenerationToolStripMenuItem
            // 
            this.QuickbookDataGenerationToolStripMenuItem.Name = "QuickbookDataGenerationToolStripMenuItem";
            this.QuickbookDataGenerationToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.QuickbookDataGenerationToolStripMenuItem.Text = "Generate Quickbook Data";
            this.QuickbookDataGenerationToolStripMenuItem.Click += new System.EventHandler(this.QuickbookDataGenerationToolStripMenuItem_Click);
            // 
            // employeeManagementToolStripMenuItem
            // 
            this.employeeManagementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaveToolStripMenuItem,
            this.excuseDutytoolStripMenuItem,
            this.terminationToolStripMenuItem,
            this.performalAppraisalToolStripMenuItem,
            this.trainingToolStripMenuItem,
            this.promotionAndDemotionToolStripMenuItem,
            this.healthAndSafetyToolStripMenuItem,
            this.disciplinaryRecordsToolStripMenuItem,
            this.accomodationToolStripMenuItem,
            this.houseOfficersRotationToolStripMenuItem,
            this.confirmationToolStripMenuItem,
            this.incrementToolStripMenuItem,
            this.locumToolStripMenuItem,
            this.changeOfJobTitleFormToolStripMenuItem,
            this.changeOfGradeFormToolStripMenuItem,
            this.changeOfNameFormToolStripMenuItem,
            this.changeOfEmploymentDateFormToolStripMenuItem,
            this.changeOfDOBFormToolStripMenuItem,
            this.changeOfStatusFormToolStripMenuItem,
            this.changeOfAppointmentTypeFormToolStripMenuItem,
            this.changeOfMaritalStatusToolStripMenuItem,
            this.changeOfQualificationToolStripMenuItem,
            this.changeofDetailsToolStripMenuItem});
            this.employeeManagementToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeManagementToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.employeeManagementToolStripMenuItem.Name = "employeeManagementToolStripMenuItem";
            this.employeeManagementToolStripMenuItem.ShowShortcutKeys = false;
            this.employeeManagementToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.employeeManagementToolStripMenuItem.Text = "Employee Management";
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaveRoasterFormToolStripMenuItem,
            this.calculateAnnualLeaveToolStripMenuItem,
            this.leaveRequestFormToolStripMenuItem,
            this.leaveRecommendationFormToolStripMenuItem,
            this.leaveApprovalFormToolStripMenuItem,
            this.leaveRecallFormToolStripMenuItem,
            this.leaveResumptionFormToolStripMenuItem,
            this.leaveEncashmentToolStripMenuItem,
            this.studyLeaveToolStripMenuItem});
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.leaveToolStripMenuItem.Text = "Leave";
            // 
            // leaveRoasterFormToolStripMenuItem
            // 
            this.leaveRoasterFormToolStripMenuItem.Name = "leaveRoasterFormToolStripMenuItem";
            this.leaveRoasterFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveRoasterFormToolStripMenuItem.Text = "Leave Roster";
            this.leaveRoasterFormToolStripMenuItem.Click += new System.EventHandler(this.scheduleLeaveToolStripMenuItem_Click);
            // 
            // calculateAnnualLeaveToolStripMenuItem
            // 
            this.calculateAnnualLeaveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.annualLeavecCalculateFormToolStripMenuItem,
            this.annualLeaveReverseFormToolStripMenuItem});
            this.calculateAnnualLeaveToolStripMenuItem.Name = "calculateAnnualLeaveToolStripMenuItem";
            this.calculateAnnualLeaveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.calculateAnnualLeaveToolStripMenuItem.Text = "Calculate Annual Leave";
            // 
            // annualLeavecCalculateFormToolStripMenuItem
            // 
            this.annualLeavecCalculateFormToolStripMenuItem.Name = "annualLeavecCalculateFormToolStripMenuItem";
            this.annualLeavecCalculateFormToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.annualLeavecCalculateFormToolStripMenuItem.Text = "Calculate";
            this.annualLeavecCalculateFormToolStripMenuItem.Click += new System.EventHandler(this.annualLeavecClculateToolStripMenuItem_Click);
            // 
            // annualLeaveReverseFormToolStripMenuItem
            // 
            this.annualLeaveReverseFormToolStripMenuItem.Name = "annualLeaveReverseFormToolStripMenuItem";
            this.annualLeaveReverseFormToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.annualLeaveReverseFormToolStripMenuItem.Text = "Reverse";
            this.annualLeaveReverseFormToolStripMenuItem.Click += new System.EventHandler(this.reverseToolStripMenuItem_Click);
            // 
            // leaveRequestFormToolStripMenuItem
            // 
            this.leaveRequestFormToolStripMenuItem.Name = "leaveRequestFormToolStripMenuItem";
            this.leaveRequestFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveRequestFormToolStripMenuItem.Text = "Leave Request";
            this.leaveRequestFormToolStripMenuItem.Click += new System.EventHandler(this.requestsToolStripMenuItem_Click);
            // 
            // leaveRecommendationFormToolStripMenuItem
            // 
            this.leaveRecommendationFormToolStripMenuItem.Name = "leaveRecommendationFormToolStripMenuItem";
            this.leaveRecommendationFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveRecommendationFormToolStripMenuItem.Text = "Leave Recommendation";
            this.leaveRecommendationFormToolStripMenuItem.Click += new System.EventHandler(this.leaveRecommendationToolStripMenuItem_Click);
            // 
            // leaveApprovalFormToolStripMenuItem
            // 
            this.leaveApprovalFormToolStripMenuItem.Name = "leaveApprovalFormToolStripMenuItem";
            this.leaveApprovalFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveApprovalFormToolStripMenuItem.Text = "Leave Approval";
            this.leaveApprovalFormToolStripMenuItem.Click += new System.EventHandler(this.leaveApprovalToolStripMenuItem_Click);
            // 
            // leaveRecallFormToolStripMenuItem
            // 
            this.leaveRecallFormToolStripMenuItem.Name = "leaveRecallFormToolStripMenuItem";
            this.leaveRecallFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveRecallFormToolStripMenuItem.Text = "Recall From Leave";
            this.leaveRecallFormToolStripMenuItem.Click += new System.EventHandler(this.recallFromLeaveToolStripMenuItem_Click);
            // 
            // leaveResumptionFormToolStripMenuItem
            // 
            this.leaveResumptionFormToolStripMenuItem.Name = "leaveResumptionFormToolStripMenuItem";
            this.leaveResumptionFormToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveResumptionFormToolStripMenuItem.Text = "Leave Resumption";
            this.leaveResumptionFormToolStripMenuItem.Click += new System.EventHandler(this.leaveResumptionToolStripMenuItem_Click);
            // 
            // leaveEncashmentToolStripMenuItem
            // 
            this.leaveEncashmentToolStripMenuItem.Name = "leaveEncashmentToolStripMenuItem";
            this.leaveEncashmentToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.leaveEncashmentToolStripMenuItem.Text = "Leave Encashment";
            this.leaveEncashmentToolStripMenuItem.Click += new System.EventHandler(this.leaveEncashmentToolStripMenuItem_Click);
            // 
            // studyLeaveToolStripMenuItem
            // 
            this.studyLeaveToolStripMenuItem.Name = "studyLeaveToolStripMenuItem";
            this.studyLeaveToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.studyLeaveToolStripMenuItem.Text = "Study Leave";
            this.studyLeaveToolStripMenuItem.Click += new System.EventHandler(this.studyLeaveToolStripMenuItem_Click);
            // 
            // excuseDutytoolStripMenuItem
            // 
            this.excuseDutytoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excuseDutyRequestToolStripMenuItem,
            this.excuseDutyRecommendationToolStripMenuItem,
            this.exuseDutyHRRecommendationToolStripMenuItem,
            this.excuseDutyApprovalToolStripMenuItem,
            this.excuseDutyResumptionToolStripMenuItem});
            this.excuseDutytoolStripMenuItem.Name = "excuseDutytoolStripMenuItem";
            this.excuseDutytoolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.excuseDutytoolStripMenuItem.Text = "Excuse Duty";
            // 
            // excuseDutyRequestToolStripMenuItem
            // 
            this.excuseDutyRequestToolStripMenuItem.Name = "excuseDutyRequestToolStripMenuItem";
            this.excuseDutyRequestToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.excuseDutyRequestToolStripMenuItem.Text = "Excuse Duty Request";
            this.excuseDutyRequestToolStripMenuItem.Click += new System.EventHandler(this.requestToolStripMenuItem_Click);
            // 
            // excuseDutyRecommendationToolStripMenuItem
            // 
            this.excuseDutyRecommendationToolStripMenuItem.Name = "excuseDutyRecommendationToolStripMenuItem";
            this.excuseDutyRecommendationToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.excuseDutyRecommendationToolStripMenuItem.Text = "Excuse Duty Supervisor\'s Recommendation";
            this.excuseDutyRecommendationToolStripMenuItem.Click += new System.EventHandler(this.excuseDutyRecommendationToolStripMenuItem_Click);
            // 
            // exuseDutyHRRecommendationToolStripMenuItem
            // 
            this.exuseDutyHRRecommendationToolStripMenuItem.Name = "exuseDutyHRRecommendationToolStripMenuItem";
            this.exuseDutyHRRecommendationToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.exuseDutyHRRecommendationToolStripMenuItem.Text = "Exuse Duty HR Recommendation";
            this.exuseDutyHRRecommendationToolStripMenuItem.Click += new System.EventHandler(this.exuseDutyHRRecommendationToolStripMenuItem_Click);
            // 
            // excuseDutyApprovalToolStripMenuItem
            // 
            this.excuseDutyApprovalToolStripMenuItem.Name = "excuseDutyApprovalToolStripMenuItem";
            this.excuseDutyApprovalToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.excuseDutyApprovalToolStripMenuItem.Text = "Excuse Duty Approval";
            this.excuseDutyApprovalToolStripMenuItem.Click += new System.EventHandler(this.excuseDutyApprovalToolStripMenuItem_Click);
            // 
            // excuseDutyResumptionToolStripMenuItem
            // 
            this.excuseDutyResumptionToolStripMenuItem.Name = "excuseDutyResumptionToolStripMenuItem";
            this.excuseDutyResumptionToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.excuseDutyResumptionToolStripMenuItem.Text = "Excuse Duty Resumption";
            this.excuseDutyResumptionToolStripMenuItem.Click += new System.EventHandler(this.excuseDutyResumptionToolStripMenuItem_Click);
            // 
            // terminationToolStripMenuItem
            // 
            this.terminationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separationToolStripMenuItem,
            this.reinstatingSeparatedStaffToolStripMenuItem,
            this.listOfStaffDueForSeparationToolStripMenuItem,
            this.transferToolStripMenuItem,
            this.reinstatingTransferedStaffToolStripMenuItem});
            this.terminationToolStripMenuItem.Name = "terminationToolStripMenuItem";
            this.terminationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.terminationToolStripMenuItem.Text = "Attrition";
            // 
            // separationToolStripMenuItem
            // 
            this.separationToolStripMenuItem.Name = "separationToolStripMenuItem";
            this.separationToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.separationToolStripMenuItem.Text = "Separation";
            this.separationToolStripMenuItem.Click += new System.EventHandler(this.terminationToolStripMenuItem_Click);
            // 
            // reinstatingSeparatedStaffToolStripMenuItem
            // 
            this.reinstatingSeparatedStaffToolStripMenuItem.Name = "reinstatingSeparatedStaffToolStripMenuItem";
            this.reinstatingSeparatedStaffToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.reinstatingSeparatedStaffToolStripMenuItem.Text = "Reinstating Separated Staff";
            this.reinstatingSeparatedStaffToolStripMenuItem.Click += new System.EventHandler(this.reinstatingSeparatedStaffToolStripMenuItem_Click);
            // 
            // listOfStaffDueForSeparationToolStripMenuItem
            // 
            this.listOfStaffDueForSeparationToolStripMenuItem.Name = "listOfStaffDueForSeparationToolStripMenuItem";
            this.listOfStaffDueForSeparationToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.listOfStaffDueForSeparationToolStripMenuItem.Text = "Separation Approval";
            this.listOfStaffDueForSeparationToolStripMenuItem.Click += new System.EventHandler(this.listOfStaffDueForSeparationToolStripMenuItem_Click);
            // 
            // transferToolStripMenuItem
            // 
            this.transferToolStripMenuItem.Name = "transferToolStripMenuItem";
            this.transferToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.transferToolStripMenuItem.Text = "Transfer";
            this.transferToolStripMenuItem.Click += new System.EventHandler(this.transfersToolStripMenuItem1_Click);
            // 
            // reinstatingTransferedStaffToolStripMenuItem
            // 
            this.reinstatingTransferedStaffToolStripMenuItem.Name = "reinstatingTransferedStaffToolStripMenuItem";
            this.reinstatingTransferedStaffToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.reinstatingTransferedStaffToolStripMenuItem.Text = "Reinstating Transfered staff";
            this.reinstatingTransferedStaffToolStripMenuItem.Click += new System.EventHandler(this.reinstatingTransferedStaffToolStripMenuItem_Click);
            // 
            // performalAppraisalToolStripMenuItem
            // 
            this.performalAppraisalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnustaffsObjectives,
            this.mnustaffAppraisal});
            this.performalAppraisalToolStripMenuItem.Name = "performalAppraisalToolStripMenuItem";
            this.performalAppraisalToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.performalAppraisalToolStripMenuItem.Text = "Performance Appraisal";
            this.performalAppraisalToolStripMenuItem.Visible = false;
            // 
            // mnustaffsObjectives
            // 
            this.mnustaffsObjectives.Name = "mnustaffsObjectives";
            this.mnustaffsObjectives.Size = new System.Drawing.Size(169, 22);
            this.mnustaffsObjectives.Text = "Staff\'s Objectives";
            this.mnustaffsObjectives.Click += new System.EventHandler(this.mnustaffsObjectives_Click);
            // 
            // mnustaffAppraisal
            // 
            this.mnustaffAppraisal.Name = "mnustaffAppraisal";
            this.mnustaffAppraisal.Size = new System.Drawing.Size(169, 22);
            this.mnustaffAppraisal.Text = "Staff Appraisal";
            this.mnustaffAppraisal.Click += new System.EventHandler(this.mnustaffAppraisal_Click);
            // 
            // trainingToolStripMenuItem
            // 
            this.trainingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainingAttendanceToolStripMenuItem,
            this.listOfAttendanceToolStripMenuItem,
            this.mnutrainingBondToolStripMenuItem,
            this.mnuexternalTrainingToolStripMenuItem,
            this.mnuExternalTrainingJustification,
            this.mnuExternalTrainingHRRecommendation,
            this.mnuExternalTrainingCEOApproval,
            this.trainingEvaluationToolStripMenuItem});
            this.trainingToolStripMenuItem.Name = "trainingToolStripMenuItem";
            this.trainingToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.trainingToolStripMenuItem.Text = "Training";
            // 
            // trainingAttendanceToolStripMenuItem
            // 
            this.trainingAttendanceToolStripMenuItem.Name = "trainingAttendanceToolStripMenuItem";
            this.trainingAttendanceToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.trainingAttendanceToolStripMenuItem.Text = "Training Attendance";
            this.trainingAttendanceToolStripMenuItem.Click += new System.EventHandler(this.trainingAttendanceToolStripMenuItem_Click);
            // 
            // listOfAttendanceToolStripMenuItem
            // 
            this.listOfAttendanceToolStripMenuItem.Name = "listOfAttendanceToolStripMenuItem";
            this.listOfAttendanceToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.listOfAttendanceToolStripMenuItem.Text = "List of Attendance";
            this.listOfAttendanceToolStripMenuItem.Click += new System.EventHandler(this.listOfAttendanceToolStripMenuItem_Click);
            // 
            // mnutrainingBondToolStripMenuItem
            // 
            this.mnutrainingBondToolStripMenuItem.Name = "mnutrainingBondToolStripMenuItem";
            this.mnutrainingBondToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.mnutrainingBondToolStripMenuItem.Text = "Training Bond";
            this.mnutrainingBondToolStripMenuItem.Click += new System.EventHandler(this.trainingBondToolStripMenuItem_Click);
            // 
            // mnuexternalTrainingToolStripMenuItem
            // 
            this.mnuexternalTrainingToolStripMenuItem.Name = "mnuexternalTrainingToolStripMenuItem";
            this.mnuexternalTrainingToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.mnuexternalTrainingToolStripMenuItem.Text = "External Training";
            this.mnuexternalTrainingToolStripMenuItem.Click += new System.EventHandler(this.mnuexternalTrainingToolStripMenuItem_Click);
            // 
            // mnuExternalTrainingJustification
            // 
            this.mnuExternalTrainingJustification.Name = "mnuExternalTrainingJustification";
            this.mnuExternalTrainingJustification.Size = new System.Drawing.Size(283, 22);
            this.mnuExternalTrainingJustification.Text = "External Training HOD Justification";
            this.mnuExternalTrainingJustification.Click += new System.EventHandler(this.mnuExternalTrainingJustification_Click);
            // 
            // mnuExternalTrainingHRRecommendation
            // 
            this.mnuExternalTrainingHRRecommendation.Name = "mnuExternalTrainingHRRecommendation";
            this.mnuExternalTrainingHRRecommendation.Size = new System.Drawing.Size(283, 22);
            this.mnuExternalTrainingHRRecommendation.Text = "External Training HR Recommendation";
            this.mnuExternalTrainingHRRecommendation.Click += new System.EventHandler(this.mnuExternalTrainingHRRecommendation_Click);
            // 
            // mnuExternalTrainingCEOApproval
            // 
            this.mnuExternalTrainingCEOApproval.Name = "mnuExternalTrainingCEOApproval";
            this.mnuExternalTrainingCEOApproval.Size = new System.Drawing.Size(283, 22);
            this.mnuExternalTrainingCEOApproval.Text = "External Training CEO Approval";
            this.mnuExternalTrainingCEOApproval.Visible = false;
            this.mnuExternalTrainingCEOApproval.Click += new System.EventHandler(this.mnuExternalTrainingCEOApproval_Click);
            // 
            // trainingEvaluationToolStripMenuItem
            // 
            this.trainingEvaluationToolStripMenuItem.Name = "trainingEvaluationToolStripMenuItem";
            this.trainingEvaluationToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.trainingEvaluationToolStripMenuItem.Text = "Training Evaluation";
            this.trainingEvaluationToolStripMenuItem.Click += new System.EventHandler(this.trainingEvaluationToolStripMenuItem_Click);
            // 
            // promotionAndDemotionToolStripMenuItem
            // 
            this.promotionAndDemotionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promotionToolStripMenuItem,
            this.demotionToolStripMenuItem,
            this.correctPromotionDateToolStripMenuItem,
            this.staffPromotionApprovalFormToolStripMenuItem,
            this.listOfPromotedStaffsToolStripMenuItem,
            this.listOfStaffDueForPromotionReportToolStripMenuItem,
            this.staffDueForPromotionToolStripMenuItem});
            this.promotionAndDemotionToolStripMenuItem.Name = "promotionAndDemotionToolStripMenuItem";
            this.promotionAndDemotionToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.promotionAndDemotionToolStripMenuItem.Text = "Promotions";
            // 
            // promotionToolStripMenuItem
            // 
            this.promotionToolStripMenuItem.Name = "promotionToolStripMenuItem";
            this.promotionToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.promotionToolStripMenuItem.Text = "Promotion";
            this.promotionToolStripMenuItem.Click += new System.EventHandler(this.promotionsToolStripMenuItem_Click);
            // 
            // demotionToolStripMenuItem
            // 
            this.demotionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.demotionFormToolStripMenuItem,
            this.correctDemotionDateToolStripMenuItem,
            this.staffDemotionApprovalFormToolStripMenuItem});
            this.demotionToolStripMenuItem.Name = "demotionToolStripMenuItem";
            this.demotionToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.demotionToolStripMenuItem.Text = "Demotion";
            this.demotionToolStripMenuItem.Visible = false;
            // 
            // demotionFormToolStripMenuItem
            // 
            this.demotionFormToolStripMenuItem.Name = "demotionFormToolStripMenuItem";
            this.demotionFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.demotionFormToolStripMenuItem.Text = "Demotion";
            this.demotionFormToolStripMenuItem.Click += new System.EventHandler(this.demotionToolStripMenuItem_Click);
            // 
            // correctDemotionDateToolStripMenuItem
            // 
            this.correctDemotionDateToolStripMenuItem.Name = "correctDemotionDateToolStripMenuItem";
            this.correctDemotionDateToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.correctDemotionDateToolStripMenuItem.Text = "Correct Demotion Date";
            this.correctDemotionDateToolStripMenuItem.Click += new System.EventHandler(this.correctDemotionDateToolStripMenuItem_Click);
            // 
            // staffDemotionApprovalFormToolStripMenuItem
            // 
            this.staffDemotionApprovalFormToolStripMenuItem.Name = "staffDemotionApprovalFormToolStripMenuItem";
            this.staffDemotionApprovalFormToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.staffDemotionApprovalFormToolStripMenuItem.Text = "Staff Demotion Approval";
            this.staffDemotionApprovalFormToolStripMenuItem.Click += new System.EventHandler(this.demotionListOfStaffDueForDemotionToolStripMenuItem_Click);
            // 
            // correctPromotionDateToolStripMenuItem
            // 
            this.correctPromotionDateToolStripMenuItem.Name = "correctPromotionDateToolStripMenuItem";
            this.correctPromotionDateToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.correctPromotionDateToolStripMenuItem.Text = "Correct Promotion Date";
            this.correctPromotionDateToolStripMenuItem.Visible = false;
            this.correctPromotionDateToolStripMenuItem.Click += new System.EventHandler(this.editPromotionDateToolStripMenuItem_Click);
            // 
            // staffPromotionApprovalFormToolStripMenuItem
            // 
            this.staffPromotionApprovalFormToolStripMenuItem.Name = "staffPromotionApprovalFormToolStripMenuItem";
            this.staffPromotionApprovalFormToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.staffPromotionApprovalFormToolStripMenuItem.Text = "Staff Promotion Approval Form";
            this.staffPromotionApprovalFormToolStripMenuItem.Click += new System.EventHandler(this.promotionListOfStaffDueForPromotionToolStripMenuItem_Click);
            // 
            // listOfPromotedStaffsToolStripMenuItem
            // 
            this.listOfPromotedStaffsToolStripMenuItem.Name = "listOfPromotedStaffsToolStripMenuItem";
            this.listOfPromotedStaffsToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.listOfPromotedStaffsToolStripMenuItem.Text = "List Of Promoted Staffs";
            this.listOfPromotedStaffsToolStripMenuItem.Click += new System.EventHandler(this.promotionListToolStripMenuItem_Click);
            // 
            // listOfStaffDueForPromotionReportToolStripMenuItem
            // 
            this.listOfStaffDueForPromotionReportToolStripMenuItem.Name = "listOfStaffDueForPromotionReportToolStripMenuItem";
            this.listOfStaffDueForPromotionReportToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.listOfStaffDueForPromotionReportToolStripMenuItem.Text = "Promotion Report Cutomization";
            this.listOfStaffDueForPromotionReportToolStripMenuItem.Click += new System.EventHandler(this.listOfStaffToolStripMenuItem_Click);
            // 
            // staffDueForPromotionToolStripMenuItem
            // 
            this.staffDueForPromotionToolStripMenuItem.Name = "staffDueForPromotionToolStripMenuItem";
            this.staffDueForPromotionToolStripMenuItem.Size = new System.Drawing.Size(245, 22);
            this.staffDueForPromotionToolStripMenuItem.Text = "Staff Due for Promotion";
            this.staffDueForPromotionToolStripMenuItem.Click += new System.EventHandler(this.staffDueForPromotionToolStripMenuItem_Click_1);
            // 
            // healthAndSafetyToolStripMenuItem
            // 
            this.healthAndSafetyToolStripMenuItem.Name = "healthAndSafetyToolStripMenuItem";
            this.healthAndSafetyToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.healthAndSafetyToolStripMenuItem.Text = "Health And Safety";
            this.healthAndSafetyToolStripMenuItem.Visible = false;
            // 
            // disciplinaryRecordsToolStripMenuItem
            // 
            this.disciplinaryRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sanctionsToolStripMenuItem,
            this.staffUnderInvestigationToolStripMenuItem,
            this.reinstatingSanctionedStaffToolStripMenuItem,
            this.sanctionsListToolStripMenuItem});
            this.disciplinaryRecordsToolStripMenuItem.Name = "disciplinaryRecordsToolStripMenuItem";
            this.disciplinaryRecordsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.disciplinaryRecordsToolStripMenuItem.Text = "Disciplinary Records";
            // 
            // sanctionsToolStripMenuItem
            // 
            this.sanctionsToolStripMenuItem.Name = "sanctionsToolStripMenuItem";
            this.sanctionsToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.sanctionsToolStripMenuItem.Text = "Sanctions";
            this.sanctionsToolStripMenuItem.Click += new System.EventHandler(this.sanctionsToolStripMenuItem_Click);
            // 
            // staffUnderInvestigationToolStripMenuItem
            // 
            this.staffUnderInvestigationToolStripMenuItem.Name = "staffUnderInvestigationToolStripMenuItem";
            this.staffUnderInvestigationToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.staffUnderInvestigationToolStripMenuItem.Text = "Staff Under Investigation";
            this.staffUnderInvestigationToolStripMenuItem.Click += new System.EventHandler(this.sanctionsListOfStaffDueToolStripMenuItem_Click);
            // 
            // reinstatingSanctionedStaffToolStripMenuItem
            // 
            this.reinstatingSanctionedStaffToolStripMenuItem.Name = "reinstatingSanctionedStaffToolStripMenuItem";
            this.reinstatingSanctionedStaffToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.reinstatingSanctionedStaffToolStripMenuItem.Text = "Reinstating Sanctioned Staff";
            this.reinstatingSanctionedStaffToolStripMenuItem.Click += new System.EventHandler(this.editSanctionStaffToolStripMenuItem_Click);
            // 
            // sanctionsListToolStripMenuItem
            // 
            this.sanctionsListToolStripMenuItem.Name = "sanctionsListToolStripMenuItem";
            this.sanctionsListToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.sanctionsListToolStripMenuItem.Text = "List of Sanctions";
            this.sanctionsListToolStripMenuItem.Visible = false;
            this.sanctionsListToolStripMenuItem.Click += new System.EventHandler(this.sanctionsListToolStripMenuItem_Click);
            // 
            // accomodationToolStripMenuItem
            // 
            this.accomodationToolStripMenuItem.Name = "accomodationToolStripMenuItem";
            this.accomodationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.accomodationToolStripMenuItem.Text = "Accomodation";
            this.accomodationToolStripMenuItem.Visible = false;
            this.accomodationToolStripMenuItem.Click += new System.EventHandler(this.accomodationToolStripMenuItem_Click);
            // 
            // houseOfficersRotationToolStripMenuItem
            // 
            this.houseOfficersRotationToolStripMenuItem.Name = "houseOfficersRotationToolStripMenuItem";
            this.houseOfficersRotationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.houseOfficersRotationToolStripMenuItem.Text = "House Officers Rotation";
            this.houseOfficersRotationToolStripMenuItem.Visible = false;
            // 
            // confirmationToolStripMenuItem
            // 
            this.confirmationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.confirmationsFormToolStripMenuItem,
            this.bulkConfirmationsFormToolStripMenuItem,
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem});
            this.confirmationToolStripMenuItem.Name = "confirmationToolStripMenuItem";
            this.confirmationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.confirmationToolStripMenuItem.Text = "Confirmations";
            // 
            // confirmationsFormToolStripMenuItem
            // 
            this.confirmationsFormToolStripMenuItem.Name = "confirmationsFormToolStripMenuItem";
            this.confirmationsFormToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.confirmationsFormToolStripMenuItem.Text = "Confirmations";
            this.confirmationsFormToolStripMenuItem.Click += new System.EventHandler(this.confirmationsToolStripMenuItem_Click);
            // 
            // bulkConfirmationsFormToolStripMenuItem
            // 
            this.bulkConfirmationsFormToolStripMenuItem.Name = "bulkConfirmationsFormToolStripMenuItem";
            this.bulkConfirmationsFormToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.bulkConfirmationsFormToolStripMenuItem.Text = "Bulk Confirmations";
            this.bulkConfirmationsFormToolStripMenuItem.Click += new System.EventHandler(this.bulkConfirmationsToolStripMenuItem_Click);
            // 
            // listOfStaffOnProbationDueForApprovalToolStripMenuItem
            // 
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem.Name = "listOfStaffOnProbationDueForApprovalToolStripMenuItem";
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem.Text = "List Of Staff On Probation Due For Approval";
            this.listOfStaffOnProbationDueForApprovalToolStripMenuItem.Click += new System.EventHandler(this.listOfStaffDueForConfirmationToolStripMenuItem_Click);
            // 
            // incrementToolStripMenuItem
            // 
            this.incrementToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generalIncrementFormToolStripMenuItem,
            this.reverseGeneralIncrementFormToolStripMenuItem,
            this.selectiveIncrementFormToolStripMenuItem,
            this.reverseSelectiveIncrementFormToolStripMenuItem});
            this.incrementToolStripMenuItem.Name = "incrementToolStripMenuItem";
            this.incrementToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.incrementToolStripMenuItem.Text = "Increment";
            // 
            // generalIncrementFormToolStripMenuItem
            // 
            this.generalIncrementFormToolStripMenuItem.Name = "generalIncrementFormToolStripMenuItem";
            this.generalIncrementFormToolStripMenuItem.ShowShortcutKeys = false;
            this.generalIncrementFormToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.generalIncrementFormToolStripMenuItem.Text = "General Increment";
            this.generalIncrementFormToolStripMenuItem.Click += new System.EventHandler(this.generalIncrementToolStripMenuItem_Click);
            // 
            // reverseGeneralIncrementFormToolStripMenuItem
            // 
            this.reverseGeneralIncrementFormToolStripMenuItem.Name = "reverseGeneralIncrementFormToolStripMenuItem";
            this.reverseGeneralIncrementFormToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.reverseGeneralIncrementFormToolStripMenuItem.Text = "Reverse General Increment";
            this.reverseGeneralIncrementFormToolStripMenuItem.Click += new System.EventHandler(this.selectiveIncrementToolStripMenuItem_Click);
            // 
            // selectiveIncrementFormToolStripMenuItem
            // 
            this.selectiveIncrementFormToolStripMenuItem.Name = "selectiveIncrementFormToolStripMenuItem";
            this.selectiveIncrementFormToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.selectiveIncrementFormToolStripMenuItem.Text = "Selective Increment";
            this.selectiveIncrementFormToolStripMenuItem.Click += new System.EventHandler(this.selectiveIncrementToolStripMenuItem1_Click);
            // 
            // reverseSelectiveIncrementFormToolStripMenuItem
            // 
            this.reverseSelectiveIncrementFormToolStripMenuItem.Name = "reverseSelectiveIncrementFormToolStripMenuItem";
            this.reverseSelectiveIncrementFormToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.reverseSelectiveIncrementFormToolStripMenuItem.Text = "Reverse Selective Increment";
            this.reverseSelectiveIncrementFormToolStripMenuItem.Click += new System.EventHandler(this.reverseSelectiveIncrementToolStripMenuItem_Click);
            // 
            // locumToolStripMenuItem
            // 
            this.locumToolStripMenuItem.Name = "locumToolStripMenuItem";
            this.locumToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.locumToolStripMenuItem.Text = "Locum";
            this.locumToolStripMenuItem.Click += new System.EventHandler(this.locumToolStripMenuItem_Click);
            // 
            // changeOfJobTitleFormToolStripMenuItem
            // 
            this.changeOfJobTitleFormToolStripMenuItem.Name = "changeOfJobTitleFormToolStripMenuItem";
            this.changeOfJobTitleFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfJobTitleFormToolStripMenuItem.Text = "Change Of Job Title";
            this.changeOfJobTitleFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfJobTitleToolStripMenuItem_Click);
            // 
            // changeOfGradeFormToolStripMenuItem
            // 
            this.changeOfGradeFormToolStripMenuItem.Name = "changeOfGradeFormToolStripMenuItem";
            this.changeOfGradeFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfGradeFormToolStripMenuItem.Text = "Change Of Grade";
            this.changeOfGradeFormToolStripMenuItem.Click += new System.EventHandler(this.changeGradeToolStripMenuItem_Click);
            // 
            // changeOfNameFormToolStripMenuItem
            // 
            this.changeOfNameFormToolStripMenuItem.Name = "changeOfNameFormToolStripMenuItem";
            this.changeOfNameFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfNameFormToolStripMenuItem.Text = "Change Of Name";
            this.changeOfNameFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfNameToolStripMenuItem_Click);
            // 
            // changeOfEmploymentDateFormToolStripMenuItem
            // 
            this.changeOfEmploymentDateFormToolStripMenuItem.Name = "changeOfEmploymentDateFormToolStripMenuItem";
            this.changeOfEmploymentDateFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfEmploymentDateFormToolStripMenuItem.Text = "Change of Employment Date";
            this.changeOfEmploymentDateFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfEmploymentDateToolStripMenuItem_Click);
            // 
            // changeOfDOBFormToolStripMenuItem
            // 
            this.changeOfDOBFormToolStripMenuItem.Name = "changeOfDOBFormToolStripMenuItem";
            this.changeOfDOBFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfDOBFormToolStripMenuItem.Text = "Change Of DOB";
            this.changeOfDOBFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfDOBToolStripMenuItem_Click);
            // 
            // changeOfStatusFormToolStripMenuItem
            // 
            this.changeOfStatusFormToolStripMenuItem.Name = "changeOfStatusFormToolStripMenuItem";
            this.changeOfStatusFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfStatusFormToolStripMenuItem.Text = "Change Of Status";
            this.changeOfStatusFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfStatusToolStripMenuItem_Click);
            // 
            // changeOfAppointmentTypeFormToolStripMenuItem
            // 
            this.changeOfAppointmentTypeFormToolStripMenuItem.Name = "changeOfAppointmentTypeFormToolStripMenuItem";
            this.changeOfAppointmentTypeFormToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfAppointmentTypeFormToolStripMenuItem.Text = "Change Of Appointment Type";
            this.changeOfAppointmentTypeFormToolStripMenuItem.Click += new System.EventHandler(this.changeOfAppointmentTypeToolStripMenuItem_Click);
            // 
            // changeOfMaritalStatusToolStripMenuItem
            // 
            this.changeOfMaritalStatusToolStripMenuItem.Name = "changeOfMaritalStatusToolStripMenuItem";
            this.changeOfMaritalStatusToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfMaritalStatusToolStripMenuItem.Text = "Change of Marital Status";
            this.changeOfMaritalStatusToolStripMenuItem.Click += new System.EventHandler(this.changeOfMaritalStatusToolStripMenuItem_Click);
            // 
            // changeOfQualificationToolStripMenuItem
            // 
            this.changeOfQualificationToolStripMenuItem.Name = "changeOfQualificationToolStripMenuItem";
            this.changeOfQualificationToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeOfQualificationToolStripMenuItem.Text = "Change of Qualification";
            this.changeOfQualificationToolStripMenuItem.Click += new System.EventHandler(this.changeOfQualificationToolStripMenuItem_Click);
            // 
            // changeofDetailsToolStripMenuItem
            // 
            this.changeofDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestChangesToolStripMenuItem,
            this.approveChangesToolStripMenuItem});
            this.changeofDetailsToolStripMenuItem.Name = "changeofDetailsToolStripMenuItem";
            this.changeofDetailsToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.changeofDetailsToolStripMenuItem.Text = "Change Of Details";
            // 
            // requestChangesToolStripMenuItem
            // 
            this.requestChangesToolStripMenuItem.Name = "requestChangesToolStripMenuItem";
            this.requestChangesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.requestChangesToolStripMenuItem.Text = "Request Changes";
            this.requestChangesToolStripMenuItem.Click += new System.EventHandler(this.requestChangesToolStripMenuItem_Click);
            // 
            // approveChangesToolStripMenuItem
            // 
            this.approveChangesToolStripMenuItem.Name = "approveChangesToolStripMenuItem";
            this.approveChangesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.approveChangesToolStripMenuItem.Text = "Approve Changes";
            this.approveChangesToolStripMenuItem.Click += new System.EventHandler(this.approveChangesToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizationalReportsToolStripMenuItem,
            this.payRollManagementReportsToolStripMenuItem,
            this.staffManagementReportsToolStripMenuItem,
            this.transactionalReportsToolStripMenuItem,
            this.recruitmentReportsToolStripMenuItem});
            this.reportsToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // organizationalReportsToolStripMenuItem
            // 
            this.organizationalReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.departmentsToolStripMenuItem,
            this.listUnitToolStripMenuItem,
            this.allowanceSetupReportToolStripMenuItem,
            this.deductionSetupReportToolStripMenuItem,
            this.listGradeCategoriesToolStripMenuItem,
            this.gradesToolStripMenuItem,
            this.listZonesToolStripMenuItem,
            this.listJobTitlesToolStripMenuItem,
            this.listBankReportToolStripMenuItem,
            this.listBankBranchesToolStripMenuItem});
            this.organizationalReportsToolStripMenuItem.Name = "organizationalReportsToolStripMenuItem";
            this.organizationalReportsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.organizationalReportsToolStripMenuItem.Text = "Organizational Reports";
            // 
            // departmentsToolStripMenuItem
            // 
            this.departmentsToolStripMenuItem.Name = "departmentsToolStripMenuItem";
            this.departmentsToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.departmentsToolStripMenuItem.Text = "List Departments";
            this.departmentsToolStripMenuItem.Click += new System.EventHandler(this.departmentsToolStripMenuItem_Click);
            // 
            // listUnitToolStripMenuItem
            // 
            this.listUnitToolStripMenuItem.Name = "listUnitToolStripMenuItem";
            this.listUnitToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listUnitToolStripMenuItem.Text = "List Unit";
            this.listUnitToolStripMenuItem.Click += new System.EventHandler(this.listUnitToolStripMenuItem_Click);
            // 
            // allowanceSetupReportToolStripMenuItem
            // 
            this.allowanceSetupReportToolStripMenuItem.Name = "allowanceSetupReportToolStripMenuItem";
            this.allowanceSetupReportToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.allowanceSetupReportToolStripMenuItem.Text = "List Allowances";
            this.allowanceSetupReportToolStripMenuItem.Click += new System.EventHandler(this.allowanceToolStripMenuItem1_Click);
            // 
            // deductionSetupReportToolStripMenuItem
            // 
            this.deductionSetupReportToolStripMenuItem.Name = "deductionSetupReportToolStripMenuItem";
            this.deductionSetupReportToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.deductionSetupReportToolStripMenuItem.Text = "List Deductions";
            this.deductionSetupReportToolStripMenuItem.Click += new System.EventHandler(this.deductionToolStripMenuItem1_Click);
            // 
            // listGradeCategoriesToolStripMenuItem
            // 
            this.listGradeCategoriesToolStripMenuItem.Name = "listGradeCategoriesToolStripMenuItem";
            this.listGradeCategoriesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listGradeCategoriesToolStripMenuItem.Text = "List Grade Categories";
            this.listGradeCategoriesToolStripMenuItem.Click += new System.EventHandler(this.listGradeCategoriesToolStripMenuItem_Click);
            // 
            // gradesToolStripMenuItem
            // 
            this.gradesToolStripMenuItem.Name = "gradesToolStripMenuItem";
            this.gradesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.gradesToolStripMenuItem.Text = "List Grades";
            this.gradesToolStripMenuItem.Click += new System.EventHandler(this.gradesToolStripMenuItem_Click);
            // 
            // listZonesToolStripMenuItem
            // 
            this.listZonesToolStripMenuItem.Name = "listZonesToolStripMenuItem";
            this.listZonesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listZonesToolStripMenuItem.Text = "List Zones";
            this.listZonesToolStripMenuItem.Click += new System.EventHandler(this.listZonesToolStripMenuItem_Click);
            // 
            // listJobTitlesToolStripMenuItem
            // 
            this.listJobTitlesToolStripMenuItem.Name = "listJobTitlesToolStripMenuItem";
            this.listJobTitlesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listJobTitlesToolStripMenuItem.Text = "List Job Titles";
            this.listJobTitlesToolStripMenuItem.Click += new System.EventHandler(this.listJobTitlesToolStripMenuItem_Click);
            // 
            // listBankReportToolStripMenuItem
            // 
            this.listBankReportToolStripMenuItem.Name = "listBankReportToolStripMenuItem";
            this.listBankReportToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listBankReportToolStripMenuItem.Text = "List Bank";
            this.listBankReportToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem10_Click);
            // 
            // listBankBranchesToolStripMenuItem
            // 
            this.listBankBranchesToolStripMenuItem.Name = "listBankBranchesToolStripMenuItem";
            this.listBankBranchesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.listBankBranchesToolStripMenuItem.Text = "List Bank Branches";
            this.listBankBranchesToolStripMenuItem.Click += new System.EventHandler(this.listBankBranchesToolStripMenuItem_Click);
            // 
            // payRollManagementReportsToolStripMenuItem
            // 
            this.payRollManagementReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loansToolStripMenuItem,
            this.sSNITReturnsToolStripMenuItem,
            this.incomeTaxReturnsReportToolStripMenuItem,
            this.payRollAndPaySlipReportToolStripMenuItem,
            this.medicalClaimsMonthlyReportToolStripMenuItem,
            this.otherDeductionsToolStripMenuItem,
            this.bankAdviceSlipToolStripMenuItem,
            this.otherAllowanceToolStripMenuItem,
            this.mnuOverTimeToolStripMenuItem,
            this.taxReliefToolStripMenuItem1});
            this.payRollManagementReportsToolStripMenuItem.Name = "payRollManagementReportsToolStripMenuItem";
            this.payRollManagementReportsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.payRollManagementReportsToolStripMenuItem.Text = "PayRoll Management Reports";
            // 
            // loansToolStripMenuItem
            // 
            this.loansToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loanReportToolStripMenuItem,
            this.summaryOfLoansToolStripMenuItem,
            this.paymentsToolStripMenuItem,
            this.summaryLoansPaymentsToolStripMenuItem});
            this.loansToolStripMenuItem.Name = "loansToolStripMenuItem";
            this.loansToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.loansToolStripMenuItem.Text = "Loans";
            // 
            // loanReportToolStripMenuItem
            // 
            this.loanReportToolStripMenuItem.Name = "loanReportToolStripMenuItem";
            this.loanReportToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.loanReportToolStripMenuItem.Text = "Loans Taken Report";
            this.loanReportToolStripMenuItem.Click += new System.EventHandler(this.loansToolStripMenuItem3_Click);
            // 
            // summaryOfLoansToolStripMenuItem
            // 
            this.summaryOfLoansToolStripMenuItem.Name = "summaryOfLoansToolStripMenuItem";
            this.summaryOfLoansToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.summaryOfLoansToolStripMenuItem.Text = "Pay Roll Loans Report";
            this.summaryOfLoansToolStripMenuItem.Click += new System.EventHandler(this.summaryOfLoansToolStripMenuItem_Click);
            // 
            // paymentsToolStripMenuItem
            // 
            this.paymentsToolStripMenuItem.Name = "paymentsToolStripMenuItem";
            this.paymentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.paymentsToolStripMenuItem.Text = "Detailed Loans Payments";
            this.paymentsToolStripMenuItem.Visible = false;
            this.paymentsToolStripMenuItem.Click += new System.EventHandler(this.paymentsToolStripMenuItem_Click);
            // 
            // summaryLoansPaymentsToolStripMenuItem
            // 
            this.summaryLoansPaymentsToolStripMenuItem.Name = "summaryLoansPaymentsToolStripMenuItem";
            this.summaryLoansPaymentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.summaryLoansPaymentsToolStripMenuItem.Text = "Summary Loans Payments";
            this.summaryLoansPaymentsToolStripMenuItem.Visible = false;
            // 
            // sSNITReturnsToolStripMenuItem
            // 
            this.sSNITReturnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sSNITContributionReportToolStripMenuItem,
            this.secondTierPensionPaymentReportToolStripMenuItem,
            this.firstTierPensionPaymentReportToolStripMenuItem});
            this.sSNITReturnsToolStripMenuItem.Name = "sSNITReturnsToolStripMenuItem";
            this.sSNITReturnsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.sSNITReturnsToolStripMenuItem.Text = "SSNIT Returns";
            // 
            // sSNITContributionReportToolStripMenuItem
            // 
            this.sSNITContributionReportToolStripMenuItem.Name = "sSNITContributionReportToolStripMenuItem";
            this.sSNITContributionReportToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.sSNITContributionReportToolStripMenuItem.Text = "SSNIT/PROVIDENT Contribution";
            this.sSNITContributionReportToolStripMenuItem.Click += new System.EventHandler(this.sSNITReturnsToolStripMenuItem1_Click);
            // 
            // secondTierPensionPaymentReportToolStripMenuItem
            // 
            this.secondTierPensionPaymentReportToolStripMenuItem.Name = "secondTierPensionPaymentReportToolStripMenuItem";
            this.secondTierPensionPaymentReportToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.secondTierPensionPaymentReportToolStripMenuItem.Text = "2ND Tier Pension Payment";
            this.secondTierPensionPaymentReportToolStripMenuItem.Click += new System.EventHandler(this.nDTierPensionPaymentToolStripMenuItem_Click);
            // 
            // firstTierPensionPaymentReportToolStripMenuItem
            // 
            this.firstTierPensionPaymentReportToolStripMenuItem.Name = "firstTierPensionPaymentReportToolStripMenuItem";
            this.firstTierPensionPaymentReportToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.firstTierPensionPaymentReportToolStripMenuItem.Text = "SSNIT Voucher";
            this.firstTierPensionPaymentReportToolStripMenuItem.Click += new System.EventHandler(this.sSNITVoucherToolStripMenuItem_Click);
            // 
            // incomeTaxReturnsReportToolStripMenuItem
            // 
            this.incomeTaxReturnsReportToolStripMenuItem.Name = "incomeTaxReturnsReportToolStripMenuItem";
            this.incomeTaxReturnsReportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.incomeTaxReturnsReportToolStripMenuItem.Text = "Income Tax Returns";
            this.incomeTaxReturnsReportToolStripMenuItem.Click += new System.EventHandler(this.incomeTaxReturnsToolStripMenuItem_Click);
            // 
            // payRollAndPaySlipReportToolStripMenuItem
            // 
            this.payRollAndPaySlipReportToolStripMenuItem.Name = "payRollAndPaySlipReportToolStripMenuItem";
            this.payRollAndPaySlipReportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.payRollAndPaySlipReportToolStripMenuItem.Text = "Pay Roll And Pay Slip";
            this.payRollAndPaySlipReportToolStripMenuItem.Click += new System.EventHandler(this.payRollAndPaySlipToolStripMenuItem_Click);
            // 
            // medicalClaimsMonthlyReportToolStripMenuItem
            // 
            this.medicalClaimsMonthlyReportToolStripMenuItem.Name = "medicalClaimsMonthlyReportToolStripMenuItem";
            this.medicalClaimsMonthlyReportToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.medicalClaimsMonthlyReportToolStripMenuItem.Text = "Medical Claims";
            this.medicalClaimsMonthlyReportToolStripMenuItem.Click += new System.EventHandler(this.medicalClaimsToolStripMenuItem1_Click);
            // 
            // otherDeductionsToolStripMenuItem
            // 
            this.otherDeductionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryDeductionReportToolStripMenuItem,
            this.detailDeductionsReportToolStripMenuItem,
            this.susuMonthlyContributionToolStripMenuItem,
            this.withholdingMonthlyContrbutionsToolStripMenuItem});
            this.otherDeductionsToolStripMenuItem.Name = "otherDeductionsToolStripMenuItem";
            this.otherDeductionsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.otherDeductionsToolStripMenuItem.Text = "Deductions";
            // 
            // summaryDeductionReportToolStripMenuItem
            // 
            this.summaryDeductionReportToolStripMenuItem.Name = "summaryDeductionReportToolStripMenuItem";
            this.summaryDeductionReportToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.summaryDeductionReportToolStripMenuItem.Text = "Deductions Report";
            this.summaryDeductionReportToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem1_Click);
            // 
            // detailDeductionsReportToolStripMenuItem
            // 
            this.detailDeductionsReportToolStripMenuItem.Name = "detailDeductionsReportToolStripMenuItem";
            this.detailDeductionsReportToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.detailDeductionsReportToolStripMenuItem.Text = "Other Deductions Report";
            this.detailDeductionsReportToolStripMenuItem.Click += new System.EventHandler(this.detailDeductionsReportToolStripMenuItem_Click);
            // 
            // susuMonthlyContributionToolStripMenuItem
            // 
            this.susuMonthlyContributionToolStripMenuItem.Name = "susuMonthlyContributionToolStripMenuItem";
            this.susuMonthlyContributionToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.susuMonthlyContributionToolStripMenuItem.Text = "Susu Monthly Contributions";
            this.susuMonthlyContributionToolStripMenuItem.Click += new System.EventHandler(this.susuMonthlyContributionToolStripMenuItem_Click);
            // 
            // withholdingMonthlyContrbutionsToolStripMenuItem
            // 
            this.withholdingMonthlyContrbutionsToolStripMenuItem.Name = "withholdingMonthlyContrbutionsToolStripMenuItem";
            this.withholdingMonthlyContrbutionsToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.withholdingMonthlyContrbutionsToolStripMenuItem.Text = "Withholding Monthly Contrbutions";
            this.withholdingMonthlyContrbutionsToolStripMenuItem.Click += new System.EventHandler(this.withholdingMonthlyContrbutionsToolStripMenuItem_Click);
            // 
            // bankAdviceSlipToolStripMenuItem
            // 
            this.bankAdviceSlipToolStripMenuItem.Name = "bankAdviceSlipToolStripMenuItem";
            this.bankAdviceSlipToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.bankAdviceSlipToolStripMenuItem.Text = "Bank Advice Slip";
            this.bankAdviceSlipToolStripMenuItem.Click += new System.EventHandler(this.bankAdviceSlipToolStripMenuItem_Click);
            // 
            // otherAllowanceToolStripMenuItem
            // 
            this.otherAllowanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryAllowanceReportToolStripMenuItem,
            this.detailAllowanceReportToolStripMenuItem});
            this.otherAllowanceToolStripMenuItem.Name = "otherAllowanceToolStripMenuItem";
            this.otherAllowanceToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.otherAllowanceToolStripMenuItem.Text = "Allowance";
            // 
            // summaryAllowanceReportToolStripMenuItem
            // 
            this.summaryAllowanceReportToolStripMenuItem.Name = "summaryAllowanceReportToolStripMenuItem";
            this.summaryAllowanceReportToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.summaryAllowanceReportToolStripMenuItem.Text = "Allowances Report";
            this.summaryAllowanceReportToolStripMenuItem.Click += new System.EventHandler(this.summaryAllowanceReportToolStripMenuItem_Click);
            // 
            // detailAllowanceReportToolStripMenuItem
            // 
            this.detailAllowanceReportToolStripMenuItem.Name = "detailAllowanceReportToolStripMenuItem";
            this.detailAllowanceReportToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.detailAllowanceReportToolStripMenuItem.Text = "Other Allowances Report";
            this.detailAllowanceReportToolStripMenuItem.Click += new System.EventHandler(this.detailAllowanceReportToolStripMenuItem_Click);
            // 
            // mnuOverTimeToolStripMenuItem
            // 
            this.mnuOverTimeToolStripMenuItem.Name = "mnuOverTimeToolStripMenuItem";
            this.mnuOverTimeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.mnuOverTimeToolStripMenuItem.Text = "Overtime";
            this.mnuOverTimeToolStripMenuItem.Click += new System.EventHandler(this.mnuOverTimeToolStripMenuItem_Click);
            // 
            // taxReliefToolStripMenuItem1
            // 
            this.taxReliefToolStripMenuItem1.Name = "taxReliefToolStripMenuItem1";
            this.taxReliefToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.taxReliefToolStripMenuItem1.Text = "Tax Relief";
            this.taxReliefToolStripMenuItem1.Click += new System.EventHandler(this.taxReliefToolStripMenuItem1_Click);
            // 
            // staffManagementReportsToolStripMenuItem
            // 
            this.staffManagementReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailedProfileToolStripMenuItem,
            this.staffListReportToolStripMenuItem,
            this.pensioneersReportToolStripMenuItem,
            this.mnuExcuseDutyReport,
            this.lengthOfServiceReportToolStripMenuItem,
            this.staffSummaryToolStripMenuItem1,
            this.staffListByAppointmentReportToolStrilMenuItem,
            this.staffListByAgeReportToolStripMenuItem,
            this.staffListByGenderReportToolStripMenuItem,
            this.staffListRetiringReportToolStripMenuItem,
            this.staffListByBankReportToolStripMenuItem,
            this.staffListByJobReportToolStripMenuItem,
            this.staffListByZoneReportToolStripMenuItem,
            this.staffListByGradeReportToolStripMenuItem,
            this.staffDurationOnGradeToolStripMenuItem,
            this.staffDurationInBranchToolStripMenuItem,
            this.staffListByQualificationTypeReportToolStripMenuItem,
            this.joinersReportToolStripMenuItem,
            this.birthdayReportsToolStripMenuItem,
            this.medicalReportsToolStripMenuItem,
            this.dependentsListToolStripMenuItem,
            this.vehicleReportMenuItem});
            this.staffManagementReportsToolStripMenuItem.Name = "staffManagementReportsToolStripMenuItem";
            this.staffManagementReportsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.staffManagementReportsToolStripMenuItem.Text = "Staff Management Reports";
            // 
            // detailedProfileToolStripMenuItem
            // 
            this.detailedProfileToolStripMenuItem.Name = "detailedProfileToolStripMenuItem";
            this.detailedProfileToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.detailedProfileToolStripMenuItem.Text = "Detailed Staff Profile";
            this.detailedProfileToolStripMenuItem.Click += new System.EventHandler(this.detailedProfileToolStripMenuItem_Click);
            // 
            // staffListReportToolStripMenuItem
            // 
            this.staffListReportToolStripMenuItem.Name = "staffListReportToolStripMenuItem";
            this.staffListReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListReportToolStripMenuItem.Text = "Staff List";
            this.staffListReportToolStripMenuItem.Click += new System.EventHandler(this.profileToolStripMenuItem_Click);
            // 
            // pensioneersReportToolStripMenuItem
            // 
            this.pensioneersReportToolStripMenuItem.Name = "pensioneersReportToolStripMenuItem";
            this.pensioneersReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.pensioneersReportToolStripMenuItem.Text = "Pensioneers";
            this.pensioneersReportToolStripMenuItem.Click += new System.EventHandler(this.pensioneersToolStripMenuItem_Click);
            // 
            // mnuExcuseDutyReport
            // 
            this.mnuExcuseDutyReport.Name = "mnuExcuseDutyReport";
            this.mnuExcuseDutyReport.Size = new System.Drawing.Size(247, 22);
            this.mnuExcuseDutyReport.Text = "Excuse Duty Report";
            this.mnuExcuseDutyReport.Click += new System.EventHandler(this.mnuExcuseDutyReport_Click);
            // 
            // lengthOfServiceReportToolStripMenuItem
            // 
            this.lengthOfServiceReportToolStripMenuItem.Name = "lengthOfServiceReportToolStripMenuItem";
            this.lengthOfServiceReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.lengthOfServiceReportToolStripMenuItem.Text = "Length Of Service";
            this.lengthOfServiceReportToolStripMenuItem.Click += new System.EventHandler(this.lengthOfServiceToolStripMenuItem1_Click);
            // 
            // staffSummaryToolStripMenuItem1
            // 
            this.staffSummaryToolStripMenuItem1.Name = "staffSummaryToolStripMenuItem1";
            this.staffSummaryToolStripMenuItem1.Size = new System.Drawing.Size(247, 22);
            this.staffSummaryToolStripMenuItem1.Text = "Chart Reports";
            this.staffSummaryToolStripMenuItem1.Click += new System.EventHandler(this.summaryToolStripMenuItem1_Click_1);
            // 
            // staffListByAppointmentReportToolStrilMenuItem
            // 
            this.staffListByAppointmentReportToolStrilMenuItem.Name = "staffListByAppointmentReportToolStrilMenuItem";
            this.staffListByAppointmentReportToolStrilMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByAppointmentReportToolStrilMenuItem.Text = "Staff List By Appointment Type";
            this.staffListByAppointmentReportToolStrilMenuItem.Click += new System.EventHandler(this.staffListByAppointmentReportToolStrilMenuItem_Click);
            // 
            // staffListByAgeReportToolStripMenuItem
            // 
            this.staffListByAgeReportToolStripMenuItem.Name = "staffListByAgeReportToolStripMenuItem";
            this.staffListByAgeReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByAgeReportToolStripMenuItem.Text = "Staff List By Age";
            this.staffListByAgeReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByAgeToolStripMenuItem_Click);
            // 
            // staffListByGenderReportToolStripMenuItem
            // 
            this.staffListByGenderReportToolStripMenuItem.Name = "staffListByGenderReportToolStripMenuItem";
            this.staffListByGenderReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByGenderReportToolStripMenuItem.Text = "Staff List By Gender";
            this.staffListByGenderReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByGenderToolStripMenuItem_Click);
            // 
            // staffListRetiringReportToolStripMenuItem
            // 
            this.staffListRetiringReportToolStripMenuItem.Name = "staffListRetiringReportToolStripMenuItem";
            this.staffListRetiringReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListRetiringReportToolStripMenuItem.Text = "Staff List Retiring";
            this.staffListRetiringReportToolStripMenuItem.Click += new System.EventHandler(this.staffListRetiringToolStripMenuItem_Click);
            // 
            // staffListByBankReportToolStripMenuItem
            // 
            this.staffListByBankReportToolStripMenuItem.Name = "staffListByBankReportToolStripMenuItem";
            this.staffListByBankReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByBankReportToolStripMenuItem.Text = "Staff List By Bank";
            this.staffListByBankReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByBankToolStripMenuItem_Click);
            // 
            // staffListByJobReportToolStripMenuItem
            // 
            this.staffListByJobReportToolStripMenuItem.Name = "staffListByJobReportToolStripMenuItem";
            this.staffListByJobReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByJobReportToolStripMenuItem.Text = "Staff List By Job";
            this.staffListByJobReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByJobToolStripMenuItem_Click);
            // 
            // staffListByZoneReportToolStripMenuItem
            // 
            this.staffListByZoneReportToolStripMenuItem.Name = "staffListByZoneReportToolStripMenuItem";
            this.staffListByZoneReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByZoneReportToolStripMenuItem.Text = "Staff List By Zone";
            this.staffListByZoneReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByZoneToolStripMenuItem_Click);
            // 
            // staffListByGradeReportToolStripMenuItem
            // 
            this.staffListByGradeReportToolStripMenuItem.Name = "staffListByGradeReportToolStripMenuItem";
            this.staffListByGradeReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByGradeReportToolStripMenuItem.Text = "Staff List By Grade";
            this.staffListByGradeReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByGradeToolStripMenuItem_Click);
            // 
            // staffDurationOnGradeToolStripMenuItem
            // 
            this.staffDurationOnGradeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffDurationOnGradeReportToolStripMenuItem,
            this.staffDueForPromotionReportToolStripMenuItem});
            this.staffDurationOnGradeToolStripMenuItem.Name = "staffDurationOnGradeToolStripMenuItem";
            this.staffDurationOnGradeToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffDurationOnGradeToolStripMenuItem.Text = "Staff Duration On Grade";
            // 
            // staffDurationOnGradeReportToolStripMenuItem
            // 
            this.staffDurationOnGradeReportToolStripMenuItem.Name = "staffDurationOnGradeReportToolStripMenuItem";
            this.staffDurationOnGradeReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.staffDurationOnGradeReportToolStripMenuItem.Text = "Staff Duration On A Grade";
            this.staffDurationOnGradeReportToolStripMenuItem.Click += new System.EventHandler(this.staffDurationOnAGradeToolStripMenuItem_Click);
            // 
            // staffDueForPromotionReportToolStripMenuItem
            // 
            this.staffDueForPromotionReportToolStripMenuItem.Name = "staffDueForPromotionReportToolStripMenuItem";
            this.staffDueForPromotionReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.staffDueForPromotionReportToolStripMenuItem.Text = "Staff Due For Promotion";
            this.staffDueForPromotionReportToolStripMenuItem.Click += new System.EventHandler(this.staffDueForPromotionToolStripMenuItem_Click);
            // 
            // staffDurationInBranchToolStripMenuItem
            // 
            this.staffDurationInBranchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffDueForTransferReportToolStripMenuItem,
            this.staffDurationAtAZoneReportToolStripMenuItem});
            this.staffDurationInBranchToolStripMenuItem.Name = "staffDurationInBranchToolStripMenuItem";
            this.staffDurationInBranchToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffDurationInBranchToolStripMenuItem.Text = "Staff Duration in a Branch";
            // 
            // staffDueForTransferReportToolStripMenuItem
            // 
            this.staffDueForTransferReportToolStripMenuItem.Name = "staffDueForTransferReportToolStripMenuItem";
            this.staffDueForTransferReportToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.staffDueForTransferReportToolStripMenuItem.Text = "Staff Due For Transfer";
            // 
            // staffDurationAtAZoneReportToolStripMenuItem
            // 
            this.staffDurationAtAZoneReportToolStripMenuItem.Name = "staffDurationAtAZoneReportToolStripMenuItem";
            this.staffDurationAtAZoneReportToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.staffDurationAtAZoneReportToolStripMenuItem.Text = "Staff Duration At A Zone";
            this.staffDurationAtAZoneReportToolStripMenuItem.Click += new System.EventHandler(this.staffDurationAtAZoneToolStripMenuItem_Click);
            // 
            // staffListByQualificationTypeReportToolStripMenuItem
            // 
            this.staffListByQualificationTypeReportToolStripMenuItem.Name = "staffListByQualificationTypeReportToolStripMenuItem";
            this.staffListByQualificationTypeReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.staffListByQualificationTypeReportToolStripMenuItem.Text = "Staff List By Qualification Type";
            this.staffListByQualificationTypeReportToolStripMenuItem.Click += new System.EventHandler(this.staffListByQualificationTypeReportToolStripMenuItem_Click);
            // 
            // joinersReportToolStripMenuItem
            // 
            this.joinersReportToolStripMenuItem.Name = "joinersReportToolStripMenuItem";
            this.joinersReportToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.joinersReportToolStripMenuItem.Text = "Joiners Report";
            this.joinersReportToolStripMenuItem.Click += new System.EventHandler(this.joinersReportToolStripMenuItem_Click);
            // 
            // birthdayReportsToolStripMenuItem
            // 
            this.birthdayReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.birthdayLettersToolStripMenuItem,
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem});
            this.birthdayReportsToolStripMenuItem.Name = "birthdayReportsToolStripMenuItem";
            this.birthdayReportsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.birthdayReportsToolStripMenuItem.Text = "Birthday Reports";
            // 
            // birthdayLettersToolStripMenuItem
            // 
            this.birthdayLettersToolStripMenuItem.Name = "birthdayLettersToolStripMenuItem";
            this.birthdayLettersToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.birthdayLettersToolStripMenuItem.Text = "Birthday Letters";
            this.birthdayLettersToolStripMenuItem.Click += new System.EventHandler(this.lettersToolStripMenuItem_Click);
            // 
            // listOfStaffCelebratingBirthdayReportToolStripMenuItem
            // 
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem.Name = "listOfStaffCelebratingBirthdayReportToolStripMenuItem";
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem.Size = new System.Drawing.Size(257, 22);
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem.Text = "List Of Staff Celebrating Birthdays";
            this.listOfStaffCelebratingBirthdayReportToolStripMenuItem.Click += new System.EventHandler(this.listOfStaffCelebratingBirthdToolStripMenuItem_Click);
            // 
            // medicalReportsToolStripMenuItem
            // 
            this.medicalReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sickLeaveListToolStripMenuItem,
            this.hospitalBillsToolStripMenuItem,
            this.hospitalAttendanceToolStripMenuItem,
            this.spectaclesIssuedToolStripMenuItem,
            this.lensIssuedToolStripMenuItem,
            this.listStaffDueForSpectaclesToolStripMenuItem,
            this.listStaffDueForLensesToolStripMenuItem});
            this.medicalReportsToolStripMenuItem.Name = "medicalReportsToolStripMenuItem";
            this.medicalReportsToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.medicalReportsToolStripMenuItem.Text = "Medical Reports";
            // 
            // sickLeaveListToolStripMenuItem
            // 
            this.sickLeaveListToolStripMenuItem.Name = "sickLeaveListToolStripMenuItem";
            this.sickLeaveListToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.sickLeaveListToolStripMenuItem.Text = "Sick Leave List";
            // 
            // hospitalBillsToolStripMenuItem
            // 
            this.hospitalBillsToolStripMenuItem.Name = "hospitalBillsToolStripMenuItem";
            this.hospitalBillsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.hospitalBillsToolStripMenuItem.Text = "Hospital Bills";
            // 
            // hospitalAttendanceToolStripMenuItem
            // 
            this.hospitalAttendanceToolStripMenuItem.Name = "hospitalAttendanceToolStripMenuItem";
            this.hospitalAttendanceToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.hospitalAttendanceToolStripMenuItem.Text = "Hospital Attendance";
            // 
            // spectaclesIssuedToolStripMenuItem
            // 
            this.spectaclesIssuedToolStripMenuItem.Name = "spectaclesIssuedToolStripMenuItem";
            this.spectaclesIssuedToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.spectaclesIssuedToolStripMenuItem.Text = "Spectacles Issued";
            // 
            // lensIssuedToolStripMenuItem
            // 
            this.lensIssuedToolStripMenuItem.Name = "lensIssuedToolStripMenuItem";
            this.lensIssuedToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.lensIssuedToolStripMenuItem.Text = "Lens Issued";
            // 
            // listStaffDueForSpectaclesToolStripMenuItem
            // 
            this.listStaffDueForSpectaclesToolStripMenuItem.Name = "listStaffDueForSpectaclesToolStripMenuItem";
            this.listStaffDueForSpectaclesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.listStaffDueForSpectaclesToolStripMenuItem.Text = "List Staff Due For Spectacles";
            // 
            // listStaffDueForLensesToolStripMenuItem
            // 
            this.listStaffDueForLensesToolStripMenuItem.Name = "listStaffDueForLensesToolStripMenuItem";
            this.listStaffDueForLensesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.listStaffDueForLensesToolStripMenuItem.Text = "List Staff Due For Lenses";
            // 
            // dependentsListToolStripMenuItem
            // 
            this.dependentsListToolStripMenuItem.Name = "dependentsListToolStripMenuItem";
            this.dependentsListToolStripMenuItem.Size = new System.Drawing.Size(247, 22);
            this.dependentsListToolStripMenuItem.Text = "Dependents List";
            this.dependentsListToolStripMenuItem.Click += new System.EventHandler(this.dependentsListToolStripMenuItem_Click);
            // 
            // vehicleReportMenuItem
            // 
            this.vehicleReportMenuItem.Name = "vehicleReportMenuItem";
            this.vehicleReportMenuItem.Size = new System.Drawing.Size(247, 22);
            this.vehicleReportMenuItem.Text = "Vehicle Report";
            this.vehicleReportMenuItem.Click += new System.EventHandler(this.vehicleReportMenuItem_Click);
            // 
            // transactionalReportsToolStripMenuItem
            // 
            this.transactionalReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attendanceReportToolStripMenuItem,
            this.dutyRoasterReportToolStripMenuItem,
            this.leaveReportsToolStripMenuItem,
            this.mnuExcuseDutyRequests,
            this.trainingReportsToolStripMenuItem,
            this.establishmentReportToolStripMenuItem,
            this.statisticsReportsToolStripMenuItem,
            this.wastageReportsToolStripMenuItem,
            this.changeJobTitleToolStripMenuItem,
            this.auditReportsToolStripMenuItem,
            this.separationReportToolStripMenuItem,
            this.medicalClaimsReportToolStripMenuItem,
            this.transferReportToolStripMenuItem,
            this.internshipReportToolStripMenuItem,
            this.promotionReportToolStripMenuItem,
            this.interviewReportToolStripMenuItem,
            this.applicantReportToolStripMenuItem,
            this.sanctionReportToolStripMenuItem,
            this.mnuAppraisalReports,
            this.locumReportToolStripMenuItem});
            this.transactionalReportsToolStripMenuItem.Name = "transactionalReportsToolStripMenuItem";
            this.transactionalReportsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.transactionalReportsToolStripMenuItem.Text = "Transactional Reports";
            // 
            // attendanceReportToolStripMenuItem
            // 
            this.attendanceReportToolStripMenuItem.Name = "attendanceReportToolStripMenuItem";
            this.attendanceReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.attendanceReportToolStripMenuItem.Text = "Attendance Report";
            this.attendanceReportToolStripMenuItem.Click += new System.EventHandler(this.attendanceToolStripMenuItem1_Click);
            // 
            // dutyRoasterReportToolStripMenuItem
            // 
            this.dutyRoasterReportToolStripMenuItem.Name = "dutyRoasterReportToolStripMenuItem";
            this.dutyRoasterReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.dutyRoasterReportToolStripMenuItem.Text = "Duty Roaster Report";
            this.dutyRoasterReportToolStripMenuItem.Visible = false;
            this.dutyRoasterReportToolStripMenuItem.Click += new System.EventHandler(this.dutyRoasterToolStripMenuItem1_Click);
            // 
            // leaveReportsToolStripMenuItem
            // 
            this.leaveReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaveReportToolStripMenuItem,
            this.leaveRoasterToolStripMenuItem,
            this.staffLeaveBalancesToolStripMenuItem,
            this.leaveResumptionReportToolStripMenuItem,
            this.reprintOfLeaveLetterReportToolStripMenuItem,
            this.leaveEncashmentReportToolStripMenuItem,
            this.studyLeaveReportToolStripMenuItem});
            this.leaveReportsToolStripMenuItem.Name = "leaveReportsToolStripMenuItem";
            this.leaveReportsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.leaveReportsToolStripMenuItem.Text = "Leave Reports";
            // 
            // leaveReportToolStripMenuItem
            // 
            this.leaveReportToolStripMenuItem.Name = "leaveReportToolStripMenuItem";
            this.leaveReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.leaveReportToolStripMenuItem.Text = "Leave Report";
            this.leaveReportToolStripMenuItem.Click += new System.EventHandler(this.leaveReportToolStripMenuItem_Click);
            // 
            // leaveRoasterToolStripMenuItem
            // 
            this.leaveRoasterToolStripMenuItem.Name = "leaveRoasterToolStripMenuItem";
            this.leaveRoasterToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.leaveRoasterToolStripMenuItem.Text = "Leave Roaster";
            this.leaveRoasterToolStripMenuItem.Click += new System.EventHandler(this.leaveRoasterToolStripMenuItem_Click);
            // 
            // staffLeaveBalancesToolStripMenuItem
            // 
            this.staffLeaveBalancesToolStripMenuItem.Name = "staffLeaveBalancesToolStripMenuItem";
            this.staffLeaveBalancesToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.staffLeaveBalancesToolStripMenuItem.Text = "Staff Leave Balances";
            this.staffLeaveBalancesToolStripMenuItem.Click += new System.EventHandler(this.staffLeaveBalancesToolStripMenuItem_Click);
            // 
            // leaveResumptionReportToolStripMenuItem
            // 
            this.leaveResumptionReportToolStripMenuItem.Name = "leaveResumptionReportToolStripMenuItem";
            this.leaveResumptionReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.leaveResumptionReportToolStripMenuItem.Text = "Leave Resumption List";
            this.leaveResumptionReportToolStripMenuItem.Click += new System.EventHandler(this.leaveRToolStripMenuItem_Click);
            // 
            // reprintOfLeaveLetterReportToolStripMenuItem
            // 
            this.reprintOfLeaveLetterReportToolStripMenuItem.Name = "reprintOfLeaveLetterReportToolStripMenuItem";
            this.reprintOfLeaveLetterReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.reprintOfLeaveLetterReportToolStripMenuItem.Text = "Reprint Of Leave Letters";
            this.reprintOfLeaveLetterReportToolStripMenuItem.Click += new System.EventHandler(this.reprintOfLeaveLettersToolStripMenuItem_Click);
            // 
            // leaveEncashmentReportToolStripMenuItem
            // 
            this.leaveEncashmentReportToolStripMenuItem.Name = "leaveEncashmentReportToolStripMenuItem";
            this.leaveEncashmentReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.leaveEncashmentReportToolStripMenuItem.Text = "Leave Encashment Report";
            this.leaveEncashmentReportToolStripMenuItem.Click += new System.EventHandler(this.leaveEncashmentReportToolStripMenuItem_Click);
            // 
            // studyLeaveReportToolStripMenuItem
            // 
            this.studyLeaveReportToolStripMenuItem.Name = "studyLeaveReportToolStripMenuItem";
            this.studyLeaveReportToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.studyLeaveReportToolStripMenuItem.Text = "Study Leave Report";
            this.studyLeaveReportToolStripMenuItem.Click += new System.EventHandler(this.studyLeaveReportToolStripMenuItem_Click);
            // 
            // mnuExcuseDutyRequests
            // 
            this.mnuExcuseDutyRequests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcuseDutyReportForm});
            this.mnuExcuseDutyRequests.Name = "mnuExcuseDutyRequests";
            this.mnuExcuseDutyRequests.Size = new System.Drawing.Size(225, 22);
            this.mnuExcuseDutyRequests.Text = "Excuse Duty Reports";
            // 
            // mnuExcuseDutyReportForm
            // 
            this.mnuExcuseDutyReportForm.Name = "mnuExcuseDutyReportForm";
            this.mnuExcuseDutyReportForm.Size = new System.Drawing.Size(183, 22);
            this.mnuExcuseDutyReportForm.Text = "Excuse Duty Report";
            this.mnuExcuseDutyReportForm.Click += new System.EventHandler(this.mnuExcuseDutyReportForm_Click);
            // 
            // trainingReportsToolStripMenuItem
            // 
            this.trainingReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainingReportToolStripMenuItem1,
            this.trainingReportToolStripMenuItem,
            this.courseAttendanceReportToolStripMenuItem,
            this.mnuExternalTrainingReport,
            this.mnuTrainingBondsReport,
            this.trainingEvaluationReportToolStripMenuItem});
            this.trainingReportsToolStripMenuItem.Name = "trainingReportsToolStripMenuItem";
            this.trainingReportsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.trainingReportsToolStripMenuItem.Text = "Training Reports";
            this.trainingReportsToolStripMenuItem.Click += new System.EventHandler(this.trainingReportsToolStripMenuItem_Click);
            // 
            // trainingReportToolStripMenuItem1
            // 
            this.trainingReportToolStripMenuItem1.Name = "trainingReportToolStripMenuItem1";
            this.trainingReportToolStripMenuItem1.Size = new System.Drawing.Size(217, 22);
            this.trainingReportToolStripMenuItem1.Text = "Training Report";
            this.trainingReportToolStripMenuItem1.Click += new System.EventHandler(this.trainingReportToolStripMenuItem1_Click);
            // 
            // trainingReportToolStripMenuItem
            // 
            this.trainingReportToolStripMenuItem.Name = "trainingReportToolStripMenuItem";
            this.trainingReportToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.trainingReportToolStripMenuItem.Text = "Training Needs";
            this.trainingReportToolStripMenuItem.Click += new System.EventHandler(this.trainingReportToolStripMenuItem_Click);
            // 
            // courseAttendanceReportToolStripMenuItem
            // 
            this.courseAttendanceReportToolStripMenuItem.Name = "courseAttendanceReportToolStripMenuItem";
            this.courseAttendanceReportToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.courseAttendanceReportToolStripMenuItem.Text = "Course Attendance";
            // 
            // mnuExternalTrainingReport
            // 
            this.mnuExternalTrainingReport.Name = "mnuExternalTrainingReport";
            this.mnuExternalTrainingReport.Size = new System.Drawing.Size(217, 22);
            this.mnuExternalTrainingReport.Text = "External Training Report";
            this.mnuExternalTrainingReport.Click += new System.EventHandler(this.mnuExternalTrainingReport_Click);
            // 
            // mnuTrainingBondsReport
            // 
            this.mnuTrainingBondsReport.Name = "mnuTrainingBondsReport";
            this.mnuTrainingBondsReport.Size = new System.Drawing.Size(217, 22);
            this.mnuTrainingBondsReport.Text = "Training Bonds Report";
            this.mnuTrainingBondsReport.Click += new System.EventHandler(this.mnuTrainingBondsReport_Click);
            // 
            // trainingEvaluationReportToolStripMenuItem
            // 
            this.trainingEvaluationReportToolStripMenuItem.Name = "trainingEvaluationReportToolStripMenuItem";
            this.trainingEvaluationReportToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.trainingEvaluationReportToolStripMenuItem.Text = "Training Evaluation Report";
            this.trainingEvaluationReportToolStripMenuItem.Click += new System.EventHandler(this.trainingEvaluationReportToolStripMenuItem_Click);
            // 
            // establishmentReportToolStripMenuItem
            // 
            this.establishmentReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.establishmentListSummaryToolStripMenuItem,
            this.establishmentListToolStripMenuItem});
            this.establishmentReportToolStripMenuItem.Name = "establishmentReportToolStripMenuItem";
            this.establishmentReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.establishmentReportToolStripMenuItem.Text = "Establishment Reports";
            this.establishmentReportToolStripMenuItem.Visible = false;
            // 
            // establishmentListSummaryToolStripMenuItem
            // 
            this.establishmentListSummaryToolStripMenuItem.Name = "establishmentListSummaryToolStripMenuItem";
            this.establishmentListSummaryToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.establishmentListSummaryToolStripMenuItem.Text = "Summary Establishment List";
            // 
            // establishmentListToolStripMenuItem
            // 
            this.establishmentListToolStripMenuItem.Name = "establishmentListToolStripMenuItem";
            this.establishmentListToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.establishmentListToolStripMenuItem.Text = "Detail Establishment List ";
            // 
            // statisticsReportsToolStripMenuItem
            // 
            this.statisticsReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lengthOfServiceToolStripMenuItem,
            this.ageDistributionToolStripMenuItem,
            this.genderDistributionToolStripMenuItem,
            this.joinersStatsToolStripMenuItem,
            this.wastageReportToolStripMenuItem});
            this.statisticsReportsToolStripMenuItem.Name = "statisticsReportsToolStripMenuItem";
            this.statisticsReportsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.statisticsReportsToolStripMenuItem.Text = "Statistics Reports";
            // 
            // lengthOfServiceToolStripMenuItem
            // 
            this.lengthOfServiceToolStripMenuItem.Name = "lengthOfServiceToolStripMenuItem";
            this.lengthOfServiceToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.lengthOfServiceToolStripMenuItem.Text = "Length Of Service";
            this.lengthOfServiceToolStripMenuItem.Click += new System.EventHandler(this.lengthOfServiceToolStripMenuItem_Click);
            // 
            // ageDistributionToolStripMenuItem
            // 
            this.ageDistributionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.distributionByAgeToolStripMenuItem,
            this.distributionByCategoryToolStripMenuItem,
            this.distributionByGradeToolStripMenuItem});
            this.ageDistributionToolStripMenuItem.Name = "ageDistributionToolStripMenuItem";
            this.ageDistributionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.ageDistributionToolStripMenuItem.Text = "Age Distribution";
            // 
            // distributionByAgeToolStripMenuItem
            // 
            this.distributionByAgeToolStripMenuItem.Name = "distributionByAgeToolStripMenuItem";
            this.distributionByAgeToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributionByAgeToolStripMenuItem.Text = "Distribution By Age";
            this.distributionByAgeToolStripMenuItem.Click += new System.EventHandler(this.distributionByAgeToolStripMenuItem_Click);
            // 
            // distributionByCategoryToolStripMenuItem
            // 
            this.distributionByCategoryToolStripMenuItem.Name = "distributionByCategoryToolStripMenuItem";
            this.distributionByCategoryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributionByCategoryToolStripMenuItem.Text = "Distribution By Category";
            this.distributionByCategoryToolStripMenuItem.Click += new System.EventHandler(this.distributionByCategoryToolStripMenuItem_Click);
            // 
            // distributionByGradeToolStripMenuItem
            // 
            this.distributionByGradeToolStripMenuItem.Name = "distributionByGradeToolStripMenuItem";
            this.distributionByGradeToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributionByGradeToolStripMenuItem.Text = "Distribution By Grade";
            this.distributionByGradeToolStripMenuItem.Click += new System.EventHandler(this.distributionByGradeToolStripMenuItem_Click);
            // 
            // genderDistributionToolStripMenuItem
            // 
            this.genderDistributionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.summaryToolStripMenuItem,
            this.distributionByZoneToolStripMenuItem,
            this.distributionByToolStripMenuItem});
            this.genderDistributionToolStripMenuItem.Name = "genderDistributionToolStripMenuItem";
            this.genderDistributionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.genderDistributionToolStripMenuItem.Text = "Gender Distribution";
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.summaryToolStripMenuItem.Text = "Summary Distribution";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // distributionByZoneToolStripMenuItem
            // 
            this.distributionByZoneToolStripMenuItem.Name = "distributionByZoneToolStripMenuItem";
            this.distributionByZoneToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributionByZoneToolStripMenuItem.Text = "Distribution By Zone";
            this.distributionByZoneToolStripMenuItem.Click += new System.EventHandler(this.distributionByZoneToolStripMenuItem_Click);
            // 
            // distributionByToolStripMenuItem
            // 
            this.distributionByToolStripMenuItem.Name = "distributionByToolStripMenuItem";
            this.distributionByToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.distributionByToolStripMenuItem.Text = "Distribution By Category";
            this.distributionByToolStripMenuItem.Click += new System.EventHandler(this.distributionByToolStripMenuItem_Click);
            // 
            // joinersStatsToolStripMenuItem
            // 
            this.joinersStatsToolStripMenuItem.Name = "joinersStatsToolStripMenuItem";
            this.joinersStatsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.joinersStatsToolStripMenuItem.Text = "Joiners Stats";
            this.joinersStatsToolStripMenuItem.Click += new System.EventHandler(this.joinersStatsToolStripMenuItem_Click);
            // 
            // wastageReportToolStripMenuItem
            // 
            this.wastageReportToolStripMenuItem.Name = "wastageReportToolStripMenuItem";
            this.wastageReportToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.wastageReportToolStripMenuItem.Text = "Wastage Report";
            this.wastageReportToolStripMenuItem.Visible = false;
            // 
            // wastageReportsToolStripMenuItem
            // 
            this.wastageReportsToolStripMenuItem.Name = "wastageReportsToolStripMenuItem";
            this.wastageReportsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.wastageReportsToolStripMenuItem.Text = "Wastage Reports";
            this.wastageReportsToolStripMenuItem.Visible = false;
            // 
            // changeJobTitleToolStripMenuItem
            // 
            this.changeJobTitleToolStripMenuItem.Name = "changeJobTitleToolStripMenuItem";
            this.changeJobTitleToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.changeJobTitleToolStripMenuItem.Text = "Staff Details Change Report";
            this.changeJobTitleToolStripMenuItem.Visible = false;
            this.changeJobTitleToolStripMenuItem.Click += new System.EventHandler(this.changeJobTitleToolStripMenuItem_Click);
            // 
            // auditReportsToolStripMenuItem
            // 
            this.auditReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffChangesReportToolStripMenuItem});
            this.auditReportsToolStripMenuItem.Name = "auditReportsToolStripMenuItem";
            this.auditReportsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.auditReportsToolStripMenuItem.Text = "Audit Report";
            this.auditReportsToolStripMenuItem.Visible = false;
            // 
            // staffChangesReportToolStripMenuItem
            // 
            this.staffChangesReportToolStripMenuItem.Name = "staffChangesReportToolStripMenuItem";
            this.staffChangesReportToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.staffChangesReportToolStripMenuItem.Text = "Staff Changes Report";
            this.staffChangesReportToolStripMenuItem.Click += new System.EventHandler(this.staffChangesReportToolStripMenuItem_Click);
            // 
            // separationReportToolStripMenuItem
            // 
            this.separationReportToolStripMenuItem.Name = "separationReportToolStripMenuItem";
            this.separationReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.separationReportToolStripMenuItem.Text = "Separation Report";
            this.separationReportToolStripMenuItem.Click += new System.EventHandler(this.separationReportToolStripMenuItem_Click);
            // 
            // medicalClaimsReportToolStripMenuItem
            // 
            this.medicalClaimsReportToolStripMenuItem.Name = "medicalClaimsReportToolStripMenuItem";
            this.medicalClaimsReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.medicalClaimsReportToolStripMenuItem.Text = "Medical Claims Report";
            this.medicalClaimsReportToolStripMenuItem.Click += new System.EventHandler(this.medicalClaimsReportToolStripMenuItem_Click);
            // 
            // transferReportToolStripMenuItem
            // 
            this.transferReportToolStripMenuItem.Name = "transferReportToolStripMenuItem";
            this.transferReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.transferReportToolStripMenuItem.Text = "Transfer Report";
            this.transferReportToolStripMenuItem.Click += new System.EventHandler(this.transferReportToolStripMenuItem_Click);
            // 
            // internshipReportToolStripMenuItem
            // 
            this.internshipReportToolStripMenuItem.Name = "internshipReportToolStripMenuItem";
            this.internshipReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.internshipReportToolStripMenuItem.Text = "Internship Report";
            this.internshipReportToolStripMenuItem.Click += new System.EventHandler(this.internshipReportToolStripMenuItem_Click);
            // 
            // promotionReportToolStripMenuItem
            // 
            this.promotionReportToolStripMenuItem.Name = "promotionReportToolStripMenuItem";
            this.promotionReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.promotionReportToolStripMenuItem.Text = "Promotion Report";
            this.promotionReportToolStripMenuItem.Click += new System.EventHandler(this.promotionReportToolStripMenuItem_Click);
            // 
            // interviewReportToolStripMenuItem
            // 
            this.interviewReportToolStripMenuItem.Name = "interviewReportToolStripMenuItem";
            this.interviewReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.interviewReportToolStripMenuItem.Text = "Interview Report";
            this.interviewReportToolStripMenuItem.Click += new System.EventHandler(this.interviewReportToolStripMenuItem_Click);
            // 
            // applicantReportToolStripMenuItem
            // 
            this.applicantReportToolStripMenuItem.Name = "applicantReportToolStripMenuItem";
            this.applicantReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.applicantReportToolStripMenuItem.Text = "Applicant Report";
            this.applicantReportToolStripMenuItem.Click += new System.EventHandler(this.applicantReportToolStripMenuItem_Click);
            // 
            // sanctionReportToolStripMenuItem
            // 
            this.sanctionReportToolStripMenuItem.Name = "sanctionReportToolStripMenuItem";
            this.sanctionReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.sanctionReportToolStripMenuItem.Text = "Sanction Report";
            this.sanctionReportToolStripMenuItem.Click += new System.EventHandler(this.sanctionReportToolStripMenuItem_Click);
            // 
            // mnuAppraisalReports
            // 
            this.mnuAppraisalReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAppraisalListReport});
            this.mnuAppraisalReports.Name = "mnuAppraisalReports";
            this.mnuAppraisalReports.Size = new System.Drawing.Size(225, 22);
            this.mnuAppraisalReports.Text = "Appraisal Reports";
            // 
            // mnuAppraisalListReport
            // 
            this.mnuAppraisalListReport.Name = "mnuAppraisalListReport";
            this.mnuAppraisalListReport.Size = new System.Drawing.Size(184, 22);
            this.mnuAppraisalListReport.Text = "Appraisal List Report";
            this.mnuAppraisalListReport.Click += new System.EventHandler(this.mnuAppraisalListReport_Click);
            // 
            // locumReportToolStripMenuItem
            // 
            this.locumReportToolStripMenuItem.Name = "locumReportToolStripMenuItem";
            this.locumReportToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.locumReportToolStripMenuItem.Text = "Locum Report";
            this.locumReportToolStripMenuItem.Click += new System.EventHandler(this.locumReportToolStripMenuItem_Click);
            // 
            // recruitmentReportsToolStripMenuItem
            // 
            this.recruitmentReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicantListReportToolStripMenuItem,
            this.vacancyListReportToolStripMenuItem,
            this.interviewListReportToolStripMenuItem,
            this.listInternsNotOnPayrollToolStripMenuItem,
            this.transferListReportToolStripMenuItem});
            this.recruitmentReportsToolStripMenuItem.Name = "recruitmentReportsToolStripMenuItem";
            this.recruitmentReportsToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.recruitmentReportsToolStripMenuItem.Text = "Recruitment Reports";
            // 
            // applicantListReportToolStripMenuItem
            // 
            this.applicantListReportToolStripMenuItem.Name = "applicantListReportToolStripMenuItem";
            this.applicantListReportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.applicantListReportToolStripMenuItem.Text = "List Applicants";
            this.applicantListReportToolStripMenuItem.Click += new System.EventHandler(this.applicantsToolStripMenuItem1_Click);
            // 
            // vacancyListReportToolStripMenuItem
            // 
            this.vacancyListReportToolStripMenuItem.Name = "vacancyListReportToolStripMenuItem";
            this.vacancyListReportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.vacancyListReportToolStripMenuItem.Text = "List Vacancies";
            this.vacancyListReportToolStripMenuItem.Click += new System.EventHandler(this.vacancyListReportToolStripMenuItem_Click);
            // 
            // interviewListReportToolStripMenuItem
            // 
            this.interviewListReportToolStripMenuItem.Name = "interviewListReportToolStripMenuItem";
            this.interviewListReportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.interviewListReportToolStripMenuItem.Text = "List Interviews";
            this.interviewListReportToolStripMenuItem.Click += new System.EventHandler(this.interviewListReportToolStripMenuItem_Click);
            // 
            // listInternsNotOnPayrollToolStripMenuItem
            // 
            this.listInternsNotOnPayrollToolStripMenuItem.Name = "listInternsNotOnPayrollToolStripMenuItem";
            this.listInternsNotOnPayrollToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.listInternsNotOnPayrollToolStripMenuItem.Text = "List Interns";
            this.listInternsNotOnPayrollToolStripMenuItem.Click += new System.EventHandler(this.listInternsNotOnPayrollToolStripMenuItem_Click);
            // 
            // transferListReportToolStripMenuItem
            // 
            this.transferListReportToolStripMenuItem.Name = "transferListReportToolStripMenuItem";
            this.transferListReportToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.transferListReportToolStripMenuItem.Text = "List Transfers";
            this.transferListReportToolStripMenuItem.Click += new System.EventHandler(this.transferListReportToolStripMenuItem_Click);
            // 
            // timeAndAttendanceToolStripMenuItem
            // 
            this.timeAndAttendanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkInOutToolStripMenuItem,
            this.dutyRoasterToolStripMenuItem,
            this.downloadUserInfoToolStripMenuItem,
            this.downloadAttendanceLogsToolStripMenuItem,
            this.enrollUserToolStripMenuItem,
            this.manualCheckOutToolStripMenuItem,
            this.timeCardManagementToolStripMenuItem});
            this.timeAndAttendanceToolStripMenuItem.Name = "timeAndAttendanceToolStripMenuItem";
            this.timeAndAttendanceToolStripMenuItem.Size = new System.Drawing.Size(141, 20);
            this.timeAndAttendanceToolStripMenuItem.Text = "Time And Attendance";
            this.timeAndAttendanceToolStripMenuItem.Visible = false;
            // 
            // checkInOutToolStripMenuItem
            // 
            this.checkInOutToolStripMenuItem.Name = "checkInOutToolStripMenuItem";
            this.checkInOutToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.checkInOutToolStripMenuItem.Text = "Check In / Out";
            this.checkInOutToolStripMenuItem.Click += new System.EventHandler(this.checkInOutToolStripMenuItem_Click);
            // 
            // dutyRoasterToolStripMenuItem
            // 
            this.dutyRoasterToolStripMenuItem.Name = "dutyRoasterToolStripMenuItem";
            this.dutyRoasterToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.dutyRoasterToolStripMenuItem.Text = "Duty Roaster";
            this.dutyRoasterToolStripMenuItem.Click += new System.EventHandler(this.dutyRoasterToolStripMenuItem_Click_1);
            // 
            // downloadUserInfoToolStripMenuItem
            // 
            this.downloadUserInfoToolStripMenuItem.Name = "downloadUserInfoToolStripMenuItem";
            this.downloadUserInfoToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.downloadUserInfoToolStripMenuItem.Text = "Download User Info and FP ";
            this.downloadUserInfoToolStripMenuItem.Click += new System.EventHandler(this.downloadUserInfoToolStripMenuItem_Click);
            // 
            // downloadAttendanceLogsToolStripMenuItem
            // 
            this.downloadAttendanceLogsToolStripMenuItem.Name = "downloadAttendanceLogsToolStripMenuItem";
            this.downloadAttendanceLogsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.downloadAttendanceLogsToolStripMenuItem.Text = "Download Attendance Logs";
            this.downloadAttendanceLogsToolStripMenuItem.Click += new System.EventHandler(this.downloadAttendanceLogsToolStripMenuItem_Click);
            // 
            // enrollUserToolStripMenuItem
            // 
            this.enrollUserToolStripMenuItem.Name = "enrollUserToolStripMenuItem";
            this.enrollUserToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.enrollUserToolStripMenuItem.Text = "Enroll User";
            this.enrollUserToolStripMenuItem.Click += new System.EventHandler(this.enrollUserToolStripMenuItem_Click);
            // 
            // manualCheckOutToolStripMenuItem
            // 
            this.manualCheckOutToolStripMenuItem.Name = "manualCheckOutToolStripMenuItem";
            this.manualCheckOutToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.manualCheckOutToolStripMenuItem.Text = "Manual CheckOut";
            this.manualCheckOutToolStripMenuItem.Click += new System.EventHandler(this.manualCheckOutToolStripMenuItem_Click);
            // 
            // timeCardManagementToolStripMenuItem
            // 
            this.timeCardManagementToolStripMenuItem.Name = "timeCardManagementToolStripMenuItem";
            this.timeCardManagementToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.timeCardManagementToolStripMenuItem.Text = "Time Card Management";
            this.timeCardManagementToolStripMenuItem.Click += new System.EventHandler(this.timeCardManagementToolStripMenuItem_Click_1);
            // 
            // systemSetupToolStripMenuItem
            // 
            this.systemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companySystemSetupToolStripMenuItem,
            this.employmentSystemSetupToolStripMenuItem,
            this.payrollManagementSystemSetupToolStripMenuItem,
            this.timeAndAttendanceSystemSetupToolStripMenuItem,
            this.staffManagementSystemSetupToolStripMenuItem,
            this.userAccountSystemSetupToolStripMenuItem});
            this.systemSetupToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemSetupToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.systemSetupToolStripMenuItem.Name = "systemSetupToolStripMenuItem";
            this.systemSetupToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.systemSetupToolStripMenuItem.Text = "System Setup";
            // 
            // companySystemSetupToolStripMenuItem
            // 
            this.companySystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyBasicInfoToolStripMenuItem});
            this.companySystemSetupToolStripMenuItem.Name = "companySystemSetupToolStripMenuItem";
            this.companySystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.companySystemSetupToolStripMenuItem.Text = "Company";
            // 
            // companyBasicInfoToolStripMenuItem
            // 
            this.companyBasicInfoToolStripMenuItem.Name = "companyBasicInfoToolStripMenuItem";
            this.companyBasicInfoToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.companyBasicInfoToolStripMenuItem.Text = "Basic Info";
            this.companyBasicInfoToolStripMenuItem.Click += new System.EventHandler(this.basicInfoToolStripMenuItem_Click);
            // 
            // employmentSystemSetupToolStripMenuItem
            // 
            this.employmentSystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nationalitiesToolStripMenuItem,
            this.mnuIdentificationTypes,
            this.townsToolStripMenuItem,
            this.regionsToolStripMenuItem,
            this.titlesToolStripMenuItem,
            this.religionsToolStripMenuItem,
            this.trainingtypesToolStripMenuItem,
            this.denominationToolStripMenuItem,
            this.relationshipsToolStripMenuItem,
            this.documentGroupsToolStripMenuItem,
            this.bankToolStripMenuItem,
            this.bankBranchesToolStripMenuItem,
            this.jobTitleToolStripMenuItem,
            this.unitsToolStripMenuItem,
            this.specialtyToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.qualificationTypeToolStripMenuItem,
            this.mnuSponsoredProgrammesMenuItem,
            this.mnuTraingAttendanceModeToolStripMenuItem,
            this.mnuAttendedSchoolsToolStripMenuItem,
            this.mnuTrainingSponsors,
            this.mnuTrainingOrganizers,
            this.occupationalGroupingToolStripMenuItem,
            this.appointmentTypeToolStripMenuItem,
            this.departmentToolStripMenuItem,
            this.promotionTypeToolStripMenuItem});
            this.employmentSystemSetupToolStripMenuItem.Name = "employmentSystemSetupToolStripMenuItem";
            this.employmentSystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.employmentSystemSetupToolStripMenuItem.Text = "Employment";
            // 
            // nationalitiesToolStripMenuItem
            // 
            this.nationalitiesToolStripMenuItem.Name = "nationalitiesToolStripMenuItem";
            this.nationalitiesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.nationalitiesToolStripMenuItem.Text = "Nationality";
            this.nationalitiesToolStripMenuItem.Click += new System.EventHandler(this.nationalitiesToolStripMenuItem_Click);
            // 
            // mnuIdentificationTypes
            // 
            this.mnuIdentificationTypes.Name = "mnuIdentificationTypes";
            this.mnuIdentificationTypes.Size = new System.Drawing.Size(211, 22);
            this.mnuIdentificationTypes.Text = "Identification Types";
            this.mnuIdentificationTypes.Click += new System.EventHandler(this.mnuIdentificationTypes_Click);
            // 
            // townsToolStripMenuItem
            // 
            this.townsToolStripMenuItem.Name = "townsToolStripMenuItem";
            this.townsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.townsToolStripMenuItem.Text = "Town";
            this.townsToolStripMenuItem.Click += new System.EventHandler(this.townsToolStripMenuItem_Click);
            // 
            // regionsToolStripMenuItem
            // 
            this.regionsToolStripMenuItem.Name = "regionsToolStripMenuItem";
            this.regionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.regionsToolStripMenuItem.Text = "District";
            this.regionsToolStripMenuItem.Click += new System.EventHandler(this.regionsToolStripMenuItem_Click);
            // 
            // titlesToolStripMenuItem
            // 
            this.titlesToolStripMenuItem.Name = "titlesToolStripMenuItem";
            this.titlesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.titlesToolStripMenuItem.Text = "Title";
            this.titlesToolStripMenuItem.Click += new System.EventHandler(this.titlesToolStripMenuItem_Click);
            // 
            // religionsToolStripMenuItem
            // 
            this.religionsToolStripMenuItem.Name = "religionsToolStripMenuItem";
            this.religionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.religionsToolStripMenuItem.Text = "Religion";
            this.religionsToolStripMenuItem.Click += new System.EventHandler(this.religionsToolStripMenuItem_Click);
            // 
            // trainingtypesToolStripMenuItem
            // 
            this.trainingtypesToolStripMenuItem.Name = "trainingtypesToolStripMenuItem";
            this.trainingtypesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.trainingtypesToolStripMenuItem.Text = "Training Types";
            this.trainingtypesToolStripMenuItem.Click += new System.EventHandler(this.trainingtypesToolStripMenuItem_Click);
            // 
            // denominationToolStripMenuItem
            // 
            this.denominationToolStripMenuItem.Name = "denominationToolStripMenuItem";
            this.denominationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.denominationToolStripMenuItem.Text = "Denomination";
            this.denominationToolStripMenuItem.Click += new System.EventHandler(this.denominationToolStripMenuItem_Click);
            // 
            // relationshipsToolStripMenuItem
            // 
            this.relationshipsToolStripMenuItem.Name = "relationshipsToolStripMenuItem";
            this.relationshipsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.relationshipsToolStripMenuItem.Text = "Relationship";
            this.relationshipsToolStripMenuItem.Click += new System.EventHandler(this.relationshipsToolStripMenuItem_Click);
            // 
            // documentGroupsToolStripMenuItem
            // 
            this.documentGroupsToolStripMenuItem.Name = "documentGroupsToolStripMenuItem";
            this.documentGroupsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.documentGroupsToolStripMenuItem.Text = "Document Group";
            this.documentGroupsToolStripMenuItem.Click += new System.EventHandler(this.documentGroupsToolStripMenuItem_Click);
            // 
            // bankToolStripMenuItem
            // 
            this.bankToolStripMenuItem.Name = "bankToolStripMenuItem";
            this.bankToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.bankToolStripMenuItem.Text = "Bank ";
            this.bankToolStripMenuItem.Click += new System.EventHandler(this.bankToolStripMenuItem_Click);
            // 
            // bankBranchesToolStripMenuItem
            // 
            this.bankBranchesToolStripMenuItem.Name = "bankBranchesToolStripMenuItem";
            this.bankBranchesToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.bankBranchesToolStripMenuItem.Text = "Bank Branch";
            this.bankBranchesToolStripMenuItem.Click += new System.EventHandler(this.bankBranchesToolStripMenuItem_Click);
            // 
            // jobTitleToolStripMenuItem
            // 
            this.jobTitleToolStripMenuItem.Name = "jobTitleToolStripMenuItem";
            this.jobTitleToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.jobTitleToolStripMenuItem.Text = "Job Title";
            this.jobTitleToolStripMenuItem.Click += new System.EventHandler(this.jobTitleToolStripMenuItem_Click);
            // 
            // unitsToolStripMenuItem
            // 
            this.unitsToolStripMenuItem.Name = "unitsToolStripMenuItem";
            this.unitsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.unitsToolStripMenuItem.Text = "Unit";
            this.unitsToolStripMenuItem.Click += new System.EventHandler(this.unitsToolStripMenuItem_Click);
            // 
            // specialtyToolStripMenuItem
            // 
            this.specialtyToolStripMenuItem.Name = "specialtyToolStripMenuItem";
            this.specialtyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.specialtyToolStripMenuItem.Text = "Specialty";
            this.specialtyToolStripMenuItem.Click += new System.EventHandler(this.specialtyToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // qualificationTypeToolStripMenuItem
            // 
            this.qualificationTypeToolStripMenuItem.Name = "qualificationTypeToolStripMenuItem";
            this.qualificationTypeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.qualificationTypeToolStripMenuItem.Text = "Qualification Type";
            this.qualificationTypeToolStripMenuItem.Click += new System.EventHandler(this.qualificationTypeToolStripMenuItem1_Click);
            // 
            // mnuSponsoredProgrammesMenuItem
            // 
            this.mnuSponsoredProgrammesMenuItem.Name = "mnuSponsoredProgrammesMenuItem";
            this.mnuSponsoredProgrammesMenuItem.Size = new System.Drawing.Size(211, 22);
            this.mnuSponsoredProgrammesMenuItem.Text = "Sponsored Programmes";
            this.mnuSponsoredProgrammesMenuItem.Click += new System.EventHandler(this.mnuSponsoredProgrammesMenuItem_Click);
            // 
            // mnuTraingAttendanceModeToolStripMenuItem
            // 
            this.mnuTraingAttendanceModeToolStripMenuItem.Name = "mnuTraingAttendanceModeToolStripMenuItem";
            this.mnuTraingAttendanceModeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.mnuTraingAttendanceModeToolStripMenuItem.Text = "Traing Attendance Mode";
            this.mnuTraingAttendanceModeToolStripMenuItem.Click += new System.EventHandler(this.mnuTraingAttendanceModeToolStripMenuItem_Click);
            // 
            // mnuAttendedSchoolsToolStripMenuItem
            // 
            this.mnuAttendedSchoolsToolStripMenuItem.Name = "mnuAttendedSchoolsToolStripMenuItem";
            this.mnuAttendedSchoolsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.mnuAttendedSchoolsToolStripMenuItem.Text = "Attended Schools";
            this.mnuAttendedSchoolsToolStripMenuItem.Click += new System.EventHandler(this.mnuAttendedSchoolsToolStripMenuItem_Click);
            // 
            // mnuTrainingSponsors
            // 
            this.mnuTrainingSponsors.Name = "mnuTrainingSponsors";
            this.mnuTrainingSponsors.Size = new System.Drawing.Size(211, 22);
            this.mnuTrainingSponsors.Text = "Training Sponsors";
            this.mnuTrainingSponsors.Click += new System.EventHandler(this.mnuTrainingSponsors_Click);
            // 
            // mnuTrainingOrganizers
            // 
            this.mnuTrainingOrganizers.Name = "mnuTrainingOrganizers";
            this.mnuTrainingOrganizers.Size = new System.Drawing.Size(211, 22);
            this.mnuTrainingOrganizers.Text = "Training Organizers";
            this.mnuTrainingOrganizers.Click += new System.EventHandler(this.mnuTrainingOrganizers_Click);
            // 
            // occupationalGroupingToolStripMenuItem
            // 
            this.occupationalGroupingToolStripMenuItem.Name = "occupationalGroupingToolStripMenuItem";
            this.occupationalGroupingToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.occupationalGroupingToolStripMenuItem.Text = "Occupational Grouping";
            this.occupationalGroupingToolStripMenuItem.Click += new System.EventHandler(this.occupationalGroupingToolStripMenuItem_Click);
            // 
            // appointmentTypeToolStripMenuItem
            // 
            this.appointmentTypeToolStripMenuItem.Name = "appointmentTypeToolStripMenuItem";
            this.appointmentTypeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.appointmentTypeToolStripMenuItem.Text = "Appointment Type";
            this.appointmentTypeToolStripMenuItem.Click += new System.EventHandler(this.appointmentTypeToolStripMenuItem_Click);
            // 
            // departmentToolStripMenuItem
            // 
            this.departmentToolStripMenuItem.Name = "departmentToolStripMenuItem";
            this.departmentToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.departmentToolStripMenuItem.Text = "Department";
            this.departmentToolStripMenuItem.Click += new System.EventHandler(this.departmentToolStripMenuItem_Click);
            // 
            // promotionTypeToolStripMenuItem
            // 
            this.promotionTypeToolStripMenuItem.Name = "promotionTypeToolStripMenuItem";
            this.promotionTypeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.promotionTypeToolStripMenuItem.Text = "Promotion Type";
            this.promotionTypeToolStripMenuItem.Click += new System.EventHandler(this.promotionTypeToolStripMenuItem_Click);
            // 
            // payrollManagementSystemSetupToolStripMenuItem
            // 
            this.payrollManagementSystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allowanceTypesToolStripMenuItem,
            this.deductioToolStripMenuItem,
            this.payGradesToolStripMenuItem,
            this.salaryStruToolStripMenuItem,
            this.mnuSalaryPaymentAccounts});
            this.payrollManagementSystemSetupToolStripMenuItem.Name = "payrollManagementSystemSetupToolStripMenuItem";
            this.payrollManagementSystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.payrollManagementSystemSetupToolStripMenuItem.Text = "Payroll Management";
            // 
            // allowanceTypesToolStripMenuItem
            // 
            this.allowanceTypesToolStripMenuItem.Name = "allowanceTypesToolStripMenuItem";
            this.allowanceTypesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.allowanceTypesToolStripMenuItem.Text = "Allowances";
            this.allowanceTypesToolStripMenuItem.Click += new System.EventHandler(this.allowanceTypesToolStripMenuItem_Click);
            // 
            // deductioToolStripMenuItem
            // 
            this.deductioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.incomeTaxToolStripMenuItem,
            this.sSNITContributionToolStripMenuItem,
            this.loanSetupFormToolStripMenuItem,
            this.otherDeductionsSetupFormToolStripMenuItem});
            this.deductioToolStripMenuItem.Name = "deductioToolStripMenuItem";
            this.deductioToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.deductioToolStripMenuItem.Text = "Deductions";
            // 
            // incomeTaxToolStripMenuItem
            // 
            this.incomeTaxToolStripMenuItem.Name = "incomeTaxToolStripMenuItem";
            this.incomeTaxToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.incomeTaxToolStripMenuItem.Text = "Income Tax";
            this.incomeTaxToolStripMenuItem.Click += new System.EventHandler(this.incomeTaxToolStripMenuItem_Click);
            // 
            // sSNITContributionToolStripMenuItem
            // 
            this.sSNITContributionToolStripMenuItem.Name = "sSNITContributionToolStripMenuItem";
            this.sSNITContributionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.sSNITContributionToolStripMenuItem.Text = "SSNIT Contribution";
            this.sSNITContributionToolStripMenuItem.Click += new System.EventHandler(this.sSNITContributionToolStripMenuItem_Click);
            // 
            // loanSetupFormToolStripMenuItem
            // 
            this.loanSetupFormToolStripMenuItem.Name = "loanSetupFormToolStripMenuItem";
            this.loanSetupFormToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.loanSetupFormToolStripMenuItem.Text = "Loans";
            this.loanSetupFormToolStripMenuItem.Click += new System.EventHandler(this.loansToolStripMenuItem2_Click);
            // 
            // otherDeductionsSetupFormToolStripMenuItem
            // 
            this.otherDeductionsSetupFormToolStripMenuItem.Name = "otherDeductionsSetupFormToolStripMenuItem";
            this.otherDeductionsSetupFormToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.otherDeductionsSetupFormToolStripMenuItem.Text = "Other Deductions";
            this.otherDeductionsSetupFormToolStripMenuItem.Click += new System.EventHandler(this.otherDeductionsToolStripMenuItem1_Click);
            // 
            // payGradesToolStripMenuItem
            // 
            this.payGradesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradeCategoriesToolStripMenuItem,
            this.gradeSetupFormToolStripMenuItem,
            this.stepToolStripMenuItem,
            this.gradesalaries});
            this.payGradesToolStripMenuItem.Name = "payGradesToolStripMenuItem";
            this.payGradesToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.payGradesToolStripMenuItem.Text = "Pay Grades";
            // 
            // gradeCategoriesToolStripMenuItem
            // 
            this.gradeCategoriesToolStripMenuItem.Name = "gradeCategoriesToolStripMenuItem";
            this.gradeCategoriesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gradeCategoriesToolStripMenuItem.Text = "Grade Categories";
            this.gradeCategoriesToolStripMenuItem.Click += new System.EventHandler(this.gradeCategoriesToolStripMenuItem_Click);
            // 
            // gradeSetupFormToolStripMenuItem
            // 
            this.gradeSetupFormToolStripMenuItem.Name = "gradeSetupFormToolStripMenuItem";
            this.gradeSetupFormToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gradeSetupFormToolStripMenuItem.Text = "Grades";
            this.gradeSetupFormToolStripMenuItem.Click += new System.EventHandler(this.gradesToolStripMenuItem1_Click);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // gradesalaries
            // 
            this.gradesalaries.Name = "gradesalaries";
            this.gradesalaries.Size = new System.Drawing.Size(167, 22);
            this.gradesalaries.Text = "Basic Salaries";
            this.gradesalaries.Click += new System.EventHandler(this.toolStripMenuItem1_Click_1);
            // 
            // salaryStruToolStripMenuItem
            // 
            this.salaryStruToolStripMenuItem.Name = "salaryStruToolStripMenuItem";
            this.salaryStruToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.salaryStruToolStripMenuItem.Text = "Salary Structure";
            this.salaryStruToolStripMenuItem.Visible = false;
            this.salaryStruToolStripMenuItem.Click += new System.EventHandler(this.salaryStruToolStripMenuItem_Click);
            // 
            // mnuSalaryPaymentAccounts
            // 
            this.mnuSalaryPaymentAccounts.Name = "mnuSalaryPaymentAccounts";
            this.mnuSalaryPaymentAccounts.Size = new System.Drawing.Size(212, 22);
            this.mnuSalaryPaymentAccounts.Text = "Salary Payment Accounts";
            this.mnuSalaryPaymentAccounts.Click += new System.EventHandler(this.mnuSalaryPaymentAccounts_Click);
            // 
            // timeAndAttendanceSystemSetupToolStripMenuItem
            // 
            this.timeAndAttendanceSystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roasterGroupsToolStripMenuItem,
            this.shiftsToolStripMenuItem,
            this.holidaysToolStripMenuItem});
            this.timeAndAttendanceSystemSetupToolStripMenuItem.Name = "timeAndAttendanceSystemSetupToolStripMenuItem";
            this.timeAndAttendanceSystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.timeAndAttendanceSystemSetupToolStripMenuItem.Text = "Time And Attendance";
            // 
            // roasterGroupsToolStripMenuItem
            // 
            this.roasterGroupsToolStripMenuItem.Name = "roasterGroupsToolStripMenuItem";
            this.roasterGroupsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.roasterGroupsToolStripMenuItem.Text = "Roaster Groups";
            this.roasterGroupsToolStripMenuItem.Click += new System.EventHandler(this.roasterGroupsToolStripMenuItem_Click);
            // 
            // shiftsToolStripMenuItem
            // 
            this.shiftsToolStripMenuItem.Name = "shiftsToolStripMenuItem";
            this.shiftsToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.shiftsToolStripMenuItem.Text = "Shifts";
            this.shiftsToolStripMenuItem.Click += new System.EventHandler(this.shiftsToolStripMenuItem_Click_2);
            // 
            // holidaysToolStripMenuItem
            // 
            this.holidaysToolStripMenuItem.Name = "holidaysToolStripMenuItem";
            this.holidaysToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.holidaysToolStripMenuItem.Text = "Holidays";
            this.holidaysToolStripMenuItem.Click += new System.EventHandler(this.holidaysToolStripMenuItem_Click);
            // 
            // staffManagementSystemSetupToolStripMenuItem
            // 
            this.staffManagementSystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.leaveTypeFormToolStripMenuItem,
            this.annualLeaveEntitlementToolStripMenuItem,
            this.sanctionTypeToolStripMenuItem,
            this.mnuAppraisalFactors,
            this.mnuAppraisalRatings,
            this.mnuAppraisalPeriods,
            this.leaveLetterSignatureToolStripMenuItem});
            this.staffManagementSystemSetupToolStripMenuItem.Name = "staffManagementSystemSetupToolStripMenuItem";
            this.staffManagementSystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.staffManagementSystemSetupToolStripMenuItem.Text = "Staff Management";
            // 
            // leaveTypeFormToolStripMenuItem
            // 
            this.leaveTypeFormToolStripMenuItem.Name = "leaveTypeFormToolStripMenuItem";
            this.leaveTypeFormToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.leaveTypeFormToolStripMenuItem.Text = "Leave Types";
            this.leaveTypeFormToolStripMenuItem.Click += new System.EventHandler(this.rosterGroupsToolStripMenuItem1_Click);
            // 
            // annualLeaveEntitlementToolStripMenuItem
            // 
            this.annualLeaveEntitlementToolStripMenuItem.Name = "annualLeaveEntitlementToolStripMenuItem";
            this.annualLeaveEntitlementToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.annualLeaveEntitlementToolStripMenuItem.Text = "Annual Leave Entitlement";
            this.annualLeaveEntitlementToolStripMenuItem.Click += new System.EventHandler(this.annualLeaveEntitlementToolStripMenuItem_Click);
            // 
            // sanctionTypeToolStripMenuItem
            // 
            this.sanctionTypeToolStripMenuItem.Name = "sanctionTypeToolStripMenuItem";
            this.sanctionTypeToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.sanctionTypeToolStripMenuItem.Text = "SanctionType";
            this.sanctionTypeToolStripMenuItem.Click += new System.EventHandler(this.sanctionTypeToolStripMenuItem_Click);
            // 
            // mnuAppraisalFactors
            // 
            this.mnuAppraisalFactors.Name = "mnuAppraisalFactors";
            this.mnuAppraisalFactors.Size = new System.Drawing.Size(215, 22);
            this.mnuAppraisalFactors.Text = "Appraisal Factors";
            this.mnuAppraisalFactors.Click += new System.EventHandler(this.mnuAppraisalFactors_Click);
            // 
            // mnuAppraisalRatings
            // 
            this.mnuAppraisalRatings.Name = "mnuAppraisalRatings";
            this.mnuAppraisalRatings.Size = new System.Drawing.Size(215, 22);
            this.mnuAppraisalRatings.Text = "Appraisal Ratings";
            this.mnuAppraisalRatings.Click += new System.EventHandler(this.mnuAppraisalRatings_Click);
            // 
            // mnuAppraisalPeriods
            // 
            this.mnuAppraisalPeriods.Name = "mnuAppraisalPeriods";
            this.mnuAppraisalPeriods.Size = new System.Drawing.Size(215, 22);
            this.mnuAppraisalPeriods.Text = "Appraisal Periods";
            this.mnuAppraisalPeriods.Click += new System.EventHandler(this.mnuAppraisalPeriods_Click);
            // 
            // leaveLetterSignatureToolStripMenuItem
            // 
            this.leaveLetterSignatureToolStripMenuItem.Name = "leaveLetterSignatureToolStripMenuItem";
            this.leaveLetterSignatureToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.leaveLetterSignatureToolStripMenuItem.Text = "Leave Letter Signature";
            this.leaveLetterSignatureToolStripMenuItem.Click += new System.EventHandler(this.leaveLetterSignatureToolStripMenuItem_Click);
            // 
            // userAccountSystemSetupToolStripMenuItem
            // 
            this.userAccountSystemSetupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.userLogToolStripMenuItem,
            this.userRolesToolStripMenuItem,
            this.managePermissionsToolStripMenuItem,
            this.manageRolesToolStripMenuItem});
            this.userAccountSystemSetupToolStripMenuItem.Name = "userAccountSystemSetupToolStripMenuItem";
            this.userAccountSystemSetupToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.userAccountSystemSetupToolStripMenuItem.Text = "User Account";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.setupToolStripMenuItem.Text = "Users";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // userLogToolStripMenuItem
            // 
            this.userLogToolStripMenuItem.Name = "userLogToolStripMenuItem";
            this.userLogToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.userLogToolStripMenuItem.Text = "User Roles";
            this.userLogToolStripMenuItem.Click += new System.EventHandler(this.userLogToolStripMenuItem_Click);
            // 
            // userRolesToolStripMenuItem
            // 
            this.userRolesToolStripMenuItem.Name = "userRolesToolStripMenuItem";
            this.userRolesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.userRolesToolStripMenuItem.Text = "User Categories";
            this.userRolesToolStripMenuItem.Click += new System.EventHandler(this.userRolesToolStripMenuItem_Click);
            // 
            // managePermissionsToolStripMenuItem
            // 
            this.managePermissionsToolStripMenuItem.Name = "managePermissionsToolStripMenuItem";
            this.managePermissionsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.managePermissionsToolStripMenuItem.Text = "Manage Permissions";
            this.managePermissionsToolStripMenuItem.Click += new System.EventHandler(this.managePermissionsToolStripMenuItem_Click);
            // 
            // manageRolesToolStripMenuItem
            // 
            this.manageRolesToolStripMenuItem.Name = "manageRolesToolStripMenuItem";
            this.manageRolesToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.manageRolesToolStripMenuItem.Text = "Manage Roles";
            this.manageRolesToolStripMenuItem.Click += new System.EventHandler(this.manageRolesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordFormToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.exitFormToolStripMenuItem});
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // changePasswordFormToolStripMenuItem
            // 
            this.changePasswordFormToolStripMenuItem.Name = "changePasswordFormToolStripMenuItem";
            this.changePasswordFormToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.changePasswordFormToolStripMenuItem.Text = "Change Password";
            this.changePasswordFormToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click_2);
            // 
            // exitFormToolStripMenuItem
            // 
            this.exitFormToolStripMenuItem.Name = "exitFormToolStripMenuItem";
            this.exitFormToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.exitFormToolStripMenuItem.Text = "Exit";
            this.exitFormToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(687, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            this.menuStrip2.Visible = false;
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Text = "notifyIcon1";
            this.notifyIconMain.Visible = true;
            // 
            // MainMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::eMAS.Properties.Resources.bgp;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(747, 395);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMDI";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Human Resource Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem recruitmentManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollProcessingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacancyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loansSalaryAdvanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollGenerationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem organizationalReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem departmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowanceSetupReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deductionSetupReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payRollManagementReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffManagementReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanPaymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionalReportsToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem companySystemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyBasicInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userAccountSystemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowancesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deductionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeeBanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salaryInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recruitmentReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employmentSystemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffManagementSystemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveTypeFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payrollManagementSystemSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allowanceTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deductioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSNITContributionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanSetupFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherDeductionsSetupFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem payGradesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeCategoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradeSetupFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveRequestFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performalAppraisalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loansToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loanReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sSNITReturnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeTaxReturnsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffListReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pensioneersReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attendanceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dutyRoasterReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveReportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicantListReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vacancyListReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interviewListReportToolStripMenuItem;
        private ToolStripMenuItem payRollAndPaySlipReportToolStripMenuItem;
        private ToolStripMenuItem nationalitiesToolStripMenuItem;
        private ToolStripMenuItem townsToolStripMenuItem;
        private ToolStripMenuItem regionsToolStripMenuItem;
        private ToolStripMenuItem titlesToolStripMenuItem;
        private ToolStripMenuItem religionsToolStripMenuItem;
        private ToolStripMenuItem relationshipsToolStripMenuItem;
        private ToolStripMenuItem documentGroupsToolStripMenuItem;
        private ToolStripMenuItem timeAndAttendanceToolStripMenuItem;
        private ToolStripMenuItem checkInOutToolStripMenuItem;
        private ToolStripMenuItem timeAndAttendanceSystemSetupToolStripMenuItem;
        private ToolStripMenuItem dutyRoasterToolStripMenuItem;
        private ToolStripMenuItem roasterGroupsToolStripMenuItem;
        private ToolStripMenuItem shiftsToolStripMenuItem;
        private ToolStripMenuItem holidaysToolStripMenuItem;
        private ToolStripMenuItem detailedProfileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem changePasswordFormToolStripMenuItem;
        private ToolStripMenuItem exitFormToolStripMenuItem;
        private ToolStripMenuItem medicalClaimsToolStripMenuItem;
        private ToolStripMenuItem medicalClaimsMonthlyReportToolStripMenuItem;
        private ToolStripMenuItem stepToolStripMenuItem;
        private ToolStripMenuItem leaveRecommendationFormToolStripMenuItem;
        private ToolStripMenuItem trainingToolStripMenuItem;
        private ToolStripMenuItem leaveRoasterFormToolStripMenuItem;
        private ToolStripMenuItem leaveApprovalFormToolStripMenuItem;
        private ToolStripMenuItem promotionAndDemotionToolStripMenuItem;
        private ToolStripMenuItem healthAndSafetyToolStripMenuItem;
        private ToolStripMenuItem disciplinaryRecordsToolStripMenuItem;
        private ToolStripMenuItem internshipToolStripMenuItem;
        private ToolStripMenuItem accomodationToolStripMenuItem;
        private ToolStripMenuItem houseOfficersRotationToolStripMenuItem;
        private ToolStripMenuItem otherDeductionsToolStripMenuItem;
        private ToolStripMenuItem bankAdviceSlipToolStripMenuItem;
        private ToolStripMenuItem bankToolStripMenuItem;
        private ToolStripMenuItem bankBranchesToolStripMenuItem;
        private ToolStripMenuItem jobTitleToolStripMenuItem;
        private ToolStripMenuItem denominationToolStripMenuItem;
        private ToolStripMenuItem unitsToolStripMenuItem;
        private ToolStripMenuItem specialtyToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem promotionToolStripMenuItem;
        private ToolStripMenuItem confirmationToolStripMenuItem;
        private ToolStripMenuItem demotionToolStripMenuItem;
        private ToolStripMenuItem incrementToolStripMenuItem;
        private ToolStripMenuItem generalIncrementFormToolStripMenuItem;
        private ToolStripMenuItem reverseGeneralIncrementFormToolStripMenuItem;
        private ToolStripMenuItem demotionFormToolStripMenuItem;
        private ToolStripMenuItem correctDemotionDateToolStripMenuItem;
        private ToolStripMenuItem selectiveIncrementFormToolStripMenuItem;
        private ToolStripMenuItem reverseSelectiveIncrementFormToolStripMenuItem;
        private ToolStripMenuItem sanctionsToolStripMenuItem;
        private ToolStripMenuItem reinstatingSanctionedStaffToolStripMenuItem;
        private ToolStripMenuItem staffUnderInvestigationToolStripMenuItem;
        private ToolStripMenuItem trainingAttendanceToolStripMenuItem;
        private ToolStripMenuItem listOfAttendanceToolStripMenuItem;
        private ToolStripMenuItem changeOfJobTitleFormToolStripMenuItem;
        private ToolStripMenuItem calculateAnnualLeaveToolStripMenuItem;
        private ToolStripMenuItem annualLeavecCalculateFormToolStripMenuItem;
        private ToolStripMenuItem annualLeaveReverseFormToolStripMenuItem;
        private ToolStripMenuItem listUnitToolStripMenuItem;
        private ToolStripMenuItem listGradeCategoriesToolStripMenuItem;
        private ToolStripMenuItem listZonesToolStripMenuItem;
        private ToolStripMenuItem listJobTitlesToolStripMenuItem;
        private ToolStripMenuItem listInternsNotOnPayrollToolStripMenuItem;
        private ToolStripMenuItem transferListReportToolStripMenuItem;
        private ToolStripMenuItem listBankReportToolStripMenuItem;
        private ToolStripMenuItem listBankBranchesToolStripMenuItem;
        private ToolStripMenuItem summaryOfLoansToolStripMenuItem;
        private ToolStripMenuItem summaryLoansPaymentsToolStripMenuItem;
        private ToolStripMenuItem leaveRoasterToolStripMenuItem;
        private ToolStripMenuItem leaveResumptionReportToolStripMenuItem;
        private ToolStripMenuItem reprintOfLeaveLetterReportToolStripMenuItem;
        private ToolStripMenuItem establishmentReportToolStripMenuItem;
        private ToolStripMenuItem establishmentListSummaryToolStripMenuItem;
        private ToolStripMenuItem establishmentListToolStripMenuItem;
        private ToolStripMenuItem statisticsReportsToolStripMenuItem;
        private ToolStripMenuItem lengthOfServiceToolStripMenuItem;
        private ToolStripMenuItem ageDistributionToolStripMenuItem;
        private ToolStripMenuItem joinersStatsToolStripMenuItem;
        private ToolStripMenuItem wastageReportToolStripMenuItem;
        private ToolStripMenuItem wastageReportsToolStripMenuItem;
        private ToolStripMenuItem lengthOfServiceReportToolStripMenuItem;
        private ToolStripMenuItem staffListByAgeReportToolStripMenuItem;
        private ToolStripMenuItem changeJobTitleToolStripMenuItem;
        private ToolStripMenuItem auditReportsToolStripMenuItem;
        private ToolStripMenuItem staffDurationOnGradeToolStripMenuItem;
        private ToolStripMenuItem staffDurationOnGradeReportToolStripMenuItem;
        private ToolStripMenuItem staffDueForPromotionReportToolStripMenuItem;
        private ToolStripMenuItem staffDurationInBranchToolStripMenuItem;
        private ToolStripMenuItem staffDueForTransferReportToolStripMenuItem;
        private ToolStripMenuItem staffDurationAtAZoneReportToolStripMenuItem;
        private ToolStripMenuItem staffListByQualificationTypeReportToolStripMenuItem;
        private ToolStripMenuItem joinersReportToolStripMenuItem;
        private ToolStripMenuItem birthdayReportsToolStripMenuItem;
        private ToolStripMenuItem birthdayLettersToolStripMenuItem;
        private ToolStripMenuItem medicalReportsToolStripMenuItem;
        private ToolStripMenuItem listOfStaffCelebratingBirthdayReportToolStripMenuItem;
        private ToolStripMenuItem sickLeaveListToolStripMenuItem;
        private ToolStripMenuItem hospitalBillsToolStripMenuItem;
        private ToolStripMenuItem hospitalAttendanceToolStripMenuItem;
        private ToolStripMenuItem spectaclesIssuedToolStripMenuItem;
        private ToolStripMenuItem lensIssuedToolStripMenuItem;
        private ToolStripMenuItem listStaffDueForSpectaclesToolStripMenuItem;
        private ToolStripMenuItem listStaffDueForLensesToolStripMenuItem;
        private ToolStripMenuItem dependentsListToolStripMenuItem;
        private ToolStripMenuItem leaveReportToolStripMenuItem;
        private ToolStripMenuItem staffDemotionApprovalFormToolStripMenuItem;
        private ToolStripMenuItem otherAllowanceToolStripMenuItem;
        private ToolStripMenuItem staffListByGenderReportToolStripMenuItem;
        private ToolStripMenuItem staffListByBankReportToolStripMenuItem;
        private ToolStripMenuItem staffListByJobReportToolStripMenuItem;
        private ToolStripMenuItem staffListByZoneReportToolStripMenuItem;
        private ToolStripMenuItem staffListRetiringReportToolStripMenuItem;
        private ToolStripMenuItem staffListByGradeReportToolStripMenuItem;
        private ToolStripMenuItem distributionByAgeToolStripMenuItem;
        private ToolStripMenuItem distributionByCategoryToolStripMenuItem;
        private ToolStripMenuItem distributionByGradeToolStripMenuItem;
        private ToolStripMenuItem genderDistributionToolStripMenuItem;
        private ToolStripMenuItem summaryToolStripMenuItem;
        private ToolStripMenuItem distributionByZoneToolStripMenuItem;
        private ToolStripMenuItem distributionByToolStripMenuItem;
        private ToolStripMenuItem confirmationsFormToolStripMenuItem;
        private ToolStripMenuItem listOfStaffOnProbationDueForApprovalToolStripMenuItem;
        private ToolStripMenuItem sanctionsListToolStripMenuItem;
        private ToolStripMenuItem qualificationTypeToolStripMenuItem;
        private ToolStripMenuItem sanctionTypeToolStripMenuItem;
        private ToolStripMenuItem occupationalGroupingToolStripMenuItem;
        private ToolStripMenuItem summaryDeductionReportToolStripMenuItem;
        private ToolStripMenuItem detailDeductionsReportToolStripMenuItem;
        private ToolStripMenuItem summaryAllowanceReportToolStripMenuItem;
        private ToolStripMenuItem detailAllowanceReportToolStripMenuItem;
        private ToolStripMenuItem susuMonthlyContributionToolStripMenuItem;
        private ToolStripMenuItem withholdingMonthlyContrbutionsToolStripMenuItem;
        private ToolStripMenuItem sMSToolStripMenuItem;
        private ToolStripMenuItem downloadUserInfoToolStripMenuItem;
        private ToolStripMenuItem downloadAttendanceLogsToolStripMenuItem;
        private ToolStripMenuItem enrollUserToolStripMenuItem;
        private ToolStripMenuItem bulkConfirmationsFormToolStripMenuItem;
        private ToolStripMenuItem salaryInfoFormToolStripMenuItem;
        private ToolStripMenuItem bulkSalaryInfoToolStripMenuItem;
        private ToolStripMenuItem separationToolStripMenuItem;
        private ToolStripMenuItem transferToolStripMenuItem;
        private ToolStripMenuItem salaryStruToolStripMenuItem;
        private ToolStripMenuItem appointmentTypeToolStripMenuItem;
        private ToolStripMenuItem correctPromotionDateToolStripMenuItem;
        private ToolStripMenuItem staffPromotionApprovalFormToolStripMenuItem;
        private ToolStripMenuItem listOfPromotedStaffsToolStripMenuItem;
        private ToolStripMenuItem reinstatingSeparatedStaffToolStripMenuItem;
        private ToolStripMenuItem listOfStaffDueForSeparationToolStripMenuItem;
        private ToolStripMenuItem annualLeaveEntitlementToolStripMenuItem;
        private ToolStripMenuItem separationReportToolStripMenuItem;
        private ToolStripMenuItem medicalClaimsFormToolStripMenuItem;
        private ToolStripMenuItem approveMedicalCliamsToolStripMenuItem;
        private ToolStripMenuItem medicalClaimsReportToolStripMenuItem;
        private ToolStripMenuItem sSNITContributionReportToolStripMenuItem;
        private ToolStripMenuItem secondTierPensionPaymentReportToolStripMenuItem;
        private ToolStripMenuItem firstTierPensionPaymentReportToolStripMenuItem;
        private ToolStripMenuItem arrearsToolStripMenuItem;
        private ToolStripMenuItem transferReportToolStripMenuItem;
        private ToolStripMenuItem internshipReportToolStripMenuItem;
        private ToolStripMenuItem leaveResumptionFormToolStripMenuItem;
        private ToolStripMenuItem leaveRecallFormToolStripMenuItem;
        private ToolStripMenuItem promotionReportToolStripMenuItem;
        private ToolStripMenuItem listOfStaffDueForPromotionReportToolStripMenuItem;
        private ToolStripMenuItem managePermissionsToolStripMenuItem;
        private ToolStripMenuItem manageRolesToolStripMenuItem;
        private ToolStripMenuItem interviewReportToolStripMenuItem;
        private ToolStripMenuItem applicantReportToolStripMenuItem;
        private ToolStripMenuItem changeOfGradeFormToolStripMenuItem;
        private ToolStripMenuItem changeOfNameFormToolStripMenuItem;
        private ToolStripMenuItem changeOfEmploymentDateFormToolStripMenuItem;
        private ToolStripMenuItem changeOfDOBFormToolStripMenuItem;
        private ToolStripMenuItem changeOfStatusFormToolStripMenuItem;
        private ToolStripMenuItem changeOfAppointmentTypeFormToolStripMenuItem;
        private ToolStripMenuItem overTimeToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem departmentToolStripMenuItem;
        private ToolStripMenuItem sanctionReportToolStripMenuItem;
        private ToolStripMenuItem staffChangesReportToolStripMenuItem;
        private ToolStripMenuItem QuickbookMappingToolStripMenuItem;
        private ToolStripMenuItem QuickbookDataGenerationToolStripMenuItem;
        private ToolStripMenuItem gradesalaries;
        private NotifyIcon notifyIconMain;
        private ToolStripMenuItem notificationsToolStripMenuItem;
        private ToolStripMenuItem excuseDutytoolStripMenuItem;
        private ToolStripMenuItem excuseDutyRequestToolStripMenuItem;
        private ToolStripMenuItem excuseDutyRecommendationToolStripMenuItem;
        private ToolStripMenuItem excuseDutyApprovalToolStripMenuItem;
        private ToolStripMenuItem excuseDutyResumptionToolStripMenuItem;
        private ToolStripMenuItem exuseDutyHRRecommendationToolStripMenuItem;
        private ToolStripMenuItem mnuTraingAttendanceModeToolStripMenuItem;
        private ToolStripMenuItem mnuAttendedSchoolsToolStripMenuItem;
        private ToolStripMenuItem mnuSponsoredProgrammesMenuItem;
        private ToolStripMenuItem mnuexternalTrainingToolStripMenuItem;
        private ToolStripMenuItem mnuTrainingSponsors;
        private ToolStripMenuItem mnuTrainingOrganizers;
        private ToolStripMenuItem mnuExcuseDutyReport;
        private ToolStripMenuItem mnuAppraisalFactors;
        private ToolStripMenuItem mnuAppraisalRatings;
        private ToolStripMenuItem mnuAppraisalPeriods;
        private ToolStripMenuItem mnustaffsObjectives;
        private ToolStripMenuItem mnustaffAppraisal;
        private ToolStripMenuItem mnuExternalTrainingJustification;
        private ToolStripMenuItem mnuExternalTrainingHRRecommendation;
        private ToolStripMenuItem mnuExternalTrainingCEOApproval;
        private ToolStripMenuItem trainingReportsToolStripMenuItem;
        private ToolStripMenuItem trainingReportToolStripMenuItem;
        private ToolStripMenuItem courseAttendanceReportToolStripMenuItem;
        private ToolStripMenuItem mnuExcuseDutyRequests;
        private ToolStripMenuItem mnuExcuseDutyReportForm;
        private ToolStripMenuItem mnuExternalTrainingReport;
        private ToolStripMenuItem mnuTrainingBondsReport;
        private ToolStripMenuItem mnuAppraisalReports;
        private ToolStripMenuItem mnuAppraisalListReport;
        private ToolStripMenuItem mnuIdentificationTypes;
        private ToolStripMenuItem mnuSalaryPaymentAccounts;
        private ToolStripMenuItem mnutrainingBondToolStripMenuItem;
        private ToolStripMenuItem leaveLetterSignatureToolStripMenuItem;
        private ToolStripMenuItem manualCheckOutToolStripMenuItem;
        private ToolStripMenuItem trainingtypesToolStripMenuItem;
        private ToolStripMenuItem staffLeaveBalancesToolStripMenuItem;
        private ToolStripMenuItem leaveEncashmentToolStripMenuItem;
        private ToolStripMenuItem leaveEncashmentReportToolStripMenuItem;
        private ToolStripMenuItem changeOfMaritalStatusToolStripMenuItem;
        private ToolStripMenuItem changeOfQualificationToolStripMenuItem;
        private ToolStripMenuItem staffDueForPromotionToolStripMenuItem;
        private ToolStripMenuItem staffListByAppointmentReportToolStrilMenuItem;
        private ToolStripMenuItem taxReliefToolStripMenuItem;
        private ToolStripMenuItem timeCardManagementToolStripMenuItem;
        private ToolStripMenuItem mnuOverTimeToolStripMenuItem;
        private ToolStripMenuItem mnuDutyAllowancesMenuItem;
        private ToolStripMenuItem taxReliefToolStripMenuItem1;
        private ToolStripMenuItem trainingReportToolStripMenuItem1;
        private ToolStripMenuItem promotionTypeToolStripMenuItem;
        private ToolStripMenuItem arrearsToolStripMenuItem1;
        private ToolStripMenuItem allowanceArrearsToolStripMenuItem;
        private ToolStripMenuItem salaryAdvanceToolStripMenuItem;
        private ToolStripMenuItem riskAllowancesToolStripMenuItem;
        private ToolStripMenuItem staffSummaryToolStripMenuItem1;
        private ToolStripMenuItem locumToolStripMenuItem;
        private ToolStripMenuItem restartToolStripMenuItem;
        private ToolStripMenuItem logOutToolStripMenuItem;
        private ToolStripMenuItem locumReportToolStripMenuItem;
        private ToolStripMenuItem studyLeaveToolStripMenuItem;
        private ToolStripMenuItem changeofDetailsToolStripMenuItem;
        private ToolStripMenuItem requestChangesToolStripMenuItem;
        private ToolStripMenuItem approveChangesToolStripMenuItem;
        private ToolStripMenuItem reinstatingTransferedStaffToolStripMenuItem;
        private ToolStripMenuItem vehicleReportMenuItem;
        private ToolStripMenuItem trainingEvaluationToolStripMenuItem;
        private ToolStripMenuItem trainingEvaluationReportToolStripMenuItem;
        private ToolStripMenuItem studyLeaveReportToolStripMenuItem;
    }
}

