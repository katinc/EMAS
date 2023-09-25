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
using HRBussinessLayer.Validation;
using HRDataAccessLayer;
using HRDataAccessLayerBase;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Deduction_SetupEdit : Form
    {
        private IDAL dal;
        private Deduction deduction;
        private IRefreshView deductionView;
        private IList<DeductionCategory> categories;
        private IList<DeductionSubCategory> deductionTypes;
        private IList<SalaryType> salaryTypes;
        private int categoryID;
        private int typeID;
        private int salaryTypeID;
        private bool loading;
        private bool rateBased;

        public Deduction_SetupEdit(Deduction deduction,IRefreshView deductionView)
        {
            try
            {
                InitializeComponent();
                this.loading = true;
                this.dal = new DAL();
                this.deductionView = deductionView;
                this.deduction = deduction;
                typecmb.Items.Add(this.deduction.Type.Description);
                typecmb.Text = this.deduction.Type.Description;
                descriptiontxt.Text = this.deduction.Description;

                if (!deduction.RateBased)
                {
                    fixedAmountTextBox.Text = deduction.Amount.ToString();
                    fixedAmountRadioButton.Checked = true;
                    calculatedOncmb.Text = string.Empty;
                    rateNud.ResetText();
                }
                else
                {
                    groupBox1.Enabled = true;
                    rateBasedRadioButton.Checked = true;
                    fixedAmountTextBox.Text = "";
                    calculatedOncmb.Items.Add(this.deduction.CalculatedOn.Description);
                    calculatedOncmb.Text = this.deduction.CalculatedOn.Description;
                    rateNud.Value = this.deduction.Rate;
                }
                inactivechkBox.Checked = this.deduction.Inactive;
                categoryID = deduction.Type.DeductionCategory.ID;
                typeID = deduction.Type.ID;
                salaryTypeID = deduction.CalculatedOn.ID;
                loading = false;
                if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID != deduction.User.ID)
                {
                    savebtn.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public Deduction_SetupEdit()
        {
            try
            {
                InitializeComponent();
                this.loading = true;
                this.dal = new DAL();
                this.deduction = new Deduction();
                typecmb.Items.Add(this.deduction.Type.Description);
                typecmb.Text = this.deduction.Type.Description;
                descriptiontxt.Text = this.deduction.Description;

                if (!deduction.RateBased)
                {
                    fixedAmountTextBox.Text = deduction.Amount.ToString();
                    fixedAmountRadioButton.Checked = true;
                    calculatedOncmb.Text = string.Empty;
                    rateNud.ResetText();
                }
                else
                {
                    groupBox1.Enabled = true;
                    rateBasedRadioButton.Checked = true;
                    fixedAmountTextBox.Text = "";
                    calculatedOncmb.Items.Add(this.deduction.CalculatedOn.Description);
                    calculatedOncmb.Text = this.deduction.CalculatedOn.Description;
                    rateNud.Value = this.deduction.Rate;
                }
                inactivechkBox.Checked = this.deduction.Inactive;
                categoryID = deduction.Type.DeductionCategory.ID;
                typeID = deduction.Type.ID;
                salaryTypeID = deduction.CalculatedOn.ID;
                loading = false;
            }
            catch (Exception ex)
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
                deduction.Type.ID = typeID;
                deduction.Description = descriptiontxt.Text.Trim();
                deduction.Inactive = inactivechkBox.Checked;
                deduction.User.ID = GlobalData.User.ID;
                if (rateBasedRadioButton.Checked)
                {
                    deduction.RateBased = true;
                    deduction.Rate = rateNud.Value;
                    deduction.CalculatedOn.Description = calculatedOncmb.Text.Trim();
                    deduction.CalculatedOn.ID = salaryTypeID;
                    deduction.Amount = 0;
                }
                else
                {
                    deduction.RateBased = false;
                    deduction.Rate = 0;
                    deduction.CalculatedOn.Description = string.Empty;
                    deduction.Amount = decimal.Parse(fixedAmountTextBox.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                calculatedOncmb.Text = string.Empty;
                inactivechkBox.Checked = false;
                descriptionErrorProvider.Clear();
                calculatedOnErrorProvider.Clear();
                rateErrorProvider.Clear();
                txtCode.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
            }
            return result;
        }
        #endregion

        #region EVENTS
        private void typecmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!loading)
                {
                    if (typecmb.Text.Trim() != string.Empty)
                    {
                        typeID = deductionTypes[typecmb.SelectedIndex].ID;
                        deductionTypeErrorProvider.Clear();
                    }
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
                if (!loading)
                {
                    if (calculatedOncmb.Text.Trim() != string.Empty)
                    {
                        salaryTypeID = salaryTypes[calculatedOncmb.SelectedIndex].ID;
                        calculatedOnErrorProvider.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

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
                salaryTypes = dal.GetAll<SalaryType>();
                calculatedOncmb.Items.Clear();
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
                    dal.Update(deduction);
                    deductionView.RefreshView();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Saving Not Successful ,See the system administrator");
            }
        }
        #endregion

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

        private void button1_Click(object sender, EventArgs e)
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
