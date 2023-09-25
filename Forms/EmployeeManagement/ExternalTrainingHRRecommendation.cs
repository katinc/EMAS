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

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExternalTrainingHRRecommendation : Form
    {
        ExternalTrainingHRRecommendationView parentForm;
        ExternalTraining externalTraining;
        private DALHelper dalHelper;
        private Employee staff;
        private EmployeeDataMapper employeeDataMapper;
        public ExternalTrainingHRRecommendation(ExternalTraining externalTraining,ExternalTrainingHRRecommendationView parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            this.externalTraining = externalTraining;
            this.dalHelper = new DALHelper();
            this.staff = new Employee();
            this.employeeDataMapper = new EmployeeDataMapper();
            if (externalTraining.HR != null && externalTraining.HR.ID>0)
            {
                chkRecommend.Checked = true;
                    txtHRID.Text=externalTraining.HR.StaffID;
                //txtHRName.Text=
                    txtAdditionalComments.Text = externalTraining.HRComment;
                    cmbPreliminaryDecision.SelectedItem = externalTraining.HRDecision;
                    dtpAssessmentDate.Value = externalTraining.HRAssessmentDate;
            }
            else
            {
              txtHRID.Text=  GlobalData.User.StaffID;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtHRID.Text==string.Empty)
                MessageBox.Show("HR Staff ID Is Required!");
            else if(txtHRName.Text==string.Empty)
                MessageBox.Show("HR Staff Name Is Required!");
            else if(cmbPreliminaryDecision.Text==string.Empty)
                MessageBox.Show("Preliminary Decision Is Required!");
            else if(txtAdditionalComments.Text==string.Empty)
                MessageBox.Show("Additional Comment Is Required!");
            else{
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@HRId",staff.ID,DbType.Int32);
                dalHelper.CreateParameter("@HRDecision",cmbPreliminaryDecision.SelectedItem.ToString(),DbType.String);
                dalHelper.CreateParameter("@HRRecommended",chkRecommend.Checked,DbType.Boolean);
                dalHelper.CreateParameter("@HRAssessmentDate",dtpAssessmentDate.Value.Date,DbType.Date);
                dalHelper.CreateParameter("@HRComment", txtAdditionalComments.Text, DbType.String);
                dalHelper.CreateParameter("@Id", externalTraining.ID, DbType.Int32);


                dalHelper.ExecuteNonQuery("update ExternalTraining set HRId=@HRId,HRDecision=@HRDecision,HRRecommended=@HRRecommended,HRAssessmentDate=@HRAssessmentDate,HRComments=@HRComment where id=@Id");
                parentForm.gridViewInfo.CurrentRow.Cells["gridHR"].Value = txtHRName.Text.Trim();
                parentForm.gridViewInfo.CurrentRow.Cells["gridHRDecision"].Value = cmbPreliminaryDecision.SelectedItem.ToString();
                parentForm.gridViewInfo.CurrentRow.Cells["gridHRComments"].Value = txtAdditionalComments.Text;
                parentForm.gridViewInfo.CurrentRow.Cells["gridHRAssessmentDate"].Value = dtpAssessmentDate.Value.Date.ToShortDateString();

                Clear();
                Close();
            }
        }
        private void Clear()
        {
            txtHRID.Clear();
            txtAdditionalComments.Clear();
            dtpAssessmentDate.ResetText();
            chkRecommend.Checked = true;
            cmbPreliminaryDecision.SelectedIndex = -1;
        }
        private void txtHRID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtHRID.Text == string.Empty)
                {
                    txtHRName.Clear();
                }
                else
                {
                    staff = employeeDataMapper.GetByID(txtHRID.Text.Trim());
                    txtHRName.Text = (staff.FirstName + " " + staff.OtherName).Trim() + " " + staff.Surname;
                }
            }
            catch (Exception xi) {
                txtHRName.Clear();
            }
            
        }

        private void ExternalTrainingHRRecommendation_Load(object sender, EventArgs e)
        {

        }
    }
}
