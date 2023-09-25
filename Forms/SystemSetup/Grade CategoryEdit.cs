using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class GradeCategoryEdit : Form
    {
        EmployeeGradeCategoryDataMapper dalHelper;
        IRefreshView viewForm;
        private string categoryCode;
        private IDAL dal;

        public GradeCategoryEdit(bool active,string description, string code,string categoryCode,int userID,IRefreshView viewForm)
        {
            InitializeComponent();
            descriptiontxt.Text = description;
            codetxt.Text = code;
            checkBoxActive.Checked = active;
            this.viewForm = viewForm;
            dalHelper = new EmployeeGradeCategoryDataMapper();
            this.categoryCode = categoryCode;
            dal = new DAL();
        }

        public GradeCategoryEdit()
        {
            InitializeComponent();
            this.viewForm = new Grade_CategoryView();
            descriptiontxt.Text = string.Empty;
            codetxt.Text = string.Empty;
            checkBoxActive.Checked = false;
            dalHelper = new EmployeeGradeCategoryDataMapper();
            this.categoryCode = string.Empty;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateView())
            {
                GradeCategory gradeCategory = new GradeCategory();
                gradeCategory.Code = codetxt.Text.Trim();
                gradeCategory.ID = int.Parse(categoryCode);
                gradeCategory.Description = descriptiontxt.Text.Trim();
                gradeCategory.Active = checkBoxActive.Checked;
                gradeCategory.User.ID = GlobalData.User.ID;
                try
                {
                    bool result = true;
                    codeErrorProvider.Clear();
                    dalHelper.OpenConnection();
                    foreach (GradeCategory category in dalHelper.GetAll())
                    {
                        if (category.Code == codetxt.Text.Trim() && category.ID != gradeCategory.ID)
                        {
                            codeErrorProvider.SetError(codetxt, "The code you have entered already exists");
                            result = false;
                        }

                    }
                    if (descriptiontxt.Text.Trim() == string.Empty)
                    {
                        descriptionErrorProvider.SetError(descriptiontxt, "Please enter a description for the grade category");
                        result = false;
                    }
                    if (result)
                    {
                        dalHelper.Update(gradeCategory);
                        this.Close();
                        viewForm.RefreshView();
                    }
                    dalHelper.CloseConnection();         
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            descriptiontxt.Clear();
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            viewForm.RefreshView();
            this.Close();
        }

        private void GradeCategoryEdit_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        #region Validate view
        private bool ValidateView()
        {
            bool result = true;
            descriptionErrorProvider.Clear();

            if (descriptiontxt.Text == string.Empty)
            {
                result = false;
                descriptionErrorProvider.SetError(descriptiontxt, "Please enter a description");
            }
            if (codetxt.Text == string.Empty)
            {
                result = false;
                codeErrorProvider.SetError(codetxt, "Please enter a code");
            }
            return result;
        }
        #endregion

        private void descriptiontxt_TextChanged(object sender, EventArgs e)
        {
            if (descriptiontxt.Text.Trim() != string.Empty)
            {
                descriptionErrorProvider.Clear();
            }
        }
        
    }
}
