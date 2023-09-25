using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using eMAS.All_UIs.PayRoll_Processing_FORMS.Staff_Attendance_FORMS;
using eMAS.All_UIs.System_SetupFORMS;
using HRBussinessLayer.ErrorLogging;
using eMAS.All_UIs.Applicants;
using eMAS.Forms.Reports;
using eMAS.Forms.StaffInformation;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.Forms;
using eMAS.Forms.System_SetupFORMS;
using eMAS.Forms.SystemSetup;
using eMAS.Forms.PayRollProcessing;
using eMAS.Forms.StaffManagement;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using eMAS.Forms.Employment;
using eMAS.Forms.SMS;
using eMAS.Forms.TimeAndAttendance;
using eMAS.Forms.EmployeeManagement;
using HRDataAccessLayer;

namespace eMAS
{
    public partial class MainMDI : Form
    {
        #region FORMS OBJECT DECLEARATION

        private Hire_Purchase hire_purchase;
        private LeaveRequest leave;
        private MedicalClaimsNew medical_claims;
        private OverTimeNew overtime;
        private TerminationNew terminationNew;
        private Loans_Payments loans_payments;
        private Loans loans;
        private PayrollGeneration payrollGeneration;
        private PayRoll_PaySlip payRoll__paySlip;
        private Allowance_Setup allowance_setup;
        private Deduction_Setup deduction_setup;
        private DepartmentsForm departmentList;
        private Employee_Grades employee_grades;
        private Form employeeRegistration;
        private Grade_Category grade_category;
        private Loans_Setup loans_setup;
        private SSNIT_Contribution ssnit_contribution;
        private Taxable_Income taxable_income;
        private Dictionary<string, string> oldMenuToolTips;
        private MenuStrip parts;
        private IDAL dal;
        private DALHelper dali;
        #endregion

        

        public MainMDI()
        {
            try
            {
                InitializeComponent();
                this.dali = new DALHelper();
                this.dal = new DAL();
                this.oldMenuToolTips = new Dictionary<string, string>();
                this.parts = new MenuStrip();
                menuStrip2 = menuStrip1;
                this.MakeMenusInvisible();
                
                menuStrip1.Visible = true;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        public ToolStripItemCollection getMainMenuScript()
        {
            return menuStrip1.Items;
        }

        private void MainMDI_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Login login = new Login(this,menuStrip1.Items,menuStrip2.Items);
                login.MdiParent = this;
                login.Show();                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void Exit()
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void vacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewVacancy newVacancy = new NewVacancy();
                newVacancy.MdiParent = this;
                newVacancy.Show();
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void loansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loans = new Loans();
                loans.MdiParent = this;
                loans.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loansPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loans_payments = new Loans_Payments();
                loans_payments.MdiParent = this;
                loans_payments.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                payrollGeneration = new PayrollGeneration();
                payrollGeneration.MdiParent = this;
                payrollGeneration.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void payRollPaySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                payRoll__paySlip = new PayRoll_PaySlip();
                payRoll__paySlip.MdiParent = this;
                payRoll__paySlip.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void overTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                overtime = new OverTimeNew();
                overtime.MdiParent = this;
                overtime.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void hirePurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                hire_purchase = new Hire_Purchase();
                hire_purchase.MdiParent = this;
                hire_purchase.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void terminationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                terminationNew = new TerminationNew();
                terminationNew.MdiParent = this;
                terminationNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void allowanceSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                allowance_setup = new Allowance_Setup();
                allowance_setup.MdiParent = this;
                allowance_setup.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loans = new Loans();
                loans.MdiParent = this;
                loans.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loanPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                loans_payments = new Loans_Payments();
                loans_payments.MdiParent = this;
                loans_payments.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void payrollGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                payrollGeneration = new PayrollGeneration();
                payrollGeneration.MdiParent = this;
                payrollGeneration.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void payRollPaySlipToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                payRoll__paySlip = new PayRoll_PaySlip();
                payRoll__paySlip.MdiParent = this;
                payRoll__paySlip.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void newApplicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewApplicant applicant = new NewApplicant();
                applicant.MdiParent = this;
                applicant.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void newVacancyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewVacancy vacancy = new NewVacancy();
                vacancy.MdiParent = this;
                vacancy.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void overTimeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                OverTimeNew overTime = new OverTimeNew();
                overTime.MdiParent = this;
                overTime.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void hirePurchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                hire_purchase = new Hire_Purchase();
                hire_purchase.MdiParent = this;
                hire_purchase.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void incomeTaxReturnsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IncomeTaxReturnsSelect irsSelect = new IncomeTaxReturnsSelect();
                irsSelect.MdiParent = this;
                irsSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sSNITReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SSNITReturnsSelect ssnitReport = new SSNITReturnsSelect();
                ssnitReport.MdiParent = this;
                ssnitReport.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void loansToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                LoansReportSelect lp = new LoansReportSelect();
                lp.MdiParent = this;
                lp.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loanPaymentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                LoanPaymentsReportSelect lps = new LoanPaymentsReportSelect();
                lps.MdiParent = this;
                lps.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void overTimeReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OverTimeReportSelect ov = new OverTimeReportSelect();
                ov.MdiParent = this;
                ov.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveReportSelect lrs = new LeaveReportSelect();
                lrs.MdiParent = this;
                lrs.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void medicalClaimsReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalClaimsReportMonthlySelect mc = new MedicalClaimsReportMonthlySelect();
                mc.MdiParent = this;
                mc.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void allowanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AllowancesReportForm rpt = new AllowancesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentsReportForm rpt = new DepartmentsReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void deductionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DeductionsReportForm rpt = new DeductionsReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GradesReportForm rpt = new GradesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void employeeGradesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                grade_category = new Grade_Category();
                grade_category.MdiParent = this;
                grade_category.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void graToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                employee_grades = new Employee_Grades();
                employee_grades.MdiParent = this;
                employee_grades.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void sdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                taxable_income = new Taxable_Income();
                taxable_income.MdiParent = this;
                taxable_income.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void loansToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                loans_setup = new Loans_Setup();
                loans_setup.MdiParent = this;
                loans_setup.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ssnit_contribution = new SSNIT_Contribution();
                ssnit_contribution.MdiParent = this;
                ssnit_contribution.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void holidaysToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                HolidaysForm holidayForm = new HolidaysForm();
                holidayForm.MdiParent = this;
                holidayForm.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                employeeRegistration = new EmployeeMaintenance();
                employeeRegistration.MdiParent = this;
                employeeRegistration.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserNew userNew = new UserNew();
                userNew.MdiParent = this;
                userNew.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void salaryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SalaryInfoNew salaryInfo = new SalaryInfoNew();
                salaryInfo.MdiParent = this;
                salaryInfo.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void allowancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AllowanceNew allowance = new AllowanceNew();
                allowance.MdiParent = this;
                allowance.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void deductionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DeductionsNew deduction = new DeductionsNew();
                deduction.MdiParent = this;
                deduction.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void employeeBanksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Employee_Banks employeeBanks = new Employee_Banks();
                employeeBanks.MdiParent = this;
                employeeBanks.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void applicantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewApplicant newApplicant = new NewApplicant();
                newApplicant.MdiParent = this;
                newApplicant.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void promotionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewPromotion newPromotion = new NewPromotion();
                newPromotion.MdiParent = this;
                newPromotion.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void userLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserRoles userCategory = new UserRoles();
                userCategory.MdiParent = this;
                userCategory.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void basicInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CompanyInfo companyInfo = new CompanyInfo();
                companyInfo.MdiParent = this;
                companyInfo.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void userRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserCategories userCategories = new UserCategories();
                userCategories.MdiParent = this;
                userCategories.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void MakeMenusVisible()
        {
            try
            {
                menuStrip1.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        

        private void  SetToolStripItems(ToolStripItemCollection dropDownItems)
        {
            try
            {
                foreach (object obj in dropDownItems)
                //for each object because it could be toolstrip separator as well.
                {
                    if (obj.GetType().Equals(typeof(ToolStripMenuItem)))
                    //if we get the desired object type.
                    {
                        ToolStripMenuItem subMenu = (ToolStripMenuItem)obj;
                        // cast to ToolStripMenuItem

                        if (subMenu.HasDropDownItems) // if subMenu has children
                        {
                            SetToolStripItems(subMenu.DropDownItems); // Call recursive Method.
                        }
                        else // Do the desired operations here.
                        {
                            if (subMenu.Tag != null)
                            {
                                subMenu.Visible = false;
                                subMenu.Enabled = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SetToolStripItems", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowToolStipItems(ToolStripItemCollection toolStripItems)
        {
            foreach (ToolStripMenuItem mi in toolStripItems)
            {
                oldMenuToolTips.Add(mi.Name, mi.ToolTipText);
                //mi.ToolTipText = mi.Name;

                if (mi.DropDownItems.Count > 0)
                {
                    ShowToolStipItems(mi.DropDownItems);
                }
                mi.Enabled = false;
                mi.Visible = false;

                
            }
        }

        public void MakeMenusInvisible()
        {
            try
            {
                menuStrip1.Visible = true;
                ShowToolStipItems(menuStrip1.Items);
                

                //// if we have a MenuStrip named ts.

                //foreach (ToolStripMenuItem main in this.menuStrip1.Items)
                //{
                //    // navigate through each submenu
                //    SetToolStripItems(main.DropDownItems);
                //    //var t = main.Name;
                //    //var r = main.Visible;
                //    //var g = main.Enabled;
                //    //if (main.Visible == true)
                //    //{
                //    //    // navigate through each submenu
                //    //    SetToolStripItems(main.DropDownItems);
                //    //}
                //}
                //menuStrip1.Visible = false;

                ////Disable 1st Access Levels
                //staffInformationToolStripMenuItem.Visible = false;
                //payrollProcessingToolStripMenuItem.Visible = false;
                //claimsLeaveHirePurchaseToolStripMenuItem.Visible = false;
                //reportsToolStripMenuItem.Visible = false;
                //systemSetupToolStripMenuItem1.Visible = false;
                //timeAndAttendanceToolStripMenuItem.Visible = false;

                ////Disable Second Access Levels
                ////Employment
                //employeeToolStripMenuItem.Visible = false;
                //interviewsToolStripMenuItem.Visible = false;
                //interviewToolStripMenuItem.Visible = false;
                //vacancyToolStripMenuItem.Visible = false;
                //applicantToolStripMenuItem.Visible = false;
                
                ////PayRoll Management
                //salaryInfoToolStripMenuItem.Visible = false;
                //allowancesToolStripMenuItem.Visible = false;
                //deductionsToolStripMenuItem.Visible = false;
                //loansSalaryAdvanceToolStripMenuItem.Visible = false;
                //employeeBanksToolStripMenuItem.Visible = false;
                //staffAttendanceToolStripMenuItem.Visible = false;
                //medicalClaimsToolStripMenuItem.Visible = false;

                ////Employee Management
                //leaveToolStripMenuItem.Visible = false;
                //terminationToolStripMenuItem.Visible = false;
                //performalAppraisalToolStripMenuItem.Visible = false;
                //trainingToolStripMenuItem.Visible = false;
                //benefitToolStripMenuItem.Visible = false;
                //promotionsDemotionsToolStripMenuItem.Visible = true;
                //discipilinaryToolStripMenuItem.Visible = true;
                //incrementToolStripMenuItem.Visible = true;

                ////Time And Attendance
                //timeAndAttendanceToolStripMenuItem1.Visible = false;
                //checkInOutToolStripMenuItem.Visible = false;
                //dutyRoasterToolStripMenuItem.Visible = false;
                //timeAndAttendanceToolStripMenuItem1.Visible = false;

                ////SystemSetup
                //departmentsToolStripMenuItem1.Visible = false;
                //usersToolStripMenuItem.Visible = false;
                //recruitmentAndStaffingToolStripMenuItem.Visible = false;
                //payrollManagementToolStripMenuItem.Visible = false;
                //staffManagementToolStripMenuItem.Visible = false;
                //timeAndAttendanceToolStripMenuItem1.Visible = false;

                ////Reports
                //generalReportToolStripMenuItem.Visible = false;
                //payRollReportsToolStripMenuItem.Visible = false;
                //staffProfileToolStripMenuItem.Visible = false;
                //staffAttendanceToolStripMenuItem2.Visible = false;
                //applicantsToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void SetAccessLevels(int userID)
        {
            try
            {
                //DataTable accessTable = new DALHelper().ExecuteReader("Select UserAccessLevels.UserID,UserAccessLevels.UserCategoryID,UserCategories.Description as UserCategory,UserAccessLevels.AccessLevel1ID,UserAccessLevel1.Description as AccessLevel1,UserAccessLevels.AccessLevel2ID,UserAccessLevel2.Description as AccessLevel2,UserAccessLevels.CanView,UserAccessLevels.CanPrint,UserAccessLevels.CanDelete,UserAccessLevels.CanEdit,UserAccessLevels.CanAdd From UserAccessLevels Inner join UserCategories on UserCategories.ID = UserAccessLevels.UserCategoryID Inner Join UserAccessLevel1 on UserAccessLevel1.ID = UserAccessLevels.AccessLevel1ID Inner Join UserAccessLevel2 on UserAccessLevel2.ID = UserAccessLevels.AccessLevel2ID Where UserAccessLevels.UserID =" + userID + " Order By UserCategory,AccessLevel1,AccessLevel2");
                //menuStrip1.Visible = true;
                //foreach (DataRow row in accessTable.Rows)
                //{
                //    if (row["AccessLevel1"].ToString() == "Employment")
                //    {
                //        staffInformationToolStripMenuItem.Visible = true;
                //        if (row["AccessLevel2"].ToString().Trim() == "Employee")
                //        {
                //            employeeToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString().Trim() == "Applicant")
                //        {
                //            applicantToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString().Trim() == "Vacancy")
                //        {
                //            vacancyToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString().Trim() == "Transfers")
                //        {
                //            transferToolStripMenuItem1.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString().Trim() == "Interviews")
                //        {
                //            interviewsToolStripMenuItem.Visible = true;
                //            interviewToolStripMenuItem.Visible = true;
                //        }

                //    }
                //    if (row["AccessLevel1"].ToString() == "PayRoll Management")
                //    {
                //        payrollProcessingToolStripMenuItem.Visible = true;
                //        if (row["AccessLevel2"].ToString() == "Salary Info")
                //        {
                //            salaryInfoToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Allowances")
                //        {
                //            allowancesToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Deductions")
                //        {
                //            deductionsToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Loans")
                //        {
                //            loansSalaryAdvanceToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Employee Banks")
                //        {
                //            employeeBanksToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "PayRoll Generation")
                //        {
                //            staffAttendanceToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Medical Claims")
                //        {
                //            medicalClaimsToolStripMenuItem.Visible = true;
                //        }
                //    }
                //    if (row["AccessLevel1"].ToString() == "Time And Attendance")
                //    {
                //        timeAndAttendanceToolStripMenuItem.Visible = true;
                //        if (row["AccessLevel2"].ToString() == "Time Card Management")
                //        {
                //            timeCardManagementToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Check In / Out")
                //        {
                //            checkInOutToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Duty Roaster")
                //        {
                //            dutyRoasterToolStripMenuItem.Visible = true;
                //        }
                //    }

                //    if (row["AccessLevel1"].ToString() == "Employee Management")
                //    {
                //        claimsLeaveHirePurchaseToolStripMenuItem.Visible = true;

                //        if (row["AccessLevel2"].ToString() == "Leave")
                //        {
                //            leaveToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Termination")
                //        {
                //            terminationToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Performance Appraisal")
                //        {
                //            performalAppraisalToolStripMenuItem.Visible = true;
                //        }
                //    }

                //    if (row["AccessLevel1"].ToString() == "System Setup")
                //    {
                //        systemSetupToolStripMenuItem1.Visible = true;
                //        if (row["AccessLevel2"].ToString() == "Company")
                //        {
                //            departmentsToolStripMenuItem1.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Employment")
                //        {
                //            recruitmentAndStaffingToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "PayRoll Management")
                //        {
                //            payrollManagementToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Time And Attendance")
                //        {
                //            timeAndAttendanceToolStripMenuItem1.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Staff Management")
                //        {
                //            staffManagementToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "User Accounts")
                //        {
                //            usersToolStripMenuItem.Visible = true;
                //        }
                //    }

                //    if (row["AccessLevel1"].ToString() == "Reports")
                //    {
                //        reportsToolStripMenuItem.Visible = true;

                //        if (row["AccessLevel2"].ToString() == "Organisational Reports")
                //        {
                //            generalReportToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "PayRoll Management")
                //        {
                //            payRollReportsToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Staff")
                //        {
                //            staffProfileToolStripMenuItem.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Staff Management")
                //        {
                //            staffAttendanceToolStripMenuItem2.Visible = true;
                //        }
                //        if (row["AccessLevel2"].ToString() == "Recruitment")
                //        {
                //            recruitmentAndStaffingToolStripMenuItem.Visible = true;
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void shiftsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Shifts form = new Shifts();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void rosterGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RosterGroups form = new RosterGroups();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void overTimeToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                OverTimeNew form = new OverTimeNew();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dutyRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DutyRoasterReportOptions form = new DutyRoasterReportOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void interviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Interview form = new Interview();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void pensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PensioneersReportFormOptions form = new PensioneersReportFormOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void vacanciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                VacanciesReportFormOptions form = new VacanciesReportFormOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void appointmentTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentTypeForm form = new AppointmentTypeForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void nationalitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Nationalities form = new Nationalities();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void regionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Districts form = new Districts();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void townsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Towns form = new Towns();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void titlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Titles form = new Titles();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void religionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Religions form = new Religions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void relationshipsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Relationships form = new Relationships();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void documentGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentGroups documentGroupsForm = new DocumentGroups();
                documentGroupsForm.MdiParent = this;
                documentGroupsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Grade_Category form = new Grade_Category();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Employee_Grades form = new Employee_Grades();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void timeCardManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TimeCards form = new TimeCards();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dutyRoasterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                DutyRoster form = new DutyRoster();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void roasterGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RosterGroups form = new RosterGroups();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void shiftsToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                Shifts form = new Shifts();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void holidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HolidaysForm form = new HolidaysForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void rosterGroupsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Leave_Types form = new Leave_Types();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void requestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                leave = new LeaveRequest();
                leave.MdiParent = this;
                leave.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void requestsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                medical_claims = new MedicalClaimsNew();
                medical_claims.MdiParent = this;
                medical_claims.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void appraisalPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppraisalTypes form = new AppraisalTypes();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void appraisalQuestionaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppraisalQuestionaires form = new AppraisalQuestionaires();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void employeeAppraisalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeAppraisalStartPage form = new EmployeeAppraisalStartPage();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void supervisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dali.ExecuteReader("Select DDepartments.ID From DDepartments inner join StaffPersonalInfo on StaffPersonalInfo.StaffID = DDepartments.SupervisorID ").Rows.Count > 0)
                {
                    SupervisorAppraisal form = new SupervisorAppraisal();
                    form.MdiParent = this;
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Sorry this section can only be used by supervisors", GlobalData.Caption);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void appraisalEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppraisalEvaluationSetup form = new AppraisalEvaluationSetup();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void otherDeductionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                deduction_setup = new Deduction_Setup();
                deduction_setup.MdiParent = this;
                deduction_setup.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sSNITContributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ssnit_contribution = new SSNIT_Contribution();
                ssnit_contribution.MdiParent = this;
                ssnit_contribution.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void allowanceTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                allowance_setup = new Allowance_Setup();
                allowance_setup.MdiParent = this;
                allowance_setup.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void payRollAndPaySlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                payRoll__paySlip = new PayRoll_PaySlip();
                payRoll__paySlip.MdiParent = this;
                payRoll__paySlip.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void incomeTaxReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                IncomeTaxReturnsSelect form = new IncomeTaxReturnsSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sSNITReturnsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SSNITReturnsSelect form = new SSNITReturnsSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileReportSelect staffProfile = new StaffProfileReportSelect();
                staffProfile.MdiParent = this;
                staffProfile.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loansToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                LoansReportSelect form = new LoansReportSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void pensioneersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PensioneersReportFormOptions form = new PensioneersReportFormOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void detailedProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffDetailedProfileSelect form = new StaffDetailedProfileSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoanPaymentsReportSelect form = new LoanPaymentsReportSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void medicalClaimsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                medical_claims = new MedicalClaimsNew();
                medical_claims.MdiParent = this;
                medical_claims.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void incomeTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                taxable_income = new Taxable_Income();
                taxable_income.MdiParent = this;
                taxable_income.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void loansToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Loans_Setup loansSetup = new Loans_Setup();
                loansSetup.MdiParent = this;
                loansSetup.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void applicantsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicantsReportFormOptions form = new ApplicantsReportFormOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changePasswordToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ChangePassword changePasswordForm = new ChangePassword();
                changePasswordForm.MdiParent = this;
                changePasswordForm.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Login login = new Login(this,menuStrip1.Items,menuStrip2.Items);
                login.MdiParent = this;
                login.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void attendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                AttendanceReportSelect staffAttendance = new AttendanceReportSelect();
                staffAttendance.MdiParent = this;
                staffAttendance.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dutyRoasterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                DutyRoasterReportOptions form = new DutyRoasterReportOptions();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void restartToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void medicalClaimsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalClaimsReportMonthlySelect form = new MedicalClaimsReportMonthlySelect();
                form.MdiParent = this;
                form.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StepForm steps = new StepForm();
                steps.MdiParent = this;
                steps.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void internshipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InternshipNewForm internshipNew = new InternshipNewForm();
                internshipNew.MdiParent = this;
                internshipNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bankAdviceSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BankAdviceSlipSelect bankAdviceSlip = new BankAdviceSlipSelect();
                bankAdviceSlip.MdiParent = this;
                bankAdviceSlip.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BankForm bankForm = new BankForm();
                bankForm.MdiParent = this;
                bankForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bankBranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BankBranchForm bankBranchForm = new BankBranchForm();
                bankBranchForm.MdiParent = this;
                bankBranchForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void jobTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                JobTitleForm jobTitleForm = new JobTitleForm();
                jobTitleForm.MdiParent = this;
                jobTitleForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void denominationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DenominationForm denominationForm = new DenominationForm();
                denominationForm.MdiParent = this;
                denominationForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UnitForm unitForm = new UnitForm();
                unitForm.MdiParent = this;
                unitForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void specialtyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SpecialtyForm specialtyForm = new SpecialtyForm();
                specialtyForm.MdiParent = this;
                specialtyForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileForm fileForm = new FileForm();
                fileForm.MdiParent = this;
                fileForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void transfersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Transfers form = new Transfers();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void trainingAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TrainingNewForm trainingNew = new TrainingNewForm();
                trainingNew.MdiParent = this;
                trainingNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void demotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DemotionForm demotionForm = new DemotionForm();
                demotionForm.MdiParent = this;
                demotionForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void editPromotionDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionCorrectForm promotionCorrectForm = new PromotionCorrectForm();
                promotionCorrectForm.MdiParent = this;
                promotionCorrectForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void correctDemotionDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DemotionCorectForm demotionCorectForm = new DemotionCorectForm();
                demotionCorectForm.MdiParent = this;
                demotionCorectForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void promotionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionReportSelect promotionReportSelect = new PromotionReportSelect();
                promotionReportSelect.MdiParent = this;
                promotionReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void demotionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DemotionReportSelect demotionReportSelect = new DemotionReportSelect();
                demotionReportSelect.MdiParent = this;
                demotionReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void transferListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TransferReportSelect transferReportSelect = new TransferReportSelect();
                transferReportSelect.MdiParent = this;
                transferReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void promotionListOfStaffDueForPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionDueStaffForm promotionDueStaffForm = new PromotionDueStaffForm();
                promotionDueStaffForm.MdiParent = this;
                promotionDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void transaferListStaffDueOnTransferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TransferDueStaffForm transferDueStaffForm = new TransferDueStaffForm();
                transferDueStaffForm.MdiParent = this;
                transferDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void demotionListOfStaffDueForDemotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DemotionDueStaffForm demotionDueStaffForm = new DemotionDueStaffForm();
                demotionDueStaffForm.MdiParent = this;
                demotionDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void annualLeavecClculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AnnualCalculateLeaveForm annualCalculateLeaveForm = new AnnualCalculateLeaveForm();
                annualCalculateLeaveForm.MdiParent = this;
                annualCalculateLeaveForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void lengthOfServiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByLengthOfServiceSelect staffListByLengthOfServiceSelect = new StaffListByLengthOfServiceSelect();
                staffListByLengthOfServiceSelect.MdiParent = this;
                staffListByLengthOfServiceSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByAgeSelect staffListByAgeSelect = new StaffListByAgeSelect();
                staffListByAgeSelect.MdiParent = this;
                staffListByAgeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByGenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileByGenderSelect staffProfileByGenderSelect = new StaffProfileByGenderSelect();
                staffProfileByGenderSelect.MdiParent = this;
                staffProfileByGenderSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListRetiringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListRetiringSelect staffListRetiringSelect = new StaffListRetiringSelect();
                staffListRetiringSelect.MdiParent = this;
                staffListRetiringSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByBankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByBankSelect staffListByBankSelect = new StaffListByBankSelect();
                staffListByBankSelect.MdiParent = this;
                staffListByBankSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByJobSelect staffListByJobSelect = new StaffListByJobSelect();
                staffListByJobSelect.MdiParent = this;
                staffListByJobSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByZoneSelect staffListByZoneSelect = new StaffListByZoneSelect();
                staffListByZoneSelect.MdiParent = this;
                staffListByZoneSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void lettersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BirthDayLettersSelect birthDayLettersSelect = new BirthDayLettersSelect();
                birthDayLettersSelect.MdiParent = this;
                birthDayLettersSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listOfStaffCelebratingBirthdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListBirthDaysSelect staffListBirthDaysSelect = new StaffListBirthDaysSelect();
                staffListBirthDaysSelect.MdiParent = this;
                staffListBirthDaysSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileByGradeSelect staffProfileByGradeSelect = new StaffProfileByGradeSelect();
                staffProfileByGradeSelect.MdiParent = this;
                staffProfileByGradeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffDurationOnAGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileByGradeDurationSelect staffProfileByGradeDurationSelect = new StaffProfileByGradeDurationSelect();
                staffProfileByGradeDurationSelect.MdiParent = this;
                staffProfileByGradeDurationSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void distributionByAgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsAgeDistributionByAgeRangeSelect statisticsAgeDistributionByAgeRangeSelect = new StatisticsAgeDistributionByAgeRangeSelect();
                statisticsAgeDistributionByAgeRangeSelect.MdiParent = this;
                statisticsAgeDistributionByAgeRangeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void distributionByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsAgeDistributionByCategorySelect statisticsAgeDistributionByCategorySelect = new StatisticsAgeDistributionByCategorySelect();
                statisticsAgeDistributionByCategorySelect.MdiParent = this;
                statisticsAgeDistributionByCategorySelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void distributionByGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsAgeDistributionByGradeSelect statisticsAgeDistributionByGradeSelect = new StatisticsAgeDistributionByGradeSelect();
                statisticsAgeDistributionByGradeSelect.MdiParent = this;
                statisticsAgeDistributionByGradeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsGenderDistributionSelect statisticsGenderDistributionSelect = new StatisticsGenderDistributionSelect();
                statisticsGenderDistributionSelect.MdiParent = this;
                statisticsGenderDistributionSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void lengthOfServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsLengthOfServiceSelect statisticsLengthOfServiceSelect = new StatisticsLengthOfServiceSelect();
                statisticsLengthOfServiceSelect.MdiParent = this;
                statisticsLengthOfServiceSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void distributionByZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsGenderDistributionByZoneSelect statisticsGenderDistributionByZoneSelect = new StatisticsGenderDistributionByZoneSelect();
                statisticsGenderDistributionByZoneSelect.MdiParent = this;
                statisticsGenderDistributionByZoneSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void distributionByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsGenderDistributionByCategorySelect statisticsGenderDistributionByCategorySelect = new StatisticsGenderDistributionByCategorySelect();
                statisticsGenderDistributionByCategorySelect.MdiParent = this;
                statisticsGenderDistributionByCategorySelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void joinersStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticsJoinersSelect statisticsJoinersSelect = new StatisticsJoinersSelect();
                statisticsJoinersSelect.MdiParent = this;
                statisticsJoinersSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffDurationAtAZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileByZoneDurationSelect staffProfileByZoneDurationSelect = new StaffProfileByZoneDurationSelect();
                staffProfileByZoneDurationSelect.MdiParent = this;
                staffProfileByZoneDurationSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void joinersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                JoinersSelect joinersSelect = new JoinersSelect();
                joinersSelect.MdiParent = this;
                joinersSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void dependentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffProfileByDependentsSelect staffProfileByDependentsSelect = new StaffProfileByDependentsSelect();
                staffProfileByDependentsSelect.MdiParent = this;
                staffProfileByDependentsSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void confirmationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConfirmationForm confirmationForm = new ConfirmationForm();
                confirmationForm.MdiParent = this;
                confirmationForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listOfStaffDueForConfirmationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ConfirmationDueStaffForm confirmationDueStaffForm = new ConfirmationDueStaffForm();
                confirmationDueStaffForm.MdiParent = this;
                confirmationDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sanctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SanctionForm sanctionForm = new SanctionForm();
                sanctionForm.MdiParent = this;
                sanctionForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void editSanctionStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SanctionedStaffForm sanctionedStaffForm = new SanctionedStaffForm();
                sanctionedStaffForm.MdiParent = this;
                sanctionedStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sanctionsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SanctionReportSelect sanctionsSelect = new SanctionReportSelect();
                sanctionsSelect.MdiParent = this;
                sanctionsSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sanctionsListOfStaffDueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                SanctionDueStaffForm sanctionDueStaffForm = new SanctionDueStaffForm();
                sanctionDueStaffForm.MdiParent = this;
                sanctionDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void qualificationTypeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                QualificationTypeForm qualificationTypeForm = new QualificationTypeForm();
                qualificationTypeForm.MdiParent = this;
                qualificationTypeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void occupationalGroupingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OccupationalGroupingForm occupationalGroupingForm = new OccupationalGroupingForm();
                occupationalGroupingForm.MdiParent = this;
                occupationalGroupingForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sanctionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SanctionTypeForm sanctionTypeForm = new SanctionTypeForm();
                sanctionTypeForm.MdiParent = this;
                sanctionTypeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void generalIncrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralIncrementForm generalIncrementForm = new GeneralIncrementForm();
                generalIncrementForm.MdiParent = this;
                generalIncrementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void selectiveIncrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GeneralReversalIncrementForm generalReversalIncrementForm = new GeneralReversalIncrementForm();
                generalReversalIncrementForm.MdiParent = this;
                generalReversalIncrementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void selectiveIncrementToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                SelectiveIncrementForm selectiveIncrementForm = new SelectiveIncrementForm();
                selectiveIncrementForm.MdiParent = this;
                selectiveIncrementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reverseSelectiveIncrementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SelectiveReversalIncrementForm selectiveReversalIncrementForm = new SelectiveReversalIncrementForm();
                selectiveReversalIncrementForm.MdiParent = this;
                selectiveReversalIncrementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void recommendReviewOfSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RecommendReviewSalaryForm recommendReviewSalaryForm = new RecommendReviewSalaryForm();
                recommendReviewSalaryForm.MdiParent = this;
                recommendReviewSalaryForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reviewOfSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReviewSalaryForm reviewSalaryForm = new ReviewSalaryForm();
                reviewSalaryForm.MdiParent = this;
                reviewSalaryForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AnnualReverseCalculateLeaveForm annualReverseCalculateLeaveForm = new AnnualReverseCalculateLeaveForm();
                annualReverseCalculateLeaveForm.MdiParent = this;
                annualReverseCalculateLeaveForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void summaryOfLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoanSummaryReportSelect loanSummaryReportSelect = new LoanSummaryReportSelect();
                loanSummaryReportSelect.MdiParent = this;
                loanSummaryReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void summaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                OtherDeductionsSelect otherDeductionSelect = new OtherDeductionsSelect();
                otherDeductionSelect.MdiParent = this;
                otherDeductionSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void detailDeductionsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OtherDeductionDetailSelect otherDeductionDetailSelect = new OtherDeductionDetailSelect();
                otherDeductionDetailSelect.MdiParent = this;
                otherDeductionDetailSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void summaryAllowanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OtherAllowanceSelect otherAllowanceSelect = new OtherAllowanceSelect();
                otherAllowanceSelect.MdiParent = this;
                otherAllowanceSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void detailAllowanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OtherAllowanceDetailSelect otherAllowanceDetailSelect = new OtherAllowanceDetailSelect();
                otherAllowanceDetailSelect.MdiParent = this;
                otherAllowanceDetailSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void susuMonthlyContributionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SusuMonthlyContributionSelect susuMonthlyContributionSelect = new SusuMonthlyContributionSelect();
                susuMonthlyContributionSelect.MdiParent = this;
                susuMonthlyContributionSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void withholdingMonthlyContrbutionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WithholdingMonthlyContrbutionSelect withholdingMonthlyContrbutionSelect = new WithholdingMonthlyContrbutionSelect();
                withholdingMonthlyContrbutionSelect.MdiParent = this;
                withholdingMonthlyContrbutionSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SMSForm sMSForm = new SMSForm();
                sMSForm.MdiParent = this;
                sMSForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void downloadUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfoMain userInfoMain = new UserInfoMain();
                userInfoMain.MdiParent = this;
                userInfoMain.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void downloadAttendanceLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AttLogsMain attLogsMain = new AttLogsMain();
                attLogsMain.MdiParent = this;
                attLogsMain.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void enrollUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OnEnrollMain onEnrollMain = new OnEnrollMain();
                onEnrollMain.MdiParent = this;
                onEnrollMain.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listUnitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                UnitReportForm rpt = new UnitReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listGradeCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                GradeCategoriesReportForm rpt = new GradeCategoriesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listZonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ZonesReportForm rpt = new ZonesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listJobTitlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                JobTitlesReportForm rpt = new JobTitlesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listToolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                BanksReportForm rpt = new BanksReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listBankBranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BankBranchesReportForm rpt = new BankBranchesReportForm();
                rpt.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bulkConfirmationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BulkConfirmationForm bulkConfirmationForm = new BulkConfirmationForm();
                bulkConfirmationForm.MdiParent = this;
                bulkConfirmationForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void bulkSalaryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SalaryInfoBulkNew salaryInfoBulkNew = new SalaryInfoBulkNew();
                salaryInfoBulkNew.MdiParent = this;
                salaryInfoBulkNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void salaryStruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SingleSpineForm singleSpineForm = new SingleSpineForm();
                singleSpineForm.MdiParent = this;
                singleSpineForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void appointmentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AppointmentTypeForm appointmentTypeForm = new AppointmentTypeForm();
                appointmentTypeForm.MdiParent = this;
                appointmentTypeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reinstatingSeparatedStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TerminatedStaffForm terminatedStaffForm = new TerminatedStaffForm();
                terminatedStaffForm.MdiParent = this;
                terminatedStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listOfStaffDueForSeparationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TerminationDueStaffForm terminationDueStaffForm = new TerminationDueStaffForm();
                terminationDueStaffForm.MdiParent = this;
                terminationDueStaffForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void annualLeaveEntitlementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AnnualLeaveEntitlementForm annualLeaveEntitlementForm = new AnnualLeaveEntitlementForm();
                annualLeaveEntitlementForm.MdiParent = this;
                annualLeaveEntitlementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void separationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SeparationReportSelect separationReportSelect = new SeparationReportSelect();
                separationReportSelect.MdiParent = this;
                separationReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void approveMedicalCliamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalClaimsDueForApprovalForm medicalClaimsDueForApprovalForm = new MedicalClaimsDueForApprovalForm();
                medicalClaimsDueForApprovalForm.MdiParent = this;
                medicalClaimsDueForApprovalForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void medicalClaimsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MedicalClaimsReportSelect medicalClaimsReportSelect = new MedicalClaimsReportSelect();
                medicalClaimsReportSelect.MdiParent = this;
                medicalClaimsReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void nDTierPensionPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SSNITSecondTierPensionPaymentSelect sSNITSecondTierPensionPaymentSelect = new SSNITSecondTierPensionPaymentSelect();
                sSNITSecondTierPensionPaymentSelect.MdiParent = this;
                sSNITSecondTierPensionPaymentSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sSNITVoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SSNITPaymentVoucherSelect sSNITPaymentVoucherSelect = new SSNITPaymentVoucherSelect();
                sSNITPaymentVoucherSelect.MdiParent = this;
                sSNITPaymentVoucherSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void arrearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ArrearsNew arrearsNew = new ArrearsNew();
                arrearsNew.MdiParent = this;
                arrearsNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void transferReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TransferReportSelect transferReportSelect = new TransferReportSelect();
                transferReportSelect.MdiParent = this;
                transferReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void scheduleLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveRoasterForm leaveRoasterForm = new LeaveRoasterForm();
                leaveRoasterForm.MdiParent = this;
                leaveRoasterForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveRoasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveRoasterReportSelect leaveRoasterReportSelect = new LeaveRoasterReportSelect();
                leaveRoasterReportSelect.MdiParent = this;
                leaveRoasterReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void internshipReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InternshipReportSelect internshipReportSelect = new InternshipReportSelect();
                internshipReportSelect.MdiParent = this;
                internshipReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveApprovalForm leaveApprovalForm = new LeaveApprovalForm();
                leaveApprovalForm.MdiParent = this;
                leaveApprovalForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveRecommendationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveRecommendationForm leaveRecommendationForm = new LeaveRecommendationForm();
                leaveRecommendationForm.MdiParent = this;
                leaveRecommendationForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveResumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveResumptionForm leaveResumptionForm = new LeaveResumptionForm();
                leaveResumptionForm.MdiParent = this;
                leaveResumptionForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void recallFromLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveStaffRecallForm leaveStaffRecallForm = new LeaveStaffRecallForm();
                leaveStaffRecallForm.MdiParent = this;
                leaveStaffRecallForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void promotionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionReportSelect promotionReportSelect = new PromotionReportSelect();
                promotionReportSelect.MdiParent = this;
                promotionReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveResumptionReportSelect leaveResumptionReportSelect = new LeaveResumptionReportSelect();
                leaveResumptionReportSelect.MdiParent = this;
                leaveResumptionReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reprintOfLeaveLettersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LeaveRequest leaveRequest = new LeaveRequest();
                leaveRequest.MdiParent = this;
                leaveRequest.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void listOfStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionDueReportSelect promotionDueReportSelect = new PromotionDueReportSelect();
                promotionDueReportSelect.MdiParent = this;
                promotionDueReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void managePermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManagePermissions managePermissions = new ManagePermissions();
                managePermissions.MdiParent = this;
                managePermissions.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void manageRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageRoles manageRoles = new ManageRoles();
                manageRoles.MdiParent = this;
                manageRoles.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DocForm f = new DocForm();
                f.MdiParent = this;
                f.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void interviewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InterviewReportSelect interviewReportSelect = new InterviewReportSelect();
                interviewReportSelect.MdiParent = this;
                interviewReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void applicantReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicantReportSelect applicantReportSelect = new ApplicantReportSelect();
                applicantReportSelect.MdiParent = this;
                applicantReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfJobTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffJobTitleChangeForm staffJobTitleChangeForm = new StaffJobTitleChangeForm();
                staffJobTitleChangeForm.MdiParent = this;
                staffJobTitleChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeGradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffGradeChangeForm staffGradeChangeForm = new StaffGradeChangeForm();
                staffGradeChangeForm.MdiParent = this;
                staffGradeChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffNameChangeForm staffNameChangeForm = new StaffNameChangeForm();
                staffNameChangeForm.MdiParent = this;
                staffNameChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfEmploymentDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffEmploymentDateChangeForm staffEmploymentDateChangeForm = new StaffEmploymentDateChangeForm();
                staffEmploymentDateChangeForm.MdiParent = this;
                staffEmploymentDateChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfDOBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffDOBChangeForm staffDOBChangeForm = new StaffDOBChangeForm();
                staffDOBChangeForm.MdiParent = this;
                staffDOBChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffStatusChangeForm staffStatusChangeForm = new StaffStatusChangeForm();
                staffStatusChangeForm.MdiParent = this;
                staffStatusChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfAppointmentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffAppointmentTypeChangeForm staffAppointmentTypeChangeForm = new StaffAppointmentTypeChangeForm();
                staffAppointmentTypeChangeForm.MdiParent = this;
                staffAppointmentTypeChangeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void qualificationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void staffDueForPromotionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionDueReportSelect promotionDueReportSelect = new PromotionDueReportSelect();
                promotionDueReportSelect.MdiParent = this;
                promotionDueReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void departmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DepartmentsForm departments = new DepartmentsForm();
                departments.MdiParent = this;
                departments.Show();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void staffListByQualificationTypeReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffListByQualificationTypeSelect staffListByQualificationTypeSelect = new StaffListByQualificationTypeSelect();
                staffListByQualificationTypeSelect.MdiParent = this;
                staffListByQualificationTypeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void sanctionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SanctionReportSelect sanctionReportSelect = new SanctionReportSelect();
                sanctionReportSelect.MdiParent = this;
                sanctionReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffChangesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StaffChangeReportSelect staffChangeReportSelect = new StaffChangeReportSelect();
                staffChangeReportSelect.MdiParent = this;
                staffChangeReportSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void QuickbookMappingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                QuickbookMappingForm chartOfAccountMapForm = new QuickbookMappingForm();
                chartOfAccountMapForm.MdiParent = this;
                chartOfAccountMapForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void QuickbookDataGenerationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                QuickbookGenerationForm quickbookForm = new QuickbookGenerationForm();
                quickbookForm.MdiParent = this;
                quickbookForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }
    }
}
