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

namespace eMAS.Forms.SystemSetup
{
    public partial class UserRoles : Form
    {
        private IDAL dal;
        private DALHelper dalhelper;
        private UserRole userRole;
        private UserCategoryRole userCategoryRole;
        private IList<UserCategoryRole> userCategoryRoles;
        private IList<UserCategory> userCategories;
        private IList<UserAccessLevel1> userAccessLevels1;
        private IList<UserAccessLevel2> userAccessLevels2;
        private IList<UserAccessLevel3> userAccessLevels3;
        private IList<UserAccessLevel4> userAccessLevels4;
        private int ctr;

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

        //void grid_Click(object sender, EventArgs e)
        //{
        //    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    if (grid.CurrentRow != null)
        //    {
        //        if (grid.CurrentCell.ColumnIndex == 3)
        //        {
        //            gridAccessLevel1.Items.Clear();
        //            foreach (UserAccessLevel1 level1 in accessLevels)
        //            {
        //                gridAccessLevel1.Items.Add(level1.Description);
        //            }
        //        }
        //        if (grid.CurrentCell.ColumnIndex == 4)
        //        {
        //            if (grid.CurrentRow.Cells["gridAccessLevel1"].Value != null && grid.CurrentRow.Cells["gridAccessLevel1"].Value.ToString() != string.Empty)
        //            {
        //                bool usedInGrid = false;
        //                foreach (string item in gridAccessLevel2.Items)
        //                {
        //                    foreach(DataGridViewRow row in grid.Rows)
        //                    {
        //                        if (!row.IsNewRow)
        //                        {
        //                            if (item != row.Cells["gridAccessLevel2"].Value.ToString())
        //                            {
        //                                grida
        //                            }
        //                        }
        //                    }
        //                }
        //                foreach (UserAccessLevel1 level1 in accessLevels)
        //                {
        //                    if (level1.Description == grid.CurrentRow.Cells["gridAccessLevel1"].Value.ToString())
        //                    {
        //                        foreach (UserAccessLevel2 level2 in level1.AccessLevel2Items)
        //                        {
        //                            gridAccessLevel2.Items.Add(level2.Description);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        void userCategoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                userCategoryComboBox.Items.Clear();
                userCategories = dal.GetAll<UserCategory>();
                foreach (UserCategory category in userCategories)
                {
                    userCategoryComboBox.Items.Add(category.Description);
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
                userCategoryComboBox.Items.Clear();
                userCategoryComboBox.Text = string.Empty;
                level1ComboBox.Items.Clear();
                level1ComboBox.Text = string.Empty;
                level2ComboBox.Items.Clear();
                level2ComboBox.Text = string.Empty;
                viewCheckBox.Checked = false;
                printCheckBox.Checked = false;
                addCheckBox.Checked = false;
                editCheckBox.Checked = false;
                deleteCheckBox.Checked = false;
                userCategoryComboBox.Enabled = true;
                grid.Rows.Clear();
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

        private void PopulateView(IList<UserCategoryRole> userCategoryRoles)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (UserCategoryRole userCategoryRole in userCategoryRoles)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = userRole.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1ID"].Value = userCategoryRole.UserAccessLevel1.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel1"].Value = userCategoryRole.UserAccessLevel1.Description;
                    grid.Rows[ctr].Cells["gridAccessLevel2ID"].Value = userCategoryRole.UserAccessLevel2.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel2"].Value = userCategoryRole.UserAccessLevel2.Description;
                    grid.Rows[ctr].Cells["gridAccessLevel3ID"].Value = userCategoryRole.UserAccessLevel3.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel3"].Value = userCategoryRole.UserAccessLevel3.Description;
                    grid.Rows[ctr].Cells["gridAccessLevel4ID"].Value = userCategoryRole.UserAccessLevel4.ID;
                    grid.Rows[ctr].Cells["gridAccessLevel4"].Value = userCategoryRole.UserAccessLevel4.Description;
                    grid.Rows[ctr].Cells["gridCanAdd"].Value = userCategoryRole.CanAdd;
                    grid.Rows[ctr].Cells["gridCanDelete"].Value = userCategoryRole.CanDelete;
                    grid.Rows[ctr].Cells["gridCanEdit"].Value = userCategoryRole.CanEdit;
                    grid.Rows[ctr].Cells["gridCanPrint"].Value = userCategoryRole.CanPrint;
                    grid.Rows[ctr].Cells["gridCanView"].Value = userCategoryRole.CanView;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public void EditRole(UserCategoryRole userCategoryRole)
        {
            try
            {
                level1ComboBox.Items.Clear();
                level1ComboBox.Text = string.Empty;
                level2ComboBox.Items.Clear();
                level2ComboBox.Text = string.Empty;
                printCheckBox.Checked = false;
                addCheckBox.Checked = false;
                deleteCheckBox.Checked = false;
                viewCheckBox.Checked = false;
                editCheckBox.Checked = false;
                userCategoryComboBox_DropDown(this, EventArgs.Empty);
                userCategoryComboBox.Text = userCategoryRole.UserCategory.Description;
                userCategoryComboBox.Enabled = false;
                userCategoryRoles=dal.GetAll<UserCategoryRole>();
                PopulateView(userCategoryRoles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void UpdateUserRole()
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserCategoryAccessLevelsView.UserCategoryID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userCategories[userCategoryComboBox.SelectedIndex].ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserCategoryAccessLevelsView.AccessLevel1ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userAccessLevels1[level1ComboBox.SelectedIndex].ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserCategoryAccessLevelsView.AccessLevel2ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userAccessLevels2[level2ComboBox.SelectedIndex].ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserCategoryAccessLevelsView.AccessLevel3ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userAccessLevels3[level3ComboBox.SelectedIndex].ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserCategoryAccessLevelsView.AccessLevel4ID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = userAccessLevels4[level4ComboBox.SelectedIndex].ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                userAccessLevels2 = dal.GetByCriteria<UserAccessLevel2>(query);

                if (userAccessLevels2.Count == 0)
                {
                    grid.Rows.Add(1);
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel1ID"].Value = userAccessLevels1[level1ComboBox.SelectedIndex].ID;
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel1"].Value = level1ComboBox.Text.Trim();
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel2ID"].Value = userAccessLevels2[level2ComboBox.SelectedIndex].ID;
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel2"].Value = level2ComboBox.Text.Trim();
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel3ID"].Value = userAccessLevels3[level3ComboBox.SelectedIndex].ID;
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel3"].Value = level3ComboBox.Text.Trim();
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel4ID"].Value = userAccessLevels4[level4ComboBox.SelectedIndex].ID;
                    grid.Rows[grid.RowCount - 1].Cells["gridAccessLevel4"].Value = level4ComboBox.Text.Trim();
                    grid.Rows[grid.RowCount - 1].Cells["gridCanAdd"].Value = addCheckBox.Checked;
                    grid.Rows[grid.RowCount - 1].Cells["gridCanDelete"].Value = deleteCheckBox.Checked;
                    grid.Rows[grid.RowCount - 1].Cells["gridCanEdit"].Value = editCheckBox.Checked;
                    grid.Rows[grid.RowCount - 1].Cells["gridCanPrint"].Value = printCheckBox.Checked;
                    grid.Rows[grid.RowCount - 1].Cells["gridCanView"].Value = viewCheckBox.Checked;

                    //foreach (DataGridViewRow row in grid.Rows)
                    //{
                    //    userCategoryRole = new UserCategoryRole();

                    //    userCategoryRole.UserCategory = userCategories[userCategoryComboBox.SelectedIndex];
                    //    userCategoryRole.AccessAreas.Clear();
                    //    userRole.AccessAreas.Add(new UserAccessLevel1()
                    //    {
                    //        Description = level1ComboBox.Text,
                    //        ID = userAccessLevels1[level1ComboBox.SelectedIndex].ID
                    //    });
                    //    userRole.AccessAreas[0].AccessLevel2Items.Clear();
                    //    userRole.AccessAreas[0].AccessLevel2Items.Add(new UserAccessLevel2()
                    //    {
                    //        Description = level2ComboBox.Text,
                    //        ID = accessLevels[level1ComboBox.SelectedIndex].AccessLevel2Items[level2ComboBox.SelectedIndex].ID,
                    //        CanAdd = addCheckBox.Checked,
                    //        CanDelete = deleteCheckBox.Checked,
                    //        CanEdit = editCheckBox.Checked,
                    //        CanPrint = printCheckBox.Checked,
                    //        CanView = viewCheckBox.Checked
                    //    });
                    //    dal.Save(userCategoryRole);

                    //    level1ComboBox.Items.Clear();
                    //    level1ComboBox.Text = string.Empty;
                    //    level2ComboBox.Items.Clear();
                    //    level2ComboBox.Text = string.Empty;
                    //    printCheckBox.Checked = false;
                    //    addCheckBox.Checked = false;
                    //    deleteCheckBox.Checked = false;
                    //    viewCheckBox.Checked = false;
                    //    editCheckBox.Checked = false;
                    //}
                }
                else
                {
                    GlobalData.ShowMessage("The user role you are creating already exists");
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
                if (ValidateFields())
                {
                    UpdateUserRole();
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
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        dalhelper.ExecuteNonQuery("Delete from UserCategoryAccessLevels Where ID = " + grid.CurrentRow.Cells["gridID"].Value);
                    }
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void level1ComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                level1ComboBox.Items.Clear();
                userAccessLevels1 = dal.GetAll<UserAccessLevel1>();
                foreach (UserAccessLevel1 level1 in userAccessLevels1)
                {
                    level1ComboBox.Items.Add(level1.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level1ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserAccessLevel1View.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = level1ComboBox.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                userAccessLevels2 = dal.GetByCriteria<UserAccessLevel2>(query);
                level2ComboBox.Items.Clear();
                level2ComboBox.Text = string.Empty;
                foreach (UserAccessLevel2 userAccessLevel2 in userAccessLevels2)
                {
                    level2ComboBox.Items.Add(userAccessLevel2.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void level2ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion()
                {
                    Property = "UserAccessLevel2View.Description",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = level1ComboBox.SelectedItem.ToString(),
                    CriteriaOperator = CriteriaOperator.And
                });
                userAccessLevels3 = dal.GetByCriteria<UserAccessLevel3>(query);
                level3ComboBox.Items.Clear();
                level3ComboBox.Text = string.Empty;
                foreach (UserAccessLevel3 userAccessLevel3 in userAccessLevels3)
                {
                    level3ComboBox.Items.Add(userAccessLevel3.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
