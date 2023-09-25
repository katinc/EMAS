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
    public partial class StaffJobTitleChangeView : Form
    {
        private IDAL dal;
        private StaffJobTitleChangeForm staffJobTitleChangeForm;
        private IList<StaffJobTitleChange> staffJobTitleChanges;
        private IList<StaffJobTitleChange> foundStaffJobTitleChanges;
        private StaffJobTitleChange staffJobTitleChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<JobTitle> jobTitles;
        private Company company;
        private int ctr;
        private bool found;

        public StaffJobTitleChangeView(IDAL dal,StaffJobTitleChangeForm staffJobTitleChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffJobTitleChange = new StaffJobTitleChange();
                this.staffJobTitleChangeForm = staffJobTitleChangeForm;
                this.staffJobTitleChanges = new List<StaffJobTitleChange>();
                this.foundStaffJobTitleChanges = new List<StaffJobTitleChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.jobTitles = new List<JobTitle>();
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

        public StaffJobTitleChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffJobTitleChange = new StaffJobTitleChange();
                this.staffJobTitleChangeForm = new StaffJobTitleChangeForm();
                this.staffJobTitleChanges = new List<StaffJobTitleChange>();
                this.foundStaffJobTitleChanges = new List<StaffJobTitleChange>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.jobTitles = new List<JobTitle>();
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
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                    {
                        StaffJobTitleChange staffJobTitleChange = new StaffJobTitleChange();
                        staffJobTitleChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        staffJobTitleChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        staffJobTitleChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        staffJobTitleChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        staffJobTitleChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        staffJobTitleChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        staffJobTitleChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        staffJobTitleChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            staffJobTitleChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }

                        staffJobTitleChange.Employee.JobTitle.Description = grid.CurrentRow.Cells["gridJobTitle"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridJobTitleDate"].Value != null)
                        {
                            staffJobTitleChange.Employee.JobTitleDate = DateTime.Parse(grid.CurrentRow.Cells["gridJobTitleDate"].Value.ToString());
                        }


                        staffJobTitleChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        staffJobTitleChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        staffJobTitleChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        staffJobTitleChange.JobTitleTo.Description = grid.CurrentRow.Cells["gridJobTitleTo"].Value.ToString();
                        staffJobTitleChangeForm.EditStaffJobTitleChange(staffJobTitleChange);
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
                                staffJobTitleChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffJobTitleChange.Archived = true;
                                dal.Delete(staffJobTitleChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffJobTitleChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffJobTitleChange.Archived = true;
                                dal.Delete(staffJobTitleChange);
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

        private void StaffJobTitleChangeView_Load(object sender, EventArgs e)
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
                cboJobTitleTo.Items.Clear();
                cboJobTitleTo.Text = string.Empty;
                cboJobTitle.Items.Clear();
                cboJobTitle.Text = string.Empty;
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

        private void PopulateView(IList<StaffJobTitleChange> staffJobTitleChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffJobTitleChange staffJobTitleChange in staffJobTitleChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffJobTitleChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffJobTitleChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffJobTitleChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffJobTitleChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffJobTitleChange.Employee.EmploymentDate;
                    

                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffJobTitleChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffJobTitleChange.Date;
                    grid.Rows[ctr].Cells["gridJobTitleTo"].Value = staffJobTitleChange.JobTitleTo.Description;
                    grid.Rows[ctr].Cells["gridJobTitle"].Value = staffJobTitleChange.JobTitleFrom.Description;
                    grid.Rows[ctr].Cells["gridJobTitleDate"].Value = staffJobTitleChange.Employee.JobTitleDate;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffJobTitleChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffJobTitleChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffJobTitleChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffJobTitleChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffJobTitleChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffJobTitleChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffJobTitleChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffJobTitleChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffJobTitleChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffJobTitleChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffJobTitleChange.User.ID;

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
                        Property = "StaffJobTitleChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboJobTitle.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.StaffJobTitleFrom",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = jobTitles[cboJobTitle.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboJobTitleTo.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.StaffJobTitleTo",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = jobTitles[cboJobTitleTo.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffJobTitleChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                staffJobTitleChanges = dal.GetByCriteria<StaffJobTitleChange>(query);
                PopulateView(staffJobTitleChanges);
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

        private void cboJobTitleTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboJobTitleTo.Items.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    cboJobTitleTo.Items.Add(jobTitle.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboJobTitle_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboJobTitle.Items.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    cboJobTitle.Items.Add(jobTitle.Description);
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
                        foundStaffJobTitleChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffJobTitleChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffJobTitleChanges = dal.GetByCriteria<StaffJobTitleChange>(query);
                        if (staffJobTitleChanges.Count > 0)
                        {
                            foreach (StaffJobTitleChange staffJobTitleChange in this.staffJobTitleChanges)
                            {
                                if (staffJobTitleChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffJobTitleChanges.Add(staffJobTitleChange);
                                }
                            }
                            PopulateView(foundStaffJobTitleChanges);
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
