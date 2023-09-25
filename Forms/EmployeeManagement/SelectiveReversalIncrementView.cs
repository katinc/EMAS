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
using eMAS.Forms.StaffManagement;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class SelectiveReversalIncrementView : Form
    {
        private IDAL dal;
        private SelectiveReversalIncrementForm selectiveReversalIncrementForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<Zone> zones;
        private Increment increment;
        private IList<Increment> increments;
        private IList<Increment> foundIncrements;
        private int ctr;
        private bool found;

        public SelectiveReversalIncrementView(SelectiveReversalIncrementForm selectiveReversalIncrementForm)
        {
            try
            {
                InitializeComponent();
                this.selectiveReversalIncrementForm = selectiveReversalIncrementForm;
                this.employee = new Employee();
                this.increment = new Increment();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.increments = new List<Increment>();
                this.foundIncrements = new List<Increment>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public SelectiveReversalIncrementView()
        {
            try
            {
                InitializeComponent();
                this.selectiveReversalIncrementForm = new SelectiveReversalIncrementForm();
                this.employee = new Employee();
                this.increment = new Increment();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.increments = new List<Increment>();
                this.foundIncrements = new List<Increment>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();
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
                    if (grid.CurrentRow != null)
                    {
                        selectiveReversalIncrementForm.EditSelectiveReversalIncrement(grid.CurrentRow);
                        this.Close();
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel the Increment of the Staff " + "?") == DialogResult.Yes)
                        {
                            
                            dal.BeginTransaction();
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                increment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                increment.Archived = true;
                                dal.Delete(increment);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.IncrementDate = null;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                increment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                increment.Archived = true;
                                dal.Delete(increment);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.IncrementDate = null;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                            dal.CommitTransaction();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Increment successfully,Please See the system Administrator");
            }
        }

        private void SelectiveIncrementView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                //Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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

        private void PopulateView(IList<Increment> increments)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Increment increment in increments)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = increment.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = increment.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = increment.Employee.Title.Description + " " + increment.Employee.Surname + " " + increment.Employee.FirstName + " " + increment.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = increment.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = increment.GradeCategory.Description;
                    //grid.Rows[ctr].Cells["gridZone"].Value = increment.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = increment.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = increment.Employee.Unit.Description;
                    //grid.Rows[ctr].Cells["gridIncrementType"].Value = increment.IncrementType;
                    grid.Rows[ctr].Cells["gridIncrementDate"].Value = increment.IncrementDate;
                    //grid.Rows[ctr].Cells["gridIsPercentage"].Value = increment.IsPercentage;
                    //grid.Rows[ctr].Cells["gridIncrease"].Value = increment.Increase;
                    //grid.Rows[ctr].Cells["gridReason"].Value = increment.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = increment.User.ID;
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
                        Property = "IncrementView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "IncrementView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "IncrementView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "IncrementView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "IncrementView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "IncrementView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "IncrementView.IncrementType",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = "Reverse",
                    CriteriaOperator = CriteriaOperator.And
                });
                increments = dal.GetByCriteria<Increment>(query);
                PopulateView(increments);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                increment = new Increment();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                //datePickerIncrementDate.ResetText();
                datePickerIncrementDate.Checked = false;
                txtStaffID.Clear();
                txtSurname.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void datePickerIncrementDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.IncrementDate.Value.Date == datePickerIncrementDate.Value.Date && increment.IncrementType == "Reverse")
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
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
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
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
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.Surname.Trim().ToLower().StartsWith(txtSurname.Text.Trim().ToLower()))
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
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
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.Unit.ID == units[cboUnit.SelectedIndex].ID)
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
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
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.GradeCategory.ID == gradeCategories[cboGradeCategory.SelectedIndex].ID)
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
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
                foundIncrements.Clear();
                increments = dal.GetAll<Increment>();
                foreach (Increment increment in increments)
                {
                    if (increment.Employee.Grade.ID == employeeGrades[cboGrade.SelectedIndex].ID)
                    {
                        foundIncrements.Add(increment);
                    }
                }
                PopulateView(foundIncrements);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void cboZone_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboZone.Items.Clear();
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

        void cboGradeCategory_DropDown(object sender, EventArgs e)
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

        private void cboDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboDepartment.Items.Clear();
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

        private void cboDepartment_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cboDepartment.Text != string.Empty)
                {
                    foundIncrements.Clear();
                    increments = dal.GetAll<Increment>();
                    foreach (Increment increment in increments)
                    {
                        if (increment.Employee.Department.ID == departments[cboDepartment.SelectedIndex].ID)
                        {
                            foundIncrements.Add(increment);
                        }
                    }
                    PopulateView(foundIncrements);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboZone_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cboZone.Text != string.Empty)
                {
                    foundIncrements.Clear();
                    increments = dal.GetAll<Increment>();
                    foreach (Increment increment in increments)
                    {
                        if (increment.Employee.Zone.ID == zones[cboZone.SelectedIndex].ID)
                        {
                            foundIncrements.Add(increment);
                        }
                    }
                    PopulateView(foundIncrements);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboGradeCategory_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if (cboGradeCategory.Text != string.Empty)
                {
                    foundIncrements.Clear();
                    increments = dal.GetAll<Increment>();
                    foreach (Increment increment in increments)
                    {
                        if (increment.Employee.GradeCategory.ID == gradeCategories[cboGradeCategory.SelectedIndex].ID)
                        {
                            foundIncrements.Add(increment);
                        }
                    }
                    PopulateView(foundIncrements);
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
