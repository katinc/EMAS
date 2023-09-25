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
    public partial class SanctionView : Form
    {
        private IDAL dal;
        private SanctionForm sanctionForm;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Zone> zones;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<SanctionType> sanctionTypes;
        private Sanction sanction;
        private IList<Sanction> sanctions;
        private IList<Sanction> foundSanctions;
        private Company company;
        private int ctr;
        private bool approved;
        private bool found;

        public SanctionView(SanctionForm sanctionForm)
        {
            try
            {
                InitializeComponent();
                this.sanctionForm = sanctionForm;
                this.employee = new Employee();
                this.sanction = new Sanction();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.sanctions = new List<Sanction>();
                this.foundSanctions = new List<Sanction>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.company = new Company();
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

        public SanctionView()
        {
            try
            {
                InitializeComponent();
                this.sanctionForm = new SanctionForm();
                this.employee = new Employee();
                this.sanction = new Sanction();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.sanctions = new List<Sanction>();
                this.foundSanctions = new List<Sanction>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.dal = new DAL();
                this.company = new Company();
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

        void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null && sanctionForm.CanEdit)
                {
                    if (grid.CurrentRow != null)
                    {
                        if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                        {
                            sanctionForm.EditSanction(grid.CurrentRow);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("The Staff is already Sanctioned");
                        }
                    }
                }
                else if (!sanctionForm.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
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
                    if (bool.Parse(grid.CurrentRow.Cells["gridApproved"].Value.ToString()) == false)
                    {
                        if (grid.CurrentRow.Cells["gridID"].Value != null)
                        {
                            if (GlobalData.QuestionMessage("Are you sure you want to Cancel the Sanctions of the Staff " + "?") == DialogResult.Yes)
                            {
                                dal.BeginTransaction();
                                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                                {
                                    sanction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                    sanction.Archived = true;
                                    //dal.Delete(sanction);
                                    GlobalData.ProcessDelete(this.Name, sanction.ID);
                                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                                }
                                else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                                {
                                    sanction.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                    sanction.Archived = true;
                                    //dal.Delete(sanction);
                                    GlobalData.ProcessDelete(this.Name, sanction.ID);
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
                    else
                    {
                        MessageBox.Show("The Employee is Aleady Confirm For Sanction and so cannot be Deleted");
                    }
                    
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Cancel the Sanction successfully,Please See the system Administrator");
            }
        }

        private void SanctionView_Load(object sender, EventArgs e)
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

        private void PopulateView(IList<Sanction> sanctions)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Sanction sanction in sanctions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = sanction.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = sanction.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = sanction.Employee.Title.Description + " " + sanction.Employee.Surname + " " + sanction.Employee.FirstName + " " + sanction.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = sanction.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = sanction.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = sanction.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = sanction.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = sanction.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridSanctionType"].Value = sanction.SanctionType.Description;
                    grid.Rows[ctr].Cells["gridSanctioned"].Value = sanction.Sanctioned;
                    grid.Rows[ctr].Cells["gridApproved"].Value = sanction.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = sanction.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedUserStaffID"].Value = sanction.ApprovedUserStaffID;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = sanction.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = sanction.ApprovedTime;
                    grid.Rows[ctr].Cells["gridSanctionDate"].Value = sanction.SanctionDate;
                    grid.Rows[ctr].Cells["gridReason"].Value = sanction.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = sanction.User.ID;
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
                        Property = "SanctionView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
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
                sanction = new Sanction();
                grid.Rows.Clear();
                cboSanctionType.Items.Clear();
                cboSanctionType.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                txtStaffID.Clear();
                txtSurname.Clear();
                datePickerSanctionDate.Checked = false;
                datePickerSanctionDate.ResetText();
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
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not in the Sanction List");
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

        private void cboSanctionType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSanctionType.Items.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
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
    }
}
