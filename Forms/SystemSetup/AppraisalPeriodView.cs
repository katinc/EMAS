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
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;
using Session_Framework;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalPeriodView : Form
    {
        private AppraisalPeriodDataMapper appraisalPeriodDataMapper;
        private IList<AppraisalPeriod> lstAppraisalPeriods;
        private DALHelper dalHelper;
        private AppraisalPeriodForm parentForm;
        public AppraisalPeriodView(AppraisalPeriodForm NewParentForm)
        {
            InitializeComponent();
            appraisalPeriodDataMapper = new AppraisalPeriodDataMapper();
            lstAppraisalPeriods = new List<AppraisalPeriod>();
            dalHelper = new DALHelper();
            parentForm = NewParentForm;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show(this, "Do You Really Want To Delete Record?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                     if (Information.IsNumeric(grid.CurrentRow.Cells["gridID"].Value))
                    {

                       var period= appraisalPeriodDataMapper.getDataById(Convert.ToInt32(grid.CurrentRow.Cells["gridID"].Value));
                       if (period.Code.ToLower() != "annual" && period.Code.ToLower() != "mid-year")
                       {
                           dalHelper.ClearParameters();
                           dalHelper.CreateParameter("@Id", period.Id, DbType.Int32);
                           dalHelper.ExecuteNonQuery("update AppraisalPeriods set Archived='true' where id=@Id");
                       }
                      
                    }

                    grid.Rows.Remove(grid.CurrentRow);
                    grid.ClearSelection();
                }
               
            }
            else
                MessageBox.Show("Sorry No Row Is Selected!");
        }

        private void AppraisalPeriodView_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData(){
            try
            {
                grid.Rows.Clear();
                lstAppraisalPeriods = appraisalPeriodDataMapper.getData();
                int ctr = 0;
                foreach (AppraisalPeriod dRow in lstAppraisalPeriods)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = dRow.Id;
                    grid.Rows[ctr].Cells["gridDescription"].Value = dRow.Description;
                    grid.Rows[ctr].Cells["gridYear"].Value = dRow.Year;
                    grid.Rows[ctr].Cells["gridType"].Value = dRow.Code;
                    grid.Rows[ctr].Cells["gridStartDate"].Value = dRow.StartDate.ToShortDateString();
                    grid.Rows[ctr].Cells["gridEndDate"].Value = dRow.EndDate.ToShortDateString();
                    grid.Rows[ctr].Cells["gridActive"].Value = dRow.Active;
                    ctr++;
                }
                grid.ClearSelection();
            }
            catch (Exception xi) { Logger.LogError(xi); }
           
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.SelectedRows.Count>0)
                {
                    parentForm.appraisalPeriod = appraisalPeriodDataMapper.getDataById(Convert.ToInt32(grid.SelectedRows[0].Cells["gridID"].Value));
                    parentForm.dtpStartDate.Value = parentForm.appraisalPeriod.StartDate;
                    parentForm.dtpEndDate.Value = parentForm.appraisalPeriod.EndDate;
                    parentForm.txtDescription.Text = parentForm.appraisalPeriod.Description;
                    parentForm.chkActive.Checked = parentForm.appraisalPeriod.Active;
                    parentForm.nudYear.Value = parentForm.appraisalPeriod.Year;
                    parentForm.cmbType.SelectedItem = parentForm.appraisalPeriod.Code;
                }
                else
                    MessageBox.Show("Soory: No Record Is Selected!");
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            grid.ClearSelection();
        }
    }
}
