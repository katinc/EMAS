using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.System_Setup_Class;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayer;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;

namespace eMAS.Forms.SystemSetup
{
    public partial class StepNewForm : Form
    {
        StepDataMapper stepManip;
        Step steps;
        IRefreshView stepView;
        IDAL dal;

        public StepNewForm(IRefreshView stepView, StepDataMapper steManip)
        {
            InitializeComponent();
            this.stepManip = steManip;
            this.steps = new Step();
            this.stepView = stepView;           
            this.dal = new DAL();
        }

        public StepNewForm()
        {
            InitializeComponent();
            this.stepManip = new StepDataMapper();
            this.steps = new Step();
            this.dal = new DAL();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                this.Assign();
                try
                {
                    stepManip.Save(steps);
                    stepView.RefreshView();
                    this.Clear();
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
            this.Close();
        }

        #region ASSIGNMENTS
        private void Assign()
        {
            steps.Description = txtDescription.Text;
            steps.Active = chkActive.Checked;
            steps.User.ID = GlobalData.User.ID;
        }
        #endregion

        #region CLEAR
        private void Clear()
        {
            txtDescription.Clear();
            chkActive.Checked = false;
        }
        #endregion

        #region ValidateFields
        private bool ValidateFields()
        {
            bool result = true;

            if (txtDescription.Text.Trim() == string.Empty)
            {
                result = false;
                MessageBox.Show("Description cannot be empty");
            }
            return result;
        }
        #endregion

        private void StepNewForm_Load(object sender, EventArgs e)
        {
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }
    }
}