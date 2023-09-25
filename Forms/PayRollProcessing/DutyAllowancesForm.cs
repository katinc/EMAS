using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRDataAccessLayer.System_Setup_Data_Control;
using System.Threading;
using Microsoft.VisualBasic;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class DutyAllowancesForm : Form
    {
        IDAL dal;
        IList<Department> departments;
        Company company;
        DutyAllowanceDataMapper dutyAllowanceDataMapper;
        public Permissions permissions;
        
        private Allowance DutyAllowanceSetup;
        public DutyAllowancesForm()
        {
            InitializeComponent();
            dal = new DAL();
            departments = new List<Department>();
            dutyAllowanceDataMapper = new DutyAllowanceDataMapper();
            company=new CompanyDataMapper().GetAll().FirstOrDefault();
            DutyAllowanceSetup = AddGetDutyAllowanceToSetup();
        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.Items.Clear();
                cmbDepartment.Items.Add("ALL DEPARTMENTS");
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }
                foreach (Department department in departments)
                {
                    cmbDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void periodComboBox_DropDown(object sender, EventArgs e)
        {
            
        }
        void getPayPeriods()
        {
            try
            {
               // company = dal.GetAll<Company>();
                if (company.PaymentFrequency == "Monthly")
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
        private void yearComboBox_DropDown(object sender, EventArgs e)
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                grid.Rows.Clear();
            if (Validation(true))
            {

                lstDutyAllowances = dutyAllowanceDataMapper.getDutyAllowances(string.Empty, string.Empty, periodComboBox.Text, Convert.ToInt32(yearComboBox.Text), cmbDepartment.Text, cboMechanised.Text);
                if(lstDutyAllowances==null || lstDutyAllowances.Count==0)
                    MessageBox.Show("No Record(s) Found!");
                else
                {
                    //oldDutyAllowances = lstDutyAllowances;
                 PopulateGrid(lstDutyAllowances);

                }
            }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            //grid.Rows.Clear();
            if (lstDutyAllowances != null){
                if(MessageBox.Show(this,"Would you like to delete related records too","Conform",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                    CheckClosedPeriodSelected(this, EventArgs.Empty);
                    if (isPeriodClosed)
                        return;
                    else
                    {
                        dalHelper = new DALHelper();
                        dalHelper.BeginTransaction();
                        int ctr=0;
                        int row=0;
                        try
                        {
                            dutyAllowanceDataMapper = new DutyAllowanceDataMapper();
                            foreach (DutyAllowance dutyAllowance in lstDutyAllowances)
                            {
                                ctr += dutyAllowanceDataMapper.DeleteDutyAllowance(dalHelper, dutyAllowance, DutyAllowanceSetup.ID, GlobalData.GetMonth(periodComboBox.Text));

                                //lstDutyAllowances.Remove(dutyAllowance);
                                   
                            }
                            if (ctr == lstDutyAllowances.Count)
                            {
                                //grid.Rows.Clear();
                                dalHelper.CommitTransaction();
                                btnFind_Click(this,EventArgs.Empty );
                                MessageBox.Show("Deletion was successful!");
                               // this.Sa.Close();
                                
                            }

                            else
                                MessageBox.Show("Sorry could to delete related record\n Contact Administrator!");
                        }
                        catch (Exception xi) 
                        {
                        }
                       
                    }
                }
                else
                PopulateGrid(lstDutyAllowances);
            }
               
            else
                MessageBox.Show("RecordSet Is Empty..Please Find Record First!");
        }

        private void DutyAllowancesForm_Load(object sender, EventArgs e)
        {
            
            getPayPeriods();
            periodComboBox.Text = GlobalData.GetMonth(DateTime.Now.AddMonths(-1).Month);
            yearComboBox_DropDown(sender, e);
            yearComboBox.Text = DateTime.Now.Year.ToString();

            cboMechanised.Text = "ALL";

            this.Resize += new System.EventHandler(this.Form_Resize);

            permissions = GlobalData.CheckPermissions(2);
            savebtn.Enabled = permissions.CanAdd;


        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (formStaffImageViewer != null)
                formStaffImageViewer.Hide();
        }
        DALHelper dalHelper;
        private IList<DutyAllowance> lstDutyAllowances;
        private bool Validation(bool useFind)
        {
            var error = string.Empty;
            errorProvider1.Clear();
            bool validate=true;
            if (periodComboBox.Text == string.Empty){
                error="Select Valid Pay Period!";
                errorProvider1.SetError(periodComboBox, error);
                validate = false;
            }
            else if (yearComboBox.Text == string.Empty)
            {
                error="Select Valid Pay Year!";
                errorProvider1.SetError(yearComboBox,error);
                validate = false;
            }
           
            else if (useFind == true && cmbDepartment.Text==string.Empty)
            {
                error="Select Department!";
                errorProvider1.SetError(cmbDepartment,error);
                validate = false;
            }
            else if (useFind == true && cboMechanised.Text == string.Empty)
            {
                error="Select Mechanised Status!";
                errorProvider1.SetError(cboMechanised,error);
                validate = false;
            }
            if(error!=string.Empty)
            MessageBox.Show("Error:" + error);

            CheckClosedPeriodSelected(this, EventArgs.Empty);
            //if(useFind)
           
            return validate;
        }
        IList<DutyAllowance> oldDutyAllowances;
        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grid.Rows.Clear();
               if (staffIDTextBox.Text.Length >= company.InitialStaffID.Length && Validation(false))
                {
                    
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();

                    //dalHelper.CreateParameter("@staffID", staffIDTextBox.Text, DbType.String);
                    lstDutyAllowances = dutyAllowanceDataMapper.getDutyAllowances(staffIDTextBox.Text, string.Empty, periodComboBox.Text, Convert.ToInt32(yearComboBox.Text), string.Empty, string.Empty);
                   
                                Thread.CurrentThread.IsBackground = true;
                        //var dt = dalHelper.ExecuteReader("select * from StaffDutyAllowancesView where StaffID like '" + staffIDTextBox.Text.Trim() + "%'");
                      

                        if (lstDutyAllowances.Count == 0)
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDTextBox.Text.Trim() + " is not found");
                            staffIDTextBox.Text = string.Empty;
                        }
                        else
                        {
                           

                            PopulateGrid(lstDutyAllowances);
                           
                        }
                }
                
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        private void PopulateGrid(IList<DutyAllowance> NewlstDutyAllowance)
        {
            try
            {

                grid.Rows.Clear();

                if (NewlstDutyAllowance != null && NewlstDutyAllowance.Count > 0)
                {
                    gridTotalDaysAbsent.SortMode = DataGridViewColumnSortMode.NotSortable;

                    int ctr = 0;
                    foreach (DutyAllowance dutyAllowance in NewlstDutyAllowance)
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = dutyAllowance.ID;
                        grid.Rows[ctr].Cells["gridStaffID"].Value = dutyAllowance.Staff.StaffID;
                        grid.Rows[ctr].Cells["gridStaffName"].Value = (dutyAllowance.Staff.FirstName + " " + dutyAllowance.Staff.OtherName).Trim() + " " + dutyAllowance.Staff.Surname;
                        grid.Rows[ctr].Cells["gridBasicSalary"].Value = dutyAllowance.BasicSalary;
                        grid.Rows[ctr].Cells["gridDutyAllowanceRate"].Value = dutyAllowance.DutyAllowanceRate;

                        grid.Rows[ctr].Cells["gridTotalDaysAbsent"].Value = dutyAllowance.DaysAbsent;

                        grid.Rows[ctr].Cells["gridEarnedDutyAllowance"].Value = getEarnedDutyAllowance(grid.Rows[ctr]);

                        //if (dutyAllowance.ID == 0)
                        //    grid.Rows[ctr].Cells["gridEarnedDutyAllowance"].Value = getEarnedDutyAllowance(grid.Rows[ctr]);
                        //else
                        //    grid.Rows[ctr].Cells["gridEarnedDutyAllowance"].Value = dutyAllowance.EarnedDutyAllowance;
                        ctr++;
                    }
                }
                
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grid.Rows.Clear();
               if (nameTextBox.Text.Length >= 2 && Validation(false))
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();

                    //dalHelper.CreateParameter("@name", nameTextBox.Text.Trim(), DbType.String);

                    // var dt = dalHelper.ExecuteReader("select * from StaffDutyAllowancesView where surname like '" + nameTextBox.Text.Trim() + "%' or firstname like '" + nameTextBox.Text.Trim() + "%' or (othername<>'' and othername like '" + nameTextBox.Text.Trim()+ "%')");
                    lstDutyAllowances = dutyAllowanceDataMapper.getDutyAllowances(string.Empty, nameTextBox.Text, periodComboBox.Text, Convert.ToInt32(yearComboBox.Text), string.Empty, string.Empty);

                    if (lstDutyAllowances.Count == 0)
                    {
                        MessageBox.Show("Employee with Staff Name " + nameTextBox.Text.Trim() + " is not found");
                        staffIDTextBox.Text = string.Empty;
                    }
                    else
                        PopulateGrid(lstDutyAllowances);
                }
                
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (!Information.IsNumeric(grid.Rows[e.RowIndex].Cells["gridTotalDaysAbsent"].Value))
                {
                    grid.Rows[e.RowIndex].Cells["gridTotalDaysAbsent"].ErrorText = "Days Absent Should Be Numeric";
                    grid.Rows[e.RowIndex].Cells["gridTotalDaysAbsent"].Value = 0;
                }
                else if (grid.Rows[e.RowIndex].Cells["gridStaffID"].Value != null && grid.Rows[e.RowIndex].Cells["gridStaffID"].Value.ToString() != string.Empty)
                    grid.Rows[e.RowIndex].Cells["gridEarnedDutyAllowance"].Value = getEarnedDutyAllowance(grid.Rows[e.RowIndex], decimal.Parse(yearComboBox.Text), periodComboBox.Text);
                else
                    grid.Rows[e.RowIndex].Cells["gridEarnedDutyAllowance"].Value = 0;
            }
            catch (Exception xi)
            {
                grid.Rows[e.RowIndex].Cells["gridTotalDaysAbsent"].Value = 0;
            }
        }

        eMAS.DataReference.hrContextDataContext _hrContext = new DataReference.hrContextDataContext();

        private decimal getEarnedDutyAllowance(DataGridViewRow dataRow)
        {
            decimal earnedDutyAllowance = 0;
            try
            {
                decimal dutyAllowanceRate = Convert.ToDecimal(dataRow.Cells["gridDutyAllowanceRate"].Value);
                decimal basicSalary = Convert.ToDecimal(dataRow.Cells["gridBasicSalary"].Value);
                decimal daysAbsent = dataRow.Cells["gridTotalDaysAbsent"].Value != null ? Convert.ToInt32(dataRow.Cells["gridTotalDaysAbsent"].Value) : 0;
                string staffID = dataRow.Cells["gridStaffID"].Value.ToString();

                decimal DutyAllowance = (dutyAllowanceRate * basicSalary) / 100;
                int monthDays = 0;

                if (company.PaymentFrequency.ToLower() == "monthly")
                {
                    monthDays = GlobalData.GetLastDayOfMonth(periodComboBox.Text);

                    int year = Int16.Parse(yearComboBox.Text);

                    if (year % 4 == 0 && monthDays == 28)
                    {
                        monthDays = monthDays + 1;
                    }

                    earnedDutyAllowance = DutyAllowance - ((DutyAllowance * daysAbsent) / monthDays);
                }

                
                //var getStaff = _hrContext.StaffDutyAllowancesViews.SingleOrDefault(u => u.StaffID == staffID);
                //if(getStaff != null)
                //{
                //    var GetStaffDetails = _hrContext.StaffDutyAllowances.SingleOrDefault(u => u.ID == getStaff.ID);
                //    if(GetStaffDetails != null)
                //    {
                //        GetStaffDetails.DutyAllowanceRate = dutyAllowanceRate;
                //        _hrContext.SubmitChanges();
                //    }
                //}

            }
            catch (Exception xi)
            {
                
                Logger.LogError(xi);
            }
           

            return Math.Round(earnedDutyAllowance,2,MidpointRounding.AwayFromZero);
           

           
        }
        private decimal getEarnedDutyAllowance(DataGridViewRow dataRow,decimal? year, string Month)
        {
            decimal earnedDutyAllowance = 0;
            try
            {
                decimal dutyAllowanceRate = Convert.ToDecimal(dataRow.Cells["gridDutyAllowanceRate"].Value);
                decimal basicSalary = Convert.ToDecimal(dataRow.Cells["gridBasicSalary"].Value);
                decimal daysAbsent = dataRow.Cells["gridTotalDaysAbsent"].Value != null ? Convert.ToInt32(dataRow.Cells["gridTotalDaysAbsent"].Value) : 0;
                string staffID = dataRow.Cells["gridStaffID"].Value.ToString();

                decimal DutyAllowance = (dutyAllowanceRate * basicSalary) / 100;
                int monthDays = 0;


                if (company.PaymentFrequency.ToLower() == "monthly")
                {
                    monthDays = GlobalData.GetLastDayOfMonth(periodComboBox.Text);

                    if (year % 4 == 0 && monthDays == 28)
                    {
                        monthDays = monthDays + 1;
                    }

                    earnedDutyAllowance = DutyAllowance - ((DutyAllowance * daysAbsent) / monthDays);
                }

                //DONT KNOW WHAT THIS IS ACHIEVING - MAKING THE PROCESS OF UPDATING DAYS EXTREMELY SLOW!
                //var getStaff = _hrContext.StaffDutyAllowancesViews.SingleOrDefault(u => u.StaffID == staffID && u.Period == Month && u.Year == year.Value);
                //if (getStaff != null)
                //{
                //    var GetStaffDetails = _hrContext.StaffDutyAllowances.SingleOrDefault(u => u.ID == getStaff.ID);
                //    if (GetStaffDetails != null)
                //    {
                //        GetStaffDetails.DutyAllowanceRate = dutyAllowanceRate;
                //        _hrContext.SubmitChanges();
                //    }
                //}

            }
            catch (Exception xi)
            {

                Logger.LogError(xi);
            }


            return Math.Round(earnedDutyAllowance, 2, MidpointRounding.AwayFromZero);



        }

        private bool isPayPeriodClosed(string Month,string Year){
            if (Month != string.Empty && Year != string.Empty)
            {
                try
                {
                    string sql = "select count(*) from StaffSalaryPayments where Month=@Month and Year=@Year and Status=2";
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@Month",GlobalData.GetMonth(Month), DbType.Int32);
                    dalHelper.CreateParameter("@Year",Convert.ToInt32(Year), DbType.Int32);

                    var count = dalHelper.ExecuteScalar(sql);
                    if (Information.IsNumeric(count))
                        return Convert.ToBoolean(count);
                    else
                        return false;
                }
                catch (Exception xi){}
                
            }

            return false;
            
        }
        private void grid_ColumnSortModeChanged(object sender, DataGridViewColumnEventArgs e)
        {
           
        }

        private void grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        EmployeeDataMapper employeeDataMapper;
        StaffImageForm formStaffImageViewer;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                employeeDataMapper = new EmployeeDataMapper();
                var emp = new Employee() { StaffID = Convert.ToString(grid.CurrentRow.Cells["gridStaffID"].Value) };
                formStaffImageViewer = new StaffImageForm(employeeDataMapper.getStaffImage(emp));

                formStaffImageViewer.Show(this);
                formStaffImageViewer.Location = new Point(this.Width + (int)(this.Width * 0.03), (int)(this.Height * 0.18));
                formStaffImageViewer.BringToFront();
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (!Validation(false))
                return;
            else if (isPeriodClosed)
            {
                MessageBox.Show("Sorry Selected Period Is Closed Already,You Cannot Changes!");
                return;
            }

            staffAllowanceDataMapper = new StaffAllowanceDataMapper();
            var periodEndDate= DateTime.Parse(Convert.ToInt32(yearComboBox.Text) + "/" + GlobalData.GetMonth(periodComboBox.Text) + "/" + DateTime.DaysInMonth(Convert.ToInt32(yearComboBox.Text), GlobalData.GetMonth(periodComboBox.Text)));
            var periodStartDate = DateTime.Parse(Convert.ToInt32(yearComboBox.Text) + "/" + GlobalData.GetMonth(periodComboBox.Text) + "/1");
            int ctr=0;
           
            foreach (var dutyAllowance in lstDutyAllowances)
            {
                var earnedDutyAllowance = Convert.ToDecimal(grid.Rows[ctr].Cells["gridEarnedDutyAllowance"].Value);
                dutyAllowance.DaysAbsent = Convert.ToInt32(grid.Rows[ctr].Cells["gridTotalDaysAbsent"].Value);
                dutyAllowance.DutyAllowanceRate = Convert.ToDecimal(grid.Rows[ctr].Cells["gridDutyAllowanceRate"].Value);
                dutyAllowance.PayFrequency = company.PaymentFrequency;
                dutyAllowance.Period = periodComboBox.Text;
                dutyAllowance.Year = Convert.ToInt32(yearComboBox.Text);
                dutyAllowance.EarnedDutyAllowance = earnedDutyAllowance;
                dutyAllowance.EntryDate = DateTime.Now;
                try
                {

                  var savedDutyAllowance=  dutyAllowanceDataMapper.Save(dutyAllowance, periodComboBox.Text, Convert.ToInt32(yearComboBox.Text), GlobalData.User);

                  if (savedDutyAllowance)
                  {
                             //var staffAllowance=  staffAllowanceDataMapper.GetById(dutyAllowance.Staff.ID, "Duty Allowance");
                             var staffAllowance = staffAllowanceDataMapper.GetByIdAnDPeriodEnd(dutyAllowance.Staff.ID, "Duty Allowance", periodEndDate);
                              if (staffAllowance != null && staffAllowance.ID > 0 && periodEndDate.Date==staffAllowance.EndDate.Value.Date)
                              {
                                  //staffAllowanceDataMapper.ArchivePrevious(dutyAllowance.Staff.ID, DutyAllowanceSetup.ID, periodEndDate);
                                  //if (staffAllowance.InUse == true)

                                 staffAllowanceDataMapper.ArchivePrevious(dutyAllowance.Staff.ID, DutyAllowanceSetup.ID, periodEndDate);
                                      staffAllowanceDataMapper.DeletePrevious(dutyAllowance.Staff.ID, DutyAllowanceSetup.ID, periodEndDate);

                                      //staffAllowance.Amount = earnedDutyAllowance;
                                      //staffAllowance.Archived = false;
                                      //staffAllowance.EffectiveDate = DateTime.Parse(Convert.ToInt32(yearComboBox.Text) + "/" + Convert.ToInt32(GlobalData.GetMonth(periodComboBox.Text)) + "/" + "1");
                                      //staffAllowance.Employee = dutyAllowance.Staff;
                                      //staffAllowance.EndDate = periodEndDate;
                                      //staffAllowance.Frequency = company.PaymentFrequency;
                                      //staffAllowance.InUse = true;
                                      //staffAllowance.IsEndDate = true;
                                      //staffAllowance.Type = DutyAllowanceSetup;
                                      //staffAllowance.User = GlobalData.User;

                                      //staffAllowanceDataMapper.Update(staffAllowance);

                                      staffAllowance = new StaffAllowance();
                                      staffAllowance.Amount = earnedDutyAllowance;
                                      staffAllowance.Archived = false;
                                      staffAllowance.EffectiveDate = DateTime.Parse(Convert.ToInt32(yearComboBox.Text) + "/" + Convert.ToInt32(GlobalData.GetMonth(periodComboBox.Text)) + "/" + "1");
                                      staffAllowance.Employee = dutyAllowance.Staff;
                                      staffAllowance.EndDate = periodEndDate;
                                      staffAllowance.Frequency = company.PaymentFrequency;
                                      staffAllowance.InUse = true;
                                      staffAllowance.IsEndDate = true;
                                      staffAllowance.Type = DutyAllowanceSetup;
                                      staffAllowance.User = GlobalData.User;

                                      staffAllowanceDataMapper.Save(staffAllowance);
                              }

                              else
                              {
                                  if (staffAllowance != null && staffAllowance.ID > 0 && periodEndDate.Date > staffAllowance.EndDate.Value.Date)
                                  {
                                      staffAllowance.Archived = true;
                                      
                                      staffAllowance.InUse = false;
                                      staffAllowanceDataMapper.Update(staffAllowance);
                                  }
                                  staffAllowance = new StaffAllowance();
                                  staffAllowance.Amount = earnedDutyAllowance;
                                  staffAllowance.Archived = false;
                                  staffAllowance.EffectiveDate = DateTime.Parse(Convert.ToInt32(yearComboBox.Text) + "/" + Convert.ToInt32(GlobalData.GetMonth(periodComboBox.Text)) + "/" + "1");
                                  staffAllowance.Employee = dutyAllowance.Staff;
                                  staffAllowance.EndDate = periodEndDate;
                                  staffAllowance.Frequency = company.PaymentFrequency;
                                  staffAllowance.InUse = true;
                                  staffAllowance.IsEndDate = true;
                                  staffAllowance.Type = DutyAllowanceSetup;
                                  staffAllowance.User = GlobalData.User;

                                  staffAllowanceDataMapper.Save(staffAllowance);
                              }
                           }
                   
                }
                catch (Exception xi){
                    MessageBox.Show("Error: Duty Allowance Generation Failed!");
                    break;
                }
                ctr++;
            }

            if(ctr==lstDutyAllowances.Count)
                MessageBox.Show("Duty Allowance Generation Successfull!");
            grid.Rows.Clear();
        }

        AllowanceDataMapper allowanceDataMapper;
        AllowanceCategoryDataMapper allowanceCategory;
        AllowanceSubCategoryDataMapper allowanceSubCategory;
        private Allowance AddGetDutyAllowanceToSetup()
        {
            try
            {
                allowanceDataMapper = new AllowanceDataMapper();
                var lstAllowanceSetups = allowanceDataMapper.GetAll();


                foreach (var allowanceSetup in lstAllowanceSetups)
                {
                    if (allowanceSetup.Description.ToLower() == "duty allowance")
                        return allowanceSetup;
                }

                var newAllowance = new Allowance();
                newAllowance.Code = string.Empty;

                allowanceCategory = new AllowanceCategoryDataMapper();
                var lstAllowanceCategories = allowanceCategory.GetAll();

                foreach (var allowanceType in lstAllowanceCategories)
                {
                    if (allowanceType.Description.ToLower() == "taxable")
                    {
                        newAllowance.AllowanceType = allowanceType;
                        break;
                    }
                }

                allowanceSubCategory = new AllowanceSubCategoryDataMapper();
                var lstAllowanceSubCategories = allowanceSubCategory.GetAll();

                foreach (var allowanCategory in lstAllowanceSubCategories)
                {
                    if (allowanCategory.Description.ToLower() == "allowance")
                    {
                        newAllowance.AllowanceSubCategory = allowanCategory;
                        break;
                    }
                }

                newAllowance.Description = "Duty Allowance";
                newAllowance.Amount = 0;
                newAllowance.InUse = true;
                newAllowance.User = GlobalData.User;
                newAllowance.Archived = false;

                //newAllowance.ID = ;
                allowanceDataMapper.Save(newAllowance);

                return newAllowance;
            }
            catch (Exception xi)
            {
                return new Allowance();
            }
            
        }
        StaffAllowanceDataMapper staffAllowanceDataMapper;
        private bool setupStaffAllowance(StaffAllowance staffAllowance)
        {
            try
            {
                staffAllowanceDataMapper = new StaffAllowanceDataMapper();
                staffAllowanceDataMapper.Save(staffAllowance);
                return true;
            }
            catch (Exception xi)
            {
                return false;
            }
          
        }
        bool isPeriodClosed = false;
        private void CheckClosedPeriodSelected(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (isPayPeriodClosed(periodComboBox.Text, yearComboBox.Text))
                {
                    var error = "Sorry Selected Period Is Closed Already,You Cannot Alter Any Changes!";
                    errorProvider1.SetError(yearComboBox, error);
                    errorProvider1.SetError(periodComboBox, error);
                    isPeriodClosed = true;
                }
                else
                    isPeriodClosed = false;
            }
            catch (Exception xi)
            {
                isPeriodClosed = false;
            }
           
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //if (formStaffImageViewer == null)
                //    formStaffImageViewer = new StaffImageForm();

                //if (grid.CurrentRow.Cells["gridStaffID"].Value != null && grid.CurrentRow.Cells["gridStaffID"].Value.ToString() != string.Empty)
                //{
                //    employeeDataMapper = new EmployeeDataMapper();
                //    var emp = new Employee() { StaffID = Convert.ToString(grid.CurrentRow.Cells["gridStaffID"].Value) };
                //    formStaffImageViewer.SetImage(employeeDataMapper.getStaffImage(emp));
                //    if (formStaffImageViewer.Visible == false)
                //        formStaffImageViewer.Show();
                //}
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
           
        }

        private void DutyAllowancesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formStaffImageViewer != null)
                formStaffImageViewer.Close();
        }

        private void DutyAllowancesForm_MinimumSizeChanged(object sender, EventArgs e)
        {
            if (formStaffImageViewer != null)
                formStaffImageViewer.Hide();
        }

        private void DutyAllowancesForm_MaximumSizeChanged(object sender, EventArgs e)
        {
            if (formStaffImageViewer != null)
                formStaffImageViewer.Hide();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }


}
