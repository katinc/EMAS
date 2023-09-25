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
    public partial class SanctionDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private Sanction sanction;
        private IList<Sanction> sanctions;
        private IList<Sanction> foundSanctions;
        private IList<SanctionType> sanctionTypes;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private Company company;
        private int ctr;
        private bool approved;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public SanctionDueStaffForm()
        {
            try
            {
                InitializeComponent();
                this.sanction = new Sanction();
                this.sanctions = new List<Sanction>();
                this.foundSanctions = new List<Sanction>();
                this.sanctionTypes = new List<SanctionType>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.dal = new DAL();
                this.ctr = 0;
                this.approved=false;
                this.company = new Company();
                this.dal.OpenConnection();
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
                            sanction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            sanction.Archived = true;
                            dal.Delete(sanction);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void SanctionDueStaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Sanction> sanctions)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Sanction sanction in sanctions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = sanction.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = sanction.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = sanction.Employee.Title.Description + " " + sanction.Employee.Surname + " " + sanction.Employee.FirstName + " " + sanction.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = sanction.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = sanction.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = sanction.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = sanction.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridSanctionType"].Value = sanction.SanctionType.Description;
                    grid.Rows[ctr].Cells["gridSanctioned"].Value = sanction.Sanctioned;
                    grid.Rows[ctr].Cells["gridSanctionDate"].Value = sanction.SanctionDate;
                    grid.Rows[ctr].Cells["gridApproved"].Value = sanction.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = sanction.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = sanction.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = sanction.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = sanction.Reason;
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
                if (datePickerSanctionDate.Checked == true && datePickerSanctionDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.SanctionDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerSanctionDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboSanctionType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.SanctionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboSanctionType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboReinstatementType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.SanctionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboReinstatementType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboDepartment.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboUnit.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                sanctions = dal.GetByCriteria<Sanction>(query);
                PopulateView(sanctions);
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
                sanction = new Sanction();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboSanctionType.Items.Clear();
                cboSanctionType.Text = string.Empty;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerSanctionDate.ResetText();
                datePickerSanctionDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved_DropDown(this,EventArgs.Empty);
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
                if (datePickerSanctionDate.Checked && !Validator.DateRangeValidator(datePickerSanctionDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The Sanction Date cannot be greater than today");
                    datePickerSanctionDate.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
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
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "SanctionView.ID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            sanctions = dal.GetByCriteria<Sanction>(query);
                            sanction = dal.GetByID<Sanction>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (sanction.ID != 0)
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
                                    foreach(Employee employee in employees)
                                    {
                                        //Update Employee Record
                                        employee.SanctionType.ID = sanction.SanctionType.ID;
                                        employee.Payment = sanction.SanctionType.Payment;
                                        employee.Terminated = sanction.SanctionType.Separated;
                                        employee.TerminationDate = sanction.SanctionDate;
                                        employee.CurrentSanctionDate = sanction.SanctionDate;
                                        employee.Sanctioned = sanction.Sanctioned;
                                        dal.Update(employee);
                                        //Update Sanction
                                        sanction.Approved = true;
                                        sanction.ApprovedDate = datePickerApprovedDate.Value.Date;
                                        sanction.ApprovedTime = datePickerApprovedDate.Value;
                                        sanction.ApprovedUser = GlobalData.User.Name;
                                        sanction.ApprovedUserStaffID = GlobalData.User.StaffID;
                                        dal.Update(sanction);
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
                MessageBox.Show("ERROR:Not Save Successfully,Please See the System Administrator");
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
            catch(Exception ex)
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

        private void cboSanctionType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSanctionType.Items.Clear();
                cboReinstatementType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SanctionTypeView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                sanctionTypes = dal.GetByCriteria<SanctionType>(query);
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    cboSanctionType.Items.Add(sanctionType.Description);
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
                cboSanctionType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SanctionTypeView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.And
                });
                sanctionTypes = dal.GetByCriteria<SanctionType>(query);
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    cboReinstatementType.Items.Add(sanctionType.Description);
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
                        foundSanctions.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "SanctionView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        sanctions = dal.GetByCriteria<Sanction>(query);
                        if (sanctions.Count > 0)
                        {
                            foreach (Sanction sanction in sanctions)
                            {
                                if (sanction.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundSanctions.Add(sanction);
                                }
                            }
                            PopulateView(foundSanctions);
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
    }
}
