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
    public partial class QualificationTypeForm : Form
    {
        private IDAL dal;
        private QualificationType qualificationType;
        private IList<QualificationType> qualificationTypes;
        private IList<QualificationType> foundQualificationTypes;
        private int ctr;
        private bool found;
        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public QualificationTypeForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.qualificationType = new QualificationType();
                this.qualificationTypes = new List<QualificationType>();
                this.foundQualificationTypes = new List<QualificationType>();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void QualificationTypeForm_Load(object sender, EventArgs e)
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
                //if (GlobalData.User.UserCategory.Description == "Basic")
                //{
                    found = true;
                //}
                //if (found == true)
                //{
                //    query.Criteria.Add(new Criterion()
                //    {
                //        Property = "QualificationTypeView.UserID",
                //        CriterionOperator = CriterionOperator.EqualTo,
                //        Value = GlobalData.User.ID,
                //        CriteriaOperator = CriteriaOperator.And
                //    });
                //}
                qualificationTypes = dal.GetAll<QualificationType>();
                PopulateView(qualificationTypes);
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
                            var code = row.Cells["gridCode"].Value;
                            qualificationType.Code = code == null ? "" : code.ToString();
                            qualificationType.Description = row.Cells["gridDescription"].Value.ToString();
                            qualificationType.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            qualificationType.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(qualificationType);
                            }
                            else
                            {
                                qualificationType.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(qualificationType);
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
                                qualificationType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                qualificationType.Active = false;
                                qualificationType.Archived = true;
                                dal.Delete(qualificationType);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                qualificationType.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                qualificationType.Active = false;
                                qualificationType.Archived = true;
                                dal.Delete(qualificationType);
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
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void PopulateView(IList<QualificationType> qualificationTypes)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (QualificationType qualificationType in qualificationTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = qualificationType.ID.ToString();
                    grid.Rows[ctr].Cells["gridCode"].Value = qualificationType.Code;
                    grid.Rows[ctr].Cells["gridDescription"].Value = qualificationType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = qualificationType.Active.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = qualificationType.User.ID;
                    ctr++;
                }
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
                foundQualificationTypes.Clear();
                qualificationTypes = dal.GetAll<QualificationType>();
                grid.Rows.Clear();
                foreach (QualificationType qualificationType in qualificationTypes)
                {
                    if ((qualificationType.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundQualificationTypes.Add(qualificationType);
                    }
                }
                PopulateView(foundQualificationTypes);
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
                foundQualificationTypes.Clear();
                qualificationTypes = dal.GetAll<QualificationType>();
                grid.Rows.Clear();
                foreach (QualificationType qualificationType in qualificationTypes)
                {
                    if (qualificationType.Active == checkBoxActive.Checked)
                    {
                        foundQualificationTypes.Add(qualificationType);
                    }
                }
                PopulateView(foundQualificationTypes);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
