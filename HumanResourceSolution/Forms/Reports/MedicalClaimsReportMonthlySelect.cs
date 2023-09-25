using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Claims_Leave_Hire_Purchase_CLASS;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;

namespace eMAS.Forms.Reports
{
    public partial class MedicalClaimsReportMonthlySelect : Form
    {
        private IList<Employee> employees;
        private IDAL dal;
        private IList<PayRollAttendance> payRollAttendances;
        private PayRollAttendance payRollAttendance;
        private Form reportForm;
        private Company company;
        private int ctr;
        private bool mechanised;

        public MedicalClaimsReportMonthlySelect()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.company = new Company();
                this.ctr = 0;
                this.mechanised = false;
                this.employees = new List<Employee>();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.payRollAttendance = new PayRollAttendance();
                this.payRollAttendances = new List<PayRollAttendance>();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void medicalClaimsReportSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                company = dal.GetAll<Company>()[0];
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
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
                if (searchGrid.CurrentRow != null)
                {
                    txtStaffNo.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    txtStaffName.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text == "All Employees")
                {
                    staffNoLabel.Visible = false;
                    nameLabel.Visible = false;
                    txtStaffName.Visible = false;
                    txtStaffNo.Visible = false;
                    searchGrid.Visible = false;
                    lblMechanised.Visible = true;
                    cboMechanised.Visible = true;
                }
                else
                {
                    staffNoLabel.Visible = true;
                    nameLabel.Visible = true;
                    txtStaffName.Visible = true;
                    txtStaffNo.Visible = true;
                    searchGrid.Visible = true;
                    lblMechanised.Visible = false;
                    cboMechanised.Visible = false;
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
                if (cmbOption.Text.Trim() == "Individual Employee")
                {
                    if (txtStaffName.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(txtStaffName, "Please enter Name of Staff");
                        txtStaffName.Focus();
                    }
                    if (txtStaffNo.Text.Trim() == string.Empty)
                    {
                        result = false;
                        staffErrorProvider.SetError(txtStaffNo, "Please enter a staffID");
                        txtStaffNo.Focus();
                    }
                }
                if (monthComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(monthComboBox, "Please Select the Month");
                    monthComboBox.Focus();
                }
                if (yearComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(yearComboBox, "Please Select the Year");
                    yearComboBox.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbOption.Text.Trim() == "Individual Employee")
                {
                    if (ValidateFields())
                    {
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.StaffID",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = txtStaffNo.Text.Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        if(monthComboBox.Text.Trim() != string.Empty && monthComboBox.Text.ToLower().Trim()!="all")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryPaymentView.Month",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = int.Parse(GlobalData.GetMonth(monthComboBox.Text.Trim()).ToString()),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        if (yearComboBox.Text.Trim() != string.Empty && yearComboBox.Text.ToLower().Trim() != "all")
                        {
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "StaffSalaryPaymentView.Year",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = int.Parse(yearComboBox.Text.Trim()),
                                CriteriaOperator = CriteriaOperator.And
                            });
                        }
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.MedicalClaims",
                            CriterionOperator = CriterionOperator.GreaterThan,
                            Value = 0,
                            CriteriaOperator = CriteriaOperator.None
                        });
                        payRollAttendances = dal.GetByCriteria<PayRollAttendance>(query);
                        if (payRollAttendances.Count <= 0)
                        {
                            MessageBox.Show("The selected Staff's payroll/Medical Claims is not processed");
                        }
                        else
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            reportForm = new MedicalClaimsReportMonthlyForm(txtStaffNo.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                    }
                }
                else
                {
                    reportForm = new MedicalClaimsReportMonthlyForm(txtStaffNo.Text.Trim(), monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboMechanised.Text.Trim());
                    reportForm.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    staffErrorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    employees=dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(txtStaffName.Text.Trim().ToLower()))
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
                        searchGrid.Location = new Point(txtStaffName.Location.X, txtStaffName.Location.Y + 21);
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
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
        }

        private void txtStaffNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffNo.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }

                    if (txtStaffNo.Text.Length >= company.MinimumCharacter)
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
                            Value = txtStaffNo.Text.Trim() + '%',
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
                                if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffNo.Text.Trim().ToLower()))
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
                                searchGrid.Location = new Point(txtStaffNo.Location.X, txtStaffNo.Location.Y + 21);
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
                            MessageBox.Show("Employee with StaffID " + txtStaffNo.Text.Trim() + " is not Found");
                            txtStaffNo.Text = string.Empty;
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

        private void Clear()
        {
            try
            {
                txtStaffName.Clear();
                txtStaffNo.Clear();
                txtStaffName.BringToFront();
                txtStaffNo.BringToFront();
                yearComboBox.Items.Clear();
                yearComboBox.Text = string.Empty;
                monthComboBox.Items.Clear();
                monthComboBox.Text = string.Empty;
                searchGrid.Rows.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:The form cannot clear,See the System Administrator");
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
                MessageBox.Show("Error:The form cannot close");
            }
        }

        private void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                monthComboBox.Items.Add("All");
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";

                    foreach (string item in GlobalData.GetMonths())
                    {
                        monthComboBox.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        monthComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                yearComboBox.Items.Add("All");
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void cboMechanised_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMechanised.Text.Trim() == "Yes")
                {
                    mechanised = true;
                }
                else if (cboMechanised.Text.Trim() == "No")
                {
                    mechanised = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
