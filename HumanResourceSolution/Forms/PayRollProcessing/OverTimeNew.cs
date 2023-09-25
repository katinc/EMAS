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
using eMAS.Forms.ClaimsLeaveHirePurchase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using eMAS.Forms.EmployeeManagement;
using HRBussinessLayer.Validation;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class OverTimeNew : Form
    {
        private OverTime overTime;
        private IList<Employee> employees;
        private IList<GradeCategory> gradeCategories;
        private IList<EmployeeGrade> grades;
        private IList<EmployeeGrade> gradess;
        private IList<OverTimeType> overTimeTypes;
        private IDAL dal;
        private bool editMode;
        private int overTimeID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;

        public OverTimeNew()
        {
            try
            {
                InitializeComponent();
                this.overTime = new OverTime();
                this.employees = new List<Employee>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.gradess = new List<EmployeeGrade>();
                this.overTimeTypes = new List<OverTimeType>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode=0;
                this.overTimeID = 0;
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
                else if (cboOverTimeType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboOverTimeType, "Please Select OverTime Type");
                    cboOverTimeType.Focus();
                }
                else if (cboOverTimeType.Text.ToLower().Trim() == "public holiday overtime" && dateHoliday.Checked == false)
                {
                    result = false;
                    staffErrorProvider.SetError(dateHoliday, "Please Select Holiday");
                    cboOverTimeType.Focus();
                }
                else if (company.TotalShifts <= 0)
                {
                    result = false;
                    MessageBox.Show("Please Enter Total Shifts at Company Setup,It cannot be Zero");
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
                    if (MessageBox.Show("Are you sure you want to add OverTime?", GlobalData.Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dal.BeginTransaction();
                        this.Assign();
                        if (editMode)
                        {
                            dal.Update(overTime);
                            Clear();
                        }
                        else
                        {
                            dal.Save(overTime);
                            Clear();
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
                Clear();
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
            try
            {
                overTime.ID = overTimeID;
                overTime.Employee.StaffID = staffIDtxt.Text.Trim();
                overTime.Employee.ID = staffCode;
                overTime.Date = dateEntry.Value;
                overTime.OverTimeType.ID = overTimeTypes[cboOverTimeType.SelectedIndex].ID;
                overTime.HrsWorked = numericHrsWorked.Value;
                if (overTime.OverTimeType.ID == 1)
                {
                    overTime.Holiday = dateHoliday.Value.Date;
                }
                
                overTime.TotalShifts = company.TotalShifts;
                overTime.GradeCategory.ID = gradeCategories[gradeCategoryTextBox.SelectedIndex].ID;
                overTime.Grade.ID = gradess[gradeTextBox.SelectedIndex].ID;
                overTime.OverTimeRate = overTimeTypes[cboOverTimeType.SelectedIndex].Rate;
                overTime.BasicSalary = decimal.Parse(txtBasicSalary.Text.ToString());
                overTime.Amount = getAmount(overTime.HrsWorked, overTime.OverTimeRate, overTime.BasicSalary, overTime.TotalShifts);
                overTime.Date = dateEntry.Value;
                overTime.GradeCategory.ID = gradeCategories[gradeCategoryTextBox.SelectedIndex].ID;
                overTime.Grade.ID = gradess[gradeTextBox.SelectedIndex].ID;
                overTime.Reason = reasontxt.Text.Trim();
                overTime.In_Use = checkBoxIsActive.Checked;
                overTime.IsTaxable = checkBoxIsTaxable.Checked;
                overTime.User.ID = GlobalData.User.ID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private decimal getAmount(decimal overTimeHrs,decimal rate,decimal basicSalary,int totalshift)
        {
            decimal amount = 0;
            try
            {
                amount = (basicSalary * overTimeHrs * rate) / totalshift;            
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return amount;
        }

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                txtTotalShifts.Clear();
                dateEntry.Value = DateTime.Now.Date;
                dateEntry.Checked = false;
                dateHoliday.ResetText();
                dateHoliday.Checked = false;
                numericHrsWorked.ResetText();
                cboOverTimeType.Items.Clear();
                cboOverTimeType.Text = string.Empty;
                reasontxt.Clear();
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                overTimeID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                numericUpDownAmount.Value = 0;
                label8.Text = "Over Time New";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtBasicSalary.Clear();
                savebtn.Enabled = true;
                checkBoxIsActive.Checked = true;
                checkBoxIsTaxable.Checked = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void OverTimeNew_Load(object sender, EventArgs e)
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
                            txtBasicSalary.Text = employee.BasicSalary.ToString();
                            txtTotalShifts.Text = company.TotalShifts.ToString();
                            numericHrsWorked.Value=0;
                            if (employee.EmploymentDate == null)
                            {
                                txtEmploymentDate.Text = string.Empty;
                            }
                            else
                            {
                                txtEmploymentDate.Text = employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
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

        public void EditOverTimeChange(OverTime overTime)
        {
            try
            {
                Clear();
                editMode = true;
                staffIDtxt.Text = overTime.Employee.StaffID;
                staffCode = overTime.Employee.ID;
                gendertxt.Text = overTime.Employee.Gender;
                agetxt.Text = overTime.Employee.Age;
                overTimeID = overTime.ID;
                departmentTextBox.Text = overTime.Employee.Department.Description;
                unitTextBox.Text = overTime.Employee.Unit.Description;
                gradeCategoryTextBox.Text = overTime.Employee.GradeCategory.Description;
                gradeTextBox.Text = overTime.Employee.Grade.Grade;
                specialtyTextBox.Text = overTime.Employee.Specialty.Description;
                txtEmploymentDate.Text = overTime.Employee.EmploymentDate.ToString();
                txtBasicSalary.Text = overTime.Employee.BasicSalary.ToString();
                txtTotalShifts.Text = overTime.TotalShifts.ToString();
                txtOverTimeRate.Text = overTime.OverTimeRate.ToString();
                numericUpDownAmount.Value = overTime.Amount;

                dateEntry.Value = overTime.Date.Value.Date;
                dateEntry.Checked = true;
                dateEntry.Enabled = false;
                reasontxt.Text = overTime.Reason;
                cboOverTimeType_DropDown(this, EventArgs.Empty);
                cboOverTimeType.Text = overTime.OverTimeType.Description;
                numericHrsWorked.Value = overTime.HrsWorked;
                if (overTime.OverTimeType.Description == "public holiday overtime" && overTime.Holiday.Value != null)
                {
                    cboOverTimeType_SelectedIndexChanged(this,EventArgs.Empty);
                    dateHoliday.Value = overTime.Holiday.Value.Date;
                }
                checkBoxIsTaxable.Checked = overTime.IsTaxable;
                checkBoxIsActive.Checked = overTime.In_Use;
                groupBox2.Enabled = false;
                savebtn.Enabled = false;
                label8.Text = "View OverTime";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != overTime.User.ID)
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
                OverTimeView overTimeView = new OverTimeView(dal, this);
                overTimeView.MdiParent = this.MdiParent;
                overTimeView.Show();
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

        private void cboOverTimeType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboOverTimeType.Items.Clear();
                overTimeTypes = dal.GetAll<OverTimeType>();
                foreach (OverTimeType overTimeType in overTimeTypes)
                {
                    cboOverTimeType.Items.Add(overTimeType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboOverTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtOverTimeRate.Text = overTimeTypes[cboOverTimeType.SelectedIndex].Rate.ToString();
                if (cboOverTimeType.Text.ToLower().Trim() == "public holiday overtime")
                {
                    lblHoliday.Visible = true;
                    dateHoliday.Visible = true;
                    dateHoliday.Checked = true;
                }
                else
                {
                    lblHoliday.Visible = false;
                    dateHoliday.Visible = false;
                    dateHoliday.Checked = false;
                }
                numericUpDownAmount.Value = getAmount(numericHrsWorked.Value, overTimeTypes[cboOverTimeType.SelectedIndex].Rate, decimal.Parse(txtBasicSalary.Text.ToString()), company.TotalShifts);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void numericHrsWorked_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                numericUpDownAmount.Value = getAmount(numericHrsWorked.Value, overTimeTypes[cboOverTimeType.SelectedIndex].Rate, decimal.Parse(txtBasicSalary.Text.ToString()), company.TotalShifts);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
