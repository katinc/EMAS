using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;

namespace eMAS.Forms.Reports
{
    public partial class StaffLeaveBalanceSelect : Form
    {
        private IDAL dal;
        private IList<Department> departments;
        private IList<Unit> units;
        private Company company;
        private DALHelper dalHelper;

        private int ctr;
        private bool mechanised;
        private IList<Employee> employees;
        public StaffLeaveBalanceSelect()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.departments = new List<Department>();
            this.units = new List<Unit>();
            this.dalHelper = new DALHelper();
            this.company = new Company();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                //monthComboBox.Items.Add("All");

                foreach (string item in GlobalData.GetMonths())
                {
                    monthComboBox.Items.Add(item);
                }
            }
            catch (Exception xi) { }
        }

        private void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_DropDown()
        {
            try
            {
                cboDepartment.Items.Clear();
                cboDepartment.Text = string.Empty;
                cboDepartment.Items.Add("All");
                departments = dal.GetAll<Department>();

                foreach (Department department in departments)
                {
                    cboDepartment.Items.Add(department.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                cboUnit.Items.Clear();
                cboUnit.Text = string.Empty;
                query.Criteria.Add(new Criterion()
                {
                    Property = "UnitView.Department",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = cboDepartment.SelectedItem,
                    CriteriaOperator = CriteriaOperator.And
                });
                cboUnit.Items.Add("All");
                units = dal.GetByCriteria<Unit>(query);
                foreach (Unit unit in units)
                {
                    cboUnit.Items.Add(unit.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMechanised_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMechanised.Items.Clear();
                cboMechanised.Text = string.Empty;
                cboMechanised.Items.Add("All");
                cboMechanised.Items.Add("Yes");
                cboMechanised.Items.Add("No");
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
            catch (Exception xi)
            {

            }
        }
        private void Clear()
        {
            try
            {
                nametxt.Clear();
                staffIDtxt.Clear();
                searchGrid.Visible = false;
                staffErrorProvider.Clear();
                dalHelper.CloseConnection();
                dal.CloseConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            int monthEnd = 0;
            if (cbMonthEnd.Checked)
            {
                monthEnd = 1;
            }

            

            StaffLeaveBalanceReportForm form = new StaffLeaveBalanceReportForm(staffIDtxt.Text ,cboDepartment.Text, cboUnit.Text, cboMechanised.Text, yearComboBox.Text, monthComboBox.Text, staffIDtxt.Text, monthEnd);
            form.Show();
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (nametxt.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (nametxt.Text.Length >= company.MinimumCharacter)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Reset not completed");
            }
        }

        private void Reset()
        {
            try
            {
                monthComboBox.Items.Add(((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString());
                monthComboBox.Text = ((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString();
                yearComboBox.Items.Add(GlobalData.ServerDate.Year.ToString());
                yearComboBox.Text = GlobalData.ServerDate.Year.ToString();
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void StaffLeaveBalanceSelect_Load(object sender, EventArgs e)
        {
            cboDepartment_DropDown();
        }

        private void searchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (searchGrid.CurrentRow != null)
                {
                    staffIDtxt.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    nametxt.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
