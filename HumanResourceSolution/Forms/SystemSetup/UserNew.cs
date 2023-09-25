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
using HRDataAccessLayerBase;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.Validation;

namespace eMAS.Forms.SystemSetup
{
    public partial class UserNew : Form
    {
        private IDAL dal;
        private User user;
        private Company company;
        private IList<UserCategory> userCategories;
        private IList<Employee> employeeList;
        private bool editMode;
        private int ctr;
        private int staffCode;
        private int userID;
        private ManageRoles manageRole;

        public UserNew()
        {
            try
            {
                InitializeComponent();
                this.user = new User();
                this.dal = new DAL();
                this.company = new Company();
                this.employeeList = new List<Employee>();
                this.userCategories = new List<UserCategory>();
                this.editMode = false;
                this.ctr = 0;
                this.staffCode = 0;
                this.userID = 0;
                this.manageRole = new ManageRoles();
                txtStaffID.Select();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public UserNew(ManageRoles manageRole)
        {
            try
            {
                InitializeComponent();
                this.user = new User();
                this.dal = new DAL();
                this.company = new Company();
                this.employeeList = new List<Employee>();
                this.userCategories = new List<UserCategory>();
                this.editMode = false;
                this.ctr = 0;
                this.staffCode = 0;
                this.userID = 0;
                txtStaffID.Select();
                this.manageRole = manageRole;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void userCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                userCategoryComboBox.Items.Clear();
                userCategories=dal.GetAll<UserCategory>();
                foreach (UserCategory userCategory in userCategories)
                {
                    userCategoryComboBox.Items.Add(userCategory.Description);
                }
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

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
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
                txtStaffID.Clear();
                txtName.Clear();
                userNameTextBox.Clear();
                passwordTextBox.Clear();
                confirmPasswordTextBox.Clear();
                emailTextBox.Clear();
                userCategoryComboBox.Items.Clear();
                userCategoryComboBox.Text = string.Empty;
                checkBoxAccountBlocked.Checked = false;
                passwordTextBox.Enabled = true;
                confirmPasswordTextBox.Enabled = true;
                editMode = false;
                ctr = 0;
                userID = 0;
                txtStaffID.Select();
                savebtn.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    Assign();
                    if (editMode)
                    {
                        user.UpdateUserID = GlobalData.User.ID;
                        dal.Update(user);
                    }
                    else
                    {
                        user.CreateUserID = GlobalData.User.ID;
                        dal.Save(user);
                    }
                    dal.CommitTransaction();
                    this.manageRole.RefreshUserView();
                    this.SendToBack();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                dal.RollBackTransaction();
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                staffErrorProvider.Clear();
                if (txtStaffID.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtStaffID, "Please enter the StaffID");
                    txtStaffID.Focus();
                }
                else if (txtName.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(txtName, "Please enter the Name");
                    txtName.Focus();
                }
                else if (userNameTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(userNameTextBox, "Please enter the User Name");
                    userNameTextBox.Focus();
                }
                else if (passwordTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(passwordTextBox, "Please enter a password");
                    passwordTextBox.Focus();
                }
                else if (passwordTextBox.Text.Trim() != confirmPasswordTextBox.Text.Trim())
                {
                    result = false;
                    staffErrorProvider.SetError(confirmPasswordTextBox, "The confirmation password does not match the origional");
                    confirmPasswordTextBox.Focus();
                }
                else if (userCategoryComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(userCategoryComboBox, "Please select a user category");
                    userCategoryComboBox.Focus();
                }
                else if (emailTextBox.Text.Trim() != string.Empty && !Validator.EmailValidator(emailTextBox.Text.Trim()))
                {
                    result = false;
                    staffErrorProvider.SetError(emailTextBox, "Please Email Address is not valid");
                    emailTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

            return result;
        }

        private void Assign()
        {
            try
            {
                user.ID = userID;
                user.EmpID = staffCode;
                user.UserName = userNameTextBox.Text.Trim();
                user.Password = passwordTextBox.Text.Trim();
                user.Email = emailTextBox.Text.Trim();
                user.StaffID = txtStaffID.Text.Trim();
                user.Name = txtName.Text.Trim();
                user.AccountBlocked = checkBoxAccountBlocked.Checked;
                user.UserCategory.ID = userCategories[userCategoryComboBox.SelectedIndex].ID;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void UserNew_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public void EditUser(User user)
        {
            try
            {
                Clear();
                editMode = true;
                txtName.Text = user.Name;
                txtStaffID.Text = user.StaffID;
                staffCode=user.EmpID;
                userID = user.ID;
                passwordTextBox.Text = user.Password;
                confirmPasswordTextBox.Text = user.Password;
                passwordTextBox.Enabled = false;
                confirmPasswordTextBox.Enabled = false;
                userNameTextBox.Text = user.UserName;
                emailTextBox.Text = user.Email;
                checkBoxAccountBlocked.Checked = user.AccountBlocked;
                userCategoryComboBox_DropDown(this, EventArgs.Empty);
                userCategoryComboBox.Text = user.UserCategory.Description;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != user.ID)
                {
                    savebtn.Enabled = false;
                }
                searchGrid.Visible = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserView view = new UserView(dal,this);
                view.MdiParent = this.MdiParent;
                view.Show();
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
                    txtStaffID.Text = searchGrid.CurrentRow.Cells["gridStaffNo"].Value.ToString();
                    txtName.Text = searchGrid.CurrentRow.Cells["gridName"].Value.ToString();
                    searchGrid.Hide();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void nametxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (txtName.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        int ctr = 0;
                        bool found = false;
                        employeeList = dal.LazyLoad<Employee>();
                        foreach (Employee employee in employeeList)
                        {
                            string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                            if (name.Trim().ToLower().StartsWith(txtName.Text.Trim().ToLower()))
                            {
                                found = true;
                                searchGrid.Rows.Add(1);
                                searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                staffCode = employee.ID;
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
                            searchGrid.Location = new Point(txtName.Location.X, txtName.Location.Y + 21);
                            searchGrid.BringToFront();
                            searchGrid.Visible = true;
                        }
                        else
                        {
                            searchGrid.Visible = false;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Search by Staff Name cannot be completed");
            }
        }

        private void staffIDtxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtStaffID.Text.Trim() != string.Empty)
                {
                    if (company.ID == 0)
                    {
                        company = dal.LazyLoad<Company>()[0];
                    }
                    if (txtStaffID.Text.Length >= company.MinimumCharacter)
                    {
                        staffErrorProvider.Clear();
                        searchGrid.Rows.Clear();
                        searchGrid.BringToFront();
                        ctr = 0;
                        bool found = false;
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.StaffID",
                            CriterionOperator = CriterionOperator.Like,
                            Value = txtStaffID.Text.Trim() + '%',
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.Terminated",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffPersonalInfoLazyLoadView.TransferredOut",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = false,
                            CriteriaOperator = CriteriaOperator.And
                        });
                        employeeList = dal.LazyLoad<Employee>();
                        if (employeeList.Count > 0)
                        {
                            foreach (Employee employee in employeeList)
                            {
                                string name = employee.FirstName + (employee.OtherName == string.Empty ? string.Empty : " " + employee.OtherName) + " " + employee.Surname;
                                if (employee.StaffID.Trim().ToLower().StartsWith(txtStaffID.Text.Trim().ToLower()))
                                {
                                    found = true;
                                    searchGrid.Rows.Add(1);
                                    searchGrid.Rows[ctr].Cells["gridName"].Value = name;
                                    searchGrid.Rows[ctr].Cells["gridStaffNo"].Value = employee.StaffID;
                                    staffCode = employee.ID;
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
                                searchGrid.Location = new Point(txtStaffID.Location.X, txtStaffID.Location.Y + 21);
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
                            MessageBox.Show("Employee with StaffID " + txtStaffID.Text + " is not Found");
                            txtStaffID.Text = string.Empty;
                        }
                    }
                }
                else
                {
                    ClearStaff();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Error:Please See the System Administrator");
            }
        }


        private void ClearStaff()
        {
            try
            {
                txtName.Clear();
                txtStaffID.Clear();
                txtStaffID.Select();
                searchGrid.Visible = false;
                staffCode = 0;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
