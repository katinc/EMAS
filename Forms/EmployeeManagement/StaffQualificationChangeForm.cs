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
    public partial class StaffQualificationChangeForm : Form
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

        public StaffQualificationChangeForm()
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
                            Property = "StaffPersonalInfoView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = staffIDtxt.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoView.Confirmed",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = true,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employees = dal.GetByCriteria<Employee>(query);
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

        private void Clear()
        {
            try
            {
                editMode = false;
                dateEntry.Value = DateTime.Now.Date;
                dateEntry.Checked = false;
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
                cboOldQualification.DataSource = null;
                cboNewQualification.DataSource = null;
                cboNewQualification.Items.Clear();
                cboOldQualification.Items.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
                            cboOldQualification_DropDown(this, EventArgs.Empty);
                            cboOldQualification.Text = employee.QualificationType.Description;

                            txtStatus_DropDown(this, EventArgs.Empty);
                            txtStatus.Text = employee.StaffStatus.Description;

                            dateEntry.Enabled = true;
                            cboNewQualification.Enabled = true;
                            reasontxt.Enabled = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboOldQualification_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOldQualification.DataSource = null;
                cboOldQualification.Items.Clear();

                var qualifications = GlobalData._context.QualificationViews.Where(u => u.Archived != true).ToList();

                if (qualifications.Count() > 0)
                {
                    cboOldQualification.DataSource = qualifications;
                    cboOldQualification.ValueMember = "ID";
                    cboOldQualification.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

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

        private void StaffQualificationChangeForm_Load(object sender, EventArgs e)
        {
            try
            {
                dateEntry.Enabled = false;
                cboNewQualification.Enabled = false;
                cboOldQualification.Enabled = false;
                reasontxt.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboNewQualification_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboNewQualification.DataSource = null;
                cboNewQualification.Items.Clear();

                var qualifications = GlobalData._context.QualificationViews.Where(u => u.Archived != true).ToList();

                if (qualifications.Count() > 0)
                {
                    cboNewQualification.DataSource = qualifications;
                    cboNewQualification.ValueMember = "ID";
                    cboNewQualification.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            Clear();
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
                else if (cboNewQualification.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboNewQualification, "Please Select New Qualification");
                    cboNewQualification.Focus();
                }
                else if (cboNewQualification.Text == cboOldQualification.Text)
                {
                    result = false;
                    staffErrorProvider.SetError(cboNewQualification, "New qualification cannot be the same as old");
                    cboNewQualification.Focus();
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
                            var Qualification = new DataReference.StaffQualificationChange
                            {
                                StaffCode = employee.ID,
                                StaffID = staffIDtxt.Text,
                                QualificationFrom = cboOldQualification.Text,
                                QualificationTo = cboNewQualification.Text,
                                Date = dateEntry.Value,
                                Description = "Basic Qualification Changed from " + cboOldQualification.Text + " To " + cboNewQualification.Text,
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
                            var qualificationId = GlobalData._context.QualificationViews.SingleOrDefault(u => u.Description == cboNewQualification.Text).ID;

                            var employeeData = GlobalData._context.StaffPersonalInfos.FirstOrDefault(u => u.StaffID == staffIDtxt.Text);
                            employeeData.QualificationID = qualificationId;

                            GlobalData._context.StaffQualificationChanges.InsertOnSubmit(Qualification);
                            GlobalData._context.SubmitChanges();
                            Clear();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        private void Viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                StaffQualificationChangeView staffQualificationView = new StaffQualificationChangeView();
                staffQualificationView.MdiParent = this.MdiParent;
                staffQualificationView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
