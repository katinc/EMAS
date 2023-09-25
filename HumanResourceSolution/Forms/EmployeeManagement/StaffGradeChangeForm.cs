using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class StaffGradeChangeForm : Form
    {
        private StaffGradeChange staffGradeChange;
        private IList<Employee> employees;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> grades;
        private IList<EmployeeGrade> gradess;
        private IList<JobTitle> jobTitles;
        private IDAL dal;
        private bool editMode;
        private int staffGradeChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public StaffGradeChangeForm()
        {
            try
            {
                InitializeComponent();
                this.staffGradeChange = new StaffGradeChange();
                this.employees = new List<Employee>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.gradess = new List<EmployeeGrade>();
                this.jobTitles = new List<JobTitle>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode=0;
                this.staffGradeChangeID = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void GetEmployees()
        {
            try
            {
                employees = dal.LazyLoad<Employee>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (dateEntry.Checked == false || dateEntry.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(dateEntry, "Please select the Entry Date");
                    dateEntry.Focus();
                }
                else if (dateEntry.Checked && !Validator.DateRangeValidator(dateEntry.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateEntry, "Please Entry Date cannot be greater than Today");
                    dateEntry.Focus();
                }
                else if (cboGradeCategoryTo.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGradeCategoryTo, "Please Select New Grade Category");
                    cboGradeCategoryTo.Focus();
                }
                else if (cboGradeTo.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboGradeTo, "Please Select New Grade");
                    cboGradeCategoryTo.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    if (MessageBox.Show("Are you sure you want to make changes,You cannot undo changes made?", GlobalData.Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dal.BeginTransaction();
                        this.Assign();
                        if (editMode)
                        {
                            employee.StaffID = staffGradeChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.GradeCategory.ID = staffGradeChange.GradeCategoryTo.ID;
                                employee.Grade.ID = staffGradeChange.GradeTo.ID;
                                employee.GradeDate = staffGradeChange.Date.Value.Date;
                                dal.Update(employee);
                                dal.Update(staffGradeChange);
                                Clear();
                            }
                        }
                        else
                        {
                            employee.StaffID = staffGradeChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.GradeCategory.ID = staffGradeChange.GradeCategoryTo.ID;
                                employee.Grade.ID = staffGradeChange.GradeTo.ID;
                                employee.GradeDate = staffGradeChange.Date.Value.Date;
                                dal.Update(employee);
                                dal.Save(staffGradeChange);
                                Clear();
                            }
                        }
                        dal.CommitTransaction();
                    }
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, "IDNS Human Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
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

        #region ASSINGNMENTS
        private void Assign()
        {
            staffGradeChange.ID = staffGradeChangeID;
            staffGradeChange.Employee.StaffID = staffIDtxt.Text.Trim();
            staffGradeChange.StaffName = nametxt.Text.Trim();
            staffGradeChange.Employee.ID = staffCode;
            staffGradeChange.Date = dateEntry.Value;
            staffGradeChange.GradeCategoryTo.ID = gradeCategories[cboGradeCategoryTo.SelectedIndex].ID;
            staffGradeChange.GradeCategoryFrom.ID = gradeCategories[gradeCategoryTextBox.SelectedIndex].ID;
            staffGradeChange.GradeTo.ID = grades[cboGradeTo.SelectedIndex].ID;
            staffGradeChange.GradeFrom.ID = gradess[gradeTextBox.SelectedIndex].ID;
            staffGradeChange.Reason = reasontxt.Text.Trim();
            staffGradeChange.Description = "Grade Changed From " + gradess[gradeTextBox.SelectedIndex].Grade + " To " + grades[cboGradeTo.SelectedIndex].Grade + ",";
            staffGradeChange.Description += " Grade Category Changed From " + gradeCategories[gradeCategoryTextBox.SelectedIndex].Description + " To " + gradeCategories[cboGradeCategoryTo.SelectedIndex].Description;
            staffGradeChange.User.ID = GlobalData.User.ID;
            staffGradeChange.Approved = true;
            staffGradeChange.ApprovedUser = GlobalData.User.Name;
            staffGradeChange.ApprovedUserStaffID = GlobalData.User.StaffID;
            staffGradeChange.ApprovedDate = DateTime.Now.Date;
            staffGradeChange.ApprovedTime = DateTime.Now; 
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                dateEntry.Value = DateTime.Now.Date;
                dateEntry.Checked = false;
                cboGradeCategoryTo.Items.Clear();
                cboGradeTo.Text = string.Empty;
                cboGradeTo.Items.Clear();
                cboGradeCategoryTo.Text = string.Empty;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffGradeChangeID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff Grade";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtGradeDate.Clear();
                savebtn.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void StaffGradeChangeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region Staff Operations
        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    Clear();
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
                            groupBox2.Enabled = true;
                            dateEntry.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox_DropDown(this,EventArgs.Empty);
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeCategoryTextBox_SelectionChangeCommitted(this,EventArgs.Empty);
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;

                            if (employee.EmploymentDate == null)
                            {
                                txtEmploymentDate.Text = string.Empty;
                            }
                            else
                            {
                                txtEmploymentDate.Text = employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                            }
                            if (employee.GradeDate == null)
                            {
                                txtGradeDate.Text = string.Empty;
                            }
                            else
                            {
                                txtGradeDate.Text = employee.GradeDate.Value.Date.ToString("dd/MM/yyyy");
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
                        searchGrid.Location = new Point(nametxt.Location.X, nametxt.Location.Y + 21);
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
        #endregion

        private void cboGradeCategoryTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboGradeCategoryTo.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory gradeCategory in gradeCategories)
                {
                    cboGradeCategoryTo.Items.Add(gradeCategory.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditStaffGradeChange(StaffGradeChange staffGradeChange)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = staffGradeChange.StaffName; ;
                staffIDtxt.Text = staffGradeChange.Employee.StaffID;
                staffCode = staffGradeChange.Employee.ID;
                gendertxt.Text = staffGradeChange.Employee.Gender;
                agetxt.Text = staffGradeChange.Employee.Age;
                staffGradeChangeID = staffGradeChange.ID;
                departmentTextBox.Text = staffGradeChange.Employee.Department.Description;
                unitTextBox.Text = staffGradeChange.Employee.Unit.Description;
                gradeCategoryTextBox.Text = staffGradeChange.Employee.GradeCategory.Description;
                gradeTextBox.Text = staffGradeChange.Employee.Grade.Grade;
                specialtyTextBox.Text = staffGradeChange.Employee.Specialty.Description;
                txtEmploymentDate.Text = staffGradeChange.Employee.EmploymentDate.ToString();
                txtGradeDate.Text = staffGradeChange.Employee.GradeDate.ToString();

                dateEntry.Value = staffGradeChange.Date.Value.Date;
                dateEntry.Checked = true;
                reasontxt.Text = staffGradeChange.Reason;
                cboGradeCategoryTo_DropDown(this, EventArgs.Empty);
                cboGradeCategoryTo.Text = staffGradeChange.GradeCategoryTo.Description;
                cboGradeCategoryTo_SelectionChangeCommitted(this, EventArgs.Empty);
                cboGradeTo.Text = staffGradeChange.GradeTo.Grade;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View Staff Grade Changes";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffGradeChange.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                StaffGradeChangeView staffJobTitleChangeView = new StaffGradeChangeView(dal, this);
                staffJobTitleChangeView.MdiParent = this.MdiParent;
                staffJobTitleChangeView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnView_Click(object sender, EventArgs e)
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

        private void cboGradeCategoryTo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboGradeTo.Items.Clear();
                cboGradeTo.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboGradeCategoryTo.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in grades)
                {
                    cboGradeTo.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategoryTextBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeCategoryTextBox.Items.Clear();
                gradeCategories = dal.GetAll<GradeCategory>();
                foreach (GradeCategory gradeCategory in gradeCategories)
                {
                    gradeCategoryTextBox.Items.Add(gradeCategory.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void gradeCategoryTextBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                gradeTextBox.Items.Clear();
                gradeTextBox.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "EmployeeGradeView.GradeCategory",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = gradeCategoryTextBox.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                gradess = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade employeeGrade in gradess)
                {
                    gradeTextBox.Items.Add(employeeGrade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
