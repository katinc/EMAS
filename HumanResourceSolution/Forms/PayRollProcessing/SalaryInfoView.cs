using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRDataAccessLayer;
using HRDataAccessLayer.System_Setup_Data_Control;
using HRBussinessLayer.Staff_Information_CLASS;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class SalaryInfoView : Form
    {
        private IDAL dal;
        private SalaryInfoNew newForm;
        private StaffSalaryHistory salaryInfo;
        private IList<StaffSalaryHistory> salaryInfos;

        public SalaryInfoView()
        {
            try
            {
                InitializeComponent();
                this.Text = GlobalData.Caption;
                this.newForm = new SalaryInfoNew();
                this.dal = new DAL();
                this.salaryInfo = new StaffSalaryHistory();
                this.salaryInfos = new List<StaffSalaryHistory>();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }

        }
        public SalaryInfoView(SalaryInfoNew newForm)
        {
            try
            {
                InitializeComponent();
                this.Text = GlobalData.Caption;
                this.newForm = newForm;
                this.dal = new DAL();
                this.salaryInfo = new StaffSalaryHistory();
                this.salaryInfos=new List<StaffSalaryHistory>();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void SalaryInfoView_Load(object sender, EventArgs e)
        {
            try
            {
                GetAll();
                this.grid.DoubleClick += new EventHandler(grid_DoubleClick);
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    newForm.GetInfoToUpdate(grid.CurrentRow);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void GetAll()
        {
            try
            {
                salaryInfos=dal.GetAll<StaffSalaryHistory>();
                grid.DataSource = salaryInfos;
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["ID"].Visible = false;
                    grid.Columns["GradeID"].Visible = false;
                    grid.Columns["SupervisorID"].Visible = false;
                    grid.Columns["DepartmentID"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (GlobalData.QuestionMessage("Are sure you want to delete this item") == DialogResult.Yes)
                    {
                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            salaryInfo.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            salaryInfo.Archived = true;
                            dal.Delete(salaryInfo);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);

                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            salaryInfo.ID = int.Parse(grid.CurrentRow.Cells["gridID"].Value.ToString());
                            salaryInfo.Archived = true;
                            dal.Delete(salaryInfo);
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);


                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
