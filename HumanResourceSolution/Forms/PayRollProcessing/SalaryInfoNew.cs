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
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class SalaryInfoNew : Form
    {
        private StaffSalaryHistory salaryInfo;
        private Employee employee;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<EmployeeGrade> grades;
        private IList<GradeCategory> gradeCategories;
        private IList<Department> departments;
        private IList<Unit> units;
        private IList<Level> levels;
        private IList<Step> steps;
        private IList<Band> bands;
        private IList<StaffSalaryHistory> salaryInfos;
        private Company company;
        private IDAL dal;
        private bool editMode;
        private int salaryID;
        private int ctr;
        private int staffCode;
        private decimal basicSalary;
        private decimal hoursWorked;
        private Nullable<DateTime> assumptionDate;

        public SalaryInfoNew()
        {            
            try
            {
                InitializeComponent();
                this.salaryInfo = new StaffSalaryHistory();
                this.company = new Company();
                this.employee = new Employee();
                this.dal = new DAL();
                this.dal.OpenConnection(); 
                this.editMode = false;
                this.ctr = 0;
                this.salaryID = 0;
                this.staffCode = 0;
                this.employees=new List<Employee>();
                this.employeeList = new List<Employee>();
                this.salaryInfos = new List<StaffSalaryHistory>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.departments = new List<Department>();
                this.bands = new List<Band>();
                this.levels = new List<Level>();
                this.steps = new List<Step>();                            
                this.company = new Company();
                this.assumptionDate = null;
                this.basicSalary = 0;
                this.hoursWorked = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }            
        }

        public SalaryInfoNew(string staffID)
        {
            try
            {
                InitializeComponent();
                this.salaryInfo = new StaffSalaryHistory();
                this.company = new Company();
                this.employee = new Employee();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.editMode = true;
                this.ctr = 0;
                this.salaryID = 0;
                this.staffCode = 0;
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.salaryInfos = new List<StaffSalaryHistory>();
                this.gradeCategories = new List<GradeCategory>();
                this.grades = new List<EmployeeGrade>();
                this.departments = new List<Department>();
                this.bands = new List<Band>();
                this.levels = new List<Level>();
                this.steps = new List<Step>();
                this.company = new Company();
                this.assumptionDate = null;
                this.basicSalary = 0;
                this.hoursWorked = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void staffIDtxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!searchGrid.Focused)
                    searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void nametxt_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!searchGrid.Focused)
                    searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SalaryInfoNew_Load(object sender, EventArgs e)
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

        void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {  
                Clear();
                
                if (searchGrid.CurrentRow != null)
                {
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            basicSalary = employee.BasicSalary;
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
                            if (employee.AssumptionDate != null)
                            {
                                startDate.Value = employee.AssumptionDate.Value.Date;
                                assumptionDate = employee.AssumptionDate.Value.Date;
                                //startDate.Enabled = false;
                                startDate.Checked = true;
                            }
                            else
                            {
                                startDate.Value = DateTime.Now.Date;
                                startDate.Enabled = true;
                                startDate.Checked = false;
                            }
                            
                            departmentComboBox_DropDown(this, EventArgs.Empty);
                            departmentComboBox.Text = employee.Department.Description;
                            supervisorComboBox.Text = employee.Department.Supervisor;
                            departmentComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                            unitComboBox.Text = employee.Unit.Description;
                            gradeCategoryComboBox_DropDown(this, EventArgs.Empty);
                            gradeCategoryComboBox.Text = employee.GradeCategory.Description;
                            gradeCategoryComboBox_SelectionChangeCommitted(this, EventArgs.Empty);
                            gradeComboBox.Text = employee.Grade.Grade;
                            stepComboBox_DropDown(this, EventArgs.Empty);
                            stepComboBox.Text = employee.Step.Description;
                            
                            bandComboBox_DropDown(this, EventArgs.Empty);
                            bandComboBox.Text = employee.Band.Description;
                            paymentFrequencyTextBox.Text = company.PaymentFrequency;
                            paymentTypeComboBox.Text = employee.PaymentType;
                            paymentModeComboBox.Select();

                            Query staffSalaryHistoryQuery = new Query();
                            staffSalaryHistoryQuery.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryHistoryView.StaffID",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = employee.StaffID,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            salaryInfos = dal.GetByCriteria<StaffSalaryHistory>(staffSalaryHistoryQuery);
                            
                            if (salaryInfos.Count > 0)
                            {
                                this.editMode = true;
                                foreach(StaffSalaryHistory salaryInfo in salaryInfos)
                                {
                                    salaryID = salaryInfo.ID;
                                    paymentModeComboBox.Text = salaryInfo.PaymentMode;
                                    paymentTypeComboBox.Text = salaryInfo.PaymentType;
                                    txtHoursWorked.Value = salaryInfo.HoursWorked;
                                    if (salaryInfo.EndDate == null)
                                    {
                                        basicSalaryTextBox.Text = salaryInfo.MonthlyBasicSalary.ToString();
                                    }
                                    else
                                    {
                                        endDate.Value = salaryInfo.EndDate.Value.Date;
                                        endDate.Checked = true;
                                        basicSalaryTextBox.Text = salaryInfo.SalaryEarned.ToString();
                                    }
                                    inUseCheckBox.Checked = salaryInfo.In_Use;
                                    startDate.Value = salaryInfo.StartDate;
                                    break;
                                }
                            }
                            else
                            {
                                this.editMode = false;
                                paymentModeComboBox.Text = "Bank";
                                basicSalaryTextBox.Text = employee.BasicSalary.ToString();
                                inUseCheckBox.Checked = true;
                                startDate.Value = DateTime.Today.Date;
                            }
                            hoursWorked = company.TotalShifts;
                            txtHoursWorked.Value = hoursWorked;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                ClearStaffInfo();
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeComboBox.Items.Clear();
                gradeComboBox.Text = string.Empty;
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                unitComboBox.Items.Clear();
                unitComboBox.Text = string.Empty;
                stepComboBox.Items.Clear();
                stepComboBox.Text = string.Empty;
                bandComboBox.Items.Clear();
                bandComboBox.Text = string.Empty;
                supervisorComboBox.Text = string.Empty;
                basicSalaryTextBox.Clear();
                paymentModeComboBox.Text = "Bank";
                inUseCheckBox.Checked = false;
                startDate.ResetText();
                paymentFrequencyTextBox.Clear();
                paymentTypeComboBox.Items.Clear();
                paymentTypeComboBox.Text = string.Empty;
                startDate.ResetText();
                searchGrid.Visible = false;
                editMode = false;
                txtHoursWorked.ResetText();
                endDate.ResetText();
                endDate.Checked = false;
                basicSalaryTextBox.Clear();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ClearStaffInfo()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                groupBox2.Enabled = false;
                staffIDtxt.Select();
                inUseCheckBox.Checked = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    ctr = 0;
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
                    if(company.ID == 0)
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    UpdateSalaryInfo();
                    if (editMode)
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        salaryInfo.MonthlyBasicSalary = salaryInfo.MonthlyBasicSalary;
                        //employee.OldBasicSalary = employee.BasicSalary;
                        //employee.BasicSalary = salaryInfo.MonthlyBasicSalary;
                        employee.IsInSalaryInfo = true;
                        dal.Update(employee);
                        dal.Update(salaryInfo);
                    }
                    else
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        salaryInfo.MonthlyBasicSalary = salaryInfo.MonthlyBasicSalary;
                        //employee.OldBasicSalary = employee.BasicSalary;
                        //employee.BasicSalary = salaryInfo.MonthlyBasicSalary;
                        employee.IsInSalaryInfo = true;
                        dal.Update(employee);
                        dal.Save(salaryInfo);
                    }
                    dal.CommitTransaction();
                    Clear();
                }               
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not saved Successfully,Please See the system Administrator");
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();

                if (basicSalaryTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(basicSalaryTextBox, "Please enter the employee's basic salary");
                }
                if (gradeCategoryComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(gradeCategoryComboBox, "Please enter the employee's grade category");
                }
                if (gradeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(gradeComboBox, "Please enter the employee's grade");
                }
                if (stepComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(stepComboBox, "Please enter the employee's step");
                }
                if (bandComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(bandComboBox, "Please enter the employee's band");
                }
                if (paymentModeComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(basicSalaryTextBox, "Please select the employee's payment mode");
                }
                if (assumptionDate == null)
                {
                    result = false;
                    staffErrorProvider.SetError(startDate, "Please setup Employee's Assumption Date at the Registration");
                }
                if (startDate.Checked == false )
                {
                    result = false;
                    staffErrorProvider.SetError(startDate, "Please select the employee's Start Date");
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void UpdateSalaryInfo()
        {
            try
            {
                if (editMode)
                {
                    salaryInfo.ID = salaryID;
                }
                employee.StaffID = staffIDtxt.Text.Trim();
                employee = dal.LazyLoadByStaffID<Employee>(employee);
                salaryInfo.Employee.StaffID=employee.StaffID;
                salaryInfo.Employee.ID = employee.ID;
                salaryInfo.Band.ID = employee.Band.ID;
                salaryInfo.Step.ID = employee.Step.ID;
                salaryInfo.Department = employee.Department;
                salaryInfo.Department.ID = employee.Department.ID;
                salaryInfo.Supervisor = employee.Department.Supervisor;
                salaryInfo.Grade.GradeCategory.ID = employee.GradeCategory.ID;
                salaryInfo.Grade.ID = employee.Grade.ID;
                salaryInfo.PaymentMode = paymentModeComboBox.Text;
                

                if (endDate.Checked == true)
                {
                    salaryInfo.EndDate = endDate.Value.Date;
                    salaryInfo.SalaryEarned = decimal.Parse(basicSalaryTextBox.Text.Trim());
                    salaryInfo.MonthlyBasicSalary = employee.BasicSalary;
                }
                else
                {
                    salaryInfo.MonthlyBasicSalary = decimal.Parse(basicSalaryTextBox.Text.Trim());
                }

                salaryInfo.HoursWorked = txtHoursWorked.Value;

                salaryInfo.In_Use = inUseCheckBox.Checked;
                salaryInfo.StartDate = DateTime.Parse(startDate.Value.Year + "/" + startDate.Value.Month + "/" + "1");
                salaryInfo.PaymentFrequency = paymentFrequencyTextBox.Text;
                salaryInfo.PaymentType = paymentTypeComboBox.Text;
                salaryInfo.UserID = GlobalData.User.ID;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                SalaryInfoView viewForm = new SalaryInfoView(this);
                viewForm.MdiParent = this.MdiParent;
                viewForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void GetInfoToUpdate(DataGridViewRow row)
        {
            try
            {
                editMode = true;
                salaryInfo = new StaffSalaryHistory();
                gradeComboBox.Items.Clear();
                foreach (EmployeeGrade grade in grades)
                {
                    gradeComboBox.Items.Add(grade.Grade);
                }
                departmentComboBox.Items.Clear();
                foreach (Department department in departments)
                {
                    departmentComboBox.Items.Add(department.Supervisor);
                }

                supervisorComboBox.Items.Clear();
                if (employees.Count <= 0)
                {
                    employees = dal.LazyLoad<Employee>();
                }
                foreach (Employee employee in employees)
                {
                    supervisorComboBox.Items.Add(employee.FirstName + (employee.OtherName == string.Empty ? " " : " " + employee.OtherName + " ") + " " + employee.Surname);
                }

                foreach (Employee employee in employees)
                {
                    if (employee.StaffID == row.Cells["StaffID"].Value.ToString())
                    {
                        nametxt.Text = employee.FirstName + (employee.OtherName == string.Empty ? " " : " " + employee.OtherName + " ") + " " + employee.Surname;
                        staffIDtxt.Text = employee.StaffID;
                        agetxt.Text = employee.Age;
                        gendertxt.Text = employee.Gender;
                        pictureBox.Image = employee.Photo;
                    }
                }

                foreach (EmployeeGrade grade in grades)
                {
                    if (grade.ID == int.Parse(row.Cells["GradeID"].Value.ToString()))
                    {
                        gradeComboBox.SelectedIndex = grades.IndexOf(grade);
                    }
                }

                foreach (Band band in bands)
                {
                    if (band.ID == int.Parse(row.Cells["BandID"].Value.ToString()))
                    {
                        bandComboBox.SelectedIndex = bands.IndexOf(band);
                    }
                }

                foreach (Department department in departments)
                {
                    if (department.ID == int.Parse(row.Cells["DepartmentID"].Value.ToString()))
                    {
                        departmentComboBox.SelectedIndex = departments.IndexOf(department);
                    }
                }
                foreach (Employee supervisor in employees)
                {
                    if (supervisor.StaffID == row.Cells["SupervisorID"].Value.ToString())
                    {
                        supervisorComboBox.SelectedIndex = employees.IndexOf(supervisor);
                    }
                }
                basicSalaryTextBox.Text = row.Cells["MonthlyBasicSalary"].Value.ToString();
                paymentModeComboBox.Text = row.Cells["PaymentMode"].Value.ToString();
                inUseCheckBox.Checked = bool.Parse(row.Cells["InUse"].Value.ToString());
                startDate.Text = row.Cells["StartDate"].Value.ToString();
                searchGrid.Visible = false;
                departmentComboBox.Enabled = true;
                supervisorComboBox.Enabled = true;
                gradeComboBox.Enabled = true;
                basicSalaryTextBox.Enabled = true;
                paymentModeComboBox.Enabled = true;
                inUseCheckBox.Enabled = true;
                groupBox2.Enabled = true;
                salaryInfo.ID = int.Parse(row.Cells["ID"].Value.ToString());
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
                departmentComboBox.Items.Clear();
                departmentComboBox.Text = string.Empty;
                departments = dal.GetAll<Department>();
                foreach (Department department in departments)
                {
                    departmentComboBox.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        void gradeCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                gradeCategoryComboBox.Items.Clear();
                gradeCategoryComboBox.Text = string.Empty;
                gradeCategories=dal.GetAll<GradeCategory>();
                foreach (GradeCategory category in gradeCategories)
                {
                    gradeCategoryComboBox.Items.Add(category.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
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
                grades = dal.GetByCriteria<EmployeeGrade>(query);
                foreach (EmployeeGrade grade in grades)
                {
                    gradeComboBox.Items.Add(grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void stepComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                stepComboBox.Items.Clear();
                stepComboBox.Text = string.Empty;
                steps = dal.GetAll<Step>();
                foreach (Step step in steps)
                {
                    stepComboBox.Items.Add(step.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void bandComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                bandComboBox.Items.Clear();
                bandComboBox.Text = string.Empty;
                bands = dal.GetAll<Band>();
                foreach (Band band in bands)
                {
                    bandComboBox.Items.Add(band.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void departmentComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                unitComboBox.Items.Clear();
                unitComboBox.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = departmentComboBox.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    unitComboBox.Items.Add(unit.Description);
                }
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

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            if(endDate.Checked == true)
            {
                basicSalaryTextBox.Text = Math.Round(txtHoursWorked.Value * basicSalary / hoursWorked,2,MidpointRounding.AwayFromZero).ToString();
            }
            else
            {
                basicSalaryTextBox.Text = basicSalary.ToString();
                txtHoursWorked.Value = company.TotalShifts;
            }
        }

        private void txtHoursWorked_ValueChanged(object sender, EventArgs e)
        {
            if (endDate.Checked == true)
            {
                basicSalaryTextBox.Text = Math.Round(txtHoursWorked.Value * basicSalary / hoursWorked, 2, MidpointRounding.AwayFromZero).ToString();
            }
            else
            {
                basicSalaryTextBox.Text = basicSalary.ToString();
            }
        }

    }
}
