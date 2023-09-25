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
    public partial class StaffEmploymentDateChangeForm : Form
    {
        private StaffEmploymentDateChange staffEmploymentDateChange;
        private IList<Employee> employees;
        private IDAL dal;
        private bool editMode;
        private int staffEmploymentDateChangeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public StaffEmploymentDateChangeForm()
        {
            try
            {
                InitializeComponent();
                this.staffEmploymentDateChange = new StaffEmploymentDateChange();
                this.employees = new List<Employee>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffEmploymentDateChangeID = 0;
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
                staffErrorProvider.Clear();

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
                else if (dateEmploymentTo.Checked == false && dateAssumptionTo.Checked == false && dateDOFATo.Checked == false)
                {
                    result = false;
                    staffErrorProvider.SetError(dateEmploymentTo, "Please select one of the following Date (Employment, Assumption, DOFA)");
                    dateEmploymentTo.Focus();
                }
                else if (dateEmploymentTo.Checked && !Validator.DateRangeValidator(dateEmploymentTo.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateEmploymentTo, "Please Employment Date cannot be greater than Today");
                    dateEmploymentTo.Focus();
                }
                else if (dateAssumptionTo.Checked && dateEmploymentTo.Checked && !Validator.DateRangeValidator(dateEmploymentTo.Value, dateAssumptionTo.Value, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateEmploymentTo, "Please Employment Date cannot be greater than Assumption Date");
                    dateEmploymentTo.Focus();
                }
                else if (dateAssumptionTo.Checked == false && dateEmploymentTo.Checked && !Validator.DateRangeValidator(dateEmploymentTo.Value, dateAssumptionFrom.Value, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(dateEmploymentTo, "Please Employment Date cannot be greater than Assumption Date");
                    dateEmploymentTo.Focus();
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
                            employee.StaffID = staffEmploymentDateChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                if (staffEmploymentDateChange.EmploymentDateTo != null)
                                {
                                    employee.EmploymentDate = staffEmploymentDateChange.EmploymentDateTo;
                                    employee.DOCA = staffEmploymentDateChange.EmploymentDateTo;
                                }
                                if (staffEmploymentDateChange.DOFADateTo != null)
                                {
                                    employee.DOFA = staffEmploymentDateChange.DOFADateTo;
                                }
                                if (staffEmploymentDateChange.AssumptionDateTo != null)
                                {
                                    employee.AssumptionDate = staffEmploymentDateChange.AssumptionDateTo;
                                }

                                dal.Update(employee);
                                dal.Update(staffEmploymentDateChange);
                                Clear();
                            }
                        }
                        else
                        {
                            employee.StaffID = staffEmploymentDateChange.Employee.StaffID;
                            employee = dal.LazyLoadByStaffID<Employee>(employee);
                            if (employee.ID != 0)
                            {
                                if (staffEmploymentDateChange.EmploymentDateTo != null)
                                {
                                    employee.EmploymentDate = staffEmploymentDateChange.EmploymentDateTo;
                                    employee.DOCA = staffEmploymentDateChange.EmploymentDateTo;
                                }
                                if (staffEmploymentDateChange.DOFADateTo != null)
                                {
                                    employee.DOFA = staffEmploymentDateChange.DOFADateTo;
                                }
                                if (staffEmploymentDateChange.AssumptionDateTo != null)
                                {
                                    employee.AssumptionDate = staffEmploymentDateChange.AssumptionDateTo;
                                }
                                dal.Update(employee);
                                dal.Save(staffEmploymentDateChange);
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
            staffEmploymentDateChange.ID = staffEmploymentDateChangeID;
            staffEmploymentDateChange.Employee.StaffID = staffIDtxt.Text.Trim();
            staffEmploymentDateChange.StaffName = nametxt.Text.Trim();
            staffEmploymentDateChange.Employee.ID = staffCode;
            staffEmploymentDateChange.Date = dateEntry.Value;

            if (dateEmploymentTo.Value != null && dateEmploymentTo.Checked == true)
            {
                staffEmploymentDateChange.EmploymentDateFrom = dateEmploymentFrom.Value.Date;
                staffEmploymentDateChange.EmploymentDateTo = dateEmploymentTo.Value.Date;
                staffEmploymentDateChange.Description = "Employment Date Changed From " + dateEmploymentFrom.Value.Date + " To " + dateEmploymentTo.Value.Date;
            }
            if (dateAssumptionTo.Value != null && dateAssumptionTo.Checked == true)
            {
                staffEmploymentDateChange.AssumptionDateFrom = dateAssumptionFrom.Value.Date;
                staffEmploymentDateChange.AssumptionDateTo = dateAssumptionTo.Value.Date;
                staffEmploymentDateChange.Description = "Assumption Date Changed From " + dateAssumptionFrom.Value.Date + " To " + dateAssumptionTo.Value.Date;
            }

            if (dateDOFATo.Value != null && dateDOFATo.Checked == true)
            {
                staffEmploymentDateChange.DOFADateFrom = dateDOFAFrom.Value.Date;
                staffEmploymentDateChange.DOFADateTo = dateDOFATo.Value.Date;
                staffEmploymentDateChange.Description = "DOFA Changed From " + dateAssumptionFrom.Value.Date + " To " + dateAssumptionTo.Value.Date;
            }

            staffEmploymentDateChange.Reason = reasontxt.Text.Trim();
            staffEmploymentDateChange.User.ID = GlobalData.User.ID;
            staffEmploymentDateChange.Approved = true;
            staffEmploymentDateChange.ApprovedUser = GlobalData.User.Name;
            staffEmploymentDateChange.ApprovedUserStaffID = GlobalData.User.StaffID;
            staffEmploymentDateChange.ApprovedDate = DateTime.Now.Date;
            staffEmploymentDateChange.ApprovedTime = DateTime.Now; 
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
                dateEmploymentFrom.Checked = false;
                dateEmploymentFrom.ResetText();
                dateDOBFrom.Checked = false;
                dateDOBFrom.ResetText();
                dateEmploymentTo.ResetText();
                dateEmploymentTo.Checked = false;
                dateAssumptionFrom.ResetText();
                dateAssumptionFrom.Checked = false;
                dateAssumptionTo.ResetText();
                dateAssumptionTo.Checked = false;
                dateDOFAFrom.ResetText();
                dateDOFAFrom.Checked = false;
                dateDOFATo.ResetText();
                dateDOFATo.Checked = false;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                staffEmploymentDateChangeID = 0;
                

                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "Change Staff Employment Date";
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

        private void StaffEmploymentDateChangeForm_Load(object sender, EventArgs e)
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
                                dateEmploymentFrom.Text = string.Empty;
                            }
                            else
                            {
                                dateEmploymentFrom.Text = employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                                dateEmploymentFrom.Checked = true;
                            }
                            if (employee.AssumptionDate == null)
                            {
                                dateAssumptionFrom.Text = string.Empty;
                            }
                            else
                            {
                                dateAssumptionFrom.Text = employee.AssumptionDate.Value.Date.ToString("dd/MM/yyyy");
                                dateAssumptionFrom.Checked = true;
                            }
                            if (employee.DOFA == null)
                            {
                                dateDOFAFrom.Text = string.Empty;
                            }
                            else
                            {
                                dateDOFAFrom.Text = employee.DOFA.Value.Date.ToString("dd/MM/yyyy");
                                dateDOFAFrom.Checked = true;
                            }
                            if (employee.DOB == null)
                            {
                                dateDOBFrom.Text = string.Empty;
                            }
                            else
                            {
                                dateDOBFrom.Text = employee.DOB.Value.Date.ToString("dd/MM/yyyy");
                                dateDOBFrom.Checked = true;
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

        public void EditStaffEmploymentChange(StaffEmploymentDateChange staffEmploymentDateChange)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = staffEmploymentDateChange.StaffName; ;
                staffIDtxt.Text = staffEmploymentDateChange.Employee.StaffID;
                staffCode = staffEmploymentDateChange.Employee.ID;
                gendertxt.Text = staffEmploymentDateChange.Employee.Gender;
                agetxt.Text = staffEmploymentDateChange.Employee.Age;
                staffEmploymentDateChangeID = staffEmploymentDateChange.ID;
                departmentTextBox.Text = staffEmploymentDateChange.Employee.Department.Description;
                unitTextBox.Text = staffEmploymentDateChange.Employee.Unit.Description;
                gradeCategoryTextBox.Text = staffEmploymentDateChange.Employee.GradeCategory.Description;
                gradeTextBox.Text = staffEmploymentDateChange.Employee.Grade.Grade;
                specialtyTextBox.Text = staffEmploymentDateChange.Employee.Specialty.Description;
                if (staffEmploymentDateChange.Employee.EmploymentDate == null)
                {
                    dateEmploymentFrom.Text = string.Empty;
                }
                else
                {
                    dateEmploymentFrom.Text = staffEmploymentDateChange.Employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                }

                if (staffEmploymentDateChange.Employee.DOB == null)
                {
                    dateDOBFrom.Text = string.Empty;
                }
                else
                {
                    dateDOBFrom.Text = staffEmploymentDateChange.Employee.DOB.Value.Date.ToString("dd/MM/yyyy");
                }

                //Form Details
                dateEntry.Checked = true;
                dateEntry.Value = staffEmploymentDateChange.Date.Value.Date;
                dateEmploymentTo.Value = staffEmploymentDateChange.EmploymentDateTo.Value.Date;
                reasontxt.Text = staffEmploymentDateChange.Reason;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View Staff Employment Date Changes";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffEmploymentDateChange.User.ID)
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
                StaffEmploymentDateChangeView staffEmploymentDateChangeView = new StaffEmploymentDateChangeView(dal, this);
                staffEmploymentDateChangeView.MdiParent = this.MdiParent;
                staffEmploymentDateChangeView.Show();
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
