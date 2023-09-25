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
    public partial class Towns : Form
    {
        private DALHelper dal;
        private IDAL idal;
        private DataTable regionsTable;
        private DataTable districtsTable;
        private DataTable townsTable;

        public Towns()
        {
            try
            {
                InitializeComponent();
                dal = new DALHelper();
                idal = new DAL();
                dal.OpenConnection();
                regionsComboBox.DropDown += new EventHandler(regionsComboBox_DropDown);
                districtsComboBox.DropDown += new EventHandler(districtsComboBox_DropDown);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void districtsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (regionsComboBox.Text.Trim() != string.Empty)
                {
                    dal.OpenConnection();
                    districtsTable = dal.ExecuteReader("Select * from districts where RegionID = " + regionsTable.Rows[regionsComboBox.SelectedIndex]["ID"].ToString() + " And Archived='False' and Active = 'True' Order by Description ASC");

                    districtsComboBox.Items.Clear();
                    foreach (DataRow row in districtsTable.Rows)
                    {
                        districtsComboBox.Items.Add(row["Description"].ToString());
                    }
                }
                grid.Rows.Clear();
                groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void regionsComboBox_DropDown(object sender, EventArgs e)
        {
            try
            {
                regionsComboBox.Items.Clear();
                foreach (DataRow row in regionsTable.Rows)
                {
                    regionsComboBox.Items.Add(row["Description"].ToString());
                }
                districtsComboBox.Items.Clear();
                districtsComboBox.Enabled = false;
                grid.Rows.Clear();
                groupBox1.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Towns_Load(object sender, EventArgs e)
        {
            this.Text = GlobalData.Caption;
            try
            {
                regionsTable = dal.ExecuteReader("Select * from Regions where Active= 'True' and Archived = 'False' order by Description ASC");
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private bool ValidateFields()
        {
            bool result = true;
            try
            {
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
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
            return result;
        }

        private void GetData()
        {
            try
            {
                if (districtsComboBox.Text.Trim() != string.Empty)
                {
                    dal.OpenConnection();
                    townsTable = dal.ExecuteReader("Select * from towns where DistrictID = " + districtsTable.Rows[districtsComboBox.SelectedIndex]["ID"].ToString() + " And Archived='False' and Active= 'True' Order by Description ASC");

                    int ctr = 0;
                    grid.Rows.Clear();
                    foreach (DataRow row in townsTable.Rows)
                    {
                        grid.Rows.Add(1);
                        grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                        grid.Rows[ctr].Cells["gridDescription"].Value = row["Description"];
                        grid.Rows[ctr].Cells["gridCode"].Value = row["Code"];
                        grid.Rows[ctr].Cells["gridDistrictID"].Value = row["DistrictID"];
                        grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"];
                        ctr++;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["gridID"].Value != null)
                    {
                        try
                        {
                            
                            if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                            {
                                dal.ExecuteNonQuery("Update Towns Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dal.ExecuteNonQuery("Update Towns Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void regionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (regionsComboBox.Text.Trim() != string.Empty)
                {
                    districtsComboBox.Enabled = true;
                }
                else
                {
                    districtsComboBox.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void districtsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (districtsComboBox.Text.Trim() != string.Empty)
                {
                    groupBox1.Enabled = true;
                    try
                    {
                        GetData();
                    }
                    catch (Exception ex)
                    {
                        string err = ex.Message;
                    }
                }
                else
                {
                    groupBox1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateFields())
                {
                    dal.BeginTransaction();
                    int districtID = int.Parse(districtsTable.Rows[districtsComboBox.SelectedIndex]["ID"].ToString());
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@Description", row.Cells["gridDescription"].Value.ToString(), DbType.String);
                            dal.CreateParameter("@Code", row.Cells["gridCode"].Value.ToString(), DbType.String);
                            dal.CreateParameter("@DistrictID", districtID, DbType.Int32);
                            dal.CreateParameter("@Active", true, DbType.Boolean);
                            dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.ExecuteNonQuery("Insert Into Towns(Description,Code,DistrictID,UserID,Active) Values(@Description,@Code,@DistrictID,@UserID,@Active)");
                            }
                            else
                            {
                                dal.CreateParameter("@ID", row.Cells["gridID"].Value.ToString(), DbType.Int32);
                                dal.ExecuteNonQuery("Update Towns Set Description=@Description,Code=@Code,DistrictID=@DistrictID,UserID=@UserID,Active=@Active where ID=@ID");
                            }
                        }
                    }
                    GetData();
                    dal.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                dal.RollBackTransaction();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Districts form = new Districts();
            form.MdiParent = this.MdiParent;
            form.Show();
        }
    }
}
