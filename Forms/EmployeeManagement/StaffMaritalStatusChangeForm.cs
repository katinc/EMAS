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
    public partial class StaffMaritalStatusChangeForm : Form
    {
        private StaffNameChange staffNameChange;
        private IList<Employee> employees;
        private IList<StaffStatus> staffStatuses;
        private IDAL dal;
        private bool editMode;
        private int staffNameChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public StaffMaritalStatusChangeForm()
        {
            InitializeComponent();
            this.employees = new List<Employee>();
            this.staffStatuses = new List<StaffStatus>();
            this.dal = new DAL();
            this.editMode = false;
            this.company = new Company();
            this.employee = new Employee();
            this.ctr = 0;
            this.staffNameChangeID = 0;
            this.staffCode = 0;
        }

        private void StaffMaritalStatusChangeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                //groupBox2.Enabled = false;
                staffIDtxt.Select();
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
                        //staffErrorProvider.Clear();
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

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                dateEntry.Value = DateTime.Now.Date;
                dateEntry.Checked = false;
                //txtFirstNameTo.Clear();
                //txtSurnameTo.Clear();
                //txtOtherNameTo.Clear();
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffNameChangeID = 0;
                txtEmploymentDate.Text = string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text = string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff Name";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtStatus.Items.Clear();
                txtStatus.Text = string.Empty;
                savebtn.Enabled = true;
                //staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        

        private void txtStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                txtStatus.Items.Clear();
                staffStatuses = dal.GetAll<StaffStatus>();
                foreach (StaffStatus staffStatus in staffStatuses)
                {
                    txtStatus.Items.Add(staffStatus.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboOldMaritalStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOldMaritalStatus.DataSource = null;
                cboOldMaritalStatus.Items.Clear();

                var maritalStatuses = GlobalData._context.MaritalStatusGroups.ToList();

                if (maritalStatuses.Count() > 0)
                {
                    cboOldMaritalStatus.DataSource = maritalStatuses;
                    cboOldMaritalStatus.ValueMember = "ID";
                    cboOldMaritalStatus.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboNewMaritalStatus_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboNewMaritalStatus.DataSource = null;
                cboNewMaritalStatus.Items.Clear();

                var maritalStatuses = GlobalData._context.MaritalStatusGroups.ToList();

                if (maritalStatuses.Count() > 0)
                {
                    cboNewMaritalStatus.DataSource = maritalStatuses;
                    cboNewMaritalStatus.ValueMember = "ID";
                    cboNewMaritalStatus.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
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
                            txtStatus_DropDown(this, EventArgs.Empty);
                            txtStatus.Text = employee.StaffStatus.Description;

                            cboOldMaritalStatus_DropDown(this, EventArgs.Empty);
                            cboOldMaritalStatus.Text = employee.MaritalStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
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
                else if (cboNewMaritalStatus.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboNewMaritalStatus, "Please Select New Marital Status");
                    cboNewMaritalStatus.Focus();
                }
                else if (cboNewMaritalStatus.Text == cboOldMaritalStatus.Text)
                {
                    result = false;
                    staffErrorProvider.SetError(cboNewMaritalStatus, "Old Marital Status cannot be the same as new");
                    cboNewMaritalStatus.Focus();
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
                        if (editMode)
                        {

                        }
                        else
                        {
                            var MaritalStatusChange = new DataReference.StaffMaritalStatusChange
                            {
                                StaffCode = employee.ID,
                                StaffID = staffIDtxt.Text,
                                MaritalStatusFrom = cboOldMaritalStatus.Text,
                                MaritalStatusTo = cboNewMaritalStatus.Text,
                                Date = dateEntry.Value,
                                Description = "Marital Status Changed from " + cboOldMaritalStatus.Text + " To " + cboNewMaritalStatus.Text,
                                Reason = reasontxt.Text,
                                Approved = true,
                                ApprovedDate = DateTime.Now.Date,
                                ApprovedTime = DateTime.Now,
                                ApprovedUser = GlobalData.User.Name,
                                ApprovedUserStaffID = GlobalData.User.StaffID,
                                CreateTime = DateTime.Now,
                                ServerTime = DateTime.Now,
                                Archived = false,
                            };

                            var maritalStatusGroupId = GlobalData._context.MaritalStatusGroups.SingleOrDefault(u => u.Description == cboNewMaritalStatus.Text).ID;

                            var employeeData = GlobalData._context.StaffPersonalInfos.FirstOrDefault(u => u.StaffID == staffIDtxt.Text);
                            employeeData.MaritalstatusID = maritalStatusGroupId;

                            GlobalData._context.StaffMaritalStatusChanges.InsertOnSubmit(MaritalStatusChange);
                            GlobalData._context.SubmitChanges();
                            Clear();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                StaffMaritalStatusChangeView staffMaritalStatusView = new StaffMaritalStatusChangeView();
                staffMaritalStatusView.MdiParent = this.MdiParent;
                staffMaritalStatusView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
