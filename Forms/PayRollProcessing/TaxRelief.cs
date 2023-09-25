using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRDataAccessLayer.System_Setup_Data_Control;
using System.Threading;
using Microsoft.VisualBasic;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer.Payroll_Processing_Data_Control;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class TaxRelief : Form
    {
        IDAL dal;
        IList<Department> departments;
        Company company;
        int ctr;
        public Permissions permissions;
        public TaxRelief()
        {
            InitializeComponent(); 
            dal = new DAL();
            departments = new List<Department>();
            company = new CompanyDataMapper().GetAll().FirstOrDefault();
            this.ctr = 0;
        }

        private void cmbDepartment_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbDepartment.DataSource = null;
                cmbDepartment.Items.Clear();
                var departments = GlobalData._context.DDepartments.Where(u => u.Active == true).ToList();
                cmbDepartment.Items.Add("ALL");

                foreach (var item in departments)
                {
                    cmbDepartment.Items.Add(item.Description);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void PopulateGrid(List<DataReference.StaffPersonalInfoView> employees)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (var staff in employees)
                {
                    grid.Rows.Add(1);
                    //grid.Rows[ctr].Cells["gridID"].Value = userCategoryRole.ID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = staff.StaffID;
                    grid.Rows[ctr].Cells["gridStaffName"].Value = staff.Firstname + " " + staff.OtherName + " " + staff.Surname;
                    grid.Rows[ctr].Cells["gridBasicSalary"].Value = staff.BasicSalary;
                    grid.Rows[ctr].Cells["gridReliefAmount"].Value = staff.CurrentTaxRelief;

                    grid.Rows[ctr].Cells["gridMonth"].Value = periodComboBox.Text;
                    grid.Rows[ctr].Cells["gridYear"].Value = yearComboBox.Text;

                    //grid.Rows[ctr].Cells["gridMonth"].Value = GlobalData.GetMonth(Convert.ToInt32(staff.CurrentTaxReliefMonth));
                    //grid.Rows[ctr].Cells["gridYear"].Value = staff.CurrentTaxReliefYear.ToString();
                    //if (staff.CurrentTaxReliefYear != null)
                    //{
                    //    grid.Rows[ctr].Cells["gridYear"].ReadOnly = true;
                    //}
                    ctr++;
                }
                
                

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void GetData()
        {
            try
            {
                grid.Rows.Clear();
                this.ctr = 0;
                List<DataReference.StaffPersonalInfo> staff = new List<DataReference.StaffPersonalInfo>();

                var employees = GlobalData._context.StaffPersonalInfoViews.
                    Where(u => !u.Archived && !u.Terminated && !u.TransferredOut && 
                    (u.Department.Contains(cmbDepartment.Text) || u.Department == "")).OrderBy(u=>u.StaffID).ToList();

                PopulateGrid(employees);
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        private void GetYears(){
            try
            {
                gridYear.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    gridYear.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void TaxRelief_Load(object sender, EventArgs e)
        {
            try
            {

                GetYears();
                getMonths();

                permissions = GlobalData.CheckPermissions(2);
                savebtn.Enabled = permissions.CanAdd;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void getPayPeriods()
        {
            try
            {
                // company = dal.GetAll<Company>();
                if (company.PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                    periodComboBox.Items.Clear();
                    foreach (string item in GlobalData.GetMonths())
                    {
                        periodComboBox.Items.Add(item);
                    }
                }
                else
                {
                    periodComboBox.Items.Clear();
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        periodComboBox.Items.Add("Week " + i.ToString());
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
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
                //yearComboBox.Items.Add(DateTime.Now.Date.Year);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool Validate(){

            return true;
        }

        bool saveFlag = false;
        bool updateFlag = false;
        string flagStr = string.Empty;
        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate())
                {
                    foreach (DataGridViewRow row in grid.Rows)
	                {
                        if (!row.IsNewRow )
	                    {
                            decimal year = row.Cells["gridYear"].Value.ToString() == string.Empty ? 0 : decimal.Parse(row.Cells["gridYear"].Value.ToString());
                            decimal month = row.Cells["gridMonth"].Value.ToString() == string.Empty ? 0 : Convert.ToDecimal(GlobalData.GetMonth(row.Cells["gridMonth"].Value.ToString()));
                            decimal reliefAmount = row.Cells["gridReliefAmount"].Value == null ? 0 : Convert.ToDecimal(row.Cells["gridReliefAmount"].Value.ToString());

                            if (month > 0 && month <= 12 && year > 0)
                            {
                                var taxRelief = GlobalData._context.StaffTaxReliefs.FirstOrDefault(u => u.StaffID == row.Cells["gridStaffID"].Value.ToString() && u.Year == year.ToString());

                                var employee = GlobalData._context.StaffPersonalInfos.First(u => u.StaffID == row.Cells["gridStaffID"].Value.ToString());

                                if (taxRelief != null)
                                {
                                    //update -- cannot update year
                                    taxRelief.ReliefAmount = reliefAmount;
                                    taxRelief.Month = month;

                                    employee.CurrentTaxRelief = reliefAmount;
                                    employee.CurrentTaxReliefMonth = month;
                                    updateFlag = true;
                                }
                                else
                                {
                                    //save
                                    var TaxRelief = new DataReference.StaffTaxRelief
                                    {
                                        StaffID = row.Cells["gridStaffID"].Value.ToString(),
                                        ReliefAmount = reliefAmount,
                                        Year = year.ToString(),
                                        Month = Convert.ToDecimal(GlobalData.GetMonth(row.Cells["gridMonth"].Value.ToString())),
                                    };


                                    employee.CurrentTaxRelief = reliefAmount;
                                    employee.CurrentTaxReliefMonth = month;
                                    employee.CurrentTaxReliefYear = year;

                                    GlobalData._context.StaffTaxReliefs.InsertOnSubmit(TaxRelief);
                                    saveFlag = true;
                                }
                            }
                            //else
                            //{
                            //    MessageBox.Show("There was an error, check the rows", "Prompt");
                            //    return;
                            //}
                            
	                    }
	                }
                    GlobalData._context.SubmitChanges();
                    DisplayPrompt();
                    grid.Rows.Clear();
                    this.Close();
                    
                    
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("There was an error, contact Admin");
            }
        }

        public void DisplayPrompt()
        {
            if (saveFlag == true && updateFlag == true)
            {
                MessageBox.Show("Save and updates successfully", "Success");
            }
            else if (saveFlag == true && updateFlag == false)
            {
                MessageBox.Show("Saved successfully", "Success");
            }
            else if (saveFlag == false && updateFlag == true)
            {
                MessageBox.Show("Updated successfully", "Success");
            }
            else
            {
                MessageBox.Show("No changes made", "Success");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(periodComboBox.Text) || string.IsNullOrEmpty(yearComboBox.Text))
                {
                    MessageBox.Show("Please select a month and year to be used for the generation of data.");
                }
                else
                {
                    GetData();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void cmbDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            //    var employees = GlobalData._context.StaffPersonalInfoViews.Where(u =>  u.Department == cmbDepartment.Text).ToList();

            //    PopulateGrid(employees);
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
        }

        private void staffIDTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (staffIDTextBox.Text.Length > 4)
                {
                    var employees = GlobalData._context.StaffPersonalInfoViews.Where(u => u.StaffID == staffIDTextBox.Text).ToList();

                    if (employees.Count() == 1)
                    {
                        foreach (var item in employees)
                        {
                            nameTextBox.Text = item.Firstname + " " + item.OtherName + " " + item.Surname;
                        }
                    }
                    else
                    {
                        nameTextBox.Text = string.Empty;
                    }

                    PopulateGrid(employees);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDepartment_DropDownClosed(object sender, EventArgs e)
        {
            eMAS.Forms.PleaseWait frm = new eMAS.Forms.PleaseWait();
            try
            {
                if (string.IsNullOrEmpty(periodComboBox.Text) ||  string.IsNullOrEmpty(yearComboBox.Text))
                {
                    cmbDepartment.Text = string.Empty;
                    MessageBox.Show("Please select a month and year to be used for the generation of data.");
                }else
                {
                    if (cmbDepartment.Text == string.Empty)
                    {
                        grid.Rows.Clear();
                    }
                    else if (cmbDepartment.Text == "ALL")
                    {
                        this.UseWaitCursor = true;//from the Form/Window instance
                        frm.Show(this);

                        Application.DoEvents();//messages pumped to update controls


                        var employees = GlobalData._context.StaffPersonalInfoViews.Where(u => !u.Archived && !u.Terminated && !u.TransferredOut).OrderBy(u => u.StaffID).ToList();


                        PopulateGrid(employees);
                        this.UseWaitCursor = false;
                        frm.Close();
                    }
                    else
                    {
                        this.UseWaitCursor = true;//from the Form/Window instance
                        frm.Show(this);

                        Application.DoEvents();//messages pumped to update controls

                        staffIDTextBox.Text = string.Empty;

                        var employee = GlobalData._context.StaffPersonalInfoViews.Where(u => !u.Archived && !u.Terminated && !u.TransferredOut && u.Department == cmbDepartment.Text).OrderBy(u => u.StaffID).ToList();


                        PopulateGrid(employee);
                        this.UseWaitCursor = false;
                        frm.Close();
                    }
                }
                
                
            }
            catch (Exception)
            {
                this.UseWaitCursor = false;
                frm.Close();
                throw;
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void getMonths()
        {
            try
            {

                gridMonth.Items.Clear();
                foreach (string item in GlobalData.GetMonths())
                {
                    gridMonth.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void periodComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {

                periodComboBox.Items.Clear();
                foreach (string item in GlobalData.GetMonths())
                {
                    periodComboBox.Items.Add(item);
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
