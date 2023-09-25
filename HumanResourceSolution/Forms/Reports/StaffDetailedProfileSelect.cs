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
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class StaffDetailedProfileSelect : Form
    {
        private IList<Employee> employees;
        private IDAL dal;
        private Form reportForm;
        private Company company;
        private int ctr;

        public StaffDetailedProfileSelect()
        {           
            try
            {
                InitializeComponent();
                this.employees = new List<Employee>();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.company = new Company();
                this.ctr = 0;
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
                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            nametxt.Text = name;
                            staffIDtxt.Text = employee.StaffID;
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


        private void StaffDetailedProfileSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                searchGrid.Rows.Clear();
                nametxt.Clear();
                staffIDtxt.Clear();
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
                if (nametxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(nametxt, "Please enter Name of Staff");
                    nametxt.Focus();
                }
                if (staffIDtxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(staffIDtxt, "Please enter a staffID");
                    staffIDtxt.Focus();
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
                if (ValidateFields())
                {
                    if (checkBox1.Checked)
                    {
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                        }
                        reportForm = new StaffDetailedProfile(staffIDtxt.Text);
                        reportForm.Show();
                    }
                    else
                    {
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                        }
                        reportForm = new StaffDetailedProfile(staffIDtxt.Text);
                        reportForm.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void ClearStaffInfo()
        {
            try
            {
                staffIDtxt.Clear();
                nametxt.Clear();
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
                    if(employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
                    
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
                    ClearStaffInfo();
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
                    ClearStaffInfo();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }

    }
}
