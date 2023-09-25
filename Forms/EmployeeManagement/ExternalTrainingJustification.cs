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
    public partial class ExternalTrainingJustification : Form
    {
        private ExternalTraining externalTraining;
        private DALHelper dalHelper;
        private EmployeeDataMapper employeeDataMapper;
        ExternalTrainingJustificationView parentForm;
        public ExternalTrainingJustification(ExternalTraining externalTraining, ExternalTrainingJustificationView parentForm)
        {
            InitializeComponent();
            this.externalTraining = externalTraining;
            this.dalHelper = new DALHelper();
            this.parentForm = parentForm;
            this.employeeDataMapper = new EmployeeDataMapper();
            if (this.externalTraining.HOD != null && this.externalTraining.HOD.ID > 0)
            {
                txtHODStaffID.Text = this.externalTraining.HOD.StaffID;
                txtHODName.Text = (this.externalTraining.HOD.FirstName + " " + this.externalTraining.HOD.OtherName).Trim() + " " + this.externalTraining.HOD.Surname;
                txtJustification.Text = this.externalTraining.Justification;
                dtpJustificationDate.Value = this.externalTraining.JustificationDate;
                chkJustify.Checked = this.externalTraining.isJustified;
            }
            else if (this.externalTraining.Staff.Department.SupervisorCode != null)
            {
                this.externalTraining.HOD = employeeDataMapper.GetByID(this.externalTraining.Staff.Department.SupervisorID);
                txtHODStaffID.Text = this.externalTraining.Staff.Department.SupervisorCode;
                txtHODName.Text = (this.externalTraining.Staff.Department.SupervisorFirstName + " " + this.externalTraining.Staff.Department.SupervisorOtherName).Trim() + " " + this.externalTraining.Staff.Department.SupervisorLastName;
            }
            else
            {
                MessageBox.Show(this, "Sorry You Must Specify Supervisor For " + this.externalTraining.Staff.Department.Description);
                this.Close();
            }
        }

        private void ExternalTrainingJustification_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHODStaffID.Text == string.Empty)
                MessageBox.Show("HOD ID Is Required!");
            else if (txtHODName.Text == string.Empty)
                MessageBox.Show("HOD Name Is Required!");
            else if (txtJustification.Text == string.Empty)
                MessageBox.Show("Justification Is Required!");
            else if(MessageBox.Show(this,"Do You Really Want To Justify This Training?","Confirm!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@HODId", externalTraining.HOD.ID, DbType.Int32);
                dalHelper.CreateParameter("@Justification", txtJustification.Text, DbType.String);
                dalHelper.CreateParameter("@isJustified", chkJustify.Checked, DbType.Boolean);
                dalHelper.CreateParameter("@JustificationDate", dtpJustificationDate.Value.Date, DbType.Date);
                dalHelper.CreateParameter("@ID", externalTraining.ID, DbType.Int32);

                dalHelper.ExecuteNonQuery("update ExternalTraining set HODId=@HODId,Justification=@Justification,isJustified=@isJustified,JustificationDate=@JustificationDate where ID=@ID");
                parentForm.gridViewInfo.CurrentRow.Cells["gridHODName"].Value = txtHODName.Text;
                parentForm.gridViewInfo.CurrentRow.Cells["gridHODJustification"].Value = txtJustification.Text;
                parentForm.gridViewInfo.CurrentRow.Cells["gridHODJustificationDate"].Value = dtpJustificationDate.Value.ToShortDateString();
                Clear();
                Close();
            }
        }

        private void Clear()
        {
            txtJustification.Clear();
            txtHODStaffID.Clear();
            txtHODName.Clear();
            dtpJustificationDate.ResetText();
            chkJustify.Checked = true;
        }
    }
}
