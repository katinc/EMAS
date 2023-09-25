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
    public partial class DisabilityTypeForm : Form
    {
        private IDAL dal;
        private DisabilityType disabilityType;
        private IList<DisabilityType> disabilityTypes;
        private IList<DisabilityType> disabilityTypeList;
        private IList<DisabilityType> foundDisabilityTypes;
        private int ctr;
        private bool found;

        public DisabilityTypeForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.disabilityType = new DisabilityType();
                this.foundDisabilityTypes = new List<DisabilityType>();
                this.disabilityTypes = new List<DisabilityType>();
                this.disabilityTypeList = new List<DisabilityType>();
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
                        Query query = new Query();
                        query.Criteria.Add(new Criterion()
                        {
                            Property = "DisabilityTypes.Description",
                            CriterionOperator = CriterionOperator.EqualTo,
                            Value = row.Cells["gridDescription"].Value.ToString().Trim(),
                            CriteriaOperator = CriteriaOperator.And
                        });
                        disabilityTypeList = dal.GetByCriteria<DisabilityType>(query);
                        if (disabilityTypeList.Count > 0)
                        {
                            result = false;
                            MessageBox.Show("Description cannot be Repeated" + (row.Index + 1));
                            grid.Rows[row.Index + 1].Selected = true;
                        }
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
                Query query = new Query();
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    query.Criteria.Add(new Criterion()
                    {
                        Property = "DisabilityTypeView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
				
                disabilityTypes = dal.GetByCriteria<DisabilityType>(query);
                PopulateView(disabilityTypes);
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
                            disabilityType.Description = row.Cells["gridDescription"].Value.ToString();
                            disabilityType.Active = (bool)row.Cells["gridActive"].FormattedValue;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(disabilityType);
                            }
                            else
                            {
                                disabilityType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(disabilityType);
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
                MessageBox.Show("ERROR:Could Not Save Successfully, Please See the System Administrator");
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
                                disabilityType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                disabilityType.Active = false;
                                dal.Delete(disabilityType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                disabilityType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                disabilityType.Active = false;
                                dal.Delete(disabilityType);
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

        private void PopulateView(IList<DisabilityType> disabilityTypes)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (DisabilityType disabilityType in disabilityTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = disabilityType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = disabilityType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = disabilityType.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = disabilityType.User.ID;
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
                foundDisabilityTypes.Clear();
                if (disabilityTypes.Count <= 0)
                {
                    disabilityTypes = dal.GetAll<DisabilityType>();
                }
                foreach (DisabilityType disabilityType in disabilityTypes)
                {
                    if ((disabilityType.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundDisabilityTypes.Add(disabilityType);
                    }
                }
                PopulateView(foundDisabilityTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundDisabilityTypes.Clear();
                if (disabilityTypes.Count <= 0)
                {
                    disabilityTypes = dal.GetAll<DisabilityType>();
                }
                foreach (DisabilityType disabilityType in disabilityTypes)
                {
                    if (disabilityType.Active == checkBoxActive.Checked)
                    {
                        foundDisabilityTypes.Add(disabilityType);
                    }
                }
                PopulateView(foundDisabilityTypes);
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
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void DisabilityTypeForm_Load(object sender, EventArgs e)
        {
            try
            {
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
