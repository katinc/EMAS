using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.StaffInformation
{
    public partial class NewVacancy : Form
    {
        private IDAL dal;
        private EmployeeGrade employeeGrade;
        private GradeCategory gradeCategory;       
        private Vacancy vacancy;
        private bool editMode;
        private IList<EmployeeGrade> employeeGrades;
        private IList<Department> departments;
        private IList<GradeCategory> gradeCategories;
        private IList<AppointmentType> appointmentTypes;
        private string descriptionsToDelete;

        public NewVacancy()
        {
            try
            {
                InitializeComponent();
                this.editMode = false;
                this.dal = new DAL();
                this.vacancy = new Vacancy();
                this.employeeGrade = new EmployeeGrade();
                this.gradeCategory = new GradeCategory();
                this.employeeGrades = new List<EmployeeGrade>();
                this.gradeCategories=new List<GradeCategory>();
                this.departments = new List<Department>();
                this.appointmentTypes=new List<AppointmentType>();
                this.employeeGrades=dal.GetAll<EmployeeGrade>();
                this.gradeCategories = dal.GetAll<GradeCategory>();
                this.departments = dal.GetAll<Department>();
                this.appointmentTypes = dal.GetAll<AppointmentType>();
                this.descriptionsToDelete = string.Empty;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void gradeCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeCategoryComboBox.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    gradeCategoryComboBox.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void faxNoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (faxNoTextBox.Text.Length > 0)
                        {
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void contactNoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
                {
                    if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                    {
                        if (contactNoTextBox.Text.Length > 0)
                        {
                            contactNoTextBox.Text = contactNoTextBox.Text.Replace(e.KeyValue.ToString(), "");
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetGradeItems()
        {
            try
            {
                gradeComboBox.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (EmployeeGrade grade in employeeGrades)
                {
                    if (grade.GradeCategory.Code == gradeCategories[gradeCategoryComboBox.SelectedIndex].Code)
                    {
                        gradeComboBox.Items.Add(grade.Grade);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetDepartmentItems()
        {
            try
            {
                departmentComboBox.Items.Clear();
                departments = dal.GetAll<Department>();
                foreach (Department department in departments)
                {
                    departmentComboBox.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void EditVacancy(Vacancy vacancy)
        {
            try
            {
                editMode = true;
                label13.Text = "Edit Vacancy";
                this.vacancy = vacancy;
                gradeCategoryComboBox_DropDown(this, EventArgs.Empty);               
                departmentComboBox_DropDown(this, EventArgs.Empty);
                appointmentTypeComboTos_DropDown(this,EventArgs.Empty);

                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = vacancy.Grade.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    gradeCategoryComboBox.Text = employeeGrade.GradeCategory.Description;
                }

                gradeCategoryComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                gradeComboBox.Text = vacancy.Grade.Grade;
                appointmentTypeComboTos.Text = vacancy.AppointmentType.Description;
                departmentComboBox.Text = vacancy.Department.Description;
                departmentComboBox.SelectedIndex = departments.IndexOf(vacancy.Department);
                emailTextBox.Text = vacancy.Email;
                postalAddressTextBox.Text = vacancy.PostalAddress;
                deadLineDatePicker.Text = vacancy.DeadLine.ToString();
                reasonForVacancyTextBox.Text = vacancy.VacancyDueTo;
                statusTextBox.Text = vacancy.Status.ToString();
                contactNoTextBox.Text = vacancy.ContactNos;
                faxNoTextBox.Text = vacancy.FaxNo;

                int ctr = 0;
                descriptionGrid.Rows.Clear();

                foreach (string item in vacancy.JobDescription)
                {
                    descriptionGrid.Rows.Add(1);
                    descriptionGrid.Rows[ctr].Cells["descriptionGridDescription"].Value = item;
                    ctr++;
                }
                ctr = 0;
                requirementsGrid.Rows.Clear();
                foreach (string item in vacancy.JobRequirements)
                {
                    requirementsGrid.Rows.Add(1);
                    requirementsGrid.Rows[ctr].Cells["requirementsGridRequirements"].Value = item;
                    ctr++;
                }

                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != vacancy.UserID)
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


        void departmentComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                GetDepartmentItems();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void NewVacancy_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetDepartmentItems();
                GetGradeItems();
                statusTextBox.Text = VacancyStatus.Open.ToString();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                errorProvider.Clear();
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                appointmentTypeComboTos.Items.Clear();
                appointmentTypeComboTos.Text = string.Empty;
                descriptionGrid.Rows.Clear();
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                datePicker.ResetText();
                requirementsGrid.Rows.Clear();
                emailTextBox.Clear();
                deadLineDatePicker.ResetText();
                editMode = false;
                label13.Text = "New Vacancy";
                vacancy.ID = 0;
                reasonForVacancyTextBox.Clear();
                statusTextBox.Text = "Open";
                postalAddressTextBox.Clear();
                emailTextBox.Clear();
                contactNoTextBox.Clear();
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
                    UpdateVacancyEntity();
                    if (editMode)
                    {
                        dal.Update(vacancy);
                        Clear();
                    }
                    else
                    {
                        dal.Save(vacancy);
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region UpdateVacancyEntity
        private void UpdateVacancyEntity()
        {
            try
            {
                vacancy.Grade = employeeGrades[gradeComboBox.SelectedIndex];
                if (appointmentTypeComboTos.Text.Trim() != string.Empty && appointmentTypeComboTos.Text.Trim() != null)
                {
                    vacancy.AppointmentType.ID = appointmentTypes[appointmentTypeComboTos.SelectedIndex].ID;
                    vacancy.AppointmentType.Description = appointmentTypes[appointmentTypeComboTos.SelectedIndex].Description;
                }
                else
                {
                    vacancy.AppointmentType.ID = 0;
                    vacancy.AppointmentType.Description = string.Empty;
                }
                appointmentTypeComboTos.Text = vacancy.AppointmentType.Description;
                vacancy.Department = departments[departmentComboBox.SelectedIndex];
                vacancy.Date = DateTime.Parse(datePicker.Text);
                vacancy.DeadLine = DateTime.Parse(deadLineDatePicker.Text.Trim());
                vacancy.VacancyDueTo = reasonForVacancyTextBox.Text.Trim();
                vacancy.Status = (VacancyStatus)Enum.Parse(typeof(VacancyStatus), statusTextBox.Text.Trim());
                vacancy.PostalAddress = postalAddressTextBox.Text.Trim();
                vacancy.Email = emailTextBox.Text.Trim();
                vacancy.ContactNos = contactNoTextBox.Text.Trim();
                vacancy.FaxNo = faxNoTextBox.Text.Trim();
                vacancy.UserID = GlobalData.User.ID;

                //JobRequirements
                vacancy.JobRequirements.Clear();

                foreach (DataGridViewRow row in requirementsGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        vacancy.JobRequirements.Add(row.Cells["requirementsGridRequirements"].Value.ToString());
                    }
                }
                //JobDescription
                vacancy.JobDescription.Clear();
                foreach (DataGridViewRow row in descriptionGrid.Rows)
                {

                    if (!row.IsNewRow)
                    {
                        vacancy.JobDescription.Add(row.Cells["descriptionGridDescription"].Value.ToString());
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Validation
        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();

                if (gradeCategoryComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(gradeCategoryComboBox, "Please select a grade category");
                    gradeCategoryComboBox.Focus();
                }
                else if (gradeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(gradeComboBox, "Please select a grade");
                    gradeComboBox.Focus();
                }
                else if (appointmentTypeComboTos.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(appointmentTypeComboTos, "Please select an appointment type");
                    appointmentTypeComboTos.Focus();
                }

                else if (departmentComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(departmentComboBox, "Please select a department");
                    departmentComboBox.Focus();
                }
                else if (DateTime.Parse(datePicker.Text.Trim()) > GlobalData.ServerDate)
                {
                    result = false;
                    errorProvider.SetError(datePicker, "The date the vacancy was opened cannot be greater than today");
                    datePicker.Focus();
                }
                else if (editMode == false && DateTime.Parse(deadLineDatePicker.Text) < GlobalData.ServerDate)
                {
                    result = false;
                    errorProvider.SetError(deadLineDatePicker, "The deadline for the vacancy cannot be less than today");
                    deadLineDatePicker.Focus();
                }

                else if (postalAddressTextBox.Text.Trim() == string.Empty && emailTextBox.Text.Trim() == string.Empty && contactNoTextBox.Text.Trim() == string.Empty && faxNoTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(postalAddressTextBox, "Please enter at least one mode of application");
                    postalAddressTextBox.Focus();
                }
                else if (emailTextBox.Text.Trim() != string.Empty && !Validator.EmailValidator(emailTextBox.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(emailTextBox, "Please enter valid Email Address");
                    emailTextBox.Focus();
                }
                foreach (DataGridViewRow row in descriptionGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["descriptionGridDescription"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(groupBox3, "Please enter a job description on row " + (row.Index + 1));
                        }
                        else if (row.Cells["descriptionGridDescription"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            errorProvider.SetError(groupBox3, "Please enter a job description on row " + (row.Index + 1));
                        }
                    }
                }

                foreach (DataGridViewRow row in requirementsGrid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["requirementsGridRequirements"].Value == null)
                        {
                            result = false;
                            errorProvider.SetError(groupBox3, "Please enter a job requirement on row " + (row.Index + 1));
                        }
                        else if (row.Cells["requirementsGridRequirements"].Value.ToString() == string.Empty)
                        {
                            result = false;
                            errorProvider.SetError(groupBox3, "Please enter a job requirement on row " + (row.Index + 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        #endregion

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                Vacancy_Maintenance vacancyMaintenance = new Vacancy_Maintenance(dal, this);
                vacancyMaintenance.MdiParent = this.MdiParent;
                vacancyMaintenance.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void appointmentTypeComboTos_DropDown(object sender, EventArgs e)
        {
            try
            {
                appointmentTypes = dal.GetAll<AppointmentType>();
                appointmentTypeComboTos.Items.Clear();
                appointmentTypeComboTos.Text = string.Empty;
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    appointmentTypeComboTos.Items.Add(appointmentType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = gradeCategoryComboBox.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                employeeGrades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in employeeGrades)
                {
                    gradeComboBox.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }    
        }
    }
}
