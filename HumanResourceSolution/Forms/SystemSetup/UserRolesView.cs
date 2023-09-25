using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.SystemSetup
{
    public partial class UserRolesView : Form
    {
        private IList<UserCategory> userCategories;
        private IList<UserCategoryRole> userCategoryRoles;
        private IDAL dal;
        private UserRoles userRoleForm;
        private int ctr;

        public UserRolesView(IDAL dal, UserRoles userRoleForm)
        {
            try
            {
                InitializeComponent();
                this.userCategories = new List<UserCategory>();
                this.userCategoryRoles = new List<UserCategoryRole>();
                this.dal = dal;
                this.userRoleForm = userRoleForm;
                this.ctr = 0;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public UserRolesView()
        {
            try
            {
                InitializeComponent();
                this.userCategories = new List<UserCategory>();
                this.userCategoryRoles = new List<UserCategoryRole>();
                this.dal = new DAL();
                this.userRoleForm = new UserRoles();
                this.ctr = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    userRoleForm.EditRole(userCategoryRoles[grid.CurrentRow.Index]);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UserRolesView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetUserCategoryAccessLevels();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<UserCategoryRole> userCategoryRoles)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (UserCategoryRole userCategoryRole in userCategoryRoles)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = userCategoryRole.ID;
                    grid.Rows[ctr].Cells["gridUserCategoryID"].Value = userCategoryRole.UserCategory.ID;
                    grid.Rows[ctr].Cells["gridUserCategory"].Value = userCategoryRole.UserCategory.Description;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetUserCategoryAccessLevels()
        {
            try
            {
                userCategoryRoles = dal.GetAll<UserCategoryRole>();
                PopulateView(userCategoryRoles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected user role?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        dal.Delete(userCategoryRoles[grid.CurrentRow.Index]);
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}