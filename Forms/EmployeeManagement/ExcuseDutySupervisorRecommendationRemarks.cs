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
using Microsoft.VisualBasic;
using Session_Framework;

namespace eMAS.Forms
{
    public partial class ExcuseDutyRecommendationRemarks : Form
    {
        private ExcuseDutyRequest excuseDutyRequest;
        private DALHelper dalHeper;
        private EmployeeDataMapper empDataMapper;
        private Employee Supervisor;
        ExcuseDutyRecommendation parentForm;
        public ExcuseDutyRecommendationRemarks()
        {
            InitializeComponent();
            dalHeper = new DALHelper();
            empDataMapper = new EmployeeDataMapper();
            Supervisor = new Employee();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(parentForm!=null)
            parentForm.btnRefresh_Click(sender, e);
            Close();
        }

        private void btnRecommend_Click(object sender, EventArgs e)
        {
            if (excuseDutyRequest == null)
                MessageBox.Show("Sorry you did not select a valid record!");
            else if(txtStaffID.Text==string.Empty)
                MessageBox.Show("Sorry staff ID is required!");
            else if(txtStaffName.Text==string.Empty)
                MessageBox.Show("Sorry staff name is required!");
           // else if (cboRecommended.Text==string.Empty)
               // MessageBox.Show("Sorry you must select yes/no from the recommend dropdown!");
            else
            {

                dalHeper.ClearParameters();
                dalHeper.BeginTransaction();
                try
                {
                    dalHeper.CreateParameter("@id", excuseDutyRequest.id, DbType.Int32);
                    dalHeper.CreateParameter("@Recommend", chkRecommended.Checked, DbType.Boolean);
                    dalHeper.CreateParameter("@RecommendedById", GlobalData.User.ID, DbType.Int32);
                    dalHeper.CreateParameter("@AdditionalComment", txtComment.Text.Trim(), DbType.String);
                    dalHeper.CreateParameter("@RecommendationDate", datePickerStartDate.Value.Date, DbType.Date);
                    dalHeper.CreateParameter("@SupervisorId", excuseDutyRequest.SupervisorId, DbType.Int32);

                    dalHeper.ExecuteNonQuery("update ExcusedDutyRequest set SupervisorId=@SupervisorId,Recommended=@Recommend,RecommendedById=@RecommendedById,RecommendationDate=@RecommendationDate,AdditionalComment=@AdditionalComment where id=@id");
                    dalHeper.CommitTransaction();
                    MessageBox.Show("Excuse Duty Recommendation Saved Successfully!");
                    clear();
                    this.Close();
                }
                catch (Exception exi)
                {
                    dalHeper.RollBackTransaction();
                    MessageBox.Show("Sorry Excuse Duty Recommendation Was Not Saved!");
                }
          
            }
        }

        public void setExcuseDutyRequest(ExcuseDutyRequest newExcuseDutyRequest,ExcuseDutyRecommendation parentForm){
            try
            {
                this.parentForm = parentForm;
                this.excuseDutyRequest = newExcuseDutyRequest;
                txtStaffID.Text = excuseDutyRequest.SupervisorEmpCode;

                if (txtStaffID.Text == string.Empty){
                    MessageBox.Show(this, "A Supervisor Must Be Specified For Requesting Staff/ (His or Her) Department\n You Cannot Recommend!");

                }
                else
                {
                    txtStaffName.Text = excuseDutyRequest.SupervisorName;
                    txtComment.Text = excuseDutyRequest.AdditionalComment;
                    chkRecommended.Checked = (excuseDutyRequest.Recommended == false) ? true : excuseDutyRequest.Recommended;
                    datePickerStartDate.Value = Information.IsDate(excuseDutyRequest.RecommendationDate) ? excuseDutyRequest.RecommendationDate.Value : DateTime.Now.Date;
                
                }
             
            }
            catch (Exception exi)
            {
                datePickerStartDate.Value = DateTime.Now.Date;
               // Logger.LogError(exi);
            }
           
        }

       /* private void txtStaffID_TextChanged(object sender, EventArgs e)
        {
            txtStaffName.Clear();
            if (txtStaffID.Text != string.Empty)
            {
                Supervisor = empDataMapper.GetByID(txtStaffID.Text);
                
                txtStaffName.Text = (Supervisor.FirstName + " " + Supervisor.OtherName).Trim() + " " + Supervisor.Surname;
            }
            
         
        }*/
        void clear()
        {
            txtStaffName.Clear();
            txtComment.Clear();
            datePickerStartDate.Value = DateTime.Now.Date;
            chkRecommended.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void ExcuseDutyRecommendationRemarks_Load(object sender, EventArgs e)
        {

        }
    }
}
