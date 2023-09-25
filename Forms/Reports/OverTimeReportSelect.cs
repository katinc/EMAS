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
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.Reports
{
    public partial class OverTimeReportSelect : Form
    {
        private IDAL dal;
        private Company company;
        private IList<Employee> employees;
        private DALHelper dalHelper;
        private IList<OverTimeType> overTimeTypes;
        private Form reportForm;


        public OverTimeReportSelect()
        {
            InitializeComponent();
            try
            {
                this.dal = new DAL();
                this.company = new Company();
                this.dalHelper = new DALHelper();
                this.overTimeTypes = new List<OverTimeType>();
                this.reportForm = new Form();

            }
            catch (Exception xi) {
                Logger.LogError(xi);
            }
           
        }

        private void OverTimeReportSelect_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (reportForm != null && !reportForm.IsDisposed)
                {
                    reportForm.Close();
                }

                reportForm = new OverTimeReportForm(txtStaffNo.Text.Trim(), datePickerFrom.Checked, datePickerTo.Checked, 
                                                   datePickerFrom.Value, datePickerTo.Value, cmbType.Text.Trim());
                reportForm.Show();

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

        private void cmbOption_DropDown(object sender, EventArgs e)
        {

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
                        errorProvider1.SetError(txtStaffName, "Please enter Name of Staff");
                        txtStaffName.Focus();
                    }
                    if (txtStaffNo.Text.Trim() == string.Empty)
                    {
                        result = false;
                        errorProvider1.SetError(txtStaffNo, "Please enter a staffID");
                        txtStaffNo.Focus();
                    }
                }
                if (datePickerTo.Checked == false || datePickerFrom.Checked==false)
                {
                    result = false;
                    errorProvider1.SetError(datePickerFrom, "Please Check Both  Starting and End Date");
                    datePickerTo.Focus();
                }
               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
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
                        errorProvider1.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                       int ctr = 0;
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
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        private void ClearStaffInfo()
        {
            try
            {
                txtStaffNo.Clear();
                txtStaffName.Clear();
                searchGrid.Rows.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtStaffName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffName.Text.Trim() != string.Empty)
                {
                    errorProvider1.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    dal.CloseConnection();
                    employees = dal.LazyLoad<Employee>();
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
                    ClearStaffInfo();
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
                if (searchGrid.CurrentRow != null)
                {
                    dal.CloseConnection();
                    employees = dal.LazyLoad<Employee>();
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            txtStaffName.Text = name;
                            txtStaffNo.Text = employee.StaffID;
                            searchGrid.Visible = false;

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
            try
            {
                ClearStaffInfo();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cmbOption_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cmbOption.Text == "Individual Employee")
            {
                nameLabel.Visible = true;
                staffNoLabel.Visible = true;
                txtStaffName.Visible = true;
                txtStaffNo.Visible = true;
                //searchGrid.Visible = false;
            }
            else
            {
                nameLabel.Visible = false;
                staffNoLabel.Visible = false;
                txtStaffName.Visible = false;
                txtStaffNo.Visible = false;
                searchGrid.Visible = false;
            }
        }

        private void cmbType_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbType.Items.Clear();
                overTimeTypes = dal.GetAll<OverTimeType>();
                cmbType.Items.Add("ALL");
                foreach (var overTimeType in overTimeTypes)
                {
                    cmbType.Items.Add(overTimeType.Description.Trim());
                }
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }

        //private void cboMechanised_DropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        cboMechanised.Items.Clear();
        //        cboMechanised.Text = string.Empty;
        //        cboMechanised.Items.Add("All");
        //        cboMechanised.Items.Add("Yes");
        //        cboMechanised.Items.Add("No");
        //    }
        //    catch (Exception ex)
        //    {
        //        Logger.LogError(ex);
        //    }
        //}
    }
}
