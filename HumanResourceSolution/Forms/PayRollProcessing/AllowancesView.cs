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
    public partial class AllowancesView : Form
    {
        private DALHelper dal;
        private IDAL idal;
        private AllowanceNew  newForm;
        private bool found;

        public AllowancesView()
        {
            try
            {
                InitializeComponent();
                this.newForm = new AllowanceNew();
                this.dal = new DALHelper();
                this.idal = new DAL();
                this.found = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public AllowancesView(AllowanceNew newForm)
        {
            try
            {
                InitializeComponent();
                this.newForm = newForm;
                this.dal = new DALHelper();
                this.found = false;
            }
            catch(Exception ex)
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

        private void AllowancesView_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetAll();
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
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
                string queryString = "Select StaffAllowances.ID,StaffAllowances.TypeID,StaffAllowances.StaffID,StaffPersonalInfo.FirstName +' '+ StaffPersonalInfo.OtherName +' '+ StaffPersonalInfo.Surname  as Name,Allowance_Setup.Description,StaffAllowances.Amount,StaffAllowances.EffectiveDate,StaffAllowances.Frequency,StaffAllowances.InUse From StaffAllowances Inner Join Allowance_Setup on Allowance_Setup.AID= StaffAllowances.TypeId Inner Join StaffPersonalInfo on StaffPersonalInfo.StaffId = StaffAllowances.StaffID Where Archived='False' ";
                if (GlobalData.User.UserCategory.Description == "Basic")
                {
                    found = true;
                }
                if (found == true)
                {
                    queryString += " and UserID = '" + GlobalData.User.ID + "' ";
                }

                grid.DataSource = dal.ExecuteReader(queryString.ToString());
                if (grid.ColumnCount > 0)
                {
                    grid.Columns["ID"].Visible = false;
                    grid.Columns["TypeID"].Visible = false;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete " + grid.CurrentRow.Cells["Name"].Value.ToString() + "'s selected allowance?", GlobalData.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dal.ExecuteNonQuery("Delete from StaffAllowances Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dal.ExecuteNonQuery("Delete from StaffAllowances Where ID =" + grid.CurrentRow.Cells["ID"].Value.ToString());
                            grid.Rows.RemoveAt(grid.CurrentRow.Index);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        } 
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                    }
                }
            }
        }
    }
}
