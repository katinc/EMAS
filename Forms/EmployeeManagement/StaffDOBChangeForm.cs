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
    public partial class StaffDOBChangeForm : Form
    {
        private StaffDOBChange staffDOBChange;
        private IList<Employee> employees;
        private IDAL dal;
        private bool editMode;
        private int staffDOBChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public StaffDOBChangeForm()
        {
            try
            {
                InitializeComponent();
                this.staffDOBChange = new StaffDOBChange();
                this.employees = new List<Employee>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffDOBChangeID = 0;
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

        private static int CalculateAge(DateTime dateOfBirth)
        {
            int age = 0;
            try
            {
                age = DateTime.Now.Year - dateOfBirth.Year;
                if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
                    age = age - 1;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return age;
        }


        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                int MaxAge = 0;
                int MinAge = 0;
                staffErrorProvider.Clear();

                company = dal.LazyLoad<Company>()[0];
                MaxAge = company.MaximumEmployeeAge;
                MinAge = company.MinimumEmployeeAge;

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
                else if (dateDOB.Checked && !Validator.DateRangeValidator(dateDOB.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "The employee's date of birth cannot be greater than today");
                    dateDOB.Focus();
                }
                else if (dateDOB.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please select the employee's date of birth");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) > MaxAge)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please the age cannot be greater than the max age");
                    dateDOB.Focus();
                }
                else if (CalculateAge(dateDOB.Value) < MinAge)
                {
                    result = false;
                    staffErrorProvider.SetError(dateDOB, "Please the age cannot be less than the min age");
                    dateDOB.Focus();
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
                            employee.StaffID = staffDOBChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.DOB = staffDOBChange.DOBTo;
                                dal.Update(employee);
                                dal.Update(staffDOBChange);
                                Clear();
                            }
                        }
                        else
                        {
                            employee.StaffID = staffDOBChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                employee.DOB = staffDOBChange.DOBTo;
                                dal.Update(employee);
                                dal.Save(staffDOBChange);
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
            staffDOBChange.ID = staffDOBChangeID;
            staffDOBChange.Employee.StaffID = staffIDtxt.Text.Trim();
            staffDOBChange.StaffName = nametxt.Text.Trim();
            staffDOBChange.Employee.ID = staffCode;
            staffDOBChange.Date = dateEntry.Value;
            staffDOBChange.DOBFrom = dateDOBFrom.Value.Date;
            staffDOBChange.DOBTo = dateDOB.Value.Date;
            staffDOBChange.Reason = reasontxt.Text.Trim();
            staffDOBChange.Description = "DOB Changed From " + dateDOBFrom.Value.Date + " To " + dateDOB.Value.Date;
            staffDOBChange.User.ID = GlobalData.User.ID;
            staffDOBChange.Approved = true;
            staffDOBChange.ApprovedUser = GlobalData.User.Name;
            staffDOBChange.ApprovedUserStaffID = GlobalData.User.StaffID;
            staffDOBChange.ApprovedDate = DateTime.Now.Date;
            staffDOBChange.ApprovedTime = DateTime.Now; 
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
                dateDOBFrom.ResetText();
                dateDOBFrom.Checked = false;
                dateDOB.ResetText();
                dateDOB.Checked = false;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffDOBChangeID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff DOB";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                savebtn.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void StaffDOBChangeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Visible = getPermissions.CanAdd;
                    findbtn.Visible = getPermissions.CanView;
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
                            if (employee.DOB == null)
                            {
                                dateDOBFrom.Checked = false; ;
                            }
                            else
                            {
                                dateDOBFrom.Checked = true;
                                dateDOBFrom.Value = employee.DOB.Value.Date;
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

        public void EditStaffDOBChange(StaffDOBChange staffDOBChange)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = staffDOBChange.StaffName; ;
                staffIDtxt.Text = staffDOBChange.Employee.StaffID;
                staffCode = staffDOBChange.Employee.ID;
                gendertxt.Text = staffDOBChange.Employee.Gender;
                agetxt.Text = staffDOBChange.Employee.Age;
                staffDOBChangeID = staffDOBChange.ID;
                departmentTextBox.Text = staffDOBChange.Employee.Department.Description;
                unitTextBox.Text = staffDOBChange.Employee.Unit.Description;
                gradeCategoryTextBox.Text = staffDOBChange.Employee.GradeCategory.Description;
                gradeTextBox.Text = staffDOBChange.Employee.Grade.Grade;
                specialtyTextBox.Text = staffDOBChange.Employee.Specialty.Description;
                if (staffDOBChange.Employee.EmploymentDate == null)
                {
                    txtEmploymentDate.Text = string.Empty;
                }
                else
                {
                    txtEmploymentDate.Text = staffDOBChange.Employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                }

                if (staffDOBChange.DOBFrom == null)
                {
                    dateDOBFrom.Checked = false;
                }
                else
                {
                    dateDOBFrom.Checked = true;
                    dateDOBFrom.Value = staffDOBChange.DOBFrom.Value.Date;
                }

                //Form Details
                dateEntry.Checked = true;
                dateDOB.Checked = true;
                dateEntry.Value = staffDOBChange.Date.Value.Date;
                dateDOB.Value = staffDOBChange.DOBTo.Value.Date;
                reasontxt.Text = staffDOBChange.Reason;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View Staff DOB Changes";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffDOBChange.User.ID)
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
                StaffDOBChangeView staffDOBChangeView = new StaffDOBChangeView(dal, this);
                staffDOBChangeView.MdiParent = this.MdiParent;
                staffDOBChangeView.btnDelete.Visible = CanDelete;
                staffDOBChangeView.Show();
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

    }
}
