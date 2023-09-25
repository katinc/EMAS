using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class SelectiveIncrementForm : Form
    {
        private IList<Employee> employees;
        private IList<StaffSalaryHistory> staffSalaryHistories;
        private Employee employee;
        private Increment increment;
        private Company company;
        private DAL dal;
        private int incrementID;
        private int staffCode;
        private int ctr;
        private bool editMode;

        public SelectiveIncrementForm()
        {
            try
            {
                InitializeComponent();
                this.increment = new Increment();
                this.employee = new Employee();
                this.company = new Company();
                this.dal = new DAL();
                this.staffSalaryHistories = new List<StaffSalaryHistory>();
                this.employees = new List<Employee>();
                this.incrementID = 0;
                this.staffCode = 0;
                this.ctr = 0;
                this.editMode = false;
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

        private void SelectiveIncrementForm_Load(object sender, EventArgs e)
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
                incrementID = 0;
                staffErrorProvider.Clear();
                incrementDatePicker.ResetText();
                txtReason.Text = string.Empty;
                checkBoxPercentage.Checked = false;
                numericNewBasicSalary.Value = 0;
                ClearStaff();
                editMode = false;
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
                            groupBox1.Enabled = true;
                            incrementDatePicker.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            txtBasicSalary.Text = employee.BasicSalary.ToString();
                            txtIncrementDate.Text = employee.IncrementDate.Value.Date.ToString("dd/MM/yyyy");
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
                    employees = dal.LazyLoad<Employee>();
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
                                    searchGrid.Rows[ctr].Cells["gridStaffCode"].Value = employee.ID;
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
                            MessageBox.Show("Employee with StaffID " + staffIDtxt.Text.Trim() + " is not Found");
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

        public void EditSelectiveIncrement(DataGridViewRow row)
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
                agetxt.Text = employee.Age;
                searchGrid.Visible = false;
                groupBox1.Enabled = true;
                incrementDatePicker.Select();
                departmentTextBox.Text = employee.Department.Description;
                unitTextBox.Text = employee.Unit.Description;
                gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                gradeTextBox.Text = employee.Grade.Grade;
                specialtyTextBox.Text = employee.Specialty.Description;
                txtBasicSalary.Text = employee.BasicSalary.ToString();
                txtIncrementDate.Text = employee.IncrementDate.ToString();
                incrementID = int.Parse(row.Cells["gridID"].Value.ToString());
                checkBoxPercentage.Checked = bool.Parse(row.Cells["gridPercentage"].Value.ToString());
                numericNewBasicSalary.Value = decimal.Parse(row.Cells["gridNewBasicSalary"].Value.ToString());
                incrementDatePicker.Text = row.Cells["gridIncrementDate"].Value.ToString();
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
                    UpdateIncrementsEntity();
                    if (editMode)
                    {
                        if (incrementDatePicker.Value.Date <= DateTime.Today.Date)
                        {
                            decimal basicSalary = 0;
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.IncrementDate = increment.IncrementDate;
                            if (increment.IsPercentage == true)
                            {
                                employee.OldBasicSalary = employee.BasicSalary;
                                basicSalary = ((increment.Increase / 100) * employee.BasicSalary) + employee.BasicSalary;
                                employee.BasicSalary = Math.Round(basicSalary, 2);
                            }
                            else
                            {
                                employee.OldBasicSalary = employee.BasicSalary;
                                basicSalary = increment.Increase + employee.BasicSalary;
                                employee.BasicSalary = Math.Round(basicSalary, 2);
                            }
                            dal.Update(employee);
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryHistoryView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffIDtxt.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(query);
                            foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                            {
                                staffSalaryH.MonthlyBasicSalary = basicSalary;
                                staffSalaryH.Grade.ID = increment.Grade.ID;
                                dal.Update(staffSalaryH);
                            }                           
                        }
                        dal.Update(increment);
                    }
                    else
                    {
                        if (incrementDatePicker.Value.Date <= DateTime.Today.Date)
                        {
                            decimal basicSalary = 0;
                            employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                            employee.IncrementDate = increment.IncrementDate;
                            if (increment.IsPercentage == true)
                            {
                                employee.OldBasicSalary = employee.BasicSalary;
                                basicSalary = ((increment.Increase / 100) * employee.BasicSalary) + employee.BasicSalary;
                                employee.BasicSalary = Math.Round(basicSalary, 2);
                            }
                            else
                            {
                                employee.OldBasicSalary = employee.BasicSalary;
                                basicSalary = increment.Increase + employee.BasicSalary;
                                employee.BasicSalary = Math.Round(basicSalary, 2);
                            }
                            dal.Update(employee);
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryHistoryView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = staffIDtxt.Text.Trim(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            staffSalaryHistories = dal.GetByCriteria<StaffSalaryHistory>(query);
                            foreach (StaffSalaryHistory staffSalaryH in staffSalaryHistories)
                            {
                                staffSalaryH.MonthlyBasicSalary = basicSalary;
                                staffSalaryH.Grade.ID = increment.Grade.ID;
                                dal.Update(staffSalaryH);
                            }
                        }
                        dal.Save(increment);
                    }
                    dal.CommitTransaction();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not saved Successfully,Please See the System Administrator");
            }
        }

        private void UpdateIncrementsEntity()
        {
            try
            {
                increment.ID = incrementID;
                increment.Employee.StaffID = staffIDtxt.Text.Trim();
                increment.Employee.ID = staffCode;
                increment.IncrementType = "Increase";
                increment.IncrementDate = incrementDatePicker.Value;
                increment.Increase = numericNewBasicSalary.Value;
                increment.IsPercentage = checkBoxPercentage.Checked;
                increment.User.ID = GlobalData.User.ID;
                increment.Reason = txtReason.Text.Trim();
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
            try
            {
                if (incrementDatePicker.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(incrementDatePicker, "Please select the Increment Date");
                    incrementDatePicker.Focus();
                }
                else if (incrementDatePicker.Checked && !Validator.DateRangeValidator(incrementDatePicker.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(incrementDatePicker, "Please Increment Date cannot be greater than Today");
                    incrementDatePicker.Focus();
                }
                else if (numericNewBasicSalary.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericNewBasicSalary, "Please New Salary Increment cannot be zero");
                    numericNewBasicSalary.Focus();
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
                SelectiveIncrementView form = new SelectiveIncrementView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void ClearStaff()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                departmentTextBox.Clear();
                unitTextBox.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                txtIncrementDate.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void checkBoxPercentage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxPercentage.Checked == true)
                {
                    lblPercent.Visible = true;
                }
                else
                {
                    lblPercent.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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
