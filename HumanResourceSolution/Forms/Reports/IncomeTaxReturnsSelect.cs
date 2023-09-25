using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer;

namespace eMAS.Forms.Reports
{
    public partial class IncomeTaxReturnsSelect : Form
    {
        private IList<PayRollAttendance> payRollAttendances;
        private PayRollAttendance payRollAttendance;
        private IDAL dal;
        private Form reportForm;
        private bool mechanised;
        private IList<Company> company;

        public IncomeTaxReturnsSelect()
        {
            try
            {
                InitializeComponent();
                this.payRollAttendances = new List<PayRollAttendance>();
                this.payRollAttendance = new PayRollAttendance();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.mechanised = false;
                this.company = new List<Company>();

            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        void yearComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                yearComboBox.Items.Clear();
                foreach (string item in GlobalData.GetYears())
                {
                    yearComboBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
                throw ex;
            }
        }

        void monthComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                monthComboBox.Items.Clear();
                monthComboBox.Items.Add("All");
                if (company[0].PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";

                    foreach (string item in GlobalData.GetMonths())
                    {
                        monthComboBox.Items.Add(item);
                    }
                }
                else
                {
                    for (int i = 0; i <= 52; i++)
                    {
                        periodLabel.Text = "Week:";
                        monthComboBox.Items.Add("Week " + i.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void IncomeTaxReturnsSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Reset();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                if (monthComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(monthComboBox, "Please Select the Month");
                    monthComboBox.Focus();
                }
                if (yearComboBox.Text.Trim() == string.Empty)
                {
                    result = false;
                    staffErrorProvider.SetError(yearComboBox, "Please enter the Year");
                    yearComboBox.Focus();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    Query query = new Query();
                    payRollAttendance.Month = int.Parse(GlobalData.GetMonth(monthComboBox.Text).ToString());
                    payRollAttendance.Year = int.Parse(yearComboBox.Text);
                    if (cboMechanised.Text.ToLower().Trim() != "all" && cboMechanised.Text.ToLower().Trim() != string.Empty)
                    {
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "StaffSalaryPaymentView.Mechanised",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = mechanised,
                            CriteriaOperator = CriteriaOperator.And
                        });
                    }
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Month",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = payRollAttendance.Month,
                        CriteriaOperator = CriteriaOperator.And
                    });
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "StaffSalaryPaymentView.Year",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = payRollAttendance.Year,
                        CriteriaOperator = CriteriaOperator.None
                    });
                    payRollAttendances = dal.GetByCriteria<PayRollAttendance>(query);
                    if (payRollAttendances.Count > 0)
                    {
                        if (reportForm != null && !reportForm.IsDisposed)
                        {
                            reportForm.Close();
                        }
                        reportForm = new IncomeTaxReturnsReportForm(monthComboBox.Text.Trim(), yearComboBox.Text.Trim(),cboMechanised.Text.Trim());
                        reportForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("The payroll for the selected criterior must be generated first", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Reset()
        {
            try
            {
                company = dal.GetAll<Company>();
                if (company[0].PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
                monthComboBox.Items.Add(((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString());
                monthComboBox.Text = ((Months)Enum.Parse(typeof(Months), GlobalData.ServerDate.Month.ToString())).ToString();
                yearComboBox.Items.Add(GlobalData.ServerDate.Year.ToString());
                yearComboBox.Text = GlobalData.ServerDate.Year.ToString();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }

        }

        private void cboMechanised_DropDown(object sender, EventArgs e)
        {
            try
            {
                cboMechanised.Items.Clear();
                cboMechanised.Text = string.Empty;
                cboMechanised.Items.Add("All");
                cboMechanised.Items.Add("Yes");
                cboMechanised.Items.Add("No");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboMechanised_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMechanised.Text.Trim() == "Yes")
                {
                    mechanised = true;
                }
                else if (cboMechanised.Text.Trim() == "No")
                {
                    mechanised = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
