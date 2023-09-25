using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class DepartmentsNew : Form
    {
        private Department departments;
        private IRefreshView departmentsView;
        private IList<Employee> employees;
        private IDAL dal;
        
        public DepartmentsNew(IRefreshView departmentsView, IDAL dal)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.departments = new Department();
                this.departmentsView = departmentsView;
                this.employees = new List<Employee>();
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
                this.Close();
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
                    this.Assign();
                    dal.Save(departments);
                    departmentsView.RefreshView();
                    this.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Please See the System Administrator");
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            try
            {
                departments.Code = txtCode.Text.Trim();
                departments.Description = txtDescription.Text.Trim();
                departments.Max_Staff = int.Parse(txtMaxStaff.Value.ToString());
                departments.In_Use = chkInUse.Checked;
                departments.Min_Staff = int.Parse(txtMinStaff.Value.ToString());
                departments.Supervisor = nameComboBox.Text.Trim();
                departments.User.ID = GlobalData.User.ID;
                if (nameComboBox.Text.Trim() != string.Empty && employees.Count > 0)
                {
                    departments.SupervisorID = employees[nameComboBox.SelectedIndex].ID;
                    departments.Supervisor = employees[nameComboBox.SelectedIndex].StaffID;
                }
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
                txtDescription.Clear();
                txtMaxStaff.ResetText();
                txtMinStaff.ResetText();
                chkInUse.Checked = true;
                nameComboBox.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        #endregion

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                employees = dal.LazyLoad<Employee>();
                nameComboBox.Items.Clear();
                foreach (Employee employee in employees)
                {
                    nameComboBox.Items.Add(GlobalData.GetFullName(employee));
                }
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region ValidateFields
        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                departmentErrorProvider.Clear();
                descriptionErrorProvider.Clear();
                maxStaffErrorProvider.Clear();
                minErrorProvider.Clear();
                if (txtDescription.Text.Trim() == string.Empty)
                {
                    result = false;
                    descriptionErrorProvider.SetError(txtDescription, "Please enter a description");
                }
                if (txtMaxStaff.Value < 1)
                {
                    result = false;
                    maxStaffErrorProvider.SetError(txtMaxStaff, "The maximum staff no. cannot be less than 1");
                }
                if (txtMinStaff.Value < 1)
                {
                    result = false;
                    minErrorProvider.SetError(txtMinStaff, "The minimum staff no. cannot be less than 1");
                }
                if (txtMaxStaff.Value < txtMinStaff.Value)
                {
                    result = false;
                    maxStaffErrorProvider.SetError(txtMaxStaff, "The minimum staff no. cannot be greater than the maximum staff no");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        #endregion

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDescription.Text.Trim() != string.Empty)
                {
                    descriptionErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void txtMaxStaff_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMaxStaff.Value > 0 && txtMinStaff.Value <= txtMaxStaff.Value)
                {
                    maxStaffErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
