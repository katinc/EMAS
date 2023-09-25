using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRDataAccessLayerBase;
using Microsoft.VisualBasic;
using Session_Framework;

namespace eMAS.Forms.SystemSetup
{
    public partial class AppraisalRatingsForm : Form
    {
        private DALHelper dalHelper;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;


        public AppraisalRatingsForm()
        {
            InitializeComponent();
            this.dalHelper = new DALHelper();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dRow in grid.Rows)
                {
                    InsertUpdate(dRow);
                }
                MessageBox.Show("Changes Saved Successfully!");
            }
            catch (Exception xi)
            {
                MessageBox.Show("Unable To Save Changes!");
            }
        }
        private void loadGrid()
        {
            try
            {
                grid.Rows.Clear();
                dalHelper = new DALHelper();
                dalHelper.ClearParameters();
                dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                DataTable dt = dalHelper.ExecuteReader("select * from AppraisalRatings where Archived=@Archived");

                int ctr = 0;
                foreach (DataRow dRow in dt.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = dRow["id"].ToString();
                    grid.Rows[ctr].Cells["gridRating"].Value = dRow["Rating"].ToString();
                    grid.Rows[ctr].Cells["gridValue"].Value =dRow["value"]!=DBNull.Value ? dRow["value"].ToString() : string.Empty;
                    grid.Rows[ctr].Cells["gridAvgMin"].Value =dRow["avgmin"]!=DBNull.Value ? dRow["avgmin"].ToString() : string.Empty;
                    grid.Rows[ctr].Cells["gridAvgMax"].Value =dRow["avgmax"]!=DBNull.Value ? dRow["avgmax"].ToString() : string.Empty;
                    grid.Rows[ctr].Cells["gridOveralMin"].Value =dRow["overalmin"]!=DBNull.Value ?  dRow["overalmin"].ToString() : string.Empty;
                    grid.Rows[ctr].Cells["gridOveralMax"].Value =dRow["overalmax"]!=DBNull.Value ? dRow["overalmax"].ToString() : string.Empty;
                    ctr++;
                }
            }
            catch (Exception xi) { Logger.LogError(xi); }

        }
        private void InsertUpdate(DataGridViewRow dRow)
        {
            try
            {
                if (Information.IsNumeric(dRow.Cells["gridValue"].Value))
                {
                    dalHelper = new DALHelper();
                    dalHelper.ClearParameters();
                    dalHelper.CreateParameter("@Rating", dRow.Cells["gridRating"].Value.ToString(), DbType.String);
                    dalHelper.CreateParameter("@Value", Convert.ToDecimal(dRow.Cells["gridValue"].Value), DbType.Decimal);
                    dalHelper.CreateParameter("@AvgMin", Convert.ToDecimal(dRow.Cells["gridAvgMin"].Value), DbType.Decimal);
                    dalHelper.CreateParameter("@AvgMax", Convert.ToDecimal(dRow.Cells["gridAvgMax"].Value), DbType.Decimal);

                    dalHelper.CreateParameter("@OveralMin", Convert.ToDecimal(dRow.Cells["gridOveralMin"].Value), DbType.Decimal);
                    dalHelper.CreateParameter("@OveralMax", Convert.ToDecimal(dRow.Cells["gridOveralMax"].Value), DbType.Decimal);

                    if (Information.IsNumeric(dRow.Cells["gridID"].Value))
                    {
                        dalHelper.CreateParameter("@Id", Convert.ToInt32(dRow.Cells["gridID"].Value), DbType.Int32);
                        dalHelper.ExecuteNonQuery("update AppraisalRatings set Rating=@Rating,OveralMax=@OveralMax,OveralMin=@OveralMin,Value=@Value,avgmin=@AvgMin,avgmax=@AvgMax where Id=@Id");
                    }
                    else
                    {
                        dalHelper.CreateParameter("@Archived", false, DbType.Boolean);
                        dalHelper.ExecuteNonQuery("insert into AppraisalRatings (Rating,Value,Archived,avgmin,avgmax,OveralMin,OveralMax) values(@Rating,@Value,@Archived,@AvgMin,@AvgMax,@OveralMin,@OveralMax)");

                    }
                }
            }
            catch (Exception xi) {  }
           

        }

        private void AppraisalRatingsForm_Load(object sender, EventArgs e)
        {
            loadGrid();

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                btnDelete.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (Information.IsNumeric(grid.CurrentRow.Cells["gridID"].Value))
                    {
                        dalHelper = new DALHelper();
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@Id", Convert.ToInt32(grid.CurrentRow.Cells["gridID"].Value), DbType.Int32);
                        dalHelper.ExecuteNonQuery("delete from AppraisalRatings where id=@Id");
                    }
                    grid.Rows.Remove(grid.CurrentRow);
                }
                else
                    MessageBox.Show("Sorry! No Row Is Selected!");
            }
            catch (Exception xi)
            {
                Logger.LogError(xi);
            }
           
        }
    }
}
