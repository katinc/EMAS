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
    public partial class SanctionTypeForm : Form
    {
        private IDAL dal;
        private SanctionType sanctionType;
        private IList<SanctionType> sanctionTypes;
        private IList<SanctionType> foundSanctionTypes;
        private int ctr;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public SanctionTypeForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.sanctionType = new SanctionType();
                this.sanctionTypes = new List<SanctionType>();
                this.foundSanctionTypes = new List<SanctionType>();
                this.ctr = 0;
                this.found = false;
                this.dal.OpenConnection();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SanctionTypeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
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
                GlobalData.FillDataGrid(grid, this);
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
                        if (row.Cells["gridDescription"].Value == null)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be empty" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
                        else if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
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
                throw ex;
            }
            return result;
        }

        private void GetData()
        {
            try
            {
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionTypeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                //query.Criteria.Add(new Criterion()
                //    {
                //        Property = "SanctionTypeView.Active",
                //        CriterionOperator = CriterionOperator.EqualTo,
                //        Value = "True",
                //        CriteriaOperator = CriteriaOperator.And
                //    });
                query.Criteria.Add(new Criterion()
                    {
                        Property = "SanctionTypeView.Archived",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = "False",
                        CriteriaOperator = CriteriaOperator.And
                    });
                sanctionTypes = dal.GetByCriteria<SanctionType>(query);
                PopulateView(sanctionTypes);
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
                            sanctionType.Description = row.Cells["gridDescription"].Value.ToString();
                            sanctionType.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            sanctionType.Payment = (bool)row.Cells["gridPayment"].FormattedValue;
                            sanctionType.Separated = (bool)row.Cells["gridSeparation"].FormattedValue;
                            sanctionType.Reinstatement = (bool)row.Cells["gridReinstatement"].FormattedValue;
                            sanctionType.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(sanctionType);
                            }
                            else
                            {
                                sanctionType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(sanctionType);
                            }
                        }
                    }
                    dal.CommitTransaction();
                    Clear();
                    GetData();
                   
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
                MessageBox.Show("ERROR:Could Not Save Successfully");
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
                                sanctionType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                sanctionType.Active = false;
                                sanctionType.Archived = true;
                                dal.Delete(sanctionType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                sanctionType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                sanctionType.Active = false;
                                sanctionType.Archived = true;
                                dal.Delete(sanctionType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else
                            {
                                MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                            }
                            GetData();
                        }
                    }
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
                Clear();
                GetData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<SanctionType> sanctionTypes)
        {
            try
            {
                ctr = 0;
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = sanctionType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = sanctionType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = sanctionType.Active;
                    grid.Rows[ctr].Cells["gridPayment"].Value = sanctionType.Payment;
                    grid.Rows[ctr].Cells["gridSeparation"].Value = sanctionType.Separated;
                    grid.Rows[ctr].Cells["gridReinstatement"].Value = sanctionType.Reinstatement;
                    grid.Rows[ctr].Cells["gridUserID"].Value = sanctionType.User.ID;
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
                foundSanctionTypes.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    if ((sanctionType.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundSanctionTypes.Add(sanctionType);
                    }
                }
                PopulateView(foundSanctionTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Clear()
        {
            try
            {
                txtDescription.Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundSanctionTypes.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    if (sanctionType.Active == checkBoxActive.Checked)
                    {
                        foundSanctionTypes.Add(sanctionType);
                    }
                }
                PopulateView(foundSanctionTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxPayment_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundSanctionTypes.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    if (sanctionType.Payment == checkBoxPayment.Checked)
                    {
                        foundSanctionTypes.Add(sanctionType);
                    }
                }
                PopulateView(foundSanctionTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxSeparation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundSanctionTypes.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    if (sanctionType.Separated == checkBoxSeparation.Checked)
                    {
                        foundSanctionTypes.Add(sanctionType);
                    }
                }
                PopulateView(foundSanctionTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxReinstatement_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundSanctionTypes.Clear();
                sanctionTypes = dal.GetAll<SanctionType>();
                grid.Rows.Clear();
                foreach (SanctionType sanctionType in sanctionTypes)
                {
                    if (sanctionType.Separated == checkBoxReinstatement.Checked)
                    {
                        foundSanctionTypes.Add(sanctionType);
                    }
                }
                PopulateView(foundSanctionTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
