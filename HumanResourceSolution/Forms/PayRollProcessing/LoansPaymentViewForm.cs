using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.PayRoll_Processing_CLASS;
using HRDataAccessLayerBase;
using HRDataAccessLayer;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class LoansPaymentViewForm : Form
    {
        private IDAL dal;
        private StaffLoan staffLoan;
        private StaffLoanPayment staffLoanPayment;
        private Loans_Payments newForm;

        public LoansPaymentViewForm()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    StaffLoanPayment staffLoanPayment = new StaffLoanPayment();
                    staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                    staffLoanPayment.StaffLoan.Employee.StaffID = grid.CurrentRow.Cells["gridStaffID"].Value.ToString();
                    staffLoanPayment.StaffLoan.Employee.ID = int.Parse(grid.CurrentRow.Cells["gridStaffCode"].Value.ToString());
                    staffLoanPayment.StaffLoan.StaffName = grid.CurrentRow.Cells["gridStaffName"].Value.ToString();
                    staffLoanPayment.Amount = decimal.Parse(grid.CurrentRow.Cells["gridAmount"].Value.ToString());
                    staffLoanPayment.StaffLoan.AmountToBePaid = decimal.Parse(grid.CurrentRow.Cells["gridAmountToBePaid"].Value.ToString());
                    staffLoanPayment.StaffLoan.MonthlyInstallment = decimal.Parse(grid.CurrentRow.Cells["gridMonthlyInstallment"].Value.ToString());
                    staffLoanPayment.PaymentDate = DateTime.Parse(grid.CurrentRow.Cells["gridPaymentDate"].Value.ToString());
                    staffLoanPayment.NotAffectSalary = bool.Parse(grid.CurrentRow.Cells["gridNotAffectSalary"].Value.ToString());
                    staffLoanPayment.User.ID = int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString());
                    newForm.StaffLoanPayment = staffLoanPayment;
                    newForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["gridStaffName"].Value.ToString() + "'s selected loan information?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {                        
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.BeginTransaction();
                                staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLoanPayment);
                                dal.CommitTransaction();
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.BeginTransaction();
                                staffLoanPayment.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                dal.Delete(staffLoanPayment);
                                dal.CommitTransaction();
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void LoansPaymentViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
