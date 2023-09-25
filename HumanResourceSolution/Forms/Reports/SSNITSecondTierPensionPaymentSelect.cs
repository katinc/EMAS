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
using HRDataAccessLayer;
using HRBussinessLayer.System_Setup_Class;

namespace eMAS.Forms.Reports
{
    public partial class SSNITSecondTierPensionPaymentSelect : Form
    {
        private IList<PayRollAttendance> payRollAttendances;
        private PayRollAttendance payRollAttendance;
        private IDAL dal;
        private Form reportForm;
        private IList<Company> company;

        public SSNITSecondTierPensionPaymentSelect()
        {
            try
            {
                InitializeComponent();
                this.payRollAttendances = new List<PayRollAttendance>();
                this.payRollAttendance = new PayRollAttendance();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.reportForm = new Form();
                this.company = new List<Company>();
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void yearComboBox_DropDown(object sender, EventArgs e)
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

        private void monthComboBox_DropDown(object sender, EventArgs e)
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

        private void SSNITSecondTierPensionPaymentSelect_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                company = dal.GetAll<Company>();
                if (company[0].PaymentFrequency == "Monthly")
                {
                    periodLabel.Text = "Month:";
                }
                else
                {
                    periodLabel.Text = "Week:";
                }
                Reset();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                GlobalData.LogError(ex);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (monthComboBox.Text.Trim() != string.Empty && yearComboBox.Text != string.Empty)
                {
                    Query query = new Query();
                    payRollAttendance.Month = int.Parse(GlobalData.GetMonth(monthComboBox.Text).ToString());
                    payRollAttendance.Year = int.Parse(yearComboBox.Text);

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
                        if (cboFormat.Text.ToLower() == "name separated")
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            reportForm = new SSNITSecondTierPensionPaymentFormatForm(monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                        else
                        {
                            if (reportForm != null && !reportForm.IsDisposed)
                            {
                                reportForm.Close();
                            }
                            reportForm = new SSNITSecondTierPensionPaymentForm(monthComboBox.Text.Trim(), yearComboBox.Text.Trim(), cboMechanised.Text.Trim());
                            reportForm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("The payroll for the selected period must be generated first", GlobalData.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                throw ex;
            }
        }

        private void Reset()
        {
            try
            {
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
    }
}
