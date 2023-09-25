using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.Staff_Information_CLASS;
using HRDataAccessLayerBase;
using Session_Framework;

namespace eMAS.Forms.EmployeeManagement
{
    public partial class ExcuseDutyResumptionDetailsForm : Form
    {
        private ExcuseDutyRequest excuseDutyRequest;
        private ExcuseDutyReturnForm parentForm;

        private DALHelper dalHelper;
        public ExcuseDutyResumptionDetailsForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void setExcuseDutyRequest(ExcuseDutyRequest newExcuseDutyRequest,ExcuseDutyReturnForm parentForm){
            try
            {
                this.excuseDutyRequest = newExcuseDutyRequest;
                this.parentForm = parentForm;
                txtResumptionReason.Text = excuseDutyRequest.ResumptionReason;
                chkReturned.Checked =(excuseDutyRequest.Returned==false)?true: excuseDutyRequest.Returned;
                datePickerEndDate.Text = excuseDutyRequest.ResumptionDate.ToString();
                
            }
            catch (Exception ei)
            {
                datePickerEndDate.Value = DateTime.Now;
                //Logger.LogError(ei);
            }
      
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            try
            {
                //dalHelper = new DALHelper();
                //dalHelper.CreateParameter("@id", excuseDutyRequest.id, DbType.Int32);
                //dalHelper.CreateParameter("@Returned", chkReturned.Checked, DbType.Boolean);
                //dalHelper.CreateParameter("@ResumptionReason", txtResumptionReason.Text, DbType.String);
                //dalHelper.CreateParameter("@ResumptionDate", datePickerEndDate.Value.Date, DbType.Date);

                //dalHelper.ExecuteNonQuery("update ExcusedDutyRequest set Returned=@Returned,ResumptionReason=@ResumptionReason,ResumptionDate=@ResumptionDate where id=@id");

                var excuse = GlobalData._context.ExcusedDutyRequests.SingleOrDefault(u => u.id == excuseDutyRequest.id);

                excuse.Returned = chkReturned.Checked;
                excuse.ResumptionDate = datePickerEndDate.Value.Date;
                excuse.ResumptionReason = txtResumptionReason.Text;

                GlobalData._context.SubmitChanges();
                MessageBox.Show(this, "Staff Resumed Successfully");
                this.Close();
            }
            catch(Exception ei)
            {
                MessageBox.Show(this, "Error: Unable to Resume Staff Contact Administrator");
                Logger.LogError(ei);
            }
            parentForm.btnRefresh_Click(sender, e);
        }
    }
}
