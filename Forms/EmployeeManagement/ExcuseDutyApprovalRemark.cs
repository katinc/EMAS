using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayer.Staff_Info_Data_Control;
using HRDataAccessLayerBase;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExcuseDutyApprovalRemark : Form
    {
        private ExcuseDutyRequest excuseDutyRequest;
        private ExcuseDutyRequestDataMapper excuseDutyRequestDataMapper;

        private DALHelper dalHelper;
        private ExcuseDutyApprovalForm parentForm;
        public ExcuseDutyApprovalRemark()
        {
            InitializeComponent();
            this.excuseDutyRequest = new ExcuseDutyRequest();
            this.excuseDutyRequestDataMapper = new ExcuseDutyRequestDataMapper();
            this.dalHelper = new DALHelper();
            this.parentForm = new ExcuseDutyApprovalForm();
        }

        public ExcuseDutyApprovalRemark(ExcuseDutyApprovalForm parentForm, ExcuseDutyRequest excuseDutyRequest)
        {
            InitializeComponent();
            try
            {
                this.excuseDutyRequest = new ExcuseDutyRequest();
                this.excuseDutyRequestDataMapper = new ExcuseDutyRequestDataMapper();
                this.dalHelper = new DALHelper();
                this.parentForm = parentForm;
                this.excuseDutyRequest = excuseDutyRequest;
                chkApprove.Checked = excuseDutyRequest.Approved;
                txtAdditionalComment.Text = excuseDutyRequest.ApprovalComment;
                //datePickerStartDate.Value = excuseDutyRequest.ApprovedDate;
                datePickerStartDate.Text = excuseDutyRequest.ApprovedDate.ToString();
            }
            catch (Exception e1) { }
           
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAdditionalComment.Clear();
            chkApprove.Checked = false;
            datePickerStartDate.Value = DateTime.Now;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Id", excuseDutyRequest.id, DbType.Int32);
                dalHelper.CreateParameter("@ApprovedById", GlobalData.User.ID, DbType.Int32);
                dalHelper.CreateParameter("@Approved", chkApprove.Checked, DbType.Boolean);
                dalHelper.CreateParameter("@ApprovalDate", datePickerStartDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@ApprovalComment", txtAdditionalComment.Text.Trim(), DbType.String);
                dalHelper.ExecuteNonQuery("update ExcusedDutyRequest set ApprovedById=@ApprovedById,Approved=@Approved,ApprovalDate=@ApprovalDate,ApprovalComment=@ApprovalComment where id=@Id");
               
                MessageBox.Show("Record Approved Successfully!");
                btnClear_Click(sender, e);
                if (parentForm != null)
                {
                    parentForm.grid.Rows.Remove(parentForm.grid.CurrentRow);
                }
                this.Close();
                //parentForm.GetData();
            }
            catch (Exception e1)
            {
                Logger.LogError(e1);
                MessageBox.Show("Record Approved Failed!");
            }
          
        }
    }
}
