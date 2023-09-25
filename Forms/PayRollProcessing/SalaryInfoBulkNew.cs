using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using eMAS.All_UIs.Applicants;
using eMAS.All_UIs.Staff_Information_FORMS;
using eMAS.Forms.Employment;
using HRDataAccessLayer.Payroll_Processing_Data_Control;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class SalaryInfoBulkNew : Form
    {
        private StaffSalaryHistory salaryInfo;
        private Employee employee;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<Employee> foundEmployees;
        private IList<EmployeeGrade> grades;
        private IList<GradeCategory> gradeCategories;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Level> levels;
        private IList<Step> steps;
        private IList<Band> bands;
        private IList<StaffSalaryHistory> salaryInfos;
        private Company company;
        private IDAL dal;
        private int ctr;
        private bool mechanised;
        private bool isInSalaryInfo;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public SalaryInfoBulkNew()
        {
            try
            {
                InitializeComponent();
                this.salaryInfo = new StaffSalaryHistory();
                this.company = new Company();
                this.employee = new Employee();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.ctr = 0;
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.foundEmployees = new List<Employee>();
                this.salaryInfos = new List<StaffSalaryHistory>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.departments = new List<Department>();
                this.bands = new List<Band>();
                this.levels = new List<Level>();
                this.steps = new List<Step>();
                this.mechanised = false;
                this.isInSalaryInfo = false;
                this.found = false;
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
        IList<SalaryPaymentAccount> lstSalaryPaymentAccounts;
        private void FetchSalaryPaymentAccounts(){
           /* try
            {
                gridSalaryPaymentAccount.Items.Clear();
                var staffSalaryHistoryMapper = new StaffSalaryHistoryDataMapper();
                lstSalaryPaymentAccounts = staffSalaryHistoryMapper.GetAllSalaryPaymentAccounts();

                foreach (var paymentAccount in lstSalaryPaymentAccounts)
                {
                    gridSalaryPaymentAccount.Items.Add(paymentAccount.AccountName);
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }*/
        }
        private void SalaryInfoBulkNew_Load(object sender, EventArgs e)
        {
            try
            {
                //cboActive.SelectedValue = 1;
                //FetchSalaryPaymentAccounts();
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.
                SingleOrDefault(u => u.AccessLevel2 == "Salary Info" && u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        StaffSalaryHistoryDataMapper staffSalaryHistoryDataMapper;
        private void PopulateView(IList<Employee> employees)
        {
            staffSalaryHistoryDataMapper = new StaffSalaryHistoryDataMapper();
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Employee employee in employees)
                {
                    //staffSalaryHistory= staffSalaryHistoryDataMapper.GetSalaryHistory(employee.StaffID);
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                    grid.Rows[ctr].Cells["gridFirstName"].Value = employee.FirstName;
                    grid.Rows[ctr].Cells["gridOtherName"].Value = employee.OtherName;
                    grid.Rows[ctr].Cells["gridSurname"].Value = employee.Surname;
                    grid.Rows[ctr].Cells["gridGender"].Value = employee.Gender;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridTitle"].Value = employee.Title.Description;
                    grid.Rows[ctr].Cells["gridMaritalStatus"].Value = employee.MaritalStatus;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = employee.BasicSalary;
                    grid.Rows[ctr].Cells["gridPaymentAccType"].Value = employee.PaymentAccType;
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(grid.Rows[ctr].Cells["gridUserID"].Value.ToString()))
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = true;
                    }
                    else
                    {
                        grid.Rows[ctr].Cells["gridSelect"].ReadOnly = false;
                    }
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData()
        {
            try
            {
                Query query = new Query();
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
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = grades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim()+'%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim()+'%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboMechanised.Text.Trim() != string.Empty && cboMechanised.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Mechanised",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = mechanised,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboActive.Text.Trim() != string.Empty && cboActive.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.IsInSalaryInfo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = isInSalaryInfo,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
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
                
                employeeList = dal.LazyLoadCriteria<Employee>(query);
                PopulateView(employeeList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetData(bool active)
        {
            try
            {
                Query query = new Query();
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
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = grades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboMechanised.Text.Trim() != string.Empty && cboMechanised.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Mechanised",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = mechanised,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboActive.Text.Trim() != string.Empty && cboActive.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.IsInSalaryInfo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = isInSalaryInfo,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
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
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.IsInSalaryInfo",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = active,
                    CriteriaOperator = CriteriaOperator.And
                });

                employeeList = dal.LazyLoadCriteria<Employee>(query);
                PopulateView(employeeList);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }



        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboActive.Items.Clear();
                cboActive.Text = string.Empty;
                cboActive_DropDown(this,EventArgs.Empty);
                cboActive.Text = "No";
                cboMechanised.Items.Clear();
                cboMechanised.Text = string.Empty;
                cboMechanised_DropDown(this,EventArgs.Empty);
                cboMechanised.Text = "No";

                grid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool resultGrid = false;
            bool result = false;
            try
            {
                errorProvider.Clear();
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (grid.Rows[ctr].Cells["gridSelect"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    }
                    if (bool.Parse(grid.Rows[ctr].Cells["gridSelect"].Value.ToString()) == true)
                    {
                        resultGrid = true;
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if (resultGrid == false)
                {
                    MessageBox.Show("Select at least one row");
                    resultGrid = false;
                    result = false;
                }
                if (paymentModeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Payment Mode Cannot be Empty");
                    paymentModeComboBox.Focus();
                }
                if (startDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Start Date Cannot be Empty");
                    startDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridSelect"].Value != null)
                        {
                            salaryInfo = dal.GetByID<StaffSalaryHistory>(grid.Rows[ctr].Cells["gridStaffNo"].Value);
                            if (salaryInfo.ID == 0)
                            {
                                employee.StaffID = grid.Rows[ctr].Cells["gridStaffNo"].Value.ToString().Trim();
                                employee = dal.LazyLoadByStaffID<Employee>(employee);
                                salaryInfo.MonthlyBasicSalary = decimal.Parse(grid.Rows[ctr].Cells["gridBasicSalary"].Value.ToString());
                                //employee.OldBasicSalary = employee.BasicSalary;
                                //employee.BasicSalary = salaryInfo.MonthlyBasicSalary;
                                employee.PaymentAccType = grid.Rows[ctr].Cells["gridPaymentAccType"].Value.ToString();
                                employee.IsInSalaryInfo = true;
                                dal.Update(employee);
                                salaryInfo.Employee.ID = employee.ID;
                                salaryInfo.Employee.StaffID = employee.StaffID;
                                salaryInfo.Grade.ID = employee.Grade.ID;
                                salaryInfo.Supervisor = employee.Department.Supervisor;
                                salaryInfo.Department.ID = employee.Department.ID;
                                salaryInfo.Band.ID = employee.Band.ID;
                                salaryInfo.Step.ID = employee.Step.ID;
                                salaryInfo.PaymentType = employee.PaymentType;

                                salaryInfo.PaymentMode = paymentModeComboBox.Text;
                                salaryInfo.StartDate = DateTime.Parse(startDate.Value.Year + "/" + startDate.Value.Month + "/" + "1");
                                salaryInfo.UserID = GlobalData.User.ID;
                                salaryInfo.In_Use = inUseCheckBox.Checked;
                                salaryInfo.PaymentFrequency = company.PaymentFrequency;

                               
                                dal.Save(salaryInfo);
                            }
                            else
                            {
                                if (!CanEdit)
                                {
                                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                                    return;
                                }

                                employee.StaffID = grid.Rows[ctr].Cells["gridStaffNo"].Value.ToString();
                                employee = dal.LazyLoadByStaffID<Employee>(employee);
                                salaryInfo.MonthlyBasicSalary = decimal.Parse(grid.Rows[ctr].Cells["gridBasicSalary"].Value.ToString());
                                employee.PaymentAccType = grid.Rows[ctr].Cells["gridPaymentAccType"].Value.ToString();

                                //employee.OldBasicSalary = employee.BasicSalary;
                                //employee.BasicSalary = salaryInfo.MonthlyBasicSalary;
                                employee.IsInSalaryInfo = true;
                                dal.Update(employee);
                                salaryInfo.Employee.ID = employee.ID;
                                salaryInfo.Employee.StaffID = employee.StaffID;
                                salaryInfo.Grade.ID = employee.Grade.ID;
                                salaryInfo.Supervisor = employee.Department.Supervisor;
                                salaryInfo.Department.ID = employee.Department.ID;
                                salaryInfo.Band.ID = employee.Band.ID;
                                salaryInfo.Step.ID = employee.Step.ID;
                                salaryInfo.PaymentType = employee.PaymentType;

                                salaryInfo.PaymentMode = paymentModeComboBox.Text;
                                salaryInfo.StartDate = DateTime.Parse(startDate.Value.Year + "/" + startDate.Value.Month + "/" + "1");
                                salaryInfo.UserID = GlobalData.User.ID;
                                salaryInfo.In_Use = inUseCheckBox.Checked;
                                salaryInfo.PaymentFrequency = company.PaymentFrequency;

                                dal.Update(salaryInfo);
                            }
                        }
                        ctr++;
                    }
                    Clear();
                    GetData();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Could Not Save Successfully,Please See the System Administrator");
            }
        }
        StaffSalaryHistory staffSalaryHistory;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                int ctr = 0;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    grid.Rows[ctr].Cells["gridSelect"].Value = true;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                company = dal.GetAll<Company>()[0];
                if (txtStaffID.Text.Length >= company.MinimumCharacter)
                {
                    foundEmployees.Clear();
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.StaffID",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtStaffID.Text.Trim() + '%',
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
                    employeeList = dal.LazyLoadCriteria<Employee>(query);
                    if (employeeList.Count > 0)
                    {
                        foreach (Employee employee in employeeList)
                        {
                            if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                            {
                                foundEmployees.Add(employee);
                            }
                        }
                        PopulateView(foundEmployees);
                    }
                    else
                    {
                        MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not Found");
                        txtStaffID.Text = string.Empty;
                    }
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
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }

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
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                if (gradeCategories.Count <= 0)
                {
                    gradeCategories = dal.GetAll<GradeCategory>();
                }

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
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in grades)
                {
                    cboGrade.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool active = false;
            try
            {
                if (cboActive.Text.Trim() == "Yes")
                {
                    active = true;
                    GetData(active);
                }
                else if (cboActive.Text.Trim() == "No")
                {
                    active = false;
                    GetData(active);
                }
                else
                {
                    GetData();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            //try
            //{
            //    foundEmployees.Clear();
            //    bool active= false;
            //    if (cboActive.Text.Trim() == "Yes")
            //    {
            //        active = true;
            //    }
            //    else if (cboActive.Text.Trim() == "No")
            //    {
            //        active = false;
            //    }
            //    if (this.employees.Count <= 0)
            //    {
            //        this.employees = dal.LazyLoad<Employee>();
            //    }
            //    if (cboActive.Text.Trim() == "All")
            //    {
            //        foreach (Employee employee in employees)
            //        {
            //            foundEmployees.Add(employee);
            //        }
            //    }
            //    else
            //    {
            //        foreach (Employee employee in employees)
            //        {
            //            if (employee.IsInSalaryInfo == active)
            //            {
            //                foundEmployees.Add(employee);
            //            }
            //        }
            //    }
            //    PopulateView(foundEmployees);
            //}
            //catch (Exception ex)
            //{
            //    Logger.LogError(ex);
            //}

            
        }

        private void cboMechanised_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMechanised.Text.Trim() == "Yes")
                {
                    mechanised = true;
                    GetData();
                    
                }
                else if (cboMechanised.Text.Trim() == "No")
                {
                    mechanised = false;
                    GetData();
                }
                else if (cboMechanised.Text.Trim() == "All")
                {
                    GetData();
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

        private void cboActive_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboActive.Items.Clear();
                cboActive.Text = string.Empty;
                cboActive.Items.Add("All");
                cboActive.Items.Add("Yes");
                cboActive.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void cboGradeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void paymentModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
