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
    public partial class Districts : Form
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

        public Districts()
        {
            InitializeComponent();
            dalHelper = new DALHelper();
            dal = new DAL();
            districtsTable = new DataTable();
            regionsTable = new DataTable();
            regionComboBox.DropDown += new EventHandler(regionComboBox_DropDown);
        }

        void regionComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                regionComboBox.Items.Clear();
                foreach (DataRow row in regionsTable.Rows)
                {
                    regionComboBox.Items.Add(row["Description"].ToString());
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dalHelper.BeginTransaction();
                    int regionID = int.Parse(regionsTable.Rows[regionComboBox.SelectedIndex]["ID"].ToString());
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            dalHelper.ClearParameters();
                            dalHelper.CreateParameter("@Description", row.Cells["gridDescription"].Value.ToString(), DbType.String);
                            dalHelper.CreateParameter("@Code", row.Cells["gridCode"].Value == null ? string.Empty : row.Cells["gridCode"].Value.ToString(), DbType.String);
                            dalHelper.CreateParameter("@RegionID", regionID, DbType.Int32);
                            dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                            dalHelper.CreateParameter("@Active", true, DbType.Boolean);
                            if (row.Cells["gridID"].Value == null)
                            {
                                dalHelper.ExecuteNonQuery("Insert Into Districts(Description,Code,RegionID,UserID,Active) Values(@Description,@Code,@RegionID,@UserID,@Active)");
                            }
                            else
                            {
                                dalHelper.CreateParameter("@ID", row.Cells["gridID"].Value.ToString(), DbType.Int32);
                                dalHelper.ExecuteNonQuery("Update Districts Set Description=@Description,Code=@Code,RegionID=@RegionID,UserID=@UserID,Active=@Active where ID=@ID");
                            }
                        }
                    }
                    GetData();
                    dalHelper.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            errorProvider.Clear();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells["gridDescription"].Value.ToString().Trim() == string.Empty)
                    {
                        result = false;
                        errorProvider.SetError(groupBox1, "Please enter a description on row " + (row.Index + 1));
                    }
                    if (row.Cells["gridCode"].Value == null)
                    {
                        row.Cells["gridCode"].Value = string.Empty;
                    }
                }
            }
            return result;
        }

        private void Districts_Load(object sender, EventArgs e)
        {
            //GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);
            this.Text = GlobalData.Caption;
            try
            {
                dal.OpenConnection();
                regionsTable = dalHelper.ExecuteReader("Select * from regions where Active = 'True' and Archived='False'");
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            var getPermissions = GlobalData._context.UserAccessLevelsViews.SingleOrDefault(u => u.AccessLevel3Control == GlobalData.ItemControl && u.RoleName == GlobalData.Role);
            if (getPermissions != null)
            {
                btnSave.Enabled = getPermissions.CanAdd;
                deleteButton.Enabled = getPermissions.CanDelete;
                CanDelete = getPermissions.CanDelete;
                CanEdit = getPermissions.CanEdit;
                CanAdd = getPermissions.CanAdd;
                CanPrint = getPermissions.CanPrint;
                CanView = getPermissions.CanView;
            }
        }

        private void GetData()
        {
            if (regionComboBox.Text.Trim() != string.Empty)
            {
                dalHelper.OpenConnection();
                districtsTable = dalHelper.ExecuteReader("Select * from districts where RegionID = " + regionsTable.Rows[regionComboBox.SelectedIndex]["ID"].ToString() + " And Archived='False' and Active= 'True' Order by Description ASC");

                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in districtsTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                    grid.Rows[ctr].Cells["gridDescription"].Value = row["Description"];
                    grid.Rows[ctr].Cells["gridCode"].Value = row["Code"];
                    grid.Rows[ctr].Cells["gridRegionID"].Value = row["RegionID"];
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"];
                    ctr++;
                }
            }
        }

        private void regionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetData();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (grid.CurrentRow != null)
            {
                if (grid.CurrentRow.Cells["gridID"].Value != null)
                {
                    try
                    {                        
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dalHelper.ExecuteNonQuery("Update Districts Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dalHelper.ExecuteNonQuery("Update Districts Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
        }
    }
}
