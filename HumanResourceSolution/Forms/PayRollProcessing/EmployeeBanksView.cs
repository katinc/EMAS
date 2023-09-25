using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using HRBussinessLayer.ErrorLogging;
using HRDataAccessLayer;

namespace eMAS.Forms.PayRollProcessing
{
    public partial class EmployeeBanksView : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private Employee_Banks newForm;

        public EmployeeBanksView()
        {
            try
            {
                InitializeComponent();
                this.newForm = new Employee_Banks();
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public EmployeeBanksView(Employee_Banks newForm)
        {
            try
            {
                InitializeComponent();
                this.newForm = newForm;
                this.dalHelper = new DALHelper();
                this.dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmployeeBanksView_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["Name"].Value.ToString() + "'s selected banking information?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dalHelper.ExecuteNonQuery("Delete from StaffBanks Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dalHelper.ExecuteNonQuery("Delete from StaffBanks Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                    catch (Exception ex)
                    {
                        string err = ex.Message;
                    }
                }
            }
        }
    }
}
