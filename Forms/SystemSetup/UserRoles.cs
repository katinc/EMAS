using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using System.Text.RegularExpressions;

namespace eMAS.Forms.SystemSetup
{
    public partial class UserRoles : Form
    {
        private IDAL dal;
        private DALHelper dalhelper;
        private UserRole userRole;
        private UserCategoryRole userCategoryRole;
        //private IList<UserCategoryRole> userCategoryRoles;
        private IList<UserCategory> userCategories;
        private IList<UserAccessLevel1> userAccessLevels1;
        private IList<UserAccessLevel2> userAccessLevels2;
        private IList<UserAccessLevel3> userAccessLevels3;
        private IList<UserAccessLevel4> userAccessLevels4;
        private int ctr;
        private decimal AccessLevel1;
        private decimal AccessLevel2;
        private decimal AccessLevel3;
        private decimal AccessLevel4;
        private int UserAccessID;
        private bool editState = false;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        //private DataReference.hrContextDataContext _context = new DataReference.hrContextDataContext();

        public UserRoles()
        {
            try
            {
                InitializeComponent();
                this.userRole = new UserRole();
                this.userCategoryRole = new UserCategoryRole();
                this.dalhelper = new DALHelper();
                this.userCategories = new List<UserCategory>();
                this.userAccessLevels1 = new List<UserAccessLevel1>();
                this.userAccessLevels2 = new List<UserAccessLevel2>();
                this.userAccessLevels3 = new List<UserAccessLevel3>();
                this.userAccessLevels4 = new List<UserAccessLevel4>();
                this.dal = new DAL();
                this.ctr = 0;

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
                userCategoryComboBox.DataSource = null;
                var category = GlobalData._context.Roles.Where(u=>u.Active == true).ToList();

                if (category.Count() > 0)
                {
                    userCategoryComboBox.DataSource = category;
                    userCategoryComboBox.ValueMember = "RoleID";
                    userCategoryComboBox.DisplayMember = "RoleName";
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
                editState = false;
                btnAdd.Text = "Add";
                btndelete.Enabled = false;
                //userCategoryComboBox.DataSource = null;
                //userCategoryComboBox.Text = string.Empty;
                level1ComboBox.DataSource = null;
                level1ComboBox.Text = string.Empty;
                level2ComboBox.DataSource = null;
                level2ComboBox.Text = string.Empty;

                level3ComboBox.DataSource = null;
                level3ComboBox.Text = string.Empty;
                level4ComboBox.DataSource = null;
                level4ComboBox.Text = string.Empty;
                
                viewCheckBox.Checked = false;
                printCheckBox.Checked = false;
                addCheckBox.Checked = false;
                editCheckBox.Checked = false;
                deleteCheckBox.Checked = false;
                approveCheckBox.Checked = false;
                userCategoryComboBox.Enabled = true;
                grid.Rows.Clear();
                groupBox2.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }


        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();
                if (userCategoryComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(userCategoryComboBox, "Please select a user category");
                    result = false;
                }
                if (level1ComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(level1ComboBox, "Please select an access level");
                    result = false;
                }
                if (level2ComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(level2ComboBox, "Please select a second access level");
                    result = false;
                }
                if (level3ComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(level3ComboBox, "Please select a third access level");
                    result = false;
                }
                if (level4ComboBox.Text.Trim() == string.Empty)
                {
                    errorProvider.SetError(level4ComboBox, "Please select a fourth access level");
                    result = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void UserCategories_Load(object sender, EventArgs e)
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

        private void PopulateView()
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                var levels = GlobalData._context.UserAccessLevelsViews.Where(u => u.RoleName == userCategoryComboBox.Text).ToList();
                foreach (var userCategoryRole in levels)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = userCategoryRole.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1ID"].Value = userCategoryRole.AccessLevel1ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1"].Value = userCategoryRole.AccessLevel1;
                    grid.Rows[ctr].Cells["gridAccessLevel2ID"].Value = userCategoryRole.AccessLevel2ID;
                    grid.Rows[ctr].Cells["gridAccessLevel2"].Value = userCategoryRole.AccessLevel2;
                    grid.Rows[ctr].Cells["gridAccessLevel3ID"].Value = userCategoryRole.AccessLevel3ID;
                    grid.Rows[ctr].Cells["gridAccessLevel3"].Value = userCategoryRole.AccessLevel3;
                    grid.Rows[ctr].Cells["gridAccessLevel4ID"].Value = userCategoryRole.AccessLevel4ID;
                    grid.Rows[ctr].Cells["gridAccessLevel4"].Value = userCategoryRole.AccessLevel4;
                    grid.Rows[ctr].Cells["gridCanAdd"].Value = userCategoryRole.CanAdd;
                    grid.Rows[ctr].Cells["gridCanDelete"].Value = userCategoryRole.CanDelete;
                    grid.Rows[ctr].Cells["gridCanEdit"].Value = userCategoryRole.CanEdit;
                    grid.Rows[ctr].Cells["gridCanPrint"].Value = userCategoryRole.CanPrint;
                    grid.Rows[ctr].Cells["gridCanView"].Value = userCategoryRole.CanView;
                    grid.Rows[ctr].Cells["gridCanApprove"].Value = userCategoryRole.CanApproveChanges;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        

        private void userCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserRolesView viewDialog = new UserRolesView(dal, this);
                viewDialog.MdiParent = this.MdiParent;
                viewDialog.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                AccessLevel1 = (decimal)level1ComboBox.SelectedValue;
                AccessLevel2 = Convert.ToDecimal(level2ComboBox.SelectedValue);
                AccessLevel3 = Convert.ToDecimal(level3ComboBox.SelectedValue);
                AccessLevel4 = Convert.ToDecimal(level4ComboBox.SelectedValue);


                if (level1ComboBox.Enabled == true && level1ComboBox.SelectedIndex == -1)
                {
                    //if (MessageBox.Show("Are you sure you want to add OverTime?", GlobalData.Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                        
                    //}
                    errorProvider.SetError(level1ComboBox, "Please select accesslevel 1");
                    return;
                }
                if (level2ComboBox.Enabled == true && level2ComboBox.SelectedIndex == -1)
                {
                    errorProvider.SetError(level2ComboBox, "Please select accesslevel 2");
                    return;
                }
                if (level3ComboBox.Enabled == true && level3ComboBox.SelectedIndex == -1)
                {
                    errorProvider.SetError(level3ComboBox, "Please select accesslevel 3");
                    return;
                }
                if (level4ComboBox.Enabled == true && level4ComboBox.SelectedIndex == -1)
                {
                    errorProvider.SetError(level1ComboBox, "Please select accesslevel 4");
                    return;
                }
                else
                {
                    errorProvider.Clear();
                }

                if (!addCheckBox.Checked && !deleteCheckBox.Checked && !editCheckBox.Checked && !viewCheckBox.Checked && !approveCheckBox.Checked)
                {
                    MessageBox.Show("Check one of the options: Add, Delete, Edit, View, Approve");
                    return;
                }

                var UserPermissions = new DataReference.UserAccessLevel
                {
                    AccessLevel1ID = AccessLevel1,
                    AccessLevel2ID = AccessLevel2,
                    AccessLevel3ID = AccessLevel3,
                    AccessLevel4ID = AccessLevel4,
                    UserID = GlobalData.User.ID,
                    CanAdd = addCheckBox.Checked,
                    CanDelete = deleteCheckBox.Checked,
                    CanEdit = editCheckBox.Checked,
                    CanPrint = printCheckBox.Checked,
                    CanView = viewCheckBox.Checked,
                    CanApproveChanges = approveCheckBox.Checked,
                    RoleID = (int)userCategoryComboBox.SelectedValue,
                };

                var find = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u =>
                    u.AccessLevel1ID == UserPermissions.AccessLevel1ID &&
                    u.AccessLevel2ID == UserPermissions.AccessLevel2ID &&
                    u.AccessLevel3ID == UserPermissions.AccessLevel3ID &&
                    u.AccessLevel4ID == UserPermissions.AccessLevel4ID &&
                    u.RoleName == userCategoryComboBox.Text
                    );
                if (editState == false)
                {
                    if (find != null)
                    {
                        MessageBox.Show("Permissions already assigned to this Role");
                        return;
                    }

                    //UserPermissions.ID = _context.UserAccessLevels.Count()+1;
                    GlobalData._context.UserAccessLevels.InsertOnSubmit(UserPermissions);
                    GlobalData._context.SubmitChanges();
                    PopulateView();
                    MessageBox.Show("Permissions assigned successfully");
                }
                else
                {
                    var getaccess = GlobalData._context.UserAccessLevels.SingleOrDefault(u => u.ID == UserAccessID);
                    getaccess.AccessLevel1ID = AccessLevel1;
                    getaccess.AccessLevel2ID = AccessLevel2;
                    getaccess.AccessLevel3ID = AccessLevel3;
                    getaccess.AccessLevel4ID = AccessLevel4;
                    getaccess.UserID = GlobalData.User.ID;
                    getaccess.CanAdd = addCheckBox.Checked;
                    getaccess.CanDelete = deleteCheckBox.Checked;
                    getaccess.CanEdit = editCheckBox.Checked;
                    getaccess.CanPrint = printCheckBox.Checked;
                    getaccess.CanView = viewCheckBox.Checked;
                    getaccess.CanApproveChanges = approveCheckBox.Checked;
                    getaccess.RoleID = (int)userCategoryComboBox.SelectedValue;
                    //UserPermissions.ID = _context.UserAccessLevels.Count()+1;

                    GlobalData._context.SubmitChanges();
                    Clear();
                    UserRoles_Load(sender, e);
                    PopulateView();
                    MessageBox.Show("Permissions updated successfully");
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void UserRoles_Load(object sender, EventArgs e)
        {
            try
            {
                //PopulateView();

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnAdd.Visible = getPermissions.CanAdd;
                    btndelete.Visible = getPermissions.CanDelete;
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

        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                //if (grid.CurrentRow != null)
                //{
                //    if (grid.CurrentRow.Cells["gridID"].Value != null)
                //    {
                //        dalhelper.ExecuteNonQuery("Delete from UserCategoryAccessLevels Where ID = " + grid.CurrentRow.Cells["gridID"].Value);
                //    }
                //    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                //}

                var remove = GlobalData._context.UserAccessLevels.Where(u => u.ID == UserAccessID).SingleOrDefault();
                if (remove != null)
                {
                    GlobalData._context.UserAccessLevels.DeleteOnSubmit(remove);
                    GlobalData._context.SubmitChanges();
                    MessageBox.Show("Access level removed");
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
                else
                {
                    MessageBox.Show("An error occured, contact system administrator");
                }
                btndelete.Enabled = false;
                Clear();
                btnSearch_Click(sender, e);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void level1ComboBox_DropDown(object sender, EventArgs e)
        {
            level1ComboBox.DataSource = null;
            level2ComboBox.DataSource = null;
            level2ComboBox.Enabled = false;
            //level3ComboBox.DataSource = null;
            //level3ComboBox.Enabled = false;
            //level4ComboBox.DataSource = null;
            //level4ComboBox.Enabled = false;
            if (userCategoryComboBox.SelectedIndex == -1)
            {
                errorProvider.SetError(userCategoryComboBox, "this field can't be empty");
                return;
            }
            else
            {
                errorProvider.Clear();
            }

            try
            {
                var getlevel1 = GlobalData._context.UserAccessLevel1s.ToList();
                if (getlevel1.Count() > 0)
                {
                    level1ComboBox.DataSource = getlevel1;
                    level1ComboBox.ValueMember = "ID";
                    level1ComboBox.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level1ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            level1ComboBox.DataSource = null;
            level2ComboBox.DataSource = null;
            level2ComboBox.Enabled = false;
            level3ComboBox.DataSource = null;
            level3ComboBox.Enabled = false;
            level4ComboBox.DataSource = null;
            level4ComboBox.Enabled = false;
            if (userCategoryComboBox.SelectedIndex == -1)
            {
                errorProvider.SetError(userCategoryComboBox, "this field can't be empty");
                return;
            }
            else
            {
                errorProvider.Clear();
            }
            try
            {
                var getlevel1 = GlobalData._context.UserAccessLevel1s.ToList();
                if (getlevel1.Count() > 0)
                {
                    level1ComboBox.DataSource = getlevel1;
                    level1ComboBox.ValueMember = "ID";
                    level1ComboBox.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level2ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            level2ComboBox.DataSource = null;
            level3ComboBox.DataSource = null;
            level3ComboBox.Enabled = false;
            level4ComboBox.DataSource = null;
            level4ComboBox.Enabled = false;

            try
            {
                var level2ID = (decimal)level1ComboBox.SelectedValue;
                var getlevel1 = GlobalData._context.UserAccessLevel2s.Where(u => u.Level1ID == level2ID).ToList();
                if (getlevel1.Count() > 0)
                {
                    level2ComboBox.DataSource = getlevel1;
                    level2ComboBox.ValueMember = "ID";
                    level2ComboBox.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void level3ComboBox_DropDown(object sender, EventArgs e)
        {
            level3ComboBox.DataSource = null;
            level4ComboBox.DataSource = null;
            level4ComboBox.Enabled = false;

            try
            {
                var level3ID = (decimal)level2ComboBox.SelectedValue;
                var getlevel1 = GlobalData._context.UserAccessLevel3s.Where(u => u.Level2ID == level3ID).ToList();
                if (getlevel1.Count() > 0)
                {
                    level3ComboBox.DataSource = getlevel1;
                    level3ComboBox.ValueMember = "ID";
                    level3ComboBox.DisplayMember = "Description";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void level4ComboBox_DropDown(object sender, EventArgs e)
        {
            level4ComboBox.DataSource = null;
            try
            {
                if (level3ComboBox.SelectedValue != null)
                {
                    var level3ID = (decimal)level3ComboBox.SelectedValue;
                    var getlevel1 = GlobalData._context.UserAccessLevel4s.Where(u => u.Level3ID == level3ID).ToList();
                    if (getlevel1.Count() > 0)
                    {
                        level4ComboBox.DataSource = getlevel1;
                        level4ComboBox.ValueMember = "ID";
                        level4ComboBox.DisplayMember = "Description";
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }

        private void level1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void level2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void level3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void level4ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserAccessID = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["gridID"].Value);
            var useraccess = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.ID == UserAccessID);
            if (useraccess != null)
            {
                userCategoryComboBox_DropDown(sender, e);
                userCategoryComboBox.Text = useraccess.RoleName;
                level1ComboBox_DropDown(sender, e);
                level1ComboBox.Text = useraccess.AccessLevel1;
                level2ComboBox_SelectionChangeCommitted(sender, e);
                level2ComboBox.Text = useraccess.AccessLevel2;
                level3ComboBox_DropDown(sender, e);
                level3ComboBox.Text = useraccess.AccessLevel3;
                level4ComboBox_DropDown(sender, e);
                level4ComboBox.Text = useraccess.AccessLevel4;
                printCheckBox.Checked = useraccess.CanPrint;
                addCheckBox.Checked = useraccess.CanAdd;
                editCheckBox.Checked = useraccess.CanEdit;
                viewCheckBox.Checked = useraccess.CanView;
                deleteCheckBox.Checked = useraccess.CanDelete;
                approveCheckBox.Checked = useraccess.CanApproveChanges;
            }
            btndelete.Enabled = true;
            editState = true;
            btnAdd.Text = "Edit";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                chkAll.Checked = false;
                grid.Rows.Clear();
                this.ctr = 0;
                var useraccess = GlobalData._context.UserAccessLevelsViews.Where(u =>
                    (u.AccessLevel1.Contains(level1ComboBox.Text) || u.AccessLevel1 == null) &&
                    (u.AccessLevel2.Contains(level2ComboBox.Text) || u.AccessLevel2 == null) &&
                    (u.AccessLevel3.Contains(level3ComboBox.Text) || u.AccessLevel3 == null) &&
                    (u.AccessLevel4.Contains(level4ComboBox.Text) || u.AccessLevel4 == null) &&
                    (u.RoleName.Contains(userCategoryComboBox.Text) || u.RoleName == null && u.RoleName != "Administrator")
                    );

                foreach (var userCategoryRole in useraccess)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = userCategoryRole.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1ID"].Value = userCategoryRole.AccessLevel1ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1"].Value = userCategoryRole.AccessLevel1;
                    grid.Rows[ctr].Cells["gridAccessLevel2ID"].Value = userCategoryRole.AccessLevel2ID;
                    grid.Rows[ctr].Cells["gridAccessLevel2"].Value = userCategoryRole.AccessLevel2;
                    grid.Rows[ctr].Cells["gridAccessLevel3ID"].Value = userCategoryRole.AccessLevel3ID;
                    grid.Rows[ctr].Cells["gridAccessLevel3"].Value = userCategoryRole.AccessLevel3;
                    grid.Rows[ctr].Cells["gridAccessLevel4ID"].Value = userCategoryRole.AccessLevel4ID;
                    grid.Rows[ctr].Cells["gridAccessLevel4"].Value = userCategoryRole.AccessLevel4;
                    grid.Rows[ctr].Cells["gridCanAdd"].Value = userCategoryRole.CanAdd;
                    grid.Rows[ctr].Cells["gridCanDelete"].Value = userCategoryRole.CanDelete;
                    grid.Rows[ctr].Cells["gridCanEdit"].Value = userCategoryRole.CanEdit;
                    grid.Rows[ctr].Cells["gridCanPrint"].Value = userCategoryRole.CanPrint;
                    grid.Rows[ctr].Cells["gridCanView"].Value = userCategoryRole.CanView;
                    grid.Rows[ctr].Cells["gridCanApprove"].Value = userCategoryRole.CanApproveChanges;
                    ctr++;
                }


            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (userCategoryComboBox.SelectedIndex == -1)
                {
                    errorProvider.SetError(userCategoryComboBox, "Please choose a User Category");
                    chkAll.Checked = false;
                    return;
                }
                else
                {
                    errorProvider.Clear();
                }

                this.ctr = 0;

                editState = false;
                btnAdd.Text = "Add";
                btndelete.Enabled = false;
                //userCategoryComboBox.DataSource = null;
                //userCategoryComboBox.Text = string.Empty;
                level1ComboBox.DataSource = null;
                level1ComboBox.Text = string.Empty;
                level2ComboBox.DataSource = null;
                level2ComboBox.Text = string.Empty;
                viewCheckBox.Checked = false;
                printCheckBox.Checked = false;
                addCheckBox.Checked = false;
                editCheckBox.Checked = false;
                deleteCheckBox.Checked = false;
                approveCheckBox.Checked = false;
                userCategoryComboBox.Enabled = true;
                grid.Rows.Clear();
                groupBox2.Enabled = true;

                if (chkAll.Checked == true)
                {
                    var userAccess = GlobalData._context.UserAccessLevelsViews.Where(u => u.RoleName.Contains(userCategoryComboBox.Text)).OrderBy(x => x.ID).ToList();

                    grid.Rows.Clear();
                    foreach (var userCategoryRole in userAccess)
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = userCategoryRole.ID;
                        grid.Rows[ctr].Cells["gridAccessLevel1ID"].Value = userCategoryRole.AccessLevel1ID;
                        grid.Rows[ctr].Cells["gridAccessLevel1"].Value = userCategoryRole.AccessLevel1;
                        grid.Rows[ctr].Cells["gridAccessLevel2ID"].Value = userCategoryRole.AccessLevel2ID;
                        grid.Rows[ctr].Cells["gridAccessLevel2"].Value = userCategoryRole.AccessLevel2;
                        grid.Rows[ctr].Cells["gridAccessLevel3ID"].Value = userCategoryRole.AccessLevel3ID;
                        grid.Rows[ctr].Cells["gridAccessLevel3"].Value = userCategoryRole.AccessLevel3;
                        grid.Rows[ctr].Cells["gridAccessLevel4ID"].Value = userCategoryRole.AccessLevel4ID;
                        grid.Rows[ctr].Cells["gridAccessLevel4"].Value = userCategoryRole.AccessLevel4;
                        grid.Rows[ctr].Cells["gridCanAdd"].Value = userCategoryRole.CanAdd;
                        grid.Rows[ctr].Cells["gridCanDelete"].Value = userCategoryRole.CanDelete;
                        grid.Rows[ctr].Cells["gridCanEdit"].Value = userCategoryRole.CanEdit;
                        grid.Rows[ctr].Cells["gridCanPrint"].Value = userCategoryRole.CanPrint;
                        grid.Rows[ctr].Cells["gridCanView"].Value = userCategoryRole.CanView;
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            errorProvider.Clear();
        }

        private void level1ComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            try
            {
                if (level1ComboBox.SelectedIndex > -1)
                {
                    var level1ID = (decimal)level1ComboBox.SelectedValue;
                    var getlevel2 = GlobalData._context.UserAccessLevel2s.Where(u => u.Level1ID == level1ID).ToList();
                    AccessLevel1 = level1ID;
                    if (getlevel2.Count() > 0)
                    {
                        level2ComboBox.Enabled = true;
                    }
                    else
                    {
                        level2ComboBox.Enabled = false;
                    }

                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level2ComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            try
            {
                if (level2ComboBox.SelectedIndex > -1)
                {
                    var level2ID = (decimal)level2ComboBox.SelectedValue;
                    var getlevel3 = GlobalData._context.UserAccessLevel3s.Where(u => u.Level2ID == level2ID);
                    AccessLevel2 = level2ID;

                    if (getlevel3.Count() > 0)
                    {
                        level3ComboBox.Enabled = true;
                    }
                    else
                    {
                        level3ComboBox.Enabled = false;
                    }

                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level3ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (level3ComboBox.SelectedIndex > -1)
                {
                    var level3ID = (decimal)level3ComboBox.SelectedValue;
                    var getlevel4 = GlobalData._context.UserAccessLevel4s.Where(u => u.Level3ID == level3ID);
                    AccessLevel3 = level3ID;

                    if (getlevel4.Count() > 0)
                    {
                        level4ComboBox.Enabled = true;
                    }
                    else
                    {
                        level4ComboBox.Enabled = false;
                    }

                    btnSearch_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level4ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (level4ComboBox.SelectedIndex > -1)
                {

                    var level3ID = (decimal)level4ComboBox.SelectedValue;
                    AccessLevel4 = level3ID;
                }

                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void userCategoryComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (userCategoryComboBox.Text.Trim() != string.Empty)
                {
                    groupBox2.Enabled = true;
                }
                else
                {
                    groupBox2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

            if (userCategoryComboBox.Text.Trim() != string.Empty)
            {
                btnSearch_Click(sender, e);
            }
        }
    }

    public static class MyStringExtensions
    {
        public static bool Like(this string toSearch, string toFind)
        {
            return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
        }
    }
}

