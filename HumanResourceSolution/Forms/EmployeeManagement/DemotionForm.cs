using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using eMAS.All_UIs.Staff_Information_FORMS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.Employment;
using eMAS.Forms.StaffManagement;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.StaffManagement
{
    public partial class DemotionForm : Form
    {
        private IList<Employee> employees;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> grades;
        private IList<StaffSalaryHistory> staffSalaryHistories;
        private Employee employee;
        private Promotion promotion;
        private DAL dal;
        private int promotionID;
        private int staffCode;
        private bool editMode;

        public DemotionForm()
        {
            try
            {
                InitializeComponent();
                this.promotion = new Promotion();
                this.employee = new Employee();
                this.dal = new DAL();
                this.staffSalaryHistories=new List<StaffSalaryHistory>();
                this.employees = new List<Employee>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.promotionID = 0;
                this.staffCode = 0;
                this.editMode = false;
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
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade grade in grades)
                {
                    cboGrade.Items.Add(grade.Grade);
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

        private void DemotionForm_Load(object sender, EventArgs e)
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

        private void Clear()
        {
            try
            {
                promotionID = 0;
                staffErrorProvider.Clear();
                datePickerEffectiveDate.ResetText();
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                txtReason.Text = string.Empty;
                txtNewSalary.Value = 0;
                ClearStaff();
                searchGrid.Visible = false;
                editMode = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaff()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                txtDemotionDate.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            if (employee.Photo != null)
                            {
                                pictureBox.Image = employee.Photo;
                            }
                            else
                            {
                                pictureBox.Image = pictureBox.InitialImage;
                            }
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            datePickerEffectiveDate.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            txtDemotionDate.Text = employee.CurrentPromotionDate.Value.Date.ToString("dd/MM/yyyy");
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(nametxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 22);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }
                }
                else
                {
                    Clear();
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
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                        {
                            found = true;
                            searchGrid.Rows.Add(1);
                            searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                            searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                            searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
                            ctr++;
                        }
                    }
                    if (found)
                    {
                        if (searchGrid.RowCount == 2)
                        {
                            searchGrid.Height = searchGrid.RowCount * 24;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 23;
                        }
                        searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 22);
                        searchGrid.BringToFront();
                        searchGrid.Visible = true;
                    }
                    else
                    {
                        searchGrid.Visible = false;
                    }

                }
                else
                {
                    Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditDemotion(DataGridViewRow row)
        {
            try
            {
                Clear();
                employees = dal.LazyLoad<Employee>();
                foreach (Employee employee in employees)
                {
                    if (employee.StaffID.Trim() == row.Cells["gridStaffID"].Value.ToString().Trim())
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        nametxt.Text = name;
                        staffIDtxt.Text = employee.StaffID;
                        staffCode = employee.ID;
                        gendertxt.Text = employee.Gender;
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            pictureBox.Image = pictureBox.InitialImage;
                        }
                        agetxt.Text = employee.Age;
                        searchGrid.Visible = false;
                        groupBox1.Enabled = true;
                        datePickerEffectiveDate.Select();
                        departmentTextBox.Text = employee.Department.Description;
                        unitTextBox.Text = employee.Unit.Description;
                        gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                        gradeTextBox.Text = employee.Grade.Grade;
                        specialtyTextBox.Text = employee.Specialty.Description;
                        txtDemotionDate.Text = employee.CurrentPromotionDate.ToString();
                        break;
                    }
                }
                editMode = true;
                promotionID = int.Parse(row.Cells["gridID"].Value.ToString());
                cboGradeCategory_DropDown(this, EventArgs.Empty);
                cboGradeCategory.Text = row.Cells["gridGradeCategory"].Value.ToString();
                cboGradeCategory_SelectionChangeCommitted(this,EventArgs.Empty);
                cboGrade.Text = row.Cells["gridGrade"].Value.ToString();
                datePickerEffectiveDate.Text = row.Cells["gridPromotionDate"].Value.ToString();
                txtReason.Text = row.Cells["gridReason"].Value.ToString();
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                {
                    savebtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.OpenConnection();
                    dal.BeginTransaction();
                    UpdateDemotionsEntity();
                    if (editMode)
                    {
                        if (datePickerEffectiveDate.Value.Date <= DateTime.Today.Date)
                        {
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.CurrentPromotionDate = datePickerEffectiveDate.Value;
                            employee.GradeDate = datePickerEffectiveDate.Value;
                            employee.Grade.ID = promotion.Grade.ID;
                            employee.GradeCategory.ID = promotion.GradeCategory.ID;
                            employee.PromotionType = promotion.PromotionType;
                            employee.OldBasicSalary = employee.BasicSalary;
                            employee.BasicSalary = promotion.NewSalary;
                            dal.Update(employee);
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryHistoryView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffIDtxt.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(query);
                            foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                            {
                                staffSalaryH.MonthlyBasicSalary = txtNewSalary.Value;
                                staffSalaryH.Grade.ID = promotion.Grade.ID;
                                dal.Update(staffSalaryH);
                            }

                        }
                        else
                        {
                            //promotion.Action = false;
                        }
                        dal.Update(promotion);
                        dal.CommitTransaction();
                        Clear();
                    }
                    else
                    {
                        if (datePickerEffectiveDate.Value.Date <= DateTime.Today.Date)
                        {
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.CurrentPromotionDate = datePickerEffectiveDate.Value;
                            employee.GradeDate = datePickerEffectiveDate.Value;
                            employee.Grade.ID = promotion.Grade.ID;
                            employee.GradeCategory.ID = promotion.GradeCategory.ID;
                            employee.PromotionType = promotion.PromotionType;
                            employee.OldBasicSalary = employee.BasicSalary;
                            employee.BasicSalary = promotion.NewSalary;
                            dal.Update(employee);
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryHistoryView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffIDtxt.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(query);
                            foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                            {
                                staffSalaryH.MonthlyBasicSalary = txtNewSalary.Value;
                                staffSalaryH.Grade.ID = promotion.Grade.ID;
                                dal.Update(staffSalaryH);
                            }
                        }
                        else
                        {
                            //promotion.Action = false;
                        }
                        dal.Save(promotion);
                        dal.CommitTransaction();
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not saved successfully,See the system Administrator");
            }
        }

        private void UpdateDemotionsEntity()
        {
            try
            {
                promotion.ID = promotionID;
                promotion.Employee.StaffID = staffIDtxt.Text;
                promotion.Employee.ID = staffCode;
                //promotion.PromotionType = "Demoted";
                promotion.PromotionDate = datePickerEffectiveDate.Value;
                promotion.GradeCategory.ID=gradeCategories[cboGradeCategory.SelectedIndex].ID;
                Query employeeGradeQuery = new Query();
                employeeGradeQuery.Criteria.Add(new Criterion()
                {
                    Property = "CategoryID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = promotion.GradeCategory.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                grades = dal.GetByCriteria<EmployeeGrade>(employeeGradeQuery);
                foreach (EmployeeGrade grade in grades)
                {
                    promotion.Grade.ID = grade.ID;
                }
                promotion.NewSalary = txtNewSalary.Value;
                promotion.User.ID = GlobalData.User.ID;
                promotion.Reason = txtReason.Text;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (datePickerEffectiveDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please select the Effective Date");
                    datePickerEffectiveDate.Focus();
                }
                if (cboGradeCategory.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGradeCategory, "Please select the Grade Category");
                    cboGradeCategory.Focus();
                }
                else if (cboGradeCategory.Text.Trim() != string.Empty && cboGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGrade, "Please select the Grade");
                    cboGrade.Focus();
                }
                else if (txtNewSalary.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(txtNewSalary, "Please Salary cannot be zero");
                    cboGrade.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                DemotionView form = new DemotionView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
