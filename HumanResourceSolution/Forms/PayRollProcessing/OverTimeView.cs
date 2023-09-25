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
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class OverTimeView : Form
    {
        private IDAL dal;
        private OverTimeNew overTimeNew;
        private IList<OverTime> overTimes;
        private IList<OverTime> foundOverTimes;
        private OverTime overTime;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> employeeGrades;
        private IList<OverTimeType> overTimeTypes;
        private Company company;
        private int ctr;
        private bool found;

        public OverTimeView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.overTime = new OverTime();
                this.overTimeNew = new OverTimeNew();
                this.overTimes = new List<OverTime>();
                this.foundOverTimes = new List<OverTime>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.overTimeTypes = new List<OverTimeType>();
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

        public OverTimeView(IDAL dal, OverTimeNew overTimeNew)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.overTime = new OverTime();
                this.overTimeNew = overTimeNew;
                this.overTimes = new List<OverTime>();
                this.foundOverTimes = new List<OverTime>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.gradeCategories = new List<GradeCategory>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.overTimeTypes = new List<OverTimeType>();
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

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    OverTime overTime = new OverTime();
                    overTime.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    overTime.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    overTime.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    overTime.Employee.Department.Description = grid.CurrentRow.Cells["gridDepartment"].Value.ToString();
                    overTime.Employee.Unit.Description = grid.CurrentRow.Cells["gridUnit"].Value.ToString();
                    overTime.Employee.GradeCategory.Description = grid.CurrentRow.Cells["gridGradeCategory"].Value.ToString();
                    overTime.Employee.Grade.Grade = grid.CurrentRow.Cells["gridGrade"].Value.ToString();
                    overTime.Employee.Specialty.Description = grid.CurrentRow.Cells["gridSpecialty"].Value.ToString();
                    overTime.OverTimeType.Description = grid.CurrentRow.Cells["gridOverTimeType"].Value.ToString();
                    overTime.OverTimeType.ID = int.Parse(grid.CurrentRow.Cells["gridOverTimeTypeID"].Value.ToString());
                    if (grid.CurrentRow.Cells["gridEmploymentDate"].Value != null)
                    {
                        overTime.Employee.EmploymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridEmploymentDate"].Value.ToString());
                    }
                    if (grid.CurrentRow.Cells["gridOverTimeTypeID"].Value != null && int.Parse(grid.CurrentRow.Cells["gridOverTimeTypeID"].Value.ToString()) == 1 && grid.CurrentRow.Cells["gridHoliday"].Value != null)
                    {
                        overTime.Holiday = DateTime.Parse(grid.CurrentRow.Cells["gridHoliday"].Value.ToString());
                    }

                    overTime.GradeCategory.Description = grid.CurrentRow.Cells["gridOverTimeGradeCategory"].Value.ToString();
                    overTime.Grade.Grade = grid.CurrentRow.Cells["gridOverTimeGrade"].Value.ToString();
                    overTime.Date = DateTime.Parse(grid.CurrentRow.Cells["gridDate"].Value.ToString());
                    overTime.HrsWorked = decimal.Parse(grid.CurrentRow.Cells["gridHrsWorked"].Value.ToString());
                    overTime.BasicSalary = decimal.Parse(grid.CurrentRow.Cells["gridBasicSalary"].Value.ToString());
                    overTime.Amount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    overTime.Holiday = DateTime.Parse(grid.CurrentRow.Cells["gridHoliday"].Value.ToString());
                    overTime.OverTimeRate = decimal.Parse(grid.CurrentRow.Cells["gridOverTimeRate"].Value.ToString());
                    overTime.TotalShifts = int.Parse(grid.CurrentRow.Cells["gridTotalShifts"].Value.ToString());
                    overTime.Reason = grid.CurrentRow.Cells["gridReason"].Value.ToString();
                    overTime.In_Use = bool.Parse(grid.CurrentRow.Cells["gridInUse"].Value.ToString());
                    overTime.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    overTimeNew.EditOverTimeChange(overTime);
                    Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s OverTime?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            overTime.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            overTime.Archived = true;
                            overTime.ArchivedTime = DateTime.Now;
                            overTime.ArchiverID = GlobalData.User.ID;
                            dal.Delete(overTime);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            overTime.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            overTime.Archived = true;
                            overTime.ArchivedTime = DateTime.Now;
                            overTime.ArchiverID = GlobalData.User.ID;
                            dal.Delete(overTime);
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

        private void closeButton_Click(object sender, EventArgs e)
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

        private void OverTimeView_Load(object sender, EventArgs e)
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
                cboOverTimeGradeCategory.Items.Clear();
                cboOverTimeGradeCategory.Text = string.Empty;
                cboOverTimeType.Items.Clear();
                cboOverTimeType.Text = string.Empty;
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

        private void PopulateView(IList<OverTime> overTimes)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (OverTime overTime in overTimes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = overTime.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = overTime.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = overTime.Employee.ID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = overTime.StaffName;
                    grid.Rows[ctr].Cells["gridSpecialty"].Value = overTime.Employee.Specialty.Description;
                    grid.Rows[ctr].Cells["gridEmploymentDate"].Value = overTime.Employee.EmploymentDate;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = overTime.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridGrade"].Value = overTime.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = overTime.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = overTime.Employee.Unit.Description;

                    
                    grid.Rows[ctr].Cells["gridDate"].Value = overTime.Date;
                    grid.Rows[ctr].Cells["gridOverTimeGradeCategory"].Value = overTime.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridOverTimeGrade"].Value = overTime.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridHrsWorked"].Value = overTime.HrsWorked;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = overTime.BasicSalary;
                    grid.Rows[ctr].Cells["gridAmount"].Value = overTime.Amount;

                    if (overTime.Holiday != null)
                    {
                        grid.Rows[ctr].Cells["gridHoliday"].Value = overTime.Holiday;
                    }
                    grid.Rows[ctr].Cells["gridOverTimeRate"].Value = overTime.OverTimeRate;
                    grid.Rows[ctr].Cells["gridTotalShifts"].Value = overTime.TotalShifts;
                    grid.Rows[ctr].Cells["gridInUse"].Value = overTime.In_Use;
                    grid.Rows[ctr].Cells["gridOverTimeType"].Value = overTime.OverTimeType.Description;
                    grid.Rows[ctr].Cells["gridOverTimeTypeID"].Value = overTime.OverTimeType.ID;
                    grid.Rows[ctr].Cells["gridReason"].Value = overTime.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = overTime.User.ID;
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
                        Property = "OverTimeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboOverTimeType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.OverTimeType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboOverTimeType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboOverTimeGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.OverTimeGradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboOverTimeGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (dateEntry.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "OverTimeView.Date",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = dateEntry.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                overTimes = dal.GetByCriteria<OverTime>(query);
                PopulateView(overTimes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                        foundOverTimes.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffGradeChangeView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        overTimes = dal.GetByCriteria<OverTime>(query);
                        if (overTimes.Count > 0)
                        {
                            foreach (OverTime overTime in this.overTimes)
                            {
                                if (overTime.Employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    foundOverTimes.Add(overTime);
                                }
                            }
                            PopulateView(foundOverTimes);
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

        private void cboOverTimeType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOverTimeType.Items.Clear();
                overTimeTypes = dal.GetAll<OverTimeType>();
                foreach (OverTimeType overTimeType in overTimeTypes)
                {
                    cboOverTimeType.Items.Add(overTimeType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboOverTimeGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOverTimeGradeCategory.Items.Clear();
                if (gradeCategories.Count <= 0)
                {
                    gradeCategories = dal.GetAll<GradeCategory>();
                }

                foreach (GradeCategory category in gradeCategories)
                {
                    cboOverTimeGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
