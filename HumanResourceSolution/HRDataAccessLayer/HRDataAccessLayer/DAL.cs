using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRDataAccessLayerBase;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.SMS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer.SMS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.EMAIL;
using HRDataAccessLayer.EMAILS;

namespace HRDataAccessLayer
{
    public class DAL: IDAL
    {
        private DALHelper dalHelper;

        public DAL()
        {
            try
            {
                this.dalHelper = new DALHelper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Transaction Management
        public bool IsInTransaction 
        {
            get { return dalHelper.IsInTransaction; }
        }

        public void BeginTransaction()
        {
            try
            {
                dalHelper.BeginTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CommitTransaction()
        {
            try
            {
                dalHelper.CommitTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RollBackTransaction()
        {
            try
            {
                dalHelper.RollBackTransaction();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Concurrency Management
        public bool IsDirty 
        {
            get { return false; }
        }
        #endregion

        #region Save
        public void Save(object item)
        {
            if (item.GetType() == typeof(Employee))
            {
                EmployeeDataMapper edm = new EmployeeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceSubCategory))
            {
                AllowanceSubCategoryDataMapper edm = new AllowanceSubCategoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper edm = new ChartOfAccountGenerationDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper edm = new ChartOfAccountMappingDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountType))
            {
                ChartOfAccountTypeDataMapper edm = new ChartOfAccountTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTimeType))
            {
                OverTimeTypeDataMapper edm = new OverTimeTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTime))
            {
                OverTimeDataMapper edm = new OverTimeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper edm = new StaffDOBChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper edm = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper edm = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper edm = new StaffNameChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper edm = new StaffStatusChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper edm = new StaffJobTitleChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper edm = new StaffGradeChangeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ControlToRole))
            {
                ControlToRoleDataMapper edm = new ControlToRoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Controls))
            {
                ControlDataMapper edm = new ControlDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserToRole))
            {
                UserToRoleDataMapper edm = new UserToRoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Role))
            {
                RoleDataMapper edm = new RoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SSNITContribution))
            {
                SSNITContributionDataMapper edm = new SSNITContributionDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLeaveRoaster))
            {
                StaffLeaveRoasterDataMapper edm = new StaffLeaveRoasterDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Arrears))
            {
                ArrearsDataMapper edm = new ArrearsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper edm = new MedicalClaimsItemsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LeaveType))
            {
                LeaveTypeDataMapper edm = new LeaveTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveEntitlement))
            {
                AnnualLeaveEntitlementMapper edm = new AnnualLeaveEntitlementMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel1))
            {
                UserAccessLevel1DataMapper edm = new UserAccessLevel1DataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel2))
            {
                UserAccessLevel2DataMapper edm = new UserAccessLevel2DataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel3))
            {
                UserAccessLevel3DataMapper edm = new UserAccessLevel3DataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel4))
            {
                UserAccessLevel4DataMapper edm = new UserAccessLevel4DataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategoryRole))
            {
                UserCategoryRoleDataMapper edm = new UserCategoryRoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserRole))
            {
                UserRoleDataMapper edm = new UserRoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PromotionType))
            {
                PromotionTypeDataMapper edm = new PromotionTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SeparationType))
            {
                SeparationTypeDataMapper edm = new SeparationTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Language))
            {
                LanguageDataMapper edm = new LanguageDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DisabilityType))
            {
                DisabilityTypeDataMapper edm = new DisabilityTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LicenceType))
            {
                LicenceTypeDataMapper edm = new LicenceTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Department))
            {
                DepartmentsDataMapper edm = new DepartmentsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AppointmentType))
            {
                AppointmentTypeDataMapper edm = new AppointmentTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatus))
            {
                StaffStatusDataMapper edm = new StaffStatusDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PhoneNumberType))
            {
                PhoneNumberTypeDataMapper edm = new PhoneNumberTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ScheduleMessage))
            {
                ScheduleMessageDataMapper edm = new ScheduleMessageDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OccupationGroup))
            {
                OccupationalGroupingDataMapper edm = new OccupationalGroupingDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveCalculation))
            {
                AnnualLeaveCalculationsDataMapper edm = new AnnualLeaveCalculationsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Increment))
            {
                IncrementDataMapper edm = new IncrementDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Loan))
            {
                LoansDataMapper edm = new LoansDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(QualificationType))
            {
                QualificationTypeDataMapper edm = new QualificationTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SanctionType))
            {
                SanctionTypeDataMapper edm = new SanctionTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Sanction))
            {
                SanctionDataMapper edm = new SanctionDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Promotion))
            {
                PromotionDataMapper edm = new PromotionDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Confirmation))
            {
                ConfirmationDataMapper edm = new ConfirmationDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceCategory))
            {
                AllowanceCategoryDataMapper edm = new AllowanceCategoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLoanPayment))
            {
                StaffLoanPaymentDataMapper edm = new StaffLoanPaymentDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SalaryType))
            {
                SalaryTypesDataMapper edm = new SalaryTypesDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionCategory))
            {
                DeductionCategoryDataMapper edm = new DeductionCategoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionSubCategory))
            {
                DeductionSubCategoryDataMapper edm = new DeductionSubCategoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Deduction))
            {
                DeductionDataMapper edm = new DeductionDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Allowance))
            {
                AllowanceDataMapper edm = new AllowanceDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Transfer))
            {
                TransferDataMapper edm = new TransferDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(InternshipType))
            {
                InternshipTypeDataMapper edm = new InternshipTypeDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Internship))
            {
                InternshipDataMapper edm = new InternshipDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(FileNumber))
            {
                FileDataMapper edm = new FileDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Religion))
            {
                ReligionDataMapper edm = new ReligionDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Specialty))
            {
                SpecialtyDataMapper edm = new SpecialtyDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Unit))
            {
                UnitDataMapper edm = new UnitDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Denomination))
            {
                DenominationDataMapper edm = new DenominationDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Relationship))
            {
                RelationshipDataMapper edm = new RelationshipDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Bank))
            {
                BankDataMapper edm = new BankDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(BankBranch))
            {
                BankBranchDataMapper edm = new BankBranchDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(JobTitle))
            {
                JobTitleDataMapper edm = new JobTitleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            else if (item.GetType() == typeof(User))
            {
                UserDataMapper edm = new UserDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategory))
            {
                UserCategoryDataMapper edm = new UserCategoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(EmployeeBank))
            {
                EmployeeBanksDataMapper edm = new EmployeeBanksDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffSalaryHistory))
            {
                StaffSalaryHistoryDataMapper edm = new StaffSalaryHistoryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDeduction))
            {
                StaffDeductionsDataMapper edm = new StaffDeductionsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAllowance))
            {
                StaffAllowanceDataMapper edm = new StaffAllowanceDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLoan))
            {
                StaffLoanDataMapper edm = new StaffLoanDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PayRollAttendance))
            {
                PayRollAttendanceDataMapper edm = new PayRollAttendanceDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PayRoll))
            {
                PayRollDataMapper edm = new PayRollDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper edm = new MedicalClaimsDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Termination))
            {
                TerminationDataMapper edm = new TerminationDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Leave))
            {
                LeaveDataMapper edm = new LeaveDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Attendance))
            {
                AttendanceDataMapper edm = new AttendanceDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Vacancy))
            {
                VacancyDataMapper edm = new VacancyDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Applicant))
            {
                ApplicantDataMapper edm = new ApplicantDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Holiday))
            {
                HolidaysDataMapper edm = new HolidaysDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserRole))
            {
                UserRoleDataMapper edm = new UserRoleDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceAndDeductionSummary))
            {
                AllowanceAndDeductionSummaryDataMapper edm = new AllowanceAndDeductionSummaryDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffBank))
            {
                StaffBankDataMapper edm = new StaffBankDataMapper();
                try
                {
                    edm.Save(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The type is not known for saving");
            }
        }
        #endregion

        #region Update
        public void Update(object item)
        {
            if (item.GetType() == typeof(Company))
            {
                CompanyDataMapper edm = new CompanyDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceSubCategory))
            {
                AllowanceSubCategoryDataMapper edm = new AllowanceSubCategoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper edm = new ChartOfAccountGenerationDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper edm = new ChartOfAccountMappingDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountType))
            {
                ChartOfAccountTypeDataMapper edm = new ChartOfAccountTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTimeType))
            {
                OverTimeTypeDataMapper edm = new OverTimeTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTime))
            {
                OverTimeDataMapper edm = new OverTimeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper edm = new StaffDOBChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper edm = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper edm = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper edm = new StaffNameChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper edm = new StaffStatusChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper edm = new StaffJobTitleChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper edm = new StaffGradeChangeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Controls))
            {
                ControlDataMapper edm = new ControlDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ControlToRole))
            {
                ControlToRoleDataMapper edm = new ControlToRoleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserToRole))
            {
                UserToRoleDataMapper edm = new UserToRoleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Role))
            {
                RoleDataMapper edm = new RoleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLeaveRoaster))
            {
                StaffLeaveRoasterDataMapper edm = new StaffLeaveRoasterDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Arrears))
            {
                ArrearsDataMapper edm = new ArrearsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper edm = new MedicalClaimsItemsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LeaveType))
            {
                LeaveTypeDataMapper edm = new LeaveTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveEntitlement))
            {
                AnnualLeaveEntitlementMapper edm = new AnnualLeaveEntitlementMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel1))
            {
                UserAccessLevel1DataMapper edm = new UserAccessLevel1DataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel2))
            {
                UserAccessLevel2DataMapper edm = new UserAccessLevel2DataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel3))
            {
                UserAccessLevel3DataMapper edm = new UserAccessLevel3DataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel4))
            {
                UserAccessLevel4DataMapper edm = new UserAccessLevel4DataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategoryRole))
            {
                UserCategoryRoleDataMapper edm = new UserCategoryRoleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserRole))
            {
                UserRoleDataMapper edm = new UserRoleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PayRollAttendance))
            {
                PayRollAttendanceDataMapper edm = new PayRollAttendanceDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PromotionType))
            {
                PromotionTypeDataMapper edm = new PromotionTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SeparationType))
            {
                SeparationTypeDataMapper edm = new SeparationTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Language))
            {
                LanguageDataMapper edm = new LanguageDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DisabilityType))
            {
                DisabilityTypeDataMapper edm = new DisabilityTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LicenceType))
            {
                LicenceTypeDataMapper edm = new LicenceTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Department))
            {
                DepartmentsDataMapper edm = new DepartmentsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AppointmentType))
            {
                AppointmentTypeDataMapper edm = new AppointmentTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatus))
            {
                StaffStatusDataMapper edm = new StaffStatusDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PhoneNumberType))
            {
                PhoneNumberTypeDataMapper edm = new PhoneNumberTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ScheduleMessage))
            {
                ScheduleMessageDataMapper edm = new ScheduleMessageDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OccupationGroup))
            {
                OccupationalGroupingDataMapper edm = new OccupationalGroupingDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveCalculation))
            {
                AnnualLeaveCalculationsDataMapper edm = new AnnualLeaveCalculationsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Increment))
            {
                IncrementDataMapper edm = new IncrementDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Loan))
            {
                LoansDataMapper edm = new LoansDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(QualificationType))
            {
                QualificationTypeDataMapper edm = new QualificationTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SanctionType))
            {
                SanctionTypeDataMapper edm = new SanctionTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Sanction))
            {
                SanctionDataMapper edm = new SanctionDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Promotion))
            {
                PromotionDataMapper edm = new PromotionDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Confirmation))
            {
                ConfirmationDataMapper edm = new ConfirmationDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceCategory))
            {
                AllowanceCategoryDataMapper edm = new AllowanceCategoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLoanPayment))
            {
                StaffLoanPaymentDataMapper edm = new StaffLoanPaymentDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SalaryType))
            {
                SalaryTypesDataMapper edm = new SalaryTypesDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionCategory))
            {
                DeductionCategoryDataMapper edm = new DeductionCategoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionSubCategory))
            {
                DeductionSubCategoryDataMapper edm = new DeductionSubCategoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Deduction))
            {
                DeductionDataMapper edm = new DeductionDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Allowance))
            {
                AllowanceDataMapper edm = new AllowanceDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Transfer))
            {
                TransferDataMapper edm = new TransferDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(InternshipType))
            {
                InternshipTypeDataMapper edm = new InternshipTypeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Internship))
            {
                InternshipDataMapper edm = new InternshipDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(FileNumber))
            {
                FileDataMapper edm = new FileDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Religion))
            {
                ReligionDataMapper edm = new ReligionDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Specialty))
            {
                SpecialtyDataMapper edm = new SpecialtyDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Unit))
            {
                UnitDataMapper edm = new UnitDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Denomination))
            {
                DenominationDataMapper edm = new DenominationDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(EmployeeBank))
            {
                EmployeeBanksDataMapper edm = new EmployeeBanksDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Bank))
            {
                BankDataMapper edm = new BankDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(BankBranch))
            {
                BankBranchDataMapper edm = new BankBranchDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(JobTitle))
            {
                JobTitleDataMapper edm = new JobTitleDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDeduction))
            {
                StaffDeductionsDataMapper edm = new StaffDeductionsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffSalaryHistory))
            {
                StaffSalaryHistoryDataMapper edm = new StaffSalaryHistoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategory))
            {
                UserCategoryDataMapper edm = new UserCategoryDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAllowance))
            {
                StaffAllowanceDataMapper edm = new StaffAllowanceDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Employee))
            {
                EmployeeDataMapper edm = new EmployeeDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLoan))
            {
                StaffLoanDataMapper edm = new StaffLoanDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PayRoll))
            {
                PayRollDataMapper edm = new PayRollDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper edm = new MedicalClaimsDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Termination))
            {
                TerminationDataMapper edm = new TerminationDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Leave))
            {
                LeaveDataMapper edm = new LeaveDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Attendance))
            {
                AttendanceDataMapper edm = new AttendanceDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Vacancy))
            {
                VacancyDataMapper edm = new VacancyDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Applicant))
            {
                ApplicantDataMapper edm = new ApplicantDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Holiday))
            {
                HolidaysDataMapper edm = new HolidaysDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(User))
            {
                UserDataMapper edm = new UserDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffBank))
            {
                StaffBankDataMapper edm = new StaffBankDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Relationship))
            {
                RelationshipDataMapper edm = new RelationshipDataMapper();
                try
                {
                    edm.Update(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The type is not known for update");
            }
        }
        #endregion

        #region Delete
        public void Delete(object item)
        {
            if (item.GetType() == typeof(User))
            {
                UserDataMapper edm = new UserDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceSubCategory))
            {
                AllowanceSubCategoryDataMapper edm = new AllowanceSubCategoryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper edm = new ChartOfAccountGenerationDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper edm = new ChartOfAccountMappingDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ChartOfAccountType))
            {
                ChartOfAccountTypeDataMapper edm = new ChartOfAccountTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTimeType))
            {
                OverTimeTypeDataMapper edm = new OverTimeTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OverTime))
            {
                OverTimeDataMapper edm = new OverTimeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper edm = new StaffDOBChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper edm = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper edm = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper edm = new StaffNameChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper edm = new StaffStatusChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper edm = new StaffJobTitleChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper edm = new StaffGradeChangeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Controls))
            {
                ControlDataMapper edm = new ControlDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ControlToRole))
            {
                ControlToRoleDataMapper edm = new ControlToRoleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserToRole))
            {
                UserToRoleDataMapper edm = new UserToRoleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Role))
            {
                RoleDataMapper edm = new RoleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLeaveRoaster))
            {
                StaffLeaveRoasterDataMapper edm = new StaffLeaveRoasterDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Arrears))
            {
                ArrearsDataMapper edm = new ArrearsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper edm = new MedicalClaimsItemsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LeaveType))
            {
                LeaveTypeDataMapper edm = new LeaveTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveEntitlement))
            {
                AnnualLeaveEntitlementMapper edm = new AnnualLeaveEntitlementMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PromotionType))
            {
                PromotionTypeDataMapper edm = new PromotionTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SeparationType))
            {
                SeparationTypeDataMapper edm = new SeparationTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Language))
            {
                LanguageDataMapper edm = new LanguageDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DisabilityType))
            {
                DisabilityTypeDataMapper edm = new DisabilityTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(LicenceType))
            {
                LicenceTypeDataMapper edm = new LicenceTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Department))
            {
                DepartmentsDataMapper edm = new DepartmentsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AppointmentType))
            {
                AppointmentTypeDataMapper edm = new AppointmentTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffStatus))
            {
                StaffStatusDataMapper edm = new StaffStatusDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PhoneNumberType))
            {
                PhoneNumberTypeDataMapper edm = new PhoneNumberTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(ScheduleMessage))
            {
                ScheduleMessageDataMapper edm = new ScheduleMessageDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(OccupationGroup))
            {
                OccupationalGroupingDataMapper edm = new OccupationalGroupingDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AnnualLeaveCalculation))
            {
                AnnualLeaveCalculationsDataMapper edm = new AnnualLeaveCalculationsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Increment))
            {
                IncrementDataMapper edm = new IncrementDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Loan))
            {
                LoansDataMapper edm = new LoansDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(QualificationType))
            {
                QualificationTypeDataMapper edm = new QualificationTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SanctionType))
            {
                SanctionTypeDataMapper edm = new SanctionTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Sanction))
            {
                SanctionDataMapper edm = new SanctionDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Promotion))
            {
                PromotionDataMapper edm = new PromotionDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Confirmation))
            {
                ConfirmationDataMapper edm = new ConfirmationDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceCategory))
            {
                AllowanceCategoryDataMapper edm = new AllowanceCategoryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffLoanPayment))
            {
                StaffLoanPaymentDataMapper edm = new StaffLoanPaymentDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(SalaryType))
            {
                SalaryTypesDataMapper edm = new SalaryTypesDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionCategory))
            {
                DeductionCategoryDataMapper edm = new DeductionCategoryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(DeductionSubCategory))
            {
                DeductionSubCategoryDataMapper edm = new DeductionSubCategoryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Deduction))
            {
                DeductionDataMapper edm = new DeductionDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Allowance))
            {
                AllowanceDataMapper edm = new AllowanceDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffAllowance))
            {
                StaffAllowanceDataMapper edm = new StaffAllowanceDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffDeduction))
            {
                StaffDeductionsDataMapper edm = new StaffDeductionsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Transfer))
            {
                TransferDataMapper edm = new TransferDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(InternshipType))
            {
                InternshipTypeDataMapper edm = new InternshipTypeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Internship))
            {
                InternshipDataMapper edm = new InternshipDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(FileNumber))
            {
                FileDataMapper edm = new FileDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Religion))
            {
                ReligionDataMapper edm = new ReligionDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Specialty))
            {
                SpecialtyDataMapper edm = new SpecialtyDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Unit))
            {
                UnitDataMapper edm = new UnitDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Denomination))
            {
                DenominationDataMapper edm = new DenominationDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserRole))
            {
                UserRoleDataMapper edm = new UserRoleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategoryRole))
            {
                UserCategoryRoleDataMapper edm = new UserCategoryRoleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserCategory)) 
            {
                UserCategoryDataMapper edm = new UserCategoryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel1))
            {
                UserAccessLevel1DataMapper edm = new UserAccessLevel1DataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel2))
            {
                UserAccessLevel2DataMapper edm = new UserAccessLevel2DataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel3))
            {
                UserAccessLevel3DataMapper edm = new UserAccessLevel3DataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(UserAccessLevel4))
            {
                UserAccessLevel4DataMapper edm = new UserAccessLevel4DataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Employee))
            {
                EmployeeDataMapper edm = new EmployeeDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }           
            else if (item.GetType() == typeof(StaffLoan))
            {
                StaffLoanDataMapper edm = new StaffLoanDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(PayRollAttendance))
            {
                PayRollAttendanceDataMapper edm = new PayRollAttendanceDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper  edm = new MedicalClaimsDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Termination))
            {
                TerminationDataMapper edm = new TerminationDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Leave))
            {
                LeaveDataMapper edm = new LeaveDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Attendance))
            {
                AttendanceDataMapper edm = new AttendanceDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Vacancy))
            {
                VacancyDataMapper edm = new VacancyDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Applicant))
            {
                ApplicantDataMapper edm = new ApplicantDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Holiday))
            {
                HolidaysDataMapper edm = new HolidaysDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(AllowanceAndDeductionSummary))
            {
                AllowanceAndDeductionSummaryDataMapper edm = new AllowanceAndDeductionSummaryDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(StaffBank))
            {
                StaffBankDataMapper edm = new StaffBankDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Bank))
            {
                BankDataMapper edm = new BankDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(BankBranch))
            {
                BankBranchDataMapper edm = new BankBranchDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(JobTitle))
            {
                JobTitleDataMapper edm = new JobTitleDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Relationship))
            {
                RelationshipDataMapper edm = new RelationshipDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (item.GetType() == typeof(Allowance))
            {
                AllowanceDataMapper edm = new AllowanceDataMapper();
                try
                {
                    edm.Delete(item);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The specified reference type is not known for delete");
            }
        }
        #endregion

        #region GetByCriteria
        public IList<T> GetByCriteria<T>(Query query) where T : class
        {
            if (typeof(T) == typeof(UserRole))
            {
                UserRoleDataMapper mapper = new UserRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AllowanceSubCategory))
            {
                AllowanceSubCategoryDataMapper mapper = new AllowanceSubCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper mapper = new ChartOfAccountGenerationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper mapper = new ChartOfAccountMappingDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountType))
            {
                ChartOfAccountTypeDataMapper mapper = new ChartOfAccountTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OverTimeType))
            {
                OverTimeTypeDataMapper mapper = new OverTimeTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OverTime))
            {
                OverTimeDataMapper mapper = new OverTimeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper mapper = new StaffDOBChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper mapper = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper mapper = new StaffStatusChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper mapper = new StaffNameChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper mapper = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            else if (typeof(T) == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper mapper = new StaffJobTitleChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper mapper = new StaffGradeChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Controls))
            {
                ControlDataMapper mapper = new ControlDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ControlToRole))
            {
                ControlToRoleDataMapper mapper = new ControlToRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Applicant))
            {
                ApplicantDataMapper mapper = new ApplicantDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserToRole))
            {
                UserToRoleDataMapper mapper = new UserToRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Role))
            {
                RoleDataMapper mapper = new RoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLeaveRoaster))
            {
                StaffLeaveRoasterDataMapper mapper = new StaffLeaveRoasterDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Leave))
            {
                LeaveDataMapper mapper = new LeaveDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Arrears))
            {
                ArrearsDataMapper mapper = new ArrearsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper mapper = new MedicalClaimsItemsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(LeaveType))
            {
                LeaveTypeDataMapper mapper = new LeaveTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AnnualLeaveEntitlement))
            {
                AnnualLeaveEntitlementMapper mapper = new AnnualLeaveEntitlementMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserCategoryRole))
            {
                UserCategoryRoleDataMapper mapper = new UserCategoryRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel1))
            {
                UserAccessLevel1DataMapper mapper = new UserAccessLevel1DataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel2))
            {
                UserAccessLevel2DataMapper mapper = new UserAccessLevel2DataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel3))
            {
                UserAccessLevel3DataMapper mapper = new UserAccessLevel3DataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel4))
            {
                UserAccessLevel4DataMapper mapper = new UserAccessLevel4DataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PromotionType))
            {
                PromotionTypeDataMapper mapper = new PromotionTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Termination))
            {
                TerminationDataMapper mapper = new TerminationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SeparationType))
            {
                SeparationTypeDataMapper mapper = new SeparationTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Occupation))
            {
                OccupationsDataMapper mapper = new OccupationsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Language))
            {
                LanguageDataMapper mapper = new LanguageDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DisabilityType))
            {
                DisabilityTypeDataMapper mapper = new DisabilityTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(LicenceType))
            {
                LicenceTypeDataMapper mapper = new LicenceTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AppointmentType))
            {
                AppointmentTypeDataMapper mapper = new AppointmentTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffStatus))
            {
                StaffStatusDataMapper mapper = new StaffStatusDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PhoneNumberType))
            {
                PhoneNumberTypeDataMapper mapper = new PhoneNumberTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OccupationGroup))
            {
                OccupationalGroupingDataMapper mapper = new OccupationalGroupingDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AnnualLeaveCalculation))
            {
                AnnualLeaveCalculationsDataMapper mapper = new AnnualLeaveCalculationsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Increment))
            {
                IncrementDataMapper mapper = new IncrementDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Loan))
            {
                LoansDataMapper mapper = new LoansDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(QualificationType))
            {
                QualificationTypeDataMapper mapper = new QualificationTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SanctionType))
            {
                SanctionTypeDataMapper mapper = new SanctionTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Sanction))
            {
                SanctionDataMapper mapper = new SanctionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Promotion))
            {
                PromotionDataMapper mapper = new PromotionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Confirmation))
            {
                ConfirmationDataMapper mapper = new ConfirmationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper mapper = new MedicalClaimsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AllowanceCategory))
            {
                AllowanceCategoryDataMapper mapper = new AllowanceCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLoan))
            {
                StaffLoanDataMapper mapper = new StaffLoanDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLoanPayment))
            {
                StaffLoanPaymentDataMapper mapper = new StaffLoanPaymentDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Department))
            {
                DepartmentsDataMapper mapper = new DepartmentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffSalaryHistory))
            {
                StaffSalaryHistoryDataMapper mapper = new StaffSalaryHistoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SalaryType))
            {
                SalaryTypesDataMapper mapper = new SalaryTypesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DeductionSubCategory))
            {
                DeductionSubCategoryDataMapper mapper = new DeductionSubCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DeductionCategory))
            {
                DeductionCategoryDataMapper mapper = new DeductionCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Deduction))
            {
                DeductionDataMapper mapper = new DeductionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Allowance))
            {
                AllowanceDataMapper mapper = new AllowanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffAllowance))
            {
                StaffAllowanceDataMapper mapper = new StaffAllowanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Deduction))
            {
                DeductionDataMapper mapper = new DeductionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDeduction))
            {
                StaffDeductionsDataMapper mapper = new StaffDeductionsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Relation))
            {
                DependentsDataMapper mapper = new DependentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Profession))
            {
                ProfessionDataMapper mapper = new ProfessionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Qualification))
            {
                QualificationDataMapper mapper = new QualificationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Referee))
            {
                RefereesDataMapper mapper = new RefereesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDocument))
            {
                StaffDocumentsDataMapper mapper = new StaffDocumentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLanguage))
            {
                StaffLanguagesDataMapper mapper = new StaffLanguagesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(WorkExperience))
            {
                WorkExperienceDataMapper mapper = new WorkExperienceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Transfer))
            {
                TransferDataMapper mapper = new TransferDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(InternshipType))
            {
                InternshipTypeDataMapper mapper = new InternshipTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Internship))
            {
                InternshipDataMapper mapper = new InternshipDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(GradeCategory))
            {
                EmployeeGradeCategoryDataMapper mapper = new EmployeeGradeCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(EmployeeGrade))
            {
                EmployeeGradeDataMapper mapper = new EmployeeGradeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(FileNumber))
            {
                FileDataMapper mapper = new FileDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Religion))
            {
                ReligionDataMapper mapper = new ReligionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Specialty))
            {
                SpecialtyDataMapper mapper = new SpecialtyDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Unit))
            {
                UnitDataMapper mapper = new UnitDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Denomination))
            {
                DenominationDataMapper mapper = new DenominationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Relationship))
            {
                RelationshipDataMapper mapper = new RelationshipDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PayRollAttendance))
            {
                PayRollAttendanceDataMapper mapper = new PayRollAttendanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PayRoll))
            {
                PayRollDataMapper mapper = new PayRollDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(User))
            {
                UserDataMapper mapper = new UserDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(District))
            {
                DistrictDataMapper mapper = new DistrictDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Zone))
            {
                ZoneDataMapper mapper = new ZoneDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Town))
            {
                TownsDataMapper mapper = new TownsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Bank))
            {
                BankDataMapper mapper = new BankDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(BankBranch))
            {
                BankBranchDataMapper mapper = new BankBranchDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(JobTitle))
            {
                JobTitleDataMapper mapper = new JobTitleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AccountType))
            {
                AccountTypeDataMapper mapper = new AccountTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Step))
            {
                StepDataMapper mapper = new StepDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(TaxableIncome))
            {
                TaxableIncomeDataMapper mapper = new TaxableIncomeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffBank))
            {
                StaffBankDataMapper mapper = new StaffBankDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The type is not known for getCriterior");
            }
        }
        #endregion

        #region Get All
        public IList<T> GetAll<T>() where T : class 
        {
            if (typeof(T) == typeof(Relationship))
            {
                RelationshipDataMapper mapper = new RelationshipDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AllowanceSubCategory))
            {
                AllowanceSubCategoryDataMapper mapper = new AllowanceSubCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper mapper = new ChartOfAccountGenerationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper mapper = new ChartOfAccountMappingDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OverTimeType))
            {
                OverTimeTypeDataMapper mapper = new OverTimeTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OverTime))
            {
                OverTimeDataMapper mapper = new OverTimeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper mapper = new StaffDOBChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper mapper = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper mapper = new StaffStatusChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper mapper = new StaffNameChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper mapper = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper mapper = new StaffJobTitleChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper mapper = new StaffGradeChangeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Controls))
            {
                ControlDataMapper mapper = new ControlDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Controls))
            {
                ControlDataMapper mapper = new ControlDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ControlToRole))
            {
                ControlToRoleDataMapper mapper = new ControlToRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserToRole))
            {
                UserToRoleDataMapper mapper = new UserToRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Role))
            {
                RoleDataMapper mapper = new RoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLeaveRoaster))
            {
                StaffLeaveRoasterDataMapper mapper = new StaffLeaveRoasterDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Arrears))
            {
                ArrearsDataMapper mapper = new ArrearsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper mapper = new MedicalClaimsItemsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(LeaveType))
            {
                LeaveTypeDataMapper mapper = new LeaveTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AnnualLeaveEntitlement))
            {
                AnnualLeaveEntitlementMapper mapper = new AnnualLeaveEntitlementMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PromotionType))
            {
                PromotionTypeDataMapper mapper = new PromotionTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SeparationType))
            {
                SeparationTypeDataMapper mapper = new SeparationTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Language))
            {
                LanguageDataMapper mapper = new LanguageDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DisabilityType))
            {
                DisabilityTypeDataMapper mapper = new DisabilityTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(LicenceType))
            {
                LicenceTypeDataMapper mapper = new LicenceTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AppointmentType))
            {
                AppointmentTypeDataMapper mapper = new AppointmentTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffStatus))
            {
                StaffStatusDataMapper mapper = new StaffStatusDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ScheduleMessage))
            {
                ScheduleMessageDataMapper mapper = new ScheduleMessageDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AnnualLeaveCalculation))
            {
                AnnualLeaveCalculationsDataMapper mapper = new AnnualLeaveCalculationsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Increment))
            {
                IncrementDataMapper mapper = new IncrementDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Loan))
            {
                LoansDataMapper mapper = new LoansDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(QualificationType))
            {
                QualificationTypeDataMapper mapper = new QualificationTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SanctionType))
            {
                SanctionTypeDataMapper mapper = new SanctionTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Sanction))
            {
                SanctionDataMapper mapper = new SanctionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Promotion))
            {
                PromotionDataMapper mapper = new PromotionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Confirmation))
            {
                ConfirmationDataMapper mapper = new ConfirmationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLoanPayment))
            {
                StaffLoanPaymentDataMapper mapper = new StaffLoanPaymentDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SalaryType))
            {
                SalaryTypesDataMapper mapper = new SalaryTypesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DeductionSubCategory))
            {
                DeductionSubCategoryDataMapper mapper = new DeductionSubCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(DeductionCategory))
            {
                DeductionCategoryDataMapper mapper = new DeductionCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Deduction))
            {
                DeductionDataMapper mapper = new DeductionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AllowanceCategory))
            {
                AllowanceCategoryDataMapper mapper = new AllowanceCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Transfer))
            {
                TransferDataMapper mapper = new TransferDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(InternshipType))
            {
                InternshipTypeDataMapper mapper = new InternshipTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Internship))
            {
                InternshipDataMapper mapper = new InternshipDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(FileNumber))
            {
                FileDataMapper mapper = new FileDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Religion))
            {
                ReligionDataMapper mapper = new ReligionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Specialty))
            {
                SpecialtyDataMapper mapper = new SpecialtyDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Unit))
            {
                UnitDataMapper mapper = new UnitDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Denomination))
            {
                DenominationDataMapper mapper = new DenominationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Zone))
            {
                ZoneDataMapper mapper = new ZoneDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Profession))
            {
                ProfessionDataMapper mapper = new ProfessionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(HealthFacilityOwnership))
            {
                HealthFacilityOwnershipDataMapper mapper = new HealthFacilityOwnershipDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(HealthFacilityType))
            {
                HealthFacilityTypeDataMapper mapper = new HealthFacilityTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Qualification))
            {
                QualificationDataMapper mapper = new QualificationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Referee))
            {
                RefereesDataMapper mapper = new RefereesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDocument))
            {
                StaffDocumentsDataMapper mapper = new StaffDocumentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(WorkExperience))
            {
                WorkExperienceDataMapper mapper = new WorkExperienceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Town))
            {
                TownsDataMapper mapper = new TownsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLanguage))
            {
                StaffLanguagesDataMapper mapper = new StaffLanguagesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Titles))
            {
                TitlesDataMapper mapper = new TitlesDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Occupation))
            {
                OccupationsDataMapper mapper = new OccupationsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(GradeCategory))
            {
                EmployeeGradeCategoryDataMapper mapper = new EmployeeGradeCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Company))
            {
                CompanyDataMapper mapper = new CompanyDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Relation))
            {
                DependentsDataMapper mapper = new DependentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserCategory))
            {
                UserCategoryDataMapper mapper = new UserCategoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel1))
            {
                UserAccessLevel1DataMapper mapper = new UserAccessLevel1DataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel2))
            {
                UserAccessLevel2DataMapper mapper = new UserAccessLevel2DataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel3))
            {
                UserAccessLevel3DataMapper mapper = new UserAccessLevel3DataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserAccessLevel4))
            {
                UserAccessLevel4DataMapper mapper = new UserAccessLevel4DataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserCategoryRole))
            {
                UserCategoryRoleDataMapper mapper = new UserCategoryRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(UserRole))
            {
                UserRoleDataMapper mapper = new UserRoleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if(typeof(T) == typeof(EmployeeGrade))
            {
                EmployeeGradeDataMapper mapper = new EmployeeGradeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Allowance))
            {
                AllowanceDataMapper  mapper = new AllowanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Deduction))
            {
                DeductionDataMapper mapper = new DeductionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Department))
            {
                DepartmentsDataMapper  mapper = new DepartmentsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLoan))
            {
                StaffLoanDataMapper mapper = new StaffLoanDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PayRollAttendance))
            {
                PayRollAttendanceDataMapper mapper = new PayRollAttendanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            else if (typeof(T) == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper mapper = new MedicalClaimsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Termination))
            {
                TerminationDataMapper mapper = new TerminationDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Leave))
            {
                LeaveDataMapper mapper = new LeaveDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Attendance))
            {
                AttendanceDataMapper mapper = new AttendanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Vacancy))
            {
                VacancyDataMapper mapper = new VacancyDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            else if (typeof(T) == typeof(Holiday))
            {
                HolidaysDataMapper mapper = new HolidaysDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Applicant))
            {
                ApplicantDataMapper mapper = new ApplicantDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(SSNITContribution))
            {
                SSNITContributionDataMapper mapper = new SSNITContributionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(TaxableIncome))
            {
                TaxableIncomeDataMapper mapper = new TaxableIncomeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(User))
            {
                UserDataMapper mapper = new UserDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffAllowance))
            {
                StaffAllowanceDataMapper mapper = new StaffAllowanceDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDeduction))
            {
                StaffDeductionsDataMapper mapper = new StaffDeductionsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffTraining))
            {
                StaffTrainingDataMapper mapper = new StaffTrainingDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffSalaryHistory))
            {
                StaffSalaryHistoryDataMapper mapper = new StaffSalaryHistoryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Loan))
            {
                LoansDataMapper mapper = new LoansDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Band))
            {
                BandsDataMapper mapper = new BandsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Level))
            {
                LevelsDataMapper mapper = new LevelsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Step))
            {
                StepDataMapper mapper = new StepDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(District))
            {
                DistrictDataMapper mapper = new DistrictDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Country))
            {
                CountryDataMapper mapper = new CountryDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Region))
            {
                RegionDataMapper mapper = new RegionDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Bank))
            {
                BankDataMapper mapper = new BankDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(BankBranch))
            {
                BankBranchDataMapper mapper = new BankBranchDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(JobTitle))
            {
                JobTitleDataMapper mapper = new JobTitleDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(AccountType))
            {
                AccountTypeDataMapper mapper = new AccountTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(OccupationGroup))
            {
                OccupationalGroupingDataMapper mapper = new OccupationalGroupingDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffEmail))
            {
                EmailsDataMapper mapper = new EmailsDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountType))
            {
                ChartOfAccountTypeDataMapper mapper = new ChartOfAccountTypeDataMapper();
                try
                {
                    return (IList<T>)mapper.GetAll();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The specified reference type is not known for getAll");
            }
        }
        #endregion

        #region LazyLoad
        public IList<T> LazyLoad<T>() where T : class 
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoad();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Company))
            {
                CompanyDataMapper mapper = new CompanyDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoad();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Transfer))
            {
                TransferDataMapper mapper = new TransferDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoad();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Applicant))
            {
                ApplicantDataMapper mapper = new ApplicantDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoad();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Internship))
            {
                InternshipDataMapper mapper = new InternshipDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoad();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region LazyLoadByStaffID
        public T LazyLoadByStaffID<T>(object key) where T : class
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Leave))
            {
                LeaveDataMapper mapper = new LeaveDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Arrears))
            {
                ArrearsDataMapper mapper = new ArrearsDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper mapper = new MedicalClaimsDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Promotion))
            {
                PromotionDataMapper mapper = new PromotionDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region LazyLoadUnconfirmedByStaffID
        public T LazyLoadUnconfirmedByStaffID<T>(object key) where T : class
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    T item = (T)(object)mapper.LazyLoadUnconfirmedByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

        #region ShowImageByStaffID
        public T ShowImageByStaffID<T>(object key) where T : class
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    T item = (T)(object)mapper.ShowImageByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Internship))
            {
                InternshipDataMapper mapper = new InternshipDataMapper();
                try
                {
                    T item = (T)(object)mapper.ShowImageByStaffID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("ShowImageByStaffID Not Found");
            }
        }
        #endregion

        #region ShowImage
        public T ShowImage<T>() where T : class
        {
            if (typeof(T) == typeof(Company))
            {
                CompanyDataMapper mapper = new CompanyDataMapper();
                try
                {
                    T item = (T)(object)mapper.ShowImage();
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region LazyLoadCriteria
        public IList<T> LazyLoadCriteria<T>(Query query) where T : class
        { 
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    return (IList<T>)mapper.LazyLoadCriteria(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("The The Method LazyLoadCriterior is not Known");
            }
        }
        #endregion

        #region Get By ID
        public T GetByID<T>(object key) where T : class
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountGeneration))
            {
                ChartOfAccountGenerationDataMapper mapper = new ChartOfAccountGenerationDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(ChartOfAccountMapping))
            {
                ChartOfAccountMappingDataMapper mapper = new ChartOfAccountMappingDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDOBChange))
            {
                StaffDOBChangeDataMapper mapper = new StaffDOBChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffEmploymentDateChange))
            {
                StaffEmploymentDateChangeDataMapper mapper = new StaffEmploymentDateChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffStatusChange))
            {
                StaffStatusChangeDataMapper mapper = new StaffStatusChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffNameChange))
            {
                StaffNameChangeDataMapper mapper = new StaffNameChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffAppointmentTypeChange))
            {
                StaffAppointmentTypeChangeDataMapper mapper = new StaffAppointmentTypeChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffJobTitleChange))
            {
                StaffJobTitleChangeDataMapper mapper = new StaffJobTitleChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffGradeChange))
            {
                StaffGradeChangeDataMapper mapper = new StaffGradeChangeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Leave))
            {
                LeaveDataMapper mapper = new LeaveDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Arrears))
            {
                ArrearsDataMapper mapper = new ArrearsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaims))
            {
                MedicalClaimsDataMapper mapper = new MedicalClaimsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(MedicalClaimsItems))
            {
                MedicalClaimsItemsDataMapper mapper = new MedicalClaimsItemsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(LeaveType))
            {
                LeaveTypeDataMapper mapper = new LeaveTypeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Termination))
            {
                TerminationDataMapper mapper = new TerminationDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Sanction))
            {
                SanctionDataMapper mapper = new SanctionDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Promotion))
            {
                PromotionDataMapper mapper = new PromotionDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffSalaryHistory))
            {
                StaffSalaryHistoryDataMapper mapper = new StaffSalaryHistoryDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Profession))
            {
                ProfessionDataMapper mapper = new ProfessionDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(WorkExperience))
            {
                WorkExperienceDataMapper mapper = new WorkExperienceDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Qualification))
            {
                QualificationDataMapper mapper = new QualificationDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Referee))
            {
                RefereesDataMapper mapper = new RefereesDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffDocument))
            {
                StaffDocumentsDataMapper mapper = new StaffDocumentsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffLanguage))
            {
                StaffLanguagesDataMapper mapper = new StaffLanguagesDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Relation))
            {
                DependentsDataMapper mapper = new DependentsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(PayRoll))
            {
                PayRollDataMapper mapper = new PayRollDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(StaffBank))
            {
                StaffBankDataMapper mapper = new StaffBankDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region Get By Description
        public T GetByDescription<T>(object key) where T : class
        {
            if (typeof(T) == typeof(LeaveType))
            {
                LeaveTypeDataMapper mapper = new LeaveTypeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByDescription(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (typeof(T) == typeof(Department))
            {
                DepartmentsDataMapper mapper = new DepartmentsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByDescription(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region Get By Phone Number
        public T GetByPhoneNumber<T>(object key) where T : class
        {
            if (typeof(T) == typeof(Employee))
            {
                EmployeeDataMapper mapper = new EmployeeDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByPhoneNumber(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region Get By Other ID
        public T GetByOtherID<T>(object key, object key2) where T : class
        {
            if (typeof(T) == typeof(Relation))
            {
                DependentsDataMapper mapper = new DependentsDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetByID(key);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }       
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region Get By Region
        public IList<T> GetByRegion<T>(string key) where T : class
        {
            if (typeof(T) == typeof(District))
            {
                DistrictDataMapper mapper = new DistrictDataMapper();
                try
                {
                    return (IList<T>)mapper.GetByRegion(key);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region Get Salary Amount
        public T GetSalaryAmount<T>(object key1, object key2, object key3) where T : class
        {
            if (typeof(T) == typeof(SingleSpine))
            {
                SingleSpineDataMapper mapper = new SingleSpineDataMapper();
                try
                {
                    T item = (T)(object)mapper.GetSalaryAmount(key1,key2,key3);
                    return item;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
            else
                throw new ArgumentException("The specified mapper does not exist");
        }
        #endregion

        #region OpenConnection
        public void OpenConnection()
        {
            try
            {
                dalHelper.OpenConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region CloseConnection
        public void CloseConnection()
        {
            try
            {
                dalHelper.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
