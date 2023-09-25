using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using Microsoft.VisualBasic;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class DepartmentsForm : Form, IRefreshView 
    {
        private DepartmentsNew departmentForm;
        private IDAL dal;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public DepartmentsForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.found = false;
                dal.OpenConnection();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                departmentForm = new DepartmentsNew(this, dal);
                departmentForm.MdiParent = this.MdiParent;
                departmentForm.Show();
                departmentForm.BringToFront();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    Department department = new Department();
                    department.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    //department.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridSupervisorID"].Value.ToString());
                    department.SupervisorID = Information.IsNumeric(grid.CurrentRow.Cells["gridSupervisorID"].Value) ? Convert.ToInt32(grid.CurrentRow.Cells["gridSupervisorID"].Value) : 0;
                    department.Supervisor = grid.CurrentRow.Cells["gridSupervisor"].Value.ToString();
                    department.Code = grid.CurrentRow.Cells["gridCode"].Value.ToString();
                    department.Description = grid.CurrentRow.Cells["gridDescription"].Value.ToString();
                    department.In_Use = bool.Parse(grid.CurrentRow.Cells["gridInUse"].Value.ToString());
                    department.Max_Staff = int.Parse(grid.CurrentRow.Cells["gridMaxStaff"].Value.ToString());
                    department.Min_Staff = int.Parse(grid.CurrentRow.Cells["gridMinStaff"].Value.ToString());
                    DepartmentsEdit departmentsEdit = new DepartmentsEdit(this, dal, department);
                    departmentsEdit.MdiParent = this.MdiParent;
                    departmentsEdit.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Please see the System Administrator", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Do you want to permanently delete the ff. department:\n", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            Department department = new Department();
                            department.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            department.Archived = true;
                            dal.Delete(department);
                            grid.Rows.RemoveAt(grid.Rows.IndexOf(grid.CurrentRow));
                            grid.Refresh();
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            Department department = new Department();
                            department.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            department.Archived = true;
                            dal.Delete(department);
                            grid.Rows.RemoveAt(grid.Rows.IndexOf(grid.CurrentRow));
                            grid.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Please see the System Administrator", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                dal.CloseConnection();
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        public void RefreshView()
        {
            try
            {
                Query query = new Query();
                /*if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }*/
                found = true;
                if (found == true)
                {
                    /*query.Criteria.Add(new Criterion()
                    {
                        Property = "DepartmentView.UserID",
                        //CriterionOperator = CriterionOperator.NotEqualTo,
                        //Value = null,
                        //CriteriaOperator = CriteriaOperator.And
                    });*/
                }
                IList<Department> departments = dal.GetAll<Department>();
                grid.Rows.Clear();
                int ctr = 0;
                foreach (Department department in departments)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = department.ID;
                    grid.Rows[ctr].Cells["gridSupervisorCode"].Value = department.SupervisorCode;
                    grid.Rows[ctr].Cells["gridSupervisorID"].Value = department.SupervisorID;
                    //grid.Rows[ctr].Cells["gridSupervisorCode"].Value = department.Employee.StaffID;
                    grid.Rows[ctr].Cells["gridSupervisor"].Value = (department.SupervisorFirstName+" "+department.SupervisorOtherName).Trim()+" "+department.SupervisorLastName;
                    grid.Rows[ctr].Cells["gridCode"].Value = department.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = department.Description;
                    grid.Rows[ctr].Cells["gridInUse"].Value = department.In_Use;
                    grid.Rows[ctr].Cells["gridMaxStaff"].Value = department.Max_Staff;
                    grid.Rows[ctr].Cells["gridMinStaff"].Value = department.Min_Staff;
                    grid.Rows[ctr].Cells["gridUserID"].Value = department.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                RefreshView();
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnAdd.Enabled = getPermissions.CanAdd;
                    btnDelete.Enabled = getPermissions.CanDelete;
                    btnUpdate.Visible = getPermissions.CanEdit;
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
    }
}
