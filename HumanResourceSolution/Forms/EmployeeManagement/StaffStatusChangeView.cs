using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class StaffStatusChangeView : Form
    {
        private IDAL dal;
        private StaffStatusChangeForm staffStatusChangeForm;
        private IList<StaffStatusChange> staffStatusChanges;
        private IList<StaffStatusChange> foundStaffStatusChanges;
        private StaffStatusChange staffStatusChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<StaffStatus> statuses;
        private Company company;
        private int ctr;
        private bool found;

        public StaffStatusChangeView(IDAL dal, StaffStatusChangeForm staffStatusChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffStatusChange = new StaffStatusChange();
                this.staffStatusChangeForm = staffStatusChangeForm;
                this.staffStatusChanges = new List<StaffStatusChange>();
                this.foundStaffStatusChanges = new List<StaffStatusChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.statuses = new List<StaffStatus>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dateEntry.Value = DateTime.Today.Date;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public StaffStatusChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffStatusChange = new StaffStatusChange();
                this.staffStatusChangeForm = new StaffStatusChangeForm();
                this.staffStatusChanges = new List<StaffStatusChange>();
                this.foundStaffStatusChanges = new List<StaffStatusChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.statuses = new List<StaffStatus>();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dateEntry.Value = DateTime.Today.Date;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == true)
                    {
                        StaffStatusChange staffStatusChange = new StaffStatusChange();
                        staffStatusChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        staffStatusChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        staffStatusChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        staffStatusChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        staffStatusChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        staffStatusChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        staffStatusChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        staffStatusChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            staffStatusChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }

                        staffStatusChange.Employee.StaffStatus.Description = grid.CurrentRow.Cells["gridStatus"].Value.ToString();
                        staffStatusChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        staffStatusChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        staffStatusChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        staffStatusChange.StaffStatusTo.Description = grid.CurrentRow.Cells["gridStatusTo"].Value.ToString();
                        staffStatusChangeForm.EditStaffStatusChange(staffStatusChange);
                        Close();
                    }               
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                {
                    if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s termination?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                staffStatusChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffStatusChange.Archived = true;
                                dal.Delete(staffStatusChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffStatusChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffStatusChange.Archived = true;
                                dal.Delete(staffStatusChange);
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
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void StaffStatusChangeView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
				
            }
            catch(Exception ex)
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

        private void Clear()
        {
            try
            {
                grid.Rows.Clear();
                cboStatusTo.Items.Clear();
                cboStatusTo.Text = string.Empty;
                cboStatus.Items.Clear();
                cboStatus.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                dateEntry.Value = DateTime.Today.Date;
                staffIDtxt.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                errorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<StaffStatusChange> staffStatusChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffStatusChange staffStatusChange in staffStatusChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffStatusChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffStatusChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffStatusChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffStatusChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffStatusChange.Employee.EmploymentDate;


                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffStatusChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffStatusChange.Date;
                    grid.Rows[ctr].Cells["gridStatusTo"].Value = staffStatusChange.StaffStatusTo.Description;
                    grid.Rows[ctr].Cells["gridStatus"].Value = staffStatusChange.StaffStatusFrom.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffStatusChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffStatusChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffStatusChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffStatusChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffStatusChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffStatusChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffStatusChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffStatusChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffStatusChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffStatusChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffStatusChange.User.ID;

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
                        Property = "StaffStatusChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboStatus.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.StaffJobTitleFrom",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = statuses[cboStatus.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboStatusTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.StaffJobTitleTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = statuses[cboStatusTo.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffStatusChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffStatusChanges = dal.GetByCriteria<StaffStatusChange>(query);
                PopulateView(staffStatusChanges);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void cboStatusTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboStatusTo.Items.Clear();
                statuses = dal.GetAll<StaffStatus>();
                foreach (StaffStatus status in statuses)
                {
                    cboStatusTo.Items.Add(status.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboStatus.Items.Clear();
                statuses = dal.GetAll<StaffStatus>();
                foreach (StaffStatus staffStatus in statuses)
                {
                    cboStatus.Items.Add(staffStatus.Description);
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
                        foundStaffStatusChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffStatusChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffStatusChanges = dal.GetByCriteria<StaffStatusChange>(query);
                        if (staffStatusChanges.Count > 0)
                        {
                            foreach (StaffStatusChange staffStatusChange in this.staffStatusChanges)
                            {
                                if (staffStatusChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffStatusChanges.Add(staffStatusChange);
                                }
                            }
                            PopulateView(foundStaffStatusChanges);
                        }
                        else
                        {
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
