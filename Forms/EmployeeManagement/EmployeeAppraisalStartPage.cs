using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using eMAS.Forms.StaffInformation;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms
{
    public partial class EmployeeAppraisalStartPage : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private DataTable typeTable;
        private object gradeID;
        private IList<Employee> employees;
        private bool ass;

        public EmployeeAppraisalStartPage()
        {
            try
            {
                InitializeComponent();
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
                this.typeTable = new DataTable();
                this.employees=new List<Employee>();
                this.ass = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (txtAssessor.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(txtAssessor, "Please Enter the Name of the Assessor");
                    txtAssessor.Focus();
                }
                else if (cboAssessmentMonth.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboAssessmentMonth, "Please select the Month");
                    cboAssessmentMonth.Focus();
                }
                else if (cboAssessmentYear.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(cboAssessmentYear, "Please select the Year");
                    cboAssessmentYear.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        void typeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                typeComboBox.Items.Clear();
                if (empNoTextBox.Text.Trim() != string.Empty)
                {
                    dal.OpenConnection();
                    if(employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
                    gradeID = dalHelper.ExecuteScalar("select StaffPersonalInfo.GradeID  from StaffPersonalInfo where StaffID ='" + empNoTextBox.Text + "'");
                    if (gradeID != null)
                    {
                        typeTable = dalHelper.ExecuteReader("Select Distinct AppraisalForms.TypeID as ID,AppraisalTypes.Description From AppraisalForms Inner Join AppraisalTypes on AppraisalForms.TypeID = AppraisalTypes.ID Where AppraisalForms.GradeID = " + gradeID.ToString() + " And AppraisalForms.Archived='False'");
                        if (typeTable.Rows.Count > 0)
                        {
                            label4.Visible = false;
                            foreach (DataRow row in typeTable.Rows)
                            {
                                typeComboBox.Items.Add(row["Description"].ToString());
                            }
                        }
                        else
                        {
                            label4.Visible = true;
                            label4.Text = "You are not yet due for any appraisal. Please contact the HR Manager for further enquiries";
                        }
                    }
                    else
                    {
                        errorProvider.SetError(empNoTextBox, "invalid employee no");
                        label4.Visible = false;
                    }
                }
                else
                {
                    errorProvider.SetError(empNoTextBox, "Please enter your employee no");
                    label4.Visible = false;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void EmployeeAppraisalStartPage_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    if (empNoTextBox.Text.Trim() != string.Empty && typeComboBox.Text.Trim() != string.Empty)
                    {
                        foreach (Employee employee in employees)
                        {
                            if (employee.StaffID.Trim().ToLower() == empNoTextBox.Text.Trim().ToLower())
                            {
                                EmployeeAppraisal form = new EmployeeAppraisal(employee, gradeID.ToString(), typeTable.Rows[typeComboBox.SelectedIndex]["ID"].ToString(),txtAssessor.Text,cboAssessmentMonth.Text,cboAssessmentYear.Text);
                                form.MdiParent = this.MdiParent;
                                form.Show();
                                this.Close();
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

        private void empNoTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (empNoTextBox.Text.Trim() != string.Empty)
                {
                    typeComboBox.Items.Clear();
                    typeComboBox.Text = string.Empty;
                    errorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    if (employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (employee.StaffID.Trim().ToLower().StartsWith(empNoTextBox.Text.Trim().ToLower()))
                        {
                            found = true;
                            ass = false;
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
                        searchGrid.Location = new Point(empNoTextBox.Location.X, empNoTextBox.Location.Y + 22);
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
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider.Clear();
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
                    Clear();
                    if (employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }

                    foreach (Employee employee in employees)
                    {
                        if (employee.StaffID.Trim() == searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString().Trim())
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            if(ass)
                            {
                                txtAssessor.Clear();
                                txtAssessor.Text = name;
                            }
                            else
                            {
                                empNoTextBox.Clear();
                                empNoTextBox.Text = employee.StaffID.ToString().Trim();
                            }
                            searchGrid.Visible = false;
                            ass = false;
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

        private void Clear()
        {
            try
            {
                errorProvider.Clear();
                searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void cboAssessmentMonth_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAssessmentMonth.Items.Clear();
                foreach (string item in GlobalData.GetMonthsToDate())
                {
                    cboAssessmentMonth.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboAssessmentYear_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboAssessmentYear.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    cboAssessmentYear.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void txtAssessor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAssessor.Text.Trim() != string.Empty)
                {
                    errorProvider.Clear();
                    searchGrid.Rows.Clear();
                    searchGrid.BringToFront();
                    int ctr = 0;
                    bool found = false;
                    if (employees.Count <= 0)
                    {
                        employees = dal.LazyLoad<Employee>();
                    }
                    foreach (Employee employee in employees)
                    {
                        string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                        if (name.Trim().ToLower().StartsWith(txtAssessor.Text.Trim().ToLower()))
                        {
                            found = true;
                            ass = true;
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
                        searchGrid.Location = new Point(txtAssessor.Location.X, txtAssessor.Location.Y + 60);
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

    }
}
