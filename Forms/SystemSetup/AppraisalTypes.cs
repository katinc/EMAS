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

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalTypes : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;

        public AppraisalTypes()
        {
            try
            {
                InitializeComponent();
                dalHelper = new DALHelper();
                dal = new DAL();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void AppraisalPeriod_Load(object sender, EventArgs e)
        {
            try
            {
                GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
                this.Text = GlobalData.Caption;
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in dalHelper.ExecuteReader("Select ID,Description From AppraisalTypes Where Archived = 'False'").Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                    grid.Rows[ctr].Cells["gridDescription"].Value = row["Description"];
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    dalHelper.ClearParameters();
                    if (grid.CurrentRow.Cells["gridID"].Value == null)
                    {
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dalHelper.CreateParameter("@Description", grid.CurrentRow.Cells["gridDescription"].Value, DbType.String);
                        dalHelper.ExecuteNonQuery("Insert Into AppraisalTypes(Description,UserID) Values(@Description,@UserID)");
                    }
                    else
                    {
                        dalHelper.CreateParameter("@ID", grid.CurrentRow.Cells["gridID"].Value, DbType.Int32);
                        dalHelper.CreateParameter("@Description", grid.CurrentRow.Cells["gridDescription"].Value, DbType.String);
                        dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                        dalHelper.ExecuteNonQuery("Update AppraisalTypes Set Description=@Description ,UserID=@UserID Where ID=@ID");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                try
                {
                    
                    if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                    {
                        dalHelper.ExecuteNonQuery("Update AppraisalTypes Set Archived = 'True' Where ID =" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        grid.Rows.RemoveAt(grid.CurrentRow.Index);
                    }
                    else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                    {
                        dalHelper.ExecuteNonQuery("Update AppraisalTypes Set Archived = 'True' Where ID =" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
