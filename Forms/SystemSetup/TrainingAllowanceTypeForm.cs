using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.SystemSetup
{
    public partial class TrainingAllowanceTypeForm : Form
    {
        private List<DataReference.TrainingAllowanceType> trainingAllowanceTypes;

        private int ctr;
        private bool found;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;
        public TrainingAllowanceTypeForm()
        {
            InitializeComponent();
            trainingAllowanceTypes = new List<DataReference.TrainingAllowanceType>();
        }

        private void TrainingAllowanceTypeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                //Clear();
                GetData();
                // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

                var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
                if (getPermissions != null)
                {
                    btnSave.Visible = getPermissions.CanAdd;
                    btnDelete.Visible = getPermissions.CanDelete;
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

        private void GetData()
        {
            try
            {
                trainingAllowanceTypes = GlobalData._context.TrainingAllowanceTypes.Where(u => u.Archived == false).ToList();
                PopulateView(trainingAllowanceTypes);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }

        private void PopulateView(List<DataReference.TrainingAllowanceType> trainingAllowanceTypes)
        {
            try
            {
                this.ctr = 0;
                grid.Rows.Clear();
                foreach (DataReference.TrainingAllowanceType trainingType in trainingAllowanceTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = trainingType.ID.ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = trainingType.Description;
                    grid.Rows[ctr].Cells["gridActive"].Value = trainingType.Active.ToString();
                    ctr++;
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridID"].Value == null)
                            {
                                var trainingAllowanceType = new DataReference.TrainingAllowanceType
                                {
                                    Description = row.Cells["gridDescription"].Value.ToString(),
                                    Active = (bool)row.Cells["gridActive"].FormattedValue,
                                };
                                GlobalData._context.TrainingAllowanceTypes.InsertOnSubmit(trainingAllowanceType);
                            }
                            else
                            {
                                int trainingTypeId = int.Parse(row.Cells["gridID"].Value.ToString());

                                var updateTT = GlobalData._context.TrainingAllowanceTypes.SingleOrDefault(u => u.ID == trainingTypeId);
                                updateTT.Description = row.Cells["gridDescription"].Value.ToString();
                                updateTT.Active = (bool)row.Cells["gridActive"].FormattedValue;

                            }

                            GlobalData._context.SubmitChanges();
                        }
                    }
                    MessageBox.Show("Saved Successfully");
                    GetData();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not Save Successfully");
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
                            int trainingTypeId = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());

                            var updateTT = GlobalData._context.TrainingAllowanceTypes.SingleOrDefault(u => u.ID == trainingTypeId);
                            updateTT.Archived = true;
                            updateTT.ArchivedTime = DateTime.Now;
                            updateTT.ArchiverID = GlobalData.User.ID.ToString();
                            updateTT.Active = false;

                            GlobalData._context.SubmitChanges();
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
