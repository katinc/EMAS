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
using HRBussinessLayer.Validation;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class TerminationDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private Termination termination;
        private IList<Termination> terminations;
        private IList<Termination> foundTerminations;
        private IList<SeparationType> separationTypes;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private Company company;
        private int ctr;
        private bool approved;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public TerminationDueStaffForm()
        {
            InitializeComponent();
            this.termination = new Termination();
            this.terminations = new List<Termination>();
            this.foundTerminations = new List<Termination>();
            this.separationTypes = new List<SeparationType>();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.gradeCategories = new List<GradeCategory>();
            this.employeeGrades = new List<EmployeeGrade>();
            this.employees = new List<Employee>();
            this.employee = new Employee();
            this.dal = new DAL();
            this.ctr = 0;
            this.approved = false;
            this.found = false;
            this.company = new Company();
            this.dal.OpenConnection();
        }

        private void PopulateView(IList<Termination> terminations)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Termination termination in terminations)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = termination.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = termination.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = termination.Employee.Title.Description + " " + termination.Employee.Surname + " " + termination.Employee.FirstName + " " + termination.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = termination.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = termination.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = termination.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = termination.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridEmployeeNotified"].Value = termination.EmployeeNoticed;
                    grid.Rows[ctr].Cells["gridEmployerNotified"].Value = termination.EmployerNoticed;
                    grid.Rows[ctr].Cells["gridSeparationType"].Value = termination.SeparationType.Description;
                    grid.Rows[ctr].Cells["gridType"].Value = termination.Type;
                    grid.Rows[ctr].Cells["gridSeparationDate"].Value = termination.TerminationDate;
                    grid.Rows[ctr].Cells["gridApproved"].Value = termination.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = termination.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = termination.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = termination.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = termination.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = termination.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = termination.User.ID;
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
                        Property = "TerminationView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerSeparationDate.Checked == true && datePickerSeparationDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.TerminationDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerSeparationDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboSeparationType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.SeparationType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboSeparationType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboReinstatementType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.SeparationType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboReinstatementType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboDepartment.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboUnit.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "TerminationView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.None
                    });
                }
                terminations = dal.GetByCriteria<Termination>(query);
                PopulateView(terminations);
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
                termination = new Termination();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboSeparationType.Items.Clear();
                cboSeparationType.Text = string.Empty;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerSeparationDate.ResetText();
                datePickerSeparationDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved_DropDown(this, EventArgs.Empty);
                cboApproved.Text = "No";
                approved = false;
                txtStaffID.Clear();
                txtSurname.Clear();
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
                if (datePickerSeparationDate.Checked && !Validator.DateRangeValidator(datePickerSeparationDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The Separation Date cannot be greater than today");
                    datePickerSeparationDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundTerminations.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "TerminationView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        terminations = dal.GetByCriteria<Termination>(query);
                        if (terminations.Count > 0)
                        {
                            foreach (Termination termination in terminations)
                            {
                                if (termination.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundTerminations.Add(termination);
                                }
                            }
                            PopulateView(foundTerminations);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not Found");
                            txtStaffID.Text = string.Empty;
                        }
                    }
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

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
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

        private void cboGradeCategory_DropDown(object sender, EventArgs e)
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

        private void cboSeparationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSeparationType.Items.Clear();
                cboReinstatementType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SeparationTypesView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                separationTypes = dal.GetByCriteria<SeparationType>(query);
                foreach (SeparationType sanctionType in separationTypes)
                {
                    cboSeparationType.Items.Add(sanctionType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboReinstatementType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboReinstatementType.Items.Clear();
                cboSeparationType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SeparationTypesView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                separationTypes = dal.GetByCriteria<SeparationType>(query);
                foreach (SeparationType sanctionType in separationTypes)
                {
                    cboReinstatementType.Items.Add(sanctionType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApproved_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboApproved.Items.Clear();
                cboApproved.Items.Add("All");
                cboApproved.Items.Add("Yes");
                cboApproved.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApproved_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboApproved.Text.ToLower().Trim() == "yes")
                {
                    approved = true;
                }
                else if (cboApproved.Text.ToLower().Trim() == "no")
                {
                    approved = false;
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

        private void btnApprove_Click(object sender, EventArgs e)
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
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value != null)
                        {
                            termination = dal.GetByID<Termination>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (termination.ID != 0)
                            {
                                Query staffQuery = new Query();
                                staffQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoLazyLoadView.StaffID",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = grid.Rows[ctr].Cells["gridStaffID"].Value.ToString().Trim(),
                                    CriteriaOperator = CriteriaOperator.And
                                });

                                staffQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = true,
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                employees = dal.LazyLoadCriteria<Employee>(staffQuery);
                                if (employees.Count > 0)
                                {
                                    foreach (Employee employee in employees)
                                    {
                                        //Update Employee Record
                                        
                                        employee.Terminated = !termination.SeparationType.Reinstatement;
                                        if (employee.Terminated)
                                        {
                                            employee.TerminationDate = termination.TerminationDate;
                                            employee.SeparationType.ID = termination.SeparationType.ID;
                                        }
                                        else
                                        {
                                            employee.TerminationDate = null;
                                            employee.SeparationType.ID = 0;
                                        }
                                        dal.Update(employee);
                                        //Update Termination
                                        termination.Approved = true;
                                        termination.ApprovedDate = datePickerApprovedDate.Value.Date;
                                        termination.ApprovedTime = datePickerApprovedDate.Value;
                                        termination.ApprovedUser = GlobalData.User.Name;
                                        termination.ApprovedUserStaffID = GlobalData.User.StaffID;
                                        dal.Update(termination);
                                    }
                                }
                            }
                        }
                        ctr++;
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to delete the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                termination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                termination.Archived = true;
                                dal.Delete(termination);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                termination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                termination.Archived = true;
                                dal.Delete(termination);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
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

        private void TerminationDueStaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnApprove.Enabled = getPermissions.CanAdd;
                    //findbtn.Visible = getPermissions.CanView;
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
    }
}
