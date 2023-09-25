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
    public partial class StaffAppointmentTypeChangeForm : Form
    {
        private StaffAppointmentTypeChange staffAppointmentTypeChange;
        private IList<Employee> employees;
        private IList<AppointmentType> appointmentTypes;
        private IDAL dal;
        private bool editMode;
        private int staffAppointmentTypeChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public StaffAppointmentTypeChangeForm()
        {
            try
            {
                InitializeComponent();
                this.staffAppointmentTypeChange = new StaffAppointmentTypeChange();
                this.employees = new List<Employee>();
                this.appointmentTypes = new List<AppointmentType>();
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
                else if (cboAppointmentTypeTo.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboAppointmentTypeTo, "Please Select New Appointment Type");
                    cboAppointmentTypeTo.Focus();
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
                            employee.StaffID = staffAppointmentTypeChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.AppointmentType.ID = staffAppointmentTypeChange.AppointmentTypeTo.ID;
                                dal.Update(employee);
                                dal.Update(staffAppointmentTypeChange);
                                Clear();
                            }
                        }
                        else
                        {
                            employee.StaffID = staffAppointmentTypeChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.AppointmentType.ID = staffAppointmentTypeChange.AppointmentTypeTo.ID;
                                dal.Update(employee);
                                dal.Save(staffAppointmentTypeChange);
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
            staffAppointmentTypeChange.ID = staffAppointmentTypeChangeID;
            staffAppointmentTypeChange.Employee.StaffID = staffIDtxt.Text.Trim();
            staffAppointmentTypeChange.StaffName = nametxt.Text.Trim();
            staffAppointmentTypeChange.Employee.ID = staffCode;
            staffAppointmentTypeChange.Date = dateEntry.Value;
            staffAppointmentTypeChange.AppointmentTypeTo.ID = appointmentTypes[cboAppointmentTypeTo.SelectedIndex].ID;
            staffAppointmentTypeChange.AppointmentTypeFrom.ID = appointmentTypes[txtAppointmentType.SelectedIndex].ID;
            staffAppointmentTypeChange.Reason = reasontxt.Text.Trim();
            staffAppointmentTypeChange.Description = "Appointment Type Changed From " + appointmentTypes[txtAppointmentType.SelectedIndex].Description + " To " + appointmentTypes[cboAppointmentTypeTo.SelectedIndex].Description;
            staffAppointmentTypeChange.User.ID = GlobalData.User.ID;
            staffAppointmentTypeChange.Approved = true;
            staffAppointmentTypeChange.ApprovedUser = GlobalData.User.Name;
            staffAppointmentTypeChange.ApprovedUserStaffID = GlobalData.User.StaffID;
            staffAppointmentTypeChange.ApprovedDate = DateTime.Now.Date;
            staffAppointmentTypeChange.ApprovedTime = DateTime.Now; 
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
                cboAppointmentTypeTo.Items.Clear();
                cboAppointmentTypeTo.Text = string.Empty;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffAppointmentTypeChangeID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff Appointment Type";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtAppointmentType.Items.Clear();
                txtAppointmentType.Text = string.Empty;
                savebtn.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void StaffAppointmentTypeChangeForm_Load(object sender, EventArgs e)
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
                            txtAppointmentType_DropDown(this,EventArgs.Empty);
                            txtAppointmentType.Text = employee.AppointmentType.Description;
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

        private void cboAppointmentTypeTo_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAppointmentTypeTo.Items.Clear();
                appointmentTypes = dal.GetAll<AppointmentType>();
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    cboAppointmentTypeTo.Items.Add(appointmentType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditStaffAppointmentTypeChange(StaffAppointmentTypeChange staffAppointmentTypeChange)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = staffAppointmentTypeChange.StaffName; ;
                staffIDtxt.Text = staffAppointmentTypeChange.Employee.StaffID;
                staffCode = staffAppointmentTypeChange.Employee.ID;
                gendertxt.Text = staffAppointmentTypeChange.Employee.Gender;
                agetxt.Text = staffAppointmentTypeChange.Employee.Age;
                staffAppointmentTypeChangeID = staffAppointmentTypeChange.ID;
                departmentTextBox.Text = staffAppointmentTypeChange.Employee.Department.Description;
                unitTextBox.Text = staffAppointmentTypeChange.Employee.Unit.Description;
                gradeCategoryTextBox.Text = staffAppointmentTypeChange.Employee.GradeCategory.Description;
                gradeTextBox.Text = staffAppointmentTypeChange.Employee.Grade.Grade;
                specialtyTextBox.Text = staffAppointmentTypeChange.Employee.Specialty.Description;
                if (staffAppointmentTypeChange.Employee.EmploymentDate == null)
                {
                    txtEmploymentDate.Text = string.Empty;
                }
                else
                {
                    txtEmploymentDate.Text = staffAppointmentTypeChange.Employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                }
                txtAppointmentType_DropDown(this, EventArgs.Empty);
                txtAppointmentType.Text = staffAppointmentTypeChange.Employee.AppointmentType.Description;

                //Form Details
                dateEntry.Checked = true;
                dateEntry.Value = staffAppointmentTypeChange.Date.Value.Date;
                reasontxt.Text = staffAppointmentTypeChange.Reason;
                cboAppointmentTypeTo_DropDown(this, EventArgs.Empty);
                cboAppointmentTypeTo.Text = staffAppointmentTypeChange.AppointmentTypeTo.Description;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View Staff Appointment Type Changes";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffAppointmentTypeChange.User.ID)
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
                StaffAppointmentTypeChangeView staffAppointmentTypeChangeView = new StaffAppointmentTypeChangeView(dal, this);
                staffAppointmentTypeChangeView.MdiParent = this.MdiParent;
                staffAppointmentTypeChangeView.Show();
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

        private void txtAppointmentType_DropDown(object sender, EventArgs e)
        {
            try
            {
                txtAppointmentType.Items.Clear();
                appointmentTypes = dal.GetAll<AppointmentType>();
                foreach (AppointmentType appointmentType in appointmentTypes)
                {
                    txtAppointmentType.Items.Add(appointmentType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
