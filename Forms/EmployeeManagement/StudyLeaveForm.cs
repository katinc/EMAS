using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Claims_Leave_Hire_Purchase_Data_Control;
using HRDataAccessLayer;
using eMAS.Forms.ClaimsLeaveHirePurchase;
using eMAS.Forms.Reports;
using HRDataAccessLayerBase;
using HRBussinessLayer;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Utils;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using eMAS.ServiceReference;
using eMAS;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class StudyLeaveForm : Form
    {
        private IDAL dal;
        private Leave leave;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private IList<LeaveType> leaveTypes;
        private Employee employee;
        private LeaveDataMapper leavManip;
        private DataTable leaveTypesTable;
        private bool editMode;
        private int leaveID;
        private DALHelper dalHelper;
        private Form reportForm;
        private Company company;
        private int ctr;
        private int staffCode;
        private decimal leaveDays;
        List<Control> controls;

        public Permissions permissions;

        public StudyLeaveForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.leave = new Leave();
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.leaveTypes = new List<LeaveType>();
                this.employee = new Employee();
                this.leavManip = new LeaveDataMapper();
                this.editMode = false;
                this.ctr = 0;
                this.staffCode = 0;
                this.leaveDays = 0;
                this.leaveID = 0;
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.company = new Company();
                this.leaveTypesTable = new DataTable();
                this.dalHelper = new DALHelper();
                controls = new List<Control>();

                //startDate.Value = DateTime.Now.Date;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
            }
        }

        void loadPaymentItems()
        {
            try
            {
                cboPayment.Items.Clear();
                cboPayment.Items.Add("Full Payment");
                cboPayment.Items.Add("Part Payment");
                cboPayment.Items.Add("No Funding");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
            }
        }

        private void StudyLeaveForm_Load(object sender, EventArgs e)
        {
            try
            {
                var studyLeaveTypes = GlobalData._context.StudyLeaveTypes.Where(u=>u.Archived == false).ToList();

                cboStudyLeaveType.Items.Clear();
                foreach (var item in studyLeaveTypes)
                {
                    cboStudyLeaveType.Items.Add(item.Description);
                }

                loadPaymentItems();

                staffIDtxt.Select();

                //GlobalData.FillControls(controls, this);

                permissions = GlobalData.CheckPermissions(3);
                if (permissions != null)
                {
                    btnSave.Enabled = permissions.CanAdd;
                    btnView.Enabled = permissions.CanView;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                AppUtils.ErrorMessageBox();
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
                    clearPersonalInfo();
                    //Clear();

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void clearPersonalInfo()
        {
            try
            {
                editMode = false;
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                txtLeaveDue.Clear();
                txtAnnualLeaveYear.Clear();
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                departmentTextBox.Clear();
                unitTextBox.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw;
            }
        }

        #region CLEAR
        private void Clear()
        {
            try
            {
                clearPersonalInfo();
                cboStudyLeaveType.Text = string.Empty;
                dateReportingDate.ResetText();
                leaveID = 0;
                btnPreview.Visible = false;
                label1.Text = "Study Leave Form";
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                departmentTextBox.Clear();
                staffErrorProvider.Clear();
                cboStudyLeaveType.Items.Clear();
                cboStudyLeaveType.Text = string.Empty;
                numericDurationyears.Value = 0;
                txtInstitution.Clear();
                txtProgramme.Clear();
                txtReason.Clear();
                gradeCategoryTextBox.Clear();
                gradeTextBox.Clear();
                specialtyTextBox.Clear();
                this.employee = null;

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    clearPersonalInfo();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            this.employee = employee;
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
                            staffCode = employee.ID;
                            gendertxt.Text = employee.Gender;
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            departmentTextBox.Text = employee.Department.Description;
                            unitTextBox.Text = employee.Unit.Description;
                            gradeCategoryTextBox.Text = employee.GradeCategory.Description;
                            gradeTextBox.Text = employee.Grade.Grade;
                            specialtyTextBox.Text = employee.Specialty.Description;
                            txtEmploymentDate.Text = employee.EmploymentDate.Value.ToString();
                            txtLeaveDue.Text = employee.AnnualLeave.ToString();
                            txtAnnualLeaveYear.Text = employee.AnnualLeaveYear.ToString();

                             
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    Assign();
                    if (editMode)
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        employee.LeaveStatus = "Requested";
                        employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        employee.CurrentLeaveEndDate = leave.EndDate.Date;
                        dal.Update(employee);
                        dal.Update(leave);

                    }
                    else
                    {
                        employee.StaffID = staffIDtxt.Text.Trim();
                        employee = dal.LazyLoadByStaffID<Employee>(employee);
                        employee.LeaveStatus = "Requested";
                        employee.CurrentLeaveDate = leave.LeaveDate.Date;
                        employee.CurrentLeaveStartDate = leave.StartDate.Date;
                        employee.CurrentLeaveEndDate = leave.EndDate.Date;

                        dal.Update(employee);
                        dal.Save(leave);
                    }
                    Clear();
                }
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
                //var studyLeave = GlobalData._context.StaffLeaves.FirstOrDefault(u=>u.StaffID == leave.Employee.StaffID && u.EndDate < leave.StartDate);

                staffErrorProvider.Clear();
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }

                if (cboStudyLeaveType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboStudyLeaveType, "Please select a leave type");
                }

                if (dateStartDate.Value >= dateEndDate.Value)
                {
                    result = false;
                    staffErrorProvider.SetError(dateEndDate, "Start date can not be greater than end date");
                }

                if (dateReportingDate.Value >= dateEndDate.Value)
                {
                    result = false;
                    staffErrorProvider.SetError(dateReportingDate, "Reporting date can not be greater than end date");
                }

                if (cboPayment.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboPayment, "Kindly select a type of funding from the facility");
                }

                if (txtInstitution.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtInstitution, "Kindly specify the institution");
                }

                if (txtProgramme.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtProgramme, "Kindly specify the area of study");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void Assign()
        {
            leave.ID = leaveID;
            leave.LeaveType = "Study Leave";
            leave.Employee.StaffID = staffIDtxt.Text.Trim();
            leave.Employee.ID = staffCode;
            leave.StaffName = nametxt.Text.Trim();
            leave.Status = "Requested";
            leave.StartDate = dateStartDate.Value;
            leave.EndDate = dateEndDate.Value;
            leave.LeaveDate = dateReportingDate.Value;
            leave.NumberOfDays = numericDurationyears.Value;
            leave.User.ID = GlobalData.User.ID;
            leave.Reason = txtReason.Text.Trim();
            leave.Institution = txtInstitution.Text.Trim();
            leave.Programme = txtProgramme.Text.Trim();
            leave.LeaveYear = (txtAnnualLeaveYear.Text != string.Empty) ? int.Parse(txtAnnualLeaveYear.Text) : 0;
            leave.Funding = cboPayment.Text;
            leave.ProgramType = cboStudyLeaveType.Text;
        }

        private void btnView_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
