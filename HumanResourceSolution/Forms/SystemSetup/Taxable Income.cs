using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.Validation;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Taxable_Income : Form
    {
        TaxableIncome taxableIncome;
        TaxableIncomeDataMapper taxableIncomeManip;
        IDAL dal;

        public Taxable_Income()
        {
            taxableIncome = new TaxableIncome();
            taxableIncomeManip = new TaxableIncomeDataMapper();
            dal = new DAL();
            taxableIncomeManip.OpenConnection();
            InitializeComponent();
            yearTextBox.DropDown += new EventHandler(yearTextBox_DropDown);
            descriptionTextBox.DropDown += new EventHandler(descriptionTextBox_DropDown);
        }

        void descriptionTextBox_DropDown(object sender, EventArgs e)
        {
            descriptionTextBox.Items.Clear();
            descriptionTextBox.Items.Add("First");
            descriptionTextBox.Items.Add("Next");
            descriptionTextBox.Items.Add("Over");
        }

        void yearTextBox_DropDown(object sender, EventArgs e)
        {
            yearTextBox.Items.Clear();
            foreach (string item in GlobalData.GetYears())
            {
                yearTextBox.Items.Add(item);
            }
            yearTextBox.Items.Add(DateTime.Now.Date.Year);
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            taxableIncomeManip.CloseConnection();
            this.Close();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.Assign();
                try
                {
                    taxableIncomeManip.Save(taxableIncome);
                    this.Clear();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void findbtn_Click(object sender, EventArgs e)
        {

        }

        #region VALIDATE FIELDS
        private bool ValidateFields()
        {
            bool result = true;
            yearErrorProvider.Clear();
            descriptionErrorProvider.Clear();
            annualTaxErrorProvider.Clear();
            taxRateErrorProvider.Clear();

            if (yearTextBox.Text.Trim() == string.Empty)
            {
                result = false;
                yearErrorProvider.SetError(yearTextBox, "Please enter a year");
            }
            if (!Validator.IntegerValidator(yearTextBox.Text))
            {
                result = false;
                yearErrorProvider.SetError(yearTextBox,"Please enter a valid year");
            }
            if (yearTextBox.Text.Trim().Length < 4 || yearTextBox.Text.Trim().Length > 4 )
            {
                result = false;
                yearErrorProvider.SetError(yearTextBox, "The year must be a four digit integer");
            }
            if (descriptionTextBox.Text.Trim() == string.Empty)
            {
                result = false;
                descriptionErrorProvider.SetError(descriptionTextBox, "Please enter a description");
            }
            if (!Validator.DecimalValidator(annualTaxTextBox.Text))
            {
                result = false;
                annualTaxErrorProvider.SetError(annualTaxTextBox, "Please enter a valid decimal as the annual taxable income");
            }
            if (!Validator.DecimalValidator(taxRateTextBox.Text))
            {
                result = false;
                taxRateErrorProvider.SetError(taxRateTextBox, "Please enter a valid decimal as the tax rate");
            }
            else
            {
                if (decimal.Parse(taxRateTextBox.Text) > 100)
                {
                    result = false;
                    taxRateErrorProvider.SetError(taxRateTextBox, "The tax rate must be 100 or less");
                }
            }
            return result;
        }
        #endregion

        #region ASSIGNMENTS
        private void Assign()
        {
            taxableIncome.AnnualTaxableIncome = decimal.Parse(annualTaxTextBox.Text);
            taxableIncome.Description = descriptionTextBox.Text;
            taxableIncome.TaxRate = decimal.Parse(taxRateTextBox.Text);
            taxableIncome.Year = int.Parse(yearTextBox.Text);
            taxableIncome.Active = checkBoxActive.Checked;
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            yearTextBox.Items.Clear();
            yearTextBox.Text = string.Empty;
            taxRateTextBox.Clear();
            descriptionTextBox.Items.Clear();
            descriptionTextBox.Text = string.Empty;
            annualTaxTextBox.Clear();
        }
        #endregion

        private void Taxable_Income_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            yearTextBox.Select();
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void yearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (yearTextBox.Text.Trim() == string.Empty)
            {
                yearErrorProvider.Clear();
            }
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (descriptionTextBox.Text.Trim() == string.Empty)
            {
                descriptionErrorProvider.Clear();
            }
        }

        private void annualTaxTextBox_TextChanged(object sender, EventArgs e)
        {
            if (annualTaxTextBox.Text.Trim() == string.Empty)
            {
                annualTaxErrorProvider.Clear();
            }
        }

        private void taxRateTextBox_TextChanged(object sender, EventArgs e)
        {
            if (taxRateTextBox.Text.Trim() == string.Empty)
            {
                taxRateErrorProvider.Clear();
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            TaxableIncomeView taxableView = new TaxableIncomeView(taxableIncomeManip);
            taxableView.Show();
        }
    }
}
