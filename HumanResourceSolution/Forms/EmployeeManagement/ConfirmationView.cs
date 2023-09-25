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

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ConfirmationView : Form
    {

        private IDAL dal;
        private ConfirmationForm confirmationForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private Confirmation confirmation;
        private IList<Confirmation> confirmations;
        private IList<Confirmation> foundConfirmations;
        private Company company;
        private int ctr;
        private bool found;

        public ConfirmationView(ConfirmationForm confirmationForm)
        {
            try
            {
                InitializeComponent();
                this.confirmationForm = confirmationForm;
                this.employee = new Employee();
                this.confirmation = new Confirmation();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.confirmations = new List<Confirmation>();
                this.foundConfirmations = new List<Confirmation>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.company = new Company();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();       
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public ConfirmationView()
        {
            try
            {
                InitializeComponent();
                this.confirmationForm = new ConfirmationForm() ;
                this.employee = new Employee();
                this.confirmation = new Confirmation();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.confirmations = new List<Confirmation>();
                this.foundConfirmations = new List<Confirmation>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.company = new Company();
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
                        if (bool.Parse(grid.CurrentRow.Cells["gridConfirmed"].Value.ToString()) == false)
                        {
                            confirmationForm.EditConfirmation(grid.CurrentRow);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The Staff is already Confirmed, Please Use the New Confirmation Form");
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel the Confirmation of the Staff " + "?") == DialogResult.Yes)
                        {
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                confirmation.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                confirmation.Archived = true;
                                dal.Delete(confirmation);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentConfirmationDate = null;
                                employee.Confirmed = false;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                confirmation.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                confirmation.Archived = true;
                                dal.Delete(confirmation);
                                employee = dal.GetByID<Employee>(grid.CurrentRow.Cells["gridStaffID"].Value);
                                employee.CurrentConfirmationDate = null;
                                employee.Confirmed = false;
                                dal.Update(employee);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                dal.CommitTransaction();

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
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Confirmation successfully,Please See the system Administrator");
            }
        }

        private void ConfirmationView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
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

        private void PopulateView(IList<Confirmation> confirmations)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Confirmation confirmation in confirmations)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = confirmation.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = confirmation.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = confirmation.Employee.Title.Description + " " + confirmation.Employee.Surname + " " + confirmation.Employee.FirstName + " " + confirmation.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = confirmation.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = confirmation.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = confirmation.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = confirmation.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridConfirmed"].Value = confirmation.Confirmed;
                    grid.Rows[ctr].Cells["gridConfirmationDate"].Value = confirmation.ConfirmationDate;
                    grid.Rows[ctr].Cells["gridReason"].Value = confirmation.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = confirmation.User.ID;
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
                        Property = "ConfirmationView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboDepartment.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.Department",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = departments[cboDepartment.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUnit.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.Unit",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = units[cboUnit.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = gradeCategories[cboGradeCategory.SelectedIndex].Description,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = employeeGrades[cboGrade.SelectedIndex].Grade,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.FirstName",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (confirmationDatePicker.Checked == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "ConfirmationView.ConfirmationDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = confirmationDatePicker.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                confirmations = dal.GetByCriteria<Confirmation>(query);
                PopulateView(confirmations);
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
                confirmation = new Confirmation();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboUnit.Items.Clear();
                txtStaffID.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
                confirmationDatePicker.Checked=false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                        foundConfirmations.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "ConfirmationView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        confirmations = dal.GetByCriteria<Confirmation>(query);
                        if (confirmations.Count > 0)
                        {
                            foreach (Confirmation confirmation in this.confirmations)
                            {
                                if (confirmation.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundConfirmations.Add(confirmation);
                                }
                            }
                            PopulateView(foundConfirmations);
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
