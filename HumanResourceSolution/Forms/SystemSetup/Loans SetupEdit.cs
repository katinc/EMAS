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
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class LoansSetupEdit : Form
    {
        private IList<LoanType> loanTypes;
        private IDAL dal;
        private Loan loan;
        private IRefreshView loanView;
        private int loanID;
        private int typeID;

        public LoansSetupEdit(IDAL dal,Loan loan,IRefreshView loanView)
        {
            try
            {
                InitializeComponent();
                this.dal = dal;
                this.loan = loan;
                this.loanID = loan.ID;
                this.loanView = loanView;
                this.descriptiontxt.Text = loan.Description;
                this.typeID = loan.Type.ID;
                this.inactivechkBox.Checked = loan.Inactive;
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public LoansSetupEdit()
        {
            try
            {
                InitializeComponent();
                this.loanView = new LoansSetupView();
                this.dal = new DAL();
                this.loan = new Loan();
                this.loanID = loan.ID;
                this.descriptiontxt.Text = loan.Description;
                this.typeID = loan.Type.ID;
                this.inactivechkBox.Checked = loan.Inactive;
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
                this.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.Assign();
                try
                {
                    dal.Update(loan);
                    loanView.RefreshView();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            try
            {
                loan.ID = loanID;
                loan.Description = descriptiontxt.Text;
                loan.Type.ID = 1;
                loan.Inactive = inactivechkBox.Checked;
                loan.User.ID = GlobalData.User.ID;
            }
            catch(Exception ex)
            {
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
                inactivechkBox.Checked = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
        #endregion

        #region Validate Fields
        private bool ValidateFields()
        {
            bool result = true;
            try
            {
                typeErrorProvider.Clear();
                descriptionErrorProvider.Clear();

                if (descriptiontxt.Text.Trim() == string.Empty)
                {
                    result = false;
                    descriptionErrorProvider.SetError(descriptiontxt, "Please enter a description");
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

        private void LoansSetupEdit_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                descriptiontxt.Select();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
