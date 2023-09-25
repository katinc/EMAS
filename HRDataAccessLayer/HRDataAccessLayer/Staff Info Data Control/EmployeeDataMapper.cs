using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Collections;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using HRDataAccessLayer.System_Setup_Data_Control;

namespace HRDataAccessLayer.Staff_Info_Data_Control
{
    public class EmployeeDataMapper 
    {
        private DALHelper dal;
        private IDAL idal;
        private IList<StaffBank> staffBanks;
        private DepartmentsDataMapper departmentDataMapper;
        
        public EmployeeDataMapper()
        {
            try
            {
                this.dal = new DALHelper();
                this.idal = new DAL();
                this.staffBanks = new List<StaffBank>();
                this.departmentDataMapper = new DepartmentsDataMapper();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
       
        #region Save
        public void Save(object item)
        {
            Employee employee = (Employee)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                dal.CreateParameter("@Surname", employee.Surname, DbType.String);
                dal.CreateParameter("@Firstname", employee.FirstName, DbType.String);
                dal.CreateParameter("@OtherName", employee.OtherName, DbType.String);
                dal.CreateParameter("@GradeID", employee.Grade.ID, DbType.Int32);
                dal.CreateParameter("@DOB", employee.DOB, DbType.DateTime);
                dal.CreateParameter("@GenderGroupID", employee.Gender, DbType.Int32);
                dal.CreateParameter("@TitleID", employee.Title.ID, DbType.Int32);
                dal.CreateParameter("@Nationality", employee.Nationality, DbType.String);
                dal.CreateParameter("@Hometown", employee.HomeTown, DbType.String);
                dal.CreateParameter("@Telno", employee.TelNo, DbType.String);
                dal.CreateParameter("@MobileNo", employee.MobileNo, DbType.String);
                dal.CreateParameter("@MaritalStatusID", employee.MaritalStatus, DbType.Int32);
                dal.CreateParameter("@Religion", employee.Religion, DbType.String);
                dal.CreateParameter("@POB", employee.POB, DbType.String);
                dal.CreateParameter("@NoOfChildren", employee.NoOfChildren, DbType.Int32);
                dal.CreateParameter("@Address", employee.Address, DbType.String);
                dal.CreateParameter("@NationalID", employee.NationalID, DbType.String);
                dal.CreateParameter("@Email", employee.Email, DbType.String);
                dal.CreateParameter("@ImagePath", employee.PhotoPath, DbType.String);
                dal.CreateParameter("@DepartmentID", employee.Department.ID, DbType.String);
                dal.CreateParameter("@EmploymentDate", employee.EmploymentDate, DbType.DateTime);
                dal.CreateParameter("@SSNIT", employee.SSNITContribution, DbType.Boolean);
                dal.CreateParameter("@IncomeTax", employee.IncomeTaxContribution, DbType.Boolean);
                dal.CreateParameter("@Probation", employee.Probation, DbType.Boolean);
                dal.CreateParameter("@VehicleNumber", employee.VehicleNumber, DbType.String);
                dal.CreateParameter("@VehicleDescription", employee.VehicleDescription, DbType.String);
                dal.CreateParameter("@VehicleType", employee.VehicleType, DbType.String);
                string columnString = string.Empty;
                string valuesString = string.Empty;
                if (employee.ProbationStartDate != null && employee.ProbationEndDate != null)
                {
                    dal.CreateParameter("@ProbationStartDate", employee.ProbationStartDate, DbType.DateTime);
                    dal.CreateParameter("@ProbationStartDate", employee.ProbationStartDate, DbType.DateTime);
                    columnString = ",ProbationStartDate,ProbationEndDate";
                    valuesString = ",@ProbationStartDate,@ProbationEndDate";
                }
                dal.CreateParameter("@SSNITNo", employee.SSNITNo, DbType.String);
                dal.CreateParameter("@FingerPrint", employee.FingerPrint, DbType.Binary);

                //Users
                dal.CreateParameter("@UserName", employee.User.UserName, DbType.String);
                dal.CreateParameter("@Password", employee.User.Password, DbType.String);
                dal.CreateParameter("@UserCategoryID", employee.User.UserCategory.ID, DbType.Int32);
                dal.CreateParameter("@EmpID", employee.ID, DbType.Int32);
                dal.CreateParameter("@Name", employee.FirstName + employee.Surname + employee.OtherName, DbType.String);
                dal.ExecuteNonQuery("Insert Into Users(UserName,Password,EmpID,Name,UserCategoryID) Values(@UserName,@Password,@EmpID,@Name,@UserCategoryID)");
                employee.User.ID = int.Parse(dal.ExecuteScalar("Select Max(ID) From Users").ToString());

                //Personal Info
                if (employee.Photo != null)
                {
                    dal.CreateParameter("@Photo", Global.ImageToArray(employee.Photo), DbType.Binary);
                    dal.ExecuteNonQuery("Insert Into StaffPersonalInfo(StaffID,Surname,Firstname,OtherName,GradeID,DOB,GenderGroupID,TitleID,Nationality,Hometown,Telno,MobileNo,MaritalStatusID,Religion,Placeofbirth,NoOfChildren,Address,NationalID,Email,Image,ImagePath, DepartmentID,EmploymentDate,SSNIT,IncomeTax,Probation,SSNITNo,FingerPrint,UserID" + columnString + ") Values(@StaffID,@Surname,@Firstname,@OtherName,@GradeID,@DOB,@GenderGroupID,@TitleID,@Nationality,@Hometown,@Telno,@MobileNo,@MaritalStatusID,@Religion,@POB,@NoOfChildren,@Address,@NationalID,@Email,@Photo,@ImagePath,@DepartmentID,@EmploymentDate,@SSNIT,@IncomeTax,@Probation,@SSNITNo,@FingerPrint"+ valuesString +","+ employee.User.ID +")");
                }
                else
                {
                    dal.ExecuteNonQuery("Insert Into StaffPersonalInfo(Surname,Firstname,OtherName,GradeID,DOB,GenderGroupID,TitleID,Nationality,Hometown,Telno,MobileNo,MaritalStatusID,Religion,Placeofbirth,NoOfChildren,Address,NationalID,Email, DepartmentID,EmploymentDate,SSNIT,IncomeTax,Probation,ProbationStartDate,ProibationEndDate,SSNITNo,FingerPrint,UserID) Values(@Surname,@Firstname,@OtherName,@GradeID,@DOB,@GenderGroupID,@Title,@Nationality,@Hometown,@Telno,@MobileNo,@MaritalstatusID,@Religion,@POB,@NoOfChildren,@Address,@NationalID,@Email,@DepartmentID,@EmploymentDate,@SSNIT,@IncomeTax,@Probation,@ProbationStartDate,@ProbationEndDate,@SSNITNo,@FingerPrint," + employee.User.ID + ")");
                }

                //Work Permit 
                if (employee.WorkPermit.ID != string.Empty)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@ID", employee.WorkPermit.ID, DbType.String);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@Duration", employee.WorkPermit.Duration, DbType.String);
                    dal.CreateParameter("@Notes", employee.WorkPermit.Notes, DbType.String);
                    dal.CreateParameter("@ExpiryDate", employee.WorkPermit.PermitExpires, DbType.DateTime);
                    dal.CreateParameter("@HasPermit", employee.WorkPermit.HasPermit, DbType.String);


                    dal.ExecuteNonQuery("Insert Into StaffWorkPermit(ID,StaffID,Duration,Notes,ExpiryDate,HasPermit,UserID) Values(@ID,@StaffID,@Duration,@Notes,@ExpiryDate,@HasPermit,@UserID)");
                }

                //Visa
                if (employee.Visa.VisaType != string.Empty)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@ExpiryDate", employee.Visa.ExpiresDate, DbType.DateTime);
                    dal.CreateParameter("@Notes", employee.Visa.Notes, DbType.String);
                    dal.CreateParameter("@ValidFrom", employee.Visa.ValidFrom, DbType.DateTime);
                    dal.CreateParameter("@VisaType", employee.Visa.VisaType, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffVisa(StaffID,ExpiryDate,Notes,ValidFrom,VisaType,UserID) values(@StaffID,@ExpiryDate,@Notes,@ValidFrom,@VisaType,@UserID) ");
                }

                //Passport
                if (employee.Passport.PassportNo != string.Empty)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@Notes", employee.WorkPermit.Notes, DbType.String);
                    dal.CreateParameter("@ExpiryDate", employee.Passport.PassportExpiresDate, DbType.DateTime);
                    dal.CreateParameter("@IssueDate", employee.Passport.PassportIssueDate, DbType.DateTime);
                    dal.CreateParameter("@PassportNo", employee.Passport.PassportNo, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffPassport(StaffID,Notes,ExpiryDate,IssueDate,PassportNo,UserID) Values(@StaffID,@Notes,@ExpiryDate,@IssueDate,@PassportNo,@UserID)");
                }

                //Social History
                dal.ClearParameters();
                dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                dal.CreateParameter("@PhysicalDisability", employee.SocialHistory.PhysicalDisability, DbType.String);
                dal.CreateParameter("@AppliedBefore", employee.SocialHistory.AppliedBefore, DbType.String);
                dal.CreateParameter("@Bonded", employee.SocialHistory.Bonded, DbType.String);
                dal.CreateParameter("@Convicted", employee.SocialHistory.Convicted, DbType.String);

                dal.ExecuteNonQuery("Insert Into StaffSocialHistory(StaffID,PhysicalDisability,AppliedBefore,Bonded,Convicted,UserID) Values(@StaffID,@PhysicalDisability,@AppliedBefore,@Bonded,@Convicted,@UserID)");

                foreach (StaffDocument document in employee.Documents)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@DateCreated", document.DateCreated, DbType.DateTime);
                    dal.CreateParameter("@Description", document.Description, DbType.String);
                    dal.CreateParameter("@DocumentContent", document.DocumentContent, DbType.Binary);
                    dal.CreateParameter("@DocumentGroup", document.DocumentGroup, DbType.String);
                    dal.CreateParameter("@DocumentType", document.DocumentType, DbType.String);
                    dal.CreateParameter("@Path", document.Path, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffDocuments(StaffID,DateCreated,Description,DocumentContent,DocumentGroup,DocumentType,Path,UserID) Values (@StaffID,@DateCreated,@Description,@DocumentContent,@DocumentGroup,@DocumentType,@Path,@UserID)");

                }
                foreach (Qualification qualification in employee.Qualifications)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@CertificateObtained", qualification.CertificateObtained, DbType.String);
                    dal.CreateParameter("@NameOfInstitution", qualification.NameOfInstitution, DbType.String);
                    dal.CreateParameter("@StartMonth", qualification.FromMonth, DbType.String);
                    dal.CreateParameter("@StartYear", qualification.FromMonth, DbType.String);
                    dal.CreateParameter("@EndMonth", qualification.ToYear, DbType.String);
                    dal.CreateParameter("@EndYear", qualification.ToYear, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffQualifications(StaffID,CertificateObtained,NameOfInstitution,StartMonth,StartYear,EndMonth,EndYear,UserID) Values (@StaffID,@CertificateObtained,@NameOfInstitution,@StartMonth,@StartYear,@EndMonth,@EndYear,@UserID)");

                }

                foreach (Profession profession in employee.Professions)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@NameOfProfession", profession.NameOfProfession, DbType.String);
                    dal.CreateParameter("@StartMonth", profession.FromMonth, DbType.String);
                    dal.CreateParameter("@StartYear", profession.FromYear, DbType.String);
                    dal.CreateParameter("@EndMonth", profession.ToMonth, DbType.String);
                    dal.CreateParameter("@EndYear", profession.ToYear, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffProfession(StaffID,NameOfProfession,StartMonth,StartYear,EndMonth,EndYear,UserID) Values(@StaffID,@NameOfProfession,@StartMonth,@StartYear,@EndMonth,@EndYear,@UserID)");

                }
                foreach (Referee referee in employee.Referees)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@Address", referee.Address, DbType.String);
                    dal.CreateParameter("@Name", referee.Name, DbType.String);
                    dal.CreateParameter("@Occupation", referee.Occupation, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffReferees(StaffID,Address,Name,Occupation,UserID) Values(@StaffID,@Address,@Name,@Occupation,@UserID)");

                }
                foreach (WorkExperience workExperience in employee.WorkExperiences)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@StartMonth", workExperience.FromMonth, DbType.String);
                    dal.CreateParameter("@StartYear", workExperience.FromYear, DbType.String);
                    dal.CreateParameter("@EndMonth", workExperience.ToMonth, DbType.String);
                    dal.CreateParameter("@EndYear", workExperience.ToYear, DbType.String);
                    dal.CreateParameter("@AnnualSalary", workExperience.AnnualSalary, DbType.Decimal);
                    dal.CreateParameter("@JobDescription", workExperience.JobTitle, DbType.String);
                    dal.CreateParameter("@NameOfOrganisation", workExperience.NameOfOrganisation, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffExperience(StaffId,StartMonth,StartYear,EndMonth,EndYear,JobDescription,NameOfOrganisation,AnnualSalary,UserID) Values(@StaffID,@StartMonth,@StartYear,@EndMonth,@EndYear,@JobDescription,@NameOfOrganisation,@AnnualSalary,@UserID)");

                }
                foreach (Relation relation in employee.OtherRelatives)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@Address", relation.Address, DbType.String);
                    dal.CreateParameter("@Name", relation.Name, DbType.String);
                    dal.CreateParameter("@Occupation", relation.Occupation, DbType.String);
                    dal.CreateParameter("@Relationship", relation.Relationship, DbType.String);
                    dal.CreateParameter("@Telephone", relation.Telephone, DbType.String);

                    dal.ExecuteNonQuery("Insert Into StaffOtherRelatives(StaffID,Address,Name,Occupation,Relationship,Telephone,UserID) Values(@StaffID,@Address,@Name,@Occupation,@Relationship,@Telephone,@UserID)");

                }

                foreach (Child child in employee.Children)
                {
                    dal.ClearParameters();
                    dal.CreateParameter("@UserID", employee.User.ID, DbType.Int32);
                    dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                    dal.CreateParameter("@DOB", child.DOB, DbType.DateTime);
                    dal.CreateParameter("@Name", child.FullName, DbType.String);
                    dal.CreateParameter("@GenderGroupID", child.Gender, DbType.Int32);

                    dal.ExecuteNonQuery("Insert Into StaffChildren(StaffID,DOB,Name,GenderGroupID,UserID) Values(@StaffID,@DOB,@Name,@GenderGroupID,@UserID)");

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region UPDATE
        public void Update(object item)
        {
            Employee employee = (Employee)item;
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@StaffCode", employee.ID, DbType.Int32);
                dal.CreateParameter("@StaffID", employee.StaffID, DbType.String);
                dal.CreateParameter("@FirstName", employee.FirstName, DbType.String);
                dal.CreateParameter("@Surname", employee.Surname, DbType.String);
                dal.CreateParameter("@OtherName", employee.OtherName, DbType.String);
                //Increments
                if (employee.IncrementDate == null)
                {
                    dal.CreateParameter("@IncrementDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@IncrementDate", employee.IncrementDate, DbType.Date);
                }
                //Job Title
                dal.CreateParameter("@JobTitleID", employee.JobTitle.ID, DbType.Int32);
                if (employee.JobTitleDate == null)
                {
                    dal.CreateParameter("@JobTitleDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@JobTitleDate", employee.JobTitleDate, DbType.Date);
                }
                //DOB
                if (employee.DOB == null)
                {
                    dal.CreateParameter("@DOB", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOB", employee.DOB, DbType.Date);
                }

                //Appointment Type
                dal.CreateParameter("@AppointmentTypeID", employee.AppointmentType.ID, DbType.Int32);

                //Status
                dal.CreateParameter("@StatusID", employee.StaffStatus.ID, DbType.Int32);

                //Probation
                dal.CreateParameter("@Probation", employee.Probation, DbType.Boolean);
                dal.CreateParameter("@ProbationApprover", employee.ProbationApprover, DbType.String);
                if (employee.ProbationApprovedTime == null)
                {
                    dal.CreateParameter("@ProbationApprovedTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@ProbationApprovedTime", employee.ProbationApprovedTime, DbType.DateTime);
                }
                if (employee.ProbationApprovedDate == null)
                {
                    dal.CreateParameter("@ProbationApprovedDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ProbationApprovedDate", employee.ProbationApprovedDate, DbType.Date);
                }
                //Confirmations
                dal.CreateParameter("@Confirmer", employee.Confirmer, DbType.String);
                dal.CreateParameter("@Confirmed", employee.Confirmed, DbType.Boolean);
                if (employee.CurrentConfirmationDate == null)
                {
                    dal.CreateParameter("@CurrentConfirmationDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentConfirmationDate", employee.CurrentConfirmationDate, DbType.Date);
                }
                if (employee.CurrentConfirmationTime == null)
                {
                    dal.CreateParameter("@CurrentConfirmationTime", DBNull.Value, DbType.DateTime);
                }
                else
                {
                    dal.CreateParameter("@CurrentConfirmationTime", employee.CurrentConfirmationTime, DbType.DateTime);
                }
                if (employee.EmploymentDate == null)
                {
                    dal.CreateParameter("@EmploymentDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@EmploymentDate", employee.EmploymentDate, DbType.Date);
                }
                if (employee.DOCA == null)
                {
                    dal.CreateParameter("@DOCA", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOCA", employee.DOCA, DbType.Date);
                }
                if (employee.DOFA == null)
                {
                    dal.CreateParameter("@DOFA", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@DOFA", employee.DOFA, DbType.Date);
                }
                if (employee.AssumptionDate == null)
                {
                    dal.CreateParameter("@AssumptionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AssumptionDate", employee.AssumptionDate, DbType.Date);
                }
                //Transfers
                if (employee.TransferType == null)
                {
                    dal.CreateParameter("@TransferType", DBNull.Value, DbType.String);
                }
                else
                {
                    dal.CreateParameter("@TransferType", employee.TransferType, DbType.String);
                }
                dal.CreateParameter("@TransferredOut", employee.TransferredOut, DbType.Boolean);
                dal.CreateParameter("@TransferredIn", employee.TransferedIn, DbType.Boolean);
                dal.CreateParameter("@TransferredInternally", employee.TransferredInternally, DbType.Boolean);

                if (employee.InZoneDate == null)
                {
                    dal.CreateParameter("@InZoneDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@InZoneDate", employee.InZoneDate, DbType.Date);
                }
                dal.CreateParameter("@ZoneID", employee.Zone.ID, DbType.Int32);
                dal.CreateParameter("@DepartmentID", employee.Department.ID, DbType.Int32);
                dal.CreateParameter("@UnitID", employee.Unit.ID, DbType.Int32);

                if (employee.CurrentTransferredDate == null)
                {
                    dal.CreateParameter("@CurrentTransferredDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentTransferredDate", employee.CurrentTransferredDate, DbType.Date);
                }             
                //Promotions
                dal.CreateParameter("@PromotionTypeID", employee.PromotionType.ID, DbType.Int32);
                dal.CreateParameter("@PromotionType", employee.PromotionType.Description.ToString(), DbType.String);
                if (employee.CurrentPromotionDate == null)
                {
                    dal.CreateParameter("@CurrentPromotionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentPromotionDate", employee.CurrentPromotionDate, DbType.Date);
                }
                dal.CreateParameter("@OldBasicSalary", employee.OldBasicSalary, DbType.Decimal);
                dal.CreateParameter("@IsInSalaryInfo", employee.IsInSalaryInfo, DbType.Boolean);
                dal.CreateParameter("@BasicSalary", employee.BasicSalary, DbType.Decimal);
                dal.CreateParameter("@GradeCategoryID", employee.GradeCategory.ID, DbType.Int32);
                dal.CreateParameter("@GradeID", employee.Grade.ID, DbType.Int32);
                dal.CreateParameter("@StepID", employee.Step.ID, DbType.Int32);
                dal.CreateParameter("@BandID", employee.Band.ID, DbType.Int32);

                if (employee.GradeDate == null)
                {
                    dal.CreateParameter("@GradeDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@GradeDate", employee.GradeDate, DbType.Date);
                }
                
                //Sanctions
                dal.CreateParameter("@Sanctioned", employee.Sanctioned, DbType.Boolean);
                dal.CreateParameter("@SanctionTypeID", employee.SanctionType.ID, DbType.Int32);
                if (employee.CurrentSanctionDate == null)
                {
                    dal.CreateParameter("@CurrentSanctionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentSanctionDate", employee.CurrentSanctionDate, DbType.Date);
                }
                dal.CreateParameter("@Payment", employee.Payment, DbType.Boolean);

                dal.CreateParameter("@Terminated", employee.Terminated, DbType.Boolean);
                if (employee.TerminationDate == null)
                {
                    dal.CreateParameter("@TerminationDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@TerminationDate", employee.TerminationDate, DbType.Date);
                }
                dal.CreateParameter("@SeparationTypeID", employee.SeparationType.ID, DbType.Int32);

                //Leave
                dal.CreateParameter("@OnLeaveWithPay", employee.OnLeaveWithPay, DbType.Boolean);
                dal.CreateParameter("@OnLeave", employee.OnLeave, DbType.Boolean);
                dal.CreateParameter("@LeaveStatus", employee.LeaveStatus, DbType.String);
                if (employee.CurrentLeaveDate == null)
                {
                    dal.CreateParameter("@CurrentLeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentLeaveDate", employee.CurrentLeaveDate, DbType.Date);
                }
                if (employee.CurrentLeaveStartDate == null)
                {
                    dal.CreateParameter("@CurrentLeaveStartDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentLeaveStartDate", employee.CurrentLeaveStartDate, DbType.Date);
                }
                if (employee.CurrentLeaveEndDate == null)
                {
                    dal.CreateParameter("@CurrentLeaveEndDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CurrentLeaveEndDate", employee.CurrentLeaveEndDate, DbType.Date);
                }
                dal.CreateParameter("@LeaveArrears", employee.LeaveArrears, DbType.Int32);
                dal.CreateParameter("@AnnualLeave", employee.AnnualLeave, DbType.Int32);
                dal.CreateParameter("@AnnualLeaveYear", employee.AnnualLeaveYear, DbType.Int32);
                if (employee.AnnualLeaveDate == null)
                {
                    dal.CreateParameter("@AnnualLeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AnnualLeaveDate", employee.AnnualLeaveDate, DbType.Date);
                }
                if (employee.AnnualLeaveProposedStartDate == null)
                {
                    dal.CreateParameter("@AnnualLeaveProposedStartDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AnnualLeaveProposedStartDate", employee.AnnualLeaveProposedStartDate, DbType.Date);
                }
                if (employee.AnnualLeaveProposedEndDate == null)
                {
                    dal.CreateParameter("@AnnualLeaveProposedEndDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@AnnualLeaveProposedEndDate", employee.AnnualLeaveProposedEndDate, DbType.Date);
                }
                dal.CreateParameter("@AnnualLeaveProposedDays", employee.AnnualLeaveProposedDays, DbType.Int32);
                dal.CreateParameter("@CasualLeave", employee.CasualLeave, DbType.Int32);
                if (employee.CasualLeaveDate == null)
                {
                    dal.CreateParameter("@CasualLeaveDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@CasualLeaveDate", employee.CasualLeaveDate, DbType.Date);
                }
                dal.CreateParameter("@LeaveTaken", employee.LeaveTaken, DbType.Int32);
                dal.CreateParameter("@LeaveBalance", employee.LeaveBalance, DbType.Int32);

                if (employee.directorates.ID>0)
                {
                    dal.CreateParameter("@DirectorateID", employee.directorates.ID, DbType.Int32);
                }
                else
                {
                    dal.CreateParameter("@DirectorateID", DBNull.Value, DbType.Int32);
                }
                if (employee.UpgradeDate == null)
                {
                    dal.CreateParameter("@UpgradeDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@UpgradeDate", employee.UpgradeDate, DbType.Date);
                }

                if (employee.ConversionDate == null)
                {
                    dal.CreateParameter("@ConversionDate", DBNull.Value, DbType.Date);
                }
                else
                {
                    dal.CreateParameter("@ConversionDate", employee.ConversionDate, DbType.Date);
                }

                if (employee.VehicleNumber == null)
                {
                    dal.CreateParameter("@VehicleNumber", string.Empty, DbType.String);
                }
                else
                {
                    dal.CreateParameter("@VehicleNumber", employee.VehicleNumber, DbType.String);
                }

                if (employee.VehicleDescription == null)
                {
                    dal.CreateParameter("@VehicleDescription", string.Empty, DbType.String);
                }
                else
                {
                    dal.CreateParameter("@VehicleDescription", employee.VehicleDescription, DbType.String);
                }

                if (employee.VehicleType == null)
                {
                    dal.CreateParameter("@VehicleType", string.Empty, DbType.String);
                }
                else
                {
                    dal.CreateParameter("@VehicleType", employee.VehicleType, DbType.String);
                }

                if (employee.SubBMC == null)
                {
                    dal.CreateParameter("@SubBMC", string.Empty, DbType.String);
                }
                else
                {
                    dal.CreateParameter("@SubBMC", employee.SubBMC, DbType.String);
                }


                dal.CreateParameter("@PaymentAccType", employee.PaymentAccType, DbType.String);
                string query = "Update StaffPersonalInfo Set Probation=@Probation, AppointmentTypeID=@AppointmentTypeID,StatusID=@StatusID,DOCA=@DOCA," +
                    "DOFA=@DOFA,DOB=@DOB,Firstname=@FirstName,Surname=@Surname,OtherName=@OtherName,JobTitleID=@JobTitleID,JobTitleDate=@JobTitleDate," +
                    "ZoneID=@ZoneID,InZoneDate=@InZoneDate,DepartmentID=@DepartmentID,UnitID=@UnitID,Confirmer=@Confirmer," +
                    "CurrentConfirmationTime=@CurrentConfirmationTime,ProbationApprover=@ProbationApprover,ProbationApprovedDate=@ProbationApprovedDate," +
                    "ProbationApprovedTime=@ProbationApprovedTime,LeaveArrears=@LeaveArrears,AnnualLeave=@AnnualLeave,AnnualLeaveYear=@AnnualLeaveYear," +
                    "AnnualLeaveDate=@AnnualLeaveDate,AnnualLeaveProposedStartDate=@AnnualLeaveProposedStartDate,AnnualLeaveProposedEndDate=@AnnualLeaveProposedEndDate," +
                    "AnnualLeaveProposedDays=@AnnualLeaveProposedDays,CasualLeave=@CasualLeave,CasualLeaveDate=@CasualLeaveDate,LeaveTaken=@LeaveTaken,LeaveBalance=@LeaveBalance," +
                    "IncrementDate=@IncrementDate,CurrentLeaveDate=@CurrentLeaveDate,OnLeave=@OnLeave,CurrentLeaveStartDate=@CurrentLeaveStartDate,CurrentLeaveEndDate=@CurrentLeaveEndDate," +
                    "LeaveStatus=@LeaveStatus,OnLeaveWithPay=@OnLeaveWithPay,Sanctioned=@Sanctioned,CurrentSanctionDate=@CurrentSanctionDate,SanctionTypeID=@SanctionTypeID,Payment=@Payment," +
                    "Terminated=@Terminated,TerminationDate=@TerminationDate,SeparationTypeID=@SeparationTypeID,CurrentPromotionDate=@CurrentPromotionDate,PromotionTypeID=@PromotionTypeID," +
                    "PromotionType=@PromotionType,BasicSalary=@BasicSalary,OldBasicSalary=@OldBasicSalary,IsInSalaryInfo=@IsInSalaryInfo,GradeID=@GradeID,GradeDate=@GradeDate," +
                    "GradeCategoryID=@GradeCategoryID,CurrentTransferredDate=@CurrentTransferredDate,TransferType=@TransferType,TransferredInternally=@TransferredInternally," +
                    "TransferredOut=@TransferredOut,TransferredIn=@TransferredIn,Confirmed=@Confirmed,CurrentConfirmationDate=@CurrentConfirmationDate,EmploymentDate=@EmploymentDate," +
                    "AssumptionDate=@AssumptionDate,StepID=@StepID, PaymentAccType=@PaymentAccType,DirectorateID=@DirectorateID,UpgradeDate=@UpgradeDate, ConversionDate=@ConversionDate, " +
                    "VehicleNumber=@VehicleNumber, VehicleDescription=@VehicleDescription, VehicleType=@VehicleType, SubBMC=@SubBMC" + 
                    " Where StaffID=@StaffID";
                dal.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        
        #endregion

        #region GetAll
        public IList<Employee> GetAll()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                string query = "SELECT StaffPersonalInfoView.*,REPLACE(StaffPersonalInfoView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoView.SupervisorFirstName +' '+ StaffPersonalInfoView.SupervisorOtherName +' '+ StaffPersonalInfoView.SupervisorSurname as SupervisorName From StaffPersonalInfoView Where StaffPersonalInfoView.Archived='False' and StaffPersonalInfoView.Terminated='False' and StaffPersonalInfoView.TransferredOut='False' Order By StaffPersonalInfoView.StaffID,StaffPersonalInfoView.Surname,StaffPersonalInfoView.Firstname,StaffPersonalInfoView.OtherName";
                DataTable table = dal.ExecuteReader(query);

                foreach (Employee employee in BuildEmployeeFromData(table))
                {
                    employees.Add(employee);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion
        
        #region GetByCriteria
        public IList<Employee> GetByCriteria(Query query1)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT StaffPersonalInfoView.*,REPLACE(StaffPersonalInfoView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoView.SupervisorFirstName +' '+ StaffPersonalInfoView.SupervisorOtherName +' '+ StaffPersonalInfoView.SupervisorSurname as SupervisorName From StaffPersonalInfoView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " StaffPersonalInfoView.Archived='False' Order By StaffPersonalInfoView.StaffID,StaffPersonalInfoView.Surname,StaffPersonalInfoView.Firstname,StaffPersonalInfoView.OtherName";
                table = dal.ExecuteReader(selectStatement);
                foreach (Employee employee in BuildEmployeeFromData(table))
                {
                    employees.Add(employee);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion
       
        #region Delete
        public void Delete(object item)
        {           
            try
            {
                Employee employee = (Employee)item;
                dal.ExecuteNonQuery("Update StaffPersonalInfo Set Archived = 'True' Where StaffID ='" + employee.StaffID +"'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Get By ID
        public Employee GetByID(object key)
        {
            Employee employee = new Employee();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@StaffID", key.ToString().Trim(), DbType.String);
                dal.CreateParameter("@Terminated", false, DbType.String);
                dal.CreateParameter("@TransferredOut", false, DbType.String);

               // string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoLazyLoadView.FirstName +' '+ StaffPersonalInfoLazyLoadView.OtherName +' '+ StaffPersonalInfoLazyLoadView.Surname as SupervisorName From StaffPersonalInfoLazyLoadView ";
                //query += "WHERE StaffPersonalInfoLazyLoadView.StaffID=@StaffID And StaffPersonalInfoLazyLoadView.Archived=@Archived order BY StaffPersonalInfoLazyLoadView.Surname ASC";

                 string query = "SELECT StaffPersonalInfoView.*,REPLACE(StaffPersonalInfoView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoView.SupervisorFirstName +' '+ StaffPersonalInfoView.SupervisorOtherName +' '+ StaffPersonalInfoView.SupervisorSurname as SupervisorName From StaffPersonalInfoView ";
                query += "WHERE StaffPersonalInfoView.StaffID=@StaffID And StaffPersonalInfoView.Archived=@Archived And StaffPersonalInfoView.Terminated=@Terminated And StaffPersonalInfoView.TransferredOut=@TransferredOut order BY StaffPersonalInfoView.Surname ASC";

                table = dal.ExecuteReader(query);                
                foreach (Employee emp in BuildEmployeeFromData(table))
                {
                    employee = emp;
                }               
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion

        #region Get By ID
        public Employee GetByID(int Id)
        {
            Employee employee = new Employee();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@Id",Id, DbType.Int32);
                // string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoLazyLoadView.FirstName +' '+ StaffPersonalInfoLazyLoadView.OtherName +' '+ StaffPersonalInfoLazyLoadView.Surname as SupervisorName From StaffPersonalInfoLazyLoadView ";
                //query += "WHERE StaffPersonalInfoLazyLoadView.StaffID=@StaffID And StaffPersonalInfoLazyLoadView.Archived=@Archived order BY StaffPersonalInfoLazyLoadView.Surname ASC";

                string query = "SELECT StaffPersonalInfoView.*,REPLACE(StaffPersonalInfoView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoView.SupervisorFirstName +' '+ StaffPersonalInfoView.SupervisorOtherName +' '+ StaffPersonalInfoView.SupervisorSurname as SupervisorName From StaffPersonalInfoView ";
                query += "WHERE StaffPersonalInfoView.ID=@Id And StaffPersonalInfoView.Archived=@Archived order BY StaffPersonalInfoView.Surname ASC";

                table = dal.ExecuteReader(query);
                foreach (Employee emp in BuildEmployeeFromData(table))
                {
                    employee = emp;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion



        #region Get By PhoneNumber
        public Employee GetByPhoneNumber(object key)
        {
            Employee employee = new Employee();
            try
            {
                DataTable table = new DataTable();
                dal.ClearParameters();
                dal.CreateParameter("@Archived", "False", DbType.String);
                dal.CreateParameter("@MobileNo", key.ToString().Trim(), DbType.String);
                // string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoLazyLoadView.FirstName +' '+ StaffPersonalInfoLazyLoadView.OtherName +' '+ StaffPersonalInfoLazyLoadView.Surname as SupervisorName From StaffPersonalInfoLazyLoadView ";
                //query += "WHERE StaffPersonalInfoLazyLoadView.StaffID=@StaffID And StaffPersonalInfoLazyLoadView.Archived=@Archived order BY StaffPersonalInfoLazyLoadView.Surname ASC";

                string query = "SELECT StaffPersonalInfoView.*,REPLACE(StaffPersonalInfoView.MobileNo,'-','') as MobileNumber,StaffPersonalInfoView.SupervisorFirstName +' '+ StaffPersonalInfoView.SupervisorOtherName +' '+ StaffPersonalInfoView.SupervisorSurname as SupervisorName From StaffPersonalInfoView ";
                query += "WHERE REPLACE(StaffPersonalInfoView.MobileNo,'-','')=@MobileNo And StaffPersonalInfoView.Archived=@Archived order BY StaffPersonalInfoView.Surname ASC";

                table = dal.ExecuteReader(query);
                foreach (Employee emp in BuildEmployeeFromData(table))
                {
                    employee = emp;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion

        #region BuildEmployeeFromData
        private IList<Employee> BuildEmployeeFromData(DataTable table)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                foreach (DataRow row in table.Rows)
                {

                    Employee employee = new Employee();
                    //Personal Info
                    employee.ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString());
                    employee.StaffID = row["StaffID"] == DBNull.Value ? string.Empty : row["StaffID"].ToString();

                    employee.GPSAddress = row["GPSAddress"] == DBNull.Value ? string.Empty : row["GPSAddress"].ToString(); 
                    
                    employee.CurrentTaxRelief = row["CurrentTaxRelief"] == DBNull.Value ? 0 : decimal.Parse(row["CurrentTaxRelief"].ToString());
                    employee.CurrentTaxReliefMonth = row["CurrentTaxReliefMonth"] == DBNull.Value ? 0 : int.Parse(row["CurrentTaxReliefMonth"].ToString());
                    employee.CurrentTaxReliefYear = row["CurrentTaxReliefYear"] == DBNull.Value ? 0 : int.Parse(row["CurrentTaxReliefYear"].ToString());

                    employee.FingerPrintID = row["FingerPrintID"] == DBNull.Value ? string.Empty : row["FingerPrintID"].ToString();
                    employee.Surname = row["Surname"] == DBNull.Value ? string.Empty : row["Surname"].ToString();
                    employee.FirstName = row["Firstname"] == DBNull.Value ? string.Empty : row["Firstname"].ToString();
                    employee.OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString();
                    employee.NickName = row["NickName"] == DBNull.Value ? string.Empty : row["NickName"].ToString();
                    employee.FileNumber = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString();
                    employee.FileLocation = row["FileLocation"] == DBNull.Value ? string.Empty : row["FileLocation"].ToString();
                    //employee.FileNumber = new FileNumber() { ID = row["FileNumberID"] == DBNull.Value ? 0 : int.Parse(row["FileNumberID"].ToString()), Description = row["FileNumber"] == DBNull.Value ? string.Empty : row["FileNumber"].ToString() };
                    employee.PIN = row["PIN"] == DBNull.Value ? string.Empty : row["PIN"].ToString();
                    employee.IsInSalaryInfo = row["IsInSalaryInfo"] == DBNull.Value ? false : bool.Parse(row["IsInSalaryInfo"].ToString());
                    employee.OldBasicSalary = row["OldBasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["OldBasicSalary"].ToString());
                    employee.Hourly = row["Hourly"] == DBNull.Value ? false : bool.Parse(row["Hourly"].ToString());
                    employee.PFRate = row["PFRate"] == DBNull.Value ? 0 : decimal.Parse(row["PFRate"].ToString());

                    employee.NationalID = row["NationalID"] == DBNull.Value ? string.Empty : row["NationalID"].ToString();
                    employee.MaidenName = row["MaidenName"] == DBNull.Value ? string.Empty : row["MaidenName"].ToString();
                    employee.GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), 
                                                                   Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString()};
                    employee.QualificationType = new QualificationType() { ID = row["QualificationID"] == DBNull.Value ? 0 : int.Parse(row["QualificationID"].ToString()), Description = row["Qualification"] == DBNull.Value ? string.Empty : row["Qualification"].ToString() };
                    employee.Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() };
                    employee.GradeDate = row["GradeDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["GradeDate"].ToString());
                    employee.GradeOnFirstAppointment = new EmployeeGrade() { ID = row["GradeOnFirstAppointmentID"] == DBNull.Value ? 0 : int.Parse(row["GradeOnFirstAppointmentID"].ToString()), Grade = row["GradeOnFirstAppointment"] == DBNull.Value ? string.Empty : row["GradeOnFirstAppointment"].ToString() };
                    employee.SalaryGrouping = row["SalaryGrouping"] == DBNull.Value ? string.Empty : row["SalaryGrouping"].ToString();
                    employee.Step = new Step() { ID = row["StepID"] == DBNull.Value ? 0 : int.Parse(row["StepID"].ToString()), Description = row["Step"] == DBNull.Value ? string.Empty : row["Step"].ToString() };
                    employee.Band = new Band() { ID = row["BandID"] == DBNull.Value ? 0 : int.Parse(row["BandID"].ToString()), Description = row["Band"] == DBNull.Value ? string.Empty : row["Band"].ToString() };
                    employee.BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString());
                    employee.DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString());
                    employee.DisabilityType = new DisabilityType() { ID = row["DisabilityTypeID"] == DBNull.Value ? 0 : int.Parse(row["DisabilityTypeID"].ToString()), Description = row["DisabilityType"] == DBNull.Value ? string.Empty : row["DisabilityType"].ToString() };
                    employee.DisabilityDate = row["DisabilityDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DisabilityDate"].ToString());
                    employee.IsDisable = row["IsDisable"] is DBNull ? false : bool.Parse(row["IsDisable"].ToString());
                    
                    employee.Race = new Race() { ID = row["RaceID"] == DBNull.Value ? 0 : int.Parse(row["RaceID"].ToString()), Description = row["Race"] == DBNull.Value ? string.Empty : row["Race"].ToString() };
                    employee.Tribe = row["Tribe"] == DBNull.Value ? string.Empty : row["Tribe"].ToString();
                    employee.Overseer = row["Overseer"] == DBNull.Value ? string.Empty : row["Overseer"].ToString();
                    employee.SupervisorCode = row["SupervisorCode"] == DBNull.Value ? 0 : int.Parse(row["SupervisorCode"].ToString());
                    employee.SupervisorStaffID = row["SupervisorStaffID"] == DBNull.Value ? string.Empty : row["SupervisorStaffID"].ToString();
                    employee.SupervisorName = row["SupervisorName"] == DBNull.Value ? string.Empty : row["SupervisorName"].ToString();

                    employee.LicenceType = new LicenceType() { ID = row["LicenceTypeID"] == DBNull.Value ? 0 : int.Parse(row["LicenceTypeID"].ToString()), Description = row["LicenceType"] == DBNull.Value ? string.Empty : row["LicenceType"].ToString() };
                    employee.LicenceNumber = row["LicenceNumber"] == DBNull.Value ? string.Empty : row["LicenceNumber"].ToString();

                    employee.Title = new Titles() { ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()), Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString() };
                    employee.Nationality = new Nationality() { ID = row["NationalityID"] == DBNull.Value ? 0 : int.Parse(row["NationalityID"].ToString()), Description = row["Nationality"] == DBNull.Value ? string.Empty : row["Nationality"].ToString() };
                    employee.Town = new Town() { ID = row["TownID"] == DBNull.Value ? 0 : int.Parse(row["TownID"].ToString()), Description = row["Town"] == DBNull.Value ? string.Empty : row["Town"].ToString() };
                    employee.HomeTown = new Town() { ID = row["HomeTownID"] == DBNull.Value ? 0 : int.Parse(row["HomeTownID"].ToString()), Description = row["HomeTown"] == DBNull.Value ? string.Empty : row["HomeTown"].ToString() };
                    employee.TelNo = row["TelNo"] == DBNull.Value ? string.Empty : row["TelNo"].ToString();
                    employee.MobileNo = row["MobileNumber"] == DBNull.Value ? string.Empty : row["MobileNumber"].ToString();


                    employee.DOM = row["DOM"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOM"].ToString());
                    employee.Religion = new Religion() { ID = row["ReligionID"] == DBNull.Value ? 0 : int.Parse(row["ReligionID"].ToString()), Description = row["Religion"] == DBNull.Value ? string.Empty : row["Religion"].ToString() };
                    employee.POB = new Town() { ID = row["PlaceOfBirthID"] == DBNull.Value ? 0 : int.Parse(row["PlaceOfBirthID"].ToString()), Description = row["PlaceOfBirth"] == DBNull.Value ? string.Empty : row["PlaceOfBirth"].ToString() };
                    employee.CountryOfBirth = new Country() { ID = row["CountryOfBirthID"] == DBNull.Value ? 0 : int.Parse(row["CountryOfBirthID"].ToString()), Description = row["CountryOfBirth"] == DBNull.Value ? string.Empty : row["CountryOfBirth"].ToString() };
                    employee.DistrictOfBirth = new District() { ID = row["DistrictOfBirthID"] == DBNull.Value ? 0 : int.Parse(row["DistrictOfBirthID"].ToString()), Description = row["DistrictOfBirth"] == DBNull.Value ? string.Empty : row["DistrictOfBirth"].ToString() };
                    employee.RegionOfBirth = new HRBussinessLayer.System_Setup_Class.Region() { ID = row["RegionOfBirthID"] == DBNull.Value ? 0 : int.Parse(row["RegionOfBirthID"].ToString()), Description = row["RegionOfBirth"] == DBNull.Value ? string.Empty : row["RegionOfBirth"].ToString() };
                    employee.NoOfChildren = row["NoOfChildren"] == DBNull.Value ? 0 : int.Parse(row["NoOfChildren"].ToString());
                    employee.Denomination = new Denomination() { ID = row["DenominationID"] == DBNull.Value ? 0 : int.Parse(row["DenominationID"].ToString()), Description = row["Denomination"] == DBNull.Value ? string.Empty : row["Denomination"].ToString() };
                    employee.NHISNumber = row["NHISNumber"] == DBNull.Value ? string.Empty : row["NHISNumber"].ToString();
                    employee.HouseNumber = row["HouseNumber"] == DBNull.Value ? string.Empty : row["HouseNumber"].ToString();
                    employee.StreetName = row["StreetName"] == DBNull.Value ? string.Empty : row["StreetName"].ToString();

                    employee.ResidentialTown = new Town() { ID = row["ResidentialTownID"] == DBNull.Value ? 0 : int.Parse(row["ResidentialTownID"].ToString()), Description = row["ResidentialTown"] == DBNull.Value ? string.Empty : row["ResidentialTown"].ToString() };
                    employee.ResidentialRegion = new HRBussinessLayer.System_Setup_Class.Region() { ID = row["ResidentialRegionID"] == DBNull.Value ? 0 : int.Parse(row["ResidentialRegionID"].ToString()), Description = row["ResidentialRegion"] == DBNull.Value ? string.Empty : row["ResidentialRegion"].ToString() };
                    employee.ResidentialCountry = new Country() { ID = row["ResidentialCountryID"] == DBNull.Value ? 0 : int.Parse(row["ResidentialCountryID"].ToString()), Description = row["ResidentialCountry"] == DBNull.Value ? string.Empty : row["ResidentialCountry"].ToString() };
                    employee.Address = row["Address"] == DBNull.Value ? string.Empty : row["Address"].ToString();
                    employee.Email = row["Email"] == DBNull.Value ? string.Empty : row["Email"].ToString();

                    employee.Region = new HRBussinessLayer.System_Setup_Class.Region() { ID = row["RegionID"] == DBNull.Value ? 0 : int.Parse(row["RegionID"].ToString()), Description = row["Region"] == DBNull.Value ? string.Empty : row["Region"].ToString() };
                    employee.ContactCountry = new Country() { ID = row["ContactCountryID"] == DBNull.Value ? 0 : int.Parse(row["ContactCountryID"].ToString()), Description = row["ContactCountry"] == DBNull.Value ? string.Empty : row["ContactCountry"].ToString() };
                    employee.ContactHomeTown = new Town() { ID = row["ContactHomeTownID"] == DBNull.Value ? 0 : int.Parse(row["ContactHomeTownID"].ToString()), Description = row["ContactHomeTown"] == DBNull.Value ? string.Empty : row["ContactHomeTown"].ToString() };
                    employee.Photo = row["Image"] is DBNull ? null : Global.ArrayToImage((byte[])row["Image"]);
                    employee.Department = row["DepartmentID"] != DBNull.Value ? departmentDataMapper.GetById(Convert.ToInt32(row["DepartmentID"])) : employee.Department;
                    employee.Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Code = row["UnitCode"] == DBNull.Value ? string.Empty : row["UnitCode"].ToString(), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() };

                    employee.EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString());
                    employee.IsProvidentFund = row["IsProvidentFund"] == DBNull.Value ? false : bool.Parse(row["IsProvidentFund"].ToString());
                    employee.SSNITContribution = row["SSNIT"] == DBNull.Value ? false : bool.Parse(row["SSNIT"].ToString());
                    employee.IncomeTaxContribution = row["IncomeTax"] == DBNull.Value ? false : bool.Parse(row["IncomeTax"].ToString());
                    employee.IsExemptFromSecondTier = row["IsExemptFromSecondTier"] == DBNull.Value ? false : bool.Parse(row["IsExemptFromSecondTier"].ToString());
                    
                    employee.IsSusuPlusContribution = row["IsSusuPlusContribution"] == DBNull.Value ? false : bool.Parse(row["IsSusuPlusContribution"].ToString());
                    employee.SusuPlusContributionAmount = row["SusuPlusContributionAmount"] == DBNull.Value ? 0 : decimal.Parse(row["SusuPlusContributionAmount"].ToString());

                    employee.IsWithholdingTax = row["IsWithholdingTax"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTax"].ToString());
                    employee.IsWithholdingTaxFixedAmount = row["IsWithholdingTaxFixedAmount"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxFixedAmount"].ToString());
                    employee.WithholdingTaxFixedAmount = row["WithholdingTaxFixedAmount"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingTaxFixedAmount"].ToString());
                    employee.IsWithholdingTaxRate = row["IsWithholdingTaxRate"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxRate"].ToString());
                    employee.WithholdingTaxRate = row["WithholdingTaxRate"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingTaxRate"].ToString());
                    employee.SalaryType = new SalaryType() { ID = row["SalaryTypeID"] == DBNull.Value ? 0 : int.Parse(row["SalaryTypeID"].ToString()), Description = row["SalaryType"] == DBNull.Value ? string.Empty : row["SalaryType"].ToString() };

                    employee.Probation = row["Probation"] == DBNull.Value ? false : bool.Parse(row["Probation"].ToString());
                    employee.ProbationStartDate = row["ProbationStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ProbationStartDate"].ToString());
                    employee.ProbationEndDate = row["ProbationEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ProbationEndDate"].ToString());
                    employee.SSNITNo = row["SSNITNo"] == DBNull.Value ? string.Empty : row["SSNITNo"].ToString();
                    employee.TIN = row["TIN"] == DBNull.Value ? string.Empty : row["TIN"].ToString();

                    //They should not be null ,Check this if Error:Object Refernce is not instantiated
                    employee.EngagementType = row["EngagementType"] is DBNull ? EngagementTypes.None.ToString() : row["EngagementType"].ToString();
                    employee.AppointmentType = new AppointmentType() { ID = row["AppointmentTypeID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeID"].ToString()), Description = row["AppointmentType"] == DBNull.Value ? string.Empty : row["AppointmentType"].ToString() };
                    employee.MaritalStatus = row["MaritalStatus"] == DBNull.Value ? string.Empty : row["MaritalStatus"].ToString();
                    employee.Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString();
                    employee.ProbationStatus = row["ProbationStatus"] is DBNull ? ProbationStatuses.None.ToString() : row["ProbationStatus"].ToString();
                    employee.PaymentType = row["PaymentType"] == DBNull.Value ? string.Empty : row["PaymentType"].ToString();
                    employee.StaffStatus = new StaffStatus() { ID = row["StatusID"] == DBNull.Value ? 0 : int.Parse(row["StatusID"].ToString()), Description = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString() };

                    //FingerPrint = row["FingerPrint"] is DBNull ? null : Global.ArrayToImage((byte[])row["FingerPrint"]);
                    employee.FingerPrint = row["FingerPrint"] is DBNull ? null : (byte[])row["FingerPrint"];
                    employee.DateAndTimeGenerated = DateTime.Parse(row["DateAndTimeGenerated"].ToString());

                    employee.User = new User() { ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()), UserName = row["UserName"] == DBNull.Value ? string.Empty : row["UserName"].ToString() };
                    employee.Archived = row["Archived"] == DBNull.Value ? false : bool.Parse(row["Archived"].ToString());

                    employee.EngagementGradeOn = new EmployeeGrade() { ID = row["EngagementGradeIDOn"] == DBNull.Value ? 0 : int.Parse(row["EngagementGradeIDOn"].ToString()), Grade = row["EngagementGradeOn"] == DBNull.Value ? string.Empty : row["EngagementGradeOn"].ToString() };
                    employee.EngagementGradeLeaving = new EmployeeGrade() { ID = row["EngagementGradeIDLeaving"] == DBNull.Value ? 0 : int.Parse(row["EngagementGradeIDLeaving"].ToString()), Grade = row["EngagementGradeLeaving"] == DBNull.Value ? string.Empty : row["EngagementGradeLeaving"].ToString() };
                    employee.EngagementDateApplied = row["EngagementDateApplied"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EngagementDateApplied"].ToString());
                    employee.EngagementEffectiveDate = row["EngagementEffectiveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EngagementEffectiveDate"].ToString());
                    employee.EngagementEndingDate = row["EngagementEndingDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["EngagementEndingDate"].ToString());
                    employee.EngagementContractOption = row["EngagementContractOption"] is DBNull ? string.Empty : row["EngagementContractOption"].ToString();
                    employee.EngagementAnnualSalary = row["EngagementAnnualSalary"] is DBNull ? 0 : decimal.Parse(row["EngagementAnnualSalary"].ToString());
                    employee.DOFA = row["DOFA"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOFA"].ToString());
                    employee.DOCA = row["DOCA"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOCA"].ToString());
                    employee.AssumptionDate = row["AssumptionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AssumptionDate"].ToString());
                    employee.Specialty = new Specialty() { ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString() };
                    

                    employee.JobTitleDate = row["JobTitleDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["JobTitleDate"].ToString());
                    employee.JobTitle = new JobTitle() { ID = row["JobTitleID"] == DBNull.Value ? 0 : int.Parse(row["JobTitleID"].ToString()), Description = row["JobTitle"] == DBNull.Value ? string.Empty : row["JobTitle"].ToString() };
                    employee.OccupationGroup = new OccupationGroup() { ID = row["OccupationGroupID"] == DBNull.Value ? 0 : int.Parse(row["OccupationGroupID"].ToString()), Description = row["OccupationGroup"] == DBNull.Value ? string.Empty : row["OccupationGroup"].ToString() };
                    employee.Zone = new Zone() { ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()), Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString() };

                    try
                    {
                        employee.directorates = new Directorate() { ID = row["DirectorateID"] == DBNull.Value ? 0 : int.Parse(row["DirectorateID"].ToString()), Description = row["Directorate"] == DBNull.Value ? string.Empty : row["Directorate"].ToString() };
                    }
                    catch (Exception ex) { }

                    employee.InZoneDate = row["InZoneDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["InZoneDate"].ToString());

                    employee.ServerDate = DateTime.Parse(row["ServerDate"].ToString());
                    employee.ServerTime = DateTime.Parse(row["ServerTime"].ToString());

                    //Sanctions and Promotions /Increments
                    employee.IncrementDate = row["IncrementDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["IncrementDate"].ToString());
                    employee.Mechanised = row["Mechanised"] == DBNull.Value ? false : bool.Parse(row["Mechanised"].ToString());
                    employee.PaymentAccType = row["PaymentAccType"] == DBNull.Value ? string.Empty : row["PaymentAccType"].ToString();
                    employee.Payment = row["Payment"] == DBNull.Value ? false : bool.Parse(row["Payment"].ToString());
                    employee.Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString());
                    employee.TerminationDate = row["TerminationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["TerminationDate"].ToString());
                    employee.SeparationType = new SeparationType()
                    {
                        ID = row["SeparationTypeID"] == DBNull.Value ? 0 : int.Parse(row["SeparationTypeID"].ToString()),
                        Description = row["SeparationType"] == DBNull.Value ? string.Empty : row["SeparationType"].ToString(),
                    };

                    employee.OnLeave = row["OnLeave"] == DBNull.Value ? false : bool.Parse(row["OnLeave"].ToString());
                    employee.LeaveStatus = row["LeaveStatus"] == DBNull.Value ? string.Empty : row["LeaveStatus"].ToString();
                    employee.OnLeaveWithPay = row["OnLeaveWithPay"] == DBNull.Value ? false : bool.Parse(row["OnLeaveWithPay"].ToString());
                    employee.CurrentLeaveDate = row["CurrentLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveDate"].ToString());
                    employee.CurrentLeaveStartDate = row["CurrentLeaveStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveStartDate"].ToString());
                    employee.CurrentLeaveEndDate = row["CurrentLeaveEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveEndDate"].ToString());
                    employee.AnnualLeave = row["AnnualLeave"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeave"].ToString());
                    employee.AnnualLeaveYear = row["AnnualLeaveYear"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveYear"].ToString());
                    employee.AnnualLeaveDate = row["AnnualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveDate"].ToString());
                    employee.AnnualLeaveProposedStartDate = row["AnnualLeaveProposedStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveProposedStartDate"].ToString());
                    employee.AnnualLeaveProposedEndDate = row["AnnualLeaveProposedEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveProposedEndDate"].ToString());
                    employee.AnnualLeaveProposedDays = row["AnnualLeaveProposedDays"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveProposedDays"].ToString());
                    employee.AnnualLeaveEntitlement = new AnnualLeaveEntitlement()
                    {
                        ID = row["AnnualLeaveEntitlementID"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveEntitlementID"].ToString()),
                        CategoryOfPost = row["CategoryOfPost"] == DBNull.Value ? string.Empty : row["CategoryOfPost"].ToString(),
                        NumberOfDays = row["NumberOfDays"] == DBNull.Value ? 0 : int.Parse(row["NumberOfDays"].ToString()),
                        TypeOfGrade = row["TypesOfGrade"] == DBNull.Value ? string.Empty : row["TypesOfGrade"].ToString(),
                        Status = row["AnnualLeaveStatus"] == DBNull.Value ? string.Empty : row["AnnualLeaveStatus"].ToString(),
                    };
                    employee.CasualLeave = row["CasualLeave"] == DBNull.Value ? 0 : int.Parse(row["CasualLeave"].ToString());
                    employee.CasualLeaveDate = row["CasualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CasualLeaveDate"].ToString());

                    employee.LeaveArrears = row["LeaveArrears"] == DBNull.Value ? 0 : int.Parse(row["LeaveArrears"].ToString());
                    employee.LeaveBalance = row["LeaveBalance"] == DBNull.Value ? 0 : int.Parse(row["LeaveBalance"].ToString());
                    employee.LeaveTaken = row["LeaveTaken"] == DBNull.Value ? 0 : int.Parse(row["LeaveTaken"].ToString());
                    employee.Confirmed = row["Confirmed"] == DBNull.Value ? false : bool.Parse(row["Confirmed"].ToString());
                    employee.CurrentConfirmationDate = row["CurrentConfirmationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentConfirmationDate"].ToString());
                    employee.PromotionType = new PromotionType()
                    {
                        ID = row["PromotionTypeID"] == DBNull.Value ? 0 : int.Parse(row["PromotionTypeID"].ToString()),
                        Description = row["PromotionType"] == DBNull.Value ? string.Empty : row["PromotionType"].ToString()
                    };
                    employee.CurrentPromotionDate = row["CurrentPromotionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentPromotionDate"].ToString());
                    employee.Sanctioned = row["Sanctioned"] == DBNull.Value ? false : bool.Parse(row["Sanctioned"].ToString());
                    employee.SanctionType = new SanctionType()
                    {
                        ID = row["SanctionTypeID"] == DBNull.Value ? 0 : int.Parse(row["SanctionTypeID"].ToString()),
                        Description = row["SanctionType"] == DBNull.Value ? string.Empty : row["SanctionType"].ToString()
                    };
                    employee.CurrentSanctionDate = row["CurrentSanctionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentSanctionDate"].ToString());
                    employee.TransferType = row["TransferType"] == DBNull.Value ? string.Empty : row["TransferType"].ToString();
                    employee.TransferredOut = row["TransferredOut"] == DBNull.Value ? false : bool.Parse(row["TransferredOut"].ToString());
                    employee.TransferedIn = row["TransferredIn"] == DBNull.Value ? false : bool.Parse(row["TransferredIn"].ToString());
                    employee.TransferredInternally = row["TransferredInternally"] == DBNull.Value ? false : bool.Parse(row["TransferredInternally"].ToString());
                    employee.CurrentTransferredDate = row["CurrentTransferredDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentTransferredDate"].ToString());
                    employee.GradeOnFirstAppointment = new EmployeeGrade() { ID = row["GradeOnFirstAppointmentID"] == DBNull.Value ? 0 : int.Parse(row["GradeOnFirstAppointmentID"].ToString()), Grade = row["GradeOnFirstAppointment"] == DBNull.Value ? string.Empty : row["GradeOnFirstAppointment"].ToString() };
                    employee.VehicleNumber = row["VehicleNumber"] is DBNull ? string.Empty : row["VehicleNumber"].ToString();
                    employee.VehicleDescription = row["VehicleDescription"] is DBNull ? string.Empty : row["VehicleDescription"].ToString();
                    employee.VehicleType = row["VehicleType"] is DBNull ? string.Empty : row["VehicleType"].ToString();
                    employee.SubBMC = row["SubBMC"] is DBNull ? string.Empty : row["SubBMC"].ToString();
                    employee.SubBMC = row["SubBMC"] is DBNull ? string.Empty : row["SubBMC"].ToString();

                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBankView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employee.StaffID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffBankView.InUse",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = true,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    staffBanks = idal.GetByCriteria<StaffBank>(query);
                    foreach (StaffBank staffBank in staffBanks)
                    {
                        employee.StaffBank.Add(staffBank);
                    }

                    table = dal.ExecuteReader("select * from StaffDocumentView Where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowSWp in table.Rows)
                    {
                        StaffDocument staffDocument = new StaffDocument() { ID = int.Parse(rowSWp["ID"].ToString()), DateCreated = DateTime.Parse(rowSWp["DateCreated"].ToString()), Description = rowSWp["Description"].ToString(), DocumentContent = (byte[])rowSWp["DocumentContent"], DocumentGroup = rowSWp["DocumentGroup"].ToString(), DocumentType = rowSWp["DocumentType"].ToString(), Path = rowSWp["Path"].ToString() };
                        employee.Documents.Add(staffDocument);
                    }
                    table = dal.ExecuteReader("Select * From StaffWorkPermit where StaffID='" + employee.StaffID + "'");
                    foreach (DataRow rowSw in table.Rows)
                    {
                        WorkPermit workPermit = new WorkPermit() { ID = rowSw["ID"].ToString(), Duration = decimal.Parse(rowSw["Duration"].ToString()), HasPermit = rowSw["HasPermit"].ToString(), Notes = rowSw["Notes"].ToString(), PermitExpires = DateTime.Parse(rowSw["ExpiryDate"].ToString()), WorkPermitID = rowSw["WorkPermitID"].ToString() };
                        employee.WorkPermit = workPermit;
                    }
                    table = dal.ExecuteReader("Select * From StaffPassport Where StaffID='" + employee.StaffID + "'");
                    foreach (DataRow rowSp in table.Rows)
                    {
                        employee.Passport = new Passport() { ID = int.Parse(rowSp["ID"].ToString()), HasPassport = bool.Parse(rowSp["HasPassport"].ToString()), Notes = rowSp["Notes"].ToString(), PassportExpiresDate = DateTime.Parse(rowSp["ExpiryDate"].ToString()), PassportNo = rowSp["PassportNo"].ToString(), PassportIssueDate = DateTime.Parse(rowSp["IssueDate"].ToString()) };
                    }
                    table = dal.ExecuteReader("Select * From StaffVisa Where StaffID = '" + employee.StaffID + "'");
                    foreach (DataRow rowVs in table.Rows)
                    {
                        employee.Visa = new Visa() { ID = int.Parse(rowVs["ID"].ToString()), VisaNo = rowVs["VisaNo"].ToString(), HasVisa = bool.Parse(rowVs["HasVisa"].ToString()), ExpiresDate = DateTime.Parse(rowVs["ExpiryDate"].ToString()), Notes = rowVs["Notes"].ToString(), VisaType = rowVs["VisaType"].ToString(), ValidFrom = DateTime.Parse(rowVs["ValidFrom"].ToString()) };
                    }
                    table = dal.ExecuteReader("Select * From StaffSocialHistoryView Where StaffID = '" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowSh in table.Rows)
                    {
                        employee.SocialHistory = new SocialHistory() { ID = int.Parse(rowSh["ID"].ToString()), AppliedBefore = rowSh["AppliedBefore"].ToString(), Bonded = rowSh["Bonded"].ToString(), Convicted = rowSh["Convicted"].ToString(), PhysicalDisability = rowSh["PhysicalDisability"].ToString() };
                    }
                    table = dal.ExecuteReader("Select * From StaffEducationHistory where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowQ in table.Rows)
                    {
                        Qualification qualification = new Qualification(int.Parse(rowQ["ID"].ToString()), rowQ["NameOfInstitution"].ToString(), rowQ["CertificateObtained"].ToString(), rowQ["StartMonth"].ToString(), rowQ["StartYear"].ToString(), rowQ["EndMonth"].ToString(), rowQ["EndYear"].ToString());
                        employee.Qualifications.Add(qualification);
                    }

                    table = dal.ExecuteReader("Select * From StaffProfessionHistory where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowP in table.Rows)
                    {
                        Profession profession = new Profession(int.Parse(rowP["ID"].ToString()), rowP["NameOfProfession"].ToString(), rowP["StartMonth"].ToString(), rowP["EndMonth"].ToString(), rowP["StartYear"].ToString(), rowP["EndYear"].ToString());
                        employee.Professions.Add(profession);
                    }

                    table = dal.ExecuteReader("Select * From StaffRefereeView where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowR in table.Rows)
                    {
                        Referee referee = new Referee(int.Parse(rowR["ID"].ToString()), rowR["Name"].ToString(), rowR["Address"].ToString(), rowR["Occupation"].ToString(), rowR["TelNumber"].ToString(), rowR["Email"].ToString());
                        employee.Referees.Add(referee);
                    }

                    table = dal.ExecuteReader("Select * From StaffEmploymentHistory where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowW in table.Rows)
                    {
                        WorkExperience experience = new WorkExperience(int.Parse(rowW["ID"].ToString()), rowW["NameOfOrganisation"].ToString(), rowW["JobTitle"].ToString(),decimal.Parse(rowW["AnnualSalary"].ToString()), rowW["StartMonth"].ToString(), rowW["StartYear"].ToString(), rowW["EndYear"].ToString(), rowW["EndMonth"].ToString(), rowW["ReasonForLeaving"].ToString(), DateTime.Parse( rowW["DateAndTimeGenerated"].ToString()), bool.Parse(rowW["Archived"].ToString()));
                        employee.WorkExperiences.Add(experience);
                    }

                    table = dal.ExecuteReader("select * from StaffOtherRelativeView where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowO in table.Rows)
                    {
                        Relation relation = new Relation(int.Parse(rowO["ID"].ToString()), int.Parse(rowO["StaffCode"].ToString()), rowO["StaffID"].ToString(), rowO["Name"].ToString(), int.Parse(rowO["RelationshipID"].ToString()), rowO["Relationship"].ToString(), rowO["Type"].ToString(), int.Parse(rowO["OccupationID"].ToString()), rowO["Occupation"].ToString(), int.Parse(rowO["POBID"].ToString()), rowO["POB"].ToString(), rowO["Telephone"].ToString(), rowO["Address"].ToString(), (Nullable<DateTime>)DateTime.Parse(rowO["DOB"].ToString()));
                        employee.OtherRelatives.Add(relation);
                    }

                    table = dal.ExecuteReader("SELECT * FROM StaffLanguageView where StaffID ='" + employee.StaffID + "' and Archived='False'");
                    foreach (DataRow rowSl in table.Rows)
                    {
                        StaffLanguage staffLanguage = new StaffLanguage(int.Parse(rowSl["ID"].ToString()), rowSl["StaffID"].ToString(), int.Parse(rowSl["StaffCode"].ToString()), int.Parse(rowSl["LanguageID"].ToString()), rowSl["Language"].ToString(), rowSl["LanguageLevel"].ToString(), bool.Parse(rowSl["Active"].ToString()), DateTime.Parse(rowSl["DateCreated"].ToString()));
                        employee.StaffLanguage.Add(staffLanguage);
                    }

                    employee.ConversionDate = row["ConversionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ConversionDate"].ToString());
                    employee.UpgradeDate = row["UpgradeDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["UpgradeDate"].ToString());

                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion

        #region LazyLoad
        public IList<Employee> LazyLoad()
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                dal.ClearParameters();
                dal.CreateParameter("@Archived", false, DbType.Boolean);
                string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView Where StaffPersonalInfoLazyLoadView.Archived=@Archived and StaffPersonalInfoLazyLoadView.Terminated='False'  and StaffPersonalInfoLazyLoadView.TransferredOut='False'  and StaffPersonalInfoLazyLoadView.Confirmed='True' Order By StaffPersonalInfoLazyLoadView.StaffID,StaffPersonalInfoLazyLoadView.Surname";
                DataTable table = dal.ExecuteReader(query);
                foreach (Employee empl in BuildLazyLoadEmployeeData(table))
                {
                    employees.Add(empl);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion

        #region LazyLoadCriteria
        public IList<Employee> LazyLoadCriteria(Query query1)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                DataTable table = new DataTable();
                string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView ";
                string selectStatement = QueryTranslater.TranslateQuery(query, query1);
                selectStatement += " StaffPersonalInfoLazyLoadView.Archived='False' Order By StaffPersonalInfoLazyLoadView.StaffID,StaffPersonalInfoLazyLoadView.Surname,StaffPersonalInfoLazyLoadView.Firstname,StaffPersonalInfoLazyLoadView.OtherName";
                table = dal.ExecuteReader(selectStatement);
                foreach (Employee employee in BuildLazyLoadEmployeeData(table))
                {
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion

        #region LazyLoadByStaffID
        public Employee LazyLoadByStaffID(object item)
        {
            Employee employee = new Employee();
            string query = string.Empty;
            try
            {
                if (item.GetType() == typeof(Employee))
                {
                    Employee emplo = (Employee)item;
                    query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView Where StaffPersonalInfoLazyLoadView.StaffID='" + emplo.StaffID + "' AND StaffPersonalInfoLazyLoadView.Archived='False' and StaffPersonalInfoLazyLoadView.Terminated='False'  and StaffPersonalInfoLazyLoadView.TransferredOut='False'  and StaffPersonalInfoLazyLoadView.Confirmed='True' Order By StaffPersonalInfoLazyLoadView.StaffID,StaffPersonalInfoLazyLoadView.Surname";
                }
                else
                {
                    query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView Where StaffPersonalInfoLazyLoadView.StaffID='" + item.ToString() + "' AND StaffPersonalInfoLazyLoadView.Archived='False' and StaffPersonalInfoLazyLoadView.Terminated='False'  and StaffPersonalInfoLazyLoadView.TransferredOut='False'  and StaffPersonalInfoLazyLoadView.Confirmed='True' Order By StaffPersonalInfoLazyLoadView.StaffID,StaffPersonalInfoLazyLoadView.Surname";
                }
                DataTable table = dal.ExecuteReader(query);
                foreach (Employee empl in BuildLazyLoadEmployeeData(table))
                {
                    employee = empl;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion

        private DALHelper dalHelper;

        #region LoadEmployeesByLikeStaffID_OR_Name
        public IList<Employee> LoadEmployeesByLikeStaffID_OR_Name(string staffInput)
        {
            dalHelper=new DALHelper();
            dalHelper.ClearParameters();
            dalHelper.CreateParameter("@StaffInput", staffInput, DbType.String);
            dalHelper.CreateParameter("@Terminated", false, DbType.Boolean);
            dalHelper.CreateParameter("@TransferredOut", false, DbType.Boolean);
            dalHelper.CreateParameter("@Confirmed", true, DbType.Boolean);

            IList<Employee> employees = new List<Employee>();

            DataTable table = dalHelper.ExecuteReader("select top 50 *,REPLACE(MobileNo,'-','') as MobileNumber from StaffPersonalInfoView where (StaffID like @StaffInput+'%' or Surname like '%@StaffInput%' or otherName like '%@StaffInput%' or FirstName like '%@StaffInput%')  and Terminated=@Terminated and TransferredOut=@TransferredOut and Confirmed=@Confirmed");
            foreach (Employee empl in BuildLazyLoadEmployeeData(table))
            {
              employees.Add(empl);
            }
            return employees;
        }
        #endregion

        #region LazyLoadUnconfirmedByStaffID
        public Employee LazyLoadUnconfirmedByStaffID(object item)
        {
            Employee employee = new Employee();
            try
            {
                Employee emplo = (Employee)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", emplo.Archived, DbType.Boolean);
                dal.CreateParameter("@StaffID", emplo.StaffID, DbType.String);
                string query = "SELECT StaffPersonalInfoLazyLoadView.*,REPLACE(StaffPersonalInfoLazyLoadView.MobileNo,'-','') as MobileNumber From StaffPersonalInfoLazyLoadView Where StaffPersonalInfoLazyLoadView.StaffID=@StaffID AND StaffPersonalInfoLazyLoadView.Archived=@Archived and StaffPersonalInfoLazyLoadView.Terminated='False'  and StaffPersonalInfoLazyLoadView.TransferredOut='False' Order By StaffPersonalInfoLazyLoadView.StaffID,StaffPersonalInfoLazyLoadView.Surname";
                DataTable table = dal.ExecuteReader(query);
                foreach (Employee empl in BuildLazyLoadEmployeeData(table))
                {
                    employee = empl;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion

        #region BuildLazyLoadEmployeeData
        public IList<Employee> BuildLazyLoadEmployeeData(DataTable table)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Employee employee = new Employee();
                    employee.ID = row["ID"] == DBNull.Value ? 0 : int.Parse(row["ID"].ToString());
                    employee.StaffID = row["StaffID"] == DBNull.Value ? string.Empty : row["StaffID"].ToString();
                    employee.Title = new Titles() { ID = row["TitleID"] == DBNull.Value ? 0 : int.Parse(row["TitleID"].ToString()), Description = row["Title"] == DBNull.Value ? string.Empty : row["Title"].ToString() };
                    employee.Surname = row["Surname"].ToString();
                    employee.FirstName = row["Firstname"].ToString();
                    employee.OtherName = row["OtherName"] == DBNull.Value ? string.Empty : row["OtherName"].ToString();
                    employee.SSNITNo = row["SSNITNo"] == DBNull.Value ? string.Empty : row["SSNITNo"].ToString();
                    employee.TelNo = row["TelNo"] == DBNull.Value ? string.Empty : row["TelNo"].ToString();
                    employee.Email = row["Email"] == DBNull.Value ? string.Empty : row["Email"].ToString();
                    employee.MobileNo = row["MobileNumber"] == DBNull.Value ? string.Empty : row["MobileNumber"].ToString();
                    employee.MaritalStatus = row["MaritalStatus"] == DBNull.Value ? string.Empty : row["MaritalStatus"].ToString();
                    employee.JobTitleDate = row["JobTitleDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["JobTitleDate"].ToString());
                    employee.JobTitle = new JobTitle() { ID = row["JobTitleID"] == DBNull.Value ? 0 : int.Parse(row["JobTitleID"].ToString()), Description = row["JobTitle"] == DBNull.Value ? string.Empty : row["JobTitle"].ToString() };
                    employee.GradeCategory = new GradeCategory() { ID = row["GradeCategoryID"] == DBNull.Value ? 0 : int.Parse(row["GradeCategoryID"].ToString()), Description = row["GradeCategory"] == DBNull.Value ? null : row["GradeCategory"].ToString() };
                    employee.Grade = new EmployeeGrade() { ID = row["GradeID"] == DBNull.Value ? 0 : int.Parse(row["GradeID"].ToString()), Grade = row["Grade"] == DBNull.Value ? string.Empty : row["Grade"].ToString() };
                    employee.GradeDate = row["GradeDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["GradeDate"].ToString());
                    employee.GradeOnFirstAppointment = new EmployeeGrade() { ID = row["GradeOnFirstAppointmentID"] == DBNull.Value ? 0 : int.Parse(row["GradeOnFirstAppointmentID"].ToString()), Grade = row["GradeOnFirstAppointment"] == DBNull.Value ? null : row["GradeOnFirstAppointment"].ToString() };
                    employee.SalaryGrouping = row["SalaryGrouping"] == DBNull.Value ? string.Empty : row["SalaryGrouping"].ToString();
                    employee.Step = new Step() { ID = row["StepID"] == DBNull.Value ? 0 : int.Parse(row["StepID"].ToString()), Description = row["Step"] == DBNull.Value ? string.Empty : row["Step"].ToString() };
                    employee.Band = new Band() { ID = row["BandID"] == DBNull.Value ? 0 : int.Parse(row["BandID"].ToString()), Description = row["Band"] == DBNull.Value ? string.Empty : row["Band"].ToString() };
                    employee.BasicSalary = row["BasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["BasicSalary"].ToString());
                    employee.OldBasicSalary = row["OldBasicSalary"] == DBNull.Value ? 0 : decimal.Parse(row["OldBasicSalary"].ToString());
                    employee.DOB = row["DOB"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOB"].ToString());
                    employee.IsInSalaryInfo = row["IsInSalaryInfo"] == DBNull.Value ? false : bool.Parse(row["IsInSalaryInfo"].ToString());
                    employee.Gender = row["Gender"] == DBNull.Value ? string.Empty : row["Gender"].ToString();
                    employee.Zone = new Zone() { ID = row["ZoneID"] == DBNull.Value ? 0 : int.Parse(row["ZoneID"].ToString()), Description = row["Zone"] == DBNull.Value ? string.Empty : row["Zone"].ToString() };
                    employee.Department = new Department() { ID = row["DepartmentID"] == DBNull.Value ? 0 : int.Parse(row["DepartmentID"].ToString()), Code = row["DepartmentCode"] == DBNull.Value ? string.Empty : row["DepartmentCode"].ToString(), Description = row["Department"] == DBNull.Value ? string.Empty : row["Department"].ToString() };
                    employee.Unit = new Unit() { ID = row["UnitID"] == DBNull.Value ? 0 : int.Parse(row["UnitID"].ToString()), Code = row["UnitCode"] == DBNull.Value ? string.Empty : row["UnitCode"].ToString(), Description = row["Unit"] == DBNull.Value ? string.Empty : row["Unit"].ToString() };
                    employee.PaymentType = row["PaymentType"] == DBNull.Value ? string.Empty : row["PaymentType"].ToString();
                    employee.Specialty = new Specialty() { ID = row["SpecialtyID"] == DBNull.Value ? 0 : int.Parse(row["SpecialtyID"].ToString()), Description = row["Specialty"] == DBNull.Value ? string.Empty : row["Specialty"].ToString() };
                    employee.NHISNumber = row["NHISNumber"] == DBNull.Value ? string.Empty : row["NHISNumber"].ToString();
                    employee.StaffStatus = new StaffStatus() { ID = row["StatusID"] == DBNull.Value ? 0 : int.Parse(row["StatusID"].ToString()), Description = row["Status"] == DBNull.Value ? string.Empty : row["Status"].ToString() };
                    employee.Hourly = row["Hourly"] == DBNull.Value ? false : bool.Parse(row["Hourly"].ToString());
                    employee.PFRate = row["PFRate"] == DBNull.Value ? 0 : decimal.Parse(row["PFRate"].ToString());

                    employee.Race = new Race() { ID = row["RaceID"] == DBNull.Value ? 0 : int.Parse(row["RaceID"].ToString()), Description = row["Race"] == DBNull.Value ? string.Empty : row["Race"].ToString() };
                    employee.Tribe = row["Tribe"] == DBNull.Value ? string.Empty : row["Tribe"].ToString();
                    employee.Overseer = row["Overseer"] == DBNull.Value ? string.Empty : row["Overseer"].ToString();
                    employee.SupervisorCode = row["SupervisorCode"] == DBNull.Value ? 0 : int.Parse(row["SupervisorCode"].ToString());
                    //employee.SupervisorStaffID = row["SupervisorStaffID"] == DBNull.Value ? string.Empty : row["SupervisorStaffID"].ToString();
                    //employee.SupervisorName = row["SupervisorName"] == DBNull.Value ? string.Empty : row["SupervisorName"].ToString();

                    employee.DOFA = row["DOFA"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOFA"].ToString());
                    employee.DOCA = row["DOCA"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["DOCA"].ToString());
                    employee.AssumptionDate = row["AssumptionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AssumptionDate"].ToString());
                    employee.EmploymentDate = row["EmploymentDate"] == DBNull.Value ? null : (Nullable<DateTime>)DateTime.Parse(row["EmploymentDate"].ToString());

                    employee.IsExemptFromSecondTier = row["IsExemptFromSecondTier"] == DBNull.Value ? false : bool.Parse(row["IsExemptFromSecondTier"].ToString());
                    employee.IsProvidentFund = row["IsProvidentFund"] == DBNull.Value ? false : bool.Parse(row["IsProvidentFund"].ToString());
                    employee.SSNITContribution = row["SSNIT"] == DBNull.Value ? false : bool.Parse(row["SSNIT"].ToString());
                    employee.IncomeTaxContribution = row["IncomeTax"] == DBNull.Value ? false : bool.Parse(row["IncomeTax"].ToString());
                    employee.IsSusuPlusContribution = row["IsSusuPlusContribution"] == DBNull.Value ? false : bool.Parse(row["IsSusuPlusContribution"].ToString());
                    employee.SusuPlusContributionAmount = row["SusuPlusContributionAmount"] == DBNull.Value ? 0 : decimal.Parse(row["SusuPlusContributionAmount"].ToString());

                    employee.IsWithholdingTax = row["IsWithholdingTax"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTax"].ToString());
                    employee.IsWithholdingTaxFixedAmount = row["IsWithholdingTaxFixedAmount"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxFixedAmount"].ToString());
                    employee.WithholdingTaxFixedAmount = row["WithholdingTaxFixedAmount"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingTaxFixedAmount"].ToString());
                    employee.IsWithholdingTaxRate = row["IsWithholdingTaxRate"] == DBNull.Value ? false : bool.Parse(row["IsWithholdingTaxRate"].ToString());
                    employee.WithholdingTaxRate = row["WithholdingTaxRate"] == DBNull.Value ? 0 : decimal.Parse(row["WithholdingTaxRate"].ToString());
                    employee.SalaryType = new SalaryType() 
                    { 
                        ID = row["SalaryTypeID"] == DBNull.Value ? 0 : int.Parse(row["SalaryTypeID"].ToString()), 
                        Description = row["SalaryType"] == DBNull.Value ? string.Empty : row["SalaryType"].ToString() 
                    };
                    employee.AppointmentType = new AppointmentType()
                    {
                        ID = row["AppointmentTypeID"] == DBNull.Value ? 0 : int.Parse(row["AppointmentTypeID"].ToString()),
                        Description = row["AppointmentType"] == DBNull.Value ? string.Empty : row["AppointmentType"].ToString()
                    };
                    employee.Probation = row["Probation"] == DBNull.Value ? false : bool.Parse(row["Probation"].ToString());
                    employee.ProbationStartDate = row["ProbationStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ProbationStartDate"].ToString());
                    employee.ProbationEndDate = row["ProbationEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ProbationEndDate"].ToString());
                    employee.TIN = row["TIN"] == DBNull.Value ? string.Empty : row["TIN"].ToString();

                    //Sanctions and Promotions terminated field is used for all separations
                    employee.IncrementDate = row["IncrementDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["IncrementDate"].ToString());
                    employee.Mechanised = row["Mechanised"] == DBNull.Value ? false : bool.Parse(row["Mechanised"].ToString());
                    employee.PaymentAccType = row["PaymentAccType"] == DBNull.Value ? string.Empty : row["PaymentAccType"].ToString();
                    employee.Payment = row["Payment"] == DBNull.Value ? false : bool.Parse(row["Payment"].ToString());

                    employee.Terminated = row["Terminated"] == DBNull.Value ? false : bool.Parse(row["Terminated"].ToString());
                    employee.TerminationDate = row["TerminationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["TerminationDate"].ToString());
                    employee.SeparationType = new SeparationType()
                    {
                        ID = row["SeparationTypeID"] == DBNull.Value ? 0 : int.Parse(row["SeparationTypeID"].ToString()),
                        Description = row["SeparationType"] == DBNull.Value ? string.Empty : row["SeparationType"].ToString(),
                    };

                    employee.OnLeave = row["OnLeave"] == DBNull.Value ? false : bool.Parse(row["OnLeave"].ToString());
                    employee.LeaveStatus = row["LeaveStatus"] == DBNull.Value ? string.Empty : row["LeaveStatus"].ToString();
                    employee.OnLeaveWithPay = row["OnLeaveWithPay"] == DBNull.Value ? false : bool.Parse(row["OnLeaveWithPay"].ToString());
                    employee.CurrentLeaveDate = row["CurrentLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveDate"].ToString());
                    employee.CurrentLeaveStartDate = row["CurrentLeaveStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveStartDate"].ToString());
                    employee.CurrentLeaveEndDate = row["CurrentLeaveEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentLeaveEndDate"].ToString());
                    employee.AnnualLeave = row["AnnualLeave"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeave"].ToString());
                    employee.AnnualLeaveYear = row["AnnualLeaveYear"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveYear"].ToString());
                    employee.AnnualLeaveDate = row["AnnualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveDate"].ToString());
                    employee.AnnualLeaveProposedStartDate = row["AnnualLeaveProposedStartDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveProposedStartDate"].ToString());
                    employee.AnnualLeaveProposedEndDate = row["AnnualLeaveProposedEndDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["AnnualLeaveProposedEndDate"].ToString());
                    employee.AnnualLeaveProposedDays = row["AnnualLeaveProposedDays"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveProposedDays"].ToString());
                    employee.AnnualLeaveEntitlement = new AnnualLeaveEntitlement()
                    {
                        ID = row["AnnualLeaveEntitlementID"] == DBNull.Value ? 0 : int.Parse(row["AnnualLeaveEntitlementID"].ToString()),
                        CategoryOfPost = row["CategoryOfPost"] == DBNull.Value ? string.Empty : row["CategoryOfPost"].ToString(),
                        NumberOfDays = row["NumberOfDays"] == DBNull.Value ? 0 : int.Parse(row["NumberOfDays"].ToString()),
                        TypeOfGrade = row["TypesOfGrade"] == DBNull.Value ? string.Empty : row["TypesOfGrade"].ToString(),
                        Status = row["AnnualLeaveStatus"] == DBNull.Value ? string.Empty : row["AnnualLeaveStatus"].ToString()
                    };
                    employee.CasualLeave = row["CasualLeave"] == DBNull.Value ? 0 : int.Parse(row["CasualLeave"].ToString());
                    employee.CasualLeaveDate = row["CasualLeaveDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CasualLeaveDate"].ToString());
                    employee.LeaveArrears = row["LeaveArrears"] == DBNull.Value ? 0 : int.Parse(row["LeaveArrears"].ToString());
                    employee.LeaveBalance = row["LeaveBalance"] == DBNull.Value ? 0 : int.Parse(row["LeaveBalance"].ToString());
                    employee.LeaveTaken = row["LeaveTaken"] == DBNull.Value ? 0 : int.Parse(row["LeaveTaken"].ToString());
                    employee.Confirmed = row["Confirmed"] == DBNull.Value ? false : bool.Parse(row["Confirmed"].ToString());
                    employee.CurrentConfirmationDate = row["CurrentConfirmationDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentConfirmationDate"].ToString());

                    employee.PromotionType = new PromotionType()
                    {
                        ID = row["PromotionTypeID"] == DBNull.Value ? 0 : int.Parse(row["PromotionTypeID"].ToString()),
                        Description = row["PromotionType"] == DBNull.Value ? string.Empty : row["PromotionType"].ToString()
                    };
                    employee.CurrentPromotionDate = row["CurrentPromotionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentPromotionDate"].ToString());

                    employee.Sanctioned = row["Sanctioned"] == DBNull.Value ? false : bool.Parse(row["Sanctioned"].ToString());
                    employee.SanctionType = new SanctionType()
                    {
                        ID = row["SanctionTypeID"] == DBNull.Value ? 0 : int.Parse(row["SanctionTypeID"].ToString()),
                        Description = row["SanctionType"] == DBNull.Value ? string.Empty : row["SanctionType"].ToString()
                    };
                    employee.CurrentSanctionDate = row["CurrentSanctionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentSanctionDate"].ToString());
                    employee.TransferType = row["TransferType"] == DBNull.Value ? string.Empty : row["TransferType"].ToString();
                    employee.TransferredOut = row["TransferredOut"] == DBNull.Value ? false : bool.Parse(row["TransferredOut"].ToString());
                    employee.TransferedIn = row["TransferredIn"] == DBNull.Value ? false : bool.Parse(row["TransferredIn"].ToString());
                    employee.TransferredInternally = row["TransferredInternally"] == DBNull.Value ? false : bool.Parse(row["TransferredInternally"].ToString());
                    employee.CurrentTransferredDate = row["CurrentTransferredDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["CurrentTransferredDate"].ToString());
                    employee.User = new User()
                    {
                        ID = row["UserID"] == DBNull.Value ? 0 : int.Parse(row["UserID"].ToString()),
                    };


                    employee.CurrentTaxRelief = row["CurrentTaxRelief"] == DBNull.Value ? 0 : decimal.Parse(row["CurrentTaxRelief"].ToString());
                    employee.CurrentTaxReliefMonth = row["CurrentTaxReliefMonth"] == DBNull.Value ? 0 : int.Parse(row["CurrentTaxReliefMonth"].ToString());
                    employee.CurrentTaxReliefYear = row["CurrentTaxReliefYear"] == DBNull.Value ? 0 : int.Parse(row["CurrentTaxReliefYear"].ToString());

                    employee.ConversionDate = row["ConversionDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["ConversionDate"].ToString());
                    employee.UpgradeDate = row["UpgradeDate"] is DBNull ? null : (Nullable<DateTime>)DateTime.Parse(row["UpgradeDate"].ToString());

                    employee.VehicleNumber = row["VehicleNumber"] is DBNull ? string.Empty : row["VehicleNumber"].ToString();
                    employee.VehicleDescription = row["VehicleDescription"] is DBNull ? string.Empty : row["VehicleDescription"].ToString();
                    employee.VehicleType = row["VehicleType"] is DBNull ? string.Empty : row["VehicleType"].ToString();
                    employee.SubBMC = row["SubBMC"] is DBNull ? string.Empty : row["SubBMC"].ToString();
                    

                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion

        #region ShowImageByStaffID
        public Employee ShowImageByStaffID(object item)
        {
            Employee employee = new Employee();
            try
            {
                Employee emplo = (Employee)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", emplo.Archived, DbType.Boolean);
                dal.CreateParameter("@StaffID", emplo.StaffID, DbType.String);
                string query = "SELECT StaffPersonalInfo.ID,StaffPersonalInfo.Image From StaffPersonalInfo Where StaffID=@StaffID AND Archived=@Archived and Terminated='False'  and TransferredOut='False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Employee empl in ShowImageData(table))
                {
                    employee = empl;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee;
        }
        #endregion

        public Image getStaffImage(object item)
        {
            Employee employee = new Employee();
            try
            {
                Employee emplo = (Employee)item;
                dal.ClearParameters();
                dal.CreateParameter("@Archived", emplo.Archived, DbType.Boolean);
                dal.CreateParameter("@StaffID", emplo.StaffID, DbType.String);
                string query = "SELECT StaffPersonalInfo.ID,StaffPersonalInfo.Image From StaffPersonalInfo Where StaffID=@StaffID AND Archived=@Archived and Terminated='False'  and TransferredOut='False'";
                DataTable table = dal.ExecuteReader(query);
                foreach (Employee empl in ShowImageData(table))
                {
                    employee = empl;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employee.Photo;
        }

        #region ShowImageData
        private IList<Employee> ShowImageData(DataTable table)
        {
            IList<Employee> employees = new List<Employee>();
            try
            {
                foreach (DataRow row in table.Rows)
                {
                    Employee employee = new Employee()
                    {
                        ID = int.Parse(row["ID"].ToString()),
                        Photo = row["Image"] is DBNull ? null : Global.ArrayToImage((byte[])row["Image"]),
                    };
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return employees;
        }
        #endregion
    }
}
