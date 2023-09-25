using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class AppraisalObjectivesAddEditForm : Form
    {
        private AppraisalObjectivesForm parentForm;
        private AppraisalObjective appraisalObjective;
        private AppraisalObjectivesDataMapper appraisalObjectiveDataMapper;

        private DALHelper dalHelper;
        public AppraisalObjectivesAddEditForm(AppraisalObjectivesForm parentForm,AppraisalObjective objective)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.appraisalObjectiveDataMapper = new AppraisalObjectivesDataMapper();
            if (objective != null && objective.Id>0)
            {
                txtObjectives.Text = objective.Description;
                chkActive.Checked = objective.Active;
                dtpEntryDate.Value = objective.EntryDate;
            }
            else
            {
                dtpEntryDate.Value = DateTime.Now.Date;
                chkActive.Checked = true;
            }
            appraisalObjective= objective;
            this.dalHelper = new DALHelper();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtObjectives.Clear();
            dtpEntryDate.ResetText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtObjectives.Text == string.Empty)
                MessageBox.Show("Objective Is Required!");
            else
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@description", txtObjectives.Text, DbType.String);
                 dalHelper.CreateParameter("@active",chkActive.Checked, DbType.Boolean);
                if (appraisalObjective != null && appraisalObjective.Id > 0)
                {
                    dalHelper.CreateParameter("@enteredById", GlobalData.User.ID, DbType.Int32);
                    dalHelper.CreateParameter("@Id", appraisalObjective.Id, DbType.Int32);

                    dalHelper.ExecuteNonQuery("update AppraisalObjectives set description=@description,active=@active,enteredById=@enteredById where id=@Id");

                   var rowIndex=  parentForm.grid.CurrentRow.Index;

                   parentForm.grid.Rows[rowIndex].Cells["gridID"].Value = txtObjectives.Text;
                   parentForm.grid.Rows[rowIndex].Cells["gridActive"].Value = chkActive.Checked;
                   parentForm.grid.Rows[rowIndex].Cells["gridEntryDate"].Value = dtpEntryDate.Value.Date;
                   parentForm.loadGrid(parentForm.selectedEmployee.ID);
                   Close();
                   // parentForm.UpdateRow(parentForm.grid.SelectedRows[0], appraisalObjective);
                }
                else
                {
                    dalHelper.CreateParameter("@entryDate", dtpEntryDate.Value.Date, DbType.Date);
                    dalHelper.CreateParameter("@enteredById", GlobalData.User.ID, DbType.Int32);
                    dalHelper.CreateParameter("@periodId", parentForm.lstAppraisalPeriod[parentForm.cmbPeriod.SelectedIndex].Id, DbType.Int32);
                    dalHelper.CreateParameter("@staffId", parentForm.selectedEmployee.ID, DbType.Int32);

                    dalHelper.CreateParameter("@archived", false, DbType.Boolean);
                    dalHelper.ExecuteNonQuery("insert into AppraisalObjectives (description,entryDate,active,enteredById,periodId,archived,staffId) values(@description,@entryDate,@active,@enteredById,@periodId,@archived,@staffId)");
                    parentForm.loadGrid(parentForm.selectedEmployee.ID);
                    btnClear_Click(sender, e);
                }
            }
        }
    }
}
