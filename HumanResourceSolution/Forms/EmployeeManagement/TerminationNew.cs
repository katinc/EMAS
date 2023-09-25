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

namespace eMAS.All_UIs.Claims_Leave_Hire_Purchase_FORMS
{
    public partial class TerminationNew : Form
    {
        private Termination termination;
        private IList<Employee> employees;
        private IList<SeparationType> separationTypes;
        private IDAL dal;
        private bool editMode;
        private int terminationID;
        private Company company;
        private Employee employee;
        private int ctr;
        private int staffCode;
        private bool terminated;

        public TerminationNew()
        {
            try
            {
                InitializeComponent();
                this.termination = new Termination();
                this.employees = new List<Employee>();
                this.separationTypes = new List<SeparationType>();
                this.dal = new DAL();
                this.editMode = false;
                this.company = new Company();
                this.employee = new Employee();
                this.ctr = 0;
                this.staffCode=0;
                this.terminated = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditTermination(Termination termination)
        {
            try
            {
                Clear();
                editMode = true;
                nametxt.Text = termination.StaffName; ;
                staffIDtxt.Text = termination.Employee.StaffID;
                staffCode = termination.Employee.ID;
                gendertxt.Text = termination.Employee.Gender;
                agetxt.Text = termination.Employee.Age;
                terminationID = termination.ID;
                departmentTextBox.Text = termination.Employee.Department.Description;
                unitTextBox.Text = termination.Employee.Unit.Description;
                gradeCategoryTextBox.Text = termination.Employee.GradeCategory.Description;
                gradeTextBox.Text = termination.Employee.Grade.Grade;
                specialtyTextBox.Text = termination.Employee.Specialty.Description;
                txtEmploymentDate.Text = termination.Employee.EmploymentDate.ToString();
                txtSeparationType.Text = termination.Employee.SeparationType.Description;
                txtSeparationDate.Text = termination.Employee.TerminationDate.ToString();
                terminated = termination.Employee.Terminated;

                terminationDate.Value = termination.TerminationDate.Value.Date;
                typecmb_DropDown(this, EventArgs.Empty);
                typecmb.Text = termination.Type;
                reasontxt.Text = termination.Reason;
                employeeCheckBox.Checked = termination.EmployeeNoticed;
                employerCheckBox.Checked = termination.EmployerNoticed;
                cboSeparationType_DropDown(this, EventArgs.Empty);
                cboSeparationType.Text = termination.SeparationType.Description;
                groupBox2.Enabled = true;
                label8.Text = "Edit Separation";
                searchGrid.Visible = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != termination.User.ID)
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
                if (terminationDate.Checked == false || terminationDate.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(terminationDate, "Please select the Termination Date");
                    terminationDate.Focus();
                }
                else if (terminationDate.Checked && !Validator.DateRangeValidator(terminationDate.Value, GlobalData.ServerDate, DateUnit.Day, DateRangeBoundary.UpperInclusive, 0))
                {
                    result = false;
                    staffErrorProvider.SetError(terminationDate, "Please Termination Date cannot be greater than Today");
                    terminationDate.Focus();
                }
                else if (cboSeparationType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboSeparationType, "Please Select Separation Type");
                    cboSeparationType.Focus();
                }
                else if (editMode == false && txtSeparationType.Text.Trim() != string.Empty && terminated == false)
                {
                    result = false;
                    staffErrorProvider.SetError(cboSeparationType, "Please Staff is already Separated Pending Approval");
                    cboSeparationType.Focus();
                }
                else if (editMode == false && txtSeparationType.Text.Trim() != string.Empty && terminated == true)
                {
                    result = false;
                    staffErrorProvider.SetError(cboSeparationType, "Please Staff is already Separated, You cannot add Sepration For the Staff");
                    cboSeparationType.Focus();
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
                    dal.BeginTransaction();
                    this.Assign();
                    if (editMode)
                    {
                        employee.StaffID = termination.Employee.StaffID;
                        employee=dal.LazyLoadByStaffID<Employee>(employee);
                        if(employee.ID != 0)
                        {
                            employee.SeparationType.ID = termination.SeparationType.ID;
                            employee.TerminationDate = termination.TerminationDate.Value.Date;
                            dal.Update(employee);
                            dal.Update(termination);
                            Clear();
                        }
                    }
                    else
                    {
                        employee.StaffID = termination.Employee.StaffID;
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        if (employee.ID != 0)
                        {
                            employee.SeparationType.ID = termination.SeparationType.ID;
                            employee.TerminationDate = termination.TerminationDate.Value.Date;
                            dal.Update(employee);
                            dal.Save(termination);
                            Clear();
                        }
                    }
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show(ex.Message, "IDNS Human Resource", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                TerminationView terminationView = new TerminationView(dal, this);
                terminationView.MdiParent = this.MdiParent;
                terminationView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
            termination.ID = terminationID;
            termination.Employee.StaffID = staffIDtxt.Text.Trim();
            termination.Employee.ID = staffCode;
            termination.StaffName = nametxt.Text.Trim();
            termination.EmployeeNoticed = employeeCheckBox.Checked;
            termination.EmployerNoticed = employerCheckBox.Checked;
            termination.TerminationDate = terminationDate.Value;
            termination.Type = typecmb.Text.Trim();
            termination.SeparationType.ID = separationTypes[cboSeparationType.SelectedIndex].ID;
            termination.Reason = reasontxt.Text.Trim();
            termination.User.ID = GlobalData.User.ID;
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                editMode = false;
                terminationDate.Value = DateTime.Now.Date;
                typecmb.Items.Clear();
                typecmb.Text = string.Empty;
                cboSeparationType.Items.Clear();
                cboSeparationType.Text = string.Empty;
                reasontxt.Clear();
                employeeCheckBox.Checked = false;
                employerCheckBox.Checked = false;
                searchGrid.Visible = false;
                staffIDtxt.Select();
                staffIDtxt.Clear();
                staffCode = 0;
                nametxt.Clear();
                agetxt.Clear();
                gendertxt.Clear();
                terminationID = 0;
                txtEmploymentDate.Text=string.Empty;
                gradeCategoryTextBox.Text = string.Empty;
                gradeTextBox.Text = string.Empty;
                departmentTextBox.Text = string.Empty;
                unitTextBox.Text=string.Empty;
                specialtyTextBox.Text = string.Empty;
                label8.Text = "New Termination";
                groupBox2.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                txtSeparationDate.Clear();
                txtSeparationType.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void Termination_Load(object sender, EventArgs e)
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
                            terminationDate.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            txtEmploymentDate.Text = employee.EmploymentDate.Value.Date.ToString("dd/MM/yyyy");
                            txtSeparationDate.Text = employee.TerminationDate.Value.Date.ToString("dd/MM/yyyy");
                            txtSeparationType.Text = employee.SeparationType.Description;
                            if (editMode == false && txtSeparationType.Text.Trim() != string.Empty && terminated == false)
                            {
                                MessageBox.Show("Please Staff is already Separated Pending Approval");
                                Clear();
                            }
                            else if (editMode == false && txtSeparationType.Text.Trim() != string.Empty && terminated == true)
                            {
                                MessageBox.Show("Please Staff is already Separated, You cannot add Sepration For the Staff");
                                Clear();
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
                        searchGrid.Location = new Point(178, 39);
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

        private void cboSeparationType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboSeparationType.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "SeparationTypesView.Reinstatement",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                separationTypes = dal.GetByCriteria<SeparationType>(query);
                foreach (SeparationType separationType in separationTypes)
                {
                    cboSeparationType.Items.Add(separationType.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void typecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                typecmb.Items.Clear();
                typecmb.Items.Add("Employee Instigated");
                typecmb.Items.Add("Employer Instigated");
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
