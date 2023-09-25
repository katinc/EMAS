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
    public partial class UserView : Form
    {

        private IDAL dal;
        private User user;
        private IList<User> users;
        private IList<UserCategory> userCategories;
        private UserNew userNew;
        private int ctr;
        private bool found;

        public UserView(IDAL dal,UserNew newForm)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.user = new User();
                this.users = new List<User>();
                this.userCategories = new List<UserCategory>();
                this.userNew = newForm;
                this.ctr = 0;
                this.found = false;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public UserView()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.user = new User();
                this.users = new List<User>();
                this.userCategories = new List<UserCategory>();
                this.userNew = new UserNew();
                this.ctr = 0;
                this.found = false;
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
                cboUserCategory.Items.Clear();
                txtUserName.Clear();
                txtStaffID.Clear();
                txtName.Clear();
                txtEmail.Clear();
                checkBoxAccountBlocked.Checked = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UserView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                this.Clear();
                this.GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                if (grid.CurrentRow != null && userNew.CanEdit)
                {
                    User user = new User();
                    user.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    user.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    user.EmpID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    user.Name = grid.CurrentRow.Cells["gridName"].Value.ToString();
                    user.UserName = grid.CurrentRow.Cells["gridUserName"].Value.ToString();
                    user.Password = grid.CurrentRow.Cells["gridPassword"].Value.ToString();
                    user.UserCategory.Description = grid.CurrentRow.Cells["gridUserCategory"].Value.ToString();
                    user.Email = grid.CurrentRow.Cells["gridEmail"].Value.ToString();
                    user.AccountBlocked = bool.Parse(grid.CurrentRow.Cells["gridAccountBlocked"].Value.ToString());
                    user.CreateUserID = int.Parse(grid.CurrentRow.Cells["gridCreateUserID"].Value.ToString());
                    user.UpdateUserID = int.Parse(grid.CurrentRow.Cells["gridUpdateUserID"].Value.ToString());
                    user.UserRole = grid.CurrentRow.Cells["gridUserRole"].Value.ToString();
                    userNew.EditUser(user);
                    Close();
                }
                else if (!userNew.CanEdit)
                {
                    MessageBox.Show("Sorry you do not have permission to edit this data.");
                }
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
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (User user in users)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = user.ID;
                    grid.Rows[ctr].Cells["gridStaffCode"].Value = user.EmpID;
                    grid.Rows[ctr].Cells["gridStaffID"].Value = user.StaffID;
                    grid.Rows[ctr].Cells["gridName"].Value = user.Name;

                    grid.Rows[ctr].Cells["gridUserName"].Value = user.UserName;
                    grid.Rows[ctr].Cells["gridPassword"].Value = user.Password;
                    grid.Rows[ctr].Cells["gridEmail"].Value = user.Email;
                    grid.Rows[ctr].Cells["gridUserCategory"].Value = user.UserCategory.Description;
                    grid.Rows[ctr].Cells["gridAccountBlocked"].Value = user.AccountBlocked;
                    grid.Rows[ctr].Cells["gridCreateUserID"].Value = user.CreateUserID;
                    grid.Rows[ctr].Cells["gridUpdateUserID"].Value = user.UpdateUserID;
                    grid.Rows[ctr].Cells["gridUserRole"].Value = user.UserRole;

                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void GetUsers()
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

        private void GetData()
        {
            try
            {
                Query query = new Query();
                if(GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.CreateUserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (cboUserCategory.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.UserCategoryID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = userCategories[cboUserCategory.SelectedIndex].ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtUserName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.UserName",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtUserName.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.StaffID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtStaffID.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtName.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.Name",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtName.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                if (txtEmail.Text.Trim() != string.Empty)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "UsersView.Email",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = txtEmail.Text.Trim(),
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "UsersView.AccountBlocked",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = checkBoxAccountBlocked.Checked,
                    CriteriaOperator = CriteriaOperator.And
                });
                
                users = dal.GetByCriteria<User>(query);
                PopulateView(users);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to remove " + grid.CurrentRow.Cells["gridName"].Value.ToString() + "?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        user.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == user.ID)
                        {
                            user.Archived = true;
                            user.ArchivedUserID = GlobalData.User.ID;
                            user.ArchivedTime = DateTime.Now;
                            dal.Delete(user);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            user.Archived = true;
                            user.ArchivedUserID = GlobalData.User.ID;
                            user.ArchivedTime = DateTime.Now;
                            dal.Delete(user);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboUserCategory_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboUserCategory.Items.Clear();
                userCategories = dal.GetAll<UserCategory>();
                foreach (UserCategory userCategory in userCategories)
                {
                    cboUserCategory.Items.Add(userCategory.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
