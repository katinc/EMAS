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
    public partial class Relationships : Form
    {
        private IDAL dal;
        private Relationship relationship;
        private IList<Relationship> relationships;
        private IList<Relationship> foundRelationships;
        private int ctr;
        private bool found;

        public Relationships()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.relationship = new Relationship();
                this.relationships = new List<Relationship>();
                this.foundRelationships = new List<Relationship>();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Relationships_Load(object sender, EventArgs e)
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
                throw ex;
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
                        Property = "RelationshipView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                relationships = dal.GetByCriteria<Relationship>(query);
                PopulateView(relationships);
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
                            relationship.Description = row.Cells["gridDescription"].Value.ToString();
                            relationship.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            relationship.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(relationship);
                            }
                            else
                            {
                                relationship.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(relationship);
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
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                relationship.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                relationship.Active = false;
                                relationship.Archived = true;
                                dal.Delete(relationship);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                relationship.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                relationship.Active = false;
                                relationship.Archived = true;
                                dal.Delete(relationship);
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

        private void PopulateView(IList<Relationship> relationships)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (Relationship relationship in relationships)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = relationship.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = relationship.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = relationship.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = relationship.User.ID;
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
                foundRelationships.Clear();
                relationships = dal.GetAll<Relationship>();
                grid.Rows.Clear();
                foreach (Relationship relationship in relationships)
                {
                    if ((relationship.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundRelationships.Add(relationship);
                    }
                }
                PopulateView(foundRelationships);
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
    }
}
