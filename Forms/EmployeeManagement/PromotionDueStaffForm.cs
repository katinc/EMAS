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
    public partial class PromotionDueStaffForm : Form
    {
        private IDAL dal;
        private IList<Employee> employees;
        private Employee employee;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;
        private Company company;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<GradeCategory> gradeCategories;
        private IList<Zone> zones;
        private IList<PromotionType> promotionTypes;
        private Promotion promotion;
        private IList<Promotion> promotions;
        private IList<Promotion> foundPromotions;
        private int ctr;
        private bool approved;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public PromotionDueStaffForm()
        {
            try
            {
                InitializeComponent();
                this.employee = new Employee();
                this.promotion = new Promotion();
                this.company = new Company();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.promotions = new List<Promotion>();
                this.foundPromotions = new List<Promotion>();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories = new List<GradeCategory>();
                this.departments = new List<Department>();
                this.units = new List<Unit>();
                this.zones = new List<Zone>();
                this.promotionTypes = new List<PromotionType>();
                this.dal = new DAL();
                this.ctr = 0;
                this.found = false;
                this.approved = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PromotionDueStaffForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnPromote.Enabled = getPermissions.CanAdd;
                    btnRemove.Enabled = getPermissions.CanDelete;
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
                        if (GlobalData.QuestionMessage("Are you sure you want to Cancel Promotion of the Staff " + "?") == DialogResult.Yes)
                        {
                            

                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                promotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                promotion.Archived = true;
                                dal.Delete(promotion);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);

                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                promotion.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                promotion.Archived = true;
                                dal.Delete(promotion);
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

        private void PopulateView(IList<Promotion> promotions)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (Promotion promotion in promotions)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = promotion.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = promotion.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = promotion.Employee.Title.Description + " " + promotion.Employee.Surname + " " + promotion.Employee.FirstName + " " + promotion.Employee.OtherName;
                    grid.Rows[ctr].Cells["gridGrade"].Value = promotion.Employee.Grade.Grade;
                    grid.Rows[ctr].Cells["gridGradeCategory"].Value = promotion.Employee.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridZone"].Value = promotion.Employee.Zone.Description;
                    grid.Rows[ctr].Cells["gridDepartment"].Value = promotion.Employee.Department.Description;
                    grid.Rows[ctr].Cells["gridUnit"].Value = promotion.Employee.Unit.Description;
                    grid.Rows[ctr].Cells["gridPromotionType"].Value = promotion.PromotionType.Description;
                    grid.Rows[ctr].Cells["gridApproved"].Value = promotion.Approved;
                    grid.Rows[ctr].Cells["gridApprovedUser"].Value = promotion.ApprovedUser;
                    grid.Rows[ctr].Cells["gridApprovedDate"].Value = promotion.ApprovedDate;
                    grid.Rows[ctr].Cells["gridApprovedTime"].Value = promotion.ApprovedTime;
                    grid.Rows[ctr].Cells["gridPromotionDate"].Value = promotion.PromotionDate;
                    grid.Rows[ctr].Cells["gridNotionalDate"].Value = promotion.NotionalDate;
                    grid.Rows[ctr].Cells["gridSubstantiveDate"].Value = promotion.SubstantiveDate;
                    grid.Rows[ctr].Cells["gridNewSalary"].Value = promotion.NewSalary;
                    grid.Rows[ctr].Cells["gridNewGradeCategory"].Value = promotion.GradeCategory.Description;
                    grid.Rows[ctr].Cells["gridNewGrade"].Value = promotion.Grade.Grade;
                    grid.Rows[ctr].Cells["gridReason"].Value = promotion.Reason;
                    grid.Rows[ctr].Cells["gridUserID"].Value = promotion.User.ID;
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
                        Property = "PromotionView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerPromotionDate.Checked == true && datePickerPromotionDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerPromotionDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerNotionalDate.Checked == true && datePickerNotionalDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.NotionalDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerNotionalDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (datePickerSubstantiveDate.Checked == true && datePickerSubstantiveDate.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.SubstantiveDate",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = datePickerNotionalDate.Value,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtNewBasicSalary.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.NewSalary",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtNewBasicSalary.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtSurname.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Surname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtSurname.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtFirstName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Firstname",
                        CriterionOperator = CriterionOperator.Like,
                        Value = txtFirstName.Text.Trim() + '%',
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboPromotionType.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.PromotionType",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboPromotionType.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.GradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Grade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboNewGradeCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.NewGradeCategory",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboNewGradeCategory.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboNewGrade.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.NewGrade",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = cboNewGrade.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboApproved.Text.Trim() != string.Empty && cboApproved.Text.ToLower().Trim() != "all")
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "PromotionView.Approved",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = approved,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "PromotionView.Archived",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.None
                });
                promotions = dal.GetByCriteria<Promotion>(query);
                PopulateView(promotions);
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
                promotion = new Promotion();
                grid.Rows.Clear();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboNewGradeCategory.Items.Clear();
                cboNewGradeCategory.Text = string.Empty;
                cboNewGrade.Items.Clear();
                cboNewGrade.Text = string.Empty;
                datePickerPromotionDate.ResetText();
                datePickerPromotionDate.Checked = false;
                datePickerNotionalDate.ResetText();
                datePickerNotionalDate.Checked = false;
                datePickerSubstantiveDate.ResetText();
                datePickerSubstantiveDate.Checked = false;
                cboApproved.Items.Clear();
                cboApproved.Text = string.Empty;
                cboApproved_DropDown(this, EventArgs.Empty);
                cboApproved.Text = "No";
                approved = false;
                txtStaffID.Clear();
                txtSurname.Clear();
                txtFirstName.Clear();
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
                    if(company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    
                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        foundPromotions.Clear();
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "PromotionView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        promotions = dal.GetByCriteria<Promotion>(query);
                        if (promotions.Count > 0)
                        {
                            foreach (Promotion promotion in promotions)
                            {
                                if (promotion.Employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    foundPromotions.Add(promotion);
                                }
                            }
                            PopulateView(foundPromotions);
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

        private bool ValidateFields()
        {
            bool result = false;
            try
            {
                errorProvider.Clear();
                int ctr = 0;
                if (datePickerApprovedDate.Checked == false || datePickerApprovedDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(datePickerApprovedDate, "Please select the Approved Date");
                    datePickerApprovedDate.Focus();
                }
                else if (datePickerApprovedDate.Checked && !Validator.DateRangeValidator(datePickerApprovedDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    errorProvider.SetError(datePickerApprovedDate, "Please Approved Date cannot be greater than Today");
                    datePickerApprovedDate.Focus();
                }
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (grid.Rows[ctr].Cells["gridSelect"].Value == null)
                    {
                        grid.Rows[ctr].Cells["gridSelect"].Value = false;
                    }
                    if (bool.Parse(grid.Rows[ctr].Cells["gridSelect"].Value.ToString()) == true)
                    {
                        result = true;
                        break;
                    }
                    ctr++;
                }
                if (result == false)
                {
                    MessageBox.Show("Select at least one row");
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnPromote_Click(object sender, EventArgs e)
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
                            promotion = dal.GetByID<Promotion>(int.Parse(grid.Rows[ctr].Cells["gridID"].Value.ToString()));
                            if (promotion.ID != 0)
                            {
                                employee.StaffID = grid.Rows[ctr].Cells["gridStaffID"].Value.ToString().Trim();
                                employee = dal.LazyLoadByStaffID<Employee>(employee);
                                if (employee.ID != 0)
                                {
                                    //Update Employee Records
                                    employee.CurrentPromotionDate = promotion.PromotionDate;
                                    employee.GradeDate = promotion.PromotionDate;
                                    employee.Grade.ID = promotion.Grade.ID;
                                    employee.GradeCategory.ID = promotion.GradeCategory.ID;
                                    employee.PromotionType.ID = promotion.PromotionType.ID;
                                    employee.PromotionType = promotion.PromotionType;
                                    employee.Step.ID = promotion.NewStepId;
                                    employee.Band.ID = promotion.Band.ID;
                                    employee.OldBasicSalary = employee.BasicSalary;
                                    employee.BasicSalary = promotion.NewSalary;
                                    employee.UpgradeDate = promotion.PromotionDate;
                                    employee.DOCA = promotion.PromotionDate;
                                    dal.Update(employee);
                                    //Update Promotion
                                    promotion.Approved = true;
                                    promotion.ApprovedDate = datePickerApprovedDate.Value.Date;
                                    promotion.ApprovedTime = datePickerApprovedDate.Value;
                                    promotion.ApprovedUser = GlobalData.User.Name;
                                    promotion.ApprovedUserStaffID = GlobalData.User.StaffID;
                                    dal.Update(promotion);
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
                MessageBox.Show("ERROR:Could Not Save Successfully");
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

        private void cboPromotionType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboPromotionType.Items.Clear();
                promotionTypes = dal.GetAll<PromotionType>();
                foreach (PromotionType promotionType in promotionTypes)
                {
                    cboPromotionType.Items.Add(promotionType.Description);
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

        private void cboNewGradeCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboNewGradeCategory.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    cboNewGradeCategory.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboNewGradeCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboNewGrade.Items.Clear();
                cboNewGrade.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboNewGradeCategory.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    cboNewGrade.Items.Add(employeeGrade.Grade);
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
