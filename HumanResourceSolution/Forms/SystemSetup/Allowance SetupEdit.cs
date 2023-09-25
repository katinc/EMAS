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
using HRBussinessLayer.Validation;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRDataAccessLayer.Staff_Info_Data_Control;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Allowance_SetupEdit : Form
    {
        private int allowanceID;
        private int levelID;
        private EmployeeGrade grade;
        private int allowanceTypeID;
        private int allowanceCategoryID;
        private IList<AllowanceCategory> allowanceTypes;
        private IList<AllowanceSubCategory> allowanceCategories;
        private IList<EmployeeGrade> grades;
        private bool load;
        private IDAL dal;
        private IRefreshView allowanceView;
        private Allowance allowanceSetup;

        public Allowance_SetupEdit(Allowance allowanceSetup,IDAL dal,IRefreshView allowanceView)
        {
            try
            {
                InitializeComponent();
                load = true;
                this.allowanceView = allowanceView;
                this.grade = new EmployeeGrade();
                this.dal = dal;
                this.dal.OpenConnection();
                this.allowanceTypes = new List<AllowanceCategory>();
                this.allowanceCategories = new List<AllowanceSubCategory>();
                this.grades = new List<EmployeeGrade>();
                this.allowanceID = allowanceSetup.ID;
                this.levelID = allowanceSetup.Level.ID;
                this.allowanceTypeID = allowanceSetup.AllowanceType.ID;
                this.allowanceCategoryID = allowanceSetup.AllowanceSubCategory.ID;
                this.PopulateForm(allowanceSetup);
                this.load = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        public Allowance_SetupEdit()
        {
            try
            {
                InitializeComponent();
                load = true;
                this.allowanceView = new Allowance_SetupView();
                this.grade = new EmployeeGrade();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.allowanceTypes = new List<AllowanceCategory>();
                this.allowanceCategories = new List<AllowanceSubCategory>();
                this.grades = new List<EmployeeGrade>();
                this.allowanceSetup = new Allowance();
                this.allowanceID = allowanceSetup.ID;
                this.levelID = allowanceSetup.Level.ID;
                this.allowanceTypeID = allowanceSetup.AllowanceType.ID;
                this.allowanceCategoryID = allowanceSetup.AllowanceSubCategory.ID;
                this.load = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateForm(Allowance allowanceSetup)
        {
            try
            {
                levelsComboBox.Items.Add(allowanceSetup.Level.Grade);
                levelsComboBox.Text = allowanceSetup.Level.Grade;
                descriptionTextBox.Text = allowanceSetup.Description;
                txtCode.Text = allowanceSetup.Code;
                amountTextBox.Text = allowanceSetup.Amount.ToString();
                typeComboBox.Items.Add(allowanceSetup.AllowanceType.Description);
                typeComboBox.Text = allowanceSetup.AllowanceType.Description;
                categoryComboBox.Items.Add(allowanceSetup.AllowanceSubCategory.Description);
                categoryComboBox.Text = allowanceSetup.AllowanceSubCategory.Description;
                inActiveCheckBox.Checked = allowanceSetup.InUse;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != allowanceSetup.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void levelsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                grades= dal.GetAll<EmployeeGrade>();
                levelsComboBox.Items.Clear();
                levelsComboBox.Text = string.Empty;
                foreach (EmployeeGrade grade in grades)
                {
                    levelsComboBox.Items.Add(grade.Grade);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void typeComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                typeComboBox.Items.Clear();
                allowanceTypes = dal.GetAll<AllowanceCategory>();
                foreach (AllowanceCategory type in allowanceTypes)
                {
                    typeComboBox.Items.Add(type.Description);
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
                allowanceView.RefreshView();
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

        #region Clear
        private void Clear()
        {
            try
            {
                levelsComboBox.Items.Clear();
                levelsComboBox.Text = string.Empty;
                descriptionTextBox.Clear();
                typeComboBox.Items.Clear();
                typeComboBox.Text = string.Empty;
                categoryComboBox.Items.Clear();
                categoryComboBox.Text = string.Empty;
                amountTextBox.Clear();
                inActiveCheckBox.Checked = false;
                levelErrorProvider.Clear();
                descriptionErrorProvider.Clear();
                amountErrorProvider.Clear();
                txtCode.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    #region Populate Allowance Class
                    Allowance allowance = new Allowance();
                    allowance.ID = allowanceID;
                    allowance.Code = txtCode.Text.Trim();
                    allowance.AllowanceType.ID = allowanceTypeID;
                    allowance.AllowanceSubCategory.ID = allowanceCategoryID;
                    allowance.Amount = decimal.Parse(amountTextBox.Text.Trim());
                    allowance.Description = descriptionTextBox.Text.Trim();
                    allowance.InUse = inActiveCheckBox.Checked;
                    allowance.Level.ID = levelID;
                    #endregion
                    dal.Update(allowance);
                    allowanceView.RefreshView();
                    this.Clear();
                    this.Close();
                }

                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        void typeComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (!load)
                {
                    allowanceTypeID = allowanceTypes[typeComboBox.SelectedIndex].ID;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void levelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!load)
                {
                    levelID = grades[levelsComboBox.SelectedIndex].ID;
                    if (levelsComboBox.Text.Trim() != string.Empty)
                    {
                        levelErrorProvider.Clear();
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
                levelErrorProvider.Clear();
                descriptionErrorProvider.Clear();
                amountErrorProvider.Clear();

                if (levelsComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    levelErrorProvider.SetError(levelsComboBox, "Please select a level");
                    return result;
                }
                if (descriptionTextBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    descriptionErrorProvider.SetError(descriptionTextBox, "Please enter a description for the allowance");
                    return result;
                }
                if (!Validator.DecimalValidator(amountTextBox.Text.Trim()))
                {
                    result = false;
                    amountErrorProvider.SetError(amountTextBox, "Please enter a valid decimal amount");
                    return result;
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (descriptionTextBox.Text.Trim() != string.Empty)
                {
                    descriptionErrorProvider.Clear();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (amountTextBox.Text.Trim() != string.Empty)
                {
                    amountErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Allowance_SetupEdit_Load(object sender, EventArgs e)
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

        private void categoryComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                categoryComboBox.Items.Clear();
                allowanceCategories = dal.GetAll<AllowanceSubCategory>();
                foreach (AllowanceSubCategory type in allowanceCategories)
                {
                    categoryComboBox.Items.Add(type.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!load)
                {
                    allowanceCategoryID = allowanceCategories[categoryComboBox.SelectedIndex].ID;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
