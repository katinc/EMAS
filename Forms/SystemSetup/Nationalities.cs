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
using System.Configuration;

namespace eMAS.Forms.SystemSetup
{
    public partial class Nationalities : Form
    {
        private DALHelper dalHelper;
        private IDAL dal;
        private DataTable nationalitiesTable;

        private bool CanEdit;
        private bool CanAdd;
        private bool CanDelete;
        private bool CanPrint;
        private bool CanView;
        DataGridView oldDT;

        public Nationalities()
        {
            try
            {
                InitializeComponent();
                dalHelper = new DALHelper();
                dal = new DAL();
                nationalitiesTable = new DataTable();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        private void Nationalities_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = GlobalData.Caption;
                GetAll();
               // GlobalData.SetFormPermissions(this, dal, GlobalData.User.ID);

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
                oldDT = new DataGridView();
                oldDT = GlobalData.CopyDataGridView(grid);

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
                if (true)
                {
                    foreach (DataGridViewRow row in grid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells["gridID"].Value == null)
                            {
                                var nationality = new DataReference.Nationality
                                {
                                    Description = row.Cells["gridDescription"].Value.ToString(),
                                    //Active = (bool)row.Cells["gridActive"].FormattedValue,
                                    DateAndTimeGenerated = DateTime.Now,
                                    UserID = GlobalData.User.ID
                                };
                                GlobalData._context.Nationalities.InsertOnSubmit(nationality);
                            }
                            else
                            {
                                int nationalityID = int.Parse(row.Cells["gridID"].Value.ToString());

                                var updateTT = GlobalData._context.Nationalities.SingleOrDefault(u => u.ID == nationalityID);
                                updateTT.Description = row.Cells["gridDescription"].Value.ToString();
                                //updateTT.Active = (bool)row.Cells["gridActive"].FormattedValue;
                            }
                        }
                    }
                    GlobalData._context.SubmitChanges();
                    MessageBox.Show("Saved Successfully");
                    GetAll();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                MessageBox.Show("ERROR:Not Save Successfully");
            }
            ////grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //int ctr = 0;
            //foreach (DataGridViewRow row in grid.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        try
            //        {
            //            var desc = row.Cells["gridDescription"].Value.ToString();
            //            string description = row.Cells["gridDescription"].Value.ToString().Substring(0, 1).ToUpper() 
            //                + row.Cells["gridDescription"].Value.ToString().Substring(1, row.Cells["gridDescription"].Value.ToString().Length - 1).ToLower();

            //            dalHelper.OpenConnection();
            //            dalHelper.ClearParameters();
            //            dalHelper.CreateParameter("@Description", description, DbType.String);
            //            dalHelper.CreateParameter("@UserID", GlobalData.User.ID, DbType.Int32);

            //            if (grid.CurrentRow.Cells["gridID"].Value == null)
            //            {
            //                dalHelper.ExecuteNonQuery("Insert Into Nationalities(Description,UserID) Values(@Description,@UserID)");
            //            }
            //            else
            //            {
            //                var nationalId = int.Parse(row.Cells["gridID"].Value.ToString());
            //                if (ConfigurationManager.AppSettings["RequestChanges"].ToLower() == "true")
            //                {
            //                    GlobalData.ProcessGridEdit(oldDT.Rows[ctr], row, nationalId, this);
            //                }
            //                else
            //                {
            //                    dalHelper.CreateParameter("@ID", nationalId, DbType.Int32);
            //                    dalHelper.ExecuteNonQuery("Update Nationalities Set Description=@Description, UserID=@UserID Where ID=@ID");
            //                }
            //            }
            //            GetAll();
            //        }
            //        catch (Exception ex)
            //        {
            //            Logger.LogError(ex);
            //        }
            //    }
            //    ctr++;
            //}

        }

        private void GetAll()
        {
            try
            {
                nationalitiesTable = dalHelper.ExecuteReader("Select * from Nationalities where Archived='False' Order by Description ASC");

                int ctr = 0;
                grid.Rows.Clear();
                foreach (DataRow row in nationalitiesTable.Rows)
                {
                    grid.Rows.Add(1);
                    grid.Rows[ctr].Cells["gridID"].Value = row["ID"];
                    grid.Rows[ctr].Cells["gridDescription"].Value = row["Description"];
                    grid.Rows[ctr].Cells["gridUserID"].Value = row["UserID"];
                    ctr++;
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
                                dalHelper.ExecuteNonQuery("Update Nationalities Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
                            }
                            else if (GlobalData.User.UserCategory.Description == "Basic" || GlobalData.User.UserCategory.Description == "Advance")
                            {
                                dalHelper.ExecuteNonQuery("Update Nationalities Set Archived='True' Where ID=" + grid.CurrentRow.Cells["gridID"].Value.ToString());
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
    }
}
