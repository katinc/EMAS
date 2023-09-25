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
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.Employment;
using eMAS.Forms.StaffManagement;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Validation;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;

namespace eMAS.Forms.StaffManagement
{
    public partial class NewPromotion : Form
    {
        private IList<Employee> employees;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> grades;
        private IList<PromotionType> promotionTypes;
        private IList<Step> steps;
        private IList<Band> bands;
        private IList<StaffSalaryHistory> staffSalaryHistories;
        private Employee employee;
        private Promotion promotion;
        private Company company;
        private DAL dal;
        private int ctr;
        private int promotionID;
        private int staffCode;
        private bool editMode;

        public NewPromotion()
        {
            try
            {
                InitializeComponent();
                this.promotion = new Promotion();
                this.employee = new Employee();
                this.company = new Company();
                this.dal = new DAL();
                this.staffSalaryHistories=new List<StaffSalaryHistory>();
                this.employees = new List<Employee>();
                this.gradeCategories = new List<GradeCategory>();
                this.steps = new List<Step>();
                this.bands = new List<Band>();
                this.promotionTypes = new List<PromotionType>();
                this.grades = new List<EmployeeGrade>();
                this.promotionID = 0;
                this.staffCode = 0;
                this.ctr = 0;
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

        private void NewPromotion_Load(object sender, EventArgs e)
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
                datePickerEffectiveDate.Checked = false;
                datePickerNotional.ResetText();
                datePickerNotional.Checked = false;
                datePickerSubstantive.ResetText();
                datePickerSubstantive.Checked = false;
                cboPromotionType.Items.Clear();
                cboPromotionType.Text = string.Empty;
                cboGradeCategory.Items.Clear();
                cboGradeCategory.Text = string.Empty;
                cboGrade.Items.Clear();
                cboGrade.Text = string.Empty;
                cboBand.Items.Clear();
                cboBand.Text = string.Empty;
                cboStep.Items.Clear();
                cboStep.Text = string.Empty;
                txtReason.Text = string.Empty;
                txtNewSalary.Text = "0";
                txtBasicSalary.Text = "0";
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
                txtDOB.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                gradeOnFirstAppointmentTextBox.Clear();
                dofaTextBox.Clear();
                txtPromotionDate.Clear();
                pictureBox.Image = null;
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
                            if (employee.DOB == null)
                            {
                                txtDOB.Text = string.Empty;
                            }
                            else
                            {
                                txtDOB.Text = employee.DOB.Value.Date.ToString("dd/MM/yyyy");
                            }
                            
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            datePickerEffectiveDate.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            gradeOnFirstAppointmentTextBox.Text = employee.GradeOnFirstAppointment.Grade;
                            if (employee.DOFA == null)
                            {
                                dofaTextBox.Text = string.Empty;
                            }
                            else
                            {
                                dofaTextBox.Text = employee.DOFA.Value.Date.ToString("dd/MM/yyyy");
                            }
                            if (employee.CurrentPromotionDate == null)
                            {
                                txtPromotionDate.Text = string.Empty;
                            }
                            else
                            {
                                txtPromotionDate.Text = employee.CurrentPromotionDate.Value.Date.ToString("dd/MM/yyyy");
                            }
                            txtNewSalary.Text = employee.BasicSalary.ToString();
                            txtPromotionType.Text = employee.PromotionType.Description;
                            txtBasicSalary.Text = employee.BasicSalary.ToString();
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
                    if(employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
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
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (staffIDtxt.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employees = dal.LazyLoadCriteria<Employee>(query);
                        if (employees.Count > 0)
                        {
                            foreach (Employee employee in employees)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(staffIDtxt.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
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
                                searchGrid.Location = new Point(staffIDtxt.Location.X, staffIDtxt.Location.Y + 21);
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text + " is not Found");
                            staffIDtxt.Text = string.Empty;
                        }
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

        public void EditPromotion(DataGridViewRow row)
        {
            try
            {
                Clear();
                editMode = true;
                employee.StaffID = row.Cells["gridStaffID"].Value.ToString().Trim();
                employee = dal.LazyLoadByStaffID<Employee>(employee);
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
                txtDOB.Text = employee.DOB.ToString();
                searchGrid.Visible = false;
                groupBox1.Enabled = true;
                datePickerEffectiveDate.Select();
                departmentTextBox.Text = employee.Department.Description;
                unitTextBox.Text = employee.Unit.Description;
                gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                gradeTextBox.Text = employee.Grade.Grade;
                gradeOnFirstAppointmentTextBox.Text = employee.Specialty.Description;
                txtPromotionDate.Text = employee.CurrentPromotionDate.ToString().Trim();
                
                promotionID = int.Parse(row.Cells["gridID"].Value.ToString().Trim());
                cboPromotionType_DropDown(this, EventArgs.Empty);
                cboPromotionType.Text = row.Cells["gridPromotionType"].Value.ToString().Trim();
                cboGradeCategory_DropDown(this, EventArgs.Empty);
                cboGradeCategory.Text = row.Cells["gridGradeCategory"].Value.ToString().Trim();
                cboGradeCategory_SelectionChangeCommitted(this,EventArgs.Empty);
                cboGrade.Text = row.Cells["gridGrade"].Value.ToString().Trim();
                if (row.Cells["gridStep"].Value != null)
                {
                    cboStep_DropDown(this, EventArgs.Empty);
                    cboStep.Text = row.Cells["gridStep"].Value.ToString().Trim();
                }
                if (row.Cells["gridBand"].Value != null)
                {
                    cboBand_DropDown(this, EventArgs.Empty);
                    cboBand.Text = row.Cells["gridBand"].Value.ToString().Trim();
                }
                
                datePickerEffectiveDate.Text = row.Cells["gridPromotionDate"].Value.ToString().Trim();
                datePickerNotional.Text = row.Cells["gridNotionalDate"].Value.ToString().Trim();
                datePickerSubstantive.Text = row.Cells["gridSubstantiveDate"].Value.ToString().Trim();
                txtNewSalary.Text = row.Cells["gridNewSalary"].Value.ToString().Trim();
                txtReason.Text = row.Cells["gridReason"].Value.ToString();
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != int.Parse(row.Cells["gridUserID"].Value.ToString()))
                {
                    btnSave.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    UpdatePromotionsEntity();
                    if (editMode)
                    {
                        dal.Update(promotion);
                    }
                    else
                    {
                        dal.Save(promotion);
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not Saved Successfully,See the System Administrator");
            }
        }

        private void UpdatePromotionsEntity()
        {
            try
            {
                promotion.ID = promotionID;
                promotion.Employee.StaffID = staffIDtxt.Text.Trim();
                promotion.Employee.ID = staffCode;
                promotion.PromotionType.ID = promotionTypes[cboPromotionType.SelectedIndex].ID;
                promotion.GradeCategory.ID=gradeCategories[cboGradeCategory.SelectedIndex].ID;
                promotion.Grade.ID = grades[cboGrade.SelectedIndex].ID;
                promotion.PromotionDate = datePickerEffectiveDate.Value.Date;
                promotion.NotionalDate = datePickerNotional.Value.Date;
                promotion.SubstantiveDate = datePickerSubstantive.Value.Date;
                if (cboStep.Text.Trim() == string.Empty)
                {
                    promotion.Step.ID = 0;
                }
                else
                {
                    promotion.Step.ID = steps[cboStep.SelectedIndex].ID;
                }
                if (cboBand.Text.Trim() == string.Empty)
                {
                    promotion.Band.ID = 0;
                }
                else
                {
                    promotion.Band.ID = bands[cboBand.SelectedIndex].ID;
                }
                promotion.NewSalary = decimal.Parse(txtNewSalary.Text.Trim());
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
            company = dal.LazyLoad<Company>()[0];
            try
            {
                if (datePickerEffectiveDate.Checked == false)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please select the Effective Date");
                    datePickerEffectiveDate.Focus();
                }
                else if (datePickerEffectiveDate.Checked && !Validator.DateRangeValidator(datePickerEffectiveDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please Promotion Date cannot be greater than Today");
                    datePickerEffectiveDate.Focus();
                }
                if (datePickerNotional.Checked && !Validator.DateRangeValidator(datePickerNotional.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerNotional, "Please Notional Date cannot be greater than Today");
                    datePickerNotional.Focus();
                }
                if (datePickerSubstantive.Checked && !Validator.DateRangeValidator(datePickerSubstantive.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerSubstantive, "Please Substantive Date cannot be greater than Today");
                    datePickerSubstantive.Focus();
                }
                if (cboGradeCategory.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGradeCategory, "Please select the Grade Category");
                    cboGradeCategory.Focus();
                }
                if(cboGradeCategory.Text.Trim() != string.Empty && cboGrade.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGrade, "Please select the Grade");
                    cboGrade.Focus();
                }
                if (company.IsSalaryStructure == true && cboStep.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboStep, "Please select the Grade");
                    cboStep.Focus();
                }
                if (company.IsSalaryStructure == true && cboBand.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboBand, "Please select the Grade");
                    cboBand.Focus();
                }
                if (!Validator.DecimalValidator(txtNewSalary.Text.Trim()))
                {
                    result = false;
                    staffErrorProvider.SetError(txtNewSalary, "Please Salary must be Decimal");
                    txtNewSalary.Focus();
                }
                else if (decimal.Parse(txtNewSalary.Text.Trim()) <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(txtNewSalary, "Please Salary cannot be zero");
                    txtNewSalary.Focus();
                }
                if (decimal.Parse(txtNewSalary.Text.Trim()) < decimal.Parse(txtBasicSalary.Text.ToString()))
                {
                    result = false;
                    staffErrorProvider.SetError(txtNewSalary, "Please New Salary cannot be greater than Basic Salary");
                    txtNewSalary.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                PromotionView form = new PromotionView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboStep_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboStep.Items.Clear();
                steps = dal.GetAll<Step>();
                foreach (Step step in steps)
                {
                    cboStep.Items.Add(step.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboBand_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboBand.Items.Clear();
                bands = dal.GetAll<Band>();
                foreach (Band band in bands)
                {
                    cboBand.Items.Add(band.Description);
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

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (staffIDtxt.Text.Trim() != string.Empty)
                {
                    employee.StaffID = staffIDtxt.Text.Trim();
                    employee = dal.ShowImageByStaffID<Employee>(employee);
                    if (employee.ID != 0)
                    {
                        if (employee.Photo != null)
                        {
                            pictureBox.Image = employee.Photo;
                        }
                        else
                        {
                            MessageBox.Show("Image is not uploaded for the Staff");
                        }
                    }
                    else
                    {
                        MessageBox.Show("StaffID Not Found");
                    }

                }
                else
                {
                    MessageBox.Show("StaffID is Empty,Please Enter the StaffID");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
