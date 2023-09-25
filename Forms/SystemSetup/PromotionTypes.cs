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
    public partial class PromotionTypes : Form
    {
        DALHelper dalHelper;
        DataTable districtsTable;
        DataTable regionsTable;
        IDAL dal;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;

        public PromotionTypes()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            dal = new DAL();
        }

        private void PromotionTypes_Load(object sender, EventArgs e)
        {
            try
            {
                getData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }
        }

        private void getData()
        {
            try
            {
                var promotionTypes = GlobalData._context.PromotionTypes.Where(u=>u.Active).ToList();

                int ctr = 0;
                grid.Rows.Clear();
                foreach (var row in promotionTypes)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row.ID;
                    grid.Rows[ctr].Cells["gridDescription"].Value = row.Description;
                    ctr++;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                //throw;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dalHelper.BeginTransaction();
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        dalHelper.ClearParameters();
                        dalHelper.CreateParameter("@Description", row.Cells["gridDescription"].Value.ToString(), DbType.String);
                        dalHelper.CreateParameter("@Active", true, DbType.Boolean);

                        if (row.Cells["gridID"].Value == null)
                        {
                            //dalHelper.CreateParameter("@ID", GlobalData._context.PromotionTypes.Last().ID + 1, DbType.Int32);
                            dalHelper.ExecuteNonQuery("Insert Into PromotionTypes(Description,Active) Values(@Description,@Active)");
                        }
                        else
                        {
                            dalHelper.CreateParameter("@ID", row.Cells["gridID"].Value.ToString(), DbType.Int32);
                            dalHelper.ExecuteNonQuery("Update PromotionTypes Set Description=@Description,Active=@Active where ID=@ID");
                        }
                    }
                }
                dalHelper.CommitTransaction();
                getData();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dalHelper.RollBackTransaction();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null )
            {
                if (grid.CurrentRow.Cells["gridID"].Value != null)
                {
                    try
                    {                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dalHelper.ExecuteNonQuery("Update PromotionTypes Set Active='False' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dalHelper.ExecuteNonQuery("Update PromotionTypes Set Active='False' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
                if (grid.CurrentRow.Cells["gridDescription"].Value != null)
                {
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
            }
            dalHelper.CommitTransaction();
        }
    }
}
