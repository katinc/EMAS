using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HRBussinessLayer.System_Setup_Class;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.All_UIs.System_SetupFORMS
{
    public partial class Loans_Setup : Form
    {
        private Loan loansSetup;
        private IDAL dal;
        private IList<LoanType> loanTypes;
        private int typeID;
        private int loanSetupID;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public Loans_Setup()
        {
            try
            {
                this.loansSetup = new Loan();
                this.dal = new DAL();
                this.loanTypes=new List<LoanType>();
                this.typeID = 0;
                this.loanSetupID = 0;
                this.dal.OpenConnection();
                this.InitializeComponent();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void closebtn_Click(object sender, EventArgs e)
        {
            try
            {
                dal.CloseConnection();
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
                    dal.Save(loansSetup);
                    this.Clear();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void viewbtn_Click(object sender, EventArgs e)
        {
            try
            {
                LoansSetupView loansView = new LoansSetupView(dal);
                loansView.deleteButton.Enabled = CanDelete;
                loansView.Show();
               
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            try
            {
                loansSetup.ID = loanSetupID;
                loansSetup.Description = descriptiontxt.Text;
                loansSetup.Inactive = inactivechkBox.Checked;
                loansSetup.Type.ID = typeID = 1;
                loansSetup.User.ID = GlobalData.User.ID;
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
                descriptiontxt.Clear();
                inactivechkBox.Checked = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
            }
            return result;
        }
        #endregion

        private void Loans_Setup_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                descriptiontxt.Select();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    savebtn.Enabled = getPermissions.CanAdd;
                    viewbtn.Enabled = getPermissions.CanView;
                    CanDelete = getPermissions.CanDelete;
                    CanEdit = getPermissions.CanEdit;
                    CanAdd = getPermissions.CanAdd;
                    CanPrint = getPermissions.CanPrint;
                    CanView = getPermissions.CanView;
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
    }
}
