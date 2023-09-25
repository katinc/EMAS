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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRDataAccessLayer.Staff_Info_Data_Control;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class DepartmentsEdit : Form
    {
        private IDAL dal;
        private Department department;
        private IRefreshView departmentsView;
        private IList<Employee> employees;
        private EmployeeDataMapper employeeDataMapper;
        
        public DepartmentsEdit(IRefreshView departmentsView, IDAL dal,Department department)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.department = department;
                this.employees = new List<Employee>();            
                this.departmentsView = departmentsView;
                this.employeeDataMapper = new EmployeeDataMapper();

                //Initializing Controls
                var staff = employeeDataMapper.GetByID(department.SupervisorID);
                string fullName=string.Empty;
                if (staff != null)
                {
                    fullName = staff.FirstName + (staff.OtherName == string.Empty ? " " : " " + staff.OtherName + " ") + staff.Surname;
                }
                //department.Supervisor = GlobalData.GetFullName(staff);
                nameComboBox.Items.Add(fullName);
                nameComboBox.SelectedText = fullName;
                nameComboBox.Text = fullName;
                txtDescription.Text = department.Description;
                txtMinStaff.Value = department.Min_Staff;
                txtMaxStaff.Value = department.Max_Staff;
                chkInUse.Checked = department.In_Use;
                txtCode.Text = department.Code;
                #region EVENT DECLARATIONS
                txtMaxStaff.ValueChanged += new EventHandler(txtMaxStaff_ValueChanged);
                savebtn.Click += new EventHandler(savebtn_Click);
                closebtn.Click += new EventHandler(closebtn_Click);
                #endregion
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public DepartmentsEdit()
        {
            try
            {
                InitializeComponent();
                this.departmentsView = new DepartmentsForm();
                this.dal = new DAL();
                this.department = new Department();
                this.employees = new List<Employee>();

                //Initializing Controls
                var staff = employeeDataMapper.GetByID(department.SupervisorID);
                string fullName = string.Empty;
                if (staff != null)
                {
                    fullName = staff.FirstName + (staff.OtherName == string.Empty ? " " : " " + staff.OtherName + " ") + staff.Surname;
                }
                nameComboBox.Items.Add(fullName);
                nameComboBox.SelectedText = fullName;
                nameComboBox.Text = fullName;
                txtDescription.Text = department.Description;
                txtMinStaff.Value = department.Min_Staff;
                txtMaxStaff.Value = department.Max_Staff;
                chkInUse.Checked = department.In_Use;
                txtCode.Text = department.Code;
                #region EVENT DECLARATIONS
                txtMaxStaff.ValueChanged += new EventHandler(txtMaxStaff_ValueChanged);
                savebtn.Click += new EventHandler(savebtn_Click);
                closebtn.Click += new EventHandler(closebtn_Click);
                #endregion
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    this.Assign();
                    dal.Update(department);
                    departmentsView.RefreshView();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Please See the System administrator", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            try
            {
                department.Supervisor = nameComboBox.Text.Trim();
                department.Code = txtCode.Text.Trim();
                department.Description = txtDescription.Text.Trim();
                department.Max_Staff = int.Parse(txtMaxStaff.Value.ToString());
                department.Min_Staff = int.Parse(txtMinStaff.Value.ToString());
                department.In_Use = chkInUse.Checked;
                if (nameComboBox.Text != string.Empty && employees.Count > 0)
                {
                    department.SupervisorID = employees[nameComboBox.SelectedIndex].ID;
                    department.SupervisorCode = employees[nameComboBox.SelectedIndex].StaffID;
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
                nameComboBox.Text = string.Empty;
                txtMinStaff.Value = 0;
                txtDescription.Clear();
                txtMaxStaff.Value = 0;
                chkInUse.Checked = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

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
                if (txtMaxStaff.Value > 0)
                {
                    maxStaffErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void DepartmentsEdit_Load(object sender, EventArgs e)
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

        private void nameComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                employees = dal.LazyLoad<Employee>();
                nameComboBox.Items.Clear();
                foreach (Employee employee in employees)
                {
                    nameComboBox.Items.Add(GlobalData.GetFullName(employee));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
