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
using HRDataAccessLayerBase;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExcuseDutyHRRecommendationRemark : Form
    {
        private ExcuseDutyRequest excuseDutyRequest;
        private ExcuseDutyHRRecommendation parentForm;
        public DataGridView parentGrid;

        private DALHelper dalHelper;
        public ExcuseDutyHRRecommendationRemark()
        {
            InitializeComponent();
            this.excuseDutyRequest = new ExcuseDutyRequest();
            this.dalHelper = new DALHelper();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExcuseDutyHRRecommendationRemark_Load(object sender, EventArgs e)
        {

        }
        public void setExcuseDutyRequest(ExcuseDutyRequest excuseDutyRequest,ExcuseDutyHRRecommendation parentForm){
            try
            {
                this.excuseDutyRequest = excuseDutyRequest;
                this.parentForm = parentForm;
                chkEligible.Checked = excuseDutyRequest.HREligibility;
                chkRecommend.Checked = excuseDutyRequest.HRRecommended;
                txtComment.Text = excuseDutyRequest.HRAdditionalComment;
                //datePickerStartDate.Value = excuseDutyRequest.HRAssessmentDate;
                datePickerStartDate.Text = excuseDutyRequest.HRAssessmentDate.ToString();
            }
            catch (Exception ei)
            {
                Logger.LogError(ei);
            }
           // parentForm.btnRefresh_Click(sender, e);
        }

        private void btnRecommend_Click(object sender, EventArgs e)
        {
           
            if (excuseDutyRequest != null)
            {
                try
                {
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@id", excuseDutyRequest.id, DbType.Int32);
                    dalHelper.CreateParameter("@HRRecommendedById", GlobalData.User.ID, DbType.Int32);
                    dalHelper.CreateParameter("@HREligibility", chkEligible.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@HRRecommended", chkRecommend.Checked, DbType.Boolean);
                    dalHelper.CreateParameter("@HRAdditionalComment", txtComment.Text.Trim(), DbType.String);
                    dalHelper.CreateParameter("@HRAssessmentDate", datePickerStartDate.Value.Date, DbType.Date);

                    dalHelper.ExecuteNonQuery("update ExcusedDutyRequest set HRRecommendedById=@HRRecommendedById,HREligibility=@HREligibility,HRRecommended=@HRRecommended,HRAdditionalComment=@HRAdditionalComment,HRAssessmentDate=@HRAssessmentDate where id=@id");
                   
                    MessageBox.Show("Excuse Duty Recommendation Successful");
                    btnClear_Click(sender, e);

                    //if (parentGrid != null)
                    //{
                    //    parentGrid.Rows.Remove(parentGrid.CurrentRow);
                    //}
                    this.Close();
                }
                catch(Exception exi){
                MessageBox.Show("Error: Unable To Save Excuse Duty,Retry Again/ Contact Administrator!");
                    Logger.LogError(exi);
                }
               
            }
        }

        private void chkRecommend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRecommend.Checked == true)
                chkEligible.Checked = true;
            else
                chkEligible.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            chkEligible.Checked = false;
            chkRecommend.Checked = false;
            datePickerStartDate.Value = DateTime.Now;
            txtComment.Clear();
        }
    }
}
