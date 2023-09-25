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
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer;
using HRDataAccessLayerBase;

namespace eMAS.Forms.SystemSetup
{
    public partial class StepEditForm : Form
    {
        private StepDataMapper stepManip;
        private Step step;
        private IRefreshView stepView;
        private DAL dal;

        public StepEditForm(IRefreshView stepView, StepDataMapper stepManip,Step step)
        {
            InitializeComponent();

            this.dal = new DAL();
            this.stepManip = stepManip;
            this.step = step;
            this.stepView = stepView;

            //Initializing Controls
            txtDescription.Text = step.Description;
            chkActive.Checked = step.Active;
            
        }

        public StepEditForm()
        {
            InitializeComponent();
            this.stepView = new StepForm();
            this.dal = new DAL();
            this.stepManip = new StepDataMapper();
            this.step = new Step();

            //Initializing Controls
            txtDescription.Text = step.Description;
            chkActive.Checked = step.Active;

        }

        private void StepEditForm_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    this.Assign();
                    stepManip.Update(step);
                    stepView.RefreshView();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                    MessageBox.Show(GlobalData.DataAccessException, GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Assign()
        {
            try
            {
                step.Description = txtDescription.Text;
                step.Active = chkActive.Checked;
                step.User.ID = GlobalData.User.ID;
                
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("Please see the System Administrator", GlobalData.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Clear()
        {
            txtDescription.Clear();
            chkActive.Checked = false;
        }

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
    }
}
