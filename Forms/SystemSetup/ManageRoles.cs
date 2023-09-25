using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;

namespace eMAS.Forms.SystemSetup
{
    public partial class ManageRoles : Form
    {
        private IDAL dal;
        private IList<Role> roles;
        private IList<User> users;
        private IList<User> foundUsers;
        private IList<Role> foundRoles;
        private User user;
        private Role role;
        private Company company;
        private IList<UserToRole> userToRoles;
        private UserToRole userToRole;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public ManageRoles()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.users = new List<User>();
                this.foundUsers = new List<User>();
                this.foundRoles = new List<Role>();
                this.user = new User();
                this.role = new Role();
                this.userToRole = new UserToRole();
                this.company = new Company();
                this.roles = new List<Role>();
                this.userToRoles = new List<UserToRole>();
                this.FillUsersInRollsTree();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void homeToolStripMenuItem_Click( object sender, EventArgs e )
        {
            DialogResult = DialogResult.OK;
        }

        private void AddNewRole_Click( object sender, EventArgs e )
        {
            string newName = string.Empty;
            try
            {
                role.RoleName=NewRoleName.Text.Trim();
                dal.Save(role);
                NewRoleName.Text = string.Empty; // clear the control
                RefreshRoleView();
            }
            catch ( Exception ex )
            {
                MessageBox.Show( "Unable to add role " + newName + ex.Message,"Unable to add role!", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }

            RolesListBox.SelectedIndex = -1;

        }

        private void Clear()
        {
            try
            {
                userErrorProvider.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void AddUsersToRole_Click( object sender, EventArgs e )
        {
            try
            {
                foreach (var userRow in AppUsersListBox.SelectedItems )
                {
                    foreach (var roleRow in RolesListBox.SelectedItems )
                    {
                        try
                        {
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "UsersView.UserName",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = userRow.ToString(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            users = dal.GetByCriteria<User>(query);
                            foreach(User user in users)
                            {
                                userToRole.User.ID = user.ID;
                            }
                            Query roleQuery = new Query();
                            roleQuery.Criteria.Add(new Criterion()
                            {
                                Property = "RoleView.RoleName",
                                CriterionOperator = CriterionOperator.EqualTo,
                                Value = roleRow.ToString(),
                                CriteriaOperator = CriteriaOperator.And
                            });
                            roles = dal.GetByCriteria<Role>(roleQuery);
                            foreach (Role role in roles)
                            {
                                userToRole.Role.RoleID = role.RoleID;
                            }
                            dal.Save(userToRole);
                        }
                        catch ( Exception ex )
                        {
                            Logger.LogError(ex);
                        }
                            
                    }
                }
                FillUsersInRollsTree();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void DisplayError( int userID, int roleID, string message )
        {
            MessageBox.Show( "Unable to add user (" + userID + ") to role (" + roleID + ")" + message,"Unable to add user to role",MessageBoxButtons.OK,MessageBoxIcon.Error );
        }

        
        private void FillUsersInRollsTree()
        {
            try
            {
                UsersInRoles.BeginUpdate();
                UsersInRoles.Nodes.Clear();
                TreeNode parentNode = null;
                TreeNode subNode = null;

                string currentName = string.Empty;
                Criterion c = new Criterion();
                c.CriterionOperator = CriterionOperator.EqualTo;
                c.Property = "Active";
                c.Value = true;
                c.CriteriaOperator = CriteriaOperator.None;

                Query query = new Query();
                query.Criteria.Add(c);

                if (rbName.Checked)
                {
                    query.OrderClause.Entity = "UserToRoleView";
                    query.OrderClause.Property = "UserName";
                    query.OrderClause.OrderClauseOperator = OrderClauseOperator.Asc;
                }
                else
                {
                    query.OrderClause.Entity = "UserToRoleView";
                    query.OrderClause.Property = "RoleName";
                    query.OrderClause.OrderClauseOperator = OrderClauseOperator.Asc;
                }
                userToRoles = dal.GetByCriteria<UserToRole>(query);
                foreach (UserToRole userToRole in userToRoles)
                {
                    if (rbName.Checked)
                    {
                        subNode = new TreeNode(userToRole.Role.RoleName.ToString());
                        if (currentName != userToRole.User.UserName.ToString())
                        {
                            parentNode = new TreeNode(userToRole.User.UserName.ToString());
                            currentName = userToRole.User.UserName.ToString();
                            UsersInRoles.Nodes.Add(parentNode);
                        }
                    }
                    else
                    {
                        subNode = new TreeNode(userToRole.User.UserName.ToString());
                        if (currentName != userToRole.Role.RoleName.ToString())
                        {
                            parentNode = new TreeNode(userToRole.Role.RoleName.ToString());
                            currentName = userToRole.Role.RoleName.ToString();
                            UsersInRoles.Nodes.Add(parentNode);
                        }
                    }

                    if (parentNode != null)
                    {
                        parentNode.Nodes.Add(subNode);
                    }
                }
                UsersInRoles.EndUpdate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void RadioButtonClick( object sender, EventArgs e )
        {
            try
            {
                FillUsersInRollsTree();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<User> users)
        {
            try
            {
                AppUsersListBox.Items.Clear();
                foreach (User user in users)
                {
                    AppUsersListBox.Items.Add(user.UserName);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundUsers.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "UsersView.UserName",
                    CriterionOperator = CriterionOperator.Like,
                    Value = txtUserName.Text.Trim() + '%',
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "UsersView.AccountBlocked",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = false,
                    CriteriaOperator = CriteriaOperator.And
                });
                users = dal.GetByCriteria<User>(query);
                if (users.Count > 0)
                {
                    foreach (User user in users)
                    {
                        if (user.UserName.Trim().ToLower().StartsWith(txtUserName.Text.Trim().ToLower()))
                        {
                            foundUsers.Add(user);
                        }
                    }
                    PopulateView(foundUsers);
                }
                else
                {
                    MessageBox.Show("User with User Name " + txtUserName.Text.Trim() + " is not Found");
                    txtUserName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtRoleName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundRoles.Clear();
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "RoleView.RoleName",
                    CriterionOperator = CriterionOperator.Like,
                    Value = txtRoleName.Text.Trim() + '%',
                    CriteriaOperator = CriteriaOperator.And
                });
                roles = dal.GetByCriteria<Role>(query);
                if (users.Count > 0)
                {
                    foreach (Role role in roles)
                    {
                        if (role.RoleName.Trim().ToLower().StartsWith(txtRoleName.Text.Trim().ToLower()))
                        {
                            foundRoles.Add(role);
                        }
                    }
                    PopulateRoleView(foundRoles);
                }
                else
                {
                    MessageBox.Show("Role with Role Name " + txtRoleName.Text.Trim() + " is not Found");
                    txtRoleName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateRoleView(IList<Role> roles)
        {
            try
            {
                RolesListBox.Items.Clear();
                foreach (Role role in roles)
                {
                    RolesListBox.Items.Add(role.RoleName);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void RefreshRoleView()
        {
            try
            {
                roles = dal.GetAll<Role>();
                PopulateRoleView(roles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void RefreshUserView()
        {
            try
            {
                users = dal.GetAll<User>();
                PopulateView(users);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void ManageRoles_Load( object sender, EventArgs e )
        {
            try
            {
                RefreshRoleView();
                RefreshUserView();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnAddUser.Visible = getPermissions.CanAdd;
                    AddNewRole.Visible = getPermissions.CanAdd;
                    DeleteRole.Visible = getPermissions.CanDelete;
                    RenameRole.Visible = getPermissions.CanEdit;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void DeleteRole_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (RolesListBox.SelectedIndex != -1)
                {
                    if (MessageBox.Show("Are you sure you want to delete item (s)?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        var selectedItems = RolesListBox.SelectedItems;
                        foreach (var r in selectedItems)
                        {
                            Query query = new Query();
                            query.Criteria.Add(new Criterion()
                            {
                                Property = "RoleView.RoleName",
                                CriterionOperator = CriterionOperator.Like,
                                Value = r,
                                CriteriaOperator = CriteriaOperator.And
                            });
                            roles = dal.GetByCriteria<Role>(query);
                            if (roles.Count > 0)
                            {
                                foreach (Role role in roles)
                                {
                                    role.RoleID = role.RoleID;
                                    role.Active = false;
                                    dal.Delete(role);
                                }
                            }
                        }
                        RolesListBox.Update();
                        RefreshRoleView();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Role (s) From the ListBox");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void RenameRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (RolesListBox.SelectedIndex != -1)
                {
                    if (NewRoleName.Text.Trim() != string.Empty)
                    {
                        if (MessageBox.Show("Are you sure you want to rename item?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            role.RoleID = roles[RolesListBox.SelectedIndex].RoleID;
                            role.RoleName = NewRoleName.Text.Trim();
                            dal.Update(role);
                            RolesListBox.Update();
                            RefreshRoleView();
                            FillUsersInRollsTree();
                            NewRoleName.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter New Role Name");
                        NewRoleName.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Role From the ListBox");
                    RolesListBox.Focus();
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void RemoveUsersFromRole_Click(object sender, EventArgs e)
        {
            try
            {
                if (AppUsersListBox.SelectedIndex != -1 && RolesListBox.SelectedIndex != -1)
                {
                    foreach (var userRow in AppUsersListBox.SelectedItems)
                    {
                        foreach (var roleRow in RolesListBox.SelectedItems)
                        {
                            try
                            {
                                Query userToRoleQuery = new Query();
                                userToRoleQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "UserToRoleView.UserName",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = userRow.ToString(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                userToRoleQuery.Criteria.Add(new Criterion()
                                {
                                    Property = "UserToRoleView.RoleName",
                                    CriterionOperator = CriterionOperator.EqualTo,
                                    Value = roleRow.ToString(),
                                    CriteriaOperator = CriteriaOperator.And
                                });
                                userToRoles = dal.GetByCriteria<UserToRole>(userToRoleQuery);
                                if (userToRoles.Count > 0)
                                {
                                    foreach (UserToRole userToRo in userToRoles)
                                    {
                                        dal.BeginTransaction();
                                        userToRole.User.ID = userToRo.User.ID;
                                        userToRole.Role.RoleID = userToRo.Role.RoleID;
                                        userToRole.User.UserName = userToRo.User.UserName;
                                        userToRole.Role.RoleName = userToRo.Role.RoleName;
                                        userToRole.User.Name = GlobalData.User.StaffID + " | " + GlobalData.User.Name + " | " + GlobalData.User.UserName;
                                        dal.Delete(userToRole);
                                        dal.CommitTransaction();
                                    }
                                }                              
                            }
                            catch (Exception ex)
                            {
                                dal.RollBackTransaction();
                                Logger.LogError(ex);
                            }

                        }
                    }
                    FillUsersInRollsTree();
                }                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                UserNew userNew = new UserNew(this);
                userNew.MdiParent = this.MdiParent;
                userNew.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}