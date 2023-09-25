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
    public partial class OccupationalGroupingForm : Form
    {
        private IDAL dal;
        private OccupationGroup occupationGroup;
        private IList<OccupationGroup> occupationGroups;
        private IList<OccupationGroup> foundOccupationGroups;
        private int ctr;
        private bool found;

        public OccupationalGroupingForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.occupationGroup = new OccupationGroup();
                this.occupationGroups = new List<OccupationGroup>();
                this.foundOccupationGroups = new List<OccupationGroup>();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void OccupationalGroupingForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                Clear();
                GetData();
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
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
                        Property = "OccupationGroupView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                occupationGroups = dal.GetByCriteria<OccupationGroup>(query);
                PopulateView(occupationGroups);
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(IList<OccupationGroup> occupationGroups)
        {
            try
            {
                int ctr = 0;
                grid.Rows.Clear();
                foreach (OccupationGroup occupationGroup in occupationGroups)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = occupationGroup.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = occupationGroup.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = occupationGroup.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = occupationGroup.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
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
                            occupationGroup.Description = row.Cells["gridDescription"].Value.ToString();
                            occupationGroup.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            occupationGroup.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(occupationGroup);
                            }
                            else
                            {
                                occupationGroup.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(occupationGroup);
                            }
                        }
                    }
                    GetData();
                    Clear();
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
                            occupationGroup.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            occupationGroup.Active = false;
                            occupationGroup.Archived = true;
                            dal.Delete(occupationGroup);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
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
                GetData();
                Clear();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foundOccupationGroups.Clear();
                occupationGroups = dal.GetAll<OccupationGroup>();
                grid.Rows.Clear();
                foreach (OccupationGroup occupationGroup in occupationGroups)
                {
                    if ((occupationGroup.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundOccupationGroups.Add(occupationGroup);
                    }
                }
                PopulateView(foundOccupationGroups);
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
                foundOccupationGroups.Clear();
                occupationGroups = dal.GetAll<OccupationGroup>();
                grid.Rows.Clear();
                foreach (OccupationGroup occupationGroup in occupationGroups)
                {
                    if (occupationGroup.Active == checkBoxActive.Checked)
                    {
                        foundOccupationGroups.Add(occupationGroup);
                    }
                }
                PopulateView(foundOccupationGroups);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
