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
    public partial class BankForm : Form
    {
        private IDAL dal;
        private Bank bank;
        private IList<Bank> banks;
        private IList<Bank> foundBanks;
        private int ctr;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;



        public BankForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.bank = new Bank();
                this.banks=new List<Bank>();
                this.foundBanks = new List<Bank>();
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
                        if (row.Cells["gridCode"].Value == null)
                        {
                            if (GlobalData.QuestionMessage("Code is empty for " + (row.Index + 1) + ".\nWould you like to continue it?") == DialogResult.Yes)
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
                //Query query = new Query();
                //if (GlobalData.User.UserCategory.Description == "Basic")
                //{
                //    found = true;
                //}
                //if (found == true)
                //{
                //    query.Criteria.Add(new Criterion()
                //    {
                //        Property = "BankView.UserID",
                //        CriterionOperator = CriterionOperator.EqualTo,
                //        Value = GlobalData.User.ID,
                //        CriteriaOperator = CriteriaOperator.And
                //    });
                //}
                banks=dal.GetAll<Bank>();
                PopulateView(banks);
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
                            bank.Description=row.Cells["gridDescription"].Value.ToString();
                            //bank.Sortcode = Convert.ToString(row.Cells["gridSortCode"].Value) ?? string.Empty;
                            bank.Code = row.Cells["gridCode"].Value.ToString();
                            bank.Active = (bool)row.Cells["gridActive"].FormattedValue ;
                            bank.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(bank);
                            }
                            else
                            {
                                bank.ID=int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(bank);
                            }
                        }
                    }
                    GetData();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Not Save Successfully");
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
                                bank.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                bank.Active = false;
                                bank.Archived = true;
                                dal.Delete(bank);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                bank.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                bank.Active = false;
                                bank.Archived = true;
                                dal.Delete(bank);
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

        private void BankForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetData();
                // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                var getPermissions = GlobalData.CheckPermissions(3);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                GetData();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<Bank> banks)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Bank bank in banks)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = bank.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = bank.Description;
                    grid.Rows[ctr].Cells["gridSortCode"].Value = bank.Sortcode;
                    grid.Rows[ctr].Cells["gridCode"].Value = bank.Code;
                    grid.Rows[ctr].Cells["gridActive"].Value = bank.Active;
                    grid.Rows[ctr].Cells["gridUserID"].Value = bank.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundBanks.Clear();
                banks = dal.GetAll<Bank>();
                grid.Rows.Clear();
                foreach (Bank bank in banks)
                {
                    if ((bank.Code.Trim().ToLower().StartsWith(txtCode.Text.Trim().ToLower())))
                    {
                        foundBanks.Add(bank);
                    }
                }
                PopulateView(foundBanks);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundBanks.Clear();
                banks = dal.GetAll<Bank>();
                grid.Rows.Clear();
                foreach (Bank bank in this.banks)
                {
                    if ((bank.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundBanks.Add(bank);
                    }
                }
                PopulateView(foundBanks);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

    }
}
