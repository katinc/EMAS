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
using System.Threading;
using HRDataAccessLayer.Alerts;
using HRBussinessLayer.Alerts;
using eMAS.Forms.Notifications;
using Microsoft.Win32;

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

        //private NotificationDataMapper notifactionMapper;
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
                //store stuff in registry
                //RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\IDNS");
                //key.SetValue("FACILITY", "IDNS");
                //key.Close();

                //RegistryKey keys = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\IDNS");
                //if (keys != null)
                //{
                //    MessageBox.Show(keys.GetValue("Password").ToString(), "Registry Stuff");
                //    keys.Close();
                //}

                var facility = GlobalData._context.CompanyInfos.First();
                this.Text = facility.Initials + " EMPLOYEE MANAGEMENT & ADMINISTRATIVE SYSTEM";
                this.BackgroundImage = facility.Initials == "KATH" ? eMAS.Properties.Resources.kbg : eMAS.Properties.Resources.bgp;

                Login login = new Login(this,menuStrip1.Items,menuStrip2.Items);
                login.MdiParent = this;
                login.Show();                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);

                DialogResult dialog = MessageBox.Show(this,"There was an error connecting to the server. Check your connection and try again.", "Connection Error", MessageBoxButtons.RetryCancel);
                DialogResult result = DialogResult.Retry;
                if(dialog == result)
                {
                    MainMDI_Load(sender, e);
                }
                else
                {
                    this.Close();
                }

            }

            NotificationDataMapper notification;

             new Thread(() =>
            {
                notifyIconMain.ShowBalloonTip(5000, "Welcome", "Hello ", ToolTipIcon.Info); 
            }).Start();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                /* run your code here */
                //notifactionMapper = new NotificationDataMapper();
                 notification = new NotificationDataMapper(notifyType.Leave);
                 notification.doSystemTrayNotifications(notifyIconMain);

                 Thread.Sleep(500);
                 notification = new NotificationDataMapper(notifyType.Pention);
                 notification.doSystemTrayNotifications(notifyIconMain);

                 Thread.Sleep(500);
                 notification = new NotificationDataMapper(notifyType.Probation);
                 notification.doSystemTrayNotifications(notifyIconMain);

            }).Start();
          
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                if (GlobalData._context.CompanyInfos.FirstOrDefault().Initials == "HTH")
                {
                    employeeRegistration = new EmployeeMaintenanceHTH();
                }
                else
                {
                    employeeRegistration = new EmployeeMaintenance();
                }
                employeeRegistration.MdiParent = this;
                //employeeRegistration.WindowState = FormWindowState.Maximized;
                int width =(int)((50/100)* Screen.PrimaryScreen.Bounds.Width);
                int heigth =(int)((98/100)*Screen.PrimaryScreen.Bounds.Height);

                employeeRegistration.MaximumSize = new Size(width, heigth);
                employeeRegistration.WindowState = FormWindowState.Normal;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                BulkDutyRoaster form = new BulkDutyRoaster();
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                //var it = sender as ToolStripMenuItem;
                //GlobalData.ItemControl = it.Name;
                //EmployeeAppraisalStartPage form = new EmployeeAppraisalStartPage();
                //form.MdiParent = this;
                //form.Show();
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
                //{
                //    var it = sender as ToolStripMenuItem;
                //    GlobalData.ItemControl = it.Name;
                //    SupervisorAppraisal form = new SupervisorAppraisal();
                //    form.MdiParent = this;
                //    form.Show();
                //}
                
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                //StaffAttendanceReportSelect staffAttendance = new StaffAttendanceReportSelect();
                //staffAttendance.MdiParent = this;
                //staffAttendance.Show();

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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ShiftSelect form = new ShiftSelect();
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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

                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AnnualLeaveEntitlementForm annualLeaveEntitlementForm = new AnnualLeaveEntitlementForm();
                annualLeaveEntitlementForm.MdiParent = this;
                annualLeaveEntitlementForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveLetterSignatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                LeaveLetterApplcationSignature leaveletterapplicationform = new LeaveLetterApplcationSignature();
                leaveletterapplicationform.MdiParent = this;
                leaveletterapplicationform.Show();
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
            
        }

        private void transferReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
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
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                QuickbookGenerationForm quickbookForm = new QuickbookGenerationForm();
                quickbookForm.MdiParent = this;
                quickbookForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void listInternsNotOnPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                InternshipReportSelect frm = new InternshipReportSelect();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void paySlipFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                EmployeeGradeSalaries frm = new EmployeeGradeSalaries();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void publicHolidaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                PublicHolidaysForm frm = new PublicHolidaysForm();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) {
                Logger.LogError(ex);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                NotificationsForm notForm = new NotificationsForm();
                notForm.MdiParent = this;
                notForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void requestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcusedDuty excuseDutyForm = new ExcusedDuty();
                excuseDutyForm.MdiParent = this;
                excuseDutyForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void excuseDutyRecommendationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcuseDutyRecommendation excuseDutyRecommendForm = new ExcuseDutyRecommendation();
                excuseDutyRecommendForm.MdiParent = this;
                excuseDutyRecommendForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void excuseDutyApprovalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcuseDutyApprovalForm excuseDutyApprovalForm = new ExcuseDutyApprovalForm();
                excuseDutyApprovalForm.MdiParent = this;
                excuseDutyApprovalForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void excuseDutyResumptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcuseDutyReturnForm excuseDutyReturnForm = new ExcuseDutyReturnForm();
                excuseDutyReturnForm.MdiParent = this;
                excuseDutyReturnForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void exuseDutyHRRecommendationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcuseDutyHRRecommendation excuseDutyReturnForm = new ExcuseDutyHRRecommendation();
                excuseDutyReturnForm.MdiParent = this;
                excuseDutyReturnForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuTraingAttendanceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingAttendanceModes attendanceModeForm = new TrainingAttendanceModes();
                attendanceModeForm.MdiParent = this;
                attendanceModeForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuAttendedSchoolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AttendedSchools attendanceSchoolsForm = new AttendedSchools();
                attendanceSchoolsForm.MdiParent = this;
                attendanceSchoolsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuSponsoredProgrammesMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                SponsoredCertProgrammesForm sponsoredProgrammes = new SponsoredCertProgrammesForm();
                sponsoredProgrammes.MdiParent = this;
                sponsoredProgrammes.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnutrainingBondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingBondForm trainingBond = new TrainingBondForm();
                trainingBond.MdiParent = this;
                trainingBond.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuexternalTrainingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExternalTrainingForm externalTrainingForm = new ExternalTrainingForm();
                externalTrainingForm.MdiParent = this;
                externalTrainingForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuTrainingSponsors_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingSponsors TrainingSponsorsForm = new TrainingSponsors();
                TrainingSponsorsForm.MdiParent = this;
                TrainingSponsorsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuTrainingOrganizers_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingOrganizers TrainingOrganizersForm = new TrainingOrganizers();
                TrainingOrganizersForm.MdiParent = this;
                TrainingOrganizersForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuExcuseDutyReport_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ExcuseDutyReportFilter excuseDutyReportFilter = new ExcuseDutyReportFilter();
                excuseDutyReportFilter.MdiParent = this;
                excuseDutyReportFilter.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuAppraisalFactors_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AppraisalFactorsForm appraisalFactorsForm = new AppraisalFactorsForm();
                appraisalFactorsForm.MdiParent = this;
                appraisalFactorsForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuAppraisalRatings_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AppraisalRatingsForm appraisalRatingForm = new AppraisalRatingsForm();
                appraisalRatingForm.MdiParent = this;
                appraisalRatingForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuAppraisalPeriods_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AppraisalPeriodForm appraisalPeriodForm= new AppraisalPeriodForm();
                appraisalPeriodForm.MdiParent = this;
                appraisalPeriodForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnustaffsObjectives_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                AppraisalObjectivesForm appraisalObjectivesForm = new AppraisalObjectivesForm();
                appraisalObjectivesForm.MdiParent = this;
                appraisalObjectivesForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnustaffAppraisal_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ApraisalForm appraisalForm = new ApraisalForm();
                appraisalForm.MdiParent = this;
                appraisalForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuExternalTrainingJustification_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            ExternalTrainingJustificationView justificationView = new ExternalTrainingJustificationView();
            justificationView.MdiParent = this;
            justificationView.ShowDialog(this);
        }

        private void postingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void mnuExternalTrainingHRRecommendation_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            ExternalTrainingHRRecommendationView recommendationView = new ExternalTrainingHRRecommendationView();
            recommendationView.MdiParent = this;
            recommendationView.ShowDialog(this);
        }

        private void mnuExternalTrainingCEOApproval_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            ExternalTrainingCEOApprovalView ceoApprovalView = new ExternalTrainingCEOApprovalView();
            ceoApprovalView.MdiParent = this;
            ceoApprovalView.ShowDialog(this);
        }

        private void mnuExcuseDutyReportForm_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            ExcuseDutyReportFilter reportFilter = new ExcuseDutyReportFilter();
            reportFilter.MdiParent = this;
            reportFilter.Show();
        }

        private void mnuExternalTrainingReport_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            ExternalTrainingReportFilter reportFilter = new ExternalTrainingReportFilter();
            reportFilter.MdiParent = this;
            reportFilter.Show();
        }

        private void mnuTrainingBondsReport_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            TrainingBondReportFilter reportFilter = new TrainingBondReportFilter();
            reportFilter.MdiParent = this;
            reportFilter.Show();
        }

        private void mnuAppraisalListReport_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            AppraisalReportFilter reportFilter = new AppraisalReportFilter();
            reportFilter.MdiParent = this;
            reportFilter.Show();
        }

        private void mnuIdentificationTypes_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            var form = new StaffIdentificationTypes();
            form.MdiParent = this;
            form.Show();
        }

        private void salaryLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnuSalaryPaymentAccounts_Click(object sender, EventArgs e)
        {
            var it = sender as ToolStripMenuItem;
            GlobalData.ItemControl = it.Name;
            var form = new SalaryPaymentAccounts();
            form.MdiParent = this;
            form.Show();
        }

        private void trainingBondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingBondForm trainingBond = new TrainingBondForm();
                trainingBond.MdiParent = this;
                trainingBond.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void manualCheckOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ManualCheckOut form = new ManualCheckOut();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void vacancyListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void interviewListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void transferListReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trainingtypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingTypes specialtyForm = new TrainingTypes();
                specialtyForm.MdiParent = this;
                specialtyForm.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffLeaveBalancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                StaffLeaveBalanceSelect form = new StaffLeaveBalanceSelect();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void leaveEncashmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                LeaveEncashment form = new LeaveEncashment();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void leaveEncashmentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                LeaveEncashmentReport form = new LeaveEncashmentReport();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfMaritalStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                StaffDetailsChangeSelect form = new StaffDetailsChangeSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeOfQualificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                StaffQualificationChangeForm form = new StaffQualificationChangeForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void changeJobTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                StaffDetailsChangeSelect form = new StaffDetailsChangeSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffDueForPromotionToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                PromotionStaffDueForm form = new PromotionStaffDueForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffListByAppointmentReportToolStrilMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                StaffListByAppointmentTypeSelect staffListByAgeSelect = new StaffListByAppointmentTypeSelect();
                staffListByAgeSelect.MdiParent = this;
                staffListByAgeSelect.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void taxReliefToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TaxRelief form = new TaxRelief();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void timeCardManagementToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                TimeCards form = new TimeCards();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuOverTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                OverTimeReportSelect form = new OverTimeReportSelect();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void mnuDutyAllowancesMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                DutyAllowancesForm form = new DutyAllowancesForm();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void taxReliefToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                TaxReliefReportSelect form = new TaxReliefReportSelect();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void trainingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                TrainingFormSelect form = new TrainingFormSelect("TrainingNeeds");
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void trainingReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                TrainingFormSelect form = new TrainingFormSelect("TrainingReport");
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void trainingReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void promotionTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                PromotionTypes form = new PromotionTypes();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void arrearsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                ArrearsNew arrearsNew = new ArrearsNew();
                arrearsNew.MdiParent = this;
                arrearsNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void allowanceArrearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                Allowance_Arrears form = new Allowance_Arrears();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void salaryAdvanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                SalaryAdvance form = new SalaryAdvance();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void riskAllowancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                RiskAllowanceForm form = new RiskAllowanceForm();
                GlobalData.ItemControl = it.Name;
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void summaryToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                SummaryReportSelect form = new SummaryReportSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void locumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                Locum form = new Locum();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void restartToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Are you sure you want to restart the Application?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //this.BackgroundImage
                //Application.Restart();
                //Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void locumReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                LocumReportSelect form = new LocumReportSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void studyLeaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                StudyLeaveForm form = new StudyLeaveForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void requestChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                RequestChangesForm form = new RequestChangesForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void approveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                RequestChangeApprovalForm form = new RequestChangeApprovalForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkInOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void accomodationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void vehicleReportMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                VehicleReportSearch form = new VehicleReportSearch();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void reinstatingTransferedStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listOfAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void trainingEvaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingEvaluationForm form = new TrainingEvaluationForm();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void trainingEvaluationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var it = sender as ToolStripMenuItem;
                GlobalData.ItemControl = it.Name;
                TrainingEvaluationFormSelect form = new TrainingEvaluationFormSelect();
                form.MdiParent = this;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void studyLeaveReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
