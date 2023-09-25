using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using System.Threading;

namespace eMAS.All_UIs.Staff_Information_FORMS
{
    public partial class Employee_Search : Form,IRefreshView
    {
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<Employee> foundEmployees;
        private IList<Department> departments;
        private IList<Zone> zones;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Unit> units;
        private Company company;
        private EmployeeMaintenance employeeRegistration;
        private IDAL dal;
        private DALHelper dalHelper;
        private int ctr;
        private bool mechanised;
        private bool found;

        public Employee_Search()
        {
            try
            {
                InitializeComponent();
                this.employeeRegistration = new EmployeeMaintenance();
                this.employees = new List<Employee>();
                this.company = new Company();
                this.employeeList = new List<Employee>();
                this.foundEmployees = new List<Employee>();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.dal = new DAL();
                this.dalHelper = new DALHelper();
                this.ctr = 0;
                this.mechanised = false;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Employee_Search(IDAL dal, EmployeeMaintenance viewForm)
        {
            try
            {
                InitializeComponent();
                this.employeeRegistration = viewForm;
                this.employees = new List<Employee>();
                this.company = new Company();
                this.employeeList=new List<Employee>();
                this.foundEmployees = new List<Employee>();
                this.zones = new List<Zone>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.dal = dal;
                this.dalHelper = new DALHelper();
                this.ctr = 0;
                this.mechanised = false;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gridSearchResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    employeeRegistration.PopulateView(grid.CurrentRow);
                    employeeRegistration.Show();
                    employeeRegistration.Focus();
                    employeeRegistration.BringToFront();
                    employeeRegistration.WindowState = FormWindowState.Normal;
                    this.WindowState=FormWindowState.Minimized;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

        private void Employee_Search_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                object count = dalHelper.ExecuteScalar("SELECT count(StaffID) From StaffPersonalInfoLazyLoadView Where StaffPersonalInfoLazyLoadView.Archived='False' and StaffPersonalInfoLazyLoadView.Terminated='False'  and StaffPersonalInfoLazyLoadView.TransferredOut='False'  and StaffPersonalInfoLazyLoadView.Confirmed='True'");
                txtTotalEmployeeCount.Text = count.ToString();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void RefreshView()
        {
            Application.DoEvents();
            eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
            try
            {
                frm.Show();
                Application.DoEvents();
                employees=dal.LazyLoad<Employee>();
                frm.Close();
            }
            catch (Exception ex)
            {
                frm.Close();
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<Employee> employees)
        {           
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Employee employee in employees)
                {
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
                    grid.Rows[ctr].Cells["gridUserID"].Value = employee.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnMainFinish_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshView();
                PopulateView(employees);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(company.ID == 0)
                {
                    company = dal.LazyLoad<Company>()[0];
                }
                
                if (txtEID.Text.Length >= company.MinimumCharacter)
                {
                    foundEmployees.Clear();
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.StaffID",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtEID.Text.Trim() + '%',
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
                            if (employee.StaffID.Trim().ToLower().StartsWith(txtEID.Text.Trim().ToLower()))
                            {
                                foundEmployees.Add(employee);
                            }
                        }
                        PopulateView(foundEmployees);
                        txtTotalEmpolyeeSearched.Text = foundEmployees.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Employee with StaffID " + txtEID.Text + " is not Found");
                        txtEID.Text = string.Empty;
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
                this.dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected employee?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.Delete(new Employee() { StaffID = grid.CurrentRow.Cells["gridStaffNo"].Value.ToString() });
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.Delete(new Employee() { StaffID = grid.CurrentRow.Cells["gridStaffNo"].Value.ToString() });
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategory.Items.Clear();
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

        private void departmentComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                departmentComboBox.Items.Clear();
                if (departments.Count <= 0)
                {
                    departments = dal.GetAll<Department>();
                }
                
                foreach (Department department in departments)
                {
                    departmentComboBox.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void departmentComboBox_SelectionChangeCommitted(object sender, EventArgs e)
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
                    Value = departmentComboBox.SelectedItem,
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

        private void Clear()
        {
            try
            {
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                txtEID.Clear();
                txtSurname.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void Employee_Search_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                this.dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
                if (zones.Count <= 0)
                {
                    zones = dal.GetAll<Zone>();
                }

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
                if (departmentComboBox.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[departmentComboBox.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
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
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
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
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim()+'%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim()+ '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Confirmed",
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
                employeeList = dal.LazyLoadCriteria<Employee>(query);
                PopulateView(employeeList);
                txtTotalEmpolyeeSearched.Text = employeeList.Count.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void txtPIN_TextChanged(object sender, EventArgs e)
        {
            try
            {
                company = dal.LazyLoad<Company>()[0];
                if (txtPIN.Text.Length >= company.PINMinimumCharacter)
                {
                    foundEmployees.Clear();
                    Query query = new Query();
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.PIN",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtPIN.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                    employeeList = dal.LazyLoadCriteria<Employee>(query);
                    if (employeeList.Count > 0)
                    {
                        foreach (Employee employee in employeeList)
                        {
                            if (employee.PIN.Trim().ToLower().StartsWith(txtPIN.Text.Trim().ToLower()))
                            {
                                foundEmployees.Add(employee);
                            }
                        }
                        PopulateView(foundEmployees);
                        txtTotalEmpolyeeSearched.Text = foundEmployees.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Employee with PIN " + txtEID.Text + " is not Found");
                        txtPIN.Text = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

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
    }
}
