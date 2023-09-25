using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExternalTrainingCEOApproval : Form
    {
        ExternalTrainingCEOApprovalView parentForm;
        ExternalTraining externalTraining;
        private Employee Staff;
        private EmployeeDataMapper employeeDataMapper;
        private DALHelper dalHeper;
        public ExternalTrainingCEOApproval(ExternalTrainingCEOApprovalView parentForm,ExternalTraining externalTraining)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.externalTraining = externalTraining;
            this.dalHeper = new DALHelper();
            this.Staff = new Employee();
            this.employeeDataMapper = new EmployeeDataMapper();

            if (externalTraining.CEO != null && externalTraining.CEO.ID > 0)
            {
                txtCEOID.Text = externalTraining.CEO.StaffID;
                txtAdditionalComments.Text = externalTraining.CEOComment;
                dtpApprovalDate.Value = externalTraining.CEOApprovalDate;
                chkApprove.Checked = externalTraining.CEOApproval;
            }
            else
            {
                txtCEOID.Text = GlobalData.User.StaffID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCEOID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCEOID.Text == string.Empty)
                    txtStaffName.Clear();
                else
                {
                    Staff = employeeDataMapper.GetByID(txtCEOID.Text.Trim());
                    txtStaffName.Text = (Staff.FirstName + " " + Staff.OtherName).Trim() + " " + Staff.Surname;
                }
            }
            catch (Exception xi)
            {
                txtStaffName.Clear();
            }
          
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCEOID.Text == string.Empty)
                MessageBox.Show("CEO Staff ID Is Required!");
            else if (txtStaffName.Text == string.Empty)
                MessageBox.Show("Staff Name Is Required!");
            else if (txtAdditionalComments.Text == string.Empty)
                MessageBox.Show("Additional Comment(s) Is Required!");
            else
            {
                try
                {
                    dalHeper.ClearParameters();
                    dalHeper.CreateParameter("@CEOId", Staff.ID, DbType.Int32);
                    dalHeper.CreateParameter("@CEOApproval", chkApprove.Checked, DbType.Boolean);
                    dalHeper.CreateParameter("@CEOComment", txtAdditionalComments.Text, DbType.String);
                    dalHeper.CreateParameter("@CEOApprovalDate", dtpApprovalDate.Value.Date, DbType.Date);
                    dalHeper.CreateParameter("@Id", externalTraining.ID, DbType.Int32);

                    dalHeper.ExecuteNonQuery("update ExternalTraining set CEOId=@CEOId,CEOApproval=@CEOApproval,CEOComment=@CEOComment,CEOApprovalDate=@CEOApprovalDate where id=@Id");
                    parentForm.gridViewInfo.CurrentRow.Cells["gridCEO"].Value = txtStaffName.Text;
                    parentForm.gridViewInfo.CurrentRow.Cells["gridCEOComment"].Value = txtAdditionalComments.Text;
                    parentForm.gridViewInfo.CurrentRow.Cells["gridCEOApprovalDate"].Value = dtpApprovalDate.Value.ToShortDateString();

                    MessageBox.Show("Training Approval Successfully!");
                    Clear();
                    Close();
                }
                catch (Exception xi)
                {
                    MessageBox.Show("Error: Unable To Approval Training!");
                    Logger.LogError(xi);
                }
               
            
            }
        }

        private void Clear()
        {
            txtCEOID.Clear();
            txtAdditionalComments.Clear();
            dtpApprovalDate.ResetText();
            chkApprove.Checked = true;
        }
    }
}
