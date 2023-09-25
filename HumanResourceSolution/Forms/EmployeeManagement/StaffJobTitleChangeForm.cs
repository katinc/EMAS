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
    public partial class StaffJobTitleChangeForm : Form
    {
        private StaffJobTitleChange staffJobTitleChange;
        private IList<Employee> employees;
        private IList<JobTitle> jobTitles;
        private IDAL dal;
        private bool editMode;
        private int staffJobTitleChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public StaffJobTitleChangeForm()
        {
            try
            {
                InitializeComponent();
                this.staffJobTitleChange = new StaffJobTitleChange();
                this.employees = new List<Employee>();
                this.jobTitles = new List<JobTitle>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode=0;
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
                else if (cboJobTitleTo.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboJobTitleTo, "Please Select New JobTitle");
                    cboJobTitleTo.Focus();
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
                            employee.StaffID = staffJobTitleChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.JobTitle.ID = staffJobTitleChange.JobTitleTo.ID;
                                employee.JobTitleDate = staffJobTitleChange.Date.Value.Date;
                                dal.Update(employee);
                                dal.Update(staffJobTitleChange);
                                Clear();
                            }
                        }
                        else
                        {
                            employee.StaffID = staffJobTitleChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.JobTitle.ID = staffJobTitleChange.JobTitleTo.ID;
                                employee.JobTitleDate = staffJobTitleChange.Date.Value.Date;
                                dal.Update(employee);
                                dal.Save(staffJobTitleChange);
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
            staffJobTitleChange.ID = staffJobTitleChangeID;
            staffJobTitleChange.Employee.StaffID = staffIDtxt.Text.Trim();
            staffJobTitleChange.StaffName = nametxt.Text.Trim();
            staffJobTitleChange.Employee.ID = staffCode;
            staffJobTitleChange.Date = dateEntry.Value;
            staffJobTitleChange.JobTitleTo.ID = jobTitles[cboJobTitleTo.SelectedIndex].ID;
            staffJobTitleChange.JobTitleFrom.ID = jobTitles[txtJobTitle.SelectedIndex].ID;
            staffJobTitleChange.Reason = reasontxt.Text.Trim();
            staffJobTitleChange.Description = "JobTitle Changed From " + jobTitles[txtJobTitle.SelectedIndex].Description + " To " + jobTitles[cboJobTitleTo.SelectedIndex].Description;
            staffJobTitleChange.User.ID = GlobalData.User.ID;
            staffJobTitleChange.Approved = true;
            staffJobTitleChange.ApprovedUser = GlobalData.User.Name;
            staffJobTitleChange.ApprovedUserStaffID = GlobalData.User.StaffID;
            staffJobTitleChange.ApprovedDate = DateTime.Now.Date;
            staffJobTitleChange.ApprovedTime = DateTime.Now; 
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
                cboJobTitleTo.Items.Clear();
                cboJobTitleTo.Text = string.Empty;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffJobTitleChangeID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff JobTitle";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtJobTitleDate.Clear();
                txtJobTitle.Items.Clear();
                txtJobTitle.Text = string.Empty;
                savebtn.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void StaffJobTitleChangeForm_Load(object sender, EventArgs e)
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
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
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
                            if (employee.JobTitleDate == null)
                            {
                                txtJobTitleDate.Text = string.Empty;
                            }
                            else
                            {
                                txtJobTitleDate.Text = employee.JobTitleDate.Value.Date.ToString("dd/MM/yyyy");
                            }
                            txtJobTitle_DropDown(this,EventArgs.Empty);
                            txtJobTitle.Text = employee.JobTitle.Description;
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
                            searchGrid.Height = searchGrid.RowCount * 25;
                        }
                        else
                        {
                            searchGrid.Height = searchGrid.RowCount * 21;
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

        private void cboJobTitleTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboJobTitleTo.Items.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    cboJobTitleTo.Items.Add(jobTitle.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditStaffJobTitleChange(StaffJobTitleChange staffJobTitleChange)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = staffJobTitleChange.StaffName; ;
                staffIDtxt.Text = staffJobTitleChange.Employee.StaffID;
                staffCode = staffJobTitleChange.Employee.ID;
                gendertxt.Text = staffJobTitleChange.Employee.Gender;
                agetxt.Text = staffJobTitleChange.Employee.Age;
                staffJobTitleChangeID = staffJobTitleChange.ID;
                departmentTextBox.Text = staffJobTitleChange.Employee.Department.Description;
                unitTextBox.Text = staffJobTitleChange.Employee.Unit.Description;
                gradeCategoryTextBox.Text = staffJobTitleChange.Employee.GradeCategory.Description;
                gradeTextBox.Text = staffJobTitleChange.Employee.Grade.Grade;
                specialtyTextBox.Text = staffJobTitleChange.Employee.Specialty.Description;
                if (staffJobTitleChange.Employee.EmploymentDate == null)
                {
                    txtEmploymentDate.Text = string.Empty;
                }
                else
                {
                    txtEmploymentDate.Text = staffJobTitleChange.Employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                }
                if (staffJobTitleChange.Employee.JobTitleDate == null)
                {
                    txtJobTitleDate.Text = string.Empty;
                }
                else
                {
                    txtJobTitleDate.Text = staffJobTitleChange.Employee.JobTitleDate.Value.Date.ToString("dd/MM/yyyy");
                }
                txtJobTitle_DropDown(this, EventArgs.Empty);
                txtJobTitle.Text = staffJobTitleChange.Employee.JobTitle.Description;

                //Form Details
                dateEntry.Checked = true;
                dateEntry.Value = staffJobTitleChange.Date.Value.Date;
                reasontxt.Text = staffJobTitleChange.Reason;
                cboJobTitleTo_DropDown(this, EventArgs.Empty);
                cboJobTitleTo.Text = staffJobTitleChange.JobTitleTo.Description;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View Staff JobTitle Changes";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffJobTitleChange.User.ID)
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
                StaffJobTitleChangeView staffJobTitleChangeView = new StaffJobTitleChangeView(dal, this);
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

        private void txtJobTitle_DropDown(object sender, EventArgs e)
        {
            try
            {
                txtJobTitle.Items.Clear();
                jobTitles = dal.GetAll<JobTitle>();
                foreach (JobTitle jobTitle in jobTitles)
                {
                    txtJobTitle.Items.Add(jobTitle.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
