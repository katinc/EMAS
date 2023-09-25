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
        IDAL dal;
        IList<Department> departments;
        IList<TaxableIncome> taxableIncomes;
        Employee employee;
        IList<PayRollAttendance> attendances;
        Dictionary<string, string> payRollErrors;
        Form reportForm;
        PayRoll payroll;
        IList<Company> company;
        DALHelper dalHelper;
        PayRollStatus status;
        bool overwrite;
        int indexCtr;

        public PayrollGeneration()
        {
            InitializeComponent();
            this.employee = new Employee();
            this.departments = new List<Department>();
            this.company=new List<Company>();
            this.attendances = new List<PayRollAttendance>();
            this.dalHelper = new DALHelper();
            this.dal = new DAL();
            this.dal.OpenConnection();
            this.taxableIncomes = dal.GetAll<TaxableIncome>();  
            this.departments = dal.GetAll<Department>();
            this.company = dal.GetAll<Company>();                      
            this.indexCtr = 0;
            this.grid.DoubleClick += new EventHandler(grid_DoubleClick);
            this.cmbDepartments.DropDown += new EventHandler(cmbDepartments_DropDown);
            this.yearComboBox.DropDown += new EventHandler(yearComboBox_DropDown);
            this.periodComboBox.DropDown += new EventHandler(periodComboBox_DropDown);
        }

        void periodComboBox_DropDown(object sender, EventArgs e)
        {
            periodComboBox.Items.Clear();
            foreach (string item in GlobalData.GetMonthsToDate())
            {
                periodComboBox.Items.Add(item);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            yearComboBox.Items.Clear();
            foreach (string item in GlobalData.GetYears())
            {
                yearComboBox.Items.Add(item);
            }
        }

        void grid_DoubleClick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string,string> error in payRollErrors)
            {
                if (error.Key.Trim() == grid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                {
                    MessageBox.Show(error.Value, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        void cmbDepartments_DropDown(object sender, EventArgs e)
        {
            cmbDepartments.Items.Clear();
            cmbDepartments.Items.Add("ALL DEPARTMENTS");
            foreach (Department department in departments)
            {
                cmbDepartments.Items.Add(department.Description);
            }
        }


        private void Attendance_Load(object sender, EventArgs e)
        {            
            try
            {
                this.Text = GlobalData.Caption;               
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

                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }


        private PayRollStatus Exists(string month, string year)
        {
            PayRollStatus result = PayRollStatus.None;
            try
            {
                dalHelper.OpenConnection();
                if (dalHelper.ExecuteReader(" Select ID From StaffSalaryPayments Where Month =" + GlobalData.GetMonth(month) + " And Year=" + year +" And Status= 2").Rows.Count > 0)
                {
                    result = PayRollStatus.Closed;
                }
                else if (dalHelper.ExecuteReader(" Select ID From StaffSalaryPayments Where Month =" + GlobalData.GetMonth(month) + " And Year=" + year + " And Status= 1").Rows.Count > 0)
                {
                    result = PayRollStatus.Open;
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
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
            if (AllowedToClosePayRoll(GlobalData.User))
            {
                if (grid.Rows.Count > 0)
                {
                    try
                    {
                        dal.OpenConnection();
                        dal.BeginTransaction();

                        if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.Open)
                        {
                            //Save Payroll
                            dalHelper.ExecuteNonQuery("Update StaffSalaryPayments Set Status='2' Where Month='" + GlobalData.GetMonth(periodComboBox.Text) + "' And Year='" + yearComboBox.Text + "'");
                            dal.CommitTransaction();
                            ClearView();
                        }
                        else if (Exists(periodComboBox.Text, yearComboBox.Text) == PayRollStatus.None)
                        {
                            GlobalData.ShowMessage("Please save the payroll first");
                        }
                        else
                        {
                            GlobalData.ShowMessage("The payroll for the selected period has already been generated");
                        }
                    }
                    catch (Exception ex)
                    {
                        dal.RollBackTransaction();
                        Logger.LogError(ex);
                    }
                }
            }
        }


        private void GeneratePayRoll()
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                dal.BeginTransaction();
                string errorString = "Error(s):\n";
                payRollErrors = new Dictionary<string, string>();
                payRollErrors.Clear();
                IList<StaffDeduction> staffDeductions = dal.GetAll<StaffDeduction>();
                IList<StaffAllowance> staffAllowances = dal.GetAll<StaffAllowance>();
                IList<SSNITContribution> ssnitContributions = dal.GetAll<SSNITContribution>();
                IList<SalaryInformation> salaryInfos = dal.GetAll<SalaryInformation>();
                IList<HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims> medicalClaims = dal.GetAll<HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims>();
                IList<StaffLoan> loans = dal.GetAll<StaffLoan>();
                IList<Deduction> deductionTypes = dal.GetAll<Deduction>();
                IList<Allowance> allowanceTypes = dal.GetAll<Allowance>();

                object result = dalHelper.ExecuteScalar("Select Max(PaymentID) From StaffSalaryPayments");
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
                foreach (DataGridViewRow row in grid1.Rows)
                {
                    errorString = string.Empty;
                    grid.Rows.Add(1);
                    PayRollAttendance attendance = new PayRollAttendance();

                    attendance.ID = id;
                    grid.Rows[ctr].Cells["gridPaymentID"].Value = id;

                    //Month And Year
                    attendance.Month = GlobalData.GetMonth(periodComboBox.Text);
                    attendance.Year = int.Parse(yearComboBox.Text);
                    grid.Rows[ctr].Cells["gridMonth"].Value = (Months)Enum.Parse(typeof(Months), attendance.Month.ToString());
                    grid.Rows[ctr].Cells["gridYear"].Value = attendance.Year;

                    //StaffNo
                    attendance.StaffID = row.Cells["grid1StaffNo"].Value.ToString();
                    grid.Rows[ctr].Cells["gridStaffNo"].Value = row.Cells["grid1StaffNo"].Value.ToString();

                    //GetEmployee Based on Staffno
                    employee = dal.GetByID<Employee>(row.Cells["grid1StaffNo"].Value.ToString());


                    //Name
                    grid.Rows[ctr].Cells["gridName"].Value = row.Cells["grid1Name"].Value.ToString();
                    attendance.Name = row.Cells["grid1Name"].Value.ToString();


                    //Loans
                    decimal carLoan = 0;
                    decimal otherLoans = 0;
                    attendance.Loans.Clear();
                    foreach (StaffLoan loan in loans)
                    {
                        if (loan.StaffNo == employee.StaffID)
                        {
                            if (loan.Payments.Count > 0)
                            {
                                foreach (StaffLoanPayment loanPayment in loan.Payments)
                                {
                                    if (!loanPayment.NotAffectSalary && (loanPayment.PaymentDate.Value.Month >= attendance.Month && loanPayment.PaymentDate.Value.Year >= attendance.Year) && (loanPayment.PaymentDate.Value.Month <= attendance.Month && loanPayment.PaymentDate.Value.Year <= attendance.Year))
                                    {
                                        if (loan.Type.ToUpper() == "CAR LOAN")
                                        {
                                            carLoan += loanPayment.Amount;
                                        }
                                        else
                                        {
                                            otherLoans += loanPayment.Amount;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    attendance.Loans.Add("Car Loan", carLoan);
                    attendance.Loans.Add("Other Loans", otherLoans);
                    grid.Rows[ctr].Cells["gridLoan"].Value = 0;
                    foreach (KeyValuePair<string, decimal> item in attendance.Loans)
                    {
                        grid.Rows[ctr].Cells["gridLoan"].Value = decimal.Parse(grid.Rows[ctr].Cells["gridLoan"].Value.ToString()) + item.Value;
                    }
                    grid.Rows[ctr].Cells["gridLoan"].Value = Math.Round(decimal.Parse(grid.Rows[ctr].Cells["gridLoan"].Value.ToString()), 2);
                    attendance.TotalLoans = Math.Round(decimal.Parse(grid.Rows[ctr].Cells["gridLoan"].Value.ToString()), 2);

                    //Medical Claims
                    attendance.MedicalClaims = 0;
                    foreach (HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS.MedicalClaims claim in medicalClaims)
                    {
                        if (claim.StaffID == employee.StaffID && claim.Paid && ((claim.PaymentDate.Value.Month >= attendance.Month && claim.PaymentDate.Value.Year >= attendance.Year) && (claim.PaymentDate.Value.Month <= attendance.Year && claim.PaymentDate.Value.Year <= attendance.Year)))
                        {
                            attendance.MedicalClaims += decimal.Parse(claim.ServiceCost);
                            grid.Rows[ctr].Cells["gridMedicalClaims"].Value = 0;
                            grid.Rows[ctr].Cells["gridMedicalClaims"].Value = decimal.Parse(grid.Rows[ctr].Cells["gridMedicalClaims"].Value.ToString()) + decimal.Parse(claim.ServiceCost);
                        }
                    }
                    if (attendance.MedicalClaims == 0)
                    {
                        grid.Rows[ctr].Cells["gridMedicalClaims"].Value = 0.00;
                    }

                    ////Grade
                    //attendance.Grade = employee.Grade.Grade;
                    //grid.Rows[ctr].Cells["gridGrade"].Value = attendance.Grade;

                    ////Level
                    //attendance.Level = employee.Grade.Level;
                    //grid.Rows[ctr].Cells["gridGradeLevel"].Value = attendance.Level;

                    //Allowances
                    decimal totalAllowance = 0;
                    bool allowanceFound = false;
                    attendance.Allowances.Clear();
                    foreach (Allowance allowanceType in allowanceTypes)
                    {
                        allowanceFound = false;
                        if (allowanceType.InUse) //&& allowanceType.AllowanceType.Description.ToLower() == "non taxable")
                        {
                            //Remember separate taxable from non taxable
                            foreach (StaffAllowance allowance in staffAllowances)
                            {
                                if (allowance.StaffID == employee.StaffID && ((allowance.EffectiveDate.Value.Month <= attendance.Month && allowance.EffectiveDate.Value.Year <= attendance.Year) && allowance.Type.Description == allowanceType.Description))
                                {
                                    totalAllowance += allowance.Amount;
                                    attendance.Allowances.Add(new StaffAllowance() { Amount = allowance.Amount, EffectiveDate = GlobalData.ServerDate, Type = allowanceType, StaffID = attendance.StaffID });
                                    allowanceFound = true;
                                }
                            }
                            if (!allowanceFound)
                                attendance.Allowances.Add(new StaffAllowance() { Amount = 0, EffectiveDate = GlobalData.ServerDate, Type = allowanceType, StaffID = attendance.StaffID });
                        }
                    }
                    grid.Rows[ctr].Cells["gridAllowances"].Value = Math.Round(totalAllowance, 2);
                    attendance.TotalAllowance += Math.Round(totalAllowance, 2);

                    //Deductions
                    decimal totalDeduction = 0;
                    bool deductionFound = false;
                    attendance.Deductions.Clear();
                    foreach (Deduction deductionType in deductionTypes)
                    {
                        deductionFound = false;
                        if (deductionType.Inactive)
                        {
                            foreach (StaffDeduction deduction in staffDeductions)
                            {
                                if (deduction.StaffID == employee.StaffID && (deduction.EffectiveDate.Value.Month <= attendance.Month && deduction.EffectiveDate.Value.Year <= attendance.Year) && deduction.Type.Description == deductionType.Description)
                                {
                                    totalDeduction += deduction.Amount;
                                    attendance.Deductions.Add(new StaffDeduction() { Amount = deduction.Amount, EffectiveDate = GlobalData.ServerDate, Type = deductionType, StaffID = attendance.StaffID });
                                    deductionFound = true;
                                }
                            }
                            if (!deductionFound)
                                attendance.Deductions.Add(new StaffDeduction() { Amount = 0, EffectiveDate = GlobalData.ServerDate, Type = deductionType, StaffID = attendance.StaffID });
                        }
                    }
                    grid.Rows[ctr].Cells["gridDeductions"].Value = Math.Round(totalDeduction, 2);
                    attendance.TotalDeductions += Math.Round(totalDeduction, 2);
                    bool salaryError = true;

                    //Salary Info
                    attendance.BasicSalary = 0;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = 0.00;
                    attendance.Attendance = "N/A";
                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = "N/A";
                    foreach (SalaryInformation salaryInfo in salaryInfos)
                    {
                        if (salaryInfo.StaffID == employee.StaffID)
                        {
                            if (salaryInfo.StartDate.Month <= attendance.Month && salaryInfo.StartDate.Year <= attendance.Year)
                            {

                                if (employee.Hourly)
                                {
                                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = 30; //Get Attendancedays from StaffAttendanceLogs
                                    decimal hourlyRate = decimal.Parse(dalHelper.ExecuteScalar("Select Sum(OverTimeAmount) From CompanyInfo").ToString());
                                    attendance.BasicSalary = hourlyRate * decimal.Parse(grid.Rows[ctr].Cells["gridAttendanceDays"].Value.ToString());
                                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = attendance.BasicSalary;
                                }
                                else
                                {
                                    attendance.BasicSalary = salaryInfo.MonthlyBasicSalary;
                                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = attendance.BasicSalary;
                                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = "N/A";
                                }

                                //Department
                                attendance.Department = salaryInfo.Department;
                                grid.Rows[ctr].Cells["gridDepartment"].Value = attendance.Department;

                                //PaymentMode
                                attendance.PaymentMode = salaryInfo.PaymentMode;
                                grid.Rows[ctr].Cells["gridPaymentMode"].Value = attendance.PaymentMode;

                                //Grade
                                attendance.Grade = salaryInfo.Grade;
                                grid.Rows[ctr].Cells["gridGrade"].Value = attendance.Grade;

                                //GradeLevel
                                attendance.Level = salaryInfo.SalaryLevelID.ToString();
                                grid.Rows[ctr].Cells["gridGradeLevel"].Value = attendance.Level;
                                salaryError = false;
                            }
                        }
                    }

                    if (salaryError)
                    {
                        SetRowColor(grid.Rows[ctr], Color.Red);
                        errorString += attendance.Name + "'s basic salary info has not been setup at the salary information section.\n\n";
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
                            //SSNITEmployerRate
                            attendance.SsnitEmployerRate = ssnitContributions[0].EmployerPercentage;

                            //SSNITEmployee
                            attendance.SsnitEmployeeRate = ssnitContributions[0].EmployeePercentage;

                            //Employee
                            attendance.SSNITEmployee = (ssnitContributions[0].EmployeePercentage / 100) * attendance.BasicSalary;
                            grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = Math.Round(attendance.SSNITEmployee, 2);

                            //Employer
                            attendance.SSNITEmployer = (ssnitContributions[0].EmployerPercentage / 100) * attendance.BasicSalary;
                            grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = Math.Round(attendance.SSNITEmployer, 2);
                        }
                        catch (Exception ex)
                        {
                            string err = ex.Message;
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
                    }

                    
                    //Calculate Income Tax
                    bool taxError = false;
                    if (employee.IncomeTaxContribution)
                    {
                        attendance.IncomeTax = CalculateIncomeTax(attendance.BasicSalary - attendance.SSNITEmployee,ref taxError);
                        grid.Rows[ctr].Cells["gridIncomeTax"].Value = Math.Round(attendance.IncomeTax, 2);
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

                    //Net After Tax
                    attendance.NetAfterTax = attendance.BasicSalary - attendance.SSNITEmployee - attendance.IncomeTax;
                    grid.Rows[ctr].Cells["gridNetAfterTax"].Value = Math.Round(attendance.NetAfterTax, 2);

                    //Calculate Net Salary
                    attendance.NetSalary = attendance.NetAfterTax;
                    foreach (StaffAllowance allowance in attendance.Allowances)
                    {
                        attendance.NetSalary += allowance.Amount;
                    }
                    grid.Rows[ctr].Cells["gridNetSalary"].Value = Math.Round(attendance.NetSalary, 2);

                    //Calculate TakeHome
                    attendance.TakeHome = attendance.NetSalary;
                    attendance.TakeHome = attendance.TakeHome - attendance.TotalDeductions - attendance.TotalLoans;


                    grid.Rows[ctr].Cells["gridTakeHome"].Value = Math.Round(attendance.TakeHome, 2);

                    //User
                    attendance.UserID = GlobalData.User;
                    attendance.Status = "1";


                    if (!taxError && !ssnitError && !salaryError)
                    {
                        dal.Save(attendance);
                        attendances.Add(attendance);
                    }
                    else
                    {
                        payRollErrors.Add(attendance.StaffID,errorString);
                    }
                    ctr++;
                }
                dal.CommitTransaction();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                dal.RollBackTransaction();
            }
        }

        private void ClearView()
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
        }

        private void DisableBoxes(bool state)
        {
            attendanceGroupBox.Enabled = !state;
            periodGroupBox.Enabled = !state;
            nameTextBox.Enabled = !state;
            staffIDTextBox.Enabled = !state;
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
                    GlobalData.ShowMessage("Sorry, a the pay slip cannot be removed because the payroll is closed");

            }
            catch (Exception ex)
            {
                dalHelper.RollBackTransaction();
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbDepartments.Text.Trim() != string.Empty)
                {
                    dalHelper.OpenConnection();
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
                    DisableBoxes(true);
                indexCtr++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, GlobalData.Caption);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClosePayroll_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private decimal CalculateIncomeTax(decimal salary ,ref bool result)
        {                            
            decimal incomeTax = 0;
            
            try
            {
                decimal cumulativeTaxableIncome = 0;
                int ctr = 0;
                foreach (TaxableIncome taxableIncome in taxableIncomes)
                {
                    cumulativeTaxableIncome += taxableIncome.AnnualTaxableIncome / 12;
                    if (GlobalData.ServerDate.Year == taxableIncome.Year)
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
                string err = ex.Message;
            }
            return incomeTax;
        }

        private void ViewPayRoll()
        {
            int ctr = 0;
            grid1.Rows.Clear();
            if (cmbDepartments.Text.Trim() != string.Empty)
            {
                if (cmbDepartments.Text.ToUpper().Trim() == "ALL DEPARTMENTS")
                {
                    foreach (Employee employee in dal.LazyLoad<Employee>())
                    {
                        grid1.Rows.Add(1);
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        grid1.Rows[ctr].Cells["grid1StaffNo"].Value = employee.StaffID;
                        grid1.Rows[ctr].Cells["grid1Name"].Value = name;
                        grid1.Rows[ctr].Cells["grid1AttendanceDays"].Value = 30;
                        ctr++;
                    }
                }
                else
                {
                    Query query = new Query();
                    query.JoinClauses.Add(new JoinClause()
                    {
                        PrimaryProperty = "StaffPersonalInfo.DepartmentID",
                        SecondaryProperty = "Departments.ID",
                        JoinOperator = JoinOperator.InnerJoin,
                        Entity = "StaffSalaryHistory"
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfo.Terminated",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfo.TransferredOut",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfo.OnLeaveWithPay",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = false,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfo.DepartmentID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cmbDepartments.SelectedIndex - 1].ID,
                        CriteriaOperator = CriteriaOperator.None
                    });

                    foreach (Employee employee in dal.GetByCriteria<Employee>(query))
                    {
                        grid1.Rows.Add(1);
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        grid1.Rows[ctr].Cells["grid1StaffNo"].Value = employee.StaffID;
                        grid1.Rows[ctr].Cells["grid1Name"].Value = name;
                        grid1.Rows[ctr].Cells["grid1AttendanceDays"].Value = 30;
                        ctr++;
                    }
                }

                if (yearComboBox.Text.Trim() != string.Empty && periodComboBox.Text.Trim() != string.Empty)
                {
                    dal.OpenConnection();
                    overwrite = false;
                    status = Exists(periodComboBox.Text, yearComboBox.Text);
                    
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
                            GetPayRoll(periodComboBox.Text, yearComboBox.Text);
                            overwrite = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The payroll for the specified period has already been closed.\nYou can only view and print but not modify");
                        GetPayRoll(periodComboBox.Text, yearComboBox.Text);
                        overwrite = false;
                    }
                }
            }
        }

        private void GetPayRoll(string month, string year)
        {
            try
            {
                PayRollAttendance attendance = new PayRollAttendance();
                DataTable payRollTable = dalHelper.ExecuteReader("Select * from StaffSalaryPayments Where Month=" + GlobalData.GetMonth(month) + " And Year =" + year);
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in payRollTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridPaymentID"].Value = row["PaymentID"];
                    grid.Rows[ctr].Cells["gridStaffNo"].Value = row["StaffID"];
                    grid.Rows[ctr].Cells["gridName"].Value = row["Name"];
                    grid.Rows[ctr].Cells["gridAttendanceDays"].Value = row["DaysOfAttendance"];
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = row["BasicSalary"];
                    grid.Rows[ctr].Cells["gridMonth"].Value = row["Month"];
                    grid.Rows[ctr].Cells["gridYear"].Value = row["Year"];
                    grid.Rows[ctr].Cells["gridSNNITEmployee"].Value = row["SSNITEmployee"];
                    grid.Rows[ctr].Cells["gridSSNITEmployer"].Value = row["SSNITEmployer"];
                    grid.Rows[ctr].Cells["gridIncomeTax"].Value = row["IncomeTax"];
                    grid.Rows[ctr].Cells["gridNetAfterTax"].Value = row["NetAfterTax"];
                    grid.Rows[ctr].Cells["gridNetSalary"].Value = row["NetSalary"];
                    grid.Rows[ctr].Cells["gridMedicalClaims"].Value = row["MedicalClaims"];
                    grid.Rows[ctr].Cells["gridAllowances"].Value = row["TotalAllowance"];
                    grid.Rows[ctr].Cells["gridDeductions"].Value = row["TotalDeduction"];
                    grid.Rows[ctr].Cells["gridTakeHome"].Value = row["TakeHome"];
                    grid.Rows[ctr].Cells["gridLoan"].Value = row["Loan"];
                    grid.Rows[ctr].Cells["gridPaymentMode"].Value = row["PaymentMode"];
                    grid.Rows[ctr].Cells["gridDepartment"].Value = row["Department"];
                    grid.Rows[ctr].Cells["gridSSNITNo"].Value = row["SSNITNo"];
                    grid.Rows[ctr].Cells["gridGrade"].Value = row["Grade"];
                    grid.Rows[ctr].Cells["gridGradeLevel"].Value = row["GradeLevel"];
                    grid.Rows[ctr].Cells["gridStatus"].Value = (PayRollStatus)Enum.Parse(typeof(PayRollStatus), row["Status"].ToString());
                    if (row["Status"].ToString() == "1")
                    {
                        if (ctr == 1 || ctr == 3 || ctr == 5 || ctr == 7 || ctr == 9 || ctr == 11 || ctr == 13 || ctr == 15 || ctr == 7 || ctr == 19 || ctr == 21)
                        {
                            SetRowColor(grid.Rows[ctr], Color.White);
                        }
                        else
                        {
                            SetRowColor(grid.Rows[ctr], Color.GhostWhite);
                        }
                    }
                    else if (row["Status"].ToString() == "2")
                    {
                        SetRowColor(grid.Rows[ctr], Color.Silver);
                    }
                    ctr++;
                }

                ctr = 0;
                grid1.Rows.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid1.Rows.Add(1);
                    grid1.Rows[ctr].Cells["grid1StaffNo"].Value = row.Cells["gridStaffNo"].Value;
                    grid1.Rows[ctr].Cells["grid1Name"].Value = row.Cells["gridName"].Value;
                    grid1.Rows[ctr].Cells["grid1AttendanceDays"].Value = row.Cells["gridAttendanceDays"].Value;

                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
                throw ex;
            }

        }


        private void SetRowColor(DataGridViewRow row , Color color)
        {
            row.Cells["gridStaffNo"].Style.BackColor = color;
            row.Cells["gridName"].Style.BackColor = color;
            row.Cells["gridAttendanceDays"].Style.BackColor = color;
            row.Cells["gridBasicSalary"].Style.BackColor = color;
            row.Cells["gridMonth"].Style.BackColor = color;
            row.Cells["gridYear"].Style.BackColor = color;
            row.Cells["gridSNNITEmployee"].Style.BackColor = color;
            row.Cells["gridSSNITEmployer"].Style.BackColor = color;
            row.Cells["gridIncomeTax"].Style.BackColor = color;
            row.Cells["gridNetAfterTax"].Style.BackColor = color;
            row.Cells["gridNetSalary"].Style.BackColor = color;
            row.Cells["gridMedicalClaims"].Style.BackColor = color;
            row.Cells["gridAllowances"].Style.BackColor = color;
            row.Cells["gridDeductions"].Style.BackColor = color;
            row.Cells["gridTakeHome"].Style.BackColor = color;
            row.Cells["gridLoan"].Style.BackColor = color;
            row.Cells["gridPaymentMode"].Style.BackColor = color;
            row.Cells["gridDepartment"].Style.BackColor = color;
            row.Cells["gridSSNITNo"].Style.BackColor = color;
            row.Cells["gridGrade"].Style.BackColor = color;
            row.Cells["gridGradeLevel"].Style.BackColor = color;
            row.Cells["gridStatus"].Style.BackColor = color;
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim() != string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["gridName"].Value.ToString().Trim().ToLower().StartsWith(nameTextBox.Text.Trim().ToLower()))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (staffIDTextBox.Text.Trim() != string.Empty)
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["gridStaffNo"].Value.ToString().Trim().ToLower().StartsWith(staffIDTextBox.Text.Trim().ToLower()))
                    {
                        row.Selected = true;
                    }
                }
            }
        }

        private void btnAllowances_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                AllowanceNew allowanceForm = new AllowanceNew();
                allowanceForm.Show();
            }
        }

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
               DeductionsNew deductionForm = new DeductionsNew();
                deductionForm.Show();
            }
        }

        private void btnLoanPayments_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                Loans_Payments loansForm = new Loans_Payments();
                loansForm.Show();
            }
        }

        private void btnMedicalClaims_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                MedicalClaimsNew medicalClaimsForm = new MedicalClaimsNew();
                medicalClaimsForm.Show();
            }
        }

        private void btnSalaryInfo_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                SalaryInfoNew salaryInfoForm = new SalaryInfoNew();
                salaryInfoForm.Show();
            }
        }

        private void btnViewPayroll_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                try
                {
                    dal.OpenConnection();
                    PayRollStatus status =Exists(periodComboBox.Text,yearComboBox.Text);
                    if ( status == PayRollStatus.Closed || status == PayRollStatus.Open && grid.RowCount > 0)
                    {
                        //Save Payroll
                        dal.BeginTransaction();
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                        }
                        payroll = new PayRoll();
                        payroll.Month = GlobalData.GetMonth(periodComboBox.Text).ToString();
                        payroll.Year = yearComboBox.Text;
                        PayRoll existingPayRoll = dal.GetByID<PayRoll>(payroll);
                        dal.Save(payroll);
                        dal.CommitTransaction();
                        reportForm = new PayRollReportForm(payroll.Month,payroll.Year); 
                        reportForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("The payroll attendance for the specified period has not been generated", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information); 
                    }
                }
                catch (Exception ex)
                {
                    dal.RollBackTransaction();
                    Logger.LogError(ex);
                }
            }
        }

        private void btnViewSelectedSlips_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                if (row != null)
                {
                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                    {
                        try
                        {
                            payroll = new PayRoll();
                            payroll.Month = GlobalData.GetMonth(periodComboBox.Text).ToString();
                            payroll.Year = yearComboBox.Text;

                            PayRoll existingPayRoll = dal.GetByID<PayRoll>(payroll);
                            if (existingPayRoll != null)
                            {
                                dal.OpenConnection();
                                PaySlipReportForm form = new PaySlipReportForm(row.Cells["gridStaffNo"].Value.ToString(), int.Parse(row.Cells["gridPaymentID"].Value.ToString()));
                                form.Show();
                            }

                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                    else
                    {
                        GlobalData.ShowMessage("Please correct the errors shown before viewing pay slip.");
                    }
                }
            }
        }

        private void btnPrintSelectedSlips_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@Application.StartupPath + @"\PaySlipReport.rpt");

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                crConnectionInfo.ServerName = GlobalData.ServerName;
                crConnectionInfo.DatabaseName = GlobalData.DatabaseName;
                crConnectionInfo.UserID = GlobalData.UserID;
                crConnectionInfo.Password = GlobalData.Password;

                CrTables = cryRpt.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                foreach (DataGridViewRow row in grid.SelectedRows)
                {
                    cryRpt.RecordSelectionFormula = "{StaffSalaryPayments.StaffID}='" + row.Cells["gridStaffNo"].Value.ToString() + "' And {StaffSalaryPayments.PaymentID}=" + row.Cells["gridPaymentID"].Value.ToString() + " And {StaffSalaryPaymentsAllowancesAndDeductions.StaffID} ='" + row.Cells["gridStaffNo"].Value.ToString() + "' And {StaffSalaryPaymentsAllowancesAndDeductions.PaymentID} =" + row.Cells["gridPaymentID"].Value.ToString() + " And {StaffSalaryPaymentsAllowancesAndDeductions.Amount} > 0 ";
                    cryRpt.Refresh();
                    cryRpt.PrintToPrinter(1, false, 0, 0);
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message + @Application.StartupPath;
            }
        }

        private void btnRemoveSelectedSlips_Click(object sender, EventArgs e)
        {
            Delete();
        }

        #region Close Pay Slip
        private void ClosePaySlip()
        {
            if (AllowedToClosePayRoll(GlobalData.User))
            {
                if (grid.CurrentRow.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                {
                    try
                    {
                        dal.OpenConnection();
                        if (btnOpenPayroll.Text.Trim() == "Close Pay Slip")
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

        private void btnPrintAllSlips_Click(object sender, EventArgs e)
        {

        }

        private void btnEmployeeBanks_Click(object sender, EventArgs e)
        {

        }

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            ViewPayRoll();
        }

        private void OldSave()
        {
            try
            {
                dal.OpenConnection();
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
                GlobalData.LogError(ex);
                dal.RollBackTransaction();
            }
        }

        private void btnOpenPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                if (AllowedToClosePayRoll(GlobalData.User))
                {
                    dal.OpenConnection();
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

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            try
            {
                dal.Delete(new PayRollAttendance() { Month = GlobalData.GetMonth(periodComboBox.Text), Year = int.Parse(yearComboBox.Text) });
                ClearView();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void btnDeductions_Click(object sender, EventArgs e)
        {
            dal.BeginTransaction();

            payroll = new PayRoll();
            payroll.Month = GlobalData.GetMonth(periodComboBox.Text).ToString();
            payroll.Year = yearComboBox.Text;
            PayRoll existingPayRoll = dal.GetByID<PayRoll>(payroll);
            dal.Save(payroll);
            dal.CommitTransaction();

            ParameterField paramField;
            ParameterDiscreteValue paramDiscreteValue;


            paramField = new ParameterField();
            paramField.Name = "Heading";
            paramDiscreteValue = new ParameterDiscreteValue();
            paramDiscreteValue.Value = "PAYROLL REPORT FOR THE PERIOD " + periodComboBox.Text + " " + yearComboBox.Text;
            paramField.CurrentValues.Add(paramDiscreteValue);
            

            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@Application.StartupPath + @"\PayRollReport.rpt");
            cryRpt.ParameterFields.Add(paramField);

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            crConnectionInfo.ServerName = GlobalData.ServerName;
            crConnectionInfo.DatabaseName = GlobalData.DatabaseName;
            crConnectionInfo.UserID = GlobalData.UserID;
            crConnectionInfo.Password = GlobalData.Password;

            CrTables = cryRpt.Database.Tables;
            foreach (Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }
            cryRpt.Refresh();
            cryRpt.PrintToPrinter(1, false, 0, 0);
        }

        private void btnPrintAllSlips_Click(object sender, EventArgs e)
        {
            try
            {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@Application.StartupPath + @"\PaySlipReport.rpt");

                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                crConnectionInfo.ServerName = GlobalData.ServerName;
                crConnectionInfo.DatabaseName = GlobalData.DatabaseName;
                crConnectionInfo.UserID = GlobalData.UserID;
                crConnectionInfo.Password = GlobalData.Password;


                CrTables = cryRpt.Database.Tables;
                foreach (Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["gridBasicSalary"].Style.BackColor != Color.Red)
                    {
                        cryRpt.RecordSelectionFormula = "{StaffSalaryPayments.StaffID}='" + row.Cells["gridStaffNo"].Value.ToString() + "' And {StaffSalaryPayments.PaymentID}=" + row.Cells["gridPaymentID"].Value.ToString() + " And {StaffSalaryPaymentsAllowancesAndDeductions.StaffID} ='" + row.Cells["gridStaffNo"].Value.ToString() + "' And {StaffSalaryPaymentsAllowancesAndDeductions.PaymentID} =" + row.Cells["gridPaymentID"].Value.ToString();
                        cryRpt.Refresh();
                        cryRpt.PrintToPrinter(1, false, 0, 0);
                    }
                }
            }
            catch(Exception ex)
            {
                string str = ex.Message;
            }
        }
    }
}
