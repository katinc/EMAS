using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;
namespace eMAS.Forms.SystemSetup
{
    public partial class UserCategories : Form
    {
        IDAL dal;
        IList<UserCategory> userCategories;
        UserCategory userCategory;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public UserCategories()
        {
            InitializeComponent();
            userCategory = new UserCategory();
            userCategories = new List<UserCategory>();
            dal = new DAL();
            dal.OpenConnection();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            savebtn.Visible = false;
            grid.Rows.Add(1);
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (grid.CurrentRow.Cells["gridID"].EditedFormattedValue != null && grid.CurrentRow.Cells["gridID"].EditedFormattedValue.ToString().Trim() != string.Empty)
                {
                    if (MessageBox.Show("Are you sure you want to delete the selected user category?", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        try
                        {
                            userCategory.ID = int.Parse(grid.CurrentRow.Cells["gridID"].EditedFormattedValue.ToString());
                            dal.Delete(userCategory);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            savebtn.Visible = true;
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
                else 
                {
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    savebtn.Visible = true;
                }
            }
        }

        private void UserCategories_Load(object sender, EventArgs e)
        {
            GetCategories();
            grid.Enabled = true;
            grid.EditMode = DataGridViewEditMode.EditOnKeystroke;
          //  GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                clearbtn.Visible = getPermissions.CanAdd;
                viewbtn.Visible = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    userCategory = new UserCategory();
                    userCategory.UserID = GlobalData.User.ID;
                    userCategory.Description = row.Cells["gridDescription"].EditedFormattedValue.ToString();
                    if (row.Cells["gridID"].EditedFormattedValue != null && row.Cells["gridID"].EditedFormattedValue.ToString().Trim() != string.Empty)
                    {
                        userCategory.ID = int.Parse(row.Cells["gridID"].EditedFormattedValue.ToString());
                        dal.Update(userCategory);
                    }
                    else
                    {
                        dal.Save(userCategory);
                    }
                }
                GetCategories();
                savebtn.Visible = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            
        }

        private void GetCategories()
        {

            userCategories = dal.GetAll<UserCategory>();
            int ctr = 0;
            grid.Rows.Clear();
            foreach (UserCategory category in userCategories)
            {
                grid.Rows.Add(1);
                grid.Rows[ctr].Cells["gridID"].Value = category.ID;
                grid.Rows[ctr].Cells["gridDescription"].Value = category.Description;
                ctr++;
            }
        }
    }
}
