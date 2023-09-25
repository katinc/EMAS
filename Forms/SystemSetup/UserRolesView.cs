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
        private IList<Role> role;
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
                this.role = new List<Role>();
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
                //if (grid.CurrentRow != null)
                //{
                //    userRoleForm.EditRole(userCategoryRoles[grid.CurrentRow.Index]);
                //    this.Close();
                //}
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
                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Role> roles)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Role role in roles)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = role.RoleID;
                    grid.Rows[ctr].Cells["gridRole"].Value = role.RoleName;
                    grid.Rows[ctr].Cells["gridActive"].Value = role.Active;
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
                //userCategoryRoles = dal.GetAll<UserCategoryRole>();
                role = dal.GetAll<Role>();
                PopulateView(role);
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

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider1.Clear();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridID"].Value == null)
                            {
                                var Role = new DataReference.Role
                                {
                                    RoleName = row.Cells["gridRole"].Value.ToString(),
                                    Active = (bool)row.Cells["gridActive"].FormattedValue,
                                };
                                GlobalData._context.Roles.InsertOnSubmit(Role);
                            }
                            else
                            {
                                int roleID = int.Parse(row.Cells["gridID"].Value.ToString());

                                var updateRole = GlobalData._context.Roles.SingleOrDefault(u => u.RoleID == roleID);
                                updateRole.RoleName = row.Cells["gridRole"].Value.ToString();
                                updateRole.Active = (bool)row.Cells["gridActive"].FormattedValue;

                            }

                            GlobalData._context.SubmitChanges();
                        }
                    }
                    MessageBox.Show("Saved Successfully");
                    GetUserCategoryAccessLevels();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not Save Successfully");
            }
        }
    }
}