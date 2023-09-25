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
    public partial class StaffDOBChangeView : Form
    {
        private IDAL dal;
        private StaffDOBChangeForm staffDOBChangeForm;
        private IList<StaffDOBChange> staffDOBChanges;
        private IList<StaffDOBChange> foundStaffDOBChanges;
        private StaffDOBChange staffDOBChange;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<StaffStatus> statuses;
        private Company company;
        private int ctr;
        private bool found;

        public StaffDOBChangeView(IDAL dal, StaffDOBChangeForm staffDOBChangeForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.staffDOBChange = new StaffDOBChange();
                this.staffDOBChangeForm = staffDOBChangeForm;
                this.staffDOBChanges = new List<StaffDOBChange>();
                this.foundStaffDOBChanges = new List<StaffDOBChange>();
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

        public StaffDOBChangeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffDOBChange = new StaffDOBChange();
                this.staffDOBChangeForm = new StaffDOBChangeForm();
                this.staffDOBChanges = new List<StaffDOBChange>();
                this.foundStaffDOBChanges = new List<StaffDOBChange>();
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
                        StaffDOBChange staffDOBChange = new StaffDOBChange();
                        staffDOBChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        staffDOBChange.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                        staffDOBChange.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                        staffDOBChange.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                        staffDOBChange.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                        staffDOBChange.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                        staffDOBChange.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                        staffDOBChange.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();

                        if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                        {
                            staffDOBChange.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                        }

                        staffDOBChange.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                        staffDOBChange.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                        staffDOBChange.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                        if (grid.CurrentRow.Cells["gridDOBTo"].Value != null)
                        {
                            staffDOBChange.DOBTo = DateTime.Parse(grid.CurrentRow.Cells["gridDOBTo"].Value.ToString());
                        }
                        if (grid.CurrentRow.Cells["gridDOBFrom"].Value != null)
                        {
                            staffDOBChange.DOBFrom = DateTime.Parse(grid.CurrentRow.Cells["gridDOBFrom"].Value.ToString());
                        }
                        
                        staffDOBChangeForm.EditStaffDOBChange(staffDOBChange);
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
                                staffDOBChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffDOBChange.Archived = true;
                                dal.Delete(staffDOBChange);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                staffDOBChange.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                staffDOBChange.Archived = true;
                                dal.Delete(staffDOBChange);
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

        private void StaffDOBChangeView_Load(object sender, EventArgs e)
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
                dateDOBFrom.Checked = false;
                dateDOBTo.Checked = false;
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

        private void PopulateView(IList<StaffDOBChange> staffDOBChanges)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (StaffDOBChange staffDOBChange in staffDOBChanges)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = staffDOBChange.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staffDOBChange.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = staffDOBChange.Employee.ID;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = staffDOBChange.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = staffDOBChange.Employee.EmploymentDate;


                    grid.Rows[ctr].Cells["gridStaffName"].Value = staffDOBChange.StaffName;
                    grid.Rows[ctr].Cells["gridDate"].Value = staffDOBChange.Date;
                    grid.Rows[ctr].Cells["gridDOBTo"].Value = staffDOBChange.DOBTo;
                    grid.Rows[ctr].Cells["gridDOBFrom"].Value = staffDOBChange.DOBFrom;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = staffDOBChange.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = staffDOBChange.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = staffDOBChange.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = staffDOBChange.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridApproved"].Value = staffDOBChange.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = staffDOBChange.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = staffDOBChange.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = staffDOBChange.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = staffDOBChange.ApprovedTime;
                    grid.Rows[ctr].Cells["gridReason"].Value = staffDOBChange.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = staffDOBChange.User.ID;

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
                        Property = "StaffDOBChangeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateDOBFrom.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateDOBFrom.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateDOBTo.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateDOBTo.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffDOBChangeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }

                staffDOBChanges = dal.GetByCriteria<StaffDOBChange>(query);
                PopulateView(staffDOBChanges);
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
                        foundStaffDOBChanges.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffDOBChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        staffDOBChanges = dal.GetByCriteria<StaffDOBChange>(query);
                        if (staffDOBChanges.Count > 0)
                        {
                            foreach (StaffDOBChange staffDOBChange in this.staffDOBChanges)
                            {
                                if (staffDOBChange.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundStaffDOBChanges.Add(staffDOBChange);
                                }
                            }
                            PopulateView(foundStaffDOBChanges);
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

