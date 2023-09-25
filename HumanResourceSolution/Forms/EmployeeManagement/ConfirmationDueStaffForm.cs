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
    public partial class ConfirmationDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private IList<Employee> foundEmployees;
        private int ctr;
        private bool approved;
        private bool found;

        public ConfirmationDueStaffForm()
        {
            try
            {
                InitializeComponent();
                this.foundEmployees = new List<Employee>();
                this.employees = new List<Employee>();
                this.employee = new Employee();
                this.dal = new DAL();
                this.ctr = 0;
                this.approved = false;
                this.found = false;
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
                        if (GlobalData.QuestionMessage("Are you sure you want to cancel confrmation of the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                employee.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                employee.Probation = false;
                                dal.Delete(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                employee.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                employee.Probation = false;
                                dal.Delete(employee);
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

        private void ConfirmationDueStaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                this.datePickerApprovalDate.Value = DateTime.Now.Date;
                this.datePickerAsAtDate.Value = DateTime.Now.Date;
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                
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

        private void PopulateView(IList<Employee> employees)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Employee employee in employees)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = employee.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = employee.Title.Description + " " + employee.Surname + " " + employee.FirstName + " " + employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridConfirmed"].Value = employee.Confirmed;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = employee.EmploymentDate;
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
                if (datePickerAsAtDate.Checked == true && datePickerAsAtDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.ProbationEndDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerAsAtDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboDepartment.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboUnit.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApprove.Text.Trim() != string.Empty && cboApprove.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffPersonalInfoLazyLoadView.Probation",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                employees = dal.GetByCriteria<Employee>(query);
                PopulateView(employees);
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
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboApprove.Items.Clear();
                cboApprove.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                datePickerAsAtDate.ResetText();
                datePickerAsAtDate.Checked = false;
                datePickerApprovalDate.ResetText();
                datePickerApprovalDate.Checked = false;
                cboApprove.Items.Clear();
                cboApprove_DropDown(this, EventArgs.Empty);
                cboApprove.Text = "No";
                approved = false;
                txtStaffID.Clear();
                txtSurname.Clear();
                datePickerApprovalDate.Value = DateTime.Now.Date;
                datePickerAsAtDate.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void datePickerAsAtDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foundEmployees.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.ProbationEndDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerApprovalDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Probation",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                employees = dal.GetByCriteria<Employee>(query);
                foreach (Employee employee in employees)
                {
                    if (employee.ProbationEndDate.Value.Date == datePickerAsAtDate.Value.Date)
                    {
                        foundEmployees.Add(employee);
                    }
                }
                PopulateView(foundEmployees);
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
                foundEmployees.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.ProbationEndDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerAsAtDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Probation",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                employees = dal.GetByCriteria<Employee>(query);
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                    {
                        foundEmployees.Add(employee);
                    }
                }
                PopulateView(foundEmployees);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundEmployees.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.ProbationEndDate",
                    CriterionOperator = CriterionOperator.LessThanOrEqualTo,
                    Value = datePickerApprovalDate.Value.Date.ToString("yyyy-MM-dd"),
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "StaffPersonalInfoLazyLoadView.Probation",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                employees = dal.GetByCriteria<Employee>(query);
                foreach (Employee employee in employees)
                {
                    if (employee.Surname.Trim().ToLower().StartsWith(txtSurname.Text.Trim().ToLower()))
                    {
                        foundEmployees.Add(employee);
                    }
                }
                PopulateView(foundEmployees);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                if (datePickerApprovalDate.Checked && !Validator.DateRangeValidator(datePickerApprovalDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    MessageBox.Show("The Approval Date cannot be greater than today");
                    datePickerApprovalDate.Focus();
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
                    int ctr = 0;
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (grid.Rows[ctr].Cells["gridID"].Value != null && grid.Rows[ctr].Cells["gridSelect"].Value !=null)
                        {
                            employee.StaffID = grid.Rows[ctr].Cells["gridStaffID"].Value.ToString().Trim();
                            employee = dal.LazyLoadByStaffID<Employee>(employee.StaffID);
                            employee.CurrentConfirmationDate = DateTime.Parse(grid.Rows[ctr].Cells["gridConfirmationDate"].Value.ToString()).Date;
                            employee.ProbationApprover = GlobalData.User.Name;
                            employee.ProbationApprovedDate = DateTime.Now.Date;
                            employee.ProbationApprovedTime = DateTime.Now.Date;
                            employee.ProbationStatus = "";
                            employee.Probation = false;
                            dal.Update(employee);
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboApprove.Text.Trim() == "Yes")
                {
                    approved = true;
                }
                else if (cboApprove.Text.Trim() == "No")
                {
                    approved = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboApprove_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboApprove.Items.Clear();
                cboApprove.Items.Add("All");
                cboApprove.Items.Add("Yes");
                cboApprove.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
