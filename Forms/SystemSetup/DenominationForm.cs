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
    public partial class DenominationForm : Form
    {
        private IDAL dal;
        private Religion religion;
        private Denomination denomination;
        private IList<Religion> religions;
        private IList<Denomination> denominations;
        private IList<Denomination> foundDenominations;
        private int ctr;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public DenominationForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.religion = new Religion();
                this.denomination = new Denomination();
                this.religions = new List<Religion>();
                this.foundDenominations = new List<Denomination>();
                this.denominations = new List<Denomination>();
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
                if (cboReligion.Text.ToString() == null || cboReligion.Text.ToString() == string.Empty)
                {
                    result = false;
                    MessageBox.Show("Please Select Religion ");
                    cboReligion.Focus();
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
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
            return result;
        }

        private void GetData()
        {
            try
            {
                if (cboReligion.Text.Trim() == string.Empty)
                {
                    religion.ID = 0;
                }
                else
                {
                    religion.ID = religions[cboReligion.SelectedIndex].ID;
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
                        Property = "DenominationView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                query.Criteria.Add(new Criterion()
                {
                    Property = "DenominationView.ReligionID",
                    CriterionOperator = CriterionOperator.EqualTo,
                    Value = religion.ID,
                    CriteriaOperator = CriteriaOperator.And
                });
                denominations = dal.GetByCriteria<Denomination>(query);
                PopulateView(denominations);
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
                            denomination.Description = row.Cells["gridDescription"].Value.ToString();
                            denomination.Religion.ID = religions[cboReligion.SelectedIndex].ID;
                            denomination.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            denomination.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {

                                dal.Save(denomination);
                            }
                            else
                            {
                                denomination.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(denomination);
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
                                denomination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                denomination.Active = false;
                                denomination.Archived = true;
                                dal.Delete(denomination);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                denomination.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                denomination.Active = false;
                                denomination.Archived = true;
                                dal.Delete(denomination);
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

        private void PopulateView(IList<Denomination> denominations)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Denomination denomination in denominations)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = denomination.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = denomination.Description;
                    grid.Rows[ctr].Cells["gridReligionID"].Value = denomination.Religion.ID.ToString();
                    grid.Rows[ctr].Cells["gridActive"].Value = denomination.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = denomination.User.ID;
                    ctr++;
                }
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
                foundDenominations.Clear();
                if (denominations.Count <= 0)
                {
                    denominations = dal.GetAll<Denomination>();
                }
                
                foreach (Denomination denomination in denominations)
                {
                    if ((denomination.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundDenominations.Add(denomination);
                    }
                }
                PopulateView(foundDenominations);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void cboReligion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                foundDenominations.Clear();
                if (denominations.Count <= 0)
                {
                    denominations = dal.GetAll<Denomination>();
                }
                
                grid.Rows.Clear();
                foreach (Denomination denomination in denominations)
                {
                    if (denomination.Religion.ID == religions[cboReligion.SelectedIndex].ID)
                    {
                        foundDenominations.Add(denomination);
                    }
                }
                PopulateView(foundDenominations);
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void cboReligion_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (religions.Count <= 0)
                {
                    religions = dal.GetAll<Religion>();
                }
                cboReligion.Items.Clear();
                cboReligion.Text = string.Empty;
                foreach (Religion religion in religions)
                {
                    cboReligion.Items.Add(religion.Description);
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void cboReligion_DropDownClosed(object sender, EventArgs e)
        {
            try
            {
                foundDenominations.Clear();
                if (denominations.Count <= 0)
                {
                    denominations = dal.GetAll<Denomination>();
                }
                
                grid.Rows.Clear();
                foreach (Denomination denomination in denominations)
                {
                    if (denomination.Religion.ID == religions[cboReligion.SelectedIndex].ID)
                    {
                        foundDenominations.Add(denomination);
                    }
                }
                PopulateView(foundDenominations);
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
                GetData();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        private void DenominationForm_Load(object sender, EventArgs e)
        {
            //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

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

    }
}
