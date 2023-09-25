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
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;
using HRBussinessLayer.Validation;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class SSNIT_Contribution : Form
    {
        private SSNITContribution contribution;
        private IDAL dal;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public SSNIT_Contribution()
        {
            InitializeComponent();
            this.dal = new DAL();
            this.contribution = new SSNITContribution();
            this.GetContribution();
        }

        private void GetContribution()
        {
            try
            {
                contribution = dal.GetAll<SSNITContribution>()[0];
                if (contribution != null)
                {
                    employeePercentagetxt.Text = contribution.EmployeePercentage.ToString();
                    employerPercentagetxt.Text = contribution.EmployerPercentage.ToString();
                    ssnitFirstTierRatetxt.Text = contribution.SSNITFirstTierRate.ToString();
                    secondTierRatetxt.Text = contribution.SecondTierRate.ToString();
                    providentFundEmployeeRatetxt.Text = contribution.ProvidentFundEmployeeRate.ToString();
                    providentFundEmployerRatetxt.Text = contribution.ProvidentFundEmployerRate.ToString();
                }
                else
                {
                    employeePercentagetxt.Text = "0";
                    employerPercentagetxt.Text = "0";
                    ssnitFirstTierRatetxt.Text = "0";
                    secondTierRatetxt.Text = "0";
                    providentFundEmployeeRatetxt.Text = "0";
                    providentFundEmployerRatetxt.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            dal.CloseConnection();
            this.Close();
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private bool ValidateFiels()
        {
            bool result = true;
            try
            {
                errorProvider.Clear();

                if (employeePercentagetxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(employeePercentagetxt, "Please enter Employee Percentage");
                }
                else if (employerPercentagetxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(employerPercentagetxt, "Please enter Employer Percentage");
                }
                else if (ssnitFirstTierRatetxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(ssnitFirstTierRatetxt, "Please enter SSNIT First Tier Rate");
                }
                else if (secondTierRatetxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    errorProvider.SetError(secondTierRatetxt, "Please enter Second Tier Rate");
                }
                if (!Validator.DecimalValidator(employeePercentagetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(employeePercentagetxt, "Please enter Employee Percentage as Decimal");
                }
                else if (!Validator.DecimalValidator(employerPercentagetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(employerPercentagetxt, "Please enter Employer Percentage as Decimal");
                }
                else if (!Validator.DecimalValidator(ssnitFirstTierRatetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(ssnitFirstTierRatetxt, "Please enter SSNIT First Tier Rate as Decimal");
                }
                else if (!Validator.DecimalValidator(secondTierRatetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(secondTierRatetxt, "Please enter Second Tier Rate as Decimal");
                }
                else if (!Validator.DecimalValidator(providentFundEmployeeRatetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(secondTierRatetxt, "Please enter Provident Fund as Decimal");
                }
                else if (!Validator.DecimalValidator(providentFundEmployerRatetxt.Text.Trim()))
                {
                    result = false;
                    errorProvider.SetError(providentFundEmployerRatetxt, "Please enter Provident Fund as Decimal");
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFiels())
                {
                    this.Assign();
                    dal.Save(contribution);
                    GetContribution();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR,Please See the System Administrator");
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            contribution.EmployeePercentage = decimal.Parse(employeePercentagetxt.Text.Trim());
            contribution.EmployerPercentage = decimal.Parse(employerPercentagetxt.Text.Trim());
            contribution.SSNITFirstTierRate = decimal.Parse(ssnitFirstTierRatetxt.Text.Trim());
            contribution.SecondTierRate = decimal.Parse(secondTierRatetxt.Text.Trim());
            contribution.ProvidentFundEmployeeRate = decimal.Parse(providentFundEmployeeRatetxt.Text.Trim());
            contribution.ProvidentFundEmployerRate = decimal.Parse(providentFundEmployerRatetxt.Text.Trim());
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            employeePercentagetxt.Clear();
            employerPercentagetxt.Clear();
            ssnitFirstTierRatetxt.Clear();
            secondTierRatetxt.Clear();
            providentFundEmployeeRatetxt.Clear();
            providentFundEmployerRatetxt.Clear();
        }
        #endregion

        private void SSNIT_Contribution_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
           // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                savebtn.Enabled = getPermissions.CanAdd;
                //deleteButton.Visible = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }
    }
}
