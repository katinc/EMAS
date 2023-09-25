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
using HRBussinessLayer.Validation;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Deduction_Setup : Form
    {
        private IDAL dal;
        private Deduction deduction;
        private IList<DeductionCategory> categories;
        private IList<DeductionSubCategory> deductionTypes;
        private IList<SalaryType> salaryTypes;
        private int categoryID;
        private int typeID;
        private int salaryTypeID;
        private bool rateBased;

        public Deduction_Setup()
        {
            try
            {
                InitializeComponent();
                this.rateBased = false;
                this.categoryID = 0;
                this.typeID = 0;
                this.salaryTypeID = 0;
                this.dal = new DAL();
                this.deduction = new Deduction();
                this.deductionTypes=new List<DeductionSubCategory>();
                this.categories=new List<DeductionCategory>();
                this.dal.OpenConnection();
                this.typecmb.DropDown += new EventHandler(typecmb_DropDown);
                this.calculatedOncmb.DropDown += new EventHandler(calculatedOncmb_DropDown);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region UPDATE DEDUCTION ENTITY
        private void UpdateDeductionEntity()
        {
            try
            {
                deduction.Code = txtCode.Text.Trim();
                deduction.Type.Description = typecmb.Text.Trim();
                deduction.Type.ID = deductionTypes[typecmb.SelectedIndex].ID;
                deduction.Description = descriptiontxt.Text.Trim();
                deduction.Inactive = inactivechkBox.Checked;
                deduction.RateBased = rateBased;
                deduction.User.ID = GlobalData.User.ID;
                if (deduction.RateBased)
                {
                    deduction.Rate = rateNud.Value;
                    deduction.CalculatedOn.Description = calculatedOncmb.Text.Trim();
                    deduction.CalculatedOn.ID = salaryTypeID;
                    deduction.Amount = 0;
                }
                else
                {
                    deduction.Rate = 0;
                    deduction.CalculatedOn.Description = string.Empty;
                    deduction.Amount = decimal.Parse(fixedAmountTextBox.Text.Trim());
                }
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
                typecmb.Items.Clear();
                typecmb.Text = string.Empty;
                descriptiontxt.Clear();
                rateNud.ResetText();
                rateNud.Value = 0;
                calculatedOncmb.Items.Clear();
                calculatedOncmb.ResetText();
                fixedAmountTextBox.Clear();
                fixedAmountRadioButton.Checked = true;
                inactivechkBox.Checked = false;
                deductionTypeErrorProvider.Clear();
                deductionCategoryErrorProvider.Clear();
                calculatedOnErrorProvider.Clear();
                rateErrorProvider.Clear();
                fixedAmountErrorProvider.Clear();
                txtCode.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region VALIDATE FIELDS
        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                deductionTypeErrorProvider.Clear();
                deductionCategoryErrorProvider.Clear();
                calculatedOnErrorProvider.Clear();
                rateErrorProvider.Clear();
                fixedAmountErrorProvider.Clear();
                if (typecmb.Text.Trim() == string.Empty)
                {
                    result = false;
                    deductionTypeErrorProvider.SetError(typecmb, "Please select a deduction type");
                }
                if (descriptiontxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    deductionTypeErrorProvider.SetError(descriptiontxt, "Please enter the Description");
                }
                if (fixedAmountRadioButton.Checked == true)
                {
                    if (!Validator.DecimalValidator(fixedAmountTextBox.Text))
                    {
                        result = false;
                        fixedAmountErrorProvider.SetError(fixedAmountTextBox, "Please enter an amount");
                    }
                }
                else
                {
                    if (calculatedOncmb.Text.Trim() == string.Empty)
                    {
                        result = false;
                        calculatedOnErrorProvider.SetError(calculatedOncmb, "Please select the salary type the deduction is to be calculated on");
                    }
                    if (rateNud.Value == 0)
                    {
                        result = false;
                        rateErrorProvider.SetError(rateNud, "The rate must be higher than 0");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }
        #endregion

        private void typecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (typecmb.Text.Trim() != string.Empty)
                {
                    deductionTypeErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void calculatedOncmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                salaryTypeID = salaryTypes[calculatedOncmb.SelectedIndex].ID;
                if (calculatedOncmb.Text.Trim() != string.Empty)
                {
                    calculatedOnErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void rateNud_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (rateNud.Value != 0)
                {
                    rateErrorProvider.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void calculatedOncmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                calculatedOncmb.Items.Clear();
                salaryTypes = dal.GetAll<SalaryType>();
                foreach (SalaryType salary in salaryTypes)
                {
                    calculatedOncmb.Items.Add(salary.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void typecmb_DropDown(object sender, EventArgs e)
        {
            try
            {
                typecmb.Items.Clear();
                deductionTypes = dal.GetAll<DeductionSubCategory>();
                foreach (DeductionSubCategory type in deductionTypes)
                {
                    typecmb.Items.Add(type.Description);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void Deduction_Setup_Load(object sender, EventArgs e)
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                dal.CloseConnection();
                Close();
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
                if (ValidateFields())
                {
                    UpdateDeductionEntity();
                    dal.Save(deduction);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "IDNS Human Resource", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DeductionSetupView deductionsView = new DeductionSetupView(dal,this);
                deductionsView.MdiParent = this.MdiParent;
                deductionsView.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

  
        private void fixedAmountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetFixedOrRate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SetFixedOrRate()
        {
            try
            {
                if (fixedAmountRadioButton.Checked == true)
                {
                    groupBox1.Enabled = false;
                    fixedAmountTextBox.Enabled = true;
                    rateNud.ResetText();
                    calculatedOncmb.Items.Clear();
                    calculatedOncmb.ResetText();
                    rateBased = false;
                }
                else
                {
                    groupBox1.Enabled = true;
                    fixedAmountTextBox.Enabled = false;
                    fixedAmountTextBox.Clear();
                    rateBased = true;
                    calculatedOncmb.Enabled = true;
                    rateNud.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void rateBasedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SetFixedOrRate();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void fixedAmountTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (fixedAmountTextBox.Text != string.Empty)
                {
                    fixedAmountErrorProvider.Clear();
                }
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnType_Click(object sender, EventArgs e)
        {
            try
            {
                DeductionTypes deductionTypeForms = new DeductionTypes();
                deductionTypeForms.MdiParent = this.MdiParent;
                deductionTypeForms.Show();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        } 
    }
}
