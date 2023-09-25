using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class BankAdviceSlipSelect : Form
    {
        private IList<PayRollAttendance> payRollAttendances;
        private PayRollAttendance payRollAttendance;
        private IList<Employee> employees;
        private IList<Zone> zones;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Bank> banks;
        private IList<BankBranch> bankBranches;
        private IList<Bank> banksOne;
        private IList<BankBranch> bankBranchesOne;
        private IList<AccountType> accountTypes;
        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;
        private bool mechanised;

        public BankAdviceSlipSelect()
        {
            try
            {
                InitializeComponent();
                this.payRollAttendances = new List<PayRollAttendance>();
                this.payRollAttendance = new PayRollAttendance();
                this.zones=new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.banks = new List<Bank>();
                this.bankBranches = new List<BankBranch>();
                this.banksOne = new List<Bank>();
                this.bankBranchesOne = new List<BankBranch>();
                this.accountTypes = new List<AccountType>();
                this.dal = new DAL();
                this.dal.CloseConnection();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.ctr = 0;
                this.mechanised = false;
                this.company = new Company();
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
                yearComboBox.Items.Add("All");
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                monthComboBox.Items.Add("All");
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                    
                    foreach (string item in GlobalData.GetMonths())
                    {
                        monthComboBox.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        monthComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (checkBoxDistribute.Checked == true)
                {
                    if (cboBankOne.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(cboBankOne, "Please Select the Bank");
                        cboBankOne.Focus();
                    }
                    if (cboBankOne.Text.Trim() != string.Empty && cboBankBranchOne.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(cboBankBranchOne, "Please Select the Bank Branch");
                        cboBankBranchOne.Focus();
                    }
                }
                if (monthComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(monthComboBox, "Please Select the Month");
                    monthComboBox.Focus();
                }
                if (yearComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(yearComboBox, "Please Select the Year");
                    yearComboBox.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateFields())
                {
                    Query query = new Query();
                    payRollAttendance.Month = int.Parse(GlobalData.GetMonth(monthComboBox.Text).ToString());
                    payRollAttendance.Year = int.Parse(yearComboBox.Text);
                    if (cboMechanised.Text.ToLower().Trim() != "all" && cboMechanised.Text.ToLower().Trim() != string.Empty)
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Mechanised",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = mechanised,
                            CriteriaOperator = CriteriaOperator.None
                        });
                    }
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Month",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = payRollAttendance.Month,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Year",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = payRollAttendance.Year,
                        CriteriaOperator = CriteriaOperator.None
                    });
                    payRollAttendances = dal.GetByCriteria<PayRollAttendance>(query);
                    if (payRollAttendances.Count > 0)
                    {
                        if (checkBoxViewSummary.Checked == true)
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            reportForm = new BankAdviceSlipSummaryForm(staffIDtxt.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboZone.Text.Trim(), cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboBank.Text.Trim(), cboBranch.Text.Trim(), cboAccountType.Text.Trim(), txtAccountNumber.Text.Trim(),cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                        else if (chkStraightToBank.Checked == true)
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            reportForm = new StraightToBankReportForm(staffIDtxt.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboZone.Text.Trim(), cboDepartment.Text.Trim(), cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboBank.Text.Trim(), cboBranch.Text.Trim(), cboAccountType.Text.Trim(), txtAccountNumber.Text.Trim(), cboMechanised.Text.Trim(), "Bank");
                            reportForm.Show();
                        }
                        else if (checkBoxDistribute.Checked == true)
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                            }
                            reportForm = new BankAdviceSlipByBankForm(staffIDtxt.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboZone.Text.Trim(), cboDepartment.Text, cboUnit.Text.Trim(), cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboBank.Text.Trim(), cboBranch.Text.Trim(), cboAccountType.Text.Trim(), txtAccountNumber.Text.Trim(), cboBankOne.Text.Trim(), cboBankBranchOne.Text.Trim(),cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                        else
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                                reportForm.Dispose();
                            }
                            reportForm = new BankAdviceSlipReportForm(staffIDtxt.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboZone.Text.Trim(), cboDepartment.Text, cboUnit.Text, cboGradeCategory.Text.Trim(), cboGrade.Text.Trim(), cboBank.Text.Trim(), cboBranch.Text.Trim(), cboAccountType.Text.Trim(), txtAccountNumber.Text.Trim(),cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The payroll for the selected criterior must be generated first", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    employees = dal.LazyLoad<Employee>();
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
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
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                                    ctr++;
                                }
                            }
                            if (found)
                            {
                                if (searchGrid.RowCount == 2)
                                {
                                    searchGrid.Height = searchGrid.RowCount * 24;
                                }
                                else
                                {
                                    searchGrid.Height = searchGrid.RowCount * 23;
                                }
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
                                searchGrid.BringToFront();
                                searchGrid.Visible = true;
                            }
                            else
                            {
                                searchGrid.Visible = false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
                throw ex;
            }
        }

        private void Reset()
        {
            try
            {
                monthComboBox.Items.Add(((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString());
                monthComboBox.Text = ((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString();
                yearComboBox.Items.Add(GlobalData.ServerDate.Year.ToString());
                yearComboBox.Text = GlobalData.ServerDate.Year.ToString();
                cboZone.Text = string.Empty;
                cboDepartment.Text = string.Empty;
                nametxt.Text = string.Empty;
                staffIDtxt.Text = string.Empty;
                txtAccountNumber.Text = string.Empty;
                cboBank.Text = string.Empty;
                cboBranch.Text = string.Empty;
                cboAccountType.Text = string.Empty;
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                cboZone.Text = string.Empty;
                cboZone.Items.Add("All");
                zones = dal.GetAll<Zone>();               
                foreach (Zone zone in zones)
                {
                    cboZone.Items.Add(zone.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboDepartment.Items.Add("All");
                departments = dal.GetAll<Department>();
                
                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboAccountType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAccountType.Items.Clear();
                cboAccountType.Text = string.Empty;
                cboAccountType.Items.Add("All");
                accountTypes = dal.GetAll<AccountType>();
                
                foreach (AccountType accountType in accountTypes)
                {
                    cboAccountType.Items.Add(accountType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBank_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboBank.Items.Clear();
                cboBank.Text = string.Empty;
                cboBank.Items.Add("All");
                banks = dal.GetAll<Bank>();              
                foreach (Bank bank in banks)
                {
                    cboBank.Items.Add(bank.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBank_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "BankView.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboBank.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                cboBranch.Items.Clear();
                cboBranch.Text = string.Empty;
                cboBranch.Items.Add("All");
                bankBranches = dal.GetByCriteria<BankBranch>(query);
                
                foreach (BankBranch bankBranch in bankBranches)
                {
                    cboBranch.Items.Add(bankBranch.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBankOne_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboBankOne.Items.Clear();
                cboBankOne.Text = string.Empty;
                cboBankOne.Items.Add("All");
                banks = dal.GetAll<Bank>();
                foreach (Bank bank in banks)
                {
                    cboBankOne.Items.Add(bank.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBankOne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "BankView.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboBankOne.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                cboBankBranchOne.Items.Clear();
                cboBankBranchOne.Text = string.Empty;
                cboBankBranchOne.Items.Add("All");
                bankBranches = dal.GetByCriteria<BankBranch>(query);

                foreach (BankBranch bankBranch in bankBranches)
                {
                    cboBankBranchOne.Items.Add(bankBranch.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxDistribute_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxDistribute.Checked)
                {
                    lblBankOne.Visible = true;
                    lblBankBranchOne.Visible = true;
                    cboBankOne.Visible = true;
                    cboBankBranchOne.Visible = true;
                }
                else
                {
                    lblBankOne.Visible = false;
                    lblBankBranchOne.Visible = false;
                    cboBankOne.Visible = false;
                    cboBankBranchOne.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cboUnit.Items.Add("All");
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMechanised_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMechanised.Items.Clear();
                cboMechanised.Text = string.Empty;
                cboMechanised.Items.Add("All");
                cboMechanised.Items.Add("Yes");
                cboMechanised.Items.Add("No");
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

        private void BankAdviceSlipSelect_Load(object sender, EventArgs e)
        {
            company = dal.GetAll<Company>()[0];
            if (company.PaymentFrequency == "Monthly")
            {
                periodLabel.Text = "Month:";
            }
            else
            {
                periodLabel.Text = "Week:";
            }
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
