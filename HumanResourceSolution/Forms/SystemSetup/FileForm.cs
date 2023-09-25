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
    public partial class FileForm : Form
    {
        private IDAL dal;
        private FileNumber file;
        private IList<FileNumber> files;
        private IList<FileNumber> foundFiles;
        private int ctr;
        private bool found;

        public FileForm()
        {
            try
            {
                InitializeComponent();
                this.dal = new DAL();
                this.dal.OpenConnection();
                this.file = new FileNumber();
                this.files = new List<FileNumber>();
                this.foundFiles = new List<FileNumber>();
                this.ctr = 0;
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void FileForm_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
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
                        Property = "FileNumberView.UserID",
                        CriterionOperator = CriterionOperator.EqualTo,
                        Value = GlobalData.User.ID,
                        CriteriaOperator = CriteriaOperator.And
                    });
                }
                files = dal.GetByCriteria<FileNumber>(query);
                PopulateView(files);
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
                            file.Description = row.Cells["gridDescription"].Value.ToString();
                            file.InUse = (bool)row.Cells["gridInUse"].FormattedValue;
                            file.User.ID = GlobalData.User.ID;

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.Save(file);
                            }
                            else
                            {
                                file.ID = int.Parse(row.Cells["gridID"].Value.ToString());
                                dal.Update(file);
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
                                file.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                file.InUse = false;
                                file.Archived = true;
                                dal.Delete(file);
                                grid.Rows.RemoveAt(grid.CurrentRow.Index);
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                file.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                                file.InUse = false;
                                file.Archived = true;
                                dal.Delete(file);
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
                throw ex;
            }
        }

        private void PopulateView(IList<FileNumber> files)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (FileNumber file in files)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = file.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = file.Description;
                    grid.Rows[ctr].Cells["gridInUse"].Value = file.InUse.ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = file.User.ID;
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
                foundFiles.Clear();
                files = dal.GetAll<FileNumber>();
                grid.Rows.Clear();
                foreach (FileNumber file in files)
                {
                    if ((file.Description.Trim().ToLower().StartsWith(txtDescription.Text.Trim().ToLower())))
                    {
                        foundFiles.Add(file);
                    }
                }
                PopulateView(foundFiles);
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
                checkBoxInUse.ResetText();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void checkBoxInUse_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foundFiles.Clear();
                files = dal.GetAll<FileNumber>();
                grid.Rows.Clear();
                foreach (FileNumber file in files)
                {
                    if (file.InUse == checkBoxInUse.Checked)
                    {
                        foundFiles.Add(file);
                    }
                }
                PopulateView(foundFiles);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
