using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.All_UIs.Staff_Information_FORMS
{
    public partial class QuickEmployeeSearchForm : Form
    {
        private IList<Employee> employees;
        private IList<Employee> foundEmployees;
        private EmployeeMaintenance employeeRegistration;
        private IDAL dal;
        private int ctr;

        public QuickEmployeeSearchForm()
        {
            try
            {
                InitializeComponent();
                this.employeeRegistration = new EmployeeMaintenance();
                this.employees = new List<Employee>();
                this.foundEmployees = new List<Employee>();
                this.dal = new DAL();
                this.dal.CloseConnection();
                this.dal.OpenConnection();
                this.ctr = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public QuickEmployeeSearchForm(IDAL dal, EmployeeMaintenance viewForm)
        {
            try
            {
                InitializeComponent();
                this.employeeRegistration = viewForm;
                this.employees = new List<Employee>();
                this.foundEmployees = new List<Employee>();
                this.dal = dal;
                this.dal.CloseConnection();
                this.dal.OpenConnection();
                this.ctr = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text.Trim() != string.Empty)
                {
                    employeeRegistration.QuickSearchView(txtSearch.Text.Trim());
                    employeeRegistration.Show();
                    employeeRegistration.Focus();
                    employeeRegistration.BringToFront();
                    employeeRegistration.WindowState = FormWindowState.Normal;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter StaffID or Mobile Number");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Could Not Find The Employee with this Number : " + txtSearch.Text.Trim());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void QuickEmployeeSearchForm_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}
