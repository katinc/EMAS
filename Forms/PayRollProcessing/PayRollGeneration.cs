using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using eMAS.Forms.Reports;
using eMAS.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using CrystalDecisions.Shared;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Configuration;
using HRBussinessLayer.EMAIL;
using HRBussinessLayer.SMS;
using System.Threading;
using System.Collections;

namespace eMAS.Forms.PayRollProcessing
{
    public enum PayRollStatus
    {
        None,
        Open,
        Closed,
    }

    public partial class PayrollGeneration : Form
    {
        private IDAL dal;
        private DALHelper dalHelper;
        private Employee employee;
        private StaffBank staffBank;
        private PayRollStatus status;
        private PayRollAttendance attendance;
        
        private IList<PayRollAttendance> attendances;
        private IList<PayRollAttendance> foundAttendances;
        private IList<Department> departments;      
        private IList<Company> company;
        private Company companyOne;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<Employee> foundEmployees;
        private IList<StaffBank> staffBanks;
        private IList<StaffAllowance> staffAllowances;
        private IList<StaffDeduction> staffDeductions;
        private IList<SSNITContribution> ssnitContributions;
        private IList<StaffSalaryHistory> salaryInfos;
        private IList<HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims> medicalClaims;
        private IList<StaffLoan> loans;
        private IList<OverTime> overTimes;
        private IList<StaffLoanPayment> staffLoanPayments;
        private IList<Deduction> deductionTypes;
        private IList<Allowance> allowanceTypes;
        private IList<OverTimeType> overTimeTypes;
        private IList<Loan> loanTypes;
        private IList<Arrears> arrears;
        private int ctr;
        private bool overwrite;
        private int indexCtr;
        private Dictionary<string, string> payRollErrors;
        private Form reportForm;
        private PayRoll payroll;
        private decimal basicSalary;
        private decimal actualBasicSalary;
        private decimal grossIncome;
        private decimal incomeTax;
        private decimal ssnit;
        private decimal ssER;
        private decimal providentFundEmployee;
        private decimal providentFundEmployer;
        private decimal taxableIncome;
        private decimal netPay;
        private decimal grandTotalLoan;
        private decimal grandTotalDeduction;
        private decimal grandTotalAllowance;
        private bool mechanised;
        private bool found;
        private object qb;

        private IList<Unit> units;



        private PayRollAttendanceDataMapper attendanceMapper;

        private eMAS.Forms.Reports.AllEmpPaySlipFormatNew allEmpSalrpt = new AllEmpPaySlipFormatNew();

        public PayrollGeneration()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.dalHelper = new DALHelper();         
            this.employee = new Employee();
            this.staffBank = new StaffBank();
            this.status = new PayRollStatus();
            this.attendances = new List<PayRollAttendance>();
            this.foundAttendances = new List<PayRollAttendance>();
            this.departments = new List<Department>();
            this.company=new List<Company>();
            this.companyOne = new Company();
            this.employees = new List<Employee>();
            this.employeeList = new List<Employee>();          
            this.foundEmployees = new List<Employee>();
            this.staffBanks = new List<StaffBank>();
            this.staffAllowances = new List<StaffAllowance>();
            this.staffDeductions = new List<StaffDeduction>();
            this.ssnitContributions = new List<SSNITContribution>();
            this.salaryInfos = new List<StaffSalaryHistory>();
            this.medicalClaims = new List<HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims>();
            this.loans=new List<StaffLoan>();
            this.overTimes=new List<OverTime>();
            this.staffLoanPayments=new List<StaffLoanPayment>();
            this.deductionTypes = new List<Deduction>();
            this.allowanceTypes = new List<Allowance>();
            this.overTimeTypes = new List<OverTimeType>();
            this.loanTypes=new List<Loan>();
            this.arrears = new List<Arrears>();
            this.ctr = 0;
            this.overwrite = false;
            this.indexCtr = 0;
            this.payRollErrors = new Dictionary<string, string>();
            this.reportForm = new Form();
            this.payroll = new PayRoll();
            this.basicSalary = 0;
            this.actualBasicSalary = 0;
            this.grossIncome = 0;
            this.incomeTax = 0;
            this.ssnit = 0;
            this.ssER = 0;
            this.providentFundEmployee = 0;
            this.providentFundEmployer = 0;
            this.taxableIncome = 0;
            this.netPay = 0;
            this.grandTotalLoan = 0;
            this.grandTotalDeduction = 0;
            this.grandTotalAllowance = 0;
            this.mechanised = false ;
            this.found = false;
            this.attendanceMapper = new PayRollAttendanceDataMapper();

            this.units = new List<Unit>();

        }

        private void Attendance_Load(object sender, EventArgs e)
        {         
            try
            {
                this.Text = GlobalData.Caption;

                //check which facility and apply their changes
                var facility = GlobalData._context.Administrators.ToList();

                if (facility.Count() > 0)
                {
                    foreach (var item in facility)
                    {
                        if (item.Facility.ToString().Equals("KATH"))
                        {
                            gridWithholdingAmount.Visible = false;
                            gridWithholdingTaxCalculateOn.Visible = false;
                            gridWithholdingTaxFixedAmount.Visible = false;
                            gridWithholdingTaxRate.Visible = false;
                            gridTakeHome.Visible = false;
                        }
                    }
                }

                ClearView();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private PayRollStatus Exists(string month, string year)
        {
            PayRollStatus result = PayRollStatus.None;
            try
            {
                if (periodComboBox.Text.Trim() != string.Empty && yearComboBox.Text.Trim() != string.Empty)
                {
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Month",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.GetMonth(month),
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Year",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = year,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Status",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = 2,
                        CriteriaOperator = CriteriaOperator.None
                    });
                    int count = dal.GetByCriteria<PayRollAttendance>(query).Count;
                    if (count > 0)
                    {
                        result = PayRollStatus.Closed;
                    }
                    else
                    {
                        result = PayRollStatus.Open;
                    }
                }
                else
                {
                    result = PayRollStatus.None;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private bool AllowedToClosePayRoll(int userID)
        {
            bool result = true;
            return result;
        }

        private void Save()
        {
            int Newctr = 0;
            try
            {
                
                if (AllowedToClosePayRoll(GlobalData.User.ID))
                {
                    if (grid.Rows.Count > 0)
                    {
                        
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (row != null)
                            {
                                //Close PayRoll Payroll
                                dal.BeginTransaction();
                                dalHelper.ExecuteNonQuery("Update StaffSalaryPayments Set Status='2' Where Month='" + GlobalData.GetMonth(row.Cells["gridMonth"].Value.ToString().Trim()) + "' And Year='" + row.Cells["gridYear"].Value.ToString().Trim() + "'");
           
                                dal.CommitTransaction();
                                Newctr++;
                                dal.BeginTransaction();

                                if (row.Cells["gridMobileNumber"].Value.ToString().Trim() != string.Empty)
                                {
                                    ScheduleMessage scheduleMessage = new ScheduleMessage();
                                    scheduleMessage.To = row.Cells["gridMobileNumber"].Value.ToString();
                                    scheduleMessage.From = "System";
                                    scheduleMessage.Message = "Your PaySlip with Net Sal.:GHC" + row.Cells["gridNetSalary"].Value + ",Gross Sal.:GHC" + row.Cells["gridGrossSalary"].Value + ",Ded.GHC" + row.Cells["gridGrandTotalDeduction"].Value + ",Allowa.:GHC" + row.Cells["gridGrandTotalAllowance"].Value + " for" + row.Cells["gridMonth"].Value.ToString().Trim() + "," + row.Cells["gridYear"].Value.ToString().Trim() + " has been Completed";
                                    scheduleMessage.Schedule_time = DateTime.Now;
                                    scheduleMessage.Status = "Send";

                                    dal.Save(scheduleMessage);
                                }
                                dal.CommitTransaction();
                               
                                //Sending Email
                                payRollRegisterOldFormat1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                payRollRegisterOldFormat1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                payRollRegisterOldFormat1.SetParameterValue("GradeCategory", " ");
                                payRollRegisterOldFormat1.SetParameterValue("Grade", " ");
                                payRollRegisterOldFormat1.SetParameterValue("Department", " ");
                                payRollRegisterOldFormat1.SetParameterValue("Unit", " ");
                                payRollRegisterOldFormat1.SetParameterValue("Zone", " ");
                                payRollRegisterOldFormat1.SetParameterValue("Mechanised", cboMechanised.Text.Trim());


                                payRollRegisterOldFormat1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password, GlobalData.ServerName, GlobalData.DatabaseName);
                                if (ConfigurationManager.AppSettings["SupervisorEmail"].ToString() != string.Empty)
                                {
                                    //payRollRegisterOldFormat1.ExportToDisk(ExportFormatType.PortableDocFormat, "reportExcelPayRoll.pdf");
                                    SendEmail(ConfigurationManager.AppSettings["SupervisorEmail"].ToString(),row.Cells["gridYear"].Value.ToString().Trim(),row.Cells["gridMonth"].Value.ToString().Trim(), ConfigurationManager.AppSettings["SupervisorName"].ToString(), ConfigurationManager.AppSettings["SupervisorSubject"].ToString(), ConfigurationManager.AppSettings["SupervisorBody"].ToString(), payRollRegisterOldFormat1, ExportFormatType.PortableDocFormat, "PayRoll-" + periodComboBox.Text.Trim() + "_" + yearComboBox.Text.Trim() + ".pdf");
                                }
                                paySlipReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                paySlipReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                paySlipReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password, GlobalData.ServerName, GlobalData.DatabaseName);

                                if (row.Cells["gridEmail"].Value == null || row.Cells["gridEmail"].Value.ToString().Trim() == string.Empty)
                                {
                                    WriteToLogFile(attendance.Name + "with" + "StaffID" + row.Cells["gridStaffNo"].Value.ToString().Trim() + "Does not have a mail");
                                }
                                else
                                {
                                    paySlipReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                    paySlipReport1.SetParameterValue("PaymentID", row.Cells["gridPaymentID"].Value.ToString().Trim());
                                    SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".pdf");
                                }

                            }
                        }
                        ClearView();          
                    }
                    else
                    {
                        GlobalData.ShowMessage("Please View PayRoll before you Close");
                    } 
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw ex;
            }
            if (Newctr > 0)
                MessageBox.Show(this,"Payroll was closed successfully!");
            ClearView();     
        }

        private void ClearView()
        {
            try
            {
                cmbDepartments.Items.Clear();
                cmbDepartments.Text = string.Empty;
                grid.Rows.Clear();
                DisableBoxes(false);
                cmbDepartments.Select();
                periodComboBox.Items.Clear();
                periodComboBox.Text = string.Empty;
                yearComboBox.Items.Clear();
                yearComboBox.Text = string.Empty;
                staffIDTextBox.Clear();
                nameTextBox.Clear();
                dal.CloseConnection();
                company = dal.GetAll<Company>();
                if (company[0].PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void DisableBoxes(bool state)
        {
            try
            {
                attendanceGroupBox.Enabled = !state;
                periodGroupBox.Enabled = !state;
                nameTextBox.Enabled = !state;
                staffIDTextBox.Enabled = !state;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void Delete()
        {
            try
            {
                PayRollStatus pStatus = Exists(periodComboBox.Text, yearComboBox.Text);

                if (pStatus == PayRollStatus.Open || pStatus == PayRollStatus.None)
                {
                    dalHelper.BeginTransaction();
                    foreach (DataGridViewRow row in grid.SelectedRows)
                    {
                        if (MessageBox.Show("Do you want to remove the ff. staff from the payroll?\nName: " + row.Cells["gridName"].Value.ToString() + "\nStaff No: " + row.Cells["gridStaffNo"].Value.ToString(), GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            if (pStatus == PayRollStatus.Open)
                            {
                                dalHelper.ExecuteNonQuery("Delete From StaffSalaryPayments where paymentID=" + row.Cells["gridPaymentID"].Value.ToString() + " And StaffID='" + row.Cells["gridStaffNo"].Value.ToString() + "'");
                                dalHelper.ExecuteNonQuery("Delete From StaffSalaryPaymentsAllowancesAndDeductions where paymentID=" + row.Cells["gridPaymentID"].Value.ToString() + " And StaffID='" + row.Cells["gridStaffNo"].Value.ToString() + "'");
                                dalHelper.ExecuteNonQuery("Delete From StaffSalaryPaymentsLoans where paymentID=" + row.Cells["gridPaymentID"].Value.ToString() + " And StaffID='" + row.Cells["gridStaffNo"].Value.ToString() + "'");
                            }
                            grid.Rows.RemoveAt(row.Index);
                        }
                    }
                    dalHelper.CommitTransaction();
                }
                else
                    GlobalData.ShowMessage("Sorry, The pay slip cannot be removed because the payroll is closed");
            }
            catch (Exception ex)
            {
                dalHelper.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, GlobalData.Caption);
                throw ex;
            }
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartments.Text.Trim() != string.Empty)
                {
                    grid.Rows.Clear();
                    attendances.Clear();
                    DisableBoxes(false);
                    DataTable periodTable = dalHelper.ExecuteReader("Select StaffSalaryPayments.Month,StaffSalaryPayments.Year,Months.Description From StaffSalaryPayments Inner Join Months On Months.ID = StaffSalaryPayments.Month Where StaffSalaryPayments.Status ='Closed' Order By StaffSalaryPayments.Month,StaffSalaryPayments.Year ASC");
                    if (periodTable.Rows.Count > 0)
                    {
                        int month = int.Parse(periodTable.Rows[0]["Description"].ToString()) + 1;
                        int year = int.Parse(periodTable.Rows[0]["Year"].ToString());
                        periodComboBox.Text = ((Months)Enum.Parse(typeof(Months), month.ToString())).ToString();
                        if (month == 12)
                        {
                            year++;
                            yearComboBox.Text = year.ToString();
                        }
                        else
                        {
                            yearComboBox.Text = year.ToString();
                        }
                    }
                    else
                    {
                        periodComboBox.Text = ((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString();
                        yearComboBox.Text = GlobalData.ServerDate.Year.ToString();
                    }
                }
                else
                {
                    DisableBoxes(true);
                }
                indexCtr++;

                Query query = new Query();
                cmbUnit.Items.Clear();
                cmbUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbDepartments.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cmbUnit.Items.Add("All");
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cmbUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnClosePayRoll_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private decimal CalculateIncomeTax(int year, decimal salary, ref bool result)
        {
            decimal incomeTax = 0;
            try
            {
                decimal cumulativeTaxableIncome = 0;
                decimal tax = 0;
                IList<TaxableIncome> taxableIncomes = dal.GetAll<TaxableIncome>();
                foreach (TaxableIncome taxableIncome in taxableIncomes)
                {
                    if (taxableIncome.Active == true)
                    {
                        cumulativeTaxableIncome += taxableIncome.AnnualTaxableIncome / 12;
                        tax = taxableIncome.AnnualTaxableIncome / 12;


                        if (salary > (cumulativeTaxableIncome - tax) && salary <= cumulativeTaxableIncome)
                        {
                            incomeTax += (salary - (cumulativeTaxableIncome - tax)) * taxableIncome.TaxRate / 100;
                            break;
                        }
                        else if (taxableIncome.Description == "Over")
                        {
                            if (salary > cumulativeTaxableIncome)
                            {
                                incomeTax += (salary - tax) * taxableIncome.TaxRate / 100;
                                break;
                            }
                        }
                        incomeTax += tax * taxableIncome.TaxRate / 100;
                    }
                }
                result = false;
            }
            catch (Exception ex)
            {
                result = true;
                Logger.LogError(ex);
                throw ex;
            }
            return incomeTax;
        }

        private decimal CalculateIncomeTaxEBO(int year, decimal salary, ref bool result)
        {
            decimal incomeTax = 0;
            try
            {
                decimal cumulativeTaxableIncome = 0;
                int ctr = 0;
                IList<TaxableIncome> taxableIncomes = dal.GetAll<TaxableIncome>();
                foreach (TaxableIncome taxableIncome in taxableIncomes)
                {
                    cumulativeTaxableIncome += taxableIncome.AnnualTaxableIncome / 12;
                    if (year == taxableIncome.Year)
                    {

                        if (taxableIncome.Description == "First")
                        {
                            incomeTax = 0;
                            if (salary <= cumulativeTaxableIncome)
                            {
                                break;
                            }
                        }
                        else if (taxableIncome.Description == "Next")
                        {
                            if (salary >= cumulativeTaxableIncome)
                            {
                                if (salary >= cumulativeTaxableIncome)
                                {
                                    incomeTax += (taxableIncome.TaxRate / 100) * (taxableIncome.AnnualTaxableIncome / 12);
                                }
                                else if (salary < cumulativeTaxableIncome)
                                {
                                    incomeTax += (taxableIncome.TaxRate / 100) * (salary - (cumulativeTaxableIncome - taxableIncome.AnnualTaxableIncome / 12));
                                }
                            }
                            else
                            {
                                incomeTax += (taxableIncome.TaxRate / 100) * (salary - (cumulativeTaxableIncome - taxableIncome.AnnualTaxableIncome / 12));
                                break;
                            }
                        }
                        else if (taxableIncome.Description == "Over")
                        {
                            if (salary >= cumulativeTaxableIncome)
                            {
                                incomeTax += (taxableIncome.TaxRate / 100) * (taxableIncome.AnnualTaxableIncome / 12);
                            }
                            else if (salary < cumulativeTaxableIncome)
                            {
                                incomeTax += (taxableIncome.TaxRate / 100) * (salary - (cumulativeTaxableIncome - taxableIncome.AnnualTaxableIncome / 12));
                            }
                        }

                        ctr++;
                    }
                }
                result = false;
            }
            catch (Exception ex)
            {
                result = true;
                Logger.LogError(ex);
                throw ex;
            }
            return incomeTax;
        }


        private decimal CalculateIncomeTaxAGA(int year, decimal salary, ref bool result)
        {
            decimal incomeTax = 0;
            //salary = decimal.Parse("7546.14");
            if (salary > 1 && salary <= 132)
            {
                incomeTax = 0;
            }
            else if (salary > 132 && salary <= 198)
            {
                incomeTax = (salary - 132) * 5 / 100;
            }
            else if (salary > 198 && salary <= 290)
            {
                incomeTax = (salary - 198) * 10 / 100 + 33 / 10;
            }
            else if (salary > 290 && salary <= 2640)
            {
                incomeTax = (salary - 290) * 175 / 1000 + 125 / 10;
            }
            else if (salary > 2640)
            {
                incomeTax = ((salary - 2640) * 25 / 100) + 42375 / 100;
            }

            return incomeTax;

        }
        //For testing Purposes
       // List<string> excludeEmpIDs = new List<string>(new string[] { "AF215141", "AF215134", "AF215138", "AF215139", "AF215136", "AF215137", "AF215142", "AF215135", "AF215140" });
      


        private void ViewPayRoll()
        {
            try
            {
                int ctr = 0;
                Query query = new Query();
                grid1.Rows.Clear();
                staffIDTextBox.Clear();
                nameTextBox.Clear();
                grid.Rows.Clear();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (paymentacctype.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.PaymentAccType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = paymentacctype.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cmbDepartments.Text.Trim() != string.Empty && cmbDepartments.Text.ToUpper().Trim() != "ALL DEPARTMENTS")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value =cmbDepartments.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cmbUnit.Text.Trim() != string.Empty && cmbUnit.Text.ToUpper().Trim() != "ALL")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cmbUnit.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboMechanised.Text.Trim() != string.Empty && cboMechanised.Text.ToUpper().Trim() != "ALL")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Mechanised",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = mechanised,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = staffIDTextBox.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Payment",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
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
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                employees = dal.LazyLoadCriteria<Employee>(query);
                IList<Employee> newEmployees = new List<Employee>();
                if (employees.Count > 0)
                {
                   
                    foreach (Employee employee in employees)
                    {
                        /*if (!excludeEmpIDs.Any(s => s == employee.StaffID))
                        {*/
                            grid1.Rows.Add(1);
                            string name = employee.Surname.Trim() + " " + employee.FirstName.Trim() + " " + (employee.OtherName.Trim() == string.Empty ? string.Empty : " " + employee.OtherName.Trim());
                            grid1.Rows[ctr].Cells["grid1StaffNo"].Value = employee.StaffID.Trim();
                            grid1.Rows[ctr].Cells["grid1StaffCode"].Value = employee.ID;
                            grid1.Rows[ctr].Cells["grid1Title"].Value = employee.Title.Description.Trim();
                            grid1.Rows[ctr].Cells["grid1Name"].Value = name.Trim();
                            grid1.Rows[ctr].Cells["grid1Email"].Value = employee.Email.Trim();
                            grid1.Rows[ctr].Cells["grid1MobileNumber"].Value = employee.MobileNo;
                            grid1.Rows[ctr].Cells["grid1Mechanised"].Value = employee.Mechanised;
                            grid1.Rows[ctr].Cells["grid1AttendanceDays"].Value = 30;
                            grid1.Rows[ctr].Cells["grid1PaymentAccType"].Value = employee.PaymentAccType;


                            newEmployees.Add(employee);
                            ctr++;
                        /*}*/
                    }
                }

                if (yearComboBox.Text.Trim() != string.Empty && periodComboBox.Text.Trim() != string.Empty)
                {
                    overwrite = false;
                    status = Exists(periodComboBox.Text.Trim(), yearComboBox.Text.Trim());

                    if (status == PayRollStatus.None)
                    {
                        GeneratePayRoll();
                        overwrite = true;
                    }
                    else if (status == PayRollStatus.Open)
                    {
                        if (GlobalData.QuestionMessage("The payroll for the period you have selected has been generated but is still open.\nWould you like to overwrite it?") == DialogResult.Yes)
                        {
                            dal.Delete(new PayRollAttendance() { Month = GlobalData.GetMonth(periodComboBox.Text), Year = int.Parse(yearComboBox.Text) });
                            GeneratePayRoll();
                            overwrite = true;
                        }
                        else
                        {
                            GetPayRoll(periodComboBox.Text.Trim(), yearComboBox.Text.Trim());
                            overwrite = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The payroll for the specified period has already been closed.\nYou can only view and print but not modify");
                      GetPayRoll(periodComboBox.Text, yearComboBox.Text);
                       // ViewPayRoll();
                        overwrite = false;
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetPayRoll(string month, string year)
        {
            try
            {
                Query query = new Query();
                if (paymentacctype.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.PaymentAccType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = paymentacctype.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cmbDepartments.Text.Trim() != string.Empty && cmbDepartments.Text.ToUpper().Trim() != "ALL DEPARTMENTS")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cmbDepartments.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffSalaryPaymentView.Month",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = GlobalData.GetMonth(month),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffSalaryPaymentView.Year",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = year,
                    CriteriaOperator = CriteriaOperator.None
                });
                attendances = dal.GetByCriteria<PayRollAttendance>(query);
                PopulateView(attendances);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GeneratePayRoll()
        {
            try
            {
                this.Enabled = false;//optional, better target a panel or specific controls
                this.UseWaitCursor = true;//from the Form/Window instance
                Application.DoEvents();//messages pumped to update controls
                this.BringToFront();
                int ctr = 0;
                this.basicSalary = 0;
                this.actualBasicSalary = 0;
                this.grossIncome = 0;
                this.incomeTax = 0;
                this.ssnit = 0;
                this.ssER = 0;
                this.providentFundEmployee = 0;
                this.providentFundEmployer = 0;
                this.taxableIncome = 0;
                this.netPay = 0;
                this.grandTotalLoan = 0;
                this.grandTotalDeduction = 0;
                this.grandTotalAllowance = 0;
                grid.Rows.Clear();
                dal.BeginTransaction();
                string errorString = "Error(s):\n";
                payRollErrors = new Dictionary<string, string>();
                payRollErrors.Clear();
                staffDeductions = dal.GetAll<StaffDeduction>();
                staffAllowances = dal.GetAll<StaffAllowance>();
                ssnitContributions = dal.GetAll<SSNITContribution>();
                salaryInfos = dal.GetAll<StaffSalaryHistory>();
                overTimes = dal.GetAll<OverTime>();
                medicalClaims = dal.GetAll<HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims>();
                loans = dal.GetAll<StaffLoan>();
                arrears = dal.GetAll<Arrears>();
                deductionTypes = dal.GetAll<Deduction>();
                allowanceTypes = dal.GetAll<Allowance>();
                overTimeTypes = dal.GetAll<OverTimeType>();
                loanTypes = dal.GetAll<Loan>();
                companyOne = dal.GetAll<Company>()[0];
                decimal totalCost = 0;
                decimal totalPayable = 0;
                object result = dalHelper.ExecuteScalar("Select Max(PaymentID) From StaffSalaryPaymentView");
                int id = 0;
                if (result != null && result.ToString() != string.Empty)
                {
                    id = int.Parse(result.ToString());
                    id++;
                }
                else
                {
                    id = 1;
                }
                attendances.Clear();
                //Loop through the Employee Records
                foreach (DataGridViewRow row in grid1.Rows)
                {
                    errorString = string.Empty;
                    grid.Rows.Add(1);
                    attendance = new PayRollAttendance();

                    attendance.ID = id;
                    grid.Rows[ctr].Cells["gridPaymentID"].Value = id;

                    //StaffNo and StaffCode
                    attendance.Employee.StaffID = row.Cells["grid1StaffNo"].Value.ToString().Trim();
                    attendance.Employee.ID = int.Parse(row.Cells["grid1StaffCode"].Value.ToString());
                    grid.Rows[ctr].Cells["gridStaffNo"].Value = row.Cells["grid1StaffNo"].Value.ToString();
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = row.Cells["grid1StaffCode"].Value.ToString();

                    //Email
                    grid.Rows[ctr].Cells["gridEmail"].Value = row.Cells["grid1Email"].Value.ToString();
                    attendance.Employee.Email = row.Cells["grid1Email"].Value.ToString();

                    //MobileNumber
                    grid.Rows[ctr].Cells["gridMobileNumber"].Value = row.Cells["grid1MobileNumber"].Value.ToString();
                    attendance.Employee.MobileNo = row.Cells["grid1MobileNumber"].Value.ToString();

                    //Title and Name
                    grid.Rows[ctr].Cells["gridTitle"].Value = row.Cells["grid1Title"].Value.ToString();
                    attendance.Employee.Title.Description = row.Cells["grid1Title"].Value.ToString();
                    grid.Rows[ctr].Cells["gridName"].Value = row.Cells["grid1Name"].Value.ToString();
                    attendance.Name = row.Cells["grid1Name"].Value.ToString();

                    //Mechanised
                    grid.Rows[ctr].Cells["gridMechanised"].Value = row.Cells["grid1Mechanised"].Value.ToString();
                    attendance.Employee.Mechanised = bool.Parse(row.Cells["grid1Mechanised"].Value.ToString());
                    attendance.Mechanised = bool.Parse(row.Cells["grid1Mechanised"].Value.ToString());

                    //Payment Acc Type
                    attendance.PaymentAccType = row.Cells["grid1PaymentAccType"].Value.ToString();
                    attendance.Employee.PaymentAccType = row.Cells["grid1PaymentAccType"].Value.ToString();
                    grid.Rows[ctr].Cells["gridPaymentAccType"].Value = row.Cells["grid1PaymentAccType"].Value.ToString();

                    //Month And Year
                    attendance.Month = GlobalData.GetMonth(periodComboBox.Text);
                    attendance.Year = int.Parse(yearComboBox.Text);
                    string date = attendance.Month.ToString() + "/" + attendance.Year.ToString();
                    DateTime attendanceDate = Convert.ToDateTime(date).Date;  

                    grid.Rows[ctr].Cells["gridMonth"].Value = (Months)Enum.Parse(typeof(Months), attendance.Month.ToString());
                    grid.Rows[ctr].Cells["gridYear"].Value = attendance.Year;

                    //GetEmployee Based on Staffno
                    employee.StaffID = row.Cells["grid1StaffNo"].Value.ToString().Trim();
                    employee = dal.LazyLoadByStaffID<Employee>(employee);
                    attendance.Unit.Description = employee.Unit.Description;
                    attendance.Overseer = employee.Unit.Code;
                    attendance.Zone.Description = employee.Zone.Description;
                    attendance.JobTitle.Description = employee.JobTitle.Description;
                    attendance.GradeCategory.Description = employee.GradeCategory.Description;
                    attendance.Step = employee.Step.Description;
                    attendance.AnnualLeave = employee.AnnualLeave;
                    attendance.AnnualLeaveMonthly = Math.Round(decimal.Parse(employee.AnnualLeave.ToString()) / 12,2,MidpointRounding.AwayFromZero);
                    attendance.AnnualLeaveBalance = employee.LeaveBalance;
                    attendance.AnnualLeaveBalanceMonthly = Math.Round(decimal.Parse(employee.LeaveBalance.ToString()) / 12,2,MidpointRounding.AwayFromZero);

                    attendance.SSNIT = employee.SSNITContribution;
                    attendance.IsProvidentFund = employee.IsProvidentFund;                   
                    attendance.Employee.IsWithholdingTaxRate = employee.IsWithholdingTax;
                    attendance.Employee.IsWithholdingTaxFixedAmount = employee.IsWithholdingTaxFixedAmount;
                    attendance.Employee.IsWithholdingTax = employee.IsWithholdingTax;
                    attendance.Employee.IsSusuPlusContribution = employee.IsSusuPlusContribution;
                    attendance.Employee.IsExemptFromSecondTier = employee.IsExemptFromSecondTier;
                    attendance.ActualBasicSalary = employee.BasicSalary;
                    grid.Rows[ctr].Cells["gridActualBasicSalary"].Value = attendance.ActualBasicSalary;

                    if (attendance.Employee.IsExemptFromSecondTier == true)
                    {
                        //ExemptSSNITEmployerRate
                        attendance.SsnitEmployerRate = ssnitContributions[0].ExemptEmployerPercentage;
                        attendance.SSNITFirstTierRate = ssnitContributions[0].ExemptSSNITFirstTierRate;

                        //ExemptSSNITEmployeeRate
                        attendance.SsnitEmployeeRate = ssnitContributions[0].ExemptEmployeePercentage;
                    }
                    else
                    {
                        //SSNITEmployerRate
                        attendance.SsnitEmployerRate = ssnitContributions[0].EmployerPercentage;
                        attendance.SSNITFirstTierRate = ssnitContributions[0].SSNITFirstTierRate;

                        //SSNITEmployeeRate
                        attendance.SsnitEmployeeRate = ssnitContributions[0].EmployeePercentage;

                    }
                    attendance.IsExemptAllowance = checkBoxExemptAllowances.Checked;
                    attendance.IsExemptDeduction = checkBoxExemptOtherDeductions.Checked;


                    //Loans
                    //decimal carLoan = 0;
                    //decimal otherLoans = 0;
                    attendance.Loans.Clear();
                    decimal totalLoan = 0;
                    decimal initialLoan = 0;
                    bool loanFound = false;

                    foreach (Loan loanType in loanTypes)
                    {
                        loanFound = false;
                        if (loanType.Inactive) //&& allowanceType.AllowanceType.Description.ToLower() == "non taxable")
                        {
                            //Remember separate taxable from non taxable
                            foreach (StaffLoan loan in loans)
                            {
                                if (loan.Employee.StaffID == employee.StaffID && loan.NotAffectSalary == false && (attendanceDate >= loan.DateFrom.Value.Date && attendanceDate <= loan.DateTo.Value.Date) && loan.Loan.Description == loanType.Description)
                                {
                                    totalLoan += loan.MonthlyInstallment;
                                    initialLoan += loan.LoanAmount;
                                    attendance.Loans.Add(
                                        new StaffLoan()
                                        {
                                            ID = loan.ID,
                                            AmountToBePaid = loan.AmountToBePaid,
                                            DateFrom = loan.DateFrom,
                                            DateTo = loan.DateTo,
                                            DateOfLoan = loan.DateOfLoan,
                                            Interest = loan.Interest,
                                            InterestRate = loan.InterestRate,
                                            LoanAmount = loan.LoanAmount,
                                            LoanDescription = loan.LoanDescription,
                                            MonthlyInstallment = loan.MonthlyInstallment,
                                            SpreadOver = loan.SpreadOver,
                                            Count = loan.Count,
                                            Loan = loanType,
                                            Employee = attendance.Employee
                                        });
                                    loanFound = true;
                                }
                            }
                            //if (!loanFound)
                            //{
                            //    attendance.Loans.Add(
                            //        new StaffLoan()
                            //        {
                            //            ID = 0,
                            //            AmountToBePaid = 0,
                            //            DateFrom = null,
                            //            DateTo = null,
                            //            DateOfLoan =null,
                            //            Interest = 0,
                            //            InterestRate = 0,
                            //            LoanAmount = 0,
                            //            LoanDescription = loanType.Description,
                            //            MonthlyInstallment = 0,
                            //            SpreadOver = 0,
                            //            Count=0,
                            //            Loan = loanType,
                            //            Employee = attendance.Employee
                            //        });
                            //}
                        }
                    }
                    grid.Rows[ctr].Cells["gridLoan"].Value = Math.Round(totalLoan, 2,MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridInitialLoan"].Value = Math.Round(initialLoan, 2, MidpointRounding.AwayFromZero);
                    attendance.TotalLoans += Math.Round(totalLoan, 2, MidpointRounding.AwayFromZero);
                    attendance.InitialLoan += Math.Round(initialLoan, 2, MidpointRounding.AwayFromZero); 
                    
                    //Medical Claims
                    attendance.MedicalClaims = 0;
                    foreach (HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims claim in medicalClaims)
                    {
                        if (claim.OnPayRoll == true && claim.Employee.StaffID == employee.StaffID && claim.OnPayRoll && ((claim.ApprovedDate.Value.Date >= attendanceDate)))
                        {
                            attendance.MedicalClaims += Math.Round(claim.ApprovedAmount, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                    if (attendance.MedicalClaims == 0)
                    {
                        grid.Rows[ctr].Cells["gridMedicalClaims"].Value = 0.00;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridMedicalClaims"].Value = attendance.MedicalClaims;
                    }

                    
                    staffBank = dal.GetByID<StaffBank>(employee.StaffID);
                    attendance.StaffBank.ID = staffBank.ID;
                    attendance.StaffBank.Bank.Description = staffBank.Bank.Description;
                    attendance.StaffBank.BankBranch.Description = staffBank.BankBranch.Description;
                    attendance.StaffBank.Address = staffBank.Address;
                    attendance.StaffBank.AccountNumber = staffBank.AccountNumber;
                    attendance.StaffBank.AccountType.Description = staffBank.AccountType.Description;
                    attendance.StaffBank.AccountName = staffBank.AccountName;
                    

                    //Allowances
                    decimal totalAllowance = 0;
                    decimal totalTaxableAllowance = 0;
                    bool allowanceFound = false;
                    attendance.Allowances.Clear();
                    Query querya = new Query();
                    querya.Criteria.Add(new Criterion()
                    {
                        Property = "StaffAllowanceView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = attendance.Employee.StaffID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    staffAllowances = dal.GetByCriteria<StaffAllowance>(querya);
                    if (checkBoxExemptAllowances.Checked == false)
                    {
                        foreach (Allowance allowanceType in allowanceTypes)
                        {
                            allowanceFound = false;
                            if (allowanceType.InUse && allowanceType.AllowanceType.Description.ToLower() == "non taxable")
                            {
                                //Remember separate taxable from non taxable
                                foreach (StaffAllowance allowance in staffAllowances)
                                {
                                    if (allowance.IsEndDate == true && allowance.EndDate != null)
                                    {
                                        if (allowance.InUse == true && allowance.Employee.StaffID == employee.StaffID && (attendanceDate >= allowance.EffectiveDate.Value.Date && attendanceDate <= allowance.EndDate.Value.Date) && allowance.Type.Description == allowanceType.Description)
                                        {
                                            totalAllowance += allowance.Amount;
                                            attendance.Allowances.Add(
                                                new StaffAllowance()
                                                {
                                                    Amount = allowance.Amount,
                                                    EffectiveDate = allowance.EffectiveDate,
                                                    Type = allowanceType,
                                                    Frequency = allowance.Frequency,
                                                    IsEndDate = allowance.IsEndDate,
                                                    EndDate = allowance.EndDate,
                                                    Employee = attendance.Employee
                                                });
                                            allowanceFound = true;
                                        }
                                    }
                                    else if (allowance.InUse == true && allowance.Employee.StaffID == employee.StaffID && allowance.EffectiveDate.Value.Date <= attendanceDate && allowance.Type.Description == allowanceType.Description)
                                    {
                                        totalAllowance += allowance.Amount;
                                        attendance.Allowances.Add(
                                            new StaffAllowance()
                                            {
                                                Amount = allowance.Amount,
                                                EffectiveDate = allowance.EffectiveDate,
                                                Type = allowanceType,
                                                Frequency = allowance.Frequency,
                                                IsEndDate = allowance.IsEndDate,
                                                EndDate = allowance.EndDate,
                                                Employee = attendance.Employee
                                            });
                                        allowanceFound = true;
                                    }
                                    
                                }
                            }
                            if (allowanceType.InUse && allowanceType.AllowanceType.Description.ToLower() == "taxable")
                            {
                                //Remember separate taxable from non taxable
                                foreach (StaffAllowance allowance in staffAllowances)
                                {
                                    if (allowance.IsEndDate == true && allowance.EndDate != null)
                                    {
                                        if (allowance.InUse == true && allowance.Employee.StaffID == employee.StaffID && (attendanceDate >= allowance.EffectiveDate.Value.Date && attendanceDate <= allowance.EndDate.Value.Date) && allowance.Type.Description == allowanceType.Description)
                                        {
                                            totalAllowance += allowance.Amount;
                                            totalTaxableAllowance += allowance.Amount;
                                            attendance.Allowances.Add(
                                                new StaffAllowance()
                                                {
                                                    Amount = allowance.Amount,
                                                    EffectiveDate = allowance.EffectiveDate,
                                                    Type = allowanceType,
                                                    Frequency = allowance.Frequency,
                                                    IsEndDate = allowance.IsEndDate,
                                                    EndDate = allowance.EndDate,
                                                    Employee = attendance.Employee
                                                });
                                            allowanceFound = true;
                                        }
                                    }
                                    else if (allowance.InUse == true && allowance.Employee.StaffID == employee.StaffID && ((allowance.EffectiveDate.Value.Date <= attendanceDate) && allowance.Type.Description == allowanceType.Description))
                                    {
                                        totalAllowance += allowance.Amount;
                                        totalTaxableAllowance += allowance.Amount;
                                        attendance.Allowances.Add(
                                            new StaffAllowance()
                                            {
                                                Amount = allowance.Amount,
                                                EffectiveDate = allowance.EffectiveDate,
                                                Type = allowanceType,
                                                Frequency = allowance.Frequency,
                                                IsEndDate = allowance.IsEndDate,
                                                EndDate = allowance.EndDate,
                                                Employee = attendance.Employee
                                            });
                                        allowanceFound = true;
                                    }
                                }
                            }
                            //if (!allowanceFound)
                            //{
                            //    attendance.Allowances.Add(
                            //        new StaffAllowance()
                            //        {
                            //            Amount = 0,
                            //            EffectiveDate = GlobalData.ServerDate,
                            //            Type = allowanceType,
                            //            Frequency = string.Empty,
                            //            IsEndDate = false,
                            //            EndDate = null,
                            //            Employee = attendance.Employee
                            //        });
                            //}
                        } 
                    }
                    grid.Rows[ctr].Cells["gridAllowances"].Value = Math.Round(totalAllowance, 2, MidpointRounding.AwayFromZero);
                    attendance.TotalAllowance += Math.Round(totalAllowance, 2, MidpointRounding.AwayFromZero);
                    


                    

                    //Salary Info
                    bool salaryError = true;
                    
                    foreach (StaffSalaryHistory salaryInfo in salaryInfos)
                    {
                        if (salaryInfo.Employee.StaffID == employee.StaffID)
                        {
                            if (salaryInfo.StartDate <= attendanceDate)
                            {
                                attendance.HoursWorked = salaryInfo.HoursWorked;
                                attendance.Attendance = attendance.HoursWorked.ToString();
                                grid.Rows[ctr].Cells["gridAttendanceDays"].Value = attendance.Attendance;
                                if (employee.Hourly)
                                {
                                    try
                                    {
                                        decimal hourlyRate = attendance.BasicSalary / attendance.HoursWorked;
                                        attendance.BasicSalary = Math.Round(hourlyRate * salaryInfo.HoursWorked, 2, MidpointRounding.AwayFromZero);
                                        grid.Rows[ctr].Cells["gridBasicSalary"].Value = attendance.BasicSalary;
                                    }
                                    catch(DivideByZeroException ex)
                                    {
                                        MessageBox.Show("Please Setup the TotalShift at the Company Info Setup " + ex.Message);
                                    }
                                    
                                }
                                else
                                {
                                    if (salaryInfo.EndDate == null)
                                    {
                                        attendance.BasicSalary = Math.Round(salaryInfo.MonthlyBasicSalary, 2, MidpointRounding.AwayFromZero);
                                    }
                                    else
                                    {
                                        attendance.BasicSalary = Math.Round(salaryInfo.SalaryEarned, 2, MidpointRounding.AwayFromZero);
                                    }
                                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = attendance.BasicSalary;
                                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = attendance.Attendance;
                                }

                                //Department
                                attendance.Department.ID = employee.Department.ID;
                                attendance.Department.Description = employee.Department.Description;
                                grid.Rows[ctr].Cells["gridDepartment"].Value = attendance.Department.Description;

                                //PaymentMode
                                attendance.PaymentMode = salaryInfo.PaymentMode;
                                grid.Rows[ctr].Cells["gridPaymentMode"].Value = attendance.PaymentMode;

                                //Grade
                                attendance.Grade.ID = employee.Grade.ID;
                                attendance.Grade.Grade = employee.Grade.Grade;
                                grid.Rows[ctr].Cells["gridGrade"].Value = attendance.Grade.Grade;

                                //GradeLevel
                                attendance.Band.ID = employee.Band.ID;
                                attendance.Band.Description = employee.Band.Description;
                                grid.Rows[ctr].Cells["gridGradeLevel"].Value = attendance.Band.Description;
                                salaryError = false;
                            }
                        }
                    }

                    if (salaryError)
                    {
                        SetRowColor(grid.Rows[ctr], Color.Red);
                        errorString += attendance.Name + "'s basic salary info has not been setup at the salary information section.\n\n";
                    }


                    


                    //OverTime
                   
                    decimal totalPublicHolidayOverTime = 0;
                    decimal totalDailyOverTime = 0;
                    decimal totalPublicHolidayOverTimeHours = 0;
                    decimal totalDailyOverTimeHours = 0;

                    decimal totalWeekendOverTime = 0;
                    decimal totalNightOverTime = 0;
                    decimal totalSaturdayOverTime = 0;
                    decimal totalSundayOverTime = 0;

                    decimal totalWeekendOverTimeHours = 0;
                    decimal totalNightOverTimeHours = 0;
                    decimal totalSaturdayOverTimeHours = 0;
                    decimal totalSundayOverTimeHours = 0;

                    decimal totalOverTime = 0;
                    decimal overtimeTaxableIncome = 0;

                    bool overTimeFound = false;
                    bool overTimeFoundDaily = false;
                    bool overTimeFoundWeekend = false;
                    bool overTimeFoundNight = false;

                    bool overTimeError = false;
                    attendance.OverTimes.Clear();

                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = attendance.Employee.StaffID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Archived",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    overTimes =dal.GetByCriteria<OverTime>(query);
                    foreach (OverTimeType overTimeType in overTimeTypes)
                    {
                        foreach (OverTime overTime in overTimes)
                        {
                            if (overTime.In_Use == true && overTime.OverTimeType.ID == 1 && overTime.OverTimeType.Description == overTimeType.Description && overTime.Employee.StaffID == employee.StaffID && (overTime.Date.Value.Date.Month == attendanceDate.Month && overTime.Date.Value.Date.Year == attendanceDate.Year))
                            {
                                totalPublicHolidayOverTime += overTime.Amount;
                                totalPublicHolidayOverTimeHours += overTime.HrsWorked;
                                if (overTime.IsTaxable == true)
                                {
                                    overtimeTaxableIncome += overTime.Amount;
                                }

                                attendance.OverTimes.Add(
                                    new OverTime()
                                    {
                                        Amount = overTime.Amount,
                                        Date = overTime.Date,
                                        OverTimeType = overTimeType,
                                        Holiday = overTime.Holiday,
                                        OverTimeRate = overTime.OverTimeRate,
                                        
                                        TotalShifts = overTime.TotalShifts,
                                        HrsWorked = overTime.HrsWorked,
                                        Employee = attendance.Employee
                                    });
                                overTimeFound = true;
                            }
                            else if (overTime.In_Use == true && overTime.OverTimeType.ID == 2 && overTime.OverTimeType.Description == overTimeType.Description && overTime.Employee.StaffID == employee.StaffID && (overTime.Date.Value.Date.Month == attendanceDate.Month && overTime.Date.Value.Date.Year == attendanceDate.Year))
                            {
                                totalDailyOverTime += overTime.Amount;
                                totalDailyOverTimeHours += overTime.HrsWorked;
                                if (overTime.IsTaxable == true)
                                {
                                    overtimeTaxableIncome += overTime.Amount;

                                }
                                attendance.OverTimes.Add(
                                    new OverTime()
                                    {
                                        Amount = overTime.Amount,
                                        Date = overTime.Date,
                                        OverTimeType = overTimeType,
                                        OverTimeRate = overTime.OverTimeRate,
                                        TotalShifts = overTime.TotalShifts,
                                        HrsWorked = overTime.HrsWorked,
                                        Employee = attendance.Employee
                                    });
                                overTimeFoundDaily = true;
                            }
                            else if (overTime.In_Use == true && overTime.OverTimeType.ID == 3 && overTime.OverTimeType.Description == overTimeType.Description && overTime.Employee.StaffID == employee.StaffID && (overTime.Date.Value.Date.Month == attendanceDate.Month && overTime.Date.Value.Date.Year == attendanceDate.Year))
                            {
                                totalWeekendOverTime += overTime.Amount;
                                totalWeekendOverTimeHours += overTime.HrsWorked;

                                totalSaturdayOverTime += overTime.Amount;
                                totalSaturdayOverTimeHours += overTime.HrsWorked;

                                if (overTime.IsTaxable == true)
                                {
                                    overtimeTaxableIncome += overTime.Amount;

                                }
                                attendance.OverTimes.Add(
                                    new OverTime()
                                    {
                                        Amount = overTime.Amount,
                                        Date = overTime.Date,
                                        OverTimeType = overTimeType,
                                        OverTimeRate = overTime.OverTimeRate,
                                        TotalShifts = overTime.TotalShifts,
                                        HrsWorked = overTime.HrsWorked,
                                        Employee = attendance.Employee
                                    });
                                overTimeFoundWeekend = true;
                            }
                            else if (overTime.In_Use == true && overTime.OverTimeType.ID == 4 && overTime.OverTimeType.Description == overTimeType.Description && overTime.Employee.StaffID == employee.StaffID && (overTime.Date.Value.Date.Month == attendanceDate.Month && overTime.Date.Value.Date.Year == attendanceDate.Year))
                            {
                                totalWeekendOverTime += overTime.Amount;
                                totalWeekendOverTimeHours += overTime.HrsWorked;

                                totalSundayOverTime += overTime.Amount;
                                totalSundayOverTimeHours += overTime.HrsWorked;

                                if (overTime.IsTaxable == true)
                                {
                                    overtimeTaxableIncome += overTime.Amount;

                                }
                                attendance.OverTimes.Add(
                                    new OverTime()
                                    {
                                        Amount = overTime.Amount,
                                        Date = overTime.Date,
                                        OverTimeType = overTimeType,
                                        OverTimeRate = overTime.OverTimeRate,
                                        TotalShifts = overTime.TotalShifts,
                                        HrsWorked = overTime.HrsWorked,
                                        Employee = attendance.Employee
                                    });
                                overTimeFoundWeekend = true;
                            }
                            else if (overTime.In_Use == true && overTime.OverTimeType.ID == 5 && overTime.OverTimeType.Description == overTimeType.Description && overTime.Employee.StaffID == employee.StaffID && (overTime.Date.Value.Date.Month == attendanceDate.Month && overTime.Date.Value.Date.Year == attendanceDate.Year))
                            {
                                totalNightOverTime += overTime.Amount;
                                totalNightOverTimeHours += overTime.HrsWorked;
                                if (overTime.IsTaxable == true)
                                {
                                    overtimeTaxableIncome += overTime.Amount;

                                }
                                attendance.OverTimes.Add(
                                    new OverTime()
                                    {
                                        Amount = overTime.Amount,
                                        Date = overTime.Date,
                                        OverTimeType = overTimeType,
                                        OverTimeRate = overTime.OverTimeRate,
                                        TotalShifts = overTime.TotalShifts,
                                        HrsWorked = overTime.HrsWorked,
                                        Employee = attendance.Employee
                                    });
                                overTimeFoundNight = true;
                            }

                        }
                        //if (!overTimeFoundDaily)
                        //{
                        //    attendance.OverTimes.Add(
                        //        new OverTime()
                        //        {
                        //            Amount = 0,
                        //            Date = GlobalData.ServerDate,
                        //            OverTimeType = overTimeType,
                        //            OverTimeRate = 0,
                        //            TotalShifts = 0,
                        //            HrsWorked = 0,
                        //            Employee = attendance.Employee
                        //        });
                        //}
                        //if (!overTimeFound)
                        //{
                        //    attendance.OverTimes.Add(
                        //        new OverTime()
                        //        {
                        //            Amount = 0,
                        //            Date = GlobalData.ServerDate,
                        //            OverTimeType = overTimeType,
                        //            OverTimeRate = 0,
                        //            TotalShifts = 0,
                        //            HrsWorked = 0,
                        //            Employee = attendance.Employee
                        //        });
                        //}
                        //if (!overTimeFoundWeekend)
                        //{
                        //    attendance.OverTimes.Add(
                        //        new OverTime()
                        //        {
                        //            Amount = 0,
                        //            Date = GlobalData.ServerDate,
                        //            OverTimeType = overTimeType,
                        //            OverTimeRate = 0,
                        //            TotalShifts = 0,
                        //            HrsWorked = 0,
                        //            Employee = attendance.Employee
                        //        });
                        //}
                        //if (!overTimeFoundNight)
                        //{
                        //    attendance.OverTimes.Add(
                        //        new OverTime()
                        //        {
                        //            Amount = 0,
                        //            Date = GlobalData.ServerDate,
                        //            OverTimeType = overTimeType,
                        //            OverTimeRate = 0,
                        //            TotalShifts = 0,
                        //            HrsWorked = 0,
                        //            Employee = attendance.Employee
                        //        });
                        //}

                    }
                    
                    //OverTime
                    totalOverTime = totalPublicHolidayOverTime + totalDailyOverTime + totalWeekendOverTime + totalNightOverTime;
                    attendance.TotalOverTime = Math.Round(totalOverTime, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridTotalOverTimes"].Value = Math.Round(attendance.TotalOverTime, 2, MidpointRounding.AwayFromZero);
                    

                    attendance.PublicHolidayOverTime = Math.Round(totalPublicHolidayOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.PublicHolidayOverTimeHours = Math.Round(totalPublicHolidayOverTimeHours, 2, MidpointRounding.AwayFromZero);
                    attendance.DailyOverTime = Math.Round(totalDailyOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.DailyOverTimeHours = Math.Round(totalDailyOverTimeHours, 2, MidpointRounding.AwayFromZero);

                    attendance.WeekendOverTime = Math.Round(totalWeekendOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.WeekendOverTimeHours = Math.Round(totalWeekendOverTimeHours, 2, MidpointRounding.AwayFromZero);

                    attendance.SaturdayOverTime = Math.Round(totalSaturdayOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.SaturdayOverTimeHours = Math.Round(totalSaturdayOverTimeHours, 2, MidpointRounding.AwayFromZero);
                    attendance.SundayOverTime = Math.Round(totalSundayOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.SundayOverTimeHours = Math.Round(totalSaturdayOverTimeHours, 2, MidpointRounding.AwayFromZero);

                    attendance.NightOverTime = Math.Round(totalNightOverTime, 2, MidpointRounding.AwayFromZero);
                    attendance.NightOverTimeHours = Math.Round(totalNightOverTimeHours, 2, MidpointRounding.AwayFromZero);

                    attendance.TotalOverTimeHours = Math.Round(totalPublicHolidayOverTimeHours + totalWeekendOverTimeHours + totalDailyOverTimeHours + totalNightOverTimeHours, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridTotalOverTimeHours"].Value = Math.Round(attendance.TotalOverTimeHours, 2, MidpointRounding.AwayFromZero);

                    if (overTimeError)
                    {
                        SetRowColor(grid.Rows[ctr], Color.Red);
                        errorString += attendance.Name + "'s OverTime has an error information section.\n\n";
                    }

                    
                    //Arrears
                    attendance.Arrears = 0;
                    decimal currentSSNITCont = 0;
                    decimal previousSSNITCont = 0;
                    decimal diffSSNITCont = 0;
                    decimal currentSSNITEmployerCont = 0;
                    decimal previousSSNITEmployerCont = 0;
                    decimal diffSSNITEmployerCont = 0;
                    decimal totalArrearsSSNITEmployee = 0;
                    decimal totalArrearsSSNITEmployer = 0;

                    decimal previousArrearsIncomeTax=0;
                    decimal currentArrearsIncomeTax = 0;
                    decimal diffArrearsIncomeTax = 0;
                    decimal totalArrearsIncomeTax = 0;

                    decimal previousArrearsTaxableIncome = 0;
                    decimal currentArrearsTaxableIncome = 0;
                    decimal totalArrearsTaxableIncome = 0;

                    bool arrearsError=false;
                    decimal amount = 0;
                    grid.Rows[ctr].Cells["gridArrears"].Value = 0;

                    foreach (Arrears arrear in arrears)
                    {
                        if (arrear.In_Use == true && arrear.Employee.StaffID == employee.StaffID && ((arrear.EffectiveDate.Value.Date == attendanceDate)))
                        {
                            amount = arrear.PreviousSalary * arrear.NumberOfTimes;
                            if (arrear.Type.ToLower().Trim() == "normal")
                            {
                                if (arrear.SSNIT && arrear.IncomeTax)
                                {
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsSSNITEmployee = Math.Round(previousSSNITCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsSSNITEmployer = Math.Round(Math.Round((attendance.SsnitEmployerRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero) * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsTaxableIncome = Math.Round(arrear.PreviousSalary - previousSSNITCont, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsTaxableIncome = Math.Round(previousArrearsTaxableIncome * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, previousArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    totalArrearsIncomeTax = Math.Round(previousArrearsIncomeTax * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    attendance.Arrears += Math.Round(amount - (totalArrearsSSNITEmployee + totalArrearsIncomeTax), 2, MidpointRounding.AwayFromZero);
                                }
                                else if (arrear.SSNIT)
                                {
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsSSNITEmployee = Math.Round(previousSSNITCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsSSNITEmployer = Math.Round(Math.Round((attendance.SsnitEmployerRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero) * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    attendance.Arrears += Math.Round(amount - totalArrearsSSNITEmployee, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (arrear.IncomeTax)
                                {
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsTaxableIncome = Math.Round(arrear.PreviousSalary - previousSSNITCont, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsTaxableIncome = Math.Round(previousArrearsTaxableIncome * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, previousArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    totalArrearsIncomeTax = Math.Round(previousArrearsIncomeTax * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    attendance.Arrears += Math.Round(amount - totalArrearsIncomeTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    attendance.Arrears += Math.Round(amount, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                            else if (arrear.Type.ToLower().Trim() == "promotional")
                            {
                                if (arrear.SSNIT && arrear.IncomeTax)
                                {
                                    //Calculate SSNIT
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    currentSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.CurrentSalary, 2, MidpointRounding.AwayFromZero);
                                    diffSSNITCont = currentSSNITCont - previousSSNITCont;
                                    totalArrearsSSNITEmployee = Math.Round(diffSSNITCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);

                                    previousSSNITEmployerCont = Math.Round((attendance.SsnitEmployerRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    currentSSNITEmployerCont = Math.Round((attendance.SsnitEmployerRate / 100) * arrear.CurrentSalary, 2, MidpointRounding.AwayFromZero);
                                    diffSSNITEmployerCont = currentSSNITEmployerCont - previousSSNITEmployerCont;
                                    totalArrearsSSNITEmployer = Math.Round(diffSSNITEmployerCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    
                                    //Calculate Income Tax
                                    previousArrearsTaxableIncome = Math.Round(arrear.PreviousSalary - previousSSNITCont, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, previousArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    currentArrearsTaxableIncome = Math.Round(arrear.CurrentSalary - currentSSNITCont, 2, MidpointRounding.AwayFromZero);
                                    totalArrearsTaxableIncome = Math.Round((currentArrearsTaxableIncome + previousArrearsTaxableIncome) * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    currentArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, currentArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    diffArrearsIncomeTax = currentArrearsIncomeTax - previousArrearsIncomeTax;
                                    totalArrearsIncomeTax = Math.Round(diffArrearsIncomeTax * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    attendance.Arrears += Math.Round(amount - (totalArrearsSSNITEmployee + totalArrearsIncomeTax), 2, MidpointRounding.AwayFromZero);
                                }
                                else if (arrear.SSNIT)
                                {
                                    //Calculate SSNIT
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    currentSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.CurrentSalary, 2, MidpointRounding.AwayFromZero);
                                    diffSSNITCont = currentSSNITCont - previousSSNITCont;
                                    totalArrearsSSNITEmployee = Math.Round(diffSSNITCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    
                                    previousSSNITEmployerCont = Math.Round((attendance.SsnitEmployerRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    currentSSNITEmployerCont = Math.Round((attendance.SsnitEmployerRate / 100) * arrear.CurrentSalary, 2, MidpointRounding.AwayFromZero);
                                    diffSSNITEmployerCont = currentSSNITEmployerCont - previousSSNITEmployerCont;
                                    totalArrearsSSNITEmployer = Math.Round(diffSSNITEmployerCont * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    
                                    attendance.Arrears += Math.Round(amount - totalArrearsSSNITEmployee, 2, MidpointRounding.AwayFromZero);
                                }
                                else if (arrear.IncomeTax)
                                {
                                    //Calculate SSNIT
                                    previousSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.PreviousSalary, 2, MidpointRounding.AwayFromZero);
                                    currentSSNITCont = Math.Round((attendance.SsnitEmployeeRate / 100) * arrear.CurrentSalary, 2, MidpointRounding.AwayFromZero);

                                    //Calculate Income Tax
                                    previousArrearsTaxableIncome = Math.Round(arrear.PreviousSalary - previousSSNITCont, 2, MidpointRounding.AwayFromZero);
                                    previousArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, previousArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    currentArrearsTaxableIncome = Math.Round(arrear.CurrentSalary - currentSSNITCont, 2, MidpointRounding.AwayFromZero);

                                    totalArrearsTaxableIncome = Math.Round((currentArrearsTaxableIncome + previousArrearsTaxableIncome) * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    currentArrearsIncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, currentArrearsTaxableIncome, ref arrearsError), 2, MidpointRounding.AwayFromZero);
                                    diffArrearsIncomeTax = currentArrearsIncomeTax - previousArrearsIncomeTax;
                                    totalArrearsIncomeTax = Math.Round(diffArrearsIncomeTax * arrear.NumberOfTimes, 2, MidpointRounding.AwayFromZero);
                                    attendance.Arrears += Math.Round(amount - totalArrearsIncomeTax, 2, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    attendance.Arrears += Math.Round(amount, 2, MidpointRounding.AwayFromZero);
                                }
                            }
                        }
                    }

                    if (attendance.Arrears == 0)
                    {
                        grid.Rows[ctr].Cells["gridArrears"].Value = 0.00;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridArrears"].Value = attendance.Arrears;
                    }

                    try
                    {
                        if (attendance.IsProvidentFund)
                        {
                            //Provident Fund Employee
                            if (employee.PFRate == 0)
                            {
                                attendance.ProvidentFundEmployeeRate = ssnitContributions[0].ProvidentFundEmployeeRate;
                            }
                            else
                            {
                                attendance.ProvidentFundEmployeeRate = employee.PFRate ;
                            }
                            
                            attendance.ProvidentFundEmployee = Math.Round((attendance.ProvidentFundEmployeeRate / 100) * attendance.BasicSalary, 2, MidpointRounding.AwayFromZero);
                            grid.Rows[ctr].Cells["gridProvidentFundEmployee"].Value = Math.Round(attendance.ProvidentFundEmployee, 2, MidpointRounding.AwayFromZero);

                            //Provident Fund Employer
                            attendance.ProvidentFundEmployerRate = ssnitContributions[0].ProvidentFundEmployerRate;
                            attendance.ProvidentFundEmployer = Math.Round((attendance.ProvidentFundEmployerRate / 100) * attendance.BasicSalary, 2, MidpointRounding.AwayFromZero);
                            grid.Rows[ctr].Cells["gridProvidentFundEmployer"].Value = Math.Round(attendance.ProvidentFundEmployer, 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            //Provident Fund Employee
                            attendance.ProvidentFundEmployee = 0;
                            grid.Rows[ctr].Cells["gridProvidentFundEmployee"].Value = 0.00;

                            //Provident Fund Employer
                            attendance.ProvidentFundEmployer = 0;
                            grid.Rows[ctr].Cells["gridProvidentFundEmployer"].Value = 0.00;
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.LogError(ex);
                    }

                    bool ssnitError = false;
                    //SSNIT Contribution
                    if (employee.SSNITContribution)
                    {
                        //SSNITNo
                        attendance.SsnitNo = employee.SSNITNo;
                        grid.Rows[ctr].Cells["gridSSNITNo"].Value = attendance.SsnitNo;

                        //Catch error in snnit setup (i.e. no ssnit contribution setup) Likely causes no values setup or no row exists in SnnitContributions table in database. This section requires one row to exist in the SnnitContributions table
                        try
                        {
                            //SSNITFirstTierRate
                            //attendance.SSNITFirstTierRate = ssnitContributions[0].SSNITFirstTierRate;

                            //SecondTierRate
                            attendance.SecondTierRate = ssnitContributions[0].SecondTierRate;

                            if (attendance.Employee.IsExemptFromSecondTier)
                            {
                                //Employee
                                attendance.SSNITEmployee = Math.Round(((attendance.SsnitEmployeeRate / 100) * attendance.BasicSalary) + totalArrearsSSNITEmployee, 2, MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = Math.Round(attendance.SSNITEmployee, 2, MidpointRounding.AwayFromZero);

                                //Employer
                                attendance.SSNITEmployer = Math.Round(((attendance.SsnitEmployerRate / 100) * attendance.BasicSalary) + totalArrearsSSNITEmployer, 2, MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = Math.Round(attendance.SSNITEmployer, 2, MidpointRounding.AwayFromZero);

                                //SSNITFirstTier
                                attendance.SSNITFirstTier = Math.Round(((attendance.SSNITFirstTierRate / 100) * attendance.BasicSalary), 2, MidpointRounding.AwayFromZero); ;
                                grid.Rows[ctr].Cells["gridSSNITFirstTier"].Value = Math.Round(attendance.SSNITFirstTier, 2, MidpointRounding.AwayFromZero);

                                //SecondTier
                                attendance.SecondTier = 0;
                                grid.Rows[ctr].Cells["gridSecondTier"].Value = 0.00;

                            }
                            else
                            {
                                //Employee
                                attendance.SSNITEmployee = Math.Round(((attendance.SsnitEmployeeRate / 100) * attendance.BasicSalary) + totalArrearsSSNITEmployee, 2, MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = Math.Round(attendance.SSNITEmployee, 2, MidpointRounding.AwayFromZero);

                                //Employer
                                attendance.SSNITEmployer = Math.Round(((attendance.SsnitEmployerRate / 100) * attendance.BasicSalary) + totalArrearsSSNITEmployer, 2, MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = Math.Round(attendance.SSNITEmployer, 2, MidpointRounding.AwayFromZero);

                                //SSNITFirstTier
                                attendance.SSNITFirstTier = Math.Round(((attendance.SSNITFirstTierRate / 100) * attendance.BasicSalary), 2, MidpointRounding.AwayFromZero); ;
                                grid.Rows[ctr].Cells["gridSSNITFirstTier"].Value = Math.Round(attendance.SSNITFirstTier, 2, MidpointRounding.AwayFromZero);

                                //SecondTier
                                attendance.SecondTier = Math.Round(((attendance.SecondTierRate / 100) * attendance.BasicSalary), 2, MidpointRounding.AwayFromZero); ;
                                grid.Rows[ctr].Cells["gridSecondTier"].Value = Math.Round(attendance.SecondTier, 2, MidpointRounding.AwayFromZero);
                            }

                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                            SetRowColor(grid.Rows[ctr], Color.Red);
                            errorString += "The ssnit employee and employer contributions have not been setup.\n\n";
                            ssnitError = true;
                        }
                    }
                    else
                    {
                        //Employee
                        attendance.SSNITEmployee = 0;
                        grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = 0.00;

                        //Employer
                        attendance.SSNITEmployer = 0;
                        grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = 0.00;

                        //SSNITFirstTier
                        attendance.SSNITFirstTier = 0;
                        grid.Rows[ctr].Cells["gridSSNITFirstTier"].Value = 0.00;

                        //SecondTier
                        attendance.SecondTier = 0;
                        grid.Rows[ctr].Cells["gridSecondTier"].Value = 0.00;
                    }


                    

                    //Total Tax Allowance
                    attendance.AllowanceTax += Math.Round(totalTaxableAllowance + overtimeTaxableIncome, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridTotalTaxAllowance"].Value = Math.Round(attendance.AllowanceTax, 2, MidpointRounding.AwayFromZero);
                    attendance.NonAllowanceTax += Math.Round((totalAllowance - totalTaxableAllowance) + (totalOverTime - overtimeTaxableIncome), 2, MidpointRounding.AwayFromZero);

                    if (employee.CurrentTaxReliefMonth >= attendance.Month && attendance.Year == employee.CurrentTaxReliefYear)
                    {
                        attendance.UpfrontRelief = employee.CurrentTaxRelief;
                    }
                    
                    //Basic Salary Taxable Income
                    decimal basicSalaryTaxableIncome = 0;
                    basicSalaryTaxableIncome = Math.Round((attendance.BasicSalary - attendance.SSNITEmployee - attendance.ProvidentFundEmployee) + (1 * attendance.AllowanceTax) - attendance.UpfrontRelief, 2, MidpointRounding.AwayFromZero);

                    //apple tax relief
                    //if (employee.CurrentTaxReliefMonth > attendance.Month && attendance.Year == employee.CurrentTaxReliefYear)
                    //{
                    //    basicSalaryTaxableIncome -= attendance.UpfrontRelief;
                    //}
                    
                    
                    //Staff Total Taxable Income
                    attendance.TaxableIncome = Math.Round(basicSalaryTaxableIncome + totalArrearsTaxableIncome, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridTaxableIncome"].Value = Math.Round(attendance.TaxableIncome, 2, MidpointRounding.AwayFromZero);


                    //Calculate Income Tax
                    bool taxError = false;
                    if (employee.IncomeTaxContribution)
                    {
                        attendance.IncomeTax = Math.Round(CalculateIncomeTax(attendance.Year, basicSalaryTaxableIncome, ref taxError) + totalArrearsIncomeTax, 2, MidpointRounding.AwayFromZero);
                        grid.Rows[ctr].Cells["gridIncomeTax"].Value = Math.Round(attendance.IncomeTax, 2, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        attendance.IncomeTax = 0;
                        grid.Rows[ctr].Cells["gridIncomeTax"].Value = 0.00;
                    }

                    if (taxError)
                    {
                        SetRowColor(grid.Rows[ctr], Color.Red);
                        errorString += "The income tax contribution values have not been setup.";
                    }

                    bool susuPlusError = false;
                    //SUSU PLUS Contribution
                    if (employee.IsSusuPlusContribution)
                    {
                        //SUSU PLUS AMOUNT
                        attendance.SusuPlusContributionAmount = Math.Round(employee.SusuPlusContributionAmount,2,MidpointRounding.AwayFromZero);
                        grid.Rows[ctr].Cells["gridSusuPlusContribution"].Value = Math.Round(attendance.SusuPlusContributionAmount,2,MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        attendance.SusuPlusContributionAmount = 0;
                        grid.Rows[ctr].Cells["gridSusuPlusContribution"].Value = 0.00;
                    }

                    bool withholdingTaxPlusError = false;
                    //WITHHOLDING TAX
                    if (employee.IsWithholdingTax)
                    {
                        if (employee.IsWithholdingTaxFixedAmount)
                        {
                            //FIXED AMOUNT
                            attendance.WithholdingTaxFixedAmount = Math.Round(employee.WithholdingTaxFixedAmount,2,MidpointRounding.AwayFromZero);
                            grid.Rows[ctr].Cells["gridWithholdingTaxFixedAmount"].Value = Math.Round(attendance.WithholdingTaxFixedAmount, 2,MidpointRounding.AwayFromZero);
                            attendance.WithholdingAmount = 0;
                            attendance.SalaryType.Description = string.Empty;
                            grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = "NA";
                            grid.Rows[ctr].Cells["gridWithholdingTaxRate"].Value = "NA";
                            grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = "NA";
                        }
                        else if (employee.IsWithholdingTaxRate)
                        {
                            attendance.WithholdingTaxRate = Math.Round(employee.WithholdingTaxRate,2,MidpointRounding.AwayFromZero);
                            grid.Rows[ctr].Cells["gridWithholdingTaxRate"].Value = Math.Round(attendance.WithholdingTaxRate, 2,MidpointRounding.AwayFromZero);
                            attendance.SalaryType.Description = employee.SalaryType.Description;
                            attendance.SalaryType.ID = employee.SalaryType.ID;
                            grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = attendance.SalaryType.Description;
                            if (attendance.SalaryType.ID == 1)
                            {
                                attendance.WithholdingAmount = Math.Round((attendance.WithholdingTaxRate/100) * attendance.BasicSalary,2,MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = Math.Round(attendance.WithholdingAmount, 2,MidpointRounding.AwayFromZero);
                            }
                            else if (attendance.SalaryType.ID == 2)
                            {
                                attendance.WithholdingAmount = Math.Round((attendance.WithholdingTaxRate / 100) * attendance.GrossSalary,2,MidpointRounding.AwayFromZero);
                                grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = Math.Round(attendance.WithholdingAmount, 2,MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                attendance.WithholdingAmount = 0;
                                attendance.SalaryType.Description = string.Empty;
                                grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = Math.Round(attendance.WithholdingAmount, 2,MidpointRounding.AwayFromZero);
                            }
                            attendance.WithholdingTaxFixedAmount = 0;
                            grid.Rows[ctr].Cells["gridWithholdingTaxFixedAmount"].Value = "NA";
                        }
                        else
                        {
                            //All Zero
                            attendance.WithholdingTaxFixedAmount = 0;
                            grid.Rows[ctr].Cells["gridWithholdingTaxFixedAmount"].Value = "NA";
                            attendance.WithholdingTaxRate = 0;
                            grid.Rows[ctr].Cells["gridWithholdingTaxRate"].Value = "NA";
                            attendance.SalaryType.Description = string.Empty;
                            grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = "NA";
                            grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = "NA";
                        }
                    }
                    else
                    {
                        attendance.WithholdingTaxFixedAmount = 0;
                        grid.Rows[ctr].Cells["gridWithholdingTaxFixedAmount"].Value = 0.00;
                        attendance.WithholdingTaxRate = 0;
                        grid.Rows[ctr].Cells["gridWithholdingTaxRate"].Value = 0.00;
                        attendance.SalaryType.Description = string.Empty;
                        grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = "NA";
                        grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = 0.00;
                    }
                    //Calculate Totals
                    
                    attendance.GrandTotalAllowance = Math.Round(attendance.TotalAllowance + attendance.MedicalClaims + attendance.Arrears + attendance.TotalOverTime, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridGrandTotalAllowance"].Value = Math.Round(attendance.GrandTotalAllowance, 2, MidpointRounding.AwayFromZero);

                    //Gross Salary
                    attendance.GrossSalary = Math.Round(attendance.BasicSalary + attendance.GrandTotalAllowance, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridGrossSalary"].Value = Math.Round(attendance.GrossSalary, 2, MidpointRounding.AwayFromZero);

                    //Other Deductions
                    decimal totalDeduction = 0;
                    bool deductionFound = false;
                    attendance.Deductions.Clear();
                    if (checkBoxExemptOtherDeductions.Checked == false)
                    {
                        foreach (Deduction deductionType in deductionTypes)
                        {
                            deductionFound = false;
                            if (deductionType.Inactive)
                            {
                                foreach (StaffDeduction deduction in staffDeductions)
                                {
                                    if (deduction.IsEndDate == true && deduction.EndDate != null)
                                    {
                                        if (deduction.InUse == true && deduction.Employee.StaffID == employee.StaffID && (attendanceDate >= deduction.EffectiveDate.Value.Date && attendanceDate <= deduction.EndDate.Value.Date) && deduction.Type.Description == deductionType.Description)
                                        {
                                            if (deductionType.RateBased && deductionType.CalculatedOn.Description == "Basic")
                                            {
                                                deduction.Amount = deductionType.Rate * attendance.BasicSalary;
                                            }
                                            else if (deductionType.RateBased && deductionType.CalculatedOn.Description == "Gross")
                                            {
                                                deduction.Amount = deductionType.Rate * attendance.GrossSalary;
                                            }
                                            totalDeduction += deduction.Amount;
                                            attendance.Deductions.Add(
                                                new StaffDeduction()
                                                {
                                                    Amount = deduction.Amount,
                                                    EffectiveDate = deduction.EffectiveDate,
                                                    Type = deductionType,
                                                    Frequency = deduction.Frequency,
                                                    IsEndDate = deduction.IsEndDate,
                                                    EndDate = deduction.EndDate,
                                                    Employee = attendance.Employee
                                                });
                                            deductionFound = true;
                                        }
                                    }
                                    else if (deduction.InUse == true && deduction.Employee.StaffID == employee.StaffID && (deduction.EffectiveDate.Value.Date <= attendanceDate) && deduction.Type.Description == deductionType.Description)
                                    {
                                        if (deductionType.RateBased && deductionType.CalculatedOn.Description == "Basic")
                                        {
                                            deduction.Amount = deductionType.Rate * attendance.BasicSalary;
                                        }
                                        else if (deductionType.RateBased && deductionType.CalculatedOn.Description == "Gross")
                                        {
                                            deduction.Amount = deductionType.Rate * attendance.GrossSalary;
                                        }
                                        totalDeduction += deduction.Amount;
                                        attendance.Deductions.Add(
                                            new StaffDeduction()
                                            {
                                                Amount = deduction.Amount,
                                                EffectiveDate = deduction.EffectiveDate,
                                                Type = deductionType,
                                                Frequency = deduction.Frequency,
                                                IsEndDate = deduction.IsEndDate,
                                                EndDate = deduction.EndDate,
                                                Employee = attendance.Employee
                                            });
                                        deductionFound = true;
                                    }
                                }
                                //if (!deductionFound)
                                //{
                                //    attendance.Deductions.Add(
                                //        new StaffDeduction()
                                //        {
                                //            Amount = 0,
                                //            EffectiveDate = GlobalData.ServerDate,
                                //            Type = deductionType,
                                //            Frequency = string.Empty,
                                //            IsEndDate = false,
                                //            EndDate = null,
                                //            Employee = attendance.Employee
                                //        });
                                //}
                            }
                        }
                    }
                    //Other Deductions
                    grid.Rows[ctr].Cells["gridDeductions"].Value = Math.Round(totalDeduction, 2, MidpointRounding.AwayFromZero);
                    attendance.TotalDeductions += Math.Round(totalDeduction, 2, MidpointRounding.AwayFromZero);


                    attendance.GrandTotalDeductions = Math.Round(attendance.SSNITEmployee + attendance.ProvidentFundEmployee + attendance.SusuPlusContributionAmount + attendance.WithholdingAmount + attendance.TotalDeductions + attendance.TotalLoans, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridGrandTotalDeduction"].Value = decimal.Round(attendance.GrandTotalDeductions, 2, MidpointRounding.AwayFromZero);
                    

                    //Net After Tax
                    attendance.TotalTax = Math.Round(attendance.IncomeTax + attendance.TotalBonusTax + attendance.TotalOverTimeTax, 2, MidpointRounding.AwayFromZero);
                    attendance.NetAfterTax = Math.Round(attendance.GrossSalary - attendance.TotalTax, 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridNetAfterTax"].Value = Math.Round(attendance.NetAfterTax, 2,MidpointRounding.AwayFromZero);

                    //Net Salary
                    attendance.NetSalary = Math.Round(attendance.GrossSalary - (attendance.GrandTotalDeductions + attendance.TotalTax), 2, MidpointRounding.AwayFromZero);
                    grid.Rows[ctr].Cells["gridNetSalary"].Value = Math.Round(attendance.NetSalary, 2, MidpointRounding.AwayFromZero);

                    //Calculate TakeHome
                    attendance.TakeHome = attendance.NetSalary;
                    grid.Rows[ctr].Cells["gridTakeHome"].Value = Math.Round(attendance.TakeHome, 2, MidpointRounding.AwayFromZero);

                    //Calculate 
                    attendance.TotalCost += Math.Round(attendance.BasicSalary + attendance.TotalAllowance + attendance.TotalOverTime + attendance.MedicalClaims + attendance.SSNITEmployer + attendance.ProvidentFundEmployer,2,MidpointRounding.AwayFromZero);
                    attendance.TotalPayable += Math.Round(attendance.NetSalary + attendance.TotalDeductions + attendance.TotalLoans + attendance.IncomeTax + attendance.SSNITEmployer + attendance.SSNITEmployee + attendance.SusuPlusContributionAmount + attendance.WithholdingAmount + attendance.ProvidentFundEmployee + attendance.ProvidentFundEmployer,2,MidpointRounding.AwayFromZero);
                    
                    //User
                    attendance.User.ID = GlobalData.User.ID;
                    attendance.Status = "1";
                    grid.Rows[ctr].Cells["gridStatus"].Value = (PayRollStatus)Enum.Parse(typeof(PayRollStatus), attendance.Status);

                    if (!taxError && !ssnitError && !salaryError && !susuPlusError && !withholdingTaxPlusError)
                    {
                        dal.Save(attendance);
                        actualBasicSalary += attendance.ActualBasicSalary;
                        basicSalary += attendance.BasicSalary;
                        incomeTax += attendance.IncomeTax;
                        ssnit += attendance.SSNITEmployee;
                        ssER +=attendance.SSNITEmployer;
                        providentFundEmployee += attendance.ProvidentFundEmployee;
                        providentFundEmployer += attendance.ProvidentFundEmployer;
                        taxableIncome += attendance.TaxableIncome;
                        grossIncome += attendance.GrossSalary;
                        netPay += attendance.TakeHome;
                        grandTotalLoan += attendance.TotalLoans;
                        grandTotalAllowance += attendance.GrandTotalAllowance;
                        grandTotalDeduction += attendance.GrandTotalDeductions;
                        attendances.Add(attendance);
                    }
                    else
                    {
                        payRollErrors.Add(attendance.Employee.StaffID.ToString(), errorString);
                    }
                    ctr++;
                }

                dal.CommitTransaction();
                txtNoPayrollStaff.Text = attendances.Count().ToString();
                txtBasicSalary.Text = actualBasicSalary.ToString();
                txtTotalSalaryEarned.Text = basicSalary.ToString();
                txtGrossIncome.Text = grossIncome.ToString();
                txtIncomeTax.Text = incomeTax.ToString();
                txtNetPay.Text = netPay.ToString();
                txtSSNIT.Text = ssnit.ToString();
                txtSSNITER.Text = ssER.ToString();
                txtProvidentFundEmployee.Text = providentFundEmployee.ToString();
                txtProvidentFundEmployer.Text = providentFundEmployer.ToString();
                txtTaxableIncome.Text = taxableIncome.ToString();
                txtTotalAllowance.Text = grandTotalAllowance.ToString();
                txtTotalDeduction.Text = grandTotalDeduction.ToString();
                txtTotalLoan.Text = grandTotalLoan.ToString();

                PayRoll payroll = new PayRoll();
                payroll.Month = GlobalData.GetMonth(periodComboBox.Text.Trim()).ToString();
                payroll.Year = yearComboBox.Text.Trim();
                payroll.Status = PayRollStatus.Open.ToString();
                //payroll=dal.GetByID<PayRoll>(payroll);
                 dal.Save(payroll);
                
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                throw ex;
            }
            finally
            {
                this.Enabled = true;//optional
                this.UseWaitCursor = false;
            }
        }

        private void SetRowColor(DataGridViewRow row , Color color)
        {
            try
            {
                row.Cells["gridStaffNo"].Style.BackColor = color;
                row.Cells["gridStaffCode"].Style.BackColor = color;
                row.Cells["gridTitle"].Style.BackColor = color;
                row.Cells["gridName"].Style.BackColor = color;
                row.Cells["gridAttendanceDays"].Style.BackColor = color;
                row.Cells["gridBasicSalary"].Style.BackColor = color;
                row.Cells["gridActualBasicSalary"].Style.BackColor = color;
                row.Cells["gridMonth"].Style.BackColor = color;
                row.Cells["gridYear"].Style.BackColor = color;
                row.Cells["gridSNNITEmployee"].Style.BackColor = color;
                row.Cells["gridSSNITEmployer"].Style.BackColor = color;
                row.Cells["gridSSNITFirstTier"].Style.BackColor = color;
                row.Cells["gridSecondTier"].Style.BackColor = color;
                row.Cells["gridProvidentFundEmployee"].Style.BackColor = color;
                row.Cells["gridProvidentFundEmployer"].Style.BackColor = color;
                row.Cells["gridIncomeTax"].Style.BackColor = color;
                row.Cells["gridNetAfterTax"].Style.BackColor = color;
                row.Cells["gridNetSalary"].Style.BackColor = color;
                row.Cells["gridMedicalClaims"].Style.BackColor = color;
                row.Cells["gridArrears"].Style.BackColor = color;
                row.Cells["gridAllowances"].Style.BackColor = color;
                row.Cells["gridTotalOverTimes"].Style.BackColor = color;
                row.Cells["gridTotalTaxAllowance"].Style.BackColor = color;
                row.Cells["gridTotalOverTimeHours"].Style.BackColor = color;
                
                row.Cells["gridDeductions"].Style.BackColor = color;
                row.Cells["gridGrandTotalAllowance"].Style.BackColor = color;
                row.Cells["gridGrandTotalDeduction"].Style.BackColor = color;
                row.Cells["gridTakeHome"].Style.BackColor = color;
                row.Cells["gridLoan"].Style.BackColor = color;
                row.Cells["gridInitialLoan"].Style.BackColor = color;
                row.Cells["gridPaymentMode"].Style.BackColor = color;
                row.Cells["gridDepartment"].Style.BackColor = color;
                row.Cells["gridSSNITNo"].Style.BackColor = color;
                row.Cells["gridGrade"].Style.BackColor = color;
                row.Cells["gridGradeLevel"].Style.BackColor = color;
                row.Cells["gridStatus"].Style.BackColor = color;
                row.Cells["gridWithholdingTaxCalculateOn"].Style.BackColor = color;
                row.Cells["gridWithholdingAmount"].Style.BackColor = color;
                row.Cells["gridWithholdingTaxRate"].Style.BackColor = color;
                row.Cells["gridWithholdingTaxFixedAmount"].Style.BackColor = color;
                row.Cells["gridSusuPlusContribution"].Style.BackColor = color;
                row.Cells["gridGrossSalary"].Style.BackColor = color;
                row.Cells["gridTaxableIncome"].Style.BackColor = color;
                row.Cells["gridEmail"].Style.BackColor = color;
                row.Cells["gridMobileNumber"].Style.BackColor = color;
                row.Cells["gridMechanised"].Style.BackColor = color;
                row.Cells["gridPaymentAccType"].Style.BackColor = color;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }
       
        private void PopulateView(IList<PayRollAttendance> attendances)
        {
            try
            {
                Query query = new Query();
         query.Criteria.Add(new Criterion()
                {
                    Property = "StaffSalaryPaymentView.Month",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = GlobalData.GetMonth(periodComboBox.Text),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffSalaryPaymentView.Year",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = yearComboBox.Text,
                    CriteriaOperator = CriteriaOperator.And
                });
                int ctr = 0;
                this.basicSalary = 0;
                this.actualBasicSalary = 0;
                this.grossIncome = 0;
                this.incomeTax = 0;
                this.ssnit = 0;
                this.ssER = 0;
                this.taxableIncome = 0;
                this.netPay = 0;
                this.grandTotalLoan = 0;
                this.grandTotalDeduction = 0;
                this.grandTotalAllowance = 0;
                grid.Rows.Clear();
                foreach (PayRollAttendance attendance in attendances)
                {
                 
                    grid.Rows.Add(1);

                    actualBasicSalary += attendance.ActualBasicSalary;
                    basicSalary += attendance.BasicSalary;
                    incomeTax += attendance.IncomeTax;
                    ssnit += attendance.SSNITEmployee;
                    ssER += attendance.SSNITEmployer;
                    taxableIncome += attendance.TaxableIncome;
                    grossIncome += attendance.GrossSalary;
                    netPay += attendance.TakeHome;
                    grandTotalLoan += attendance.TotalLoans;
                    grandTotalAllowance += attendance.GrandTotalAllowance;
                    grandTotalDeduction += attendance.GrandTotalDeductions;

                    grid.Rows[ctr].Cells["gridPaymentID"].Value = attendance.PaymentID;
                    grid.Rows[ctr].Cells["gridStaffNo"].Value = attendance.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = attendance.Employee.ID;
                    grid.Rows[ctr].Cells["gridTitle"].Value = attendance.Employee.Title.Description;
                    grid.Rows[ctr].Cells["gridName"].Value = attendance.Name;
                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = attendance.Attendance;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = attendance.BasicSalary;
                    grid.Rows[ctr].Cells["gridActualBasicSalary"].Value = attendance.ActualBasicSalary;
                    grid.Rows[ctr].Cells["gridMonth"].Value = (Months)Enum.Parse(typeof(Months), attendance.Month.ToString());
                    grid.Rows[ctr].Cells["gridYear"].Value = attendance.Year;
                    grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = attendance.SSNITEmployee;
                    grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = attendance.SSNITEmployer;
                    grid.Rows[ctr].Cells["gridSSNITFirstTier"].Value = attendance.SSNITFirstTier;
                    grid.Rows[ctr].Cells["gridSecondTier"].Value = attendance.SecondTier;
                    grid.Rows[ctr].Cells["gridProvidentFundEmployee"].Value = attendance.ProvidentFundEmployee;
                    grid.Rows[ctr].Cells["gridProvidentFundEmployer"].Value = attendance.ProvidentFundEmployer;
                    grid.Rows[ctr].Cells["gridIncomeTax"].Value = attendance.IncomeTax;
                    grid.Rows[ctr].Cells["gridNetAfterTax"].Value = attendance.NetAfterTax;
                    grid.Rows[ctr].Cells["gridNetSalary"].Value = attendance.NetSalary;
                    grid.Rows[ctr].Cells["gridMedicalClaims"].Value = attendance.MedicalClaims;
                    grid.Rows[ctr].Cells["gridArrears"].Value = attendance.Arrears;
                    grid.Rows[ctr].Cells["gridGrandTotalAllowance"].Value = attendance.GrandTotalAllowance;
                    grid.Rows[ctr].Cells["gridGrandTotalDeduction"].Value = attendance.GrandTotalDeductions;
                    grid.Rows[ctr].Cells["gridAllowances"].Value = attendance.TotalAllowance;
                    grid.Rows[ctr].Cells["gridTotalOverTimeHours"].Value = attendance.TotalOverTimeHours;
                    
                    grid.Rows[ctr].Cells["gridTotalTaxAllowance"].Value = attendance.AllowanceTax;
                    grid.Rows[ctr].Cells["gridTotalOverTimes"].Value = attendance.TotalOverTime;
                    grid.Rows[ctr].Cells["gridDeductions"].Value = attendance.TotalDeductions;
                    grid.Rows[ctr].Cells["gridTakeHome"].Value = attendance.TakeHome;
                    grid.Rows[ctr].Cells["gridLoan"].Value = attendance.TotalLoans;
                    grid.Rows[ctr].Cells["gridInitialLoan"].Value = attendance.InitialLoan;
                    grid.Rows[ctr].Cells["gridPaymentMode"].Value = attendance.PaymentMode;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = attendance.Department.Description;
                    grid.Rows[ctr].Cells["gridSSNITNo"].Value = attendance.SsnitNo;
                    grid.Rows[ctr].Cells["gridGrade"].Value = attendance.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeLevel"].Value = attendance.Band.Description;
                    grid.Rows[ctr].Cells["gridStatus"].Value = (PayRollStatus)Enum.Parse(typeof(PayRollStatus), attendance.Status);
                    grid.Rows[ctr].Cells["gridGrossSalary"].Value = attendance.GrossSalary;
                    grid.Rows[ctr].Cells["gridTaxableIncome"].Value = attendance.TaxableIncome;
                    grid.Rows[ctr].Cells["gridEmail"].Value = attendance.Employee.Email;
                    grid.Rows[ctr].Cells["gridMobileNumber"].Value = attendance.Employee.MobileNo;
                    grid.Rows[ctr].Cells["gridMechanised"].Value = attendance.Employee.Mechanised;
                    grid.Rows[ctr].Cells["gridPaymentAccType"].Value = attendance.PaymentAccType;

                    if (attendance.SalaryType.Description == null)
                    {
                        grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = "NA";
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridWithholdingTaxCalculateOn"].Value = attendance.SalaryType.Description;
                    }
                    grid.Rows[ctr].Cells["gridWithholdingAmount"].Value = attendance.WithholdingAmount;
                    grid.Rows[ctr].Cells["gridWithholdingTaxRate"].Value = attendance.WithholdingTaxRate;
                    grid.Rows[ctr].Cells["gridWithholdingTaxFixedAmount"].Value = attendance.WithholdingTaxFixedAmount;
                    grid.Rows[ctr].Cells["gridSusuPlusContribution"].Value = attendance.SusuPlusContributionAmount;
                    if (attendance.Status == "1")
                    {
                        if (ctr == 1 || ctr == 3 || ctr == 5 || ctr == 7 || ctr == 9 || ctr == 11 || ctr == 13 || ctr == 15 || ctr == 17 || ctr == 19 || ctr == 21 || ctr == 23)
                        {
                            SetRowColor(grid.Rows[ctr], Color.White);
                        }
                        else
                        {
                            SetRowColor(grid.Rows[ctr], Color.GhostWhite);
                        }
                    }
                    else if (attendance.Status == "2")
                    {
                        SetRowColor(grid.Rows[ctr], Color.Silver);
                    }
                    ctr++;
                }
                txtNoPayrollStaff.Text = attendances.Count().ToString();
                txtBasicSalary.Text = actualBasicSalary.ToString();
                txtTotalSalaryEarned.Text = basicSalary.ToString();
                txtGrossIncome.Text = grossIncome.ToString();
                txtIncomeTax.Text = incomeTax.ToString();
                txtNetPay.Text = netPay.ToString();
                txtSSNIT.Text = ssnit.ToString();
                txtSSNITER.Text = ssER.ToString();
                txtTaxableIncome.Text = taxableIncome.ToString();
                txtTotalAllowance.Text = grandTotalAllowance.ToString();
                txtTotalDeduction.Text = grandTotalDeduction.ToString();
                txtTotalLoan.Text = grandTotalLoan.ToString();

                ctr = 0;
                grid1.Rows.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid1.Rows.Add(1);
                    grid1.Rows[ctr].Cells["grid1StaffNo"].Value = row.Cells["gridStaffNo"].Value;
                    grid1.Rows[ctr].Cells["grid1StaffCode"].Value = row.Cells["gridStaffCode"].Value;
                    grid1.Rows[ctr].Cells["grid1Title"].Value = row.Cells["gridTitle"].Value;
                    grid1.Rows[ctr].Cells["grid1Name"].Value = row.Cells["gridName"].Value;
                    grid1.Rows[ctr].Cells["grid1AttendanceDays"].Value = row.Cells["gridAttendanceDays"].Value;
                    grid1.Rows[ctr].Cells["grid1Email"].Value = row.Cells["gridEmail"].Value;
                    grid1.Rows[ctr].Cells["grid1MobileNumber"].Value = row.Cells["gridMobileNumber"].Value;

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nameTextBox.Text.Trim() != string.Empty)
                {
                    if (companyOne.ID == 0)
                    {
                        companyOne = dal.LazyLoad<Company>()[0];
                    }

                    if (nameTextBox.Text.Length >= companyOne.MinimumCharacter)
                    {
                        foundAttendances.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Name",
                            CriterionOperator = CriterionOperator.Like,
                            Value = nameTextBox.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Year",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = yearComboBox.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Month",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = GlobalData.GetMonth(periodComboBox.Text.Trim()),
                            CriteriaOperator = CriteriaOperator.None
                        });
                        attendances = dal.GetByCriteria<PayRollAttendance>(query);
                        if (attendances.Count > 0)
                        {
                            foreach (PayRollAttendance attendance in attendances)
                            {
                                string name = attendance.Name;
                                if (name.Trim().ToLower().StartsWith(nameTextBox.Text.Trim().ToLower()))
                                {
                                    foundAttendances.Add(attendance);
                                }
                            }
                            PopulateView(foundAttendances);
                        }
                        else
                        {
                            MessageBox.Show("Employee with Name " + nameTextBox.Text.Trim() + " is not found on the PayRoll");
                            nameTextBox.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Trim() != string.Empty)
                {
                    if (companyOne.ID == 0)
                    {
                        companyOne = dal.LazyLoad<Company>()[0];
                    }

                    if (staffIDTextBox.Text.Length >= companyOne.MinimumCharacter)
                    {
                        foundAttendances.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDTextBox.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Year",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = yearComboBox.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Month",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = GlobalData.GetMonth(periodComboBox.Text.Trim()),
                            CriteriaOperator = CriteriaOperator.None
                        });
                        attendances = dal.GetByCriteria<PayRollAttendance>(query);
                        if (attendances.Count > 0)
                        {
                            foreach (PayRollAttendance attendance in attendances)
                            {
                                if (attendance.Employee.StaffID.Trim().ToLower().StartsWith(staffIDTextBox.Text.Trim().ToLower()))
                                {
                                    foundAttendances.Add(attendance);
                                }
                            }
                            PopulateView(foundAttendances);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDTextBox.Text.Trim() + " is not found on the PayRoll,Please Check the Color of the PaySlip");
                            staffIDTextBox.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnAllowances_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    AllowanceNew allowanceForm = new AllowanceNew();
                    allowanceForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    DeductionsNew deductionForm = new DeductionsNew();
                    deductionForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnLoanPayments_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Loans_Payments loansForm = new Loans_Payments();
                    loansForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnMedicalClaim_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    MedicalClaimsNew medicalClaimsForm = new MedicalClaimsNew();
                    medicalClaimsForm.Show();
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void btnSalaryInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    SalaryInfoNew salaryInfoForm = new SalaryInfoNew();
                    salaryInfoForm.MdiParent = this.MdiParent;
                    salaryInfoForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnViewPayRoll_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    PayRollStatus status = Exists(periodComboBox.Text.Trim(), yearComboBox.Text.Trim());
                    if (status == PayRollStatus.Closed || status == PayRollStatus.Open)
                    {
                        //Get Payroll
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                        }
                        reportForm = new PayRollOldReportForm(staffIDTextBox.Text.Trim(),periodComboBox.Text.Trim(), yearComboBox.Text.Trim(), cmbDepartments.Text.Trim(), string.Empty, string.Empty, string.Empty, string.Empty,cboMechanised.Text.Trim(), frm);
                        frm.Close();
                        reportForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("The payroll attendance for the specified period has not been generated", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    dal.RollBackTransaction();
                    Logger.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnViewSelectedSlips_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (grid.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grid.SelectedRows)
                        {
                            if (row != null)
                            {
                                if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                                {
                                    int paymentID = int.Parse(row.Cells["gridPaymentID"].Value.ToString().Trim());
                                    if (reportForm != null && !reportForm.IsDisposed)
                                    {
                                        reportForm.Close();
                                    }
                                    if (this.company[0].PayslipFormat.Equals("Payslip Format 1", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        reportForm = new PaySlipFormatReportForm(row.Cells["gridStaffNo"].Value.ToString().Trim(), paymentID, row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
                                        reportForm.Show();
                                    }
                                    else
                                    {
                                        reportForm = new PaySlipReportForm(row.Cells["gridStaffNo"].Value.ToString().Trim(), paymentID, row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "");
                                        reportForm.Show();
                                    }
                                }
                                else
                                {
                                    GlobalData.ShowMessage("Please Correct the errors shown before viewing the pay slip.");
                                }
                            }
                        }
                        frm.Close();
                    }
                    else
                    {
                        frm.Close();
                        GlobalData.ShowMessage("Please Select the PaySlip from the Grid.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrintSelectedSlips_Click(object sender, EventArgs e)
        {


            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (grid.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grid.SelectedRows)
                        {
                            if (row != null)
                            {
                                if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                                {
                                    int paymentID = int.Parse(row.Cells["gridPaymentID"].Value.ToString().Trim());
                                    if (reportForm != null && !reportForm.IsDisposed)
                                    {
                                        reportForm.Close();
                                    }

                                    if (this.company[0].PayslipFormat.Equals("Payslip Format 1", StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        PaySlipFormatReport1 = new PaySlipFormatReport();
                                        PaySlipFormatReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                        PaySlipFormatReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                        PaySlipFormatReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                        PaySlipFormatReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                        PaySlipFormatReport1.SetParameterValue("Department", string.Empty);
                                        PaySlipFormatReport1.SetParameterValue("Unit", string.Empty);
                                        PaySlipFormatReport1.SetParameterValue("GradeCategory", string.Empty);
                                        PaySlipFormatReport1.SetParameterValue("Grade", string.Empty);
                                        PaySlipFormatReport1.SetParameterValue("Zone", string.Empty);
                                        PaySlipFormatReport1.SetParameterValue("Mechanised", string.Empty);

                                        PaySlipFormatReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                            GlobalData.ServerName, GlobalData.DatabaseName, true);

                                        PaySlipFormatReport1.PrintToPrinter(1, true, 0, 0);
                                    }
                                    else
                                    {
                                        paySlipReport1 = new PaySlipReport();
                                        paySlipReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                        paySlipReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                        paySlipReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                        paySlipReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                        paySlipReport1.SetParameterValue("Department", string.Empty);
                                        paySlipReport1.SetParameterValue("Unit", string.Empty);
                                        paySlipReport1.SetParameterValue("GradeCategory", string.Empty);
                                        paySlipReport1.SetParameterValue("Grade", string.Empty);
                                        paySlipReport1.SetParameterValue("Zone", string.Empty);
                                        paySlipReport1.SetParameterValue("Mechanised", string.Empty);

                                        paySlipReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                            GlobalData.ServerName, GlobalData.DatabaseName, true);

                                        paySlipReport1.PrintToPrinter(1, true, 0, 0);
                                    }
                                    
                                }
                                else
                                {
                                    GlobalData.ShowMessage("Please Correct the errors shown before viewing the pay slip.");
                                }
                            }
                        }
                        frm.Close();
                    }
                    else
                    {
                        frm.Close();
                        GlobalData.ShowMessage("Please Select the PaySlip from the Grid.");
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    Logger.LogError(ex);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRemoveSelectedSlips_Click(object sender, EventArgs e)
        {
            try
            {
                Delete();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        #region Close Pay Slip
        private void ClosePaySlip()
        {
            if (AllowedToClosePayRoll(GlobalData.User.ID))
            {
                if (grid.CurrentRow.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                {
                    try
                    {
                        dal.OpenConnection();
                        if (btnOpenPayRoll.Text.Trim() == "Close Pay Slip")
                        {
                            if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.Open)
                            {
                                //Save Payroll
                                dalHelper.ExecuteNonQuery("Update StaffSalaryPayments Set Status='2' Where Month='" + GlobalData.GetMonth(periodComboBox.Text) + "' And Year='" + yearComboBox.Text + "'");
                                SetRowColor(grid.CurrentRow, Color.Silver);
                            }
                            else
                            {
                                GlobalData.ShowMessage("No open payroll exists for the current period");
                            }
                        }
                        else
                        {
                            if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.Closed)
                            {
                                //Save Payroll
                                dalHelper.ExecuteNonQuery("Update StaffSalaryPayments Set Status='1' Where Month='" + GlobalData.GetMonth(periodComboBox.Text) + "' And Year='" + yearComboBox.Text + "' And StaffID='" + grid.CurrentRow.Cells["StaffID"].Value.ToString() + "'");
                                ClearView();
                            }
                            else
                            {
                                GlobalData.ShowMessage("No closed payroll exists for the specified period");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        dal.RollBackTransaction();
                        Logger.LogError(ex);
                    }
                }
                else
                {
                    GlobalData.ShowMessage("Please correct the errors before you can close this pay slip");
                }
            }
        }
        #endregion

        private void payRollButton_Click(object sender, EventArgs e)
        {
            try
            {
                ViewPayRoll();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Please See the System Administrator", GlobalData.Caption);
            }
        }

        private void OldSave()
        {
            try
            {
                dal.BeginTransaction();
                if (overwrite)
                {
                    if (attendances.Count == 0)
                    {
                        GeneratePayRoll();
                    }
                    //Delete old payroll that was generated for the period but not closed
                    int temp = GlobalData.GetMonth(periodComboBox.Text.Trim());
                    int year = int.Parse(yearComboBox.Text.Trim());
                    

                    foreach (PayRollAttendance attendance in attendances)
                    {
                        if (attendance.Month == GlobalData.GetMonth(periodComboBox.Text) && attendance.Year == int.Parse(yearComboBox.Text))
                        {
                            dal.Save(attendance);
                        }
                    }
                    dal.CommitTransaction();
                    ClearView();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private void btnOpenPayRoll_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllowedToClosePayRoll(GlobalData.User.ID))
                {
                    dal.BeginTransaction();

                    if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.Closed)
                    {
                        //Save Payroll
                        overwrite = true;
                        dalHelper.ExecuteNonQuery("Update StaffSalaryPayments Set Status='1' Where Month='" + GlobalData.GetMonth(periodComboBox.Text) + "' And Year='" + yearComboBox.Text + "'");
                        dal.CommitTransaction();
                        ClearView();
                    }
                    else
                    {
                        GlobalData.ShowMessage("No closed payroll exists");
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        private void btnDeletePayRoll_Click(object sender, EventArgs e)
        {
            try
            {
                if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.Open)
                {
                    if (GlobalData.QuestionMessage("Are you sure you want to Delete the PayRoll " + "?") == DialogResult.Yes)
                    {
                        dal.BeginTransaction();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Month",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = GlobalData.GetMonth(periodComboBox.Text.Trim()),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Year",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = yearComboBox.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.None
                        });
                        attendances = dal.GetByCriteria<PayRollAttendance>(query);
                        foreach (PayRollAttendance attendance in attendances)
                        {
                            dal.Update(attendance);
                        }
                        dal.Delete(new PayRollAttendance()
                        {
                            Month = GlobalData.GetMonth(periodComboBox.Text),
                            Year = int.Parse(yearComboBox.Text)
                        });
                        dal.CommitTransaction();
                        ClearView();
                    }
                }
                else
                {
                    MessageBox.Show("The PayRoll Cannot be Deleted",GlobalData.Caption);
                }
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrintPayRoll_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (yearComboBox.Text.Trim() != string.Empty && periodComboBox.Text.Trim() != string.Empty && grid.Rows.Count > 0)
                    {
                        payRollRegisterOldFormat1.SetDatabaseLogon(GlobalData.UserID.Trim(), GlobalData.Password.Trim(), GlobalData.ServerName.Trim(), GlobalData.DatabaseName.Trim(), true);

                        payRollRegisterOldFormat1.SetParameterValue("Year", yearComboBox.Text.Trim());
                        payRollRegisterOldFormat1.SetParameterValue("Month", periodComboBox.Text.Trim());
                        payRollRegisterOldFormat1.SetParameterValue("GradeCategory", string.Empty);
                        payRollRegisterOldFormat1.SetParameterValue("Grade", string.Empty);
                        payRollRegisterOldFormat1.SetParameterValue("Department", cmbDepartments.Text.Trim());
                        payRollRegisterOldFormat1.SetParameterValue("Unit", string.Empty);
                        payRollRegisterOldFormat1.SetParameterValue("Zone", string.Empty);
                        payRollRegisterOldFormat1.PrintToPrinter(1, false, 0, 0);
                        frm.Close();
                    }
                    else
                    {
                        frm.Close();
                        GlobalData.ShowMessage("Please Select the Period and View the PayRoll");
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    Logger.LogError(ex);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPrintAllSlips_Click(object sender, EventArgs e)
        {
                try
                {
                    Application.DoEvents();
                    eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                    frm.TopMost = true;
                    //frm.Show(this);
                    Application.DoEvents();
                    try
                    {
                        if (grid.Rows.Count > 0)
                        {
                            if (this.company[0].PayslipFormat.Equals("Payslip Format 1", StringComparison.CurrentCultureIgnoreCase))
                            {
                                var slipsCount = 0;
                                var directorPath = string.Empty;
                                List<string> StaffIDs = new List<string>();
                                List<Int32> PaymentIDs = new List<int>();
                                List<string> Months = new List<string>();
                                List<string> Years = new List<string>();
                                foreach (DataGridViewRow row in grid.Rows)
                                {
                                    
                                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                                    {
                                        //var employee=new Employee();
                                        //employee.StaffID = row.Cells["gridStaffNo"].Value.ToString();
                                        var StaffID = row.Cells["gridStaffNo"].Value.ToString().Trim();
                                        var PaymentID = Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString());
                                        var Month = row.Cells["gridMonth"].Value.ToString().Trim();
                                        var Year = row.Cells["gridYear"].Value.ToString().Trim();

                                        var employee = new Employee();
                                        employee.StaffID = StaffID;

                                        PayRollAttendance payAttendance =new PayRollAttendance();
                                        payAttendance.Employee = employee;
                                        payAttendance.Month = (periodComboBox.Text != string.Empty) ? GlobalData.GetMonth(periodComboBox.Text) : 0;
                                        payAttendance.Year = (yearComboBox.Text != string.Empty) ? int.Parse(yearComboBox.Text) : 0;

                                        attendanceMapper = new PayRollAttendanceDataMapper();
                                        attendanceMapper.UpdateYTD(payAttendance);
                                        //StaffIDs.Add(row.Cells["gridStaffNo"].Value.ToString());

                                        Months.Add(Month);
                                        Years.Add(Year);

                                        StaffIDs.Add(StaffID);

                                        PaymentIDs.Add(PaymentID);

                                        slipsCount++;
                                    }
                                    else
                                    {
                                        WriteToLogFile("Please Correct the Errors in the PaySlip. for StaffID " + row.Cells["gridStaffNo"].Value.ToString().Trim());
                                    }
                                }

                                ////if (StaffIDs.Count > 0)
                                ////{
                                    //allEmpSalrpt.Refresh();

                                    //dalHelper = new DALHelper();
                                    //dalHelper.ClearParameters();

                                    //var strStaffIDs=AppUtils.ArrayToStringInput(StaffIDs.ToArray());
                                    ////dalHelper.CreateParameter("@StaffIDs",strStaffIDs,DbType.String);
                                    //dalHelper.CreateParameter("@Month", (periodComboBox.Text!=string.Empty)? GlobalData.GetMonth(periodComboBox.Text.Trim()):0,DbType.Int32);
                                    //dalHelper.CreateParameter("@Year", (yearComboBox.Text != string.Empty) ? int.Parse(yearComboBox.Text) : 0, DbType.Int32);

                                    //var dataSet = new DataSet();

                                    //var dtPaySlips = dalHelper.ExecuteReader("SELECT r.*,c.Name as CompanyName,c.PostalAddress as CompanyPostalAddress,c.Logo FROM StaffSalaryPaymentView r,CompanyInfoView c where r.StaffID in (" + strStaffIDs + ") and r.Month=@Month and r.Year=@Year");
                                    //dtPaySlips.TableName = "PaySlipFormReport";
                                    //dataSet.Tables.Add(dtPaySlips);

                                    //dalHelper.ClearParameters();
                                    //dalHelper.CreateParameter("@Month", (periodComboBox.Text != string.Empty) ? GlobalData.GetMonth(periodComboBox.Text.Trim()) : 0, DbType.Int32);
                                    //dalHelper.CreateParameter("@Year", (yearComboBox.Text != string.Empty) ? int.Parse(yearComboBox.Text) : 0, DbType.Int32);

                                    //dtPaySlips = dalHelper.ExecuteReader("SELECT ColumnHeader,ColumnValue,s.StaffID,Type,AccountType,(select t.TotalOverTimeHours from StaffSalaryPaymentView t where t.StaffID=s.StaffID and t.Month=s.Month and t.Year=s.Year) as TotalOverTime from PayRollSummaryView s where s.StaffID in (" + strStaffIDs + ") and s.Month=@Month and s.Year=@Year");
                                    //dtPaySlips.TableName = "PaySlipSummaryViewReport";

                                    //dataSet.Tables.Add(dtPaySlips);
                                    
                                    
                                    //allEmpSalrpt.SetDataSource(dataSet);
                                frm.TopMost = false;
                                if (slipsCount > 0)
                                {
                                    MyReportForm rptfrm = new MyReportForm(paySlipFormatReport1, StaffIDs, PaymentIDs, Months, Years);
                                    rptfrm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("No Payslips were generated. Empty Recordset");

                                }
                                frm.Close();
                                    

                                //}
                                //frm.TopMost = false;
                                
                            }
                            else
                            {

                                //MessageBox.Show("Kindly wait as the system generates" + grid.Rows.Count + "  payslips for the selected month");
                                var slipsCount = 0;
                                var directorPath = string.Empty;
                                List<string> StaffIDs = new List<string>();
                                List<Int32> PaymentIDs = new List<int>();
                                List<string>Months=new List<string>();
                                List<string> Years=new List<string>();
                                //List<ReportDocument> paySlipReports = new List<ReportDocument>();

                                foreach (DataGridViewRow row in grid.Rows)
                                {
                                   
                                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                                    {
                                        var StaffID = row.Cells["gridStaffNo"].Value.ToString().Trim();
                                        var PaymentID=Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString());
                                        var Month=row.Cells["gridMonth"].Value.ToString().Trim();
                                        var Year=row.Cells["gridYear"].Value.ToString().Trim();
                                       
                                        var employee = new Employee();
                                        employee.StaffID = StaffID;

                                        PayRollAttendance payAttendance = new PayRollAttendance();
                                        payAttendance.Employee = employee;
                                        payAttendance.Month = (periodComboBox.Text != string.Empty) ? GlobalData.GetMonth(periodComboBox.Text) : 0;
                                        payAttendance.Year = (yearComboBox.Text != string.Empty) ? int.Parse(yearComboBox.Text) : 0;

                                        attendanceMapper = new PayRollAttendanceDataMapper();
                                        attendanceMapper.UpdateYTD(payAttendance);


                                        Months.Add(Month);
                                        Years.Add(Year);

                                        StaffIDs.Add(StaffID);

                                        PaymentIDs.Add(PaymentID);
                                      
                                        slipsCount++;

                                    }
                                    else
                                    {
                                        WriteToLogFile("Please Correct the Errors in the PaySlip. for StaffID " + row.Cells["gridStaffNo"].Value.ToString().Trim());
                                    }
                                }
                                frm.TopMost = false;
                                if (slipsCount > 0)
                                {
                                    PrintAllSlipsDefaultFormat frmRpt = new PrintAllSlipsDefaultFormat(paySlipReport1,StaffIDs,PaymentIDs,Months,Years);
                                    frmRpt.Show();
                                }
                                   // MessageBox.Show((slipsCount + 1) + " slips have been generated into " + directorPath);
                                else
                                    MessageBox.Show("No Payslips were generated. Empty Recordset");
                                frm.Close();
                            }

                            frm.Close();
                        }
                        else
                        {
                            frm.Close();
                            GlobalData.ShowMessage("Please Display the PayRoll.");
                        }
                        if(frm!=null && frm.Visible==true)
                            frm.Close();
                    }
                    catch (Exception ex)
                    {
                        frm.Close();
                        Logger.LogError(ex);
                    }

                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }


            
        }

        void periodComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                company = dal.GetAll<Company>();
                if (company[0].PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                    periodComboBox.Items.Clear();
                    foreach (string item in GlobalData.GetMonths())
                    {
                        periodComboBox.Items.Add(item);
                    }
                }
                else
                {
                    periodComboBox.Items.Clear();
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        periodComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
                yearComboBox.Items.Add(DateTime.Now.Date.Year);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                foreach (KeyValuePair<string, string> error in payRollErrors)
                {
                    if (error.Key.Trim() == grid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                    {
                        MessageBox.Show(error.Value, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cmbDepartments_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartments.Items.Clear();
                cmbDepartments.Items.Add("ALL DEPARTMENTS");
                if(departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }
                
                foreach (Department department in departments)
                {
                    cmbDepartments.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        
        private void SetCurrentValuesForParameterField(ReportDocument reportDocument, string paramFieldName, string value)
        {
            try
            {
                ParameterDiscreteValue parameterDiscreteValue = new ParameterDiscreteValue();
                parameterDiscreteValue.Value = value;

                ParameterValues currentParameterValues = new ParameterValues();
                currentParameterValues.Add(parameterDiscreteValue);

                reportDocument.DataDefinition.ParameterFields[paramFieldName].ApplyCurrentValues(currentParameterValues);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnEmailAll_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (yearComboBox.Text.Trim() != string.Empty && periodComboBox.Text.Trim() != string.Empty && grid.Rows.Count > 0)
                    {
                        string filetype = cmbFileFomats.Text.Trim();
                        if (filetype != string.Empty)
                        {
                            payRollRegisterOldFormat1 = new PayRollRegisterOldFormat();
                            payRollRegisterOldFormat1.SetDatabaseLogon(GlobalData.UserID.Trim(), GlobalData.Password.Trim(), GlobalData.ServerName.Trim(), GlobalData.DatabaseName.Trim(), true);
                            payRollRegisterOldFormat1.SetParameterValue("StaffID", staffIDTextBox.Text.Trim());
                            payRollRegisterOldFormat1.SetParameterValue("Year", yearComboBox.Text.Trim());
                            payRollRegisterOldFormat1.SetParameterValue("Month", periodComboBox.Text.Trim());
                            payRollRegisterOldFormat1.SetParameterValue("GradeCategory", string.Empty);
                            payRollRegisterOldFormat1.SetParameterValue("Grade", string.Empty);
                            payRollRegisterOldFormat1.SetParameterValue("Department", cmbDepartments.Text.Trim());
                            payRollRegisterOldFormat1.SetParameterValue("Unit", string.Empty);
                            payRollRegisterOldFormat1.SetParameterValue("Zone", string.Empty);
                            payRollRegisterOldFormat1.SetParameterValue("Mechanised", cboMechanised.Text.Trim());

                            //Send Email to The Supervisor
                            if (ConfigurationManager.AppSettings["SupervisorEmail"].ToString() != string.Empty)
                            {
                                //payRollRegisterOldFormat1.ExportToDisk(ExportFormatType.PortableDocFormat, "reportExcelPayRoll.pdf");
                                SendEmail(ConfigurationManager.AppSettings["SupervisorEmail"].ToString(), yearComboBox.Text.Trim(), periodComboBox.Text.Trim(), ConfigurationManager.AppSettings["SupervisorName"].ToString(), ConfigurationManager.AppSettings["SupervisorSubject"].ToString(), ConfigurationManager.AppSettings["SupervisorBody"].ToString(), payRollRegisterOldFormat1, ExportFormatType.PortableDocFormat, "PayRoll-" + periodComboBox.Text.Trim() + "_" + yearComboBox.Text.Trim() + ".pdf");
                            }

                            foreach (DataGridViewRow row in grid.Rows)
                            {
                                if (row != null)
                                {
                                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red || row.Cells["gridEmail"].Value.ToString().Trim() == null || row.Cells["gridEmail"].Value.ToString().Trim() == string.Empty)
                                    {
                                        if (row.Cells["gridEmail"].Value.ToString().Trim() == null || row.Cells["gridEmail"].Value.ToString().Trim() == string.Empty)
                                        {
                                            WriteToLogFile(attendance.Name + "with" + "StaffID" + row.Cells["gridStaffNo"].Value.ToString().Trim() + "Does not have a mail");
                                        }
                                        else
                                        {
                                            CrystalDecisions.Shared.ExportFormatType efileType = (CrystalDecisions.Shared.ExportFormatType)Enum.Parse(typeof(CrystalDecisions.Shared.ExportFormatType), filetype);
                                            if (this.company[0].PayslipFormat.Equals("Payslip Format 1", StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                PaySlipFormatReport1 = new PaySlipFormatReport();
                                                PaySlipFormatReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                                PaySlipFormatReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("Department", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Unit", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("GradeCategory", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Grade", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Zone", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Mechanised", string.Empty);

                                                PaySlipFormatReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                                    GlobalData.ServerName, GlobalData.DatabaseName, true);

                                                switch (efileType)
                                                {
                                                    case CrystalDecisions.Shared.ExportFormatType.Excel:
                                                        //paySlipReport1.ExportToDisk(efileType, "reportExcel"+attendance.Employee.StaffID+".xls");
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.ExcelRecord:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.HTML32:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".html");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.HTML40:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".html");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.NoFormat:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".pdf");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.RichText:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".rtf");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".doc");
                                                        break;
                                                    default:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), PaySlipFormatReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".pdf");
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                PaySlipFormatReport1 = new PaySlipFormatReport();
                                                paySlipReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                                paySlipReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("Department", string.Empty);
                                                paySlipReport1.SetParameterValue("Unit", string.Empty);
                                                paySlipReport1.SetParameterValue("GradeCategory", string.Empty);
                                                paySlipReport1.SetParameterValue("Grade", string.Empty);
                                                paySlipReport1.SetParameterValue("Zone", string.Empty);
                                                paySlipReport1.SetParameterValue("Mechanised", string.Empty);

                                                paySlipReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                                    GlobalData.ServerName, GlobalData.DatabaseName, true);


                                                switch (efileType)
                                                {
                                                    case CrystalDecisions.Shared.ExportFormatType.Excel:
                                                        //paySlipReport1.ExportToDisk(efileType, "reportExcel"+attendance.Employee.StaffID+".xls");
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.ExcelRecord:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.HTML32:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".html");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.HTML40:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".html");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.NoFormat:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".xls");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.PortableDocFormat:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".pdf");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.RichText:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".rtf");
                                                        break;
                                                    case CrystalDecisions.Shared.ExportFormatType.WordForWindows:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".doc");
                                                        break;
                                                    default:
                                                        SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString(), ConfigurationManager.AppSettings["Body"].ToString(), paySlipReport1, efileType, "PaySlip-" + row.Cells["gridMonth"].Value.ToString().Trim() + "_" + row.Cells["gridYear"].Value.ToString().Trim() + ".pdf");
                                                        break;
                                                }

                                            }
                                        }
                                    }
                                    else
                                    {
                                        WriteToLogFile("The Row is Flagged Red Please correct the Error and Resend it");
                                    }
                                }
                            }
                        }
                        else
                        {
                            frm.Close();
                            MessageBox.Show("File Type cannot be empty, Please Select File Type");
                        }
                    }
                    else
                    {
                        frm.Close();
                        MessageBox.Show("Please View the PayRoll First");
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    MessageBox.Show("Error:Please See the System Administrator For Internet Connection or Configuration");
                    WriteToLogFile(ex.Message);
                }
                frm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:Please See the System Administrator For Internet Connection or Configuration");
                WriteToLogFile(ex.Message);
            }
        }

        public void WriteToLogFile(string content)
        {
            try
            {
                //if the directory does not exist create the directory
                if (!(Directory.Exists(ConfigurationManager.AppSettings["LogFilePath"].ToString())))
                {
                    Directory.CreateDirectory(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                }

                //get the path for the log file
                StringBuilder strLogFilePath = new StringBuilder();
                strLogFilePath.Append(ConfigurationManager.AppSettings["LogFilePath"].ToString());
                strLogFilePath.Append(@"\EmailSMSLogFile_" + DateTime.Today.ToString("dd-MM-yyyy")+ ".txt");

                //if the file doesnot exist create the file
                if (!File.Exists(strLogFilePath.ToString()))
                {
                    FileStream fsErrorLog = new FileStream(strLogFilePath.ToString(), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fsErrorLog.Close();
                }

                //write to the log file
                StreamWriter writer = new StreamWriter(strLogFilePath.ToString(), true);
                writer.WriteLine("********************************************************************");
                writer.WriteLine("Date " + DateTime.Now);
                writer.WriteLine("Content: " + content);
                writer.WriteLine("********************************************************************");
                writer.Close();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void SendEmail(string emailId, string year, string month,string name,string subject,string body, ReportDocument rpt, ExportFormatType fileType, string fileName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["MailServer"].ToString().Trim());

                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailFromAddress"].ToString().Trim());
                mail.To.Add(emailId);                
                mail.Subject = subject;
                mail.Body = "Hello" + " " + name + ", " + body + " " + "For" + " " + month + "," + year;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                mail.Attachments.Add(new Attachment(rpt.ExportToStream(fileType), fileName));
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["UserName"].ToString().Trim(), ConfigurationManager.AppSettings["Password"].ToString().Trim());
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                WriteToLogFile("Message Sent SUCCESS to - " + emailId + " - " + name);
            }
            catch (Exception ex)
            {
                WriteToLogFile("Message Sent FAILED to - " + emailId + " - " + name);
                //if (MessageBox.Show("Unable to send email to " + emailId + " due to following error:\n\n" + e.Message, "Email send error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                //{
                //    this.SendEmail(emailId, name, subject, body, rpt, fileType, fileName);
                //}
                throw ex;
            }
        }

        private void btnEmailSelected_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (grid.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grid.SelectedRows)
                        {
                            if (row != null)
                            {
                                if (row.Cells["gridEmail"].Value.ToString().Trim() == string.Empty || row.Cells["gridEmail"].Value == null)
                                {
                                    GlobalData.ShowMessage("ERROR:The Selected Staff Does not have Email.");
                                }
                                else
                                {
                                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                                    {
                                        if (Validator.EmailValidator(ConfigurationManager.AppSettings["MailFromAddress"].ToString().Trim()))
                                        {

                                            if (this.company[0].PayslipFormat.Equals("Payslip Format 1", StringComparison.CurrentCultureIgnoreCase))
                                            {
                                                PaySlipFormatReport1 = new PaySlipFormatReport();
                                                PaySlipFormatReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                                PaySlipFormatReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                                PaySlipFormatReport1.SetParameterValue("Department", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Unit", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("GradeCategory", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Grade", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Zone", string.Empty);
                                                PaySlipFormatReport1.SetParameterValue("Mechanised", string.Empty);

                                                //PaySlipFormatReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                                //    GlobalData.ServerName, GlobalData.DatabaseName);

                                                PaySlipFormatReport1.DataSourceConnections[0].SetConnection(GlobalData.ServerName, GlobalData.DatabaseName, GlobalData.UserID, GlobalData.Password);


                                                SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), 
                                                    row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), 
                                                    ConfigurationManager.AppSettings["Subject"].ToString().Trim(), ConfigurationManager.AppSettings["Body"].ToString().Trim(), 
                                                    PaySlipFormatReport1, ExportFormatType.PortableDocFormat, "PaySlip.pdf");
                                                //SendEmail("as.kwabena@gmail.com", row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString().Trim(), ConfigurationManager.AppSettings["Body"].ToString().Trim(), PaySlipFormatReport1, ExportFormatType.PortableDocFormat, "PaySlip.pdf");
                                                //GlobalData.ShowMessage("Message Sent SUCCESSFULLY " + "From " + ConfigurationManager.AppSettings["MailFromAddress"].ToString().Trim() + " to - " + row.Cells["gridEmail"].Value.ToString().Trim() + " - " + row.Cells["gridName"].Value.ToString().Trim());
                                            }
                                            else
                                            {
                                                PaySlipFormatReport1 = new PaySlipFormatReport();
                                                paySlipReport1.SetParameterValue("StaffID", row.Cells["gridStaffNo"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("PaymentID", Convert.ToInt32(row.Cells["gridPaymentID"].Value.ToString()));
                                                paySlipReport1.SetParameterValue("Month", row.Cells["gridMonth"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("Year", row.Cells["gridYear"].Value.ToString().Trim());
                                                paySlipReport1.SetParameterValue("Department", string.Empty);
                                                paySlipReport1.SetParameterValue("Unit", string.Empty);
                                                paySlipReport1.SetParameterValue("GradeCategory", string.Empty);
                                                paySlipReport1.SetParameterValue("Grade", string.Empty);
                                                paySlipReport1.SetParameterValue("Zone", string.Empty);
                                                paySlipReport1.SetParameterValue("Mechanised", string.Empty);

                                                //paySlipReport1.SetDatabaseLogon(GlobalData.UserID, GlobalData.Password,
                                                //    GlobalData.ServerName, GlobalData.DatabaseName, true);

                                                PaySlipFormatReport1.DataSourceConnections[0].SetConnection(GlobalData.ServerName, GlobalData.DatabaseName, GlobalData.UserID, GlobalData.Password);

                                                SendEmail(row.Cells["gridEmail"].Value.ToString().Trim(), row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString().Trim(), ConfigurationManager.AppSettings["Body"].ToString().Trim(), paySlipReport1, ExportFormatType.PortableDocFormat, "PaySlip.pdf");
                                                //SendEmail("as.kwabena@gmail.com", row.Cells["gridYear"].Value.ToString().Trim(), row.Cells["gridMonth"].Value.ToString().Trim(), row.Cells["gridTitle"].Value.ToString().Trim() + " " + row.Cells["gridName"].Value.ToString().Trim() + " " + "with" + " " + row.Cells["gridStaffNo"].Value.ToString().Trim(), ConfigurationManager.AppSettings["Subject"].ToString().Trim(), ConfigurationManager.AppSettings["Body"].ToString().Trim(), paySlipReport1, ExportFormatType.PortableDocFormat, "PaySlip.pdf");
                                                //GlobalData.ShowMessage("Message Sent SUCCESSFULLY " + "From " + ConfigurationManager.AppSettings["MailFromAddress"].ToString().Trim() + " to - " + row.Cells["gridEmail"].Value.ToString().Trim() + " - " + row.Cells["gridName"].Value.ToString().Trim());
                                            }
                                        }
                                        else
                                        {
                                            GlobalData.ShowMessage("Please correct the Format Email From Address in the Configuration file.");
                                        }
                                    }
                                    else
                                    {
                                        GlobalData.ShowMessage("Please correct the errors shown before Emailing Pay Slip.");
                                    }
                                }
                            }
                        }
                        frm.Close();
                        GlobalData.ShowMessage("Message(s) Sent SUCCESSFULLY");
                    }
                    else
                    {
                        GlobalData.ShowMessage("Please Select the PaySlip from the Grid.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    frm.Close();
                    MessageBox.Show("Error:Please See the System Administrator For Internet Connection or Configuration");
                    WriteToLogFile(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator For Internet Connection or Configuration");
                WriteToLogFile(ex.Message);
            }
        }

        private void btnSMS_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (grid.Rows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (row != null)
                            {
                                if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red || row.Cells["gridMobileNumber"].Value.ToString().Trim() == null || row.Cells["gridMobileNumber"].Value.ToString().Trim() == string.Empty)
                                {
                                    ScheduleMessage scheduleMessage = new ScheduleMessage();
                                    scheduleMessage.To = row.Cells["gridMobileNumber"].Value.ToString().Trim();
                                    scheduleMessage.From = "System";
                                    scheduleMessage.Message = "Your PaySlip with Net Salary: GHC" + row.Cells["gridNetSalary"].Value.ToString().Trim() + " for " + row.Cells["gridMonth"].Value.ToString().Trim() + "," + row.Cells["gridYear"].Value.ToString().Trim() + " has been Sent to your Bank";
                                    scheduleMessage.Schedule_time = DateTime.Now;
                                    scheduleMessage.Status = "Send";

                                    dal.Save(scheduleMessage);
                                }
                            }
                        }
                        dal.CommitTransaction();
                        frm.Close();

                        GlobalData.ShowMessage("SMS sent to all Payslip owners in the current list");
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    Logger.LogError(ex);
                    WriteToLogFile(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                WriteToLogFile(ex.Message);
            }
        }

        private void btnSMSSelected_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
                frm.Show(this);
                Application.DoEvents();
                try
                {
                    if (grid.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow row in grid.SelectedRows)
                        {
                            if (row != null)
                            {
                                if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red || row.Cells["gridMobileNumber"].Value.ToString().Trim() == null || row.Cells["gridMobileNumber"].Value.ToString().Trim() == string.Empty)
                                {
                                    ScheduleMessage scheduleMessage = new ScheduleMessage();
                                    scheduleMessage.To = row.Cells["gridMobileNumber"].Value.ToString().Trim();
                                    scheduleMessage.From = "System";
                                    scheduleMessage.Message = "Your PaySlip with Net Salary: GHC" + row.Cells["gridNetSalary"].Value.ToString().Trim() + " for " + row.Cells["gridMonth"].Value.ToString().Trim() + "," + row.Cells["gridYear"].Value.ToString().Trim() + " has been Completed";
                                    scheduleMessage.Schedule_time = DateTime.Now;
                                    scheduleMessage.Status = "Send";

                                    dal.Save(scheduleMessage);
                                    dal.CommitTransaction();
                                }
                            }
                        }
                        frm.Close();

                        GlobalData.ShowMessage("SMS sent to Selected Payslip owners");
                    }
                    else
                    {
                        GlobalData.ShowMessage("Please Select the PaySlip from the Grid.");
                    }
                }
                catch (Exception ex)
                {
                    frm.Close();
                    Logger.LogError(ex);
                    WriteToLogFile(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                WriteToLogFile(ex.Message);
            }
        }

        private void btnEmployeeBanks_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Employee_Banks employee_Banks = new Employee_Banks();
                    employee_Banks.MdiParent = this.MdiParent;
                    employee_Banks.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbFileFomats_DropDown(object sender, EventArgs e)
        {
            try
            {
                string[] collectionFormat = Enum.GetNames(typeof(CrystalDecisions.Shared.ExportFormatType));
                this.cmbFileFomats.Items.AddRange(collectionFormat);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMechanised_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMechanised.Text.Trim() == "Yes")
                {
                    mechanised = true;
                }
                else if (cboMechanised.Text.Trim() == "No")
                {
                    mechanised = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPostQuickbook_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void paySlipReport1_InitReport(object sender, EventArgs e)
        {

        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbUnit_DropDown(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cmbUnit.Items.Clear();
                cmbUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cmbDepartments.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cmbUnit.Items.Add("All");
                var units = dal.GetByCriteria<Unit>(query);

                foreach (var unit in units)
                {
                    cmbUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        
    }
}
