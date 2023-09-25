using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayerBase;
using HRBussinessLayer.Validation;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class ArrearsNew : Form
    {
        private Arrears arrearsInfo;
        private Employee employee;
        private IList<Employee> employees;
        private IList<Employee> employeeList;
        private Company company;
        private IDAL dal;
        private bool editMode;
        private int arrearsID;
        private int ctr;
        private int staffCode;
        public bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public ArrearsNew()
        {
            try
            {
                InitializeComponent();
                this.company = new Company();
                this.arrearsInfo = new Arrears();
                this.employee = new Employee();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.editMode = false;
                this.ctr = 0;
                this.arrearsID = 0;
                this.staffCode = 0;
                this.employees = new List<Employee>();
                this.employeeList = new List<Employee>();
                this.company = new Company();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }   
        }

        public Arrears Arrear
        {
            set
            {
                Clear();
                label5.Text = "Edit Arrears Information Form";
                editMode = true;
                arrearsID = value.ID;
                searchGrid.Visible = false;
                groupBox1.Enabled = true;
                //Staff Details
                if (value.Employee.Photo != null)
                {
                    pictureBox.Image = value.Employee.Photo;
                }
                else
                {
                    pictureBox.Image = pictureBox.InitialImage;
                }
                staffIDtxt.Text = value.Employee.StaffID;
                staffCode = value.Employee.ID;
                nametxt.Text = value.Employee.FirstName;
                gendertxt.Text = value.Employee.Gender;
                agetxt.Text = value.Employee.Age;

                cboType_DropDown(this,EventArgs.Empty);
                cboType.Text = value.Type;
                numericUpDownPreviousSalary.Value = value.PreviousSalary;
                numericUpDownCurrentSalary.Value = value.CurrentSalary;
                numericUpDownNumberOfTimes.Value = value.NumberOfTimes;

                datePickerEffectiveDate.Text = value.EffectiveDate.ToString();
                checkBoxSSNIT.Checked = value.SSNIT;
                checkBoxIncomeTax.Checked = value.IncomeTax;
                inUseCheckBox.Checked = value.In_Use;
                txtReason.Text = value.Reason;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != value.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
        }

        private void staffIDtxt_Leave(object sender, EventArgs e)
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

        private void nametxt_Leave(object sender, EventArgs e)
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

        private void ArrearsNew_Load(object sender, EventArgs e)
        {
            try
            {
                //GlobalData.assignControls(this);
                this.Text = GlobalData.Caption;
                Clear();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel2Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    findbtn.Enabled = getPermissions.CanView;
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

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
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
                            numericUpDownPreviousSalary.Value = employee.OldBasicSalary;
                            numericUpDownCurrentSalary.Value = employee.BasicSalary;

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
                            btnPreView_Click(sender, e);
                        }
                    }
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
                ClearStaffInfo();
                searchGrid.Visible = false;
                editMode = false;
                numericUpDownPreviousSalary.Value = 0;
                numericUpDownCurrentSalary.Value = 0;
                numericUpDownNumberOfTimes.Value = 1;
                cboType.Items.Clear();
                cboType.Text = string.Empty;
                checkBoxIncomeTax.Checked = false;
                checkBoxSSNIT.Checked = false;
                inUseCheckBox.Checked = false;
                datePickerEffectiveDate.ResetText();
                txtReason.Clear();
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
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
                groupBox1.Enabled = false;
                staffIDtxt.Select();
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    UpdateArrearsInfo();
                    if (editMode)
                    {
                        dal.Update(arrearsInfo);
                    }
                    else
                    {
                        dal.Save(arrearsInfo);
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
                if (cboType.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(cboType, "Please enter the Type");
                }
                if (numericUpDownPreviousSalary.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownPreviousSalary, "Please enter the Previous Salary");
                }
                if (numericUpDownNumberOfTimes.Value <= 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownNumberOfTimes, "Please Number of Times cannot be Zero");
                }
                if (cboType.Text.ToLower().Trim() == "promotional" && numericUpDownCurrentSalary.Value == 0)
                {
                    result = false;
                    staffErrorProvider.SetError(numericUpDownCurrentSalary, "Please enter the Current Salary");
                }
                if (datePickerEffectiveDate.Checked == false)
                {
                    result = false;
                    staffErrorProvider.SetError(datePickerEffectiveDate, "Please Select the Effective Date");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void UpdateArrearsInfo()
        {
            try
            {
                if (editMode)
                {
                    arrearsInfo.ID = arrearsID;
                }
                employee.StaffID = staffIDtxt.Text.Trim();
                employee = dal.LazyLoadByStaffID<Employee>(employee);
                arrearsInfo.Employee.StaffID = employee.StaffID;
                arrearsInfo.Employee.ID = employee.ID;
                arrearsInfo.PreviousSalary = numericUpDownPreviousSalary.Value;
                arrearsInfo.CurrentSalary = numericUpDownCurrentSalary.Value;
                arrearsInfo.NumberOfTimes = int.Parse(numericUpDownNumberOfTimes.Value.ToString());
                arrearsInfo.Type = cboType.Text.Trim();
                arrearsInfo.In_Use = inUseCheckBox.Checked;
                arrearsInfo.SSNIT = checkBoxSSNIT.Checked;
                arrearsInfo.IncomeTax = checkBoxIncomeTax.Checked;
                arrearsInfo.EffectiveDate = (new DateTime(datePickerEffectiveDate.Value.Year, datePickerEffectiveDate.Value.Month, 1));
                arrearsInfo.Reason = txtReason.Text.Trim();
                arrearsInfo.User.ID = GlobalData.User.ID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnPreView_Click(object sender, EventArgs e)
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

        private void findbtn_Click(object sender, EventArgs e)
        {
            try
            {
                ArrearsView arrearsView = new ArrearsView(dal, this);
                arrearsView.MdiParent = this.MdiParent;
                arrearsView.removeButton.Enabled = CanDelete;
                arrearsView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboType.Items.Clear();
                cboType.Items.Add("Promotional");
                cboType.Items.Add("Normal");
                cboType.Items.Add("Allowance");
                cboType.Items.Add("Other");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboType.Text.ToLower().Trim() == "normal")
                {
                    lblPrevSalary.Text = "Amount:";
                    lblCurSalary.Visible = false;
                    numericUpDownCurrentSalary.Visible = false;
                }
                else if (cboType.Text.ToLower().Trim() == "promotional")
                {
                    lblPrevSalary.Text = "Prev. Salary:";
                    lblCurSalary.Visible = true;
                    numericUpDownCurrentSalary.Visible = true;
                }
                else
                {
                    lblPrevSalary.Text = "Amount:";
                    lblCurSalary.Visible = false;
                    numericUpDownCurrentSalary.Visible = false;
                }
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
    }
}
