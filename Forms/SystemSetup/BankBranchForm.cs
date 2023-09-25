using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayer;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;


namespace eMAS.Forms.SystemSetup
{
    public partial class BankBranchForm : Form
    {
        private IDAL dal;
        private Bank bank;
        private BankBranch bankBranch;
        private IList<Bank> banks;
        private IList<BankBranch> bankBranches;
        private IList<BankBranch> foundBankBranches;
        private int ctr;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public BankBranchForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.bank = new Bank();
                this.bankBranch = new BankBranch();
                this.banks = new List<Bank>();
                this.foundBankBranches = new List<BankBranch>();
                this.bankBranches = new List<BankBranch>();
                this.ctr = 0;
                this.found = false;
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
                errorProvider.Clear();
                if (cboBank.Text.ToString() == null || cboBank.Text.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Bank ");
                    cboBank.Focus();
                }
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridCode"].Value == null)
                        {
                            if (GlobalData.QuestionMessage("Code is empty for row " + (row.Index + 1) + ".\nWould you like to continue it?") == DialogResult.Yes)
                            {
                                row.Cells["gridCode"].Value = string.Empty;
                            }
                            else
                            {
                                result = false;
                                MessageBox.Show("Code cannot be empty" + (row.Index + 1));
                                grid.Rows[row.Index + 1].Selected = true;
                            }
                        }
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

        private void GetData()
        {
            try
            {

                if (cboBank.Text.Trim() == string.Empty)
                {
                    bank.ID=0;
                }
                else
                {
                    bank.ID=banks[cboBank.SelectedIndex].ID;
                }
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "BankBranchView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "BankBranchView.BankID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = bank.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                bankBranches = dal.GetByCriteria<BankBranch>(query);
                PopulateView(bankBranches);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            bankBranch.Description = row.Cells["gridDescription"].Value.ToString();
                            bankBranch.Code = row.Cells["gridCode"].Value.ToString();
                            bankBranch.SortCode = row.Cells["gridSortCode"].Value != null ? Convert.ToString(row.Cells["gridSortCode"].Value) : string.Empty;
                            bankBranch.Bank.ID = banks[cboBank.SelectedIndex].ID;
                            bankBranch.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            bankBranch.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {

                                dal.Save(bankBranch);
                            }
                            else
                            {
                                bankBranch.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(bankBranch);
                            }
                        }
                    }
                  
                    dal.CommitTransaction();

                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
            }
            GetData();
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                bankBranch.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                bankBranch.Active = false;
                                bankBranch.Archived = true;
                                dal.Delete(bankBranch);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                bankBranch.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                bankBranch.Active = false;
                                bankBranch.Archived = true;
                                dal.Delete(bankBranch);
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
            }
        }

        private void PopulateView(IList<BankBranch> bankBranches)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (BankBranch bankBranch in bankBranches)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = bankBranch.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = bankBranch.Description;
                    grid.Rows[ctr].Cells["gridCode"].Value = bankBranch.Code;
                    grid.Rows[ctr].Cells["gridSortCode"].Value = bankBranch.SortCode;
                    grid.Rows[ctr].Cells["gridBankID"].Value = bankBranch.Bank.ID.ToString();
                    grid.Rows[ctr].Cells["gridActive"].Value = bankBranch.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = bankBranch.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundBankBranches.Clear();
                cboBank.Items.Clear();
                bankBranches = dal.GetAll<BankBranch>();
                foreach (BankBranch bankBranch in bankBranches)
                {
                    if ((bankBranch.Code.Trim().ToLower().StartsWith(txtCode.Text.Trim().ToLower())))
                    {
                        foundBankBranches.Add(bankBranch);
                    }
                }
                PopulateView(foundBankBranches);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundBankBranches.Clear();
                cboBank.Items.Clear();
                bankBranches = dal.GetAll<BankBranch>();
                foreach (BankBranch bankBranch in bankBranches)
                {
                    if ((bankBranch.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundBankBranches.Add(bankBranch);
                    }
                }
                PopulateView(foundBankBranches);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBank.Text != string.Empty)
                {
                    foundBankBranches.Clear();
                    Clear();
                    bankBranches = dal.GetAll<BankBranch>();
                    grid.Rows.Clear();
                    foreach (BankBranch bankBranch in bankBranches)
                    {
                        if (bankBranch.Bank.ID == banks[cboBank.SelectedIndex].ID)
                        {
                            foundBankBranches.Add(bankBranch);
                        }
                    }
                    PopulateView(foundBankBranches);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboBank_DropDown(object sender, EventArgs e)
        {
            try
            {
                banks = dal.GetAll<Bank>();
                cboBank.Items.Clear();
                Clear();
                cboBank.Text = string.Empty;
                foreach (Bank bank in banks)
                {
                    cboBank.Items.Add(bank.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboBank_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                if(cboBank.Text != string.Empty)
                {
                    foundBankBranches.Clear();
                    Clear();
                    bankBranches = dal.GetAll<BankBranch>();
                    grid.Rows.Clear();
                    foreach (BankBranch bankBranch in bankBranches)
                    {
                        if (bankBranch.Bank.ID == banks[cboBank.SelectedIndex].ID)
                        {
                            foundBankBranches.Add(bankBranch);
                        }
                    }
                    PopulateView(foundBankBranches);
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void Clear()
        {
            try
            {
                txtCode.Clear();
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void BankBranchForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Enabled = getPermissions.CanAdd;
                    btnDelete.Enabled = getPermissions.CanDelete;
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
    }
}
