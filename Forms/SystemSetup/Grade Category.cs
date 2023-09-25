using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Grade_Category : Form
    {
        private EmployeeGradeCategoryDataMapper gradeCategoryManip;
        private GradeCategory gradeCategory;
        private IDAL dal;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public Grade_Category()
        {
            try
            {
                gradeCategoryManip = new EmployeeGradeCategoryDataMapper();
                gradeCategory = new GradeCategory();
                dal = new DAL();
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                gradeCategoryManip.CloseConnection();
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

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateView())
                {
                    Assign();
                    bool result = true;
                    codeErorProvider.Clear();
                    gradeCategoryManip.OpenConnection();
                    if (descriptiontxt.Text.Trim() == string.Empty)
                    {
                        descriptionErrorProvider.SetError(descriptiontxt, "Please enter a description for the grade category");
                        result = false;
                    }
                    if (txtOvertime.Text.Trim() == string.Empty)
                    {
                        descriptionErrorProvider.SetError(txtOvertime, "Please enter an Overtime rate for the grade category");
                        result = false;
                    }
                    if (txtLeaveEncashment.Text.Trim() == string.Empty)
                    {
                        descriptionErrorProvider.SetError(txtLeaveEncashment, "Please enter a Leave encashment rate for the grade category");
                        result = false;
                    }
                    foreach (GradeCategory category in gradeCategoryManip.GetAll())
                    {
                        if (category.Code == codetxt.Text.Trim())
                        {
                            codeErorProvider.SetError(codetxt, "The code you have entered already exists");
                            result = false;
                        }

                    }
                    if (result)
                    {
                        gradeCategoryManip.Save(gradeCategory);
                        Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                Grade_CategoryView gradeCategoryView = new Grade_CategoryView();
                gradeCategoryView.btnRemove.Enabled = CanDelete;
                gradeCategoryView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Grade_Category_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                descriptiontxt.Select();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    viewbtn.Enabled = getPermissions.CanView;
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
                MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            try
            {
                gradeCategory.Code = codetxt.Text.Trim();
                gradeCategory.Description = descriptiontxt.Text.Trim();
                gradeCategory.Active = checkBoxActive.Checked;
                gradeCategory.User.ID = GlobalData.User.ID;
                gradeCategory.LeaveEncashmentRate = txtLeaveEncashment.Text;
                gradeCategory.OverTimeRate = txtOvertime.Text;

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
                descriptiontxt.Clear();
                codetxt.Clear();
                txtOvertime.Clear();
                txtLeaveEncashment.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
        #endregion

        #region Validate view
        private bool ValidateView()
        {
            bool result = true;
            try
            {
                descriptionErrorProvider.Clear();

                if (descriptiontxt.Text == string.Empty)
                {
                    result = false;
                    descriptionErrorProvider.SetError(descriptiontxt, "Please enter a description");
                }
                if (codetxt.Text == string.Empty)
                {
                    result = false;
                    codeErorProvider.SetError(codetxt, "Please enter a code");
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }
        #endregion

        private void descriptiontxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (descriptiontxt.Text.Trim() != string.Empty)
                {
                    descriptionErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void codetxt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (codetxt.Text.Trim() != string.Empty)
                {
                    codeErorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
