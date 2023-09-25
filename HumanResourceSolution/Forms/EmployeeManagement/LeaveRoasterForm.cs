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


namespace eMAS.Forms.EmployeeManagement
{
    public partial class LeaveRoasterForm : Form
    {
        private IDAL dal;
        private StaffLeaveRoaster staffLeaveRoaster;
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

        public LeaveRoasterForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.staffLeaveRoaster = new StaffLeaveRoaster();
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
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void leaveTypecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                leaveTypecmb.Items.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "LeaveTypeView.Active",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = true,
                    CriteriaOperator = CriteriaOperator.None
                });
                leaveTypes=dal.GetByCriteria<LeaveType>(query);
                foreach (LeaveType leaveType in leaveTypes)
                {
                    leaveTypecmb.Items.Add(leaveType.Description);
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditLeave(StaffLeaveRoaster staffLeaveRoaster)
        {
            try
            {
                Clear();
                editMode = true;
                leaveID = staffLeaveRoaster.ID;
                staffIDtxt.Text = staffLeaveRoaster.Employee.StaffID;
                staffCode = staffLeaveRoaster.Employee.ID;
                nametxt.Text = staffLeaveRoaster.StaffName;
                gendertxt.Text = staffLeaveRoaster.Employee.Gender;
                agetxt.Text = staffLeaveRoaster.Employee.Age;
                departmentTextBox.Text = staffLeaveRoaster.Employee.Department.Description;
                txtLeaveDue.Text = staffLeaveRoaster.Employee.AnnualLeave.ToString();
                txtAnnualLeaveYear.Text = staffLeaveRoaster.Employee.AnnualLeaveYear.ToString();
                txtLeaveArrears.Text = (staffLeaveRoaster.Employee.LeaveArrears + staffLeaveRoaster.NumberOfDays).ToString();
                leaveDays = staffLeaveRoaster.NumberOfDays;

                leaveTypecmb_DropDown(this,EventArgs.Empty);
                leaveTypecmb.Text = staffLeaveRoaster.LeaveType;
                numericUpDownNumberOfDays.Value = staffLeaveRoaster.NumberOfDays;
                startDate.Text = staffLeaveRoaster.StartDate.ToString();
                endDate.Text = staffLeaveRoaster.EndDate.ToString();
                leaveDate.Text = staffLeaveRoaster.LeaveDate.ToString();
                groupBox1.Enabled = true;
                searchGrid.Visible = false;
                label1.Text = "Edit Leave";
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != staffLeaveRoaster.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
            catch(Exception ex)
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
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please Enter The Staff");
                }
                if (leaveTypecmb.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please select a leave type");
                }
                if (numericUpDownNumberOfDays.Value > dal.GetByDescription<LeaveType>(leaveTypecmb.Text.Trim()).MaximumEntitlement)
                {
                    result = false;
                    staffErrorProvider.SetError(leaveTypecmb, "Please Number of Days Cannot be greater than the Maximum Days");
                }
                if (numericUpDownNumberOfDays.Value > decimal.Parse(txtLeaveArrears.Text.Trim()))
                {
                    result = false;
                    staffErrorProvider.SetError(txtLeaveArrears, "Please The Staff is Left with " + txtLeaveArrears.Text.Trim() + "Days");
                }
                if (decimal.Parse(txtLeaveDue.Text.Trim()) <= 0 || int.Parse(txtAnnualLeaveYear.Text.Trim()) != DateTime.Today.Year)
                {
                    result = false;
                    staffErrorProvider.SetError(txtLeaveDue, "Please Calculate the Annual Leave For the Staff For this Year,It is run yearly ");
                }
                if (startDate.Value.Date > endDate.Value.Date)
                {
                    result = false;
                    staffErrorProvider.SetError(startDate, "The start date of the leave cannot be greater than the end date");
                }
                if (numericUpDownNumberOfDays.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfDays, "Number Of Days Cannot be Zero");
                }
            }
            catch(Exception ex)
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
                    Assign();
                    if (editMode)
                    {
                        employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                        employee.AnnualLeaveProposedStartDate = staffLeaveRoaster.StartDate.Date;
                        employee.AnnualLeaveProposedEndDate = staffLeaveRoaster.EndDate.Date;
                        employee.AnnualLeaveProposedDays = int.Parse(staffLeaveRoaster.NumberOfDays.ToString());
                        dal.Update(employee);
                        staffLeaveRoaster.ID = leaveID;
                        dal.Update(staffLeaveRoaster);
                        Clear();
                    }
                    else
                    {
                        employee = dal.GetByID<Employee>(staffIDtxt.Text.Trim());
                        employee.AnnualLeaveProposedStartDate = staffLeaveRoaster.StartDate.Date;
                        employee.AnnualLeaveProposedEndDate = staffLeaveRoaster.EndDate.Date;
                        employee.AnnualLeaveProposedDays = int.Parse(staffLeaveRoaster.NumberOfDays.ToString());
                        dal.Update(employee);
                        dal.Save(staffLeaveRoaster);
                        Clear();
                    }
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
                MessageBox.Show("Error:Not saved successfully,Please See the system Administrator");
            }
        }

        #region ASSINGNMENTS
        private void Assign()
        {
            try
            {
                staffLeaveRoaster.ID = leaveID;
                staffLeaveRoaster.Employee.StaffID = staffIDtxt.Text.Trim();
                staffLeaveRoaster.Employee.ID = staffCode;
                staffLeaveRoaster.StaffName = nametxt.Text.Trim();
                staffLeaveRoaster.LeaveType = leaveTypecmb.Text.Trim();
                staffLeaveRoaster.StartDate = startDate.Value;
                staffLeaveRoaster.EndDate = endDate.Value;
                staffLeaveRoaster.LeaveDate = leaveDate.Value;
                staffLeaveRoaster.NumberOfDays = numericUpDownNumberOfDays.Value;
                staffLeaveRoaster.User.ID = GlobalData.User.ID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
                gendertxt.Clear();
                agetxt.Clear();
                leaveTypecmb.Text = string.Empty;
                startDate.ResetText();
                startDate.Checked=false;
                endDate.ResetText();
                endDate.Checked=false;
                leaveDate.Value = DateTime.Today.Date;
                txtLeaveDue.Text = string.Empty;
                txtAnnualLeaveYear.Clear();
                txtLeaveArrears.Clear();
                leaveID = 0;
                editMode = false;
                label1.Text = "New Leave";
                groupBox1.Enabled = false;
                pictureBox.Image = pictureBox.InitialImage;
                searchGrid.Visible = false;
                departmentTextBox.Clear();
                staffErrorProvider.Clear();
                leaveTypecmb.Items.Clear();
                leaveTypecmb.Text = string.Empty;
                numericUpDownNumberOfDays.Value = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

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
                            pictureBox.Image = employee.Photo;
                            agetxt.Text = employee.Age;
                            searchGrid.Visible = false;
                            groupBox1.Enabled = true;
                            leaveTypecmb.Select();
                            departmentTextBox.Text = employee.Department.Description;
                            txtLeaveDue.Text = employee.AnnualLeave.ToString();
                            txtLeaveArrears.Text = employee.LeaveArrears.ToString();
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

        private void StaffLeaveRoaster_Load(object sender, EventArgs e)
        {
            try
            {
                groupBox1.Enabled = false;
                this.Text = GlobalData.Caption;
                staffIDtxt.Select();
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()));
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
				
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
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
                Clear();
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
                LeaveRoasterView form = new LeaveRoasterView(this);
                form.MdiParent = this.MdiParent;
                form.Show();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    if (reportForm != null && !reportForm.IsDisposed)
                    {
                        reportForm.Close();
                    }
                    reportForm = new LeaveRequestApplicationForm(staffIDtxt.Text, leaveTypecmb.Text, startDate.Value, endDate.Value, numericUpDownNumberOfDays.Value);
                    reportForm.Show();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Cannot Preview,Please See the system Administrator");
            }
        }

        public void getDays()
        {
            try
            {
                decimal result = decimal.Parse((endDate.Value.Subtract(startDate.Value).Days).ToString());
                numericUpDownNumberOfDays.Value = (result == 0) ? 1 : (decimal.Ceiling(result) > 0 ? decimal.Ceiling(result) : -1 * decimal.Ceiling(result));
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        DateTime AddBusinessDays(int noofDays, DateTime dtCurrent)
        {
            DateTime tempdt = new DateTime(dtCurrent.Year, dtCurrent.Month, dtCurrent.Day);
            try
            {
                var holidays = new List<DateTime>() { new DateTime(2014, 12, 25), new DateTime(2014, 10, 28) };

                // if starting day is non working day adjust to next working day
                tempdt = ExcludeNotWorkingDay(tempdt, holidays);

                // if starting day is non working day adjust to next working day then minus 1 day in noofadding days
                if (tempdt.Date > dtCurrent.Date && !(noofDays == 0))
                    noofDays = noofDays - 1;

                while (noofDays > 0)
                {
                    tempdt = tempdt.AddDays(1);
                    // if day is non working day adjust to next working day
                    tempdt = ExcludeNotWorkingDay(tempdt, holidays);
                    noofDays = noofDays - 1;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return tempdt;
        }

        DateTime ExcludeNotWorkingDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            while (!IsWorkDay(dtCurrent, holidays))
            {
                dtCurrent = dtCurrent.AddDays(1);
            }
            return dtCurrent;
        }

        bool IsWorkDay(DateTime dtCurrent, List<DateTime> holidays)
        {
            if ((dtCurrent.DayOfWeek == DayOfWeek.Saturday || dtCurrent.DayOfWeek == DayOfWeek.Sunday || holidays.Contains(dtCurrent)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void numericUpDownNumberOfDays_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString())-1);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                endDate.Value = startDate.Value.AddDays(double.Parse(numericUpDownNumberOfDays.Value.ToString()) - 1);
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

