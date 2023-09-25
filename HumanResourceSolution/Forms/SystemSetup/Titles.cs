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
    public partial class Titles : Form
    {
        private DALHelper dal;
        private DataTable titlesTable;
        private DataTable gendersTable;
        private IDAL idal;

        public Titles()
        {
            try
            {
                InitializeComponent();
                dal = new DALHelper();
                gendersTable = new DataTable();
                idal = new DAL();
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                grid.CurrentCellDirtyStateChanged += new EventHandler(grid_CurrentCellDirtyStateChanged);
            }
            catch(Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                if (grid.CurrentCell.ColumnIndex == 2)
                {
                    foreach (DataRow row in gendersTable.Rows)
                    {
                        if (row["Description"].ToString() == grid.CurrentCell.Value.ToString())
                        {
                            try
                            {
                                grid.CurrentRow.Cells["gridGenderID"].Value = row["ID"];
                            }
                            catch (Exception ex)
                            {
                                string err = ex.Message;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grid.CurrentCell.ColumnIndex == 2)
                {
                    gridGender.Items.Clear();
                    foreach (DataRow row in gendersTable.Rows)
                    {
                        gridGender.Items.Add(row["Description"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
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
            if (grid.CurrentRow != null)
            {
                if (grid.CurrentRow.Cells["gridID"].Value != null)
                {
                    try
                    {                       
                        if (GlobalData.User.UserCategory.Description == "Intermediate" && GlobalData.User.ID == int.Parse(grid.CurrentRow.Cells["gridUserID"].Value.ToString()))
                        {
                            dal.ExecuteNonQuery("Update Titles Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        }
                        else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                        {
                            dal.ExecuteNonQuery("Update Titles Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                        }
                        else
                        {
                            MessageBox.Show("You do not have Permission to Delete Entries made by other Users");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.LogError(ex);
                        throw ex;
                    }
                }
                if (grid.CurrentRow.Cells["gridDescription"].Value != null)
                {
                    grid.Rows.RemoveAt(grid.CurrentRow.Index);
                }
            }
        }

        private void Titles_Load(object sender, EventArgs e)
        {
            try
            {
                dal.ClearParameters();
                titlesTable = dal.ExecuteReader("Select Titles.*,GenderGroups.Description as Gender from Titles Inner Join GenderGroups on GenderGroups.ID = Titles.GenderGroupID Where Archived = 'false'");
                gendersTable = dal.ExecuteReader("Select * from GenderGroups");
                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in titlesTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"].ToString();
                    grid.Rows[ctr].Cells["gridDescription"].Value = row["Description"].ToString();
                    gridGender.Items.Add(row["Gender"].ToString());
                    grid.Rows[ctr].Cells["gridGender"].Value = row["Gender"].ToString();
                    grid.Rows[ctr].Cells["gridGenderID"].Value = row["GenderGroupID"].ToString();
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"].ToString();
                    ctr++;
                }
                GlobalData.SetFormPermissions(this, idal, GlobalData.User.ID);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            if (ValidateFields())
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        try
                        {
                            dal.ClearParameters();
                            dal.CreateParameter("@Description", row.Cells["gridDescription"].Value, DbType.String);
                            dal.CreateParameter("@GenderGroupID", row.Cells["gridGenderID"].Value, DbType.Int32);
                            dal.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);
                            dal.CreateParameter("@Active", true, DbType.Boolean);

                            if (row.Cells["gridID"].Value == null)
                            {
                                dal.ExecuteReader("Insert Into Titles(Description,GenderGroupID,UserID,Active) Values(@Description,@GenderGroupID,@UserID,@Active)");
                            }
                            else
                            {
                                dal.ExecuteReader("Update Titles Set Description = @Description,GenderGroupID=@GenderGroupID,UserID=@UserID,Active=@Active Where ID = " + row.Cells["gridID"].Value.ToString());
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex);
                        }
                    }
                }
                Titles_Load(this, EventArgs.Empty);
            }
        }

        private bool ValidateFields()
        {
            try
            {
                bool result = true;
                errorProvider.Clear();
                return result;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                throw ex;
            }
        }
    }
}
