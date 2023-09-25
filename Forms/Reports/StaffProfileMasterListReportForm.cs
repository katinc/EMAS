using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using eMAS.Forms.Reports.NewReportingDataSetTableAdapters;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.Reports
{
    public partial class StaffProfileMasterListReportForm : Form
    {
        private IDAL dal;
        private ParameterFields paramFields;
        private ParameterField paramField;
        private ParameterDiscreteValue paramDiscreteValue;
        StaffProfileMasterList report;
        private DALHelper dalHelper;


        public StaffProfileMasterListReportForm(bool isDateFromDOFAChecked, bool isDateToDOFAChecked, DateTime dateFromDOFA, DateTime dateToDOFA, 
            bool isDateFromAssumptionChecked, bool isDateToAssumptionChecked, DateTime dateFromAssumption, DateTime dateToAssumption, bool isDateFromChecked, 
            bool isDateToChecked, DateTime dateFrom, DateTime dateTo, string department, string unit, string gradeCategory, string employeeGrade, string zone, 
            string mechanised, string leave, string gender, string probation, DateTime asAtDate, bool asAtDateChecked, string confirmed, DateTime date, DateTime datehistoryFrom)
        {
            InitializeComponent();
            this.dal = new DAL();
            try
            {
                string where = string.Empty;
                string sql = string.Empty;
                this.dalHelper = new DALHelper();
                dalHelper.ClearParameters();

                report = new StaffProfileMasterList();
                var ds = new DataSet();

                CompanyInfoTableAdapter companyAdapta = new CompanyInfoTableAdapter();
                var dt = new DataTable("CompanyInfo");
                dt = companyAdapta.GetData();
                ds.Tables.Add(dt);

                if (isDateFromDOFAChecked == true)
                {
                    where += " dateFromDOFA >= @DateFromDOFA and ";
                    dalHelper.CreateParameter("@DateFromDOFA", dateFromDOFA, DbType.Date);
                }

                if (isDateToDOFAChecked == true)
                {
                    where += " dateToDOFA <= @DateToDOFA and ";
                    dalHelper.CreateParameter("@DateToDOFA", dateToDOFA, DbType.Date);
                }

                if (isDateFromAssumptionChecked == true)
                {
                    where += " dateFromAssumption >= @DateFromAssumption and ";
                    dalHelper.CreateParameter("@DateFromAssumption", dateFromAssumption, DbType.Date);
                }

                if (isDateToAssumptionChecked == true)
                {
                    where += " dateToAssumption <= @DateToAssumption and ";
                    dalHelper.CreateParameter("@DateToAssumption", dateToAssumption, DbType.Date);
                }

                if (isDateFromChecked == true)
                {
                    where += " EmploymentDate >= @dateFrom and ";
                    dalHelper.CreateParameter("@dateFrom", dateFrom, DbType.Date);
                }

                if (isDateToChecked == true)
                {
                    where += " EmploymentDate <= @dateTo and ";
                    dalHelper.CreateParameter("@dateTo", dateTo, DbType.Date);
                }

                if (department.Trim().ToUpper() != "ALL" && department.Trim() != string.Empty)
                {
                    where += " Department=@Department and ";
                    dalHelper.CreateParameter("@Department", department, DbType.String);
                }

                if (unit.Trim().ToUpper() != "ALL" && unit.Trim() != string.Empty)
                {
                    where += " Unit=@Unit and ";
                    dalHelper.CreateParameter("@Unit", unit, DbType.String);
                }

                if (gradeCategory.Trim().ToUpper() != "ALL" && gradeCategory.Trim() != string.Empty && gradeCategory.Trim().ToUpper() != "NOT APPLICABLE")
                {
                    where += " gradeCategory=@gradeCategory and ";
                    dalHelper.CreateParameter("@gradeCategory", gradeCategory, DbType.String);
                }

                if (employeeGrade.Trim().ToUpper() != "ALL" && employeeGrade.Trim() != string.Empty)
                {
                    where += " Grade=@employeeGrade and ";
                    dalHelper.CreateParameter("@employeeGrade", employeeGrade, DbType.String);
                }

                if (mechanised.Trim().ToUpper() != "ALL" && mechanised.Trim() != string.Empty)
                {
                    where += " mechanised=@mechanised and ";
                    dalHelper.CreateParameter("@mechanised", mechanised, DbType.String);
                }

                if (leave.Trim().ToUpper() != "ALL" && leave.Trim() != string.Empty)
                {
                    where += " leave=@leave and ";
                    dalHelper.CreateParameter("@leave", leave, DbType.String);
                }

                if (gender.Trim().ToUpper() != "ALL" && gender.Trim() != string.Empty)
                {
                    where += " gender=@gender and ";
                    dalHelper.CreateParameter("@gender", gender, DbType.String);
                }

                if (probation.Trim().ToUpper() != "ALL" && probation.Trim() != string.Empty)
                {
                    where += " probation=@probation and ";
                    dalHelper.CreateParameter("@probation", probation, DbType.String);
                }

                if (asAtDateChecked == true && probation.Trim().ToUpper() == "YES")
                {
                    where += " ProbationEndDate <= @asAtDate and ";
                    dalHelper.CreateParameter("@asAtDate", asAtDate, DbType.Date);
                }

                if (confirmed.Trim().ToUpper() != "ALL" && confirmed.Trim() != string.Empty)
                {
                    where += " confirmed=@confirmed and ";
                    dalHelper.CreateParameter("@confirmed", confirmed, DbType.String);
                }

                string where2 = where;
                dalHelper.CreateParameter("@date", datehistoryFrom.Date, DbType.Date);
                where += " DateAndTimeGenerated >= @date and ";

                where += " DateAndTimeGenerated <= @datehistoryFrom and ";
                dalHelper.CreateParameter("@datehistoryFrom", date.Date.AddDays(1).AddTicks(-1) , DbType.Date); //getting end of day for that day else query will take current time of day

                if (where != string.Empty)
                {
                    where = " where " + where.TrimEnd(" and ".ToCharArray());       
                }

                sql = " select p.* from StaffPersonalInfoHistoryView as p inner join";
                sql += "(SELECT  dbo.StaffPersonalInfoHistoryView.StaffID, MAX(dbo.StaffPersonalInfoHistoryView.DateAndTimeGenerated) AS DateTime FROM StaffPersonalInfoHistoryView ";
                sql += where.TrimEnd(" and ".ToCharArray());
                sql += " GROUP BY StaffID) as s on p.DateAndTimeGenerated = s.DateTime ";

                var dtResults = dalHelper.ExecuteReader(sql);
                DataTable dtResult = new DataTable();
                dtResult = dtResults.Copy();

                string sql2 = ("SELECT " +
                    "[ID],[StaffID],[Surname],[Firstname],[OtherName],[NickName],[PIN],[NationalID],[GradeCategoryID],[GradeID],[StepID],[BandID],[BasicSalary],[DOB],[GenderGroupID]" +
                    ",[Gender],[TitleID],[Title],[NationalityID],[Nationality],[TownID],[HometownID],[Telno],[MobileNo],[MaritalstatusID],[MaritalStatus],[DOM],[ReligionID],[Religion]" +
                    ",[PlaceOfBirthID],[CountryOfBirthID],[DistrictOfBirthID],[NoOfchildren],[DenominationID],[Denomination],[NHISNumber],[HouseNumber],[StreetName],[ResidentialTownID]" +
                    ",[ResidentialRegionID],[ResidentialCountryID],[Address],[Email],[RegionID],[ContactCountryID],[ContactHomeTownID],[DepartmentID],[Department],[AppointmentTypeID]" +
                    ",[AppointmentType],[EmploymentDate],[SSNIT],[IncomeTax],[Probation],[ProbationStartDate],[ProbationEndDate],[ProbationStatusID],[ProbationStatus],[SSNITNo],[TIN]" +
                    ",[PaymentType],[FingerPrint],[Terminated],[TerminationDate],[OnLeave],[OnLeaveWithPay],[TransferredOut],[TransferredIn],[DateAndTimeGenerated],[UserID],[UserName]" +
                    ",[Archived],[EngagementTypeID],[EngagementType],[EngagementGradeIDOn],[EngagementGradeIDLeaving],[EngagementDateApplied],[EngagementEffectiveDate],[EngagementEndingDate]" +
                    ",[EngagementContractOption],[DOFA],[DOCA],[AssumptionDate],[SpecialtyID],[UnitID],[Unit],[JobTitleID],[JobTitle],[OccupationGroupID],[StatusID],[Status],[ZoneID]" +
                    ",[IsSusuPlusContribution],[SusuPlusContributionAmount],[IsWithholdingTax],[IsWithholdingTaxFixedAmount],[WithholdingTaxFixedAmount],[IsWithholdingTaxRate],[WithholdingTaxRate]" +
                    ",[ServerDate],[ServerTime],[ArchivedTime],[ArchivererID],[CalculateOn],[UserInfoID],[Telno_2],[MaidenName],[ResidentialTown],[HomeTown],[ContactHomeTown],[EngagementGradeOn]" +
                    ",[ResidentialRegion],[ResidentialCountry],[ContactCountry],[EngagementGradeLeaving],[CountryOfBirth],[PlaceOfBirth],[SalaryLevelID],[SalaryTypeID],[SalaryType]" +
                    ",[InDepartmentDate],[CurrentLeaveDate],[TransferredInternally],[CurrentTransferredDate],[Confirmed],[CurrentConfirmationDate],[CurrentPromotionDate],[InZoneDate]" +
                    ",[GradeDate],[QualificationID],[Qualification],[CurrentSanctionDate],[SanctionTypeID],[SanctionType],[Age],[Sanctioned],[TransferType],[Payment],[IncrementDate]" +
                    ",[LeaveArrears],[AnnualLeave],[AnnualLeaveDate],[AnnualLeaveYear],[CasualLeave],[CasualLeaveDate],[LeaveTaken],[LeaveBalance],[RegionOfBirthID],[RegionOfBirth]" +
                    ",[Mechanised],[IsInSalaryInfo],[OldBasicSalary],[SalaryGrouping],[LicenceNumber],[IsDisable],[DisabilityDate],[DisabilityTypeID],[LicenceTypeID],[EngagementAnnualSalary]" +
                    ",[GradeOnFirstAppointment],[Confirmer],[CurrentConfirmationTime],[ProbationApprover],[ProbationApprovedDate],[ProbationApprovedTime],[GradeOnFirstAppointmentID]" +
                    ",[PromotionTypeID],[PromotionType],[SeparationTypeID],[SeparationType],[AnnualLeaveEntitlementID],[CategoryOfPost],[TypesOfGrade],[AnnualLeaveStatus],[NumberOfDays]" +
                    ",[AnnualLeaveProposedStartDate],[AnnualLeaveProposedEndDate],[AnnualLeaveProposedDays],[LeaveStatus],[CurrentLeaveStartDate],[CurrentLeaveEndDate],[IsProvidentFund]" +
                    ",[LicenceType],[DisabilityType],[Step],[Grade],[GradeCategory],[Band],[Region],[Specialty],[Town],[DistrictOfBirth],[Zone],[OccupationGroup],[Tribe],[SupervisorCode]" +
                    ",[Overseer],[JobTitleDate],[SupervisorStaffID],[SupervisorSurname],[SupervisorFirstname],[SupervisorOtherName],[SupervisorTitle],[SupervisorGender],[SupervisorJobTitle]" +
                    ",[SupervisorUnit],[SupervisorDepartment],[SupervisorEmail],[SupervisorMobileNo],[SupervisorTelno],[SupervisorGrade],[SupervisorGradeCategory],[IsExemptFromSecondTier]" +
                    ",[RaceID],[Race],[Hourly],[GradeCategoryCode],[GradeCode],[DepartmentCode],[UnitCode],[PFRate],[StaffResidenceName],[DirectorateID],[Directorate],[PaymentAccType]" +
                    ",[UserType],[GPSAddress],[Image],[FileNumber],[FileLocation] ");
                sql2 += " FROM dbo.StaffPersonalInfoView where Archived = 'false' and TransferredOut = 'false'";

                //where2 += " Terminated=@ and ";
                //dalHelper.CreateParameter("@terminated", false, DbType.Boolean);

                //where2 += " Archived=@Archived";
                //dalHelper.CreateParameter("@Archived", false, DbType.Boolean);

                if (isDateFromChecked == true)
                {
                    //where2 += " TerminationDate <= @dateFrom and";
                    //dalHelper.CreateParameter("@dateFrom", dateFrom, DbType.Date);
                }
                else
                {
                    //where2 += " TerminationDate >= @dateTo and";
                    dalHelper.CreateParameter("@dateTo", DateTime.Now, DbType.Date);
                }

                if (isDateToChecked == true)
                {
                    //where2 += " TerminationDate >= @dateTo and";
                    //dalHelper.CreateParameter("@dateTo", dateTo, DbType.Date);
                }
                else
                {
                    //where2 += " TerminationDate >= @dateTo and";
                    dalHelper.CreateParameter("@dateTo", new DateTime(2015,1,1), DbType.Date);
                }

                string andSql = string.Empty;

                if (isDateFromChecked == true || isDateToChecked == true)
                {
                    //where2 += " Terminated = @Terminated ";
                    //dalHelper.CreateParameter("@Terminated", false, DbType.Boolean);

                    andSql = " StaffID not in ( select staffid from StaffPersonalInfo where Terminated = 'True' and(TerminationDate between @dateFrom and @dateTo))";
                }
                else if(isDateFromChecked == false && isDateToChecked == false)
                {
                    where2 += " Terminated=@terminated";
                    dalHelper.CreateParameter("@terminated", false, DbType.Boolean);
                }

                if (where2 != string.Empty)
                {
                    //where2 = " where " + where2.TrimEnd(" and ".ToCharArray());
                    where2 = " and " + where2;
                }

                sql2 += where2;
                sql2 += andSql;

                //if (where2.Trim().EndsWith("and"))
                //{
                //    where2 = where2.Trim().TrimEnd("and".ToCharArray());
                //}

                //sql2 += where2.TrimEnd(" and ".ToCharArray());
                sql2 += " order by staffid asc";

                var nonHistoryEmployee = dalHelper.ExecuteReader(sql2);

                
                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dtResults.Columns["StaffId"];
                dtResults.PrimaryKey = keyColumns;
                DataTable employees = new DataTable();

                DataTable resultTable = new DataTable();

                //int ctr = 0;
                if (dtResults.Rows.Count != 0)
                {
                    foreach (DataRow item in nonHistoryEmployee.Rows)
                    {
                        foreach (DataRow item2 in dtResults.Rows)
                        {
                            string str1 = item["StaffID"].ToString();
                            string st2 = item2["StaffID"].ToString();
                            if (item["StaffID"].ToString() != item2["StaffID"].ToString())
                            {
                                dtResult.Rows.Add(item.ItemArray);
                            }
                        }
                        //if (!Enumerable.SequenceEqual(dtResults.Rows[ctr].ItemArray, item.ItemArray))
                        //{
                        //    dtResults.Rows.Add(item.ItemArray);
                        //}
                        //ctr++;
                    }
                }


                if (dtResults.Rows.Count != 0)
                {
                    resultTable = dtResult.Copy();
                }
                else
                {
                    resultTable = nonHistoryEmployee.Copy();
                }
                

                string grade = employeeGrade.ToString();

                ds.Tables.Add(dtResults);
                report.SetDataSource(ds);
                report.Database.Tables[0].SetDataSource(dt);
                report.Database.Tables[1].SetDataSource(resultTable);
                report.SetParameterValue("Department", department);
                report.SetParameterValue("Unit", unit);
                report.SetParameterValue("GradeCategory", gradeCategory);
                report.SetParameterValue("Grade", grade);
                report.SetParameterValue("Leave", leave);
                report.SetParameterValue("DateFrom", dateFrom);
                report.SetParameterValue("DateTo", dateTo);
                report.SetParameterValue("IsDateFromChecked", isDateFromChecked);
                report.SetParameterValue("IsDateToChecked", isDateToChecked);
                report.SetParameterValue("Gender", gender);
                report.SetParameterValue("Mechanised", mechanised);
                report.SetParameterValue("Probation", probation);
                report.SetParameterValue("AsAtDate", asAtDate);
                report.SetParameterValue("AsAtDateChecked", asAtDateChecked);
                report.SetParameterValue("Confirmed", confirmed);
                report.SetParameterValue("DateFromDOFA", dateFromDOFA);
                report.SetParameterValue("DateToDOFA", dateToDOFA);
                report.SetParameterValue("IsDateFromDOFAChecked", isDateFromDOFAChecked);
                report.SetParameterValue("IsDateToDOFAChecked", isDateToDOFAChecked);
                report.SetParameterValue("DateFromAssumption", dateFromAssumption);
                report.SetParameterValue("IsDateFromAssumptionChecked", isDateFromAssumptionChecked);
                report.SetParameterValue("IsDateToAssumptionChecked", isDateToAssumptionChecked);
                report.SetParameterValue("Zone", zone);

                crystalReportViewer1.ReportSource = report;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffProfileMasterListReportForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void StaffProfileMasterListReportForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                crystalReportViewer1.ShowPrintButton = btnPrintReport.Visible;
                crystalReportViewer1.ShowExportButton = btnExportReport.Visible;
                btnPrintReport.Visible = false;
                btnExportReport.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
