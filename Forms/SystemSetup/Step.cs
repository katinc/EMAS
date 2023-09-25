using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;

namespace eMAS.Forms.SystemSetup
{
    public partial class StepForm : Form, IRefreshView 
    {
        StepNewForm stepNewForm;
        StepDataMapper stepManip;
        private Step step;
        private IDAL dal;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public StepForm()
        {
            InitializeComponent();
            stepManip = new StepDataMapper();
            this.step = new Step();
            stepManip.OpenConnection();
            dal = new DAL();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            stepNewForm = new StepNewForm(this, stepManip);
            stepNewForm.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridStep.CurrentRow != null)
                {
                    Step step = new Step();
                    step.ID = int.Parse(gridStep.CurrentRow.Cells["gridID"].Value.ToString());
                    step.Description = gridStep.CurrentRow.Cells["gridDescription"].Value.ToString();
                    step.Active = bool.Parse(gridStep.CurrentRow.Cells["gridActive"].Value.ToString());
                    step.User.ID = int.Parse(gridStep.CurrentRow.Cells["gridUserID"].Value.ToString());
                    StepEditForm stepEdit = new StepEditForm(this, stepManip, step);
                    stepEdit.Show();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Please see the System Administrator", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridStep.CurrentRow != null)
            {
                try
                {

                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(gridStep.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        step.ID = int.Parse(gridStep.CurrentRow.Cells["gridID"].Value.ToString());
                        stepManip.Delete(step);
                        gridStep.Rows.RemoveAt(gridStep.Rows.IndexOf(gridStep.CurrentRow));
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        step.ID = int.Parse(gridStep.CurrentRow.Cells["gridID"].Value.ToString());
                        stepManip.Delete(step);
                        gridStep.Rows.RemoveAt(gridStep.Rows.IndexOf(gridStep.CurrentRow));
                    }
                    else
                    {
                        MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                    }
                    gridStep.Refresh();

                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            stepManip.CloseConnection();
            this.Close();
        }

        public void RefreshView()
        {
            try
            {
                IList<Step> steps = stepManip.GetAll();
                PopulateView(steps);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                string err = ex.Message;
            }
        }

        private void PopulateView(IList<Step> steps)
        {
            try
            {
                gridStep.Rows.Clear();
                int ctr = 0;

                foreach (Step step in steps)
                {
                    gridStep.Rows.Add(1);
                    gridStep.Rows[ctr].Cells["gridID"].Value = step.ID;
                    gridStep.Rows[ctr].Cells["gridDescription"].Value = step.Description;
                    gridStep.Rows[ctr].Cells["gridActive"].Value = step.Active;
                    gridStep.Rows[ctr].Cells["gridUserID"].Value = step.User.ID;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void StepForm_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            RefreshView();
            //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel4Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnAdd.Enabled = getPermissions.CanAdd;
                btnDelete.Enabled = getPermissions.CanDelete;
                btnUpdate.Enabled = getPermissions.CanEdit;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }
    }
}
